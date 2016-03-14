using System;
using System.Collections;
using UnityEngine;

public class CreepShadowArcher : Creep
{
    protected int arrowChargeTime;
    protected int arrowChargeTimeCounter;
    protected int arrowMaxDamage;
    protected int arrowMinDamage;
    protected int arrowMinRange;
    protected bool arrowOnTarget;
    public Transform arrowPrefab;
    protected int arrowRangeHeight;
    protected int arrowRangeWidth;
    protected int arrowReloadTime;
    protected int arrowReloadTimeCounter;
    protected Soldier arrowTarget;
    protected Vector2 destinyPoint;
    protected bool isArrowing;

    public CreepShadowArcher()
    {
        base..ctor();
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        this.isArrowing = 0;
        base.creepSprite.RevertToStatic();
        return;
    }

    protected virtual unsafe void FireArrow()
    {
        Transform transform;
        Arrow arrow;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        transform = UnityEngine.Object.Instantiate(this.arrowPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 20f, -900f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        arrow = transform.GetComponent<Arrow>();
        arrow.SetT1(15f);
        arrow.SetTarget(this.arrowTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        arrow.SetDamage(this.GetArrowDamage());
        arrow.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -900f);
        return;
    }

    protected int GetArrowDamage()
    {
        return UnityEngine.Random.Range(base.minDamage, base.maxDamage + 1);
    }

    protected bool GetArrowTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.arrowTarget = null;
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
            if (IronUtils.ellipseContainPoint(soldier.transform.position, (float) this.arrowRangeHeight, (float) this.arrowRangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_007C;
            }
            this.arrowTarget = soldier;
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
        if ((this.arrowTarget != null) == null)
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
        this.arrowReloadTime = 30;
        this.arrowRangeWidth = 0x199 + UnityEngine.Random.Range(-100, 0x2b);
        this.arrowRangeHeight = Mathf.RoundToInt(((float) this.arrowRangeWidth) * 0.7f);
        this.arrowMinRange = 70;
        this.arrowMinDamage = 20;
        this.arrowMaxDamage = 30;
        this.arrowChargeTime = 12;
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.arrowMinRange))
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
        this.destinyPoint = new Vector2(&this.arrowTarget.transform.position.x, &this.arrowTarget.transform.position.y + 18f);
        return;
    }

    protected override unsafe bool SpecialPower()
    {
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if (this.isArrowing != null)
        {
            goto Label_01BD;
        }
        if (base.isBlocked == null)
        {
            goto Label_002A;
        }
        if (this.arrowOnTarget == null)
        {
            goto Label_0028;
        }
        this.arrowOnTarget = 0;
    Label_0028:
        return 0;
    Label_002A:
        if (this.arrowReloadTimeCounter >= this.arrowReloadTime)
        {
            goto Label_0050;
        }
        this.arrowReloadTimeCounter += 1;
        return this.arrowOnTarget;
    Label_0050:
        if (this.GetArrowTarget() != null)
        {
            goto Label_0083;
        }
        if (this.arrowOnTarget == null)
        {
            goto Label_007A;
        }
        base.isStopped = 0;
        base.facing = 4;
        this.CheckFacing();
    Label_007A:
        this.arrowOnTarget = 0;
        return 0;
    Label_0083:
        if (&this.arrowTarget.transform.position.x < &base.transform.position.x)
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
        this.SetDestinyPoint();
        this.isArrowing = 1;
        base.isStopped = 1;
        this.arrowOnTarget = 1;
        this.arrowChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        return 1;
    Label_01BD:
        if (this.arrowChargeTimeCounter >= this.arrowChargeTime)
        {
            goto Label_0223;
        }
        this.arrowChargeTimeCounter += 1;
        if (this.arrowChargeTimeCounter != 7)
        {
            goto Label_0221;
        }
        if ((this.arrowTarget == null) != null)
        {
            goto Label_0209;
        }
        if (this.arrowTarget.IsActive() != null)
        {
            goto Label_021B;
        }
    Label_0209:
        if (this.GetArrowTarget() != null)
        {
            goto Label_021B;
        }
        vector = this.destinyPoint;
    Label_021B:
        this.FireArrow();
    Label_0221:
        return 1;
    Label_0223:
        this.isArrowing = 0;
        this.arrowReloadTimeCounter = 0;
        return 1;
    }

    protected void StopSpecialPower()
    {
        this.isArrowing = 0;
        this.arrowOnTarget = 0;
        return;
    }
}

