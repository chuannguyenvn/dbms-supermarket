using System.Collections.Generic;
using UnityEngine;


public abstract class ProductView : MonoBehaviour
{
    protected List<ProductViewItem> productItemViews = new List<ProductViewItem>();

    protected virtual void Start()
    {
        
    }
}