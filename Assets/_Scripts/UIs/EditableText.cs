using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditableText : MonoBehaviour
{
    [HideInInspector] public string FieldDatabaseName;
    [HideInInspector] public string FieldDisplayName;
    [SerializeField] private TMP_Text fieldDisplayNameText;
    [SerializeField] private TMP_Text viewText;
    [SerializeField] private TMP_InputField editField;


    public void Init(string fieldDatabaseName, string fieldDisplayName, string value)
    {
        FieldDatabaseName = fieldDatabaseName;
        fieldDisplayNameText.text = FieldDisplayName = fieldDisplayName;
        viewText.text = editField.text = value;

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
    }

    public void Save()
    {
        viewText.text = editField.text;

        View();
    }

    public void Cancel()
    {
        View();
    }
}