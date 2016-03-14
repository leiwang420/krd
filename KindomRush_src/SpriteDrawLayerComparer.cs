using System;
using System.Collections.Generic;

public class SpriteDrawLayerComparer : IComparer<SpriteMesh_Managed>
{
    public SpriteDrawLayerComparer()
    {
        base..ctor();
        return;
    }

    public int Compare(SpriteMesh_Managed a, SpriteMesh_Managed b)
    {
        if (a.drawLayer <= b.drawLayer)
        {
            goto Label_0013;
        }
        return 1;
    Label_0013:
        if (a.drawLayer >= b.drawLayer)
        {
            goto Label_0026;
        }
        return -1;
    Label_0026:
        return 0;
    }
}

