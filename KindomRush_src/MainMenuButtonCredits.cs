using System;
using UnityEngine;

public class MainMenuButtonCredits : MainMenuButtonBase
{
    private MainMenuCredits screenCredits;

    public MainMenuButtonCredits()
    {
        base..ctor();
        return;
    }

    protected override void CustomInit()
    {
        this.screenCredits = GameObject.Find("ScreenCredits").GetComponent<MainMenuCredits>();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        GameSoundManager.PlayGUIButtonCommon();
        this.screenCredits.Show();
        return;
    }
}

