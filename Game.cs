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
    public readonly Avocado Avocado = new Avocado();

    private List<Product> Products { get; set; } = new List<Product>();

    private readonly Product _Product;

    private Game() { }

    private static Game instance;
    
    public static Game Current
    {
        get
        {
            if(instance == null)
            {
                instance = new Game();
                Product grannyJuju = new GrannyJuju("GrannyJuju");
                instance.Products.Add(grannyJuju);
            }
            return instance;
        }
    }
    
    public void Click()
        => Avocado.ClickesAvocados();

    public void Product()
        => this.Avocado.Product();

    public void BuyProduct(Product p, int value)
    {
        if (Avocado.Avocados >= p.Price)
        {
            p.AddProduct();
            Avocado.BuyAnyProd(p.Price);
            p.UpdateLevel(value);

            Avocado.AddProduction(p.QuantiyPerClick);
        }
    }

    public float GetQuantity(Product p)
        => p.Quantity;

    public List<Product> GetProducts() 
        => this.Products;

    public float CountAvocados()
        => Avocado.Avocados;

    public float GetGeneratPerClick()
        => Avocado.Avocados;

    public void UpdatePrice(Product p)
        => p.UpdatePrice();

    public float GetPrice(Product p)
        => p.GetPrice();

    public float UpdateLevel(int value, Product p)
        => p.UpdateLevel(value);

}
