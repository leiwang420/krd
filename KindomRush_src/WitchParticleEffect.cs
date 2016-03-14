using System;
using UnityEngine;

public class WitchParticleEffect : MonoBehaviour
{
    private float fadeSpeed;
    private bool isPaused;
    private float opacity;
    private float rotation;
    private float scale;
    private float scaleSpeed;
    private PackedSprite sprite;

    public WitchParticleEffect()
    {
        this.opacity = 1f;
        base..ctor();
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
        if (this.opacity > 0.2f)
        {
            goto Label_0027;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0027:
        this.opacity -= this.fadeSpeed;
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
        this.fadeSpeed = 0.6f;
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

