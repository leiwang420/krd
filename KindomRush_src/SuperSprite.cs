using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class SuperSprite : MonoBehaviour
{
    protected bool animating;
    public SuperSpriteAnim[] animations;
    protected AnimCompleteDelegate animCompleteDelegate;
    protected SpriteBase.AnimFrameDelegate animFrameDelegate;
    protected SuperSpriteAnim curAnim;
    public int defaultAnim;
    protected bool m_started;
    public bool playDefaultAnimOnStart;

    public SuperSprite()
    {
        this.animations = new SuperSpriteAnim[0];
        base..ctor();
        return;
    }

    protected void AnimFinished(SuperSpriteAnim anim)
    {
        int num;
        SuperSpriteAnim.ANIM_END_ACTION anim_end_action;
        this.animating = 0;
        if (this.animCompleteDelegate == null)
        {
            goto Label_001E;
        }
        this.animCompleteDelegate(this);
    Label_001E:
        if (this.curAnim == null)
        {
            goto Label_00AB;
        }
        switch ((this.curAnim.onAnimEnd - 1))
        {
            case 0:
                goto Label_004E;

            case 1:
                goto Label_005F;

            case 2:
                goto Label_0070;
        }
        goto Label_00A6;
    Label_004E:
        this.PlayAnim(this.defaultAnim);
        goto Label_00AB;
    Label_005F:
        base.gameObject.SetActive(0);
        goto Label_00AB;
    Label_0070:
        num = 0;
        goto Label_0088;
    Label_0077:
        this.animations[num].Delete();
        num += 1;
    Label_0088:
        if (num < ((int) this.animations.Length))
        {
            goto Label_0077;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        goto Label_00AB;
    Label_00A6:;
    Label_00AB:
        return;
    }

    public void DoAnim(SuperSpriteAnim anim)
    {
        if ((((this.curAnim == anim) == 0) | (this.animating == 0)) == null)
        {
            goto Label_0022;
        }
        this.PlayAnim(anim);
    Label_0022:
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
        if (this.animating != null)
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
        if (this.animating != null)
        {
            goto Label_003F;
        }
    Label_0038:
        this.PlayAnim(name);
    Label_003F:
        return;
    }

    public SuperSpriteAnim GetAnim(int index)
    {
        if (index < 0)
        {
            goto Label_0015;
        }
        if (index < ((int) this.animations.Length))
        {
            goto Label_0017;
        }
    Label_0015:
        return null;
    Label_0017:
        return this.animations[index];
    }

    public SuperSpriteAnim GetAnim(string name)
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

    public SuperSpriteAnim GetCurAnim()
    {
        return this.curAnim;
    }

    public void Hide(bool tf)
    {
        if (this.curAnim == null)
        {
            goto Label_004E;
        }
        this.curAnim.Hide(tf);
        if (tf != null)
        {
            goto Label_0038;
        }
        if (this.animating == null)
        {
            goto Label_004E;
        }
        this.curAnim.Pause();
        goto Label_004E;
    Label_0038:
        if (this.animating == null)
        {
            goto Label_004E;
        }
        this.curAnim.Unpause();
    Label_004E:
        return;
    }

    public bool IsAnimating()
    {
        return this.animating;
    }

    public bool IsHidden()
    {
        if (this.curAnim != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        return this.curAnim.IsHidden();
    }

    public void PauseAnim()
    {
        if (this.curAnim == null)
        {
            goto Label_0016;
        }
        this.curAnim.Pause();
    Label_0016:
        this.animating = 0;
        return;
    }

    public void PlayAnim(SuperSpriteAnim anim)
    {
        if (this.m_started != null)
        {
            goto Label_0011;
        }
        this.Start();
    Label_0011:
        if (this.curAnim == null)
        {
            goto Label_0028;
        }
        this.curAnim.Hide(1);
    Label_0028:
        this.curAnim = anim;
        this.curAnim.Reset();
        this.animating = 1;
        anim.Play();
        return;
    }

    public void PlayAnim(int index)
    {
        if (index < 0)
        {
            goto Label_0015;
        }
        if (index < ((int) this.animations.Length))
        {
            goto Label_0016;
        }
    Label_0015:
        return;
    Label_0016:
        this.PlayAnim(this.animations[index]);
        return;
    }

    public void PlayAnim(string anim)
    {
        int num;
        num = 0;
        goto Label_0032;
    Label_0007:
        if ((this.animations[num].name == anim) == null)
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
        return;
    }

    public void SetAnimCompleteDelegate(AnimCompleteDelegate del)
    {
        this.animCompleteDelegate = del;
        return;
    }

    public void SetAnimFrameDelegate(SpriteBase.AnimFrameDelegate del)
    {
        int num;
        this.animFrameDelegate = del;
        num = 0;
        goto Label_0025;
    Label_000E:
        this.animations[num].SetAnimFrameDelegate(this.animFrameDelegate);
        num += 1;
    Label_0025:
        if (num < ((int) this.animations.Length))
        {
            goto Label_000E;
        }
        return;
    }

    public void Start()
    {
        int num;
        if (this.m_started == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.m_started = 1;
        num = 0;
        goto Label_004B;
    Label_001A:
        if (this.animations[num] == null)
        {
            goto Label_0047;
        }
        this.animations[num].Init(num, new SuperSpriteAnim.AnimCompletedDelegate(this.AnimFinished), this.animFrameDelegate);
    Label_0047:
        num += 1;
    Label_004B:
        if (num < ((int) this.animations.Length))
        {
            goto Label_001A;
        }
        if (this.playDefaultAnimOnStart == null)
        {
            goto Label_0077;
        }
        this.PlayAnim(this.animations[this.defaultAnim]);
    Label_0077:
        return;
    }

    public void StopAnim()
    {
        if (this.curAnim == null)
        {
            goto Label_0016;
        }
        this.curAnim.Stop();
    Label_0016:
        this.animating = 0;
        return;
    }

    public void UnpauseAnim()
    {
        if (this.curAnim == null)
        {
            goto Label_001D;
        }
        this.curAnim.Unpause();
        this.animating = 1;
    Label_001D:
        return;
    }

    public SpriteRoot CurrentSprite
    {
        get
        {
            if (this.curAnim != null)
            {
                goto Label_000D;
            }
            return null;
        Label_000D:
            return this.curAnim.CurrentSprite;
        }
    }

    public delegate void AnimCompleteDelegate(SuperSprite sprite);
}

