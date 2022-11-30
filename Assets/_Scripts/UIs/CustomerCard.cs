using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerCard : Singleton<CustomerCard>
{
    [SerializeField] private TMP_Text cardTypeText;
    [SerializeField] private TMP_Text pointText;
    
    private int pointCount;
    
    public int PointCount
    {
        get => pointCount;
        set
        {
            pointCount = value;
            pointText.text = pointCount.ToString("{0:n0}");
        }
    }
}