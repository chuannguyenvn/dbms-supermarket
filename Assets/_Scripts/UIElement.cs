using System;
using UnityEngine;


public abstract class UIElement : MonoBehaviour
{
    protected virtual void Start()
    {
        UIManager.Instance.ScreenChanged += ScreenChangedHandler;
    }

    protected virtual void OnDestroy()
    {
        UIManager.Instance.ScreenChanged -= ScreenChangedHandler;
    }

    protected virtual void ScreenChangedHandler()
    {
    }
}