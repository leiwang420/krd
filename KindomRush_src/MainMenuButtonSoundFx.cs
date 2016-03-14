using System;
using UnityEngine;

public class MainMenuButtonSoundFx : MainMenuButtonSound
{
    public MainMenuButtonSoundFx()
    {
        base..ctor();
        return;
    }

    protected override unsafe void CustomInit()
    {
        Vector3 vector;
        base.bar = base.transform.parent.FindChild("BarFx");
        base.percentage = GameSoundManager.GetVolumeFx();
        base.transform.localPosition = new Vector3(Mathf.Round((base.percentage * 268f) - 134f), &base.transform.localPosition.y, -2f);
        base.CustomInit();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected override void OnMouseUp()
    {
        base.sprite.RevertToStatic();
        base.dragging = 0;
        GameSoundManager.PlayFxCheck();
        return;
    }

    protected override void SetVolAndScale()
    {
        base.bar.transform.localScale = new Vector3(base.percentage, 1f, 1f);
        GameSoundManager.SetVolumeFx(base.percentage);
        return;
    }
}

