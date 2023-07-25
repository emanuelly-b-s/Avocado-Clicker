using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Fruit;

public class Avocado
{
    public string Name { get; } = "Avocado";
    public float Avocados { get; private set; } = 1;
    public float AvocadosPerClick { get; private set; } = 1;
    public float AvocadoProduction { get; private set; } = 0;

    public void AddProduction(float product)
        => this.AvocadoProduction += product;


    public void ClickesAvocados()
        => this.Avocados += AvocadosPerClick;

    public float GetAvocados()
        => this.Avocados;

    public void BuyAnyProd(float value)
       => this.Avocados -= value;


    public void UpdateGenerating(float value)
        => this.AvocadosPerClick += value;
    

    private DateTime last = DateTime.Now;
    public void Product()
    {
        var now = DateTime.Now;
        var time = now - last;
        var prod = time.TotalSeconds * AvocadoProduction;
        this.Avocados += (float)prod;
        last = now;
    }
}

