using System;
using UnityEngine;

public class EZScreenPlacementMirror
{
    public Transform relativeObject;
    public EZScreenPlacement.RelativeTo relativeTo;
    public Camera renderCamera;
    public Vector3 screenPos;
    public Vector2 screenSize;
    public Vector3 worldPos;

    public EZScreenPlacementMirror()
    {
        base..ctor();
        this.relativeTo = new EZScreenPlacement.RelativeTo(null);
        return;
    }

    public virtual unsafe bool DidChange(EZScreenPlacement sp)
    {
        if ((this.worldPos != sp.transform.position) == null)
        {
            goto Label_0044;
        }
        if (sp.allowTransformDrag == null)
        {
            goto Label_003C;
        }
        sp.WorldToScreenPos(sp.transform.position);
        goto Label_0042;
    Label_003C:
        sp.PositionOnScreen();
    Label_0042:
        return 1;
    Label_0044:
        if ((this.screenPos != sp.screenPos) == null)
        {
            goto Label_005C;
        }
        return 1;
    Label_005C:
        if ((this.renderCamera != null) == null)
        {
            goto Label_00A5;
        }
        if (&this.screenSize.x != sp.renderCamera.pixelWidth)
        {
            goto Label_00A3;
        }
        if (&this.screenSize.y == sp.renderCamera.pixelHeight)
        {
            goto Label_00A5;
        }
    Label_00A3:
        return 1;
    Label_00A5:
        if (this.relativeTo.Equals(sp.relativeTo) != null)
        {
            goto Label_00BD;
        }
        return 1;
    Label_00BD:
        if ((this.renderCamera != sp.renderCamera) == null)
        {
            goto Label_00D5;
        }
        return 1;
    Label_00D5:
        if ((this.relativeObject != sp.relativeObject) == null)
        {
            goto Label_00ED;
        }
        return 1;
    Label_00ED:
        return 0;
    }

    public virtual void Mirror(EZScreenPlacement sp)
    {
        this.worldPos = sp.transform.position;
        this.screenPos = sp.screenPos;
        this.relativeTo.Copy(sp.relativeTo);
        this.relativeObject = sp.relativeObject;
        this.renderCamera = sp.renderCamera;
        this.screenSize = new Vector2(sp.renderCamera.pixelWidth, sp.renderCamera.pixelHeight);
        return;
    }

    public virtual bool Validate(EZScreenPlacement sp)
    {
        string[] textArray1;
        if (sp.relativeTo.horizontal == 4)
        {
            goto Label_0029;
        }
        if (sp.relativeTo.vertical == 4)
        {
            goto Label_0029;
        }
        sp.relativeObject = null;
    Label_0029:
        if ((sp.relativeObject != null) == null)
        {
            goto Label_008B;
        }
        if (EZScreenPlacement.TestDepenency(sp) != null)
        {
            goto Label_008B;
        }
        textArray1 = new string[] { "ERROR: The Relative Object you recently assigned on \"", sp.name, "\" which points to \"", sp.relativeObject.name, "\" would create a circular dependency.  Please check your placement dependencies to resolve this." };
        Debug.LogError(string.Concat(textArray1));
        sp.relativeObject = null;
    Label_008B:
        return 1;
    }
}

