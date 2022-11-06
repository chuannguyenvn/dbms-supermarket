using System;
using System.Collections.Generic;

public class ProductOrder_Item
{
    public event Action<int> UpdateCount;
    public Product Product;
    private int count;
    public int Count
    {
        get => count;
        set
        {
            count = value;
            UpdateCount?.Invoke(count);
        }
    }
    
    public int Price => Product.Price * Count;
    
    public ProductOrder_Item(Product product, int count)
    {
        Product = product;
        Count = count;
    }
    
    
}