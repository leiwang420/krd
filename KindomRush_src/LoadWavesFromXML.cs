using System;
using System.IO;
using System.Text;
using UnityEngine;

public class LoadWavesFromXML : MonoBehaviour
{
    private StringBuilder builder;
    private int countSpawns;
    private int countWaves;
    public bool enabled;
    public string fileNameCampaign;
    public string fileNameHeroic;
    public string fileNameIron;
    public int gold;
    private bool printWaves;
    public Wave[] waves;
    private WaveSpawn[] wSpawn;

    public LoadWavesFromXML()
    {
        this.builder = new StringBuilder();
        base..ctor();
        return;
    }

    protected void CreateWave(WavesXMLParser.WaveSpawn a)
    {
        object[] objArray1;
        this.wSpawn[this.countSpawns] = new WaveSpawn(a.creep, a.creepAux, a.maxSame, a.max, a.interval, a.intervalNext, a.fixedSubPath, a.subpath);
        this.countSpawns += 1;
        if (this.printWaves == null)
        {
            goto Label_00F3;
        }
        objArray1 = new object[] { a.creep, a.creepAux, (int) a.maxSame, (int) a.max, (int) Mathf.RoundToInt(((float) a.interval) * 1.41f), (int) a.intervalNext, (a.fixedSubPath == null) ? "false" : "true", (int) a.subpath };
        this.builder.AppendFormat("\tnew WaveSpawn(\"{0}\",\"{1}\",{2},{3},{4},{5},{6},{7}),\n", objArray1);
    Label_00F3:
        return;
    }

    protected void CreateWaves(WavesXMLParser.Wave a)
    {
        object[] objArray1;
        if (this.printWaves == null)
        {
            goto Label_001C;
        }
        this.builder.AppendLine("new Wave(new WaveSpawn[] {\n");
    Label_001C:
        this.wSpawn = new WaveSpawn[a.spawns.Count];
        this.countSpawns = 0;
        a.spawns.ForEach(new Action<WavesXMLParser.WaveSpawn>(this.CreateWave));
        this.waves[this.countWaves] = new Wave(this.wSpawn, a.interval, a.pathIndex, a.notification, a.notificationSecondLevel, 0);
        this.countWaves += 1;
        if (this.printWaves == null)
        {
            goto Label_00DF;
        }
        objArray1 = new object[] { (int) a.interval, (int) a.pathIndex, a.notification, a.notificationSecondLevel };
        this.builder.AppendFormat("}} , {0},{1},\"{2}\",\"{3}\", false),\n\n", objArray1);
    Label_00DF:
        return;
    }

    public void LoadWaves(Constants.gameMode mode)
    {
        string str;
        WavesXMLParser parser;
        WavesXMLParser.Level level;
        str = string.Empty;
        if (mode != null)
        {
            goto Label_0018;
        }
        str = this.fileNameCampaign;
        goto Label_0039;
    Label_0018:
        if (mode != 1)
        {
            goto Label_002B;
        }
        str = this.fileNameHeroic;
        goto Label_0039;
    Label_002B:
        if (mode != 2)
        {
            goto Label_0039;
        }
        str = this.fileNameIron;
    Label_0039:
        parser = new WavesXMLParser(str);
        level = parser.level;
        this.gold = level.cash;
        this.waves = new Wave[level.waves.Count];
        this.countWaves = 0;
        level.waves.ForEach(new Action<WavesXMLParser.Wave>(this.CreateWaves));
        return;
    }

    public void PrintWaves()
    {
        StreamWriter writer;
        this.printWaves = 1;
        if (this.fileNameCampaign.Equals(string.Empty) != null)
        {
            goto Label_0050;
        }
        this.LoadWaves(0);
        writer = new StreamWriter("Assets/Resources/Levels/campaignFromXml.txt", 1);
        writer.Write(this.builder.ToString());
        writer.Close();
        Debug.Log("CAMPAIGN PRINTED");
    Label_0050:
        if (this.fileNameHeroic.Equals(string.Empty) != null)
        {
            goto Label_00A4;
        }
        this.builder = new StringBuilder();
        this.LoadWaves(1);
        writer = new StreamWriter("Assets/Resources/Levels/heroicFromXml.txt", 1);
        writer.Write(this.builder.ToString());
        writer.Close();
        Debug.Log("HEROIC PRINTED");
    Label_00A4:
        if (this.fileNameIron.Equals(string.Empty) != null)
        {
            goto Label_00F8;
        }
        this.builder = new StringBuilder();
        this.LoadWaves(2);
        writer = new StreamWriter("Assets/Resources/Levels/ironFromXml.txt", 1);
        writer.Write(this.builder.ToString());
        writer.Close();
        Debug.Log("IRON PRINTED");
    Label_00F8:
        return;
    }
}

