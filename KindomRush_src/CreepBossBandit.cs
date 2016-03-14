using System;
using System.Collections;
using UnityEngine;

public class CreepBossBandit : Creep
{
    protected int areaReloadTime;
    protected int areaReloadTimeCounter;
    protected int healingMePoints;
    protected int healingPoints;
    protected int healingRangeHeight;
    protected int healingRangeWidth;
    protected bool isWaiting;
    protected bool isWaitingMoney;
    protected int waitingDurationTime;
    protected int waitingDurationTimeCounter;
    protected int waitingReloadTime;
    protected int waitingReloadTimeCounter;

    public CreepBossBandit()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        base.areaAttackPoint = this.GetAttackPoint();
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_001F:
        try
        {
            goto Label_0054;
        Label_0024:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0054;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0054;
            }
            soldier.SetDamage(base.GetDamage(), 0);
        Label_0054:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
            }
            goto Label_0076;
        }
        finally
        {
        Label_0064:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006F;
            }
        Label_006F:
            disposable.Dispose();
        }
    Label_0076:
        return;
    }

    protected bool CanHeal(Creep myEnemy)
    {
        if (myEnemy.GetHealth() >= myEnemy.GetTotalLife())
        {
            goto Label_0013;
        }
        return 1;
    Label_0013:
        return 0;
    }

    protected void CheckBarricades()
    {
        if (((Stage17) base.stage).GetBarricade(0).IsActive() == null)
        {
            goto Label_0048;
        }
        if (this.OnRangeBarricade(((Stage17) base.stage).GetBarricade(0)) == null)
        {
            goto Label_0048;
        }
        ((Stage17) base.stage).DestroyBarricade(0);
    Label_0048:
        if (((Stage17) base.stage).GetBarricade(1).IsActive() == null)
        {
            goto Label_0090;
        }
        if (this.OnRangeBarricade(((Stage17) base.stage).GetBarricade(1)) == null)
        {
            goto Label_0090;
        }
        ((Stage17) base.stage).DestroyBarricade(1);
    Label_0090:
        if (((Stage17) base.stage).GetBarricade(2).IsActive() == null)
        {
            goto Label_00D8;
        }
        if (this.OnRangeBarricade(((Stage17) base.stage).GetBarricade(2)) == null)
        {
            goto Label_00D8;
        }
        ((Stage17) base.stage).DestroyBarricade(2);
    Label_00D8:
        return;
    }

    protected override unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        return new Vector2(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected void HealTargets()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0058;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0058;
            }
            if ((creep != this) == null)
            {
                goto Label_0058;
            }
            if (this.OnRangeHealing(creep) == null)
            {
                goto Label_0058;
            }
            creep.Heal(this.healingPoints);
        Label_0058:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_007A;
        }
        finally
        {
        Label_0068:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0073;
            }
        Label_0073:
            disposable.Dispose();
        }
    Label_007A:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.canBeBlocked = 0;
        this.areaReloadTime = 1;
        this.areaReloadTimeCounter = 0;
        base.areaAttackRangeWidth = 0xb7;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        this.isWaiting = 0;
        this.waitingReloadTime = 150;
        this.waitingReloadTimeCounter = 0;
        this.waitingDurationTime = 150;
        this.waitingDurationTimeCounter = 0;
        this.healingMePoints = 500;
        this.healingRangeWidth = 0x11a;
        this.healingRangeHeight = Mathf.RoundToInt(((float) this.healingRangeWidth) * 0.7f);
        this.healingPoints = 50;
        base.fadingTime = 120;
        GameData.notificationEnemyBossBandit = 1;
        base.stage.PlayMusicBossFight();
        return;
    }

    protected bool OnRange(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, base.areaAttackPoint);
    }

    protected bool OnRangeBarricade(Barricade myBarricade)
    {
        return IronUtils.ellipseContainPoint(myBarricade.transform.position, (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, base.transform.position + base.anchorPoint);
    }

    protected bool OnRangeHealing(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.healingRangeHeight, (float) this.healingRangeWidth, base.transform.position + base.anchorPoint);
    }

    protected override bool SpecialPower()
    {
        if (this.areaReloadTimeCounter >= this.areaReloadTime)
        {
            goto Label_0024;
        }
        this.areaReloadTimeCounter += 1;
        goto Label_0037;
    Label_0024:
        this.CheckBarricades();
        this.Attack();
        this.areaReloadTimeCounter = 0;
    Label_0037:
        if (this.isWaiting == null)
        {
            goto Label_00BA;
        }
        this.waitingDurationTimeCounter += 1;
        if (this.waitingDurationTimeCounter >= this.waitingDurationTime)
        {
            goto Label_0092;
        }
        if (this.waitingDurationTimeCounter != 0x19)
        {
            goto Label_0090;
        }
        if (this.isWaitingMoney == null)
        {
            goto Label_0084;
        }
        this.HealTargets();
        goto Label_0090;
    Label_0084:
        base.Heal(this.healingMePoints);
    Label_0090:
        return 1;
    Label_0092:
        this.isWaiting = 0;
        this.waitingReloadTimeCounter = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_00B8;
        }
        this.CheckFacing();
    Label_00B8:
        return 0;
    Label_00BA:
        this.waitingReloadTimeCounter += 1;
        if (this.waitingReloadTimeCounter >= this.waitingReloadTime)
        {
            goto Label_00DB;
        }
        return 0;
    Label_00DB:
        this.isWaiting = 1;
        if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
        {
            goto Label_0117;
        }
        this.isWaitingMoney = 1;
        base.creepSprite.PlayAnim("money");
        goto Label_012E;
    Label_0117:
        this.isWaitingMoney = 0;
        base.creepSprite.PlayAnim("eat");
    Label_012E:
        this.waitingDurationTimeCounter = 0;
        return 1;
    }
}

