using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCartManager : Singleton<ProductCartManager>
{
    [SerializeField] private Button cartButton;

    [SerializeField] private ProductCartView productCartView;

    public Dictionary<Product, (ProductOrder_Item, ProductCartView_Item)> CartList;

    private void Start()
    {
        CartList = new Dictionary<Product, (ProductOrder_Item, ProductCartView_Item)>();

        foreach (var product in ProductManager.Instance.Products)
        {
            var view = Instantiate(ResourceManager.Instance.ProductCartItemView)
                .GetComponent<ProductCartView_Item>();
            productCartView.AddNewViewItem(view);
            view.AssignProduct(product);
            CartList.Add(product, (new ProductOrder_Item(product, 0), view));
        }

        cartButton.onClick.AddListener(productCartView.ToggleVisibility);
    }

    public void AddOneProductItem(Product product)
    {
        if (CartList.ContainsKey(product)) CartList[product].Item1.Count++;
        else
        {
            var view = Instantiate(ResourceManager.Instance.ProductCartItemView)
                .GetComponent<ProductCartView_Item>();
            productCartView.AddNewViewItem(view);
            view.AssignProduct(product);
            CartList.Add(product, (new ProductOrder_Item(product, 1), view));
        }
    }

    public void RemoveOneProductItem(Product product)
    {
        if (CartList.ContainsKey(product))
        {
            var (order, view) = CartList[product];
            order.Count--;
            view.SetText(order.Price, order.Count);
            if (order.Count == 0) CartList.Remove(product);
        }
    }
}