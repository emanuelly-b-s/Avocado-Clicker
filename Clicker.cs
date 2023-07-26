using Avocado_Cliker.Marketplace;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Avocado_Cliker;

public partial class Clicker : Form
{
    public Clicker()
    {
        InitializeComponent();

        bg = Bitmap.FromFile("../../../Images/Background/background.png") as Bitmap;
        grannyPicture = Bitmap.FromFile("../../../Images/Product/Gann.png") as Bitmap;
        avocadoPicture = Bitmap.FromFile("../../../Images/avocado.png") as Bitmap;
        bgStore = Bitmap.FromFile("../../../Images/Background/bgStore.png") as Bitmap;
        bgGarden = Bitmap.FromFile("../../../Images/Background/gardem.png") as Bitmap;
        grannyProduction = Bitmap.FromFile("../../../Images/Product/granny.png") as Bitmap;

    }

    Bitmap bgGarden = null;
    Graphics g = null;
    bool running = true;
    Bitmap bg = null;
    Bitmap bmp = null;
    Bitmap avocadoPicture = null;
    Bitmap grannyPicture = null;
    Bitmap bgStore = null;
    Bitmap grannyProduction = null;

    RectangleF avocadoRect = Rectangle.Empty;
    RectangleF avocadoStandar = RectangleF.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;
    RectangleF avocadoUp = RectangleF.Empty;
    RectangleF grannyRect = RectangleF.Empty;
    RectangleF productReact = RectangleF.Empty;
    RectangleF productionReact = RectangleF.Empty;
    RectangleF grannyProductionReact = RectangleF.Empty;

    Point cursor = Point.Empty;

    bool isDown = false;
    bool inAvocadoDown = false;
    bool inProductDown = false;

    //infos Granny
    private static readonly List<Product> listProducts = Game.Current.GetProducts();
    private readonly Product granny = listProducts.Find(p => p.Name == "GrannyJuju");

    private void Draw()
    {
        float heightRectStore = .20f * pb.Height;

        var listProducts = Game.Current.GetProducts();

        //format strings 
        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        RectangleF totalAvocadoRect = new RectangleF(
            avocadoRect.X,
            avocadoRect.Y + avocadoRect.Height,
            avocadoRect.Width,
            30
        );

        RectangleF drawInfosGranny = new RectangleF(productReact.X,
            productReact.Y + 10,
            productReact.Width / 10,
            heightRectStore / 2
          );

        RectangleF drawRecte = new RectangleF(50, 50, Width, Height);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial Narrow Regular", 14, FontStyle.Bold);


        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);

        g.DrawImage(avocadoPicture, avocadoRect);
        g.DrawImage(bgStore, productReact);

        g.DrawString(Game.Current.CountAvocados().ToString("#.00").ToString(), drawFont, drawBrush, totalAvocadoRect, stringFormat);

        if (granny is not null)
        {
            g.DrawImage(grannyPicture, grannyRect);
            g.DrawString("Price: " + Game.Current.GetPrice(granny).ToString("#.00"), drawFont, drawBrush, drawInfosGranny, stringFormat);

            g.DrawString("\n\n\n\nGenerate +: " + Game.Current.GetGenerateClickes(granny), drawFont, drawBrush, drawInfosGranny, stringFormat);
        }

        foreach (var item in listProducts)
        {
            if (item.QuantityProduct != 0)
            {
                switch (item)
                {
                    case GrannyJuju granny:

                        var grannyProductionWidth = productionReact.Width / 15;
                        var grannyProductionHeight = productionReact.Height / 2;

                        g.DrawImage(bgGarden, productionReact);

                        for (int i = 0; i < (int)granny.QuantityProduct; i++)
                        {
                            var x = productionReact.X + 50 * i;
                            if (50 * (i - 2) > productionReact.Width)
                                break;

                            var y = productionReact.Y + productionReact.Height - grannyProductionHeight;
                            var grannyProductionReact = new RectangleF(
                                x,
                                y,
                                grannyProductionWidth,
                                grannyProductionHeight
                            );

                            g.DrawImage(grannyProduction, grannyProductionReact);
                        }

                        break;
                }
            }
        }

        if (avocadoRect.Contains(cursor) && isDown)
        {
            avocadoRect = avocadoIsDown;
            inAvocadoDown = true;
        }

        if (avocadoRect.Contains(cursor) && !isDown)
        {
            avocadoRect = avocadoUp;
            if (inAvocadoDown)
            {
                inAvocadoDown = false;
                Game.Current.Click();
            }
        }

        if (!avocadoRect.Contains(cursor))
            avocadoRect = avocadoStandar;


        if (grannyRect.Contains(cursor) && isDown)
            inProductDown = true;

        if (grannyRect.Contains(cursor) && !isDown && inProductDown)
        {
            inProductDown = false;
            Game.Current.BuyProduct(granny, 1);
        }
        pb.Refresh();
    }

    private void Clicker_Load(object sender, System.EventArgs e)
    {

        float heightRectStore = .20f * pb.Height;

        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;

        bmp = new Bitmap(pb.Width, pb.Height);

        g = Graphics.FromImage(bmp);
        pb.Image = bmp;

        productReact = new RectangleF(
            pb.Width - (.25f * pb.Width), pb.Height * .10f,
            pb.Width - (productReact.X), .15f * pb.Height
        );

        RectangleF drawInfosGranny = new RectangleF(
            productReact.X,
            productReact.Y + 10,
            productReact.Width / 10,
            heightRectStore / 2
          );

        //rect products
        grannyRect = new RectangleF(
            productReact.Width - 50,
            productReact.Y,
            50,
            productReact.Height
        );

        //avocado states
        avocadoStandar = new RectangleF(
            .03f * pb.Width, .03f * pb.Height,
            .10f * pb.Width, .10f * pb.Width
        );

        avocadoIsDown = new RectangleF(
            .0325f * pb.Width, .03f * pb.Height + .0075f * pb.Width / 2,
            .0925f * pb.Width, .0925f * pb.Width
        );

        avocadoUp = new RectangleF(
            .0275f * pb.Width, .03f * pb.Height - .0075f * pb.Width / 2,
            .1075f * pb.Width, .1075f * pb.Width
        );

        avocadoRect = avocadoStandar;

        //granny

        productionReact = new RectangleF(
           .25f * pb.Width, pb.Height * .10f,
           .50f * pb.Width, .20f * pb.Height
        );

        grannyProductionReact = new RectangleF(
            productionReact.Width,
            productionReact.Height,
            productionReact.Width / 15,
            productionReact.Height / 2
      );

        //key to exit
        KeyPreview = true;

        KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        };
    }

    private void Clicker_Shown(object sender, System.EventArgs e)
    {
        while (running)
        {
            Draw();
            Game.Current.Product();
            pb.Refresh();
            Application.DoEvents();
        }
    }

    private void pb_MouseDown(object sender, MouseEventArgs e)
        => isDown = true;

    private void pb_MouseMove(object sender, MouseEventArgs e)
        => cursor = e.Location;

    private void pb_MouseUp(object sender, MouseEventArgs e)
        => isDown = false;
}
