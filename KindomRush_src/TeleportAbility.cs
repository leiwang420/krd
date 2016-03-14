using System;
using System.Collections;
using UnityEngine;

public class TeleportAbility : AbilityBase
{
    private ArrayList creeps;
    private int extraNodes;
    private int maxEnemies;
    private int nodes;
    private float range;
    private bool ready;
    private float reloadTimer;
    private GameObject spawner;
    public Transform starEffect;
    private Creep target;
    public Transform teleportDecal;

    public TeleportAbility()
    {
        this.maxEnemies = 3;
        this.range = 122f;
        this.nodes = 20;
        this.extraNodes = 5;
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

    public void Fire()
    {
        Transform transform;
        Creep creep;
        IEnumerator enumerator;
        IDisposable disposable;
        GameSoundManager.PlayTeleporthSound();
        transform = UnityEngine.Object.Instantiate(this.teleportDecal, this.target.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.name = "teleportDecal";
        enumerator = this.creeps.GetEnumerator();
    Label_004E:
        try
        {
            goto Label_0091;
        Label_0053:
            creep = (Creep) enumerator.Current;
            if (creep.isBoss != null)
            {
                goto Label_0091;
            }
            if (creep.IsActive() == null)
            {
                goto Label_0091;
            }
            if (creep.IsDead() != null)
            {
                goto Label_0091;
            }
            creep.TeleportStart(this.nodes);
            GameAchievements.CheckBeamMeUp();
        Label_0091:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0053;
            }
            goto Label_00B3;
        }
        finally
        {
        Label_00A1:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00AC;
            }
        Label_00AC:
            disposable.Dispose();
        }
    Label_00B3:
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

    private ArrayList GetCreepsInRange()
    {
        ArrayList list;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        list = new ArrayList();
        if (this.target.CanTeleport() == null)
        {
            goto Label_0028;
        }
        list.Add(this.target.GetComponent<Creep>());
    Label_0028:
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0039:
        try
        {
            goto Label_00CF;
        Label_003E:
            transform = (Transform) enumerator.Current;
            if (transform.gameObject.Equals(this.target.gameObject) != null)
            {
                goto Label_00CF;
            }
            if (IronUtils.ellipseContainPoint(transform.position, this.range * 0.7f, this.range, this.target.transform.position) == null)
            {
                goto Label_00CF;
            }
            if (list.Count >= this.maxEnemies)
            {
                goto Label_00DA;
            }
            if (transform.GetComponent<Creep>().CanTeleport() == null)
            {
                goto Label_00CF;
            }
            list.Add(transform.GetComponent<Creep>());
            goto Label_00CF;
            goto Label_00DA;
        Label_00CF:
            if (enumerator.MoveNext() != null)
            {
                goto Label_003E;
            }
        Label_00DA:
            goto Label_00F1;
        }
        finally
        {
        Label_00DF:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00EA;
            }
        Label_00EA:
            disposable.Dispose();
        }
    Label_00F1:
        return list;
    }

    public bool IsReady()
    {
        return this.ready;
    }

    public override void LevelUp()
    {
        base.level += 1;
        this.maxEnemies += 1;
        this.nodes += this.extraNodes;
        return;
    }

    public void LookForTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        if (base.level <= 0)
        {
            goto Label_0127;
        }
        creep = null;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_001F:
        try
        {
            goto Label_00D7;
        Label_0024:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_00D7;
            }
            if (creep2.IsDead() != null)
            {
                goto Label_00D7;
            }
            if (creep2.isBoss != null)
            {
                goto Label_00D7;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, ((float) base.tower.range) * 0.7f, (float) base.tower.range, base.transform.position + new Vector3(0f, (float) -base.tower.yAdjust, 0f)) == null)
            {
                goto Label_00D7;
            }
            if ((creep == null) != null)
            {
                goto Label_00D5;
            }
            if (base.tower.IsNearExit(creep, creep2) == null)
            {
                goto Label_00D7;
            }
        Label_00D5:
            creep = creep2;
        Label_00D7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
            }
            goto Label_00FC;
        }
        finally
        {
        Label_00E7:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00F4;
            }
        Label_00F4:
            disposable.Dispose();
        }
    Label_00FC:
        if ((creep != null) == null)
        {
            goto Label_0127;
        }
        this.target = creep;
        base.tower.SetState(1);
        this.creeps = this.GetCreepsInRange();
    Label_0127:
        return;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        base.isPaused = 1;
        enumerator = base.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0069;
        Label_0018:
            transform = (Transform) enumerator.Current;
            if ((transform.name == "starEffect") == null)
            {
                goto Label_0049;
            }
            transform.GetComponent<PackedSprite>().PauseAnim();
            goto Label_0069;
        Label_0049:
            if ((transform.name == "teleportDecal") == null)
            {
                goto Label_0069;
            }
            transform.GetComponent<PackedSprite>().PauseAnim();
        Label_0069:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_008B;
        }
        finally
        {
        Label_0079:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0084;
            }
        Label_0084:
            disposable.Dispose();
        }
    Label_008B:
        return;
    }

    public void ShowEffect()
    {
        Transform transform1;
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.starEffect, base.transform.position, Quaternion.identity) as Transform;
        transform.name = "starEffect";
        transform.transform.parent = base.tower.transform;
        transform1 = transform.transform;
        transform1.localPosition += new Vector3(0f, 80f, -900f);
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("ArcaneTower") as ArcaneTower;
        this.spawner = GameObject.Find("Spawner");
        base.reload = 10f;
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        base.isPaused = 0;
        enumerator = base.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0069;
        Label_0018:
            transform = (Transform) enumerator.Current;
            if ((transform.name == "starEffect") == null)
            {
                goto Label_0049;
            }
            transform.GetComponent<PackedSprite>().UnpauseAnim();
            goto Label_0069;
        Label_0049:
            if ((transform.name == "teleportDecal") == null)
            {
                goto Label_0069;
            }
            transform.GetComponent<PackedSprite>().UnpauseAnim();
        Label_0069:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_008B;
        }
        finally
        {
        Label_0079:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0084;
            }
        Label_0084:
            disposable.Dispose();
        }
    Label_008B:
        return;
    }
}

