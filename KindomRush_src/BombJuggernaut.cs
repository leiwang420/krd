using System;
using UnityEngine;

public class BombJuggernaut : Bomb
{
    private int creepSpawned;
    private Transform explosion;
    public Transform golemHeadPrefab;
    private int maxCreeps;
    private int nodeIndex;
    private int nodePath;
    private CreepSpawner spawner;
    private bool spawning;
    private int spawnTime;
    private int spawnTimeCounter;

    public BombJuggernaut()
    {
        this.spawnTime = 5;
        this.maxCreeps = 7;
        base..ctor();
        return;
    }

    protected unsafe void ChangeExplosionZ()
    {
        Vector3 vector;
        Vector3 vector2;
        this.explosion.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f);
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.spawning != null)
        {
            goto Label_004A;
        }
        this.Rotate();
        base.Travel();
        if (this.TravelEnd() == null)
        {
            goto Label_00B6;
        }
        GameSoundManager.PlayBombExplosionSound();
        this.Hit();
        this.ShowExplosion();
        this.ShowDecal();
        goto Label_00B6;
    Label_004A:
        if (this.spawnTimeCounter >= this.spawnTime)
        {
            goto Label_006A;
        }
        this.spawnTimeCounter += 1;
        return;
    Label_006A:
        if (this.creepSpawned >= this.maxCreeps)
        {
            goto Label_009B;
        }
        this.spawnTimeCounter = 0;
        this.SpawnEnemy();
        this.creepSpawned += 1;
        goto Label_00B6;
    Label_009B:
        UnityEngine.Object.Destroy(this.explosion.gameObject);
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00B6:
        return;
    }

    public override unsafe void Hit()
    {
        Vector3 vector;
        Vector3 vector2;
        this.spawning = 1;
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f);
        return;
    }

    public unsafe void InitBomb(Vector2 balldestiny, int spawningNodePath, int spawningNodeIndex)
    {
        Vector3 vector;
        base.destination = balldestiny;
        base.xDest = &balldestiny.x;
        base.yDest = &balldestiny.y;
        this.nodePath = spawningNodePath;
        this.nodeIndex = spawningNodeIndex;
        if (base.xDest <= &base.transform.position.x)
        {
            goto Label_0059;
        }
        base.rotDir = -1;
        goto Label_0060;
    Label_0059:
        base.rotDir = 1;
    Label_0060:
        return;
    }

    protected override void InitCustom()
    {
    }

    public override void ShowDecal()
    {
        Transform transform;
        int num;
        if ((base.decal != null) == null)
        {
            goto Label_009E;
        }
        num = (base.decalOver == null) ? -1 : -900;
        if (base.decalRotation == null)
        {
            goto Label_006E;
        }
        transform = UnityEngine.Object.Instantiate(base.decal, new Vector3(base.xDest, base.yDest + base.yDecalAdjust, (float) num), base.transform.rotation) as Transform;
        goto Label_009E;
    Label_006E:
        transform = UnityEngine.Object.Instantiate(base.decal, new Vector3(base.xDest, base.yDest + base.yDecalAdjust, (float) num), Quaternion.identity) as Transform;
    Label_009E:
        base.GetComponent<PackedSprite>().Hide(1);
        return;
    }

    protected override unsafe void ShowExplosion()
    {
        Vector3 vector;
        Vector3 vector2;
        this.explosion = UnityEngine.Object.Instantiate(base.explosionPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 20f, -840f), Quaternion.identity) as Transform;
        base.stage.AddExplosion(this.explosion);
        base.Invoke("ChangeExplosionZ", 0.5f);
        return;
    }

    private unsafe void SpawnEnemy()
    {
        Transform transform;
        Creep creep;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.golemHeadPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 4f, -1f), Quaternion.identity) as Transform;
        transform.parent = this.spawner.transform;
        transform.name = "Golem Head";
        creep = transform.GetComponent<Creep>();
        creep.InitSprite();
        creep.SetPathIndex(this.nodePath);
        creep.SetSubPath(UnityEngine.Random.Range(0, 3));
        creep.SetCurrentNode(this.nodeIndex + 5);
        creep.roadNodesTillActive = 0;
        creep.SetActive(1);
        creep.CheckFacing();
        return;
    }

    private unsafe void Start()
    {
        Vector2 vector;
        float num;
        Vector3 vector2;
        Vector3 vector3;
        GameSoundManager.PlayBombShootSound();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.g = -1.08f;
        &vector = new Vector2(&base.transform.position.x - base.xDest, &base.transform.position.y - base.yDest);
        num = (float) Mathf.RoundToInt(&vector.magnitude);
        base.t1 = 45f + Mathf.Floor(num / 256f);
        base.t0 = 0f;
        base.Init();
        base.ySpeed = ((base.yDest - base.yOrig) - (((base.g * base.t1) * base.t1) / 2f)) / base.t1;
        return;
    }
}

