using Avocado_Cliker.Fruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

internal class JorelsBrother : Product
{

    public JorelsBrother(string name) : base(name)
    {
        this.Price = 10f;
        this.QuantityProduct = 0;
        this.QuantiyGenerate = 0.8f;
    }

    public float UpdatePrice()
            => this.Price += this.QuantityProduct * QuantiyGenerate;


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
