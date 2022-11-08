using UnityEngine;


public class ProductListView : ProductView
{
    private const float VERTICAL_SPACE = 10f;

    protected override void Start()
    {
        base.Start();

        int count = 0;
        foreach (var (_, orderItem) in ProductOrderManager.Instance.Order)
        {
            var view = Instantiate(ResourceManager.Instance.ProductListItemView, transform)
                .GetComponent<ProductListItemView>();

            view.AssignProduct(orderItem);
            itemViews.Add(view);

            var viewRectTransform = view.GetComponent<RectTransform>();
            var height = viewRectTransform.rect.height;
            viewRectTransform.anchoredPosition = new Vector2(0, -(count * height + VERTICAL_SPACE));

            count++;
        }
    }
}