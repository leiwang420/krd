using System;
using System.Collections;
using UnityEngine;

public class ThorHammer : Bolt
{
    protected int areaDamage;
    protected Constants.damageType areaDamageType;
    public Transform layer0;
    public Transform layer1;
    private int level;
    protected CreepSpawner spawner;
    protected int stunDuration;
    public Transform thorLightning;
    protected int thunderArea;

    public ThorHammer()
    {
        base..ctor();
        return;
    }

    public override void Hit()
    {
        if (base.target.IsActive() == null)
        {
            goto Label_0060;
        }
        base.target.Damage(base.damage, 0, 0, 0);
        if (base.target.IsActive() == null)
        {
            goto Label_0055;
        }
        if (base.target.isBoss != null)
        {
            goto Label_0055;
        }
        base.target.DoStun(this.stunDuration);
    Label_0055:
        base.target.ShowTeslaHit();
    Label_0060:
        GameSoundManager.PlayHeroThorThunder();
        return;
    }

    public void Init(int damage, int level, CreepSpawner spawner, int thunderArea, int areaDamage, Constants.damageType areaDamageType, int stunDuration)
    {
        base.damage = damage;
        this.level = level;
        base.acceleration = 14f;
        base.maxAcceleration = 42f;
        this.spawner = spawner;
        this.thunderArea = thunderArea;
        this.areaDamage = areaDamage;
        this.stunDuration = stunDuration;
        this.areaDamageType = areaDamageType;
        return;
    }

    protected bool isEnemyInRange(Creep tmpEnemy, Vector3 hitPoint)
    {
        return IronUtils.ellipseContainPoint(tmpEnemy.transform.position, (float) this.thunderArea, ((float) this.thunderArea) * 0.7f, hitPoint);
    }

    public override unsafe void ShowDecal()
    {
        Vector3 vector;
        Transform transform;
        Transform transform2;
        Transform transform3;
        Transform transform4;
        IEnumerator enumerator;
        Creep creep;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        IDisposable disposable;
        if ((base.target != null) == null)
        {
            goto Label_0105;
        }
        if (base.target.isFlying == null)
        {
            goto Label_0096;
        }
        &vector = new Vector3(&base.target.transform.position.x + base.target.xAdjust, &base.target.transform.position.y - (base.target.yAdjust * 2f), &base.target.transform.position.z);
        goto Label_0100;
    Label_0096:
        &vector = new Vector3(&base.target.transform.position.x + base.target.xAdjust, &base.target.transform.position.y + base.target.yAdjust, &base.target.transform.position.z);
    Label_0100:
        goto Label_011D;
    Label_0105:
        &vector = new Vector3(base.xDest, base.yDest, -900f);
    Label_011D:
        transform = UnityEngine.Object.Instantiate(this.thorLightning, vector, Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        transform2 = UnityEngine.Object.Instantiate(this.layer0, vector, Quaternion.identity) as Transform;
        base.stage.AddEffect(transform2);
        transform3 = UnityEngine.Object.Instantiate(this.layer1, new Vector3(&vector.x, &vector.y, -900f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform3);
        enumerator = this.spawner.transform.GetEnumerator();
    Label_01AF:
        try
        {
            goto Label_0241;
        Label_01B4:
            transform4 = (Transform) enumerator.Current;
            creep = transform4.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_0241;
            }
            if (creep.IsActive() == null)
            {
                goto Label_0241;
            }
            if ((creep != base.target) == null)
            {
                goto Label_0241;
            }
            if (this.isEnemyInRange(creep, vector) == null)
            {
                goto Label_0241;
            }
            creep.Damage(this.areaDamage, 2, 0, 0);
            if (base.target.IsActive() == null)
            {
                goto Label_0241;
            }
            if (base.target.isBoss != null)
            {
                goto Label_0241;
            }
            creep.DoStun(this.stunDuration);
        Label_0241:
            if (enumerator.MoveNext() != null)
            {
                goto Label_01B4;
            }
            goto Label_0268;
        }
        finally
        {
        Label_0252:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0260;
            }
        Label_0260:
            disposable.Dispose();
        }
    Label_0268:
        base.ShowDecal();
        return;
    }
}

