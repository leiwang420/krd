using System;
using System.Collections;
using UnityEngine;

public class CreepSwampThing : Creep
{
    public Transform bombPrefab;
    protected Vector2 destinyPoint;
    protected bool isThrowing;
    protected int throwChargeTime;
    protected int throwChargeTimeCounter;
    protected int throwMaxDamage;
    protected int throwMinDamage;
    protected int throwMinRange;
    protected bool throwOnTarget;
    protected int throwRangeHeight;
    protected int throwRangeWidth;
    protected int throwReloadTime;
    protected int throwReloadTimeCounter;
    protected Soldier throwTarget;

    public CreepSwampThing()
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

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        this.isThrowing = 0;
        base.creepSprite.RevertToStatic();
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

    protected int GetThrowDamage()
    {
        return UnityEngine.Random.Range(this.throwMinDamage, this.throwMaxDamage + 1);
    }

    protected bool GetThrowTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.throwTarget = null;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_001A:
        try
        {
            goto Label_007C;
        Label_001F:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_007C;
            }
            if (IronUtils.ellipseContainPoint(soldier.transform.position, (float) this.throwRangeHeight, (float) this.throwRangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_007C;
            }
            this.throwTarget = soldier;
            goto Label_0087;
        Label_007C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_0087:
            goto Label_009E;
        }
        finally
        {
        Label_008C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0097;
            }
        Label_0097:
            disposable.Dispose();
        }
    Label_009E:
        if ((this.throwTarget != null) == null)
        {
            goto Label_00B1;
        }
        return 1;
    Label_00B1:
        return 0;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.throwReloadTime = 30;
        this.throwRangeWidth = 0x1d1 + UnityEngine.Random.Range(-70, 0x1f);
        this.throwRangeHeight = Mathf.RoundToInt(((float) this.throwRangeWidth) * 0.7f);
        this.throwMinRange = 0x55;
        this.throwMinDamage = 30;
        this.throwMaxDamage = 60;
        this.throwChargeTime = 12;
        this.throwReloadTime = 30;
        this.throwRangeWidth = 0x1d1 + UnityEngine.Random.Range(-70, 30);
        this.throwRangeHeight = Mathf.RoundToInt(((float) this.throwRangeWidth) * 0.7f);
        this.throwMinRange = 0x9b;
        this.throwMinDamage = 40;
        this.throwMaxDamage = 100;
        this.throwChargeTime = 0x20;
        base.regenerateTimeCounter = 0;
        base.regenerateTime = 1;
        base.regenerateHealPoints = 1;
        return;
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.throwMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
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

    protected override unsafe bool SpecialPower()
    {
        Vector2 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        if (this.isThrowing != null)
        {
            goto Label_01A5;
        }
        if (base.isBlocked == null)
        {
            goto Label_002A;
        }
        if (this.throwOnTarget == null)
        {
            goto Label_0028;
        }
        this.throwOnTarget = 0;
    Label_0028:
        return 0;
    Label_002A:
        if (this.throwReloadTimeCounter >= this.throwReloadTime)
        {
            goto Label_0050;
        }
        this.throwReloadTimeCounter += 1;
        return this.throwOnTarget;
    Label_0050:
        if (this.GetThrowTarget() != null)
        {
            goto Label_0083;
        }
        if (this.throwOnTarget == null)
        {
            goto Label_007A;
        }
        base.isStopped = 0;
        base.facing = 4;
        this.CheckFacing();
    Label_007A:
        this.throwOnTarget = 0;
        return 0;
    Label_0083:
        if (&this.throwTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00F6;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_0134;
    Label_00F6:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
    Label_0134:
        this.destinyPoint = new Vector2(&this.throwTarget.transform.position.x, &this.throwTarget.transform.position.y + 18f);
        this.isThrowing = 1;
        base.isStopped = 1;
        this.throwOnTarget = 1;
        this.throwChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        return 1;
    Label_01A5:
        if (this.throwChargeTimeCounter >= this.throwChargeTime)
        {
            goto Label_0311;
        }
        this.throwChargeTimeCounter += 1;
        if (this.throwChargeTimeCounter != 15)
        {
            goto Label_030F;
        }
        if ((this.throwTarget == null) != null)
        {
            goto Label_01F2;
        }
        if (this.throwTarget.IsActive() != null)
        {
            goto Label_024C;
        }
    Label_01F2:
        if (this.GetThrowTarget() != null)
        {
            goto Label_0209;
        }
        vector = this.destinyPoint;
        goto Label_024C;
    Label_0209:
        this.destinyPoint = new Vector2(&this.throwTarget.transform.position.x, &this.throwTarget.transform.position.y + 18f);
    Label_024C:
        transform = UnityEngine.Object.Instantiate(this.bombPrefab, new Vector3(&base.transform.position.x + 6f, &base.transform.position.y + 18f, -890f), Quaternion.identity) as Transform;
        transform.GetComponent<BombZapper>().SetTarget(this.throwTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        transform.GetComponent<BombZapper>().SetDamage(this.throwMinDamage, this.throwMaxDamage);
        transform.GetComponent<BombZapper>().SetArea(141f);
        transform.GetComponent<BombZapper>().SetT1(25f);
        transform.GetComponent<BombZapper>().SetStage(base.stage);
    Label_030F:
        return 1;
    Label_0311:
        this.isThrowing = 0;
        this.throwReloadTimeCounter = 0;
        return 1;
    }

    protected void StopSpecialMove()
    {
        this.isThrowing = 0;
        this.throwOnTarget = 0;
        return;
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        this.isThrowing = 0;
        this.throwOnTarget = 0;
        return;
    }
}

