using System;
using TMPro;
using UnityEngine;

public class CustomerInformationView : View
{
    public int CustomerID;
    [SerializeField] private DynamicDefaultAvatar dynamicDefaultAvatar;
    [SerializeField] private CustomerDataTableReflector customerDataTableReflector;

    private void Start()
    {
        var param = new {ID = CustomerID};
        var customerData = DapperFacade.Instance.QuerySingle<CustomerData>(Function.ReadCustomer, param);

        dynamicDefaultAvatar.Init(customerData.First_name);
        customerDataTableReflector.Init(customerData);
    }
}