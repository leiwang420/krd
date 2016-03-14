using System;
using UnityEngine;

public class SpriteMirror : SpriteRootMirror
{
    public Vector2 lowerLeftPixel;
    public Vector2 pixelDimensions;

    public SpriteMirror()
    {
        base..ctor();
        return;
    }

    public override bool DidChange(SpriteRoot s)
    {
        if (base.DidChange(s) == null)
        {
            goto Label_000E;
        }
        return 1;
    Label_000E:
        if ((((Sprite) s).lowerLeftPixel != this.lowerLeftPixel) == null)
        {
            goto Label_0032;
        }
        s.uvsInitialized = 0;
        return 1;
    Label_0032:
        if ((((Sprite) s).pixelDimensions != this.pixelDimensions) == null)
        {
            goto Label_0056;
        }
        s.uvsInitialized = 0;
        return 1;
    Label_0056:
        return 0;
    }

    public override void Mirror(SpriteRoot s)
    {
        base.Mirror(s);
        this.lowerLeftPixel = ((Sprite) s).lowerLeftPixel;
        this.pixelDimensions = ((Sprite) s).pixelDimensions;
        return;
    }
}

