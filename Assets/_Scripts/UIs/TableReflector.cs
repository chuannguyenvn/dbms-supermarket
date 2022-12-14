using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TableReflector<T> : MonoBehaviour
{
    protected T data;

    [SerializeField] protected Button editButton;
    [SerializeField] protected Button saveButton;
    [SerializeField] protected Button cancelButton;
    protected List<Field> fields = new();


    protected virtual void Start()
    {
        editButton.onClick.AddListener(Edit);
        saveButton.onClick.AddListener(Save);
        cancelButton.onClick.AddListener(Cancel);

        View();
    }

    public abstract void Init(T data);
    protected abstract void CreateFields();

    protected void AddNewEditableField(Field field)
    {
        fields.Add(field);
    }

    protected Field CreateNewField(string fieldDatabaseName, string fieldDisplayName,
        FieldType fieldType, string value, bool editable)
    {
        var prefab = ResourceManager.Instance.field;
        var field = Instantiate(prefab, transform).GetComponent<Field>();
        field.Init(fieldDatabaseName, fieldDisplayName, fieldType, value);
        if (editable) AddNewEditableField(field);
        return field;
    }

    protected Field CreateNewField(string fieldDatabaseName, string fieldDisplayName,
        FieldType fieldType, DateTime value, bool editable)
    {
        var prefab = ResourceManager.Instance.field;
        var field = Instantiate(prefab, transform).GetComponent<Field>();
        field.Init(fieldDatabaseName, fieldDisplayName, fieldType, value);
        if (editable) AddNewEditableField(field);
        return field;
    }

    protected void UpdateButtonsSiblingIndex()
    {
        var childCount = transform.childCount;
        editButton.transform.SetSiblingIndex(childCount - 1);
        saveButton.transform.SetSiblingIndex(childCount - 1);
        cancelButton.transform.SetSiblingIndex(childCount - 1);
    }

    protected virtual void View()
    {
        foreach (var editableText in fields)
        {
            editableText.View();
        }

        editButton.gameObject.SetActive(true);
        saveButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(false);
    }

    protected virtual void Edit()
    {
        foreach (var editableText in fields)
        {
            editableText.Edit();
        }

        editButton.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
    }

    protected virtual void Save()
    {
        foreach (var editableText in fields)
        {
            editableText.Save();
        }

        View();
    }

    protected virtual void Cancel()
    {
        foreach (var editableText in fields)
        {
            editableText.Cancel();
        }

        View();
    }

    protected bool Validate()
    {
        bool allValid = true;
        foreach (var field in fields)
        {
            allValid &= field.Validate();
        }

        return allValid;
    }
}