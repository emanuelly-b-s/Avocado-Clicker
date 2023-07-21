using Avocado_Cliker.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avocado_Cliker.Store;

namespace Avocado_Cliker;

public class Game
{
    public float Avocados { get; private set; } = 0;
    public float AvocadoPerClick { get; private set; } = 1;

    private Game() { }
    private static Game instance;

    private GrannyJuju GrannyJuju { get; set; }

    private Product product { get; set; }
    
    public static Game Current
    {
        get
        {
            if(instance == null)
                instance = new Game();

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
