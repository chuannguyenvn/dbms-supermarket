using UnityEngine;


public class CustomerDataTableReflector : TableReflector<CustomerData>
{
    private Field firstNameField;
    private Field lastNameField;
    private Field genderField;
    private Field addressField;
    private Field phoneNumberField;
    private Field dateOfBirthField;
    private Field typeField;


    public override void Init(CustomerData data)
    {
        this.data = data;
        CreateFields();
        UpdateButtonsSiblingIndex();
    }

    protected override void CreateFields()
    {
        firstNameField = CreateNewField("First_name", "First name", data.First_name, true);
        lastNameField = CreateNewField("Last_name", "Last name", data.Last_name, true);
        genderField = CreateNewField("Gender", "Gender", data.Gender, true);
        addressField = CreateNewField("Address", "Address", data.Address, true);
        phoneNumberField = CreateNewField("Phone_number", "Phone number", data.Phone_number, true);
        dateOfBirthField =
            CreateNewField("Date_of_birth", "Date of birth", data.Date_of_birth.Value, true);
        typeField = CreateNewField("Type", "Type", data.Type, false);
    }

    protected override void Save()
    {
        base.Save();

        DapperFacade.Instance.QueryNone(Function.UpdateCustomer,
            new
            {
                ID = data.ID,
                First_name = firstNameField.Value,
                Last_name = lastNameField.Value,
                Gender = genderField.Value,
                Address = addressField.Value,
                Phone_number = phoneNumberField.Value,
                Date_of_birth = dateOfBirthField.Value,
                Type = data.Type,
            });
    }
}