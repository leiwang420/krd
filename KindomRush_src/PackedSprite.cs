using System;
using System.Collections.Generic;
using UnityEngine;

public class PackedSprite : AutoSpriteBase
{
    [HideInInspector]
    public CSpriteFrame _ser_stat_frame_info;
    [HideInInspector]
    public SPRITE_FRAME staticFrameInfo;
    [HideInInspector]
    public string staticTexGUID;
    [HideInInspector]
    public string staticTexPath;
    public TextureAnim[] textureAnimations;

    public PackedSprite()
    {
        this.staticTexPath = string.Empty;
        this.staticTexGUID = string.Empty;
        this._ser_stat_frame_info = new CSpriteFrame();
        base..ctor();
        return;
    }

    public void AddAnimation(UVAnimation anim)
    {
        UVAnimation[] animationArray;
        animationArray = base.animations;
        base.animations = new UVAnimation[((int) animationArray.Length) + 1];
        animationArray.CopyTo(base.animations, 0);
        base.animations[((int) base.animations.Length) - 1] = anim;
        return;
    }

    public override void Aggregate(PathFromGUIDDelegate guid2Path, LoadAssetDelegate load, GUIDFromPathDelegate path2Guid)
    {
        List<Texture2D> list;
        List<CSpriteFrame> list2;
        int num;
        int num2;
        string str;
        int num3;
        int num4;
        list = new List<Texture2D>();
        list2 = new List<CSpriteFrame>();
        num = 0;
        goto Label_01EE;
    Label_0013:
        this.textureAnimations[num].Allocate();
        if (((int) this.textureAnimations[num].frameGUIDs.Length) < ((int) this.textureAnimations[num].framePaths.Length))
        {
            goto Label_00C4;
        }
        num2 = 0;
        goto Label_0097;
    Label_004A:
        str = guid2Path(this.textureAnimations[num].frameGUIDs[num2]);
        list.Add((Texture2D) load(str, typeof(Texture2D)));
        list2.Add(this.textureAnimations[num].spriteFrames[num2]);
        num2 += 1;
    Label_0097:
        if (num2 < ((int) this.textureAnimations[num].frameGUIDs.Length))
        {
            goto Label_004A;
        }
        this.textureAnimations[num].framePaths = new string[0];
        goto Label_01EA;
    Label_00C4:
        this.textureAnimations[num].frameGUIDs = new string[(int) this.textureAnimations[num].framePaths.Length];
        this.textureAnimations[num].spriteFrames = new CSpriteFrame[(int) this.textureAnimations[num].framePaths.Length];
        num3 = 0;
        goto Label_0129;
    Label_010E:
        this.textureAnimations[num].spriteFrames[num3] = new CSpriteFrame();
        num3 += 1;
    Label_0129:
        if (num3 < ((int) this.textureAnimations[num].spriteFrames.Length))
        {
            goto Label_010E;
        }
        num4 = 0;
        goto Label_01D4;
    Label_0147:
        if (this.textureAnimations[num].framePaths[num4].Length >= 1)
        {
            goto Label_0167;
        }
        goto Label_01CE;
    Label_0167:
        this.textureAnimations[num].frameGUIDs[num4] = path2Guid(this.textureAnimations[num].framePaths[num4]);
        list.Add((Texture2D) load(this.textureAnimations[num].framePaths[num4], typeof(Texture2D)));
        list2.Add(this.textureAnimations[num].spriteFrames[num4]);
    Label_01CE:
        num4 += 1;
    Label_01D4:
        if (num4 < ((int) this.textureAnimations[num].framePaths.Length))
        {
            goto Label_0147;
        }
    Label_01EA:
        num += 1;
    Label_01EE:
        if (num < ((int) this.textureAnimations.Length))
        {
            goto Label_0013;
        }
        if (this.staticTexGUID.Length <= 1)
        {
            goto Label_0224;
        }
        this.staticTexPath = guid2Path(this.staticTexGUID);
        goto Label_0236;
    Label_0224:
        this.staticTexGUID = path2Guid(this.staticTexPath);
    Label_0236:
        list.Add((Texture2D) load(this.staticTexPath, typeof(Texture2D)));
        list2.Add(this._ser_stat_frame_info);
        base.sourceTextures = list.ToArray();
        base.spriteFrames = list2.ToArray();
        return;
    }

