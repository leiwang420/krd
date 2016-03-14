using System;
using System.Collections;
using UnityEngine;

public class ClusterAbility : AbilityBase
{
    private int bombs;
    public Transform clusterBombPrefab;
    private bool ready;
    private float reloadTimer;
    private CreepSpawner spawner;
    private StageBase stage;
    private Creep target;
    private float xDest;
    private float yDest;

    public ClusterAbility()
    {
        this.bombs = 1;
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
        BombBox box;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.clusterBombPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 6f, -6f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        box = transform.GetComponent<BombBox>();
        box.SetDest(this.xDest, this.yDest + 120f);
        box.SetArea(131f);
        box.SetDamage(0, 0);
        box.SetTargetPath(this.target);
        box.SetBombs(this.bombs);
        box.SetStage(this.stage);
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
        this.bombs += 2;
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
            goto Label_018B;
        }
        creep = null;
        this.target = null;
        vector = Vector3.zero;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_002C:
        try
        {
            goto Label_010E;
        Label_0031:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            num = creep2.GetNodesSpeed();
            vector2 = creep2.GetNode(num);
            &vector.Set(&vector2.x, &vector2.y, 0f);
            if (creep2.isFlying != null)
            {
                goto Label_010E;
            }
            if (creep2.IsActive() == null)
            {
                goto Label_010E;
            }
            if (IronUtils.ellipseContainPoint(vector, ((float) base.tower.range) * 0.7f, (float) base.tower.range, base.transform.position + new Vector3(0f, (float) -(base.tower.yAdjust + base.tower.yRangeAdjust), 0f)) == null)
            {
                goto Label_010E;
            }
            if ((creep == null) != null)
            {
                goto Label_010B;
            }
            if (base.tower.IsNearExit(creep, creep2) == null)
            {
                goto Label_010E;
            }
        Label_010B:
            creep = creep2;
        Label_010E:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0031;
            }
            goto Label_0133;
        }
        finally
        {
        Label_011E:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_012B;
            }
        Label_012B:
            disposable.Dispose();
        }
    Label_0133:
        if ((creep != null) == null)
        {
            goto Label_018B;
        }
        this.target = creep;
        num2 = this.target.GetNodesSpeed();
        vector = this.target.GetNode(num2);
        this.xDest = &vector.x;
        this.yDest = &vector.y;
        base.tower.BeginFire();
    Label_018B:
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("BFGTower") as BFGTower;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.reload = 17f;
        this.ready = 0;
        return;
    }
}

