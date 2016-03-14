using System;
using UnityEngine;

public class DecoSquirrel : MonoBehaviour
{
    private float counterIdleTime;
    private float idleTime;
    private bool inactive;
    private PackedSprite sprite;

    public DecoSquirrel()
    {
        base..ctor();
        return;
    }

    private void AnimNut()
    {
        this.sprite.PlayAnim("nut");
        GameAchievements.AcornFound();
        return;
    }

    public void CatchNut()
    {
        base.Invoke("AnimNut", 1.8f);
        this.inactive = 1;
        return;
    }

    private void FixedUpdate()
    {
        if (this.inactive == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.counterIdleTime += Time.deltaTime;
        if (this.counterIdleTime < this.idleTime)
        {
            goto Label_0050;
        }
        this.counterIdleTime = 0f;
        this.SetRandomIdleTime();
        this.sprite.PlayAnim("jump");
    Label_0050:
        return;
    }

    private void SetRandomIdleTime()
    {
        this.idleTime = UnityEngine.Random.Range(2f, 5f);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.SetRandomIdleTime();
        return;
    }
}

