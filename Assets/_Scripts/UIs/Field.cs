using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Field : MonoBehaviour
{
    [HideInInspector] public string FieldDatabaseName;
    [HideInInspector] public string FieldDisplayName;
    [SerializeField] private TMP_Text fieldDisplayNameText;
    [SerializeField] private TMP_Text viewText;
    [SerializeField] private TMP_InputField editField;
    private bool editable;
    public string Value => viewText.text;

    public void Init(string fieldDatabaseName, string fieldDisplayName, string value, bool editable)
    {
        FieldDatabaseName = fieldDatabaseName;
        fieldDisplayNameText.text = FieldDisplayName = fieldDisplayName;
        viewText.text = editField.text = value;
        this.editable = editable;

        View();
    }

    public void Init(string fieldDatabaseName, string fieldDisplayName, DateTime value, bool editable)
    {
        FieldDatabaseName = fieldDatabaseName;
        fieldDisplayNameText.text = FieldDisplayName = fieldDisplayName;
        viewText.text = editField.text = value.ToString("yyyyMMdd");
        this.editable = editable;

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