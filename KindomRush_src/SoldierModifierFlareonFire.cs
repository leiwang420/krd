using System;
using UnityEngine;

public class SoldierModifierFlareonFire : SoldierModifier
{
    private int damage;
    private int damageBase;
    private float damageTime;
    private float damageTimeCounter;

    public SoldierModifierFlareonFire()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if ((base.target != null) == null)
        {
            goto Label_008C;
        }
        base.durationTimer += Time.deltaTime;
        this.damageTimeCounter += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_005E;
        }
        base.target.HideFire();
        return;
    Label_005E:
        if (this.damageTimeCounter < this.damageTime)
        {
            goto Label_008C;
        }
        this.damageTimeCounter = 0f;
        base.target.SetDamage(this.damage, 1);
    Label_008C:
        return;
    }

    public override void ResetToLevel(int lvl)
    {
        this.SetProperties(lvl);
        base.durationTimer = 0f;
        this.damageTimeCounter = 0f;
        return;
    }

    public override void SetProperties(int l)
    {
        this.damage = this.damageBase * l;
        base.level = l;
        return;
    }

    public override void Show()
    {
    }

    private void Start()
    {
        this.damage = 20;
        this.damageBase = 20;
        this.damageTime = 0.3f;
        this.damageTimeCounter = 0f;
        base.durationTimer = 0f;
        base.duration = 3f;
        base.target = base.GetComponent<Soldier>();
        return;
    }
}

