using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroThor : SoldierHero
{
    private int chainAreaDamage;
    private int chainChance;
    private int chainChargeTime;
    private int chainChargeTimeCounter;
    private int chainDamage;
    private Constants.damageType chainDamageType;
    private Vector3 chainHitPosition;
    private int chainLevel;
    private int chainMainDamage;
    private Constants.damageType chainMainDamageType;
    private int chainMaxJumps;
    private int chainMinAreaDamage;
    private int chainReloadTime;
    private ArrayList enemyCandidates;
    private bool isChain;
    private bool isThunderclap;
    private int referenceNode;
    private int referencePath;
    private ArrayList shootEnemies;
    public Transform thorHammerPrefab;
    public Transform thorRayPrefab;
    private int thunderclapArea;
    private int thunderclapChargeTime;
    private int thunderclapChargeTimeCounter;
    private int thunderclapLevel;
    private int thunderclapMainDamage;
    private Constants.damageType thunderclapMainDamageType;
    private int thunderClapMaxStunDuration;
    private int thunderclapMinDistance;
    private int thunderClapMinStunDuration;
    private Vector3 thunderclapPoint;
    private Vector3 thunderclapPointOriginal;
    private int thunderclapRangeHeight;
    private int thunderclapRangeWidth;
    private int thunderclapReloadTime;
    private int thunderclapReloadTimeCounter;
    private int thunderclapSecondaryDamage;
    private Constants.damageType thunderclapSecondaryDamageType;
    private Creep thunderclapTarget;
    private Creep thunderclapTargetOriginal;

    public SoldierHeroThor()
    {
        this.enemyCandidates = new ArrayList();
        base..ctor();
        return;
    }

    protected bool canChain()
    {
        if (this.chainLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (UnityEngine.Random.Range(0f, 1f) <= (((float) this.chainChance) / 100f))
        {
            goto Label_0030;
        }
        return 0;
    Label_0030:
        return 1;
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
        GameSoundManager.PlayHeroThorTaunt();
    Label_0048:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.shootEnemies = new ArrayList();
        base.attackChargeTime = 0x19;
        base.attackChargeDamageTime = 0x10;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_thor", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_thor", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_thor", "respawn", 1)) * 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_thor", "reload", 1)) * 30) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_thor", "chainAbilityOneModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_thor", "thunderclapAbilityTwoModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_thor", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(10f, 30f);
        base.levelUpChargeTime = 0x10;
        base.respawnTime = (int) GameSettings.GetHeroSetting("hero_thor", "respawn", 1);
        base.levelUpSoundShoot = 5;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.8f;
        base.lifes = 1;
        base.xAdjust = 15f;
        base.yAdjust = 23f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        base.damageType = 5;
        return;
    }

    protected void doChain()
    {
        if ((base.enemy != null) == null)
        {
            goto Label_0062;
        }
        if (base.enemy.IsActive() == null)
        {
            goto Label_0062;
        }
        if (base.enemy.IsDead() != null)
        {
            goto Label_0062;
        }
        base.enemy.ShowTeslaHit();
        base.enemy.Damage(this.chainMainDamage, this.chainMainDamageType, 0, 0);
        base.GainXpByAbilityModifier(1, this.chainLevel);
    Label_0062:
        return;
    }

    protected void doChainAreaDamage()
    {
        Creep creep;
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        creep = null;
        num = 0;
        this.enemyCandidates = new ArrayList();
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0020:
        try
        {
            goto Label_0091;
        Label_0025:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if ((creep2 != null) == null)
            {
                goto Label_0091;
            }
            if (creep2.IsActive() == null)
            {
                goto Label_0091;
            }
            if ((creep2 != base.enemy) == null)
            {
                goto Label_0091;
            }
            if (this.isEnemyInRangeForChain(creep2) == null)
            {
                goto Label_0091;
            }
            if (this.enemyCandidates.Contains(creep2) != null)
            {
                goto Label_0091;
            }
            this.enemyCandidates.Add(creep2);
        Label_0091:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0025;
            }
            goto Label_00B6;
        }
        finally
        {
        Label_00A1:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00AE;
            }
        Label_00AE:
            disposable.Dispose();
        }
    Label_00B6:
        this.doRays();
        return;
    }

    protected unsafe void doRays()
    {
        int num;
        int num2;
        Creep creep;
        Transform transform;
        ArrayList list;
        TeslaRay ray;
        num = 0;
        goto Label_00D4;
    Label_0007:
        num2 = UnityEngine.Random.Range(0, this.enemyCandidates.Count);
        creep = (Creep) this.enemyCandidates[num2];
        transform = UnityEngine.Object.Instantiate(this.thorRayPrefab, new Vector3(&this.chainHitPosition.x + 6f, &this.chainHitPosition.y - 18f, -890f), base.transform.rotation) as Transform;
        list = new ArrayList();
        ray = transform.GetComponent<TeslaRay>();
        ray.Init(creep, 1, 1, &list, base.stage);
        ray.SetDamage(this.chainDamage);
        ray.SetTowerPos(&this.chainHitPosition.x, &this.chainHitPosition.y - 18f);
        num += 1;
        this.enemyCandidates.RemoveAt(num2);
    Label_00D4:
        if (this.enemyCandidates.Count <= 0)
        {
            goto Label_00F1;
        }
        if (num < this.chainMaxJumps)
        {
            goto Label_0007;
        }
    Label_00F1:
        return;
    }

    protected unsafe void doThunderclap()
    {
        int num;
        Transform transform;
        ThorHammer hammer;
        this.thunderclapReloadTimeCounter = 0;
        num = this.GetDamageThunderclap();
        transform = UnityEngine.Object.Instantiate(this.thorHammerPrefab, base.transform.position + new Vector3(0f, 14f, 0f), Quaternion.identity) as Transform;
        hammer = transform.GetComponent<ThorHammer>();
        base.stage.AddProjectile(hammer.transform);
        hammer.Init(num, 1, base.spawner, this.thunderclapArea, this.thunderclapSecondaryDamage, this.thunderclapSecondaryDamageType, Mathf.RoundToInt(this.getStunDuration() * 30f));
        hammer.SetDamage(num);
        hammer.SetTarget(this.thunderclapTarget, &this.thunderclapPoint.x, &this.thunderclapPoint.y);
        hammer.SetStage(base.stage);
        GameSoundManager.PlayHeroThorHammer();
        base.GainXpByAbilityModifier(2, this.thunderclapLevel);
        return;
    }

    protected void endChain()
    {
        this.isChain = 0;
        this.chainChargeTimeCounter = 0;
        return;
    }

    protected void endThunderclap()
    {
        this.isThunderclap = 0;
        this.thunderclapReloadTimeCounter = 0;
        this.thunderclapChargeTimeCounter = 0;
        base.RecoverAnimationState();
        return;
    }

    protected bool EvalChain()
    {
        if (this.chainLevel != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isChain != null)
        {
            goto Label_001A;
        }
        return 0;
    Label_001A:
        if (this.chainChargeTimeCounter >= this.chainChargeTime)
        {
            goto Label_0061;
        }
        this.chainChargeTimeCounter += 1;
        if (this.chainChargeTimeCounter != 0x10)
        {
            goto Label_004C;
        }
        this.doChain();
    Label_004C:
        if (this.chainChargeTimeCounter != 0x12)
        {
            goto Label_005F;
        }
        this.doChainAreaDamage();
    Label_005F:
        return 1;
    Label_0061:
        this.endChain();
        return 0;
    }

    protected bool EvalThunderclap()
    {
        if (base.isCharging != null)
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
        if (this.isThunderclap != null)
        {
            goto Label_004B;
        }
        if (this.thunderclapReloadTimeCounter >= this.thunderclapReloadTime)
        {
            goto Label_0036;
        }
        return 0;
    Label_0036:
        if (this.FindThunderclapTarget() != null)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        this.startThunderclap();
        return 1;
    Label_004B:
        if (this.thunderclapChargeTimeCounter >= this.thunderclapChargeTime)
        {
            goto Label_007F;
        }
        this.thunderclapChargeTimeCounter += 1;
        if (this.thunderclapChargeTimeCounter != 13)
        {
            goto Label_007D;
        }
        this.doThunderclap();
    Label_007D:
        return 1;
    Label_007F:
        this.endThunderclap();
        return 0;
    }

    protected unsafe bool FindThunderclapTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        bool flag;
        IDisposable disposable;
        creep = null;
        this.thunderclapTarget = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001A:
        try
        {
            goto Label_00FC;
        Label_001F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            num = (float) this.thunderclapMinDistance;
            num2 = (float) (((double) this.thunderclapMinDistance) * 0.7);
            if (creep2.IsActive() == null)
            {
                goto Label_00FC;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, num2, num, base.transform.position) != null)
            {
                goto Label_00FC;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, (float) this.thunderclapRangeHeight, (float) this.thunderclapRangeWidth, base.transform.position) == null)
            {
                goto Label_00FC;
            }
            this.thunderclapTarget = creep2;
            this.thunderclapPoint = new Vector3(&creep2.transform.position.x + creep2.xAdjust, &creep2.transform.position.y + creep2.yAdjust);
            flag = 1;
            goto Label_0123;
        Label_00FC:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
            goto Label_0121;
        }
        finally
        {
        Label_010C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0119;
            }
        Label_0119:
            disposable.Dispose();
        }
    Label_0121:
        return 0;
    Label_0123:
        return flag;
    }

    protected int GetDamageThunderclap()
    {
        return this.thunderclapMainDamage;
    }

    protected float getStunDuration()
    {
        return UnityEngine.Random.Range((float) this.thunderClapMinStunDuration, (float) this.thunderClapMaxStunDuration);
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

    protected bool isEnemyInRangeForChain(Creep tmpEnemy)
    {
        return ((IronUtils.ellipseContainPoint(tmpEnemy.transform.position, ((float) this.chainAreaDamage) * 0.7f, (float) this.chainAreaDamage, this.chainHitPosition) == null) ? 0 : (IronUtils.ellipseContainPoint(tmpEnemy.transform.position, ((float) this.chainMinAreaDamage) * 0.7f, (float) this.chainMinAreaDamage, this.chainHitPosition) == 0));
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
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_thor", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_thor", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_thor", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_thor", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_thor", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeChain();
        this.UpgradeThunderclap();
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroThorDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroThorTauntIntro();
        return;
    }

    protected override bool ReadyToAttack()
    {
        base.attackReloadTimeCounter += 1;
        if (base.attackReloadTimeCounter != base.attackReloadTime)
        {
            goto Label_0044;
        }
        if (this.canChain() == null)
        {
            goto Label_0035;
        }
        this.startChain();
        goto Label_003B;
    Label_0035:
        this.ChargeAttack();
    Label_003B:
        base.attackReloadTimeCounter = 0;
        return 1;
    Label_0044:
        return 0;
    }

    protected override bool RunSpecial()
    {
        this.thunderclapReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_001B;
        }
        return 1;
    Label_001B:
        if (this.chainLevel == null)
        {
            goto Label_0033;
        }
        if (this.EvalChain() == null)
        {
            goto Label_0033;
        }
        return 1;
    Label_0033:
        if (this.thunderclapLevel == null)
        {
            goto Label_004B;
        }
        if (this.EvalThunderclap() == null)
        {
            goto Label_004B;
        }
        return 1;
    Label_004B:
        return 0;
    }

    protected unsafe void startChain()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.isChain = 1;
        this.chainChargeTimeCounter = 0;
        this.chainHitPosition = new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -40 : 40)), &base.transform.position.y - 18f);
        base.sprite.PlayAnim("chain");
        GameSoundManager.PlayHeroThorElectricAttack();
        return;
    }

    protected unsafe void startThunderclap()
    {
        Vector3 vector;
        Vector3 vector2;
        this.isThunderclap = 1;
        this.thunderclapChargeTimeCounter = 0;
        if (&this.thunderclapTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_0053;
        }
        base.transform.localScale = Vector3.one;
        goto Label_0072;
    Label_0053:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_0072:
        this.thunderclapChargeTimeCounter = 0;
        base.sprite.PlayAnim("thunderClap");
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isChain = 0;
        this.isThunderclap = 0;
        base.isLevelUp = 0;
        return;
    }

    protected void UpgradeChain()
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
        this.chainLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.chainLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.chainLevel = 3;
    Label_0068:
        this.chainChance = (int) GameSettings.GetHeroSetting("hero_thor", "chainChance", this.chainLevel);
        this.chainMainDamage = (int) GameSettings.GetHeroSetting("hero_thor", "chainMainDamage", this.chainLevel);
        this.chainMainDamageType = 0;
        this.chainDamage = (int) GameSettings.GetHeroSetting("hero_thor", "chainChainMainDamage", this.chainLevel);
        this.chainDamageType = 2;
        this.chainAreaDamage = (int) GameSettings.GetHeroSetting("hero_thor", "chainArea", 1);
        this.chainMaxJumps = (int) GameSettings.GetHeroSetting("hero_thor", "chainMaxJumps", this.chainLevel);
        this.chainMinAreaDamage = (int) GameSettings.GetHeroSetting("hero_thor", "chainMinArea", 1);
        this.chainChargeTime = 0x20;
        this.chainChargeTimeCounter = 0;
        return;
    }

    protected void UpgradeThunderclap()
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
        this.thunderclapLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.thunderclapLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.thunderclapLevel = 3;
    Label_006A:
        this.thunderclapReloadTime = ((int) GameSettings.GetHeroSetting("hero_thor", "thunderclapReload", 1)) * 30;
        this.thunderclapRangeWidth = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapRange", 1);
        this.thunderclapRangeHeight = Mathf.RoundToInt(((float) this.thunderclapRangeWidth) * 0.7f);
        this.thunderclapMinDistance = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapMinDistance", 1);
        this.thunderclapMainDamage = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapMainDamage", this.thunderclapLevel);
        this.thunderclapMainDamageType = 0;
        this.thunderclapSecondaryDamage = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapSecondaryDamage", this.thunderclapLevel);
        this.thunderclapSecondaryDamageType = 2;
        this.thunderclapArea = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapArea", this.thunderclapLevel);
        this.thunderClapMinStunDuration = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapMinStunDuration", this.thunderclapLevel);
        this.thunderClapMaxStunDuration = (int) GameSettings.GetHeroSetting("hero_thor", "thunderclapMaxStunDuration", this.thunderclapLevel);
        this.thunderclapChargeTime = 0x1b;
        return;
    }
}

