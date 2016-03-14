using System;
using UnityEngine;

public class DecoFogContainerAnimation : MonoBehaviour
{
    private int currentAnim;
    private PackedSprite fog1;
    private PackedSprite fog2;

    public DecoFogContainerAnimation()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        this.fog1 = base.transform.FindChild("Fog1").GetComponent<PackedSprite>();
        this.fog2 = base.transform.FindChild("Fog2").GetComponent<PackedSprite>();
        this.currentAnim = 1;
        this.fog2.Hide(1);
        this.fog1.Hide(0);
        this.fog1.PlayAnim(0);
        return;
    }

    public void SwitchAnim()
    {
        if (this.currentAnim != 1)
        {
            goto Label_003C;
        }
        this.fog1.Hide(1);
        this.fog2.Hide(0);
        this.fog2.PlayAnim(0);
        this.currentAnim = 2;
        goto Label_0073;
    Label_003C:
        if (this.currentAnim != 2)
        {
            goto Label_0073;
        }
        this.fog2.Hide(1);
        this.fog1.Hide(0);
        this.fog1.PlayAnim(0);
        this.currentAnim = 1;
    Label_0073:
        return;
    }
}

