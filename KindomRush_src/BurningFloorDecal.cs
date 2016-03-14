using System;
using UnityEngine;

public class BurningFloorDecal : MonoBehaviour
{
    private ParticleFadeIn fadeIn;
    private ParticleFadeOut fadeOut;

    public BurningFloorDecal()
    {
        base..ctor();
        return;
    }

    public void SetOff()
    {
        this.fadeOut.Fade();
        return;
    }

    public void SetOn()
    {
        this.fadeIn.FadeIn();
        return;
    }

    private void Start()
    {
        this.fadeIn = base.GetComponent<ParticleFadeIn>();
        this.fadeOut = base.GetComponent<ParticleFadeOut>();
        base.GetComponent<PackedSprite>().SetColor(new Color(1f, 1f, 1f, 0f));
        return;
    }

    private void Update()
    {
    }
}

