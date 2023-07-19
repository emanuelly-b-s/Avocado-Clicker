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
    RectangleF avocadoGeral = RectangleF.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;

    Point cursor = Point.Empty;
    bool isDown = false;

    private void Draw()
    {
        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);
        g.DrawImage(avocado, avocadoRect);

        if (avocadoRect.Contains(cursor) && isDown)
        {
            avocadoRect = avocadoIsDown;
        }
    }

    private void Clicker_Load(object sender, System.EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;

        bmp = new Bitmap(pb.Width, pb.Height);
        g = Graphics.FromImage(bmp);
        pb.Image = bmp;

        avocadoGeral = avocadoRect = new RectangleF(
            .02f * pb.Width, .02f * pb.Height,
            .12f * pb.Width, .12f * pb.Width
        );
        avocadoIsDown = new RectangleF(
            .02f * pb.Width, .02f * pb.Height,
            .09f * pb.Width, .09f * pb.Width
        );

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
    {
        isDown = true;

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
