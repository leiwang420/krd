using System;
using System.Collections;
using UnityEngine;

public class OverchargeAbility : AbilityBase
{
    private int baseMaxDamage;
    private int baseMinDamage;
    private float currentHeight;
    private float currentWidth;
    private int damageIncrement;
    private float displayRangeRelation;
    private bool firing;
    private float fullHeight;
    private float fullWidth;
    private Vector3 initPoint;
    private int maxDamage;
    private int minDamage;
    private CreepSpawner spawner;
    private int speed;
    public Transform staticParticle;

    public OverchargeAbility()
    {
        this.fullWidth = 465f;
        this.speed = 0x15;
        this.baseMaxDamage = 10;
        this.damageIncrement = 10;
        this.displayRangeRelation = 0.7f;
        this.initPoint = Vector3.zero;
        base..ctor();
        return;
    }

    private void ElectrifyEnemies()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_008C;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_008C;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, this.currentHeight, this.currentWidth, this.initPoint) == null)
            {
                goto Label_008C;
            }
            creep.Damage(this.GetDamage(), 3, 0, 0);
            creep.ShowTeslaHit();
            if ((creep != null) == null)
            {
                goto Label_008C;
            }
            if (creep.IsDead() == null)
            {
                goto Label_008C;
            }
            GameAchievements.TeslaKill();
        Label_008C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_00AE;
        }
        finally
        {
        Label_009C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A7;
            }
        Label_00A7:
            disposable.Dispose();
        }
    Label_00AE:
        return;
    }

    public unsafe void Fire()
    {
        int num;
        Vector3 vector;
        Transform transform;
        ParticleStatic @static;
        Vector3 vector2;
        Vector3 vector3;
        if (base.level <= 0)
        {
            goto Label_009B;
        }
        this.firing = 1;
        num = 0;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 30f, -3f);
        goto Label_0090;
    Label_0054:
        transform = UnityEngine.Object.Instantiate(this.staticParticle, vector, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.GetComponent<ParticleStatic>().Init(this.GetDestinationPoint(num));
        num += 30;
    Label_0090:
        if (num <= 360)
        {
            goto Label_0054;
        }
    Label_009B:
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
            goto Label_0085;
        }
        if (this.firing == null)
        {
            goto Label_0085;
        }
        this.currentWidth += (float) this.speed;
        this.currentHeight += ((float) this.speed) * 0.7f;
        if (this.currentWidth < this.fullWidth)
        {
            goto Label_0085;
        }
        this.ElectrifyEnemies();
        this.firing = 0;
        this.currentWidth = 0f;
        this.currentHeight = 0f;
    Label_0085:
        return;
    }

    private int GetDamage()
    {
        return (this.minDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.maxDamage - this.minDamage))));
    }

    private unsafe Vector2 GetDestinationPoint(int angle)
    {
        return IronUtils.ellipseGetPointOfDegree((float) angle, this.fullHeight * this.displayRangeRelation, this.fullWidth * this.displayRangeRelation, new Vector2(&this.initPoint.x, &this.initPoint.y));
    }

    public override void LevelUp()
    {
        base.level += 1;
        this.minDamage = this.baseMinDamage + (this.damageIncrement * base.level);
        this.maxDamage = this.baseMaxDamage + (this.damageIncrement * base.level);
        return;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        ParticleStatic @static;
        IDisposable disposable;
        base.isPaused = 1;
        enumerator = base.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_003D;
        Label_0018:
            transform = (Transform) enumerator.Current;
            @static = transform.GetComponent<ParticleStatic>();
            if ((@static != null) == null)
            {
                goto Label_003D;
            }
            @static.Pause();
        Label_003D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_005F;
        }
        finally
        {
        Label_004D:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0058;
            }
        Label_0058:
            disposable.Dispose();
        }
    Label_005F:
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        base.tower = base.transform.GetComponent<TeslaTower>();
        this.initPoint = new Vector3(&base.transform.position.x, (&base.transform.position.y - ((float) base.tower.yAdjust)) + 18f, 0f);
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.fullHeight = this.fullWidth * 0.7f;
        this.currentWidth = 0f;
        this.currentHeight = 0f;
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        ParticleStatic @static;
        IDisposable disposable;
        base.isPaused = 0;
        enumerator = base.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_003D;
        Label_0018:
            transform = (Transform) enumerator.Current;
            @static = transform.GetComponent<ParticleStatic>();
            if ((@static != null) == null)
            {
                goto Label_003D;
            }
            @static.Unpause();
        Label_003D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_005F;
        }
        finally
        {
        Label_004D:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0058;
            }
        Label_0058:
            disposable.Dispose();
        }
    Label_005F:
        return;
    }
}

