using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal interface IManufacturing : IStore
{
    string Name { get; }
    List<Product> Products { get; set; }

}

