using System;
using UnityEngine;

public class EnemyModifierStun : EnemyModifier
{
    public int durationTime;
    private int durationTimeCounter;

    public EnemyModifierStun()
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
            goto Label_0041;
        }
        base.target.EndStun();
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0041:
        return;
    }

    public override void ResetToLevel(int l)
    {
        base.level = l;
        this.SetProperties();
        return;
    }

    public void SetLevel(int l)
    {
        base.level = l;
        this.SetProperties();
        return;
    }

    public void SetProperties()
    {
        this.durationTime = ((int) GameSettings.GetHeroSetting("hero_hammer", "fissureStuntDurationTime", 1)) * 30;
        this.durationTimeCounter = 0;
        return;
    }

    private void Start()
    {
        base.target = base.transform.parent.GetComponent<Creep>();
        this.SetProperties();
        return;
    }
}

