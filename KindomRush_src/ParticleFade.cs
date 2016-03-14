using System;
using UnityEngine;

public class ParticleFade : MonoBehaviour
{
    public float fadeSpeed;
    private bool isPaused;
    private float opacity;
    private PackedSprite sprite;

    public ParticleFade()
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
        if (this.opacity > 0.1f)
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
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

