using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private ViewGroup viewGroup;
    [SerializeField] private int buttonIndex;


    private void Start()
    {
        Sidebar.Instance.ViewButtonPressed += ViewButtonPressedHandler;
        button.onClick.AddListener(() => Sidebar.Instance.OnViewButtonPressed(buttonIndex));
    }

    private void ViewButtonPressedHandler(int index)
    {
        if (index == buttonIndex)
        {
            viewGroup.Show();
        }
        else
        {
            viewGroup.Hide();
        }
    }
}