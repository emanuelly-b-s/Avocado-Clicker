using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Fruit;

internal class Avocado : IFruit
{
    public string Name { get; }

    public float ClickersPerSecund { get; set; } = 0;

    public Avocado(string name) => Name = name;

    public void Clickers(float clicks) =>
        ClickersPerSecund += clicks;

}

