using System;
using UnityEngine;

public class SoldierModifier : MonoBehaviour
{
    protected float duration;
    protected float durationTimer;
    protected bool isPaused;
    protected int level;
    protected Soldier target;

    public SoldierModifier()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public int GetLevel()
    {
        return this.level;
    }

    public bool IsActive()
    {
        return (this.durationTimer < this.duration);
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public virtual void ResetToLevel(int lvl)
    {
    }

    public virtual void SetProperties(int level)
    {
    }

    public void SetTarget()
    {
        this.target = base.transform.parent.GetComponent("Soldier") as Soldier;
        return;
    }

    public virtual void Show()
    {
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

