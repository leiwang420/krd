using System;
using UnityEngine;

public class LavaSpawn : MonoBehaviour
{
    private bool first;
    private GameGui gui;
    private bool isPaused;
    private bool isStarted;
    public Transform lavaElemental;
    private int spawnAuxTime;
    private CreepSpawner spawner;
    private int spawnTime;
    private int spawnTimeCounter;

    public LavaSpawn()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused != null)
        {
            goto Label_0016;
        }
        if (this.isStarted != null)
        {
            goto Label_0017;
        }
    Label_0016:
        return;
    Label_0017:
        this.spawnTimeCounter += 1;
        if (this.spawnTimeCounter >= this.spawnTime)
        {
            goto Label_0037;
        }
        return;
    Label_0037:
        this.SpawnLavaElemental();
        this.spawnTimeCounter = 0;
        if (this.first == null)
        {
            goto Label_0062;
        }
        this.spawnTime = this.spawnAuxTime;
        this.first = 0;
    Label_0062:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void SpawnLavaElemental()
    {
        int num;
        Transform transform;
        Creep creep;
        num = 3;
        transform = UnityEngine.Object.Instantiate(this.lavaElemental, new Vector3(-22f, 36f, -1f), Quaternion.identity) as Transform;
        transform.parent = this.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.InitSprite();
        creep.SetPathIndex(num);
        creep.SetSubPath(0);
        creep.SetCurrentNode(1);
        creep.SetActive(1);
        creep.roadNodesTillActive = 0;
        GameSoundManager.PlayRockElementalRally();
        this.gui.AddNotificationSecondLevel(0x29);
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.gui = base.GetComponent<GameGui>();
        this.first = 1;
        this.spawnTime = 0x2ee0;
        this.spawnAuxTime = 0xe10;
        this.isStarted = 0;
        return;
    }

    public void StartTimer()
    {
        this.isStarted = 1;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

