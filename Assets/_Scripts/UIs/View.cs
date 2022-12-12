using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    
    public void Show()
    {
        canvasGroup.alpha = 1f;
    }
    
    public void Hide()
    {
        canvasGroup.alpha = 0f;
    }
}