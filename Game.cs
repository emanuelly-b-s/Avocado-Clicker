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

    public List<Product> Products { get; private set; } = new List<Product>();

    private readonly Product _Product;

    private Game() { }

    private static Game instance;

    public static Game Current
    {
        get
        {
            if (instance == null)
            {
                instance = new Game();
                Product grannyJuju = new GrannyJuju("GrannyJuju");
                Product jorelsBrother = new JorelsBrother("Irmão do Jorel");
                instance.Products.Add(grannyJuju);
                instance.Products.Add(jorelsBrother);
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
            switch (p)
            {
                case GrannyJuju granny:
                    granny.AddProduct();
                    Avocado.BuyAnyProd(granny.Price);
                    granny.UpdateLevel(value);
                    Avocado.AddProduction(granny.QuantiyGenerating);
                    break;

                case JorelsBrother jorelsBrother:
                    jorelsBrother.AddProduct();
                    Avocado.BuyAnyProd(jorelsBrother.Price);
                    jorelsBrother.UpdateLevel(value);
                    Avocado.AddProduction(jorelsBrother.QuantiyGenerating);
                    break;
            } 
        }
    }

    public float GetQuantity(Product p)
        => p.QuantityProduct;

    public List<Product> GetProducts()
        => this.Products;

    public float CountAvocados()
        => Avocado.Avocados;

    public float GetGeneratePerClick()
        => Avocado.Avocados;

    public float GetPrice(Product p)
        => p.Price;

    public float UpdateLevel(int value, Product p)
        => p.UpdateLevel(value);

    public float GetGenerateClickes(Product p)
        => p.QuantiyGenerate;

}
