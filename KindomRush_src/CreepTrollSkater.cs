using System;
using UnityEngine;

public class CreepTrollSkater : Creep
{
    private float addedSpeed;
    private bool isSkating;
    private int skatingIndex;

    public CreepTrollSkater()
    {
        base..ctor();
        return;
    }

    public override unsafe void CheckFacing()
    {
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        double num;
        Vector3 vector4;
        Vector3 vector5;
        if (base.isStunned == null)
        {
            goto Label_0016;
        }
        base.creepSprite.RevertToStatic();
    Label_0016:
        vector = ((base.currentNode + 1) >= ((int) base.path[base.pathIndex][base.subpathIndex].Length)) ? *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode])) : *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode + 1]));
        &vector2 = new Vector2(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y);
        vector3 = vector - vector2;
        &vector3.Normalize();
        num = ((double) (Mathf.Atan2(&vector3.y, &vector3.x) * 180f)) / 3.14;
        if (num >= 0.0)
        {
            goto Label_0113;
        }
        num += 360.0;
    Label_0113:
        if (num <= 55.0)
        {
            goto Label_0179;
        }
        if (num >= 135.0)
        {
            goto Label_0179;
        }
        if (base.facing == 1)
        {
            goto Label_02CF;
        }
        base.facing = 1;
        if (this.isSkating != null)
        {
            goto Label_0164;
        }
        base.creepSprite.PlayAnim("walkUp");
        goto Label_0174;
    Label_0164:
        base.creepSprite.PlayAnim("skate");
    Label_0174:
        goto Label_02CF;
    Label_0179:
        if (num < 135.0)
        {
            goto Label_0203;
        }
        if (num > 240.0)
        {
            goto Label_0203;
        }
        if (base.facing == 2)
        {
            goto Label_02CF;
        }
        base.facing = 2;
        if (this.isSkating != null)
        {
            goto Label_01CA;
        }
        base.creepSprite.PlayAnim("walk");
        goto Label_01DA;
    Label_01CA:
        base.creepSprite.PlayAnim("skate");
    Label_01DA:
        base.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_02CF;
    Label_0203:
        if (num <= 240.0)
        {
            goto Label_0268;
        }
        if (num >= 315.0)
        {
            goto Label_0268;
        }
        if (base.facing == null)
        {
            goto Label_02CF;
        }
        base.facing = 0;
        if (this.isSkating != null)
        {
            goto Label_0253;
        }
        base.creepSprite.PlayAnim("walkDown");
        goto Label_0263;
    Label_0253:
        base.creepSprite.PlayAnim("skateDown");
    Label_0263:
        goto Label_02CF;
    Label_0268:
        if (base.facing == 3)
        {
            goto Label_02CF;
        }
        base.facing = 3;
        if (this.isSkating != null)
        {
            goto Label_029B;
        }
        base.creepSprite.PlayAnim("walk");
        goto Label_02AB;
    Label_029B:
        base.creepSprite.PlayAnim("skate");
    Label_02AB:
        base.creepSprite.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_02CF:
        return;
    }

    protected override void Die()
    {
        base.Die();
        if (this.isSkating == null)
        {
            goto Label_0016;
        }
        GameAchievements.TrollSkaterKilled();
    Label_0016:
        return;
    }

    protected override void ExtraReachGoalLine()
    {
        if (base.stage.HasIce() == null)
        {
            goto Label_008F;
        }
        if (base.stage.HasIceOnPath(base.pathIndex) == null)
        {
            goto Label_008F;
        }
        if (this.skatingIndex >= base.stage.GetIcePathCount(base.pathIndex))
        {
            goto Label_008F;
        }
        if (base.currentNode != base.stage.GetIcePathValue(base.pathIndex, this.skatingIndex))
        {
            goto Label_008F;
        }
        if (this.isSkating == null)
        {
            goto Label_007B;
        }
        this.OnLeaveIce(0);
        goto Label_0081;
    Label_007B:
        this.OnEnterIce();
    Label_0081:
        this.skatingIndex += 1;
    Label_008F:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.regenerateTime = 90;
        base.regenerateHealPoints = 1;
        this.addedSpeed = 3.06f;
        this.skatingIndex = 1;
        this.isSkating = 0;
        return;
    }

    protected void OnEnterIce()
    {
        base.canBeBlocked = 0;
        if (this.isSkating != null)
        {
            goto Label_0025;
        }
        base.speed += this.addedSpeed;
    Label_0025:
        this.isSkating = 1;
        base.facing = -1;
        this.CheckFacing();
        return;
    }

    protected void OnLeaveIce(bool fromTeleporth)
    {
        int num;
        this.isSkating = 0;
        base.canBeBlocked = 1;
        base.speed -= this.addedSpeed;
        base.facing = -1;
        this.CheckFacing();
        if (fromTeleporth == null)
        {
            goto Label_0092;
        }
        num = 1;
        this.skatingIndex = 1;
        goto Label_007B;
    Label_0042:
        if (base.currentNode <= base.stage.GetIcePathValue(base.pathIndex, num))
        {
            goto Label_0092;
        }
        this.skatingIndex += 1;
        goto Label_0077;
        goto Label_0092;
    Label_0077:
        num += 1;
    Label_007B:
        if (num < base.stage.GetIcePathCount(base.pathIndex))
        {
            goto Label_0042;
        }
    Label_0092:
        return;
    }
}

