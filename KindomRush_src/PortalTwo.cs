using System;
using UnityEngine;

public class PortalTwo : Portal
{
    public PortalTwo()
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
                goto Label_0048;

            case 2:
                goto Label_006E;
        }
        goto Label_00C6;
    Label_0022:
        creep = UnityEngine.Object.Instantiate(base.demonPrefab, base.transform.position, Quaternion.identity) as Creep;
        goto Label_00C6;
    Label_0048:
        creep = UnityEngine.Object.Instantiate(base.demonWolfPrefab, base.transform.position, Quaternion.identity) as Creep;
        goto Label_00C6;
    Label_006E:
        if (base.headsMaxIndex > 3)
        {
            goto Label_00A0;
        }
        creep = UnityEngine.Object.Instantiate(base.demonPrefab, base.transform.position, Quaternion.identity) as Creep;
        goto Label_00C1;
    Label_00A0:
        creep = UnityEngine.Object.Instantiate(base.demonMagePrefab, base.transform.position, Quaternion.identity) as Creep;
    Label_00C1:;
    Label_00C6:
        return creep;
    }

    protected override void InitCustom()
    {
        float num;
        int num2;
        base.nodePath = 0;
        base.nodeIndex = 0x92;
        num = UnityEngine.Random.Range(0f, 1f);
        if (num > 0.5f)
        {
            goto Label_004F;
        }
        base.creepType = 1;
        base.headsTotalMax = base.headsSpawnMax = UnityEngine.Random.Range(2, 6);
        goto Label_0098;
    Label_004F:
        if (num <= 0.5f)
        {
            goto Label_0081;
        }
        if (num > 0.8f)
        {
            goto Label_0081;
        }
        base.creepType = 2;
        base.headsTotalMax = base.headsSpawnMax = 2;
        goto Label_0098;
    Label_0081:
        base.creepType = 3;
        base.headsTotalMax = base.headsSpawnMax = 3;
    Label_0098:
        base.intervalHeadTime = 30;
        return;
    }
}

