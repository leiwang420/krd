using System;
using UnityEngine;

public class WaveSpawn
{
    public int cant;
    public string creepType;
    public string creepTypeAux;
    private string currentCreep;
    private GameGui gui;
    private int indexCant;
    private int indexSwap;
    private int interval;
    private int intervalCounter;
    private int intervalNextSpawn;
    public int maxSameCreep;
    private int path;
    private CreepSpawner spawner;
    private bool useFixedPath;

    public WaveSpawn(string myCreepType, string myCreepTypeAux, int myMaxSameCreep, int myCant, int myInterval, int myIntervalNextSpawn, bool myUseFixedPath, int myPath)
    {
        base..ctor();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.gui = GameObject.Find("Stage").GetComponent<GameGui>();
        this.intervalCounter = 0;
        this.indexCant = 1;
        this.indexSwap = 0;
        this.creepType = myCreepType;
        this.creepTypeAux = myCreepTypeAux;
        this.currentCreep = myCreepType;
        this.maxSameCreep = myMaxSameCreep;
        this.cant = myCant;
        this.interval = myInterval - ((myInterval * 2) / 10);
        this.intervalNextSpawn = myIntervalNextSpawn - (myInterval / 10);
        this.useFixedPath = myUseFixedPath;
        this.path = myPath;
        return;
    }

