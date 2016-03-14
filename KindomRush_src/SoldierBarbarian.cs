using System;
using System.Collections;
using UnityEngine;

public class SoldierBarbarian : Soldier
{
    public Transform axe;
    private int dualWeaponsIncrementDamage;
    private int dualWeaponsLevel;
    private int enemiesKills;
    private bool isThrowing;
    private bool isTwister;
    private int maxDamageBase;
    private int minDamageBase;
    private Creep target;
    private Vector2 targetPoint;
    private int throwingChargeTime;
    private int throwingChargeTimeCounter;
    private int throwingCoolDown;
    private int throwingIncrementDamage;
    private int throwingIncrementRange;
    private int throwingLevel;
    private int throwingMaxDamage;
    private int throwingMaxDamageBase;
    private int throwingMinDamage;
    private int throwingMinDamageBase;
    private int throwingMinRange;
    private int throwingRange;
    private int throwingRangeHeight;
    private int throwingRangeWidth;
    private int throwingReloadTime;
    private int throwingReloadTimeCounter;
    private int tmpAxeRotation;
    private int twisterChance;
    private int twisterChanceBase;
    private int twisterChargeTime;
    private int twisterChargeTimeCounter;
    private int twisterIncrementChance;
    private int twisterIncrementDamage;
    private int twisterLevel;
    private int twisterMaxBaseDamage;
    private int twisterMaxDamage;
    private int twisterMaxSoldiers;
    private int twisterMinBaseDamage;
    private int twisterMinDamage;
    private int twisterRangeHeight;
    private int twisterRangeWidth;

    public SoldierBarbarian()
    {
        base..ctor();
        return;
    }

    protected void AddBarbarianKill()
    {
        this.enemiesKills += 1;
        if (this.enemiesKills != 10)
        {
            goto Label_0020;
        }
        GameAchievements.EvalBarbarianRush();
    Label_0020:
        return;
    }

    protected unsafe bool EvalThrowing()
    {
        Transform transform;
        Axe axe;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.isThrowing != null)
        {
            goto Label_00FB;
        }
        if (this.throwingReloadTimeCounter >= this.throwingReloadTime)
        {
            goto Label_002C;
        }
        this.throwingReloadTimeCounter += 1;
        return 0;
    Label_002C:
        if (this.FindThrowingTarget() != null)
        {
            goto Label_0039;
        }
        return 0;
    Label_0039:
        if (&this.target.transform.position.x < &base.transform.position.x)
        {
            goto Label_0094;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        this.tmpAxeRotation = 1;
        goto Label_00BA;
    Label_0094:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        this.tmpAxeRotation = -1;
    Label_00BA:
        this.isThrowing = 1;
        this.throwingChargeTimeCounter = 0;
        if (this.dualWeaponsLevel < 1)
        {
            goto Label_00E9;
        }
        base.sprite.PlayAnim("throwDouble");
        goto Label_00F9;
    Label_00E9:
        base.sprite.PlayAnim("throw");
    Label_00F9:
        return 1;
    Label_00FB:
        if (this.throwingChargeTimeCounter >= this.throwingChargeTime)
        {
            goto Label_01E5;
        }
        this.throwingChargeTimeCounter += 1;
        if (this.throwingChargeTimeCounter != 7)
        {
            goto Label_01E3;
        }
        GameAchievements.AxeFire();
        transform = UnityEngine.Object.Instantiate(this.axe, new Vector3(&base.transform.position.x, &base.transform.position.y + 17f, -899f), Quaternion.identity) as Transform;
        transform.parent = base.tower.transform;
        axe = transform.GetComponent<Axe>();
        axe.SetTarget(this.target, &this.targetPoint.x, &this.targetPoint.y);
        axe.SetDamage(UnityEngine.Random.Range(this.throwingMinDamage, this.throwingMaxDamage + 1));
        axe.SetT1(27f);
        axe.SetRotation(this.tmpAxeRotation);
    Label_01E3:
        return 1;
    Label_01E5:
        this.isThrowing = 0;
        this.throwingReloadTimeCounter = 0;
        if (base.isWalking != null)
        {
            goto Label_0209;
        }
        this.RevertToStatic();
        goto Label_020F;
    Label_0209:
        this.PlayAnimationWalk();
    Label_020F:
        return 0;
    }

