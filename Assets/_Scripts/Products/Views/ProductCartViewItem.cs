using TMPro;
using UnityEngine;

public class ProductCartViewItem : ProductViewItem
{
    [SerializeField] private TMP_Text totalPrice;

    public override void UpdateQuantity(int count)
    {
        base.UpdateQuantity(count);
        totalPrice.text = ProductUtility.FormatVNDPrice(orderItem.Price);
    }
}