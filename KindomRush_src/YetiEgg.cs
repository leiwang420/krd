using System;
using UnityEngine;

public class YetiEgg : MonoBehaviour
{
    private int headsCurrentNodeIndex;
    private int headsMaxIndex;
    private int headsSpawnIndex;
    private int headsSpawnMax;
    private int headsTotalMax;
    private int intervalHeadTime;
    private int intervalHeadTimeCounter;
    private int intervalTime;
    private int intervalTimeCounter;
    private bool isActive;
    private bool isPaused;
    private bool isSpawning;
    private CreepJT jt;
    private int nodeIndex;
    private int nodePath;
    private CreepSpawner spawner;
    private bool whiteWolf;

    public YetiEgg()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isActive != null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        if (this.jt.IsActive() == null)
        {
            goto Label_0038;
        }
        if (this.jt.IsDead() == null)
        {
            goto Label_0044;
        }
    Label_0038:
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0044:
        if (this.isSpawning != null)
        {
            goto Label_0089;
        }
        if (this.intervalTimeCounter >= this.intervalTime)
        {
            goto Label_006F;
        }
        this.intervalTimeCounter += 1;
        return;
    Label_006F:
        this.isSpawning = 1;
        this.intervalHeadTimeCounter = this.intervalHeadTime;
        this.headsCurrentNodeIndex = 0;
    Label_0089:
        if (this.intervalHeadTimeCounter >= this.intervalHeadTime)
        {
            goto Label_00A9;
        }
        this.intervalHeadTimeCounter += 1;
        return;
    Label_00A9:
        this.SpawnSpider(this.headsCurrentNodeIndex);
        this.intervalHeadTimeCounter = 0;
        this.headsSpawnIndex += 1;
        this.headsMaxIndex += 1;
        this.headsCurrentNodeIndex += 1;
        if (this.headsCurrentNodeIndex <= 2)
        {
            goto Label_00F9;
        }
        this.headsCurrentNodeIndex = 0;
    Label_00F9:
        if (this.headsMaxIndex != this.headsTotalMax)
        {
            goto Label_0116;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0116:
        if (this.headsSpawnIndex != this.headsSpawnMax)
        {
            goto Label_013C;
        }
        this.intervalTimeCounter = 0;
        this.headsSpawnIndex = 0;
        this.isSpawning = 0;
    Label_013C:
        return;
    }

    public void InitWithPosition(Vector3 pos, int myNodePath, int myNodeIndex, CreepJT myJt, bool andWolf)
    {
        int num;
        base.transform.position = pos;
        this.nodePath = myNodePath;
        this.nodeIndex = myNodeIndex;
        this.jt = myJt;
        this.whiteWolf = andWolf;
        if (this.whiteWolf == null)
        {
            goto Label_0052;
        }
        this.headsTotalMax = this.headsSpawnMax = 2;
        this.intervalHeadTime = 20;
        goto Label_006D;
    Label_0052:
        this.headsTotalMax = this.headsSpawnMax = 1;
        this.intervalHeadTime = 200;
    Label_006D:
        this.isActive = 1;
        this.isSpawning = 0;
        this.intervalTime = 1;
        this.intervalTimeCounter = 0;
        this.intervalHeadTimeCounter = 0;
        this.headsMaxIndex = 0;
        this.headsSpawnIndex = 0;
        this.headsCurrentNodeIndex = 0;
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void SpawnSpider(int roadIndex)
    {
        if (this.whiteWolf == null)
        {
            goto Label_0027;
        }
        this.spawner.Spawn("EnemyWhiteWolf", this.nodePath, roadIndex);
        goto Label_003E;
    Label_0027:
        this.spawner.Spawn("EnemyYeti", this.nodePath, roadIndex);
    Label_003E:
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

