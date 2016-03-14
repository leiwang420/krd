using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepLycan : CreepBlackburn
{
    public Transform werewolfSpecialPrefab;

    public CreepLycan()
    {
        base..ctor();
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        int num;
        int num2;
        num = 100;
        num2 = 0;
        if (damageType == null)
        {
            goto Label_0021;
        }
        num2 = base.life - this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002A;
    Label_0021:
        num2 = base.life - dmg;
    Label_002A:
        if (num2 >= num)
        {
            goto Label_0038;
        }
        this.StartTransformingIntoWerewolf();
        return;
    Label_0038:
        if (damageType == null)
        {
            goto Label_004A;
        }
        base.life = num2;
        goto Label_0058;
    Label_004A:
        base.life -= dmg;
    Label_0058:
        if (base.life >= 0)
        {
            goto Label_006B;
        }
        base.life = 0;
    Label_006B:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.regenerateTimeCounter = 0;
        base.regenerateTime = 8;
        base.regenerateHealPoints = 2;
        return;
    }

    public unsafe void StartTransformingIntoWerewolf()
    {
        Vector3 vector;
        Transform transform;
        CreepWerewolfSpecial special;
        Vector3 vector2;
        &vector = new Vector3(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode]).x, &(base.path[base.pathIndex][base.subpathIndex][base.currentNode]).y, -1f);
        transform = UnityEngine.Object.Instantiate(this.werewolfSpecialPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.spawner.transform;
        special = transform.GetComponent<CreepWerewolfSpecial>();
        special.name = "Werewolf Special";
        special.InitSprite();
        special.SetPathIndex(base.pathIndex);
        special.SetSubPath(base.subpathIndex);
        special.SetCurrentNode(base.currentNode);
        special.SetActive(1);
        special.roadNodesTillActive = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_0102;
        }
        special.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_0102:
        special.lifeRemaining = base.life;
        if ((base.soldier != null) == null)
        {
            goto Label_0137;
        }
        special.SetSoldier(base.soldier);
        base.soldier.SetEnemy(special);
    Label_0137:
        base.DestroyMe();
        return;
    }
}

