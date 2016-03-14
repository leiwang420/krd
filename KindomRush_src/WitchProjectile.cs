using System;
using UnityEngine;

public class WitchProjectile : BaseProjectile
{
    public float acceleration;
    public Transform explosion;
    public Transform explosionToad;
    protected bool ignoresArmor;
    public float maxAcceleration;
    public Transform particle;
    protected float xSpeed;
    protected float ySpeed;

    public WitchProjectile()
    {
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        float num;
        Vector3 vector;
        Vector3 vector2;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.Travel();
        num = Mathf.Atan2(this.ySpeed, this.xSpeed) * 57.29578f;
        this.Rotate(num);
        if (Mathf.Sqrt(Mathf.Pow(base.yDest - &base.transform.position.y, 2f) + Mathf.Pow(base.xDest - &base.transform.position.x, 2f)) >= this.acceleration)
        {
            goto Label_0096;
        }
        this.Hit();
        this.ShowDecal();
    Label_0096:
        return;
    }

    public override unsafe void Hit()
    {
        Transform transform;
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
        Vector3 vector11;
        Vector3 vector12;
        Debug.Log("soldier es nulo");
        if ((base.targetSoldier == null) == null)
        {
            goto Label_008A;
        }
        Debug.Log("soldier es nulo");
        transform = UnityEngine.Object.Instantiate(this.explosion, new Vector3(&base.transform.position.x, &base.transform.position.y, &base.transform.position.z), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform);
        goto Label_023A;
    Label_008A:
        if (base.targetSoldier.IsDead() == null)
        {
            goto Label_010D;
        }
        transform = UnityEngine.Object.Instantiate(this.explosion, new Vector3(&base.targetSoldier.transform.position.x, &base.targetSoldier.transform.position.y, &base.targetSoldier.transform.position.z), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform);
        return;
    Label_010D:
        if ((base.targetSoldier as SoldierHero) == null)
        {
            goto Label_01AB;
        }
        base.targetSoldier.SetDamage(base.damage, this.ignoresArmor);
        transform = UnityEngine.Object.Instantiate(this.explosion, new Vector3(&base.targetSoldier.transform.position.x, &base.targetSoldier.transform.position.y, &base.targetSoldier.transform.position.z), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform);
        goto Label_023A;
    Label_01AB:
        base.targetSoldier.Hide(1);
        base.targetSoldier.SetDamage(0x1869f, 1);
        transform = UnityEngine.Object.Instantiate(this.explosionToad, new Vector3(&base.targetSoldier.transform.position.x, &base.targetSoldier.transform.position.y, &base.targetSoldier.transform.position.z), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform);
    Label_023A:
        return;
    }

    public override void Pause()
    {
        PackedSprite sprite;
        base.isPaused = 1;
        sprite = base.GetComponent<PackedSprite>();
        if ((sprite != null) == null)
        {
            goto Label_0020;
        }
        sprite.PauseAnim();
    Label_0020:
        return;
    }

    protected void Rotate(float angle)
    {
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(0f, 0f, angle);
        return;
    }

    public void SetIgnoresArmor(bool i)
    {
        this.ignoresArmor = i;
        return;
    }

    private unsafe void SpawnParticles()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.particle, new Vector3(&base.transform.position.x + 2f, &base.transform.position.y, -898f), Quaternion.identity) as Transform;
        transform.parent = base.transform.parent;
        return;
    }

    private void Start()
    {
        float num;
        this.Travel();
        num = Mathf.Atan2(this.ySpeed, this.xSpeed) * 57.29578f;
        this.Rotate(num);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        return;
    }

    protected unsafe void Travel()
    {
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
        Vector3 vector11;
        if ((base.targetSoldier == null) == null)
        {
            goto Label_004D;
        }
        num2 = base.xDest - &base.transform.position.x;
        num = base.yDest - &base.transform.position.y;
        goto Label_00E3;
    Label_004D:
        base.SetDest(&base.targetSoldier.transform.position.x, &base.targetSoldier.transform.position.y);
        num2 = &base.targetSoldier.transform.position.x - &base.transform.position.x;
        num = &base.targetSoldier.transform.position.y - &base.transform.position.y;
    Label_00E3:
        num3 = Mathf.Atan2(num, num2);
        if (this.acceleration >= this.maxAcceleration)
        {
            goto Label_0137;
        }
        this.acceleration += Mathf.Ceil(this.acceleration * 0.05f);
        if (this.acceleration < this.maxAcceleration)
        {
            goto Label_0137;
        }
        this.acceleration = this.maxAcceleration;
    Label_0137:
        this.ySpeed = Mathf.Sin(num3) * this.acceleration;
        this.xSpeed = Mathf.Cos(num3) * this.acceleration;
        this.SpawnParticles();
        base.transform.position = new Vector3(&base.transform.position.x + this.xSpeed, &base.transform.position.y + this.ySpeed, &base.transform.position.z);
        return;
    }

    public override void Unpause()
    {
        PackedSprite sprite;
        base.isPaused = 0;
        sprite = base.GetComponent<PackedSprite>();
        if ((sprite != null) == null)
        {
            goto Label_0020;
        }
        sprite.UnpauseAnim();
    Label_0020:
        return;
    }
}

