using System;
using System.Collections;
using UnityEngine;

public class CreepNecromancer : Creep
{
    protected int animationSummon;
    protected Vector2 destinyPoint;
    protected bool isSpell;
    protected bool isSummon;
    public Bolt necroBolt;
    protected Vector2[][][] path;
    public Transform skeletonPrefab;
    public Transform skeletonWarriorPrefab;
    protected int spellChargeTime;
    protected int spellChargeTimeCounter;
    public int spellMaxDamage;
    public int spellMinDamage;
    public int spellMinRange;
    protected bool spellOnTarget;
    protected int spellRangeHeight;
    protected int spellRangeWidth;
    public int spellReloadTime;
    protected int spellReloadTimeCounter;
    protected Soldier spellTarget;
    protected int summonAnimationTime;
    protected int summonAnimationTimeCounter;
    protected int summonAnimationTimeFire;
    public int summonCooldownTime;
    protected int summonCooldownTimeCounter;
    protected int summonIndex;
    public int summonMaxEnemies;
    protected int summonOneTime;
    protected int summonOneTimeCounter;

    public CreepNecromancer()
    {
        base..ctor();
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        this.isSpell = 0;
        this.isSummon = 0;
        return;
    }

    protected int GetSpellDamage()
    {
        return UnityEngine.Random.Range(this.spellMinDamage, this.spellMaxDamage + 1);
    }

