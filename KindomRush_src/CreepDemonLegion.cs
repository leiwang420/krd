using System;
using UnityEngine;

public class CreepDemonLegion : CreepDemon
{
    protected int cloneChargeTime;
    protected int cloneChargeTimeCounter;
    protected int cloneInitReloadTime;
    protected int cloneMaxGenerations;
    protected int cloneMinNodes;
    protected int cloneReloadTime;
    protected int cloneReloadTimeCounter;
    protected GameObject creepSpawner;
    protected bool didSummon;
    protected int generation;
    protected int initGeneration;
    protected bool isCloning;
    protected Transform legionPrefab;
    protected bool spawnPortal;

    public CreepDemonLegion()
    {
        this.spawnPortal = 1;
        base..ctor();
        return;
    }

    private void AfterSummon()
    {
        base.active = 1;
        base.teleporting = 0;
        this.CheckFacing();
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor, bool shieldOn)
    {
        base.Damage(dmg, damageType, ignoreArmor, shieldOn);
        if (base.life != null)
        {
            goto Label_0032;
        }
        if (this.didSummon != null)
        {
            goto Label_0032;
        }
        if (this.initGeneration != 2)
        {
            goto Label_0032;
        }
        GameAchievements.ArmyOfOneFunc();
    Label_0032:
        return;
    }

    protected void DoCloning()
    {
        this.isCloning = 1;
        this.cloneChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        return;
    }

    protected void EndCloning()
    {
        this.isCloning = 0;
        this.cloneChargeTimeCounter = 0;
        this.cloneReloadTimeCounter = 0;
        this.cloneReloadTime = 300;
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_0038;
        }
        this.CheckFacing();
    Label_0038:
        return;
    }

    protected override unsafe void InitCustomSettings()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.legionPrefab = Resources.Load("Prefabs/Creeps/Demon Legion", typeof(Transform)) as Transform;
        this.creepSpawner = GameObject.Find("Spawner");
        base.explodeRangeWidth = 170;
        base.explodeRangeHeight = Mathf.RoundToInt(((float) base.explodeRangeWidth) * 0.7f);
        base.canRage = 1;
        this.didSummon = 0;
        base.ignoreArmorOnMelee = 1;
        base.attackChargeTime = 0x1c;
        base.attackChargeTimeCounter = 0;
        base.attackReloadTimeCounter = 0;
        this.generation = 2;
        this.initGeneration = this.generation;
        this.isCloning = 0;
        this.cloneInitReloadTime = 450;
        this.cloneReloadTime = this.cloneInitReloadTime;
        this.cloneMaxGenerations = 2;
        this.cloneMinNodes = 30;
        this.cloneChargeTime = 0x27;
        this.cloneChargeTimeCounter = 0;
        this.cloneReloadTimeCounter = 0;
        base.fadingTime = 40;
        base.fadingTimeCounter = 0;
        base.xSoldierAdjust = 32f;
        base.respawnTime = 0x23;
        if (this.spawnPortal == null)
        {
            goto Label_0150;
        }
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 40f, -780f);
        UnityEngine.Object.Instantiate(base.portalVeznan, vector, Quaternion.identity);
        this.CheckFacing();
    Label_0150:
        return;
    }

    public void InitWithRoad(int pIndex, int spIndex, int cNode, int gen, int myHealth)
    {
        base.teleporting = 1;
        this.spawnPortal = 0;
        base.pathIndex = pIndex;
        base.subpathIndex = spIndex;
        base.currentNode = cNode + 2;
        this.generation = gen;
        base.life = myHealth;
        base.gold = 0;
        this.cloneReloadTime = 300;
        base.creepSprite.PlayAnim("summon");
        base.Invoke("AfterSummon", 1f);
        return;
    }

    protected override void RevertToStatic()
    {
        base.creepSprite.PlayAnim("idle");
        return;
    }

    protected unsafe void SpawnClone()
    {
        int num;
        int num2;
        Vector2 vector;
        Transform transform;
        CreepDemonLegion legion;
        float num3;
        Vector3 vector2;
        Vector3 vector3;
        this.cloneReloadTimeCounter = 0;
        num = base.currentNode + UnityEngine.Random.Range(5, 10);
        if (base.stage.IsIlegal(base.pathIndex, num) == null)
        {
            goto Label_0035;
        }
        num = base.currentNode;
    Label_0035:
        num2 = UnityEngine.Random.Range(0, 3);
        vector = *(&(base.path[base.pathIndex][num2][num]));
        transform = UnityEngine.Object.Instantiate(this.legionPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.transform.localScale = new Vector3(&base.transform.localScale.x, 1f, 1f);
        transform.name = "Demon Legion";
        legion = transform.GetComponent<CreepDemonLegion>();
        legion.InitSprite();
        legion.InitWithRoad(base.pathIndex, num2, num, this.initGeneration - 1, base.life);
        legion.transform.parent = this.creepSpawner.transform;
        legion.transform.position = new Vector3(&vector.x, &vector.y - &this.anchorPoint.y, &base.transform.position.z);
        num3 = base.GetComponent<Layer>().offset;
        legion.GetComponent<Layer>().offset = num3;
        this.generation -= 1;
        this.didSummon = 1;
        return;
    }

    protected bool SpecialCloning()
    {
        if (this.isCloning != null)
        {
            goto Label_005D;
        }
        if (this.cloneReloadTimeCounter >= this.cloneReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        if ((base.currentNode + this.cloneMinNodes) < ((int) base.path[base.pathIndex][base.subpathIndex].Length))
        {
            goto Label_0048;
        }
        return 0;
    Label_0048:
        if (this.generation != null)
        {
            goto Label_0055;
        }
        return 0;
    Label_0055:
        this.DoCloning();
        return 1;
    Label_005D:
        if (this.cloneChargeTimeCounter >= this.cloneChargeTime)
        {
            goto Label_0090;
        }
        this.cloneChargeTimeCounter += 1;
        if (this.cloneChargeTimeCounter != 5)
        {
            goto Label_008E;
        }
        this.SpawnClone();
    Label_008E:
        return 1;
    Label_0090:
        this.EndCloning();
        return 0;
    }

    protected override bool SpecialPower()
    {
        if (this.SpecialCloning() == null)
        {
            goto Label_000D;
        }
        return 1;
    Label_000D:
        return base.SpecialPower();
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        if (this.isCloning == null)
        {
            goto Label_0017;
        }
        this.EndCloning();
    Label_0017:
        return;
    }

    protected override void UpdateSpecialPowerCooldowns()
    {
        this.cloneReloadTimeCounter += 1;
        return;
    }
}

