using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepBossMyconid : Creep
{
    public Transform explosionSpore;
    public Transform rottenLesserPrefab;
    protected int sporeExplosionFrameTrigger;
    protected int[] sporesCantSpawn;
    protected int sporesCantSpawnIndex;
    protected int sporesCantSpawnOnDeath;
    protected int sporesMinNodeIndex;
    protected int sporesRange;

    public CreepBossMyconid()
    {
        base..ctor();
        return;
    }

    public override bool BlockShouldSetIdle()
    {
        return (((base.BlockShouldSetIdle() == null) || (base.isBasicSpecial != null)) ? 0 : (base.isCharging == 0));
    }

    protected override bool CanDoSpecial()
    {
        return (base.currentNode > this.sporesMinNodeIndex);
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        base.Damage(dmg, damageType, ignoreArmor, shieldOn);
        if (base.life != null)
        {
            goto Label_001C;
        }
        base.CreepArmaggedon();
    Label_001C:
        return;
    }

    protected override void DoSpecial()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        SoldierModifierPoison poison;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_00D7;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_00D7;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_00D7;
            }
            if (soldier.IsDead() != null)
            {
                goto Label_00D7;
            }
            if (soldier.CanBePoisoned() == null)
            {
                goto Label_00D7;
            }
            if (IronUtils.ellipseContainPoint(soldier.transform.position - new Vector3(0f, soldier.yAdjust, 0f), ((float) this.sporesRange) * 0.7f, (float) this.sporesRange, base.transform.position) == null)
            {
                goto Label_00D7;
            }
            poison = soldier.GetComponent<SoldierModifierPoison>();
            if ((poison != null) == null)
            {
                goto Label_00C4;
            }
            poison.ResetToLevel(2);
            soldier.ShowPoison();
            goto Label_00D7;
        Label_00C4:
            soldier.gameObject.AddComponent<SoldierModifierPoison>().SetProperties(2);
        Label_00D7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00FC;
        }
        finally
        {
        Label_00E7:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00F4;
            }
        Label_00F4:
            disposable.Dispose();
        }
    Label_00FC:
        return;
    }

    protected override unsafe bool EvalSpecialBasic()
    {
        bool flag;
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        flag = base.EvalSpecialBasic();
        if (flag == null)
        {
            goto Label_00C4;
        }
        if (base.basicAnimationTimeCounter != this.sporeExplosionFrameTrigger)
        {
            goto Label_0083;
        }
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 50f, &base.transform.position.z - 40f);
        transform = UnityEngine.Object.Instantiate(this.explosionSpore, vector, Quaternion.identity) as Transform;
    Label_0083:
        if (base.basicAnimationTimeCounter != (this.sporeExplosionFrameTrigger + 9))
        {
            goto Label_00C4;
        }
        this.SpawnShrooms(this.sporesCantSpawn[this.sporesCantSpawnIndex]);
        if (this.sporesCantSpawnIndex >= 7)
        {
            goto Label_00C4;
        }
        this.sporesCantSpawnIndex += 1;
    Label_00C4:
        return flag;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.basicCooldownTime = 150;
        this.sporesRange = 220;
        this.sporesCantSpawn = new int[] { 2, 3, 3, 4, 4, 4, 3, 2 };
        this.sporesCantSpawnIndex = 0;
        this.sporesMinNodeIndex = 0x1b;
        this.sporeExplosionFrameTrigger = 15;
        base.basicIncrementOnFunction = 0;
        base.basicAnimationTime = 0x30;
        base.basicAnimationStartTime = 0x12;
        this.sporesCantSpawnOnDeath = 12;
        GameData.notificationEnemyBossMyconid = 1;
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayMushroomBossDeath();
        return;
    }

    protected override void PlaySpecial()
    {
        base.creepSprite.PlayAnim("special");
        return;
    }

    protected override void PlaySpecialSound()
    {
        GameSoundManager.PlayMushroomBossGas();
        return;
    }

    protected override bool ShouldTruncateAttack()
    {
        return 0;
    }

    protected unsafe void SpawnShrooms(int cantToSpawn)
    {
        int[] numArray3;
        int[] numArray1;
        int[] numArray;
        int num;
        ArrayList list;
        int num2;
        int num3;
        int num4;
        int[] numArray2;
        int num5;
        int num6;
        Vector3 vector;
        Transform transform;
        Creep creep;
        Vector3 vector2;
        numArray1 = new int[] { 4, -2, -2 };
        numArray = numArray1;
        num = 5;
        list = new ArrayList();
        num2 = 0;
        goto Label_005A;
    Label_0024:
        num3 = numArray[num2];
        goto Label_004A;
    Label_002E:
        numArray3 = new int[] { num2, num3 };
        list.Add(numArray3);
        num3 += 1;
    Label_004A:
        if (num3 < (numArray[num2] + num))
        {
            goto Label_002E;
        }
        num2 += 1;
    Label_005A:
        if (num2 < 3)
        {
            goto Label_0024;
        }
        goto Label_01B8;
    Label_0066:
        num4 = UnityEngine.Random.Range(0, list.Count);
        numArray2 = (int[]) list[num4];
        list.RemoveAt(num4);
        num5 = numArray2[0];
        num6 = numArray2[1] + base.currentNode;
        if (base.stage.IsIlegal(base.pathIndex, num6) == null)
        {
            goto Label_00BB;
        }
        goto Label_01B8;
    Label_00BB:
        &vector = new Vector3(&(base.path[base.pathIndex][num5][num6]).x, &(base.path[base.pathIndex][num5][num6]).y, -1f);
        transform = UnityEngine.Object.Instantiate(this.rottenLesserPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.name = "Rotten Lesser";
        creep.InitSprite();
        creep.SetPathIndex(base.pathIndex);
        creep.SetSubPath(num5);
        creep.SetCurrentNode(num6);
        creep.SetActive(1);
        creep.roadNodesTillActive = 0;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_01B3;
        }
        creep.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_01B3:
        cantToSpawn -= 1;
    Label_01B8:
        if (cantToSpawn <= 0)
        {
            goto Label_01CB;
        }
        if (list.Count > 0)
        {
            goto Label_0066;
        }
    Label_01CB:
        return;
    }

    protected void spawnShroomsOnDeath()
    {
        this.SpawnShrooms(this.sporesCantSpawnOnDeath);
        return;
    }

    public override bool StartFightingShouldSetChargeAttack()
    {
        return (((base.StartFightingShouldSetChargeAttack() == null) || (base.isBasicSpecial != null)) ? 0 : (base.isCharging == 0));
    }

    protected override void UpdateSpecialPowerCooldowns()
    {
        base.UpdateSpecialPowerCooldowns();
        base.basicCoolddownTimeCounter += 1;
        return;
    }
}

