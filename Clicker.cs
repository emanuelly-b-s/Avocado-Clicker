using System.Drawing;
using System.Windows.Forms;
using Avocado_Cliker.Fruit;

namespace Avocado_Cliker;

public partial class Clicker : Form
{
    public Clicker()
    {
        InitializeComponent();

        bg = Bitmap.FromFile("../../../Images/Background/background.png") as Bitmap;
        avocado = Bitmap.FromFile("../../../Images/avocado.png") as Bitmap;
    }

    Avocado avocado_Clicker = new();
    Bitmap bmp = null;
    Graphics g = null;
    bool running = true;

    Bitmap bg = null;
    Bitmap avocado = null;
    RectangleF avocadoRect = Rectangle.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;

    Point cursor = Point.Empty;
    bool isDown = false;

    private void Draw()
    {
        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);
        g.DrawImage(avocado, avocadoRect);

        if (avocadoRect.Contains(cursor) && isDown)
        {
            g.DrawImage(avocado, avocadoIsDown);
        }
    }

    private void Clicker_Load(object sender, System.EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;

        bmp = new Bitmap(pb.Width, pb.Height);
        g = Graphics.FromImage(bmp);
        pb.Image = bmp;

        avocadoRect = new RectangleF(
            .02f * pb.Width, .02f * pb.Height,
            .12f * pb.Width, .12f * pb.Width
        );
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
    {
        isDown = true;
        avocadoIsDown = new RectangleF(.02f * pb.Width, .02f * pb.Height,
             .30f * pb.Width, .30f * pb.Width);

    }

    private void pb_MouseMove(object sender, MouseEventArgs e)
    {
        cursor = e.Location;
    }

    private void pb_MouseUp(object sender, MouseEventArgs e)
    {
        isDown = false;
    }
}
