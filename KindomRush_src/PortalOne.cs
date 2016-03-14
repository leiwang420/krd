using System;
using UnityEngine;

public class PortalOne : Portal
{
    public PortalOne()
    {
        base..ctor();
        return;
    }

    protected override Creep GetEnemy()
    {
        Creep creep;
        int num;
        creep = null;
        switch ((base.creepType - 1))
        {
            case 0:
                goto Label_0022;

            case 1:
                goto Label_0053;

            case 2:
                goto Label_0084;
        }
        goto Label_00F2;
    Label_0022:
        creep = UnityEngine.Object.Instantiate(base.demonPrefab, base.transform.position, Quaternion.identity) as Creep;
        creep.name = "Demon";
        goto Label_00F2;
    Label_0053:
        creep = UnityEngine.Object.Instantiate(base.demonWolfPrefab, base.transform.position, Quaternion.identity) as Creep;
        creep.name = "Demon Wolf";
        goto Label_00F2;
    Label_0084:
        if (base.headsMaxIndex > 5)
        {
            goto Label_00C1;
        }
        creep = UnityEngine.Object.Instantiate(base.demonPrefab, base.transform.position, Quaternion.identity) as Creep;
        creep.name = "Demon";
        goto Label_00ED;
    Label_00C1:
        creep = UnityEngine.Object.Instantiate(base.demonMagePrefab, base.transform.position, Quaternion.identity) as Creep;
        creep.name = "Demon Mage";
    Label_00ED:;
    Label_00F2:
        return creep;
    }

    protected override void InitCustom()
    {
        float num;
        int num2;
        base.nodePath = 0;
        base.nodeIndex = 0x62;
        num = UnityEngine.Random.Range(0f, 1f);
        if (num > 0.5f)
        {
            goto Label_004C;
        }
        base.creepType = 1;
        base.headsTotalMax = base.headsSpawnMax = UnityEngine.Random.Range(4, 8);
        goto Label_0095;
    Label_004C:
        if (num <= 0.5f)
        {
            goto Label_007E;
        }
        if (num > 0.8f)
        {
            goto Label_007E;
        }
        base.creepType = 2;
        base.headsTotalMax = base.headsSpawnMax = 3;
        goto Label_0095;
    Label_007E:
        base.creepType = 3;
        base.headsTotalMax = base.headsSpawnMax = 6;
    Label_0095:
        base.intervalHeadTime = 30;
        return;
    }
}

