using System;
using UnityEngine;

[Serializable]
public class UVAnimation_Multi
{
    public UVAnimation_Auto[] clips;
    protected int curClip;
    protected float duration;
    protected int framePos;
    public float framerate;
    protected int i;
    [HideInInspector]
    public int index;
    public int loopCycles;
    public bool loopReverse;
    public string name;
    protected int numLoops;
    public UVAnimation.ANIM_END_ACTION onAnimEnd;
    protected bool ret;
    protected int stepDir;

    public UVAnimation_Multi()
    {
        this.framerate = 15f;
        this.stepDir = 1;
        this.framePos = -1;
        base..ctor();
        if (this.clips != null)
        {
            goto Label_0036;
        }
        this.clips = new UVAnimation_Auto[0];
    Label_0036:
        return;
    }

    public UVAnimation_Multi(UVAnimation_Multi anim)
    {
        int num;
        this.framerate = 15f;
        this.stepDir = 1;
        this.framePos = -1;
        base..ctor();
        this.name = anim.name;
        this.loopCycles = anim.loopCycles;
        this.loopReverse = anim.loopReverse;
        this.framerate = anim.framerate;
        this.onAnimEnd = anim.onAnimEnd;
        this.curClip = anim.curClip;
        this.stepDir = anim.stepDir;
        this.numLoops = anim.numLoops;
        this.duration = anim.duration;
        this.clips = new UVAnimation_Auto[(int) anim.clips.Length];
        num = 0;
        goto Label_00BE;
    Label_00A5:
        this.clips[num] = anim.clips[num].Clone();
        num += 1;
    Label_00BE:
        if (num < ((int) this.clips.Length))
        {
            goto Label_00A5;
        }
        this.CalcDuration();
        return;
    }

    public void AppendAnim(int index, SPRITE_FRAME[] anim)
    {
        if (index < ((int) this.clips.Length))
        {
            goto Label_000F;
        }
        return;
    Label_000F:
        this.clips[index].AppendAnim(anim);
        this.CalcDuration();
        return;
    }

    public void AppendClip(UVAnimation clip)
    {
        UVAnimation[] animationArray;
        animationArray = this.clips;
        this.clips = new UVAnimation_Auto[((int) this.clips.Length) + 1];
        animationArray.CopyTo(this.clips, 0);
        this.clips[((int) this.clips.Length) - 1] = (UVAnimation_Auto) clip;
        this.CalcDuration();
        return;
    }

    public UVAnimation_Auto[] BuildUVAnim(SpriteRoot s)
    {
        this.i = 0;
        goto Label_002E;
    Label_000C:
        this.clips[this.i].BuildUVAnim(s);
        this.i += 1;
    Label_002E:
        if (this.i < ((int) this.clips.Length))
        {
            goto Label_000C;
        }
        this.CalcDuration();
        return this.clips;
    }

    protected void CalcDuration()
    {
        int num;
        if (this.loopCycles >= 0)
        {
            goto Label_0018;
        }
        this.duration = -1f;
        return;
    Label_0018:
        this.duration = 0f;
        num = 0;
        goto Label_0048;
    Label_002A:
        this.duration += this.clips[num].GetDuration();
        num += 1;
    Label_0048:
        if (num < ((int) this.clips.Length))
        {
            goto Label_002A;
        }
        if (this.loopReverse == null)
        {
            goto Label_0073;
        }
        this.duration *= 2f;
    Label_0073:
        this.duration += ((float) this.loopCycles) * this.duration;
        return;
    }

    public UVAnimation_Multi Clone()
    {
        return new UVAnimation_Multi(this);
    }

    public int GetCurClipNum()
    {
        return this.curClip;
    }

    public int GetCurPosition()
    {
        return this.framePos;
    }

    public UVAnimation_Auto GetCurrentClip()
    {
        return this.clips[this.curClip];
    }

