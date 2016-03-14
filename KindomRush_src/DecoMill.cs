using System;
using UnityEngine;

public class DecoMill : MonoBehaviour
{
    private PackedSprite sprite;

    public DecoMill()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        if (this.sprite.IsAnimating() == null)
        {
            goto Label_0020;
        }
        this.sprite.PauseAnim();
        goto Label_002B;
    Label_0020:
        this.sprite.UnpauseAnim();
    Label_002B:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

