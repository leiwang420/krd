using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class WavesXMLParser : SmallXmlParser.IContentHandler
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$mapE;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$mapF;
    private string currentValue;
    public Level level;
    private const string LEVEL_KEY = "waves";
    private int parseDepth;
    private const string SPAWN_KEY = "spawn";
    private Dictionary<string, string>[] values;
    private Wave wave;
    private const string WAVE_KEY = "wave";
    private WaveSpawn waveSpawn;

    public WavesXMLParser(string fileName)
    {
        int num;
        int num2;
        SmallXmlParser parser;
        TextReader reader;
        StringBuilder builder;
        base..ctor();
        num = 3;
        this.values = new Dictionary<string, string>[num];
        num2 = 0;
        goto Label_002C;
    Label_001B:
        this.values[num2] = new Dictionary<string, string>();
        num2 += 1;
    Label_002C:
        if (num2 < num)
        {
            goto Label_001B;
        }
        this.parseDepth = -1;
        parser = new SmallXmlParser();
        reader = this.GetReader(fileName);
        if (reader != null)
        {
            goto Label_004F;
        }
        return;
    Label_004F:
        parser.Parse(reader, this);
        builder = new StringBuilder();
        this.level.print(builder);
        Debug.Log(builder.ToString());
        return;
    }

    public Dictionary<string, string> GetCurrentDictionary()
    {
        return this.values[this.parseDepth];
    }

    public TextReader GetReader(string fileName)
    {
        FileInfo info;
        TextReader reader;
        TextAsset asset;
        Exception exception;
        TextReader reader2;
    Label_0000:
        try
        {
            info = null;
            reader = null;
            info = new FileInfo("Assets/Resources/Levels/" + fileName);
            Debug.Log(info.FullName);
            if (info == null)
            {
                goto Label_0047;
            }
            if (info.Exists == null)
            {
                goto Label_0047;
            }
            reader = info.OpenText();
            Debug.Log("Loaded xml from the filesystem");
            goto Label_0082;
        Label_0047:
            asset = (TextAsset) Resources.Load("Levels/" + Path.GetFileNameWithoutExtension(fileName), typeof(TextAsset));
            reader = new StringReader(asset.text);
            Debug.Log("Loaded xml from the resources");
        Label_0082:
            if (reader != null)
            {
                goto Label_0098;
            }
            Debug.Log(fileName + " not found or not readable");
        Label_0098:
            reader2 = reader;
            goto Label_00B9;
            goto Label_00B9;
        }
        catch (Exception exception1)
        {
        Label_00A5:
            exception = exception1;
            Debug.LogError(exception);
            reader2 = null;
            goto Label_00B9;
            goto Label_00B9;
        }
    Label_00B9:
        return reader2;
    }

    public void OnChars(string s)
    {
        this.currentValue = s;
        return;
    }

    public unsafe void OnEndElement(string name)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = name;
        if (str == null)
        {
            goto Label_0208;
        }
        if (<>f__switch$mapF != null)
        {
            goto Label_0043;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("waves", 0);
        dictionary.Add("wave", 1);
        dictionary.Add("spawn", 2);
        <>f__switch$mapF = dictionary;
    Label_0043:
        if (<>f__switch$mapF.TryGetValue(str, &num) == null)
        {
            goto Label_0208;
        }
        switch (num)
        {
            case 0:
                goto Label_006C;

            case 1:
                goto Label_0095;

            case 2:
                goto Label_0121;
        }
        goto Label_0208;
    Label_006C:
        this.level.cash = this.readInt("cash");
        this.parseDepth -= 1;
        goto Label_023C;
    Label_0095:
        this.wave.interval = this.readInt("interval");
        this.wave.pathIndex = this.readInt("path_index");
        this.wave.notification = this.readString("notification");
        this.wave.notificationSecondLevel = this.readString("notification_second_level");
        this.level.waves.Add(this.wave);
        this.GetCurrentDictionary().Clear();
        this.parseDepth -= 1;
        goto Label_023C;
    Label_0121:
        this.waveSpawn.creep = this.readString("creep");
        this.waveSpawn.creepAux = this.readString("creep_aux");
        this.waveSpawn.maxSame = this.readInt("max_same");
        this.waveSpawn.max = this.readInt("max");
        this.waveSpawn.interval = this.readInt("interval");
        this.waveSpawn.intervalNext = this.readInt("interval_next");
        this.waveSpawn.fixedSubPath = this.readInt("fixed_sub_path") == 1;
        this.waveSpawn.subpath = this.readInt("path");
        this.wave.spawns.Add(this.waveSpawn);
        this.GetCurrentDictionary().Clear();
        this.parseDepth -= 1;
        goto Label_023C;
    Label_0208:
        if (this.currentValue != null)
        {
            goto Label_021E;
        }
        this.currentValue = string.Empty;
    Label_021E:
        this.GetCurrentDictionary().Add(name, this.currentValue);
        this.currentValue = null;
    Label_023C:
        return;
    }

    public void OnEndParsing(SmallXmlParser parser)
    {
    }

    public void OnIgnorableWhitespace(string s)
    {
    }

    public void OnProcessingInstruction(string name, string text)
    {
    }

    public unsafe void OnStartElement(string name, SmallXmlParser.IAttrList attrs)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = name;
        if (str == null)
        {
            goto Label_00CB;
        }
        if (<>f__switch$mapE != null)
        {
            goto Label_0043;
        }
        dictionary = new Dictionary<string, int>(3);
        dictionary.Add("waves", 0);
        dictionary.Add("wave", 1);
        dictionary.Add("spawn", 2);
        <>f__switch$mapE = dictionary;
    Label_0043:
        if (<>f__switch$mapE.TryGetValue(str, &num) == null)
        {
            goto Label_00CB;
        }
        switch (num)
        {
            case 0:
                goto Label_006C;

            case 1:
                goto Label_008A;

            case 2:
                goto Label_00A8;
        }
        goto Label_00C6;
    Label_006C:
        this.level = new Level();
        this.parseDepth += 1;
        goto Label_00CB;
    Label_008A:
        this.wave = new Wave();
        this.parseDepth += 1;
        goto Label_00CB;
    Label_00A8:
        this.waveSpawn = new WaveSpawn();
        this.parseDepth += 1;
        goto Label_00CB;
    Label_00C6:;
    Label_00CB:
        return;
    }

    public void OnStartParsing(SmallXmlParser parser)
    {
    }

    public int readInt(string name)
    {
        string str;
        str = this.readString(name);
        if (str == null)
        {
            goto Label_001E;
        }
        if ((str == string.Empty) == null)
        {
            goto Label_0020;
        }
    Label_001E:
        return 0;
    Label_0020:
        return int.Parse(str);
    }

    public string readString(string name)
    {
        return this.GetCurrentDictionary()[name];
    }

    public class Level
    {
        public int cash;
        public List<WavesXMLParser.Wave> waves;

        public Level()
        {
            base..ctor();
            this.waves = new List<WavesXMLParser.Wave>();
            return;
        }

        public unsafe void print(StringBuilder builder)
        {
            WavesXMLParser.Wave wave;
            List<WavesXMLParser.Wave>.Enumerator enumerator;
            builder.AppendFormat("cash: {0}, wavesCant: {1}\n", (int) this.cash, (int) this.waves.Count);
            enumerator = this.waves.GetEnumerator();
        Label_0033:
            try
            {
                goto Label_0047;
            Label_0038:
                wave = &enumerator.Current;
                wave.print(builder);
            Label_0047:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_0038;
                }
                goto Label_0064;
            }
            finally
            {
            Label_0058:
                ((List<WavesXMLParser.Wave>.Enumerator) enumerator).Dispose();
            }
        Label_0064:
            return;
        }
    }

    public class Wave
    {
        public int interval;
        public string notification;
        public string notificationSecondLevel;
        public int pathIndex;
        public List<WavesXMLParser.WaveSpawn> spawns;

        public Wave()
        {
            base..ctor();
            this.spawns = new List<WavesXMLParser.WaveSpawn>();
            return;
        }

        public unsafe void print(StringBuilder builder)
        {
            object[] objArray1;
            WavesXMLParser.WaveSpawn spawn;
            List<WavesXMLParser.WaveSpawn>.Enumerator enumerator;
            objArray1 = new object[] { (int) this.interval, (int) this.pathIndex, this.notification, this.notificationSecondLevel, (int) this.spawns.Count };
            builder.AppendFormat("\tinterval: {0}, pathIndex: {1}, notification: {2}, notificationSecondLevel: {3}, cantSpawns: {4}\n", objArray1);
            enumerator = this.spawns.GetEnumerator();
        Label_005F:
            try
            {
                goto Label_0073;
            Label_0064:
                spawn = &enumerator.Current;
                spawn.print(builder);
            Label_0073:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_0064;
                }
                goto Label_0090;
            }
            finally
            {
            Label_0084:
                ((List<WavesXMLParser.WaveSpawn>.Enumerator) enumerator).Dispose();
            }
        Label_0090:
            return;
        }
    }

    public class WaveSpawn
    {
        public string creep;
        public string creepAux;
        public bool fixedSubPath;
        public int interval;
        public int intervalNext;
        public int max;
        public int maxSame;
        public int subpath;

        public WaveSpawn()
        {
            base..ctor();
            return;
        }

        public void print(StringBuilder builder)
        {
            object[] objArray1;
            objArray1 = new object[] { this.creep, (this.creepAux != null) ? this.creepAux : "null", (int) this.maxSame, (int) this.max, (int) this.interval, (int) this.intervalNext, (bool) this.fixedSubPath, (int) this.subpath };
            builder.AppendFormat("\t\t[creep: {0}, creepAux: {1}, maxSame: {2}, max: {3}, interval: {4}, intervalNext: {5}, fixedSubpath: {6}, subpath: {7}]\n", objArray1);
            return;
        }
    }
}

