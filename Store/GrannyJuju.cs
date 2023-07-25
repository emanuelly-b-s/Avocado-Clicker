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
        this.QuantityProduct = 5;
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


        this.QuantiyPerClick += (this.Level / 0.5f)
                                * 0.02f
                                + (this.QuantityProduct / .10f)
                                * 0.0005f;



        return this.QuantiyPerClick;
    }

}
