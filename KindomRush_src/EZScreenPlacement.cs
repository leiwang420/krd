using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable, AddComponentMenu("EZ GUI/Utility/EZ Screen Placement"), ExecuteInEditMode]
public class EZScreenPlacement : MonoBehaviour, IUseCamera
{
    public bool allowTransformDrag;
    public bool alwaysRecursive;
    [HideInInspector]
    public EZScreenPlacement[] dependents;
    public bool ignoreZ;
    [NonSerialized]
    protected bool justEnabled;
    protected bool m_awake;
    protected bool m_started;
    [NonSerialized]
    protected EZScreenPlacementMirror mirror;
    public Transform relativeObject;
    public RelativeTo relativeTo;
    public Camera renderCamera;
    public Vector3 screenPos;
    protected Vector2 screenSize;

    public EZScreenPlacement()
    {
        this.screenPos = Vector3.forward;
        this.alwaysRecursive = 1;
        this.justEnabled = 1;
        this.mirror = new EZScreenPlacementMirror();
        this.dependents = new EZScreenPlacement[0];
        base..ctor();
        return;
    }

    private void Awake()
    {
        IUseCamera camera;
        RelativeTo to;
        if (this.m_awake == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.m_awake = 1;
        camera = (IUseCamera) base.GetComponent("IUseCamera");
        if (camera == null)
        {
            goto Label_0036;
        }
        this.renderCamera = camera.RenderCamera;
    Label_0036:
        if ((this.renderCamera == null) == null)
        {
            goto Label_0052;
        }
        this.renderCamera = Camera.main;
    Label_0052:
        if (this.relativeTo != null)
        {
            goto Label_006E;
        }
        this.relativeTo = new RelativeTo(this);
        goto Label_0098;
    Label_006E:
        if ((this.relativeTo.Script != this) == null)
        {
            goto Label_0098;
        }
        to = new RelativeTo(this, this.relativeTo);
        this.relativeTo = to;
    Label_0098:
        return;
    }

    public virtual void DoMirror()
    {
        if (Application.isPlaying == null)
        {
            goto Label_000B;
        }
        return;
    Label_000B:
        if (this.mirror != null)
        {
            goto Label_002D;
        }
        this.mirror = new EZScreenPlacementMirror();
        this.mirror.Mirror(this);
    Label_002D:
        this.mirror.Validate(this);
        if (this.mirror.DidChange(this) == null)
        {
            goto Label_0063;
        }
        this.SetCamera(this.renderCamera);
        this.mirror.Mirror(this);
    Label_0063:
        return;
    }

    public virtual void OnDrawGizmos()
    {
        this.DoMirror();
        return;
    }

    public virtual void OnDrawGizmosSelected()
    {
        this.DoMirror();
        return;
    }

    public unsafe void PositionOnScreen()
    {
        Plane plane;
        Vector3 vector;
        Vector3 vector2;
        if (this.m_awake != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.ignoreZ == null)
        {
            goto Label_005B;
        }
        &plane = new Plane(this.renderCamera.transform.forward, this.renderCamera.transform.position);
        &this.screenPos.z = &plane.GetDistanceToPoint(base.transform.position);
    Label_005B:
        if (this.ignoreZ == null)
        {
            goto Label_009E;
        }
        vector = this.ScreenPosToWorldPos(this.screenPos);
        &vector.z = &base.transform.position.z;
        base.transform.position = vector;
        goto Label_00B5;
    Label_009E:
        base.transform.position = this.ScreenPosToWorldPos(this.screenPos);
    Label_00B5:
        base.SendMessage("OnReposition", 1);
        return;
    }

    public void PositionOnScreen(Vector3 pos)
    {
        this.screenPos = pos;
        this.PositionOnScreen();
        return;
    }

    public void PositionOnScreen(int x, int y, float depth)
    {
        this.PositionOnScreen(new Vector3((float) x, (float) y, depth));
        return;
    }

    public void PositionOnScreenRecursively()
    {
        EZScreenPlacement placement;
        if (this.m_started != null)
        {
            goto Label_0011;
        }
        this.Start();
    Label_0011:
        if ((this.relativeObject != null) == null)
        {
            goto Label_004F;
        }
        placement = this.relativeObject.GetComponent(typeof(EZScreenPlacement)) as EZScreenPlacement;
        if ((placement != null) == null)
        {
            goto Label_004F;
        }
        placement.PositionOnScreenRecursively();
    Label_004F:
        this.PositionOnScreen();
        return;
    }

    public Vector3 ScreenPosToLocalPos(Vector3 screenPos)
    {
        return base.transform.InverseTransformPoint(this.ScreenPosToWorldPos(screenPos));
    }

    public Vector3 ScreenPosToParentPos(Vector3 screenPos)
    {
        return (this.ScreenPosToLocalPos(screenPos) + base.transform.localPosition);
    }

    public unsafe Vector3 ScreenPosToWorldPos(Vector3 screenPos)
    {
        Vector3 vector;
        Vector3 vector2;
        HORIZONTAL_ALIGN horizontal_align;
        Vector3 vector3;
        VERTICAL_ALIGN vertical_align;
        Vector3 vector4;
        if (this.m_started != null)
        {
            goto Label_0011;
        }
        this.Start();
    Label_0011:
        if ((this.renderCamera == null) == null)
        {
            goto Label_0048;
        }
        Debug.LogError("Render camera not yet assigned to EZScreenPlacement component of \"" + base.name + "\" when attempting to call PositionOnScreen()");
        return base.transform.position;
    Label_0048:
        vector = this.renderCamera.WorldToScreenPoint(base.transform.position);
        vector2 = screenPos;
        switch (this.relativeTo.horizontal)
        {
            case 0:
                goto Label_0126;

            case 1:
                goto Label_0139;

            case 2:
                goto Label_008C;

            case 3:
                goto Label_00AB;

            case 4:
                goto Label_00D0;
        }
        goto Label_0139;
    Label_008C:
        &vector2.x = &this.screenSize.x + &vector2.x;
        goto Label_0139;
    Label_00AB:
        &vector2.x = (&this.screenSize.x * 0.5f) + &vector2.x;
        goto Label_0139;
    Label_00D0:
        if ((this.relativeObject != null) == null)
        {
            goto Label_0113;
        }
        &vector2.x = &this.renderCamera.WorldToScreenPoint(this.relativeObject.position).x + &vector2.x;
        goto Label_0121;
    Label_0113:
        &vector2.x = &vector.x;
    Label_0121:
        goto Label_0139;
    Label_0126:
        &vector2.x = &vector.x;
    Label_0139:
        switch (this.relativeTo.vertical)
        {
            case 0:
                goto Label_0201;

            case 1:
                goto Label_0166;

            case 2:
                goto Label_0214;

            case 3:
                goto Label_0185;

            case 4:
                goto Label_01AA;
        }
        goto Label_0214;
    Label_0166:
        &vector2.y = &this.screenSize.y + &vector2.y;
        goto Label_0214;
    Label_0185:
        &vector2.y = (&this.screenSize.y * 0.5f) + &vector2.y;
        goto Label_0214;
    Label_01AA:
        if ((this.relativeObject != null) == null)
        {
            goto Label_01EE;
        }
        &vector2.y = &this.renderCamera.WorldToScreenPoint(this.relativeObject.position).y + &vector2.y;
        goto Label_01FC;
    Label_01EE:
        &vector2.y = &vector.y;
    Label_01FC:
        goto Label_0214;
    Label_0201:
        &vector2.y = &vector.y;
    Label_0214:
        return this.renderCamera.ScreenToWorldPoint(vector2);
    }

    public void SetCamera()
    {
        this.SetCamera(this.renderCamera);
        return;
    }

    public unsafe void SetCamera(Camera c)
    {
        if ((c == null) != null)
        {
            goto Label_0017;
        }
        if (base.enabled != null)
        {
            goto Label_0018;
        }
    Label_0017:
        return;
    Label_0018:
        this.renderCamera = c;
        &this.screenSize.x = this.renderCamera.pixelWidth;
        &this.screenSize.y = this.renderCamera.pixelHeight;
        if (this.alwaysRecursive != null)
        {
            goto Label_006A;
        }
        if (Application.isEditor == null)
        {
            goto Label_0075;
        }
        if (Application.isPlaying != null)
        {
            goto Label_0075;
        }
    Label_006A:
        this.PositionOnScreenRecursively();
        goto Label_007B;
    Label_0075:
        this.PositionOnScreen();
    Label_007B:
        return;
    }

    public unsafe void Start()
    {
        if (this.m_started == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.m_started = 1;
        if ((this.renderCamera != null) == null)
        {
            goto Label_0050;
        }
        &this.screenSize.x = this.renderCamera.pixelWidth;
        &this.screenSize.y = this.renderCamera.pixelHeight;
    Label_0050:
        this.PositionOnScreenRecursively();
        return;
    }

    public static bool TestDepenency(EZScreenPlacement sp)
    {
        List<EZScreenPlacement> list;
        EZScreenPlacement placement;
        if ((sp.relativeObject == null) == null)
        {
            goto Label_0013;
        }
        return 1;
    Label_0013:
        list = new List<EZScreenPlacement>();
        list.Add(sp);
        placement = sp.relativeObject.GetComponent(typeof(EZScreenPlacement)) as EZScreenPlacement;
        goto Label_0083;
    Label_0040:
        if (list.Contains(placement) == null)
        {
            goto Label_004E;
        }
        return 0;
    Label_004E:
        list.Add(placement);
        if ((placement.relativeObject == null) == null)
        {
            goto Label_0068;
        }
        return 1;
    Label_0068:
        placement = placement.relativeObject.GetComponent(typeof(EZScreenPlacement)) as EZScreenPlacement;
    Label_0083:
        if ((placement != null) != null)
        {
            goto Label_0040;
        }
        return 1;
    }

    public void UpdateCamera()
    {
        this.SetCamera(this.renderCamera);
        return;
    }

    public unsafe void WorldToScreenPos(Vector3 worldPos)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        HORIZONTAL_ALIGN horizontal_align;
        VERTICAL_ALIGN vertical_align;
        if ((this.renderCamera == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        vector = this.renderCamera.WorldToScreenPoint(worldPos);
        switch ((this.relativeTo.horizontal - 1))
        {
            case 0:
                goto Label_0071;

            case 1:
                goto Label_0088;

            case 2:
                goto Label_0048;

            case 3:
                goto Label_00AB;
        }
        goto Label_00F7;
    Label_0048:
        &this.screenPos.x = &vector.x - (this.renderCamera.pixelWidth / 2f);
        goto Label_00F7;
    Label_0071:
        &this.screenPos.x = &vector.x;
        goto Label_00F7;
    Label_0088:
        &this.screenPos.x = &vector.x - this.renderCamera.pixelWidth;
        goto Label_00F7;
    Label_00AB:
        if ((this.relativeObject != null) == null)
        {
            goto Label_00F7;
        }
        vector2 = this.renderCamera.WorldToScreenPoint(this.relativeObject.transform.position);
        &this.screenPos.x = &vector.x - &vector2.x;
    Label_00F7:
        switch ((this.relativeTo.vertical - 1))
        {
            case 0:
                goto Label_014B;

            case 1:
                goto Label_016E;

            case 2:
                goto Label_0122;

            case 3:
                goto Label_0185;
        }
        goto Label_01D1;
    Label_0122:
        &this.screenPos.y = &vector.y - (this.renderCamera.pixelHeight / 2f);
        goto Label_01D1;
    Label_014B:
        &this.screenPos.y = &vector.y - this.renderCamera.pixelHeight;
        goto Label_01D1;
    Label_016E:
        &this.screenPos.y = &vector.y;
        goto Label_01D1;
    Label_0185:
        if ((this.relativeObject != null) == null)
        {
            goto Label_01D1;
        }
        vector3 = this.renderCamera.WorldToScreenPoint(this.relativeObject.transform.position);
        &this.screenPos.y = &vector.y - &vector3.y;
    Label_01D1:
        &this.screenPos.z = &vector.z;
        if (this.alwaysRecursive == null)
        {
            goto Label_01F9;
        }
        this.PositionOnScreenRecursively();
        goto Label_01FF;
    Label_01F9:
        this.PositionOnScreen();
    Label_01FF:
        return;
    }

    public Camera RenderCamera
    {
        get
        {
            return this.renderCamera;
        }
        set
        {
            this.SetCamera(value);
            return;
        }
    }

    public Vector3 ScreenCoord
    {
        get
        {
            return this.renderCamera.WorldToScreenPoint(base.transform.position);
        }
    }

    public enum HORIZONTAL_ALIGN
    {
        NONE,
        SCREEN_LEFT,
        SCREEN_RIGHT,
        SCREEN_CENTER,
        OBJECT
    }

    [Serializable]
    public class RelativeTo
    {
        public EZScreenPlacement.HORIZONTAL_ALIGN horizontal;
        protected EZScreenPlacement script;
        public EZScreenPlacement.VERTICAL_ALIGN vertical;

        public RelativeTo(EZScreenPlacement sp)
        {
            this.horizontal = 1;
            this.vertical = 1;
            base..ctor();
            this.script = sp;
            return;
        }

        public RelativeTo(EZScreenPlacement sp, EZScreenPlacement.RelativeTo rt)
        {
            this.horizontal = 1;
            this.vertical = 1;
            base..ctor();
            this.script = sp;
            this.Copy(rt);
            return;
        }

        public void Copy(EZScreenPlacement.RelativeTo rt)
        {
            if (rt != null)
            {
                goto Label_0007;
            }
            return;
        Label_0007:
            this.horizontal = rt.horizontal;
            this.vertical = rt.vertical;
            return;
        }

        public bool Equals(EZScreenPlacement.RelativeTo rt)
        {
            if (rt != null)
            {
                goto Label_0008;
            }
            return 0;
        Label_0008:
            return ((this.horizontal != rt.horizontal) ? 0 : (this.vertical == rt.vertical));
        }

        public EZScreenPlacement Script
        {
            get
            {
                return this.script;
            }
            set
            {
                this.Script = value;
                return;
            }
        }
    }

    public enum VERTICAL_ALIGN
    {
        NONE,
        SCREEN_TOP,
        SCREEN_BOTTOM,
        SCREEN_CENTER,
        OBJECT
    }
}

