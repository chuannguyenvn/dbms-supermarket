using System;
using UnityEngine;

public class Sidebar : Singleton<Sidebar>
{
    public event Action<int> ViewButtonPressed;

    
    private void Start()
    {
        OnViewButtonPressed(0);
    }

    public void OnViewButtonPressed(int index)
    {
        ViewButtonPressed?.Invoke(index);
    }
}