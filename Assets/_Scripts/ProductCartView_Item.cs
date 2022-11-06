using TMPro;
using UnityEngine;

public class ProductCartView_Item : ProductView_Item
{
    [SerializeField] private TMP_Text totalPrice;

    public void SetText(int totalPrice, int count)
    {
        this.totalPrice.text = ProductUtility.FormatVNDPrice(totalPrice);
        orderItemCount.text = count.ToString();
    }
}