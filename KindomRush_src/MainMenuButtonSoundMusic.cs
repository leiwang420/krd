using System;
using UnityEngine;

public class MainMenuButtonSoundMusic : MainMenuButtonSound
{
    public MainMenuButtonSoundMusic()
    {
        base..ctor();
        return;
    }

    protected override unsafe void CustomInit()
    {
        Vector3 vector;
        base.menu = base.transform.parent.parent.GetComponent<MainMenu>();
        base.bar = base.transform.parent.FindChild("BarMusic");
        base.percentage = GameSoundManager.GetVolumeMusic();
        base.transform.localPosition = new Vector3(Mathf.Round((base.percentage * 268f) - 134f), &base.transform.localPosition.y, -2f);
        base.CustomInit();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected override void SetVolAndScale()
    {
        base.bar.transform.localScale = new Vector3(base.percentage, 1f, 1f);
        GameSoundManager.SetVolumeMusic(base.percentage);
        base.menu.SetMusicVol();
        return;
    }
}

