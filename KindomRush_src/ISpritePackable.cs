using System;
using UnityEngine;

public interface ISpritePackable
{
    SpriteRoot.ANCHOR_METHOD Anchor { get; }

    UnityEngine.Color Color { get; set; }

    GameObject gameObject { get; }

    TextureAnim[] States { get; set; }

    bool SupportsArbitraryAnimations { get; }
}

