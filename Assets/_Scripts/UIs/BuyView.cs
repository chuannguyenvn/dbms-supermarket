using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyView : View
{
    [SerializeField] private ScrollRect scrollRect;

    private void Start()
    {
        foreach (var goodsData in DapperFacade.Instance.Query<GoodsData>("select * from goods"))
        {
            var goodGridItemViewGO = Instantiate(ResourceManager.Instance.GoodGridItemView,
                scrollRect.content.transform);
            goodGridItemViewGO.GetComponent<GoodGridItemView>().Init(goodsData);
        }
    }
}