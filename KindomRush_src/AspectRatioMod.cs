using System;
using UnityEngine;

public class AspectRatioMod : MonoBehaviour
{
    public float posX1610;
    public float posX169;
    public float posX43;
    public float posY1610;
    public float posY169;
    public float posY43;
    private const float ratio1610 = 1.6f;
    private const float ratio43 = 1.33333f;
    public bool scaleSwap;
    public float scaleX1610;
    public float scaleX169;
    public float scaleX43;
    public float scaleY1610;
    public float scaleY169;
    public float scaleY43;
    public bool textureSwap;

    public AspectRatioMod()
    {
        this.scaleX169 = 1f;
        this.scaleY169 = 1f;
        this.scaleX1610 = 1f;
        this.scaleY1610 = 1f;
        this.scaleX43 = 1f;
        this.scaleY43 = 1f;
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void Refresh(int width, int height)
    {
        float num;
        PackedSprite sprite;
        PackedSprite sprite2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        num = ((float) width) / ((float) height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_009B;
        }
        base.transform.position = new Vector3(this.posX43, this.posY43, &base.transform.position.z);
        if (this.textureSwap == null)
        {
            goto Label_006A;
        }
        sprite = base.GetComponent<PackedSprite>();
        sprite.PlayAnim(0);
        sprite.PauseAnim();
    Label_006A:
        if (this.scaleSwap == null)
        {
            goto Label_01A3;
        }
        base.transform.localScale = new Vector3(this.scaleX43, this.scaleY43, 1f);
        goto Label_01A3;
    Label_009B:
        if (Mathf.Abs(num - 1.6f) >= 0.1f)
        {
            goto Label_0131;
        }
        base.transform.position = new Vector3(this.posX1610, this.posY1610, &base.transform.position.z);
        if (this.textureSwap == null)
        {
            goto Label_0100;
        }
        sprite2 = base.GetComponent<PackedSprite>();
        sprite2.PlayAnim(1);
        sprite2.PauseAnim();
    Label_0100:
        if (this.scaleSwap == null)
        {
            goto Label_01A3;
        }
        base.transform.localScale = new Vector3(this.scaleX1610, this.scaleY1610, 1f);
        goto Label_01A3;
    Label_0131:
        base.transform.position = new Vector3(this.posX169, this.posY169, &base.transform.position.z);
        if (this.textureSwap == null)
        {
            goto Label_0177;
        }
        base.GetComponent<PackedSprite>().RevertToStatic();
    Label_0177:
        if (this.scaleSwap == null)
        {
            goto Label_01A3;
        }
        base.transform.localScale = new Vector3(this.scaleX169, this.scaleY169, 1f);
    Label_01A3:
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        this.posX169 = &base.transform.position.x;
        this.posY169 = &base.transform.position.y;
        this.Refresh(Screen.width, Screen.height);
        return;
    }
}

