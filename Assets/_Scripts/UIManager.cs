using System;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    public event Action ScreenChanged;

    public void OnScreenChanged()
    {
        ScreenChanged?.Invoke();
    }
}