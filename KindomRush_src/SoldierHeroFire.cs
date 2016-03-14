using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroFire : SoldierHero
{
    public Transform fireGhostPrefab;
    private int flamingFrenzyChargeTime;
    private int flamingFrenzyChargeTimeCounter;
    private int flamingFrenzyHealing;
    private int flamingFrenzyLevel;
    private int flamingFrenzyMaxDamage;
    private int flamingFrenzyMinDamage;
    private int flamingFrenzyRangeHeight;
    private int flamingFrenzyRangeWidth;
    private int idleParticleCounter;
    private bool isFlamingFrenzy;
    private bool isSurgeOfFlame;
    private bool isSurgeOfFlameEnd;
    private bool isSurgeOfFlameWalking;
    private float originalSpeed;
    private int particleCounter;
    private PackedSprite particleIdle1;
    private PackedSprite particleIdle2;
    private PackedSprite particleIdle3;
    private PackedSprite particleIdle4;
    private PackedSprite particleIdle5;
    private PackedSprite particleIdle6;
    public Transform smashFlamingPrefab;
    public Transform smokeParticlePrefab;
    private int surgeOfFlameBlockMinDistance;
    private int surgeOfFlameBlockRangeHeight;
    private int surgeOfFlameBlockRangeWidth;
    private int surgeOfFlameChargeTime;
    private int surgeOfFlameChargeTimeCounter;
    private int surgeOfFlameLevel;
    private int surgeOfFlameMaxDamage;
    private int surgeOfFlameMinDamage;
    private int surgeOfFlameRangeHeight;
    private int surgeOfFlameRangeWidth;
    private int surgeOfFlameReloadTime;
    private int surgeOfFlameReloadTimeCounter;
    private int surgeOfFlameSpeed;

    public SoldierHeroFire()
    {
        base..ctor();
        return;
    }

    protected unsafe void AddParticleIdle()
    {
        int num;
        Vector3 vector;
        int num2;
        this.idleParticleCounter += 1;
        num = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_002F;
        }
        num = 3;
    Label_002F:
        switch ((this.idleParticleCounter - 2))
        {
            case 0:
                goto Label_006F;

            case 1:
                goto Label_0124;

            case 2:
                goto Label_008C;

            case 3:
                goto Label_0124;

            case 4:
                goto Label_00A9;

            case 5:
                goto Label_0124;

            case 6:
                goto Label_00C6;

            case 7:
                goto Label_0124;

            case 8:
                goto Label_00E3;

            case 9:
                goto Label_0124;

            case 10:
                goto Label_0100;
        }
        goto Label_0124;
    Label_006F:
        this.particleIdle1.Hide(0);
        this.particleIdle1.PlayAnim(0);
        goto Label_0124;
    Label_008C:
        this.particleIdle2.Hide(0);
        this.particleIdle2.PlayAnim(0);
        goto Label_0124;
    Label_00A9:
        this.particleIdle3.Hide(0);
        this.particleIdle3.PlayAnim(0);
        goto Label_0124;
    Label_00C6:
        this.particleIdle4.Hide(0);
        this.particleIdle4.PlayAnim(0);
        goto Label_0124;
    Label_00E3:
        this.particleIdle5.Hide(0);
        this.particleIdle5.PlayAnim(0);
        goto Label_0124;
    Label_0100:
        this.particleIdle6.Hide(0);
        this.particleIdle6.PlayAnim(0);
        this.idleParticleCounter = 0;
    Label_0124:
        return;
    }

    protected override unsafe void AddWalkParticle()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Vector3 vector;
        Transform transform2;
        Vector3 vector2;
        Transform transform3;
        IDisposable disposable;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if (this.isSurgeOfFlame == null)
        {
            goto Label_00EE;
        }
        if (this.isSurgeOfFlameWalking == null)
        {
            goto Label_00EE;
        }
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0027:
        try
        {
            goto Label_006B;
        Label_002C:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_006B;
            }
            if (this.OnRangeSurgeOfFlame(creep) == null)
            {
                goto Label_006B;
            }
            creep.Damage(this.GetDamageSurgeOfFlame(), 0, 0, 0);
            creep.AddBurnModifier();
        Label_006B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002C;
            }
            goto Label_0090;
        }
        finally
        {
        Label_007B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0088;
            }
        Label_0088:
            disposable.Dispose();
        }
    Label_0090:
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, -2f);
        transform2 = UnityEngine.Object.Instantiate(this.smokeParticlePrefab, vector, Quaternion.identity) as Transform;
        base.stage.AddEffect(transform2);
        goto Label_0162;
    Label_00EE:
        this.particleCounter += 1;
        if (this.particleCounter != 3)
        {
            goto Label_0162;
        }
        &vector2 = new Vector3(&base.transform.position.x, &base.transform.position.y - 21f, -2f);
        transform3 = UnityEngine.Object.Instantiate(this.fireGhostPrefab, vector2, Quaternion.identity) as Transform;
        this.particleCounter = 0;
    Label_0162:
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        if (this.isSurgeOfFlame == null)
        {
            goto Label_0042;
        }
        if (this.isSurgeOfFlameWalking != null)
        {
            goto Label_0042;
        }
        this.isSurgeOfFlameWalking = 1;
        if ((base.sprite.GetCurAnim().name == "surgeOfFlameEnd") == null)
        {
            goto Label_0042;
        }
        this.SurgeOfFlameEnd();
    Label_0042:
        return;
    }

    protected unsafe bool CanSurgeOfFlame()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        IDisposable disposable;
        if (this.surgeOfFlameReloadTimeCounter >= this.surgeOfFlameReloadTime)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        if (base.isActive != null)
        {
            goto Label_0020;
        }
        return 0;
    Label_0020:
        creep = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0033:
        try
        {
            goto Label_010D;
        Label_0038:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            &vector = new Vector2(&base.transform.position.x - &transform.position.x, &base.transform.position.y - &transform.position.y);
            if (creep2.IsActive() == null)
            {
                goto Label_010D;
            }
            if (creep2.isFlying != null)
            {
                goto Label_010D;
            }
            if (creep2.IsBlocked() != null)
            {
                goto Label_010D;
            }
            if (creep2.CanBeBlocked() == null)
            {
                goto Label_010D;
            }
            if (this.OnRangeSurgeOfFlameBlock(creep2) == null)
            {
                goto Label_010D;
            }
            if (&vector.magnitude <= ((float) this.surgeOfFlameBlockMinDistance))
            {
                goto Label_010D;
            }
            if (creep2.GetCurrentNodeIndex() <= 20)
            {
                goto Label_010D;
            }
            if (creep2.GetCurrentNodeIndex() >= (creep2.GetSubPathCount() - 20))
            {
                goto Label_010D;
            }
            creep = creep2;
            goto Label_0118;
        Label_010D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0038;
            }
        Label_0118:
            goto Label_0132;
        }
        finally
        {
        Label_011D:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_012A;
            }
        Label_012A:
            disposable.Dispose();
        }
    Label_0132:
        if ((creep != null) == null)
        {
            goto Label_018C;
        }
        if (base.isBlocking == null)
        {
            goto Label_0165;
        }
        if ((base.enemy != null) == null)
        {
            goto Label_0165;
        }
        base.enemy.StopFighting();
    Label_0165:
        base.UnBlock();
        base.SetBlockingStatus(creep);
        base.rangePoint = base.destinationPoint;
        base.rallyPoint = base.rangePoint;
        return 1;
    Label_018C:
        return 0;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        bool flag;
        if (base.isDead != null)
        {
            goto Label_0054;
        }
        flag = this.isSurgeOfFlame;
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0020;
        }
        return 0;
    Label_0020:
        base.rangePoint = newRallyPoint;
        base.GetMyPath();
        base.speed = this.originalSpeed;
        GameSoundManager.PlayHeroRainOfFireTaunt();
        if (flag == null)
        {
            goto Label_0054;
        }
        base.sprite.PlayAnim("walk");
    Label_0054:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        this.particleIdle1 = base.transform.FindChild("Fire Particle Idle 1").GetComponent<PackedSprite>();
        this.particleIdle2 = base.transform.FindChild("Fire Particle Idle 2").GetComponent<PackedSprite>();
        this.particleIdle3 = base.transform.FindChild("Fire Particle Idle 3").GetComponent<PackedSprite>();
        this.particleIdle4 = base.transform.FindChild("Fire Particle Idle 4").GetComponent<PackedSprite>();
        this.particleIdle5 = base.transform.FindChild("Fire Particle Idle 5").GetComponent<PackedSprite>();
        this.particleIdle6 = base.transform.FindChild("Fire Particle Idle 6").GetComponent<PackedSprite>();
        base.attackChargeTime = 0x13;
        base.attackChargeDamageTime = 9;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_fire", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_fire", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_fire", "respawn", 1)) * 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_fire", "reload", 1)) * 30) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_fire", "flamingFrenzyModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_fire", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(0f, 30f);
        base.levelUpChargeTime = 0x18;
        base.respawnTime = 14;
        this.surgeOfFlameReloadTime = 0x1f;
        this.flamingFrenzyChargeTime = 0x18;
        base.levelUpSoundShoot = 5;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 5.4f;
        this.originalSpeed = base.speed;
        base.lifes = 1;
        base.xAdjust = 6f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        base.damageTypeMelee = 0;
        this.particleCounter = 0;
        this.idleParticleCounter = 0;
        base.canBeBurned = 0;
        return;
    }

    protected override unsafe bool DestinationReach()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        float introduced3 = Mathf.Pow(&this.destinationPoint.y - &base.transform.position.y, 2f);
        if (Mathf.Sqrt(introduced3 + Mathf.Pow(&this.destinationPoint.x - &base.transform.position.x, 2f)) > base.speed)
        {
            goto Label_0174;
        }
        base.isWalking = 0;
        base.isActive = 1;
        float introduced4 = Mathf.Round(&this.destinationPoint.x);
        base.transform.position = new Vector3(introduced4, Mathf.Round(&this.destinationPoint.y), &base.transform.position.z);
        if (base.isFighting == null)
        {
            goto Label_0153;
        }
        if (this.isSurgeOfFlame != null)
        {
            goto Label_00D0;
        }
        base.SetFacing();
    Label_00D0:
        if (base.isBlocking == null)
        {
            goto Label_0107;
        }
        if ((base.enemy != null) == null)
        {
            goto Label_0107;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_0107;
        }
        base.enemy.StartFighting();
    Label_0107:
        if (this.isSurgeOfFlame == null)
        {
            goto Label_015A;
        }
        if ((base.enemy != null) == null)
        {
            goto Label_0129;
        }
        base.SetFacing();
    Label_0129:
        this.isSurgeOfFlameWalking = 0;
        this.isSurgeOfFlameEnd = 1;
        base.sprite.PlayAnim("surgeOfFlameEnd");
        GameSoundManager.PlayHeroRainOfFireFireball2();
        return 0;
        goto Label_015A;
    Label_0153:
        base.isIdle = 1;
    Label_015A:
        this.RevertToStatic();
        if (this.isSurgeOfFlame == null)
        {
            goto Label_0172;
        }
        this.isSurgeOfFlame = 0;
    Label_0172:
        return 1;
    Label_0174:
        return 0;
    }

    protected void DoFlamingFrenzy()
    {
        this.StopSpecial();
        this.isFlamingFrenzy = 1;
        base.sprite.PlayAnim("flamingFrenzy");
        base.GainXpByAbilityModifier(2, this.flamingFrenzyLevel);
        GameSoundManager.PlayHeroRainOfFireArea();
        return;
    }

    protected unsafe void DoSurgeOfFlame()
    {
        Vector3 vector;
        this.isSurgeOfFlame = 1;
        this.isSurgeOfFlameWalking = 0;
        this.isSurgeOfFlameEnd = 0;
        base.speed = (float) this.surgeOfFlameSpeed;
        if (&base.enemy.transform.localScale.x != -1f)
        {
            goto Label_0070;
        }
        base.destinationPoint = new Vector2(&this.destinationPoint.x - 20f, &this.destinationPoint.y);
        goto Label_0097;
    Label_0070:
        base.destinationPoint = new Vector2(&this.destinationPoint.x - 11f, &this.destinationPoint.y);
    Label_0097:
        base.sprite.PlayAnim("surgeOfFlameStart");
        base.GainXpByAbilityModifier(1, this.surgeOfFlameLevel);
        GameSoundManager.PlayHeroRainOfFireFireball1();
        return;
    }

    protected unsafe bool EvalFlamingFrenzy()
    {
        Vector3 vector;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Vector3 vector2;
        Vector3 vector3;
        IDisposable disposable;
        if (this.flamingFrenzyChargeTimeCounter >= this.flamingFrenzyChargeTime)
        {
            goto Label_010C;
        }
        this.flamingFrenzyChargeTimeCounter += 1;
        if (this.flamingFrenzyChargeTimeCounter != 12)
        {
            goto Label_010A;
        }
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 15f, -2f);
        UnityEngine.Object.Instantiate(this.smashFlamingPrefab, vector, Quaternion.identity);
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0089:
        try
        {
            goto Label_00CD;
        Label_008E:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00CD;
            }
            if (this.OnRangeFlamingFrenzy(creep) == null)
            {
                goto Label_00CD;
            }
            creep.Damage(this.GetDamageFlamingFrenzy(), 0, 0, 0);
            creep.AddBurnModifier();
        Label_00CD:
            if (enumerator.MoveNext() != null)
            {
                goto Label_008E;
            }
            goto Label_00F2;
        }
        finally
        {
        Label_00DD:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00EA;
            }
        Label_00EA:
            disposable.Dispose();
        }
    Label_00F2:
        base.Heal(Mathf.RoundToInt(((float) base.initHealth) * 0.2f));
    Label_010A:
        return 1;
    Label_010C:
        this.isFlamingFrenzy = 0;
        this.flamingFrenzyChargeTimeCounter = 0;
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
        if (this.CanSurgeOfFlame() == null)
        {
            goto Label_005C;
        }
        this.DoSurgeOfFlame();
        return;
    Label_005C:
        if (this.flamingFrenzyLevel == null)
        {
            goto Label_009C;
        }
        if (this.isFlamingFrenzy != null)
        {
            goto Label_009C;
        }
        if (base.isLevelUp != null)
        {
            goto Label_009C;
        }
        if (UnityEngine.Random.Range(0f, 1f) >= 0.25f)
        {
            goto Label_009C;
        }
        this.DoFlamingFrenzy();
    Label_009C:
        return;
    }

    protected int GetDamageFlamingFrenzy()
    {
        return UnityEngine.Random.Range(this.flamingFrenzyMinDamage, this.flamingFrenzyMaxDamage + 1);
    }

    protected int GetDamageSurgeOfFlame()
    {
        return UnityEngine.Random.Range(this.surgeOfFlameMinDamage, this.surgeOfFlameMaxDamage + 1);
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_fire", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_fire", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_fire", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_fire", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_fire", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeFlamingFrenzy();
        this.UpgradeSurgeOfFlame();
        return;
    }

    protected bool OnRangeFlamingFrenzy(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.flamingFrenzyRangeHeight, (float) this.flamingFrenzyRangeWidth, base.rangeCenterPosition);
    }

    protected bool OnRangeSurgeOfFlame(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.surgeOfFlameRangeHeight, (float) this.surgeOfFlameRangeWidth, base.rangeCenterPosition);
    }

    protected bool OnRangeSurgeOfFlameBlock(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.surgeOfFlameBlockRangeHeight, (float) this.surgeOfFlameBlockRangeWidth, base.rangeCenterPosition);
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroRainOfFireDeath();
        return;
    }

    protected override void PlayIdle()
    {
        base.PlayIdle();
        this.AddParticleIdle();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroRainOfFireTauntIntro();
        return;
    }

    protected override bool ReadyToAttack()
    {
        this.AddParticleIdle();
        base.attackReloadTimeCounter += 1;
        if (base.attackReloadTimeCounter != base.attackReloadTime)
        {
            goto Label_003B;
        }
        this.ChargeAttack();
        base.attackReloadTimeCounter = 0;
        base.attackChargeTimeCounter = 0;
        return 1;
    Label_003B:
        return 0;
    }

    protected override bool RunSpecial()
    {
        this.surgeOfFlameReloadTimeCounter += 1;
        this.surgeOfFlameReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0029;
        }
        return 1;
    Label_0029:
        if (this.isSurgeOfFlame == null)
        {
            goto Label_0041;
        }
        if (this.isSurgeOfFlameWalking != null)
        {
            goto Label_0041;
        }
        return 1;
    Label_0041:
        if (this.isFlamingFrenzy == null)
        {
            goto Label_0059;
        }
        if (this.EvalFlamingFrenzy() == null)
        {
            goto Label_0059;
        }
        return 1;
    Label_0059:
        return 0;
    }

    protected override unsafe void SetGoToIdleStatus()
    {
        Vector3 vector;
        if (base.isWalking == null)
        {
            goto Label_0016;
        }
        if (this.isSurgeOfFlame == null)
        {
            goto Label_0034;
        }
    Label_0016:
        base.isIdle = 0;
        base.isWalking = 1;
        base.sprite.PlayAnim("walk");
    Label_0034:
        base.enemy = null;
        base.isFighting = 0;
        base.isBlocking = 0;
        base.isCharging = 0;
        this.isSurgeOfFlame = 0;
        base.destinationPoint = new Vector2(&this.rallyPoint.x, &this.rallyPoint.y);
        base.rangeCenterPosition = new Vector2(&this.rallyPoint.x, &this.rallyPoint.y - base.yAdjust);
        if (&this.destinationPoint.x >= &base.transform.position.x)
        {
            goto Label_00EC;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_00FC;
    Label_00EC:
        base.transform.localScale = Vector3.one;
    Label_00FC:
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isFlamingFrenzy = 0;
        this.isSurgeOfFlame = 0;
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isSurgeOfFlame = 0;
        this.isSurgeOfFlameWalking = 0;
        this.isSurgeOfFlameEnd = 0;
        return;
    }

    protected void SurgeOfFlameEnd()
    {
        this.isSurgeOfFlame = 0;
        this.isSurgeOfFlameEnd = 0;
        this.isSurgeOfFlameWalking = 0;
        this.surgeOfFlameReloadTimeCounter = 0;
        base.speed = this.originalSpeed;
        base.SetFacing();
        return;
    }

    protected void SurgeOfFlameStartEnd()
    {
        this.isSurgeOfFlameWalking = 1;
        return;
    }

    protected void UpgradeFlamingFrenzy()
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
        this.flamingFrenzyLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.flamingFrenzyLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.flamingFrenzyLevel = 3;
    Label_006A:
        this.flamingFrenzyMinDamage = ((int) GameSettings.GetHeroSetting("hero_fire", "flamingFrenzyMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameDamageIncrement", 1)) * this.flamingFrenzyLevel);
        this.flamingFrenzyMaxDamage = ((int) GameSettings.GetHeroSetting("hero_fire", "flamingFrenzyMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameDamageIncrement", 1)) * this.flamingFrenzyLevel);
        this.flamingFrenzyRangeWidth = (int) GameSettings.GetHeroSetting("hero_fire", "flamingFrenzyRangeWidth", 1);
        this.flamingFrenzyRangeHeight = Mathf.RoundToInt(((float) this.flamingFrenzyRangeWidth) * 0.7f);
        return;
    }

    protected void UpgradeSurgeOfFlame()
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
        this.surgeOfFlameLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.surgeOfFlameLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.surgeOfFlameLevel = 3;
    Label_0068:
        this.surgeOfFlameReloadTime = ((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameReloadTime", 1)) * 30;
        this.surgeOfFlameMinDamage = ((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameDamageIncrement", 1)) * this.surgeOfFlameLevel);
        this.surgeOfFlameMaxDamage = ((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameDamageIncrement", 1)) * this.surgeOfFlameLevel);
        this.surgeOfFlameRangeWidth = (int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameRangeWidth", 1);
        this.surgeOfFlameRangeHeight = Mathf.RoundToInt(((float) this.surgeOfFlameRangeWidth) * 0.7f);
        this.surgeOfFlameBlockRangeWidth = (int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameBlockRangeWidth", 1);
        this.surgeOfFlameBlockRangeHeight = Mathf.RoundToInt(((float) this.surgeOfFlameBlockRangeWidth) * 0.7f);
        this.surgeOfFlameBlockMinDistance = (int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameBlockMinDistance", 1);
        this.surgeOfFlameSpeed = (int) GameSettings.GetHeroSetting("hero_fire", "surgeOfFlameSpeed", 1);
        return;
    }

    protected override unsafe bool Walk()
    {
        float num;
        Vector2 vector;
        AStarNode node;
        Vector2 vector2;
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
        if (base.path.Count != null)
        {
            goto Label_01D8;
        }
        if (base.isActive == null)
        {
            goto Label_00A8;
        }
        if (base.isFighting == null)
        {
            goto Label_00A1;
        }
        if ((base.enemy == null) != null)
        {
            goto Label_0057;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_0057;
        }
        if (base.enemy.IsBlocked() != null)
        {
            goto Label_008A;
        }
    Label_0057:
        base.UnBlock();
        if (this.isSurgeOfFlame != null)
        {
            goto Label_0073;
        }
        if (base.FindEnemy() != null)
        {
            goto Label_00A8;
        }
    Label_0073:
        base.speed = this.originalSpeed;
        this.SetGoToIdleStatus();
        goto Label_009C;
    Label_008A:
        if (base.isBlocking != null)
        {
            goto Label_00A8;
        }
        base.FindEnemy();
    Label_009C:
        goto Label_00A8;
    Label_00A1:
        base.FindEnemy();
    Label_00A8:
        if (this.DestinationReach() == null)
        {
            goto Label_00B5;
        }
        return 1;
    Label_00B5:
        num = Mathf.Atan2(&this.destinationPoint.y - &base.transform.position.y, &this.destinationPoint.x - &base.transform.position.x);
        if (this.isSurgeOfFlameEnd != null)
        {
            goto Label_015E;
        }
        if (&this.destinationPoint.x >= &base.transform.position.x)
        {
            goto Label_014E;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_015E;
    Label_014E:
        base.transform.localScale = Vector3.one;
    Label_015E:
        this.AddWalkParticle();
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x + (Mathf.Cos(num) * base.speed)), Mathf.Round(&base.transform.position.y + (Mathf.Sin(num) * base.speed)), &base.transform.position.z);
        return 0;
    Label_01D8:
        vector = ((AStarNode) base.path[base.currentPathNode - 1]).GetNodeRealPosition() + new Vector2(0f, base.yAdjust);
        if (this.DestinationReachOnPath(vector) == null)
        {
            goto Label_024B;
        }
        base.currentPathNode -= 1;
        if ((base.currentPathNode - 1) != null)
        {
            goto Label_024B;
        }
        base.path.Clear();
        base.currentPathNode = 0;
        return base.Walk();
    Label_024B:
        node = (AStarNode) base.path[base.currentPathNode - 1];
        vector2 = node.GetNodeRealPosition() + new Vector2(0f, base.yAdjust);
        num = Mathf.Atan2(&vector2.y - &base.transform.position.y, &vector2.x - &base.transform.position.x);
        if (&vector2.x >= &base.transform.position.x)
        {
            goto Label_0302;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0312;
    Label_0302:
        base.transform.localScale = Vector3.one;
    Label_0312:
        this.AddWalkParticle();
        base.transform.position = new Vector3(&base.transform.position.x + (Mathf.Cos(num) * base.speed), &base.transform.position.y + (Mathf.Sin(num) * base.speed), &base.transform.position.z);
        return 0;
    }
}

