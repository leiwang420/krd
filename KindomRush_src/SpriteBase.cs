using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public abstract class SpriteBase : SpriteRoot, ISpriteAnimatable
{
    protected bool animating;
    protected AnimCompleteDelegate animCompleteDelegate;
    protected AnimFrameDelegate animFrameDelegate;
    [HideInInspector]
    public bool crossfadeFrames;
    protected int curAnimIndex;
    protected bool currentlyAnimating;
    public int defaultAnim;
    protected float framesToAdvance;
    protected SPRITE_FRAME nextFrameInfo;
    public bool playAnimOnStart;
    protected float timeBetweenAnimFrames;
    protected float timeSinceLastFrame;

    protected SpriteBase()
    {
        this.nextFrameInfo = new SPRITE_FRAME(0f);
        base..ctor();
        return;
    }

    public void AddSpriteResizedDelegate(SpriteRoot.SpriteResizedDelegate del)
    {
        base.resizedDelegate = (SpriteRoot.SpriteResizedDelegate) Delegate.Combine(base.resizedDelegate, del);
        return;
    }

    protected abstract void AddToAnimatedList();
    protected override void Awake()
    {
        base.Awake();
        return;
    }

    public override void Clear()
    {
        base.Clear();
        this.animCompleteDelegate = null;
        return;
    }

    public override void Copy(SpriteRoot s)
    {
        SpriteBase base2;
        base.Copy(s);
        if ((s as SpriteBase) != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        base2 = (SpriteBase) s;
        this.defaultAnim = base2.defaultAnim;
        this.playAnimOnStart = base2.playAnimOnStart;
        return;
    }

    public override void Delete()
    {
        if (this.currentlyAnimating == null)
        {
            goto Label_0011;
        }
        this.RemoveFromAnimatedList();
    Label_0011:
        base.Delete();
        return;
    }

    public override void Hide(bool tf)
    {
        base.Hide(tf);
        if (tf == null)
        {
            goto Label_0013;
        }
        this.PauseAnim();
    Label_0013:
        return;
    }

    public bool IsAnimating()
    {
        return this.animating;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (this.animating == null)
        {
            goto Label_001E;
        }
        this.RemoveFromAnimatedList();
        this.animating = 1;
    Label_001E:
        return;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (Application.isPlaying != null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        if (this.animating == null)
        {
            goto Label_0029;
        }
        this.animating = 0;
        this.AddToAnimatedList();
    Label_0029:
        return;
    }

    public void PauseAnim()
    {
        if (this.animating == null)
        {
            goto Label_0011;
        }
        this.RemoveFromAnimatedList();
    Label_0011:
        return;
    }

    public virtual void PlayAnim(int index)
    {
    }

    public virtual void PlayAnim(string name)
    {
    }

    public virtual void PlayAnimInReverse(int index)
    {
    }

    public virtual void PlayAnimInReverse(string name)
    {
    }

    protected abstract void RemoveFromAnimatedList();
    public void RemoveSpriteresizedDelegate(SpriteRoot.SpriteResizedDelegate del)
    {
        base.resizedDelegate = (SpriteRoot.SpriteResizedDelegate) Delegate.Remove(base.resizedDelegate, del);
        return;
    }

    public void RevertToStatic()
    {
        if (this.animating == null)
        {
            goto Label_0011;
        }
        this.StopAnim();
    Label_0011:
        this.InitUVs();
        base.SetBleedCompensation();
        if (base.autoResize != null)
        {
            goto Label_0033;
        }
        if (base.pixelPerfect == null)
        {
            goto Label_0039;
        }
    Label_0033:
        base.CalcSize();
    Label_0039:
        return;
    }

    public void SetAnimCompleteDelegate(AnimCompleteDelegate del)
    {
        this.animCompleteDelegate = del;
        return;
    }

    public void SetAnimFrameDelegate(AnimFrameDelegate del)
    {
        this.animFrameDelegate = del;
        return;
    }

    public void SetFramerate(float fps)
    {
        this.timeBetweenAnimFrames = 1f / fps;
        return;
    }

    public void SetSpriteResizedDelegate(SpriteRoot.SpriteResizedDelegate del)
    {
        base.resizedDelegate = del;
        return;
    }

    public override void Start()
    {
        base.Start();
        if (base.m_spriteMesh == null)
        {
            goto Label_0022;
        }
        base.m_spriteMesh.UseUV2 = this.crossfadeFrames;
    Label_0022:
        return;
    }

    public virtual bool StepAnim(float time)
    {
        return 0;
    }

    public virtual void StopAnim()
    {
    }

    public bool Animating
    {
        get
        {
            return this.animating;
        }
        set
        {
            if (value == null)
            {
                goto Label_0012;
            }
            this.PlayAnim(this.curAnimIndex);
        Label_0012:
            return;
        }
    }

    public int CurAnimIndex
    {
        get
        {
            return this.curAnimIndex;
        }
        set
        {
            this.curAnimIndex = value;
            return;
        }
    }

    public delegate void AnimCompleteDelegate(SpriteBase sprite);

    public delegate void AnimFrameDelegate(SpriteBase sprite, int frame);
}

