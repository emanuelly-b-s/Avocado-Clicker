using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avocado_Cliker.Marketplace;

internal interface ILevel
{
    void SetLevel(int lXp);
}

public abstract class LevelConcrect : ILevel
{
    int _initialLevel { get; set; } = 0;
    int _crrLevel { get; set; }
    public void SetLevel(int lXp) 
        => _crrLevel += lXp; 

    public int GetLevel () 
        => _crrLevel;
}
