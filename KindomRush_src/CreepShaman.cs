using System;
using System.Collections;
using UnityEngine;

public class CreepShaman : Creep
{
    private float healCoolDown;
    private int healMaxEnemies;
    private int healPoints;
    private int healRange;

    public CreepShaman()
    {
        this.healMaxEnemies = 3;
        this.healCoolDown = 8f;
        this.healRange = 0x10c;
        this.healPoints = 50;
        base..ctor();
        return;
    }

    protected override bool CanDoSpecial()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        bool flag;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_008A;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_008A;
            }
            if (creep.GetHealth() >= creep.GetTotalLife())
            {
                goto Label_008A;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) base.basicRangeHeight, (float) base.basicRangeWidth, base.transform.position) == null)
            {
                goto Label_008A;
            }
            base.creepSprite.PlayAnim("special");
            flag = 1;
            goto Label_00B1;
        Label_008A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_00AF;
        }
        finally
        {
        Label_009A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A7;
            }
        Label_00A7:
            disposable.Dispose();
        }
    Label_00AF:
        return 0;
    Label_00B1:
        return flag;
    }

    protected override void DoSpecial()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0096;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0096;
            }
            if (creep.GetHealth() >= creep.GetTotalLife())
            {
                goto Label_0096;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) base.basicRangeHeight, (float) base.basicRangeWidth, base.transform.position) == null)
            {
                goto Label_0096;
            }
            creep.Heal(this.healPoints);
            num += 1;
            if (num != this.healMaxEnemies)
            {
                goto Label_0096;
            }
            goto Label_00BB;
        Label_0096:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00BB;
        }
        finally
        {
        Label_00A6:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B3;
            }
        Label_00B3:
            disposable.Dispose();
        }
    Label_00BB:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.hasBasicSpecialAction = 1;
        base.basicCooldownTime = Mathf.RoundToInt(this.healCoolDown * 30f);
        base.basicAnimationTime = 0x1c;
        base.basicAnimationStartTime = 14;
        base.basicAnimationTimeCounter = 0;
        base.basicCoolddownTimeCounter = 0;
        base.basicRangeWidth = this.healRange;
        base.basicRangeHeight = Mathf.RoundToInt(((float) this.healRange) * 0.7f);
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }

    protected override void PlaySpecialSound()
    {
        GameSoundManager.PlayEnemyHealing();
        return;
    }
}

