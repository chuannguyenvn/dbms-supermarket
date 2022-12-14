using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private View view;


    private void Start()
    {
        Sidebar.Instance.ViewButtonPressed += ViewButtonPressedHandler;
        button.onClick.AddListener(() =>
            Sidebar.Instance.OnViewButtonPressed(transform.GetSiblingIndex()));
    }

    private void ViewButtonPressedHandler(int index)
    {
        if (index == transform.GetSiblingIndex())
        {
            view.Show();
        }
        else
        {
            view.Hide();
        }
    }
}