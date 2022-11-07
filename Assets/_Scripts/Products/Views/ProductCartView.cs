using System.Collections.Generic;
using UnityEngine;


public class ProductCartView : MonoBehaviour
{
    public bool IsVisible { get; private set; }
    private List<ProductCartViewItem> viewItems = new List<ProductCartViewItem>();

    private void Start()
    {
        Hide();
    }

    public void AddNewViewItem(ProductOrderItem orderItem)
    {
        var view = Instantiate(ResourceManager.Instance.ProductCartItemView)
            .GetComponent<ProductCartViewItem>();

        viewItems.Add(view);
        view.AssignProduct(orderItem);

        var itemRect = view.GetComponent<RectTransform>();
        var initialLeftRight = itemRect.sizeDelta;
        view.transform.SetParent(transform);
        itemRect.sizeDelta = initialLeftRight;
        itemRect.anchoredPosition = new Vector2(0, -(viewItems.Count - 1) * itemRect.sizeDelta.y);
    }

    public void Show()
    {
        IsVisible = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsVisible = false;
        gameObject.SetActive(false);
    }

    public void ToggleVisibility()
    {
        if (IsVisible) Hide();
        else Show();
    }
}