using System;
using UnityEngine;

public class DenasStuff : Arrow
{
    private SoldierHeroDenas denas;
    private bool fRange;

    public DenasStuff()
    {
        base..ctor();
        return;
    }

    public override unsafe void Hit()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.fRange != null)
        {
            goto Label_009F;
        }
        if (Mathf.Sqrt(Mathf.Pow((&base.target.transform.position.y + base.target.yAdjust) - &base.transform.position.y, 2f) + Mathf.Pow((&base.target.transform.position.x + base.target.xAdjust) - &base.transform.position.x, 2f)) >= 31f)
        {
            goto Label_013B;
        }
    Label_009F:
        base.target.Damage(base.damage, 1, base.ignoresArmorPoints, 0);
        base.target.BloodSplatter();
        if ((this.denas != null) == null)
        {
            goto Label_00F2;
        }
        this.denas.GainXpByDamage(base.target.GetArmorDamage(1, base.damage, 0));
    Label_00F2:
        if (base.target.IsDead() == null)
        {
            goto Label_0129;
        }
        if ((this.denas != null) == null)
        {
            goto Label_0129;
        }
        this.denas.GainXpByTargetKill(base.target.GetTotalLife());
    Label_0129:
        base.t0 = base.t1 + 1f;
    Label_013B:
        return;
    }

    public void SetDenas(SoldierHeroDenas d)
    {
        this.denas = d;
        return;
    }

    public void SetFrame(int i)
    {
        if (i != 1)
        {
            goto Label_0017;
        }
        base.GetComponent<PackedSprite>().RevertToStatic();
        goto Label_0025;
    Label_0017:
        base.GetComponent<PackedSprite>().PlayAnim(i - 2);
    Label_0025:
        return;
    }

    public void SetFRange(bool r)
    {
        this.fRange = r;
        return;
    }
}

