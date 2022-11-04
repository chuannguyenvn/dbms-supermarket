using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ProductItemView : MonoBehaviour
{
    [SerializeField] protected TMP_Text productName;
    [SerializeField] protected TMP_Text productPrice;
    [SerializeField] protected TMP_Text productDescription;
    [SerializeField] protected Image productImage;
    [SerializeField] protected Button initialIncreaseButton;
    [SerializeField] protected Button increaseButton;
    [SerializeField] protected Button decreaseButton;
    [SerializeField] protected GameObject quantityAdjustmentGroup;
    [SerializeField] private TMP_Text orderItemCount;

    private Product product;

    public void AssignProduct(Product product)
    {
        this.product = product;
        productName.text = product.Name;
        productPrice.text = ProductUtility.FormatVNDPrice(product.Price);
        productDescription.text = product.Description;
        productImage.sprite = product.Sprite;
    }

    protected virtual void Start()
    {
        initialIncreaseButton.onClick.AddListener(AddFirstItem);
        increaseButton.onClick.AddListener(AddOneItem);
        decreaseButton.onClick.AddListener(RemoveOneItem);
    }

    protected void AddFirstItem()
    {
        initialIncreaseButton.gameObject.SetActive(false);
        quantityAdjustmentGroup.SetActive(true);
        AddOneItem();
    }

    private void AddOneItem()
    {
        CartManager.Instance.AddOneProductItem(product);

        orderItemCount.text = CartManager.Instance.CartList[product].Item1.Count.ToString();
    }

    private void RemoveOneItem()
    {
        CartManager.Instance.RemoveOneProductItem(product);

        if (CartManager.Instance.CartList.ContainsKey(product))
        {
            var count = CartManager.Instance.CartList[product].Item1.Count;
            orderItemCount.text = count.ToString();
        }
        else
        {
            initialIncreaseButton.gameObject.SetActive(true);
            quantityAdjustmentGroup.SetActive(false);
        }
    }
}