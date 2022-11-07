using UnityEngine;


public class ProductListView : ProductView
{
    protected override void Start()
    {
        base.Start();
        
        var margin = VisualManager.Instance.ProductListItemViewVerticalMargin;
        int count = 0;
        foreach (var (_, orderItem) in ProductOrderManager.Instance.Order)
        {
            var productListItemView =
                Instantiate(ResourceManager.Instance.ProductListItemView, transform)
                    .GetComponent<ProductListView_Item>();

            productListItemView.AssignProduct(orderItem);
            var viewRectTransform = productListItemView.GetComponent<RectTransform>();
            var height = viewRectTransform.rect.height;
            viewRectTransform.anchoredPosition = new Vector2(0, -(count * height + margin));
            count++;
        }
    }
}