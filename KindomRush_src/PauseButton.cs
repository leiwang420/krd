using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private MenuOptions menu;
    private bool paused;
    private Quickmenu quickmenu;
    private PackedSprite sprite;
    private StageBase stage;

    public PauseButton()
    {
        base..ctor();
        return;
    }

    private void DisableTime()
    {
        Time.timeScale = 0f;
        return;
    }

    private void EnableTime()
    {
        Time.timeScale = 1f;
        return;
    }

    private void FixedUpdate()
    {
    }

    protected void OnMouseDown()
    {
        if (this.paused != null)
        {
            goto Label_0016;
        }
        this.Pause();
        goto Label_0029;
    Label_0016:
        if (this.paused == null)
        {
            goto Label_0029;
        }
        this.UnPause(1, 1);
    Label_0029:
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

    public void Pause()
    {
        base.Invoke("DisableTime", 0.1f);
        this.paused = 1;
        this.stage.Pause(1);
        this.stage.PauseMusic();
        GameSoundManager.Pause();
        this.menu.Show();
        if (this.stage.GetCurrentWaveNumber() == null)
        {
            goto Label_0059;
        }
        this.stage.DisablePowers();
    Label_0059:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.menu = GameObject.Find("MenuOptions").GetComponent<MenuOptions>();
        this.quickmenu = GameObject.Find("Quickmenu").GetComponent<Quickmenu>();
        return;
    }

    public void UnPause(bool hideOverlay = true, bool menuFade = true)
    {
        this.EnableTime();
        this.paused = 0;
        this.stage.UnPause(hideOverlay);
        this.stage.UnpauseMusic();
        GameSoundManager.Unpause();
        this.menu.Close(menuFade);
        return;
    }
}

