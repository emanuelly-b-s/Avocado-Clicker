using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Fruit;

public class Avocado
{
    public string Name { get; } = "Avocado";
    private float Avocados { get; set; } = 1;
    private float AvocadosPerClick { get; set; } = 1;

    public void ClickesAvocados()
        => this.Avocados += AvocadosPerClick;

    public float GetAvocados()
        => this.Avocados;

    public float BuyAnyProd(float value)
        => this.Avocados -= value;

    public void UpdateGenerated(float value)
        => this.AvocadosPerClick += value;

    public float GetGeneratedPerClick()
        => this.AvocadosPerClick;
}

