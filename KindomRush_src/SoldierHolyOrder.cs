using System;
using System.Collections;
using UnityEngine;

public class SoldierHolyOrder : Soldier
{
    private int healingChargeTime;
    private int healingChargeTimeCounter;
    private int healingLevel;
    private int healingMax;
    public int healingMaxBase;
    private int healingMin;
    public int healingMinBase;
    private int healingReloadTime;
    private int healingReloadTimeCounter;
    private int holyStrikeChance;
    private int holyStrikeChargeTime;
    private int holyStrikeChargeTimeCounter;
    public Transform holyStrikeDecalPrefab;
    private int holyStrikeLevel;
    private int holyStrikeMaxDamage;
    public int holyStrikeMaxDamageBase;
    private int holyStrikeMinDamage;
    public int holyStrikeMinDamageBase;
    private int holyStrikeMinEnemies;
    private int holyStrikeRangeHeight;
    private int holyStrikeRangeWidth;
    private bool isHealing;
    private bool isHolyStrike;
    private int shieldLevel;

    public SoldierHolyOrder()
    {
        base..ctor();
        return;
    }

    protected bool CanHolyStrike()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        bool flag;
        IDisposable disposable;
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0065;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0065;
            }
            if (creep.isFlying != null)
            {
                goto Label_0065;
            }
            if (this.OnRange(creep) == null)
            {
                goto Label_0065;
            }
            num += 1;
            if (num != this.holyStrikeMinEnemies)
            {
                goto Label_0065;
            }
            flag = 1;
            goto Label_008C;
        Label_0065:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_008A;
        }
        finally
        {
        Label_0075:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0082;
            }
        Label_0082:
            disposable.Dispose();
        }
    Label_008A:
        return 0;
    Label_008C:
        return flag;
    }

    protected override void ChargeAttack()
    {
        if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
        {
            goto Label_002E;
        }
        base.sprite.PlayAnim("attack");
        goto Label_003E;
    Label_002E:
        base.sprite.PlayAnim("attack2");
    Label_003E:
        base.isCharging = 1;
        return;
    }

    protected bool EvalHealing()
    {
        if (this.isHolyStrike == null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isHealing != null)
        {
            goto Label_006B;
        }
        if (this.healingReloadTimeCounter >= this.healingReloadTime)
        {
            goto Label_0039;
        }
        this.healingReloadTimeCounter += 1;
        return 0;
    Label_0039:
        if (base.CanHeal() != null)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        this.isHealing = 1;
        this.healingChargeTimeCounter = 0;
        base.sprite.PlayAnim("heal");
        GameSoundManager.PlayHealingSound();
        return 1;
    Label_006B:
        if (this.healingChargeTimeCounter >= this.healingChargeTime)
        {
            goto Label_00A5;
        }
        this.healingChargeTimeCounter += 1;
        if (this.healingChargeTimeCounter != 0x11)
        {
            goto Label_00A3;
        }
        base.Heal(this.GetHealingPoints());
    Label_00A3:
        return 1;
    Label_00A5:
        this.isHealing = 0;
        base.isCharging = 0;
        base.attackReloadTimeCounter = 0;
        base.attackChargeTimeCounter = 0;
        this.healingReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalHolyStrike()
    {
        Transform transform;
        Transform transform2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if (this.isHealing == null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isHolyStrike != null)
        {
            goto Label_005A;
        }
        if (UnityEngine.Random.Range(1, 0x65) <= this.holyStrikeChance)
        {
            goto Label_002D;
        }
        return 0;
    Label_002D:
        if (this.CanHolyStrike() != null)
        {
            goto Label_003A;
        }
        return 0;
    Label_003A:
        this.isHolyStrike = 1;
        this.holyStrikeChargeTimeCounter = 0;
        base.sprite.PlayAnim("holyStrike");
        return 1;
    Label_005A:
        if (this.holyStrikeChargeTimeCounter >= this.holyStrikeChargeTime)
        {
            goto Label_0192;
        }
        this.holyStrikeChargeTimeCounter += 1;
        if (this.holyStrikeChargeTimeCounter != 15)
        {
            goto Label_0190;
        }
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_0107;
        }
        transform = UnityEngine.Object.Instantiate(this.holyStrikeDecalPrefab, new Vector3(&base.transform.position.x + 35f, &base.transform.position.y - 22f, -1f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        goto Label_0185;
    Label_0107:
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_0185;
        }
        transform2 = UnityEngine.Object.Instantiate(this.holyStrikeDecalPrefab, new Vector3(&base.transform.position.x - 35f, &base.transform.position.y - 22f, -1f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform2);
    Label_0185:
        GameAchievements.HolyStrike();
        this.HolyStrike();
    Label_0190:
        return 1;
    Label_0192:
        this.isHolyStrike = 0;
        base.isCharging = 0;
        base.attackReloadTimeCounter = 0;
        base.attackChargeTimeCounter = 0;
        return 0;
    }

    protected int GetHealingPoints()
    {
        int num;
        num = this.healingMin + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.healingMax - this.healingMin)));
        GameAchievements.HealMe(num);
        return num;
    }

    protected int GetHolyStrikeDamage()
    {
        return (this.holyStrikeMinDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.holyStrikeMaxDamage - this.holyStrikeMinDamage))));
    }

    protected void HolyStrike()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_005A;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_005A;
            }
            if (creep.isFlying != null)
            {
                goto Label_005A;
            }
            if (this.OnRange(creep) == null)
            {
                goto Label_005A;
            }
            creep.Damage(this.GetHolyStrikeDamage(), 1, 0, 0);
        Label_005A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_007C;
        }
        finally
        {
        Label_006A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0075;
            }
        Label_0075:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    protected override void LoadNames()
    {
        base.nameCandidates = new ArrayList();
        base.nameCandidates.Add("Sir Roland");
        base.nameCandidates.Add("Sir Nicholas");
        base.nameCandidates.Add("Sir Litto");
        base.nameCandidates.Add("Sir Wallace");
        base.nameCandidates.Add("Sir Vincent");
        base.nameCandidates.Add("Sir Dante");
        base.nameCandidates.Add("Sir Julian");
        base.nameCandidates.Add("Sir Caspian");
        base.nameCandidates.Add("Sir Gaw Ain");
        base.nameCandidates.Add("Sir Alvus");
        base.nameCandidates.Add("Sir Olivier");
        base.nameCandidates.Add("Sir Sande");
        base.nameCandidates.Add("Sir Ulric");
        base.nameCandidates.Add("Sir Magnus");
        base.nameCandidates.Add("Sir Gabini");
        base.nameCandidates.Add("Sir Crisden");
        base.nameCandidates.Add("Sir Guybrush");
        base.nameCandidates.Add("Sir Wiggins");
        base.nameCandidates.Add("Sir Wynants");
        base.nameCandidates.Add("Sir Cavendish");
        base.nameCandidates.Add("Sir LeMond");
        base.nameCandidates.Add("Sir Fignon");
        base.nameCandidates.Add("Sir Ashton");
        base.nameCandidates.Add("Sir Spencer");
        base.nameCandidates.Add("Sir Esti");
        base.nameCandidates.Add("Sir Coppes");
        base.nameCandidates.Add("Sir Rubens");
        base.nameCandidates.Add("Sir Gerson");
        return;
    }

    protected override bool ReadyToAttack()
    {
        base.attackReloadTimeCounter += 1;
        if (base.attackReloadTimeCounter != base.attackReloadTime)
        {
            goto Label_0054;
        }
        if (this.holyStrikeLevel == null)
        {
            goto Label_0045;
        }
        if (this.isHealing != null)
        {
            goto Label_0045;
        }
        if (this.EvalHolyStrike() == null)
        {
            goto Label_0045;
        }
        goto Label_004B;
    Label_0045:
        this.ChargeAttack();
    Label_004B:
        base.attackReloadTimeCounter = 0;
        return 1;
    Label_0054:
        return 0;
    }

    protected override bool RunSpecial()
    {
        if (this.healingLevel == null)
        {
            goto Label_0018;
        }
        if (this.EvalHealing() == null)
        {
            goto Label_0018;
        }
        return 1;
    Label_0018:
        if (this.isHolyStrike == null)
        {
            goto Label_0030;
        }
        if (this.EvalHolyStrike() == null)
        {
            goto Label_0030;
        }
        return 1;
    Label_0030:
        return 0;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        int num;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -3f);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.rangeWidth = 0xd9;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.health = base.initHealth = (int) GameSettings.GetTowerSetting("barrack_paladin", "health");
        base.armor = (int) GameSettings.GetTowerSetting("barrack_paladin", "armor");
        base.respawnTime = (int) GameSettings.GetTowerSetting("barrack_paladin", "respawn");
        base.regenerateHealth = 0x19;
        base.regenerateTime = 30;
        this.holyStrikeChargeTime = 0x1f;
        this.holyStrikeChance = 10;
        this.holyStrikeRangeWidth = 0x8d;
        this.holyStrikeRangeHeight = Mathf.RoundToInt(((float) this.holyStrikeRangeWidth) * 0.7f);
        this.holyStrikeMinEnemies = 1;
        this.healingChargeTime = 0x1f;
        this.healingChargeTimeCounter = 0;
        this.healingReloadTimeCounter = 0;
        this.healingReloadTime = 300;
        this.LoadNames();
        base.SetRandomName();
        return;
    }

    public void UpgradeHealing(int myHealingLevel)
    {
        this.healingLevel = myHealingLevel;
        this.healingMin = this.healingMinBase * this.healingLevel;
        this.healingMax = this.healingMaxBase * this.healingLevel;
        return;
    }

    public void UpgradeHolyStrike(int holyLevel)
    {
        this.holyStrikeLevel = holyLevel;
        this.holyStrikeMinDamage = this.holyStrikeMinDamageBase * this.holyStrikeLevel;
        this.holyStrikeMaxDamage = this.holyStrikeMaxDamageBase * this.holyStrikeLevel;
        return;
    }

    public void UpgradeShield(int myShieldLevel)
    {
        this.shieldLevel = myShieldLevel;
        base.armor += 15;
        return;
    }
}

