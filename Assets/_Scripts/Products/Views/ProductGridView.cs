using UnityEngine;


public class ProductGridView : ProductView
{
    private const float SIDE_MARGIN = 20f;
    private const float VERTICAL_SPACE = 10f;

    protected override void Start()
    {
        base.Start();

        int count = 0;
        foreach (var (_, orderItem) in ProductOrderManager.Instance.Order)
        {
            var view = Instantiate(ResourceManager.Instance.ProductGridItemView, transform)
                .GetComponent<ProductGridViewItem>();

            view.AssignProduct(orderItem);
            itemViews.Add(view);

            var viewRectTransform = view.GetComponent<RectTransform>();
            var height = viewRectTransform.rect.height;
            var verticalSpace = count == 0 ? 0 : VERTICAL_SPACE; // Exclude first.
            var posY = -(count / 2 * height + verticalSpace); 
            if (count % 2 == 0)
            {
                viewRectTransform.anchorMin = new Vector2(0, 1);
                viewRectTransform.anchorMax = new Vector2(0, 1);
                viewRectTransform.pivot = new Vector2(0, 1);
                viewRectTransform.anchoredPosition = new Vector2(SIDE_MARGIN, posY);
            }
            else
            {
                viewRectTransform.anchorMin = new Vector2(1, 1);
                viewRectTransform.anchorMax = new Vector2(1, 1);
                viewRectTransform.pivot = new Vector2(1, 1);
                viewRectTransform.anchoredPosition = new Vector2(-SIDE_MARGIN, posY);
            }

            count++;
        }
    }
}