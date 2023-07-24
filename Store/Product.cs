using Avocado_Cliker.Fruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

public abstract class Product
{
    protected Avocado avocado = new Avocado();

    public int Level;
    public float Price { get; set; }
    public int Quantity { get; set; }
    public float QuantiyPerClick { get; set; } = 0;
    public string Name { get; set; }

    public Product(string name)
        => this.Name = name;


    public float UpdatePrice()
        => this.Price += this.Quantity
                         * .2f
                         + this.Price
                         * .3f
                         + this.Level;

    public void AddProduct()
        => Quantity++;

    public float GetPrice()
        => this.Price;

    public float UpdateLevel(int value)
    {
        this.Level += value;
        this.Price += this.Quantity
                        * .2f
                        + this.Price
                        * .3f
                        + this.Level;

        this.QuantiyPerClick += this.Level * 2f + this.Quantity * 0.05f;

        avocado.UpdateGenerated(QuantiyPerClick);

        return this.QuantiyPerClick;
    }

    public float GetQuantityPerClick()
        => this.QuantiyPerClick;
}