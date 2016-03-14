using System;
using UnityEngine;

public class EnemyModifierSlow : EnemyModifier
{
    private float removeSpeed;
    private float slowFactor;

    public EnemyModifierSlow()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        base.durationTimer += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_0052;
        }
        if ((base.target != null) == null)
        {
            goto Label_004C;
        }
        base.target.speed += this.removeSpeed;
    Label_004C:
        UnityEngine.Object.Destroy(this);
    Label_0052:
        return;
    }

    public void Init(float factor, float totalTime)
    {
        this.slowFactor = factor;
        base.duration = totalTime;
        base.target = base.GetComponent<Creep>();
        this.removeSpeed = base.target.speed * this.slowFactor;
        base.target.speed -= this.removeSpeed;
        if (base.target.speed > 0f)
        {
            goto Label_0088;
        }
        base.target.speed = base.target.GetOriginalSpeed() - (base.target.GetOriginalSpeed() * this.slowFactor);
    Label_0088:
        return;
    }

    public void Reset(float factor, float totalTime)
    {
        base.durationTimer = 0f;
        return;
    }
}

