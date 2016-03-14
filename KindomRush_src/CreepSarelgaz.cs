using System;
using UnityEngine;

public class CreepSarelgaz : Creep
{
    protected bool eating;

    public CreepSarelgaz()
    {
        base..ctor();
        return;
    }

    public override void ChargeAttack()
    {
        GameSoundManager.PlaySpiderAttack();
        base.creepSprite.PlayAnim("attack");
        base.isCharging = 1;
        this.eating = 1;
        return;
    }

    protected override unsafe void FixedUpdate()
    {
        Vector3 vector;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.isFading == null)
        {
            goto Label_0042;
        }
        base.fadingTimeCounter += 1;
        if (base.fadingTimeCounter != base.fadingTime)
        {
            goto Label_0041;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0041:
        return;
    Label_0042:
        base.UpdateLifeBar();
        if (base.life > 0)
        {
            goto Label_0074;
        }
        base.active = 0;
        base.HidePoison();
        base.HideCurse();
        base.ToGraveyard();
        this.Die();
        return;
    Label_0074:
        if (base.active == null)
        {
            goto Label_0096;
        }
        if (base.isCharging != null)
        {
            goto Label_0096;
        }
        if (this.SpecialPower() == null)
        {
            goto Label_0096;
        }
        return;
    Label_0096:
        if (base.isBlocked == null)
        {
            goto Label_00E3;
        }
        if (this.eating != null)
        {
            goto Label_00E3;
        }
        if ((base.soldier == null) != null)
        {
            goto Label_00DD;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_00DD;
        }
        if (base.soldier.IsFighting() != null)
        {
            goto Label_00E3;
        }
    Label_00DD:
        this.StopFighting();
    Label_00E3:
        if (base.isFighting == null)
        {
            goto Label_0149;
        }
        if (base.isCharging == null)
        {
            goto Label_013D;
        }
        if (this.ReadyToDamage() != null)
        {
            goto Label_0105;
        }
        return;
    Label_0105:
        this.Attack();
        if (base.isDead == null)
        {
            goto Label_0117;
        }
        return;
    Label_0117:
        base.creepSprite.RevertToStatic();
        if (base.soldier.IsDead() == null)
        {
            goto Label_014F;
        }
        this.StopFighting();
        goto Label_0144;
    Label_013D:
        base.ReadyToAttack();
    Label_0144:
        goto Label_014F;
    Label_0149:
        base.Move();
    Label_014F:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_0190;
        }
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_01AF;
    Label_0190:
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_01AF:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.fadingTime = 40;
        GameData.notificationEnemySarelgaz = 1;
        base.stage.PlayMusicBossFight();
        return;
    }

    protected override bool ReadyToDamage()
    {
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter != base.attackChargeTime)
        {
            goto Label_0028;
        }
        base.attackChargeTimeCounter = 0;
        return 1;
    Label_0028:
        if (base.attackChargeTimeCounter != 15)
        {
            goto Label_0040;
        }
        base.soldier.Eat();
    Label_0040:
        return 0;
    }
}

