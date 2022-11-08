using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductOrderManager : Singleton<ProductOrderManager>
{
    [SerializeField] private ProductCartView productCartView;

    public Dictionary<Product, ProductOrderItem> Order = new();

    private void Start()
    {
        foreach (var product in ProductManager.Instance.Products)
        {
            Order.Add(product, new ProductOrderItem(product, 0));
        }
    }

    public void AddOneProductItem(Product product)
    {
        if (Order[product].Count == 0) productCartView.AddViewItem(Order[product]);
        Order[product].Count++;
    }

    public void RemoveOneProductItem(Product product)
    {
        Order[product].Count--;
        if (Order[product].Count == 0) productCartView.RemoveViewItem(Order[product]);
    }
}