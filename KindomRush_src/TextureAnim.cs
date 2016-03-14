using System;
using UnityEngine;

[Serializable]
public class TextureAnim
{
    [HideInInspector]
    public string[] frameGUIDs;
    [HideInInspector]
    public string[] framePaths;
    public float framerate;
    public int loopCycles;
    public bool loopReverse;
    public string name;
    public UVAnimation.ANIM_END_ACTION onAnimEnd;
    [HideInInspector]
    public CSpriteFrame[] spriteFrames;

    public TextureAnim()
    {
        this.framerate = 15f;
        base..ctor();
        this.Allocate();
        return;
    }

    public TextureAnim(string n)
    {
        this.framerate = 15f;
        base..ctor();
        this.name = n;
        this.Allocate();
        return;
    }

    public void Allocate()
    {
        bool flag;
        int num;
        flag = 0;
        if (this.framePaths != null)
        {
            goto Label_0019;
        }
        this.framePaths = new string[0];
    Label_0019:
        if (this.frameGUIDs != null)
        {
            goto Label_0030;
        }
        this.frameGUIDs = new string[0];
    Label_0030:
        if (this.spriteFrames != null)
        {
            goto Label_0042;
        }
        flag = 1;
        goto Label_0059;
    Label_0042:
        if (((int) this.spriteFrames.Length) == ((int) this.frameGUIDs.Length))
        {
            goto Label_0059;
        }
        flag = 1;
    Label_0059:
        if (flag == null)
        {
            goto Label_00A5;
        }
        this.spriteFrames = new CSpriteFrame[Mathf.Max((int) this.frameGUIDs.Length, (int) this.framePaths.Length)];
        num = 0;
        goto Label_0097;
    Label_0086:
        this.spriteFrames[num] = new CSpriteFrame();
        num += 1;
    Label_0097:
        if (num < ((int) this.spriteFrames.Length))
        {
            goto Label_0086;
        }
    Label_00A5:
        return;
    }

    public void Copy(TextureAnim a)
    {
        int num;
        this.name = a.name;
        this.loopCycles = a.loopCycles;
        this.loopReverse = a.loopReverse;
        this.framerate = a.framerate;
        this.onAnimEnd = a.onAnimEnd;
        this.framePaths = new string[(int) a.framePaths.Length];
        a.framePaths.CopyTo(this.framePaths, 0);
        this.frameGUIDs = new string[(int) a.frameGUIDs.Length];
        a.frameGUIDs.CopyTo(this.frameGUIDs, 0);
        this.spriteFrames = new CSpriteFrame[(int) a.spriteFrames.Length];
        num = 0;
        goto Label_00B9;
    Label_00A0:
        this.spriteFrames[num] = new CSpriteFrame(a.spriteFrames[num]);
        num += 1;
    Label_00B9:
        if (num < ((int) this.spriteFrames.Length))
        {
            goto Label_00A0;
        }
        return;
    }
}

