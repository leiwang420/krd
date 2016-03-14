using System;
using System.Collections;
using UnityEngine;

public class BarrackHolyOrderTower : BarrackTower
{
    private int healingLevel;
    private int holyStrikeLevel;
    private int shieldLevel;

    public BarrackHolyOrderTower()
    {
        base..ctor();
        return;
    }

    public int GetHealingLevel()
    {
        return this.healingLevel;
    }

    public int GetHolyStrikeLevel()
    {
        return this.holyStrikeLevel;
    }

    public int GetShieldLevel()
    {
        return this.shieldLevel;
    }

    public bool HealingLevelUp()
    {
        SoldierHolyOrder order;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.healingLevel >= 3)
        {
            goto Label_0067;
        }
        this.healingLevel += 1;
        enumerator = base.soldiers.GetEnumerator();
    Label_0026:
        try
        {
            goto Label_0043;
        Label_002B:
            order = (SoldierHolyOrder) enumerator.Current;
            order.UpgradeHealing(this.healingLevel);
        Label_0043:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002B;
            }
            goto Label_0065;
        }
        finally
        {
        Label_0053:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_005E;
            }
        Label_005E:
            disposable.Dispose();
        }
    Label_0065:
        return 1;
    Label_0067:
        return 0;
    }

    public bool HolyStrikeLevelUp()
    {
        SoldierHolyOrder order;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.holyStrikeLevel >= 3)
        {
            goto Label_0067;
        }
        this.holyStrikeLevel += 1;
        enumerator = base.soldiers.GetEnumerator();
    Label_0026:
        try
        {
            goto Label_0043;
        Label_002B:
            order = (SoldierHolyOrder) enumerator.Current;
            order.UpgradeHolyStrike(this.holyStrikeLevel);
        Label_0043:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002B;
            }
            goto Label_0065;
        }
        finally
        {
        Label_0053:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_005E;
            }
        Label_005E:
            disposable.Dispose();
        }
    Label_0065:
        return 1;
    Label_0067:
        return 0;
    }

    protected override void PlayRallyPointMoveSound()
    {
        GameSoundManager.PlayBarrackPaladinTaunt();
        return;
    }

    public bool ShieldLevelUp()
    {
        SoldierHolyOrder order;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.shieldLevel >= 1)
        {
            goto Label_0076;
        }
        this.shieldLevel += 1;
        base.armor += 15;
        enumerator = base.soldiers.GetEnumerator();
    Label_0035:
        try
        {
            goto Label_0052;
        Label_003A:
            order = (SoldierHolyOrder) enumerator.Current;
            order.UpgradeShield(this.shieldLevel);
        Label_0052:
            if (enumerator.MoveNext() != null)
            {
                goto Label_003A;
            }
            goto Label_0074;
        }
        finally
        {
        Label_0062:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006D;
            }
        Label_006D:
            disposable.Dispose();
        }
    Label_0074:
        return 1;
    Label_0076:
        return 0;
    }

    private void Start()
    {
        int num;
        base.doorStatus = 2;
        base.sprite = base.GetComponent<PackedSprite>();
        base.rallyRangeWidth = base.rangeRally = (int) GameSettings.GetTowerSetting("barrack_paladin", "rangeRally");
        base.rallyRangeHeight = Mathf.CeilToInt(((float) base.rallyRangeWidth) * 0.7f);
        base.minDamange = (int) GameSettings.GetTowerSetting("barrack_paladin", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("barrack_paladin", "maxDamage");
        base.respawn = (int) GameSettings.GetTowerSetting("barrack_paladin", "respawn");
        base.health = (int) GameSettings.GetTowerSetting("barrack_paladin", "health");
        base.armor = (int) GameSettings.GetTowerSetting("barrack_paladin", "armor");
        base.AddSoldiersToStage();
        GameSoundManager.PlayBarrackPaladinTaunt();
        return;
    }
}

