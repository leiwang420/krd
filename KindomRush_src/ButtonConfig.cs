using System;
using UnityEngine;

public class ButtonConfig : MonoBehaviour
{
    private Map map;
    private MenuOptions menuOptions;
    private bool menuShown;
    private PackedSprite sprite;

    public ButtonConfig()
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
        if (this.menuShown != null)
        {
            goto Label_004D;
        }
        this.map.DisableMapButtons();
        this.map.ShowOverlay();
        this.menuOptions.Show();
        this.menuShown = 1;
        goto Label_0076;
    Label_004D:
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.menuOptions.Close(1);
        this.menuShown = 0;
    Label_0076:
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

    public void Reset()
    {
        this.menuShown = 0;
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.menuOptions = GameObject.Find("MenuOptions").GetComponent<MenuOptions>();
        this.map = GameObject.Find("Map").GetComponent<Map>();
        return;
    }
}

