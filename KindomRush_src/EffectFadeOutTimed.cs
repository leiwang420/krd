using System;
using UnityEngine;

public class EffectFadeOutTimed : MonoBehaviour
{
    private bool isActive;
    private float opacity;
    private float speed;
    private PackedSprite sprite;

    public EffectFadeOutTimed()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    private void FixedUpdate()
    {
        if (this.isActive != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.opacity -= this.speed * Time.deltaTime;
        if (this.opacity > 0f)
        {
            goto Label_0065;
        }
        this.sprite.SetColor(new Color(1f, 1f, 1f, 0f));
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0065:
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        return;
    }

    public void Init(float duration)
    {
        this.speed = 1f / duration;
        this.isActive = 1;
        this.opacity = 1f;
        return;
    }

    private void Start()
    {
    }
}

