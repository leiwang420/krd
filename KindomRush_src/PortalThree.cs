using System;
using UnityEngine;

public class PortalThree : Portal
{
    public PortalThree()
    {
        base..ctor();
        return;
    }

    protected override Creep GetEnemy()
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(base.demonPrefab, base.transform.position, Quaternion.identity) as Creep;
        return creep;
    }

    protected override void InitCustom()
    {
        int num;
        base.nodePath = 0;
        base.nodeIndex = 0xde;
        base.creepType = 1;
        base.headsTotalMax = base.headsSpawnMax = 3;
        base.intervalHeadTime = 30;
        return;
    }
}

