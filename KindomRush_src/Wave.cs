using System;
using System.Collections;
using UnityEngine;

public class Wave
{
    private int counter;
    private int indexSpawn;
    private int interval;
    private bool isFly;
    private bool isWaiting;
    private int isWatingTimeCounter;
    private string notification;
    private string notificationSecondLevel;
    private bool notificationSent;
    private int pathIndex;
    private WaveSpawn[] spawns;
    private StageBase stage;
    private ArrayList tmpArray;

    public Wave(WaveSpawn[] mySpawns, int myInterval, int myPathIndex, bool isWaveFlying)
    {
        this.tmpArray = new ArrayList();
        base..ctor();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.spawns = mySpawns;
        this.interval = myInterval;
        this.pathIndex = myPathIndex;
        this.counter = 0;
        this.indexSpawn = 0;
        this.isWaiting = 0;
        this.notification = string.Empty;
        this.notificationSecondLevel = string.Empty;
        this.notificationSent = 0;
        this.isFly = isWaveFlying;
        this.InitializeTooltipInformation();
        this.InitializeIsFlying();
        return;
    }

    public Wave(WaveSpawn[] mySpawns, int myInterval, int myPathIndex, string myNotification, string myNotificationSecondLevel, bool isWaveFlying)
    {
        this.tmpArray = new ArrayList();
        base..ctor();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.spawns = mySpawns;
        this.interval = myInterval;
        this.pathIndex = myPathIndex;
        this.counter = 0;
        this.indexSpawn = 0;
        this.isWaiting = 0;
        this.notification = myNotification;
        this.notificationSecondLevel = myNotificationSecondLevel;
        this.notificationSent = 0;
        this.isFly = isWaveFlying;
        this.InitializeTooltipInformation();
        this.InitializeIsFlying();
        return;
    }

    private void FixedUpdate()
    {
    }

    public int GetInterval()
    {
        return this.interval;
    }

    public ArrayList GetTooltipInformation()
    {
        return this.tmpArray;
    }

    private void InitializeIsFlying()
    {
        int num;
        string str;
        bool flag;
        this.isFly = 0;
        num = 0;
        goto Label_0057;
    Label_000E:
        flag = IronUtils.IsFlyingByCreepType(((ArrayList) this.tmpArray[num])[2].ToString());
        this.isFly = (this.isFly != null) ? 1 : flag;
        if (this.isFly == null)
        {
            goto Label_0053;
        }
        return;
    Label_0053:
        num += 1;
    Label_0057:
        if (num < this.tmpArray.Count)
        {
            goto Label_000E;
        }
        return;
    }

    public void InitializeTooltipInformation()
    {
        int num;
        int num2;
        int num3;
        int num4;
        int num5;
        int num6;
        ArrayList list;
        ArrayList list2;
        ArrayList list3;
        num = 0;
        num2 = 0;
        num3 = 0;
        num4 = 0;
        num5 = 0;
        num6 = 0;
        goto Label_0308;
    Label_0013:
        if ((this.spawns[num6].creepTypeAux == string.Empty) == null)
        {
            goto Label_0104;
        }
        num = this.IsAlready(this.tmpArray, this.spawns[num6].creepType);
        if (num != -1)
        {
            goto Label_00B8;
        }
        list = new ArrayList();
        list.Add(IronUtils.GetEnemyNameByClassName(this.spawns[num6].creepType));
        list.Add((int) this.spawns[num6].cant);
        list.Add(this.spawns[num6].creepType);
        this.tmpArray.Add(list);
        goto Label_00FF;
    Label_00B8:
        ((ArrayList) this.tmpArray[num])[1] = (int) (((int) ((ArrayList) this.tmpArray[num])[1]) + this.spawns[num6].cant);
    Label_00FF:
        goto Label_0302;
    Label_0104:
        num2 = Mathf.FloorToInt((float) (this.spawns[num6].cant / this.spawns[num6].maxSameCreep));
        num5 = this.spawns[num6].cant % this.spawns[num6].maxSameCreep;
        num3 = Mathf.CeilToInt(((float) num2) / 2f) * this.spawns[num6].maxSameCreep;
        num4 = Mathf.FloorToInt(((float) num2) / 2f) * this.spawns[num6].maxSameCreep;
        if ((num2 % 2) != null)
        {
            goto Label_0193;
        }
        num3 += num5;
        goto Label_0198;
    Label_0193:
        num4 += num5;
    Label_0198:
        num = this.IsAlready(this.tmpArray, this.spawns[num6].creepType);
        if (num != -1)
        {
            goto Label_0213;
        }
        list2 = new ArrayList();
        list2.Add(IronUtils.GetEnemyNameByClassName(this.spawns[num6].creepType));
        list2.Add((int) num3);
        list2.Add(this.spawns[num6].creepType);
        this.tmpArray.Add(list2);
        goto Label_024D;
    Label_0213:
        ((ArrayList) this.tmpArray[num])[1] = (int) (((int) ((ArrayList) this.tmpArray[num])[1]) + num3);
    Label_024D:
        num = this.IsAlready(this.tmpArray, this.spawns[num6].creepTypeAux);
        if (num != -1)
        {
            goto Label_02C8;
        }
        list3 = new ArrayList();
        list3.Add(IronUtils.GetEnemyNameByClassName(this.spawns[num6].creepTypeAux));
        list3.Add((int) num4);
        list3.Add(this.spawns[num6].creepTypeAux);
        this.tmpArray.Add(list3);
        goto Label_0302;
    Label_02C8:
        ((ArrayList) this.tmpArray[num])[1] = (int) (((int) ((ArrayList) this.tmpArray[num])[1]) + num4);
    Label_0302:
        num6 += 1;
    Label_0308:
        if (num6 < ((int) this.spawns.Length))
        {
            goto Label_0013;
        }
        return;
    }

