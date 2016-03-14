using System;
using UnityEngine;

public class CreepSpiderEgg : MonoBehaviour
{
    private int intervalSpiderTime;
    private int intervalSpiderTimeCounter;
    private int intervalTime;
    private int intervalTimeCounter;
    private bool isActive;
    private bool isFading;
    private bool isPaused;
    private bool isSpawning;
    private int nodeIndex;
    private int nodePath;
    private CreepSpawner spawner;
    private int spiderCurrentNodeIndex;
    private int spiderMaxIndex;
    private int spiderSpawnIndex;
    private int spidersSpawnMax;
    private int spidersTotalMax;
    public Transform spiderTiny;
    private StageBase stage;

    public CreepSpiderEgg()
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
        if (this.isActive == null)
        {
            goto Label_0117;
        }
        if (this.isSpawning != null)
        {
            goto Label_005C;
        }
        if (this.intervalTimeCounter >= this.intervalTime)
        {
            goto Label_0042;
        }
        this.intervalTimeCounter += 1;
        return;
    Label_0042:
        this.isSpawning = 1;
        this.intervalSpiderTimeCounter = this.intervalSpiderTime;
        this.spiderCurrentNodeIndex = 0;
    Label_005C:
        if (this.intervalSpiderTimeCounter >= this.intervalSpiderTime)
        {
            goto Label_007C;
        }
        this.intervalSpiderTimeCounter += 1;
        return;
    Label_007C:
        this.SpawnSpider(this.spiderCurrentNodeIndex);
        this.intervalSpiderTimeCounter = 0;
        this.spiderSpawnIndex += 1;
        this.spiderMaxIndex += 1;
        this.spiderCurrentNodeIndex += 1;
        if (this.spiderCurrentNodeIndex <= 2)
        {
            goto Label_00CC;
        }
        this.spiderCurrentNodeIndex = 0;
    Label_00CC:
        if (this.spiderMaxIndex != this.spidersTotalMax)
        {
            goto Label_00F1;
        }
        this.isActive = 0;
        base.GetComponent<ParticleFade>().enabled = 1;
        return;
    Label_00F1:
        if (this.spiderSpawnIndex != this.spidersSpawnMax)
        {
            goto Label_0117;
        }
        this.intervalTimeCounter = 0;
        this.spiderSpawnIndex = 0;
        this.isSpawning = 0;
    Label_0117:
        return;
    }

    public void Init(int myNodePath, int myNodeIndex)
    {
        this.nodePath = myNodePath;
        this.nodeIndex = myNodeIndex;
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        base.GetComponent<PackedSprite>().PauseAnim();
        return;
    }

    private void SpawnSpider(int spiderCurrentNodeIndex)
    {
        Transform transform;
        Creep creep;
        transform = UnityEngine.Object.Instantiate(this.spiderTiny, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.spawner.transform;
        creep = transform.GetComponent<Creep>();
        creep.InitSprite();
        creep.SetPathIndex(this.nodePath);
        creep.SetSubPath(spiderCurrentNodeIndex);
        creep.SetCurrentNode(this.nodeIndex);
        creep.CheckFacing();
        creep.roadNodesTillActive = 0;
        creep.SetActive(1);
        if ((this.spiderTiny.name == "Spider Tiny") == null)
        {
            goto Label_009C;
        }
        creep.name = "Spider Tiny";
        goto Label_00C1;
    Label_009C:
        if ((this.spiderTiny.name == "Spider Rotten Tiny") == null)
        {
            goto Label_00C1;
        }
        creep.name = "Spider Rotten Tiny";
    Label_00C1:
        return;
    }

    private unsafe void Start()
    {
        int num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.spidersTotalMax = this.spidersSpawnMax = 3;
        this.isSpawning = 0;
        this.intervalTime = 0x55;
        this.intervalSpiderTime = 6;
        this.intervalTimeCounter = 0;
        this.intervalSpiderTimeCounter = 0;
        this.spiderMaxIndex = 0;
        this.spiderSpawnIndex = 0;
        this.spiderCurrentNodeIndex = 0;
        this.isActive = 1;
        this.isFading = 0;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        base.GetComponent<PackedSprite>().UnpauseAnim();
        return;
    }
}

