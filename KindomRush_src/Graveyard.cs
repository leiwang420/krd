using System;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    protected int lastSpawn;
    protected int nodeIndex;
    public int nodeIndex43;
    public int nodeIndexWide;
    public int nodePath;
    public Transform skeletonPrefab;
    public Transform skeletonWarriorPrefab;
    protected CreepSpawner spawner;
    public Vector2[] spawnPoints;
    protected int subRoadIndex;

    public Graveyard()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void SpawnSkeleton(int deadHealth)
    {
        Vector3 vector;
        Transform transform;
        Creep creep;
        Vector3 vector2;
        Transform transform2;
        Creep creep2;
        this.subRoadIndex += 1;
        if (this.subRoadIndex <= 2)
        {
            goto Label_0021;
        }
        this.subRoadIndex = 0;
    Label_0021:
        if (deadHealth >= 0x12b)
        {
            goto Label_00E4;
        }
        &vector = new Vector3(&(this.spawnPoints[this.lastSpawn]).x, &(this.spawnPoints[this.lastSpawn]).y, -1f);
        transform = UnityEngine.Object.Instantiate(this.skeletonPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = this.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.name = "Skeleton";
        creep.InitSprite();
        creep.SetPathIndex(this.nodePath);
        creep.SetSubPath(this.subRoadIndex);
        creep.SetCurrentNode(this.nodeIndex);
        creep.SetActive(1);
        if (GameData.notificationEnemySkeletor != null)
        {
            goto Label_01A1;
        }
        GameData.notificationEnemySkeletor = 1;
        goto Label_01A1;
    Label_00E4:
        &vector2 = new Vector3(&(this.spawnPoints[this.lastSpawn]).x, &(this.spawnPoints[this.lastSpawn]).y, -1f);
        transform2 = UnityEngine.Object.Instantiate(this.skeletonWarriorPrefab, vector2, Quaternion.identity) as Transform;
        transform2.parent = this.spawner.transform;
        creep2 = transform2.GetComponent<Creep>();
        creep2.name = "Skeleton Warrior";
        creep2.InitSprite();
        creep2.SetPathIndex(this.nodePath);
        creep2.SetSubPath(this.subRoadIndex);
        creep2.SetCurrentNode(this.nodeIndex);
        creep2.SetActive(1);
        if (GameData.notificationEnemySkeletorBig != null)
        {
            goto Label_01A1;
        }
        GameData.notificationEnemySkeletorBig = 1;
    Label_01A1:
        this.lastSpawn += 1;
        if (this.lastSpawn < ((int) this.spawnPoints.Length))
        {
            goto Label_01C9;
        }
        this.lastSpawn = 0;
    Label_01C9:
        return;
    }

    private void Start()
    {
        float num;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_004A;
        }
        this.nodeIndex = this.nodeIndex43;
        goto Label_0056;
    Label_004A:
        this.nodeIndex = this.nodeIndexWide;
    Label_0056:
        return;
    }
}

