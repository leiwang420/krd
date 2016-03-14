using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroMage : SoldierHero
{
    public Transform boltPrefab;
    private ArrayList illusionList;
    public Transform ilusionPrefab;
    private bool isMirage;
    private bool isRangeShooting;
    private bool isTeleporting;
    private bool isThunder;
    private int mirageChargeTime;
    private int mirageChargeTimeCounter;
    private int mirageIllusionsMax;
    private int mirageLevel;
    private int mirageReloadTime;
    private int mirageReloadTimeCounter;
    private int rangeShootChargeTime;
    private int rangeShootChargeTimeCounter;
    private int rangeShootHeight;
    private int rangeShootMinDistance;
    private Vector2 rangeShootPoint;
    private float rangeShootReloadTime;
    private int rangeShootReloadTimeCounter;
    private Creep rangeShootTarget;
    private int rangeShootWidth;
    private int teleporthChargeTime;
    private int teleporthChargeTimeCounter;
    private Vector2 teleporthPosition;
    private bool teleportIn;
    private bool teleportStart;
    private int thunderChargeTime;
    private int thunderChargeTimeCounter;
    private ThunderController thunderController;
    private int thunderLevel;
    private int thunderMinDistance;
    private Vector2 thunderPoint;
    public Transform thunderPrefab;
    private int thunderRangeHeight;
    private int thunderRangeWidth;
    private int thunderReloadTime;
    private int thunderReloadTimeCounter;

    public SoldierHeroMage()
    {
        base..ctor();
        return;
    }

    protected void AnimationDelegate(SpriteBase sprt)
    {
        if (this.isTeleporting == null)
        {
            goto Label_0032;
        }
        if (this.teleportStart == null)
        {
            goto Label_0021;
        }
        this.DoTeleporthIn();
        goto Label_0032;
    Label_0021:
        if (this.teleportIn == null)
        {
            goto Label_0032;
        }
        this.TeleporthEnd();
    Label_0032:
        return;
    }

    protected bool CanMirage()
    {
        return 1;
    }

    protected bool CanThunder()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        creep = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_006C;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if ((creep2 != null) == null)
            {
                goto Label_006C;
            }
            if (creep2.IsActive() == null)
            {
                goto Label_006C;
            }
            if (creep2.isFlying != null)
            {
                goto Label_006C;
            }
            if (this.MinThunderDistance(creep2) == null)
            {
                goto Label_006C;
            }
            if (this.OnRangeThunder(creep2) == null)
            {
                goto Label_006C;
            }
            creep = creep2;
            goto Label_0077;
        Label_006C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
        Label_0077:
            goto Label_0091;
        }
        finally
        {
        Label_007C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0089;
            }
        Label_0089:
            disposable.Dispose();
        }
    Label_0091:
        if ((creep != null) == null)
        {
            goto Label_00F9;
        }
        if (creep.IsStopped() != null)
        {
            goto Label_00B3;
        }
        if (creep.IsBlocked() == null)
        {
            goto Label_00C5;
        }
    Label_00B3:
        this.thunderPoint = creep.GetNode(0);
        goto Label_00F7;
    Label_00C5:
        if ((creep.GetCurrentNodeIndex() + 5) <= creep.GetSubPathCount())
        {
            goto Label_00EA;
        }
        this.thunderPoint = creep.GetNode(0);
        goto Label_00F7;
    Label_00EA:
        this.thunderPoint = creep.GetNode(5);
    Label_00F7:
        return 1;
    Label_00F9:
        return 0;
    }

    public override unsafe bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        Vector3 vector;
        Vector3 vector2;
        if (this.isTeleporting == null)
        {
            goto Label_000D;
        }
        return 1;
    Label_000D:
        if (base.isDead != null)
        {
            goto Label_00AB;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0026;
        }
        return 0;
    Label_0026:
        base.rangePoint = newRallyPoint;
        GameSoundManager.PlayHeroMageTaunt();
        if (Vector2.Distance(new Vector2(&base.transform.position.x, &base.transform.position.y), base.rangePoint) <= 141f)
        {
            goto Label_00A5;
        }
        this.DoTeleporth();
        this.teleporthPosition = newRallyPoint;
        GameSoundManager.PlayTeleporthSound();
        if (base.path.Count <= 0)
        {
            goto Label_00AB;
        }
        base.path.Clear();
        goto Label_00AB;
    Label_00A5:
        base.GetMyPath();
    Label_00AB:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.illusionList = new ArrayList();
        base.attackChargeTime = 0x16;
        base.attackChargeDamageTime = 12;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_mage", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_mage", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_mage", "respawn", 1)) * 30;
        base.attackReloadTime = ((int) (GameSettings.GetHeroSetting("hero_mage", "reload", 1) * 30f)) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_mage", "mirageModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_mage", "thunderModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_mage", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(15f, 45f);
        this.rangeShootReloadTime = GameSettings.GetHeroSetting("hero_mage", "rangeShootReloadTime", 1);
        this.rangeShootWidth = (int) GameSettings.GetHeroSetting("hero_mage", "rangeShootRangeWidth", 1);
        this.rangeShootHeight = Mathf.RoundToInt(((float) this.rangeShootWidth) * 0.7f);
        this.rangeShootMinDistance = (int) GameSettings.GetHeroSetting("hero_mage", "rangeShootMinDistance", 1);
        base.levelUpChargeTime = 0x1d;
        base.respawnTime = 0x12;
        this.mirageChargeTime = 0x1f;
        this.thunderChargeTime = 40;
        base.levelUpSoundShoot = 5;
        this.rangeShootChargeTime = 0x21;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 2.2f;
        base.lifes = 1;
        base.xAdjust = 6f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        base.damageType = 2;
        base.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        return;
    }

    protected unsafe void DoMirage()
    {
        Vector3 vector;
        int num;
        Transform transform;
        Transform transform2;
        Transform transform3;
        Vector3 vector2;
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
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y + 3f, &base.transform.position.z + 1f);
        num = 0;
        goto Label_02C4;
    Label_0056:
        if (num != null)
        {
            goto Label_0126;
        }
        transform = UnityEngine.Object.Instantiate(this.ilusionPrefab, vector, Quaternion.identity) as Transform;
        transform.GetComponent<SoldierMageIllusion>().Init(base.transform.position, new Vector2(&base.transform.position.x, &base.transform.position.y + 42f), 40, 0, new Vector2(&base.transform.position.x, &base.transform.position.y + 42f), this.mirageLevel, num);
        this.illusionList.Add(transform.GetComponent<SoldierMageIllusion>());
        transform.localScale = base.transform.localScale;
        goto Label_02C0;
    Label_0126:
        if (num != 1)
        {
            goto Label_01F7;
        }
        transform2 = UnityEngine.Object.Instantiate(this.ilusionPrefab, vector, Quaternion.identity) as Transform;
        transform2.GetComponent<SoldierMageIllusion>().Init(base.transform.position, new Vector2(&base.transform.position.x, &base.transform.position.y - 42f), 40, 0, new Vector2(&base.transform.position.x, &base.transform.position.y - 42f), this.mirageLevel, num);
        this.illusionList.Add(transform2.GetComponent<SoldierMageIllusion>());
        transform2.localScale = base.transform.localScale;
        goto Label_02C0;
    Label_01F7:
        transform3 = UnityEngine.Object.Instantiate(this.ilusionPrefab, vector, Quaternion.identity) as Transform;
        transform3.GetComponent<SoldierMageIllusion>().Init(base.transform.position, new Vector2(&base.transform.position.x + 42f, &base.transform.position.y), 40, 0, new Vector2(&base.transform.position.x + 42f, &base.transform.position.y), this.mirageLevel, num);
        this.illusionList.Add(transform3.GetComponent<SoldierMageIllusion>());
        transform3.localScale = base.transform.localScale;
    Label_02C0:
        num += 1;
    Label_02C4:
        if (num < this.mirageLevel)
        {
            goto Label_0056;
        }
        return;
    }

    protected void DoTeleporth()
    {
        this.StopSpecial();
        this.isTeleporting = 1;
        base.sprite.PlayAnim("teleportStart");
        this.teleportStart = 1;
        return;
    }

    protected unsafe void DoTeleporthIn()
    {
        Vector3 vector;
        this.teleportStart = 0;
        this.teleportIn = 1;
        base.transform.position = new Vector3(&this.teleporthPosition.x, &this.teleporthPosition.y + base.yAdjust, &base.transform.position.z);
        base.sprite.PlayAnim("teleport");
        return;
    }

    protected unsafe void DoThunder()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.thunderPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -1f), Quaternion.identity) as Transform;
        this.thunderController = transform.GetComponent<ThunderController>();
        this.thunderController.Init(this.thunderPoint, this.thunderLevel);
        this.thunderController.SetStage(base.stage);
        return;
    }

    protected bool EvalMirage()
    {
        if (this.isThunder != null)
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
        if (this.isMirage != null)
        {
            goto Label_0092;
        }
        if (this.mirageReloadTimeCounter >= this.mirageReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanMirage() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        this.isMirage = 1;
        this.mirageChargeTimeCounter = 0;
        this.mirageReloadTimeCounter = 0;
        base.sprite.PlayAnim("mirageIn");
        GameSoundManager.PlayHeroMageShadows();
        base.GainXpByAbilityModifier(1, this.mirageLevel);
        return 1;
    Label_0092:
        if (this.mirageChargeTimeCounter >= this.mirageChargeTime)
        {
            goto Label_00C5;
        }
        this.mirageChargeTimeCounter += 1;
        if (this.mirageChargeTimeCounter != 3)
        {
            goto Label_00C3;
        }
        this.DoMirage();
    Label_00C3:
        return 1;
    Label_00C5:
        this.isMirage = 0;
        this.mirageReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalRangeShoot()
    {
        int num;
        Transform transform;
        Bolt bolt;
        Vector3 vector;
        Vector3 vector2;
        if (this.isMirage != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (this.isThunder != null)
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
            goto Label_00EE;
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
            goto Label_00AF;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00CE;
    Label_00AF:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00CE:
        this.isRangeShooting = 1;
        this.rangeShootChargeTimeCounter = 0;
        base.sprite.PlayAnim("shoot");
        return 1;
    Label_00EE:
        if (this.rangeShootChargeTimeCounter >= this.rangeShootChargeTime)
        {
            goto Label_01B1;
        }
        this.rangeShootChargeTimeCounter += 1;
        if (this.rangeShootChargeTimeCounter != 14)
        {
            goto Label_01AF;
        }
        num = this.GetDamageRangeShoot();
        transform = UnityEngine.Object.Instantiate(this.boltPrefab, base.transform.position + new Vector3(0f, 24f, 0f), Quaternion.identity) as Transform;
        base.stage.AddProjectile(transform);
        bolt = transform.GetComponent<Bolt>();
        bolt.SetTarget(this.rangeShootTarget, &this.rangeShootPoint.x, &this.rangeShootPoint.y);
        bolt.SetDamage(num);
        bolt.SetStage(base.stage);
        GameSoundManager.PlayBoltSound();
        base.GainXpByDamage(num);
    Label_01AF:
        return 1;
    Label_01B1:
        this.isRangeShooting = 0;
        return 0;
    }

    protected unsafe bool EvalThunder()
    {
        Vector3 vector;
        if (this.isMirage != null)
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
        if (this.isThunder != null)
        {
            goto Label_00F8;
        }
        if (this.thunderReloadTimeCounter >= this.thunderReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanThunder() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        if (&this.thunderPoint.x < &base.transform.position.x)
        {
            goto Label_00A0;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00BF;
    Label_00A0:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00BF:
        this.isThunder = 1;
        this.thunderChargeTimeCounter = 0;
        this.thunderReloadTimeCounter = 0;
        base.sprite.PlayAnim("thunder");
        GameSoundManager.PlayHeroMageRainCharge();
        base.GainXpByAbilityModifier(2, this.thunderLevel);
        return 1;
    Label_00F8:
        if (this.thunderChargeTimeCounter >= this.thunderChargeTime)
        {
            goto Label_012C;
        }
        this.thunderChargeTimeCounter += 1;
        if (this.thunderChargeTimeCounter != 15)
        {
            goto Label_012A;
        }
        this.DoThunder();
    Label_012A:
        return 1;
    Label_012C:
        this.isThunder = 0;
        this.thunderReloadTimeCounter = 0;
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
            goto Label_00D7;
        }
        this.rangeShootTarget = creep;
        this.rangeShootPoint = new Vector2(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y + creep.yAdjust);
        return 1;
    Label_00D7:
        return 0;
    }

    protected int GetDamageRangeShoot()
    {
        return UnityEngine.Random.Range(base.rangeShootMinDamage, base.rangeShootMaxDamage + 1);
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_mage", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_mage", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_mage", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_mage", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_mage", "maxDamage", base.level);
        base.rangeShootMinDamage = (int) GameSettings.GetHeroSetting("hero_mage", "minRangeDamage", base.level);
        base.rangeShootMaxDamage = (int) GameSettings.GetHeroSetting("hero_mage", "maxRangeDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeThunder();
        this.UpgradeMirage();
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

    protected unsafe bool MinThunderDistance(Creep myEnemy)
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.thunderMinDistance))
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

    protected bool OnRangeThunder(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.thunderRangeHeight, (float) this.thunderRangeWidth, base.transform.position);
    }

    public override void Pause()
    {
        bool[] flagArray;
        int num;
        SoldierMageIllusion illusion;
        IEnumerator enumerator;
        bool flag;
        bool[] flagArray2;
        int num2;
        IDisposable disposable;
        base.Pause();
        if ((this.thunderController != null) == null)
        {
            goto Label_0022;
        }
        this.thunderController.Pause();
    Label_0022:
        flagArray = new bool[this.illusionList.Count];
        num = 0;
        enumerator = this.illusionList.GetEnumerator();
    Label_0041:
        try
        {
            goto Label_0071;
        Label_0046:
            illusion = (SoldierMageIllusion) enumerator.Current;
            if ((illusion != null) == null)
            {
                goto Label_0069;
            }
            illusion.Pause();
            goto Label_006D;
        Label_0069:
            flagArray[num] = 1;
        Label_006D:
            num += 1;
        Label_0071:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0046;
            }
            goto Label_0096;
        }
        finally
        {
        Label_0081:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_008E;
            }
        Label_008E:
            disposable.Dispose();
        }
    Label_0096:
        num = 0;
        flagArray2 = flagArray;
        num2 = 0;
        goto Label_00CC;
    Label_00A3:
        if (flagArray2[num2] == null)
        {
            goto Label_00C2;
        }
        this.illusionList.Remove((int) num);
    Label_00C2:
        num += 1;
        num2 += 1;
    Label_00CC:
        if (num2 < ((int) flagArray2.Length))
        {
            goto Label_00A3;
        }
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroMageDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroMageTauntIntro();
        return;
    }

    protected override bool RunSpecial()
    {
        this.rangeShootReloadTimeCounter += 1;
        this.mirageReloadTimeCounter += 1;
        this.thunderReloadTimeCounter += 1;
        if (this.isTeleporting == null)
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        if (base.RunSpecial() == null)
        {
            goto Label_0044;
        }
        return 1;
    Label_0044:
        if (this.EvalRangeShoot() == null)
        {
            goto Label_0051;
        }
        return 1;
    Label_0051:
        if (this.mirageLevel == null)
        {
            goto Label_0069;
        }
        if (this.EvalMirage() == null)
        {
            goto Label_0069;
        }
        return 1;
    Label_0069:
        if (this.thunderLevel == null)
        {
            goto Label_0081;
        }
        if (this.EvalThunder() == null)
        {
            goto Label_0081;
        }
        return 1;
    Label_0081:
        return 0;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isMirage = 0;
        this.isThunder = 0;
        this.isRangeShooting = 0;
        base.isCharging = 0;
        base.isLevelUp = 0;
        return;
    }

    protected void TeleporthEnd()
    {
        this.teleportIn = 0;
        this.isTeleporting = 0;
        this.teleporthChargeTimeCounter = 0;
        return;
    }

    public override void Unpause()
    {
        SoldierMageIllusion illusion;
        IEnumerator enumerator;
        IDisposable disposable;
        base.Unpause();
        if ((this.thunderController != null) == null)
        {
            goto Label_0022;
        }
        this.thunderController.Unpause();
    Label_0022:
        enumerator = this.illusionList.GetEnumerator();
    Label_002E:
        try
        {
            goto Label_0045;
        Label_0033:
            illusion = (SoldierMageIllusion) enumerator.Current;
            illusion.Unpause();
        Label_0045:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0033;
            }
            goto Label_0067;
        }
        finally
        {
        Label_0055:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0060;
            }
        Label_0060:
            disposable.Dispose();
        }
    Label_0067:
        return;
    }

    protected void UpgradeMirage()
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
        this.mirageLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.mirageLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.mirageLevel = 3;
    Label_0068:
        this.mirageReloadTime = ((int) GameSettings.GetHeroSetting("hero_mage", "mirageReloadTime", 1)) * 30;
        return;
    }

    protected void UpgradeThunder()
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
        this.thunderLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.thunderLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.thunderLevel = 3;
    Label_006A:
        this.thunderReloadTime = ((int) GameSettings.GetHeroSetting("hero_mage", "thunderReloadTime", 1)) * 30;
        this.thunderMinDistance = (int) GameSettings.GetHeroSetting("hero_mage", "thunderMinDistance", 1);
        this.thunderRangeWidth = (int) GameSettings.GetHeroSetting("hero_mage", "thunderShootRangeWidth", 1);
        this.thunderRangeHeight = Mathf.RoundToInt(((float) this.thunderRangeWidth) * 0.7f);
        return;
    }
}

