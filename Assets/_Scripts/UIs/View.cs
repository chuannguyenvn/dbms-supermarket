using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}