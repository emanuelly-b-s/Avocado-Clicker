using System.Windows.Forms;
using Avocado_Cliker.Fruit;

namespace Avocado_Cliker;

public partial class Clicker : Form
{
    public Clicker()
    {
        InitializeComponent();
    }

    Avocado avocado_Clicker = new();


    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void avocado_clicker(object sender, System.EventArgs e)
    {
        avocado_Clicker.SetClickers(1);
        float count_clickers = avocado_Clicker.GetClicker();
        clickerTxt.Text = count_clickers.ToString();
    }

    private void label1_Click(object sender, System.EventArgs e)
    {

    }
}
