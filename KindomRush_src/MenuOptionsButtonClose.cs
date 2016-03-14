using System;
using UnityEngine;

public class MenuOptionsButtonClose : MonoBehaviour
{
    private PauseButton pause;
    private PackedSprite sprite;

    public MenuOptionsButtonClose()
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
        this.pause.UnPause(1, 1);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.pause = GameObject.Find("Pause Button").transform.FindChild("Button").GetComponent<PauseButton>();
        return;
    }
}

