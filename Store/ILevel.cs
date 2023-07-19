using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal interface ILevel
{
    void SetLevel();
}

public abstract class LevelConcrect : ILevel
{
    // Product _product;
    int _crrLevel { get; set; } = 0;
    public void SetLevel() => _crrLevel += 1;
    // public int GetLevel(_product p) => this._crrLevel;
}
