using System;
using UnityEngine;

public class VisualManager : PersistentSingleton<VisualManager>
{
    [Header("Theme")] public Color PrimaryColor;
    [Header("Navigation Bar")] public float NavigationBarItemMoveAnimationTime = 1f;
    [Header("Product List Item View")] public float ProductListItemViewVerticalMargin;
    private void OnValidate()
    {
    }
}