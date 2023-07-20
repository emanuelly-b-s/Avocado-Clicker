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
        vovoJujuPhoto = Bitmap.FromFile("../../../Images/Product/GannerJuju.png") as Bitmap;
        avocado = Bitmap.FromFile("../../../Images/avocado.png") as Bitmap;

    }

    Avocado avocado_Clicker = new();
    Graphics g = null;
    bool running = true;

    Bitmap bg = null;
    Bitmap avocado = null;
    Bitmap bmp = null;
    Bitmap vovoJujuPhoto = null;


    RectangleF avocadoRect = Rectangle.Empty;
    RectangleF avocadoStandar = RectangleF.Empty;
    RectangleF avocadoIsDown = RectangleF.Empty;
    RectangleF avocadoUp = RectangleF.Empty;
    RectangleF vovoPhoto = RectangleF.Empty;


    Product vovoJuju = new VovoJuju("teste");
    Point cursor = Point.Empty;
    bool isDown = false;

    private void Draw()
    {
        g.DrawImage(bg, 0, 0, pb.Width, pb.Height);
        g.DrawImage(avocado, avocadoRect);

        g.DrawImage(vovoJujuPhoto, vovoPhoto);

        if (vovoPhoto.Contains(cursor))
            MessageBox.Show(vovoJuju.Name);

        if (avocadoRect.Contains(cursor) && isDown)
            avocadoRect = avocadoIsDown;


        if (avocadoRect.Contains(cursor) && !isDown)
            avocadoRect = avocadoUp;


    }

    private void Clicker_Load(object sender, System.EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;

        VovoJuju vovoJuju = new VovoJuju("vovo");

        bmp = new Bitmap(pb.Width, pb.Height);
        g = Graphics.FromImage(bmp);
        pb.Image = bmp;

        avocadoStandar = new RectangleF(
            .03f * pb.Width, .058f * pb.Height,
            .11f * pb.Width, .11f * pb.Width
        );


        avocadoRect = new RectangleF(
            .03f * pb.Width, .08f * pb.Height,
            .11f * pb.Width, .11f * pb.Width
        );

        avocadoIsDown = new RectangleF(
            .02f * pb.Width, .02f * pb.Height,
            .106f * pb.Width, .106f * pb.Width
        );

        avocadoUp = new RectangleF(
            .02f * pb.Width, .02f * pb.Height,
            .11f * pb.Width, .11f * pb.Width
          );

        vovoPhoto = new RectangleF(
            .20f * pb.Width, .20f * pb.Height,
            .11f * pb.Width, .11f * pb.Width
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
