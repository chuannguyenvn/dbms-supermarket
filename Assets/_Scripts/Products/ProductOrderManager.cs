using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductOrderManager : Singleton<ProductOrderManager>
{
    [SerializeField] private Button cartButton;
    [SerializeField] private ProductCartView productCartView;

    public Dictionary<Product, ProductOrder_Item> Order = new();

    private void Start()
    {
        foreach (var product in ProductManager.Instance.Products)
        {
            var productOrder = new ProductOrder_Item(product, 0);
            productCartView.AddNewViewItem(productOrder);
            Order.Add(product, productOrder);
        }

        cartButton.onClick.AddListener(productCartView.ToggleVisibility);
    }

    public void AddOneProductItem(Product product)
    {
        Order[product].Count++;
    }

    public void RemoveOneProductItem(Product product)
    {
        Order[product].Count--;
    }
}