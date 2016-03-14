using System;
using UnityEngine;

public class Parabola : BaseProjectile
{
    protected float g;
    protected float t0;
    protected float t1;
    protected float xOrig;
    protected float xSpeed;
    protected float yOrig;
    protected float ySpeed;

    public Parabola()
    {
        this.t1 = 40f;
        base..ctor();
        return;
    }

    protected virtual unsafe bool CheckTarget()
    {
        float num;
        float num2;
        Vector2 vector;
        float num3;
        float num4;
        Vector2 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if ((base.targetSoldier == null) == null)
        {
            goto Label_0084;
        }
        if ((base.target == null) != null)
        {
            goto Label_0032;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_0034;
        }
    Label_0032:
        return 0;
    Label_0034:
        num = &base.transform.position.x - base.xDest;
        num2 = &base.transform.position.y - base.yDest;
        &vector = new Vector2(num, num2);
        return (&vector.magnitude < 24.5f);
    Label_0084:
        if ((base.targetSoldier == null) != null)
        {
            goto Label_00A5;
        }
        if (base.targetSoldier.IsDead() == null)
        {
            goto Label_00A7;
        }
    Label_00A5:
        return 0;
    Label_00A7:
        num3 = &base.transform.position.x - base.xDest;
        num4 = &base.transform.position.y - base.yDest;
        &vector2 = new Vector2(num3, num4);
        return (&vector2.magnitude < 24.5f);
    }

    private void FixedUpdate()
    {
    }

    protected unsafe void Init()
    {
        Vector3 vector;
        Vector3 vector2;
        this.InitCustom();
        this.t0 = 0f;
        this.g = -1.41f;
        this.xOrig = &base.transform.position.x;
        this.yOrig = &base.transform.position.y;
        this.xSpeed = (base.xDest - this.xOrig) / this.t1;
        this.ySpeed = ((base.yDest - this.yOrig) - (((this.g * this.t1) * this.t1) / 2f)) / this.t1;
        return;
    }

    protected virtual void InitCustom()
    {
    }

    protected virtual unsafe void Rotate()
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        float num6;
        Vector3 vector;
        Vector3 vector2;
        if (base.spinning == null)
        {
            goto Label_002A;
        }
        base.transform.Rotate(0f, 0f, 20f);
        goto Label_012F;
    Label_002A:
        this.t0 += 1f;
        num = (this.yOrig + (this.t0 * this.ySpeed)) + (((this.g * this.t0) * this.t0) / 2f);
        num2 = this.xOrig + (this.t0 * this.xSpeed);
        this.t0 -= 1f;
        num3 = num - &base.transform.position.y;
        num4 = num2 - &base.transform.position.x;
        num5 = Mathf.Atan2(num3, num4);
        num6 = (float) (180.0 - (((double) (Mathf.Atan2(Mathf.Sin(num5) * 20f, Mathf.Cos(num5) * 20f) * 180f)) / 3.14));
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(0f, 0f, -num6);
    Label_012F:
        return;
    }

    public void SetG(float grav)
    {
        this.g = grav;
        return;
    }

    public void SetT1(float t)
    {
        this.t1 = t;
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        this.t0 = 0f;
        this.t1 = 40f;
        this.g = -1.41f;
        this.xOrig = &base.transform.position.x;
        this.yOrig = &base.transform.position.y;
        this.xSpeed = (base.xDest - this.xOrig) / this.t1;
        this.ySpeed = ((base.yDest - this.yOrig) - (((this.g * this.t1) * this.t1) / 2f)) / this.t1;
        return;
    }

    protected void Travel()
    {
        float num;
        float num2;
        num = this.xOrig + (this.t0 * this.xSpeed);
        num2 = (this.yOrig + (this.t0 * this.ySpeed)) + (((this.g * this.t0) * this.t0) / 2f);
        base.transform.position = new Vector3(num, num2, -900f);
        this.t0 += 1f;
        return;
    }

    protected virtual bool TravelEnd()
    {
        return (this.t0 == this.t1);
    }
}

