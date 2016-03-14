using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroFrost : SoldierHero
{
    private int abilityChillLevel;
    private int abilityIceStormLevel;
    public Transform boltPrefab;
    private int chillCastMaxRange;
    private int chillCastMinRange;
    private int chillGroundFreezeProjectiles;
    private int chillGroundFreezeSlowRange;
    private int chillReloadTime;
    private int chillReloadTimeCounter;
    private float chillSlowDuration;
    private float chillSlowFactor;
    public Transform groundFreezePrefab;
    public Transform iceRainPrefab;
    private int iceStormCastMaxRange;
    private int iceStormCastMinRange;
    private int iceStormProjectileMaxDamage;
    private int iceStormProjectileMinDamage;
    private int iceStormProjectiles;
    private int iceStormReloadTime;
    private int iceStormReloadTimeCounter;
    private int iceStormSpikeRange;
    private PackedSprite idleEffect;
    private bool isCastingChillSpell;
    private bool isFiringRangedShot;
    private bool isIceStorm;
    private int particleCounter;
    private int rangedShotMaxRange;
    private int rangedShotMinRange;
    private int rangedShotReloadTime;
    private int rangedShotReloadTimeCounter;
    private Creep rangedShotTarget;
    private Vector2 rangedShotTargetPoint;
    private int roadIndex;
    private int roadNode;
    private Transform walkParticlePrefab;

    public SoldierHeroFrost()
    {
        base..ctor();
        return;
    }

    protected override unsafe void AddWalkParticle()
    {
        Vector3 vector;
        Vector3 vector2;
        this.particleCounter += 1;
        if (this.particleCounter != 3)
        {
            goto Label_0068;
        }
        this.particleCounter = 0;
        UnityEngine.Object.Instantiate(this.walkParticlePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 44f, -1f), Quaternion.identity);
    Label_0068:
        return;
    }

    protected void AnimationDelegate(SpriteBase sprt)
    {
        if ((base.sprite.GetCurAnim().name == "shoot") == null)
        {
            goto Label_003D;
        }
        base.sprite.RevertToStatic();
        this.isFiringRangedShot = 0;
        this.rangedShotReloadTimeCounter = 0;
        goto Label_00C6;
    Label_003D:
        if ((base.sprite.GetCurAnim().name == "freeze") == null)
        {
            goto Label_0096;
        }
        base.sprite.RevertToStatic();
        this.chillReloadTimeCounter = 0;
        this.isCastingChillSpell = 0;
        if (base.isBlocking != null)
        {
            goto Label_008B;
        }
        if (base.isFighting == null)
        {
            goto Label_00C6;
        }
    Label_008B:
        base.SetFacing();
        goto Label_00C6;
    Label_0096:
        if ((base.sprite.GetCurAnim().name == "skyfall") == null)
        {
            goto Label_00C6;
        }
        base.sprite.RevertToStatic();
        this.EndIceStorm();
    Label_00C6:
        return;
    }

    protected Creep CanCastSpellInRange(float minRange, float maxRange, bool filterFlying)
    {
        float num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Creep creep2;
        IDisposable disposable;
        num = 0.7f;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0017:
        try
        {
            goto Label_00C4;
        Label_001C:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_00C4;
            }
            if (filterFlying == null)
            {
                goto Label_0051;
            }
            if (creep.isFlying == null)
            {
                goto Label_0051;
            }
            goto Label_00C4;
        Label_0051:
            if (creep.IsActive() == null)
            {
                goto Label_00C4;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, maxRange * num, maxRange, base.transform.position) == null)
            {
                goto Label_00C4;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, minRange * num, minRange, base.transform.position) != null)
            {
                goto Label_00C4;
            }
            this.roadIndex = creep.GetCurrentPath();
            this.roadNode = creep.GetCurrentNodeIndex();
            creep2 = creep;
            goto Label_00EB;
        Label_00C4:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001C;
            }
            goto Label_00E9;
        }
        finally
        {
        Label_00D4:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E1;
            }
        Label_00E1:
            disposable.Dispose();
        }
    Label_00E9:
        return null;
    Label_00EB:
        return creep2;
    }

    protected void CastChillSpell()
    {
        GameSoundManager.PlayHeroFrostGroundFreeze();
        this.chillReloadTimeCounter = 0;
        base.sprite.PlayAnim("freeze");
        base.Invoke("DelayedCastChillSpell", 0.6f);
        return;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (base.isDead != null)
        {
            goto Label_0040;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0019;
        }
        return 0;
    Label_0019:
        base.rangePoint = newRallyPoint + new Vector2(0f, base.yAdjust);
        base.GetMyPath();
        GameSoundManager.PlayHeroFrostTaunt();
    Label_0040:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        this.walkParticlePrefab = Resources.Load("Prefabs/Soldiers & units/HeroEloraWalkParticle", typeof(Transform)) as Transform;
        this.idleEffect = base.transform.FindChild("IdleEffect").GetComponent<PackedSprite>();
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.attackChargeTime = 0x17;
        base.attackChargeDamageTime = 14;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "respawn", 1)) * 30;
        base.attackReloadTime = ((int) (GameSettings.GetHeroSetting("hero_frost_sorcerer", "reload", 1) * 30f)) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_frost_sorcerer", "abilityOneModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_frost_sorcerer", "abilityTwoModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_frost_sorcerer", "xpMultiplier", 1);
        this.rangedShotMinRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "rangedShotMinRange", 1);
        this.rangedShotMaxRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "rangedShotMaxRange", 1);
        this.rangedShotReloadTime = 0x1b;
        base.adjustAbducted = new Vector2(0f, 32f);
        base.levelUpChargeTime = 0x16;
        base.respawnTime = 0x16;
        base.levelUpSoundShoot = 5;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 5.4f;
        base.lifes = 1;
        base.xAdjust = 17f;
        base.idleTime = 30;
        base.damageType = 2;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        this.chillReloadTimeCounter = 0;
        this.abilityChillLevel = 0;
        this.abilityIceStormLevel = 0;
        base.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        return;
    }

    protected unsafe void DelayedCastChillSpell()
    {
        int num;
        int num2;
        float num3;
        int num4;
        int num5;
        int num6;
        Vector2[][][] vectorArray;
        int num7;
        int num8;
        Vector2 vector;
        Transform transform;
        GroundFreeze freeze;
        num = base.stage.FindNearestNodeInPath(this.roadIndex, 0, base.transform.position);
        num2 = 2;
        if (num >= this.roadNode)
        {
            goto Label_0034;
        }
        num2 = -num2;
        goto Label_0042;
    Label_0034:
        this.roadNode += 4;
    Label_0042:
        num3 = 0f;
        num4 = 0;
        num5 = 0;
        num6 = 1;
        vectorArray = base.stage.GetPath();
        num7 = 0;
        goto Label_0139;
    Label_0065:
        num8 = this.roadNode - num4;
        if (base.stage.IsIlegal(this.roadIndex, num8) != null)
        {
            goto Label_010E;
        }
        if (this.IsNodeInsidePath(num8, this.roadIndex) == null)
        {
            goto Label_010E;
        }
        vector = *(&(vectorArray[this.roadIndex][num5][num8]));
        transform = UnityEngine.Object.Instantiate(this.groundFreezePrefab, new Vector3(&vector.x, &vector.y, -1f), Quaternion.identity) as Transform;
        transform.GetComponent<GroundFreeze>().Init(num3, num6, this.chillSlowFactor, this.chillGroundFreezeSlowRange, this.chillSlowDuration, this.abilityChillLevel);
    Label_010E:
        num3 += 0.05f;
        num5 = ((num5 + 1) + UnityEngine.Random.Range(0, 3)) % 3;
        num4 += num2;
        num6 = UnityEngine.Random.Range(1, 4);
        num7 += 1;
    Label_0139:
        if (num7 < this.chillGroundFreezeProjectiles)
        {
            goto Label_0065;
        }
        return;
    }

    protected unsafe void DelayedFireRangedShot()
    {
        int num;
        Transform transform;
        FrostBolt bolt;
        Vector3 vector;
        if (this.isCastingChillSpell != null)
        {
            goto Label_002C;
        }
        if (this.isIceStorm != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (base.isWalking == null)
        {
            goto Label_0034;
        }
    Label_002C:
        this.isFiringRangedShot = 0;
        return;
    Label_0034:
        num = UnityEngine.Random.Range(base.rangeShootMinDamage, base.rangeShootMaxDamage + 1);
        transform = null;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_00A6;
        }
        transform = UnityEngine.Object.Instantiate(this.boltPrefab, base.transform.position + new Vector3(-18f, 5f, 0f), Quaternion.identity) as Transform;
        goto Label_00E0;
    Label_00A6:
        transform = UnityEngine.Object.Instantiate(this.boltPrefab, base.transform.position + new Vector3(18f, 5f, 0f), Quaternion.identity) as Transform;
    Label_00E0:
        base.stage.AddProjectile(transform);
        bolt = transform.GetComponent<FrostBolt>();
        bolt.Init(num, 1);
        bolt.SetTarget(this.rangedShotTarget, &this.rangedShotTargetPoint.x, &this.rangedShotTargetPoint.y);
        GameSoundManager.PlayBoltSound();
        base.GainXpByDamage(num);
        return;
    }

    protected unsafe void DoIceStorm()
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        float num3;
        int num4;
        int num5;
        int num6;
        int num7;
        int num8;
        int num9;
        Vector2 vector;
        Transform transform;
        vectorArray = base.stage.GetPath();
        num = base.stage.FindNearestNodeInPath(this.roadIndex, 0, base.transform.position);
        num2 = 2;
        if (num >= this.roadNode)
        {
            goto Label_0040;
        }
        num2 = -num2;
        goto Label_004E;
    Label_0040:
        this.roadNode += 3;
    Label_004E:
        num3 = 0f;
        num4 = 0;
        num5 = 0;
        num6 = 1;
        num7 = 0;
        goto Label_014C;
    Label_0065:
        num8 = UnityEngine.Random.Range(this.iceStormProjectileMinDamage, this.iceStormProjectileMaxDamage + 1);
        num9 = this.roadNode - num4;
        if (base.stage.IsIlegal(this.roadIndex, num9) != null)
        {
            goto Label_0115;
        }
        if (this.IsNodeInsidePath(num9, this.roadIndex) == null)
        {
            goto Label_0115;
        }
        vector = *(&(vectorArray[this.roadIndex][num5][num9]));
        transform = UnityEngine.Object.Instantiate(this.iceRainPrefab, new Vector3(&vector.x, &vector.y + 25f, -899f), Quaternion.identity) as Transform;
        transform.GetComponent<IceStormSpike>().Init(num3, num6, num8, this.iceStormSpikeRange);
    Label_0115:
        num3 += UnityEngine.Random.Range(0.05f, 0.1f);
        num5 = ((num5 + 1) + UnityEngine.Random.Range(0, 3)) % 3;
        num4 += num2;
        num6 = UnityEngine.Random.Range(1, 3);
        num7 += 1;
    Label_014C:
        if (num7 < this.iceStormProjectiles)
        {
            goto Label_0065;
        }
        return;
    }

    protected void EndIceStorm()
    {
        this.isIceStorm = 0;
        this.iceStormReloadTimeCounter = 0;
        if (base.isBlocking != null)
        {
            goto Label_0024;
        }
        if (base.isFighting == null)
        {
            goto Label_002A;
        }
    Label_0024:
        base.SetFacing();
    Label_002A:
        return;
    }

    protected unsafe bool EvalChillSpell()
    {
        Vector2 vector;
        Vector3 vector2;
        if (base.isWalking != null)
        {
            goto Label_0021;
        }
        if (this.isFiringRangedShot != null)
        {
            goto Label_0021;
        }
        if (this.isIceStorm == null)
        {
            goto Label_0023;
        }
    Label_0021:
        return 0;
    Label_0023:
        if (this.isCastingChillSpell == null)
        {
            goto Label_0030;
        }
        return 1;
    Label_0030:
        if (this.chillReloadTimeCounter >= this.chillReloadTime)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        if (this.CanCastSpellInRange((float) this.chillCastMinRange, (float) this.chillCastMaxRange, 1) != null)
        {
            goto Label_0064;
        }
        return 0;
    Label_0064:
        this.isCastingChillSpell = 1;
        this.chillReloadTimeCounter = 0;
        vector = *(&(base.stage.GetPath()[this.roadIndex][0][this.roadNode]));
        if (&vector.x < &base.transform.position.x)
        {
            goto Label_00DA;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00F9;
    Label_00DA:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00F9:
        this.CastChillSpell();
        base.GainXpByAbilityModifier(1, this.abilityChillLevel);
        return 1;
    }

    protected unsafe bool EvalFireRangedShot()
    {
        Vector3 vector;
        Vector3 vector2;
        if (this.isCastingChillSpell != null)
        {
            goto Label_002C;
        }
        if (this.isIceStorm != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (base.isWalking == null)
        {
            goto Label_002E;
        }
    Label_002C:
        return 0;
    Label_002E:
        if (this.isFiringRangedShot == null)
        {
            goto Label_003B;
        }
        return 1;
    Label_003B:
        if (this.rangedShotReloadTimeCounter >= this.rangedShotReloadTime)
        {
            goto Label_004E;
        }
        return 0;
    Label_004E:
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_005B;
        }
        return 0;
    Label_005B:
        if (&this.rangedShotTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00AF;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00CE;
    Label_00AF:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00CE:
        this.isFiringRangedShot = 1;
        this.rangedShotReloadTimeCounter = 0;
        this.FireRangedShot();
        return 1;
    }

    protected unsafe bool EvalIceStorm()
    {
        Vector2 vector;
        Vector3 vector2;
        if (base.isWalking != null)
        {
            goto Label_0021;
        }
        if (this.isFiringRangedShot != null)
        {
            goto Label_0021;
        }
        if (this.isCastingChillSpell == null)
        {
            goto Label_0023;
        }
    Label_0021:
        return 0;
    Label_0023:
        if (this.isIceStorm == null)
        {
            goto Label_0030;
        }
        return 1;
    Label_0030:
        if (this.iceStormReloadTimeCounter >= this.iceStormReloadTime)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        if ((this.CanCastSpellInRange((float) this.iceStormCastMinRange, (float) this.iceStormCastMaxRange, 1) == null) == null)
        {
            goto Label_0065;
        }
        return 0;
    Label_0065:
        this.isIceStorm = 1;
        this.iceStormReloadTimeCounter = 0;
        vector = *(&(base.stage.GetPath()[this.roadIndex][0][this.roadNode]));
        if (&vector.x < &base.transform.position.x)
        {
            goto Label_00DB;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00FA;
    Label_00DB:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00FA:
        base.sprite.PlayAnim("skyfall");
        base.Invoke("DoIceStorm", 0.4666667f);
        base.GainXpByAbilityModifier(2, this.abilityIceStormLevel);
        GameSoundManager.PlayHeroFrostIceRainSummon();
        return 1;
    }

    protected unsafe bool FindRangeShootTarget()
    {
        Vector3 vector;
        Vector3 vector2;
        this.rangedShotTarget = null;
        this.rangedShotTarget = this.CanCastSpellInRange((float) this.rangedShotMinRange, (float) this.rangedShotMaxRange, 0);
        if ((this.rangedShotTarget == null) == null)
        {
            goto Label_0035;
        }
        return 0;
    Label_0035:
        this.rangedShotTargetPoint = new Vector2(&this.rangedShotTarget.transform.position.x + this.rangedShotTarget.xAdjust, &this.rangedShotTarget.transform.position.y + this.rangedShotTarget.yAdjust);
        return 1;
    }

    protected void FireRangedShot()
    {
        base.sprite.PlayAnim("shoot");
        base.Invoke("DelayedFireRangedShot", 0.6333333f);
        return;
    }

    protected int GetAbilityLevelForFirstSkill(int newLevel)
    {
        if (newLevel >= 2)
        {
            goto Label_0009;
        }
        return 0;
    Label_0009:
        if (newLevel >= 5)
        {
            goto Label_0012;
        }
        return 1;
    Label_0012:
        if (newLevel >= 8)
        {
            goto Label_001B;
        }
        return 2;
    Label_001B:
        return 3;
    }

    protected int GetAbilityLevelForSecondSkill(int newLevel)
    {
        if (newLevel >= 4)
        {
            goto Label_0009;
        }
        return 0;
    Label_0009:
        if (newLevel >= 7)
        {
            goto Label_0012;
        }
        return 1;
    Label_0012:
        if (newLevel >= 10)
        {
            goto Label_001C;
        }
        return 2;
    Label_001C:
        return 3;
    }

    protected bool IsNodeInsidePath(int nodeIndex, int pathIndex)
    {
        if (nodeIndex >= 0)
        {
            goto Label_0009;
        }
        return 0;
    Label_0009:
        return (nodeIndex < ((int) base.stage.GetPath()[this.roadIndex][0].Length));
    }

    protected override void LevelUpWithAnimation(bool playAnimation)
    {
        int num;
        if (playAnimation == null)
        {
            goto Label_000D;
        }
        base.LevelUpWithAnimation(playAnimation);
    Label_000D:
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "maxDamage", base.level);
        base.rangeShootMinDamage = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "minRangeDamage", base.level);
        base.rangeShootMaxDamage = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "maxRangeDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeChill();
        this.UpgradeIceStorm();
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroFrostDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroVikingTauntIntro();
        return;
    }

    protected void ReloadChillValues(int abilityLevel)
    {
        int num;
        num = abilityLevel - 1;
        this.chillSlowFactor = GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillSlowFactor", abilityLevel);
        this.chillSlowDuration = GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillSlowDuration", abilityLevel);
        this.chillReloadTime = ((int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillCooldown", 1)) * 30;
        this.chillCastMinRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillCastMinRange", abilityLevel);
        this.chillCastMaxRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillCastMaxRange", abilityLevel);
        this.chillGroundFreezeSlowRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillGroundFreezeSlowRange", 1);
        this.chillGroundFreezeProjectiles = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "chillGroundFreezeProjectiles", abilityLevel);
        return;
    }

    protected void ReloadIceStormValues(int abilityLevel)
    {
        int num;
        num = abilityLevel - 1;
        this.iceStormReloadTime = ((int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormCooldown", 1)) * 30;
        this.iceStormProjectiles = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormProjectiles", abilityLevel);
        this.iceStormProjectileMinDamage = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormMinDamage", abilityLevel);
        this.iceStormProjectileMaxDamage = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormMaxDamage", abilityLevel);
        this.iceStormSpikeRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormSpikeRange", 1);
        this.iceStormCastMinRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormCastMinRange", abilityLevel);
        this.iceStormCastMaxRange = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "iceStormCastMaxRange", abilityLevel);
        return;
    }

    protected override void Respawn()
    {
        base.Respawn();
        this.idleEffect.Hide(0);
        return;
    }

    protected override bool RunSpecial()
    {
        this.iceStormReloadTimeCounter += 1;
        this.chillReloadTimeCounter += 1;
        this.rangedShotReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        if (this.abilityIceStormLevel <= 0)
        {
            goto Label_0050;
        }
        if (this.EvalIceStorm() == null)
        {
            goto Label_0050;
        }
        return 1;
    Label_0050:
        if (this.abilityChillLevel <= 0)
        {
            goto Label_0069;
        }
        if (this.EvalChillSpell() == null)
        {
            goto Label_0069;
        }
        return 1;
    Label_0069:
        if (this.EvalFireRangedShot() == null)
        {
            goto Label_0076;
        }
        return 1;
    Label_0076:
        return 0;
    }

    protected override void StopOnDead()
    {
        base.StopOnDead();
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isIceStorm = 0;
        this.isCastingChillSpell = 0;
        this.isFiringRangedShot = 0;
        this.idleEffect.Hide(1);
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isIceStorm = 0;
        this.isCastingChillSpell = 0;
        this.isFiringRangedShot = 0;
        return;
    }

    protected void UpgradeChill()
    {
        this.abilityChillLevel = this.GetAbilityLevelForFirstSkill(base.level);
        if (this.abilityChillLevel != null)
        {
            goto Label_001E;
        }
        return;
    Label_001E:
        this.ReloadChillValues(this.abilityChillLevel);
        return;
    }

    protected void UpgradeIceStorm()
    {
        this.abilityIceStormLevel = this.GetAbilityLevelForSecondSkill(base.level);
        if (this.abilityIceStormLevel != null)
        {
            goto Label_001E;
        }
        return;
    Label_001E:
        this.ReloadIceStormValues(this.abilityIceStormLevel);
        return;
    }

    protected override unsafe bool Walk()
    {
        Vector2 vector;
        AStarNode node;
        Vector2 vector2;
        float num;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if (base.path.Count != null)
        {
            goto Label_0017;
        }
        return base.Walk();
    Label_0017:
        vector = ((AStarNode) base.path[base.currentPathNode - 1]).GetNodeRealPosition() + new Vector2(0f, 5f);
        if (this.DestinationReachOnPath(vector) == null)
        {
            goto Label_0089;
        }
        base.currentPathNode -= 1;
        if ((base.currentPathNode - 1) != null)
        {
            goto Label_0089;
        }
        base.path.Clear();
        base.currentPathNode = 0;
        return base.Walk();
    Label_0089:
        node = (AStarNode) base.path[base.currentPathNode - 1];
        vector2 = node.GetNodeRealPosition() + new Vector2(0f, 5f);
        num = Mathf.Atan2(&vector2.y - &base.transform.position.y, &vector2.x - &base.transform.position.x);
        if (&vector2.x >= &base.transform.position.x)
        {
            goto Label_013F;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_014F;
    Label_013F:
        base.transform.localScale = Vector3.one;
    Label_014F:
        this.AddWalkParticle();
        base.transform.position = new Vector3(&base.transform.position.x + (Mathf.Cos(num) * base.speed), &base.transform.position.y + (Mathf.Sin(num) * base.speed), &base.transform.position.z);
        return 0;
    }
}

