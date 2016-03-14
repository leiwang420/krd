using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepDemon : Creep
{
    protected bool exploded;
    protected int explodeDamageTime;
    public int explodeMaxDamage;
    public int explodeMinDamage;
    protected int explodeRangeHeight;
    protected int explodeRangeWidth;
    protected bool isShield;
    public Transform portalVeznan;
    protected Transform shield;
    protected int shieldIgnoreHits;
    public Transform shieldPrefab;
    protected bool teleportingIn;

    public CreepDemon()
    {
        base..ctor();
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (this.isShield == null)
        {
            goto Label_0033;
        }
        if (shieldOn != null)
        {
            goto Label_0032;
        }
        this.shieldIgnoreHits -= 1;
        if (this.shieldIgnoreHits > 0)
        {
            goto Label_0032;
        }
        this.UnShieldMe();
    Label_0032:
        return;
    Label_0033:
        base.Damage(dmg, damageType, ignoreArmor, shieldOn);
        if (base.life > 0)
        {
            goto Label_0062;
        }
        if (this.exploded != null)
        {
            goto Label_0062;
        }
        this.exploded = 1;
        this.DemonExplodeAttack();
    Label_0062:
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
            goto Label_0089;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_0089;
            }
            if (soldier.transform.name.StartsWith("HeroSamurai") != null)
            {
                goto Label_0089;
            }
            if (soldier.IsDead() != null)
            {
                goto Label_0089;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_0089;
            }
            if (this.OnRangeExplode(soldier) == null)
            {
                goto Label_0089;
            }
            soldier.SetDamage(this.GetDamageExplode(), 0);
            if (soldier.IsDead() != null)
            {
                goto Label_0089;
            }
            GameAchievements.DineInHellFunc();
        Label_0089:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00AB;
        }
        finally
        {
        Label_0099:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A4;
            }
        Label_00A4:
            disposable.Dispose();
        }
    Label_00AB:
        return;
    }

    protected int GetDamageExplode()
    {
        int num;
        return UnityEngine.Random.Range(this.explodeMinDamage, this.explodeMaxDamage + 1);
    }

    public bool HasShield()
    {
        return this.isShield;
    }

    protected override unsafe void InitCustomSettings()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.explodeRangeWidth = 170;
        this.explodeRangeHeight = Mathf.RoundToInt(((float) this.explodeRangeWidth) * 0.7f);
        this.explodeDamageTime = 5;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 10f, -780f);
        UnityEngine.Object.Instantiate(this.portalVeznan, vector, Quaternion.identity);
        return;
    }

    protected bool OnRangeExplode(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), (float) this.explodeRangeHeight, (float) this.explodeRangeWidth, base.transform.position + base.anchorPoint);
    }

    public void SetTeleportingIn(bool t)
    {
        this.teleportingIn = t;
        return;
    }

    public unsafe void ShieldMe()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.isShield = 1;
        this.shieldIgnoreHits = 4;
        base.canBlood = 0;
        if ((this.shield == null) == null)
        {
            goto Label_009D;
        }
        this.shield = UnityEngine.Object.Instantiate(this.shieldPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + base.yModifierAdjust, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        this.shield.parent = base.transform;
    Label_009D:
        return;
    }

    protected void UnShieldMe()
    {
        this.isShield = 0;
        UnityEngine.Object.Destroy(this.shield.gameObject);
        this.shield = null;
        return;
    }
}

