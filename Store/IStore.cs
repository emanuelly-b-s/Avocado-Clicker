using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal interface IStore
{
    void AddProduct(Product product);
}

internal abstract class Store : IStore
{
    List<Product> newProducts { get; set; } 
    public void AddProduct(Product product)
        => newProducts.Add(product);
}

