using System;
using System.Collections;
using UnityEngine;

public class WitchProjectileMissile : BaseProjectile
{
    public float acceleration;
    protected bool airHit;
    protected float angleFollow;
    public int area;
    protected float correctAngle;
    protected float correctAngleMax;
    public Transform explosion;
    public Transform explosionAir;
    protected bool follow;
    protected bool isGoingHeight;
    protected Vector2 lastDest;
    protected int level;
    public float maxAcceleration;
    protected int maxDamage;
    protected int minDamage;
    public Transform particle;
    protected float rangeHeight;
    protected float rangeWidth;
    protected float rotation;
    protected CreepSpawner spawner;
    protected ArrayList tmpSoldiers;
    protected bool turning;
    protected float turningAngle;
    protected float xSpeed;
    protected float ySpeed;

    public WitchProjectileMissile()
    {
        base..ctor();
        return;
    }

    private float AngleDifference(float angle0, float angle1)
    {
        return (float) Mathf.Abs((((((int) angle0) + 180) - ((int) angle1)) % 360) - 180);
    }

    private float DegFromDeg(float p_degInput)
    {
        float num;
        num = p_degInput;
        goto Label_000F;
    Label_0007:
        num -= 360f;
    Label_000F:
        if (num >= 360f)
        {
            goto Label_0007;
        }
        goto Label_0027;
    Label_001F:
        num += 360f;
    Label_0027:
        if (num < 0f)
        {
            goto Label_001F;
        }
        return num;
    }

