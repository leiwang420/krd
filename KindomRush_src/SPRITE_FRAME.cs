using System;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable, StructLayout(LayoutKind.Sequential)]
public struct SPRITE_FRAME
{
    public Rect uvs;
    public Vector2 scaleFactor;
    public Vector2 topLeftOffset;
    public Vector2 bottomRightOffset;
    public SPRITE_FRAME(float dummy)
    {
        this.uvs = new Rect(1f, 1f, 1f, 1f);
        this.scaleFactor = new Vector2(0.5f, 0.5f);
        this.topLeftOffset = new Vector2(-1f, 1f);
        this.bottomRightOffset = new Vector2(1f, -1f);
        return;
    }

    public void Copy(CSpriteFrame f)
    {
        this.uvs = f.uvs;
        this.scaleFactor = f.scaleFactor;
        this.topLeftOffset = f.topLeftOffset;
        this.bottomRightOffset = f.bottomRightOffset;
        return;
    }
}

