using System;
using UnityEngine;

public class VeznanSoulParticle : MonoBehaviour
{
    private int activeTimeCounter;
    private float fadeSpeed;
    private bool isActive;
    private float opacity;
    private float scaleSpeed;
    private PackedSprite sprite;

    public VeznanSoulParticle()
    {
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        Vector3 vector;
        Vector3 vector2;
        if (this.isActive != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.opacity > 0.6f)
        {
            goto Label_0027;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0027:
        this.opacity -= this.fadeSpeed;
        base.transform.localScale = new Vector3(&base.transform.localScale.x + this.scaleSpeed, &base.transform.localScale.y + this.scaleSpeed, 1f);
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        return;
    }

    public void Go()
    {
        this.isActive = 1;
        this.sprite.Hide(0);
        return;
    }

    private void Start()
    {
        this.opacity = 1f;
        this.sprite = base.GetComponent<PackedSprite>();
        base.transform.Rotate(0f, 0f, UnityEngine.Random.Range(0f, 1f));
        this.fadeSpeed = (UnityEngine.Random.Range(0f, 1f) * 0.2f) + 0.06f;
        this.scaleSpeed = (UnityEngine.Random.Range(0f, 1f) * 0.05f) + 0.01f;
        base.transform.localScale = new Vector3((UnityEngine.Random.Range(0f, 1f) * 0.75f) + 0.25f, (UnityEngine.Random.Range(0f, 1f) * 0.75f) + 0.25f, 1f);
        return;
    }
}

