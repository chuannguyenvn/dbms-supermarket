using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomerInformationView : View
{
    [SerializeField] private DynamicDefaultAvatar dynamicDefaultAvatar;
    [FormerlySerializedAs("customerDataTableReflector")] [SerializeField] private Customer_CustomerDataTableReflector customerCustomerDataTableReflector;

    private void Start()
    {
        var param = new {ID = CustomerViewManager.Instance.CustomerID};
        var customerData =
            DapperFacade.Instance.QuerySingle<CustomerData>(Function.ReadCustomerProfile, param);

        dynamicDefaultAvatar.Init(customerData.First_name);
        customerCustomerDataTableReflector.Init(customerData);
    }
}