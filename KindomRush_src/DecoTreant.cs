using System;
using UnityEngine;

public class DecoTreant : MonoBehaviour
{
    private bool atA;
    private float counterIdle;
    private bool isIdle;
    private PackedSprite sprite;
    private float timeIdle;

    public DecoTreant()
    {
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        if (this.sprite.GetCurAnim() != null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        if ((this.sprite.GetCurAnim().name == "AtoB") == null)
        {
            goto Label_0068;
        }
        this.sprite.PlayAnim("idleB");
        this.isIdle = 1;
        this.timeIdle = UnityEngine.Random.Range(4f, 15f);
        this.atA = 0;
        goto Label_00B5;
    Label_0068:
        if ((this.sprite.GetCurAnim().name == "BtoA") == null)
        {
            goto Label_00B5;
        }
        this.sprite.RevertToStatic();
        this.isIdle = 1;
        this.timeIdle = UnityEngine.Random.Range(4f, 15f);
        this.atA = 1;
    Label_00B5:
        return;
    }

    private void FixedUpdate()
    {
        if (this.isIdle == null)
        {
            goto Label_0070;
        }
        this.counterIdle += Time.deltaTime;
        if (this.counterIdle < this.timeIdle)
        {
            goto Label_0070;
        }
        this.isIdle = 0;
        this.counterIdle = 0f;
        if (this.atA == null)
        {
            goto Label_0060;
        }
        this.sprite.PlayAnim("AtoB");
        goto Label_0070;
    Label_0060:
        this.sprite.PlayAnim("BtoA");
    Label_0070:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        this.timeIdle = UnityEngine.Random.Range(4f, 15f);
        this.isIdle = 1;
        this.atA = 1;
        return;
    }
}

