using System;
using System.Collections;
using UnityEngine;

public class SoldierMageIllusion : SoldierReinforcement
{
    public Transform boltPrefab;
    private int direction;
    private bool isRangeShooting;
    private int level;
    private int rangeShootChargeTime;
    private int rangeShootChargeTimeCounter;
    private int rangeShootHeight;
    private int rangeShootMaxDamage;
    private int rangeShootMinDamage;
    private int rangeShootMinDistance;
    private Vector2 rangeShootPoint;
    private float rangeShootReloadTime;
    private int rangeShootReloadTimeCounter;
    private Creep rangeShootTarget;
    private int rangeShootWidth;

    public SoldierMageIllusion()
    {
        base..ctor();
        return;
    }

    protected unsafe bool EvalRangeShoot()
    {
        int num;
        Transform transform;
        Bolt bolt;
        Vector3 vector;
        Vector3 vector2;
        if (base.isFighting != null)
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
        if (this.isRangeShooting != null)
        {
            goto Label_00D8;
        }
        if (((float) this.rangeShootReloadTimeCounter) >= this.rangeShootReloadTime)
        {
            goto Label_0037;
        }
        return 0;
    Label_0037:
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_0044;
        }
        return 0;
    Label_0044:
        if (&this.rangeShootTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_0099;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00B8;
    Label_0099:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00B8:
        this.isRangeShooting = 1;
        this.rangeShootChargeTimeCounter = 0;
        base.sprite.PlayAnim("shoot");
        return 1;
    Label_00D8:
        if (this.rangeShootChargeTimeCounter >= this.rangeShootChargeTime)
        {
            goto Label_018F;
        }
        this.rangeShootChargeTimeCounter += 1;
        if (this.rangeShootChargeTimeCounter != 14)
        {
            goto Label_018D;
        }
        num = this.GetDamageRangeShoot();
        transform = UnityEngine.Object.Instantiate(this.boltPrefab, base.transform.position + new Vector3(0f, 24f, 0f), Quaternion.identity) as Transform;
        base.stage.AddProjectile(transform);
        bolt = transform.GetComponent<Bolt>();
        bolt.SetTarget(this.rangeShootTarget, &this.rangeShootPoint.x, &this.rangeShootPoint.y);
        bolt.SetDamage(num);
        bolt.SetStage(base.stage);
    Label_018D:
        return 1;
    Label_018F:
        this.isRangeShooting = 0;
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
            goto Label_0068;
        Label_001F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if ((transform != null) == null)
            {
                goto Label_0068;
            }
            if (creep2.IsActive() == null)
            {
                goto Label_0068;
            }
            if (this.MinRangeShootDistance(creep2) == null)
            {
                goto Label_0068;
            }
            if (this.OnRangeShoot(creep2) == null)
            {
                goto Label_0068;
            }
            creep = creep2;
            goto Label_0073;
        Label_0068:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_0073:
            goto Label_008D;
        }
        finally
        {
        Label_0078:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0085;
            }
        Label_0085:
            disposable.Dispose();
        }
    Label_008D:
        if ((creep != null) == null)
        {
            goto Label_00E3;
        }
        this.rangeShootTarget = creep;
        this.rangeShootPoint = new Vector2(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y + creep.yAdjust);
        return 1;
    Label_00E3:
        return 0;
    }

    protected int GetDamageRangeShoot()
    {
        return UnityEngine.Random.Range(this.rangeShootMinDamage, this.rangeShootMaxDamage + 1);
    }

    public void Init(Vector2 pos, Vector2 pRallyPoint, int pNameMax, bool pRespawnOnInit, Vector2 myRangePoint, int myLevel, int dir)
    {
        base.InitWithPosition(pos, pRallyPoint, pNameMax, pRespawnOnInit, myRangePoint);
        this.LevelUp(myLevel);
        this.direction = dir;
        return;
    }

    protected void LevelUp(int myLevel)
    {
        int num;
        this.level = myLevel;
        base.health = base.initHealth = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_mage", "health", this.level) * 0.3f);
        base.minDamage = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_mage", "minDamage", this.level) * 0.2f);
        base.maxDamage = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_mage", "maxDamage", this.level) * 0.2f);
        this.rangeShootMinDamage = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_mage", "minRangeDamage", this.level) * 0.2f);
        this.rangeShootMaxDamage = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_mage", "maxRangeDamage", this.level) * 0.2f);
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

    protected override void PlayAnimationDeath()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position -= new Vector3(0f, 35f, 0f);
        base.sprite.PlayAnim("death");
        return;
    }

    protected override unsafe void PlayAnimationRespawn()
    {
        object[] objArray3;
        object[] objArray2;
        object[] objArray1;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        base.sprite.PlayAnim("respawn");
        base.Invoke("RespawnEndAnim", 0.4f);
        if (this.direction != null)
        {
            goto Label_00AF;
        }
        objArray1 = new object[] { "position", (Vector3) new Vector3(&base.transform.position.x, &base.transform.position.y + 42f, &base.transform.position.z), "time", (float) 0.4f };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        goto Label_01C3;
    Label_00AF:
        if (this.direction != 1)
        {
            goto Label_0141;
        }
        objArray2 = new object[] { "position", (Vector3) new Vector3(&base.transform.position.x, &base.transform.position.y - 42f, &base.transform.position.z), "time", (float) 0.4f };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray2));
        goto Label_01C3;
    Label_0141:
        objArray3 = new object[] { "position", (Vector3) new Vector3(&base.transform.position.x + 42f, &base.transform.position.y, &base.transform.position.z), "time", (float) 0.4f };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray3));
    Label_01C3:
        return;
    }

    protected override void Respawn()
    {
        base.isActive = 1;
        base.isDead = 0;
        base.isRespawning = 0;
        base.isWalking = 1;
        base.isCharging = 0;
        base.isBlocking = 0;
        base.isFighting = 0;
        base.isIdle = 0;
        base.destinationPoint = base.rallyPoint;
        base.health = base.initHealth;
        base.deadTimeCounter = 0;
        base.respawnTimeCounter = 0;
        base.sprite.SetColor(new Color(1f, 1f, 1f, 0.7f));
        return;
    }

    protected void RespawnEndAnim()
    {
        base.sprite.PlayAnim("respawnEnd");
        return;
    }

    protected override bool RunSpecial()
    {
        this.rangeShootReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_001B;
        }
        return 1;
    Label_001B:
        if (this.EvalRangeShoot() == null)
        {
            goto Label_0028;
        }
        return 1;
    Label_0028:
        return 0;
    }

    private void Start()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.attackChargeTime = 0x16;
        base.attackChargeDamageTime = 12;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_mage", "mirageRangeRally", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_mage", "mirageRegen", 1);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_mage", "mirageRegenReload", 1)) * 30;
        base.armor = (int) GameSettings.GetHeroSetting("hero_mage", "mirageArmor", 1);
        base.deadTime = 14;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_mage", "mirageReload", 1)) * 30) - base.attackChargeTime;
        this.rangeShootReloadTime = (float) (((int) GameSettings.GetHeroSetting("hero_mage", "rangeShootReloadTime", 1)) * 30);
        this.rangeShootWidth = (int) GameSettings.GetHeroSetting("hero_mage", "rangeShootRangeWidth", 1);
        this.rangeShootHeight = Mathf.RoundToInt(((float) this.rangeShootWidth) * 0.7f);
        this.rangeShootMinDistance = (int) GameSettings.GetHeroSetting("hero_mage", "rangeShootMinDistance", 1);
        base.respawnTime = 0x13;
        this.rangeShootChargeTime = 0x21;
        base.speed = 2.2f;
        base.lifes = 1;
        base.xAdjust = 5.6f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.isLifeTimed = 1;
        base.lifeTime = ((int) GameSettings.GetHeroSetting("hero_mage", "lifeTime", 1)) * 30;
        base.lifeTimeCounter = 0;
        base.deadTimeCounter = base.deadTime - 1;
        base.canBeCourage = 0;
        base.damageType = 2;
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isRangeShooting = 0;
        base.isCharging = 0;
        return;
    }
}

