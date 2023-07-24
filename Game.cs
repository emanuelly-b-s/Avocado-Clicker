using Avocado_Cliker.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avocado_Cliker.Marketplace;
using Avocado_Cliker.Fruit;

namespace Avocado_Cliker;

public class Game
{
    Avocado Avocado = new Avocado();

    public float AvocadoPerClick { get; private set; } = 1;

    private List<Product> Products { get; set; } = new List<Product>();

    private Game() { }

    private static Game instance;
    
    public static Game Current
    {
        get
        {
            if(instance == null)
            {
                instance = new Game();
                GrannyJuju grannyJuju = new GrannyJuju("GrannyJuju");
                instance.Products.Add(grannyJuju);
            }
            return instance;
        }
    }


    public void Click()
        => Avocado.ClickesAvocados(AvocadoPerClick);

    public void BuyProduct(Product p)
    {
        if (Avocado.GetAvocados() >= p.Price)
        {
            p.AddProduct();
            Avocado.BuyAnyProd(p.Price);
        }
    }

    public int GetQuantity(Product p)
        => p.Quantity;

    public List<Product> GetProducts() 
        => this.Products;

    public float CountAvocados()
        => Avocado.GetAvocados();

    public void UpdatePrice(Product p)
        => p.UpdatePrice();
}
