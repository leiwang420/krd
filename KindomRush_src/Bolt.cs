using System;
using UnityEngine;

public class Bolt : BaseProjectile
{
    public float acceleration;
    protected bool ignoresArmor;
    public float maxAcceleration;
    protected float xSpeed;
    protected float ySpeed;

    public Bolt()
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
            goto Label_00B8;
        }
        if ((base.target != null) != null)
        {
            goto Label_00AC;
        }
        if ((base.targetSoldier != null) == null)
        {
            goto Label_00B2;
        }
    Label_00AC:
        this.Hit();
    Label_00B2:
        this.ShowDecal();
    Label_00B8:
        return;
    }

    public override void Hit()
    {
        EnemyModifierSlow slow;
        if ((base.targetSoldier == null) == null)
        {
            goto Label_0108;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_011F;
        }
        if (GameUpgrades.MagesUpSlowCurse == null)
        {
            goto Label_0093;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_004C;
        }
        if (base.stage.MaxUpgradeLevel != 5)
        {
            goto Label_0093;
        }
    Label_004C:
        if ((base.target.GetComponent<EnemyModifierSlow>() == null) == null)
        {
            goto Label_0093;
        }
        if (base.target.HasRageModifier() != null)
        {
            goto Label_0093;
        }
        base.target.gameObject.AddComponent<EnemyModifierSlow>().Init(0.5f, 0.5f);
    Label_0093:
        base.target.Damage(base.damage, 2, 0, 0);
        if (GameUpgrades.MagesUpArcaneShatter == null)
        {
            goto Label_011F;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_00D2;
        }
        if (base.stage.MaxUpgradeLevel < 2)
        {
            goto Label_011F;
        }
    Label_00D2:
        if ((base.target != null) == null)
        {
            goto Label_011F;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_011F;
        }
        base.target.SetDamageArmor(GameUpgrades.MagesUpArcaneShatterDamage);
        goto Label_011F;
    Label_0108:
        base.targetSoldier.SetDamage(base.damage, this.ignoresArmor);
    Label_011F:
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

    private void Start()
    {
        float num;
        this.Travel();
        num = Mathf.Atan2(this.ySpeed, this.xSpeed) * 57.29578f;
        this.Rotate(num);
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
        if ((base.target == null) == null)
        {
            goto Label_004D;
        }
        num2 = base.xDest - &base.transform.position.x;
        num = base.yDest - &base.transform.position.y;
        goto Label_0120;
    Label_004D:
        if ((base.target.name != "Veznan") == null)
        {
            goto Label_00B0;
        }
        base.SetDest(&base.target.transform.position.x, &base.target.transform.position.y + base.target.yAdjust);
        goto Label_00E8;
    Label_00B0:
        base.SetDest(&base.target.transform.position.x, &base.target.transform.position.y);
    Label_00E8:
        num2 = base.xDest - &base.transform.position.x;
        num = base.yDest - &base.transform.position.y;
    Label_0120:
        num3 = Mathf.Atan2(num, num2);
        if (this.acceleration >= this.maxAcceleration)
        {
            goto Label_0174;
        }
        this.acceleration += Mathf.Ceil(this.acceleration * 0.05f);
        if (this.acceleration < this.maxAcceleration)
        {
            goto Label_0174;
        }
        this.acceleration = this.maxAcceleration;
    Label_0174:
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

