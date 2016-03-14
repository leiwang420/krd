using System;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Creep creepComp;
    private bool isPaused;
    private PackedSprite sprite;

    public Skeleton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.sprite.IsAnimating() != null)
        {
            goto Label_0039;
        }
        this.creepComp.enabled = 1;
        this.creepComp.CheckFacing();
        UnityEngine.Object.Destroy(this);
    Label_0039:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.sprite.PauseAnim();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.creepComp = base.GetComponent<Creep>();
        this.creepComp.InitSprite();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.sprite.UnpauseAnim();
        return;
    }
}

