using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroArcher : SoldierHero
{
    public ArrowHero arrowHeroPrefab;
    public Arrow arrowPrefab;
    private int callOfWildChargeTime;
    private int callOfWildChargeTimeCounter;
    private int callOfWildLevel;
    private int callOfWildReloadTime;
    private int callOfWildReloadTimeCounter;
    private bool isCallOfWild;
    private bool isMultiShoot;
    private bool isRangeShooting;
    private int multiShootChargeTime;
    private int multiShootChargeTimeCounter;
    private int multiShootLevel;
    private int multiShootMaxArrows;
    private int multiShootMaxDamage;
    private int multiShootMinDamage;
    private int multiShootRangeHeightNear;
    private int multiShootRangeWidthNear;
    private int multiShootReloadTime;
    private int multiShootReloadTimeCounter;
    private int rangeShootChargeTime;
    private int rangeShootChargeTimeCounter;
    private int rangeShootHeight;
    private int rangeShootMinDistance;
    private Vector2 rangeShootPoint;
    private float rangeShootReloadTime;
    private int rangeShootReloadTimeCounter;
    private Creep rangeShootTarget;
    private int rangeShootWidth;
    private int referenceNode;
    private int referencePath;
    private SoldierWildCat wildCat;
    private Vector2 wildCatNode;
    public SoldierWildCat wildcatPrefab;

    public SoldierHeroArcher()
    {
        base..ctor();
        return;
    }

    protected unsafe void AddArrowMultiShoot(int arrowDamage, Vector2 myDestination, Creep arrowTarget, int myHeight)
    {
        ArrowHero hero;
        hero = UnityEngine.Object.Instantiate(this.arrowHeroPrefab, base.transform.position + new Vector3(4f, 0f, 0f), Quaternion.identity) as ArrowHero;
        base.stage.AddProjectile(hero.transform);
        hero.SetDamage(arrowDamage);
        hero.SetTarget(arrowTarget, &myDestination.x, &myDestination.y);
        hero.SetIgnoresArmorPoints(100);
        hero.SetT1((float) myHeight);
        return;
    }

    protected bool CanCallOfWild()
    {
        if ((this.wildCat != null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        if (this.callOfWildReloadTime != null)
        {
            goto Label_0020;
        }
        return 0;
    Label_0020:
        return 1;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (base.isDead != null)
        {
            goto Label_005A;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0019;
        }
        return 0;
    Label_0019:
        base.rangePoint = newRallyPoint;
        this.FindReferenceNode();
        base.GetMyPath();
        if ((this.wildCat != null) == null)
        {
            goto Label_0055;
        }
        this.wildCat.ChangeRallyPointHero(this.wildCatNode, base.path);
    Label_0055:
        GameSoundManager.PlayHeroArcherTaunt();
    Label_005A:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.attackChargeTime = 0x12;
        base.attackChargeDamageTime = 8;
        base.levelUpChargeTime = 0x13;
        base.respawnTime = 0x13;
        this.multiShootChargeTime = 0x1d;
        this.callOfWildChargeTime = 40;
        this.rangeShootChargeTime = 15;
        base.levelUpSoundShoot = 5;
        base.adjustAbducted = new Vector2(10f, 30f);
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_archer", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_archer", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_archer", "respawn", 1)) * 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_archer", "reload", 1)) * 30) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_archer", "multiShootModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_archer", "callOfWildModifier", 1);
        this.rangeShootReloadTime = (GameSettings.GetHeroSetting("hero_archer", "rangeShootReloadTime", 1) * 30f) - ((float) this.rangeShootChargeTime);
        this.rangeShootWidth = (int) GameSettings.GetHeroSetting("hero_archer", "rangeShootRangeWidth", 1);
        this.rangeShootHeight = Mathf.RoundToInt(((float) this.rangeShootWidth) * 0.7f);
        this.rangeShootMinDistance = (int) GameSettings.GetHeroSetting("hero_archer", "rangeShootMinDistance", 1);
        this.multiShootRangeWidthNear = (int) GameSettings.GetHeroSetting("hero_archer", "multiShootRangeWidthNear", 1);
        this.multiShootRangeHeightNear = Mathf.RoundToInt(((float) this.multiShootRangeWidthNear) * 0.7f);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_archer", "xpMultiplier", 1);
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 4.2f;
        base.lifes = 1;
        base.xAdjust = 5f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        this.FindReferenceNode();
        base.damageType = 4;
        return;
    }

    protected unsafe void DoCallOfWild()
    {
        this.wildCat = UnityEngine.Object.Instantiate(this.wildcatPrefab, new Vector3(&this.wildCatNode.x, &this.wildCatNode.y, -1f), Quaternion.identity) as SoldierWildCat;
        this.wildCat.InitWithPosition(this.wildCatNode, this.wildCatNode, 40, 0, this.wildCatNode, this.callOfWildLevel, this);
        this.wildcatPrefab.SetRangeCenterPosition(this.wildCatNode);
        base.stage.AddSoldier(this.wildCat);
        this.callOfWildReloadTime = 0;
        return;
    }

    protected void DoMultiShoot()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        int num2;
        IDisposable disposable;
        if ((this.rangeShootTarget == null) == null)
        {
            goto Label_001D;
        }
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_001D;
        }
        return;
    Label_001D:
        num = 0;
        this.AddArrowMultiShoot(this.GetDamageMultiShoot(), this.rangeShootPoint, this.rangeShootTarget, this.GetRandomHeight());
        num += 1;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0052:
        try
        {
            goto Label_00C0;
        Label_0057:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00C0;
            }
            if ((creep != this.rangeShootTarget) == null)
            {
                goto Label_00C0;
            }
            if (this.OnRangeShootMultiShootNear(creep) == null)
            {
                goto Label_00C0;
            }
            this.AddArrowMultiShoot(this.GetDamageMultiShoot(), this.rangeShootPoint, creep, this.GetRandomHeight());
            num += 1;
            if (num != this.multiShootMaxArrows)
            {
                goto Label_00C0;
            }
            goto Label_00CB;
        Label_00C0:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0057;
            }
        Label_00CB:
            goto Label_00E5;
        }
        finally
        {
        Label_00D0:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00DD;
            }
        Label_00DD:
            disposable.Dispose();
        }
    Label_00E5:
        if (num >= this.multiShootMaxArrows)
        {
            goto Label_014D;
        }
        if ((this.rangeShootTarget != null) == null)
        {
            goto Label_014D;
        }
        if (this.rangeShootTarget.IsActive() == null)
        {
            goto Label_014D;
        }
        num2 = 0;
        goto Label_013E;
    Label_011A:
        this.AddArrowMultiShoot(this.GetDamageMultiShoot(), this.rangeShootPoint, this.rangeShootTarget, this.GetRandomHeight());
        num2 += 1;
    Label_013E:
        if (num2 < (this.multiShootMaxArrows - num))
        {
            goto Label_011A;
        }
    Label_014D:
        return;
    }

    protected bool EvalCallOfWild()
    {
        if (this.isMultiShoot != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (this.isRangeShooting != null)
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
        if (this.isCallOfWild != null)
        {
            goto Label_0092;
        }
        if (this.callOfWildReloadTimeCounter >= this.callOfWildReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanCallOfWild() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        this.isCallOfWild = 1;
        this.callOfWildChargeTimeCounter = 0;
        this.callOfWildReloadTimeCounter = 0;
        base.sprite.PlayAnim("callofthewild");
        GameSoundManager.PlayHeroArcherSummon();
        base.GainXpByAbilityModifier(2, this.callOfWildLevel);
        return 1;
    Label_0092:
        if (this.callOfWildChargeTimeCounter >= this.callOfWildChargeTime)
        {
            goto Label_00C6;
        }
        this.callOfWildChargeTimeCounter += 1;
        if (this.callOfWildChargeTimeCounter != 0x11)
        {
            goto Label_00C4;
        }
        this.DoCallOfWild();
    Label_00C4:
        return 1;
    Label_00C6:
        this.isCallOfWild = 0;
        this.callOfWildReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalMultiShoot()
    {
        Vector3 vector;
        Vector3 vector2;
        if (this.isCallOfWild != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (this.isRangeShooting != null)
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
        if (this.isMultiShoot != null)
        {
            goto Label_00F6;
        }
        if (this.multiShootReloadTimeCounter >= this.multiShootReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        if (&this.rangeShootTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_009E;
        }
        base.transform.localScale = Vector3.one;
        goto Label_00BD;
    Label_009E:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00BD:
        this.isMultiShoot = 1;
        this.multiShootChargeTimeCounter = 0;
        this.multiShootReloadTimeCounter = 0;
        base.sprite.PlayAnim("multishoot");
        GameSoundManager.PlayHeroArcherShoot();
        base.GainXpByAbilityModifier(1, this.multiShootLevel);
        return 1;
    Label_00F6:
        if (this.multiShootChargeTimeCounter >= this.multiShootChargeTime)
        {
            goto Label_012A;
        }
        this.multiShootChargeTimeCounter += 1;
        if (this.multiShootChargeTimeCounter != 0x10)
        {
            goto Label_0128;
        }
        this.DoMultiShoot();
    Label_0128:
        return 1;
    Label_012A:
        this.isMultiShoot = 0;
        this.multiShootReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalRangeShoot()
    {
        int num;
        Arrow arrow;
        Vector3 vector;
        Vector3 vector2;
        if (this.isMultiShoot != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (this.isCallOfWild != null)
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
        if (this.isRangeShooting != null)
        {
            goto Label_00DE;
        }
        if (((float) this.rangeShootReloadTimeCounter) >= this.rangeShootReloadTime)
        {
            goto Label_004D;
        }
        return 0;
    Label_004D:
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_005A;
        }
        return 0;
    Label_005A:
        if (&this.rangeShootTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_009F;
        }
        base.transform.localScale = Vector3.one;
        goto Label_00BE;
    Label_009F:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00BE:
        this.isRangeShooting = 1;
        this.rangeShootChargeTimeCounter = 0;
        base.sprite.PlayAnim("shoot");
        return 1;
    Label_00DE:
        if (this.rangeShootChargeTimeCounter >= this.rangeShootChargeTime)
        {
            goto Label_0198;
        }
        this.rangeShootChargeTimeCounter += 1;
        if (this.rangeShootChargeTimeCounter != 7)
        {
            goto Label_0196;
        }
        num = this.GetDamageRangeShoot();
        arrow = UnityEngine.Object.Instantiate(this.arrowPrefab, base.transform.position + new Vector3(4f, 0f, 0f), Quaternion.identity) as Arrow;
        base.stage.AddProjectile(arrow.transform);
        arrow.SetT1(15f);
        arrow.SetDamage(num);
        arrow.SetTarget(this.rangeShootTarget, &this.rangeShootPoint.x, &this.rangeShootPoint.y);
        base.GainXpByDamage(num);
    Label_0196:
        return 1;
    Label_0198:
        this.isRangeShooting = 0;
        this.rangeShootReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool FindRangeShootTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        creep = null;
        this.rangeShootTarget = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001A:
        try
        {
            goto Label_005C;
        Label_001F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_005C;
            }
            if (this.MinRangeShootDistance(creep2) == null)
            {
                goto Label_005C;
            }
            if (this.OnRangeShoot(creep2) == null)
            {
                goto Label_005C;
            }
            creep = creep2;
            goto Label_0067;
        Label_005C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_0067:
            goto Label_0081;
        }
        finally
        {
        Label_006C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0079;
            }
        Label_0079:
            disposable.Dispose();
        }
    Label_0081:
        if ((creep != null) == null)
        {
            goto Label_012C;
        }
        this.rangeShootTarget = creep;
        if ((this.rangeShootTarget.GetComponent<CreepJuggernaut>() != null) == null)
        {
            goto Label_00E9;
        }
        this.rangeShootPoint = new Vector2(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y);
        goto Label_012A;
    Label_00E9:
        this.rangeShootPoint = new Vector2(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y + creep.yAdjust);
    Label_012A:
        return 1;
    Label_012C:
        return 0;
    }

    protected unsafe void FindReferenceNode()
    {
        int num;
        int num2;
        Vector2[][][] vectorArray;
        int num3;
        int num4;
        int num5;
        num = 0;
        num2 = 0;
        vectorArray = base.stage.GetPath();
        num3 = 0;
        goto Label_00D5;
    Label_0017:
        num4 = 0;
        goto Label_00C3;
    Label_001F:
        if (base.stage.StageHasTunnels() == null)
        {
            goto Label_003D;
        }
        if (base.OnTunnel(num3, num4) != null)
        {
            goto Label_00BD;
        }
    Label_003D:
        num2 = Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow(&(vectorArray[num3][0][num4]).y - &this.rangePoint.y, 2f) + Mathf.Pow(&(vectorArray[num3][0][num4]).x - &this.rangePoint.x, 2f)));
        if (num2 >= 0x49)
        {
            goto Label_00BD;
        }
        if (num == null)
        {
            goto Label_00AC;
        }
        if (num <= num2)
        {
            goto Label_00BD;
        }
    Label_00AC:
        this.referencePath = num3;
        this.referenceNode = num4;
        num = num2;
    Label_00BD:
        num4 += 1;
    Label_00C3:
        if (num4 < ((int) vectorArray[num3][0].Length))
        {
            goto Label_001F;
        }
        num3 += 1;
    Label_00D5:
        if (num3 < ((int) vectorArray.Length))
        {
            goto Label_0017;
        }
        if (this.referenceNode == null)
        {
            goto Label_011A;
        }
        num5 = this.referenceNode - 5;
        if (num5 >= 0)
        {
            goto Label_00FE;
        }
        num5 = 0;
    Label_00FE:
        this.wildCatNode = *(&(vectorArray[this.referencePath][0][num5]));
    Label_011A:
        return;
    }

    protected int GetDamageMultiShoot()
    {
        return UnityEngine.Random.Range(this.multiShootMinDamage, this.multiShootMaxDamage + 1);
    }

    protected int GetDamageRangeShoot()
    {
        return UnityEngine.Random.Range(base.rangeShootMaxDamage, base.rangeShootMinDamage + 1);
    }

    protected int GetRandomHeight()
    {
        return UnityEngine.Random.Range(15, 0x16);
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

    protected bool IsNearExit(Creep enemyOld, Creep enemyNew)
    {
        if ((base.enemy.GetSubPathCount() - base.enemy.GetCurrentNodeIndex()) <= (enemyNew.GetSubPathCount() - enemyNew.GetCurrentNodeIndex()))
        {
            goto Label_002B;
        }
        return 1;
    Label_002B:
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_archer", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_archer", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_archer", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_archer", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_archer", "maxDamage", base.level);
        base.rangeShootMinDamage = (int) GameSettings.GetHeroSetting("hero_archer", "minRangeDamage", base.level);
        base.rangeShootMaxDamage = (int) GameSettings.GetHeroSetting("hero_archer", "maxRangeDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeMultiShoot();
        this.UpgradeCallOfWild();
        return;
    }

    protected unsafe bool MinRangeShootDistance(Creep myEnemy)
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.rangeShootMinDistance))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected bool OnRangeShoot(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeShootHeight, (float) this.rangeShootWidth, base.transform.position);
    }

    protected bool OnRangeShootMultiShootNear(Creep myEnemy)
    {
        if ((myEnemy == null) == null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.multiShootRangeHeightNear, (float) this.multiShootRangeWidthNear, this.rangeShootTarget.transform.position);
    }

    public override void Pause()
    {
        base.Pause();
        if ((this.wildCat != null) == null)
        {
            goto Label_0022;
        }
        this.wildCat.Pause();
    Label_0022:
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroArcherDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroArcherTauntIntro();
        return;
    }

    protected override bool RunSpecial()
    {
        this.rangeShootReloadTimeCounter += 1;
        this.multiShootReloadTimeCounter += 1;
        this.callOfWildReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        if (this.EvalRangeShoot() == null)
        {
            goto Label_0044;
        }
        return 1;
    Label_0044:
        if (this.multiShootLevel == null)
        {
            goto Label_005C;
        }
        if (this.EvalMultiShoot() == null)
        {
            goto Label_005C;
        }
        return 1;
    Label_005C:
        if (this.callOfWildLevel == null)
        {
            goto Label_0074;
        }
        if (this.EvalCallOfWild() == null)
        {
            goto Label_0074;
        }
        return 1;
    Label_0074:
        return 0;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isMultiShoot = 0;
        this.isCallOfWild = 0;
        this.isRangeShooting = 0;
        base.isCharging = 0;
        base.isLevelUp = 0;
        return;
    }

    public override void Unpause()
    {
        base.Unpause();
        if ((this.wildCat != null) == null)
        {
            goto Label_0022;
        }
        this.wildCat.Unpause();
    Label_0022:
        return;
    }

    protected void UpgradeCallOfWild()
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
        this.callOfWildLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.callOfWildLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.callOfWildLevel = 3;
    Label_006A:
        this.callOfWildReloadTime = (int) GameSettings.GetHeroSetting("hero_archer", "callOfWildReloadTime", 1);
        if ((this.wildCat != null) == null)
        {
            goto Label_00B3;
        }
        if (this.wildCat.IsActive() == null)
        {
            goto Label_00B3;
        }
        this.wildCat.LevelUp(this.callOfWildLevel);
    Label_00B3:
        return;
    }

    protected void UpgradeMultiShoot()
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
        this.multiShootLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.multiShootLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.multiShootLevel = 3;
    Label_0068:
        this.multiShootReloadTime = ((int) GameSettings.GetHeroSetting("hero_archer", "multiShootReloadTime", 1)) * 30;
        this.multiShootMaxArrows = ((int) GameSettings.GetHeroSetting("hero_archer", "multiShootArrows", 1)) + (((int) GameSettings.GetHeroSetting("hero_archer", "multiShootArrowsIncrement", 1)) * this.multiShootLevel);
        this.multiShootMinDamage = base.rangeShootMinDamage;
        this.multiShootMaxDamage = base.rangeShootMaxDamage;
        return;
    }

    public void WildCatIsDead()
    {
        this.wildCat = null;
        this.callOfWildReloadTime = ((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildReloadTime", 1)) * 30;
        this.callOfWildReloadTimeCounter = 0;
        return;
    }
}

