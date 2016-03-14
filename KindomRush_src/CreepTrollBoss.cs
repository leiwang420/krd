using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepTrollBoss : Creep
{
    private Transform greyBloodPrefab;
    private Transform redBloodPrefab;
    public Transform smokeDecalPrefab;
    public Transform smokeGroundPrefab;

    public CreepTrollBoss()
    {
        base..ctor();
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.Block(mySoldier);
        base.bloodSplatter = this.redBloodPrefab;
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (base.isBlocked != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.Damage(dmg, damageType, ignoreArmor, shieldOn);
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
            goto Label_005B;
        }
        return new Vector2(&base.transform.position.x + 42f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector3(&base.transform.position.x - 42f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected override void InitCustomSettings()
    {
        base.regenerateTime = 30;
        base.regenerateHealPoints = 2;
        this.greyBloodPrefab = base.bloodSplatter;
        this.redBloodPrefab = Resources.Load("Prefabs/Particles & fx/Blood splatter red", typeof(Transform)) as Transform;
        GameData.notificationEnemyTrollBoss = 1;
        base.stage.PlayMusicBossFight();
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayDeathBig();
        return;
    }

    protected override unsafe bool ReadyToDamage()
    {
        Vector2 vector;
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
            goto Label_0093;
        }
        vector = this.GetAttackPoint();
        UnityEngine.Object.Instantiate(this.smokeDecalPrefab, new Vector3(&vector.x, &vector.y, -1f), Quaternion.identity);
        UnityEngine.Object.Instantiate(this.smokeGroundPrefab, new Vector3(&vector.x, &vector.y, -899f), Quaternion.identity);
        goto Label_00ED;
    Label_0093:
        if (base.attackChargeTimeCounter != base.attackDodgeTime)
        {
            goto Label_00ED;
        }
        if ((base.soldier != null) == null)
        {
            goto Label_00ED;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_00ED;
        }
        if (base.soldier.DodgeHit() == null)
        {
            goto Label_00ED;
        }
        base.soldier.SetDodgeDamage(base.GetDamage());
        base.attackIsDodged = 1;
    Label_00ED:
        return 0;
    }

    public override void StopFighting()
    {
        base.StopFighting();
        base.bloodSplatter = this.greyBloodPrefab;
        return;
    }
}

