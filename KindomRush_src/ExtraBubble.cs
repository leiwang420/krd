using System;
using UnityEngine;

public class ExtraBubble : MonoBehaviour
{
    protected bool isPaused;
    protected int jumpTime;
    protected int jumpTimeCurrent;
    protected PackedSprite sprite;

    public ExtraBubble()
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
        this.jumpTimeCurrent += 1;
        if (this.jumpTimeCurrent < this.jumpTime)
        {
            goto Label_0051;
        }
        this.jumpTimeCurrent = 0;
        this.sprite.Hide(0);
        this.sprite.PlayAnim(0);
        this.jumpTimeCurrent = 0;
    Label_0051:
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
        this.jumpTime = UnityEngine.Random.Range(150, 400);
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0059;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_0059:
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.sprite.UnpauseAnim();
        return;
    }
}

