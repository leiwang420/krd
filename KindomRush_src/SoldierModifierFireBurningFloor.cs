using System;
using UnityEngine;

public class SoldierModifierFireBurningFloor : SoldierModifier
{
    private int damage;
    private int damageBase;
    private float damageTime;
    private float damageTimeCounter;

    public SoldierModifierFireBurningFloor()
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
            goto Label_00A2;
        }
        if (base.target.IsDead() != null)
        {
            goto Label_00A2;
        }
        base.durationTimer += Time.deltaTime;
        this.damageTimeCounter += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_0074;
        }
        base.target.HideFire();
        UnityEngine.Object.Destroy(this);
        return;
    Label_0074:
        if (this.damageTimeCounter < this.damageTime)
        {
            goto Label_00A2;
        }
        this.damageTimeCounter = 0f;
        base.target.SetDamage(this.damage, 1);
    Label_00A2:
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
        if ((base.target != null) == null)
        {
            goto Label_0064;
        }
        base.target.ShowFire();
    Label_0064:
        return;
    }
}

