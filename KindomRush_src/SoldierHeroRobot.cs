using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroRobot : SoldierHero
{
    protected bool isSawblade;
    protected bool isTimber;
    public Transform prefabSawblade;
    protected int sawbladeChargeTime;
    protected int sawbladeChargeTimeCounter;
    protected int sawbladeLevel;
    protected int sawbladeMinDistance;
    protected Vector3 sawbladePoint;
    protected int sawbladeRangeHeight;
    protected int sawbladeRangeWidth;
    protected int sawbladeReloadTime;
    protected int sawbladeReloadTimeCounter;
    protected Creep sawbladeTarget;
    protected int timberChargeTime;
    protected int timberChargeTimeCounter;
    protected int timberLevel;
    protected int timberReloadTime;
    protected int timberReloadTimeCounter;

    public SoldierHeroRobot()
    {
        base..ctor();
        return;
    }

    protected unsafe bool CanSawblade()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Vector3 vector;
        Vector3 vector2;
        bool flag;
        IDisposable disposable;
        this.sawbladeTarget = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0018:
        try
        {
            goto Label_00FA;
        Label_001D:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_00FA;
            }
            if (creep.IsActive() == null)
            {
                goto Label_00FA;
            }
            if (this.MinDistance(creep) == null)
            {
                goto Label_00FA;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position + creep.anchorPoint, (float) this.sawbladeRangeHeight, (float) this.sawbladeRangeWidth, base.transform.position - new Vector3(0f, base.yAdjust, 0f)) == null)
            {
                goto Label_00FA;
            }
            this.sawbladeTarget = creep;
            this.sawbladePoint = new Vector3(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y + creep.yAdjust, 0f);
            flag = 1;
            goto Label_0121;
        Label_00FA:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001D;
            }
            goto Label_011F;
        }
        finally
        {
        Label_010A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0117;
            }
        Label_0117:
            disposable.Dispose();
        }
    Label_011F:
        return 0;
    Label_0121:
        return flag;
    }

    protected bool CanTimber()
    {
        if (this.timberLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.timberReloadTimeCounter >= this.timberReloadTime)
        {
            goto Label_0020;
        }
        return 0;
    Label_0020:
        if (base.enemy.IsBoss() == null)
        {
            goto Label_0032;
        }
        return 0;
    Label_0032:
        this.StartTimber();
        return 1;
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
        GameSoundManager.PlayHeroRobotTaunt();
    Label_002B:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.attackChargeTime = 0x1f;
        base.attackChargeDamageTime = 15;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_robot", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_robot", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_robot", "respawn", 1)) * 30;
        base.attackReloadTime = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_robot", "reload", 1) * 30f) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_robot", "sawbladeModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_robot", "timberModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_robot", "xpMultiplier", 1);
        base.levelUpChargeTime = 0x11;
        base.respawnTime = 0x11;
        base.levelUpSoundShoot = 5;
        this.timberChargeTime = 0x23;
        this.sawbladeChargeTime = 0x20;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 2.5f;
        base.lifes = 1;
        base.xAdjust = 18f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        return;
    }

    protected unsafe void DoSawblade()
    {
        Vector3 vector;
        Transform transform;
        RobotSawblade sawblade;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        this.sawbladeReloadTimeCounter = 0;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_0063;
        }
        &vector = new Vector3(&base.transform.position.x + 41f, &base.transform.position.y, -750f);
        goto Label_009D;
    Label_0063:
        &vector = new Vector3(&base.transform.position.x - 41f, &base.transform.position.y, -750f);
    Label_009D:
        transform = UnityEngine.Object.Instantiate(this.prefabSawblade, vector, Quaternion.identity) as Transform;
        transform.GetComponent<RobotSawblade>().Init(this.sawbladeTarget, this.sawbladeLevel, this.sawbladePoint, base.stage);
        this.sawbladeTarget = null;
        GameSoundManager.PlayHeroRobotShoot();
        base.GainXpByAbilityModifier(1, this.sawbladeLevel);
        return;
    }

    protected void DoTimber()
    {
        this.timberReloadTimeCounter = 0;
        if ((base.enemy != null) == null)
        {
            goto Label_0046;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_0046;
        }
        base.enemy.Gib();
        base.enemy.Damage(0x186a0, 0, 0, 0);
    Label_0046:
        base.GainXpByAbilityModifier(2, this.timberLevel);
        return;
    }

    protected void EndSawblade()
    {
        this.isSawblade = 0;
        this.sawbladeReloadTimeCounter = 0;
        this.sawbladeChargeTimeCounter = 0;
        base.RecoverAnimationState();
        return;
    }

    protected void EndTimber()
    {
        this.isTimber = 0;
        this.timberReloadTimeCounter = 0;
        this.timberChargeTimeCounter = 0;
        base.RecoverAnimationState();
        return;
    }

    protected bool EvalSawblade()
    {
        if (this.sawbladeLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isTimber == null)
        {
            goto Label_001A;
        }
        return 0;
    Label_001A:
        if (base.isWalking == null)
        {
            goto Label_0027;
        }
        return 0;
    Label_0027:
        if (this.isSawblade != null)
        {
            goto Label_005A;
        }
        if (this.sawbladeReloadTimeCounter >= this.sawbladeReloadTime)
        {
            goto Label_0045;
        }
        return 0;
    Label_0045:
        if (this.CanSawblade() != null)
        {
            goto Label_0052;
        }
        return 0;
    Label_0052:
        this.StartSawblade();
        return 1;
    Label_005A:
        if (this.sawbladeChargeTimeCounter >= this.sawbladeChargeTime)
        {
            goto Label_008E;
        }
        this.sawbladeChargeTimeCounter += 1;
        if (this.sawbladeChargeTimeCounter != 15)
        {
            goto Label_008C;
        }
        this.DoSawblade();
    Label_008C:
        return 1;
    Label_008E:
        this.EndSawblade();
        return 0;
    }

    protected bool EvalTimber()
    {
        if (this.timberLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isTimber != null)
        {
            goto Label_001A;
        }
        return 0;
    Label_001A:
        if (this.timberChargeTimeCounter >= this.timberChargeTime)
        {
            goto Label_005F;
        }
        this.timberChargeTimeCounter += 1;
        if (this.timberChargeTimeCounter != 7)
        {
            goto Label_004A;
        }
        GameSoundManager.PlayHeroRobotDrill();
    Label_004A:
        if (this.timberChargeTimeCounter != 14)
        {
            goto Label_005D;
        }
        this.DoTimber();
    Label_005D:
        return 1;
    Label_005F:
        this.EndTimber();
        return 0;
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_robot", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_robot", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_robot", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_robot", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_robot", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeTimber();
        this.UpgradeSawblade();
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.sawbladeMinDistance))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroRobotDeath();
        GameSoundManager.PlayBombExplosionSound();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroRobotTaunt();
        return;
    }

    protected override bool ReadyToAttack()
    {
        base.attackReloadTimeCounter += 1;
        if (base.attackReloadTimeCounter != base.attackReloadTime)
        {
            goto Label_003E;
        }
        if (this.CanTimber() == null)
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

    protected override bool RunSpecial()
    {
        this.timberReloadTimeCounter += 1;
        this.sawbladeReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0029;
        }
        return 1;
    Label_0029:
        if (this.EvalSawblade() == null)
        {
            goto Label_0036;
        }
        return 1;
    Label_0036:
        if (this.EvalTimber() == null)
        {
            goto Label_0043;
        }
        return 1;
    Label_0043:
        return 0;
    }

    protected unsafe void StartSawblade()
    {
        Vector3 vector;
        this.isSawblade = 1;
        this.sawbladeChargeTimeCounter = 0;
        if (&base.transform.position.x <= &this.sawbladePoint.x)
        {
            goto Label_0055;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0074;
    Label_0055:
        base.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_0074:
        base.sprite.PlayAnim("sawblade");
        return;
    }

    protected void StartTimber()
    {
        this.isTimber = 1;
        this.timberChargeTimeCounter = 0;
        base.sprite.PlayAnim("timber");
        return;
    }

    protected override void StopOnDead()
    {
        base.StopOnDead();
        this.isTimber = 0;
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isSawblade = 0;
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isTimber = 0;
        this.isSawblade = 0;
        base.isLevelUp = 0;
        return;
    }

    protected void UpgradeSawblade()
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
        this.sawbladeLevel = 1;
    Label_0038:
        if (base.level != 5)
        {
            goto Label_004B;
        }
        this.sawbladeLevel = 2;
    Label_004B:
        if (base.level != 8)
        {
            goto Label_005E;
        }
        this.sawbladeLevel = 3;
    Label_005E:
        this.sawbladeReloadTime = ((int) GameSettings.GetHeroSetting("hero_robot", "sawbladeReloadTime", this.sawbladeLevel)) * 30;
        this.sawbladeRangeWidth = (int) GameSettings.GetHeroSetting("hero_robot", "sawbladeRange", 1);
        this.sawbladeRangeHeight = Mathf.RoundToInt(((float) this.sawbladeRangeWidth) * 0.7f);
        this.sawbladeMinDistance = (int) GameSettings.GetHeroSetting("hero_robot", "sawbladeMinDistance", 1);
        return;
    }

    protected void UpgradeTimber()
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
        this.timberLevel = 1;
    Label_0039:
        if (base.level != 7)
        {
            goto Label_004C;
        }
        this.timberLevel = 2;
    Label_004C:
        if (base.level != 10)
        {
            goto Label_0060;
        }
        this.timberLevel = 3;
    Label_0060:
        this.timberReloadTime = ((int) GameSettings.GetHeroSetting("hero_robot", "timberReloadTime", this.timberLevel)) * 30;
        return;
    }
}

