using System;
using UnityEngine;

public class CreepWererat : CreepBlackburn
{
    public int PoisonDamage;
    public float PoisonDamageTime;
    public int PoisonDuration;
    public int WeaknessDamagePercent;

    public CreepWererat()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        SoldierModifierGiantRatPoison poison;
        if (base.attackIsDodged == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (UnityEngine.Random.Range(0f, 1f) >= 0.3f)
        {
            goto Label_0025;
        }
    Label_0025:
        if (base.areaAttack != null)
        {
            goto Label_0047;
        }
        base.soldier.SetDamage(base.GetDamage(), 0);
        goto Label_004D;
    Label_0047:
        base.AreaAttack();
    Label_004D:
        if ((base.soldier != null) == null)
        {
            goto Label_00F6;
        }
        if (base.soldier.IsDead() != null)
        {
            goto Label_00F6;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_00F6;
        }
        poison = base.soldier.GetComponent<SoldierModifierGiantRatPoison>();
        if ((poison != null) == null)
        {
            goto Label_00AD;
        }
        poison.ResetToLevel(2);
        base.soldier.ShowRatPoison();
        goto Label_00F6;
    Label_00AD:
        poison = base.soldier.gameObject.AddComponent<SoldierModifierGiantRatPoison>();
        poison.SetProperties(2);
        poison.damageReduced = (float) this.WeaknessDamagePercent;
        poison.damageTime = this.PoisonDamageTime;
        poison.damage = this.PoisonDamage;
        poison.poisonDuration = this.PoisonDuration;
    Label_00F6:
        return;
    }

    protected override void InitCustomSettings()
    {
    }
}

