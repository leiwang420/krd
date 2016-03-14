using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroDenas : SoldierHero
{
    private int buffChargeTime;
    private int buffChargeTimeCounter;
    private int buffLevel;
    private int buffRangeHeight;
    private int buffRangeWidth;
    private int buffReloadTime;
    private int buffReloadTimeCounter;
    private CatapultController catapult;
    private int catapultChargeTime;
    private int catapultChargeTimeCounter;
    public CatapultController catapultControllerPrefab;
    private int catapultLevel;
    private Vector2 catapultPoint;
    private int catapultRangeHeight;
    private int catapultRangeMin;
    private int catapultRangeWidth;
    private int catapultReloadTime;
    private int catapultReloadTimeCounter;
    private int currentWeapon;
    private DenasCursing curse;
    public Transform denasBuffPrefab;
    public DenasStuff denasStuffPrefab;
    private bool isBuff;
    private bool isCatapult;
    private bool isRangeShooting;
    private int rangeShootChargeTime;
    private int rangeShootChargeTimeCounter;
    private int rangeShootHeight;
    private int rangeShootMinDistance;
    private Vector2 rangeShootPoint;
    private float rangeShootReloadTime;
    private int rangeShootReloadTimeCounter;
    private Creep rangeShootTarget;
    private int rangeShootWidth;
    private ArrayList towers;

    public SoldierHeroDenas()
    {
        base..ctor();
        return;
    }

    protected bool CanBuff()
    {
        TowerBase[] baseArray;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num;
        TowerBase base3;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        this.towers.Clear();
        baseArray2 = baseArray;
        num = 0;
        goto Label_003E;
    Label_0029:
        base2 = baseArray2[num];
        this.towers.Add(base2);
        num += 1;
    Label_003E:
        if (num < ((int) baseArray2.Length))
        {
            goto Label_0029;
        }
        enumerator = this.towers.GetEnumerator();
    Label_0054:
        try
        {
            goto Label_0094;
        Label_0059:
            base3 = (TowerBase) enumerator.Current;
            if (base3.IsActive() == null)
            {
                goto Label_0094;
            }
            if (base3.canBeBuff == null)
            {
                goto Label_0094;
            }
            if (this.OnRangeBuff(base3) == null)
            {
                goto Label_0094;
            }
            flag = 1;
            goto Label_00BD;
        Label_0094:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0059;
            }
            goto Label_00BB;
        }
        finally
        {
        Label_00A5:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B3;
            }
        Label_00B3:
            disposable.Dispose();
        }
    Label_00BB:
        return 0;
    Label_00BD:
        return flag;
    }

    protected unsafe bool CanCatapult()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        int num;
        IDisposable disposable;
        creep = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0060;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_0060;
            }
            if (creep2.isFlying != null)
            {
                goto Label_0060;
            }
            if (this.MinRangeCatapultDistance(creep2) == null)
            {
                goto Label_0060;
            }
            if (this.OnRangeCatapult(creep2) == null)
            {
                goto Label_0060;
            }
            creep = creep2;
            goto Label_006B;
        Label_0060:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
        Label_006B:
            goto Label_0085;
        }
        finally
        {
        Label_0070:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007D;
            }
        Label_007D:
            disposable.Dispose();
        }
    Label_0085:
        if ((creep != null) == null)
        {
            goto Label_00F9;
        }
        if (creep.IsStopped() != null)
        {
            goto Label_00A7;
        }
        if (creep.IsBlocked() == null)
        {
            goto Label_00B4;
        }
    Label_00A7:
        num = creep.GetCurrentNodeIndex();
        goto Label_00DE;
    Label_00B4:
        if ((creep.GetCurrentNodeIndex() + 5) <= creep.GetSubPathCount())
        {
            goto Label_00D4;
        }
        num = creep.GetCurrentNodeIndex();
        goto Label_00DE;
    Label_00D4:
        num = creep.GetCurrentNodeIndex() + 5;
    Label_00DE:
        this.catapultPoint = *(&(creep.GetPath(0)[num]));
        return 1;
    Label_00F9:
        return 0;
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
        GameSoundManager.PlayHeroDenasTaunt();
    Label_002B:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.towers = new ArrayList();
        base.attackChargeTime = 0x13;
        base.attackChargeDamageTime = 9;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_denas", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_denas", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_denas", "respawn", 1)) * 30;
        base.attackReloadTime = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_denas", "reload", 1) * 30f) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_denas", "buffModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_denas", "catapultModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_denas", "xpMultiplier", 1);
        this.rangeShootReloadTime = (float) Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_denas", "rangeShootReloadTime", 1) * 30f);
        this.rangeShootWidth = (int) GameSettings.GetHeroSetting("hero_denas", "rangeShootRangeWidth", 1);
        this.rangeShootHeight = Mathf.RoundToInt(((float) this.rangeShootWidth) * 0.7f);
        this.rangeShootMinDistance = (int) GameSettings.GetHeroSetting("hero_denas", "rangeShootMinDistance", 1);
        this.catapultReloadTime = ((int) GameSettings.GetHeroSetting("hero_denas", "catapultReloadTime", 1)) * 30;
        this.catapultRangeWidth = (int) GameSettings.GetHeroSetting("hero_denas", "catapultRangeWidth", 1);
        this.catapultRangeHeight = Mathf.RoundToInt(((float) this.catapultRangeWidth) * 0.7f);
        this.catapultRangeMin = (int) GameSettings.GetHeroSetting("hero_denas", "catapultMinRangeWidth", 1);
        this.buffReloadTime = ((int) GameSettings.GetHeroSetting("hero_denas", "buffReloadTime", 1)) * 30;
        this.buffRangeWidth = (int) GameSettings.GetHeroSetting("hero_denas", "buffRangeWidth", 1);
        this.buffRangeHeight = Mathf.RoundToInt(((float) this.buffRangeWidth) * 0.7f);
        this.curse = base.transform.FindChild("DenasCurse").GetComponent<DenasCursing>();
        base.adjustAbducted = new Vector2(10f, 30f);
        base.levelUpChargeTime = 0x1b;
        base.respawnTime = 0x15;
        this.catapultChargeTime = 40;
        base.levelUpSoundShoot = 5;
        this.rangeShootChargeTime = 0x13;
        this.buffChargeTime = 0x33;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.6f;
        base.lifes = 1;
        base.xAdjust = 31f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        base.damageTypeMelee = 1;
        return;
    }

    protected void DoBuff()
    {
        TowerBase base2;
        IEnumerator enumerator;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        enumerator = this.towers.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_005E;
        Label_0011:
            base2 = (TowerBase) enumerator.Current;
            if (base2.IsActive() == null)
            {
                goto Label_005E;
            }
            if (base2.canBeBuff == null)
            {
                goto Label_005E;
            }
            if (this.OnRangeBuff(base2) == null)
            {
                goto Label_005E;
            }
            denas = base2.gameObject.AddComponent<TowerModifierHeroDenas>();
            denas.SetLevel(this.buffLevel);
            denas.SetTower(base2);
        Label_005E:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0080;
        }
        finally
        {
        Label_006E:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0079;
            }
        Label_0079:
            disposable.Dispose();
        }
    Label_0080:
        return;
    }

    protected unsafe void DoCatapult()
    {
        this.catapult = UnityEngine.Object.Instantiate(this.catapultControllerPrefab, new Vector3(&this.catapultPoint.x, &this.catapultPoint.y, -1f), Quaternion.identity) as CatapultController;
        this.catapult.SetLevel(this.catapultLevel);
        this.catapult.SetStage(base.stage);
        return;
    }

    protected unsafe bool EvalBuff()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        if (this.isCatapult != null)
        {
            goto Label_0016;
        }
        if (base.isWalking == null)
        {
            goto Label_0018;
        }
    Label_0016:
        return 0;
    Label_0018:
        if (this.isBuff != null)
        {
            goto Label_00CE;
        }
        if (this.buffReloadTimeCounter >= this.buffReloadTime)
        {
            goto Label_0036;
        }
        return 0;
    Label_0036:
        if (this.CanBuff() != null)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        this.isBuff = 1;
        this.buffChargeTimeCounter = 0;
        this.buffReloadTimeCounter = 0;
        base.sprite.PlayAnim("buffTower");
        GameSoundManager.PlayHeroDenasBuff();
        base.GainXpByAbilityModifier(1, this.buffLevel);
        transform = UnityEngine.Object.Instantiate(this.denasBuffPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        return 1;
    Label_00CE:
        if (this.buffChargeTimeCounter >= this.buffChargeTime)
        {
            goto Label_0119;
        }
        this.buffChargeTimeCounter += 1;
        if (this.buffChargeTimeCounter != 2)
        {
            goto Label_0104;
        }
        this.curse.Play();
    Label_0104:
        if (this.buffChargeTimeCounter != 13)
        {
            goto Label_0117;
        }
        this.DoBuff();
    Label_0117:
        return 1;
    Label_0119:
        this.isBuff = 0;
        this.buffReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalCatapult()
    {
        Vector3 vector;
        if (this.isBuff != null)
        {
            goto Label_0016;
        }
        if (base.isWalking == null)
        {
            goto Label_0018;
        }
    Label_0016:
        return 0;
    Label_0018:
        if (this.isCatapult != null)
        {
            goto Label_00D3;
        }
        if (this.catapultReloadTimeCounter >= this.catapultReloadTime)
        {
            goto Label_0036;
        }
        return 0;
    Label_0036:
        if (this.CanCatapult() != null)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        if (&this.catapultPoint.x < &base.transform.position.x)
        {
            goto Label_007B;
        }
        base.transform.localScale = Vector3.one;
        goto Label_009A;
    Label_007B:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_009A:
        this.isCatapult = 1;
        this.catapultChargeTimeCounter = 0;
        this.catapultReloadTimeCounter = 0;
        base.sprite.PlayAnim("catapult");
        GameSoundManager.PlayHeroDenasAttack();
        base.GainXpByAbilityModifier(2, this.catapultLevel);
        return 1;
    Label_00D3:
        if (this.catapultChargeTimeCounter >= this.catapultChargeTime)
        {
            goto Label_0106;
        }
        this.catapultChargeTimeCounter += 1;
        if (this.catapultChargeTimeCounter != 7)
        {
            goto Label_0104;
        }
        this.DoCatapult();
    Label_0104:
        return 1;
    Label_0106:
        this.isCatapult = 0;
        this.catapultReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalRangeShoot()
    {
        int num;
        Vector2 vector;
        DenasStuff stuff;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if (this.isBuff != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (this.isCatapult != null)
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
            goto Label_00D5;
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
            goto Label_00A0;
        }
        base.transform.localScale = Vector3.one;
        goto Label_00BF;
    Label_00A0:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00BF:
        this.isRangeShooting = 1;
        this.rangeShootChargeTimeCounter = 0;
        this.PlayAnimationAttack();
        return 1;
    Label_00D5:
        if (this.rangeShootChargeTimeCounter >= this.rangeShootChargeTime)
        {
            goto Label_02AA;
        }
        this.rangeShootChargeTimeCounter += 1;
        if (this.rangeShootChargeTimeCounter != 9)
        {
            goto Label_02A8;
        }
        num = this.GetDamage();
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_0166;
        }
        &vector = new Vector2(&base.transform.position.x + 8.5f, &base.transform.position.y + 30f);
        goto Label_01A1;
    Label_0166:
        &vector = new Vector2(&base.transform.position.x - 8.5f, &base.transform.position.y + 30f);
    Label_01A1:
        if ((this.rangeShootTarget != null) == null)
        {
            goto Label_0210;
        }
        if (this.rangeShootTarget.IsActive() == null)
        {
            goto Label_0210;
        }
        this.rangeShootPoint = this.rangeShootTarget.GetNode(3);
        if (this.rangeShootTarget.isFlying == null)
        {
            goto Label_0210;
        }
        this.rangeShootPoint += new Vector2(this.rangeShootTarget.xAdjust, this.rangeShootTarget.yAdjust);
    Label_0210:
        stuff = UnityEngine.Object.Instantiate(this.denasStuffPrefab, new Vector3(&vector.x, &vector.y, -890f), Quaternion.identity) as DenasStuff;
        base.stage.AddProjectile(stuff.transform);
        stuff.SetTarget(this.rangeShootTarget, &this.rangeShootPoint.x, &this.rangeShootPoint.y);
        stuff.SetFrame(this.currentWeapon);
        stuff.SetFRange(1);
        stuff.SetG(-0.6f);
        stuff.SetT1(17f);
        stuff.SetDamage(num);
        stuff.SetDenas(this);
    Label_02A8:
        return 1;
    Label_02AA:
        this.isRangeShooting = 0;
        return 0;
    }

    protected bool FindRangeShootTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
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
            goto Label_00D5;
        }
        this.rangeShootTarget = creep;
        this.rangeShootPoint = this.rangeShootTarget.GetNode(3);
        if (creep.isFlying == null)
        {
            goto Label_00D3;
        }
        this.rangeShootPoint += new Vector2(creep.xAdjust, creep.yAdjust);
    Label_00D3:
        return 1;
    Label_00D5:
        return 0;
    }

    protected int GetDamageRangeShoot()
    {
        return UnityEngine.Random.Range(base.rangeShootMinDamage, base.rangeShootMaxDamage + 1);
    }

    protected override unsafe void HitEnemy()
    {
        int num;
        Vector2 vector;
        DenasStuff stuff;
        DenasStuff stuff2;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
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
        num = this.GetDamage();
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_0093;
        }
        &vector = new Vector2(&base.transform.position.x + 8.5f, &base.transform.position.y + 30f);
        goto Label_00CE;
    Label_0093:
        &vector = new Vector2(&base.transform.position.x - 8.5f, &base.transform.position.y + 30f);
    Label_00CE:
        if (base.enemy.DodgeAttack() != null)
        {
            goto Label_01AF;
        }
        stuff = UnityEngine.Object.Instantiate(this.denasStuffPrefab, new Vector3(&vector.x, &vector.y, -890f), Quaternion.identity) as DenasStuff;
        base.stage.AddProjectile(stuff.transform);
        stuff.SetTarget(base.enemy, &base.enemy.transform.position.x + base.enemy.xAdjust, &base.enemy.transform.position.y + base.enemy.yAdjust);
        stuff.SetFrame(this.currentWeapon);
        stuff.SetFRange(0);
        stuff.SetG(-0.6f);
        stuff.SetT1(15f);
        stuff.SetDamage(num);
        stuff.SetDenas(this);
        goto Label_0275;
    Label_01AF:
        stuff2 = UnityEngine.Object.Instantiate(this.denasStuffPrefab, new Vector3(&vector.x, &vector.y, -890f), Quaternion.identity) as DenasStuff;
        base.stage.AddProjectile(stuff2.transform);
        stuff2.SetDest(&base.enemy.transform.position.x + base.enemy.xAdjust, &base.enemy.transform.position.y + base.enemy.yAdjust);
        stuff2.SetFrame(this.currentWeapon);
        stuff2.SetFRange(0);
        stuff2.SetG(-0.6f);
        stuff2.SetT1(15f);
        stuff2.SetDamage(num);
        stuff2.SetDenas(this);
    Label_0275:
        return;
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_denas", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_denas", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_denas", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_denas", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_denas", "maxDamage", base.level);
        base.rangeShootMinDamage = (int) GameSettings.GetHeroSetting("hero_denas", "minRangeDamage", base.level);
        base.rangeShootMaxDamage = (int) GameSettings.GetHeroSetting("hero_denas", "maxRangeDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeBuff();
        this.UpgradeCatapult();
        return;
    }

    protected unsafe bool MinRangeCatapultDistance(Creep myEnemy)
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.catapultRangeMin))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
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

    protected unsafe bool OnRangeBuff(TowerBase myTower)
    {
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        if ((myTower == null) == null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        &vector = new Vector2(&myTower.transform.position.x, &myTower.transform.position.y - ((float) myTower.terrainOffsetY));
        return IronUtils.ellipseContainPoint(vector, (float) this.buffRangeHeight, (float) this.buffRangeWidth, base.transform.position);
    }

    protected bool OnRangeCatapult(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.catapultRangeHeight, (float) this.catapultRangeWidth, base.transform.position);
    }

    protected bool OnRangeShoot(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeShootHeight, (float) this.rangeShootWidth, base.transform.position);
    }

    public override void Pause()
    {
        if ((this.curse == null) == null)
        {
            goto Label_002C;
        }
        this.curse = base.transform.FindChild("DenasCurse").GetComponent<DenasCursing>();
    Label_002C:
        if ((this.catapult != null) == null)
        {
            goto Label_0048;
        }
        this.catapult.Pause();
    Label_0048:
        base.Pause();
        this.curse.Pause();
        return;
    }

    protected override void PlayAnimationAttack()
    {
        int num;
        this.currentWeapon = UnityEngine.Random.Range(1, 5);
        switch ((this.currentWeapon - 1))
        {
            case 0:
                goto Label_0031;

            case 1:
                goto Label_0046;

            case 2:
                goto Label_005B;

            case 3:
                goto Label_0070;
        }
        goto Label_0085;
    Label_0031:
        base.sprite.PlayAnim("attack");
        goto Label_008A;
    Label_0046:
        base.sprite.PlayAnim("barrel");
        goto Label_008A;
    Label_005B:
        base.sprite.PlayAnim("chicken");
        goto Label_008A;
    Label_0070:
        base.sprite.PlayAnim("bottle");
        goto Label_008A;
    Label_0085:;
    Label_008A:
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroDenasDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroDenasTauntIntro();
        return;
    }

    protected override bool RunSpecial()
    {
        this.rangeShootReloadTimeCounter += 1;
        this.buffReloadTimeCounter += 1;
        this.catapultReloadTimeCounter += 1;
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
        if (this.buffLevel == null)
        {
            goto Label_005C;
        }
        if (this.EvalBuff() == null)
        {
            goto Label_005C;
        }
        return 1;
    Label_005C:
        if (this.catapultLevel == null)
        {
            goto Label_0074;
        }
        if (this.EvalCatapult() == null)
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
        this.isBuff = 0;
        this.isCatapult = 0;
        base.isCharging = 0;
        this.isRangeShooting = 0;
        base.isLevelUp = 0;
        return;
    }

    public override void Unpause()
    {
        base.Unpause();
        this.curse.Unpause();
        if ((this.catapult != null) == null)
        {
            goto Label_002D;
        }
        this.catapult.Unpause();
    Label_002D:
        return;
    }

    protected void UpgradeBuff()
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
        this.buffLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.buffLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.buffLevel = 3;
    Label_0068:
        return;
    }

    protected void UpgradeCatapult()
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
        this.catapultLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.catapultLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.catapultLevel = 3;
    Label_006A:
        return;
    }
}

