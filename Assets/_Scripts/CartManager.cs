using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartManager : Singleton<CartManager>
{
    [SerializeField] private Button cartButton;
    [SerializeField] private CartView cartView;

    public Dictionary<Product, (ProductOrder_Item, ProductCartItemView)> CartList;

    private void Start()
    {
        CartList = new Dictionary<Product, (ProductOrder_Item, ProductCartItemView)>();
        cartButton.onClick.AddListener(() =>
            cartView.gameObject.SetActive(cartView.gameObject.activeInHierarchy));
    }

    public void AddOneProductItem(Product product)
    {
        if (CartList.ContainsKey(product)) CartList[product].Item1.Count++;
        else
        {
            var view = Instantiate(ResourceManager.Instance.ProductCartItemView)
                .GetComponent<ProductCartItemView>();
            view.transform.SetParent(cartView);
            
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