    protected bool GetSpellTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.spellTarget = null;
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
            if (IronUtils.ellipseContainPoint(soldier.transform.position, (float) this.spellRangeHeight, (float) this.spellRangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_007C;
            }
            this.spellTarget = soldier;
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
        if ((this.spellTarget != null) == null)
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
        this.path = base.stage.GetPath();
        this.spellRangeWidth = 410 + UnityEngine.Random.Range(-99, 0x2b);
        this.spellRangeHeight = Mathf.RoundToInt(((float) this.spellRangeWidth) * 0.7f);
        this.spellChargeTime = 0x17;
        this.spellMinDamage = 20;
        this.spellMaxDamage = 40;
        this.summonAnimationTime = 0x2f;
        this.summonAnimationTimeFire = 12;
        this.summonOneTime = 4;
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.spellMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected override bool SpecialPower()
    {
        this.summonCooldownTimeCounter += 1;
        this.spellReloadTimeCounter += 1;
        if (this.isSpell != null)
        {
            goto Label_0034;
        }
        if (this.SpecialSummon() == null)
        {
            goto Label_0034;
        }
        return 1;
    Label_0034:
        if (this.isSummon != null)
        {
            goto Label_004C;
        }
        if (this.SpecialSpell() == null)
        {
            goto Label_004C;
        }
        return 1;
    Label_004C:
        return 0;
    }

    protected unsafe bool SpecialSpell()
    {
        Vector2 vector;
        Vector3 vector2;
        Bolt bolt;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        Vector3 vector11;
        Vector3 vector12;
        Vector3 vector13;
        Vector3 vector14;
        Vector3 vector15;
        Vector3 vector16;
        if (this.isSpell != null)
        {
            goto Label_01FC;
        }
        if (base.isBlocked == null)
        {
            goto Label_002A;
        }
        if (this.spellOnTarget == null)
        {
            goto Label_0028;
        }
        this.spellOnTarget = 0;
    Label_0028:
        return 0;
    Label_002A:
        if (this.spellReloadTimeCounter >= this.spellReloadTime)
        {
            goto Label_0050;
        }
        this.spellReloadTimeCounter += 1;
        return this.spellOnTarget;
    Label_0050:
        if (this.GetSpellTarget() != null)
        {
            goto Label_0083;
        }
        if (this.spellOnTarget == null)
        {
            goto Label_007A;
        }
        base.isStopped = 0;
        base.facing = 4;
        this.CheckFacing();
    Label_007A:
        this.spellOnTarget = 0;
        return 0;
    Label_0083:
        if (&this.spellTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00F7;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_0135;
    Label_00F7:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
    Label_0135:
        this.destinyPoint = new Vector2(&this.spellTarget.transform.position.x, &this.spellTarget.transform.position.y + 18f);
        this.isSpell = 1;
        base.isStopped = 1;
        this.spellOnTarget = 1;
        this.spellChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        return 1;
    Label_01FC:
        if (this.spellChargeTimeCounter >= this.spellChargeTime)
        {
            goto Label_036E;
        }
        this.spellChargeTimeCounter += 1;
        if (this.spellChargeTimeCounter != 7)
        {
            goto Label_036C;
        }
        vector = this.destinyPoint;
        if ((this.spellTarget == null) != null)
        {
            goto Label_024F;
        }
        if (this.spellTarget.IsActive() != null)
        {
            goto Label_0261;
        }
    Label_024F:
        if (this.GetSpellTarget() != null)
        {
            goto Label_0261;
        }
        vector = this.destinyPoint;
    Label_0261:
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_02D3;
        }
        &vector2 = new Vector3(&base.transform.position.x - 15f, &base.transform.position.y + 21f, &base.transform.position.z);
        goto Label_0322;
    Label_02D3:
        &vector2 = new Vector3(&base.transform.position.x + 15f, &base.transform.position.y + 21f, &base.transform.position.z);
    Label_0322:
        bolt = UnityEngine.Object.Instantiate(this.necroBolt, vector2, Quaternion.identity) as Bolt;
        bolt.SetTarget(this.spellTarget, &vector.x, &vector.y - 8f);
        bolt.SetDamage(this.GetSpellDamage());
        bolt.SetIgnoresArmor(1);
    Label_036C:
        return 1;
    Label_036E:
        this.isSpell = 0;
        this.spellReloadTimeCounter = 0;
        return 1;
    }

    protected bool SpecialSummon()
    {
        if (base.isBlocked == null)
        {
            goto Label_0014;
        }
        this.summonCooldownTimeCounter = 0;
        return 0;
    Label_0014:
        if (this.isSummon != null)
        {
            goto Label_006D;
        }
        if (this.summonCooldownTimeCounter >= this.summonCooldownTime)
        {
            goto Label_0032;
        }
        return 0;
    Label_0032:
        if (base.spawner.GetSkeletonCount() < 0x23)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        this.isSummon = 1;
        base.creepSprite.PlayAnim("summon");
        this.summonAnimationTimeCounter = 0;
        this.summonIndex = 0;
        return 1;
    Label_006D:
        if (this.summonAnimationTimeCounter >= this.summonAnimationTime)
        {
            goto Label_0136;
        }
        this.summonAnimationTimeCounter += 1;
        if (this.summonAnimationTimeCounter <= this.summonAnimationTimeFire)
        {
            goto Label_0134;
        }
        if (this.summonIndex > this.summonMaxEnemies)
        {
            goto Label_0134;
        }
        if (this.summonOneTimeCounter >= this.summonOneTime)
        {
            goto Label_00D2;
        }
        this.summonOneTimeCounter += 1;
        goto Label_0134;
    Label_00D2:
        if (base.spawner.GetSkeletonCount() >= 0x23)
        {
            goto Label_010A;
        }
        this.SummonSkeleton(this.summonIndex);
        this.summonIndex += 1;
        this.summonOneTimeCounter = 0;
        goto Label_0134;
    Label_010A:
        if (this.summonIndex != null)
        {
            goto Label_0134;
        }
        this.SummonSkeleton(this.summonIndex);
        this.summonIndex = this.summonMaxEnemies;
        this.summonOneTimeCounter = 0;
    Label_0134:
        return 1;
    Label_0136:
        this.isSummon = 0;
        this.summonCooldownTimeCounter = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_015C;
        }
        this.CheckFacing();
    Label_015C:
        return 0;
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        this.isSpell = 0;
        this.isSummon = 0;
        this.spellOnTarget = 0;
        return;
    }

