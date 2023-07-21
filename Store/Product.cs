using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

public class Product
{
    public int Level;
    public float Price;
    public int Quantity;
    public string Name { get; }

    public Product(string name) => this.Name = name;

    public void AddProduct()
        => Quantity += 1;

    //public List<Product> GetProducts(Product p)
    //    => myProducts.GetProducts(p);

    public void GetCrrActual(Product p)
    {
        throw new NotImplementedException();
    }


    public int GetLevelActual()
    {
        throw new NotImplementedException();
    }
}