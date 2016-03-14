using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    public ButtonStart()
    {
        base..ctor();
        return;
    }

    private SaveGame DeserializeItem(string fileName, IFormatter formatter)
    {
        FileStream stream;
        SaveGame game;
        stream = new FileStream(fileName, 3);
        game = (SaveGame) formatter.Deserialize(stream);
        stream.Close();
        return game;
    }

    private void OnMouseDown()
    {
        string str;
        IFormatter formatter;
        str = "dataStuff.myData";
        formatter = new BinaryFormatter();
        this.SerializeItem(str, formatter);
        return;
    }

    private void SerializeItem(string fileName, IFormatter formatter)
    {
        SaveGame game;
        FileStream stream;
        game = new SaveGame();
        stream = new FileStream(fileName, 2);
        formatter.Serialize(stream, game);
        stream.Close();
        return;
    }

    private void Start()
    {
    }

    private void Update()
    {
        string str;
        IFormatter formatter;
        SaveGame game;
        if (Input.GetKeyDown(0x20) == null)
        {
            goto Label_0021;
        }
        str = "dataStuff.myData";
        formatter = new BinaryFormatter();
        game = this.DeserializeItem(str, formatter);
    Label_0021:
        return;
    }
}

