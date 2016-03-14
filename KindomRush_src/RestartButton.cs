using System;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    protected PauseButton pause;
    protected PackedSprite sprite;

    public RestartButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected void OnMouseDown()
    {
        GameSoundManager.StopMeleeFight();
        Application.LoadLevel(Application.loadedLevel);
        return;
    }

    protected void OnMouseEnter()
    {
        GameSoundManager.PlayGUIButtonCommon();
        this.sprite.PlayAnim("over");
        return;
    }

    protected void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void Start()
    {
        object[] objArray1;
        this.sprite = base.GetComponent<PackedSprite>();
        this.pause = GameObject.Find("Pause Button").transform.FindChild("Button").GetComponent<PauseButton>();
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, -194f, -908f), "time", (float) 0.4f, "easetype", (iTween.EaseType) 0x1b };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }
}

