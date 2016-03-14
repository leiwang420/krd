using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    protected int creepType;
    public Creep demonMagePrefab;
    public Creep demonPrefab;
    public Creep demonWolfPrefab;
    protected int fadeTime;
    protected int fadeTimeCounter;
    protected int headsCurrentNodeIndex;
    protected int headsMaxIndex;
    protected int headsSpawnIndex;
    protected int headsSpawnMax;
    protected int headsTotalMax;
    protected int intervalHeadTime;
    protected int intervalHeadTimeCounter;
    protected int intervalTime;
    protected int intervalTimeCounter;
    protected bool isActive;
    protected bool isPaused;
    protected bool isSpawning;
    protected int nodeIndex;
    protected int nodePath;
    public Transform portalEffectBigPrefab;
    public Transform portalEffectPrefab;
    protected CreepSpawner spawner;
    protected PackedSprite sprite;
    protected CreepVeznan veznan;

    public Portal()
    {
        base..ctor();
        return;
    }

    protected void FixedUpdate()
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
        if ((this.veznan == null) != null)
        {
            goto Label_0039;
        }
        if (this.veznan.IsDead() == null)
        {
            goto Label_0057;
        }
    Label_0039:
        this.isActive = 0;
        this.sprite.PlayAnim("fade");
        UnityEngine.Object.Destroy(this);
        return;
    Label_0057:
        if (this.isSpawning != null)
        {
            goto Label_009C;
        }
        if (this.intervalTimeCounter >= this.intervalTime)
        {
            goto Label_0082;
        }
        this.intervalTimeCounter += 1;
        return;
    Label_0082:
        this.isSpawning = 1;
        this.intervalHeadTimeCounter = this.intervalHeadTime;
        this.headsCurrentNodeIndex = 0;
    Label_009C:
        if (this.intervalHeadTimeCounter >= this.intervalHeadTime)
        {
            goto Label_00BC;
        }
        this.intervalHeadTimeCounter += 1;
        return;
    Label_00BC:
        this.SpawnEnemy(this.headsCurrentNodeIndex);
        this.intervalHeadTimeCounter = 0;
        this.headsSpawnIndex += 1;
        this.headsMaxIndex += 1;
        this.headsCurrentNodeIndex += 1;
        if (this.headsCurrentNodeIndex <= 2)
        {
            goto Label_010C;
        }
        this.headsCurrentNodeIndex = 0;
    Label_010C:
        if (this.headsMaxIndex != this.headsTotalMax)
        {
            goto Label_013B;
        }
        this.isActive = 0;
        this.sprite.PlayAnim("fade");
        UnityEngine.Object.Destroy(this);
        return;
    Label_013B:
        if (this.headsSpawnIndex != this.headsSpawnMax)
        {
            goto Label_0161;
        }
        this.intervalTimeCounter = 0;
        this.headsSpawnIndex = 0;
        this.isSpawning = 0;
    Label_0161:
        return;
    }

    protected virtual Creep GetEnemy()
    {
        return null;
    }

    protected virtual void InitCustom()
    {
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    protected void RemovePortal()
    {
    }

    protected void SpawnEnemy(int roadIndex)
    {
        Creep creep;
        creep = this.GetEnemy();
        creep.transform.parent = this.spawner.transform;
        creep.InitSprite();
        creep.SetPathIndex(this.nodePath);
        creep.SetSubPath(roadIndex);
        creep.SetCurrentNode(this.nodeIndex);
        creep.InitPosition();
        creep.CheckFacing();
        creep.roadNodesTillActive = 0;
        creep.SetActive(1);
        GameSoundManager.PlayVeznanPortalIn();
        return;
    }

    protected void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.veznan = GameObject.Find("Veznan").GetComponent<CreepVeznan>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.sprite.PlayAnim(0);
        this.demonPrefab = ((GameObject) Resources.Load("Prefabs/Creeps/Demon")).GetComponent<Creep>();
        this.demonMagePrefab = ((GameObject) Resources.Load("Prefabs/Creeps/DemonMage")).GetComponent<Creep>();
        this.demonWolfPrefab = ((GameObject) Resources.Load("Prefabs/Creeps/DemonWolf")).GetComponent<Creep>();
        this.portalEffectPrefab = ((GameObject) Resources.Load("Prefabs/Creep effects/State small/Teleport Veznan small")).GetComponent<Transform>();
        this.portalEffectBigPrefab = ((GameObject) Resources.Load("Prefabs/Creep effects/State big/Teleport Veznan big")).GetComponent<Transform>();
        this.isActive = 1;
        this.isSpawning = 0;
        this.intervalTime = 1;
        this.intervalTimeCounter = 0;
        this.intervalHeadTimeCounter = 0;
        this.headsMaxIndex = 0;
        this.headsSpawnIndex = 0;
        this.headsCurrentNodeIndex = 0;
        this.InitCustom();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

