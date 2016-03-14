using System;
using System.Collections;
using UnityEngine;

public class CreepGulthak : Creep
{
    protected int healMaxEnemies;
    protected int healPoints;

    public CreepGulthak()
    {
        base..ctor();
        return;
    }

    public override unsafe void Block(Soldier mySoldier)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.soldier = mySoldier;
        base.isBlocked = 1;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        if (base.isBasicSpecial != null)
        {
            goto Label_0077;
        }
        base.creepSprite.RevertToStatic();
    Label_0077:
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
            goto Label_008B;
        Label_0016:
            transform = (Transform) enumerator.Current;
            if ((transform != base.transform) == null)
            {
                goto Label_008B;
            }
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_008B;
            }
            if (creep.GetHealth() >= creep.GetTotalLife())
            {
                goto Label_008B;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) base.basicRangeHeight, (float) base.basicRangeWidth, base.transform.position) == null)
            {
                goto Label_008B;
            }
            flag = 1;
            goto Label_00B2;
        Label_008B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_00B0;
        }
        finally
        {
        Label_009B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A8;
            }
        Label_00A8:
            disposable.Dispose();
        }
    Label_00B0:
        return 0;
    Label_00B2:
        return flag;
    }

    protected void DoSpecial()
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
            goto Label_00A7;
        Label_0018:
            transform = (Transform) enumerator.Current;
            if ((transform != base.transform) == null)
            {
                goto Label_00A7;
            }
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00A7;
            }
            if (creep.GetHealth() >= creep.GetTotalLife())
            {
                goto Label_00A7;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) base.basicRangeHeight, (float) base.basicRangeWidth, base.transform.position) == null)
            {
                goto Label_00A7;
            }
            creep.Heal(this.healPoints);
            num += 1;
            if (num != this.healMaxEnemies)
            {
                goto Label_00A7;
            }
            goto Label_00CC;
        Label_00A7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00CC;
        }
        finally
        {
        Label_00B7:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C4;
            }
        Label_00C4:
            disposable.Dispose();
        }
    Label_00CC:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.hasBasicSpecialAction = 1;
        base.basicCooldownTime = 240;
        base.basicAnimationTime = 0x23;
        base.basicAnimationStartTime = 14;
        base.basicAnimationTimeCounter = 0;
        base.basicCoolddownTimeCounter = 0;
        base.basicRangeWidth = 0x386;
        base.basicRangeHeight = Mathf.RoundToInt(((float) base.basicRangeWidth) * 0.7f);
        this.healMaxEnemies = 20;
        this.healPoints = 200;
        GameData.notificationEnemyGulThak = 1;
        base.stage.PlayMusicBossFight();
        return;
    }

    protected override void PlaySpecialSound()
    {
        GameSoundManager.PlayEnemyHealing();
        return;
    }

    public override unsafe void StartFighting()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.isFighting = 1;
        if (base.isBasicSpecial != null)
        {
            goto Label_0072;
        }
        base.facing = 4;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.ChargeAttack();
    Label_0072:
        return;
    }
}

