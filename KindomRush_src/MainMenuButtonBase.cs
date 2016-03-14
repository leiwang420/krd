using System;
using UnityEngine;

public class MainMenuButtonBase : MonoBehaviour
{
    protected MainMenu menu;
    protected PackedSprite sprite;

    public MainMenuButtonBase()
    {
        base..ctor();
        return;
    }

    protected virtual void CustomInit()
    {
    }

    private void FixedUpdate()
    {
    }

    protected virtual void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
        return;
    }

    protected virtual void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    protected virtual void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    protected virtual void OnMouseUp()
    {
        this.sprite.PlayAnim("over");
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    protected void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.menu = base.transform.parent.GetComponent<MainMenu>();
        this.CustomInit();
        return;
    }
}

