using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerCard : Singleton<CustomerCard>
{
    [SerializeField] private TMP_Text cardTypeText;
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private TMP_Text issueDate;

    private int pointCount;

    public int PointCount
    {
        get => pointCount;
        set
        {
            pointCount = value;

            if (pointCount <= 1)
                pointText.text = $"{pointCount:n0} Point";
            else 
                pointText.text = $"{pointCount:n0} Points";
        }
    }

    private void Start()
    {
        var cardInformation = DatabaseManager.Instance.GetCustomerCard("lmao");

        PointCount = int.Parse(cardInformation[2]);
        issueDate.text = cardInformation[1];
    }
}