    private bool EvalNotification(int notificationType, string enemy)
    {
        int num;
        num = notificationType;
        switch (num)
        {
            case 0:
                goto Label_0109;

            case 1:
                goto Label_0120;

            case 2:
                goto Label_051E;

            case 3:
                goto Label_051E;

            case 4:
                goto Label_03E9;

            case 5:
                goto Label_03ED;

            case 6:
                goto Label_03EF;

            case 7:
                goto Label_03F1;

            case 8:
                goto Label_03EB;

            case 9:
                goto Label_0137;

            case 10:
                goto Label_014E;

            case 11:
                goto Label_0165;

            case 12:
                goto Label_051E;

            case 13:
                goto Label_051E;

            case 14:
                goto Label_051E;

            case 15:
                goto Label_051E;

            case 0x10:
                goto Label_017C;

            case 0x11:
                goto Label_0193;

            case 0x12:
                goto Label_01AA;

            case 0x13:
                goto Label_01C1;

            case 20:
                goto Label_01D8;

            case 0x15:
                goto Label_01EF;

            case 0x16:
                goto Label_0206;

            case 0x17:
                goto Label_021D;

            case 0x18:
                goto Label_0234;

            case 0x19:
                goto Label_051E;

            case 0x1a:
                goto Label_051E;

            case 0x1b:
                goto Label_051E;

            case 0x1c:
                goto Label_051E;

            case 0x1d:
                goto Label_024B;

            case 30:
                goto Label_0262;

            case 0x1f:
                goto Label_0279;

            case 0x20:
                goto Label_0290;

            case 0x21:
                goto Label_02A7;

            case 0x22:
                goto Label_02BE;

            case 0x23:
                goto Label_02D5;

            case 0x24:
                goto Label_02EC;

            case 0x25:
                goto Label_0303;

            case 0x26:
                goto Label_031A;

            case 0x27:
                goto Label_0331;

            case 40:
                goto Label_0348;

            case 0x29:
                goto Label_035F;

            case 0x2a:
                goto Label_0376;

            case 0x2b:
                goto Label_038D;

            case 0x2c:
                goto Label_03A4;

            case 0x2d:
                goto Label_03BB;

            case 0x2e:
                goto Label_03D2;

            case 0x2f:
                goto Label_03F3;

            case 0x30:
                goto Label_040A;

            case 0x31:
                goto Label_051E;

            case 50:
                goto Label_0438;

            case 0x33:
                goto Label_0421;

            case 0x34:
                goto Label_051E;

            case 0x35:
                goto Label_044F;

            case 0x36:
                goto Label_0466;

            case 0x37:
                goto Label_051E;

            case 0x38:
                goto Label_047D;

            case 0x39:
                goto Label_0494;

            case 0x3a:
                goto Label_04AB;

            case 0x3b:
                goto Label_04C2;

            case 60:
                goto Label_04D9;

            case 0x3d:
                goto Label_04F0;

            case 0x3e:
                goto Label_0507;
        }
        goto Label_051E;
    Label_0109:
        if (enemy.Equals("EnemyGoblin") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0120:
        if (enemy.Equals("EnemyFatOrc") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0137:
        if (enemy.Equals("EnemyWolfSmall") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_014E:
        if (enemy.Equals("EnemyShaman") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0165:
        if (enemy.Equals("EnemyOgre") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_017C:
        if (enemy.Equals("EnemyBandit") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0193:
        if (enemy.Equals("EnemyBrigand") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_01AA:
        if (enemy.Equals("EnemyDarkKnight") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_01C1:
        if (enemy.Equals("EnemyMarauder") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_01D8:
        if (enemy.Equals("EnemySpider") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_01EF:
        if (enemy.Equals("EnemySpiderSmall") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0206:
        if (enemy.Equals("EnemyShadowArcher") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_021D:
        if (enemy.Equals("EnemyGargoyle") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0234:
        if (enemy.Equals("EnemyWolf") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_024B:
        if (enemy.Equals("EnemyTroll") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0262:
        if (enemy.Equals("EnemyTrollAxeThrower") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0279:
        if (enemy.Equals("EnemyTrollChieftain") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0290:
        if (enemy.Equals("EnemyWhiteWolf") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_02A7:
        if (enemy.Equals("EnemySlayer") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_02BE:
        if (enemy.Equals("EnemyYeti") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_02D5:
        if (enemy.Equals("EnemyRocketeer") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_02EC:
        if (enemy.Equals("EnemyDemon") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0303:
        if (enemy.Equals("EnemyDemonMage") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_031A:
        if (enemy.Equals("EnemyDemonImp") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0331:
        if (enemy.Equals("EnemyDemonWolf") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0348:
        if (enemy.Equals("EnemyNecromancer") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_035F:
        if (enemy.Equals("EnemyLavaElemental") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0376:
        if (enemy.Equals("EnemySarelgazSmall") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_038D:
        if (enemy.Equals("EnemyGoblinZapper") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_03A4:
        if (enemy.Equals("EnemyOrcWolfRider") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_03BB:
        if (enemy.Equals("EnemyOrcArmored") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_03D2:
        if (enemy.Equals("EnemyForestTroll") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_03E9:
        return 1;
    Label_03EB:
        return 1;
    Label_03ED:
        return 1;
    Label_03EF:
        return 1;
    Label_03F1:
        return 1;
    Label_03F3:
        if (enemy.Equals("EnemyZombie") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_040A:
        if (enemy.Equals("EnemyRottenSpider") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0421:
        if (enemy.Equals("EnemyThing") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0438:
        if (enemy.Equals("EnemyRottenTree") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_044F:
        if (enemy.Equals("EnemyRaider") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0466:
        if (enemy.Equals("EnemyPillager") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_047D:
        if (enemy.Equals("EnemyTrollSkater") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0494:
        if (enemy.Equals("EnemyTrollBrute") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_04AB:
        if (enemy.Equals("EnemyDemonCerberus") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_04C2:
        if (enemy.Equals("EnemyDemonLegion") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_04D9:
        if (enemy.Equals("EnemyDemonFlareon") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_04F0:
        if (enemy.Equals("EnemyDemonGulaemon") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_0507:
        if (enemy.Equals("EnemyRottenLesser") == null)
        {
            goto Label_0523;
        }
        return 1;
        goto Label_0523;
    Label_051E:;
    Label_0523:
        return 0;
    }

    public int GetIntervalNextSpawn()
    {
        return this.intervalNextSpawn;
    }

    public bool SpawnEnemies(int pathIndex, Wave wave)
    {
        if (this.indexCant <= this.cant)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        if ((this.interval - 1) <= this.intervalCounter)
        {
            goto Label_0039;
        }
        this.intervalCounter += 1;
        goto Label_00DB;
    Label_0039:
        if ((this.creepTypeAux != string.Empty) == null)
        {
            goto Label_009E;
        }
        if (this.indexSwap != this.maxSameCreep)
        {
            goto Label_00AA;
        }
        if ((this.currentCreep == this.creepTypeAux) == null)
        {
            goto Label_0086;
        }
        this.currentCreep = this.creepType;
        goto Label_0092;
    Label_0086:
        this.currentCreep = this.creepTypeAux;
    Label_0092:
        this.indexSwap = 0;
        goto Label_00AA;
    Label_009E:
        this.currentCreep = this.creepType;
    Label_00AA:
        this.SpawnEnemy(this.currentCreep, pathIndex, wave);
        this.indexSwap += 1;
        this.indexCant += 1;
        this.intervalCounter = 0;
    Label_00DB:
        return 1;
    }

    private void SpawnEnemy(string enemyType, int pathIndex, Wave wave)
    {
        int num;
        if (this.useFixedPath != null)
        {
            goto Label_0024;
        }
        this.spawner.Spawn(enemyType, pathIndex, UnityEngine.Random.Range(0, 3));
        goto Label_0037;
    Label_0024:
        this.spawner.Spawn(enemyType, pathIndex, this.path);
    Label_0037:
        if (wave.NotificationSecondLevel.Equals(string.Empty) != null)
        {
            goto Label_008D;
        }
        if (wave.NotificationSent != null)
        {
            goto Label_008D;
        }
        if (this.EvalNotification(Convert.ToInt32(wave.NotificationSecondLevel), enemyType) == null)
        {
            goto Label_008D;
        }
        num = Convert.ToInt32(wave.NotificationSecondLevel);
        this.gui.AddNotificationSecondLevel(num);
        wave.NotificationSent = 1;
    Label_008D:
        return;
    }
}

