using System;
using System.Collections.Generic;

public class ProductOrder_Item
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

    private List<ProductView_Item> views = new();

    public ProductOrder_Item(Product product, int count)
    {
        Product = product;
        Count = count;
    }

    public void AssignViewItem(ProductView_Item viewItem)
    {
        views.Add(viewItem);
    }
}