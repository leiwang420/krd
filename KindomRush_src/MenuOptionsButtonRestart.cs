using System;
using UnityEngine;

public class MenuOptionsButtonRestart : MonoBehaviour
{
    private PauseButton pause;
    private PackedSprite sprite;

    public MenuOptionsButtonRestart()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void OnMouseUp()
    {
        GameSoundManager.StopMeleeFight();
        this.sprite.RevertToStatic();
        Application.LoadLevel(Application.loadedLevel);
        this.pause.UnPause(0, 0);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.pause = GameObject.Find("Pause Button").transform.FindChild("Button").GetComponent<PauseButton>();
        return;
    }
}

