using System;
using UnityEngine;

public class SoldierReinforcement : Soldier
{
    protected int lifes;
    public Vector2 rangePoint;

    public SoldierReinforcement()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.LoadNames();
        return;
    }

    public virtual unsafe void InitWithPosition(Vector2 pos, Vector2 pRallyPoint, int pNameMax, bool pRespawnOnInit, Vector2 myRangePoint)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.rallyPoint = pRallyPoint;
        base.targetedTime = 60;
        base.respawnOnInit = pRespawnOnInit;
        this.rangePoint = myRangePoint;
        base.regenerateTime = 30;
        base.xAdjust = 5f;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z + 1f), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.isLifeTimed = 1;
        base.lifeTimeCounter = 0;
        base.deadTimeCounter = base.deadTime - 1;
        return;
    }

    public override bool IsTowerSelected()
    {
        return 0;
    }

    protected override unsafe bool OnRange(Creep myEnemy)
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        num = Mathf.Round(&myEnemy.transform.position.x + &myEnemy.anchorPoint.x);
        num2 = Mathf.Round(&myEnemy.transform.position.y + &myEnemy.anchorPoint.y);
        &vector = new Vector3(num, num2, 0f);
        return IronUtils.ellipseContainPoint(vector, (float) base.rangeHeight, (float) base.rangeWidth, this.rangePoint);
    }

    protected virtual void PlayAnimationRespawn()
    {
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
            goto Label_0063;
        }
        if (this.lifes == 1)
        {
            goto Label_0038;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return 0;
    Label_0038:
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        this.lifes += 1;
        this.PlayAnimationRespawn();
        return 1;
    Label_0063:
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
        base.transform.position = new Vector3(&this.rallyPoint.x, &this.rallyPoint.y, -3f);
        base.destinationPoint = new Vector2(&this.rallyPoint.x, &this.rallyPoint.y);
        base.health = base.initHealth;
        base.deadTimeCounter = 0;
        base.respawnTimeCounter = 0;
        return;
    }

    private void Start()
    {
        base.yAdjust = 2f;
        base.yLifebarOffset = 20;
        base.deadTime = 10;
        base.attackChargeTime = 11;
        base.attackChargeDamageTime = 5;
        base.attackReloadTime = (GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "reload") * 30) - base.attackChargeTime;
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.canBeSkeleteon = 0;
        this.LoadNames();
        base.SetRandomName();
        return;
    }
}

