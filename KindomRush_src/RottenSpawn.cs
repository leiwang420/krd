using System;
using UnityEngine;

public class RottenSpawn : MonoBehaviour
{
    private bool isPaused;
    protected int maxTrees;
    protected int[][] rottenTimers;
    public Creep rottenTreePrefab;
    protected CreepSpawner spawner;
    protected int spawnTime;
    protected int spawnTimeCounter;
    protected StageBase stage;

    public RottenSpawn()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        int num;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.stage.GetCurrentWaveNumber() != null)
        {
            goto Label_001D;
        }
        return;
    Label_001D:
        if (this.spawnTime != null)
        {
            goto Label_0029;
        }
        return;
    Label_0029:
        this.spawnTimeCounter += 1;
        if (this.spawnTimeCounter >= this.spawnTime)
        {
            goto Label_0049;
        }
        return;
    Label_0049:
        num = 1;
        goto Label_005A;
    Label_0050:
        this.SpawnTrees();
        num += 1;
    Label_005A:
        if (num <= this.maxTrees)
        {
            goto Label_0050;
        }
        this.spawnTimeCounter = 0;
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    protected unsafe void SpawnTrees()
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        int num3;
        Vector3 vector;
        Creep creep;
        vectorArray = this.stage.GetPath();
        num = UnityEngine.Random.Range(0, (int) vectorArray.Length);
        if (num <= 2)
        {
            goto Label_001F;
        }
        num = 2;
    Label_001F:
        num2 = UnityEngine.Random.Range(0, 3);
        if (num2 <= 2)
        {
            goto Label_0030;
        }
        num2 = 2;
    Label_0030:
        num3 = UnityEngine.Random.Range(30, ((int) vectorArray[num][num2].Length) - 0x5e);
        if (num3 > ((int) vectorArray[num][num2].Length))
        {
            goto Label_0056;
        }
        if (num3 >= 0)
        {
            goto Label_0059;
        }
    Label_0056:
        num3 = 0x1f;
    Label_0059:
        &vector = new Vector3(&(vectorArray[num][num2][num3]).x, &(vectorArray[num][num2][num3]).y, -1f);
        creep = UnityEngine.Object.Instantiate(this.rottenTreePrefab, vector + new Vector3(0f, 40f, 0f), Quaternion.identity) as Creep;
        creep.transform.parent = this.spawner.transform;
        creep.name = "Rotten Tree";
        creep.InitSprite();
        creep.SetPathIndex(num);
        creep.SetSubPath(num2);
        creep.SetCurrentNode(num3);
        creep.SetUseGold(0);
        creep.roadNodesTillActive = 0;
        creep.SetActive(1);
        return;
    }

    private void Start()
    {
        this.stage = base.GetComponent<Stage15>();
        this.rottenTimers = ((Stage15) this.stage).GetRottenTimers();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }

    public void UpdateSpawnTimers()
    {
        if (this.rottenTimers != null)
        {
            goto Label_002D;
        }
        this.stage = base.GetComponent<Stage15>();
        this.rottenTimers = ((Stage15) this.stage).GetRottenTimers();
    Label_002D:
        this.spawnTime = this.rottenTimers[this.stage.GetCurrentWaveNumber() - 1][0] * 30;
        this.spawnTimeCounter = 0;
        this.maxTrees = this.rottenTimers[this.stage.GetCurrentWaveNumber() - 1][1];
        return;
    }
}

