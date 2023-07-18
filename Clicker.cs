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
    }

    private void textBox1_TextChanged(object sender, System.EventArgs e)
    {
        textBox1.Text = avocado_Clicker.GetClicker().ToString();
    }
}
