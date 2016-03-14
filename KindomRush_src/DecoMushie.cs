using System;
using UnityEngine;

public class DecoMushie : MonoBehaviour
{
    private PackedSprite sprite;
    //private Stage19 stage;

    public DecoMushie()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim(0);
        GameSoundManager.PlayDeathPuff();
        this.stage.PopMushroom();
        base.collider.enabled = 0;
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<Stage19>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

