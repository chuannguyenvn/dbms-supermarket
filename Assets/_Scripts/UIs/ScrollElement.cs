using UnityEngine;
using UnityEngine.UI;

public class ScrollElement : UIElement
{
    [SerializeField] private ScrollRect scrollRect;

    protected override void ScreenChangedHandler()
    {
        base.ScreenChangedHandler();
        scrollRect.content.anchoredPosition = new Vector2(0, 0);
    }
}