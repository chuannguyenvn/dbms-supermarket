using UnityEngine;

public class ApplicationManager : PersistentSingleton<ApplicationManager>
{
    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 60;
    }
}
