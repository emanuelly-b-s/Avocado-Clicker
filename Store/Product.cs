using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

public class Product
{
    public int Level;
    public float Price;
    public int Quantity;
    public string Name { get; }

    private Store _store;
    public Product(string name) => this.Name = name;

    public void AddProduct()
        => Quantity++;

    public void AddNewProduct(Product p)
        => _store.AddProduct(p);

    public int GetLevelActual()
    {
        throw new NotImplementedException();
    }
}