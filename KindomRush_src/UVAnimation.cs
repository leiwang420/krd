using System;
using UnityEngine;

[Serializable]
public class UVAnimation
{
    protected int curFrame;
    [HideInInspector]
    public float framerate;
    protected SPRITE_FRAME[] frames;
    [HideInInspector]
    public int index;
    protected float length;
    public int loopCycles;
    public bool loopReverse;
    public string name;
    protected int numLoops;
    [HideInInspector]
    public ANIM_END_ACTION onAnimEnd;
    protected bool playInReverse;
    protected int stepDir;

    public UVAnimation()
    {
        this.curFrame = -1;
        this.stepDir = 1;
        this.framerate = 15f;
        this.index = -1;
        base..ctor();
        this.frames = new SPRITE_FRAME[0];
        return;
    }

    public UVAnimation(UVAnimation anim)
    {
        this.curFrame = -1;
        this.stepDir = 1;
        this.framerate = 15f;
        this.index = -1;
        base..ctor();
        this.frames = new SPRITE_FRAME[(int) anim.frames.Length];
        anim.frames.CopyTo(this.frames, 0);
        this.name = anim.name;
        this.loopCycles = anim.loopCycles;
        this.loopReverse = anim.loopReverse;
        this.framerate = anim.framerate;
        this.onAnimEnd = anim.onAnimEnd;
        this.curFrame = anim.curFrame;
        this.stepDir = anim.stepDir;
        this.numLoops = anim.numLoops;
        this.playInReverse = anim.playInReverse;
        this.length = anim.length;
        this.CalcLength();
        return;
    }

    public void AppendAnim(SPRITE_FRAME[] anim)
    {
        SPRITE_FRAME[] sprite_frameArray;
        sprite_frameArray = this.frames;
        this.frames = new SPRITE_FRAME[((int) this.frames.Length) + ((int) anim.Length)];
        sprite_frameArray.CopyTo(this.frames, 0);
        anim.CopyTo(this.frames, (int) sprite_frameArray.Length);
        this.CalcLength();
        return;
    }

    public unsafe SPRITE_FRAME[] BuildUVAnim(Vector2 start, Vector2 cellSize, int cols, int rows, int totalCells)
    {
        int num;
        int num2;
        int num3;
        num = 0;
        this.frames = new SPRITE_FRAME[totalCells];
        *(&(this.frames[0])) = new SPRITE_FRAME(0f);
        &&(this.frames[0]).uvs.x = &start.x;
        &&(this.frames[0]).uvs.y = &start.y;
        &&(this.frames[0]).uvs.xMax = &start.x + &cellSize.x;
        &&(this.frames[0]).uvs.yMax = &start.y + &cellSize.y;
        num2 = 0;
        goto Label_01AA;
    Label_00B5:
        num3 = 0;
        goto Label_0197;
    Label_00BC:
        *(&(this.frames[num])) = new SPRITE_FRAME(0f);
        &&(this.frames[num]).uvs.x = &start.x + (&cellSize.x * ((float) num3));
        &&(this.frames[num]).uvs.y = &start.y - (&cellSize.y * ((float) num2));
        &&(this.frames[num]).uvs.xMax = &&(this.frames[num]).uvs.x + &cellSize.x;
        &&(this.frames[num]).uvs.yMax = &&(this.frames[num]).uvs.y + &cellSize.y;
        num += 1;
        num3 += 1;
    Label_0197:
        if (num3 >= cols)
        {
            goto Label_01A6;
        }
        if (num < totalCells)
        {
            goto Label_00BC;
        }
    Label_01A6:
        num2 += 1;
    Label_01AA:
        if (num2 < rows)
        {
            goto Label_00B5;
        }
        this.CalcLength();
        return this.frames;
    }

