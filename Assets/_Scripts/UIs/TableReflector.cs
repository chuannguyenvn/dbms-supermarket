using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TableReflector<T> : MonoBehaviour
{
    [SerializeField] protected Button editButton;
    [SerializeField] protected Button saveButton;
    [SerializeField] protected Button cancelButton;
    protected List<EditableText> editableTexts = new();
    
    
    protected virtual void Start()
    {
        editButton.onClick.AddListener(Edit);
        saveButton.onClick.AddListener(Save);
        cancelButton.onClick.AddListener(Cancel);
        
        View();
    }

    public abstract void Init(T data);

    protected void AddNewEditableText(EditableText editableText)
    {
        editableTexts.Add(editableText);
    }
    
    protected virtual void View()
    {
        foreach (var editableText in editableTexts)
        {
            editableText.View();
        }
        
        editButton.gameObject.SetActive(true);
        saveButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(false);
    }
    
    protected virtual void Edit()
    {
        foreach (var editableText in editableTexts)
        {
            editableText.Edit();
        }
        
        editButton.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
    }

    protected virtual void Save()
    {
        foreach (var editableText in editableTexts)
        {
            editableText.Save();
        }
        
        View();
    }

    protected virtual void Cancel()
    {
        foreach (var editableText in editableTexts)
        {
            editableText.Cancel();
        }
        
        View();
    }
}