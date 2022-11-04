using System.Collections.Generic;

public class ProductManager : Singleton<ProductManager>
{
    public List<Product> Products;
}