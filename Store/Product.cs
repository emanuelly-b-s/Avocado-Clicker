using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal class Product
{
    public int Level;
    public float Price;

    public string Name { get; }

    public Product(string name) => this.Name = name;

    public void GetCrrActual(Product p)
    {
        throw new NotImplementedException();
    }

    //public int GetLevelActual(Product p)
    //    => _levelConcrect.SetLevel();

    public int GetLevelActual(Product p)
    {
        throw new NotImplementedException();
    }
}