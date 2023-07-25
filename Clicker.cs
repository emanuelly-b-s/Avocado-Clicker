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

    }

    Bitmap bgGarden = null;
    Graphics g = null;
    bool running = true;
    Bitmap bg = null;
    Bitmap bmp = null;
    Bitmap avocadoPicture = null;
    Bitmap grannyPicture = null;
    Bitmap bgStore = null;

    RectangleF avocadoRect = Rectangle.Empty;
    RectangleF avocadoStandar = RectangleF.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;
    RectangleF avocadoUp = RectangleF.Empty;
    RectangleF grannyRect = RectangleF.Empty;
    RectangleF productReact = RectangleF.Empty;
    RectangleF productionReact = RectangleF.Empty;


    Point cursor = Point.Empty;

    bool isDown = false;
    bool inAvocadoDown = false;
    bool inProductDown = false;

    //LinearGradientBrush linGrBrush = new LinearGradientBrush(
    //   new Point(0, 10),
    //   new Point(200, 10),
    //   Color.FromArgb(255, 255, 0, 0),
    //   Color.FromArgb(255, 0, 0, 255)
    //);

    //infos Granny
    private static readonly List<Product> listProducts = Game.Current.GetProducts();
    private readonly Product granny = listProducts.Find(p => p.Name == "GrannyJuju");
    private float priceGranny;


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


        RectangleF drawRecte = new RectangleF(50, 50, Width, Height);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial Narrow Regular", 14, FontStyle.Bold);


        RectangleF drawInfosGranny = new RectangleF(productReact.X + 3, productReact.Y + 10, productReact.Width / 2, heightRectStore / 2);


        //foreach (var item in listProducts)
        //{
        //g.DrawString(item.Name + item.Price.ToString(), drawFont, drawBrush, drawRecte, stringFormat);
        //    pb.Refresh();
        //}

        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);

        g.DrawImage(avocadoPicture, avocadoRect);
        g.DrawImage(bgStore, productReact);


        //g.DrawString(": " + granny.QuantiyPerClick, drawFont, drawBrush, productReact, stringFormat);
        g.DrawString("Price: " + Game.Current.GetPrice(granny).ToString("#.00"), drawFont, drawBrush, drawInfosGranny, stringFormat);
        g.DrawString("\n\nGenerate +: " + Game.Current.GetGenerateClickes(granny), drawFont, drawBrush, drawInfosGranny, stringFormat);
        g.DrawString(Game.Current.CountAvocados().ToString("#.00").ToString(), drawFont, drawBrush, totalAvocadoRect, stringFormat);


        if (granny is not null)
        {
            priceGranny = granny.Price;
            g.DrawImage(grannyPicture, grannyRect);
            //g.DrawString("Price: " + priceGranny.ToString(), drawFont, drawBrush, productReact, stringFormat)
        }


        foreach (var item in listProducts)
        {
            if (item.QuantityProduct != 0)
            {
                switch (item)
                {
                    case GrannyJuju granny:
                        g.DrawImage(bgGarden, productionReact);
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
            //Game.Current.BuyProduct(granny);
            //Game.Current.UpdatePrice(granny);
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


        //rect products
        productReact = new RectangleF(
            .85f * pb.Width, heightRectStore,
            .15f * pb.Width, .15f * pb.Height
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
        grannyRect = new RectangleF(
            .92f * pb.Width, heightRectStore,
            .08f * pb.Width, .08f * pb.Width
        );

        productionReact = new RectangleF(
           .25f * pb.Width, pb.Height * .10f,
           .50f * pb.Width, .20f * pb.Height
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
