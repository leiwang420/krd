using System;
using System.Collections;
using UnityEngine;

public class SoldierReinforcementLeggionaire : SoldierReinforcement
{
    protected bool canSpear;
    protected bool isSpearing;
    protected int spearChargeTime;
    protected int spearChargeTimeCounter;
    protected int spearMaxDamage;
    protected int spearMinDamage;
    protected int spearMinRange;
    protected Vector2 spearPoint;
    public Transform spearPrefab;
    protected int spearRangeHeight;
    protected int spearRangeWidth;
    protected int spearReloadTime;
    protected int spearReloadTimeCounter;
    protected Creep spearTarget;

    public SoldierReinforcementLeggionaire()
    {
        base..ctor();
        return;
    }

    protected unsafe bool EvalSpear()
    {
        Transform transform;
        Arrow arrow;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.canSpear != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isSpearing != null)
        {
            goto Label_00E6;
        }
        if (this.spearReloadTimeCounter >= this.spearReloadTime)
        {
            goto Label_0039;
        }
        this.spearReloadTimeCounter += 1;
        return 0;
    Label_0039:
        if (base.isIdle != null)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        if (this.GetSpearTarget() != null)
        {
            goto Label_0053;
        }
        return 0;
    Label_0053:
        if (&this.spearTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_00A7;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00C6;
    Label_00A7:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00C6:
        this.isSpearing = 1;
        this.spearChargeTimeCounter = 0;
        base.sprite.PlayAnim("spear");
        return 1;
    Label_00E6:
        if (this.spearChargeTimeCounter >= this.spearChargeTime)
        {
            goto Label_01AD;
        }
        this.spearChargeTimeCounter += 1;
        if (this.spearChargeTimeCounter != 5)
        {
            goto Label_01AB;
        }
        transform = UnityEngine.Object.Instantiate(this.spearPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 14f, -890f), Quaternion.identity) as Transform;
        base.stage.AddReinforce(transform);
        arrow = transform.GetComponent<Arrow>();
        arrow.SetTarget(this.spearTarget, &this.spearPoint.x, &this.spearPoint.y);
        arrow.SetDamage(this.GetSpearDamage());
        arrow.SetT1(20f);
    Label_01AB:
        return 1;
    Label_01AD:
        this.isSpearing = 0;
        this.spearReloadTimeCounter = 0;
        return 0;
    }

    protected int GetSpearDamage()
    {
        return UnityEngine.Random.Range(this.spearMinDamage, this.spearMaxDamage + 1);
    }

    protected unsafe bool GetSpearTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        creep = null;
        this.spearTarget = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001A:
        try
        {
            goto Label_0092;
        Label_001F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_0092;
            }
            if (this.MinDistance(creep2) == null)
            {
                goto Label_0092;
            }
            if (IronUtils.ellipseContainPoint(creep2.transform.position, (float) this.spearRangeHeight, (float) this.spearRangeWidth, base.transform.position) == null)
            {
                goto Label_0092;
            }
            if ((creep == null) != null)
            {
                goto Label_0090;
            }
            if (this.IsNearExit(creep, creep2) == null)
            {
                goto Label_0092;
            }
        Label_0090:
            creep = creep2;
        Label_0092:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
            goto Label_00B7;
        }
        finally
        {
        Label_00A2:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00AF;
            }
        Label_00AF:
            disposable.Dispose();
        }
    Label_00B7:
        if ((creep != null) == null)
        {
            goto Label_0117;
        }
        this.spearTarget = creep;
        this.spearPoint = new Vector2(&creep.transform.position.x + &creep.anchorPoint.x, &creep.transform.position.y + &creep.anchorPoint.y);
        return 1;
    Label_0117:
        return 0;
    }

    protected bool IsNearExit(Creep enemy, Creep enemyNew)
    {
        if ((enemy.GetSubPathCount() - enemy.GetCurrentNodeIndex()) <= (enemyNew.GetSubPathCount() - enemyNew.GetCurrentNodeIndex()))
        {
            goto Label_0021;
        }
        return 1;
    Label_0021:
        return 0;
    }

    protected unsafe bool MinDistance(Creep myEnemy)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &myEnemy.transform.position.x - &base.transform.position.x;
        num3 = &myEnemy.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.spearMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected override bool RunSpecial()
    {
        if (base.isActive != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.EvalSpear() == null)
        {
            goto Label_001A;
        }
        return 1;
    Label_001A:
        return 0;
    }

    private void Start()
    {
        int num;
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.rangeWidth = 170;
        base.rangeHeight = Mathf.CeilToInt(((float) base.rangeWidth) * 0.7f);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.stage.AddSoldier(this);
        base.yLifebarOffset = 20;
        base.deadTime = 10;
        base.attackChargeTime = 11;
        base.attackChargeDamageTime = 5;
        base.attackReloadTime = (GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "reload") * 30) - base.attackChargeTime;
        base.minDamage = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "minDamage");
        base.maxDamage = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "maxDamage");
        base.health = base.initHealth = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "health");
        base.armor = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "armor");
        base.lifeTime = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "lifeTime") * 30;
        base.regenerateHealth = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "regen");
        base.regenerateTime = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "regenReload") * 30;
        if (GameUpgrades.ReinforcementLevel != 5)
        {
            goto Label_0225;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_0192;
        }
        if (base.stage.MaxUpgradeLevel != 5)
        {
            goto Label_0225;
        }
    Label_0192:
        this.canSpear = 1;
        this.spearReloadTime = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "spearCoolDown") * 30;
        this.spearRangeWidth = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "spearRange");
        this.spearRangeHeight = Mathf.RoundToInt(((float) this.spearRangeWidth) * 0.7f);
        this.spearMinRange = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "spearMinRange");
        this.spearMinDamage = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "spearMinDamage");
        this.spearMaxDamage = GameSettings.GetPowerSetting("power_reinforcement_leggionaire", "spearMaxDamage");
        this.spearChargeTime = 10;
    Label_0225:
        this.LoadNames();
        base.SetRandomName();
        return;
    }

    protected override void StopSpecial()
    {
        if (this.isSpearing == null)
        {
            goto Label_0012;
        }
        this.isSpearing = 0;
    Label_0012:
        return;
    }
}