    public SPRITE_FRAME GetCurrentFrame()
    {
        return this.clips[Mathf.Clamp(this.curClip, 0, this.curClip)].GetCurrentFrame();
    }

    public float GetDuration()
    {
        return this.duration;
    }

    public int GetFrameCount()
    {
        int num;
        int num2;
        num = 0;
        num2 = 0;
        goto Label_001D;
    Label_0009:
        num += this.clips[num2].GetFramesDisplayed();
        num2 += 1;
    Label_001D:
        if (num2 < ((int) this.clips.Length))
        {
            goto Label_0009;
        }
        return num;
    }

    public bool GetNextFrame(ref SPRITE_FRAME nextFrame)
    {
        if (((int) this.clips.Length) >= 1)
        {
            goto Label_0010;
        }
        return 0;
    Label_0010:
        this.ret = this.clips[this.curClip].GetNextFrame(nextFrame);
        if (this.ret != null)
        {
            goto Label_0250;
        }
        if ((this.curClip + this.stepDir) >= ((int) this.clips.Length))
        {
            goto Label_0061;
        }
        if ((this.curClip + this.stepDir) >= 0)
        {
            goto Label_01D0;
        }
    Label_0061:
        if (this.stepDir <= 0)
        {
            goto Label_00EB;
        }
        if (this.loopReverse == null)
        {
            goto Label_00EB;
        }
        this.stepDir = -1;
        this.curClip += this.stepDir;
        this.curClip = Mathf.Clamp(this.curClip, 0, ((int) this.clips.Length) - 1);
        this.clips[this.curClip].Reset();
        this.clips[this.curClip].PlayInReverse();
        this.clips[this.curClip].GetNextFrame(nextFrame);
        goto Label_01CB;
    Label_00EB:
        if ((this.numLoops + 1) <= this.loopCycles)
        {
            goto Label_010C;
        }
        if (this.loopCycles == -1)
        {
            goto Label_010C;
        }
        return 0;
    Label_010C:
        this.numLoops += 1;
        if (this.loopReverse == null)
        {
            goto Label_01AB;
        }
        this.stepDir *= -1;
        this.curClip += this.stepDir;
        this.curClip = Mathf.Clamp(this.curClip, 0, ((int) this.clips.Length) - 1);
        this.clips[this.curClip].Reset();
        if (this.stepDir >= 0)
        {
            goto Label_0192;
        }
        this.clips[this.curClip].PlayInReverse();
    Label_0192:
        this.clips[this.curClip].GetNextFrame(nextFrame);
        goto Label_01CB;
    Label_01AB:
        this.curClip = 0;
        this.framePos = -1;
        this.clips[this.curClip].Reset();
    Label_01CB:
        goto Label_0227;
    Label_01D0:
        this.curClip += this.stepDir;
        this.clips[this.curClip].Reset();
        if (this.stepDir >= 0)
        {
            goto Label_0227;
        }
        this.clips[this.curClip].PlayInReverse();
        this.clips[this.curClip].GetNextFrame(nextFrame);
    Label_0227:
        this.framePos += this.stepDir;
        this.clips[this.curClip].GetNextFrame(nextFrame);
        return 1;
    Label_0250:
        this.framePos += this.stepDir;
        return 1;
    }

    public void PlayInReverse()
    {
        this.i = 0;
        goto Label_002C;
    Label_000C:
        this.clips[this.i].PlayInReverse();
        this.i += 1;
    Label_002C:
        if (this.i < ((int) this.clips.Length))
        {
            goto Label_000C;
        }
        this.stepDir = -1;
        this.framePos = this.GetFrameCount() - 1;
        this.curClip = ((int) this.clips.Length) - 1;
        return;
    }

    public void Reset()
    {
        this.curClip = 0;
        this.stepDir = 1;
        this.numLoops = 0;
        this.framePos = -1;
        this.i = 0;
        goto Label_0048;
    Label_0028:
        this.clips[this.i].Reset();
        this.i += 1;
    Label_0048:
        if (this.i < ((int) this.clips.Length))
        {
            goto Label_0028;
        }
        return;
    }

