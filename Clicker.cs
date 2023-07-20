using System.Drawing;
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
        grannyPicture = Bitmap.FromFile("../../../Images/Product/GannerJuju.png") as Bitmap;
        avocadoPicture = Bitmap.FromFile("../../../Images/avocado.png") as Bitmap;

    }

    Graphics g = null;
    bool running = true;

    Bitmap bg = null;
    Bitmap avocadoPicture = null;
    Bitmap bmp = null;
    Bitmap grannyPicture = null;

    RectangleF avocadoRect = Rectangle.Empty;
    RectangleF avocadoStandar = RectangleF.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;
    RectangleF avocadoUp = RectangleF.Empty;
    RectangleF grannyRect = RectangleF.Empty;


    Label label = new Label();


    Product grannyJuju = new GrannyJuju("teste");
    Avocado avocado = new Avocado();

    Point cursor = Point.Empty;
    
    bool isDown = false;
    bool inAvocadoDown = false;

    private void Draw()
    {
        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);
        g.DrawImage(avocadoPicture, avocadoRect);

        g.DrawImage(grannyPicture, grannyRect);

        // if (grannyRect.Contains(cursor))
        //MessageBox.Show(grannyJuju.GetLevelActual(grannyJuju).ToString());


        //animations to avocado
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
                // game.Click(); 
            }
        }

        if (!avocadoRect.Contains(cursor))
            avocadoRect = avocadoStandar;

        ////methods avocado
        //if (avocadoRect.Contains(cursor) && isDown)
        //{
        //    avocado.SetClickers(1);
        //    label.Text = (avocado.GetClicker().ToString());

        //    label.Show();

        //}

    }

    private void Clicker_Load(object sender, System.EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;


        bmp = new Bitmap(pb.Width, pb.Height);
        g = Graphics.FromImage(bmp);
        pb.Image = bmp;

        //label clicks

        label.Show();
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
            .20f * pb.Width, .20f * pb.Height,
            .11f * pb.Width, .11f * pb.Width
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
