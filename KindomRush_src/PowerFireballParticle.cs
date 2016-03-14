using System;
using UnityEngine;

public class PowerFireballParticle : MonoBehaviour
{
    private int alphaTime;
    private int alphaTimeCounter;
    private float fadeSpeed;
    private bool isPaused;
    private float opacity;
    private float scaleSpeed;
    private float scaleX;
    private float scaleY;
    private PackedSprite sprite;

    public PowerFireballParticle()
    {
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
        if (this.opacity > 0.14f)
        {
            goto Label_0028;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0028:
        if (this.alphaTimeCounter >= this.alphaTime)
        {
            goto Label_004C;
        }
        this.alphaTimeCounter += 1;
        goto Label_005F;
    Label_004C:
        this.opacity -= this.fadeSpeed;
    Label_005F:
        this.scaleX += this.scaleSpeed;
        this.scaleY += this.scaleSpeed;
        base.transform.localScale = new Vector3(this.scaleX, this.scaleY, 1f);
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
        this.opacity = 1f;
        this.alphaTime = 1;
        this.alphaTimeCounter = 0;
        base.transform.rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 1f) * 360f);
        this.scaleX = (UnityEngine.Random.Range(0f, 1f) * 0.75f) + 0.15f;
        this.scaleY = (UnityEngine.Random.Range(0f, 1f) * 0.75f) + 0.15f;
        this.fadeSpeed = (UnityEngine.Random.Range(0f, 1f) * 0.05f) + 0.1f;
        this.scaleSpeed = (UnityEngine.Random.Range(0f, 1f) * 0.05f) + 0.1f;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

