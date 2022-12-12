using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SQLQueryBox : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button resetButton;

    private void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
        resetButton.onClick.AddListener(OnReset);
    }

    private void OnReset()
    {
        inputField.text = "";
    }

    private void OnSubmit()
    {
        resultText.text = DapperFacade.Instance.FreeQuery(inputField.text);
        StartCoroutine(UpdateScrollView_CO());
    }

    private IEnumerator UpdateScrollView_CO()
    {
        resultText.ForceMeshUpdate();
        yield return null;
        yield return new WaitForSeconds(0.1f);
        scrollRect.content.sizeDelta =
            new Vector2(resultText.preferredWidth, resultText.preferredHeight);
    }
}