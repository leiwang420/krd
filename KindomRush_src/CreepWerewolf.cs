using System;
using UnityEngine;

public class CreepWerewolf : Creep
{
    public CreepWerewolf()
    {
        base..ctor();
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.regenerateTimeCounter = 0;
        base.regenerateTime = 8;
        base.regenerateHealPoints = 2;
        if (base.isRespawning != null)
        {
            goto Label_0035;
        }
    Label_0035:
        return;
    }
}