    protected bool EvalTwister()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        if (this.twisterChargeTimeCounter >= this.twisterChargeTime)
        {
            goto Label_00A9;
        }
        this.twisterChargeTimeCounter += 1;
        if (this.twisterChargeTimeCounter != 7)
        {
            goto Label_00A7;
        }
        enumerator = base.spawner.transform.GetEnumerator();
    Label_003C:
        try
        {
            goto Label_0085;
        Label_0041:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0085;
            }
            if (creep.isFlying != null)
            {
                goto Label_0085;
            }
            if (this.OnRangeTwister(creep) == null)
            {
                goto Label_0085;
            }
            creep.Damage(this.GetTwisterDamage(), 1, 0, 0);
        Label_0085:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0041;
            }
            goto Label_00A7;
        }
        finally
        {
        Label_0095:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A0;
            }
        Label_00A0:
            disposable.Dispose();
        }
    Label_00A7:
        return 1;
    Label_00A9:
        this.isTwister = 0;
        this.twisterChargeTimeCounter = 0;
        return 0;
    }

    protected unsafe bool FindThrowingTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        creep = null;
        this.target = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001A:
        try
        {
            goto Label_0092;
        Label_001F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_0092;
            }
            if (this.MinDistance(creep2) == null)
            {
                goto Label_0092;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, (float) this.throwingRangeHeight, (float) this.throwingRangeWidth, base.transform.position) == null)
            {
                goto Label_0092;
            }
            if ((creep == null) != null)
            {
                goto Label_0090;
            }
            if (this.IsNearExit(creep, creep2) == null)
            {
                goto Label_0092;
            }
        Label_0090:
            creep = creep2;
        Label_0092:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
            goto Label_00B7;
        }
        finally
        {
        Label_00A2:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00AF;
            }
        Label_00AF:
            disposable.Dispose();
        }
    Label_00B7:
        if ((creep != null) == null)
        {
            goto Label_00FF;
        }
        this.target = creep;
        this.targetPoint = new Vector2(&creep.transform.position.x, &creep.transform.position.y);
        return 1;
    Label_00FF:
        return 0;
    }

    protected int GetTwisterDamage()
    {
        return UnityEngine.Random.Range(this.twisterMinDamage, this.twisterMaxDamage + 1);
    }

    protected override void HitEnemy()
    {
        if ((base.enemy == null) != null)
        {
            goto Label_0021;
        }
        if (base.enemy.IsActive() != null)
        {
            goto Label_002E;
        }
    Label_0021:
        base.UnBlock();
        this.SetGoToIdleStatus();
        return;
    Label_002E:
        if (base.enemy.DodgeAttack() != null)
        {
            goto Label_0098;
        }
        if (UnityEngine.Random.Range(0f, 1f) >= 0.3f)
        {
            goto Label_0057;
        }
    Label_0057:
        base.enemy.Damage(this.GetDamage(), 1, 0, 0);
        if ((base.enemy != null) == null)
        {
            goto Label_0098;
        }
        if (base.enemy.IsDead() == null)
        {
            goto Label_0098;
        }
        this.AddBarbarianKill();
        base.UnBlock();
    Label_0098:
        return;
    }

    protected bool IsNearExit(Creep enemyOld, Creep enemyNew)
    {
        if ((enemyOld.GetSubPathCount() - enemyOld.GetCurrentNodeIndex()) <= (enemyNew.GetSubPathCount() - enemyNew.GetCurrentNodeIndex()))
        {
            goto Label_0021;
        }
        return 1;
    Label_0021:
        return 0;
    }

    protected override void LoadNames()
    {
        base.nameCandidates = new ArrayList();
        base.nameCandidates.Add("Erik");
        base.nameCandidates.Add("Conan");
        base.nameCandidates.Add("Ragnar");
        base.nameCandidates.Add("Rurik");
        base.nameCandidates.Add("Haltaf");
        base.nameCandidates.Add("Ingvar");
        base.nameCandidates.Add("Thor");
        base.nameCandidates.Add("Obelix");
        base.nameCandidates.Add("Drogo");
        base.nameCandidates.Add("Hogan");
        base.nameCandidates.Add("Ferrigno");
        base.nameCandidates.Add("The Rock");
        base.nameCandidates.Add("Helfdane");
        base.nameCandidates.Add("Siegfried");
        base.nameCandidates.Add("Hyglak");
        base.nameCandidates.Add("Diesel");
        base.nameCandidates.Add("Gowueld");
        base.nameCandidates.Add("Gaben");
        base.nameCandidates.Add("Mastalli");
        base.nameCandidates.Add("Lalanne");
        return;
    }

    protected unsafe bool MinDistance(Creep myEnemy)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &myEnemy.transform.position.x - &base.transform.position.x;
        num3 = &myEnemy.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.throwingMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected bool OnRangeTwister(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.twisterRangeHeight, (float) this.twisterRangeWidth, base.transform.position);
    }

    protected override void PlayAnimationAttack()
    {
        if (this.dualWeaponsLevel < 1)
        {
            goto Label_0021;
        }
        base.sprite.PlayAnim("attackDouble");
        goto Label_0031;
    Label_0021:
        base.sprite.PlayAnim("attack");
    Label_0031:
        base.SetFacing();
        return;
    }

    protected override void PlayAnimationWalk()
    {
        if (this.dualWeaponsLevel < 1)
        {
            goto Label_0021;
        }
        base.sprite.PlayAnim("walkDouble");
        goto Label_0031;
    Label_0021:
        base.sprite.PlayAnim("walk");
    Label_0031:
        return;
    }

    protected override bool ReadyToRespawn()
    {
        base.deadTimeCounter += 1;
        if (base.deadTimeCounter < base.deadTime)
        {
            goto Label_0052;
        }
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        this.enemiesKills = 0;
        base.runDeathAnimation = 0;
        base.spawnSkeletonWarrior = 0;
        base.spawnedSkeletonWarrior = 0;
        return 1;
    Label_0052:
        return 0;
    }

    protected override void RevertToStatic()
    {
        if (this.dualWeaponsLevel <= 0)
        {
            goto Label_0021;
        }
        base.sprite.PlayAnim("idleDouble");
        goto Label_002C;
    Label_0021:
        base.sprite.RevertToStatic();
    Label_002C:
        return;
    }

    protected override bool RunSpecial()
    {
        if (this.isTwister == null)
        {
            goto Label_0014;
        }
        this.EvalTwister();
        return 1;
    Label_0014:
        if (this.throwingLevel == null)
        {
            goto Label_002C;
        }
        if (this.EvalThrowing() == null)
        {
            goto Label_002C;
        }
        return 1;
    Label_002C:
        return 0;
    }

    public override void SetDamage(int damage, bool ignoresArmor)
    {
        base.SetDamage(damage, ignoresArmor);
        if (base.health <= 0)
        {
            goto Label_00AD;
        }
        if (this.twisterLevel == null)
        {
            goto Label_00AD;
        }
        if (this.isTwister != null)
        {
            goto Label_00AD;
        }
        if (base.isFighting == null)
        {
            goto Label_00AD;
        }
        if ((base.enemy != null) == null)
        {
            goto Label_00AD;
        }
        if (UnityEngine.Random.Range(1, 0x65) > this.twisterChance)
        {
            goto Label_00AD;
        }
        this.isThrowing = 0;
        base.isCharging = 0;
        base.attackChargeTimeCounter = 0;
        this.isTwister = 1;
        this.twisterChargeTimeCounter = 0;
        if (this.dualWeaponsLevel < 1)
        {
            goto Label_009D;
        }
        base.sprite.PlayAnim("twisterDouble");
        goto Label_00AD;
    Label_009D:
        base.sprite.PlayAnim("twister");
    Label_00AD:
        return;
    }

    protected override unsafe void SetGoToIdleStatus()
    {
        if (base.isWalking != null)
        {
            goto Label_0067;
        }
        base.isIdle = 0;
        base.isWalking = 1;
        if ((base.sprite == null) == null)
        {
            goto Label_0036;
        }
        base.sprite = base.GetComponent<PackedSprite>();
    Label_0036:
        if (this.dualWeaponsLevel < 1)
        {
            goto Label_0057;
        }
        base.sprite.PlayAnim("walkDouble");
        goto Label_0067;
    Label_0057:
        base.sprite.PlayAnim("walk");
    Label_0067:
        base.enemy = null;
        base.isFighting = 0;
        base.isBlocking = 0;
        base.isCharging = 0;
        &this.destinationPoint.Set(&this.rallyPoint.x, &this.rallyPoint.y);
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        int num;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -3f);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.rangeWidth = 170;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.health = base.initHealth = (int) GameSettings.GetTowerSetting("barrack_barbarian", "health");
        base.armor = (int) GameSettings.GetTowerSetting("barrack_barbarian", "armor");
        base.respawnTime = (int) GameSettings.GetTowerSetting("barrack_barbarian", "respawn");
        base.regenerateHealth = 20;
        base.regenerateTime = 30;
        this.minDamageBase = base.minDamage;
        this.maxDamageBase = base.maxDamage;
        this.twisterRangeWidth = 0x70;
        this.twisterRangeHeight = Mathf.RoundToInt(((float) this.twisterRangeWidth) * 0.7f);
        this.twisterMaxSoldiers = 10;
        this.twisterChargeTime = 15;
        this.twisterChargeTimeCounter = 0;
        this.twisterMinBaseDamage = 10;
        this.twisterMaxBaseDamage = 30;
        this.twisterIncrementDamage = 15;
        this.twisterChanceBase = 10;
        this.twisterIncrementChance = 5;
        this.throwingChargeTime = 14;
        this.throwingRange = 0x1b5;
        this.throwingIncrementRange = 0x1a;
        this.throwingCoolDown = 3;
        this.throwingIncrementDamage = 10;
        this.throwingMinDamageBase = (int) GameSettings.GetTowerSetting("barrack_barbarian", "throwingMinDamage");
        this.throwingMaxDamageBase = (int) GameSettings.GetTowerSetting("barrack_barbarian", "throwingMaxDamage");
        this.dualWeaponsIncrementDamage = 10;
        this.LoadNames();
        base.SetRandomName();
        return;
    }

    protected override void StopSpecial()
    {
        this.isThrowing = 0;
        this.throwingReloadTimeCounter = 0;
        return;
    }

    public void UpgradeDualWeapons(int myDualWeaponsLevel)
    {
        base.attackChargeTime = 20;
        base.attackChargeDamageTime = 10;
        this.dualWeaponsLevel = myDualWeaponsLevel;
        base.minDamage = this.minDamageBase + (this.dualWeaponsIncrementDamage * this.dualWeaponsLevel);
        base.maxDamage = this.maxDamageBase + (this.dualWeaponsIncrementDamage * this.dualWeaponsLevel);
        base.tower.minDamange = base.minDamage;
        base.tower.maxDamage = base.maxDamage;
        if (this.dualWeaponsLevel != 1)
        {
            goto Label_00A4;
        }
        base.xAdjust = 7f;
        if (base.sprite.IsAnimating() != null)
        {
            goto Label_00A4;
        }
        base.sprite.PlayAnim("idleDouble");
    Label_00A4:
        return;
    }

    public void UpgradeThrowingAxe(int myThrowingAxeLevel)
    {
        this.throwingLevel = myThrowingAxeLevel;
        this.throwingReloadTime = this.throwingCoolDown * 30;
        this.throwingRangeWidth = this.throwingRange + (this.throwingIncrementRange * this.throwingLevel);
        this.throwingRangeHeight = Mathf.RoundToInt(((float) this.throwingRangeWidth) * 0.7f);
        this.throwingMinRange = 0x4e;
        this.throwingMinDamage = this.throwingMinDamageBase + (this.throwingIncrementDamage * this.throwingLevel);
        this.throwingMaxDamage = this.throwingMaxDamageBase + (this.throwingIncrementDamage * this.throwingLevel);
        return;
    }

    public void UpgradeTwister(int myTwisterLevel)
    {
        this.twisterLevel = myTwisterLevel;
        this.twisterMinDamage = this.twisterMinBaseDamage + (this.twisterIncrementDamage * this.twisterLevel);
        this.twisterMaxDamage = this.twisterMaxBaseDamage + (this.twisterIncrementDamage * this.twisterLevel);
        this.twisterChance = this.twisterChanceBase + (this.twisterIncrementChance * this.twisterLevel);
        return;
    }
}

