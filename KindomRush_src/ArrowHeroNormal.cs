using System;
using UnityEngine;

public class ArrowHeroNormal : Arrow
{
    public ArrowHeroNormal()
    {
        base..ctor();
        return;
    }

    protected override unsafe void InitArrow()
    {
        bool flag;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector2 vector6;
        Vector3 vector7;
        Vector2 vector8;
        Vector3 vector9;
        Vector2 vector10;
        Vector3 vector11;
        Vector2 vector12;
        base.ignoresArmorPoints = 0;
        if ((base.target == null) == null)
        {
            goto Label_003F;
        }
        base.xDest = &this.destination.x;
        base.yDest = &this.destination.y;
        goto Label_0281;
    Label_003F:
        flag = ((base.target.GetComponent<CreepJuggernaut>() != null) == null) ? 0 : 1;
        if (base.target.IsStopped() == null)
        {
            goto Label_010E;
        }
        if (flag == null)
        {
            goto Label_00B4;
        }
        base.xDest = &base.target.transform.position.x;
        base.yDest = &base.target.transform.position.y;
        goto Label_0109;
    Label_00B4:
        base.xDest = &base.target.transform.position.x + base.target.xAdjust;
        base.yDest = &base.target.transform.position.y + base.target.yAdjust;
    Label_0109:
        goto Label_0281;
    Label_010E:
        if (flag == null)
        {
            goto Label_01C1;
        }
        base.xDest = (&base.target.transform.position.x + (&base.target.GetSpeedVector().x * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f);
        base.yDest = ((&base.target.transform.position.y + (&base.target.GetSpeedVector().y * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f)) - 14.1f;
        goto Label_0281;
    Label_01C1:
        base.xDest = ((&base.target.transform.position.x + base.target.xAdjust) + (&base.target.GetSpeedVector().x * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f);
        base.yDest = (((&base.target.transform.position.y + base.target.yAdjust) + (&base.target.GetSpeedVector().y * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f)) - 14.1f;
    Label_0281:
        base.xSpeed = (base.xDest - base.xOrig) / base.t1;
        base.ySpeed = ((base.yDest - base.yOrig) - (((base.g * base.t1) * base.t1) / 2f)) / base.t1;
        return;
    }
}

