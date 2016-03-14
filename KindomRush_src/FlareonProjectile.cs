using System;
using UnityEngine;

public class FlareonProjectile : Arrow
{
    protected PackedSprite projectileSprite;

    public FlareonProjectile()
    {
        base..ctor();
        return;
    }

    protected override unsafe bool CheckTarget()
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

    public override void Hit()
    {
        SoldierModifierFlareonFire fire;
        int num;
        if ((base.GetComponent<SoldierModifierFlareonFire>() != null) == null)
        {
            goto Label_006F;
        }
        fire = base.targetSoldier.GetComponent<SoldierModifierFlareonFire>();
        num = base.GetComponent<SoldierModifierFlareonFire>().GetLevel();
        if ((fire != null) == null)
        {
            goto Label_004C;
        }
        fire.ResetToLevel(num);
        base.targetSoldier.ShowFire();
        goto Label_006F;
    Label_004C:
        base.targetSoldier.gameObject.AddComponent<SoldierModifierFlareonFire>().SetProperties(num);
        base.targetSoldier.ShowFire();
    Label_006F:
        if ((base.targetSoldier != null) == null)
        {
            goto Label_00B2;
        }
        if (base.targetSoldier.IsDead() == null)
        {
            goto Label_00B2;
        }
        base.targetSoldier.BloodSplatter();
        base.targetSoldier.SetDamage(base.damage, base.ignoresArmor);
    Label_00B2:
        return;
    }

    protected override void InitArrow()
    {
        this.projectileSprite = base.transform.GetComponent("PackedSprite") as PackedSprite;
        this.projectileSprite.PlayAnim("idle");
        base.Init();
        this.Rotate();
        return;
    }

    protected override unsafe void Rotate()
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        float num6;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (base.spinning == null)
        {
            goto Label_002A;
        }
        base.transform.Rotate(0f, 0f, 20f);
        goto Label_0176;
    Label_002A:
        base.t0 += 1f;
        num = (base.yOrig + (base.t0 * base.ySpeed)) + (((base.g * base.t0) * base.t0) / 2f);
        num2 = base.xOrig + (base.t0 * base.xSpeed);
        base.t0 -= 1f;
        num3 = num - &base.transform.position.y;
        num4 = num2 - &base.transform.position.x;
        num5 = Mathf.Atan2(num3, num4);
        num6 = (float) (180.0 - (((double) (Mathf.Atan2(Mathf.Sin(num5) * 20f, Mathf.Cos(num5) * 20f) * 180f)) / 3.14));
        base.transform.rotation = Quaternion.identity;
        if (base.xDest >= &base.transform.position.x)
        {
            goto Label_0158;
        }
        base.transform.Rotate(0f, 0f, num6 + 180f);
        goto Label_0176;
    Label_0158:
        base.transform.Rotate(0f, 0f, -num6 + 180f);
    Label_0176:
        return;
    }
}

