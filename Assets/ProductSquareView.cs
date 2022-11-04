using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductSquareView : MonoBehaviour
{
    [SerializeField] private Button initialIncreaseButton;
    [SerializeField] private Button increaseButton;
    [SerializeField] private Button decreaseButton;
    [SerializeField] private GameObject quantityAdjustmentButtons;

    private void Start()
    {
        initialIncreaseButton.onClick.AddListener(AddFirstItem);
    }

    private void AddFirstItem()
    {
        foreach (var image in initialIncreaseButton.GetComponents<Image>())
        {
            image.enabled = false;
        }
        
        quantityAdjustmentButtons.SetActive(true);
    }
}