using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroSamurai : SoldierHero
{
    private int deathStrikeChance;
    private int deathStrikeChargeTime;
    private int deathStrikeChargeTimeCounter;
    private int deathStrikeDamage;
    private int deathStrikeLevel;
    private int deathStrikeReloadTime;
    private int deathStrikeReloadTimeCounter;
    private bool isDeathStrike;
    private bool isTorment;
    private SwordsController swords;
    public SwordsController swordsControllerPrefab;
    private Vector2 swordsPoint;
    private int tormentChargeTime;
    private int tormentChargeTimeCounter;
    private int tormentLevel;
    private int tormentMaxDamage;
    private int tormentMinDamage;
    private int tormentMinEnemiesToCast;
    private int tormentRangeHeight;
    private int tormentRangeWidth;
    private int tormentReloadTime;
    private int tormentReloadTimeCounter;

    public SoldierHeroSamurai()
    {
        base..ctor();
        return;
    }

    protected bool CanDeathStrike()
    {
        if (this.deathStrikeLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.deathStrikeReloadTimeCounter >= this.deathStrikeReloadTime)
        {
            goto Label_0020;
        }
        return 0;
    Label_0020:
        this.StartDeathStrike();
        return 1;
    }

    protected bool CanTorment()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        bool flag;
        IDisposable disposable;
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0065;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0065;
            }
            if (creep.isFlying != null)
            {
                goto Label_0065;
            }
            if (this.OnRangeTorment(creep) == null)
            {
                goto Label_0065;
            }
            num += 1;
            if (num != this.tormentMinEnemiesToCast)
            {
                goto Label_0065;
            }
            flag = 1;
            goto Label_008C;
        Label_0065:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
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
        return 0;
    Label_008C:
        return flag;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (base.IsDead() != null)
        {
            goto Label_0048;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0019;
        }
        return 0;
    Label_0019:
        this.ChangeRallyPoint(newRallyPoint);
        base.rangePoint = newRallyPoint + new Vector2(base.xAdjust, base.yAdjust);
        base.GetMyPath();
        GameSoundManager.PlayHeroSamuraiTaunt();
    Label_0048:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.attackChargeTime = 0x1c;
        base.attackChargeDamageTime = 15;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_samurai", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_samurai", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_samurai", "respawn", 1)) * 30;
        base.attackReloadTime = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_samurai", "reload", 1) * 30f) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_samurai", "tormentModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_samurai", "deathStrikeModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_samurai", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(0f, 32f);
        base.levelUpChargeTime = 0x12;
        base.respawnTime = 0x12;
        base.levelUpSoundShoot = 5;
        this.tormentChargeTime = 0x44;
        this.deathStrikeChargeTime = 0x30;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.8f;
        base.lifes = 1;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        return;
    }

    protected void DoDeathStrike()
    {
        this.deathStrikeReloadTimeCounter = 0;
        if ((base.enemy != null) == null)
        {
            goto Label_007D;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_007D;
        }
        if (base.enemy.IsBoss() != null)
        {
            goto Label_0059;
        }
        if ((UnityEngine.Random.Range(0f, 1f) * 100f) <= ((float) this.deathStrikeChance))
        {
            goto Label_0072;
        }
    Label_0059:
        base.enemy.Damage(this.deathStrikeDamage, 0, 0, 0);
        goto Label_007D;
    Label_0072:
        base.enemy.ExplodeMe();
    Label_007D:
        base.GainXpByAbilityModifier(2, this.deathStrikeLevel);
        return;
    }

    protected unsafe void DoTorment()
    {
        Vector3 vector;
        Vector3 vector2;
        GameSoundManager.PlayHeroSamuraiTorment();
        this.tormentReloadTimeCounter = 0;
        base.Invoke("TormentRealDamage", 0.15f);
        this.swords = UnityEngine.Object.Instantiate(this.swordsControllerPrefab, new Vector3(&base.transform.position.x - base.xAdjust, &base.transform.position.y - base.yAdjust, -1f), Quaternion.identity) as SwordsController;
        base.GainXpByAbilityModifier(1, this.tormentLevel);
        return;
    }

    protected void EndDeathStrike()
    {
        this.isDeathStrike = 0;
        this.deathStrikeReloadTimeCounter = 0;
        this.deathStrikeChargeTimeCounter = 0;
        base.RecoverAnimationState();
        return;
    }

    protected void EndTorment()
    {
        this.isTorment = 0;
        this.tormentReloadTimeCounter = 0;
        this.tormentChargeTimeCounter = 0;
        base.RecoverAnimationState();
        return;
    }

    protected bool EvalDeathStrike()
    {
        if (this.deathStrikeLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isDeathStrike != null)
        {
            goto Label_001A;
        }
        return 0;
    Label_001A:
        if (this.deathStrikeChargeTimeCounter >= this.deathStrikeChargeTime)
        {
            goto Label_004E;
        }
        this.deathStrikeChargeTimeCounter += 1;
        if (this.deathStrikeChargeTimeCounter != 0x1c)
        {
            goto Label_004C;
        }
        this.DoDeathStrike();
    Label_004C:
        return 1;
    Label_004E:
        this.EndDeathStrike();
        return 0;
    }

    protected bool EvalTorment()
    {
        if (this.tormentLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isDeathStrike != null)
        {
            goto Label_0023;
        }
        if (base.isWalking == null)
        {
            goto Label_0025;
        }
    Label_0023:
        return 0;
    Label_0025:
        if (this.isTorment != null)
        {
            goto Label_0058;
        }
        if (this.tormentReloadTimeCounter >= this.tormentReloadTime)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        if (this.CanTorment() != null)
        {
            goto Label_0050;
        }
        return 0;
    Label_0050:
        this.StartTorment();
        return 1;
    Label_0058:
        if (this.tormentChargeTimeCounter >= this.tormentChargeTime)
        {
            goto Label_008C;
        }
        this.tormentChargeTimeCounter += 1;
        if (this.tormentChargeTimeCounter != 0x10)
        {
            goto Label_008A;
        }
        this.DoTorment();
    Label_008A:
        return 1;
    Label_008C:
        this.EndTorment();
        return 0;
    }

    protected int GetDamageTorment()
    {
        return (this.tormentMinDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.tormentMaxDamage - this.tormentMinDamage))));
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_samurai", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_samurai", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_samurai", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_samurai", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_samurai", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeTorment();
        this.UpgradeDeathStrike();
        return;
    }

    protected bool OnRangeTorment(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.tormentRangeHeight, (float) this.tormentRangeWidth, base.transform.position);
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroSamuraiDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroSamuraiTauntIntro();
        return;
    }

    protected override bool ReadyToAttack()
    {
        base.attackReloadTimeCounter += 1;
        if (base.attackReloadTimeCounter != base.attackReloadTime)
        {
            goto Label_003E;
        }
        if (this.CanDeathStrike() == null)
        {
            goto Label_002F;
        }
        goto Label_0035;
    Label_002F:
        this.ChargeAttack();
    Label_0035:
        base.attackReloadTimeCounter = 0;
        return 1;
    Label_003E:
        return 0;
    }

    protected override void RevertToStatic()
    {
        base.sprite.PlayAnim("idle");
        return;
    }

    protected override bool RunSpecial()
    {
        this.tormentReloadTimeCounter += 1;
        this.deathStrikeReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0029;
        }
        return 1;
    Label_0029:
        if (this.EvalTorment() == null)
        {
            goto Label_0036;
        }
        return 1;
    Label_0036:
        if (this.EvalDeathStrike() == null)
        {
            goto Label_0043;
        }
        return 1;
    Label_0043:
        return 0;
    }

    protected void StartDeathStrike()
    {
        this.isDeathStrike = 1;
        this.deathStrikeChargeTimeCounter = 0;
        GameSoundManager.PlayHeroSamuraiDeathStrike();
        base.sprite.PlayAnim("deathStrike");
        return;
    }

    protected void StartTorment()
    {
        this.isTorment = 1;
        this.tormentChargeTimeCounter = 0;
        base.sprite.PlayAnim("torment");
        return;
    }

    protected override void StopOnDead()
    {
        base.StopOnDead();
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isTorment = 0;
        this.isDeathStrike = 0;
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isTorment = 0;
        this.isDeathStrike = 0;
        return;
    }

    protected void TormentRealDamage()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        int num;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0073;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0073;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.tormentRangeHeight, (float) this.tormentRangeWidth, base.transform.position) == null)
            {
                goto Label_0073;
            }
            num = this.GetDamageTorment();
            creep.Damage(num, 0, 0, 0);
        Label_0073:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_0098;
        }
        finally
        {
        Label_0083:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0090;
            }
        Label_0090:
            disposable.Dispose();
        }
    Label_0098:
        return;
    }

    public override void Unpause()
    {
        UVAnimation animation;
        base.isPaused = 0;
        if (base.wasAnimating == null)
        {
            goto Label_0022;
        }
        base.sprite.UnpauseAnim();
        goto Label_004F;
    Label_0022:
        animation = base.sprite.GetCurAnim();
        if (animation == null)
        {
            goto Label_004F;
        }
        if ((animation.name != "death") == null)
        {
            goto Label_004F;
        }
        this.RevertToStatic();
    Label_004F:
        if ((base.poisonEffect != null) == null)
        {
            goto Label_0086;
        }
        if (base.poisonEffect.IsHidden() != null)
        {
            goto Label_0086;
        }
        base.poisonEffect.UnpauseAnim();
        base.GetComponent<SoldierModifierPoison>().Unpause();
    Label_0086:
        return;
    }

    protected void UpgradeDeathStrike()
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
            goto Label_0039;
        }
        this.deathStrikeLevel = 1;
    Label_0039:
        if (base.level != 7)
        {
            goto Label_004C;
        }
        this.deathStrikeLevel = 2;
    Label_004C:
        if (base.level != 10)
        {
            goto Label_0060;
        }
        this.deathStrikeLevel = 3;
    Label_0060:
        this.deathStrikeReloadTime = ((int) GameSettings.GetHeroSetting("hero_samurai", "deathStrikeReloadTime", this.deathStrikeLevel)) * 30;
        this.deathStrikeDamage = (int) GameSettings.GetHeroSetting("hero_samurai", "deathStrikeDamage", this.deathStrikeLevel);
        this.deathStrikeChance = (int) GameSettings.GetHeroSetting("hero_samurai", "deathStrikeChance", this.deathStrikeLevel);
        return;
    }

    protected void UpgradeTorment()
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
            goto Label_0038;
        }
        this.tormentLevel = 1;
    Label_0038:
        if (base.level != 5)
        {
            goto Label_004B;
        }
        this.tormentLevel = 2;
    Label_004B:
        if (base.level != 8)
        {
            goto Label_005E;
        }
        this.tormentLevel = 3;
    Label_005E:
        this.tormentReloadTime = ((int) GameSettings.GetHeroSetting("hero_samurai", "tormentReloadTime", 1)) * 30;
        this.tormentRangeWidth = (int) GameSettings.GetHeroSetting("hero_samurai", "tormentRangeWidth", 1);
        this.tormentRangeHeight = Mathf.RoundToInt(((float) this.tormentRangeWidth) * 0.7f);
        this.tormentMinEnemiesToCast = (int) GameSettings.GetHeroSetting("hero_samurai", "tormentMinEnemiesToCast", 1);
        this.tormentMinDamage = (int) GameSettings.GetHeroSetting("hero_samurai", "tormentMinDamage", this.tormentLevel);
        this.tormentMaxDamage = (int) GameSettings.GetHeroSetting("hero_samurai", "tormentMaxDamage", this.tormentLevel);
        return;
    }
}

