using System;
using System.Collections;
using UnityEngine;

public class ThornsAbility : AbilityBase
{
    private ArrayList creeps;
    private PackedSprite druid;
    public Transform druidPrefab;
    private int maxEnemies;
    private int minEnemies;
    private bool ready;
    private float reloadTimer;
    private Transform spawner;
    private bool wasAnimating;
    public int xOffset;
    public int yOffset;

    public ThornsAbility()
    {
        base..ctor();
        return;
    }

    private void Fire()
    {
        bool flag;
        Creep creep;
        IEnumerator enumerator;
        IDisposable disposable;
        flag = 0;
        enumerator = this.creeps.GetEnumerator();
    Label_000E:
        try
        {
            goto Label_0055;
        Label_0013:
            creep = (Creep) enumerator.Current;
            if ((creep != null) == null)
            {
                goto Label_0055;
            }
            if (creep.IsActive() == null)
            {
                goto Label_0055;
            }
            if (creep.IsDead() != null)
            {
                goto Label_0055;
            }
            creep.ApplyThornSpecial(base.duration, base.damage);
            flag = 1;
        Label_0055:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0013;
            }
            goto Label_0077;
        }
        finally
        {
        Label_0065:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0070;
            }
        Label_0070:
            disposable.Dispose();
        }
    Label_0077:
        if (flag == null)
        {
            goto Label_0082;
        }
        GameSoundManager.PlayThornSound();
    Label_0082:
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
            goto Label_00A2;
        }
        if (this.ready == null)
        {
            goto Label_006D;
        }
        this.creeps = this.GetCreepsInRange();
        if (this.creeps.Count < this.minEnemies)
        {
            goto Label_00A2;
        }
        this.druid.PlayAnim(0);
        base.Invoke("Fire", 0.8f);
        this.ready = 0;
        goto Label_00A2;
    Label_006D:
        this.reloadTimer += Time.deltaTime;
        if (this.reloadTimer < base.reload)
        {
            goto Label_00A2;
        }
        this.ready = 1;
        this.reloadTimer = 0f;
    Label_00A2:
        return;
    }

    private ArrayList GetCreepsInRange()
    {
        ArrayList list;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        list = new ArrayList();
        enumerator = this.spawner.GetEnumerator();
    Label_0012:
        try
        {
            goto Label_00A7;
        Label_0017:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00A7;
            }
            if (creep.IsBoss() != null)
            {
                goto Label_00A7;
            }
            if (creep.isFlying != null)
            {
                goto Label_00A7;
            }
            if (IronUtils.ellipseContainPoint(transform.position, ((float) base.tower.range) * 0.7f, (float) base.tower.range, base.transform.position) == null)
            {
                goto Label_00A7;
            }
            if (list.Count >= this.maxEnemies)
            {
                goto Label_00B2;
            }
            list.Add(creep);
            goto Label_00A7;
            goto Label_00B2;
        Label_00A7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0017;
            }
        Label_00B2:
            goto Label_00CC;
        }
        finally
        {
        Label_00B7:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C4;
            }
        Label_00C4:
            disposable.Dispose();
        }
    Label_00CC:
        return list;
    }

    public override void LevelUp()
    {
        base.level += 1;
        base.duration = (float) base.level;
        this.maxEnemies = this.MaxEnemies();
        this.ready = 0;
        return;
    }

    private int MaxEnemies()
    {
        return (this.minEnemies + (2 * base.level));
    }

    public override void Pause()
    {
        base.isPaused = 1;
        if ((this.druid != null) == null)
        {
            goto Label_0034;
        }
        this.wasAnimating = this.druid.IsAnimating();
        this.druid.PauseAnim();
    Label_0034:
        return;
    }

    public void SpawnDruid()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.druidPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        transform.transform.localPosition = new Vector3((float) -this.xOffset, (float) this.yOffset, -1f);
        this.druid = transform.GetComponent<PackedSprite>();
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent<ArcherTower>();
        this.minEnemies = 2;
        this.maxEnemies = this.MaxEnemies();
        base.duration = 1f;
        base.damage = 40;
        base.reload = 8f;
        this.reloadTimer = 0f;
        this.ready = 1;
        this.spawner = GameObject.Find("Spawner").GetComponent<Transform>();
        return;
    }

    public override void Unpause()
    {
        base.isPaused = 0;
        if (this.wasAnimating == null)
        {
            goto Label_001D;
        }
        this.druid.UnpauseAnim();
    Label_001D:
        return;
    }
}

