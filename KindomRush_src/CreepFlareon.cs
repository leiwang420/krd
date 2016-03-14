using System;
using System.Collections;
using UnityEngine;

public class CreepFlareon : CreepDemon
{
    public Transform arrowPrefab;
    protected Vector3 destinyPoint;
    public int flareChargeTime;
    protected int flareChargeTimeCounter;
    public int flareFireDamage;
    public int flareFireDuration;
    public int flareFireReloadTime;
    public int flareMaxDamage;
    public int flareMinDamage;
    public int flareMinRange;
    public int flareRangeHeight;
    public int flareRangeWidth;
    public int flareReloadTime;
    protected int flareReloadTimeCounter;
    protected Soldier flareTarget;
    protected bool isFlaring;

    public CreepFlareon()
    {
        base..ctor();
        return;
    }

    protected virtual unsafe void FireArrow()
    {
        Transform transform;
        FlareonProjectile projectile;
        SoldierModifierFlareonFire fire;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        transform = UnityEngine.Object.Instantiate(this.arrowPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 20f, -900f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        projectile = transform.GetComponent<FlareonProjectile>();
        projectile.SetT1(15f);
        projectile.SetTarget(this.flareTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        projectile.SetDamage(this.getFlareDamage());
        projectile.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -900f);
        projectile.gameObject.AddComponent<SoldierModifierFlareonFire>().SetProperties(1);
        return;
    }

    protected int getFlareDamage()
    {
        int num;
        return Mathf.RoundToInt(((float) this.flareMinDamage) + Mathf.Ceil(UnityEngine.Random.Range(0f, 1f) * ((float) (this.flareMaxDamage - this.flareMinDamage))));
    }

    protected bool getFlareTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.flareTarget = null;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_001A:
        try
        {
            goto Label_007C;
        Label_001F:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_007C;
            }
            if (IronUtils.ellipseContainPoint(soldier.transform.position, (float) this.flareRangeHeight, (float) this.flareRangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_007C;
            }
            this.flareTarget = soldier;
            goto Label_0087;
        Label_007C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_0087:
            goto Label_009E;
        }
        finally
        {
        Label_008C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0097;
            }
        Label_0097:
            disposable.Dispose();
        }
    Label_009E:
        if ((this.flareTarget != null) == null)
        {
            goto Label_00B1;
        }
        return 1;
    Label_00B1:
        return 0;
    }

    protected override unsafe void InitCustomSettings()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.explodeRangeWidth = 170;
        base.explodeRangeHeight = Mathf.RoundToInt(((float) base.explodeRangeWidth) * 0.7f);
        base.explodeDamageTime = 5;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 10f, -780f);
        UnityEngine.Object.Instantiate(base.portalVeznan, vector, Quaternion.identity);
        this.flareChargeTime = 0x24;
        this.flareReloadTime = 90;
        this.flareRangeWidth = Mathf.RoundToInt(423f + UnityEngine.Random.Range(-98.7f, 42.3f));
        this.flareRangeHeight = Mathf.RoundToInt(((float) this.flareRangeWidth) * 0.7f);
        this.flareMinRange = Mathf.RoundToInt(70.5f);
        this.flareMinDamage = 20;
        this.flareMaxDamage = 30;
        base.attackChargeTimeCounter = 0;
        base.attackReloadTimeCounter = 0;
        base.fadingTimeCounter = 0;
        base.respawnTime = 0x23;
        return;
    }

    protected unsafe bool MinDistance(Soldier tmpSoldier)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &tmpSoldier.transform.position.x - &base.transform.position.x;
        num3 = &tmpSoldier.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.flareMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected override void RevertToStatic()
    {
        base.creepSprite.PlayAnim("idle");
        return;
    }

    protected virtual unsafe void SetDestinyPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        this.destinyPoint = new Vector2(&this.flareTarget.transform.position.x, &this.flareTarget.transform.position.y);
        return;
    }

    protected override unsafe bool SpecialPower()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.isFlaring != null)
        {
            goto Label_0124;
        }
        if (base.isBlocked == null)
        {
            goto Label_0018;
        }
        return 0;
    Label_0018:
        if (this.flareReloadTimeCounter >= this.flareReloadTime)
        {
            goto Label_0039;
        }
        this.flareReloadTimeCounter += 1;
        return 0;
    Label_0039:
        if (this.getFlareTarget() != null)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        if (&this.flareTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00B9;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00F7;
    Label_00B9:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
    Label_00F7:
        this.SetDestinyPoint();
        this.isFlaring = 1;
        base.isStopped = 1;
        this.flareChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        return 1;
    Label_0124:
        if (this.flareChargeTimeCounter >= this.flareChargeTime)
        {
            goto Label_01A1;
        }
        this.flareChargeTimeCounter += 1;
        if (this.flareChargeTimeCounter != 10)
        {
            goto Label_019F;
        }
        &vector = new Vector3(0f, 0f, 0f);
        if ((this.flareTarget == null) != null)
        {
            goto Label_0187;
        }
        if (this.flareTarget.IsActive() != null)
        {
            goto Label_0199;
        }
    Label_0187:
        if (this.getFlareTarget() != null)
        {
            goto Label_0199;
        }
        vector = this.destinyPoint;
    Label_0199:
        this.FireArrow();
    Label_019F:
        return 1;
    Label_01A1:
        this.isFlaring = 0;
        this.flareReloadTimeCounter = 0;
        this.flareChargeTimeCounter = 0;
        base.isStopped = 0;
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_01D5;
        }
        this.CheckFacing();
    Label_01D5:
        return 0;
    }
}

