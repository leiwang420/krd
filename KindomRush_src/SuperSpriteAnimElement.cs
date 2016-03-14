using System;
using UnityEngine;

[Serializable]
public class SuperSpriteAnimElement
{
    [HideInInspector]
    public UVAnimation anim;
    public string animName;
    public AutoSpriteBase sprite;

    public SuperSpriteAnimElement()
    {
        base..ctor();
        return;
    }

    public void Init()
    {
        string[] textArray1;
        bool flag;
        flag = 0;
        if ((this.sprite != null) == null)
        {
            goto Label_00B3;
        }
        if (this.sprite.gameObject.activeInHierarchy != null)
        {
            goto Label_003B;
        }
        flag = 1;
        this.sprite.gameObject.SetActive(1);
    Label_003B:
        this.anim = this.sprite.GetAnim(this.animName);
        if (this.anim != null)
        {
            goto Label_009C;
        }
        textArray1 = new string[] { "SuperSprite error: No animation by the name of \"", this.animName, "\" was found on sprite \"", this.sprite.name, "\". Please verify the spelling and capitalization of the name, including any extra spaces, etc." };
        Debug.LogError(string.Concat(textArray1));
    Label_009C:
        if (flag == null)
        {
            goto Label_00B3;
        }
        this.sprite.gameObject.SetActive(0);
    Label_00B3:
        return;
    }

    public void Play()
    {
        this.sprite.PlayAnim(this.anim);
        return;
    }

    public void PlayInReverse()
    {
        this.sprite.PlayAnimInReverse(this.anim);
        return;
    }
}

