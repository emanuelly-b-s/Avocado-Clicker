using Avocado_Cliker.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avocado_Cliker.Marketplace;

namespace Avocado_Cliker;

public class Game
{
    public float Avocados { get; private set; } = 0;
    public float AvocadoPerClick { get; private set; } = 1;

    private List<Product> Products { get; set; } = new List<Product>();

    private Game() { }

    private static Game instance;

    private Store MyStore { get; set; }


    private Product Product { get; set; }

    
    public static Game Current
    {
        get
        {
            if(instance == null)
            {
                instance = new Game();
                GrannyJuju grannyJuju = new GrannyJuju("vovo");
                instance.Products.Add(grannyJuju);
                instance.Products.Add(grannyJuju);
                instance.Products.Add(grannyJuju);
            }
            return instance;
        }
    }


    public void Click() 
        => Avocados += AvocadoPerClick;
    

    public void BuyProduct(Product p)
        => p.AddProduct();

    public int GetQuantity(Product p)
        => p.Quantity;

    public List<Product> GetProducts() 
        => this.Products;
}
