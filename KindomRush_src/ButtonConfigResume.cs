using System;
using UnityEngine;

public class ButtonConfigResume : MonoBehaviour
{
    private ButtonConfig buttonConfig;
    private Map map;
    private MenuOptions menuOptions;
    private PackedSprite sprite;

    public ButtonConfigResume()
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
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.menuOptions.Close(1);
        this.buttonConfig.Reset();
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
        this.menuOptions = GameObject.Find("MenuOptions").GetComponent<MenuOptions>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.buttonConfig = GameObject.Find("ButtonConfig").GetComponent<ButtonConfig>();
        return;
    }
}

