using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal interface IStore
{
    string Name { get; }
    int _crrActual { get; }

    int GetCrrActual(Product p);

}

