using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Avocado_Cliker.Fruit;
using Avocado_Cliker.Store;

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

    }

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

    Product grannyJuju = new GrannyJuju("teste");
    Avocado avocado = new Avocado();

    Point cursor = Point.Empty;

    bool isDown = false;
    bool inAvocadoDown = false;

    LinearGradientBrush linGrBrush = new LinearGradientBrush(
       new Point(0, 10),
       new Point(200, 10),
       Color.FromArgb(255, 255, 0, 0),
       Color.FromArgb(255, 0, 0, 255)
    );


    private void Draw()
    {

        Pen pen = new Pen(linGrBrush);
        //g.DrawRectangle(pen, 100, 100, Width, Height);
        StringFormat drawFormat = new StringFormat();
        drawFormat.Alignment = StringAlignment.Center;
        RectangleF drawRect = new RectangleF(100, 50, Width, Height);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial", 16);


        // Draw string to screen.
        g.DrawString(Game.Current.GetQuantity(grannyJuju).ToString(), drawFont, drawBrush, drawRect, drawFormat);
        pb.Refresh();

        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);
        g.DrawImage(avocadoPicture, avocadoRect);
        g.DrawImage(bgStore, productReact);

        g.DrawImage(grannyPicture, grannyRect);


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
        {
            Game.Current.BuyProduct(grannyJuju);


 
            //foreach (var item in myProducts)
            //{
            //    Console.WriteLine(item);
            //}
        }

    }

    private void Clicker_Load(object sender, System.EventArgs e)
    {

        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;

        float heightRectStore = .20f * pb.Height;
        bmp = new Bitmap(pb.Width, pb.Height);

        g = Graphics.FromImage(bmp);
        pb.Image = bmp;

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

        //granny states
        grannyRect = new RectangleF(
            .92f * pb.Width, heightRectStore,
            .08f * pb.Width, .08f * pb.Width
        );

        productReact = new RectangleF(
            .85f * pb.Width, heightRectStore,
            .15f * pb.Width, .15f * pb.Height
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
