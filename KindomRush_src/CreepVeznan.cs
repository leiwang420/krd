using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepVeznan : Creep
{
    protected int areaAttackAnimation;
    protected PackedSprite currentTaunt;
    public Transform curseBigPrefab;
    protected Transform demonFire;
    public Transform demonFirePrefab;
    protected int downstairsTime;
    protected int downstairsTimeCounter;
    private EndGame endGame;
    protected int goingDemonAnimationTime;
    protected int goingDemonAnimationTimeCounter;
    protected int goingVeznanAnimationTime;
    protected int goingVeznanAnimationTimeCounter;
    public Transform healingBigPrefab;
    protected int holdAnimationTime;
    protected int holdAnimationTimeCounter;
    protected int holdReloadTime;
    protected int holdReloadTimeCounter;
    protected int[][] holdTimers;
    protected bool isDemon;
    protected bool isDownstairs;
    protected bool isGoingDemon;
    protected bool isGoingVeznan;
    protected bool isHold;
    protected bool isLocked;
    protected bool isPortal;
    protected bool isStarting;
    protected bool isTaunt;
    protected bool isTsung;
    protected bool isWatching;
    public Transform lifeBarDemon;
    private AudioSource musicBattle;
    private AudioSource musicBoss;
    public Transform poisonBigPrefab;
    private Transform portal1;
    private Transform portal2;
    private Transform portal3;
    protected int portalAnimationTime;
    protected int portalAnimationTimeCounter;
    protected int portalCurrent;
    protected int portalMax;
    protected Vector3 portalPositionOne;
    protected Vector3 portalPositionThree;
    protected Vector3 portalPositionTwo;
    public Transform portalPrefab;
    protected int portalReloadTime;
    protected int portalReloadTimeCounter;
    protected int[][] portalTimers;
    protected int rndCanTauntTime;
    protected int rndCanTauntTimeCounter;
    protected int rndTauntAnimationTime;
    protected int rndTauntAnimationTimeCounter;
    protected int rndTauntReloadTime;
    protected int rndTauntReloadTimeCounter;
    public Transform smokeBigPrefab;
    protected int startTime;
    protected int startTimeCounter;
    public Transform teslaHitBigPrefab;
    protected int tsungChargeLoopTime;
    protected int tsungChargeLoopTimeCounter;
    protected int tsungChargeTime;
    protected int tsungChargeTimeCounter;
    protected int tsungMaxEnemies;
    protected int tsungMinRange;
    protected int tsungRangeHeight;
    protected int tsungRangeWidth;
    protected int tsungReloadTime;
    protected int tsungReloadTimeCounter;
    public Transform unHolyStrikePrefab;
    protected bool wasDemon;
    public float yLifebarDemonOffset;

    public CreepVeznan()
    {
        base..ctor();
        return;
    }

    protected void AdjustPositionTimed()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, 30f, 0f);
        return;
    }

    protected override void Attack()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        base.areaAttackPoint = this.GetAttackPoint();
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0021:
        try
        {
            goto Label_0077;
        Label_0026:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_0077;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_0077;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0077;
            }
            soldier.SetDamage(base.GetDamage(), 0);
            num += 1;
            if (num != base.areaAttackMax)
            {
                goto Label_0077;
            }
            goto Label_0082;
        Label_0077:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0026;
            }
        Label_0082:
            goto Label_009C;
        }
        finally
        {
        Label_0087:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0094;
            }
        Label_0094:
            disposable.Dispose();
        }
    Label_009C:
        return;
    }

    protected void AttackDemon()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0015:
        try
        {
            goto Label_005F;
        Label_001A:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_005F;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_005F;
            }
            soldier.SetDamage(base.GetDamage(), 0);
            num += 1;
            if (num != base.areaAttackMax)
            {
                goto Label_005F;
            }
            goto Label_006A;
        Label_005F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
        Label_006A:
            goto Label_0084;
        }
        finally
        {
        Label_006F:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007C;
            }
        Label_007C:
            disposable.Dispose();
        }
    Label_0084:
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        if (this.isHold != null)
        {
            goto Label_004B;
        }
        if (this.isPortal != null)
        {
            goto Label_004B;
        }
        if (this.isGoingVeznan != null)
        {
            goto Label_004B;
        }
        if (this.isGoingDemon != null)
        {
            goto Label_004B;
        }
        if (this.isTsung != null)
        {
            goto Label_004B;
        }
        this.RevertToStatic();
    Label_004B:
        return;
    }

    protected void BlockRandomTower(ArrayList tmpTowers, int index)
    {
        int num;
        num = UnityEngine.Random.Range(0, index);
        ((TowerBase) tmpTowers[num]).VeznanBlockTower();
        tmpTowers.RemoveAt(num);
        return;
    }

    protected bool CanTaunt()
    {
        if (this.isWatching != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isWatching == null)
        {
            goto Label_0025;
        }
        if (this.isDownstairs == null)
        {
            goto Label_0025;
        }
        return 0;
    Label_0025:
        if (base.isBlocked == null)
        {
            goto Label_0032;
        }
        return 0;
    Label_0032:
        if (this.rndCanTauntTimeCounter >= this.rndCanTauntTime)
        {
            goto Label_0045;
        }
        return 0;
    Label_0045:
        return 1;
    }

    public override void ChargeAttack()
    {
        if (this.isDemon == null)
        {
            goto Label_0025;
        }
        GameSoundManager.PlayVeznanDemonFire();
        base.creepSprite.PlayAnim("attackDemon");
        goto Label_0035;
    Label_0025:
        base.creepSprite.PlayAnim("attack");
    Label_0035:
        base.isCharging = 1;
        return;
    }

    public override unsafe void CheckFacing()
    {
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        double num;
        Vector3 vector4;
        Vector3 vector5;
        vector = ((base.currentNode + 1) >= ((int) base.path[base.pathIndex][base.subpathIndex].Length)) ? *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode])) : *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode + 1]));
        &vector2 = new Vector2(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y);
        vector3 = vector - vector2;
        &vector3.Normalize();
        num = ((double) (Mathf.Atan2(&vector3.y, &vector3.x) * 180f)) / 3.14;
        if (num >= 0.0)
        {
            goto Label_00FD;
        }
        num += 360.0;
    Label_00FD:
        if (num <= 55.0)
        {
            goto Label_0139;
        }
        if (num >= 135.0)
        {
            goto Label_0139;
        }
        if (base.facing == 1)
        {
            goto Label_0211;
        }
        base.facing = 1;
        this.WalkUpAnimation();
        goto Label_0211;
    Label_0139:
        if (num < 135.0)
        {
            goto Label_0199;
        }
        if (num > 240.0)
        {
            goto Label_0199;
        }
        if (base.facing == 2)
        {
            goto Label_0211;
        }
        base.facing = 2;
        this.WalkAnimation();
        base.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0211;
    Label_0199:
        if (num <= 240.0)
        {
            goto Label_01D4;
        }
        if (num >= 315.0)
        {
            goto Label_01D4;
        }
        if (base.facing == null)
        {
            goto Label_0211;
        }
        base.facing = 0;
        this.WalkDownAnimation();
        goto Label_0211;
    Label_01D4:
        if (base.facing == 3)
        {
            goto Label_0211;
        }
        base.facing = 3;
        this.WalkAnimation();
        base.creepSprite.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_0211:
        return;
    }

    protected void CheckRndTaunt()
    {
        if (base.stage.GetCurrentWaveNumber() != null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        if (this.isWatching != null)
        {
            goto Label_001D;
        }
        return;
    Label_001D:
        if (this.isStarting != null)
        {
            goto Label_0033;
        }
        if (this.isDownstairs == null)
        {
            goto Label_0034;
        }
    Label_0033:
        return;
    Label_0034:
        if (this.isLocked != null)
        {
            goto Label_004A;
        }
        if (this.isTaunt == null)
        {
            goto Label_004B;
        }
    Label_004A:
        return;
    Label_004B:
        if (this.rndTauntReloadTimeCounter >= this.rndTauntReloadTime)
        {
            goto Label_005D;
        }
        return;
    Label_005D:
        if (this.rndCanTauntTimeCounter >= this.rndCanTauntTime)
        {
            goto Label_006F;
        }
        return;
    Label_006F:
        this.DoTaunt(UnityEngine.Random.Range(5, 0x1a), 1);
        return;
    }

    protected void CreatePortals()
    {
        this.portalCurrent += 1;
        GameSoundManager.PlayVeznanPortalSummon();
        if (this.portalTimers[base.stage.GetCurrentWaveNumber() - 1][1] != 1)
        {
            goto Label_0040;
        }
        this.portal1.gameObject.AddComponent<PortalOne>();
    Label_0040:
        if (this.portalTimers[base.stage.GetCurrentWaveNumber() - 1][2] != 1)
        {
            goto Label_006D;
        }
        this.portal2.gameObject.AddComponent<PortalTwo>();
    Label_006D:
        if (this.portalTimers[base.stage.GetCurrentWaveNumber() - 1][3] != 1)
        {
            goto Label_009A;
        }
        this.portal3.gameObject.AddComponent<PortalThree>();
    Label_009A:
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if (damageType == null)
        {
            goto Label_0021;
        }
        base.life -= this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002F;
    Label_0021:
        base.life -= dmg;
    Label_002F:
        if (base.life > 0)
        {
            goto Label_014E;
        }
        base.life = 0;
        if (this.isDemon != null)
        {
            goto Label_007F;
        }
        if (this.wasDemon == null)
        {
            goto Label_0074;
        }
        this.Die();
        GameAchievements.KillEnemy();
        GameAchievements.DefeatEndBoss();
        base.isDead = 0;
        goto Label_007A;
    Label_0074:
        this.GoToDemon();
    Label_007A:
        goto Label_014D;
    Label_007F:
        if (base.creepSprite.IsAnimating() == null)
        {
            goto Label_00AF;
        }
        if ((base.creepSprite.GetCurAnim().name == "death") == null)
        {
            goto Label_00AF;
        }
        return;
    Label_00AF:
        if ((this.demonFire != null) == null)
        {
            goto Label_00C7;
        }
        this.demonFire = null;
    Label_00C7:
        enumerator = base.transform.GetEnumerator();
    Label_00D3:
        try
        {
            goto Label_0119;
        Label_00D8:
            transform = (Transform) enumerator.Current;
            if ((transform.name != "Effect") == null)
            {
                goto Label_0119;
            }
            if ((transform.name != "Explosion") == null)
            {
                goto Label_0119;
            }
            UnityEngine.Object.Destroy(transform.gameObject);
        Label_0119:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00D8;
            }
            goto Label_013B;
        }
        finally
        {
        Label_0129:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0134;
            }
        Label_0134:
            disposable.Dispose();
        }
    Label_013B:
        GameAchievements.DefeatEndBoss();
        this.Die();
        base.isDead = 0;
    Label_014D:
        return;
    Label_014E:
        return;
    }

    protected void DoTaunt(int tauntId, bool isRandom)
    {
        this.isTaunt = 1;
        base.isBlocked = 1;
        this.rndTauntAnimationTimeCounter = 0;
        base.creepSprite.PlayAnim("laugh");
        this.currentTaunt.Hide(0);
        this.currentTaunt.PlayAnim(tauntId);
        return;
    }

    protected void FireDamageTaunt()
    {
        if (this.CanTaunt() == null)
        {
            goto Label_001B;
        }
        this.DoTaunt(UnityEngine.Random.Range(0x19, 30), 0);
    Label_001B:
        return;
    }

    protected void FireWaveTaunt()
    {
        int num;
        if (this.CanTaunt() == null)
        {
            goto Label_0030;
        }
        if (base.stage.GetCurrentWaveNumber() == 1)
        {
            goto Label_0023;
        }
        goto Label_0030;
    Label_0023:
        this.DoTaunt(4, 0);
    Label_0030:
        return;
    }

    protected override unsafe void FixedUpdate()
    {
        object[] objArray1;
        PackedSprite sprite;
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.isFading == null)
        {
            goto Label_01A9;
        }
        if (base.fadingTimeCounter != null)
        {
            goto Label_0048;
        }
        this.musicBattle.Stop();
        this.musicBoss.Stop();
        GameSoundManager.PlayVeznanDeath();
        base.stage.HideGUI();
    Label_0048:
        base.fadingTimeCounter += 1;
        if (base.fadingTimeCounter != 110)
        {
            goto Label_006F;
        }
        base.GetComponent<VeznanSoulController>().enabled = 1;
    Label_006F:
        if (base.fadingTimeCounter != 150)
        {
            goto Label_008F;
        }
        base.creepSprite.PlayAnim("deadEnd");
    Label_008F:
        if (base.fadingTimeCounter != 0xfe)
        {
            goto Label_00C3;
        }
        sprite = base.transform.FindChild("Effect").GetComponent<PackedSprite>();
        sprite.Hide(0);
        sprite.PlayAnim(0);
    Label_00C3:
        if (base.fadingTimeCounter != 300)
        {
            goto Label_0171;
        }
        transform = base.transform.FindChild("Explosion");
        transform.position = new Vector3(&transform.position.x, &transform.position.y, -919f);
        transform.GetComponent<PackedSprite>().Hide(0);
        objArray1 = new object[] { "x", (float) 15f, "y", (float) 15f, "time", (float) 1f };
        iTween.ScaleTo(transform.gameObject, iTween.Hash(objArray1));
    Label_0171:
        if (base.fadingTimeCounter != 0x13b)
        {
            goto Label_0197;
        }
        this.endGame.Launch();
        base.stage.DisableHero();
    Label_0197:
        if (base.fadingTimeCounter < base.fadingTime)
        {
            goto Label_01A8;
        }
    Label_01A8:
        return;
    Label_01A9:
        base.UpdateLifeBar();
        if (base.life > 0)
        {
            goto Label_01E5;
        }
        GameAchievements.KillEnemy();
        GameAchievements.DefeatEndBoss();
        base.active = 0;
        base.HidePoison();
        base.HideCurse();
        base.HideTeslaHit();
        this.Die();
        return;
    Label_01E5:
        if (base.EvalThorns() == null)
        {
            goto Label_01F1;
        }
        return;
    Label_01F1:
        if (this.isWatching != null)
        {
            goto Label_0212;
        }
        if (base.active == null)
        {
            goto Label_021E;
        }
        if (base.isCharging != null)
        {
            goto Label_021E;
        }
    Label_0212:
        if (this.SpecialPower() == null)
        {
            goto Label_021E;
        }
        return;
    Label_021E:
        if (base.isBlocked == null)
        {
            goto Label_026B;
        }
        if (base.isCharging != null)
        {
            goto Label_026B;
        }
        if ((base.soldier == null) != null)
        {
            goto Label_0265;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_0265;
        }
        if (base.soldier.IsFighting() != null)
        {
            goto Label_026B;
        }
    Label_0265:
        this.StopFighting();
    Label_026B:
        if (base.isFighting == null)
        {
            goto Label_02DE;
        }
        if (base.isCharging == null)
        {
            goto Label_02D2;
        }
        if (this.ReadyToDamage() != null)
        {
            goto Label_028D;
        }
        return;
    Label_028D:
        if (base.isDead == null)
        {
            goto Label_0299;
        }
        return;
    Label_0299:
        base.isCharging = 0;
        this.RevertToStatic();
        if ((base.soldier != null) == null)
        {
            goto Label_02E4;
        }
        if (base.soldier.IsDead() == null)
        {
            goto Label_02E4;
        }
        this.StopFighting();
        goto Label_02D9;
    Label_02D2:
        base.ReadyToAttack();
    Label_02D9:
        goto Label_02E4;
    Label_02DE:
        base.Move();
    Label_02E4:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_0326;
        }
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0345;
    Label_0326:
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_0345:
        return;
    }

    protected unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_005B;
        }
        return new Vector2(&base.transform.position.x + 56f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 56f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected void GoToDemon()
    {
        int num;
        base.GetComponent<BoxCollider>().size = new Vector3(120f, 160f, 0f);
        base.life = base.totalLife = 0x1a0a;
        base.speed = 1.08f;
        base.attackChargeTime = 0x35;
        base.attackChargeTimeCounter = 0;
        this.areaAttackAnimation = 0x13;
        base.attackReloadTime = 0x4b - base.attackChargeTime;
        base.yAdjust = 56f;
        base.xModifierAdjust = 0f;
        base.yModifierAdjust = -20f;
        base.xSoldierAdjust = 70f;
        base.ySoldierAdjust = -40f;
        base.anchorPoint -= new Vector3(0f, 30f, 0f);
        base.Invoke("AdjustPositionTimed", 0.35f);
        base.currentNode += 3;
        this.isTsung = 0;
        this.isHold = 0;
        this.isPortal = 0;
        this.isLocked = 0;
        this.isDemon = 1;
        base.isCharging = 0;
        UnityEngine.Object.Destroy(base.mainBar.gameObject);
        this.StopSpecialPower();
        this.isGoingDemon = 1;
        this.goingDemonAnimationTimeCounter = 0;
        base.creepSprite.PlayAnim("toDemon");
        GameSoundManager.PlayVeznanToDemon();
        if ((base.GetComponent<EnemyModifierCurse>() != null) == null)
        {
            goto Label_015D;
        }
        UnityEngine.Object.Destroy(base.GetComponent<EnemyModifierCurse>());
    Label_015D:
        this.SwitchEffects();
        return;
    }

    protected void GotoVeznan()
    {
        base.life = 100;
        base.totalLife = 0x1a0a;
        base.speed = 0.56f;
        base.attackChargeTime = 0x22;
        base.attackChargeTimeCounter = 0;
        this.areaAttackAnimation = 0x10;
        base.attackReloadTime = 60 - base.attackChargeTime;
        base.yAdjust = 5f;
        base.xModifierAdjust = 150f;
        base.yModifierAdjust = 63f;
        base.xSoldierAdjust = 28f;
        this.isTsung = 0;
        this.isHold = 0;
        this.isPortal = 0;
        this.isLocked = 0;
        base.isCharging = 0;
        UnityEngine.Object.Destroy(base.mainBar.gameObject);
        this.StopSpecialPower();
        this.isGoingVeznan = 1;
        this.goingVeznanAnimationTimeCounter = 0;
        base.creepSprite.PlayAnim("toVeznan");
        return;
    }

    protected void HoldTowers()
    {
        int num;
        TowerBase[] baseArray;
        ArrayList list;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num2;
        int num3;
        TowerBase base3;
        IEnumerator enumerator;
        int num4;
        IDisposable disposable;
        num = 0;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        list = new ArrayList();
        baseArray2 = baseArray;
        num2 = 0;
        goto Label_0047;
    Label_0028:
        base2 = baseArray2[num2];
        if (base2.IsActive() == null)
        {
            goto Label_0041;
        }
        list.Add(base2);
    Label_0041:
        num2 += 1;
    Label_0047:
        if (num2 < ((int) baseArray2.Length))
        {
            goto Label_0028;
        }
        num = list.Count;
        if (num != null)
        {
            goto Label_0060;
        }
        return;
    Label_0060:
        GameSoundManager.PlayVeznanHoldCast();
        num3 = this.holdTimers[base.stage.GetCurrentWaveNumber() - 1][1];
        if (num >= num3)
        {
            goto Label_00DF;
        }
        enumerator = list.GetEnumerator();
    Label_008D:
        try
        {
            goto Label_00B3;
        Label_0092:
            base3 = (TowerBase) enumerator.Current;
            if (base3.IsActive() == null)
            {
                goto Label_00B3;
            }
            base3.VeznanBlockTower();
        Label_00B3:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0092;
            }
            goto Label_00DA;
        }
        finally
        {
        Label_00C4:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00D2;
            }
        Label_00D2:
            disposable.Dispose();
        }
    Label_00DA:
        goto Label_0102;
    Label_00DF:
        num4 = 0;
        goto Label_00F9;
    Label_00E7:
        this.BlockRandomTower(list, num);
        num -= 1;
        num4 += 1;
    Label_00F9:
        if (num4 < num3)
        {
            goto Label_00E7;
        }
    Label_0102:
        return;
    }

    protected override void InitCustomSettings()
    {
        int[] numArray22;
        int[] numArray21;
        int[] numArray20;
        int[] numArray19;
        int[] numArray18;
        int[] numArray17;
        int[] numArray16;
        int[] numArray15;
        int[] numArray14;
        int[] numArray13;
        int[] numArray12;
        int[] numArray11;
        int[] numArray10;
        int[] numArray9;
        int[] numArray8;
        int[] numArray7;
        int[] numArray6;
        int[][] numArrayArray2;
        int[] numArray5;
        int[] numArray4;
        int[] numArray3;
        int[] numArray2;
        int[] numArray1;
        int[][] numArrayArray1;
        this.endGame = GameObject.Find("EndGame").GetComponent<EndGame>();
        this.musicBattle = GameObject.Find("Music Battle").GetComponent<AudioSource>();
        this.musicBoss = GameObject.Find("Music Boss").GetComponent<AudioSource>();
        this.isStarting = 1;
        base.creepSprite.PlayAnim("idleDown");
        this.currentTaunt = GameObject.Find("Taunt").GetComponent<PackedSprite>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.path = base.stage.GetPath();
        this.isWatching = 1;
        base.active = 0;
        base.canBePoisoned = 1;
        base.fadingTime = 340;
        base.attackChargeTime = 0x25;
        this.areaAttackAnimation = 0x11;
        base.roadNodesTillActive = 12;
        base.mainBar.gameObject.SetActive(0);
        GameData.notificationEnemyVeznan = 1;
        this.portal1 = GameObject.Find("Portal1").GetComponent<Transform>();
        this.portal2 = GameObject.Find("Portal2").GetComponent<Transform>();
        this.portal3 = GameObject.Find("Portal3").GetComponent<Transform>();
        numArrayArray1 = new int[0x10][];
        numArrayArray1[0] = new int[5];
        numArrayArray1[1] = new int[5];
        numArrayArray1[2] = new int[5];
        numArrayArray1[3] = new int[5];
        numArrayArray1[4] = new int[5];
        numArray1 = new int[5];
        numArray1[0] = 15;
        numArray1[1] = 1;
        numArray1[4] = 3;
        numArrayArray1[5] = numArray1;
        numArray2 = new int[5];
        numArray2[0] = 10;
        numArray2[1] = 1;
        numArray2[4] = 2;
        numArrayArray1[6] = numArray2;
        numArray3 = new int[5];
        numArray3[0] = 20;
        numArray3[2] = 1;
        numArray3[4] = 3;
        numArrayArray1[7] = numArray3;
        numArray4 = new int[5];
        numArray4[0] = 15;
        numArray4[1] = 1;
        numArray4[4] = 3;
        numArrayArray1[8] = numArray4;
        numArrayArray1[9] = new int[] { 20, 1, 1, 0, 3 };
        numArrayArray1[10] = new int[] { 15, 1, 1, 0, 3 };
        numArrayArray1[11] = new int[] { 15, 1, 1, 0, 3 };
        numArray5 = new int[5];
        numArray5[0] = 15;
        numArray5[3] = 1;
        numArray5[4] = 3;
        numArrayArray1[12] = numArray5;
        numArrayArray1[13] = new int[] { 15, 1, 1, 1, 3 };
        numArrayArray1[14] = new int[] { 15, 1, 1, 1, 3 };
        numArrayArray1[15] = new int[] { 15, 1, 1, 1, 3 };
        this.portalTimers = numArrayArray1;
        numArrayArray2 = new int[0x11][];
        numArray6 = new int[2];
        numArray6[1] = 3;
        numArrayArray2[0] = numArray6;
        numArray7 = new int[2];
        numArray7[1] = 3;
        numArrayArray2[1] = numArray7;
        numArray8 = new int[2];
        numArray8[1] = 3;
        numArrayArray2[2] = numArray8;
        numArray9 = new int[2];
        numArray9[1] = 3;
        numArrayArray2[3] = numArray9;
        numArray10 = new int[2];
        numArray10[1] = 2;
        numArrayArray2[4] = numArray10;
        numArray11 = new int[2];
        numArray11[1] = 2;
        numArrayArray2[5] = numArray11;
        numArray12 = new int[2];
        numArray12[1] = 2;
        numArrayArray2[6] = numArray12;
        numArray13 = new int[2];
        numArray13[1] = 2;
        numArrayArray2[7] = numArray13;
        numArray14 = new int[] { 13, 2 };
        numArrayArray2[8] = numArray14;
        numArray15 = new int[] { 13, 3 };
        numArrayArray2[9] = numArray15;
        numArray16 = new int[] { 14, 4 };
        numArrayArray2[10] = numArray16;
        numArray17 = new int[] { 14, 5 };
        numArrayArray2[11] = numArray17;
        numArray18 = new int[] { 0x10, 6 };
        numArrayArray2[12] = numArray18;
        numArray19 = new int[] { 0x10, 7 };
        numArrayArray2[13] = numArray19;
        numArray20 = new int[] { 0x12, 8 };
        numArrayArray2[14] = numArray20;
        numArray21 = new int[] { 0x12, 8 };
        numArrayArray2[15] = numArray21;
        numArray22 = new int[] { 0x12, 8 };
        numArrayArray2[0x10] = numArray22;
        this.holdTimers = numArrayArray2;
        base.areaAttackRangeWidth = 0xd4;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        base.areaAttackMax = 8;
        this.tsungReloadTime = 150;
        this.tsungRangeWidth = 410;
        this.tsungRangeHeight = Mathf.RoundToInt(((float) this.tsungRangeWidth) * 0.7f);
        this.tsungMaxEnemies = 5;
        this.tsungMinRange = 0x63;
        base.fadingTimeCounter = 0;
        this.startTime = 0x3e8;
        this.portalAnimationTime = 0x2c;
        this.holdAnimationTime = 0x2c;
        this.goingDemonAnimationTime = 0x22;
        this.goingVeznanAnimationTime = 0x13;
        this.tsungChargeLoopTime = 12;
        this.tsungChargeTime = 0x19;
        this.downstairsTime = 140;
        this.rndTauntAnimationTime = 120;
        this.rndTauntReloadTime = 400;
        this.rndCanTauntTime = 300;
        return;
    }

    public override bool IsDead()
    {
        return ((base.life > 0) ? 0 : (base.isDead == 1));
    }

    public bool IsDemon()
    {
        return this.isDemon;
    }

    public bool IsWatching()
    {
        return this.isWatching;
    }

    protected bool OnRange(Soldier mySoldier)
    {
        if ((mySoldier == null) == null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, base.areaAttackPoint);
    }

    public override void Pause()
    {
        PortalOne one;
        PortalTwo two;
        PortalThree three;
        base.Pause();
        one = base.GetComponent<PortalOne>();
        two = base.GetComponent<PortalTwo>();
        three = base.GetComponent<PortalThree>();
        if ((one != null) == null)
        {
            goto Label_002D;
        }
        one.Pause();
    Label_002D:
        if ((two != null) == null)
        {
            goto Label_003F;
        }
        two.Pause();
    Label_003F:
        if ((three != null) == null)
        {
            goto Label_0051;
        }
        three.Pause();
    Label_0051:
        return;
    }

    protected override unsafe bool ReadyToDamage()
    {
        Vector3 vector;
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
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter < base.attackChargeTime)
        {
            goto Label_002F;
        }
        base.attackChargeTimeCounter = 0;
        this.demonFire = null;
        return 1;
    Label_002F:
        if (base.attackChargeTimeCounter != this.areaAttackAnimation)
        {
            goto Label_01EF;
        }
        base.areaAttackPoint = this.GetAttackPoint();
        if (this.isDemon == null)
        {
            goto Label_019B;
        }
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_0107;
        }
        &vector = new Vector3(&base.transform.position.x + 82f, &base.transform.position.y - 60f, -890f);
        this.demonFire = UnityEngine.Object.Instantiate(this.demonFirePrefab, vector, Quaternion.identity) as Transform;
        this.demonFire.transform.localScale = new Vector3(&base.transform.localScale.x, 1f, 1f);
        goto Label_0196;
    Label_0107:
        &vector2 = new Vector3(&base.transform.position.x - 82f, &base.transform.position.y - 60f, -890f);
        this.demonFire = UnityEngine.Object.Instantiate(this.demonFirePrefab, vector2, Quaternion.identity) as Transform;
        this.demonFire.transform.localScale = new Vector3(&base.transform.localScale.x, 1f, 1f);
    Label_0196:
        goto Label_01EF;
    Label_019B:
        this.Attack();
        UnityEngine.Object.Instantiate(this.unHolyStrikePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 30f, -1f), Quaternion.identity);
        GameSoundManager.PlayVeznanAttack();
    Label_01EF:
        if (this.isDemon == null)
        {
            goto Label_021E;
        }
        if ((this.demonFire != null) == null)
        {
            goto Label_021E;
        }
        if (base.attackChargeTimeCounter > 0x3e)
        {
            goto Label_021E;
        }
        this.AttackDemon();
    Label_021E:
        return 0;
    }

    protected void RevertToStatic()
    {
        if (this.isDemon == null)
        {
            goto Label_0020;
        }
        base.creepSprite.PlayAnim("idleDemon");
        goto Label_002B;
    Label_0020:
        base.creepSprite.RevertToStatic();
    Label_002B:
        return;
    }

    protected unsafe bool SpecialDownstairs()
    {
        Vector2 vector;
        Vector3 vector2;
        if (this.isLocked == null)
        {
            goto Label_0018;
        }
        if (this.isDownstairs != null)
        {
            goto Label_0018;
        }
        return 0;
    Label_0018:
        if (this.isDownstairs != null)
        {
            goto Label_0025;
        }
        return 0;
    Label_0025:
        if (this.downstairsTimeCounter >= this.downstairsTime)
        {
            goto Label_0086;
        }
        if (this.downstairsTimeCounter != 0x18)
        {
            goto Label_0067;
        }
        if (this.isTaunt == null)
        {
            goto Label_005E;
        }
        this.downstairsTimeCounter -= 1;
        return 1;
    Label_005E:
        this.DoTaunt(0x1d, 0);
    Label_0067:
        if (this.downstairsTimeCounter != 0x73)
        {
            goto Label_0084;
        }
        base.creepSprite.PlayAnim("walkAway");
    Label_0084:
        return 1;
    Label_0086:
        this.isLocked = 0;
        this.isDownstairs = 0;
        this.isWatching = 0;
        base.isStopped = 0;
        this.downstairsTimeCounter = 0;
        this.portalReloadTimeCounter = 0;
        this.holdReloadTimeCounter = 0;
        base.currentNode = 2;
        vector = *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode - 1]));
        vector -= new Vector2(&this.anchorPoint.x, &this.anchorPoint.y);
        base.transform.position = new Vector3(&vector.x, &vector.y, &base.transform.position.z);
        base.facing = 4;
        this.CheckFacing();
        this.portalCurrent = 0;
        this.portalReloadTime = 300;
        this.portalMax = 40;
        base.mainBar.gameObject.SetActive(1);
        return 0;
    }

    protected unsafe bool SpecialGoingDemon()
    {
        Vector3 vector;
        Vector3 vector2;
        if (this.isGoingDemon != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.goingDemonAnimationTimeCounter >= this.goingDemonAnimationTime)
        {
            goto Label_002E;
        }
        this.goingDemonAnimationTimeCounter += 1;
        return 1;
    Label_002E:
        base.mainBar = UnityEngine.Object.Instantiate(this.lifeBarDemon, new Vector3(&base.transform.position.x, &base.transform.position.y + this.yLifebarDemonOffset, -705f), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        this.isGoingDemon = 0;
        base.isStopped = 0;
        this.wasDemon = 1;
        this.goingDemonAnimationTimeCounter = 0;
        base.GetComponent<Layer>().UpdateOffset();
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_00E6;
        }
        this.CheckFacing();
    Label_00E6:
        return 0;
    }

    protected unsafe bool SpecialGoingVeznan()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.isGoingVeznan != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.goingVeznanAnimationTimeCounter >= this.goingDemonAnimationTime)
        {
            goto Label_002E;
        }
        this.goingVeznanAnimationTimeCounter += 1;
        return 1;
    Label_002E:
        this.isGoingVeznan = 0;
        base.isStopped = 0;
        this.isDemon = 0;
        this.goingVeznanAnimationTimeCounter = 0;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_00EA;
        }
        this.CheckFacing();
    Label_00EA:
        return 0;
    }

    protected bool SpecialHold()
    {
        if (this.holdReloadTime == null)
        {
            goto Label_0021;
        }
        if (this.isLocked == null)
        {
            goto Label_0023;
        }
        if (this.isHold != null)
        {
            goto Label_0023;
        }
    Label_0021:
        return 0;
    Label_0023:
        if (this.isHold != null)
        {
            goto Label_009A;
        }
        if (this.holdReloadTimeCounter >= this.holdReloadTime)
        {
            goto Label_0041;
        }
        return 0;
    Label_0041:
        this.isHold = 1;
        this.isLocked = 1;
        base.isStopped = 1;
        this.holdAnimationTimeCounter = 0;
        if (this.isWatching != null)
        {
            goto Label_0073;
        }
        if (base.facing != null)
        {
            goto Label_0088;
        }
    Label_0073:
        base.creepSprite.PlayAnim("spellDown");
        goto Label_0098;
    Label_0088:
        base.creepSprite.PlayAnim("spell");
    Label_0098:
        return 1;
    Label_009A:
        if (this.holdAnimationTimeCounter >= this.holdAnimationTime)
        {
            goto Label_00CE;
        }
        this.holdAnimationTimeCounter += 1;
        if (this.holdAnimationTimeCounter != 14)
        {
            goto Label_00CC;
        }
        this.HoldTowers();
    Label_00CC:
        return 1;
    Label_00CE:
        this.isLocked = 0;
        this.isHold = 0;
        base.isStopped = 0;
        this.holdReloadTimeCounter = 0;
        if (this.isWatching == null)
        {
            goto Label_010A;
        }
        base.creepSprite.PlayAnim("idleDown");
        goto Label_0122;
    Label_010A:
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_0122;
        }
        this.CheckFacing();
    Label_0122:
        return 0;
    }

    protected bool SpecialPortal()
    {
        if (this.portalReloadTime == null)
        {
            goto Label_0021;
        }
        if (this.isLocked == null)
        {
            goto Label_0023;
        }
        if (this.isPortal != null)
        {
            goto Label_0023;
        }
    Label_0021:
        return 0;
    Label_0023:
        if (this.isPortal != null)
        {
            goto Label_0041;
        }
        if (this.portalCurrent != this.portalMax)
        {
            goto Label_0041;
        }
        return 0;
    Label_0041:
        if (this.isPortal != null)
        {
            goto Label_00B8;
        }
        if (this.portalReloadTimeCounter >= this.portalReloadTime)
        {
            goto Label_005F;
        }
        return 0;
    Label_005F:
        this.isPortal = 1;
        this.isLocked = 1;
        base.isStopped = 1;
        this.portalAnimationTimeCounter = 0;
        if (this.isWatching != null)
        {
            goto Label_0091;
        }
        if (base.facing != null)
        {
            goto Label_00A6;
        }
    Label_0091:
        base.creepSprite.PlayAnim("spellDown");
        goto Label_00B6;
    Label_00A6:
        base.creepSprite.PlayAnim("spell");
    Label_00B6:
        return 1;
    Label_00B8:
        if (this.portalAnimationTimeCounter >= this.portalAnimationTime)
        {
            goto Label_00EC;
        }
        this.portalAnimationTimeCounter += 1;
        if (this.portalAnimationTimeCounter != 14)
        {
            goto Label_00EA;
        }
        this.CreatePortals();
    Label_00EA:
        return 1;
    Label_00EC:
        this.isLocked = 0;
        this.isPortal = 0;
        base.isStopped = 0;
        this.portalReloadTimeCounter = 0;
        if (this.isWatching == null)
        {
            goto Label_0128;
        }
        base.creepSprite.PlayAnim("idleDown");
        goto Label_0140;
    Label_0128:
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_0140;
        }
        this.CheckFacing();
    Label_0140:
        return 0;
    }

    protected override bool SpecialPower()
    {
        this.holdReloadTimeCounter += 1;
        this.portalReloadTimeCounter += 1;
        this.tsungReloadTimeCounter += 1;
        this.rndTauntReloadTimeCounter += 1;
        this.rndCanTauntTimeCounter += 1;
        if (this.isStarting == null)
        {
            goto Label_005F;
        }
        this.startTimeCounter += 1;
    Label_005F:
        this.CheckRndTaunt();
        if (this.SpecialTaunt() == null)
        {
            goto Label_0072;
        }
        return 1;
    Label_0072:
        if (this.isDownstairs == null)
        {
            goto Label_008B;
        }
        this.downstairsTimeCounter += 1;
    Label_008B:
        if (this.SpecialDownstairs() == null)
        {
            goto Label_0098;
        }
        return 1;
    Label_0098:
        if (this.isStarting == null)
        {
            goto Label_00B0;
        }
        if (this.SpecialStarting() == null)
        {
            goto Label_00B0;
        }
        return 1;
    Label_00B0:
        if (this.isDemon != null)
        {
            goto Label_00C8;
        }
        if (this.SpecialHold() == null)
        {
            goto Label_00C8;
        }
        return 1;
    Label_00C8:
        if (this.isDemon != null)
        {
            goto Label_00E0;
        }
        if (this.SpecialPortal() == null)
        {
            goto Label_00E0;
        }
        return 1;
    Label_00E0:
        if (this.SpecialGoingDemon() == null)
        {
            goto Label_00ED;
        }
        return 1;
    Label_00ED:
        return this.isWatching;
    }

    protected bool SpecialStarting()
    {
        if (this.isWatching != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isLocked == null)
        {
            goto Label_0025;
        }
        if (this.isStarting != null)
        {
            goto Label_0025;
        }
        return 0;
    Label_0025:
        if (this.startTimeCounter >= this.startTime)
        {
            goto Label_0095;
        }
        if (this.startTimeCounter != 60)
        {
            goto Label_004B;
        }
        this.DoTaunt(0, 0);
    Label_004B:
        if (this.startTimeCounter != 200)
        {
            goto Label_0063;
        }
        this.DoTaunt(1, 0);
    Label_0063:
        if (this.startTimeCounter != 650)
        {
            goto Label_007B;
        }
        this.DoTaunt(2, 0);
    Label_007B:
        if (this.startTimeCounter != 900)
        {
            goto Label_0093;
        }
        this.DoTaunt(3, 0);
    Label_0093:
        return 1;
    Label_0095:
        this.isStarting = 0;
        this.startTimeCounter = 0;
        base.creepSprite.PlayAnim("idleDown");
        return 0;
    }

    protected bool SpecialTaunt()
    {
        if (this.isWatching != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isLocked == null)
        {
            goto Label_0025;
        }
        if (this.isTaunt != null)
        {
            goto Label_0025;
        }
        return 0;
    Label_0025:
        if (this.isTaunt != null)
        {
            goto Label_0032;
        }
        return 0;
    Label_0032:
        if (this.rndTauntAnimationTimeCounter >= this.rndTauntAnimationTime)
        {
            goto Label_0053;
        }
        this.rndTauntAnimationTimeCounter += 1;
        return 1;
    Label_0053:
        if (this.currentTaunt.IsHidden() != null)
        {
            goto Label_006F;
        }
        this.currentTaunt.Hide(1);
    Label_006F:
        this.isTaunt = 0;
        base.isBlocked = 0;
        this.rndTauntReloadTimeCounter = 0;
        this.rndCanTauntTimeCounter = 0;
        base.creepSprite.PlayAnim("idleDown");
        if (this.isDownstairs == null)
        {
            goto Label_00AD;
        }
        base.isBlocked = 1;
    Label_00AD:
        return 0;
    }

    public override unsafe void StartFighting()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.isFighting = 1;
        if (this.isPortal != null)
        {
            goto Label_009E;
        }
        if (this.isHold != null)
        {
            goto Label_009E;
        }
        if (this.isGoingDemon != null)
        {
            goto Label_009E;
        }
        if (this.isGoingVeznan != null)
        {
            goto Label_009E;
        }
        if (this.isTsung != null)
        {
            goto Label_009E;
        }
        base.facing = 4;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.ChargeAttack();
    Label_009E:
        return;
    }

    protected override void StopSpecialPower()
    {
        this.isHold = 0;
        this.isPortal = 0;
        this.isGoingDemon = 0;
        this.isGoingVeznan = 0;
        this.isTsung = 0;
        this.isTaunt = 0;
        this.isDownstairs = 0;
        if (this.currentTaunt.IsHidden() != null)
        {
            goto Label_004D;
        }
        this.currentTaunt.Hide(1);
    Label_004D:
        return;
    }

    public void StopWatching()
    {
        if (this.isWatching != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isDownstairs == null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        if (this.isWatching == null)
        {
            goto Label_0054;
        }
        if (this.isDownstairs != null)
        {
            goto Label_0054;
        }
        base.stage.PlayMusicBossFight();
        this.StopSpecialPower();
        this.isLocked = 1;
        this.isDownstairs = 1;
        this.downstairsTimeCounter = 0;
    Label_0054:
        return;
    }

    private void SwitchEffects()
    {
        base.cursePrefab = this.curseBigPrefab;
        base.poisonPrefab = this.poisonBigPrefab;
        base.smokePrefab = this.smokeBigPrefab;
        base.teslaHitPrefab = this.teslaHitBigPrefab;
        base.healingPrefab = this.healingBigPrefab;
        if ((base.curseEffect != null) == null)
        {
            goto Label_005D;
        }
        UnityEngine.Object.Destroy(base.curseEffect.gameObject);
    Label_005D:
        if ((base.poisonEffect != null) == null)
        {
            goto Label_007E;
        }
        UnityEngine.Object.Destroy(base.poisonEffect.gameObject);
    Label_007E:
        if ((base.teslaEffect != null) == null)
        {
            goto Label_009F;
        }
        UnityEngine.Object.Destroy(base.teslaEffect.gameObject);
    Label_009F:
        base.curseEffect = null;
        base.poisonEffect = null;
        base.teslaEffect = null;
        return;
    }

    public override void Unpause()
    {
        PortalOne one;
        PortalTwo two;
        PortalThree three;
        base.Unpause();
        one = base.GetComponent<PortalOne>();
        two = base.GetComponent<PortalTwo>();
        three = base.GetComponent<PortalThree>();
        if ((one != null) == null)
        {
            goto Label_002D;
        }
        one.Unpause();
    Label_002D:
        if ((two != null) == null)
        {
            goto Label_003F;
        }
        two.Unpause();
    Label_003F:
        if ((three != null) == null)
        {
            goto Label_0051;
        }
        three.Unpause();
    Label_0051:
        return;
    }

    public void UpdateTimers()
    {
        if (base.stage.GetCurrentWaveNumber() != 1)
        {
            goto Label_0018;
        }
        this.isStarting = 0;
    Label_0018:
        this.holdReloadTime = this.holdTimers[base.stage.GetCurrentWaveNumber() - 1][0] * 30;
        this.holdReloadTimeCounter = 0;
        this.portalReloadTime = this.portalTimers[base.stage.GetCurrentWaveNumber() - 1][0] * 30;
        this.portalMax = this.portalTimers[base.stage.GetCurrentWaveNumber() - 1][4];
        this.portalReloadTimeCounter = 0;
        this.portalCurrent = 0;
        this.FireWaveTaunt();
        return;
    }

    protected void WalkAnimation()
    {
        if (this.isDemon == null)
        {
            goto Label_0020;
        }
        base.creepSprite.PlayAnim("walkDemon");
        goto Label_0030;
    Label_0020:
        base.creepSprite.PlayAnim("walk");
    Label_0030:
        return;
    }

    protected void WalkDownAnimation()
    {
        if (this.isDemon == null)
        {
            goto Label_0020;
        }
        base.creepSprite.PlayAnim("walkDownDemon");
        goto Label_0030;
    Label_0020:
        base.creepSprite.PlayAnim("walkDown");
    Label_0030:
        return;
    }

    protected void WalkUpAnimation()
    {
        if (this.isDemon == null)
        {
            goto Label_0020;
        }
        base.creepSprite.PlayAnim("walkUpDemon");
        goto Label_0030;
    Label_0020:
        base.creepSprite.PlayAnim("walkUp");
    Label_0030:
        return;
    }
}

