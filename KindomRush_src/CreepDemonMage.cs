using System;
using System.Collections;
using UnityEngine;

public class CreepDemonMage : CreepDemon
{
    protected int shieldMaxEnemies;

    public CreepDemonMage()
    {
        base..ctor();
        return;
    }

    protected override bool CanDoSpecial()
    {
        Transform transform;
        IEnumerator enumerator;
        CreepDemon demon;
        bool flag;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0081;
        Label_0016:
            transform = (Transform) enumerator.Current;
            demon = transform.GetComponent<CreepDemon>();
            if ((demon != null) == null)
            {
                goto Label_0081;
            }
            if ((demon != this) == null)
            {
                goto Label_0081;
            }
            if (demon.IsActive() == null)
            {
                goto Label_0081;
            }
            if (IronUtils.ellipseContainPoint(demon.transform.position, (float) base.basicRangeHeight, (float) base.basicRangeWidth, base.transform.position) == null)
            {
                goto Label_0081;
            }
            flag = 1;
            goto Label_00A8;
        Label_0081:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_00A6;
        }
        finally
        {
        Label_0091:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_009E;
            }
        Label_009E:
            disposable.Dispose();
        }
    Label_00A6:
        return 0;
    Label_00A8:
        return flag;
    }

    protected override void DoSpecial()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        CreepDemon demon;
        IDisposable disposable;
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_009C;
        Label_0018:
            transform = (Transform) enumerator.Current;
            demon = transform.GetComponent<CreepDemon>();
            if ((demon != null) == null)
            {
                goto Label_009C;
            }
            if ((demon.GetComponent<CreepDemonMage>() == null) == null)
            {
                goto Label_009C;
            }
            if (demon.IsActive() == null)
            {
                goto Label_009C;
            }
            if (IronUtils.ellipseContainPoint(demon.transform.position, (float) base.basicRangeHeight, (float) base.basicRangeWidth, base.transform.position) == null)
            {
                goto Label_009C;
            }
            demon.ShieldMe();
            num += 1;
            if (num != this.shieldMaxEnemies)
            {
                goto Label_009C;
            }
            goto Label_00C8;
        Label_009C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00C1;
        }
        finally
        {
        Label_00AC:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B9;
            }
        Label_00B9:
            disposable.Dispose();
        }
    Label_00C1:
        base.facing = -1;
    Label_00C8:
        return;
    }

    protected override unsafe void InitCustomSettings()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.explodeRangeWidth = 170;
        base.explodeRangeHeight = Mathf.RoundToInt(((float) base.explodeRangeWidth) * 0.7f);
        base.explodeDamageTime = 5;
        base.hasBasicSpecialAction = 1;
        base.basicCooldownTime = 180;
        base.basicAnimationTime = 0x18;
        base.basicAnimationStartTime = 15;
        base.basicAnimationTimeCounter = 0;
        base.basicCoolddownTimeCounter = 0;
        base.basicRangeWidth = 0x1fc;
        base.basicRangeHeight = Mathf.RoundToInt(((float) base.basicRangeWidth) * 0.7f);
        this.shieldMaxEnemies = 4;
        if (base.teleportingIn == null)
        {
            goto Label_00F7;
        }
        GameSoundManager.PlayVeznanPortalIn();
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, -100f);
        UnityEngine.Object.Instantiate(base.portalVeznan, base.transform.position, Quaternion.identity);
    Label_00F7:
        return;
    }

    protected override void PlaySpecial()
    {
        base.creepSprite.PlayAnim("special");
        return;
    }

    protected override void PlaySpecialSound()
    {
        GameSoundManager.PlayEnemyHealing();
        return;
    }
}

