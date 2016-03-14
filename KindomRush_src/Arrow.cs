using System;
using UnityEngine;

public class Arrow : Parabola
{
    public bool ignoresArmor;
    protected int ignoresArmorPoints;
    protected bool poisoned;
    public bool spear;

    public Arrow()
    {
        base..ctor();
        return;
    }

    protected void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.Rotate();
        base.Travel();
        if (this.TravelEnd() == null)
        {
            goto Label_004F;
        }
        if (this.CheckTarget() == null)
        {
            goto Label_0044;
        }
        this.Hit();
        UnityEngine.Object.Destroy(base.gameObject);
        goto Label_004A;
    Label_0044:
        this.ShowDecal();
    Label_004A:
        goto Label_006B;
    Label_004F:
        if (base.t0 <= base.t1)
        {
            goto Label_006B;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_006B:
        return;
    }

    public override void Hit()
    {
        EnemyModifierPoison poison;
        int num;
        if ((base.targetSoldier == null) == null)
        {
            goto Label_00DC;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_00D1;
        }
        if (this.ignoresArmor == null)
        {
            goto Label_0034;
        }
        this.ignoresArmorPoints = 10;
    Label_0034:
        base.target.Damage(base.damage, 1, this.ignoresArmorPoints, 0);
        base.target.BloodSplatter();
        if ((base.GetComponent<EnemyModifierPoison>() != null) == null)
        {
            goto Label_00FE;
        }
        if (base.target.CanBePoisoned() == null)
        {
            goto Label_00FE;
        }
        poison = base.target.GetComponent<EnemyModifierPoison>();
        num = base.GetComponent<EnemyModifierPoison>().GetLevel();
        if ((poison != null) == null)
        {
            goto Label_00B4;
        }
        poison.ResetToLevel(num);
        base.target.ShowPoison();
        goto Label_00CC;
    Label_00B4:
        base.target.gameObject.AddComponent<EnemyModifierPoison>().SetProperties(num);
    Label_00CC:
        goto Label_00D7;
    Label_00D1:
        this.ShowDecal();
    Label_00D7:
        goto Label_00FE;
    Label_00DC:
        base.targetSoldier.SetDamage(base.damage, this.ignoresArmor);
        base.targetSoldier.BloodSplatter();
    Label_00FE:
        return;
    }

    protected virtual unsafe void InitArrow()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector2 vector4;
        Vector3 vector5;
        Vector2 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        Vector2 vector11;
        Vector3 vector12;
        Vector2 vector13;
        Vector3 vector14;
        Vector2 vector15;
        this.ignoresArmorPoints = 0;
        if ((base.targetSoldier == null) == null)
        {
            goto Label_017C;
        }
        if ((base.target == null) == null)
        {
            goto Label_0050;
        }
        base.xDest = &this.destination.x;
        base.yDest = &this.destination.y;
        goto Label_0177;
    Label_0050:
        if (base.target.IsStopped() == null)
        {
            goto Label_00B9;
        }
        base.xDest = &base.target.transform.position.x + base.target.xAdjust;
        base.yDest = &base.target.transform.position.y + base.target.yAdjust;
        goto Label_0177;
    Label_00B9:
        base.xDest = ((&base.target.transform.position.x + base.target.xAdjust) + (&base.target.GetSpeedVector().x * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f);
        base.yDest = (((&base.target.transform.position.y + base.target.yAdjust) + (&base.target.GetSpeedVector().y * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f)) - 14.1f;
    Label_0177:
        goto Label_03AF;
    Label_017C:
        if ((base.targetSoldier == null) == null)
        {
            goto Label_01B4;
        }
        base.xDest = &this.destination.x;
        base.yDest = &this.destination.y;
        goto Label_03AF;
    Label_01B4:
        if (base.targetSoldier.IsStopped() == null)
        {
            goto Label_026B;
        }
        base.xDest = &base.targetSoldier.transform.position.x + base.targetSoldier.xAdjust;
        if ((base.targetSoldier.GetComponent<SoldierHeroViking>() != null) == null)
        {
            goto Label_023B;
        }
        base.yDest = (&base.targetSoldier.transform.position.y + base.targetSoldier.yAdjust) - 50f;
        goto Label_0266;
    Label_023B:
        base.yDest = &base.targetSoldier.transform.position.y + base.targetSoldier.yAdjust;
    Label_0266:
        goto Label_03AF;
    Label_026B:
        base.xDest = ((&base.targetSoldier.transform.position.x + base.targetSoldier.xAdjust) + (&base.targetSoldier.GetSpeedVector().x * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f);
        if ((base.targetSoldier.GetComponent<SoldierHeroViking>() != null) == null)
        {
            goto Label_034C;
        }
        base.yDest = ((((&base.targetSoldier.transform.position.y + base.targetSoldier.yAdjust) - 50f) + (&base.targetSoldier.GetSpeedVector().y * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f)) - 14.1f;
        goto Label_03AF;
    Label_034C:
        base.yDest = (((&base.targetSoldier.transform.position.y + base.targetSoldier.yAdjust) + (&base.targetSoldier.GetSpeedVector().y * base.t1)) + (UnityEngine.Random.Range(0f, 1f) * 14.1f)) - 14.1f;
    Label_03AF:
        base.xSpeed = (base.xDest - base.xOrig) / base.t1;
        base.ySpeed = ((base.yDest - base.yOrig) - (((base.g * base.t1) * base.t1) / 2f)) / base.t1;
        return;
    }

    private void Start()
    {
        base.Init();
        this.InitArrow();
        if (this.spear == null)
        {
            goto Label_001C;
        }
        GameSoundManager.PlayAxeSound();
    Label_001C:
        return;
    }
}

