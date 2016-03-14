using System;
using UnityEngine;

public class ParticleFadeIn : MonoBehaviour
{
    public float fadeSpeed;
    public float finalOpacity;
    private bool isPaused;
    private float opacity;
    public bool removeWhenDone;
    private PackedSprite sprite;

    public ParticleFadeIn()
    {
        this.isPaused = 1;
        base..ctor();
        return;
    }

    public void FadeIn()
    {
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.sprite.SetColor(new Color(1f, 1f, 1f, 0f));
        this.opacity = 0f;
        this.isPaused = 0;
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.opacity < this.finalOpacity)
        {
            goto Label_0041;
        }
        this.isPaused = 1;
        this.opacity = this.finalOpacity;
        if (this.removeWhenDone == null)
        {
            goto Label_0041;
        }
        UnityEngine.Object.Destroy(this);
    Label_0041:
        this.opacity += this.fadeSpeed;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

