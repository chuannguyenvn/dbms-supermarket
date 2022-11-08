using System.Collections.Generic;
using UnityEngine;


public abstract class ProductView : UIElement
{
    protected List<ProductItemView> itemViews = new();
}