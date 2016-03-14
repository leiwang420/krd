using System;
using UnityEngine;

public class Ray : BaseProjectile
{
    protected Vector3 anchorPoint;
    protected float currentDistance;
    protected int durationTime;
    protected int durationTimeCounter;
    protected int extraDamage;
    public Transform hitPrefab;
    protected float maxDamage;
    protected float minDamage;
    protected Vector3 originalPosition;
    protected float radians;
    protected float rotation;
    protected PackedSprite sprite;
    protected Vector2 towerPos;
    protected float xScale;
    protected float xSpeed;
    protected float yScale;
    protected float ySpeed;

    public Ray()
    {
        this.yScale = 1f;
        base..ctor();
        return;
    }

    protected void ChangeWidth(float width)
    {
        float num;
        num = (width * this.xScale) / this.sprite.width;
        this.xScale = num;
        return;
    }

    private void FixedUpdate()
    {
    }

    protected void Follow()
    {
        Transform transform1;
        this.xScale = 1f;
        this.rotation = 0f;
        this.currentDistance = Mathf.Sqrt((base.xDest * base.xDest) + (base.yDest * base.yDest));
        this.ChangeWidth(this.currentDistance);
        base.transform.position = this.originalPosition;
        this.SetMovementVars();
        this.xScale *= 1f + ((Mathf.Sqrt((base.xDest * base.xDest) + (base.yDest * base.yDest)) - this.currentDistance) / this.currentDistance);
        this.currentDistance = Mathf.Sqrt((base.xDest * base.xDest) + (base.yDest * base.yDest));
        if (float.IsNaN(this.xScale) != null)
        {
            goto Label_0134;
        }
        base.transform.localScale = new Vector3(this.xScale, this.yScale, 1f);
        transform1 = base.transform;
        transform1.position += new Vector3((this.sprite.width * this.xScale) / 2f, 30f, 0f);
    Label_0134:
        this.FollowHit();
        return;
    }

    protected virtual void FollowHit()
    {
    }

    protected void GetDamage()
    {
        int num;
        num = 0;
        if ((base.target != null) == null)
        {
            goto Label_004D;
        }
        if (base.damage <= base.target.GetHealth())
        {
            goto Label_004D;
        }
        num = base.damage - base.target.GetHealth();
        base.damage = base.target.GetHealth();
    Label_004D:
        this.extraDamage = num;
        return;
    }

    protected void Rotate()
    {
        this.rotation = 360f - (Mathf.Atan2(this.ySpeed, this.xSpeed) * 57.29578f);
        base.transform.rotation = Quaternion.identity;
        base.transform.RotateAround(this.anchorPoint, new Vector3(0f, 0f, 1f), -this.rotation);
        return;
    }

    protected virtual unsafe void SetMovementVars()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if ((base.target != null) == null)
        {
            goto Label_00D3;
        }
        base.xDest = &base.target.transform.position.x - &base.transform.position.x;
        base.yDest = (&base.target.transform.position.y - &base.transform.position.y) - 30f;
        if ((base.target.name == "Veznan") == null)
        {
            goto Label_00A7;
        }
        base.yDest -= 10f;
    Label_00A7:
        if ((base.target.name == "Demon Legion") == null)
        {
            goto Label_00D3;
        }
        base.yDest -= 25f;
    Label_00D3:
        this.radians = Mathf.Atan2(base.yDest, base.xDest);
        this.ySpeed = Mathf.Sin(this.radians);
        this.xSpeed = Mathf.Cos(this.radians);
        return;
    }

    public void SetTowerPos(float x, float y)
    {
        this.towerPos = new Vector2(x, y);
        return;
    }

    private void Start()
    {
    }
}

