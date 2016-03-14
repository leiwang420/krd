using System;
using System.Collections;
using UnityEngine;

public class SniperAbility : AbilityBase
{
    private int baseChance;
    private float range;
    private bool ready;
    private float reloadTimer;
    private CreepSpawner spawner;
    private TowerBase.states state;
    private Creep target;
    private float xDest;
    private float yDest;

    public SniperAbility()
    {
        base..ctor();
        return;
    }

    public unsafe void BulletSetup(Bullet bullet)
    {
        Vector3 vector;
        Vector3 vector2;
        if ((this.target == null) == null)
        {
            goto Label_0018;
        }
        this.LookForTarget();
    Label_0018:
        if ((this.target != null) == null)
        {
            goto Label_00B9;
        }
        bullet.SetTarget(this.target, &this.target.transform.position.x, &this.target.transform.position.y);
        bullet.SetDamage(UnityEngine.Random.Range(base.tower.minDamange, base.tower.maxDamage) + ((int) (((float) this.target.GetTotalLife()) * base.chance)));
        bullet.SetChance(this.baseChance * base.level);
        bullet.EnableParticles();
        GameSoundManager.PlaySniperSound();
    Label_00B9:
        return;
    }

    public bool CanFire()
    {
        return this.ready;
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

    public unsafe float GetXDest()
    {
        Vector3 vector;
        if ((this.target != null) == null)
        {
            goto Label_002A;
        }
        return &this.target.transform.position.x;
    Label_002A:
        return this.xDest;
    }

    public unsafe float GetYDest()
    {
        Vector3 vector;
        if ((this.target != null) == null)
        {
            goto Label_002A;
        }
        return &this.target.transform.position.y;
    Label_002A:
        return this.yDest;
    }

    public override void LevelUp()
    {
        base.level += 1;
        base.damage = this.baseChance * base.level;
        base.chance = ((float) (this.baseChance * base.level)) / 100f;
        return;
    }

    public unsafe bool LookForTarget()
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
            goto Label_015F;
        }
        if (this.ready == null)
        {
            goto Label_015F;
        }
        creep = null;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_002A:
        try
        {
            goto Label_00E5;
        Label_002F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_00E5;
            }
            if (creep2.isBoss != null)
            {
                goto Label_00E5;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, (this.range * ((float) base.tower.range)) * 0.7f, this.range * ((float) base.tower.range), base.transform.position + new Vector3(0f, (float) -base.tower.yAdjust, 0f)) == null)
            {
                goto Label_00E5;
            }
            if ((creep == null) != null)
            {
                goto Label_00E3;
            }
            if (base.tower.IsNearExit(creep, creep2) == null)
            {
                goto Label_00E5;
            }
        Label_00E3:
            creep = creep2;
        Label_00E5:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002F;
            }
            goto Label_010A;
        }
        finally
        {
        Label_00F5:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0102;
            }
        Label_0102:
            disposable.Dispose();
        }
    Label_010A:
        if ((creep != null) == null)
        {
            goto Label_015F;
        }
        this.xDest = &creep.transform.position.x;
        this.yDest = &creep.transform.position.y;
        this.target = creep;
        base.tower.SetState(1);
        return 1;
    Label_015F:
        return 0;
    }

    public void Reset()
    {
        this.ready = 0;
        this.target = null;
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("MusketeerTower") as MusketeerTower;
        this.baseChance = 20;
        this.range = 1.5f;
        base.reload = 14f;
        this.reloadTimer = 0f;
        this.target = null;
        this.ready = 0;
        base.chance = 0f;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }
}

