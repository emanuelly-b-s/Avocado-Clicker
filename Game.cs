using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker;

public class Game
{
    public int Avocados { get; private set; }


    public void Click()
    {
        Avocados++;
    }
}
