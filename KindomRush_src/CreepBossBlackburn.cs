using System;
using System.Collections;
using UnityEngine;

public class CreepBossBlackburn : CreepBlackburn
{
    protected int impactDamageRange;
    protected int impactMaxAttack;
    protected int impactMaxDamage;
    protected int impactMinDamage;
    protected int impactRange;
    public Transform skeletonWarriorPrefab;
    protected int undeathMax;
    protected int undeathRange;

    public CreepBossBlackburn()
    {
        base..ctor();
        return;
    }

    public override bool BlockShouldSetIdle()
    {
        return (((base.BlockShouldSetIdle() == null) || (base.isBasicSpecial != null)) ? 0 : (base.isCharging == 0));
    }

    protected override void DoSpecial()
    {
        GameObject obj2;
        Hashtable hashtable;
        obj2 = Camera.main.gameObject;
        hashtable = new Hashtable();
        hashtable.Add("x", (float) 4f);
        hashtable.Add("y", (float) 4f);
        hashtable.Add("time", (float) 1.5f);
        iTween.ShakePosition(obj2, hashtable);
        this.HoldTowers();
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
        return new Vector2(&base.transform.position.x + 28f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 28f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected int GetImpactDamage()
    {
        return (this.impactMinDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.impactMaxDamage - this.impactMinDamage))));
    }

    protected void HoldTowers()
    {
        TowerBase[] baseArray;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num;
        ArrayList list;
        int num2;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        baseArray2 = baseArray;
        num = 0;
        goto Label_0054;
    Label_001E:
        base2 = baseArray2[num];
        if (base2.IsActive() == null)
        {
            goto Label_0050;
        }
        if (this.OnRangeImpact(base2) == null)
        {
            goto Label_0050;
        }
        if ((base2.blackburnBlockPrefab != null) == null)
        {
            goto Label_0050;
        }
        base2.BlackburnBlockTower();
    Label_0050:
        num += 1;
    Label_0054:
        if (num < ((int) baseArray2.Length))
        {
            goto Label_001E;
        }
        list = base.stage.GetSoldiers();
        num2 = 0;
        enumerator = list.GetEnumerator();
    Label_0076:
        try
        {
            goto Label_00E1;
        Label_007B:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_00E1;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_00E1;
            }
            if (soldier.IsDead() != null)
            {
                goto Label_00E1;
            }
            if (this.OnRangeImpactDamage(soldier) == null)
            {
                goto Label_00E1;
            }
            soldier.SetDamage(this.GetImpactDamage(), 0);
            num2 += 1;
            if (num2 != this.impactMaxAttack)
            {
                goto Label_00E1;
            }
            goto Label_00ED;
        Label_00E1:
            if (enumerator.MoveNext() != null)
            {
                goto Label_007B;
            }
        Label_00ED:
            goto Label_0108;
        }
        finally
        {
        Label_00F2:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0100;
            }
        Label_0100:
            disposable.Dispose();
        }
    Label_0108:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.basicCooldownTime = 150;
        base.basicAnimationTime = 80;
        base.basicAnimationStartTime = 0x18;
        base.areaAttackRangeWidth = 180;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        this.impactRange = 0x3e8;
        this.impactDamageRange = 0x3e8;
        this.impactMinDamage = 1;
        this.impactMaxDamage = 5;
        this.impactMaxAttack = 15;
        this.undeathMax = 10;
        this.undeathRange = 300;
        return;
    }

    protected bool MaxSkeletonWarriors(ArrayList soldiers)
    {
        int num;
        int num2;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        num = base.spawner.GetSkeletonCount();
        if (num < this.undeathMax)
        {
            goto Label_001A;
        }
        return 1;
    Label_001A:
        num2 = 0;
        enumerator = soldiers.GetEnumerator();
    Label_0023:
        try
        {
            goto Label_0065;
        Label_0028:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_0065;
            }
            if (soldier.IsActive() != null)
            {
                goto Label_0065;
            }
            if (soldier.IsDead() == null)
            {
                goto Label_0065;
            }
            if (soldier.SpawnSkeletonWarrior() != null)
            {
                goto Label_0065;
            }
            num2 += 1;
        Label_0065:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0028;
            }
            goto Label_008A;
        }
        finally
        {
        Label_0075:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0082;
            }
        Label_0082:
            disposable.Dispose();
        }
    Label_008A:
        return (((num2 + num) < this.undeathMax) == 0);
    }

    protected bool OnRangeImpact(TowerBase myTower)
    {
        return IronUtils.ellipseContainPoint(myTower.transform.position - new Vector3(0f, (float) myTower.yAdjust, 0f), ((float) this.impactRange) * 0.7f, (float) this.impactRange, base.transform.position + base.anchorPoint);
    }

    protected bool OnRangeImpactDamage(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), ((float) this.impactDamageRange) * 0.7f, (float) this.impactDamageRange, base.transform.position + base.anchorPoint);
    }

    protected bool OnRangeUndeath(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), ((float) this.undeathRange) * 0.7f, (float) this.undeathRange, base.transform.position + base.anchorPoint);
    }

    protected override void PlaySpecial()
    {
        base.creepSprite.PlayAnim("special");
        return;
    }

    protected override bool ShouldTruncateAttack()
    {
        return 0;
    }

    protected override void SpecialPasivePower()
    {
        base.SpecialPasivePower();
        this.summonSkeletons();
        return;
    }

    public override bool StartFightingShouldSetChargeAttack()
    {
        return (((base.StartFightingShouldSetChargeAttack() == null) || (base.isBasicSpecial != null)) ? 0 : (base.isCharging == 0));
    }

    protected unsafe void summonSkeletons()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        int num;
        int num2;
        Transform transform;
        Creep creep;
        Vector3 vector;
        Vector3 vector2;
        IDisposable disposable;
        list = base.stage.GetSoldiers();
        if (this.MaxSkeletonWarriors(list) != null)
        {
            goto Label_01CE;
        }
        enumerator = list.GetEnumerator();
    Label_001F:
        try
        {
            goto Label_01A9;
        Label_0024:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_01A9;
            }
            if (soldier.IsActive() != null)
            {
                goto Label_01A9;
            }
            if (soldier.IsDeathBool() == null)
            {
                goto Label_01A9;
            }
            if (this.OnRangeUndeath(soldier) == null)
            {
                goto Label_01A9;
            }
            if (soldier.CanBeSkeleton() == null)
            {
                goto Label_01A9;
            }
            if (soldier.SpawnedSkeletonWarrior() != null)
            {
                goto Label_01A9;
            }
            if (soldier.SpawnSkeletonWarrior() != null)
            {
                goto Label_01A9;
            }
            num = UnityEngine.Random.Range(0, 3);
            num2 = base.stage.FindNearestNodeInPath(base.pathIndex, num, soldier.transform.position);
            if (soldier.RunDeathAnimation() == null)
            {
                goto Label_018D;
            }
            transform = UnityEngine.Object.Instantiate(this.skeletonWarriorPrefab, soldier.transform.position, Quaternion.identity) as Transform;
            transform.parent = base.spawner.transform;
            creep = transform.GetComponent<Creep>();
            creep.name = "Skeleton Warrior";
            creep.InitSprite();
            creep.SetPathIndex(base.pathIndex);
            creep.SetSubPath(num);
            creep.SetCurrentNode(num2);
            creep.SetUseGold(0);
            creep.SetActive(1);
            creep.roadNodesTillActive = 0;
            soldier.SetSpawnedSkeletonWarrior(1);
            if (&soldier.transform.localScale.x != -1f)
            {
                goto Label_017C;
            }
            creep.transform.localScale = new Vector3(-1f, 1f, 1f);
        Label_017C:
            soldier.GetComponent<PackedSprite>().Hide(1);
            goto Label_01A9;
        Label_018D:
            &vector = new Vector3((float) base.pathIndex, (float) num, (float) num2);
            soldier.SetSpawnSkeletonWarrior(1, vector);
        Label_01A9:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
            }
            goto Label_01CE;
        }
        finally
        {
        Label_01B9:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_01C6;
            }
        Label_01C6:
            disposable.Dispose();
        }
    Label_01CE:
        return;
    }

    protected override void UpdateSpecialPowerCooldowns()
    {
        base.UpdateSpecialPowerCooldowns();
        base.basicCoolddownTimeCounter += 1;
        return;
    }
}

