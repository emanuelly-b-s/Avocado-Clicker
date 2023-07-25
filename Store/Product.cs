using Avocado_Cliker.Fruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

public abstract class Product
{

    public int Level;
    public float Price { get; set; }
    public float QuantityProduct { get; set; }
    public float QuantiyGenerating { get; set; } = 0;
    public float QuantiyGenerate { get; set; } = 0;
    public string Name { get; set; }

    public Product(string name)
        => this.Name = name;


    public float UpdatePrice()
        => this.Price += this.QuantityProduct
                         * .02f
                         + this.Price
                         * .3f
                         + this.Level;

    public void AddProduct()
        => QuantityProduct++;

    public float GetPrice()
        => this.Price;

    public float UpdateLevel(int value)
    {
        this.Level += value;
        this.Price += this.QuantityProduct
                         * .02f
                         + this.Price
                         * .3f
                         + this.Level;


        this.QuantiyGenerating += (this.Level / 0.5f)
                                * 0.02f 
                                + (this.QuantityProduct / .10f)
                                * 0.0005f;

        return this.QuantiyGenerating;
    }
}