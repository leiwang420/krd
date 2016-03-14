using System;
using UnityEngine;

public class MainMenuButtonConfirm : MonoBehaviour
{
    protected PackedSprite sprite;

    public MainMenuButtonConfirm()
    {
        base..ctor();
        return;
    }

    protected virtual void Action()
    {
    }

    private void FixedUpdate()
    {
    }

    protected void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
        return;
    }

    protected void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    protected void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    protected void OnMouseUp()
    {
        this.sprite.RevertToStatic();
        GameSoundManager.PlayGUIButtonCommon();
        this.Action();
        return;
    }

    protected void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

