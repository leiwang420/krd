using System;
using UnityEngine;

public class ButtonConfigHome : MonoBehaviour
{
    private LoadingScreen loadingScreen;
    private MenuOptions menuOptions;
    private PackedSprite sprite;

    public ButtonConfigHome()
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
        GameSoundManager.PlayGUIButtonCommon();
        this.menuOptions.Close(1);
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
        GameData.SaveGameData();
        GameData.LevelToLoad = 0;
        this.loadingScreen.Launch();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        this.menuOptions = GameObject.Find("MenuOptions").GetComponent<MenuOptions>();
        return;
    }
}

