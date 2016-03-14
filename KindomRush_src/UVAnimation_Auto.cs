using System;
using UnityEngine;

[Serializable]
public class UVAnimation_Auto : UVAnimation
{
    public int cols;
    public Vector2 pixelsToNextColumnAndRow;
    public int rows;
    public Vector2 start;
    public int totalCells;

    public UVAnimation_Auto()
    {
        base..ctor();
        return;
    }

    public UVAnimation_Auto(UVAnimation_Auto anim)
    {
        base..ctor(anim);
        this.start = anim.start;
        this.pixelsToNextColumnAndRow = anim.pixelsToNextColumnAndRow;
        this.cols = anim.cols;
        this.rows = anim.rows;
        this.totalCells = anim.totalCells;
        return;
    }

    public SPRITE_FRAME[] BuildUVAnim(SpriteRoot s)
    {
        if (this.totalCells >= 1)
        {
            goto Label_000E;
        }
        return null;
    Label_000E:
        return base.BuildUVAnim(s.PixelCoordToUVCoord(this.start), s.PixelSpaceToUVSpace(this.pixelsToNextColumnAndRow), this.cols, this.rows, this.totalCells);
    }

    public UVAnimation_Auto Clone()
    {
        return new UVAnimation_Auto(this);
    }
}

