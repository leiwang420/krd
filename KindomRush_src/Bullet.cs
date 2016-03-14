using System;
using System.Collections;
using UnityEngine;

public class Bullet : BaseProjectile
{
    public float acceleration;
    private int chance;
    private Vector2 dir;
    private bool ignoresArmor;
    public float minAcceleration;
    public float speed;
    private float xSpeed;
    private float ySpeed;

    public Bullet()
    {
        base..ctor();
        return;
    }

    public unsafe bool CheckTarget()
    {
        float num;
        float num2;
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        if ((base.target == null) != null)
        {
            goto Label_0021;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_0023;
        }
    Label_0021:
        return 0;
    Label_0023:
        num = &base.transform.position.x - base.xDest;
        num2 = &base.transform.position.y - base.yDest;
        &vector = new Vector2(num, num2);
        MonoBehaviour.print((float) &vector.magnitude);
        return (&vector.magnitude < 22f);
    }

    public void EnableParticles()
    {
        ((BolinParticleEmitter) base.transform.GetComponent("BolinParticleEmitter")).SetEnabled(1);
        return;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform1;
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        num = 0f;
        num2 = 0f;
        if ((base.target != null) == null)
        {
            goto Label_0072;
        }
        base.xDest = &base.target.transform.position.x;
        base.yDest = &base.target.transform.position.y + base.target.yAdjust;
    Label_0072:
        if ((base.target == null) != null)
        {
            goto Label_00A3;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_00A3;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_00E0;
        }
    Label_00A3:
        num2 = base.yDest - &base.transform.position.y;
        num = base.xDest - &base.transform.position.x;
        goto Label_014A;
    Label_00E0:
        num2 = (&base.target.transform.position.y + base.target.yAdjust) - &base.transform.position.y;
        num = &base.target.transform.position.x - &base.transform.position.x;
    Label_014A:
        num3 = Mathf.Atan2(num2, num);
        this.ySpeed = Mathf.Sin(num3) * this.acceleration;
        this.xSpeed = Mathf.Cos(num3) * this.acceleration;
        transform1 = base.transform;
        transform1.position += new Vector3(this.xSpeed, this.ySpeed, 0f);
        this.Rotate();
        if (Mathf.Sqrt(Mathf.Pow(base.yDest - &base.transform.position.y, 2f) + Mathf.Pow(base.xDest - &base.transform.position.x, 2f)) >= this.acceleration)
        {
            goto Label_02B3;
        }
        if ((base.target != null) == null)
        {
            goto Label_02AD;
        }
        if (base.target.IsDead() != null)
        {
            goto Label_02AD;
        }
        if (this.chance <= 0)
        {
            goto Label_0297;
        }
        if (UnityEngine.Random.Range(0, 100) >= this.chance)
        {
            goto Label_028C;
        }
        base.damage = base.target.GetTotalLife() + 0x2710;
        if (base.target.IsActive() == null)
        {
            goto Label_0297;
        }
        base.target.Gib();
        base.target.PopHeadshot();
        GameAchievements.SniperEnemy();
        goto Label_0297;
    Label_028C:
        base.target.BloodSplatter();
    Label_0297:
        this.Hit();
        UnityEngine.Object.Destroy(base.gameObject);
        goto Label_02B3;
    Label_02AD:
        this.ShowDecal();
    Label_02B3:
        return;
    }

    public Vector2 GetDir()
    {
        return this.dir;
    }

    public override void Hit()
    {
        int num;
        if (base.target.IsActive() == null)
        {
            goto Label_0029;
        }
        num = 0;
        num = 10;
        base.target.Damage(base.damage, 1, num, 0);
    Label_0029:
        return;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        IDisposable disposable;
        base.isPaused = 1;
        enumerator = base.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_003D;
        Label_0018:
            transform = (Transform) enumerator.Current;
            sprite = transform.GetComponent<PackedSprite>();
            if ((sprite != null) == null)
            {
                goto Label_003D;
            }
            sprite.PauseAnim();
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

    private unsafe void Rotate()
    {
        float num;
        float num2;
        float num3;
        float num4;
        Vector3 vector;
        Vector3 vector2;
        num = base.yDest - &base.transform.position.y;
        num2 = base.xDest - &base.transform.position.x;
        num4 = (Mathf.Atan2(num, num2) * 180f) / 3.14f;
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(0f, 0f, num4);
        return;
    }

    public void SetChance(int c)
    {
        this.chance = c;
        return;
    }

    public void SetIgnoresArmor(bool ignores)
    {
        this.ignoresArmor = ignores;
        return;
    }

    private void Start()
    {
        this.minAcceleration = 14f;
        this.acceleration = 28f;
        this.Rotate();
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        IDisposable disposable;
        base.isPaused = 0;
        enumerator = base.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_003D;
        Label_0018:
            transform = (Transform) enumerator.Current;
            sprite = transform.GetComponent<PackedSprite>();
            if ((sprite != null) == null)
            {
                goto Label_003D;
            }
            sprite.UnpauseAnim();
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

