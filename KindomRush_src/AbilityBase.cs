using System;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    protected float chance;
    protected int damage;
    protected float duration;
    protected bool isPaused;
    protected int level;
    public int maxLevel;
    protected float reload;
    protected TowerBase tower;

    public AbilityBase()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
    }

    public int GetLevel()
    {
        return this.level;
    }

    public bool IsMaxLevel()
    {
        return (this.level == this.maxLevel);
    }

    public virtual void LevelUp()
    {
        this.level += 1;
        return;
    }

    public virtual void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void Start()
    {
    }

    public virtual void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

