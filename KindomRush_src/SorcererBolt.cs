using System;
using UnityEngine;

public class SorcererBolt : BaseProjectile
{
    public float acceleration;
    public float maxAcceleration;
    protected float xSpeed;
    protected float ySpeed;

    public SorcererBolt()
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
            goto Label_00A7;
        }
        if ((base.target != null) == null)
        {
            goto Label_00A1;
        }
        this.Hit();
    Label_00A1:
        this.ShowDecal();
    Label_00A7:
        return;
    }

    public override void Hit()
    {
        if (base.target.IsActive() == null)
        {
            goto Label_0066;
        }
        base.target.Damage(base.damage, 2, 0, 0);
        if ((base.target.GetModifier("EnemyModifierCurse") == null) == null)
        {
            goto Label_0055;
        }
        base.target.gameObject.AddComponent<EnemyModifierCurse>();
        goto Label_0066;
    Label_0055:
        base.target.GetComponent<EnemyModifierCurse>().ResetToLevel(0);
    Label_0066:
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

    private unsafe void Start()
    {
        Transform transform1;
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        num = base.xDest - &base.transform.position.x;
        num2 = base.yDest - &base.transform.position.y;
        num3 = Mathf.Atan2(num2, num);
        this.ySpeed = Mathf.Sin(num3) * 14f;
        this.xSpeed = Mathf.Cos(num3) * 14f;
        transform1 = base.transform;
        transform1.position += new Vector3(this.xSpeed, this.ySpeed, -840f);
        this.Rotate(num3 * 57.29578f);
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
        if ((base.target == null) == null)
        {
            goto Label_004D;
        }
        num2 = base.xDest - &base.transform.position.x;
        num = base.yDest - &base.transform.position.y;
        goto Label_00BD;
    Label_004D:
        base.SetDest(&base.target.transform.position.x, &base.target.transform.position.y);
        num2 = base.xDest - &base.transform.position.x;
        num = base.yDest - &base.transform.position.y;
    Label_00BD:
        num3 = Mathf.Atan2(num, num2);
        if (this.acceleration >= this.maxAcceleration)
        {
            goto Label_0111;
        }
        this.acceleration += Mathf.Ceil(this.acceleration * 0.05f);
        if (this.acceleration < this.maxAcceleration)
        {
            goto Label_0111;
        }
        this.acceleration = this.maxAcceleration;
    Label_0111:
        this.ySpeed = Mathf.Sin(num3) * this.acceleration;
        this.xSpeed = Mathf.Cos(num3) * this.acceleration;
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

