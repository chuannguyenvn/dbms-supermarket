using System;
using TMPro;
using UnityEngine;

public class CustomerInformationView : View
{
    public int CustomerID;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text genderText;
    [SerializeField] private TMP_Text addressText;
    [SerializeField] private TMP_Text phoneNumberText;
    [SerializeField] private TMP_Text dateOfBirthText;
    [SerializeField] private TMP_Text typeText;

    private void Start()
    {
        var param = new {id = CustomerID};
        var customerData = DapperFacade.Instance.QuerySingle<CustomerData>(Function.ReadCustomer, param);

        nameText.text = customerData.First_name + ", " + customerData.Last_name;
        genderText.text = customerData.Gender;
        addressText.text = customerData.Address;
        phoneNumberText.text = customerData.Phone_number;
        dateOfBirthText.text = customerData.Date_of_birth.ToString();
        typeText.text = customerData.Type;
    }
}