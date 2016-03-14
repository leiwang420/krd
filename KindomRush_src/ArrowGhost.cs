using System;
using UnityEngine;

public class ArrowGhost : MonoBehaviour
{
    private float fadeSpeed;
    private float fadeTime;
    private float fadeTimeCounter;
    private float opacity;
    private PackedSprite sprite;

    public ArrowGhost()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        this.opacity -= this.fadeSpeed * Time.deltaTime;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity > 0f)
        {
            goto Label_0059;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0059:
        return;
    }

    private void Start()
    {
        this.fadeTime = 0.1f;
        this.fadeSpeed = 1f / this.fadeTime;
        this.opacity = 1f;
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

