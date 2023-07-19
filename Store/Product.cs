using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Avocado_Cliker.Store;

internal class Product : IProduct, IPrice, ILevel
{
    private int _level;
    private float _priceConcrect;

    public string Name { get; }

    public Product(string name) =>  this.Name = name;
    
    public void GetCrrActual(Product p)
    {
        throw new NotImplementedException();
    }

    public int GetLevelActual(Product p)
        => this._level;

    public float GetPriceActual(Product p)
        => this._priceConcrect;
    public void SetLevel()
        => this._level += 1;

    public void SetPrice(float p)
        => this._priceConcrect = p;

}