    public void SetAnim(int index, SPRITE_FRAME[] frames)
    {
        if (index < ((int) this.clips.Length))
        {
            goto Label_000F;
        }
        return;
    Label_000F:
        this.clips[index].SetAnim(frames);
        this.CalcDuration();
        return;
    }

    public void SetAnimPosition(float pos)
    {
        int num;
        float num2;
        float num3;
        int num4;
        int num5;
        int num6;
        int num7;
        num = 0;
        num3 = pos;
        num4 = 0;
        goto Label_001F;
    Label_000B:
        num += this.clips[num4].GetFramesDisplayed();
        num4 += 1;
    Label_001F:
        if (num4 < ((int) this.clips.Length))
        {
            goto Label_000B;
        }
        if (this.loopReverse == null)
        {
            goto Label_0154;
        }
        if (pos >= 0.5f)
        {
            goto Label_00BB;
        }
        this.stepDir = 1;
        num3 *= 2f;
        num5 = 0;
        goto Label_00A7;
    Label_005A:
        num2 = (float) (this.clips[num5].GetFramesDisplayed() / num);
        if (num3 > num2)
        {
            goto Label_009D;
        }
        this.curClip = num5;
        this.clips[this.curClip].SetPosition(num3 / num2);
        this.framePos = ((int) num2) * (num - 1);
        return;
    Label_009D:
        num3 -= num2;
        num5 += 1;
    Label_00A7:
        if (num5 < ((int) this.clips.Length))
        {
            goto Label_005A;
        }
        goto Label_014F;
    Label_00BB:
        this.stepDir = -1;
        num3 = (num3 - 0.5f) / 0.5f;
        num6 = ((int) this.clips.Length) - 1;
        goto Label_0147;
    Label_00E1:
        num2 = (float) (this.clips[num6].GetFramesDisplayed() / num);
        if (num3 > num2)
        {
            goto Label_013D;
        }
        this.curClip = num6;
        this.clips[this.curClip].SetPosition(1f - (num3 / num2));
        this.clips[this.curClip].SetStepDir(-1);
        this.framePos = ((int) num2) * (num - 1);
        return;
    Label_013D:
        num3 -= num2;
        num6 -= 1;
    Label_0147:
        if (num6 >= 0)
        {
            goto Label_00E1;
        }
    Label_014F:
        goto Label_01B8;
    Label_0154:
        num7 = 0;
        goto Label_01A9;
    Label_015C:
        num2 = (float) (this.clips[num7].GetFramesDisplayed() / num);
        if (num3 > num2)
        {
            goto Label_019F;
        }
        this.curClip = num7;
        this.clips[this.curClip].SetPosition(num3 / num2);
        this.framePos = ((int) num2) * (num - 1);
        return;
    Label_019F:
        num3 -= num2;
        num7 += 1;
    Label_01A9:
        if (num7 < ((int) this.clips.Length))
        {
            goto Label_015C;
        }
    Label_01B8:
        return;
    }

    public void SetCurClipNum(int index)
    {
        this.curClip = index;
        return;
    }

    public void SetPosition(float pos)
    {
        float num;
        float num2;
        pos = Mathf.Clamp01(pos);
        if (this.loopCycles >= 1)
        {
            goto Label_001C;
        }
        this.SetAnimPosition(pos);
        return;
    Label_001C:
        num = 1f / (((float) this.loopCycles) + 1f);
        this.numLoops = Mathf.FloorToInt(pos / num);
        num2 = pos - (((float) this.numLoops) * num);
        this.SetAnimPosition(num2 / num);
        return;
    }

    public int StepDirection
    {
        get
        {
            return this.stepDir;
        }
        set
        {
            this.stepDir = value;
            return;
        }
    }
}

