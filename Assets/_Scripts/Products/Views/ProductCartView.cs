using System;
using System.Collections.Generic;
using UnityEngine;


public class ProductCartView : Singleton<ProductCartView>
{
    public bool IsVisible { get; private set; }
    private List<ProductCartView_Item> viewItems = new List<ProductCartView_Item>();

    private void Start()
    {
        Hide();
    }

    public void AddNewViewItem(ProductCartView_Item item)
    {
        viewItems.Add(item);
        var itemRect = item.GetComponent<RectTransform>();
        var initialLeftRight = itemRect.sizeDelta;
        item.transform.SetParent(transform);
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