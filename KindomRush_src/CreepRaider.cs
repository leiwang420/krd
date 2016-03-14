using System;
using System.Collections;
using UnityEngine;

public class CreepRaider : Creep
{
    protected int ballChargeTime;
    protected int ballChargeTimeCounter;
    protected int ballMaxDamage;
    protected int ballMinDamage;
    protected int ballMinRange;
    protected bool ballOnTarget;
    public Transform ballPrefab;
    protected int ballRangeHeight;
    protected int ballRangeWidth;
    protected int ballReloadTime;
    protected int ballReloadTimeCounter;
    protected Soldier ballTarget;
    protected Vector2 destinyPoint;
    protected bool isBall;
    protected int tmpAxeRotation;

    public CreepRaider()
    {
        base..ctor();
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        this.isBall = 0;
        base.creepSprite.RevertToStatic();
        return;
    }

    protected int GetBallDamage()
    {
        return UnityEngine.Random.Range(this.ballMinDamage, this.ballMaxDamage + 1);
    }

    protected bool GetBallTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.ballTarget = null;
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
            if (IronUtils.ellipseContainPoint(soldier.transform.position, (float) this.ballRangeHeight, (float) this.ballRangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_007C;
            }
            this.ballTarget = soldier;
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
        if ((this.ballTarget != null) == null)
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
        this.ballReloadTime = 0x2d;
        this.ballRangeWidth = 0x1d1 + UnityEngine.Random.Range(-70, 0x1f);
        this.ballRangeHeight = Mathf.RoundToInt(((float) this.ballRangeWidth) * 0.7f);
        this.ballMinRange = 0x4e;
        this.ballMinDamage = 80;
        this.ballMaxDamage = 120;
        this.ballChargeTime = 0x17;
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.ballMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected override unsafe bool SpecialPower()
    {
        Vector2 vector;
        Vector3 vector2;
        Transform transform;
        Axe axe;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if (this.isBall != null)
        {
            goto Label_0171;
        }
        if (base.isBlocked == null)
        {
            goto Label_0018;
        }
        return 0;
    Label_0018:
        if (this.ballReloadTimeCounter >= this.ballReloadTime)
        {
            goto Label_0039;
        }
        this.ballReloadTimeCounter += 1;
        return 0;
    Label_0039:
        if (this.GetBallTarget() != null)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        if (&this.ballTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00C2;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
        this.tmpAxeRotation = 1;
        goto Label_0107;
    Label_00C2:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        this.tmpAxeRotation = -1;
    Label_0107:
        this.destinyPoint = new Vector2(&this.ballTarget.transform.position.x, &this.ballTarget.transform.position.y + 18f);
        this.isBall = 1;
        base.isStopped = 1;
        this.ballChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        return 1;
    Label_0171:
        if (this.ballChargeTimeCounter >= this.ballChargeTime)
        {
            goto Label_026F;
        }
        this.ballChargeTimeCounter += 1;
        if (this.ballChargeTimeCounter != 0x12)
        {
            goto Label_026D;
        }
        if ((this.ballTarget == null) != null)
        {
            goto Label_01BE;
        }
        if (this.ballTarget.IsActive() != null)
        {
            goto Label_01D0;
        }
    Label_01BE:
        if (this.GetBallTarget() != null)
        {
            goto Label_01D0;
        }
        vector = this.destinyPoint;
    Label_01D0:
        &vector2 = new Vector3(&base.transform.position.x, &base.transform.position.y + 34f, -890f);
        transform = UnityEngine.Object.Instantiate(this.ballPrefab, vector2, Quaternion.identity) as Transform;
        axe = transform.GetComponent<Axe>();
        axe.SetT1(20f);
        axe.SetTarget(this.ballTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        axe.SetDamage(this.GetBallDamage());
        axe.SetRotation(this.tmpAxeRotation);
    Label_026D:
        return 1;
    Label_026F:
        this.isBall = 0;
        this.ballReloadTimeCounter = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_0295;
        }
        this.CheckFacing();
    Label_0295:
        return 0;
    }

    protected void StopSpecialPower()
    {
        this.isBall = 0;
        this.ballOnTarget = 0;
        return;
    }
}

