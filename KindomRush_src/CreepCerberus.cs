using System;
using System.Collections;
using UnityEngine;

public class CreepCerberus : CreepDemon
{
    public bool isSleep;

    public CreepCerberus()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        if (base.attackIsDodged == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.areaAttackPoint = this.GetAttackPoint();
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_002B:
        try
        {
            goto Label_0060;
        Label_0030:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0060;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0060;
            }
            soldier.SetDamage(base.GetDamage(), 0);
        Label_0060:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0030;
            }
            goto Label_0082;
        }
        finally
        {
        Label_0070:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007B;
            }
        Label_007B:
            disposable.Dispose();
        }
    Label_0082:
        return;
    }

    public void EndSleep()
    {
        CreepSpawner spawner;
        base.path = base.stage.GetPath();
        base.active = 1;
        this.isSleep = 0;
        base.isRespawning = 1;
        base.respawnTime = 0x3a;
        base.respawnTimeCounter = 0;
        base.mainBar.gameObject.SetActive(1);
        spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.parent = spawner.transform;
        base.mainBar.gameObject.SetActive(1);
        base.creepSprite.PlayAnim("respawn");
        return;
    }

    protected override void FixedUpdate()
    {
        if (this.isSleep == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.FixedUpdate();
        return;
    }

    protected override unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_005B;
        }
        return new Vector2(&base.transform.position.x + 28f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 28f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected override unsafe void InitCustomSettings()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.isBoss = 1;
        base.areaAttackRangeWidth = 180;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        base.explodeRangeWidth = 0x152;
        base.explodeRangeHeight = Mathf.RoundToInt(((float) base.explodeRangeWidth) * 0.7f);
        base.explodeDamageTime = 5;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 10f, -780f);
        UnityEngine.Object.Instantiate(base.portalVeznan, vector, Quaternion.identity);
        if (this.isSleep == null)
        {
            goto Label_00EE;
        }
        base.creepSprite.PlayAnim("sleep");
        base.mainBar.gameObject.SetActive(0);
        base.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00EE:
        return;
    }

    protected bool OnRange(Soldier mySoldier)
    {
        if ((mySoldier == null) == null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, base.areaAttackPoint);
    }
}

