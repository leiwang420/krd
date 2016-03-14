using System;
using UnityEngine;

public class BlackburnBlock : MonoBehaviour
{
    protected float holdTime;
    protected float holdTimeCounter;
    protected bool isHolding;
    protected bool isPaused;
    protected bool isStarting;
    protected PackedSprite sprite;
    protected float startTime;
    protected float startTimeCounter;
    protected TowerBase tower;

    public BlackburnBlock()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        float num;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if ((this.tower == null) == null)
        {
            goto Label_001D;
        }
    Label_001D:
        num = Time.deltaTime;
        if (this.isStarting == null)
        {
            goto Label_0075;
        }
        this.startTimeCounter += num;
        if (this.startTimeCounter < this.startTime)
        {
            goto Label_00C8;
        }
        this.isHolding = 1;
        this.isStarting = 0;
        this.sprite.PlayAnim("startEnd");
        GameSoundManager.PlayVeznanHoldTrap();
        goto Label_00C8;
    Label_0075:
        if (this.isHolding == null)
        {
            goto Label_00C8;
        }
        this.holdTimeCounter += num;
        if (this.holdTimeCounter < this.holdTime)
        {
            goto Label_00C8;
        }
        this.isHolding = 0;
        this.sprite.PlayAnim("release");
        GameSoundManager.PlayVeznanHoldDissipate();
        this.tower.SetActive(1, 1);
    Label_00C8:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.sprite.PauseAnim();
        return;
    }

    public void SetTower(TowerBase t)
    {
        this.tower = t;
        this.tower.SetActive(0, 0);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.startTime = 1.1f;
        this.holdTime = 6f;
        this.sprite.PlayAnim("start");
        this.isStarting = 1;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.sprite.UnpauseAnim();
        return;
    }
}

