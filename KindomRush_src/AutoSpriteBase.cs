using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class AutoSpriteBase : SpriteBase, ISpriteAggregator, ISpritePackable
{
    [HideInInspector]
    public UVAnimation[] animations;
    protected UVAnimation curAnim;
    public bool doNotTrimImages;
    protected Texture2D[] sourceTextures;
    protected CSpriteFrame[] spriteFrames;

    protected AutoSpriteBase()
    {
        base..ctor();
        return;
    }

    protected override void AddToAnimatedList()
    {
        if (base.animating != null)
        {
            goto Label_0025;
        }
        if (Application.isPlaying == null)
        {
            goto Label_0025;
        }
        if (base.gameObject.activeInHierarchy != null)
        {
            goto Label_0026;
        }
    Label_0025:
        return;
    Label_0026:
        base.animating = 1;
        base.currentlyAnimating = 1;
        SpriteAnimationPump.Add(this);
        return;
    }

    public virtual void Aggregate(PathFromGUIDDelegate guid2Path, LoadAssetDelegate load, GUIDFromPathDelegate path2Guid)
    {
        ArrayList list;
        ArrayList list2;
        int num;
        int num2;
        string str;
        int num3;
        int num4;
        list = new ArrayList();
        list2 = new ArrayList();
        num = 0;
        goto Label_01C8;
    Label_0013:
        this.States[num].Allocate();
        if (((int) this.States[num].frameGUIDs.Length) < ((int) this.States[num].framePaths.Length))
        {
            goto Label_00C1;
        }
        num2 = 0;
        goto Label_0094;
    Label_004A:
        str = guid2Path(this.States[num].frameGUIDs[num2]);
        list.Add(load(str, typeof(Texture2D)));
        list2.Add(this.States[num].spriteFrames[num2]);
        num2 += 1;
    Label_0094:
        if (num2 < ((int) this.States[num].frameGUIDs.Length))
        {
            goto Label_004A;
        }
        this.States[num].framePaths = new string[0];
        goto Label_01C4;
    Label_00C1:
        this.States[num].frameGUIDs = new string[(int) this.States[num].framePaths.Length];
        this.States[num].spriteFrames = new CSpriteFrame[(int) this.States[num].framePaths.Length];
        num3 = 0;
        goto Label_0126;
    Label_010B:
        this.States[num].spriteFrames[num3] = new CSpriteFrame();
        num3 += 1;
    Label_0126:
        if (num3 < ((int) this.States[num].spriteFrames.Length))
        {
            goto Label_010B;
        }
        num4 = 0;
        goto Label_01AE;
    Label_0144:
        this.States[num].frameGUIDs[num4] = path2Guid(this.States[num].framePaths[num4]);
        list.Add(load(this.States[num].framePaths[num4], typeof(Texture2D)));
        list2.Add(this.States[num].spriteFrames[num4]);
        num4 += 1;
    Label_01AE:
        if (num4 < ((int) this.States[num].framePaths.Length))
        {
            goto Label_0144;
        }
    Label_01C4:
        num += 1;
    Label_01C8:
        if (num < ((int) this.States.Length))
        {
            goto Label_0013;
        }
        this.sourceTextures = (Texture2D[]) list.ToArray(typeof(Texture2D));
        this.spriteFrames = (CSpriteFrame[]) list2.ToArray(typeof(CSpriteFrame));
        return;
    }

    protected override void Awake()
    {
        int num;
        base.Awake();
        this.animations = new UVAnimation[(int) this.States.Length];
        num = 0;
        goto Label_0047;
    Label_0020:
        this.animations[num] = new UVAnimation();
        this.animations[num].SetAnim(this.States[num], num);
        num += 1;
    Label_0047:
        if (num < ((int) this.States.Length))
        {
            goto Label_0020;
        }
        return;
    }

    protected void CallAnimCompleteDelegate()
    {
        if (base.animCompleteDelegate == null)
        {
            goto Label_0017;
        }
        base.animCompleteDelegate(this);
    Label_0017:
        return;
    }

    public override void Clear()
    {
        base.Clear();
        if (this.curAnim == null)
        {
            goto Label_001E;
        }
        base.PauseAnim();
        this.curAnim = null;
    Label_001E:
        return;
    }

    public override void Copy(SpriteRoot s)
    {
        AutoSpriteBase base2;
        int num;
        int num2;
        base.Copy(s);
        if ((s as AutoSpriteBase) != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        base2 = (AutoSpriteBase) s;
        if (base2.spriteMesh == null)
        {
            goto Label_0079;
        }
        if (((int) base2.animations.Length) <= 0)
        {
            goto Label_00D3;
        }
        this.animations = new UVAnimation[(int) base2.animations.Length];
        num = 0;
        goto Label_0066;
    Label_004D:
        this.animations[num] = base2.animations[num].Clone();
        num += 1;
    Label_0066:
        if (num < ((int) this.animations.Length))
        {
            goto Label_004D;
        }
        goto Label_00D3;
    Label_0079:
        if (this.States == null)
        {
            goto Label_00D3;
        }
        this.animations = new UVAnimation[(int) base2.States.Length];
        num2 = 0;
        goto Label_00C5;
    Label_009E:
        this.animations[num2] = new UVAnimation();
        this.animations[num2].SetAnim(base2.States[num2], num2);
        num2 += 1;
    Label_00C5:
        if (num2 < ((int) base2.States.Length))
        {
            goto Label_009E;
        }
    Label_00D3:
        return;
    }

    public virtual void CopyAll(SpriteRoot s)
    {
        AutoSpriteBase base2;
        int num;
        int num2;
        base.Copy(s);
        if ((s as AutoSpriteBase) != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        base2 = (AutoSpriteBase) s;
        this.States = new TextureAnim[(int) base2.States.Length];
        num = 0;
        goto Label_005A;
    Label_0034:
        this.States[num] = new TextureAnim();
        this.States[num].Copy(base2.States[num]);
        num += 1;
    Label_005A:
        if (num < ((int) this.States.Length))
        {
            goto Label_0034;
        }
        this.animations = new UVAnimation[(int) this.States.Length];
        num2 = 0;
        goto Label_00A9;
    Label_0082:
        this.animations[num2] = new UVAnimation();
        this.animations[num2].SetAnim(this.States[num2], num2);
        num2 += 1;
    Label_00A9:
        if (num2 < ((int) this.States.Length))
        {
            goto Label_0082;
        }
        this.doNotTrimImages = base2.doNotTrimImages;
        return;
    }

    public void DoAnim(int index)
    {
        if (this.curAnim != null)
        {
            goto Label_0017;
        }
        this.PlayAnim(index);
        goto Label_003A;
    Label_0017:
        if (this.curAnim.index != index)
        {
            goto Label_0033;
        }
        if (base.animating != null)
        {
            goto Label_003A;
        }
    Label_0033:
        this.PlayAnim(index);
    Label_003A:
        return;
    }

    public void DoAnim(string name)
    {
        if (this.curAnim != null)
        {
            goto Label_0017;
        }
        this.PlayAnim(name);
        goto Label_003F;
    Label_0017:
        if ((this.curAnim.name != name) != null)
        {
            goto Label_0038;
        }
        if (base.animating != null)
        {
            goto Label_003F;
        }
    Label_0038:
        this.PlayAnim(name);
    Label_003F:
        return;
    }

    public void DoAnim(UVAnimation anim)
    {
        if (this.curAnim != anim)
        {
            goto Label_0017;
        }
        if (base.animating != null)
        {
            goto Label_001E;
        }
    Label_0017:
        this.PlayAnim(anim);
    Label_001E:
        return;
    }

    public UVAnimation GetAnim(string name)
    {
        int num;
        num = 0;
        goto Label_002C;
    Label_0007:
        if ((this.animations[num].name == name) == null)
        {
            goto Label_0028;
        }
        return this.animations[num];
    Label_0028:
        num += 1;
    Label_002C:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0007;
        }
        return null;
    }

    public UVAnimation GetCurAnim()
    {
        return this.curAnim;
    }

    public override unsafe Vector2 GetDefaultPixelSize(PathFromGUIDDelegate guid2Path, AssetLoaderDelegate loader)
    {
        TextureAnim anim;
        CSpriteFrame frame;
        Vector2 vector;
        Texture2D textured;
        anim = this.DefaultState;
        frame = this.DefaultFrame;
        if (anim != null)
        {
            goto Label_001A;
        }
        return Vector2.zero;
    Label_001A:
        if (anim.frameGUIDs != null)
        {
            goto Label_002B;
        }
        return Vector2.zero;
    Label_002B:
        if (((int) anim.frameGUIDs.Length) != null)
        {
            goto Label_003E;
        }
        return Vector2.zero;
    Label_003E:
        if (frame != null)
        {
            goto Label_0064;
        }
        Debug.LogWarning("Sprite \"" + base.name + "\" does not seem to have been built to an atlas yet.");
        return Vector2.zero;
    Label_0064:
        vector = Vector2.zero;
        textured = (Texture2D) loader(guid2Path(anim.frameGUIDs[0]), typeof(Texture2D));
        if ((textured == null) == null)
        {
            goto Label_00F2;
        }
        if (base.spriteMesh == null)
        {
            goto Label_0137;
        }
        textured = (Texture2D) base.spriteMesh.material.GetTexture("_MainTex");
        &vector = new Vector2(&frame.uvs.width * ((float) textured.width), &frame.uvs.height * ((float) textured.height));
        goto Label_0137;
    Label_00F2:
        &vector = new Vector2(((float) textured.width) * (1f / (&frame.scaleFactor.x * 2f)), ((float) textured.height) * (1f / (&frame.scaleFactor.y * 2f)));
    Label_0137:
        return vector;
    }

    public virtual Material GetPackedMaterial(out string errString)
    {
        *(errString) = "Sprite \"" + base.name + "\" has not been assigned a material, and can therefore not be included in the atlas build.";
        if (base.spriteMesh != null)
        {
            goto Label_0074;
        }
        if (base.managed == null)
        {
            goto Label_0068;
        }
        if ((base.manager != null) == null)
        {
            goto Label_004F;
        }
        return base.manager.renderer.sharedMaterial;
    Label_004F:
        *(errString) = "Sprite \"" + base.name + "\" is not associated with a SpriteManager, and can therefore not be included in the atlas build.";
        return null;
    Label_0068:
        return base.renderer.sharedMaterial;
    Label_0074:
        if (base.managed == null)
        {
            goto Label_00BA;
        }
        if ((base.manager != null) == null)
        {
            goto Label_00A1;
        }
        return base.manager.renderer.sharedMaterial;
    Label_00A1:
        *(errString) = "Sprite \"" + base.name + "\" is not associated with a SpriteManager, and can therefore not be included in the atlas build.";
        return null;
    Label_00BA:
        return base.spriteMesh.material;
    }

    public override int GetStateIndex(string stateName)
    {
        int num;
        num = 0;
        goto Label_0026;
    Label_0007:
        if (string.Equals(this.animations[num].name, stateName, 1) == null)
        {
            goto Label_0022;
        }
        return num;
    Label_0022:
        num += 1;
    Label_0026:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0007;
        }
        return -1;
    }

    //GameObject ISpriteAggregator.get_gameObject()
    //{
    //    return base.gameObject;
    //}

    void ISpriteAggregator.SetUVs(Rect uvs)
    {
        base.SetUVs(uvs);
        return;
    }

    //SpriteRoot.ANCHOR_METHOD ISpritePackable.get_Anchor()
    //{
    //    return base.Anchor;
    //}

    //Color ISpritePackable.get_Color()
    //{
    //    return base.Color;
    //}

    //GameObject ISpritePackable.get_gameObject()
    //{
    //    return base.gameObject;
    //}

    //void ISpritePackable.set_Color(Color value)
    //{
    //    base.Color = value;
    //    return;
    //}

    public override void PlayAnim(int index)
    {
        if (index < ((int) this.animations.Length))
        {
            goto Label_0029;
        }
        Debug.LogError("ERROR: Animation index " + ((int) index) + " is out of bounds!");
        return;
    Label_0029:
        this.PlayAnim(this.animations[index], 0);
        return;
    }

    public override void PlayAnim(string name)
    {
        this.PlayAnim(name, 0);
        return;
    }

    public void PlayAnim(UVAnimation anim)
    {
        this.PlayAnim(anim, 0);
        return;
    }

    public void PlayAnim(int index, int frame)
    {
        if (index < ((int) this.animations.Length))
        {
            goto Label_0029;
        }
        Debug.LogError("ERROR: Animation index " + ((int) index) + " is out of bounds!");
        return;
    Label_0029:
        this.PlayAnim(this.animations[index], frame);
        return;
    }

    public void PlayAnim(string name, int frame)
    {
        int num;
        num = 0;
        goto Label_0033;
    Label_0007:
        if ((this.animations[num].name == name) == null)
        {
            goto Label_002F;
        }
        this.PlayAnim(this.animations[num], frame);
        return;
    Label_002F:
        num += 1;
    Label_0033:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0007;
        }
        Debug.LogError("ERROR: Animation \"" + name + "\" not found!");
        return;
    }

    public void PlayAnim(UVAnimation anim, int frame)
    {
        if (base.deleted != null)
        {
            goto Label_001B;
        }
        if (base.gameObject.activeInHierarchy != null)
        {
            goto Label_001C;
        }
    Label_001B:
        return;
    Label_001C:
        if (base.m_started != null)
        {
            goto Label_002D;
        }
        this.Start();
    Label_002D:
        this.curAnim = anim;
        base.curAnimIndex = this.curAnim.index;
        this.curAnim.Reset();
        this.curAnim.SetCurrentFrame(frame - 1);
        if (anim.framerate == 0f)
        {
            goto Label_0085;
        }
        base.timeBetweenAnimFrames = 1f / anim.framerate;
        goto Label_0090;
    Label_0085:
        base.timeBetweenAnimFrames = 1f;
    Label_0090:
        base.timeSinceLastFrame = base.timeBetweenAnimFrames;
        if (anim.GetFrameCount() > 1)
        {
            goto Label_00B3;
        }
        if (anim.onAnimEnd == null)
        {
            goto Label_00E5;
        }
    Label_00B3:
        if (anim.framerate == 0f)
        {
            goto Label_00E5;
        }
        this.StepAnim(0f);
        if (base.animating != null)
        {
            goto Label_013A;
        }
        this.AddToAnimatedList();
        goto Label_013A;
    Label_00E5:
        base.PauseAnim();
        if (base.animCompleteDelegate == null)
        {
            goto Label_012E;
        }
        if (anim.framerate == 0f)
        {
            goto Label_0122;
        }
        base.Invoke("CallAnimCompleteDelegate", 1f / anim.framerate);
        goto Label_012E;
    Label_0122:
        base.animCompleteDelegate(this);
    Label_012E:
        this.StepAnim(0f);
    Label_013A:
        return;
    }

    public override void PlayAnimInReverse(int index)
    {
        if (index < ((int) this.animations.Length))
        {
            goto Label_0029;
        }
        Debug.LogError("ERROR: Animation index " + ((int) index) + " is out of bounds!");
        return;
    Label_0029:
        this.PlayAnimInReverse(this.animations[index]);
        return;
    }

    public override void PlayAnimInReverse(string name)
    {
        int num;
        num = 0;
        goto Label_003F;
    Label_0007:
        if ((this.animations[num].name == name) == null)
        {
            goto Label_003B;
        }
        this.animations[num].PlayInReverse();
        this.PlayAnimInReverse(this.animations[num]);
        return;
    Label_003B:
        num += 1;
    Label_003F:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0007;
        }
        Debug.LogError("ERROR: Animation \"" + name + "\" not found!");
        return;
    }

    public void PlayAnimInReverse(UVAnimation anim)
    {
        if (base.deleted != null)
        {
            goto Label_001B;
        }
        if (base.gameObject.activeInHierarchy != null)
        {
            goto Label_001C;
        }
    Label_001B:
        return;
    Label_001C:
        this.curAnim = anim;
        this.curAnim.Reset();
        this.curAnim.PlayInReverse();
        if (anim.framerate == 0f)
        {
            goto Label_0060;
        }
        base.timeBetweenAnimFrames = 1f / anim.framerate;
        goto Label_006B;
    Label_0060:
        base.timeBetweenAnimFrames = 1f;
    Label_006B:
        base.timeSinceLastFrame = base.timeBetweenAnimFrames;
        if (anim.GetFrameCount() > 1)
        {
            goto Label_008E;
        }
        if (anim.onAnimEnd == null)
        {
            goto Label_00C0;
        }
    Label_008E:
        if (anim.framerate == 0f)
        {
            goto Label_00C0;
        }
        this.StepAnim(0f);
        if (base.animating != null)
        {
            goto Label_00E9;
        }
        this.AddToAnimatedList();
        goto Label_00E9;
    Label_00C0:
        base.PauseAnim();
        if (base.animCompleteDelegate == null)
        {
            goto Label_00DD;
        }
        base.animCompleteDelegate(this);
    Label_00DD:
        this.StepAnim(0f);
    Label_00E9:
        return;
    }

    public void PlayAnimInReverse(int index, int frame)
    {
        if (index < ((int) this.animations.Length))
        {
            goto Label_0029;
        }
        Debug.LogError("ERROR: Animation index " + ((int) index) + " is out of bounds!");
        return;
    Label_0029:
        this.PlayAnimInReverse(this.animations[index], frame);
        return;
    }

    public void PlayAnimInReverse(string name, int frame)
    {
        int num;
        num = 0;
        goto Label_0040;
    Label_0007:
        if ((this.animations[num].name == name) == null)
        {
            goto Label_003C;
        }
        this.animations[num].PlayInReverse();
        this.PlayAnimInReverse(this.animations[num], frame);
        return;
    Label_003C:
        num += 1;
    Label_0040:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0007;
        }
        Debug.LogError("ERROR: Animation \"" + name + "\" not found!");
        return;
    }

    public void PlayAnimInReverse(UVAnimation anim, int frame)
    {
        if (base.deleted != null)
        {
            goto Label_001B;
        }
        if (base.gameObject.activeInHierarchy != null)
        {
            goto Label_001C;
        }
    Label_001B:
        return;
    Label_001C:
        if (base.m_started != null)
        {
            goto Label_002D;
        }
        this.Start();
    Label_002D:
        this.curAnim = anim;
        this.curAnim.Reset();
        this.curAnim.PlayInReverse();
        this.curAnim.SetCurrentFrame(frame + 1);
        anim.framerate = Mathf.Max(0.0001f, anim.framerate);
        base.timeBetweenAnimFrames = 1f / anim.framerate;
        base.timeSinceLastFrame = base.timeBetweenAnimFrames;
        if (anim.GetFrameCount() <= 1)
        {
            goto Label_00BA;
        }
        this.StepAnim(0f);
        if (base.animating != null)
        {
            goto Label_00DD;
        }
        this.AddToAnimatedList();
        goto Label_00DD;
    Label_00BA:
        if (base.animCompleteDelegate == null)
        {
            goto Label_00D1;
        }
        base.animCompleteDelegate(this);
    Label_00D1:
        this.StepAnim(0f);
    Label_00DD:
        return;
    }

    protected override void RemoveFromAnimatedList()
    {
        SpriteAnimationPump.Remove(this);
        base.animating = 0;
        base.currentlyAnimating = 0;
        return;
    }

    public void SetCurFrame(int index)
    {
        if (this.curAnim != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.m_started != null)
        {
            goto Label_001D;
        }
        this.Start();
    Label_001D:
        this.curAnim.SetCurrentFrame(index - this.curAnim.StepDirection);
        base.timeSinceLastFrame = base.timeBetweenAnimFrames;
        this.StepAnim(0f);
        return;
    }

    public void SetFrame(int anim, int frameNum)
    {
        this.PlayAnim(anim);
        if (base.IsAnimating() == null)
        {
            goto Label_0018;
        }
        base.PauseAnim();
    Label_0018:
        this.SetCurFrame(frameNum);
        return;
    }

    public void SetFrame(string anim, int frameNum)
    {
        this.PlayAnim(anim);
        if (base.IsAnimating() == null)
        {
            goto Label_0018;
        }
        base.PauseAnim();
    Label_0018:
        this.SetCurFrame(frameNum);
        return;
    }

    public void SetFrame(UVAnimation anim, int frameNum)
    {
        this.PlayAnim(anim);
        if (base.IsAnimating() == null)
        {
            goto Label_0018;
        }
        base.PauseAnim();
    Label_0018:
        this.SetCurFrame(frameNum);
        return;
    }

    public override void SetState(int index)
    {
        this.PlayAnim(index);
        return;
    }

    public void Setup(float w, float h)
    {
        this.Setup(w, h, base.m_spriteMesh.material);
        return;
    }

    public void Setup(float w, float h, Material material)
    {
        base.width = w;
        base.height = h;
        if (base.managed != null)
        {
            goto Label_002A;
        }
        ((SpriteMesh) base.m_spriteMesh).material = material;
    Label_002A:
        this.Init();
        return;
    }

    public override unsafe bool StepAnim(float time)
    {
        int num;
        int num2;
        Vector2[] vectorArray;
        Rect rect;
        UVAnimation.ANIM_END_ACTION anim_end_action;
        if (this.curAnim != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        base.timeSinceLastFrame += Mathf.Max(0f, time);
        base.framesToAdvance = base.timeSinceLastFrame / base.timeBetweenAnimFrames;
        if (base.framesToAdvance >= 1f)
        {
            goto Label_01EA;
        }
        if (base.crossfadeFrames == null)
        {
            goto Label_0079;
        }
        this.SetColor(new Color(1f, 1f, 1f, 1f - base.framesToAdvance));
    Label_0079:
        return 1;
        goto Label_01EA;
    Label_0080:
        if (this.curAnim.GetNextFrame(&this.frameInfo) == null)
        {
            goto Label_00C0;
        }
        base.framesToAdvance -= 1f;
        base.timeSinceLastFrame -= base.timeBetweenAnimFrames;
        goto Label_01EA;
    Label_00C0:
        if (base.crossfadeFrames == null)
        {
            goto Label_00D6;
        }
        this.SetColor(Color.white);
    Label_00D6:
        switch (this.curAnim.onAnimEnd)
        {
            case 0:
                goto Label_0107;

            case 1:
                goto Label_0145;

            case 2:
                goto Label_0150;

            case 3:
                goto Label_0175;

            case 4:
                goto Label_0181;

            case 5:
                goto Label_0192;
        }
        goto Label_01BF;
    Label_0107:
        base.PauseAnim();
        base.uvRect = &this.frameInfo.uvs;
        base.SetBleedCompensation();
        if (base.autoResize != null)
        {
            goto Label_013A;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_01BF;
        }
    Label_013A:
        base.CalcSize();
        goto Label_01BF;
    Label_0145:
        base.RevertToStatic();
        goto Label_01BF;
    Label_0150:
        if (base.animCompleteDelegate == null)
        {
            goto Label_0167;
        }
        base.animCompleteDelegate(this);
    Label_0167:
        this.PlayAnim(base.defaultAnim);
        return 0;
    Label_0175:
        this.Hide(1);
        goto Label_01BF;
    Label_0181:
        base.gameObject.SetActive(0);
        goto Label_01BF;
    Label_0192:
        if (base.animCompleteDelegate == null)
        {
            goto Label_01A9;
        }
        base.animCompleteDelegate(this);
    Label_01A9:
        this.Delete();
        UnityEngine.Object.Destroy(base.gameObject);
    Label_01BF:
        if (base.animCompleteDelegate == null)
        {
            goto Label_01D6;
        }
        base.animCompleteDelegate(this);
    Label_01D6:
        if (base.animating != null)
        {
            goto Label_01E8;
        }
        this.curAnim = null;
    Label_01E8:
        return 0;
    Label_01EA:
        if (base.framesToAdvance >= 1f)
        {
            goto Label_0080;
        }
        if (base.crossfadeFrames == null)
        {
            goto Label_031D;
        }
        num = this.curAnim.GetCurPosition();
        num2 = this.curAnim.StepDirection;
        this.curAnim.GetNextFrame(&this.nextFrameInfo);
        vectorArray = base.m_spriteMesh.uvs2;
        rect = &this.nextFrameInfo.uvs;
        &(vectorArray[0]).x = &rect.xMin;
        &(vectorArray[0]).y = &rect.yMax;
        &(vectorArray[1]).x = &rect.xMin;
        &(vectorArray[1]).y = &rect.yMin;
        &(vectorArray[2]).x = &rect.xMax;
        &(vectorArray[2]).y = &rect.yMin;
        &(vectorArray[3]).x = &rect.xMax;
        &(vectorArray[3]).y = &rect.yMax;
        this.curAnim.SetCurrentFrame(num);
        this.curAnim.StepDirection = num2;
        this.SetColor(new Color(1f, 1f, 1f, 1f - base.framesToAdvance));
    Label_031D:
        base.uvRect = &this.frameInfo.uvs;
        base.SetBleedCompensation();
        if (base.autoResize != null)
        {
            goto Label_034A;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_0355;
        }
    Label_034A:
        base.CalcSize();
        goto Label_0374;
    Label_0355:
        if (base.anchor != 9)
        {
            goto Label_0374;
        }
        this.SetSize(base.width, base.height);
    Label_0374:
        return 1;
    }

    public override void StopAnim()
    {
        this.RemoveFromAnimatedList();
        if (this.curAnim == null)
        {
            goto Label_001C;
        }
        this.curAnim.Reset();
    Label_001C:
        base.RevertToStatic();
        return;
    }

    public void UnpauseAnim()
    {
        if (this.curAnim != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.AddToAnimatedList();
        return;
    }

    public virtual CSpriteFrame DefaultFrame
    {
        get
        {
            if (((int) this.States[0].spriteFrames.Length) == null)
            {
                goto Label_0024;
            }
            return this.States[0].spriteFrames[0];
        Label_0024:
            return null;
        }
    }

    public virtual TextureAnim DefaultState
    {
        get
        {
            if (this.States == null)
            {
                goto Label_0021;
            }
            if (((int) this.States.Length) == null)
            {
                goto Label_0021;
            }
            return this.States[0];
        Label_0021:
            return null;
        }
    }

    public virtual bool DoNotTrimImages
    {
        get
        {
            return this.doNotTrimImages;
        }
        set
        {
            this.doNotTrimImages = value;
            return;
        }
    }

    public Texture2D[] SourceTextures
    {
        get
        {
            return this.sourceTextures;
        }
    }

    public CSpriteFrame[] SpriteFrames
    {
        get
        {
            return this.spriteFrames;
        }
    }

    public abstract TextureAnim[] States { get; set; }

    public virtual bool SupportsArbitraryAnimations
    {
        get
        {
            return 0;
        }
    }
}

