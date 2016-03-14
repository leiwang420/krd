using System;
using System.Collections;
using UnityEngine;

public class CreepWitch : CreepBlackburn
{
    public int attackMaxDamage;
    public int attackMinDamage;
    public int attackMinRange;
    public int attackRangeWidth;
    protected Soldier attackTarget;
    protected Vector3 destinyPoint;
    protected bool isRangeAttack;
    public Transform projectilePrefab;
    protected int rangeAttackChargeTime;
    protected int rangeAttackChargeTimeCounter;
    public int rangeAttackReloadTime;
    protected int rangeAttackReloadTimeCounter;

    public CreepWitch()
    {
        this.rangeAttackChargeTime = 0x22;
        base..ctor();
        return;
    }

    protected virtual unsafe void FireProjectile(Vector3 destiny)
    {
        Vector3 vector;
        Transform transform;
        WitchProjectile projectile;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_0071;
        }
        &vector = new Vector3(&base.transform.position.x - 7f, &base.transform.position.y + 18f, &base.transform.position.z);
        goto Label_00C0;
    Label_0071:
        &vector = new Vector3(&base.transform.position.x + 7f, &base.transform.position.y + 18f, &base.transform.position.z);
    Label_00C0:
        transform = UnityEngine.Object.Instantiate(this.projectilePrefab, vector, Quaternion.identity) as Transform;
        projectile = transform.GetComponent<WitchProjectile>();
        projectile.SetTarget(this.attackTarget, &destiny.x, &destiny.y);
        projectile.SetDamage(this.getattackDamage());
        projectile.SetIgnoresArmor(0);
        return;
    }

    protected int getattackDamage()
    {
        int num;
        return Mathf.RoundToInt(((float) this.attackMinDamage) + Mathf.Ceil(UnityEngine.Random.Range(0f, 1f) * ((float) (this.attackMaxDamage - this.attackMinDamage))));
    }

    protected bool getattackTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.attackTarget = null;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_001A:
        try
        {
            goto Label_0082;
        Label_001F:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0082;
            }
            if (IronUtils.ellipseContainPoint(soldier.transform.position, ((float) this.attackRangeWidth) * 0.7f, (float) this.attackRangeWidth, base.transform.position) == null)
            {
                goto Label_0082;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_0082;
            }
            this.attackTarget = soldier;
            goto Label_008D;
        Label_0082:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_008D:
            goto Label_00A4;
        }
        finally
        {
        Label_0092:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_009D;
            }
        Label_009D:
            disposable.Dispose();
        }
    Label_00A4:
        if ((this.attackTarget != null) == null)
        {
            goto Label_00B7;
        }
        return 1;
    Label_00B7:
        return 0;
    }

    protected override void InitCustomSettings()
    {
    }

    protected unsafe bool MinDistance(Soldier tmpSoldier)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &tmpSoldier.transform.position.x - &base.transform.position.x;
        num3 = &tmpSoldier.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.attackMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected virtual unsafe void SetDestinyPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        this.destinyPoint = new Vector2(&this.attackTarget.transform.position.x, &this.attackTarget.transform.position.y + 18f);
        return;
    }

    protected override unsafe bool SpecialPower()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.isRangeAttack != null)
        {
            goto Label_0124;
        }
        if (base.isBlocked == null)
        {
            goto Label_0018;
        }
        return 0;
    Label_0018:
        if (this.rangeAttackReloadTimeCounter >= this.rangeAttackReloadTime)
        {
            goto Label_0039;
        }
        this.rangeAttackReloadTimeCounter += 1;
        return 0;
    Label_0039:
        if (this.getattackTarget() != null)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        if (&this.attackTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00B9;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00F7;
    Label_00B9:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
    Label_00F7:
        this.SetDestinyPoint();
        this.isRangeAttack = 1;
        base.isStopped = 1;
        this.rangeAttackChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("attack");
        return 1;
    Label_0124:
        if (this.rangeAttackChargeTimeCounter >= this.rangeAttackChargeTime)
        {
            goto Label_0183;
        }
        this.rangeAttackChargeTimeCounter += 1;
        if (this.rangeAttackChargeTimeCounter != 0x15)
        {
            goto Label_0181;
        }
        vector = this.destinyPoint;
        if ((this.attackTarget == null) == null)
        {
            goto Label_017A;
        }
        if (this.getattackTarget() != null)
        {
            goto Label_017A;
        }
        vector = this.destinyPoint;
    Label_017A:
        this.FireProjectile(vector);
    Label_0181:
        return 1;
    Label_0183:
        this.isRangeAttack = 0;
        this.rangeAttackReloadTimeCounter = 0;
        this.rangeAttackChargeTimeCounter = 0;
        base.isStopped = 0;
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_01B7;
        }
        this.CheckFacing();
    Label_01B7:
        return 0;
    }
}

