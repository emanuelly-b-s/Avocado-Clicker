using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Fruit;

internal class Avocado : IFruit
{
    public string Name { get; } = "Avocado";
    private float Clickers { get; set; }
    public float clickersPerSecund;

    public float SetClickers(float value) => Clickers += value;

    public float GetClicker() => Clickers;

}

