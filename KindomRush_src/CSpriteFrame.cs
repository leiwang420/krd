using System;
using UnityEngine;

[Serializable]
public class CSpriteFrame
{
    public Vector2 bottomRightOffset;
    public Vector2 scaleFactor;
    public Vector2 topLeftOffset;
    public Rect uvs;

    public CSpriteFrame()
    {
        this.uvs = new Rect(1f, 1f, 1f, 1f);
        this.scaleFactor = new Vector2(0.5f, 0.5f);
        this.topLeftOffset = new Vector2(-1f, 1f);
        this.bottomRightOffset = new Vector2(1f, -1f);
        base..ctor();
        return;
    }

    public CSpriteFrame(CSpriteFrame f)
    {
        this.uvs = new Rect(1f, 1f, 1f, 1f);
        this.scaleFactor = new Vector2(0.5f, 0.5f);
        this.topLeftOffset = new Vector2(-1f, 1f);
        this.bottomRightOffset = new Vector2(1f, -1f);
        base..ctor();
        this.Copy(f);
        return;
    }

    public CSpriteFrame(SPRITE_FRAME f)
    {
        this.uvs = new Rect(1f, 1f, 1f, 1f);
        this.scaleFactor = new Vector2(0.5f, 0.5f);
        this.topLeftOffset = new Vector2(-1f, 1f);
        this.bottomRightOffset = new Vector2(1f, -1f);
        base..ctor();
        this.Copy(f);
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

    public unsafe void Copy(SPRITE_FRAME f)
    {
        this.uvs = &f.uvs;
        this.scaleFactor = &f.scaleFactor;
        this.topLeftOffset = &f.topLeftOffset;
        this.bottomRightOffset = &f.bottomRightOffset;
        return;
    }

    public unsafe SPRITE_FRAME ToStruct()
    {
        SPRITE_FRAME sprite_frame;
        &sprite_frame.uvs = this.uvs;
        &sprite_frame.scaleFactor = this.scaleFactor;
        &sprite_frame.topLeftOffset = this.topLeftOffset;
        &sprite_frame.bottomRightOffset = this.bottomRightOffset;
        return sprite_frame;
    }
}

