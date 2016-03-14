using System;
using System.Collections;
using UnityEngine;

public class CreepLavaElemental : Creep
{
    public Transform decalSmokePrefab;
    public Transform effectSmokePrefab;

    public CreepLavaElemental()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        int num;
        ArrayList list;
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
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
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
            goto Label_004F;
        }
        return new Vector2(&base.transform.position.x + 42f, &base.transform.position.y);
    Label_004F:
        return new Vector2(&base.transform.position.x - 42f, &base.transform.position.y);
    }

    protected override void InitCustomSettings()
    {
        base.creepSprite = base.GetComponent<PackedSprite>();
        return;
    }

    protected override unsafe bool ReadyToDamage()
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
            goto Label_00B9;
        }
        base.areaAttackPoint = this.GetAttackPoint();
        UnityEngine.Object.Instantiate(this.decalSmokePrefab, new Vector3(&this.areaAttackPoint.x, &this.areaAttackPoint.y - 35f, -3f), Quaternion.identity);
        UnityEngine.Object.Instantiate(this.effectSmokePrefab, new Vector3(&this.areaAttackPoint.x, &this.areaAttackPoint.y - 17f, -800f), Quaternion.identity);
        GameSoundManager.PlayAreaAttack();
        goto Label_0102;
    Label_00B9:
        if (base.attackChargeTimeCounter != base.attackDodgeTime)
        {
            goto Label_0102;
        }
        if ((base.soldier != null) == null)
        {
            goto Label_0102;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_0102;
        }
        if (base.soldier.DodgeHit() == null)
        {
            goto Label_0102;
        }
        base.attackIsDodged = 1;
    Label_0102:
        return 0;
    }
}

