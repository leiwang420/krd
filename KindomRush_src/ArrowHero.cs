using System;
using UnityEngine;

public class ArrowHero : ArrowHeroNormal
{
    public Transform arrowGhostPrefab;

    public ArrowHero()
    {
        base..ctor();
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
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        if (base.spinning == null)
        {
            goto Label_002A;
        }
        base.transform.Rotate(0f, 0f, 20f);
        goto Label_012F;
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
        base.transform.Rotate(0f, 0f, -num6);
    Label_012F:
        transform = UnityEngine.Object.Instantiate(this.arrowGhostPrefab, base.transform.position, base.transform.rotation) as Transform;
        return;
    }

    public void SetIgnoresArmorPoints(int points)
    {
        base.ignoresArmorPoints = points;
        return;
    }
}

