using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Fruit;

internal class Avocado
{
    public string Name { get; } = "Avocado";
    private float Avocados { get; set; } = 0;
    private float AvocadosPerClick;

    public float ClickesAvocados(float value)
        => Avocados += value;

    public float GetAvocados()
        => Avocados;

    public float BuyAnyProd(float value)
        => Avocados -= value;
}

