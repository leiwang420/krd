using System;
using UnityEngine;

public class TryAgainButton : MonoBehaviour
{
    protected PauseButton pause;
    protected PackedSprite sprite;

    public TryAgainButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected void OnMouseDown()
    {
        Application.LoadLevel(Application.loadedLevel);
        this.pause.UnPause(0, 1);
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
        this.sprite = base.GetComponent<PackedSprite>();
        this.pause = GameObject.Find("Pause Button").transform.FindChild("Button").GetComponent<PauseButton>();
        return;
    }
}

