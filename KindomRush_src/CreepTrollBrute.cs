using System;
using UnityEngine;

public class CreepTrollBrute : Creep
{
    public CreepTrollBrute()
    {
        base..ctor();
        return;
    }

    protected override unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_004F;
        }
        return new Vector2(&base.transform.position.x + 42f, &base.transform.position.y);
    Label_004F:
        return new Vector3(&base.transform.position.x - 42f, &base.transform.position.y);
    }

    protected override void InitCustomSettings()
    {
        base.regenerateTime = 30;
        base.regenerateHealPoints = 2;
        return;
    }
}

