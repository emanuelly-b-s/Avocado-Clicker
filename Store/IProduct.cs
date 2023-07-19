using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal interface IProduct 
{
    string Name { get; } 
    void GetCrrActual(Product p);

    int GetLevelActual (Product p);
    float GetPriceActual (Product p);

    // public 
    // List<> : 
}