    private void FindNewTarget()
    {
        Soldier soldier;
        Soldier soldier2;
        IEnumerator enumerator;
        IDisposable disposable;
        soldier = null;
        this.tmpSoldiers = base.stage.GetSoldiers();
        base.targetSoldier = null;
        enumerator = this.tmpSoldiers.GetEnumerator();
    Label_0026:
        try
        {
            goto Label_005D;
        Label_002B:
            soldier2 = (Soldier) enumerator.Current;
            if (soldier2.IsActive() == null)
            {
                goto Label_005D;
            }
            if ((soldier == null) != null)
            {
                goto Label_005B;
            }
            if (this.IsNearExit(soldier, soldier2) == null)
            {
                goto Label_005D;
            }
        Label_005B:
            soldier = soldier2;
        Label_005D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002B;
            }
            goto Label_007F;
        }
        finally
        {
        Label_006D:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0078;
            }
        Label_0078:
            disposable.Dispose();
        }
    Label_007F:
        if ((soldier != null) == null)
        {
            goto Label_00A7;
        }
        base.targetSoldier = soldier;
        this.airHit = 0;
        this.follow = 0;
        this.turning = 0;
    Label_00A7:
        return;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform1;
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        num = 0f;
        num2 = 0f;
        num3 = 0f;
        num4 = 0f;
        num5 = 0f;
        if (this.isGoingHeight != null)
        {
            goto Label_005D;
        }
        if ((base.targetSoldier == null) != null)
        {
            goto Label_0057;
        }
        if (base.targetSoldier.IsActive() != null)
        {
            goto Label_005D;
        }
    Label_0057:
        this.FindNewTarget();
    Label_005D:
        if (this.isGoingHeight != null)
        {
            goto Label_00E6;
        }
        if ((base.targetSoldier != null) == null)
        {
            goto Label_00E6;
        }
        base.xDest = &base.targetSoldier.transform.position.x + base.targetSoldier.xAdjust;
        base.yDest = &base.targetSoldier.transform.position.y + base.targetSoldier.yAdjust;
        &this.lastDest.Set(base.xDest, base.yDest);
    Label_00E6:
        num2 = base.xDest - &base.transform.position.x;
        num = base.yDest - &base.transform.position.y;
        num3 = num4 = Mathf.Atan2(-num, num2);
        if (this.isGoingHeight != null)
        {
            goto Label_025F;
        }
        if (this.follow != null)
        {
            goto Label_01F7;
        }
        if (this.turning != null)
        {
            goto Label_018B;
        }
        if (&base.transform.position.x <= base.xDest)
        {
            goto Label_0179;
        }
        this.turningAngle = 10f;
        goto Label_0184;
    Label_0179:
        this.turningAngle = -10f;
    Label_0184:
        this.turning = 1;
    Label_018B:
        num5 = this.DegFromDeg(57.32484f * Mathf.Atan2(this.ySpeed, this.xSpeed)) + this.turningAngle;
        num3 = (num5 * 3.14f) / 180f;
        if (this.AngleDifference(this.DegFromDeg((num4 * 180f) / 3.14f), this.DegFromDeg(num5)) >= 11f)
        {
            goto Label_025F;
        }
        this.follow = 1;
        goto Label_025F;
    Label_01F7:
        num3 = ((((num3 * 180f) / 3.14f) + this.angleFollow) * 3.14f) / 180f;
        if (this.acceleration >= this.maxAcceleration)
        {
            goto Label_025F;
        }
        this.acceleration += this.acceleration * 0.1f;
        if (this.acceleration < this.maxAcceleration)
        {
            goto Label_025F;
        }
        this.acceleration = this.maxAcceleration;
    Label_025F:
        this.xSpeed = Mathf.Cos(num3) * this.acceleration;
        this.ySpeed = Mathf.Sin(num3) * this.acceleration;
        this.rotation = 360f - ((Mathf.Atan2(-this.ySpeed, this.xSpeed) * 180f) / 3.14f);
        transform1 = base.transform;
        transform1.position += new Vector3(this.xSpeed, -this.ySpeed, 0f);
        base.transform.rotation = Quaternion.identity;
        this.rotation += 180f;
        base.transform.Rotate(0f, 0f, -this.rotation);
        this.SpawnParticles();
        if (Mathf.Sqrt(Mathf.Pow(base.yDest - &base.transform.position.y, 2f) + Mathf.Pow(base.xDest - &base.transform.position.x, 2f)) >= this.acceleration)
        {
            goto Label_043B;
        }
        if (this.isGoingHeight == null)
        {
            goto Label_0430;
        }
        this.isGoingHeight = 0;
        if ((base.targetSoldier == null) != null)
        {
            goto Label_03AE;
        }
        if (base.targetSoldier.IsActive() != null)
        {
            goto Label_03D5;
        }
    Label_03AE:
        base.xDest = &this.lastDest.x;
        base.yDest = &this.lastDest.y;
        goto Label_042B;
    Label_03D5:
        base.xDest = &base.targetSoldier.transform.position.x + base.targetSoldier.xAdjust;
        base.yDest = &base.targetSoldier.transform.position.y + base.targetSoldier.yAdjust;
    Label_042B:
        goto Label_043B;
    Label_0430:
        GameSoundManager.PlayBombExplosionSound();
        this.Hit();
    Label_043B:
        return;
    }

    private unsafe int GetDamage(Vector3 enemyPos)
    {
        float num;
        Vector2 vector;
        float num2;
        float num3;
        float num4;
        int num5;
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
        num = (Mathf.Atan2(&enemyPos.x - &base.transform.position.x, &enemyPos.y - &base.transform.position.y) * 180f) / 3.141593f;
        vector = this.GetDestinationPoint(num);
        num2 = Mathf.Sqrt(((&vector.x - &base.transform.position.x) * (&vector.x - &base.transform.position.x)) + ((&vector.y - &base.transform.position.y) * (&vector.y - &base.transform.position.y)));
        num3 = Mathf.Sqrt(((&enemyPos.x - &base.transform.position.x) * (&enemyPos.x - &base.transform.position.x)) + ((&enemyPos.y - &base.transform.position.y) * (&enemyPos.y - &base.transform.position.y)));
        num4 = (float) (this.maxDamage - this.minDamage);
        num5 = ((int) (num4 - ((num3 * num4) / num2))) + this.minDamage;
        return num5;
    }

    private unsafe Vector2 GetDestinationPoint(float angle)
    {
        Vector3 vector;
        Vector3 vector2;
        return IronUtils.ellipseGetPointOfDegree(angle, this.rangeHeight, this.rangeWidth, new Vector2(&base.transform.position.x, &base.transform.position.y));
    }

    public override unsafe void Hit()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Transform transform2;
        Vector3 vector;
        Vector3 vector2;
        IDisposable disposable;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        this.acceleration = 0f;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_001C:
        try
        {
            goto Label_00CC;
        Label_0021:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00CC;
            }
            if (IronUtils.ellipseContainPoint(new Vector3(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y + creep.yAdjust, 0f), this.rangeHeight, this.rangeWidth, base.transform.position) == null)
            {
                goto Label_00CC;
            }
            creep.Damage(this.GetDamage(creep.transform.position), 3, 0, 0);
            if (creep.GetHealth() > 0)
            {
                goto Label_00CC;
            }
            creep.Gib();
        Label_00CC:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0021;
            }
            goto Label_00F1;
        }
        finally
        {
        Label_00DC:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E9;
            }
        Label_00E9:
            disposable.Dispose();
        }
    Label_00F1:
        this.rotation = 0f;
        if (this.airHit == null)
        {
            goto Label_0160;
        }
        transform2 = UnityEngine.Object.Instantiate(this.explosionAir, new Vector3(&base.transform.position.x, &base.transform.position.y, -840f), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform2);
        goto Label_01BA;
    Label_0160:
        transform2 = UnityEngine.Object.Instantiate(this.explosion, new Vector3(&base.transform.position.x, &base.transform.position.y + 15f, -840f), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform2);
    Label_01BA:
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    public unsafe void Init(Vector2 pos, Soldier myTarget, int myLevel, bool isAirHit)
    {
        Vector3 vector;
        Vector3 vector2;
        base.transform.position = new Vector3(&pos.x, &pos.y, -899f);
        base.targetSoldier = myTarget;
        this.level = myLevel;
        this.airHit = isAirHit;
        this.maxAcceleration = 28.125f;
        this.angleFollow = 0.2f;
        this.isGoingHeight = 1;
        this.follow = 0;
        this.turning = 0;
        base.xDest = &base.transform.position.x + 22.5f;
        base.yDest = &base.transform.position.y + 206f;
        &this.lastDest.Set(base.xDest, base.yDest);
        this.xSpeed = Mathf.Cos(1.570796f) * this.acceleration;
        this.ySpeed = Mathf.Sin(1.570796f) * this.acceleration;
        this.rangeWidth = ((float) this.area) * 1.5f;
        this.rangeHeight = (((float) this.area) * 1.5f) * 0.7f;
        return;
    }

    private bool IsNearExit(Soldier enemy, Soldier enemyNew)
    {
        return 0;
    }

    public override void Pause()
    {
        base.isPaused = 1;
        base.GetComponent<PackedSprite>().PauseAnim();
        return;
    }

    public void SetDamage(int min, int max)
    {
        this.minDamage = min;
        this.maxDamage = max;
        return;
    }

    private unsafe void SpawnParticles()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        transform = UnityEngine.Object.Instantiate(this.particle, new Vector3(&base.transform.position.x + 2f, &base.transform.position.y, -898f), Quaternion.identity) as Transform;
        transform.parent = base.transform.parent;
        transform = UnityEngine.Object.Instantiate(this.particle, new Vector3(&base.transform.position.x - 2f, &base.transform.position.y, -898f), Quaternion.identity) as Transform;
        transform.parent = base.transform.parent;
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.tmpSoldiers = base.stage.GetSoldiers();
        GameSoundManager.PlayRocketLaunchSound();
        return;
    }

    public override void Unpause()
    {
        base.isPaused = 0;
        base.GetComponent<PackedSprite>().UnpauseAnim();
        return;
    }
}

