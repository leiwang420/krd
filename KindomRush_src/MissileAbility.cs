using System;
using System.Collections;
using UnityEngine;

public class MissileAbility : AbilityBase
{
    private int damageIncrement;
    private int maxDamage;
    private int minDamage;
    public Transform missilePrefab;
    private int range;
    private float rangeIncrement;
    private bool ready;
    private float reloadTimer;
    private CreepSpawner spawner;
    private Creep target;
    private float xDest;
    private float yDest;

    public MissileAbility()
    {
        this.minDamage = 60;
        this.maxDamage = 100;
        this.damageIncrement = 40;
        this.rangeIncrement = 0.2f;
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public bool CanFire()
    {
        return (((this.target != null) == null) ? 0 : this.ready);
    }

    public unsafe void Fire()
    {
        Transform transform;
        Missile missile;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        transform = UnityEngine.Object.Instantiate(this.missilePrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        missile = transform.GetComponent<Missile>();
        &vector = new Vector3(&base.transform.position.x - 35f, &base.transform.position.y, -899f);
        missile.Init(vector, this.target, base.level, this.target.isFlying);
        missile.SetDamage(this.minDamage, this.maxDamage);
        GameAchievements.MissileFire();
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.level <= 0)
        {
            goto Label_0058;
        }
        if (this.ready != null)
        {
            goto Label_0058;
        }
        this.reloadTimer += Time.deltaTime;
        if (this.reloadTimer < base.reload)
        {
            goto Label_0058;
        }
        this.ready = 1;
        this.reloadTimer = 0f;
    Label_0058:
        return;
    }

    public bool IsReady()
    {
        return this.ready;
    }

    public override void LevelUp()
    {
        base.level += 1;
        this.minDamage += this.damageIncrement;
        this.maxDamage += this.damageIncrement;
        this.range = (int) (((float) base.tower.range) + (((float) (base.tower.range * base.level)) * this.rangeIncrement));
        return;
    }

    public unsafe void LookForTarget()
    {
        Creep creep;
        Vector3 vector;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        int num;
        Vector2 vector2;
        int num2;
        IDisposable disposable;
        if (base.level <= 0)
        {
            goto Label_0175;
        }
        creep = null;
        this.target = null;
        vector = Vector3.zero;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_002C:
        try
        {
            goto Label_00F8;
        Label_0031:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            num = creep2.GetNodesSpeed();
            vector2 = creep2.GetNode(num);
            &vector.Set(&vector2.x, &vector2.y, 0f);
            if (creep2.IsActive() == null)
            {
                goto Label_00F8;
            }
            if (IronUtils.ellipseContainPoint(vector, ((float) this.range) * 0.7f, (float) this.range, base.transform.position + new Vector3(0f, (float) -(base.tower.yAdjust + base.tower.yRangeAdjust), 0f)) == null)
            {
                goto Label_00F8;
            }
            if ((creep == null) != null)
            {
                goto Label_00F5;
            }
            if (base.tower.IsNearExit(creep, creep2) == null)
            {
                goto Label_00F8;
            }
        Label_00F5:
            creep = creep2;
        Label_00F8:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0031;
            }
            goto Label_011D;
        }
        finally
        {
        Label_0108:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0115;
            }
        Label_0115:
            disposable.Dispose();
        }
    Label_011D:
        if ((creep != null) == null)
        {
            goto Label_0175;
        }
        this.target = creep;
        num2 = this.target.GetNodesSpeed();
        vector = this.target.GetNode(num2);
        this.xDest = &vector.x;
        this.yDest = &vector.y;
        base.tower.BeginFire();
    Label_0175:
        return;
    }

    public void Reset()
    {
        this.ready = 0;
        this.target = null;
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("BFGTower") as BFGTower;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.reload = 11f;
        this.ready = 0;
        return;
    }
}

