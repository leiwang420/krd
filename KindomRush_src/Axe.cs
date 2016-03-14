using System;
using UnityEngine;

public class Axe : Arrow
{
    private int rotation;

    public Axe()
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
            goto Label_00B5;
        }
        if (base.targetSoldier.IsDead() != null)
        {
            goto Label_00B5;
        }
        if (base.targetSoldier.IsActive() != null)
        {
            goto Label_00B7;
        }
    Label_00B5:
        return 0;
    Label_00B7:
        num3 = &base.transform.position.x - base.xDest;
        num4 = &base.transform.position.y - base.yDest;
        &vector2 = new Vector2(num3, num4);
        return (&vector2.magnitude < 24.5f);
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
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.spinning == null)
        {
            goto Label_003B;
        }
        base.transform.Rotate(0f, 0f, (float) (20 * this.rotation));
        goto Label_0140;
    Label_003B:
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
    Label_0140:
        return;
    }

    public void SetRotation(int rot)
    {
        this.rotation = rot * -1;
        return;
    }

    public override void ShowDecal()
    {
        Transform transform;
        int num;
        if ((base.decal != null) == null)
        {
            goto Label_00C4;
        }
        num = (base.decalOver == null) ? -1 : -900;
        if (base.decalRotation == null)
        {
            goto Label_006E;
        }
        transform = UnityEngine.Object.Instantiate(base.decal, new Vector3(base.xDest, base.yDest + base.yDecalAdjust, (float) num), base.transform.rotation) as Transform;
        goto Label_009E;
    Label_006E:
        transform = UnityEngine.Object.Instantiate(base.decal, new Vector3(base.xDest, base.yDest + base.yDecalAdjust, (float) num), Quaternion.identity) as Transform;
    Label_009E:
        if (this.rotation != 1)
        {
            goto Label_00C4;
        }
        transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00C4:
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void Start()
    {
        base.Init();
        this.InitArrow();
        GameSoundManager.PlayAxeSound();
        return;
    }
}

