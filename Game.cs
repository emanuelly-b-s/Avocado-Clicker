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


    private Game()
    {
        //foreach (var item in product)
        //{
        //    MyStore.AddProduct(item);
        //}
    }

    private static Game instance;

    private Store MyStore { get; set; }

     GrannyJuju grannyJuju = new GrannyJuju("vovo");

    private Product Product { get; set; }

    
    public static Game Current
    {
        get
        {
            if(instance == null)
                instance = new Game(
                    );

            return instance;
        }
    }


    public void Click() 
        => Avocados += AvocadoPerClick;
    


    public void BuyProduct(Product p)
        => p.AddProduct();

    public int GetQuantity(Product p)
        => p.Quantity;
}
