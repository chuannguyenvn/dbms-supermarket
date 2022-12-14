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
        firstNameField = CreateNewField(fieldDatabaseName: "First_name",
            fieldDisplayName: "First name",
            fieldType: FieldType.Name,
            value: data.First_name,
            editable: true);

        lastNameField = CreateNewField(fieldDatabaseName: "Last_name",
            fieldDisplayName: "Last name",
            fieldType: FieldType.Name,
            value: data.Last_name,
            editable: true);

        genderField = CreateNewField(fieldDatabaseName: "Gender",
            fieldDisplayName: "Gender",
            fieldType: FieldType.Name,
            value: data.Gender,
            editable: true);

        addressField = CreateNewField(fieldDatabaseName: "Address",
            fieldDisplayName: "Address",
            fieldType: FieldType.Unrestricted,
            value: data.Address,
            editable: true);

        phoneNumberField = CreateNewField(fieldDatabaseName: "Phone_number",
            fieldDisplayName: "Phone number",
            fieldType: FieldType.PhoneNumber,
            value: data.Phone_number,
            editable: true);

        dateOfBirthField = CreateNewField(fieldDatabaseName: "Date_of_birth",
            fieldDisplayName: "Date of birth",
            fieldType: FieldType.Date,
            value: data.Date_of_birth.Value,
            editable: true);

        typeField = CreateNewField(fieldDatabaseName: "Type",
            fieldDisplayName: "Type",
            fieldType: FieldType.Name,
            value: data.Type,
            editable: false);
    }

    protected override void Save()
    {
        if (!Validate()) return;
        base.Save();

        DapperFacade.Instance.QueryNone(Function.UpdateCustomerProfile,
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