using System;
using TMPro;
using UnityEngine;

public class CustomerInformationView : View
{
    [SerializeField] private DynamicDefaultAvatar dynamicDefaultAvatar;
    [SerializeField] private CustomerDataTableReflector customerDataTableReflector;

    private void Start()
    {
        var param = new {ID = CustomerViewManager.Instance.CustomerID};
        var customerData =
            DapperFacade.Instance.QuerySingle<CustomerData>(Function.ReadCustomerProfile, param);

        dynamicDefaultAvatar.Init(customerData.First_name);
        customerDataTableReflector.Init(customerData);
    }
}