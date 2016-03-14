using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroGeneral : SoldierHero
{
    private int blockCounterChance;
    private int blockCounterChargeTime;
    private int blockCounterChargeTimeCounter;
    private int blockCounterDamageReturn;
    private int blockCounterLevel;
    private int blockCounterMaxDamage;
    private int blockCounterMinDamage;
    public Transform buffCouragePrefab;
    private int courageChargeTime;
    private int courageChargeTimeCounter;
    private int courageLevel;
    private int courageRangeHeight;
    private int courageRangeWidth;
    private int courageReloadTime;
    private int courageReloadTimeCounter;
    private bool isBlockCounter;
    private bool isCourage;

    public SoldierHeroGeneral()
    {
        base..ctor();
        return;
    }

    protected bool CanCourage()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0015:
        try
        {
            goto Label_0066;
        Label_001A:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0066;
            }
            if (soldier.CanBeCourage() == null)
            {
                goto Label_0066;
            }
            if (soldier.IsFighting() == null)
            {
                goto Label_0066;
            }
            if (this.OnRangeCourage(soldier) == null)
            {
                goto Label_0066;
            }
            num += 1;
            if (num != 2)
            {
                goto Label_0066;
            }
            flag = 1;
            goto Label_008D;
        Label_0066:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
            goto Label_008B;
        }
        finally
        {
        Label_0076:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0083;
            }
        Label_0083:
            disposable.Dispose();
        }
    Label_008B:
        return 0;
    Label_008D:
        return flag;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (base.isDead != null)
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
        GameSoundManager.PlayHeroPaladinTaunt();
    Label_0048:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.attackChargeTime = 12;
        base.attackChargeDamageTime = 5;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_general", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_general", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_general", "respawn", 1)) * 30;
        base.attackReloadTime = ((int) (GameSettings.GetHeroSetting("hero_general", "reload", 1) * 30f)) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_general", "courageModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_general", "blockCounterModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_general", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(0f, 32f);
        base.levelUpChargeTime = 0x16;
        base.respawnTime = 0x16;
        this.blockCounterChargeTime = 0x16;
        this.courageChargeTime = 0x37;
        base.levelUpSoundShoot = 5;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.1f;
        base.lifes = 1;
        base.xAdjust = 7f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        return;
    }

    protected void DoCourage()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        Transform transform;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_00D8;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_00D8;
            }
            if (soldier.CanBeCourage() == null)
            {
                goto Label_00D8;
            }
            if (this.OnRangeCourage(soldier) == null)
            {
                goto Label_00D8;
            }
            transform = UnityEngine.Object.Instantiate(this.buffCouragePrefab, soldier.transform.position - new Vector3(2f, 0f, -1f), Quaternion.identity) as Transform;
            transform.GetComponent<SoldierModifierCourage>().Init(this.courageLevel, soldier);
            transform.parent = soldier.transform;
            if ((soldier.name == "Sylvan Elf(Clone)") == null)
            {
                goto Label_00D8;
            }
            transform.position += new Vector3(0f, 4f, 0f);
        Label_00D8:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00FD;
        }
        finally
        {
        Label_00E8:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00F5;
            }
        Label_00F5:
            disposable.Dispose();
        }
    Label_00FD:
        return;
    }

    public override bool DodgeHit()
    {
        if (this.isBlockCounter != null)
        {
            goto Label_0021;
        }
        if (base.isLevelUp != null)
        {
            goto Label_0021;
        }
        if (this.isCourage == null)
        {
            goto Label_0023;
        }
    Label_0021:
        return 0;
    Label_0023:
        if (UnityEngine.Random.Range(1, 0x65) <= this.blockCounterChance)
        {
            goto Label_0038;
        }
        return 0;
    Label_0038:
        this.StopSpecial();
        this.isBlockCounter = 1;
        this.blockCounterChargeTimeCounter = 0;
        base.sprite.PlayAnim("blockCounter");
        GameSoundManager.PlayHeroPaladinDeflect();
        base.GainXpByAbilityModifier(2, this.blockCounterLevel);
        return 1;
    }

    protected bool EvalBlockCounterAttack()
    {
        if (this.blockCounterChargeTimeCounter >= this.blockCounterChargeTime)
        {
            goto Label_0062;
        }
        this.blockCounterChargeTimeCounter += 1;
        if (this.blockCounterChargeTimeCounter != 5)
        {
            goto Label_0060;
        }
        if ((base.enemy != null) == null)
        {
            goto Label_0060;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_0060;
        }
        base.enemy.Damage(this.GetDamageCounterAttack(), 0, 0, 0);
    Label_0060:
        return 1;
    Label_0062:
        this.isBlockCounter = 0;
        this.blockCounterChargeTimeCounter = 0;
        return 0;
    }

    protected bool EvalCourage()
    {
        if (base.isLevelUp != null)
        {
            goto Label_002C;
        }
        if (base.isCharging != null)
        {
            goto Label_002C;
        }
        if (this.isBlockCounter != null)
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
        if (this.isCourage != null)
        {
            goto Label_0086;
        }
        if (this.courageReloadTimeCounter >= this.courageReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanCourage() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        this.isCourage = 1;
        this.courageChargeTimeCounter = 0;
        base.sprite.PlayAnim("courage");
        base.GainXpByAbilityModifier(1, this.courageLevel);
        return 1;
    Label_0086:
        if (this.courageChargeTimeCounter >= this.courageChargeTime)
        {
            goto Label_00CB;
        }
        this.courageChargeTimeCounter += 1;
        if (this.courageChargeTimeCounter != 0x11)
        {
            goto Label_00B8;
        }
        this.DoCourage();
    Label_00B8:
        if (this.courageChargeTimeCounter != 3)
        {
            goto Label_00C9;
        }
        GameSoundManager.PlayHeroPaladinValor();
    Label_00C9:
        return 1;
    Label_00CB:
        this.isCourage = 0;
        base.isCharging = 0;
        base.attackReloadTimeCounter = 0;
        base.attackChargeTimeCounter = 0;
        this.courageChargeTimeCounter = 0;
        this.courageReloadTimeCounter = 0;
        return 0;
    }

    protected int GetDamageCounterAttack()
    {
        return ((base.dodgeDamage * this.blockCounterDamageReturn) / 100);
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_general", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_general", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_general", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_general", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_general", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeBlockCounterAttack();
        this.UpgradeCourage();
        return;
    }

    protected bool OnRangeCourage(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) this.courageRangeHeight, (float) this.courageRangeWidth, base.transform.position);
    }

    protected override void PlayAnimationAttack()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_002E;
        }
        base.sprite.PlayAnim("attack");
        goto Label_003E;
    Label_002E:
        base.sprite.PlayAnim("attack2");
    Label_003E:
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroPaladinDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroPaladinTauntIntro();
        return;
    }

    protected override bool RunSpecial()
    {
        this.courageReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_001B;
        }
        return 1;
    Label_001B:
        if (this.isBlockCounter == null)
        {
            goto Label_002F;
        }
        this.EvalBlockCounterAttack();
        return 1;
    Label_002F:
        if (this.courageLevel == null)
        {
            goto Label_0047;
        }
        if (this.EvalCourage() == null)
        {
            goto Label_0047;
        }
        return 1;
    Label_0047:
        return 0;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isCourage = 0;
        this.isBlockCounter = 0;
        base.isLevelUp = 0;
        return;
    }

    protected void UpgradeBlockCounterAttack()
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
        this.blockCounterLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.blockCounterLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.blockCounterLevel = 3;
    Label_006A:
        this.blockCounterMinDamage = (int) GameSettings.GetHeroSetting("hero_general", "blockCounterMinDamage", 1);
        this.blockCounterMaxDamage = (int) GameSettings.GetHeroSetting("hero_general", "blockCounterMaxDamage", 1);
        this.blockCounterDamageReturn = ((int) GameSettings.GetHeroSetting("hero_general", "blockCounterDamageReturn", 1)) + (((int) GameSettings.GetHeroSetting("hero_general", "blockCounterDamageReturnIncrement", 1)) * this.blockCounterLevel);
        this.blockCounterChance = ((int) GameSettings.GetHeroSetting("hero_general", "blockCounterChance", 1)) + (((int) GameSettings.GetHeroSetting("hero_general", "blockCounterChanceIncrement", 1)) * this.blockCounterLevel);
        return;
    }

    protected void UpgradeCourage()
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
        this.courageLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.courageLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.courageLevel = 3;
    Label_0068:
        this.courageRangeWidth = (int) GameSettings.GetHeroSetting("hero_general", "courageRangeWidth", 1);
        this.courageRangeHeight = Mathf.RoundToInt(((float) this.courageRangeWidth) * 0.7f);
        this.courageReloadTime = ((int) GameSettings.GetHeroSetting("hero_general", "courageReloadTime", 1)) * 30;
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

