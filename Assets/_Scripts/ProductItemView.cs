using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ProductItemView : MonoBehaviour
{
    [SerializeField] protected TMP_Text productName;
    [SerializeField] protected TMP_Text productDescription;
    [SerializeField] protected TMP_Text productPrice;
    [SerializeField] protected Button initialIncreaseButton;
    [SerializeField] protected Button increaseButton;
    [SerializeField] protected Button decreaseButton;
    [SerializeField] protected GameObject quantityAdjustmentGroup;

    protected virtual void Start()
    {
        initialIncreaseButton.onClick.AddListener(AddFirstItem);
    }

    protected void AddFirstItem()
    {
        initialIncreaseButton.gameObject.SetActive(false);

        // No need?
        // foreach (var image in initialIncreaseButton.GetComponents<Image>())
        // {
        //     image.enabled = false;
        // }

        quantityAdjustmentGroup.SetActive(true);
    }
}