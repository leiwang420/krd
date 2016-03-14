using System;
using System.Collections;
using UnityEngine;

public class DeathRayAbility : AbilityBase
{
    public Transform deathRayPrefab;
    private bool ready;
    private float reloadTimer;
    private CreepSpawner spawner;
    private Creep target;
    private float xDest;
    private float yDest;

    public DeathRayAbility()
    {
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
        BaseProjectile projectile;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if ((this.target == null) == null)
        {
            goto Label_0017;
        }
        this.LookForTarget();
    Label_0017:
        transform = UnityEngine.Object.Instantiate(this.deathRayPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 24f, -840f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        projectile = transform.GetComponent<BaseProjectile>();
        projectile.SetTarget(this.target, this.xDest, this.yDest);
        projectile.SetDamage(this.target.GetTotalLife());
        ((DeathRay) projectile).SetTowerPos(&base.tower.transform.position.x, &base.tower.transform.position.y);
        this.ready = 0;
        this.target = null;
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
        base.reload -= 2f;
        return;
    }

    public unsafe void LookForTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        if (base.level <= 0)
        {
            goto Label_0144;
        }
        creep = null;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_001F:
        try
        {
            goto Label_00CC;
        Label_0024:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_00CC;
            }
            if (creep2.isBoss != null)
            {
                goto Label_00CC;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, ((float) base.tower.range) * 0.7f, (float) base.tower.range, base.transform.position + new Vector3(0f, (float) -base.tower.yAdjust, 0f)) == null)
            {
                goto Label_00CC;
            }
            if ((creep == null) != null)
            {
                goto Label_00CA;
            }
            if (base.tower.IsNearExit(creep, creep2) == null)
            {
                goto Label_00CC;
            }
        Label_00CA:
            creep = creep2;
        Label_00CC:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
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
        if ((creep != null) == null)
        {
            goto Label_0144;
        }
        this.xDest = &creep.transform.position.x;
        this.yDest = &creep.transform.position.y;
        this.target = creep;
        base.tower.SetState(1);
    Label_0144:
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("ArcaneTower") as ArcaneTower;
        base.reload = 22f;
        this.ready = 0;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }
}

