using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker;

public class Game
{
    public float Avocados { get; private set; }
    public float AvocadoPerClick { get; private set; } = 1;

    private Game() { }
    private static Game instance;
    
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
    
}
