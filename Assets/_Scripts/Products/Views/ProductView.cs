using System.Collections.Generic;
using UnityEngine;


public abstract class ProductView : MonoBehaviour
{
    protected List<ProductView_Item> productItemViews = new List<ProductView_Item>();

    protected virtual void Start()
    {
        
    }
}