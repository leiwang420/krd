using System;
using UnityEngine;

public class ButtonConfigMusic : MonoBehaviour
{
    private MenuOptions menuOptions;
    private PackedSprite sprite;

    public ButtonConfigMusic()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        GameSoundManager.PlayGUIButtonCommon();
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
        this.sprite.RevertToStatic();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.menuOptions = GameObject.Find("MenuOptions").GetComponent<MenuOptions>();
        if (GameSoundManager.IsMusicMuted() == null)
        {
            goto Label_003B;
        }
        this.sprite.PlayAnim("mute");
    Label_003B:
        return;
    }
}