    public unsafe SPRITE_FRAME[] BuildWrappedUVAnim(Vector2 start, Vector2 cellSize, int totalCells)
    {
        int num;
        Vector2 vector;
        num = 0;
        this.frames = new SPRITE_FRAME[totalCells];
        *(&(this.frames[0])) = new SPRITE_FRAME(0f);
        &&(this.frames[0]).uvs.x = &start.x;
        &&(this.frames[0]).uvs.y = &start.y;
        &&(this.frames[0]).uvs.xMax = &start.x + &cellSize.x;
        &&(this.frames[0]).uvs.yMax = &start.y + &cellSize.y;
        vector = start;
        num = 1;
        goto Label_01A8;
    Label_00B6:
        &vector.x += &cellSize.x;
        if ((&vector.x + &cellSize.x) <= 1.01f)
        {
            goto Label_0105;
        }
        &vector.x = 0f;
        &vector.y -= &cellSize.y;
    Label_0105:
        *(&(this.frames[num])) = new SPRITE_FRAME(0f);
        &&(this.frames[num]).uvs.x = &vector.x;
        &&(this.frames[num]).uvs.y = &vector.y;
        &&(this.frames[num]).uvs.xMax = &vector.x + &cellSize.x;
        &&(this.frames[num]).uvs.yMax = &vector.y + &cellSize.y;
        num += 1;
    Label_01A8:
        if (num < totalCells)
        {
            goto Label_00B6;
        }
        return this.frames;
    }

    public SPRITE_FRAME[] BuildWrappedUVAnim(Vector2 start, Vector2 cellSize, int cols, int rows, int totalCells)
    {
        return this.BuildWrappedUVAnim(start, cellSize, totalCells);
    }

    protected void CalcLength()
    {
        this.length = (1f / this.framerate) * ((float) ((int) this.frames.Length));
        return;
    }

    public UVAnimation Clone()
    {
        return new UVAnimation(this);
    }

    public int GetCurPosition()
    {
        return this.curFrame;
    }

    public unsafe SPRITE_FRAME GetCurrentFrame()
    {
        return *(&(this.frames[Mathf.Clamp(this.curFrame, 0, this.curFrame)]));
    }

    public float GetDuration()
    {
        float num;
        if (this.loopCycles >= 0)
        {
            goto Label_0012;
        }
        return -1f;
    Label_0012:
        num = this.GetLength();
        if (this.loopReverse == null)
        {
            goto Label_002C;
        }
        num *= 2f;
    Label_002C:
        return (num + (((float) this.loopCycles) * num));
    }

    public unsafe SPRITE_FRAME GetFrame(int frame)
    {
        return *(&(this.frames[frame]));
    }

    public int GetFrameCount()
    {
        return (int) this.frames.Length;
    }

    public int GetFramesDisplayed()
    {
        int num;
        if (this.loopCycles != -1)
        {
            goto Label_000E;
        }
        return -1;
    Label_000E:
        num = ((int) this.frames.Length) + (((int) this.frames.Length) * this.loopCycles);
        if (this.loopReverse == null)
        {
            goto Label_0036;
        }
        num *= 2;
    Label_0036:
        return num;
    }

    public float GetLength()
    {
        return this.length;
    }

    public unsafe bool GetNextFrame(ref SPRITE_FRAME nextFrame)
    {
        if (((int) this.frames.Length) >= 1)
        {
            goto Label_0010;
        }
        return 0;
    Label_0010:
        if ((this.curFrame + this.stepDir) >= ((int) this.frames.Length))
        {
            goto Label_003D;
        }
        if ((this.curFrame + this.stepDir) >= 0)
        {
            goto Label_016F;
        }
    Label_003D:
        if (this.stepDir <= 0)
        {
            goto Label_00AB;
        }
        if (this.loopReverse == null)
        {
            goto Label_00AB;
        }
        this.stepDir = -1;
        this.curFrame += this.stepDir;
        this.curFrame = Mathf.Clamp(this.curFrame, 0, ((int) this.frames.Length) - 1);
        *(nextFrame) = *(&(this.frames[this.curFrame]));
        goto Label_016A;
    Label_00AB:
        if ((this.numLoops + 1) <= this.loopCycles)
        {
            goto Label_00CC;
        }
        if (this.loopCycles == -1)
        {
            goto Label_00CC;
        }
        return 0;
    Label_00CC:
        this.numLoops += 1;
        if (this.loopReverse == null)
        {
            goto Label_0127;
        }
        this.stepDir *= -1;
        this.curFrame += this.stepDir;
        this.curFrame = Mathf.Clamp(this.curFrame, 0, ((int) this.frames.Length) - 1);
        goto Label_014E;
    Label_0127:
        if (this.playInReverse == null)
        {
            goto Label_0147;
        }
        this.curFrame = ((int) this.frames.Length) - 1;
        goto Label_014E;
    Label_0147:
        this.curFrame = 0;
    Label_014E:
        *(nextFrame) = *(&(this.frames[this.curFrame]));
    Label_016A:
        goto Label_019E;
    Label_016F:
        this.curFrame += this.stepDir;
        *(nextFrame) = *(&(this.frames[this.curFrame]));
    Label_019E:
        return 1;
    }

