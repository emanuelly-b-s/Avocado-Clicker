using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

public class Product
{
    public int Level;
    public float Price { get; set; }
    public int Quantity;
    public string Name { get; set; }

    public Product(string name)
        => this.Name = name;

    public float UpdatePrice()
        => Price += Quantity * .05f;

    public void AddProduct()
        => Quantity++;

    public int GetLevelActual()
    {
        throw new NotImplementedException();
    }
}