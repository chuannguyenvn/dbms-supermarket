using System;
using UnityEngine;
using UnityEngine.UI;

public class CategoryView : UIElement
{
    [SerializeField] private ScrollRect scrollRect;

    protected override void ScreenChangedHandler()
    {
        base.ScreenChangedHandler();
        scrollRect.content.anchoredPosition = new Vector2(0, scrollRect.content.anchoredPosition.y);
    }
}