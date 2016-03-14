using System;
using System.Collections;
using System.Xml;
using UnityEngine;

public class StageXMLParser : MonoBehaviour
{
    private int cash;
    private int currentWaveInterval;
    private string currentWaveNotification;
    private string currentWaveNotificationSecondLevel;
    private int currentWavePathIndex;
    private ArrayList listWaves;
    private ArrayList listWaveSpawns;

    public StageXMLParser()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        XmlTextReader reader;
        XmlNodeType type;
        reader = new XmlTextReader("stageexample.xml");
        goto Label_008B;
    Label_0010:
        type = reader.NodeType;
        switch ((type - 1))
        {
            case 0:
                goto Label_0038;

            case 1:
                goto Label_002B;

            case 2:
                goto Label_0057;
        }
    Label_002B:
        if (type == 15)
        {
            goto Label_0067;
        }
        goto Label_0086;
    Label_0038:
        MonoBehaviour.print("<" + reader.Name + ">");
        goto Label_008B;
    Label_0057:
        MonoBehaviour.print(reader.Value);
        goto Label_008B;
    Label_0067:
        MonoBehaviour.print("</" + reader.Name + ">");
        goto Label_008B;
    Label_0086:;
    Label_008B:
        if (reader.Read() != null)
        {
            goto Label_0010;
        }
        return;
    }

    public int Cash
    {
        get
        {
            return this.cash;
        }
    }
}

