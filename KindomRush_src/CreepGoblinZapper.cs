using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepGoblinZapper : Creep
{
    public Transform bombPrefab;
    protected Vector2 destinyPoint;
    protected bool exploded;
    protected int explodeDamageTime;
    protected int explodeMaxDamage;
    protected int explodeMinDamage;
    protected int explodeRangeHeight;
    protected int explodeRangeWidth;
    protected bool isThrowing;
    protected int throwChargeTime;
    protected int throwChargeTimeCounter;
    protected int throwMaxDamage;
    protected int throwMinDamage;
    protected int throwMinRange;
    protected bool throwOnTarget;
    protected int throwRangeHeight;
    protected int throwRangeWidth;
    protected int throwReloadTime;
    protected int throwReloadTimeCounter;
    protected Soldier throwTarget;

    public CreepGoblinZapper()
    {
        base..ctor();
        return;
    }

    public void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        this.isThrowing = 0;
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (damageType == null)
        {
            goto Label_0021;
        }
        base.life -= this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002F;
    Label_0021:
        base.life -= dmg;
    Label_002F:
        if (base.life >= 0)
        {
            goto Label_0064;
        }
        if (this.exploded != null)
        {
            goto Label_0064;
        }
        this.exploded = 1;
        base.life = 0;
        base.Invoke("DemonExplodeAttack", 0.1f);
    Label_0064:
        return;
    }

    protected void DemonExplodeAttack()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0048;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0048;
            }
            if (this.OnRangeExplode(soldier) == null)
            {
                goto Label_0048;
            }
            soldier.SetDamage(this.GetDamageExplode(), 0);
        Label_0048:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_006A;
        }
        finally
        {
        Label_0058:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0063;
            }
        Label_0063:
            disposable.Dispose();
        }
    Label_006A:
        return;
    }

    protected int GetDamageExplode()
    {
        return UnityEngine.Random.Range(this.explodeMinDamage, this.explodeMaxDamage + 1);
    }

    protected int GetThrowDamage()
    {
        return UnityEngine.Random.Range(this.throwMinDamage, this.throwMaxDamage + 1);
    }

    protected bool GetThrowTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.throwTarget = null;
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
            if (IronUtils.ellipseContainPoint(soldier.transform.position, (float) this.throwRangeHeight, (float) this.throwRangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_007C;
            }
            this.throwTarget = soldier;
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
        if ((this.throwTarget != null) == null)
        {
            goto Label_00B1;
        }
        return 1;
    Label_00B1:
        return 0;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.throwReloadTime = 30;
        this.throwRangeWidth = 0x1d1 + UnityEngine.Random.Range(-70, 0x1f);
        this.throwRangeHeight = Mathf.RoundToInt(((float) this.throwRangeWidth) * 0.7f);
        this.throwMinRange = 0x55;
        this.throwMinDamage = 30;
        this.throwMaxDamage = 60;
        this.throwChargeTime = 12;
        this.explodeRangeWidth = 170;
        this.explodeRangeHeight = Mathf.RoundToInt(((float) this.explodeRangeWidth) * 0.7f);
        this.explodeMinDamage = 30;
        this.explodeMaxDamage = 60;
        this.explodeDamageTime = 5;
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
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.throwMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected bool OnRangeExplode(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) this.explodeRangeHeight, (float) this.explodeRangeWidth, base.transform.position);
    }

    protected override unsafe bool SpecialPower()
    {
        Vector2 vector;
        Transform transform;
        BombZapper zapper;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        if (this.isThrowing != null)
        {
            goto Label_01A6;
        }
        if (base.isBlocked == null)
        {
            goto Label_002A;
        }
        if (this.throwOnTarget == null)
        {
            goto Label_0028;
        }
        this.throwOnTarget = 0;
    Label_0028:
        return 0;
    Label_002A:
        if (this.throwReloadTimeCounter >= this.throwReloadTime)
        {
            goto Label_0050;
        }
        this.throwReloadTimeCounter += 1;
        return this.throwOnTarget;
    Label_0050:
        if (this.GetThrowTarget() != null)
        {
            goto Label_0083;
        }
        if (this.throwOnTarget == null)
        {
            goto Label_007A;
        }
        base.isStopped = 0;
        base.facing = 4;
        this.CheckFacing();
    Label_007A:
        this.throwOnTarget = 0;
        return 0;
    Label_0083:
        if (&this.throwTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00F7;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_0135;
    Label_00F7:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
    Label_0135:
        this.destinyPoint = new Vector2(&this.throwTarget.transform.position.x, &this.throwTarget.transform.position.y + 18f);
        this.isThrowing = 1;
        base.isStopped = 1;
        this.throwOnTarget = 1;
        this.throwChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("special");
        return 1;
    Label_01A6:
        if (this.throwChargeTimeCounter >= this.throwChargeTime)
        {
            goto Label_02FF;
        }
        this.throwChargeTimeCounter += 1;
        if (this.throwChargeTimeCounter != 7)
        {
            goto Label_02FD;
        }
        if ((this.throwTarget == null) != null)
        {
            goto Label_01F2;
        }
        if (this.throwTarget.IsActive() != null)
        {
            goto Label_024C;
        }
    Label_01F2:
        if (this.GetThrowTarget() != null)
        {
            goto Label_0209;
        }
        vector = this.destinyPoint;
        goto Label_024C;
    Label_0209:
        this.destinyPoint = new Vector2(&this.throwTarget.transform.position.x, &this.throwTarget.transform.position.y + 18f);
    Label_024C:
        transform = UnityEngine.Object.Instantiate(this.bombPrefab, new Vector3(&base.transform.position.x + 6f, &base.transform.position.y + 18f, -890f), Quaternion.identity) as Transform;
        zapper = transform.GetComponent<BombZapper>();
        zapper.SetTarget(this.throwTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        zapper.SetDamage(this.throwMinDamage, this.throwMaxDamage);
        zapper.SetArea(141f);
        zapper.SetT1(25f);
        zapper.SetStage(base.stage);
    Label_02FD:
        return 1;
    Label_02FF:
        this.isThrowing = 0;
        this.throwReloadTimeCounter = 0;
        return 1;
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        this.isThrowing = 0;
        this.throwOnTarget = 0;
        return;
    }
}

