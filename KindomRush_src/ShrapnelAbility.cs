using System;
using System.Collections;
using UnityEngine;

public class ShrapnelAbility : AbilityBase
{
    private int area;
    private int baseMaxDamage;
    private int baseMinDamage;
    private int maxDamage;
    private int minDamage;
    private float range;
    private bool ready;
    private float reloadTimer;
    private CreepSpawner spawner;
    private Creep target;
    private float xDest;
    private float yDest;

    public ShrapnelAbility()
    {
        base..ctor();
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

    public float GetXDest()
    {
        return this.xDest;
    }

    public float GetYDest()
    {
        return this.yDest;
    }

    public override void LevelUp()
    {
        base.level += 1;
        this.maxDamage = this.baseMaxDamage * base.level;
        this.minDamage = this.baseMinDamage * base.level;
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
            if (creep2.isFlying != null)
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

    public unsafe void ShrapnelSetup(BombShrapnel bomb, int angle)
    {
        Vector2 vector;
        int num;
        int num2;
        Vector2 vector2;
        if ((this.target == null) == null)
        {
            goto Label_0018;
        }
        this.LookForTarget();
    Label_0018:
        if ((this.target != null) == null)
        {
            goto Label_00D1;
        }
        vector = this.target.GetNode(4);
        bomb.SetDamage(this.minDamage, this.maxDamage);
        bomb.SetArea((float) this.area);
        num = Mathf.RoundToInt((UnityEngine.Random.Range(0f, 1f) * 56f) + 35f);
        num2 = Mathf.RoundToInt(((float) num) * 0.7f);
        vector2 = IronUtils.ellipseGetPointOfDegree((float) angle, (float) num2, (float) num, vector);
        bomb.SetTarget(this.target, &vector2.x, &vector2.y);
        bomb.SetT1(Mathf.Round((UnityEngine.Random.Range(0f, 1f) * 5f) + 5f));
    Label_00D1:
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("MusketeerTower") as MusketeerTower;
        this.range = 0.5f;
        base.reload = 9f;
        this.reloadTimer = 0f;
        this.target = null;
        this.ready = 0;
        this.baseMinDamage = 10;
        this.baseMaxDamage = 40;
        this.area = 0x60;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }
}

