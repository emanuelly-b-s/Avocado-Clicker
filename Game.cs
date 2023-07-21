using Avocado_Cliker.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker;

public class Game
{
    public float Avocados { get; private set; } = 0;
    public float AvocadoPerClick { get; private set; } = 1;

    private Game() { }
    private static Game instance;

    private GrannyJuju GrannyJuju { get; set; }
    
    public static Game Current
    {
        get
        {
            if(instance == null)
                instance = new Game();

            return instance;
        }
    }

    public void Click() 
            => Avocados += AvocadoPerClick;

    public void BuyGrannyJuju()
        => GrannyJuju.GetLevelActual();
    
}