    protected unsafe void SummonIt(int pRoadPath, int pRoadIndex, int pNode)
    {
        Vector3 vector;
        Transform transform;
        Creep creep;
        Vector3 vector2;
        Transform transform2;
        Creep creep2;
        Vector3 vector3;
        Vector3 vector4;
        if (pNode < 0)
        {
            goto Label_0019;
        }
        if (pNode < ((int) this.path[pRoadPath][pRoadIndex].Length))
        {
            goto Label_001A;
        }
    Label_0019:
        return;
    Label_001A:
        if (UnityEngine.Random.Range(0f, 1f) >= 0.05f)
        {
            goto Label_0115;
        }
        &vector = new Vector3(&(this.path[pRoadPath][pRoadIndex][pNode]).x, &(this.path[pRoadPath][pRoadIndex][pNode]).y, -1f);
        transform = UnityEngine.Object.Instantiate(this.skeletonWarriorPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.name = "Skeleton Warrior";
        creep.InitSprite();
        creep.SetPathIndex(pRoadPath);
        creep.SetSubPath(pRoadIndex);
        creep.SetCurrentNode(pNode);
        creep.SetUseGold(0);
        creep.SetActive(1);
        creep.roadNodesTillActive = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_01FF;
        }
        creep.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_01FF;
    Label_0115:
        &vector2 = new Vector3(&(this.path[pRoadPath][pRoadIndex][pNode]).x, &(this.path[pRoadPath][pRoadIndex][pNode]).y, -1f);
        transform2 = UnityEngine.Object.Instantiate(this.skeletonPrefab, vector2, Quaternion.identity) as Transform;
        transform2.parent = base.spawner.transform;
        creep2 = transform2.GetComponent<Creep>();
        creep2.name = "Skeleton";
        creep2.InitSprite();
        creep2.SetPathIndex(pRoadPath);
        creep2.SetSubPath(pRoadIndex);
        creep2.SetCurrentNode(pNode);
        creep2.SetUseGold(0);
        creep2.SetActive(1);
        creep2.roadNodesTillActive = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_01FF;
        }
        creep2.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_01FF:
        return;
    }

    protected void SummonSkeleton(int i)
    {
        int num;
        num = i;
        switch (num)
        {
            case 0:
                goto Label_002D;

            case 1:
                goto Label_0045;

            case 2:
                goto Label_005D;

            case 3:
                goto Label_007E;

            case 4:
                goto Label_009F;

            case 5:
                goto Label_00C0;

            case 6:
                goto Label_00E1;

            case 7:
                goto Label_0102;
        }
        goto Label_0123;
    Label_002D:
        this.SummonIt(base.pathIndex, 1, base.currentNode);
        goto Label_0128;
    Label_0045:
        this.SummonIt(base.pathIndex, 2, base.currentNode);
        goto Label_0128;
    Label_005D:
        this.SummonIt(base.pathIndex, 0, base.currentNode + UnityEngine.Random.Range(3, 9));
        goto Label_0128;
    Label_007E:
        this.SummonIt(base.pathIndex, 1, base.currentNode + UnityEngine.Random.Range(3, 9));
        goto Label_0128;
    Label_009F:
        this.SummonIt(base.pathIndex, 2, base.currentNode + UnityEngine.Random.Range(3, 9));
        goto Label_0128;
    Label_00C0:
        this.SummonIt(base.pathIndex, 0, base.currentNode - UnityEngine.Random.Range(3, 9));
        goto Label_0128;
    Label_00E1:
        this.SummonIt(base.pathIndex, 1, base.currentNode - UnityEngine.Random.Range(3, 9));
        goto Label_0128;
    Label_0102:
        this.SummonIt(base.pathIndex, 2, base.currentNode - UnityEngine.Random.Range(3, 9));
        goto Label_0128;
    Label_0123:;
    Label_0128:
        return;
    }
}

