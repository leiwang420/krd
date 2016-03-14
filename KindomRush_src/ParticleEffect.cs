using System;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    private float fadeSpeed;
    private bool isPaused;
    private float opacity;
    private float rotation;
    private float scale;
    private float scaleSpeed;
    private PackedSprite sprite;

    public ParticleEffect()
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
        this.scale += this.scaleSpeed;
        base.transform.localScale = new Vector3(this.scale, this.scale, 1f);
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void Start()
    {
        this.scale = (UnityEngine.Random.Range(0f, 1f) * 0.75f) + 0.3f;
        this.scaleSpeed = (UnityEngine.Random.Range(0f, 1f) * 0.05f) + 0.015f;
        this.fadeSpeed = (UnityEngine.Random.Range(0f, 1f) * 0.05f) + 0.015f;
        this.rotation = UnityEngine.Random.Range(0f, 1f) * 360f;
        this.sprite = base.GetComponent<PackedSprite>();
        base.transform.Rotate(0f, 0f, this.rotation);
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

