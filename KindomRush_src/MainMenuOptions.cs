using System;
using UnityEngine;

public class MainMenuOptions : MonoBehaviour
{
    public MainMenuOptions()
    {
        base..ctor();
        return;
    }

    private void AfterHide()
    {
        base.gameObject.SetActive(0);
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-615f, -330f, 0f), "time", (float) 0.2f, "onComplete", "AfterHide" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    public void Show()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-197f, -330f, 0f), "time", (float) 0.25f, "easetype", (iTween.EaseType) 7 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
    }
}

