using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyView : View
{
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect.content.sizeDelta = new Vector2(
            gridLayoutGroup.preferredWidth, gridLayoutGroup.preferredHeight);
    }
}