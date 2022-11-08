using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ProductViewItem : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;
    public RectTransform RectTransform => rectTransform;
    
    [SerializeField] protected TMP_Text productName;
    [SerializeField] protected TMP_Text productPrice;
    [SerializeField] protected TMP_Text productDescription;
    [SerializeField] protected Image productImage;
    [SerializeField] protected Button initialIncreaseButton;
    [SerializeField] protected Button increaseButton;
    [SerializeField] protected Button decreaseButton;
    [SerializeField] protected GameObject quantityAdjustmentGroup;
    [SerializeField] protected TMP_Text orderItemCount;

    protected ProductOrderItem orderItem;
    public ProductOrderItem OrderItem => orderItem;

    public void AssignProduct(ProductOrderItem orderItem)
    {
        this.orderItem = orderItem;
        
        productName.text = orderItem.Product.Name;
        productPrice.text = ProductUtility.FormatVNDPrice(orderItem.Product.Price);
        productDescription.text = orderItem.Product.Description;
        productImage.sprite = orderItem.Product.Sprite;
        
        orderItem.AssignViewItem(this);
    }

    protected virtual void Start()
    {
        initialIncreaseButton.onClick.AddListener(AddOneItem);
        increaseButton.onClick.AddListener(AddOneItem);
        decreaseButton.onClick.AddListener(RemoveOneItem);
    }
    
    private void AddOneItem()
    {
        ProductOrderManager.Instance.AddOneProductItem(orderItem.Product);
    }

    private void RemoveOneItem()
    {
        ProductOrderManager.Instance.RemoveOneProductItem(orderItem.Product);
    }

    public virtual void UpdateQuantity(int count)
    {
        orderItemCount.text = count.ToString();
        if (count == 0)
        {
            initialIncreaseButton.gameObject.SetActive(true);
            quantityAdjustmentGroup.SetActive(false);
        }
        else
        {
            initialIncreaseButton.gameObject.SetActive(false);
            quantityAdjustmentGroup.SetActive(true); 
        }
    }
}