using System;
using UnityEngine;

public class SpriteRootMirror
{
    public SpriteRoot.ANCHOR_METHOD anchor;
    public bool autoResize;
    public Vector2 bleedCompensation;
    public Color color;
    public int drawLayer;
    public float height;
    public bool hideAtStart;
    public bool managed;
    public SpriteManager manager;
    public Vector3 offset;
    public bool pixelPerfect;
    public SpriteRoot.SPRITE_PLANE plane;
    public Camera renderCamera;
    public float width;
    public SpriteRoot.WINDING_ORDER winding;

    public SpriteRootMirror()
    {
        base..ctor();
        return;
    }

    public virtual unsafe bool DidChange(SpriteRoot s)
    {
        if (s.managed == this.managed)
        {
            goto Label_001A;
        }
        this.HandleManageState(s);
        return 1;
    Label_001A:
        if ((s.manager != this.manager) == null)
        {
            goto Label_0039;
        }
        this.UpdateManager(s);
        return 1;
    Label_0039:
        if (s.drawLayer == this.drawLayer)
        {
            goto Label_0053;
        }
        this.HandleDrawLayerChange(s);
        return 1;
    Label_0053:
        if (s.plane == this.plane)
        {
            goto Label_0066;
        }
        return 1;
    Label_0066:
        if (s.winding == this.winding)
        {
            goto Label_0079;
        }
        return 1;
    Label_0079:
        if (s.width == this.width)
        {
            goto Label_008C;
        }
        return 1;
    Label_008C:
        if (s.height == this.height)
        {
            goto Label_009F;
        }
        return 1;
    Label_009F:
        if ((s.bleedCompensation != this.bleedCompensation) == null)
        {
            goto Label_00B7;
        }
        return 1;
    Label_00B7:
        if (s.anchor == this.anchor)
        {
            goto Label_00CA;
        }
        return 1;
    Label_00CA:
        if ((s.offset != this.offset) == null)
        {
            goto Label_00E2;
        }
        return 1;
    Label_00E2:
        if (&s.color.r != &this.color.r)
        {
            goto Label_014E;
        }
        if (&s.color.g != &this.color.g)
        {
            goto Label_014E;
        }
        if (&s.color.b != &this.color.b)
        {
            goto Label_014E;
        }
        if (&s.color.a == &this.color.a)
        {
            goto Label_0150;
        }
    Label_014E:
        return 1;
    Label_0150:
        if (s.pixelPerfect == this.pixelPerfect)
        {
            goto Label_0163;
        }
        return 1;
    Label_0163:
        if (s.autoResize == this.autoResize)
        {
            goto Label_0176;
        }
        return 1;
    Label_0176:
        if ((s.renderCamera != this.renderCamera) == null)
        {
            goto Label_018E;
        }
        return 1;
    Label_018E:
        if (s.hideAtStart == this.hideAtStart)
        {
            goto Label_01AD;
        }
        s.Hide(s.hideAtStart);
        return 1;
    Label_01AD:
        return 0;
    }

    protected virtual void HandleDrawLayerChange(SpriteRoot s)
    {
        if (s.managed != null)
        {
            goto Label_0013;
        }
        s.drawLayer = 0;
        return;
    Label_0013:
        s.SetDrawLayer(s.drawLayer);
        return;
    }

    protected virtual void HandleManageState(SpriteRoot s)
    {
        s.managed = this.managed;
        s.Managed = this.managed == 0;
        return;
    }

    public virtual void Mirror(SpriteRoot s)
    {
        this.managed = s.managed;
        this.manager = s.manager;
        this.drawLayer = s.drawLayer;
        this.plane = s.plane;
        this.winding = s.winding;
        this.width = s.width;
        this.height = s.height;
        this.bleedCompensation = s.bleedCompensation;
        this.anchor = s.anchor;
        this.offset = s.offset;
        this.color = s.color;
        this.pixelPerfect = s.pixelPerfect;
        this.autoResize = s.autoResize;
        this.renderCamera = s.renderCamera;
        this.hideAtStart = s.hideAtStart;
        return;
    }

    public virtual void UpdateManager(SpriteRoot s)
    {
        if (s.managed != null)
        {
            goto Label_0017;
        }
        s.manager = null;
        goto Label_0052;
    Label_0017:
        if ((this.manager != null) == null)
        {
            goto Label_0034;
        }
        this.manager.RemoveSprite(s);
    Label_0034:
        if ((s.manager != null) == null)
        {
            goto Label_0052;
        }
        s.manager.AddSprite(s);
    Label_0052:
        return;
    }

    public virtual bool Validate(SpriteRoot s)
    {
        if (s.pixelPerfect == null)
        {
            goto Label_0012;
        }
        s.autoResize = 1;
    Label_0012:
        return 1;
    }
}

