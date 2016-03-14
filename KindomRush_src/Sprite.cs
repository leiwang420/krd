using System;
using UnityEngine;

[ExecuteInEditMode]
public class Sprite : SpriteBase
{
    public UVAnimation_Multi[] animations;
    protected UVAnimation_Multi curAnim;
    public Vector2 lowerLeftPixel;
    public Vector2 pixelDimensions;

    public Sprite()
    {
        base..ctor();
        return;
    }

    public void AddAnimation(UVAnimation_Multi anim)
    {
        UVAnimation_Multi[] multiArray;
        multiArray = this.animations;
        this.animations = new UVAnimation_Multi[((int) multiArray.Length) + 1];
        multiArray.CopyTo(this.animations, 0);
        anim.index = ((int) this.animations.Length) - 1;
        this.animations[anim.index] = anim;
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

    protected override void Awake()
    {
        int num;
        base.Awake();
        this.Init();
        if (this.animations != null)
        {
            goto Label_0023;
        }
        this.animations = new UVAnimation_Multi[0];
    Label_0023:
        num = 0;
        goto Label_004B;
    Label_002A:
        this.animations[num].index = num;
        this.animations[num].BuildUVAnim(this);
        num += 1;
    Label_004B:
        if (num < ((int) this.animations.Length))
        {
            goto Label_002A;
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
        Sprite sprite;
        int num;
        int num2;
        base.Copy(s);
        if ((s as Sprite) != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        sprite = (Sprite) s;
        this.lowerLeftPixel = sprite.lowerLeftPixel;
        this.pixelDimensions = sprite.pixelDimensions;
        this.InitUVs();
        base.SetBleedCompensation(s.bleedCompensation);
        if (base.autoResize != null)
        {
            goto Label_005A;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_0065;
        }
    Label_005A:
        base.CalcSize();
        goto Label_0077;
    Label_0065:
        this.SetSize(s.width, s.height);
    Label_0077:
        if (((int) sprite.animations.Length) <= 0)
        {
            goto Label_00C6;
        }
        this.animations = new UVAnimation_Multi[(int) sprite.animations.Length];
        num = 0;
        goto Label_00B8;
    Label_009F:
        this.animations[num] = sprite.animations[num].Clone();
        num += 1;
    Label_00B8:
        if (num < ((int) this.animations.Length))
        {
            goto Label_009F;
        }
    Label_00C6:
        num2 = 0;
        goto Label_00E0;
    Label_00CD:
        this.animations[num2].BuildUVAnim(this);
        num2 += 1;
    Label_00E0:
        if (num2 < ((int) this.animations.Length))
        {
            goto Label_00CD;
        }
        return;
    }

    public static Sprite Create(string name, Vector3 pos)
    {
        GameObject obj2;
        obj2 = new GameObject(name);
        obj2.transform.position = pos;
        return (Sprite) obj2.AddComponent(typeof(Sprite));
    }

    public static Sprite Create(string name, Vector3 pos, Quaternion rotation)
    {
        GameObject obj2;
        obj2 = new GameObject(name);
        obj2.transform.position = pos;
        obj2.transform.rotation = rotation;
        return (Sprite) obj2.AddComponent(typeof(Sprite));
    }

    public void DoAnim(int index)
    {
        if (this.curAnim != null)
        {
            goto Label_0017;
        }
        this.PlayAnim(index);
        goto Label_003C;
    Label_0017:
        if (this.curAnim != this.animations[index])
        {
            goto Label_0035;
        }
        if (base.animating != null)
        {
            goto Label_003C;
        }
    Label_0035:
        this.PlayAnim(index);
    Label_003C:
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

    public void DoAnim(UVAnimation_Multi anim)
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

    public override unsafe void DoMirror()
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
        base.Start();
    Label_003B:
        if (base.mirror != null)
        {
            goto Label_005D;
        }
        base.mirror = new SpriteMirror();
        base.mirror.Mirror(this);
    Label_005D:
        base.mirror.Validate(this);
        if (base.mirror.DidChange(this) == null)
        {
            goto Label_008D;
        }
        this.Init();
        base.mirror.Mirror(this);
    Label_008D:
        return;
    }

    public UVAnimation_Multi GetAnim(string name)
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

    public UVAnimation_Multi GetCurAnim()
    {
        return this.curAnim;
    }

    public override Vector2 GetDefaultPixelSize(PathFromGUIDDelegate guid2Path, AssetLoaderDelegate loader)
    {
        return this.pixelDimensions;
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

    protected override void Init()
    {
        base.Init();
        return;
    }

    public override unsafe void InitUVs()
    {
        base.tempUV = base.PixelCoordToUVCoord(this.lowerLeftPixel);
        &this.uvRect.x = &this.tempUV.x;
        &this.uvRect.y = &this.tempUV.y;
        base.tempUV = base.PixelSpaceToUVSpace(this.pixelDimensions);
        &this.uvRect.xMax = &this.uvRect.x + &this.tempUV.x;
        &this.uvRect.yMax = &this.uvRect.y + &this.tempUV.y;
        &this.frameInfo.uvs = base.uvRect;
        return;
    }

    public override void PlayAnim(int index)
    {
        if (index < ((int) this.animations.Length))
        {
            goto Label_0029;
        }
        Debug.LogError("ERROR: Animation index " + ((int) index) + " is out of bounds!");
        return;
    Label_0029:
        this.PlayAnim(this.animations[index]);
        return;
    }

    public override void PlayAnim(string name)
    {
        int num;
        num = 0;
        goto Label_0032;
    Label_0007:
        if ((this.animations[num].name == name) == null)
        {
            goto Label_002E;
        }
        this.PlayAnim(this.animations[num]);
        return;
    Label_002E:
        num += 1;
    Label_0032:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0007;
        }
        Debug.LogError("ERROR: Animation \"" + name + "\" not found!");
        return;
    }

    public void PlayAnim(UVAnimation_Multi anim)
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
        if (anim.framerate == 0f)
        {
            goto Label_0077;
        }
        base.timeBetweenAnimFrames = 1f / anim.framerate;
        goto Label_0082;
    Label_0077:
        base.timeBetweenAnimFrames = 1f;
    Label_0082:
        base.timeSinceLastFrame = base.timeBetweenAnimFrames;
        if (anim.GetFrameCount() > 1)
        {
            goto Label_00A5;
        }
        if (anim.onAnimEnd == null)
        {
            goto Label_00D7;
        }
    Label_00A5:
        if (anim.framerate == 0f)
        {
            goto Label_00D7;
        }
        this.StepAnim(0f);
        if (base.animating != null)
        {
            goto Label_012C;
        }
        this.AddToAnimatedList();
        goto Label_012C;
    Label_00D7:
        base.PauseAnim();
        if (base.animCompleteDelegate == null)
        {
            goto Label_0120;
        }
        if (anim.framerate == 0f)
        {
            goto Label_0114;
        }
        base.Invoke("CallAnimCompleteDelegate", 1f / anim.framerate);
        goto Label_0120;
    Label_0114:
        base.animCompleteDelegate(this);
    Label_0120:
        this.StepAnim(0f);
    Label_012C:
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

    public void PlayAnimInReverse(UVAnimation_Multi anim)
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
        if (anim.framerate == 0f)
        {
            goto Label_0071;
        }
        base.timeBetweenAnimFrames = 1f / anim.framerate;
        goto Label_007C;
    Label_0071:
        base.timeBetweenAnimFrames = 1f;
    Label_007C:
        base.timeSinceLastFrame = base.timeBetweenAnimFrames;
        if (anim.GetFrameCount() > 1)
        {
            goto Label_009F;
        }
        if (anim.onAnimEnd == null)
        {
            goto Label_00D1;
        }
    Label_009F:
        if (anim.framerate == 0f)
        {
            goto Label_00D1;
        }
        this.StepAnim(0f);
        if (base.animating != null)
        {
            goto Label_00FA;
        }
        this.AddToAnimatedList();
        goto Label_00FA;
    Label_00D1:
        base.PauseAnim();
        if (base.animCompleteDelegate == null)
        {
            goto Label_00EE;
        }
        base.animCompleteDelegate(this);
    Label_00EE:
        this.StepAnim(0f);
    Label_00FA:
        return;
    }

    protected override void RemoveFromAnimatedList()
    {
        SpriteAnimationPump.Remove(this);
        base.animating = 0;
        base.currentlyAnimating = 0;
        return;
    }

    public unsafe void SetLowerLeftPixel(Vector2 lowerLeft)
    {
        this.lowerLeftPixel = lowerLeft;
        base.tempUV = base.PixelCoordToUVCoord(this.lowerLeftPixel);
        &this.uvRect.x = &this.tempUV.x;
        &this.uvRect.y = &this.tempUV.y;
        base.tempUV = base.PixelSpaceToUVSpace(this.pixelDimensions);
        &this.uvRect.xMax = &this.uvRect.x + &this.tempUV.x;
        &this.uvRect.yMax = &this.uvRect.y + &this.tempUV.y;
        &this.frameInfo.uvs = base.uvRect;
        base.SetBleedCompensation(base.bleedCompensation);
        if (base.autoResize != null)
        {
            goto Label_00CE;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_00D4;
        }
    Label_00CE:
        base.CalcSize();
    Label_00D4:
        return;
    }

    public void SetLowerLeftPixel(int x, int y)
    {
        this.SetLowerLeftPixel(new Vector2((float) x, (float) y));
        return;
    }

    public unsafe void SetPixelDimensions(Vector2 size)
    {
        this.pixelDimensions = size;
        base.tempUV = base.PixelSpaceToUVSpace(this.pixelDimensions);
        &this.uvRect.xMax = &this.uvRect.x + &this.tempUV.x;
        &this.uvRect.yMax = &this.uvRect.y + &this.tempUV.y;
        &this.uvRect.xMax -= &this.bleedCompensationUV.x * 2f;
        &this.uvRect.yMax -= &this.bleedCompensationUV.y * 2f;
        &this.frameInfo.uvs = base.uvRect;
        if (base.autoResize != null)
        {
            goto Label_00CA;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_00D0;
        }
    Label_00CA:
        base.CalcSize();
    Label_00D0:
        return;
    }

    public void SetPixelDimensions(int x, int y)
    {
        this.SetPixelDimensions(new Vector2((float) x, (float) y));
        return;
    }

    public override void SetState(int index)
    {
        this.PlayAnim(index);
        return;
    }

    public void Setup(float w, float h, Vector2 lowerleftPixel, Vector2 pixeldimensions)
    {
        this.Setup(w, h, lowerleftPixel, pixeldimensions, base.m_spriteMesh.material);
        return;
    }

    public void Setup(float w, float h, Vector2 lowerleftPixel, Vector2 pixeldimensions, Material material)
    {
        base.width = w;
        base.height = h;
        this.lowerLeftPixel = lowerleftPixel;
        this.pixelDimensions = pixeldimensions;
        base.uvsInitialized = 0;
        if (base.managed != null)
        {
            goto Label_0041;
        }
        ((SpriteMesh) base.m_spriteMesh).material = material;
    Label_0041:
        if (base.uvsInitialized == null)
        {
            goto Label_0063;
        }
        this.Init();
        this.InitUVs();
        base.SetBleedCompensation();
        goto Label_0069;
    Label_0063:
        this.Init();
    Label_0069:
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
        if (base.defaultAnim >= ((int) this.animations.Length))
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

    public override unsafe bool StepAnim(float time)
    {
        UVAnimation animation;
        int num;
        int num2;
        int num3;
        int num4;
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
            goto Label_01F1;
        }
        if (base.crossfadeFrames == null)
        {
            goto Label_0079;
        }
        this.SetColor(new Color(1f, 1f, 1f, 1f - base.framesToAdvance));
    Label_0079:
        return 1;
        goto Label_01F1;
    Label_0080:
        if (this.curAnim.GetNextFrame(&this.frameInfo) == null)
        {
            goto Label_00C0;
        }
        base.framesToAdvance -= 1f;
        base.timeSinceLastFrame -= base.timeBetweenAnimFrames;
        goto Label_01F1;
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
                goto Label_0157;

            case 3:
                goto Label_017C;

            case 4:
                goto Label_0188;

            case 5:
                goto Label_0199;
        }
        goto Label_01C6;
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
            goto Label_01C6;
        }
    Label_013A:
        base.CalcSize();
        goto Label_01C6;
    Label_0145:
        base.RevertToStatic();
        this.curAnim = null;
        goto Label_01C6;
    Label_0157:
        if (base.animCompleteDelegate == null)
        {
            goto Label_016E;
        }
        base.animCompleteDelegate(this);
    Label_016E:
        this.PlayAnim(base.defaultAnim);
        return 0;
    Label_017C:
        this.Hide(1);
        goto Label_01C6;
    Label_0188:
        base.gameObject.SetActive(0);
        goto Label_01C6;
    Label_0199:
        if (base.animCompleteDelegate == null)
        {
            goto Label_01B0;
        }
        base.animCompleteDelegate(this);
    Label_01B0:
        this.Delete();
        UnityEngine.Object.Destroy(base.gameObject);
    Label_01C6:
        if (base.animCompleteDelegate == null)
        {
            goto Label_01DD;
        }
        base.animCompleteDelegate(this);
    Label_01DD:
        if (base.animating != null)
        {
            goto Label_01EF;
        }
        this.curAnim = null;
    Label_01EF:
        return 0;
    Label_01F1:
        if (base.framesToAdvance >= 1f)
        {
            goto Label_0080;
        }
        if (base.crossfadeFrames == null)
        {
            goto Label_0358;
        }
        animation = this.curAnim.GetCurrentClip();
        num = this.curAnim.GetCurClipNum();
        num2 = animation.GetCurPosition();
        num3 = this.curAnim.StepDirection;
        num4 = animation.StepDirection;
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
        this.curAnim.SetCurClipNum(num);
        animation.SetCurrentFrame(num2);
        this.curAnim.StepDirection = num3;
        animation.StepDirection = num4;
        this.SetColor(new Color(1f, 1f, 1f, 1f - base.framesToAdvance));
    Label_0358:
        base.uvRect = &this.frameInfo.uvs;
        base.SetBleedCompensation();
        if (base.autoResize != null)
        {
            goto Label_0385;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_038B;
        }
    Label_0385:
        base.CalcSize();
    Label_038B:
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
}

