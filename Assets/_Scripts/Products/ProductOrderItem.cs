using System;
using System.Collections.Generic;

public class ProductOrderItem
{
    public Product Product { get; private set; }
    
    private int count;
    public int Count
    {
        get => count;
        set
        {
            count = value;
            foreach (var view in views)
            {
                view.UpdateQuantity(count);
            }
        }
    }
    
    public int Price => Product.Price * Count;

    private List<ProductViewItem> views = new();

    public ProductOrderItem(Product product, int count)
    {
        Product = product;
        Count = count;
    }

    public void AssignViewItem(ProductViewItem viewItem)
    {
        views.Add(viewItem);
    }
}