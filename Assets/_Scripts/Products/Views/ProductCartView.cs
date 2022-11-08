using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProductCartView : ProductView
{
    private const float VERTICAL_SPACE = 30f;

    [SerializeField] private Button cartButton;
    [SerializeField] private ScrollRect scrollRect;
    public bool IsVisible { get; private set; }
    private RectTransform prefabItemRect;

    protected override void Start()
    {
        base.Start();
        Hide();
        cartButton.onClick.AddListener(ToggleVisibility);
        prefabItemRect = VisualManager.Instance.productCartItemRectTransform;
    }

    public void AddViewItem(ProductOrderItem orderItem)
    {
        var view = Instantiate(ResourceManager.Instance.ProductCartItemView)
            .GetComponent<ProductCartViewItem>();

        view.AssignProduct(orderItem);
        itemViews.Add(view);

        view.transform.SetParent(scrollRect.content.transform);
        UpdateContentLayout();
    }

    public void RemoveViewItem(ProductOrderItem orderItem)
    {
        var index = itemViews.FindIndex(item => item.OrderItem == orderItem);
        if (index == -1) return;
        Destroy(itemViews[index].gameObject);
        itemViews.RemoveAt(index);
        
        UpdateContentLayout();
    }

    private void UpdateContentLayout()
    {
        var itemRectHeight = prefabItemRect.sizeDelta.y;
        scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x,
            itemRectHeight * itemViews.Count + VERTICAL_SPACE * (itemViews.Count + 1));

        for (int i = 0; i < itemViews.Count; i++)
        {
            var itemPosY = -(itemRectHeight * i + VERTICAL_SPACE * (i + 1));
            itemViews[i].RectTransform.anchoredPosition = new Vector2(0, itemPosY);
            itemViews[i].RectTransform.sizeDelta = prefabItemRect.sizeDelta; // Must keep!
        }
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
        UIManager.Instance.OnScreenChanged();
        if (IsVisible) Hide();
        else Show();
    }
}