using System;
using UnityEngine;

public class DecoIceNut : MonoBehaviour
{
    private int counterClicks;
    private bool inactive;
    private PackedSprite sprite;
    private PackedSprite spriteClickEffect;
    private DecoSquirrel squirrel;
    private int totalClicks;

    public DecoIceNut()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        if (this.inactive == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.counterClicks += 1;
        if (this.counterClicks != this.totalClicks)
        {
            goto Label_004E;
        }
        this.sprite.PlayAnim(0);
        this.squirrel.CatchNut();
        this.inactive = 1;
        goto Label_0076;
    Label_004E:
        if (this.spriteClickEffect.IsAnimating() != null)
        {
            goto Label_0076;
        }
        this.spriteClickEffect.Hide(0);
        this.spriteClickEffect.PlayAnim(0);
    Label_0076:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.spriteClickEffect = base.transform.FindChild("EffectClick").GetComponent<PackedSprite>();
        this.squirrel = base.transform.FindChild("Squirrel").GetComponent<DecoSquirrel>();
        this.totalClicks = UnityEngine.Random.Range(7, 11);
        return;
    }
}

