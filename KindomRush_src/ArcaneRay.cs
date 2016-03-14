using System;
using UnityEngine;

public class ArcaneRay : Ray
{
    private bool shielded;

    public ArcaneRay()
    {
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform1;
        Vector3 vector;
        Vector3 vector2;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if ((base.target == null) == null)
        {
            goto Label_0029;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0029:
        base.durationTimeCounter += 1;
        this.Hit();
        if (base.durationTimeCounter <= base.durationTime)
        {
            goto Label_0060;
        }
        base.durationTimeCounter = 0;
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0060:
        base.Follow();
        base.Rotate();
        if (&base.target.transform.position.y <= &this.towerPos.y)
        {
            goto Label_00E6;
        }
        if (&base.target.transform.position.x >= &this.towerPos.x)
        {
            goto Label_00E6;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(-10f, 0f, 0f);
    Label_00E6:
        return;
    }

    public override void Hit()
    {
        EnemyModifierSlow slow;
        int num;
        if (this.shielded != null)
        {
            goto Label_007D;
        }
        if (GameUpgrades.MagesUpSlowCurse == null)
        {
            goto Label_007D;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_0036;
        }
        if (base.stage.MaxUpgradeLevel != 5)
        {
            goto Label_007D;
        }
    Label_0036:
        if ((base.target.GetComponent<EnemyModifierSlow>() != null) == null)
        {
            goto Label_007D;
        }
        if (base.target.HasRageModifier() != null)
        {
            goto Label_007D;
        }
        base.target.gameObject.AddComponent<EnemyModifierSlow>().Init(0.5f, 0.5f);
    Label_007D:
        num = base.damage / base.durationTime;
        if ((base.durationTimeCounter + 1) != base.durationTime)
        {
            goto Label_00A7;
        }
        num += base.extraDamage;
    Label_00A7:
        if (base.target.IsActive() == null)
        {
            goto Label_00C6;
        }
        base.target.Damage(num, 2, 0, 0);
    Label_00C6:
        if (this.shielded != null)
        {
            goto Label_012D;
        }
        if (GameUpgrades.MagesUpArcaneShatter == null)
        {
            goto Label_012D;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_00FC;
        }
        if (base.stage.MaxUpgradeLevel < 2)
        {
            goto Label_012D;
        }
    Label_00FC:
        if ((base.target != null) == null)
        {
            goto Label_012D;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_012D;
        }
        base.target.SetDamageArmor(GameUpgrades.MagesUpArcaneShatterDamage);
    Label_012D:
        if (this.shielded != null)
        {
            goto Label_013F;
        }
        this.shielded = 1;
    Label_013F:
        return;
    }

    public override void Pause()
    {
        base.isPaused = 1;
        base.sprite.PauseAnim();
        return;
    }

    private unsafe void Start()
    {
        Transform transform1;
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if ((base.target == null) != null)
        {
            goto Label_0021;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_002C;
        }
    Label_0021:
        UnityEngine.Object.Destroy(base.gameObject);
    Label_002C:
        base.sprite = base.GetComponent<PackedSprite>();
        base.GetDamage();
        base.durationTimeCounter = 0;
        base.durationTime = 10;
        base.anchorPoint = new Vector3(0f, 30f, 0f) + base.transform.position;
        base.originalPosition = base.transform.position;
        base.Follow();
        base.Rotate();
        if (&base.target.transform.position.y <= &this.towerPos.y)
        {
            goto Label_010E;
        }
        if (&base.target.transform.position.x >= &this.towerPos.x)
        {
            goto Label_010E;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(-10f, 0f, 0f);
    Label_010E:
        if (base.target.IsDead() != null)
        {
            goto Label_0184;
        }
        &vector = new Vector3(&base.target.transform.position.x, &base.target.transform.position.y, -890f);
        transform = UnityEngine.Object.Instantiate(base.hitPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.target.transform;
    Label_0184:
        GameSoundManager.PlayArcaneRaySound();
        return;
    }

    public override void Unpause()
    {
        base.isPaused = 0;
        base.sprite.UnpauseAnim();
        return;
    }
}

