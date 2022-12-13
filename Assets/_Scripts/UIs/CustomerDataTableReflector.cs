using UnityEngine;


public class CustomerDataTableReflector : TableReflector<CustomerData>
{
    // DEBUG //

    protected override void Start()
    {
        base.Start();
        Init(DapperFacade.Instance.QuerySingle<CustomerData>(Function.ReadCustomer, new {ID = 1}));
    }

    // DEBUG //


    public override void Init(CustomerData data)
    {
        var editableTextPrefab = ResourceManager.Instance.EditableText;

        var firstNameEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        firstNameEditableText.Init("First_name", "First name", data.First_name);
        AddNewEditableText(firstNameEditableText);

        var lastNameEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        lastNameEditableText.Init("Last_name", "Last name", data.Last_name);
        AddNewEditableText(lastNameEditableText);

        var genderEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        genderEditableText.Init("Gender", "Gender", data.Gender);
        AddNewEditableText(genderEditableText);

        var addressEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        addressEditableText.Init("Address", "Address", data.Address);
        AddNewEditableText(addressEditableText);

        var phoneNumberEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        phoneNumberEditableText.Init("Phone_number", "Phone number", data.Phone_number);
        AddNewEditableText(phoneNumberEditableText);

        var dateOfBirthEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        dateOfBirthEditableText.Init("Date_of_birth", "Date of birth", data.Date_of_birth.ToString());
        AddNewEditableText(dateOfBirthEditableText);

        var typeEditableText = Instantiate(editableTextPrefab, transform).GetComponent<EditableText>();
        typeEditableText.Init("Type", "Type", data.Type);
        AddNewEditableText(typeEditableText);

        var childCount = transform.childCount;
        editButton.transform.SetSiblingIndex(childCount - 1);
        saveButton.transform.SetSiblingIndex(childCount - 1);
        cancelButton.transform.SetSiblingIndex(childCount - 1);
    }

    protected override void Save()
    {
        base.Save();
        
    }
}