using System;
using UnityEngine;

public class Power : MonoBehaviour
{
    protected bool activatedThisFrame;
    protected int coolDown;
    protected int coolDownTimer;
    protected bool enabled;
    protected GUIBottom guiBottom;
    protected bool isPaused;
    protected Transform overlay;
    protected bool reloading;
    protected Transform rewardTimePrefab;
    protected PackedSprite sprite;

    public Power()
    {
        base..ctor();
        return;
    }

    protected virtual void Activate()
    {
    }

    public void CompensateTime(int lessTime)
    {
        int num;
        if (this.reloading != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (lessTime <= this.coolDown)
        {
            goto Label_0020;
        }
        lessTime = this.coolDown;
    Label_0020:
        num = lessTime / 30;
        this.ShowRewardTime(num);
        this.coolDownTimer += lessTime;
        if (this.coolDownTimer <= this.coolDown)
        {
            goto Label_0059;
        }
        this.coolDownTimer = this.coolDown - 2;
    Label_0059:
        return;
    }

    protected virtual void Deactivate()
    {
    }

    public void Deselect()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected virtual bool IsActive()
    {
        return 0;
    }

    protected void OnMouseDown()
    {
        if (this.enabled != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.reloading != null)
        {
            goto Label_005A;
        }
        if (this.IsActive() != null)
        {
            goto Label_0049;
        }
        this.activatedThisFrame = 1;
        this.Activate();
        this.sprite.PlayAnim("selected");
        GameSoundManager.PlayGUISpellSelect();
        goto Label_005A;
    Label_0049:
        this.Deactivate();
        this.sprite.RevertToStatic();
    Label_005A:
        return;
    }

    protected void OnMouseEnter()
    {
        if (this.enabled != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.reloading != null)
        {
            goto Label_003F;
        }
        if (this.IsActive() != null)
        {
            goto Label_003F;
        }
        this.sprite.PlayAnim("reload", 9);
        this.sprite.PauseAnim();
    Label_003F:
        return;
    }

    protected void OnMouseExit()
    {
        if (this.enabled != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.reloading != null)
        {
            goto Label_002D;
        }
        if (this.IsActive() != null)
        {
            goto Label_002D;
        }
        this.sprite.RevertToStatic();
    Label_002D:
        return;
    }

    public void Open()
    {
        this.enabled = 1;
        this.sprite.PlayAnim("open");
        base.Invoke("OpenEffect", 0.86f);
        return;
    }

    protected void OpenEffect()
    {
        this.sprite.PlayAnim("reload");
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    protected void Reloading()
    {
        float num;
        this.coolDownTimer += 1;
        num = 1f - (((float) this.coolDownTimer) / ((float) this.coolDown));
        this.overlay.transform.localScale = new Vector3(1f, num, 1f);
        if (this.coolDownTimer < this.coolDown)
        {
            goto Label_00B7;
        }
        GameSoundManager.PlayGUISpellRefresh();
        this.sprite.PlayAnim("reload");
        this.overlay.transform.localScale = new Vector3(1f, 1f, 1f);
        this.overlay.transform.parent.gameObject.SetActive(0);
        this.coolDownTimer = 0;
        this.reloading = 0;
    Label_00B7:
        return;
    }

    protected unsafe void ShowRewardTime(int t)
    {
        Vector3 vector;
        Transform transform;
        &vector = new Vector3(0f, 0f, -1f);
        transform = UnityEngine.Object.Instantiate(this.rewardTimePrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.GetComponent<WaveRewardTime>().SetTime(t);
        transform.GetComponent<WaveRewardTime>().Launch();
        return;
    }

    private void Start()
    {
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

