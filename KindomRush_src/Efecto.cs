using System;
using UnityEngine;

public class Efecto : MonoBehaviour
{
    private float dt;
    public float duration;
    public PackedSprite effectSprite;
    private bool on;

    public Efecto()
    {
        base..ctor();
        return;
    }

    public void Apply()
    {
        this.dt = 0f;
        this.effectSprite.Hide(0);
        this.effectSprite.PlayAnim(0);
        this.on = 1;
        return;
    }

    private void FixedUpdate()
    {
        if (this.on == null)
        {
            goto Label_0057;
        }
        this.dt += Time.deltaTime;
        if (this.dt < this.duration)
        {
            goto Label_0057;
        }
        this.dt = 0f;
        this.effectSprite.StopAnim();
        this.effectSprite.Hide(1);
        this.on = 0;
    Label_0057:
        return;
    }

    private void Start()
    {
        this.dt = 0f;
        this.on = 0;
        return;
    }
}

