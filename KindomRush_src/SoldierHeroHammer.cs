using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroHammer : SoldierHero
{
    private int currentAttack;
    public Transform effectEarthquakePrefab;
    public Transform effectSmashPrefab;
    private int fissureChargeTime;
    private int fissureChargeTimeCounter;
    private int fissureDamageIncrement;
    private int fissureLevel;
    private int fissureMaxDamage;
    private int fissureMinDamage;
    private int fissureNodeIndex;
    private int fissureNodePath;
    private int fissureNodeSubPath;
    private int fissureRangeHeight;
    private int fissureRangeWidth;
    private int fissureReloadTime;
    private int fissureReloadTimeCounter;
    public Transform groundDecalPrefab;
    private bool isFissure;
    private bool isSmash;
    private int smashChargeTime;
    private int smashChargeTimeCounter;
    private int smashDamageIncrement;
    private int smashLevel;
    private int smashMaxDamage;
    private int smashMinDamage;
    private int smashRangeHeight;
    private int smashRangeWidth;
    private int smashReloadTime;
    private int smashReloadTimeCounter;

    public SoldierHeroHammer()
    {
        base..ctor();
        return;
    }

    protected bool CanFissure()
    {
        Vector2[][][] vectorArray;
        if ((base.enemy == null) != null)
        {
            goto Label_003C;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_003C;
        }
        if (base.enemy.IsFighting() == null)
        {
            goto Label_003C;
        }
        if (base.isWalking == null)
        {
            goto Label_003E;
        }
    Label_003C:
        return 0;
    Label_003E:
        vectorArray = base.stage.GetPath();
        if (base.enemy.GetCurrentSubPath() != null)
        {
            goto Label_0066;
        }
        this.fissureNodeSubPath = 0;
        goto Label_008A;
    Label_0066:
        if (base.enemy.GetCurrentSubPath() != 1)
        {
            goto Label_0083;
        }
        this.fissureNodeSubPath = 1;
        goto Label_008A;
    Label_0083:
        this.fissureNodeSubPath = 2;
    Label_008A:
        this.fissureNodePath = base.enemy.GetCurrentPath();
        this.fissureNodeIndex = base.enemy.GetCurrentNodeIndex();
        return 1;
    }

    protected bool CanSmash()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        bool flag;
        IDisposable disposable;
        if ((base.enemy == null) != null)
        {
            goto Label_003C;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_003C;
        }
        if (base.enemy.IsFighting() == null)
        {
            goto Label_003C;
        }
        if (base.isWalking == null)
        {
            goto Label_003E;
        }
    Label_003C:
        return 0;
    Label_003E:
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0051:
        try
        {
            goto Label_009E;
        Label_0056:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_009E;
            }
            if (creep.isFlying != null)
            {
                goto Label_009E;
            }
            if (this.OnRangeSmash(creep) == null)
            {
                goto Label_009E;
            }
            num += 1;
            if (num != 3)
            {
                goto Label_009E;
            }
            flag = 1;
            goto Label_00C5;
        Label_009E:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0056;
            }
            goto Label_00C3;
        }
        finally
        {
        Label_00AE:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00BB;
            }
        Label_00BB:
            disposable.Dispose();
        }
    Label_00C3:
        return 0;
    Label_00C5:
        return flag;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (base.isDead != null)
        {
            goto Label_002B;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0019;
        }
        return 0;
    Label_0019:
        base.rangePoint = newRallyPoint;
        base.GetMyPath();
        GameSoundManager.PlayHeroReinforcementTaunt();
    Label_002B:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.attackChargeTime = 12;
        base.attackChargeDamageTime = 8;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_hammer", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_hammer", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_hammer", "respawn", 1)) * 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_hammer", "reload", 1)) * 30) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_hammer", "smashModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_hammer", "fissureModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_hammer", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(0f, 32f);
        base.levelUpChargeTime = 0x16;
        base.respawnTime = 0x16;
        this.smashChargeTime = 0x1c;
        this.fissureChargeTime = 0x25;
        base.levelUpSoundShoot = 5;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.6f;
        base.lifes = 1;
        base.xAdjust = 7f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        this.currentAttack = 1;
        return;
    }

    protected unsafe void DoFissure()
    {
        EarthquakeController controller;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_0059;
        }
        this.DoFissureDamage(new Vector2(&base.transform.position.x + 31f, &base.transform.position.y));
        goto Label_0092;
    Label_0059:
        this.DoFissureDamage(new Vector2(&base.transform.position.x - 31f, &base.transform.position.y));
    Label_0092:
        controller = base.GetComponent<EarthquakeController>();
        controller.enabled = 1;
        controller.InitWithPath(this.fissureNodePath, this.fissureNodeSubPath, this.fissureNodeIndex, this.fissureLevel, this.fissureMinDamage, this.fissureMaxDamage, this.fissureRangeWidth, this.fissureRangeHeight);
        return;
    }

    protected unsafe void DoFissureDamage(Vector2 pos)
    {
        Transform transform;
        Transform transform2;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        transform = UnityEngine.Object.Instantiate(this.effectEarthquakePrefab, new Vector3(&pos.x, (&pos.y - base.yAdjust) - 15f, -900f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0058:
        try
        {
            goto Label_00CB;
        Label_005D:
            transform2 = (Transform) enumerator.Current;
            creep = transform2.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00CB;
            }
            if (this.OnRangeFissure(creep, pos) == null)
            {
                goto Label_00CB;
            }
            creep.Damage(this.GetDamageFissure(), 0, 0, 0);
            if (creep.IsBoss() != null)
            {
                goto Label_00CB;
            }
            if (creep.isFlying != null)
            {
                goto Label_00CB;
            }
            if (creep.IsActive() == null)
            {
                goto Label_00CB;
            }
            if (creep.IsDead() != null)
            {
                goto Label_00CB;
            }
            creep.DoStun(60);
        Label_00CB:
            if (enumerator.MoveNext() != null)
            {
                goto Label_005D;
            }
            goto Label_00F0;
        }
        finally
        {
        Label_00DB:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E8;
            }
        Label_00E8:
            disposable.Dispose();
        }
    Label_00F0:
        return;
    }

    protected void DoSmash()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_005A;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_005A;
            }
            if (creep.isFlying != null)
            {
                goto Label_005A;
            }
            if (this.OnRangeSmash(creep) == null)
            {
                goto Label_005A;
            }
            creep.Damage(this.GetDamageSmash(), 0, 0, 0);
        Label_005A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_007C;
        }
        finally
        {
        Label_006A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0075;
            }
        Label_0075:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    protected bool EvalFissure()
    {
        if (base.isLevelUp != null)
        {
            goto Label_002C;
        }
        if (base.isCharging != null)
        {
            goto Label_002C;
        }
        if (this.isSmash != null)
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
        if (this.isFissure != null)
        {
            goto Label_009D;
        }
        if (this.fissureReloadTimeCounter >= this.fissureReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (base.isFighting == null)
        {
            goto Label_0062;
        }
        if (this.CanFissure() != null)
        {
            goto Label_0064;
        }
    Label_0062:
        return 0;
    Label_0064:
        this.isFissure = 1;
        this.fissureChargeTimeCounter = 0;
        this.fissureReloadTimeCounter = 0;
        base.sprite.PlayAnim("fissure");
        GameSoundManager.PlayHeroReinforcementJump();
        base.GainXpByAbilityModifier(2, this.fissureLevel);
        return 1;
    Label_009D:
        if (this.fissureChargeTimeCounter >= this.fissureChargeTime)
        {
            goto Label_00D1;
        }
        this.fissureChargeTimeCounter += 1;
        if (this.fissureChargeTimeCounter != 0x11)
        {
            goto Label_00CF;
        }
        this.DoFissure();
    Label_00CF:
        return 1;
    Label_00D1:
        this.isFissure = 0;
        base.isCharging = 0;
        base.attackReloadTimeCounter = 0;
        base.attackChargeTimeCounter = 0;
        this.fissureChargeTimeCounter = 0;
        this.fissureReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalSmash()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        if (base.isLevelUp != null)
        {
            goto Label_002C;
        }
        if (base.isCharging != null)
        {
            goto Label_002C;
        }
        if (this.isFissure != null)
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
        if (this.isSmash != null)
        {
            goto Label_0092;
        }
        if (this.smashReloadTimeCounter >= this.smashReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanSmash() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        this.isSmash = 1;
        this.smashChargeTimeCounter = 0;
        this.smashReloadTimeCounter = 0;
        base.sprite.PlayAnim("smash");
        GameSoundManager.PlayHeroReinforcementSpecial();
        base.GainXpByAbilityModifier(1, this.smashLevel);
        return 1;
    Label_0092:
        if (this.smashChargeTimeCounter >= this.smashChargeTime)
        {
            goto Label_01E5;
        }
        this.smashChargeTimeCounter += 1;
        if (this.smashChargeTimeCounter != 14)
        {
            goto Label_01E3;
        }
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_015E;
        }
        vector = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f) + new Vector3(31f, -10f, 0f);
        UnityEngine.Object.Instantiate(this.groundDecalPrefab, vector, Quaternion.identity);
        base.stage.AddEffect(UnityEngine.Object.Instantiate(this.effectSmashPrefab, vector, Quaternion.identity) as Transform);
        goto Label_01DD;
    Label_015E:
        vector2 = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f) + new Vector3(-31f, -10f, 0f);
        UnityEngine.Object.Instantiate(this.groundDecalPrefab, vector2, Quaternion.identity);
        base.stage.AddEffect(UnityEngine.Object.Instantiate(this.effectSmashPrefab, vector2, Quaternion.identity) as Transform);
    Label_01DD:
        this.DoSmash();
    Label_01E3:
        return 1;
    Label_01E5:
        this.isSmash = 0;
        base.isCharging = 0;
        base.attackReloadTimeCounter = 0;
        base.attackChargeTimeCounter = 0;
        this.smashChargeTimeCounter = 0;
        this.smashReloadTimeCounter = 0;
        return 0;
    }

    protected override void Fight()
    {
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter >= base.attackChargeTime)
        {
            goto Label_003C;
        }
        if (base.attackChargeTimeCounter != base.attackChargeDamageTime)
        {
            goto Label_003B;
        }
        GameSoundManager.PlayHeroReinforcementHit();
        this.HitEnemy();
    Label_003B:
        return;
    Label_003C:
        base.attackChargeTimeCounter = 0;
        base.isCharging = 0;
        return;
    }

    protected int GetDamageFissure()
    {
        return UnityEngine.Random.Range(this.fissureMinDamage, this.fissureMaxDamage);
    }

    protected int GetDamageSmash()
    {
        return UnityEngine.Random.Range(this.smashMinDamage, this.smashMaxDamage + 1);
    }

    public override unsafe void InitWithPosition(Vector2 pos, Vector2 pRallyPoint, int pNameMax, bool pRespawnOnInit, Vector2 myRangePoint)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.rallyPoint = pRallyPoint;
        base.targetedTime = 60;
        base.respawnOnInit = pRespawnOnInit;
        base.rangePoint = myRangePoint;
        base.regenerateTime = 30;
        base.xAdjust = 5f;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.isLifeTimed = 1;
        base.lifeTimeCounter = 0;
        base.deadTimeCounter = base.deadTime - 1;
        return;
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_hammer", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_hammer", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_hammer", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_hammer", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_hammer", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeSmash();
        this.UpgradeFissure();
        return;
    }

    protected bool OnRangeFissure(Creep myEnemy, Vector2 pos)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.fissureRangeHeight, (float) this.fissureRangeWidth, pos);
    }

    protected unsafe bool OnRangeSmash(Creep myEnemy)
    {
        Vector3 vector;
        Vector3 vector2;
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.smashRangeHeight, (float) this.smashRangeWidth, new Vector3(&base.transform.position.x, &base.transform.position.y - base.yAdjust, 0f));
    }

    public override void Pause()
    {
        EarthquakeController controller;
        base.Pause();
        controller = base.GetComponent<EarthquakeController>();
        if (controller.enabled == null)
        {
            goto Label_001E;
        }
        controller.Pause();
    Label_001E:
        return;
    }

    protected override void PlayAnimationAttack()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0035;
        }
        base.sprite.PlayAnim("attack");
        this.currentAttack = 1;
        goto Label_004C;
    Label_0035:
        base.sprite.PlayAnim("attack2");
        this.currentAttack = 2;
    Label_004C:
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroReinforcementDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroReinforcementTauntIntro();
        return;
    }

    protected override bool RunSpecial()
    {
        this.smashReloadTimeCounter += 1;
        this.fissureReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0029;
        }
        return 1;
    Label_0029:
        if (this.smashLevel == null)
        {
            goto Label_0041;
        }
        if (this.EvalSmash() == null)
        {
            goto Label_0041;
        }
        return 1;
    Label_0041:
        if (this.fissureLevel == null)
        {
            goto Label_0059;
        }
        if (this.EvalFissure() == null)
        {
            goto Label_0059;
        }
        return 1;
    Label_0059:
        return 0;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isSmash = 0;
        this.isFissure = 0;
        base.isLevelUp = 0;
        return;
    }

    public override void Unpause()
    {
        EarthquakeController controller;
        base.Unpause();
        controller = base.GetComponent<EarthquakeController>();
        if (controller.enabled == null)
        {
            goto Label_001E;
        }
        controller.Unpause();
    Label_001E:
        return;
    }

    protected void UpgradeFissure()
    {
        if (base.level == 4)
        {
            goto Label_0026;
        }
        if (base.level == 7)
        {
            goto Label_0026;
        }
        if (base.level == 10)
        {
            goto Label_0026;
        }
        return;
    Label_0026:
        if (base.level != 4)
        {
            goto Label_003E;
        }
        this.fissureLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.fissureLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.fissureLevel = 3;
    Label_006A:
        this.fissureRangeWidth = (int) GameSettings.GetHeroSetting("hero_hammer", "fissureRangeWidth", 1);
        this.fissureRangeHeight = Mathf.RoundToInt(((float) this.fissureRangeWidth) * 0.7f);
        this.fissureReloadTime = ((int) GameSettings.GetHeroSetting("hero_hammer", "fissureReloadTime", 1)) * 30;
        this.fissureMinDamage = ((int) GameSettings.GetHeroSetting("hero_hammer", "fissureMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_hammer", "fissureDamageIncrement", 1)) * this.fissureLevel);
        this.fissureMaxDamage = ((int) GameSettings.GetHeroSetting("hero_hammer", "fissureMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_hammer", "fissureDamageIncrement", 1)) * this.fissureLevel);
        return;
    }

    protected void UpgradeSmash()
    {
        if (base.level == 2)
        {
            goto Label_0025;
        }
        if (base.level == 5)
        {
            goto Label_0025;
        }
        if (base.level == 8)
        {
            goto Label_0025;
        }
        return;
    Label_0025:
        if (base.level != 2)
        {
            goto Label_003D;
        }
        this.smashLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.smashLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.smashLevel = 3;
    Label_0068:
        this.smashRangeWidth = (int) GameSettings.GetHeroSetting("hero_hammer", "smashRangeWidth", 1);
        this.smashRangeHeight = Mathf.RoundToInt(((float) this.smashRangeWidth) * 0.7f);
        this.smashReloadTime = ((int) GameSettings.GetHeroSetting("hero_hammer", "smashReloadTime", 1)) * 30;
        this.smashMinDamage = ((int) GameSettings.GetHeroSetting("hero_hammer", "smashMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_hammer", "smashDamageIncrement", 1)) * this.smashLevel);
        this.smashMaxDamage = ((int) GameSettings.GetHeroSetting("hero_hammer", "smashMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_hammer", "smashDamageIncrement", 1)) * this.smashLevel);
        return;
    }
}