    protected override void Awake()
    {
        if (this.textureAnimations != null)
        {
            goto Label_0017;
        }
        this.textureAnimations = new TextureAnim[0];
    Label_0017:
        this.staticFrameInfo = this._ser_stat_frame_info.ToStruct();
        base.Awake();
        this.Init();
        return;
    }

    public override unsafe void Copy(SpriteRoot s)
    {
        PackedSprite sprite;
        base.Copy(s);
        if ((s as PackedSprite) != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        sprite = (PackedSprite) s;
        if (sprite.m_started != null)
        {
            goto Label_003B;
        }
        this.staticFrameInfo = sprite._ser_stat_frame_info.ToStruct();
        goto Label_0047;
    Label_003B:
        this.staticFrameInfo = sprite.staticFrameInfo;
    Label_0047:
        if (base.curAnim == null)
        {
            goto Label_008A;
        }
        if (base.curAnim.index != -1)
        {
            goto Label_0074;
        }
        base.PlayAnim(base.curAnim);
        goto Label_0085;
    Label_0074:
        this.SetState(base.curAnim.index);
    Label_0085:
        goto Label_00DA;
    Label_008A:
        base.frameInfo = this.staticFrameInfo;
        base.uvRect = &this.frameInfo.uvs;
        if (base.autoResize != null)
        {
            goto Label_00BD;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_00C8;
        }
    Label_00BD:
        base.CalcSize();
        goto Label_00DA;
    Label_00C8:
        this.SetSize(s.width, s.height);
    Label_00DA:
        base.SetBleedCompensation();
        return;
    }

    public static PackedSprite Create(string name, Vector3 pos)
    {
        GameObject obj2;
        obj2 = new GameObject(name);
        obj2.transform.position = pos;
        return (PackedSprite) obj2.AddComponent(typeof(PackedSprite));
    }

    public static PackedSprite Create(string name, Vector3 pos, Quaternion rotation)
    {
        GameObject obj2;
        obj2 = new GameObject(name);
        obj2.transform.position = pos;
        obj2.transform.rotation = rotation;
        return (PackedSprite) obj2.AddComponent(typeof(PackedSprite));
    }

    public override unsafe Vector2 GetDefaultPixelSize(PathFromGUIDDelegate guid2Path, AssetLoaderDelegate loader)
    {
        Texture2D textured;
        Vector2 vector;
        if ((this.staticTexGUID == string.Empty) == null)
        {
            goto Label_001B;
        }
        return Vector2.zero;
    Label_001B:
        textured = (Texture2D) loader(guid2Path(this.staticTexGUID), typeof(Texture2D));
        &vector = new Vector2(((float) textured.width) * (1f / (&this._ser_stat_frame_info.scaleFactor.x * 2f)), ((float) textured.height) * (1f / (&this._ser_stat_frame_info.scaleFactor.y * 2f)));
        return vector;
    }

    protected override void Init()
    {
        base.Init();
        return;
    }

    public override unsafe void InitUVs()
    {
        base.frameInfo = this.staticFrameInfo;
        base.uvRect = &this.staticFrameInfo.uvs;
        return;
    }

    public override void Start()
    {
        if (base.m_started == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.Start();
        if (base.playAnimOnStart == null)
        {
            goto Label_0046;
        }
        if (base.defaultAnim >= ((int) base.animations.Length))
        {
            goto Label_0046;
        }
        if (Application.isPlaying == null)
        {
            goto Label_0046;
        }
        this.PlayAnim(base.defaultAnim);
    Label_0046:
        return;
    }

    public override CSpriteFrame DefaultFrame
    {
        get
        {
            return this._ser_stat_frame_info;
        }
    }

    public override TextureAnim DefaultState
    {
        get
        {
            if (this.textureAnimations == null)
            {
                goto Label_0039;
            }
            if (((int) this.textureAnimations.Length) == null)
            {
                goto Label_0039;
            }
            if (base.defaultAnim >= ((int) this.textureAnimations.Length))
            {
                goto Label_0039;
            }
            return this.textureAnimations[base.defaultAnim];
        Label_0039:
            return null;
        }
    }

    public override TextureAnim[] States
    {
        get
        {
            if (this.textureAnimations != null)
            {
                goto Label_0017;
            }
            this.textureAnimations = new TextureAnim[0];
        Label_0017:
            return this.textureAnimations;
        }
        set
        {
            this.textureAnimations = value;
            return;
        }
    }

    public override bool SupportsArbitraryAnimations
    {
        get
        {
            return 1;
        }
    }
}

