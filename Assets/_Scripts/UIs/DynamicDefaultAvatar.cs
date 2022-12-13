using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDefaultAvatar : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text initialCharacterText;

    public void Init(string name)
    {
        background.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.4f, 0.9f);
        initialCharacterText.text = name[0].ToString();
    }
}
