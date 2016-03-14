using System;
using UnityEngine;

[Serializable]
public class SpriteState
{
    [HideInInspector]
    public CSpriteFrame frameInfo;
    [HideInInspector]
    public string imgPath;
    public string name;

    public SpriteState(string n, string p)
    {
        base..ctor();
        this.name = n;
        this.imgPath = p;
        return;
    }
}

