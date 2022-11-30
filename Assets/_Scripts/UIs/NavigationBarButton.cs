using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBarButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject screen;
    
    private void Start()
    {
        button.onClick.AddListener(() => NavigationBar.Instance.OnNavigationItemChosen(this));
        NavigationBar.Instance.NavigationItemChosen += NavigationItemChosenHandler;
    }

    private void NavigationItemChosenHandler(NavigationBarButton item)
    {
        screen.SetActive(item == this);
    }
}
