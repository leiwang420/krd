using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public abstract class SpriteRoot : MonoBehaviour, IEZLinkedListItem<ISpriteAnimatable>, IUseCamera
{
    protected bool addedToManager;
    public ANCHOR_METHOD anchor;
    public bool autoResize;
    [HideInInspector]
    public bool billboarded;
    public Vector2 bleedCompensation;
    protected Vector2 bleedCompensationUV;
    protected Vector2 bleedCompensationUVMax;
    protected float bottomClipPct;
    protected Vector3 bottomRight;
    protected Vector2 bottomRightOffset;
    protected Vector2 brTruncate;
    protected bool clipped;
    protected Rect3D clippingRect;
    public UnityEngine.Color color;
    protected bool deleted;
    public int drawLayer;
    protected SPRITE_FRAME frameInfo;
    public float height;
    public bool hideAtStart;
    public bool ignoreClipping;
    [NonSerialized]
    public bool isClone;
    protected float leftClipPct;
    protected Rect localClipRect;
    protected bool m_hidden;
    protected ISpriteAnimatable m_next;
    protected ISpriteAnimatable m_prev;
    protected ISpriteMesh m_spriteMesh;
    protected bool m_started;
    public bool managed;
    public SpriteManager manager;
    protected SpriteRootMirror mirror;
    public Vector3 offset;
    protected Mesh oldMesh;
    public bool persistent;
    public bool pixelPerfect;
    [HideInInspector]
    public Vector2 pixelsPerUV;
    public SPRITE_PLANE plane;
    public Camera renderCamera;
    protected SpriteResizedDelegate resizedDelegate;
    protected float rightClipPct;
    protected SpriteManager savedManager;
    protected Vector2 scaleFactor;
    protected EZScreenPlacement screenPlacer;
    protected Vector2 screenSize;
    protected Vector2 sizeUnitsPerUV;
    protected Vector2 tempUV;
    protected Vector2 tlTruncate;
    protected float topClipPct;
    protected Vector3 topLeft;
    protected Vector2 topLeftOffset;
    protected bool truncated;
    protected Vector3 unclippedBottomRight;
    protected Vector3 unclippedTopLeft;
    protected Rect uvRect;
    [NonSerialized]
    public bool uvsInitialized;
    public float width;
    public WINDING_ORDER winding;
    protected float worldUnitsPerScreenPixel;

    protected SpriteRoot()
    {
        Vector3 vector;
        this.winding = 1;
        this.anchor = 9;
        this.frameInfo = new SPRITE_FRAME(0f);
        this.scaleFactor = new Vector2(0.5f, 0.5f);
        this.topLeftOffset = new Vector2(-1f, 1f);
        this.bottomRightOffset = new Vector2(1f, -1f);
        this.tlTruncate = new Vector2(1f, 1f);
        this.brTruncate = new Vector2(1f, 1f);
        this.leftClipPct = 1f;
        this.rightClipPct = 1f;
        this.topClipPct = 1f;
        this.bottomClipPct = 1f;
        this.offset = new Vector3();
        this.color = UnityEngine.Color.white;
        base..ctor();
        return;
    }

    protected void AddMesh()
    {
        this.m_spriteMesh = new SpriteMesh();
        this.m_spriteMesh.sprite = this;
        return;
    }

    protected virtual unsafe void Awake()
    {
        MeshFilter filter;
        &this.screenSize.x = 0f;
        &this.screenSize.y = 0f;
        if (base.name.EndsWith("(Clone)") == null)
        {
            goto Label_003C;
        }
        this.isClone = 1;
    Label_003C:
        if (this.managed != null)
        {
            goto Label_0087;
        }
        filter = (MeshFilter) base.GetComponent(typeof(MeshFilter));
        if ((filter != null) == null)
        {
            goto Label_007C;
        }
        this.oldMesh = filter.sharedMesh;
        filter.sharedMesh = null;
    Label_007C:
        this.AddMesh();
        goto Label_00C4;
    Label_0087:
        if ((this.manager != null) == null)
        {
            goto Label_00AA;
        }
        this.manager.AddSprite(this);
        goto Label_00C4;
    Label_00AA:
        Debug.LogError("Managed sprite \"" + base.name + "\" has not been assigned to a SpriteManager!");
    Label_00C4:
        return;
    }

    public unsafe void CalcEdges()
    {
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Rect rect;
        ANCHOR_METHOD anchor_method;
        float num;
        switch (this.anchor)
        {
            case 0:
                goto Label_00EB;

            case 1:
                goto Label_0133;

            case 2:
                goto Label_0188;

            case 3:
                goto Label_01D1;

            case 4:
                goto Label_0225;

            case 5:
                goto Label_0286;

            case 6:
                goto Label_02DB;

            case 7:
                goto Label_0322;

            case 8:
                goto Label_0376;

            case 9:
                goto Label_003C;
        }
        goto Label_03BE;
    Label_003C:
        &vector.x = this.width * &this.scaleFactor.x;
        &vector.y = this.height * &this.scaleFactor.y;
        &this.topLeft.x = &vector.x * &this.topLeftOffset.x;
        &this.topLeft.y = &vector.y * &this.topLeftOffset.y;
        &this.bottomRight.x = &vector.x * &this.bottomRightOffset.x;
        &this.bottomRight.y = &vector.y * &this.bottomRightOffset.y;
        goto Label_03BE;
    Label_00EB:
        &this.topLeft.x = 0f;
        &this.topLeft.y = 0f;
        &this.bottomRight.x = this.width;
        &this.bottomRight.y = -this.height;
        goto Label_03BE;
    Label_0133:
        &this.topLeft.x = this.width * -0.5f;
        &this.topLeft.y = 0f;
        &this.bottomRight.x = this.width * 0.5f;
        &this.bottomRight.y = -this.height;
        goto Label_03BE;
    Label_0188:
        &this.topLeft.x = -this.width;
        &this.topLeft.y = 0f;
        &this.bottomRight.x = 0f;
        &this.bottomRight.y = -this.height;
        goto Label_03BE;
    Label_01D1:
        &this.topLeft.x = 0f;
        &this.topLeft.y = this.height * 0.5f;
        &this.bottomRight.x = this.width;
        &this.bottomRight.y = this.height * -0.5f;
        goto Label_03BE;
    Label_0225:
        &this.topLeft.x = this.width * -0.5f;
        &this.topLeft.y = this.height * 0.5f;
        &this.bottomRight.x = this.width * 0.5f;
        &this.bottomRight.y = this.height * -0.5f;
        goto Label_03BE;
    Label_0286:
        &this.topLeft.x = -this.width;
        &this.topLeft.y = this.height * 0.5f;
        &this.bottomRight.x = 0f;
        &this.bottomRight.y = this.height * -0.5f;
        goto Label_03BE;
    Label_02DB:
        &this.topLeft.x = 0f;
        &this.topLeft.y = this.height;
        &this.bottomRight.x = this.width;
        &this.bottomRight.y = 0f;
        goto Label_03BE;
    Label_0322:
        &this.topLeft.x = this.width * -0.5f;
        &this.topLeft.y = this.height;
        &this.bottomRight.x = this.width * 0.5f;
        &this.bottomRight.y = 0f;
        goto Label_03BE;
    Label_0376:
        &this.topLeft.x = -this.width;
        &this.topLeft.y = this.height;
        &this.bottomRight.x = 0f;
        &this.bottomRight.y = 0f;
    Label_03BE:
        this.unclippedTopLeft = this.topLeft + this.offset;
        this.unclippedBottomRight = this.bottomRight + this.offset;
        if (this.truncated == null)
        {
            goto Label_04DF;
        }
        &this.topLeft.x = &this.bottomRight.x - ((&this.bottomRight.x - &this.topLeft.x) * &this.tlTruncate.x);
        &this.topLeft.y = &this.bottomRight.y - ((&this.bottomRight.y - &this.topLeft.y) * &this.tlTruncate.y);
        &this.bottomRight.x = &this.topLeft.x - ((&this.topLeft.x - &this.bottomRight.x) * &this.brTruncate.x);
        &this.bottomRight.y = &this.topLeft.y - ((&this.topLeft.y - &this.bottomRight.y) * &this.brTruncate.y);
    Label_04DF:
        if (this.clipped == null)
        {
            goto Label_080B;
        }
        if ((&this.bottomRight.x - &this.topLeft.x) == 0f)
        {
            goto Label_080B;
        }
        if ((&this.topLeft.y - &this.bottomRight.y) == 0f)
        {
            goto Label_080B;
        }
        vector2 = this.topLeft;
        vector3 = this.bottomRight;
        rect = this.localClipRect;
        &rect.x -= &this.offset.x;
        &rect.y -= &this.offset.y;
        if (&this.topLeft.x >= &rect.x)
        {
            goto Label_0611;
        }
        this.leftClipPct = 1f - ((&rect.x - &vector2.x) / (&vector3.x - &vector2.x));
        &this.topLeft.x = Mathf.Clamp(&rect.x, &vector2.x, &vector3.x);
        if (this.leftClipPct > 0f)
        {
            goto Label_061C;
        }
        &this.topLeft.x = &this.bottomRight.x = &rect.x;
        goto Label_061C;
    Label_0611:
        this.leftClipPct = 1f;
    Label_061C:
        if (&this.bottomRight.x <= &rect.xMax)
        {
            goto Label_06B4;
        }
        this.rightClipPct = (&rect.xMax - &vector2.x) / (&vector3.x - &vector2.x);
        &this.bottomRight.x = Mathf.Clamp(&rect.xMax, &vector2.x, &vector3.x);
        if (this.rightClipPct > 0f)
        {
            goto Label_06BF;
        }
        &this.bottomRight.x = &this.topLeft.x = &rect.xMax;
        goto Label_06BF;
    Label_06B4:
        this.rightClipPct = 1f;
    Label_06BF:
        if (&this.topLeft.y <= &rect.yMax)
        {
            goto Label_0757;
        }
        this.topClipPct = (&rect.yMax - &vector3.y) / (&vector2.y - &vector3.y);
        &this.topLeft.y = Mathf.Clamp(&rect.yMax, &vector3.y, &vector2.y);
        if (this.topClipPct > 0f)
        {
            goto Label_0762;
        }
        &this.topLeft.y = &this.bottomRight.y = &rect.yMax;
        goto Label_0762;
    Label_0757:
        this.topClipPct = 1f;
    Label_0762:
        if (&this.bottomRight.y >= &rect.y)
        {
            goto Label_0800;
        }
        this.bottomClipPct = 1f - ((&rect.y - &vector3.y) / (&vector2.y - &vector3.y));
        &this.bottomRight.y = Mathf.Clamp(&rect.y, &vector3.y, &vector2.y);
        if (this.bottomClipPct > 0f)
        {
            goto Label_080B;
        }
        &this.bottomRight.y = &this.topLeft.y = &rect.y;
        goto Label_080B;
    Label_0800:
        this.bottomClipPct = 1f;
    Label_080B:
        if (this.winding != null)
        {
            goto Label_0844;
        }
        &this.topLeft.x *= -1f;
        &this.bottomRight.x *= -1f;
    Label_0844:
        return;
    }

    public void CalcPixelToUV()
    {
        if (this.managed == null)
        {
            goto Label_0062;
        }
        if (this.spriteMesh == null)
        {
            goto Label_00BA;
        }
        if ((this.spriteMesh.material != null) == null)
        {
            goto Label_00BA;
        }
        if ((this.spriteMesh.material.mainTexture != null) == null)
        {
            goto Label_00BA;
        }
        this.SetPixelToUV(this.spriteMesh.material.mainTexture);
        goto Label_00BA;
    Label_0062:
        if ((base.renderer != null) == null)
        {
            goto Label_00BA;
        }
        if ((base.renderer.sharedMaterial != null) == null)
        {
            goto Label_00BA;
        }
        if ((base.renderer.sharedMaterial.mainTexture != null) == null)
        {
            goto Label_00BA;
        }
        this.SetPixelToUV(base.renderer.sharedMaterial.mainTexture);
    Label_00BA:
        return;
    }

    public unsafe void CalcSize()
    {
        if (&this.uvRect.width != 0f)
        {
            goto Label_0025;
        }
        &this.uvRect.width = 1E-07f;
    Label_0025:
        if (&this.uvRect.height != 0f)
        {
            goto Label_004A;
        }
        &this.uvRect.height = 1E-07f;
    Label_004A:
        if (this.pixelPerfect == null)
        {
            goto Label_00AC;
        }
        this.width = (this.worldUnitsPerScreenPixel * &&this.frameInfo.uvs.width) * &this.pixelsPerUV.x;
        this.height = (this.worldUnitsPerScreenPixel * &&this.frameInfo.uvs.height) * &this.pixelsPerUV.y;
        goto Label_0125;
    Label_00AC:
        if (this.autoResize == null)
        {
            goto Label_0125;
        }
        if (&this.sizeUnitsPerUV.x == 0f)
        {
            goto Label_0125;
        }
        if (&this.sizeUnitsPerUV.y == 0f)
        {
            goto Label_0125;
        }
        this.width = &&this.frameInfo.uvs.width * &this.sizeUnitsPerUV.x;
        this.height = &&this.frameInfo.uvs.height * &this.sizeUnitsPerUV.y;
    Label_0125:
        this.SetSize(this.width, this.height);
        return;
    }

    protected unsafe void CalcSizeUnitsPerUV()
    {
        Rect rect;
        rect = &this.frameInfo.uvs;
        if (&rect.width == 0f)
        {
            goto Label_0050;
        }
        if (&rect.height == 0f)
        {
            goto Label_0050;
        }
        if (&rect.xMin != 1f)
        {
            goto Label_005C;
        }
        if (&rect.yMin != 1f)
        {
            goto Label_005C;
        }
    Label_0050:
        this.sizeUnitsPerUV = Vector2.zero;
        return;
    Label_005C:
        &this.sizeUnitsPerUV.x = this.width / &rect.width;
        &this.sizeUnitsPerUV.y = this.height / &rect.height;
        return;
    }

    public virtual void Clear()
    {
        this.billboarded = 0;
        this.SetColor(UnityEngine.Color.white);
        this.offset = Vector3.zero;
        return;
    }

    public virtual void Copy(SpriteRoot s)
    {
        if (this.managed != null)
        {
            goto Label_0062;
        }
        if (this.m_spriteMesh == null)
        {
            goto Label_0041;
        }
        if (s.spriteMesh == null)
        {
            goto Label_0041;
        }
        ((SpriteMesh) this.m_spriteMesh).material = s.spriteMesh.material;
        goto Label_0062;
    Label_0041:
        if (s.managed != null)
        {
            goto Label_0062;
        }
        base.renderer.sharedMaterial = s.renderer.sharedMaterial;
    Label_0062:
        this.drawLayer = s.drawLayer;
        if ((s.renderCamera != null) == null)
        {
            goto Label_008B;
        }
        this.SetCamera(s.renderCamera);
    Label_008B:
        if ((this.renderCamera == null) == null)
        {
            goto Label_00A7;
        }
        this.renderCamera = Camera.main;
    Label_00A7:
        if (this.m_spriteMesh == null)
        {
            goto Label_0115;
        }
        if ((this.m_spriteMesh.texture != null) == null)
        {
            goto Label_00DE;
        }
        this.SetPixelToUV(this.m_spriteMesh.texture);
        goto Label_0115;
    Label_00DE:
        if (this.managed != null)
        {
            goto Label_0115;
        }
        ((SpriteMesh) this.m_spriteMesh).material = base.renderer.sharedMaterial;
        this.SetPixelToUV(this.m_spriteMesh.texture);
    Label_0115:
        this.plane = s.plane;
        this.winding = s.winding;
        this.offset = s.offset;
        this.anchor = s.anchor;
        this.bleedCompensation = s.bleedCompensation;
        this.autoResize = s.autoResize;
        this.pixelPerfect = s.pixelPerfect;
        this.ignoreClipping = s.ignoreClipping;
        this.uvRect = s.uvRect;
        this.scaleFactor = s.scaleFactor;
        this.topLeftOffset = s.topLeftOffset;
        this.bottomRightOffset = s.bottomRightOffset;
        this.width = s.width;
        this.height = s.height;
        this.SetColor(s.color);
        return;
    }

    public virtual void Delete()
    {
        this.deleted = 1;
        if (this.managed != null)
        {
            goto Label_0042;
        }
        if (Application.isPlaying == null)
        {
            goto Label_0042;
        }
        UnityEngine.Object.Destroy(((SpriteMesh) this.spriteMesh).mesh);
        ((SpriteMesh) this.spriteMesh).mesh = null;
    Label_0042:
        return;
    }

    protected void DestroyMesh()
    {
        UnityEngine.Object obj2;
        if (this.m_spriteMesh == null)
        {
            goto Label_0017;
        }
        this.m_spriteMesh.sprite = null;
    Label_0017:
        this.m_spriteMesh = null;
        if ((base.renderer != null) == null)
        {
            goto Label_0054;
        }
        if (Application.isPlaying == null)
        {
            goto Label_0049;
        }
        UnityEngine.Object.Destroy(base.renderer);
        goto Label_0054;
    Label_0049:
        UnityEngine.Object.DestroyImmediate(base.renderer);
    Label_0054:
        obj2 = base.gameObject.GetComponent(typeof(MeshFilter));
        if ((obj2 != null) == null)
        {
            goto Label_0091;
        }
        if (Application.isPlaying == null)
        {
            goto Label_008B;
        }
        UnityEngine.Object.Destroy(obj2);
        goto Label_0091;
    Label_008B:
        UnityEngine.Object.DestroyImmediate(obj2);
    Label_0091:
        return;
    }

    public virtual unsafe void DoMirror()
    {
        if (Application.isPlaying == null)
        {
            goto Label_000B;
        }
        return;
    Label_000B:
        if (&this.screenSize.x == 0f)
        {
            goto Label_0035;
        }
        if (&this.screenSize.y != 0f)
        {
            goto Label_003B;
        }
    Label_0035:
        this.Start();
    Label_003B:
        if (this.mirror != null)
        {
            goto Label_005D;
        }
        this.mirror = new SpriteRootMirror();
        this.mirror.Mirror(this);
    Label_005D:
        this.mirror.Validate(this);
        if (this.mirror.DidChange(this) == null)
        {
            goto Label_008D;
        }
        this.Init();
        this.mirror.Mirror(this);
    Label_008D:
        return;
    }

    public unsafe Vector3 GetCenterPoint()
    {
        Vector3[] vectorArray;
        SPRITE_PLANE sprite_plane;
        if (this.m_spriteMesh != null)
        {
            goto Label_0011;
        }
        return Vector3.zero;
    Label_0011:
        vectorArray = this.m_spriteMesh.vertices;
        switch (this.plane)
        {
            case 0:
                goto Label_003B;

            case 1:
                goto Label_00A4;

            case 2:
                goto Label_010D;
        }
        goto Label_0176;
    Label_003B:
        return new Vector3(&(vectorArray[0]).x + (0.5f * (&(vectorArray[2]).x - &(vectorArray[0]).x)), &(vectorArray[0]).y - (0.5f * (&(vectorArray[0]).y - &(vectorArray[2]).y)), &this.offset.z);
    Label_00A4:
        return new Vector3(&(vectorArray[0]).x + (0.5f * (&(vectorArray[2]).x - &(vectorArray[0]).x)), &this.offset.y, &(vectorArray[0]).z - (0.5f * (&(vectorArray[0]).z - &(vectorArray[2]).z)));
    Label_010D:
        return new Vector3(&this.offset.x, &(vectorArray[0]).y - (0.5f * (&(vectorArray[0]).y - &(vectorArray[2]).y)), &(vectorArray[0]).z - (0.5f * (&(vectorArray[0]).z - &(vectorArray[2]).z)));
    Label_0176:
        return new Vector3(&(vectorArray[0]).x + (0.5f * (&(vectorArray[2]).x - &(vectorArray[0]).x)), &(vectorArray[0]).y - (0.5f * (&(vectorArray[0]).y - &(vectorArray[2]).y)), &this.offset.z);
    }

    public abstract Vector2 GetDefaultPixelSize(PathFromGUIDDelegate guid2Path, AssetLoaderDelegate loader);
    public abstract int GetStateIndex(string stateName);
    public Rect GetUVs()
    {
        return this.uvRect;
    }

    public Vector3[] GetVertices()
    {
        if (this.managed != null)
        {
            goto Label_0021;
        }
        return ((SpriteMesh) this.m_spriteMesh).mesh.vertices;
    Label_0021:
        return this.m_spriteMesh.vertices;
    }

    public virtual void Hide(bool tf)
    {
        if (this.m_spriteMesh == null)
        {
            goto Label_0017;
        }
        this.m_spriteMesh.Hide(tf);
    Label_0017:
        this.m_hidden = tf;
        return;
    }

    protected virtual void Init()
    {
        this.screenPlacer = (EZScreenPlacement) base.GetComponent(typeof(EZScreenPlacement));
        if ((this.screenPlacer != null) == null)
        {
            goto Label_003D;
        }
        this.screenPlacer.SetCamera(this.renderCamera);
    Label_003D:
        if (this.m_spriteMesh == null)
        {
            goto Label_00A5;
        }
        if (this.persistent == null)
        {
            goto Label_0073;
        }
        if (this.managed != null)
        {
            goto Label_0073;
        }
        UnityEngine.Object.DontDestroyOnLoad(((SpriteMesh) this.m_spriteMesh).mesh);
    Label_0073:
        if ((this.m_spriteMesh.texture != null) == null)
        {
            goto Label_009A;
        }
        this.SetPixelToUV(this.m_spriteMesh.texture);
    Label_009A:
        this.m_spriteMesh.Init();
    Label_00A5:
        if (Application.isPlaying != null)
        {
            goto Label_00B5;
        }
        this.CalcSizeUnitsPerUV();
    Label_00B5:
        return;
    }

    public virtual unsafe void InitUVs()
    {
        this.uvRect = &this.frameInfo.uvs;
        return;
    }

    public bool IsHidden()
    {
        return this.m_hidden;
    }

    public virtual void OnDestroy()
    {
        this.Delete();
        return;
    }

    protected virtual void OnDisable()
    {
        if (this.managed == null)
        {
            goto Label_0034;
        }
        if ((this.manager != null) == null)
        {
            goto Label_0034;
        }
        this.savedManager = this.manager;
        this.manager.RemoveSprite(this);
    Label_0034:
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

    protected virtual unsafe void OnEnable()
    {
        SPRITE_FRAME sprite_frame;
        if (this.managed == null)
        {
            goto Label_005E;
        }
        if ((this.manager != null) == null)
        {
            goto Label_005E;
        }
        if (this.m_started == null)
        {
            goto Label_005E;
        }
        sprite_frame = this.frameInfo;
        this.manager.AddSprite(this);
        this.frameInfo = sprite_frame;
        this.uvRect = &this.frameInfo.uvs;
        this.SetBleedCompensation();
        goto Label_007C;
    Label_005E:
        if ((this.savedManager != null) == null)
        {
            goto Label_007C;
        }
        this.savedManager.AddSprite(this);
    Label_007C:
        return;
    }

    public unsafe Vector2 PixelCoordToUVCoord(Vector2 xy)
    {
        if (&this.pixelsPerUV.x == 0f)
        {
            goto Label_002A;
        }
        if (&this.pixelsPerUV.y != 0f)
        {
            goto Label_0030;
        }
    Label_002A:
        return Vector2.zero;
    Label_0030:
        return new Vector2(&xy.x / &this.pixelsPerUV.x, ((&this.pixelsPerUV.y - &xy.y) - 1f) / &this.pixelsPerUV.y);
    }

    public Vector2 PixelCoordToUVCoord(int x, int y)
    {
        return this.PixelCoordToUVCoord(new Vector2((float) x, (float) y));
    }

    public unsafe Vector2 PixelSpaceToUVSpace(Vector2 xy)
    {
        if (&this.pixelsPerUV.x == 0f)
        {
            goto Label_002A;
        }
        if (&this.pixelsPerUV.y != 0f)
        {
            goto Label_0030;
        }
    Label_002A:
        return Vector2.zero;
    Label_0030:
        return new Vector2(&xy.x / &this.pixelsPerUV.x, &xy.y / &this.pixelsPerUV.y);
    }

    public Vector2 PixelSpaceToUVSpace(int x, int y)
    {
        return this.PixelSpaceToUVSpace(new Vector2((float) x, (float) y));
    }

    public void SetAnchor(ANCHOR_METHOD a)
    {
        this.anchor = a;
        this.SetSize(this.width, this.height);
        return;
    }

    public void SetBleedCompensation()
    {
        this.SetBleedCompensation(this.bleedCompensation);
        return;
    }

    public unsafe void SetBleedCompensation(Vector2 xy)
    {
        this.bleedCompensation = xy;
        this.bleedCompensationUV = this.PixelSpaceToUVSpace(this.bleedCompensation);
        this.bleedCompensationUVMax = this.bleedCompensationUV * -2f;
        &this.uvRect.x += &this.bleedCompensationUV.x;
        &this.uvRect.y += &this.bleedCompensationUV.y;
        &this.uvRect.xMax += &this.bleedCompensationUVMax.x;
        &this.uvRect.yMax += &this.bleedCompensationUVMax.y;
        this.UpdateUVs();
        return;
    }

    public void SetBleedCompensation(float x, float y)
    {
        this.SetBleedCompensation(new Vector2(x, y));
        return;
    }

    public void SetCamera()
    {
        this.SetCamera(this.renderCamera);
        return;
    }

    public virtual unsafe void SetCamera(Camera c)
    {
        float num;
        Plane plane;
        if ((c == null) != null)
        {
            goto Label_0017;
        }
        if (this.m_started != null)
        {
            goto Label_0018;
        }
    Label_0017:
        return;
    Label_0018:
        &plane = new Plane(c.transform.forward, c.transform.position);
        if (Application.isPlaying != null)
        {
            goto Label_00FC;
        }
        &this.screenSize.x = c.pixelWidth;
        &this.screenSize.y = c.pixelHeight;
        if (&this.screenSize.x != 0f)
        {
            goto Label_0077;
        }
        return;
    Label_0077:
        this.renderCamera = c;
        if ((this.screenPlacer != null) == null)
        {
            goto Label_00A0;
        }
        this.screenPlacer.SetCamera(this.renderCamera);
    Label_00A0:
        num = &plane.GetDistanceToPoint(base.transform.position);
        this.worldUnitsPerScreenPixel = Vector3.Distance(c.ScreenToWorldPoint(new Vector3(0f, 1f, num)), c.ScreenToWorldPoint(new Vector3(0f, 0f, num)));
        if (this.hideAtStart != null)
        {
            goto Label_00FB;
        }
        this.CalcSize();
    Label_00FB:
        return;
    Label_00FC:
        this.renderCamera = c;
        &this.screenSize.x = c.pixelWidth;
        &this.screenSize.y = c.pixelHeight;
        if ((this.screenPlacer != null) == null)
        {
            goto Label_0147;
        }
        this.screenPlacer.SetCamera(this.renderCamera);
    Label_0147:
        num = &plane.GetDistanceToPoint(base.transform.position);
        this.worldUnitsPerScreenPixel = Vector3.Distance(c.ScreenToWorldPoint(new Vector3(0f, 1f, num)), c.ScreenToWorldPoint(new Vector3(0f, 0f, num)));
        this.CalcSize();
        return;
    }

    public virtual void SetColor(UnityEngine.Color c)
    {
        this.color = c;
        if (this.m_spriteMesh == null)
        {
            goto Label_0023;
        }
        this.m_spriteMesh.UpdateColors(this.color);
    Label_0023:
        return;
    }

    public void SetDrawLayer(int layer)
    {
        if (this.managed != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.drawLayer = layer;
        ((SpriteMesh_Managed) this.m_spriteMesh).drawLayer = layer;
        if ((this.manager != null) == null)
        {
            goto Label_0040;
        }
        this.manager.SortDrawingOrder();
    Label_0040:
        return;
    }

    public unsafe void SetFrameInfo(SPRITE_FRAME fInfo)
    {
        this.frameInfo = fInfo;
        this.uvRect = &fInfo.uvs;
        this.SetBleedCompensation();
        if (this.autoResize != null)
        {
            goto Label_0030;
        }
        if (this.pixelPerfect == null)
        {
            goto Label_0036;
        }
    Label_0030:
        this.CalcSize();
    Label_0036:
        return;
    }

    public void SetMaterial(Material mat)
    {
        if (this.managed != null)
        {
            goto Label_001C;
        }
        if ((base.renderer == null) == null)
        {
            goto Label_001D;
        }
    Label_001C:
        return;
    Label_001D:
        base.renderer.sharedMaterial = mat;
        this.SetPixelToUV(mat.mainTexture);
        this.SetCamera();
        return;
    }

    public void SetOffset(Vector3 o)
    {
        this.offset = o;
        this.SetSize(this.width, this.height);
        return;
    }

    public void SetPixelToUV(Texture tex)
    {
        if ((tex == null) == null)
        {
            goto Label_000D;
        }
        return;
    Label_000D:
        this.SetPixelToUV(tex.width, tex.height);
        return;
    }

    public unsafe void SetPixelToUV(int texWidth, int texHeight)
    {
        Vector2 vector;
        Rect rect;
        Vector2 vector2;
        vector = this.pixelsPerUV;
        &this.pixelsPerUV.x = (float) texWidth;
        &this.pixelsPerUV.y = (float) texHeight;
        rect = &this.frameInfo.uvs;
        if (&rect.width == 0f)
        {
            goto Label_0071;
        }
        if (&rect.height == 0f)
        {
            goto Label_0071;
        }
        if (&vector.x == 0f)
        {
            goto Label_0071;
        }
        if (&vector.y != 0f)
        {
            goto Label_0072;
        }
    Label_0071:
        return;
    Label_0072:
        &vector2 = new Vector2(this.width / (&rect.width * &vector.x), this.height / (&rect.height * &vector.y));
        &this.sizeUnitsPerUV.x = &vector2.x * &this.pixelsPerUV.x;
        &this.sizeUnitsPerUV.y = &vector2.y * &this.pixelsPerUV.y;
        return;
    }

    public void SetPlane(SPRITE_PLANE p)
    {
        this.plane = p;
        this.SetSize(this.width, this.height);
        return;
    }

    public virtual void SetSize(float w, float h)
    {
        SPRITE_PLANE sprite_plane;
        if (this.m_spriteMesh != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.width = w;
        this.height = h;
        this.CalcSizeUnitsPerUV();
        switch (this.plane)
        {
            case 0:
                goto Label_003E;

            case 1:
                goto Label_0055;

            case 2:
                goto Label_006C;
        }
        goto Label_0083;
    Label_003E:
        this.SetSizeXY(this.width, this.height);
        goto Label_0083;
    Label_0055:
        this.SetSizeXZ(this.width, this.height);
        goto Label_0083;
    Label_006C:
        this.SetSizeYZ(this.width, this.height);
    Label_0083:
        if (this.resizedDelegate == null)
        {
            goto Label_00A6;
        }
        this.resizedDelegate(this.width, this.height, this);
    Label_00A6:
        return;
    }

    protected unsafe void SetSizeXY(float w, float h)
    {
        Vector3[] vectorArray;
        this.CalcEdges();
        vectorArray = this.m_spriteMesh.vertices;
        if (this.winding != 1)
        {
            goto Label_0197;
        }
        &(vectorArray[0]).x = &this.offset.x + &this.topLeft.x;
        &(vectorArray[0]).y = &this.offset.y + &this.topLeft.y;
        &(vectorArray[0]).z = &this.offset.z;
        &(vectorArray[1]).x = &this.offset.x + &this.topLeft.x;
        &(vectorArray[1]).y = &this.offset.y + &this.bottomRight.y;
        &(vectorArray[1]).z = &this.offset.z;
        &(vectorArray[2]).x = &this.offset.x + &this.bottomRight.x;
        &(vectorArray[2]).y = &this.offset.y + &this.bottomRight.y;
        &(vectorArray[2]).z = &this.offset.z;
        &(vectorArray[3]).x = &this.offset.x + &this.bottomRight.x;
        &(vectorArray[3]).y = &this.offset.y + &this.topLeft.y;
        &(vectorArray[3]).z = &this.offset.z;
        goto Label_030B;
    Label_0197:
        &(vectorArray[0]).x = &this.offset.x + &this.topLeft.x;
        &(vectorArray[0]).y = &this.offset.y + &this.topLeft.y;
        &(vectorArray[0]).z = &this.offset.z;
        &(vectorArray[1]).x = &this.offset.x + &this.topLeft.x;
        &(vectorArray[1]).y = &this.offset.y + &this.bottomRight.y;
        &(vectorArray[1]).z = &this.offset.z;
        &(vectorArray[2]).x = &this.offset.x + &this.bottomRight.x;
        &(vectorArray[2]).y = &this.offset.y + &this.bottomRight.y;
        &(vectorArray[2]).z = &this.offset.z;
        &(vectorArray[3]).x = &this.offset.x + &this.bottomRight.x;
        &(vectorArray[3]).y = &this.offset.y + &this.topLeft.y;
        &(vectorArray[3]).z = &this.offset.z;
    Label_030B:
        this.m_spriteMesh.UpdateVerts();
        return;
    }

    protected unsafe void SetSizeXZ(float w, float h)
    {
        Vector3[] vectorArray;
        this.CalcEdges();
        vectorArray = this.m_spriteMesh.vertices;
        &(vectorArray[0]).x = &this.offset.x + &this.topLeft.x;
        &(vectorArray[0]).y = &this.offset.y;
        &(vectorArray[0]).z = &this.offset.z + &this.topLeft.y;
        &(vectorArray[1]).x = &this.offset.x + &this.topLeft.x;
        &(vectorArray[1]).y = &this.offset.y;
        &(vectorArray[1]).z = &this.offset.z + &this.bottomRight.y;
        &(vectorArray[2]).x = &this.offset.x + &this.bottomRight.x;
        &(vectorArray[2]).y = &this.offset.y;
        &(vectorArray[2]).z = &this.offset.z + &this.bottomRight.y;
        &(vectorArray[3]).x = &this.offset.x + &this.bottomRight.x;
        &(vectorArray[3]).y = &this.offset.y;
        &(vectorArray[3]).z = &this.offset.z + &this.topLeft.y;
        this.m_spriteMesh.UpdateVerts();
        return;
    }

    protected unsafe void SetSizeYZ(float w, float h)
    {
        Vector3[] vectorArray;
        this.CalcEdges();
        vectorArray = this.m_spriteMesh.vertices;
        &(vectorArray[0]).x = &this.offset.x;
        &(vectorArray[0]).y = &this.offset.y + &this.topLeft.y;
        &(vectorArray[0]).z = &this.offset.z + &this.topLeft.x;
        &(vectorArray[1]).x = &this.offset.x;
        &(vectorArray[1]).y = &this.offset.y + &this.bottomRight.y;
        &(vectorArray[1]).z = &this.offset.z + &this.topLeft.x;
        &(vectorArray[2]).x = &this.offset.x;
        &(vectorArray[2]).y = &this.offset.y + &this.bottomRight.y;
        &(vectorArray[2]).z = &this.offset.z + &this.bottomRight.x;
        &(vectorArray[3]).x = &this.offset.x;
        &(vectorArray[3]).y = &this.offset.y + &this.topLeft.y;
        &(vectorArray[3]).z = &this.offset.z + &this.bottomRight.x;
        this.m_spriteMesh.UpdateVerts();
        return;
    }

    public abstract void SetState(int index);
    public void SetTexture(Texture2D tex)
    {
        if (this.managed != null)
        {
            goto Label_001C;
        }
        if ((base.renderer == null) == null)
        {
            goto Label_001D;
        }
    Label_001C:
        return;
    Label_001D:
        base.renderer.material.mainTexture = tex;
        this.SetPixelToUV(tex);
        this.SetCamera();
        return;
    }

    public unsafe void SetUVs(Rect uv)
    {
        &this.frameInfo.uvs = uv;
        this.uvRect = uv;
        this.SetBleedCompensation();
        if (Application.isPlaying != null)
        {
            goto Label_0029;
        }
        this.CalcSizeUnitsPerUV();
    Label_0029:
        if (this.autoResize != null)
        {
            goto Label_003F;
        }
        if (this.pixelPerfect == null)
        {
            goto Label_0045;
        }
    Label_003F:
        this.CalcSize();
    Label_0045:
        return;
    }

    public unsafe void SetUVsFromPixelCoords(Rect pxCoords)
    {
        this.tempUV = this.PixelCoordToUVCoord((int) &pxCoords.x, (int) &pxCoords.yMax);
        &this.uvRect.x = &this.tempUV.x;
        &this.uvRect.y = &this.tempUV.y;
        this.tempUV = this.PixelCoordToUVCoord((int) &pxCoords.xMax, (int) &pxCoords.y);
        &this.uvRect.xMax = &this.tempUV.x;
        &this.uvRect.yMax = &this.tempUV.y;
        &this.frameInfo.uvs = this.uvRect;
        this.SetBleedCompensation();
        if (this.autoResize != null)
        {
            goto Label_00BD;
        }
        if (this.pixelPerfect == null)
        {
            goto Label_00C3;
        }
    Label_00BD:
        this.CalcSize();
    Label_00C3:
        return;
    }

    public void SetWindingOrder(WINDING_ORDER order)
    {
        this.winding = order;
        if (this.managed != null)
        {
            goto Label_002E;
        }
        if (this.m_spriteMesh == null)
        {
            goto Label_002E;
        }
        ((SpriteMesh) this.m_spriteMesh).SetWindingOrder(order);
    Label_002E:
        return;
    }

    public virtual void Start()
    {
        this.m_started = 1;
        if (this.managed != null)
        {
            goto Label_003E;
        }
        if (Application.isPlaying == null)
        {
            goto Label_004F;
        }
        if (this.isClone != null)
        {
            goto Label_0032;
        }
        UnityEngine.Object.Destroy(this.oldMesh);
    Label_0032:
        this.oldMesh = null;
        goto Label_004F;
    Label_003E:
        if (this.m_spriteMesh == null)
        {
            goto Label_004F;
        }
        this.Init();
    Label_004F:
        if (this.persistent == null)
        {
            goto Label_0080;
        }
        UnityEngine.Object.DontDestroyOnLoad(this);
        if ((this.m_spriteMesh as SpriteMesh) == null)
        {
            goto Label_0080;
        }
        ((SpriteMesh) this.m_spriteMesh).SetPersistent();
    Label_0080:
        if (this.m_spriteMesh != null)
        {
            goto Label_009C;
        }
        if (this.managed != null)
        {
            goto Label_009C;
        }
        this.AddMesh();
    Label_009C:
        this.CalcSizeUnitsPerUV();
        if (this.m_spriteMesh == null)
        {
            goto Label_00D4;
        }
        if ((this.m_spriteMesh.texture != null) == null)
        {
            goto Label_00D4;
        }
        this.SetPixelToUV(this.m_spriteMesh.texture);
    Label_00D4:
        if ((this.renderCamera == null) == null)
        {
            goto Label_00F0;
        }
        this.renderCamera = Camera.mainCamera;
    Label_00F0:
        this.SetCamera(this.renderCamera);
        if (this.clipped == null)
        {
            goto Label_010D;
        }
        this.UpdateUVs();
    Label_010D:
        if (this.hideAtStart == null)
        {
            goto Label_011F;
        }
        this.Hide(1);
    Label_011F:
        return;
    }

    public void TransformBillboarded(Transform t)
    {
    }

    public virtual unsafe void TruncateBottom(float pct)
    {
        &this.tlTruncate.y = 1f;
        &this.brTruncate.y = Mathf.Clamp01(pct);
        if (&this.brTruncate.y < 1f)
        {
            goto Label_0060;
        }
        if (&this.tlTruncate.x < 1f)
        {
            goto Label_0060;
        }
        if (&this.brTruncate.x >= 1f)
        {
            goto Label_006C;
        }
    Label_0060:
        this.truncated = 1;
        goto Label_0073;
    Label_006C:
        this.Untruncate();
        return;
    Label_0073:
        this.UpdateUVs();
        this.CalcSize();
        return;
    }

    public virtual unsafe void TruncateLeft(float pct)
    {
        &this.tlTruncate.x = Mathf.Clamp01(pct);
        &this.brTruncate.x = 1f;
        if (&this.tlTruncate.x < 1f)
        {
            goto Label_0060;
        }
        if (&this.tlTruncate.y < 1f)
        {
            goto Label_0060;
        }
        if (&this.brTruncate.y >= 1f)
        {
            goto Label_006C;
        }
    Label_0060:
        this.truncated = 1;
        goto Label_0073;
    Label_006C:
        this.Untruncate();
        return;
    Label_0073:
        this.UpdateUVs();
        this.CalcSize();
        return;
    }

    public virtual unsafe void TruncateRight(float pct)
    {
        &this.tlTruncate.x = 1f;
        &this.brTruncate.x = Mathf.Clamp01(pct);
        if (&this.brTruncate.x < 1f)
        {
            goto Label_0060;
        }
        if (&this.tlTruncate.y < 1f)
        {
            goto Label_0060;
        }
        if (&this.brTruncate.y >= 1f)
        {
            goto Label_006C;
        }
    Label_0060:
        this.truncated = 1;
        goto Label_0073;
    Label_006C:
        this.Untruncate();
        return;
    Label_0073:
        this.UpdateUVs();
        this.CalcSize();
        return;
    }

    public virtual unsafe void TruncateTop(float pct)
    {
        &this.tlTruncate.y = Mathf.Clamp01(pct);
        &this.brTruncate.y = 1f;
        if (&this.tlTruncate.y < 1f)
        {
            goto Label_0060;
        }
        if (&this.tlTruncate.x < 1f)
        {
            goto Label_0060;
        }
        if (&this.brTruncate.x >= 1f)
        {
            goto Label_006C;
        }
    Label_0060:
        this.truncated = 1;
        goto Label_0073;
    Label_006C:
        this.Untruncate();
        return;
    Label_0073:
        this.UpdateUVs();
        this.CalcSize();
        return;
    }

    public virtual unsafe void Unclip()
    {
        if (this.ignoreClipping == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.leftClipPct = 1f;
        this.rightClipPct = 1f;
        this.topClipPct = 1f;
        this.bottomClipPct = 1f;
        this.clipped = 0;
        this.uvRect = &this.frameInfo.uvs;
        this.SetBleedCompensation();
        this.CalcSize();
        return;
    }

    public virtual unsafe void Untruncate()
    {
        &this.tlTruncate.x = 1f;
        &this.tlTruncate.y = 1f;
        &this.brTruncate.x = 1f;
        &this.brTruncate.y = 1f;
        this.truncated = 0;
        this.uvRect = &this.frameInfo.uvs;
        this.SetBleedCompensation();
        this.CalcSize();
        return;
    }

    public void UpdateCamera()
    {
        this.SetCamera(this.renderCamera);
        return;
    }

    public virtual unsafe void UpdateUVs()
    {
        Rect rect;
        Vector2[] vectorArray;
        this.scaleFactor = &this.frameInfo.scaleFactor;
        this.topLeftOffset = &this.frameInfo.topLeftOffset;
        this.bottomRightOffset = &this.frameInfo.bottomRightOffset;
        if (this.truncated == null)
        {
            goto Label_016F;
        }
        &this.uvRect.x = (&&this.frameInfo.uvs.xMax + &this.bleedCompensationUV.x) - ((&&this.frameInfo.uvs.width * &this.tlTruncate.x) * this.leftClipPct);
        &this.uvRect.y = (&&this.frameInfo.uvs.yMax + &this.bleedCompensationUV.y) - ((&&this.frameInfo.uvs.height * &this.brTruncate.y) * this.bottomClipPct);
        &this.uvRect.xMax = (&&this.frameInfo.uvs.x + &this.bleedCompensationUVMax.x) + ((&&this.frameInfo.uvs.width * &this.brTruncate.x) * this.rightClipPct);
        &this.uvRect.yMax = (&&this.frameInfo.uvs.y + &this.bleedCompensationUVMax.y) + ((&&this.frameInfo.uvs.height * &this.tlTruncate.y) * this.topClipPct);
        goto Label_0280;
    Label_016F:
        if (this.clipped == null)
        {
            goto Label_0280;
        }
        rect = Rect.MinMaxRect(&&this.frameInfo.uvs.x + &this.bleedCompensationUV.x, &&this.frameInfo.uvs.y + &this.bleedCompensationUV.y, &&this.frameInfo.uvs.xMax + &this.bleedCompensationUVMax.x, &&this.frameInfo.uvs.yMax + &this.bleedCompensationUVMax.y);
        &this.uvRect.x = Mathf.Lerp(&rect.xMax, &rect.x, this.leftClipPct);
        &this.uvRect.y = Mathf.Lerp(&rect.yMax, &rect.y, this.bottomClipPct);
        &this.uvRect.xMax = Mathf.Lerp(&rect.x, &rect.xMax, this.rightClipPct);
        &this.uvRect.yMax = Mathf.Lerp(&rect.y, &rect.yMax, this.topClipPct);
    Label_0280:
        if (this.m_spriteMesh != null)
        {
            goto Label_028C;
        }
        return;
    Label_028C:
        vectorArray = this.m_spriteMesh.uvs;
        &(vectorArray[0]).x = &this.uvRect.x;
        &(vectorArray[0]).y = &this.uvRect.yMax;
        &(vectorArray[1]).x = &this.uvRect.x;
        &(vectorArray[1]).y = &this.uvRect.y;
        &(vectorArray[2]).x = &this.uvRect.xMax;
        &(vectorArray[2]).y = &this.uvRect.y;
        &(vectorArray[3]).x = &this.uvRect.xMax;
        &(vectorArray[3]).y = &this.uvRect.yMax;
        this.m_spriteMesh.UpdateUVs();
        return;
    }

    public bool AddedToManager
    {
        get
        {
            return this.addedToManager;
        }
        set
        {
            this.addedToManager = value;
            return;
        }
    }

    public ANCHOR_METHOD Anchor
    {
        get
        {
            return this.anchor;
        }
        set
        {
            this.SetAnchor(value);
            return;
        }
    }

    public Vector3 BottomRight
    {
        get
        {
            if (this.m_spriteMesh == null)
            {
                goto Label_0022;
            }
            return *(&(this.m_spriteMesh.vertices[2]));
        Label_0022:
            return Vector3.zero;
        }
    }

    public virtual bool Clipped
    {
        get
        {
            return this.clipped;
        }
        set
        {
            if (this.ignoreClipping == null)
            {
                goto Label_000C;
            }
            return;
        Label_000C:
            if (value == null)
            {
                goto Label_002F;
            }
            if (this.clipped != null)
            {
                goto Label_002F;
            }
            this.clipped = 1;
            this.CalcSize();
            goto Label_0040;
        Label_002F:
            if (this.clipped == null)
            {
                goto Label_0040;
            }
            this.Unclip();
        Label_0040:
            return;
        }
    }

    public virtual Rect3D ClippingRect
    {
        get
        {
            return this.clippingRect;
        }
        set
        {
            Rect3D rectd;
            if (this.ignoreClipping == null)
            {
                goto Label_000C;
            }
            return;
        Label_000C:
            this.clippingRect = value;
            this.localClipRect = &Rect3D.MultFast(this.clippingRect, base.transform.worldToLocalMatrix).GetRect();
            this.clipped = 1;
            this.CalcSize();
            this.UpdateUVs();
            return;
        }
    }

    public UnityEngine.Color Color
    {
        get
        {
            return this.color;
        }
        set
        {
            this.SetColor(value);
            return;
        }
    }

    public Vector2 ImageSize
    {
        get
        {
            return new Vector2(&this.uvRect.width * &this.pixelsPerUV.x, &this.uvRect.height * &this.pixelsPerUV.y);
        }
    }

    public bool Managed
    {
        get
        {
            return this.managed;
        }
        set
        {
            if (value == null)
            {
                goto Label_0023;
            }
            if (this.managed != null)
            {
                goto Label_0017;
            }
            this.DestroyMesh();
        Label_0017:
            this.managed = value;
            goto Label_0085;
        Label_0023:
            if (this.managed == null)
            {
                goto Label_0052;
            }
            if ((this.manager != null) == null)
            {
                goto Label_004B;
            }
            this.manager.RemoveSprite(this);
        Label_004B:
            this.manager = null;
        Label_0052:
            this.managed = value;
            if (this.m_spriteMesh != null)
            {
                goto Label_006F;
            }
            this.AddMesh();
            goto Label_0085;
        Label_006F:
            if ((this.m_spriteMesh as SpriteMesh) != null)
            {
                goto Label_0085;
            }
            this.AddMesh();
        Label_0085:
            return;
        }
    }

    public ISpriteAnimatable next
    {
        get
        {
            return this.m_next;
        }
        set
        {
            this.m_next = value;
            return;
        }
    }

    public Vector2 PixelSize
    {
        get
        {
            return new Vector2(this.width / this.worldUnitsPerScreenPixel, this.height / this.worldUnitsPerScreenPixel);
        }
        set
        {
            this.SetSize(&value.x * this.worldUnitsPerScreenPixel, &value.y * this.worldUnitsPerScreenPixel);
            return;
        }
    }

    public ISpriteAnimatable prev
    {
        get
        {
            return this.m_prev;
        }
        set
        {
            this.m_prev = value;
            return;
        }
    }

    public virtual Camera RenderCamera
    {
        get
        {
            return this.renderCamera;
        }
        set
        {
            this.renderCamera = value;
            this.SetCamera(value);
            return;
        }
    }

    public ISpriteMesh spriteMesh
    {
        get
        {
            return this.m_spriteMesh;
        }
        set
        {
            this.m_spriteMesh = value;
            if (this.m_spriteMesh == null)
            {
                goto Label_0039;
            }
            if ((this.m_spriteMesh.sprite != this) == null)
            {
                goto Label_003A;
            }
            this.m_spriteMesh.sprite = this;
            goto Label_003A;
        Label_0039:
            return;
        Label_003A:
            if (this.managed == null)
            {
                goto Label_005B;
            }
            this.manager = ((SpriteMesh_Managed) this.m_spriteMesh).manager;
        Label_005B:
            return;
        }
    }

    public bool Started
    {
        get
        {
            return this.m_started;
        }
    }

    public Vector3 TopLeft
    {
        get
        {
            if (this.m_spriteMesh == null)
            {
                goto Label_0022;
            }
            return *(&(this.m_spriteMesh.vertices[0]));
        Label_0022:
            return Vector3.zero;
        }
    }

    public Vector3 UnclippedBottomRight
    {
        get
        {
            if (this.m_started != null)
            {
                goto Label_0011;
            }
            this.Start();
        Label_0011:
            return this.unclippedBottomRight;
        }
    }

    public Vector3 UnclippedTopLeft
    {
        get
        {
            if (this.m_started != null)
            {
                goto Label_0011;
            }
            this.Start();
        Label_0011:
            return this.unclippedTopLeft;
        }
    }

    public enum ANCHOR_METHOD
    {
        UPPER_LEFT,
        UPPER_CENTER,
        UPPER_RIGHT,
        MIDDLE_LEFT,
        MIDDLE_CENTER,
        MIDDLE_RIGHT,
        BOTTOM_LEFT,
        BOTTOM_CENTER,
        BOTTOM_RIGHT,
        TEXTURE_OFFSET
    }

    public enum SPRITE_PLANE
    {
        XY,
        XZ,
        YZ
    }

    public delegate void SpriteResizedDelegate(float newWidth, float newHeight, SpriteRoot sprite);

    public enum WINDING_ORDER
    {
        CCW,
        CW
    }
}

