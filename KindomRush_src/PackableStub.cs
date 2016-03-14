using System;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class PackableStub : MonoBehaviour
{
    protected PackableStub()
    {
        base..ctor();
        return;
    }

    public abstract void Aggregate(PathFromGUIDDelegate guid2Path, LoadAssetDelegate load, GUIDFromPathDelegate path2Guid);
    public abstract Material GetPackedMaterial(out string errString);
    public abstract void SetUVs(Rect uvs);

    public abstract CSpriteFrame DefaultFrame { get; }

    public abstract bool DoNotTrimImages { get; set; }

    public abstract Texture2D[] SourceTextures { get; }

    public abstract CSpriteFrame[] SpriteFrames { get; }
}

