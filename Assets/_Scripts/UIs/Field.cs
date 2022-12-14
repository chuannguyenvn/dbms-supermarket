using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class Field : MonoBehaviour
{
    [HideInInspector] public string FieldDatabaseName;
    [HideInInspector] public string FieldDisplayName;
    [SerializeField] private TMP_Text fieldDisplayNameText;
    [SerializeField] private TMP_Text viewText;
    [SerializeField] private TMP_InputField editField;
    private FieldType fieldType;


    public string Value => editField.text;

    public void Init(string fieldDatabaseName, string fieldDisplayName, FieldType fieldType,
        string value)
    {
        FieldDatabaseName = fieldDatabaseName;
        fieldDisplayNameText.text = FieldDisplayName = fieldDisplayName;
        viewText.text = editField.text = value;
        this.fieldType = fieldType;

        View();
    }

    public void Init(string fieldDatabaseName, string fieldDisplayName, FieldType fieldType,
        DateTime value)
    {
        FieldDatabaseName = fieldDatabaseName;
        fieldDisplayNameText.text = FieldDisplayName = fieldDisplayName;
        viewText.text = editField.text = value.ToString("yyyyMMdd");
        this.fieldType = fieldType;

        View();
    }

    public void Edit()
    {
        editField.gameObject.SetActive(true);
        viewText.gameObject.SetActive(false);

        editField.text = viewText.text;
    }

    public void View()
    {
        editField.gameObject.SetActive(false);
        viewText.gameObject.SetActive(true);

        fieldDisplayNameText.text = FieldDisplayName;
    }

    public void Save()
    {
        viewText.text = editField.text;

        View();
    }

    public void Cancel()
    {
        editField.text = viewText.text;

        View();
    }

    public bool Validate()
    {
        string errorMessage = "";
        bool isValid = true;
        switch (fieldType)
        {
            case FieldType.PhoneNumber:
                isValid = FieldValidator.TryValidateNumberPhone(Value, ref errorMessage);
                break;
            case FieldType.Date:
                isValid = FieldValidator.TryValidateDate(Value, ref errorMessage);
                break;
            case FieldType.Name:
                isValid = FieldValidator.TryValidateName(Value, ref errorMessage);
                break;
            case FieldType.Money:
                isValid = FieldValidator.TryValidateMoney(Value, ref errorMessage);
                break;
            case FieldType.Email:
                isValid = FieldValidator.TryValidateEmail(Value, ref errorMessage);
                break;
        }

        if (isValid) fieldDisplayNameText.text = FieldDisplayName;
        else fieldDisplayNameText.text = CreateErrorMessageText(errorMessage);
        return isValid;
    }

    private string CreateErrorMessageText(string errorMessage)
    {
        return FieldDisplayName + " - <color=\"red\">" + errorMessage;
    }
}

public static class FieldValidator
{
    private static string PHONE_NUMBER_REGEX = @"";
    private static string DATE_REGEX = @"";
    private static string NAME_REGEX = @"^[a-zA-Z]*$";
    private static string MONEY_REGEX = @"";
    private static string EMAIL_REGEX = @"";

    public static bool TryValidateNumberPhone(string numberPhone, ref string errorMessage)
    {
        errorMessage = "";
        var result = Regex.Match(numberPhone, PHONE_NUMBER_REGEX);
        if (result.Success == false) errorMessage = "Invalid phone number.";
        return result.Success;
    }

    public static bool TryValidateDate(string date, ref string errorMessage)
    {
        errorMessage = "";
        var result = Regex.Match(date, DATE_REGEX);
        if (result.Success == false) errorMessage = "Invalid date.";
        return result.Success;
    }

    public static bool TryValidateName(string name, ref string errorMessage)
    {
        errorMessage = "";
        var result = Regex.Match(name, NAME_REGEX);
        if (result.Success == false) errorMessage = "Invalid name.";
        return result.Success;
    }

    public static bool TryValidateMoney(string money, ref string errorMessage)
    {
        errorMessage = "";
        var result = Regex.Match(money, MONEY_REGEX);
        if (result.Success == false) errorMessage = "Invalid price/salary.";
        return result.Success;
    }

    public static bool TryValidateEmail(string email, ref string errorMessage)
    {
        errorMessage = "";
        var result = Regex.Match(email, EMAIL_REGEX);
        if (result.Success == false) errorMessage = "Invalid email.";
        return result.Success;
    }
}

public enum FieldType
{
    Unrestricted,
    PhoneNumber,
    Date,
    Name,
    Money,
    Email,
}