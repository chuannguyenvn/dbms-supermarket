using TMPro;
using UnityEngine;

public class ProductCartView_Item : ProductView_Item
{
    [SerializeField] private TMP_Text totalPrice;

    public override void UpdateQuantity(int count)
    {
        base.UpdateQuantity(count);
        totalPrice.text = ProductUtility.FormatVNDPrice(orderItem.Price);
    }
}