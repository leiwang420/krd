using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    protected Vector2 adjustSelector;
    public int armor;
    public int attackChargeDamageTime;
    public int attackChargeTime;
    protected int attackChargeTimeCounter;
    public int attackReloadTime;
    protected int attackReloadTimeCounter;
    public Transform barbarianPrefab;
    public Transform bloodSplatter;
    protected bool canBeBurned;
    protected bool canBeConvertedToWerewolf;
    protected bool canBeCourage;
    public bool canBePoisoned;
    protected bool canBeSkeleteon;
    public bool canZombie;
    protected Constants.damageType damageType;
    protected Constants.damageType damageTypeMelee;
    public int deadTime;
    protected int deadTimeCounter;
    protected Vector2 destinationPoint;
    protected int dodgeDamage;
    protected bool doorQueed;
    protected Creep enemy;
    protected int fightingPosition;
    protected PackedSprite fireEffect;
    public Transform firePrefab;
    protected bool flipX;
    public Transform footmenPrefab;
    protected GUIBottom gui;
    protected int health;
    public int idleTime;
    protected int idleTimeCounter;
    protected int initHealth;
    protected bool isActive;
    protected bool isBlocking;
    protected bool isCharging;
    protected bool isDead;
    protected bool isFighting;
    protected bool isIdle;
    protected bool isLifeTimed;
    protected bool isPaused;
    protected bool isRespawning;
    protected bool isWalking;
    public Transform knightPrefab;
    protected Transform lifeBar;
    public Transform lifeBarPrefab;
    public int lifeTime;
    protected int lifeTimeCounter;
    protected Transform mainBar;
    public int maxDamage;
    public int minDamage;
    protected ArrayList nameCandidates;
    protected int nameIndex;
    protected int nameMax;
    protected bool overrideDodge;
    public Transform paladinPrefab;
    protected PackedSprite poisonEffect;
    public Transform poisonPrefab;
    private Vector3 positionSkeletonWarrior;
    protected Vector2 rallyPoint;
    protected Vector3 rangeCenterPosition;
    protected int rangeHeight;
    protected int rangeWidth;
    protected PackedSprite ratPoisonEffect;
    protected int regenerateHealth;
    protected int regenerateTime;
    protected int regenerateTimeCounter;
    protected bool respawnOnInit;
    public int respawnTime;
    protected int respawnTimeCounter;
    protected bool runDeathAnimation;
    protected Transform skeletonWarriorPrefab;
    protected bool spawnedSkeletonWarrior;
    protected CreepSpawner spawner;
    protected Vector2 spawnPosition;
    protected bool spawnSkeletonWarrior;
    public float speed;
    protected PackedSprite sprite;
    protected StageBase stage;
    protected int targetedTime;
    protected int targetedTimeCounter;
    protected TowerBase tower;
    protected UnitClickable unitClickable;
    protected bool wasAnimating;
    public float xAdjust;
    public int xModifierAdjust;
    protected float xSpeed;
    public float yAdjust;
    public int yLifebarOffset;
    public int yModifierAdjust;
    protected float ySpeed;

    public Soldier()
    {
        this.isRespawning = 1;
        this.canBeCourage = 1;
        this.canBePoisoned = 1;
        this.canBeConvertedToWerewolf = 1;
        this.canBeSkeleteon = 1;
        this.targetedTime = 60;
        this.spawnPosition = Vector2.zero;
        this.damageType = 1;
        this.damageTypeMelee = 1;
        this.canZombie = 1;
        this.canBeBurned = 1;
        base..ctor();
        return;
    }

    protected virtual void AddWalkParticle()
    {
    }

    protected virtual void AfterDamage()
    {
    }

    private unsafe void AnimationDelegate(SpriteBase sprt)
    {
        Transform transform;
        Creep creep;
        Vector3 vector;
        if (this.isDead == null)
        {
            goto Label_010D;
        }
        this.runDeathAnimation = 1;
        if (this.spawnSkeletonWarrior == null)
        {
            goto Label_0028;
        }
        if (this.spawnedSkeletonWarrior == null)
        {
            goto Label_0029;
        }
    Label_0028:
        return;
    Label_0029:
        transform = UnityEngine.Object.Instantiate(this.skeletonWarriorPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.name = "Skeleton Warrior";
        creep.InitSprite();
        creep.SetPathIndex((int) &this.positionSkeletonWarrior.x);
        creep.SetSubPath((int) &this.positionSkeletonWarrior.y);
        creep.SetCurrentNode((int) &this.positionSkeletonWarrior.z);
        creep.SetUseGold(0);
        creep.SetActive(1);
        creep.roadNodesTillActive = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_00FA;
        }
        creep.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00FA:
        this.spawnedSkeletonWarrior = 1;
        this.sprite.Hide(1);
    Label_010D:
        return;
    }

    private void Awake()
    {
        Stage22 stage;
        this.LoadNames();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        if ((this.stage.GetComponent<Stage22>() != null) == null)
        {
            goto Label_0052;
        }
        this.skeletonWarriorPrefab = Resources.Load("Prefabs/Creeps/Skeleton Warrior", typeof(Transform)) as Transform;
    Label_0052:
        return;
    }

    protected bool BeforeRespawn()
    {
        if (((BarrackTower) this.tower).IsDoorClosed() == null)
        {
            goto Label_0044;
        }
        ((BarrackTower) this.tower).OpenDoor();
        this.respawnTime = ((BarrackTower) this.tower).doorToOpenTime;
        this.doorQueed = 1;
        return 1;
    Label_0044:
        if (((BarrackTower) this.tower).IsDoorOpening() == null)
        {
            goto Label_0089;
        }
        this.respawnTime = ((BarrackTower) this.tower).doorToOpenTime - ((BarrackTower) this.tower).GetDoorTimeCounter();
        this.doorQueed = 1;
        return 1;
    Label_0089:
        return 0;
    }

    public unsafe void BloodSplatter()
    {
        Vector3 vector;
        Vector3 vector2;
        GameSoundManager.PlayHitSound();
        UnityEngine.Object.Instantiate(this.bloodSplatter, new Vector3(&base.transform.position.x, &base.transform.position.y, -900f), Quaternion.identity);
        return;
    }

    public bool CanBeBurned()
    {
        return this.canBeBurned;
    }

    public bool CanBeConvertedToWerewolf()
    {
        return this.canBeConvertedToWerewolf;
    }

    public bool CanBeCourage()
    {
        return this.canBeCourage;
    }

    public bool CanBePoisoned()
    {
        return this.canBePoisoned;
    }

    public bool CanBeSkeleton()
    {
        return this.canBeSkeleteon;
    }

    protected bool CanHeal()
    {
        if (this.isActive != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (((this.health * 100) / this.initHealth) > 70)
        {
            goto Label_0026;
        }
        return 1;
    Label_0026:
        return 0;
    }

    public virtual void ChangeRallyPoint(Vector2 newRallyPoint)
    {
        this.rallyPoint = newRallyPoint + new Vector2(0f, this.yAdjust);
        if (this.isDead != null)
        {
            goto Label_0032;
        }
        if (this.isRespawning == null)
        {
            goto Label_0033;
        }
    Label_0032:
        return;
    Label_0033:
        this.isActive = 0;
        this.isCharging = 0;
        this.UnBlock();
        this.SetGoToIdleStatus();
        this.StopSpecial();
        return;
    }

    public virtual unsafe bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        vectorArray = this.stage.GetPath();
        num = 0;
        goto Label_00A9;
    Label_0013:
        num2 = 0;
        goto Label_0098;
    Label_001A:
        if (this.stage.StageHasTunnels() == null)
        {
            goto Label_0037;
        }
        if (this.OnTunnel(num, num2) != null)
        {
            goto Label_0094;
        }
    Label_0037:
        if (Mathf.Sqrt(Mathf.Pow(&(vectorArray[num][0][num2]).y - &newRallyPoint.y, 2f) + Mathf.Pow(&(vectorArray[num][0][num2]).x - &newRallyPoint.x, 2f)) >= 60f)
        {
            goto Label_0094;
        }
        this.ChangeRallyPoint(newRallyPoint);
        return 1;
    Label_0094:
        num2 += 1;
    Label_0098:
        if (num2 < ((int) vectorArray[num][0].Length))
        {
            goto Label_001A;
        }
        num += 1;
    Label_00A9:
        if (num < ((int) vectorArray.Length))
        {
            goto Label_0013;
        }
        return 0;
    }

    public void ChangeRallyPointOnly(Vector2 newRallyPoint)
    {
        this.rallyPoint = newRallyPoint;
        if (this.isFighting == null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        this.isActive = 0;
        this.SetGoToIdleStatus();
        this.StopSpecial();
        return;
    }

    protected virtual void ChargeAttack()
    {
        this.PlayAnimationAttack();
        this.isCharging = 1;
        return;
    }

    protected bool CheckExtraCharge()
    {
        if (this.attackChargeTimeCounter >= this.attackChargeTime)
        {
            goto Label_0021;
        }
        this.attackChargeTimeCounter += 1;
        return 1;
    Label_0021:
        this.attackChargeTimeCounter = 0;
        this.SetGoToIdleStatus();
        return 0;
    }

    protected virtual unsafe bool DestinationReach()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        float introduced3 = Mathf.Pow(&this.destinationPoint.y - &base.transform.position.y, 2f);
        if (Mathf.Sqrt(introduced3 + Mathf.Pow(&this.destinationPoint.x - &base.transform.position.x, 2f)) > this.speed)
        {
            goto Label_0110;
        }
        this.isWalking = 0;
        this.isActive = 1;
        float introduced4 = Mathf.Round(&this.destinationPoint.x);
        base.transform.position = new Vector3(introduced4, Mathf.Round(&this.destinationPoint.y), &base.transform.position.z);
        if (this.isFighting == null)
        {
            goto Label_0101;
        }
        this.SetFacing();
        if (this.isBlocking == null)
        {
            goto Label_0108;
        }
        if ((this.enemy != null) == null)
        {
            goto Label_0108;
        }
        if (this.enemy.IsActive() == null)
        {
            goto Label_0108;
        }
        this.enemy.StartFighting();
        goto Label_0108;
    Label_0101:
        this.isIdle = 1;
    Label_0108:
        this.RevertToStatic();
        return 1;
    Label_0110:
        return 0;
    }

    public virtual bool DodgeHit()
    {
        return 0;
    }

    public virtual void Eat()
    {
        this.sprite.Hide(1);
        this.health = 0;
        this.isActive = 0;
        this.isDead = 1;
        if ((this.mainBar != null) == null)
        {
            goto Label_0043;
        }
        this.mainBar.gameObject.SetActive(0);
    Label_0043:
        if (this.isBlocking == null)
        {
            goto Label_0054;
        }
        this.UnBlock();
    Label_0054:
        this.unitClickable.UnSelect();
        if ((this.gui == null) == null)
        {
            goto Label_0085;
        }
        this.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
    Label_0085:
        this.gui.HideInfo(this.unitClickable);
        this.unitClickable.UnSelect();
        base.collider.enabled = 0;
        GameAchievements.KillSoldier();
        return;
    }

    protected virtual void Fight()
    {
        this.attackChargeTimeCounter += 1;
        if (this.attackChargeTimeCounter >= this.attackChargeTime)
        {
            goto Label_0037;
        }
        if (this.attackChargeTimeCounter != this.attackChargeDamageTime)
        {
            goto Label_0036;
        }
        this.HitEnemy();
    Label_0036:
        return;
    Label_0037:
        this.attackChargeTimeCounter = 0;
        this.isCharging = 0;
        return;
    }

    protected bool FindEnemy()
    {
        Creep creep;
        Creep creep2;
        Transform transform;
        IEnumerator enumerator;
        Creep creep3;
        IDisposable disposable;
        if (this.isActive != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        creep = null;
        creep2 = null;
        if (this.isBlocking == null)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        enumerator = this.spawner.transform.GetEnumerator();
    Label_002F:
        try
        {
            goto Label_00D7;
        Label_0034:
            transform = (Transform) enumerator.Current;
            creep3 = transform.GetComponent<Creep>();
            if (creep3.isFlying != null)
            {
                goto Label_00D7;
            }
            if (creep3.IsActive() == null)
            {
                goto Label_00D7;
            }
            if (creep3.CanBeBlocked() == null)
            {
                goto Label_00D7;
            }
            if (this.OnRange(creep3) == null)
            {
                goto Label_00D7;
            }
            if (creep3.IsBlocked() != null)
            {
                goto Label_00AB;
            }
            if ((creep == null) != null)
            {
                goto Label_00A3;
            }
            if (creep.GetCurrentNodeIndex() <= creep3.GetCurrentNodeIndex())
            {
                goto Label_00D7;
            }
        Label_00A3:
            creep = creep3;
            goto Label_00D7;
        Label_00AB:
            if (this.isFighting != null)
            {
                goto Label_00D7;
            }
            if ((creep2 == null) != null)
            {
                goto Label_00D4;
            }
            if (creep2.GetCurrentNodeIndex() <= creep3.GetCurrentNodeIndex())
            {
                goto Label_00D7;
            }
        Label_00D4:
            creep2 = creep3;
        Label_00D7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0034;
            }
            goto Label_00FC;
        }
        finally
        {
        Label_00E7:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00F4;
            }
        Label_00F4:
            disposable.Dispose();
        }
    Label_00FC:
        if ((creep != null) == null)
        {
            goto Label_0111;
        }
        this.SetBlockingStatus(creep);
        return 1;
    Label_0111:
        if ((creep2 != null) == null)
        {
            goto Label_0126;
        }
        this.SetFightingStatus(creep2);
        return 1;
    Label_0126:
        return 0;
    }

    protected void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.UpdateLifeBar();
        if (this.isDead == null)
        {
            goto Label_0029;
        }
        if (this.ReadyToRespawn() != null)
        {
            goto Label_0029;
        }
        return;
    Label_0029:
        if (this.isRespawning == null)
        {
            goto Label_0040;
        }
        if (this.ReadyToLive() != null)
        {
            goto Label_0040;
        }
        return;
    Label_0040:
        if (this.isLifeTimed == null)
        {
            goto Label_0057;
        }
        if (this.ReadyToHide() == null)
        {
            goto Label_0057;
        }
        return;
    Label_0057:
        if (this.RunSpecial() == null)
        {
            goto Label_0063;
        }
        return;
    Label_0063:
        if (this.isActive == null)
        {
            goto Label_009B;
        }
        if (this.isFighting != null)
        {
            goto Label_009B;
        }
        if (this.isBlocking != null)
        {
            goto Label_009B;
        }
        if (this.attackChargeTimeCounter == null)
        {
            goto Label_009B;
        }
        if (this.CheckExtraCharge() == null)
        {
            goto Label_009B;
        }
        return;
    Label_009B:
        if (this.isWalking == null)
        {
            goto Label_00B2;
        }
        if (this.Walk() != null)
        {
            goto Label_00B2;
        }
        return;
    Label_00B2:
        if (this.isActive == null)
        {
            goto Label_017B;
        }
        if (this.isIdle == null)
        {
            goto Label_00DE;
        }
        if (this.FindEnemy() != null)
        {
            goto Label_017B;
        }
        this.PlayIdle();
        goto Label_017B;
    Label_00DE:
        if (this.isFighting == null)
        {
            goto Label_0175;
        }
        if ((this.enemy == null) != null)
        {
            goto Label_010A;
        }
        if (this.enemy.IsActive() != null)
        {
            goto Label_0110;
        }
    Label_010A:
        this.UnBlock();
    Label_0110:
        if (this.isFighting == null)
        {
            goto Label_013C;
        }
        if (this.isBlocking != null)
        {
            goto Label_013C;
        }
        if (this.enemy.IsBlocked() != null)
        {
            goto Label_013C;
        }
        this.UnBlock();
    Label_013C:
        if (this.isBlocking != null)
        {
            goto Label_0153;
        }
        if (this.FindEnemy() == null)
        {
            goto Label_0153;
        }
        return;
    Label_0153:
        if (this.isCharging == null)
        {
            goto Label_0169;
        }
        this.Fight();
        goto Label_0170;
    Label_0169:
        this.ReadyToAttack();
    Label_0170:
        goto Label_017B;
    Label_0175:
        this.SetGoToIdleStatus();
    Label_017B:
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
        return "8=D";
    }

    protected virtual int GetDamage()
    {
        return (this.minDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.maxDamage - this.minDamage))));
    }

    public Creep GetEnemy()
    {
        return this.enemy;
    }

    public int GetHealth()
    {
        return this.health;
    }

    public int GetInitHealth()
    {
        return this.initHealth;
    }

    protected void GetNameIndex()
    {
        this.nameIndex = UnityEngine.Random.Range(1, this.nameMax);
        return;
    }

    public Vector2 GetSpeedVector()
    {
        return new Vector2(this.xSpeed, this.ySpeed);
    }

    public TowerBase GetTower()
    {
        return this.tower;
    }

    public void Heal(int HealPoints)
    {
        this.health += HealPoints;
        if (this.health <= this.initHealth)
        {
            goto Label_002B;
        }
        this.health = this.initHealth;
    Label_002B:
        return;
    }

    public void Hide(bool h)
    {
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.sprite.Hide(h);
        return;
    }

    public void HideFire()
    {
        if ((this.fireEffect != null) == null)
        {
            goto Label_001D;
        }
        this.fireEffect.Hide(1);
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

    public void HideRatPoison()
    {
        SoldierModifierGiantRatPoison poison;
        base.GetComponent<SoldierModifierGiantRatPoison>().removeWeakness();
        if ((this.ratPoisonEffect != null) == null)
        {
            goto Label_002A;
        }
        this.ratPoisonEffect.Hide(1);
    Label_002A:
        return;
    }

    protected virtual void HitEnemy()
    {
        int num;
        if ((this.enemy == null) != null)
        {
            goto Label_0021;
        }
        if (this.enemy.IsActive() != null)
        {
            goto Label_002E;
        }
    Label_0021:
        this.UnBlock();
        this.SetGoToIdleStatus();
        return;
    Label_002E:
        if (this.enemy.DodgeAttack() == null)
        {
            goto Label_0049;
        }
        if (this.overrideDodge == null)
        {
            goto Label_00AB;
        }
    Label_0049:
        if (UnityEngine.Random.Range(0f, 1f) >= 0.3f)
        {
            goto Label_0062;
        }
    Label_0062:
        num = this.GetDamage();
        this.enemy.Damage(num, this.damageTypeMelee, 0, 0);
        this.OnEnemyDamaged(num);
        if ((this.enemy != null) == null)
        {
            goto Label_00AB;
        }
        if (this.enemy.IsActive() != null)
        {
            goto Label_00AB;
        }
        this.UnBlock();
    Label_00AB:
        return;
    }

    public unsafe void InitWithPosition(Vector2 pos, Vector2 pRallyPoint, BarrackTower myTower, int pNameMax, bool pRespawnOnInit)
    {
        Vector3 vector;
        Vector3 vector2;
        this.respawnOnInit = pRespawnOnInit;
        this.targetedTime = 60;
        this.nameMax = pNameMax;
        &base.transform.position.Set(&pos.x, &pos.y, &base.transform.position.z);
        this.rallyPoint = pRallyPoint;
        this.tower = myTower;
        this.nameMax = pNameMax;
        this.GetNameIndex();
        return;
    }

    public bool IsActive()
    {
        return this.isActive;
    }

    public bool IsDead()
    {
        return ((this.health > 0) == 0);
    }

    public bool IsDeathBool()
    {
        return this.isDead;
    }

    public bool IsFighting()
    {
        return this.isFighting;
    }

    public bool IsFireActive()
    {
        if ((base.GetComponent<SoldierModifierFlareonFire>() == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return (this.fireEffect.IsHidden() == 0);
    }

    public bool IsPoisonActive()
    {
        if ((base.GetComponent<SoldierModifierPoison>() == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return (this.poisonEffect.IsHidden() == 0);
    }

    public bool IsRatPoisonActive()
    {
        if ((base.GetComponent<SoldierModifierGiantRatPoison>() == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return (this.ratPoisonEffect.IsHidden() == 0);
    }

    public bool IsStopped()
    {
        return 0;
    }

    public virtual bool IsTowerSelected()
    {
        return this.tower.IsRallySelected();
    }

    public bool IsWalking()
    {
        return this.isWalking;
    }

    protected virtual void LoadNames()
    {
        this.nameCandidates = new ArrayList();
        this.nameCandidates.Add("Willard");
        this.nameCandidates.Add("Wesley");
        this.nameCandidates.Add("Wallace");
        this.nameCandidates.Add("Usher");
        this.nameCandidates.Add("Tanner");
        this.nameCandidates.Add("Stuart");
        this.nameCandidates.Add("Silas");
        this.nameCandidates.Add("Sawyer");
        this.nameCandidates.Add("Robert");
        this.nameCandidates.Add("Raymond");
        this.nameCandidates.Add("Ramsey");
        this.nameCandidates.Add("Peyton");
        this.nameCandidates.Add("Maddox");
        this.nameCandidates.Add("Lando");
        this.nameCandidates.Add("Kelvin");
        this.nameCandidates.Add("Jerald");
        this.nameCandidates.Add("Gordon");
        this.nameCandidates.Add("Godwin");
        this.nameCandidates.Add("Garrett");
        this.nameCandidates.Add("Eldon");
        this.nameCandidates.Add("Egbert");
        this.nameCandidates.Add("Simon");
        this.nameCandidates.Add("Altair");
        this.nameCandidates.Add("Allister");
        this.nameCandidates.Add("Rulf");
        this.nameCandidates.Add("Bryce");
        this.nameCandidates.Add("Henry");
        this.nameCandidates.Add("Thomas");
        this.nameCandidates.Add("Hadrian");
        this.nameCandidates.Add("Borin");
        this.nameCandidates.Add("Alvus");
        this.nameCandidates.Add("Arthur");
        this.nameCandidates.Add("Martin");
        this.nameCandidates.Add("William");
        this.nameCandidates.Add("Robin");
        this.nameCandidates.Add("McMoe");
        return;
    }

    protected virtual void OnDeath()
    {
    }

    protected virtual void OnEnemyDamaged(int damage)
    {
    }

    protected virtual unsafe bool OnRange(Creep myEnemy)
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        num = Mathf.Round(&myEnemy.transform.position.x + &myEnemy.anchorPoint.x);
        num2 = Mathf.Round(&myEnemy.transform.position.y + &myEnemy.anchorPoint.y);
        &vector = new Vector3(num, num2, 0f);
        return IronUtils.ellipseContainPoint(vector, (float) this.rangeHeight, (float) this.rangeWidth, this.rangeCenterPosition);
    }

    protected bool OnTunnel(int i, int j)
    {
        if (this.stage.HasTunnels(i) == null)
        {
            goto Label_0037;
        }
        if (j < this.stage.TunnelStart(i))
        {
            goto Label_0037;
        }
        if (j > this.stage.TunnelEnd(i))
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        return 0;
    }

    public virtual void Pause()
    {
        UVAnimation animation;
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.isPaused = 1;
        animation = this.sprite.GetCurAnim();
        if (animation == null)
        {
            goto Label_00E8;
        }
        if (this.sprite.IsAnimating() != null)
        {
            goto Label_0072;
        }
        if (animation.loopCycles != -1)
        {
            goto Label_0089;
        }
        if ((animation.name == "walk") == null)
        {
            goto Label_0089;
        }
        if (this.isWalking == null)
        {
            goto Label_0089;
        }
    Label_0072:
        this.sprite.PauseAnim();
        this.wasAnimating = 1;
        goto Label_00E8;
    Label_0089:
        if ((base.GetComponent<SoldierHero>() != null) == null)
        {
            goto Label_00E8;
        }
        if (this.sprite.IsAnimating() != null)
        {
            goto Label_00D6;
        }
        if (animation.loopCycles != -1)
        {
            goto Label_00E8;
        }
        if ((animation.name == "walk") == null)
        {
            goto Label_00E8;
        }
        if (this.isWalking == null)
        {
            goto Label_00E8;
        }
    Label_00D6:
        this.sprite.PauseAnim();
        this.wasAnimating = 1;
    Label_00E8:
        if ((this.poisonEffect != null) == null)
        {
            goto Label_011F;
        }
        if (this.poisonEffect.IsHidden() != null)
        {
            goto Label_011F;
        }
        this.poisonEffect.PauseAnim();
        base.GetComponent<SoldierModifierPoison>().Pause();
    Label_011F:
        if ((this.ratPoisonEffect != null) == null)
        {
            goto Label_0156;
        }
        if (this.ratPoisonEffect.IsHidden() != null)
        {
            goto Label_0156;
        }
        this.ratPoisonEffect.PauseAnim();
        base.GetComponent<SoldierModifierGiantRatPoison>().Pause();
    Label_0156:
        return;
    }

    protected virtual void PlayAnimationAttack()
    {
        this.sprite.PlayAnim("attack");
        return;
    }

    protected virtual void PlayAnimationDeath()
    {
        this.sprite.PlayAnim("death");
        return;
    }

    protected virtual void PlayAnimationWalk()
    {
        this.sprite.PlayAnim("walk");
        return;
    }

    protected virtual void PlayDeathSound()
    {
    }

    protected virtual unsafe void PlayIdle()
    {
        Vector3 vector;
        this.targetedTimeCounter += 1;
        this.idleTimeCounter += 1;
        if (this.idleTimeCounter < this.idleTime)
        {
            goto Label_00B4;
        }
        if (Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f) * 10f) >= 4)
        {
            goto Label_00AD;
        }
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_008E;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00AD;
    Label_008E:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00AD:
        this.idleTimeCounter = 0;
    Label_00B4:
        if (this.targetedTimeCounter >= this.targetedTime)
        {
            goto Label_00C6;
        }
        return;
    Label_00C6:
        this.targetedTimeCounter = this.targetedTime;
        this.regenerateTimeCounter += 1;
        if (this.regenerateTimeCounter < this.regenerateTime)
        {
            goto Label_0144;
        }
        if (this.health >= this.initHealth)
        {
            goto Label_013D;
        }
        this.health += this.regenerateHealth;
        GameAchievements.AddRegeneration(this.regenerateHealth);
        if (this.health <= this.initHealth)
        {
            goto Label_013D;
        }
        this.health = this.initHealth;
    Label_013D:
        this.regenerateTimeCounter = 0;
    Label_0144:
        return;
    }

    protected virtual bool ReadyToAttack()
    {
        this.attackReloadTimeCounter += 1;
        if (this.attackReloadTimeCounter != this.attackReloadTime)
        {
            goto Label_002E;
        }
        this.ChargeAttack();
        this.attackReloadTimeCounter = 0;
        return 1;
    Label_002E:
        return 0;
    }

    protected bool ReadyToHide()
    {
        this.lifeTimeCounter += 1;
        if (this.lifeTimeCounter >= this.lifeTime)
        {
            goto Label_0021;
        }
        return 0;
    Label_0021:
        this.isActive = 0;
        this.isDead = 1;
        this.PlayAnimationDeath();
        this.PlayDeathSound();
        if ((this.gui != null) == null)
        {
            goto Label_005D;
        }
        this.gui.HideInfo(this.unitClickable);
    Label_005D:
        if ((this.unitClickable != null) == null)
        {
            goto Label_0079;
        }
        this.unitClickable.UnSelect();
    Label_0079:
        if ((base.collider != null) == null)
        {
            goto Label_0096;
        }
        base.collider.enabled = 0;
    Label_0096:
        this.mainBar.gameObject.SetActive(0);
        this.stage.RemoveSoldier(this);
        if (this.isBlocking == null)
        {
            goto Label_00C4;
        }
        this.UnBlock();
    Label_00C4:
        return 1;
    }

    protected virtual bool ReadyToLive()
    {
        if ((this.tower != null) == null)
        {
            goto Label_0023;
        }
        if (this.tower.IsActive() != null)
        {
            goto Label_0023;
        }
        return 0;
    Label_0023:
        this.sprite.Hide(1);
        if (this.doorQueed != null)
        {
            goto Label_0047;
        }
        if (this.BeforeRespawn() != null)
        {
            goto Label_0047;
        }
        return 0;
    Label_0047:
        this.respawnTimeCounter += 1;
        if (this.respawnTimeCounter < this.respawnTime)
        {
            goto Label_007A;
        }
        this.sprite.Hide(0);
        this.Respawn();
        return 1;
    Label_007A:
        return 0;
    }

    protected virtual bool ReadyToRespawn()
    {
        this.deadTimeCounter += 1;
        if (this.deadTimeCounter < this.deadTime)
        {
            goto Label_004B;
        }
        this.isDead = 0;
        this.doorQueed = 0;
        this.isRespawning = 1;
        this.runDeathAnimation = 0;
        this.spawnSkeletonWarrior = 0;
        this.spawnedSkeletonWarrior = 0;
        return 1;
    Label_004B:
        return 0;
    }

    protected void RecoverAnimationState()
    {
        if (this.isWalking == null)
        {
            goto Label_0016;
        }
        this.PlayAnimationWalk();
        goto Label_0044;
    Label_0016:
        if (this.isIdle == null)
        {
            goto Label_002C;
        }
        this.RevertToStatic();
        goto Label_0044;
    Label_002C:
        if (this.isFighting == null)
        {
            goto Label_0044;
        }
        this.attackReloadTimeCounter = 0;
        this.SetFacing();
    Label_0044:
        return;
    }

    protected virtual unsafe void Respawn()
    {
        this.isActive = 1;
        this.isDead = 0;
        this.isRespawning = 0;
        this.isWalking = 1;
        this.isCharging = 0;
        this.isBlocking = 0;
        this.isFighting = 0;
        this.isIdle = 0;
        base.collider.enabled = 1;
        base.transform.position = new Vector3(&this.spawnPosition.x, &this.spawnPosition.y, -3f);
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        &this.destinationPoint.Set(&this.rallyPoint.x, &this.rallyPoint.y);
        this.health = this.initHealth;
        this.deadTimeCounter = 0;
        this.respawnTimeCounter = 0;
        this.RespawnCustom();
        this.RevertToStatic();
        this.PlayAnimationWalk();
        GameAchievements.TrainSoldier();
        this.mainBar.gameObject.SetActive(1);
        return;
    }

    protected virtual void RespawnCustom()
    {
    }

    protected virtual void RevertToStatic()
    {
        this.sprite.RevertToStatic();
        return;
    }

    public bool RunDeathAnimation()
    {
        return this.runDeathAnimation;
    }

    protected virtual bool RunSpecial()
    {
        return 0;
    }

    protected void SetBlockingStatus(Creep myEnemy)
    {
        if (this.isFighting == null)
        {
            goto Label_001C;
        }
        this.enemy.UnSetFighter(this.fightingPosition);
    Label_001C:
        this.isFighting = 1;
        this.isBlocking = 1;
        this.isWalking = 1;
        this.isIdle = 0;
        this.enemy = myEnemy;
        this.enemy.Block(this);
        this.fightingPosition = 2;
        this.attackReloadTimeCounter = this.attackReloadTime - 1;
        this.SetFightingPosition();
        return;
    }

    public virtual void SetDamage(int damage, bool ignoresArmor = false)
    {
        SoldierModifierFlareonFire fire;
        SoldierModifierPoison poison;
        SoldierModifierGiantRatPoison poison2;
        SoldierModifierFireBurningFloor floor;
        this.targetedTimeCounter = 0;
        if (ignoresArmor != null)
        {
            goto Label_002C;
        }
        this.health -= damage - ((this.armor * damage) / 100);
        goto Label_003A;
    Label_002C:
        this.health -= damage;
    Label_003A:
        if (this.health > 0)
        {
            goto Label_0195;
        }
        this.health = 0;
        this.isActive = 0;
        this.isDead = 1;
        this.isCharging = 0;
        this.attackChargeTimeCounter = 0;
        this.PlayAnimationDeath();
        this.mainBar.gameObject.SetActive(0);
        if ((this.gui == null) == null)
        {
            goto Label_00A6;
        }
        this.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
    Label_00A6:
        this.gui.HideInfo(this.unitClickable);
        if ((this.unitClickable != null) == null)
        {
            goto Label_00D3;
        }
        this.unitClickable.UnSelect();
    Label_00D3:
        if (this.isBlocking == null)
        {
            goto Label_00E4;
        }
        this.UnBlock();
    Label_00E4:
        if ((base.collider != null) == null)
        {
            goto Label_0101;
        }
        base.collider.enabled = 0;
    Label_0101:
        fire = base.GetComponent<SoldierModifierFlareonFire>();
        if ((fire != null) == null)
        {
            goto Label_0120;
        }
        UnityEngine.Object.Destroy(fire);
        this.HideFire();
    Label_0120:
        poison = base.GetComponent<SoldierModifierPoison>();
        if ((poison != null) == null)
        {
            goto Label_013F;
        }
        UnityEngine.Object.Destroy(poison);
        this.HidePoison();
    Label_013F:
        poison2 = base.GetComponent<SoldierModifierGiantRatPoison>();
        if ((poison2 != null) == null)
        {
            goto Label_015E;
        }
        this.HideRatPoison();
        UnityEngine.Object.Destroy(poison2);
    Label_015E:
        floor = base.GetComponent<SoldierModifierFireBurningFloor>();
        if ((floor != null) == null)
        {
            goto Label_017D;
        }
        UnityEngine.Object.Destroy(floor);
        this.HideFire();
    Label_017D:
        GameAchievements.KillSoldier();
        this.ToSwamp();
        this.StopOnDead();
        this.OnDeath();
        return;
    Label_0195:
        if (GameUpgrades.BarracksUpBarbedArmor == null)
        {
            goto Label_0223;
        }
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_01C0;
        }
        if (this.stage.MaxUpgradeLevel != 5)
        {
            goto Label_0223;
        }
    Label_01C0:
        if ((this.enemy != null) == null)
        {
            goto Label_0223;
        }
        if (this.enemy.IsActive() == null)
        {
            goto Label_0223;
        }
        this.enemy.Damage(Mathf.CeilToInt(((float) damage) * 0.1f), 0, 0, 0);
        if ((this.enemy != null) == null)
        {
            goto Label_0223;
        }
        if (this.enemy.IsActive() != null)
        {
            goto Label_0223;
        }
        this.UnBlock();
    Label_0223:
        this.AfterDamage();
        return;
    }

    public void SetDodgeDamage(int d)
    {
        this.dodgeDamage = d;
        return;
    }

    public void SetEnemy(Creep e)
    {
        this.enemy = e;
        return;
    }

    protected unsafe void SetFacing()
    {
        Vector3 vector;
        if ((this.enemy == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        if (&this.enemy.transform.localScale.x != -1f)
        {
            goto Label_005F;
        }
        this.flipX = 0;
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_0085;
    Label_005F:
        this.flipX = 1;
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_0085:
        return;
    }

    protected unsafe void SetFightingPosition()
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        num = 0f;
        num2 = 0f;
        if (this.fightingPosition != 2)
        {
            goto Label_0029;
        }
        num = 0f;
        num2 = 0f;
        goto Label_0051;
    Label_0029:
        if (this.fightingPosition != null)
        {
            goto Label_0045;
        }
        num = 3f;
        num2 = -6f;
        goto Label_0051;
    Label_0045:
        num = 3f;
        num2 = 6f;
    Label_0051:
        if (&this.enemy.transform.localScale.x != 1f)
        {
            goto Label_00F9;
        }
        &this.destinationPoint.Set(((Mathf.Round(&this.enemy.transform.position.x) + this.xAdjust) + this.enemy.xSoldierAdjust) - num, (((Mathf.Round(&this.enemy.transform.position.y) + &this.enemy.anchorPoint.y) + num2) + this.enemy.ySoldierAdjust) + this.yAdjust);
        goto Label_017B;
    Label_00F9:
        &this.destinationPoint.Set(((Mathf.Round(&this.enemy.transform.position.x) - this.xAdjust) - this.enemy.xSoldierAdjust) + num, (((Mathf.Round(&this.enemy.transform.position.y) + &this.enemy.anchorPoint.y) + num2) + this.enemy.ySoldierAdjust) + this.yAdjust);
    Label_017B:
        this.PlayAnimationWalk();
        return;
    }

    protected void SetFightingStatus(Creep myEnemy)
    {
        this.isWalking = 1;
        this.isBlocking = 0;
        this.isFighting = 1;
        this.isIdle = 0;
        this.enemy = myEnemy;
        this.fightingPosition = this.enemy.GetFighterPosition();
        this.attackReloadTimeCounter = this.attackReloadTime - 1;
        this.SetFightingPosition();
        return;
    }

    protected virtual unsafe void SetGoToIdleStatus()
    {
        if (this.isWalking != null)
        {
            goto Label_003C;
        }
        this.isIdle = 0;
        this.isWalking = 1;
        if ((this.sprite == null) == null)
        {
            goto Label_0036;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_0036:
        this.PlayAnimationWalk();
    Label_003C:
        this.enemy = null;
        this.isFighting = 0;
        this.isBlocking = 0;
        this.isCharging = 0;
        &this.destinationPoint.Set(&this.rallyPoint.x, &this.rallyPoint.y);
        return;
    }

    public void SetName(string name)
    {
        base.GetComponent<UnitClickable>().name = name;
        return;
    }

    public void SetRallyPoint(Vector2 rally)
    {
        this.rallyPoint = rally;
        return;
    }

    public void SetRandomName()
    {
        int num;
        num = UnityEngine.Random.Range(0, this.nameCandidates.Count);
        base.GetComponent<UnitClickable>().name = (string) this.nameCandidates[num];
        return;
    }

    public unsafe void SetRangeCenterPosition(Vector2 p)
    {
        this.rangeCenterPosition = new Vector3(&p.x, &p.y, 0f);
        return;
    }

    public void SetSpawnedSkeletonWarrior(bool state)
    {
        this.spawnedSkeletonWarrior = state;
        return;
    }

    public void SetSpawnPosition(Vector2 pos)
    {
        this.spawnPosition = pos;
        return;
    }

    public void SetSpawnSkeletonWarrior(bool state, Vector3 position)
    {
        this.spawnSkeletonWarrior = state;
        this.positionSkeletonWarrior = position;
        return;
    }

    public void SetTower(TowerBase t)
    {
        this.tower = t;
        return;
    }

    public void ShowFire()
    {
        Transform transform1;
        Transform transform;
        if ((this.fireEffect == null) == null)
        {
            goto Label_007D;
        }
        transform = UnityEngine.Object.Instantiate(this.firePrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform1 = transform.transform;
        transform1.position += new Vector3((float) this.xModifierAdjust, (float) this.yModifierAdjust, -1f);
        this.fireEffect = transform.GetComponent<PackedSprite>();
        goto Label_00A5;
    Label_007D:
        if (this.fireEffect.IsHidden() == null)
        {
            goto Label_00A5;
        }
        this.fireEffect.Hide(0);
        this.fireEffect.PlayAnim(0);
    Label_00A5:
        return;
    }

    public void ShowPoison()
    {
        Transform transform1;
        Transform transform;
        if ((this.poisonEffect == null) == null)
        {
            goto Label_007D;
        }
        transform = UnityEngine.Object.Instantiate(this.poisonPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform1 = transform.transform;
        transform1.position += new Vector3((float) this.xModifierAdjust, (float) this.yModifierAdjust, -1f);
        this.poisonEffect = transform.GetComponent<PackedSprite>();
        goto Label_00A5;
    Label_007D:
        if (this.poisonEffect.IsHidden() == null)
        {
            goto Label_00A5;
        }
        this.poisonEffect.Hide(0);
        this.poisonEffect.PlayAnim(0);
    Label_00A5:
        return;
    }

    public void ShowRatPoison()
    {
        Transform transform1;
        Transform transform;
        if ((this.ratPoisonEffect == null) == null)
        {
            goto Label_007D;
        }
        transform = UnityEngine.Object.Instantiate(this.poisonPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform1 = transform.transform;
        transform1.position += new Vector3((float) this.xModifierAdjust, (float) this.yModifierAdjust, -1f);
        this.ratPoisonEffect = transform.GetComponent<PackedSprite>();
        goto Label_00A5;
    Label_007D:
        if (this.ratPoisonEffect.IsHidden() == null)
        {
            goto Label_00A5;
        }
        this.ratPoisonEffect.Hide(0);
        this.ratPoisonEffect.PlayAnim(0);
    Label_00A5:
        return;
    }

    public bool SpawnedSkeletonWarrior()
    {
        return this.spawnedSkeletonWarrior;
    }

    public bool SpawnSkeletonWarrior()
    {
        return this.spawnSkeletonWarrior;
    }

    private unsafe void Start()
    {
        string str;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        int num;
        this.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -3f);
        this.unitClickable = base.GetComponent<UnitClickable>();
        str = base.transform.name;
        base.transform.name = base.transform.name.Remove(str.IndexOf("("));
        this.rangeWidth = this.tower.range;
        this.rangeHeight = (int) (((float) this.rangeWidth) * 0.7f);
        this.minDamage = this.tower.minDamange;
        this.maxDamage = this.tower.maxDamage;
        this.regenerateTime = ((BarrackTower) this.tower).regenReload * 30;
        this.regenerateHealth = ((BarrackTower) this.tower).regen;
        this.mainBar = UnityEngine.Object.Instantiate(this.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) this.yLifebarOffset), &base.transform.position.z + 1f), Quaternion.identity) as Transform;
        this.mainBar.parent = base.transform;
        this.lifeBar = this.mainBar.FindChild("Bar");
        if (base.name.EndsWith("1") == null)
        {
            goto Label_021C;
        }
        this.health = this.initHealth = (int) GameSettings.GetTowerSetting("barrack_level1", "health");
        this.armor = (int) GameSettings.GetTowerSetting("barrack_level1", "armor");
        this.respawnTime = (int) GameSettings.GetTowerSetting("barrack_level1", "respawn");
        goto Label_02E5;
    Label_021C:
        if (base.name.EndsWith("2") == null)
        {
            goto Label_0283;
        }
        this.health = this.initHealth = (int) GameSettings.GetTowerSetting("barrack_level2", "health");
        this.armor = (int) GameSettings.GetTowerSetting("barrack_level2", "armor");
        this.respawnTime = (int) GameSettings.GetTowerSetting("barrack_level2", "respawn");
        goto Label_02E5;
    Label_0283:
        if (base.name.EndsWith("3") == null)
        {
            goto Label_02E5;
        }
        this.health = this.initHealth = (int) GameSettings.GetTowerSetting("barrack_level3", "health");
        this.armor = (int) GameSettings.GetTowerSetting("barrack_level3", "armor");
        this.respawnTime = (int) GameSettings.GetTowerSetting("barrack_level3", "respawn");
    Label_02E5:
        base.GetComponent<PackedSprite>().SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        return;
    }

    protected virtual void StopOnDead()
    {
    }

    protected virtual void StopSpecial()
    {
    }

    public unsafe Soldier SwapSoldier(string type, BarrackTower myTower, bool withName)
    {
        bool flag;
        Transform transform;
        Soldier soldier;
        flag = (this.isDead == null) ? 0 : 1;
        transform = null;
        if ((type == "footmen") == null)
        {
            goto Label_004B;
        }
        transform = UnityEngine.Object.Instantiate(this.footmenPrefab, base.transform.position, Quaternion.identity) as Transform;
        goto Label_00E8;
    Label_004B:
        if ((type == "knight") == null)
        {
            goto Label_0081;
        }
        transform = UnityEngine.Object.Instantiate(this.knightPrefab, base.transform.position, Quaternion.identity) as Transform;
        goto Label_00E8;
    Label_0081:
        if ((type == "holyOrder") == null)
        {
            goto Label_00B7;
        }
        transform = UnityEngine.Object.Instantiate(this.paladinPrefab, base.transform.position, Quaternion.identity) as Transform;
        goto Label_00E8;
    Label_00B7:
        if ((type == "barbarian") == null)
        {
            goto Label_00E8;
        }
        transform = UnityEngine.Object.Instantiate(this.barbarianPrefab, base.transform.position, Quaternion.identity) as Transform;
    Label_00E8:
        soldier = transform.GetComponent<Soldier>();
        soldier.InitWithPosition(base.transform.position, this.rallyPoint, myTower, 0, flag);
        soldier.SetSpawnPosition(this.spawnPosition);
        soldier.SetRangeCenterPosition(this.rangeCenterPosition);
        soldier.SetName(this.unitClickable.name);
        if (withName == null)
        {
            goto Label_014E;
        }
        soldier.nameIndex = this.nameIndex;
    Label_014E:
        if (this.isDead == null)
        {
            goto Label_015B;
        }
        return soldier;
    Label_015B:
        soldier.isActive = this.isActive;
        soldier.isDead = this.isDead;
        soldier.isCharging = 0;
        soldier.isRespawning = this.isRespawning;
        soldier.isWalking = this.isWalking;
        soldier.isBlocking = this.isBlocking;
        soldier.isFighting = this.isFighting;
        soldier.isIdle = this.isIdle;
        soldier.doorQueed = this.doorQueed;
        soldier.targetedTimeCounter = this.targetedTimeCounter;
        soldier.destinationPoint = new Vector2(&this.destinationPoint.x, &this.destinationPoint.y);
        if ((this.enemy != null) == null)
        {
            goto Label_0218;
        }
        this.enemy.SetSoldier(soldier);
        soldier.SetEnemy(this.enemy);
    Label_0218:
        if (this.isWalking == null)
        {
            goto Label_0229;
        }
        soldier.WalkAnimation();
    Label_0229:
        if (flag != null)
        {
            goto Label_0236;
        }
        soldier.Hide(0);
    Label_0236:
        if (soldier.isFighting == null)
        {
            goto Label_0247;
        }
        soldier.SetFacing();
    Label_0247:
        return soldier;
    }

    protected virtual void ToSwamp()
    {
        if (this.canZombie == null)
        {
            goto Label_001C;
        }
        this.stage.SpawnZombie(this.initHealth);
    Label_001C:
        return;
    }

    public void UnBlock()
    {
        this.isBlocking = 0;
        this.isFighting = 0;
        this.isCharging = 0;
        this.attackChargeTimeCounter = 0;
        if ((this.enemy != null) == null)
        {
            goto Label_003E;
        }
        this.enemy.UnSetFighter(this.fightingPosition);
    Label_003E:
        this.enemy = null;
        return;
    }

    public virtual void Unpause()
    {
        UVAnimation animation;
        this.isPaused = 0;
        if (this.wasAnimating == null)
        {
            goto Label_0043;
        }
        if (this.isWalking != null)
        {
            goto Label_0033;
        }
        if (this.isFighting != null)
        {
            goto Label_0033;
        }
        if (this.isDead == null)
        {
            goto Label_0070;
        }
    Label_0033:
        this.sprite.UnpauseAnim();
        goto Label_0070;
    Label_0043:
        animation = this.sprite.GetCurAnim();
        if (animation == null)
        {
            goto Label_0070;
        }
        if ((animation.name != "death") == null)
        {
            goto Label_0070;
        }
        this.RevertToStatic();
    Label_0070:
        if ((this.poisonEffect != null) == null)
        {
            goto Label_00A7;
        }
        if (this.poisonEffect.IsHidden() != null)
        {
            goto Label_00A7;
        }
        this.poisonEffect.UnpauseAnim();
        base.GetComponent<SoldierModifierPoison>().Unpause();
    Label_00A7:
        return;
    }

    protected virtual unsafe void UpdateLifeBar()
    {
        Vector3 vector;
        if (this.health <= 0)
        {
            goto Label_0035;
        }
        this.lifeBar.localScale = new Vector3(((float) this.health) / ((float) this.initHealth), 1f, 1f);
    Label_0035:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_0076;
        }
        this.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0095;
    Label_0076:
        this.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_0095:
        return;
    }

    protected virtual unsafe bool Walk()
    {
        Transform transform1;
        float num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.isActive == null)
        {
            goto Label_0081;
        }
        if (this.isFighting == null)
        {
            goto Label_007A;
        }
        if ((this.enemy == null) != null)
        {
            goto Label_0047;
        }
        if (this.enemy.IsActive() == null)
        {
            goto Label_0047;
        }
        if (this.enemy.IsBlocked() != null)
        {
            goto Label_0063;
        }
    Label_0047:
        this.UnBlock();
        if (this.FindEnemy() != null)
        {
            goto Label_0081;
        }
        this.SetGoToIdleStatus();
        goto Label_0075;
    Label_0063:
        if (this.isBlocking != null)
        {
            goto Label_0081;
        }
        this.FindEnemy();
    Label_0075:
        goto Label_0081;
    Label_007A:
        this.FindEnemy();
    Label_0081:
        if (this.DestinationReach() == null)
        {
            goto Label_008E;
        }
        return 1;
    Label_008E:
        num = Mathf.Atan2(&this.destinationPoint.y - &base.transform.position.y, &this.destinationPoint.x - &base.transform.position.x);
        if (&this.destinationPoint.x >= &base.transform.position.x)
        {
            goto Label_0119;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0138;
    Label_0119:
        base.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_0138:
        this.AddWalkParticle();
        transform1 = base.transform;
        transform1.position += new Vector3(Mathf.Cos(num) * this.speed, Mathf.Sin(num) * this.speed, 0f);
        return 0;
    }

    public void WalkAnimation()
    {
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.PlayAnimationWalk();
        return;
    }
}

