using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

public interface IStore
{
    void AddProduct(Product product);
}

public class Store : IStore
{
    List<Product> newProducts { get; set; }

    public void AddProduct(Product product)
        => newProducts.Add(product);
}

