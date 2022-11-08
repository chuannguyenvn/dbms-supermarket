using System;
using UnityEngine;

public class VisualManager : PersistentSingleton<VisualManager>
{
    [Header("Theme")] public Color PrimaryColor;
    [Header("Navigation Bar")] public float NavigationBarItemMoveAnimationTime = 1f;
    [Header("Product List Item View")] public float ProductListItemViewVerticalMargin;

    [HideInInspector] public RectTransform productGridItemRectTransform;
    [HideInInspector] public RectTransform productListItemRectTransform;
    [HideInInspector] public RectTransform productCartItemRectTransform;

    protected override void Awake()
    {
        base.Awake();
        var resourceManager = ResourceManager.Instance;
        productGridItemRectTransform = resourceManager.ProductGridItemView.GetComponent<RectTransform>();
        productListItemRectTransform = resourceManager.ProductListItemView.GetComponent<RectTransform>();
        productCartItemRectTransform = resourceManager.ProductCartItemView.GetComponent<RectTransform>();
    }
}