    public void InitWithSpawns(WaveSpawn[] mySpawns, int myInterval, int myPathIndex, bool isWaveFlying)
    {
        this.spawns = mySpawns;
        this.interval = myInterval;
        this.pathIndex = myPathIndex;
        this.counter = 0;
        this.indexSpawn = 0;
        this.isWaiting = 0;
        this.isFly = isWaveFlying;
        this.InitializeTooltipInformation();
        this.InitializeIsFlying();
        return;
    }

    private int IsAlready(ArrayList tmpArray, string creep)
    {
        int num;
        num = 0;
        goto Label_002A;
    Label_0007:
        if (((ArrayList) tmpArray[num])[2].Equals(creep) == null)
        {
            goto Label_0026;
        }
        return num;
    Label_0026:
        num += 1;
    Label_002A:
        if (num < tmpArray.Count)
        {
            goto Label_0007;
        }
        return -1;
    }

    public void ShowWaveFlag(int myInterval, int index)
    {
        WaveSpawnFlag flag;
        bool flag2;
        flag2 = 0;
        if (index != null)
        {
            goto Label_000E;
        }
        flag2 = 1;
        myInterval = 10;
    Label_000E:
        this.stage.ShowWaveSpawnFlag(this.pathIndex, this.isFly, flag2, myInterval, this);
        return;
    }

    public bool SpawnEnemies()
    {
        if (this.indexSpawn >= ((int) this.spawns.Length))
        {
            goto Label_00B5;
        }
        if (this.isWaiting == null)
        {
            goto Label_0062;
        }
        if (this.isWatingTimeCounter >= this.spawns[this.indexSpawn].GetIntervalNextSpawn())
        {
            goto Label_004B;
        }
        this.isWatingTimeCounter += 1;
        return 1;
    Label_004B:
        this.indexSpawn += 1;
        this.isWaiting = 0;
        return 1;
    Label_0062:
        if (this.spawns[this.indexSpawn].SpawnEnemies(this.pathIndex, this) != null)
        {
            goto Label_00B3;
        }
        this.isWaiting = 1;
        this.isWatingTimeCounter = 0;
        if ((this.indexSpawn + 1) != ((int) this.spawns.Length))
        {
            goto Label_00B3;
        }
        this.indexSpawn += 1;
        return 0;
    Label_00B3:
        return 1;
    Label_00B5:
        this.stage.RemoveWave(this);
        return 0;
    }

    private void Start()
    {
    }

    public string Notification
    {
        get
        {
            return this.notification;
        }
    }

    public string NotificationSecondLevel
    {
        get
        {
            return this.notificationSecondLevel;
        }
    }

    public bool NotificationSent
    {
        get
        {
            return this.notificationSent;
        }
        set
        {
            this.notificationSent = value;
            return;
        }
    }
}

