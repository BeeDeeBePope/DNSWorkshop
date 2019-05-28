using System.Collections.Generic;

public class TallObjectFactory : AbstractFactory
{
    public List<Product> products;

    public override List<Product> GetProducts()
    {
        return products;
    }
}