using System;
using UnityEngine;

public class EnemyModifierRocketeer : EnemyModifier
{
    private bool isPaused;
    private float originalSpeed;
    private Creep target;

    public EnemyModifierRocketeer()
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
        base.durationTimer += 1f;
        if (base.durationTimer < base.duration)
        {
            goto Label_0061;
        }
        this.target.speed = this.originalSpeed;
        ((CreepRocketeer) this.target).StopRampage();
        this.target.CheckFacing();
        UnityEngine.Object.Destroy(this);
    Label_0061:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void Start()
    {
        this.target = base.GetComponent<CreepRocketeer>();
        this.originalSpeed = this.target.speed;
        this.target.speed = 7.2f;
        base.duration = 60f;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

