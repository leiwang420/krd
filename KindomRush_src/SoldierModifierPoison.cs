using System;
using UnityEngine;

public class SoldierModifierPoison : SoldierModifier
{
    private int damage;
    private int damageBase;
    private float damageTime;
    private float damageTimeCounter;

    public SoldierModifierPoison()
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
        base.target.HidePoison();
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
        base.level = l;
        if (l != 1)
        {
            goto Label_0030;
        }
        this.damage = 2;
        this.damageTime = 3f;
        base.duration = 5f;
        goto Label_004D;
    Label_0030:
        this.damage = 4;
        this.damageTime = 1f;
        base.duration = 5f;
    Label_004D:
        base.durationTimer = 0f;
        return;
    }

    public override void Show()
    {
    }

    private void Start()
    {
        this.damage = 2;
        this.damageBase = 2;
        this.damageTime = 3f;
        this.damageTimeCounter = 0f;
        base.durationTimer = 0f;
        base.duration = 5f;
        base.target = base.GetComponent<Soldier>();
        if ((base.target != null) == null)
        {
            goto Label_0062;
        }
        base.target.ShowPoison();
    Label_0062:
        return;
    }
}

