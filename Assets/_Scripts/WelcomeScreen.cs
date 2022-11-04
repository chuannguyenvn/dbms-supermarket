using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeScreen : MonoBehaviour
{
    [SerializeField] private Button customerButton;
    [SerializeField] private Button managerButton;
    [SerializeField] private Button cashierButton;

    private void Awake()
    {
        customerButton.onClick.AddListener(() => SceneManager.LoadScene("Customer"));
        managerButton.onClick.AddListener(() => SceneManager.LoadScene("Manager"));
        cashierButton.onClick.AddListener(() => SceneManager.LoadScene("Cashier"));
    }
}