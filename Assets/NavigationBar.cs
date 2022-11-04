using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBar : Singleton<NavigationBar>
{
    public event Action<NavigationBarButton> NavigationItemChosen;
    
    [SerializeField] private Image indicator;
    
    public void OnNavigationItemChosen(NavigationBarButton item)
    {
        NavigationItemChosen?.Invoke(item);

        var time = VisualManager.Instance.NavigationBarItemMoveAnimationTime;
        indicator.transform.DOMoveX(item.transform.position.x, time);
    }
}