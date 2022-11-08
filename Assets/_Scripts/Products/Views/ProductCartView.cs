using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProductCartView : ProductView
{
    private const float VERTICAL_SPACE = 30f;

    [SerializeField] private ScrollRect scrollRect;
    public bool IsVisible { get; private set; }
    private List<ProductCartViewItem> viewItems = new();

    private void Awake()
    {
        scrollRect.content.sizeDelta = new Vector2(0, VERTICAL_SPACE);
    }

    protected override void Start()
    {
        base.Start();
        Hide();
    }

    public void AddNewViewItem(ProductOrderItem orderItem)
    {
        var view = Instantiate(ResourceManager.Instance.ProductCartItemView)
            .GetComponent<ProductCartViewItem>();

        view.AssignProduct(orderItem);

        var itemRect = view.GetComponent<RectTransform>();
        var initialLeftRight = itemRect.sizeDelta;
        view.transform.SetParent(scrollRect.content.transform);

        itemRect.sizeDelta = initialLeftRight;
        itemRect.anchoredPosition = new Vector2(0, -scrollRect.content.sizeDelta.y);
        viewItems.Add(view);
        UpdateContentHeight();
    }

    private void UpdateContentHeight()
    {
        var itemRect = VisualManager.Instance.productCartItemRectTransform;
        scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x,
            itemRect.sizeDelta.y * viewItems.Count + VERTICAL_SPACE * (viewItems.Count + 1));
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