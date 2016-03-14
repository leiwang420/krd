using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepAbomination : CreepBlackburn
{
    protected bool exploded;
    protected int explodeMaxDamage;
    protected int explodeMinDamage;
    protected int explodeRangeHeight;
    protected int explodeRangeWidth;

    public CreepAbomination()
    {
        base..ctor();
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        base.Damage(dmg, damageType, ignoreArmor, shieldOn);
        if (base.life > 0)
        {
            goto Label_002F;
        }
        if (this.exploded != null)
        {
            goto Label_002F;
        }
        this.exploded = 1;
        this.ExplodeAttack();
    Label_002F:
        return;
    }

    protected void ExplodeAttack()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_005F;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_005F;
            }
            if (soldier.IsDead() != null)
            {
                goto Label_005F;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_005F;
            }
            if (this.OnRangeExplode(soldier) == null)
            {
                goto Label_005F;
            }
            soldier.SetDamage(this.GetDamageExplode(), 0);
        Label_005F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_0081;
        }
        finally
        {
        Label_006F:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007A;
            }
        Label_007A:
            disposable.Dispose();
        }
    Label_0081:
        return;
    }

    protected int GetDamageExplode()
    {
        int num;
        return UnityEngine.Random.Range(this.explodeMinDamage, this.explodeMaxDamage + 1);
    }

    protected override void InitCustomSettings()
    {
        this.explodeRangeHeight = 140;
        this.explodeRangeWidth = 200;
        this.explodeMinDamage = 250;
        this.explodeMaxDamage = 250;
        return;
    }

    protected bool OnRangeExplode(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), (float) this.explodeRangeHeight, (float) this.explodeRangeWidth, base.transform.position + base.anchorPoint);
    }
}

