using System;
using System.Collections;
using UnityEngine;

public class CreepForestTroll : Creep
{
    public CreepForestTroll()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        ArrayList list;
        int num;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        if (base.attackIsDodged == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.areaAttackPoint = this.GetAttackPoint();
        list = base.stage.GetSoldiers();
        num = 0;
        enumerator = list.GetEnumerator();
    Label_002D:
        try
        {
            goto Label_0077;
        Label_0032:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0077;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0077;
            }
            soldier.SetDamage(base.GetDamage(), 0);
            num += 1;
            if (num != base.areaAttackMax)
            {
                goto Label_0077;
            }
            goto Label_0082;
        Label_0077:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0032;
            }
        Label_0082:
            goto Label_009C;
        }
        finally
        {
        Label_0087:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0094;
            }
        Label_0094:
            disposable.Dispose();
        }
    Label_009C:
        return;
    }

    protected override unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_005B;
        }
        return new Vector2(&base.transform.position.x + 42f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 42f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.regenerateHealPoints = 2;
        base.regenerateTime = 30;
        return;
    }

    protected override bool ReadyToDamage()
    {
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter < base.attackChargeTime)
        {
            goto Label_0028;
        }
        base.attackChargeTimeCounter = 0;
        return 1;
    Label_0028:
        if (base.attackChargeTimeCounter != 15)
        {
            goto Label_003A;
        }
        goto Label_0094;
    Label_003A:
        if (base.attackChargeTimeCounter != base.attackDodgeTime)
        {
            goto Label_0094;
        }
        if ((base.soldier != null) == null)
        {
            goto Label_0094;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_0094;
        }
        if (base.soldier.DodgeHit() == null)
        {
            goto Label_0094;
        }
        base.soldier.SetDodgeDamage(base.GetDamage());
        base.attackIsDodged = 1;
    Label_0094:
        return 0;
    }
}

