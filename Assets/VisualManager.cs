using System;
using UnityEngine;

public class VisualManager : PersistentSingleton<VisualManager>
{
    [Header("Theme")] public Color PrimaryColor;
    [Header("Navigation Bar")] public float NavigationBarItemMoveAnimationTime = 1f;

    private void OnValidate()
    {
    }
}