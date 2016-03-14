using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class SuperSpriteAnim
{
    protected int curAnim;
    public bool deactivateNonPlaying;
    public bool deactivateRecursively;
    private AnimCompletedDelegate endDelegate;
    [HideInInspector]
    public int index;
    protected bool isRunning;
    public int loopCycles;
    public string name;
    protected int numLoops;
    public ANIM_END_ACTION onAnimEnd;
    public bool pingPong;
    public SuperSpriteAnimElement[] spriteAnims;
    protected int stepDir;

    public SuperSpriteAnim()
    {
        this.spriteAnims = new SuperSpriteAnimElement[0];
        this.stepDir = 1;
        base..ctor();
        return;
    }

    private void AnimFinished(SpriteBase sp)
    {
        if ((this.curAnim + this.stepDir) >= ((int) this.spriteAnims.Length))
        {
            goto Label_002D;
        }
        if ((this.curAnim + this.stepDir) >= 0)
        {
            goto Label_0134;
        }
    Label_002D:
        if (this.stepDir <= 0)
        {
            goto Label_0082;
        }
        if (this.pingPong == null)
        {
            goto Label_0082;
        }
        this.stepDir = -1;
        ((AutoSpriteBase) sp).PlayAnimInReverse(this.spriteAnims[this.curAnim].anim, this.spriteAnims[this.curAnim].anim.GetFrameCount() - 2);
        return;
    Label_0082:
        if ((this.numLoops + 1) <= this.loopCycles)
        {
            goto Label_00C7;
        }
        if (this.loopCycles == -1)
        {
            goto Label_00C7;
        }
        this.isRunning = 0;
        sp.SetAnimCompleteDelegate(null);
        if (this.endDelegate == null)
        {
            goto Label_00C6;
        }
        this.endDelegate(this);
    Label_00C6:
        return;
    Label_00C7:
        this.numLoops += 1;
        if (this.pingPong == null)
        {
            goto Label_0119;
        }
        this.spriteAnims[this.curAnim].sprite.PlayAnim(this.spriteAnims[this.curAnim].anim, 1);
        this.stepDir *= -1;
        return;
    Label_0119:
        this.HideSprite(sp, 1);
        sp.SetAnimCompleteDelegate(null);
        this.curAnim = 0;
        goto Label_0156;
    Label_0134:
        sp.SetAnimCompleteDelegate(null);
        this.HideSprite(sp, 1);
        this.curAnim += this.stepDir;
    Label_0156:
        this.HideSprite(this.spriteAnims[this.curAnim].sprite, 0);
        this.spriteAnims[this.curAnim].sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimFinished));
        if (this.stepDir <= 0)
        {
            goto Label_01B5;
        }
        this.spriteAnims[this.curAnim].Play();
        goto Label_01C7;
    Label_01B5:
        this.spriteAnims[this.curAnim].PlayInReverse();
    Label_01C7:
        return;
    }

    public void Delete()
    {
        int num;
        num = 0;
        goto Label_0047;
    Label_0007:
        if ((this.spriteAnims[num].sprite != null) == null)
        {
            goto Label_0043;
        }
        this.spriteAnims[num].sprite.Delete();
        UnityEngine.Object.Destroy(this.spriteAnims[num].sprite);
    Label_0043:
        num += 1;
    Label_0047:
        if (num < ((int) this.spriteAnims.Length))
        {
            goto Label_0007;
        }
        return;
    }

    public void Hide(bool tf)
    {
        if (this.curAnim < 0)
        {
            goto Label_001F;
        }
        if (this.curAnim < ((int) this.spriteAnims.Length))
        {
            goto Label_0020;
        }
    Label_001F:
        return;
    Label_0020:
        this.HideSprite(this.spriteAnims[this.curAnim].sprite, tf);
        return;
    }

    protected void HideSprite(SpriteBase sp, bool tf)
    {
        if (this.deactivateNonPlaying == null)
        {
            goto Label_001F;
        }
        sp.gameObject.SetActive(tf == 0);
        goto Label_0026;
    Label_001F:
        sp.Hide(tf);
    Label_0026:
        return;
    }

    public void Init(int idx, AnimCompletedDelegate del, SpriteBase.AnimFrameDelegate frameDel)
    {
        List<SuperSpriteAnimElement> list;
        int num;
        this.endDelegate = del;
        this.index = idx;
        list = new List<SuperSpriteAnimElement>();
        num = 0;
        goto Label_008C;
    Label_001B:
        if (this.spriteAnims[num] == null)
        {
            goto Label_0088;
        }
        if ((this.spriteAnims[num].sprite != null) == null)
        {
            goto Label_0088;
        }
        this.spriteAnims[num].Init();
        list.Add(this.spriteAnims[num]);
        if (frameDel == null)
        {
            goto Label_0074;
        }
        this.spriteAnims[num].sprite.SetAnimFrameDelegate(frameDel);
    Label_0074:
        this.HideSprite(this.spriteAnims[num].sprite, 1);
    Label_0088:
        num += 1;
    Label_008C:
        if (num < ((int) this.spriteAnims.Length))
        {
            goto Label_001B;
        }
        this.spriteAnims = list.ToArray();
        return;
    }

    public bool IsHidden()
    {
        if (this.curAnim < 0)
        {
            goto Label_001F;
        }
        if (this.curAnim < ((int) this.spriteAnims.Length))
        {
            goto Label_0021;
        }
    Label_001F:
        return 0;
    Label_0021:
        return this.spriteAnims[this.curAnim].sprite.IsHidden();
    }

    public void Pause()
    {
        this.isRunning = 0;
        this.spriteAnims[this.curAnim].sprite.PauseAnim();
        return;
    }

    public void Play()
    {
        this.isRunning = 1;
        this.spriteAnims[this.curAnim].sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimFinished));
        this.HideSprite(this.spriteAnims[this.curAnim].sprite, 0);
        this.spriteAnims[this.curAnim].Play();
        return;
    }

    public void Reset()
    {
        int num;
        this.Stop();
        this.curAnim = 0;
        this.stepDir = 1;
        this.numLoops = 0;
        num = 1;
        goto Label_003A;
    Label_0022:
        this.HideSprite(this.spriteAnims[num].sprite, 1);
        num += 1;
    Label_003A:
        if (num < ((int) this.spriteAnims.Length))
        {
            goto Label_0022;
        }
        return;
    }

    public void SetAnimFrameDelegate(SpriteBase.AnimFrameDelegate frameDel)
    {
        int num;
        num = 0;
        goto Label_0043;
    Label_0007:
        if (this.spriteAnims[num] == null)
        {
            goto Label_003F;
        }
        if ((this.spriteAnims[num].sprite != null) == null)
        {
            goto Label_003F;
        }
        this.spriteAnims[num].sprite.SetAnimFrameDelegate(frameDel);
    Label_003F:
        num += 1;
    Label_0043:
        if (num < ((int) this.spriteAnims.Length))
        {
            goto Label_0007;
        }
        return;
    }

    public void Stop()
    {
        this.isRunning = 0;
        this.spriteAnims[this.curAnim].sprite.StopAnim();
        this.spriteAnims[this.curAnim].sprite.SetAnimCompleteDelegate(null);
        return;
    }

    public void Unpause()
    {
        this.isRunning = 1;
        this.spriteAnims[this.curAnim].sprite.UnpauseAnim();
        return;
    }

    public SpriteBase CurrentSprite
    {
        get
        {
            if (this.curAnim < 0)
            {
                goto Label_001F;
            }
            if (this.curAnim < ((int) this.spriteAnims.Length))
            {
                goto Label_0021;
            }
        Label_001F:
            return null;
        Label_0021:
            return this.spriteAnims[this.curAnim].sprite;
        }
    }

    public bool IsRunning
    {
        get
        {
            return this.isRunning;
        }
    }

    public enum ANIM_END_ACTION
    {
        Do_Nothing,
        Play_Default_Anim,
        Deactivate,
        Destroy
    }

    public delegate void AnimCompletedDelegate(SuperSpriteAnim anim);
}

