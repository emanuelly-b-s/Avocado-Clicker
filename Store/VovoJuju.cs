using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal class VovoJuju : Product
{
    public string Name { get; }
    private int _level;
    private float _priceConcrect;

    public VovoJuju(string name) : base(name) => Name = name;
}
