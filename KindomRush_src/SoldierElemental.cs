using System;
using System.Collections;
using UnityEngine;

public class SoldierElemental : Soldier
{
    private int areaAttackMax;
    private Vector3 areaAttackPoint;
    private int areaAttackRangeHeight;
    private int areaAttackRangeWidth;
    private int armorExtra;
    private int baseArmor;
    private int baseHealth;
    private int baseMaxDamage;
    private int baseMinDamage;
    private int damageExtra;
    public Transform decalSmokePrefab;
    public Transform effectSmokePrefab;
    private int extraHealth;
    private int level;

    public SoldierElemental()
    {
        base..ctor();
        return;
    }

    protected unsafe void AreaAttack()
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
            goto Label_00A8;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00A8;
            }
            if (creep.isFlying != null)
            {
                goto Label_00A8;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.areaAttackRangeHeight, (float) this.areaAttackRangeWidth, new Vector3(&this.areaAttackPoint.x, &this.areaAttackPoint.y, 0f)) == null)
            {
                goto Label_00A8;
            }
            creep.Damage(this.GetDamage(), 1, 0, 0);
            num += 1;
            if (num != this.areaAttackMax)
            {
                goto Label_00A8;
            }
            goto Label_00B3;
        Label_00A8:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
        Label_00B3:
            goto Label_00CD;
        }
        finally
        {
        Label_00B8:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C5;
            }
        Label_00C5:
            disposable.Dispose();
        }
    Label_00CD:
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

    protected override unsafe void HitEnemy()
    {
        this.areaAttackPoint = this.GetAttackPoint();
        GameSoundManager.PlayAreaAttack();
        UnityEngine.Object.Instantiate(this.decalSmokePrefab, new Vector3(&this.areaAttackPoint.x, &this.areaAttackPoint.y - 35f, -3f), Quaternion.identity);
        UnityEngine.Object.Instantiate(this.effectSmokePrefab, new Vector3(&this.areaAttackPoint.x, &this.areaAttackPoint.y - 17f, -800f), Quaternion.identity);
        if ((base.enemy == null) != null)
        {
            goto Label_00A5;
        }
        if (base.enemy.IsActive() != null)
        {
            goto Label_00B7;
        }
    Label_00A5:
        base.UnBlock();
        base.sprite.RevertToStatic();
        return;
    Label_00B7:
        this.AreaAttack();
        if ((base.enemy != null) == null)
        {
            goto Label_00E4;
        }
        if (base.enemy.IsActive() != null)
        {
            goto Label_00E4;
        }
        base.UnBlock();
    Label_00E4:
        return;
    }

    protected override void PlayAnimationDeath()
    {
        GameSoundManager.PlayRockElementalDeath();
        base.sprite.PlayAnim("death");
        return;
    }

    protected override bool ReadyToLive()
    {
        base.respawnTimeCounter += 1;
        if (base.respawnTimeCounter < base.respawnTime)
        {
            goto Label_0027;
        }
        this.Respawn();
        return 1;
    Label_0027:
        return 0;
    }

    protected override bool ReadyToRespawn()
    {
        base.deadTimeCounter += 1;
        if (base.deadTimeCounter < base.deadTime)
        {
            goto Label_0057;
        }
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        base.sprite.PlayAnim("respawn");
        base.sprite.Hide(0);
        GameSoundManager.PlayRockElementalDeath();
        return 1;
    Label_0057:
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
        base.deadTimeCounter = 0;
        base.respawnTimeCounter = 0;
        base.sprite.PlayAnim("walk");
        base.mainBar.gameObject.SetActive(1);
        GameSoundManager.PlayRockElementalRally();
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        int num;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        base.transform.name = "SoldierElemental";
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.rangeWidth = 0xd4;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        this.baseMinDamage = base.minDamage;
        this.baseMaxDamage = base.maxDamage;
        this.baseHealth = base.initHealth = 500;
        this.baseArmor = base.armor;
        base.regenerateTime = 30;
        base.regenerateHealth = 20;
        base.deadTimeCounter = base.deadTime - 1;
        this.extraHealth = 100;
        this.damageExtra = 10;
        this.armorExtra = 10;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        this.areaAttackRangeWidth = 0x6a;
        this.areaAttackRangeHeight = Mathf.RoundToInt(((float) this.areaAttackRangeWidth) * 0.7f);
        this.areaAttackMax = 4;
        base.sprite.PlayAnim("respawn");
        GameSoundManager.PlayRockElementalRally();
        return;
    }

    public void Upgrade(int elementalLevel)
    {
        int num;
        this.level = elementalLevel;
        base.health = base.initHealth = this.baseHealth + (this.extraHealth * this.level);
        base.armor = this.baseArmor + (this.armorExtra * this.level);
        base.minDamage = this.baseMinDamage + (this.damageExtra * this.level);
        base.maxDamage = this.baseMaxDamage + (this.damageExtra * this.level);
        return;
    }
}

