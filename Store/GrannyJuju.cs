using Avocado_Cliker.Fruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

internal class GrannyJuju : Product
{

    public GrannyJuju(string name) : base(name)
    {
        this.Price = 6f;
        this.Quantity = 5;
    }

    public float UpdatePrice()
        => this.Price += this.Quantity * .05f;

}
