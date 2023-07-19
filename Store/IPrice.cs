using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avocado_Cliker.Store;

internal interface IPrice
{
    void SetPrice(float p);
}

public abstract class PriceConcrect : IPrice
{
    float _price { get; set; } = 0;

    public void SetPrice(float price) => _price = price; 
}
