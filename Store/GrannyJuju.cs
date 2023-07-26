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
        this.QuantityProduct = 6;
        this.QuantiyGenerate = 0.5f;
    }

    public float UpdatePrice()
            => this.Price += this.QuantityProduct * .05f;

    public void AddProduct()
       => this.QuantityProduct++;

    public float UpdateLevel(int value)
    {
        this.Level += value;
        this.Price += this.QuantityProduct
                         * .02f
                         + this.Price
                         * .3f
                         + this.Level;


        this.QuantiyGenerating += this.QuantiyGenerate;


        return this.QuantiyGenerating;
    }

}
