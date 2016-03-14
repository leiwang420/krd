using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepOrcRider : Creep
{
    public Creep orcArmored;

    public CreepOrcRider()
    {
        base..ctor();
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (damageType == null)
        {
            goto Label_0021;
        }
        base.life -= this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002F;
    Label_0021:
        base.life -= dmg;
    Label_002F:
        if (base.life > 0)
        {
            goto Label_0052;
        }
        base.life = 0;
        base.Invoke("SpawnOrcArmored", 0.1f);
    Label_0052:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }

    protected void SpawnOrcArmored()
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.orcArmored, base.transform.position + base.anchorPoint, Quaternion.identity) as Creep;
        creep.transform.parent = base.spawner.transform;
        creep.InitSprite();
        creep.SetPathIndex(base.pathIndex);
        creep.SetSubPath(base.subpathIndex);
        creep.SetCurrentNode(base.currentNode);
        creep.CheckFacing();
        creep.InitPosition();
        creep.roadNodesTillActive = 0;
        creep.SetActive(1);
        creep.name = "Orc Champion";
        return;
    }
}

