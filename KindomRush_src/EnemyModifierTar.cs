using System;
using UnityEngine;

public class EnemyModifierTar : EnemyModifier
{
    private int durationTime;
    private int durationTimeCounter;
    private int maxDamageReduce;
    private int minDamageReduce;

    public EnemyModifierTar()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.durationTimeCounter += 1;
        if (this.durationTimeCounter < this.durationTime)
        {
            goto Label_004D;
        }
        base.target.speed *= 2f;
        UnityEngine.Object.Destroy(this);
    Label_004D:
        return;
    }

    public override void ResetToLevel(int lvl)
    {
        base.level = lvl;
        this.SetProperties();
        return;
    }

    protected void SetProperties()
    {
        this.durationTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "tarDurationBuffTime", 1)) * 30;
        this.durationTimeCounter = 0;
        return;
    }

    private void Start()
    {
        this.SetProperties();
        base.target = base.GetComponent<Creep>();
        base.target.speed /= 2f;
        return;
    }
}

