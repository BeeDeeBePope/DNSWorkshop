using System.Collections.Generic;

public class ShortObjectFactory : AbstractFactory
{
    public List<Product> products;

    public override List<Product> GetProducts()
    {
        return products;
    }
}