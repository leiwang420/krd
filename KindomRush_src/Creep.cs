using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class Creep : MonoBehaviour
{
    protected bool active;
    public Vector3 anchorPoint;
    public bool areaAttack;
    public int areaAttackMax;
    protected Vector2 areaAttackPoint;
    public int areaAttackRangeHeight;
    public int areaAttackRangeWidth;
    public int armor;
    public int attackChargeTime;
    protected int attackChargeTimeCounter;
    public int attackDodgeTime;
    protected bool attackIsDodged;
    public int attackReloadTime;
    protected int attackReloadTimeCounter;
    protected int basicAnimationStartTime;
    protected int basicAnimationTime;
    protected int basicAnimationTimeCounter;
    protected int basicCoolddownTimeCounter;
    protected int basicCooldownTime;
    protected bool basicIncrementOnFunction;
    protected int basicRangeHeight;
    protected int basicRangeWidth;
    public Transform bloodDecal;
    public Transform bloodSplatter;
    protected Transform burnEffect;
    public Transform burnPrefab;
    protected bool canBeBlocked;
    public bool canBePoisoned;
    public bool canBeTeleported;
    public bool canBeThorned;
    public bool canBlood;
    public bool canGib;
    public bool canRage;
    public bool canRegenerate;
    public bool canSkeleton;
    protected UnitClickable clickable;
    public int cost;
    protected PackedSprite creepSprite;
    protected int currentNode;
    protected PackedSprite curseEffect;
    public Transform cursePrefab;
    protected bool desintegrate;
    public Transform desintegratePrefab;
    public int dodge;
    protected int facing;
    public int fadingTime;
    protected int fadingTimeCounter;
    protected int fighterPositionOne;
    protected int fighterPositionTwo;
    protected int freezeTime;
    protected int freezeTimeCounter;
    protected bool gibs;
    public Transform gibsPrefab;
    public int gold;
    protected GUIBottom gui;
    public bool hasBasicSpecialAction;
    public Transform healingPrefab;
    protected PackedSprite iceBlock;
    public Transform iceBlockPrefab;
    protected bool ignoreArmorOnMelee;
    protected bool isActive;
    protected bool isBasicSpecial;
    protected bool isBlocked;
    public bool isBoss;
    protected bool isCharging;
    protected bool isDead;
    protected bool isFading;
    protected bool isFighting;
    public bool isFlying;
    protected bool isFreeze;
    protected bool isPaused;
    protected bool isRespawning;
    protected bool isStopped;
    protected bool isStunned;
    public int life;
    protected Transform lifeBar;
    public Transform lifeBarPrefab;
    public int magicArmor;
    protected Transform mainBar;
    public int maxDamage;
    public int minDamage;
    protected float originalSpeed;
    protected Vector2[][][] path;
    protected int pathIndex;
    protected PackedSprite poisonEffect;
    public Transform poisonPrefab;
    public bool polymorphable;
    protected Transform popHeadshotPrefab;
    public Transform portalVeznanImp;
    protected int regenerateHealPoints;
    protected int regenerateTime;
    protected int regenerateTimeCounter;
    protected int respawnTime;
    protected int respawnTimeCounter;
    public int roadNodesTillActive;
    public Transform smokePrefab;
    protected Soldier soldier;
    protected CreepSpawner spawner;
    public float speed;
    protected StageBase stage;
    protected Transform stun;
    public Transform stunPrefab;
    protected int subpathIndex;
    protected int teleportCount;
    protected Transform teleportEffect;
    protected bool teleporting;
    protected int teleportMaxTimes;
    public Transform teleportPrefab;
    protected PackedSprite teslaEffect;
    public Transform teslaHitPrefab;
    protected int thornCount;
    protected int thornDamage;
    protected float thornDamageTime;
    protected float thornDamageTimeCounter;
    protected float thornDuration;
    protected float thornDurationCounter;
    protected int thornMaxTimes;
    protected bool thornSpecial;
    protected int totalArmor;
    protected int totalLife;
    protected int totalMagicArmor;
    protected bool useGold;
    protected bool wasAnimating;
    public float xAdjust;
    public int xLifebarOffset;
    public float xModifierAdjust;
    public float xSoldierAdjust;
    protected float xSpeed;
    public float yAdjust;
    public int yLifebarOffset;
    public float yModifierAdjust;
    public float ySoldierAdjust;
    protected float ySpeed;

    public Creep()
    {
        this.facing = -1;
        this.fadingTime = 50;
        this.canBePoisoned = 1;
        this.canBeThorned = 1;
        this.canBeTeleported = 1;
        this.canGib = 1;
        this.canSkeleton = 1;
        this.canBlood = 1;
        this.useGold = 1;
        this.roadNodesTillActive = 3;
        base..ctor();
        return;
    }

    public void AddArmor(int quantity)
    {
        this.armor += quantity;
        return;
    }

    public unsafe void AddBurnModifier()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        &vector = new Vector3(&base.transform.position.x + this.xModifierAdjust, &base.transform.position.y + this.yModifierAdjust, &base.transform.position.z - 1f);
        this.burnEffect = UnityEngine.Object.Instantiate(this.burnPrefab, vector, Quaternion.identity) as Transform;
        this.burnEffect.parent = base.transform;
        return;
    }

    public virtual void AddExplodeEffect()
    {
    }

    public unsafe void ApplyThornSpecial(float d, int dmg)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.thornCount >= this.thornMaxTimes)
        {
            goto Label_00C0;
        }
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        GameAchievements.ThornEnemy();
        this.thornCount += 1;
        this.thornSpecial = 1;
        this.thornDuration = d;
        this.thornDamageTimeCounter = 0f;
        this.thornDurationCounter = 0f;
        this.thornDamage = dmg;
        this.isStopped = 1;
        this.isCharging = 0;
        this.creepSprite.PlayAnim("thornUp");
    Label_00C0:
        return;
    }

    protected void AreaAttack()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.areaAttackPoint = this.GetAttackPoint();
        num = 0;
        enumerator = this.stage.GetSoldiers().GetEnumerator();
    Label_0021:
        try
        {
            goto Label_006B;
        Label_0026:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_006B;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_006B;
            }
            soldier.SetDamage(this.GetDamage(), 0);
            num += 1;
            if (num != this.areaAttackMax)
            {
                goto Label_006B;
            }
            goto Label_0076;
        Label_006B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0026;
            }
        Label_0076:
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
        return;
    }

    protected virtual void Attack()
    {
        if (this.attackIsDodged == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (UnityEngine.Random.Range(0f, 1f) >= 0.3f)
        {
            goto Label_0025;
        }
    Label_0025:
        if (this.areaAttack != null)
        {
            goto Label_0047;
        }
        this.soldier.SetDamage(this.GetDamage(), 0);
        goto Label_004D;
    Label_0047:
        this.AreaAttack();
    Label_004D:
        return;
    }

    protected void Awake()
    {
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.path = this.stage.GetPath();
        this.active = 0;
        return;
    }

    public virtual unsafe void Block(Soldier mySoldier)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.soldier = mySoldier;
        this.isBlocked = 1;
        if (this.BlockShouldSetIdle() == null)
        {
            goto Label_0072;
        }
        this.RevertToStatic();
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
    Label_0072:
        return;
    }

    public virtual bool BlockShouldSetIdle()
    {
        return (this.isFreeze == 0);
    }

    protected unsafe void BloodDecal()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        if ((this.bloodDecal != null) == null)
        {
            goto Label_007A;
        }
        if (this.canBlood == null)
        {
            goto Label_007A;
        }
        transform = UnityEngine.Object.Instantiate(this.bloodDecal, new Vector3(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y, -2f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform);
    Label_007A:
        return;
    }

    public virtual unsafe void BloodSplatter()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if ((this.bloodSplatter != null) == null)
        {
            goto Label_0083;
        }
        GameSoundManager.PlayHitSound();
        transform = UnityEngine.Object.Instantiate(this.bloodSplatter, new Vector3(&base.transform.position.x, &base.transform.position.y + this.yAdjust, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
    Label_0083:
        return;
    }

    public bool CanBeBlocked()
    {
        return this.canBeBlocked;
    }

    public bool CanBePoisoned()
    {
        return this.canBePoisoned;
    }

    protected virtual bool CanDoSpecial()
    {
        return 1;
    }

    public bool CanTeleport()
    {
        return (this.teleportCount < this.teleportMaxTimes);
    }

    public virtual void ChargeAttack()
    {
        this.creepSprite.PlayAnim("attack");
        this.isCharging = 1;
        if ((base.name == "Spider Tiny") != null)
        {
            goto Label_006B;
        }
        if ((base.name == "Spider Small") != null)
        {
            goto Label_006B;
        }
        if ((base.name == "Spider Rotten") != null)
        {
            goto Label_006B;
        }
        if ((base.name == "Spider Rotten Tiny") == null)
        {
            goto Label_0075;
        }
    Label_006B:
        GameSoundManager.PlaySpiderAttack();
        goto Label_00E3;
    Label_0075:
        if ((base.name == "White Wolf") != null)
        {
            goto Label_00DE;
        }
        if ((base.name == "Demon Wolf") != null)
        {
            goto Label_00DE;
        }
        if ((base.name == "Orc Rider") != null)
        {
            goto Label_00DE;
        }
        if ((base.name == "Wolf Small") != null)
        {
            goto Label_00DE;
        }
        if ((base.name == "Wolf") == null)
        {
            goto Label_00E3;
        }
    Label_00DE:
        GameSoundManager.PlayWolfAttack();
    Label_00E3:
        return;
    }

    public virtual unsafe void CheckFacing()
    {
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        double num;
        Vector3 vector4;
        Vector3 vector5;
        if (this.isStunned == null)
        {
            goto Label_0011;
        }
        this.RevertToStatic();
    Label_0011:
        if (this.path != null)
        {
            goto Label_002D;
        }
        this.path = this.stage.GetPath();
    Label_002D:
        vector = ((this.currentNode + 1) >= ((int) this.path[this.pathIndex][this.subpathIndex].Length)) ? *(&(this.path[this.pathIndex][this.subpathIndex][this.currentNode])) : *(&(this.path[this.pathIndex][this.subpathIndex][this.currentNode + 1]));
        &vector2 = new Vector2(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y);
        vector3 = vector - vector2;
        &vector3.Normalize();
        num = ((double) (Mathf.Atan2(&vector3.y, &vector3.x) * 180f)) / 3.14;
        if (num >= 0.0)
        {
            goto Label_012A;
        }
        num += 360.0;
    Label_012A:
        if (num <= 55.0)
        {
            goto Label_0170;
        }
        if (num >= 135.0)
        {
            goto Label_0170;
        }
        if (this.facing == 1)
        {
            goto Label_0280;
        }
        this.facing = 1;
        this.creepSprite.PlayAnim("walkUp");
        goto Label_0280;
    Label_0170:
        if (num < 135.0)
        {
            goto Label_01DA;
        }
        if (num > 240.0)
        {
            goto Label_01DA;
        }
        if (this.facing == 2)
        {
            goto Label_0280;
        }
        this.facing = 2;
        this.creepSprite.PlayAnim("walk");
        this.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0280;
    Label_01DA:
        if (num <= 240.0)
        {
            goto Label_0239;
        }
        if (num >= 315.0)
        {
            goto Label_0239;
        }
        if (this.facing == null)
        {
            goto Label_0280;
        }
        this.facing = 0;
        if ((base.transform.name != "Golem Head") == null)
        {
            goto Label_0280;
        }
        this.creepSprite.PlayAnim("walkDown");
        goto Label_0280;
    Label_0239:
        if (this.facing == 3)
        {
            goto Label_0280;
        }
        this.facing = 3;
        this.creepSprite.PlayAnim("walk");
        this.creepSprite.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_0280:
        return;
    }

    protected virtual void CheckTunnels()
    {
        if (this.stage.HasTunnels(this.pathIndex) == null)
        {
            goto Label_0138;
        }
        if (this.currentNode != this.stage.TunnelStart(this.pathIndex))
        {
            goto Label_003E;
        }
        this.active = 0;
        goto Label_0138;
    Label_003E:
        if (this.currentNode != this.stage.TunnelStartHide(this.pathIndex))
        {
            goto Label_00BD;
        }
        this.speed *= 2f;
        this.stage.EnterTunnel(this.pathIndex);
        this.Hide(1);
        this.gui.HideInfo(this.clickable);
        this.clickable.UnSelect();
        base.collider.enabled = 0;
        this.HideCurse();
        this.HidePoison();
        goto Label_0138;
    Label_00BD:
        if (this.currentNode != this.stage.TunnelEndShow(this.pathIndex))
        {
            goto Label_0115;
        }
        this.speed = this.originalSpeed;
        this.stage.ExitTunnel(this.pathIndex);
        this.facing = 4;
        this.Hide(0);
        base.collider.enabled = 1;
        goto Label_0138;
    Label_0115:
        if (this.currentNode != this.stage.TunnelEnd(this.pathIndex))
        {
            goto Label_0138;
        }
        this.active = 1;
    Label_0138:
        return;
    }

    public void CreepArmaggedon()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_005A;
        Label_0016:
            transform = (Transform) enumerator.Current;
            if ((transform != base.transform) == null)
            {
                goto Label_005A;
            }
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_005A;
            }
            creep.Gib();
            creep.Damage(0x186a0, 0, 0, 0);
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

    public virtual void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (damageType == null)
        {
            goto Label_0021;
        }
        this.life -= this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002F;
    Label_0021:
        this.life -= dmg;
    Label_002F:
        if (this.life >= 0)
        {
            goto Label_0042;
        }
        this.life = 0;
    Label_0042:
        return;
    }

    public void Desintegrate()
    {
        this.desintegrate = 1;
        return;
    }

    protected void DestroyMe()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    protected virtual void DestroyThis()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    protected virtual void Die()
    {
        if (this.isDead != null)
        {
            goto Label_00CD;
        }
        if ((this.iceBlock != null) == null)
        {
            goto Label_002C;
        }
        UnityEngine.Object.Destroy(this.iceBlock.gameObject);
    Label_002C:
        if (this.gibs == null)
        {
            goto Label_0042;
        }
        this.SpawnGibs();
        goto Label_0075;
    Label_0042:
        if (this.desintegrate == null)
        {
            goto Label_0058;
        }
        this.SpawnDesintegrate();
        goto Label_0075;
    Label_0058:
        this.creepSprite.PlayAnim("death");
        this.isFading = 1;
        this.PlayDeathSound();
    Label_0075:
        if (this.useGold == null)
        {
            goto Label_0091;
        }
        this.stage.AddGold(this.gold);
    Label_0091:
        this.BloodDecal();
        this.isDead = 1;
        this.active = 0;
        this.gui.HideInfo(this.clickable);
        this.clickable.UnSelect();
        base.collider.enabled = 0;
    Label_00CD:
        return;
    }

    public int DistanceInNodes()
    {
        return (this.GetSubPathCount() - this.currentNode);
    }

    public bool DodgeAttack()
    {
        if (this.dodge != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if ((UnityEngine.Random.Range(0f, 1f) * 100f) > ((float) this.dodge))
        {
            goto Label_0030;
        }
        return 1;
    Label_0030:
        return 0;
    }

    protected virtual void DoSpecial()
    {
    }

    public unsafe void DoStun(int time = 60)
    {
        EnemyModifierStun stun;
        Vector3 vector;
        Vector3 vector2;
        this.isStunned = 1;
        this.isCharging = 0;
        this.StopSpecialPower();
        this.RevertToStatic();
        this.stun = UnityEngine.Object.Instantiate(this.stunPrefab, new Vector3(&base.transform.position.x + this.xModifierAdjust, &base.transform.position.y + this.yModifierAdjust, -899f), Quaternion.identity) as Transform;
        this.stun.name = "StunEffect";
        this.stun.parent = base.transform;
        this.stun.GetComponent<EnemyModifierStun>().durationTime = time;
        return;
    }

    protected void EndFreeze()
    {
        this.isStopped = 0;
        this.isFreeze = 0;
        this.creepSprite.SetColor(new Color(1f, 1f, 1f, 1f));
        this.facing = -1;
        if ((this.iceBlock != null) == null)
        {
            goto Label_0061;
        }
        this.iceBlock.PlayAnim("kill");
        this.iceBlock = null;
    Label_0061:
        return;
    }

    public void EndStun()
    {
        if ((this.stun != null) == null)
        {
            goto Label_0028;
        }
        UnityEngine.Object.Destroy(this.stun.gameObject);
        this.stun = null;
    Label_0028:
        this.isStunned = 0;
        this.facing = -1;
        if (this.isBlocked != null)
        {
            goto Label_0052;
        }
        if (this.active == null)
        {
            goto Label_0052;
        }
        this.CheckFacing();
    Label_0052:
        return;
    }

    protected unsafe bool EvalFreeze()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.isFreeze != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        this.freezeTimeCounter += 1;
        if (this.freezeTimeCounter >= this.freezeTime)
        {
            goto Label_002E;
        }
        return 1;
    Label_002E:
        if (this.isBlocked == null)
        {
            goto Label_0092;
        }
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.RevertToStatic();
    Label_0092:
        this.EndFreeze();
        return 0;
    }

    public virtual bool evalRespawn()
    {
        if (this.respawnTimeCounter >= this.respawnTime)
        {
            goto Label_0021;
        }
        this.respawnTimeCounter += 1;
        return 1;
    Label_0021:
        this.isRespawning = 0;
        this.isActive = 1;
        this.facing = -1;
        this.CheckFacing();
        return 1;
    }

    protected virtual bool EvalSpecialBasic()
    {
        if (this.isBasicSpecial != null)
        {
            goto Label_0060;
        }
        if (this.basicCoolddownTimeCounter >= this.basicCooldownTime)
        {
            goto Label_0037;
        }
        if (this.basicIncrementOnFunction == null)
        {
            goto Label_0035;
        }
        this.basicCoolddownTimeCounter += 1;
    Label_0035:
        return 0;
    Label_0037:
        if (this.CanDoSpecial() != null)
        {
            goto Label_0044;
        }
        return 0;
    Label_0044:
        this.isBasicSpecial = 1;
        this.PlaySpecial();
        this.basicAnimationTimeCounter = 0;
        this.PlaySpecialSound();
        return 1;
    Label_0060:
        if (this.basicAnimationTimeCounter >= this.basicAnimationTime)
        {
            goto Label_0098;
        }
        this.basicAnimationTimeCounter += 1;
        if (this.basicAnimationTimeCounter != this.basicAnimationStartTime)
        {
            goto Label_0096;
        }
        this.DoSpecial();
    Label_0096:
        return 1;
    Label_0098:
        this.isBasicSpecial = 0;
        this.basicCoolddownTimeCounter = 0;
        this.facing = -1;
        if (this.isBlocked != null)
        {
            goto Label_00C9;
        }
        if (this.active == null)
        {
            goto Label_00C9;
        }
        this.CheckFacing();
    Label_00C9:
        return 0;
    }

    protected bool EvalThorns()
    {
        if (this.thornDurationCounter >= this.thornDuration)
        {
            goto Label_0068;
        }
        this.thornDurationCounter += Time.deltaTime;
        this.thornDamageTimeCounter += Time.deltaTime;
        if (this.thornDamageTimeCounter < (this.thornDamageTime - 0.01f))
        {
            goto Label_0066;
        }
        this.Damage(this.thornDamage, 1, 0, 0);
        this.thornDamageTimeCounter = 0f;
    Label_0066:
        return 1;
    Label_0068:
        if (this.thornSpecial == null)
        {
            goto Label_00B6;
        }
        this.thornSpecial = 0;
        this.creepSprite.PlayAnim("thornDown");
        this.isStopped = 0;
        this.facing = -1;
        if (this.isBlocked != null)
        {
            goto Label_00B4;
        }
        if (this.active == null)
        {
            goto Label_00B4;
        }
        this.CheckFacing();
    Label_00B4:
        return 1;
    Label_00B6:
        return 0;
    }

    public virtual void ExplodeMe()
    {
        this.life = 0;
        this.BloodSplatter();
        this.AddExplodeEffect();
        return;
    }

    protected virtual void ExtraReachGoalLine()
    {
    }

    protected virtual unsafe void FixedUpdate()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isFading == null)
        {
            goto Label_003D;
        }
        this.fadingTimeCounter += 1;
        if (this.fadingTimeCounter != this.fadingTime)
        {
            goto Label_003C;
        }
        this.DestroyThis();
    Label_003C:
        return;
    Label_003D:
        this.UpdateLifeBar();
        if (this.life > 0)
        {
            goto Label_00D9;
        }
        GameAchievements.KillEnemy();
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.HidePoison();
        this.HideRage();
        this.HideCurse();
        this.EndStun();
        this.RemoveBurnModifier();
        this.ToGraveyard();
        this.Die();
        this.active = 0;
        return;
    Label_00D9:
        if (this.EvalFreeze() == null)
        {
            goto Label_00E5;
        }
        return;
    Label_00E5:
        if (this.isRespawning == null)
        {
            goto Label_00FC;
        }
        if (this.evalRespawn() == null)
        {
            goto Label_00FC;
        }
        return;
    Label_00FC:
        if (this.canRegenerate == null)
        {
            goto Label_010D;
        }
        this.Regenerate();
    Label_010D:
        if (this.EvalThorns() == null)
        {
            goto Label_0119;
        }
        return;
    Label_0119:
        if (this.isStunned == null)
        {
            goto Label_0125;
        }
        return;
    Label_0125:
        this.SpecialPasivePower();
        if (this.life > 0)
        {
            goto Label_0138;
        }
        return;
    Label_0138:
        this.UpdateSpecialPowerCooldowns();
        if (this.active == null)
        {
            goto Label_0160;
        }
        if (this.isCharging != null)
        {
            goto Label_0160;
        }
        if (this.SpecialPower() == null)
        {
            goto Label_0160;
        }
        return;
    Label_0160:
        if (this.isBlocked == null)
        {
            goto Label_01B9;
        }
        if (this.isCharging == null)
        {
            goto Label_0181;
        }
        if (this.ShouldTruncateAttack() == null)
        {
            goto Label_01B9;
        }
    Label_0181:
        if ((this.soldier == null) != null)
        {
            goto Label_01B2;
        }
        if (this.soldier.IsActive() == null)
        {
            goto Label_01B2;
        }
        if (this.soldier.IsFighting() != null)
        {
            goto Label_01B9;
        }
    Label_01B2:
        this.StopFighting();
        return;
    Label_01B9:
        if (this.isFighting == null)
        {
            goto Label_0263;
        }
        if (this.isCharging == null)
        {
            goto Label_01DA;
        }
        if (this.ShouldTruncateAttack() == null)
        {
            goto Label_0206;
        }
    Label_01DA:
        if ((this.soldier == null) != null)
        {
            goto Label_01FB;
        }
        if (this.soldier.IsActive() != null)
        {
            goto Label_0206;
        }
    Label_01FB:
        this.StopFighting();
        goto Label_025E;
    Label_0206:
        if (this.isCharging == null)
        {
            goto Label_0257;
        }
        if (this.ReadyToDamage() != null)
        {
            goto Label_021D;
        }
        return;
    Label_021D:
        this.isCharging = 0;
        this.Attack();
        if (this.isDead != null)
        {
            goto Label_0240;
        }
        if (this.active != null)
        {
            goto Label_0241;
        }
    Label_0240:
        return;
    Label_0241:
        if (this.isDead == null)
        {
            goto Label_0274;
        }
        this.StopFighting();
        goto Label_025E;
    Label_0257:
        this.ReadyToAttack();
    Label_025E:
        goto Label_0274;
    Label_0263:
        if (this.teleporting != null)
        {
            goto Label_0274;
        }
        this.Move();
    Label_0274:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_02B5;
        }
        this.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_02D4;
    Label_02B5:
        this.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_02D4:
        return;
    }

    public string GetArmor()
    {
        if (this.armor != null)
        {
            goto Label_0011;
        }
        return "None";
    Label_0011:
        if (this.armor < 1)
        {
            goto Label_0030;
        }
        if (this.armor > 30)
        {
            goto Label_0030;
        }
        return "Low";
    Label_0030:
        if (this.armor < 0x1f)
        {
            goto Label_0050;
        }
        if (this.armor > 60)
        {
            goto Label_0050;
        }
        return "Medium";
    Label_0050:
        if (this.armor < 0x3d)
        {
            goto Label_0070;
        }
        if (this.armor > 90)
        {
            goto Label_0070;
        }
        return "High";
    Label_0070:
        if (this.armor < 90)
        {
            goto Label_0083;
        }
        return "Great";
    Label_0083:
        return string.Empty;
    }

    public virtual int GetArmorDamage(Constants.damageType damageType, int damage, int ignoreArmor)
    {
        int num;
        Constants.damageType type;
        num = this.armor;
        if (ignoreArmor == null)
        {
            goto Label_001A;
        }
        num -= ignoreArmor;
        if (num >= 0)
        {
            goto Label_001A;
        }
        num = 0;
    Label_001A:
        type = damageType;
        switch ((type - 1))
        {
            case 0:
                goto Label_0035;

            case 1:
                goto Label_003E;

            case 2:
                goto Label_004C;
        }
        goto Label_0057;
    Label_0035:
        return (damage - ((num * damage) / 100));
    Label_003E:
        return (damage - ((this.magicArmor * damage) / 100));
    Label_004C:
        return (damage - (((num / 2) * damage) / 100));
    Label_0057:
        return damage;
    }

    protected virtual Vector2 GetAttackPoint()
    {
        return Vector2.zero;
    }

    public int GetCurrentNodeIndex()
    {
        return this.currentNode;
    }

    public int GetCurrentPath()
    {
        return this.pathIndex;
    }

    public int GetCurrentSubPath()
    {
        return this.subpathIndex;
    }

    protected int GetDamage()
    {
        return (this.minDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.maxDamage - this.minDamage))));
    }

    public int GetFighterPosition()
    {
        if (this.fighterPositionOne != null)
        {
            goto Label_001B;
        }
        this.fighterPositionOne += 1;
        return 0;
    Label_001B:
        if (this.fighterPositionTwo != null)
        {
            goto Label_0036;
        }
        this.fighterPositionTwo += 1;
        return 1;
    Label_0036:
        if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
        {
            goto Label_005F;
        }
        this.fighterPositionOne += 1;
        return 0;
    Label_005F:
        this.fighterPositionTwo += 1;
        return 1;
    }

    public int GetHealth()
    {
        return this.life;
    }

    public string GetMagicArmor()
    {
        if (this.magicArmor != null)
        {
            goto Label_0011;
        }
        return "None";
    Label_0011:
        if (this.magicArmor < 1)
        {
            goto Label_0030;
        }
        if (this.magicArmor > 30)
        {
            goto Label_0030;
        }
        return "Low";
    Label_0030:
        if (this.magicArmor < 0x1f)
        {
            goto Label_0050;
        }
        if (this.magicArmor > 60)
        {
            goto Label_0050;
        }
        return "Medium";
    Label_0050:
        if (this.magicArmor < 0x3d)
        {
            goto Label_0070;
        }
        if (this.magicArmor > 90)
        {
            goto Label_0070;
        }
        return "High";
    Label_0070:
        if (this.magicArmor < 90)
        {
            goto Label_0083;
        }
        return "Great";
    Label_0083:
        return string.Empty;
    }

    public EnemyModifier GetModifier(string type)
    {
        return (base.GetComponent(type) as EnemyModifier);
    }

    public unsafe Vector2 GetNode(int offset)
    {
        int num;
        num = this.currentNode + offset;
        if (num < ((int) this.path[this.pathIndex][this.subpathIndex].Length))
        {
            goto Label_004A;
        }
        return *(&(this.path[this.pathIndex][this.subpathIndex][this.currentNode]));
    Label_004A:
        return *(&(this.path[this.pathIndex][this.subpathIndex][num]));
    }

    public int GetNodesSpeed()
    {
        int num;
        int num2;
        if (this.path != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isBlocked == null)
        {
            goto Label_001A;
        }
        return 0;
    Label_001A:
        if (this.isStopped == null)
        {
            goto Label_0027;
        }
        return 0;
    Label_0027:
        num = Mathf.CeilToInt(4f * this.speed);
        num2 = (int) this.path[this.pathIndex][this.subpathIndex].Length;
        if ((this.currentNode + num) < num2)
        {
            goto Label_0069;
        }
        return ((num2 - this.currentNode) - 1);
    Label_0069:
        return num;
    }

    public float GetOriginalSpeed()
    {
        return this.originalSpeed;
    }

    public Vector2[] GetPath(int i)
    {
        return this.path[this.pathIndex][i];
    }

    public float GetSpeed()
    {
        return this.speed;
    }

    public Vector2 GetSpeedVector()
    {
        return new Vector2(this.xSpeed, this.ySpeed);
    }

    public int GetSubPathCount()
    {
        return (int) this.path[this.pathIndex][this.subpathIndex].Length;
    }

    public int GetTotalArmor()
    {
        return this.totalArmor;
    }

    public int GetTotalLife()
    {
        return this.totalLife;
    }

    public void Gib()
    {
        if (this.canGib == null)
        {
            goto Label_001D;
        }
        if (this.isBoss != null)
        {
            goto Label_001D;
        }
        this.gibs = 1;
    Label_001D:
        return;
    }

    public bool HasModifier(string type)
    {
        Transform transform;
        return (base.transform.Find(type) != null);
    }

    public bool HasRageModifier()
    {
        if (this.canRage == null)
        {
            goto Label_0028;
        }
        if ((base.transform.FindChild("Rage") != null) == null)
        {
            goto Label_0028;
        }
        return 1;
    Label_0028:
        return 0;
    }

    public void Heal(int healingPoints)
    {
        Transform transform;
        this.life += healingPoints;
        if (this.life <= this.totalLife)
        {
            goto Label_002B;
        }
        this.life = this.totalLife;
    Label_002B:
        transform = UnityEngine.Object.Instantiate(this.healingPrefab, base.transform.position + new Vector3(this.xModifierAdjust, this.yModifierAdjust, 0f), Quaternion.identity) as Transform;
        transform.name = "healEffect";
        transform.parent = base.transform;
        return;
    }

    protected void Hide(bool h)
    {
        Transform transform;
        this.creepSprite.Hide(h);
        this.mainBar.gameObject.SetActive(h == 0);
        transform = base.transform.FindChild("Rage");
        if ((transform != null) == null)
        {
            goto Label_0049;
        }
        transform.GetComponent<PackedSprite>().Hide(h);
    Label_0049:
        return;
    }

    public void HideCurse()
    {
        if ((this.curseEffect != null) == null)
        {
            goto Label_001D;
        }
        this.curseEffect.Hide(1);
    Label_001D:
        return;
    }

    public void HidePoison()
    {
        if ((this.poisonEffect != null) == null)
        {
            goto Label_001D;
        }
        this.poisonEffect.Hide(1);
    Label_001D:
        return;
    }

    protected void HideRage()
    {
        Transform transform;
        transform = base.transform.FindChild("Rage");
        if ((transform != null) == null)
        {
            goto Label_0029;
        }
        transform.GetComponent<PackedSprite>().Hide(1);
    Label_0029:
        return;
    }

    public void HideTeslaHit()
    {
        if ((this.teslaEffect != null) == null)
        {
            goto Label_001D;
        }
        this.teslaEffect.Hide(1);
    Label_001D:
        return;
    }

    public unsafe void HitFreeze(int pTime)
    {
        Transform transform;
        Vector3 vector;
        float num;
        this.freezeTime = pTime;
        this.freezeTimeCounter = 0;
        this.isStopped = 1;
        if (this.isFreeze == null)
        {
            goto Label_0021;
        }
        return;
    Label_0021:
        this.isFreeze = 1;
        this.creepSprite.SetColor(new Color(0.6235294f, 0.9176471f, 1f, 1f));
        if (this.facing != 1)
        {
            goto Label_0078;
        }
        this.creepSprite.PlayAnim("walkUp");
        this.creepSprite.PauseAnim();
        goto Label_0186;
    Label_0078:
        if (this.facing != 2)
        {
            goto Label_00EC;
        }
        this.creepSprite.PlayAnim("walk");
        this.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        this.mainBar.transform.localScale = new Vector3(-1f, 1f, 1f);
        this.creepSprite.PauseAnim();
        goto Label_0186;
    Label_00EC:
        if (this.facing != null)
        {
            goto Label_0117;
        }
        this.creepSprite.PlayAnim("walkDown");
        this.creepSprite.PauseAnim();
        goto Label_0186;
    Label_0117:
        if (this.facing != 3)
        {
            goto Label_0186;
        }
        this.creepSprite.PlayAnim("walk");
        this.creepSprite.transform.localScale = new Vector3(1f, 1f, 1f);
        this.mainBar.transform.localScale = new Vector3(1f, 1f, 1f);
        this.creepSprite.PauseAnim();
    Label_0186:
        if ((this.iceBlock == null) == null)
        {
            goto Label_026C;
        }
        transform = UnityEngine.Object.Instantiate(this.iceBlockPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.iceBlock = transform.GetComponent<PackedSprite>();
        if (this.isFlying != null)
        {
            goto Label_0202;
        }
        &vector = new Vector3(0f, this.clickable.yOffset - 3f, -1f);
        goto Label_0265;
    Label_0202:
        num = 0f;
        if (this.facing == 1)
        {
            goto Label_021F;
        }
        if (this.facing != null)
        {
            goto Label_022A;
        }
    Label_021F:
        num = -6f;
        goto Label_0253;
    Label_022A:
        if (this.facing != 2)
        {
            goto Label_0241;
        }
        num = 8f;
        goto Label_0253;
    Label_0241:
        if (this.facing != 3)
        {
            goto Label_0253;
        }
        num = -6f;
    Label_0253:
        &vector = new Vector3(num, -13f, -1f);
    Label_0265:
        transform.localPosition = vector;
    Label_026C:
        return;
    }

    protected virtual void InitCustomSettings()
    {
    }

    public unsafe void InitPosition()
    {
        Transform transform1;
        base.transform.position = *(&(this.path[this.pathIndex][this.subpathIndex][this.currentNode]));
        transform1 = base.transform;
        transform1.position -= new Vector3(&this.anchorPoint.x, &this.anchorPoint.y, 0f);
        this.CheckTunnels();
        return;
    }

    public void InitSprite()
    {
        this.creepSprite = base.GetComponent<PackedSprite>();
        return;
    }

    public bool IsActive()
    {
        return this.active;
    }

    public bool IsBlocked()
    {
        return this.isBlocked;
    }

    public bool IsBoss()
    {
        return this.isBoss;
    }

    public virtual bool IsDead()
    {
        return ((this.life > 0) == 0);
    }

    public bool IsFighting()
    {
        return this.isFighting;
    }

    protected unsafe bool IsNear(int node)
    {
        Vector2 vector;
        Vector2 vector2;
        Vector3 vector3;
        Vector3 vector4;
        &vector = new Vector2(&base.transform.position.x, &base.transform.position.y);
        vector2 = vector - *(&(this.path[this.pathIndex][this.subpathIndex][node]));
        return (Mathf.Abs(&vector2.magnitude) < 0.75f);
    }

    public bool IsPoisonActive()
    {
        if ((base.GetComponent<EnemyModifierPoison>() == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return (this.poisonEffect.IsHidden() == 0);
    }

    public bool IsPolymorphable()
    {
        return this.polymorphable;
    }

    public bool IsStopped()
    {
        return this.isStopped;
    }

    public bool IsThorned()
    {
        return this.thornSpecial;
    }

    protected unsafe void Move()
    {
        Vector2 vector;
        float num;
        float num2;
        float num3;
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
        if (this.isBlocked == null)
        {
            goto Label_0022;
        }
        this.xSpeed = 0f;
        this.ySpeed = 0f;
        return;
    Label_0022:
        if ((this.currentNode + 1) < ((int) this.path[this.pathIndex][this.subpathIndex].Length))
        {
            goto Label_00A6;
        }
        if (this.ReachGoalLine() == null)
        {
            goto Label_00A6;
        }
        this.stage.RemoveLives(this.cost);
        this.gui.HideInfo(this.clickable);
        if ((this.clickable != null) == null)
        {
            goto Label_008E;
        }
        this.clickable.UnSelect();
    Label_008E:
        base.collider.enabled = 0;
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_00A6:
        vector = *(&(this.path[this.pathIndex][this.subpathIndex][this.currentNode + 1]));
        vector -= new Vector2(&this.anchorPoint.x, &this.anchorPoint.y);
        num = &vector.y - &base.transform.position.y;
        num2 = &vector.x - &base.transform.position.x;
        num3 = Mathf.Atan2(num, num2);
        this.ySpeed = Mathf.Sin(num3) * this.speed;
        this.xSpeed = Mathf.Cos(num3) * this.speed;
        base.transform.position = new Vector3(&base.transform.position.x + this.xSpeed, &base.transform.position.y + this.ySpeed, &base.transform.position.z);
        float introduced14 = Mathf.Pow(&vector.y - &base.transform.position.y, 2f);
        if (Mathf.Sqrt(introduced14 + Mathf.Pow(&vector.x - &base.transform.position.x, 2f)) >= (this.speed + 0.18f))
        {
            goto Label_02EE;
        }
        this.currentNode += 1;
        if (this.ReachGoalLine() == null)
        {
            goto Label_022E;
        }
        return;
    Label_022E:
        if (this.currentNode < (((int) this.path[this.pathIndex][this.subpathIndex].Length) - 1))
        {
            goto Label_0296;
        }
        this.stage.RemoveLives(this.cost);
        this.gui.HideInfo(this.clickable);
        this.clickable.UnSelect();
        base.collider.enabled = 0;
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0296:
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, &base.transform.position.z);
        this.CheckTunnels();
        this.CheckFacing();
    Label_02EE:
        return;
    }

    protected virtual bool OnRange(Soldier mySoldier)
    {
        if ((mySoldier == null) == null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), (float) this.areaAttackRangeHeight, (float) this.areaAttackRangeWidth, this.areaAttackPoint);
    }

    public virtual void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        Skeleton skeleton;
        Transform transform2;
        Transform transform3;
        EnemyModifierTar tar;
        Transform transform4;
        IDisposable disposable;
        this.isPaused = 1;
        this.wasAnimating = this.creepSprite.IsAnimating();
        this.creepSprite.PauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_002F:
        try
        {
            goto Label_0059;
        Label_0034:
            transform = (Transform) enumerator.Current;
            sprite = transform.GetComponent<PackedSprite>();
            if ((sprite != null) == null)
            {
                goto Label_0059;
            }
            sprite.PauseAnim();
        Label_0059:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0034;
            }
            goto Label_007E;
        }
        finally
        {
        Label_0069:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0076;
            }
        Label_0076:
            disposable.Dispose();
        }
    Label_007E:
        skeleton = base.GetComponent<Skeleton>();
        if ((skeleton != null) == null)
        {
            goto Label_0097;
        }
        skeleton.Pause();
    Label_0097:
        if ((this.curseEffect != null) == null)
        {
            goto Label_00CE;
        }
        if (this.curseEffect.IsHidden() != null)
        {
            goto Label_00CE;
        }
        this.curseEffect.PauseAnim();
        base.GetComponent<EnemyModifierCurse>().Pause();
    Label_00CE:
        if ((this.poisonEffect != null) == null)
        {
            goto Label_0105;
        }
        if (this.poisonEffect.IsHidden() != null)
        {
            goto Label_0105;
        }
        this.poisonEffect.PauseAnim();
        base.GetComponent<EnemyModifierPoison>().Pause();
    Label_0105:
        transform2 = base.transform.FindChild("Rage");
        if ((transform2 != null) == null)
        {
            goto Label_0130;
        }
        transform2.GetComponent<EnemyModifierRage>().Pause();
    Label_0130:
        transform3 = base.transform.FindChild("StunEffect");
        if ((transform3 != null) == null)
        {
            goto Label_015B;
        }
        transform3.GetComponent<EnemyModifierStun>().Pause();
    Label_015B:
        tar = base.GetComponent<EnemyModifierTar>();
        if ((tar != null) == null)
        {
            goto Label_0177;
        }
        tar.Pause();
    Label_0177:
        transform4 = base.transform.FindChild("healEffect");
        if ((transform4 != null) == null)
        {
            goto Label_01A2;
        }
        transform4.GetComponent<PackedSprite>().PauseAnim();
    Label_01A2:
        if ((this.teslaEffect != null) == null)
        {
            goto Label_01BE;
        }
        this.teslaEffect.PauseAnim();
    Label_01BE:
        return;
    }

    protected virtual void PlayDeathSound()
    {
        if ((base.name == "Fat Orc") != null)
        {
            goto Label_002A;
        }
        if ((base.name == "Orc Champion") == null)
        {
            goto Label_0034;
        }
    Label_002A:
        GameSoundManager.PlayDeathOrc();
        goto Label_03BD;
    Label_0034:
        if ((base.name == "Goblin") != null)
        {
            goto Label_0073;
        }
        if ((base.name == "Shaman") != null)
        {
            goto Label_0073;
        }
        if ((base.name == "Golem Head") == null)
        {
            goto Label_007D;
        }
    Label_0073:
        GameSoundManager.PlayDeathGoblin();
        goto Label_03BD;
    Label_007D:
        if ((base.name == "Demon") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Demon Mage") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Demon Wolf") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Demon Imp") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Gargoyle") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Necromancer") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Orc Rider") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "White Wolf") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Wolf") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Demon Legion") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Gulaemon") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Cerberus") != null)
        {
            goto Label_018E;
        }
        if ((base.name == "Wolf Small") == null)
        {
            goto Label_0198;
        }
    Label_018E:
        GameSoundManager.PlayDeathPuff();
        goto Label_03BD;
    Label_0198:
        if ((base.name == "Troll") != null)
        {
            goto Label_01EC;
        }
        if ((base.name == "Troll Axe Thrower") != null)
        {
            goto Label_01EC;
        }
        if ((base.name == "Troll Skater") != null)
        {
            goto Label_01EC;
        }
        if ((base.name == "Troll Brute") == null)
        {
            goto Label_01F6;
        }
    Label_01EC:
        GameSoundManager.PlayDeathTroll();
        goto Label_03BD;
    Label_01F6:
        if ((base.name == "Rotten Tree") != null)
        {
            goto Label_024A;
        }
        if ((base.name == "Skeleton") != null)
        {
            goto Label_024A;
        }
        if ((base.name == "Skeleton Warrior") != null)
        {
            goto Label_024A;
        }
        if ((base.name == "Zombie") == null)
        {
            goto Label_0254;
        }
    Label_024A:
        GameSoundManager.PlayDeathSkeleton();
        goto Label_03BD;
    Label_0254:
        if ((base.name == "Forest Troll") != null)
        {
            goto Label_02D2;
        }
        if ((base.name == "Gulthak") != null)
        {
            goto Label_02D2;
        }
        if ((base.name == "Ogre") != null)
        {
            goto Label_02D2;
        }
        if ((base.name == "Swamp Thing") != null)
        {
            goto Label_02D2;
        }
        if ((base.name == "Troll Chieftain") != null)
        {
            goto Label_02D2;
        }
        if ((base.name == "Yeti") == null)
        {
            goto Label_02DC;
        }
    Label_02D2:
        GameSoundManager.PlayDeathBig();
        goto Label_03BD;
    Label_02DC:
        if ((base.name == "Bandit") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Brigand") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Dark Knight") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Goblin Zapper") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Marauder") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Raider") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Shadow Archer") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Slayer") != null)
        {
            goto Label_0399;
        }
        if ((base.name == "Pillager") == null)
        {
            goto Label_03A3;
        }
    Label_0399:
        GameSoundManager.PlayDeathHuman();
        goto Label_03BD;
    Label_03A3:
        if ((base.name == "Lava Elemental") == null)
        {
            goto Label_03BD;
        }
        GameSoundManager.PlayRockElementalDeath();
    Label_03BD:
        return;
    }

    protected virtual void PlaySpecial()
    {
    }

    protected virtual void PlaySpecialSound()
    {
    }

    public unsafe void PopHeadshot()
    {
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        if ((this.popHeadshotPrefab == null) == null)
        {
            goto Label_002C;
        }
        Debug.Log(base.transform.name + " pop null");
        return;
    Label_002C:
        &vector = new Vector3(&base.transform.position.x + this.xAdjust, &base.transform.position.y + this.yAdjust, -800f);
        transform = UnityEngine.Object.Instantiate(this.popHeadshotPrefab, vector, Quaternion.identity) as Transform;
        return;
    }

    protected bool ReachGoalLine()
    {
        if ((this.currentNode - 1) != this.roadNodesTillActive)
        {
            goto Label_001C;
        }
        this.active = 1;
        return 0;
    Label_001C:
        if ((this.currentNode + 11) != ((int) this.path[this.pathIndex][this.subpathIndex].Length))
        {
            goto Label_0049;
        }
        this.active = 0;
        return 0;
    Label_0049:
        this.ExtraReachGoalLine();
        if ((this.currentNode + 7) >= ((int) this.path[this.pathIndex][this.subpathIndex].Length))
        {
            goto Label_0074;
        }
        return 0;
    Label_0074:
        this.active = 0;
        return 1;
    }

    protected bool ReadyToAttack()
    {
        this.attackReloadTimeCounter += 1;
        if (this.attackReloadTimeCounter != this.attackReloadTime)
        {
            goto Label_0035;
        }
        this.ChargeAttack();
        this.attackReloadTimeCounter = 0;
        this.attackIsDodged = 0;
        return 1;
    Label_0035:
        return 0;
    }

    protected virtual bool ReadyToDamage()
    {
        this.attackChargeTimeCounter += 1;
        if (this.attackChargeTimeCounter != this.attackChargeTime)
        {
            goto Label_0028;
        }
        this.attackChargeTimeCounter = 0;
        return 1;
    Label_0028:
        if (this.attackChargeTimeCounter != this.attackDodgeTime)
        {
            goto Label_0082;
        }
        if ((this.soldier != null) == null)
        {
            goto Label_0082;
        }
        if (this.soldier.IsActive() == null)
        {
            goto Label_0082;
        }
        if (this.soldier.DodgeHit() == null)
        {
            goto Label_0082;
        }
        this.soldier.SetDodgeDamage(this.GetDamage());
        this.attackIsDodged = 1;
    Label_0082:
        return 0;
    }

    protected virtual void Regenerate()
    {
        if (this.regenerateTimeCounter >= this.regenerateTime)
        {
            goto Label_0020;
        }
        this.regenerateTimeCounter += 1;
        return;
    Label_0020:
        this.life += this.regenerateHealPoints;
        if (this.life <= this.totalLife)
        {
            goto Label_0050;
        }
        this.life = this.totalLife;
    Label_0050:
        this.regenerateTimeCounter = 0;
        return;
    }

    protected void RemoveAllSlowModifiers()
    {
        EnemyModifierSlow slow;
        EnemyModifierTar tar;
        slow = base.GetComponent<EnemyModifierSlow>();
        tar = base.GetComponent<EnemyModifierTar>();
        if ((slow != null) == null)
        {
            goto Label_0020;
        }
        UnityEngine.Object.Destroy(slow);
    Label_0020:
        if ((tar != null) == null)
        {
            goto Label_0032;
        }
        UnityEngine.Object.Destroy(tar);
    Label_0032:
        this.speed = this.originalSpeed;
        return;
    }

    public void RemoveArmor(int quantity)
    {
        this.armor -= quantity;
        if (this.armor >= 0)
        {
            goto Label_0021;
        }
        this.armor = 0;
    Label_0021:
        return;
    }

    public void RemoveBurnModifier()
    {
        if ((this.burnEffect != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.burnEffect.gameObject);
    Label_0021:
        return;
    }

    public void ResetSpeed()
    {
        this.speed = this.originalSpeed;
        return;
    }

    protected virtual void RevertToStatic()
    {
        this.creepSprite.RevertToStatic();
        return;
    }

    public void SetActive(bool a)
    {
        this.active = a;
        return;
    }

    public void SetCurrentNode(int n)
    {
        this.currentNode = n;
        return;
    }

    public void SetDamageArmor(int reduceArmor)
    {
        if (this.armor != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.armor -= reduceArmor;
        if (this.armor >= 0)
        {
            goto Label_002D;
        }
        this.armor = 0;
    Label_002D:
        return;
    }

    public void SetPathIndex(int index)
    {
        this.pathIndex = index;
        return;
    }

    public void SetSoldier(Soldier s)
    {
        this.soldier = s;
        return;
    }

    public void SetSubPath(int i)
    {
        this.subpathIndex = i;
        return;
    }

    public void SetUseGold(bool use)
    {
        this.useGold = use;
        return;
    }

    protected virtual bool ShouldTruncateAttack()
    {
        return 1;
    }

    protected void Show(SpriteBase sprt)
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        UnityEngine.Object.Destroy(this.teleportEffect.gameObject);
        this.creepSprite.Hide(0);
        this.RevertToStatic();
        this.active = 1;
        this.teleporting = 0;
        this.facing = 4;
        this.CheckFacing();
        this.Move();
        return;
    }

    public void ShowCurse()
    {
        Transform transform1;
        Transform transform;
        if ((this.curseEffect == null) == null)
        {
            goto Label_007B;
        }
        transform = UnityEngine.Object.Instantiate(this.cursePrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform1 = transform.transform;
        transform1.position += new Vector3(this.xModifierAdjust, this.yModifierAdjust, -1f);
        this.curseEffect = transform.GetComponent<PackedSprite>();
        goto Label_0093;
    Label_007B:
        this.curseEffect.Hide(0);
        this.curseEffect.PlayAnim(0);
    Label_0093:
        return;
    }

    public void ShowPoison()
    {
        Transform transform1;
        Transform transform;
        if ((this.poisonEffect == null) == null)
        {
            goto Label_007B;
        }
        transform = UnityEngine.Object.Instantiate(this.poisonPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform1 = transform.transform;
        transform1.position += new Vector3(this.xModifierAdjust, this.yModifierAdjust, -1f);
        this.poisonEffect = transform.GetComponent<PackedSprite>();
        goto Label_00A3;
    Label_007B:
        if (this.poisonEffect.IsHidden() == null)
        {
            goto Label_00A3;
        }
        this.poisonEffect.Hide(0);
        this.poisonEffect.PlayAnim(0);
    Label_00A3:
        return;
    }

    public unsafe void ShowSmoke()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.smokePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -800f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform);
        return;
    }

    public void ShowTeslaHit()
    {
        Transform transform1;
        Transform transform;
        if (this.life <= 0)
        {
            goto Label_009E;
        }
        if ((this.teslaEffect == null) == null)
        {
            goto Label_0086;
        }
        transform = UnityEngine.Object.Instantiate(this.teslaHitPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform1 = transform.transform;
        transform1.position += new Vector3(0f, this.yModifierAdjust, -1f);
        this.teslaEffect = transform.GetComponent<PackedSprite>();
        goto Label_009E;
    Label_0086:
        this.teslaEffect.Hide(0);
        this.teslaEffect.PlayAnim(0);
    Label_009E:
        return;
    }

    public void SpawnDesintegrate()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.desintegratePrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = null;
        this.stage.AddEffect(transform);
        this.creepSprite.Hide(1);
        base.Invoke("DestroyMe", 0.25f);
        return;
    }

    protected void SpawnGibs()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.gibsPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = null;
        this.stage.AddEffect(transform);
        GameSoundManager.PlayDeathExplosion();
        this.creepSprite.Hide(1);
        base.Invoke("DestroyMe", 0.25f);
        return;
    }

    protected virtual void SpecialPasivePower()
    {
    }

    protected virtual bool SpecialPower()
    {
        if (this.hasBasicSpecialAction == null)
        {
            goto Label_0018;
        }
        if (this.EvalSpecialBasic() == null)
        {
            goto Label_0018;
        }
        return 1;
    Label_0018:
        return 0;
    }

    protected unsafe void Start()
    {
        string str;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        this.popHeadshotPrefab = Resources.Load("Prefabs/Particles & fx/PopHeadshot", typeof(Transform)) as Transform;
        this.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.creepSprite = base.transform.GetComponent("PackedSprite") as PackedSprite;
        this.clickable = base.GetComponent<UnitClickable>();
        this.facing = 4;
        this.isStopped = 0;
        this.totalLife = this.life;
        this.gibs = 0;
        this.desintegrate = 0;
        this.totalArmor = this.armor;
        this.totalMagicArmor = this.magicArmor;
        this.thornSpecial = 0;
        this.thornCount = 0;
        this.thornMaxTimes = 3;
        this.thornDamageTimeCounter = 0f;
        this.thornDamageTime = 1f;
        this.thornDurationCounter = 0f;
        this.thornDamage = 0;
        this.teleportCount = 0;
        this.teleportMaxTimes = 3;
        this.fighterPositionOne = 0;
        this.fighterPositionTwo = 0;
        this.isFighting = 0;
        this.isCharging = 0;
        this.isBlocked = 0;
        this.canBeBlocked = 1;
        this.isDead = 0;
        this.isActive = 0;
        this.basicIncrementOnFunction = 1;
        this.originalSpeed = this.speed;
        this.mainBar = UnityEngine.Object.Instantiate(this.lifeBarPrefab, new Vector3(&base.transform.position.x + ((float) this.xLifebarOffset), &base.transform.position.y + ((float) this.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        this.mainBar.parent = base.transform;
        this.lifeBar = this.mainBar.FindChild("Bar");
        this.iceBlock = null;
        str = string.Empty;
        if (this.isFlying == null)
        {
            goto Label_01E5;
        }
        str = "Prefabs/CreepIceBlockFlying";
        goto Label_01EB;
    Label_01E5:
        str = "Prefabs/CreepIceBlock";
    Label_01EB:
        this.iceBlockPrefab = Resources.Load(str, typeof(Transform)) as Transform;
        this.InitCustomSettings();
        if ((base.transform.name == "Demon Imp") == null)
        {
            goto Label_0272;
        }
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 10f, -780f);
        UnityEngine.Object.Instantiate(this.portalVeznanImp, vector, Quaternion.identity);
    Label_0272:
        return;
    }

    public virtual unsafe void StartFighting()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.isFighting = 1;
        if (this.StartFightingShouldSetChargeAttack() == null)
        {
            goto Label_006B;
        }
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.ChargeAttack();
    Label_006B:
        return;
    }

    public virtual bool StartFightingShouldSetChargeAttack()
    {
        return (this.isFreeze == 0);
    }

    public virtual void StopFighting()
    {
        this.isBlocked = 0;
        this.isFighting = 0;
        this.isCharging = 0;
        this.soldier = null;
        this.facing = -1;
        this.CheckFacing();
        return;
    }

    protected virtual void StopSpecialPower()
    {
        this.thornSpecial = 0;
        this.teleporting = 0;
        if (this.hasBasicSpecialAction == null)
        {
            goto Label_0020;
        }
        this.isBasicSpecial = 0;
    Label_0020:
        return;
    }

    protected unsafe void TeleportEnd(SpriteBase sprt)
    {
        Vector2 vector;
        Transform transform;
        Vector3 vector2;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.active != null)
        {
            goto Label_0141;
        }
        if (this.path != null)
        {
            goto Label_0033;
        }
        this.path = this.stage.GetPath();
    Label_0033:
        if (this.currentNode >= 0)
        {
            goto Label_0046;
        }
        this.currentNode = 0;
    Label_0046:
        UnityEngine.Object.Destroy(this.teleportEffect.gameObject);
        vector = *(&(this.path[this.pathIndex][this.subpathIndex][this.currentNode]));
        vector -= new Vector2(&this.anchorPoint.x, &this.anchorPoint.y);
        base.transform.position = new Vector3(&vector.x, &vector.y, &base.transform.position.z - 1f);
        transform = UnityEngine.Object.Instantiate(this.teleportPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.GetComponent<PackedSprite>().SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.Show));
        transform.parent = base.transform;
        this.teleportEffect = transform;
        this.isBlocked = 0;
        this.isFighting = 0;
        this.isCharging = 0;
        this.soldier = null;
        this.StopSpecialPower();
    Label_0141:
        return;
    }

    public void TeleportStart(int nodes)
    {
        Transform transform;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.active = 0;
        this.teleporting = 1;
        this.creepSprite.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.teleportPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.GetComponent<PackedSprite>().SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.TeleportEnd));
        transform.parent = base.transform;
        this.teleportEffect = transform;
        this.teleportCount += 1;
        this.currentNode -= nodes;
        if (this.currentNode >= 0)
        {
            goto Label_00A0;
        }
        this.currentNode = 0;
    Label_00A0:
        if (this.stage.HasTunnels(this.pathIndex) == null)
        {
            goto Label_0107;
        }
        if (this.stage.TunnelStart(this.pathIndex) > this.currentNode)
        {
            goto Label_0107;
        }
        if (this.currentNode > this.stage.TunnelEnd(this.pathIndex))
        {
            goto Label_0107;
        }
        this.currentNode = this.stage.TunnelStart(this.pathIndex) - 5;
    Label_0107:
        if (this.thornSpecial == null)
        {
            goto Label_012E;
        }
        this.thornSpecial = 0;
        this.isStopped = 0;
        this.facing += 1;
    Label_012E:
        return;
    }

    protected void ToGraveyard()
    {
        Graveyard graveyard;
        graveyard = this.stage.GetComponent<Graveyard>();
        if ((graveyard != null) == null)
        {
            goto Label_003A;
        }
        if (this.canSkeleton == null)
        {
            goto Label_003A;
        }
        if (this.active == null)
        {
            goto Label_003A;
        }
        graveyard.SpawnSkeleton(this.totalLife);
    Label_003A:
        return;
    }

    public virtual void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        Skeleton skeleton;
        Transform transform2;
        Transform transform3;
        EnemyModifierTar tar;
        Transform transform4;
        IDisposable disposable;
        this.isPaused = 0;
        if (this.wasAnimating == null)
        {
            goto Label_001D;
        }
        this.creepSprite.UnpauseAnim();
    Label_001D:
        enumerator = base.transform.GetEnumerator();
    Label_0029:
        try
        {
            goto Label_0053;
        Label_002E:
            transform = (Transform) enumerator.Current;
            sprite = transform.GetComponent<PackedSprite>();
            if ((sprite != null) == null)
            {
                goto Label_0053;
            }
            sprite.UnpauseAnim();
        Label_0053:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002E;
            }
            goto Label_0078;
        }
        finally
        {
        Label_0063:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0070;
            }
        Label_0070:
            disposable.Dispose();
        }
    Label_0078:
        skeleton = base.GetComponent<Skeleton>();
        if ((skeleton != null) == null)
        {
            goto Label_0091;
        }
        skeleton.Unpause();
    Label_0091:
        if ((this.curseEffect != null) == null)
        {
            goto Label_00C8;
        }
        if (this.curseEffect.IsHidden() != null)
        {
            goto Label_00C8;
        }
        this.curseEffect.UnpauseAnim();
        base.GetComponent<EnemyModifierCurse>().Unpause();
    Label_00C8:
        if ((this.poisonEffect != null) == null)
        {
            goto Label_00FF;
        }
        if (this.poisonEffect.IsHidden() != null)
        {
            goto Label_00FF;
        }
        this.poisonEffect.UnpauseAnim();
        base.GetComponent<EnemyModifierPoison>().Unpause();
    Label_00FF:
        transform2 = base.transform.FindChild("Rage");
        if ((transform2 != null) == null)
        {
            goto Label_012A;
        }
        transform2.GetComponent<EnemyModifierRage>().Unpause();
    Label_012A:
        transform3 = base.transform.FindChild("StunEffect");
        if ((transform3 != null) == null)
        {
            goto Label_0155;
        }
        transform3.GetComponent<EnemyModifierStun>().Unpause();
    Label_0155:
        tar = base.GetComponent<EnemyModifierTar>();
        if ((tar != null) == null)
        {
            goto Label_0171;
        }
        tar.Unpause();
    Label_0171:
        transform4 = base.transform.FindChild("healEffect");
        if ((transform4 != null) == null)
        {
            goto Label_019C;
        }
        transform4.GetComponent<PackedSprite>().UnpauseAnim();
    Label_019C:
        if ((this.teslaEffect != null) == null)
        {
            goto Label_01B8;
        }
        this.teslaEffect.UnpauseAnim();
    Label_01B8:
        return;
    }

    public void UnSetFighter(int pos)
    {
        if (pos != null)
        {
            goto Label_0019;
        }
        this.fighterPositionOne -= 1;
        goto Label_0027;
    Label_0019:
        this.fighterPositionTwo -= 1;
    Label_0027:
        return;
    }

    protected void UpdateLifeBar()
    {
        if ((this.mainBar != null) == null)
        {
            goto Label_005C;
        }
        if (this.life > 0)
        {
            goto Label_0033;
        }
        this.mainBar.gameObject.SetActive(0);
        goto Label_005C;
    Label_0033:
        this.lifeBar.localScale = new Vector3(((float) this.life) / ((float) this.totalLife), 1f, 1f);
    Label_005C:
        return;
    }

    protected virtual void UpdateSpecialPowerCooldowns()
    {
    }
}

