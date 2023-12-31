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
        grannyProduction = Bitmap.FromFile("../../../Images/Product/granny2.png") as Bitmap;
        irmaoDoJorelPicture = Bitmap.FromFile("../../../Images/Product/irmaoDoJorel.png") as Bitmap;
        irmaoDoJorelProduction = Bitmap.FromFile("../../../Images/Product/vovoEirmaoDoJorel.png") as Bitmap;

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
    Bitmap irmaoDoJorelPicture = null;
    Bitmap irmaoDoJorelProduction = null;


    RectangleF avocadoRect = Rectangle.Empty;
    RectangleF avocadoStandar = RectangleF.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;
    RectangleF avocadoUp = RectangleF.Empty;
    RectangleF productsRect = RectangleF.Empty;
    RectangleF storeRect = RectangleF.Empty;
    RectangleF productionReact = RectangleF.Empty;
    RectangleF grannyProductionReact = RectangleF.Empty;
    RectangleF irmaoDoJorelProductionRect = RectangleF.Empty;

    Point cursor = Point.Empty;

    bool isDown = false;
    bool inAvocadoDown = false;
    bool inProductDown = false;

    //infos Granny
    private static readonly List<Product> listProducts = Game.Current.GetProducts();
    private readonly Product granny = listProducts.Find(p => p.Name == "GrannyJuju");
    private readonly Product jorelsBrother = listProducts.Find(p => p.Name == "Irm�o do Jorel");

    private void Draw()
    {
        var tst = 0;

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

        RectangleF drawInfoProduct = new RectangleF(
            storeRect.X,
            storeRect.Y + 10,
            storeRect.Width / 3,
            heightRectStore / 2
          );

        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial Narrow Regular", 14, FontStyle.Bold);

        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);
        g.DrawImage(avocadoPicture, avocadoRect);

        var realStoreRect = new RectangleF(
            storeRect.X, storeRect.Y,
            storeRect.Width, 
            storeRect.Height * listProducts.Count
         );

        g.DrawImage(bgStore, realStoreRect);
        int k = 0;

        foreach (var item in listProducts)
        {
            var y = realStoreRect.Y;

            var realProductsRect = new RectangleF(
                        productsRect.X, y + k * productsRect.Height,
                        productsRect.Width, productsRect.Width
            );

            var realDrawInfoProduct = new RectangleF(
                realStoreRect.X + (realStoreRect.Width * .05f),
                realStoreRect.Y +  k * productsRect.Height,
                realStoreRect.Width / 3,
                heightRectStore / 2
            );

            k++;


            if (realProductsRect.Contains(cursor) && isDown)
                inProductDown = true;

            switch (item)
            {

                case GrannyJuju gran:
                 
                    g.DrawImage(grannyPicture, realProductsRect);
                    g.DrawString("Price: " + Game.Current.GetPrice(granny).ToString("#.00"), drawFont, drawBrush,
                        realDrawInfoProduct, stringFormat);

                    if (realProductsRect.Contains(cursor) && !isDown && inProductDown)
                    {
                        inProductDown = false;
                        Game.Current.BuyProduct(granny, 1);
                    }

                    break;

                case JorelsBrother irmaoDoJorel:
                    g.DrawImage(irmaoDoJorelPicture, realProductsRect);
                    g.DrawString("Price: " + Game.Current.GetPrice(irmaoDoJorel).ToString("#.00"), drawFont, drawBrush,
                        realDrawInfoProduct, stringFormat);

                    if (realProductsRect.Contains(cursor) && !isDown && inProductDown)
                    {
                        inProductDown = false;
                        Game.Current.BuyProduct(jorelsBrother, 1);
                    }

                    break;
            }
        }

        g.DrawString(Game.Current.CountAvocados().ToString("#.00").ToString(), drawFont, drawBrush, totalAvocadoRect, stringFormat);

        int c = 0;
        foreach (var item in listProducts)
        {
            if (item.QuantityProduct != 0)
            {
                
                var realProductionRect = new RectangleF(
                            productionReact.X, productionReact.Y + c * productionReact.Height,
                            productionReact.Width, productionReact.Height
                 );
                c++;

                switch (item)
                {
                    case GrannyJuju granny:

                        Brush pen1 = new SolidBrush(Color.FromArgb(222, 253, 247));

                        var grannyProductionWidth = productionReact.Width / 7;
                        var grannyProductionHeight = productionReact.Height ;

                        g.FillRectangle(pen1, realProductionRect);

                        for (int i = 0; i < (int)granny.QuantityProduct; i++)
                        {
                            var x = productionReact.X + (grannyProductionWidth - 5) * i;
                            if (x  > productionReact.Width)
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

                    case JorelsBrother irmaoDoJorel:

                        Brush pen2 = new SolidBrush(Color.FromArgb(255, 255, 209));

                        var irmaoDoJorelProductionWidth = productionReact.Width / 5;
                        var irmaoDoJorelProductionHeight = productionReact.Height;

                        g.FillRectangle(pen2, realProductionRect);

                        for (int i = 0; i < (int)irmaoDoJorel.QuantityProduct; i++)
                        {
                            var x = productionReact.X + (irmaoDoJorelProductionWidth - 5) * i;
                            if (x > productionReact.Width)
                                break;

                            var y = realProductionRect.Y + productionReact.Height - irmaoDoJorelProductionHeight;

                            var irmaoDoJorelRect = new RectangleF(
                                x,
                                y,
                                irmaoDoJorelProductionWidth,
                                irmaoDoJorelProductionHeight
                            );

                            g.DrawImage(irmaoDoJorelProduction, irmaoDoJorelRect);
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

        storeRect = new RectangleF(
            pb.Width - (.25f * pb.Width), pb.Height * .10f,
            pb.Width - (pb.Width - (.25f * pb.Width)), .15f * pb.Height
        );

        RectangleF drawInfosGranny = new RectangleF(
            storeRect.X,
            storeRect.Y + 10,
            storeRect.Width / 10,
            heightRectStore / 2
          );

        //rect products
        productsRect = new RectangleF(
            storeRect.X + storeRect.Width - storeRect.Width / 3,
            storeRect.Y,
            storeRect.Width / 3,
            storeRect.Height
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
           (avocadoRect.Width + avocadoRect.X) + ((avocadoRect.Width + avocadoRect.X) * .2f),
           pb.Height * .10f,
           pb.Width - (avocadoRect.Width + storeRect.Width) - (avocadoRect.Width + storeRect.Width) * .2f,
           .20f * pb.Height
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
                running = false;
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
