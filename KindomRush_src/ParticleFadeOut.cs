using System;
using UnityEngine;

public class ParticleFadeOut : MonoBehaviour
{
    public float fadeSpeed;
    public float finalOpacity;
    public bool hideAtEnd;
    public float initialOpacity;
    private bool isPaused;
    private float opacity;
    private PackedSprite sprite;

    public ParticleFadeOut()
    {
        this.initialOpacity = 1f;
        this.opacity = 1f;
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.isPaused = 1;
        return;
    }

    public void Fade()
    {
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.opacity = this.initialOpacity;
        this.isPaused = 0;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.sprite.IsHidden() == null)
        {
            goto Label_0071;
        }
        this.sprite.Hide(0);
    Label_0071:
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
        if (this.opacity > this.finalOpacity)
        {
            goto Label_0060;
        }
        this.isPaused = 1;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.finalOpacity));
        if (this.hideAtEnd == null)
        {
            goto Label_0060;
        }
        this.sprite.Hide(1);
    Label_0060:
        this.opacity -= this.fadeSpeed;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public void Reset()
    {
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.isPaused = 1;
        this.sprite.SetColor(new Color(1f, 1f, 1f, 1f));
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    private void TimedFade()
    {
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.opacity = this.initialOpacity;
        this.isPaused = 0;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.sprite.IsHidden() == null)
        {
            goto Label_0071;
        }
        this.sprite.Hide(0);
    Label_0071:
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

