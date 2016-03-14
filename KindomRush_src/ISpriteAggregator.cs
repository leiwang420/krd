using System;
using System.Runtime.InteropServices;
using UnityEngine;

public interface ISpriteAggregator
{
    void Aggregate(PathFromGUIDDelegate guid2Path, LoadAssetDelegate load, GUIDFromPathDelegate path2Guid);
    Material GetPackedMaterial(out string errString);
    void SetUVs(Rect uvs);

    CSpriteFrame DefaultFrame { get; }

    bool DoNotTrimImages { get; }

    GameObject gameObject { get; }

    Texture2D[] SourceTextures { get; }

    CSpriteFrame[] SpriteFrames { get; }
}