    public void PlayInReverse()
    {
        this.stepDir = -1;
        this.curFrame = (int) this.frames.Length;
        this.numLoops = 0;
        this.playInReverse = 1;
        return;
    }

    public void Reset()
    {
        this.curFrame = -1;
        this.stepDir = 1;
        this.numLoops = 0;
        this.playInReverse = 0;
        return;
    }

    public void SetAnim(SPRITE_FRAME[] anim)
    {
        this.frames = anim;
        this.CalcLength();
        return;
    }

    public unsafe void SetAnim(TextureAnim anim, int idx)
    {
        int num;
        Exception exception;
        if (anim != null)
        {
            goto Label_0007;
        }
        return;
    Label_0007:
        if (anim.spriteFrames != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        this.frames = new SPRITE_FRAME[(int) anim.spriteFrames.Length];
        this.index = idx;
        this.name = anim.name;
        this.loopCycles = anim.loopCycles;
        this.loopReverse = anim.loopReverse;
        this.framerate = anim.framerate;
        this.onAnimEnd = anim.onAnimEnd;
    Label_0069:
        try
        {
            num = 0;
            goto Label_0092;
        Label_0070:
            *(&(this.frames[num])) = anim.spriteFrames[num].ToStruct();
            num += 1;
        Label_0092:
            if (num < ((int) this.frames.Length))
            {
                goto Label_0070;
            }
            goto Label_00C0;
        }
        catch (Exception exception1)
        {
        Label_00A5:
            exception = exception1;
            Debug.LogError("Exception caught in UVAnimation.SetAnim(). Make sure you have re-built your atlases!\nException: " + exception.Message);
            goto Label_00C0;
        }
    Label_00C0:
        this.CalcLength();
        return;
    }

    public void SetClipPosition(float pos)
    {
        this.curFrame = (int) ((((float) ((int) this.frames.Length)) - 1f) * pos);
        return;
    }

    public void SetCurrentFrame(int f)
    {
        f = Mathf.Clamp(f, -1, ((int) this.frames.Length) + 1);
        this.curFrame = f;
        return;
    }

    public void SetPosition(float pos)
    {
        float num;
        float num2;
        float num3;
        pos = Mathf.Clamp01(pos);
        if (this.loopCycles >= 1)
        {
            goto Label_001C;
        }
        this.SetClipPosition(pos);
        return;
    Label_001C:
        num = 1f / (((float) this.loopCycles) + 1f);
        this.numLoops = Mathf.FloorToInt(pos / num);
        num2 = pos - (((float) this.numLoops) * num);
        num3 = num2 / num;
        if (this.loopReverse == null)
        {
            goto Label_00C9;
        }
        if (num3 >= 0.5f)
        {
            goto Label_008E;
        }
        this.curFrame = (int) ((((float) ((int) this.frames.Length)) - 1f) * (num3 / 0.5f));
        this.stepDir = 1;
        goto Label_00C4;
    Label_008E:
        this.curFrame = (((int) this.frames.Length) - 1) - ((int) ((((float) ((int) this.frames.Length)) - 1f) * ((num3 - 0.5f) / 0.5f)));
        this.stepDir = -1;
    Label_00C4:
        goto Label_00E1;
    Label_00C9:
        this.curFrame = (int) ((((float) ((int) this.frames.Length)) - 1f) * num3);
    Label_00E1:
        return;
    }

    public void SetStepDir(int dir)
    {
        if (dir >= 0)
        {
            goto Label_001A;
        }
        this.stepDir = -1;
        this.playInReverse = 1;
        goto Label_0021;
    Label_001A:
        this.stepDir = 1;
    Label_0021:
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
            this.SetStepDir(value);
            return;
        }
    }

    public enum ANIM_END_ACTION
    {
        Do_Nothing,
        Revert_To_Static,
        Play_Default_Anim,
        Hide,
        Deactivate,
        Destroy
    }
}

