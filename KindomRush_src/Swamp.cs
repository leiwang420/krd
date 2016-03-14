using System;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    protected int lastSpawn;
    public int nodeIndex;
    public int nodePath;
    protected CreepSpawner spawner;
    public Vector2[] spawnPoints;
    protected int subRoadIndex;
    public Transform swampThingPrefab;
    public Transform zombiePrefab;

    public Swamp()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void SpawnZombie(int deadHealth)
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
        if (deadHealth >= 400)
        {
            goto Label_00DB;
        }
        &vector = new Vector3(&(this.spawnPoints[this.lastSpawn]).x, &(this.spawnPoints[this.lastSpawn]).y, -1f);
        transform = UnityEngine.Object.Instantiate(this.zombiePrefab, vector, Quaternion.identity) as Transform;
        transform.parent = this.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.name = "Zombie";
        creep.InitSprite();
        creep.SetPathIndex(this.nodePath);
        creep.SetSubPath(this.subRoadIndex);
        creep.SetCurrentNode(this.nodeIndex);
        creep.SetUseGold(0);
        creep.roadNodesTillActive = 0;
        goto Label_0190;
    Label_00DB:
        &vector2 = new Vector3(&(this.spawnPoints[this.lastSpawn]).x, &(this.spawnPoints[this.lastSpawn]).y, -1f);
        transform2 = UnityEngine.Object.Instantiate(this.swampThingPrefab, vector2, Quaternion.identity) as Transform;
        transform2.parent = this.spawner.transform;
        creep2 = transform2.GetComponent<Creep>();
        creep2.name = "Swamp Thing";
        creep2.InitSprite();
        creep2.SetPathIndex(this.nodePath);
        creep2.SetSubPath(this.subRoadIndex);
        creep2.SetCurrentNode(this.nodeIndex);
        creep2.SetUseGold(0);
        creep2.roadNodesTillActive = 0;
    Label_0190:
        this.lastSpawn += 1;
        if (this.lastSpawn < ((int) this.spawnPoints.Length))
        {
            goto Label_01B8;
        }
        this.lastSpawn = 0;
    Label_01B8:
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }
}

