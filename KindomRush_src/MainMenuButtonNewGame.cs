using System;
using UnityEngine;

public class MainMenuButtonNewGame : MainMenuButtonBase
{
    private LoadingScreen loadingScreen;
    private int slotNumber;

    public MainMenuButtonNewGame()
    {
        base..ctor();
        return;
    }

    protected override void CustomInit()
    {
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        GameData.CurrentSlot = this.slotNumber;
        GameData.LevelToLoad = 1;
        GameData.LoadGameData();
        this.loadingScreen.Launch();
        return;
    }

    public int SlotNumber
    {
        set
        {
            this.slotNumber = value;
            return;
        }
    }
}

