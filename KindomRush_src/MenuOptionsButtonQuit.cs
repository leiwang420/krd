using System;
using UnityEngine;

public class MenuOptionsButtonQuit : MonoBehaviour
{
    private LoadingScreen loadingScreen;
    private Transform menu;
    private PauseButton pause;
    private PackedSprite sprite;

    public MenuOptionsButtonQuit()
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
        UnityEngine.Object.Destroy(this.menu.gameObject);
        GameSoundManager.StopMeleeFight();
        GameSoundManager.UnmuteSound();
        Time.timeScale = 1f;
        GameData.LevelToLoad = 1;
        this.loadingScreen.Launch();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.menu = base.transform.parent;
        this.pause = GameObject.Find("Pause Button").transform.FindChild("Button").GetComponent<PauseButton>();
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        return;
    }
}

