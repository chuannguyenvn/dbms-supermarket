using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodGridItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text brandText;
    [SerializeField] private TMP_Text typeText;
    [SerializeField] private Image image;

    public void Init(GoodsData goodsData)
    {
        nameText.text = goodsData.Name;
        priceText.text = goodsData.Price.ToString();
        brandText.text = goodsData.Brand;
        typeText.text = goodsData.Type;
        image.sprite = ResourceManager.Instance.GetGoodsSpriteById(goodsData.ID);
    }
}
