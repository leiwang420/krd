using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    protected float idleTimer;
    protected PackedSprite sprite;
    protected states state;
    protected bool wasAnimating;

    public Shooter()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.state != null)
        {
            goto Label_0011;
        }
        this.RefreshIdle();
    Label_0011:
        return;
    }

    public void PauseAnim()
    {
        this.wasAnimating = this.sprite.IsAnimating();
        this.sprite.PauseAnim();
        return;
    }

    public virtual void PlayAnim(string anim)
    {
        this.sprite.PlayAnim(anim);
        if ((anim == "fireUp") != null)
        {
            goto Label_008C;
        }
        if ((anim == "fire") != null)
        {
            goto Label_008C;
        }
        if ((anim == "binocular") != null)
        {
            goto Label_008C;
        }
        if ((anim == "binocularUp") != null)
        {
            goto Label_008C;
        }
        if ((anim == "fireSniper") != null)
        {
            goto Label_008C;
        }
        if ((anim == "fireSniperUp") != null)
        {
            goto Label_008C;
        }
        if ((anim == "fireShrapnel") != null)
        {
            goto Label_008C;
        }
        if ((anim == "fireShrapnelUp") == null)
        {
            goto Label_0093;
        }
    Label_008C:
        this.state = 1;
    Label_0093:
        return;
    }

    private void RefreshIdle()
    {
        this.idleTimer += Time.deltaTime;
        if (this.idleTimer < 3f)
        {
            goto Label_002D;
        }
        this.sprite.RevertToStatic();
    Label_002D:
        return;
    }

    public void Reset()
    {
        this.idleTimer = 0f;
        this.state = 0;
        return;
    }

    public void RevertToStatic()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void Start()
    {
        this.sprite = base.transform.GetComponent<PackedSprite>();
        this.state = 0;
        this.idleTimer = 0f;
        return;
    }

    public void StopAnim()
    {
        this.sprite.StopAnim();
        return;
    }

    public void UnpauseAnim()
    {
        if (this.wasAnimating == null)
        {
            goto Label_0016;
        }
        this.sprite.UnpauseAnim();
    Label_0016:
        return;
    }

    protected enum states
    {
        IDLE,
        FIRING
    }
}

