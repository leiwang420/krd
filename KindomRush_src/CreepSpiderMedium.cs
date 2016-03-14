using System;
using UnityEngine;

public class CreepSpiderMedium : Creep
{
    protected int eggsFree;
    public int eggsMax;
    public Transform spiderEgg;

    public CreepSpiderMedium()
    {
        base..ctor();
        return;
    }

    public override void ChargeAttack()
    {
        GameSoundManager.PlaySpiderAttack();
        base.creepSprite.PlayAnim("attack");
        base.isCharging = 1;
        return;
    }

    protected override void InitCustomSettings()
    {
        this.eggsFree = 0;
        base.attackReloadTime -= base.attackChargeTime;
        base.basicCooldownTime = UnityEngine.Random.Range(150, 0x12d);
        return;
    }

    protected override bool SpecialPower()
    {
        Transform transform;
        if (base.active != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.eggsMax != this.eggsFree)
        {
            goto Label_0020;
        }
        return 0;
    Label_0020:
        if (base.basicCoolddownTimeCounter >= base.basicCooldownTime)
        {
            goto Label_0041;
        }
        base.basicCoolddownTimeCounter += 1;
        return 0;
    Label_0041:
        if (base.isBlocked == null)
        {
            goto Label_004E;
        }
        return 0;
    Label_004E:
        transform = UnityEngine.Object.Instantiate(this.spiderEgg, base.transform.position, Quaternion.identity) as Transform;
        base.stage.AddProjectile(transform);
        transform.GetComponent<CreepSpiderEgg>().Init(base.pathIndex, base.currentNode + 3);
        base.basicCoolddownTimeCounter = 0;
        this.eggsFree += 1;
        return 0;
    }
}

