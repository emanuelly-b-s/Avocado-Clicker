using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal class GrannyJuju : Product
{
    public string Name { get; }
    private int _level;
    private float _priceConcrect;

    public GrannyJuju(string name) : base(name) => Name = name;

    
}
