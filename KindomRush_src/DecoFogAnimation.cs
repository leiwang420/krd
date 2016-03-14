using System;
using UnityEngine;

public class DecoFogAnimation : MonoBehaviour
{
    private DecoFogContainerAnimation container;

    public DecoFogAnimation()
    {
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        this.container.SwitchAnim();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        this.container = base.transform.parent.GetComponent<DecoFogContainerAnimation>();
        base.GetComponent<PackedSprite>().SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        return;
    }
}

