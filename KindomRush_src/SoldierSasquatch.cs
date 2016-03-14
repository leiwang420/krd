using System;
using System.Collections;
using UnityEngine;

public class SoldierSasquatch : Soldier
{
    protected int areaAttackMax;
    protected Vector2 areaAttackPoint;
    protected int areaAttackRangeHeight;
    protected int areaAttackRangeWidth;
    protected int lifes;

    public SoldierSasquatch()
    {
        base..ctor();
        return;
    }

    protected void AreaAttack()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0093;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0093;
            }
            if (creep.isFlying != null)
            {
                goto Label_0093;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.areaAttackRangeHeight, (float) this.areaAttackRangeWidth, this.areaAttackPoint) == null)
            {
                goto Label_0093;
            }
            creep.Damage(this.GetDamage(), 1, 0, 0);
            num += 1;
            if (num != this.areaAttackMax)
            {
                goto Label_0093;
            }
            goto Label_009E;
        Label_0093:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
        Label_009E:
            goto Label_00B8;
        }
        finally
        {
        Label_00A3:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B0;
            }
        Label_00B0:
            disposable.Dispose();
        }
    Label_00B8:
        return;
    }

    private void Awake()
    {
        base.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    public override void ChangeRallyPoint(Vector2 newRallyPoint)
    {
        base.rallyPoint = newRallyPoint + new Vector2(0f, base.yAdjust + 25f);
        if (base.isDead != null)
        {
            goto Label_0038;
        }
        if (base.isRespawning == null)
        {
            goto Label_0039;
        }
    Label_0038:
        return;
    Label_0039:
        base.isActive = 0;
        base.isCharging = 0;
        base.UnBlock();
        this.SetGoToIdleStatus();
        this.StopSpecial();
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
            goto Label_004F;
        }
        return new Vector2(&base.transform.position.x + 49f, &base.transform.position.y);
    Label_004F:
        return new Vector2(&base.transform.position.x - 49f, &base.transform.position.y);
    }

    protected override void HitEnemy()
    {
        this.areaAttackPoint = this.GetAttackPoint();
        if ((base.enemy == null) != null)
        {
            goto Label_002D;
        }
        if (base.enemy.IsActive() != null)
        {
            goto Label_003A;
        }
    Label_002D:
        base.UnBlock();
        this.SetGoToIdleStatus();
        return;
    Label_003A:
        this.AreaAttack();
        if (base.enemy.IsActive() != null)
        {
            goto Label_0056;
        }
        base.UnBlock();
    Label_0056:
        return;
    }

    public override bool IsTowerSelected()
    {
        if ((base.tower == null) == null)
        {
            goto Label_0013;
        }
        return 1;
    Label_0013:
        return base.tower.IsRallySelected();
    }

    protected override void OnDeath()
    {
        base.stage.RemoveSoldier(this);
        return;
    }

    protected override bool ReadyToRespawn()
    {
        base.deadTimeCounter += 1;
        if (base.deadTimeCounter < base.deadTime)
        {
            goto Label_0060;
        }
        if (this.lifes != 1)
        {
            goto Label_0049;
        }
        ((TowerSasquatch) base.tower).RemoveSoldier(this);
        UnityEngine.Object.Destroy(base.gameObject);
        return 0;
    Label_0049:
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        return 1;
    Label_0060:
        return 0;
    }

    protected override unsafe void Respawn()
    {
        base.isActive = 1;
        base.isDead = 0;
        base.isRespawning = 0;
        base.isWalking = 1;
        base.isCharging = 0;
        base.isBlocking = 0;
        base.isFighting = 0;
        base.isIdle = 0;
        base.destinationPoint = new Vector2(&this.rallyPoint.x, &this.rallyPoint.y);
        base.health = base.initHealth;
        base.mainBar.gameObject.SetActive(1);
        base.deadTimeCounter = 0;
        base.respawnTimeCounter = 0;
        base.sprite.PlayAnim("walk");
        GameAchievements.TrainSoldier();
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        int num;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f);
        base.spawnPosition = new Vector2(&base.transform.position.x, &base.transform.position.y);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.attackChargeTime = 30;
        base.attackChargeDamageTime = 13;
        base.rangeWidth = 0xea;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.health = base.initHealth = 0x9c4;
        base.regenerateHealth = 250;
        base.regenerateTime = 0x4b;
        base.armor = 0;
        base.minDamage = 50;
        base.maxDamage = 110;
        base.deadTime = 50;
        base.attackReloadTime = 0x4b - base.attackChargeTime;
        this.areaAttackRangeWidth = 100;
        this.areaAttackRangeHeight = Mathf.RoundToInt(((float) this.areaAttackRangeWidth) * 0.7f);
        this.areaAttackMax = 10;
        base.respawnTime = 1;
        base.speed = 2.3f;
        this.lifes = 1;
        base.idleTime = 30;
        base.xModifierAdjust = 0x47;
        base.yModifierAdjust = 0x2a;
        base.tower = GameObject.Find("Sasquash Cave Top").GetComponent<TowerSasquatch>();
        base.rallyPoint = new Vector2(-75f, 120f);
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        return;
    }
}

