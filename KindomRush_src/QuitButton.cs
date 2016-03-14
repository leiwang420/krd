using System;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    protected LoadingScreen loadingScreen;
    protected PackedSprite sprite;

    public QuitButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected void OnMouseDown()
    {
        GameSoundManager.StopMeleeFight();
        GameData.LevelToLoad = 1;
        this.loadingScreen.Launch();
        return;
    }

    protected void OnMouseEnter()
    {
        GameSoundManager.PlayGUIButtonCommon();
        this.sprite.PlayAnim("over");
        return;
    }

    protected void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        return;
    }
}

