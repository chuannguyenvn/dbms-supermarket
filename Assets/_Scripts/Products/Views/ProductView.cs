using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ProductView : MonoBehaviour
{
    protected List<ProductView_Item> productItemViews;

    private void Start()
    {
        productItemViews = new List<ProductView_Item>();

        var products = ProductManager.Instance.Products;
        var margin = VisualManager.Instance.ProductListItemViewVerticalMargin;
        for (int i = 0; i < ProductManager.Instance.Products.Count; i++)
        {
            var productListItemView =
                Instantiate(ResourceManager.Instance.ProductListItemView, transform)
                    .GetComponent<ProductListView_Item>();

            productListItemView.AssignProduct(products[i]);
            var viewRectTransform = productListItemView.GetComponent<RectTransform>();
            var height = viewRectTransform.rect.height;
            viewRectTransform.anchoredPosition = new Vector2(0, -(i * height + margin));
        }
    }
}