using System;
using UnityEngine;

public interface ISpriteMesh
{
    void Hide(bool tf);
    void Init();
    bool IsHidden();
    void UpdateColors(Color color);
    void UpdateUVs();
    void UpdateVerts();

    Material material { get; }

    SpriteRoot sprite { get; set; }

    Texture texture { get; }

    bool UseUV2 { get; set; }

    Vector2[] uvs { get; }

    Vector2[] uvs2 { get; }

    Vector3[] vertices { get; }
}

