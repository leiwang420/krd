using System;
using System.Collections;
using UnityEngine;

public class BarrackBarbarianTower : BarrackTower
{
    private int dualWeaponsLevel;
    private int throwingLevel;
    private int twisterLevel;

    public BarrackBarbarianTower()
    {
        base..ctor();
        return;
    }

    public bool DualWeaponsLevelUp()
    {
        SoldierBarbarian barbarian;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.dualWeaponsLevel >= 3)
        {
            goto Label_0067;
        }
        this.dualWeaponsLevel += 1;
        enumerator = base.soldiers.GetEnumerator();
    Label_0026:
        try
        {
            goto Label_0043;
        Label_002B:
            barbarian = (SoldierBarbarian) enumerator.Current;
            barbarian.UpgradeDualWeapons(this.dualWeaponsLevel);
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

    public int GetDualWeaponsLevel()
    {
        return this.dualWeaponsLevel;
    }

    public int GetThrowingAxeLevel()
    {
        return this.throwingLevel;
    }

    public int GetTwisterLevel()
    {
        return this.twisterLevel;
    }

    public override void Pause()
    {
        Soldier soldier;
        IEnumerator enumerator;
        TowerModifierHeroDenas denas;
        Transform transform;
        IEnumerator enumerator2;
        Axe axe;
        IDisposable disposable;
        IDisposable disposable2;
        base.isPaused = 1;
        base.wasAnimating = base.sprite.IsAnimating();
        base.sprite.PauseAnim();
        enumerator = base.soldiers.GetEnumerator();
    Label_002F:
        try
        {
            goto Label_0046;
        Label_0034:
            soldier = (Soldier) enumerator.Current;
            soldier.Pause();
        Label_0046:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0034;
            }
            goto Label_006B;
        }
        finally
        {
        Label_0056:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0063;
            }
        Label_0063:
            disposable.Dispose();
        }
    Label_006B:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_0084;
        }
        denas.Pause();
    Label_0084:
        enumerator2 = base.transform.GetEnumerator();
    Label_0091:
        try
        {
            goto Label_00BF;
        Label_0096:
            transform = (Transform) enumerator2.Current;
            axe = transform.GetComponent<Axe>();
            if ((axe != null) == null)
            {
                goto Label_00BF;
            }
            axe.Pause();
        Label_00BF:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_0096;
            }
            goto Label_00E6;
        }
        finally
        {
        Label_00D0:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_00DE;
            }
        Label_00DE:
            disposable2.Dispose();
        }
    Label_00E6:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_0102;
        }
        base.veznanBlock.Pause();
    Label_0102:
        return;
    }

    protected override void PlayRallyPointMoveSound()
    {
        GameSoundManager.PlayBarrackBarbarianTaunt();
        return;
    }

    private void Start()
    {
        int num;
        base.doorStatus = 2;
        base.sprite = base.GetComponent<PackedSprite>();
        base.rallyRangeWidth = base.rangeRally = (int) GameSettings.GetTowerSetting("barrack_barbarian", "rangeRally");
        base.rallyRangeHeight = Mathf.CeilToInt(((float) base.rallyRangeWidth) * 0.7f);
        base.minDamange = (int) GameSettings.GetTowerSetting("barrack_barbarian", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("barrack_barbarian", "maxDamage");
        base.respawn = (int) GameSettings.GetTowerSetting("barrack_barbarian", "respawn");
        base.health = (int) GameSettings.GetTowerSetting("barrack_barbarian", "health");
        base.armor = (int) GameSettings.GetTowerSetting("barrack_barbarian", "armor");
        base.AddSoldiersToStage();
        GameSoundManager.PlayBarrackBarbarianTaunt();
        return;
    }

    public bool ThrowingAxeLevelUp()
    {
        SoldierBarbarian barbarian;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.throwingLevel >= 3)
        {
            goto Label_0067;
        }
        this.throwingLevel += 1;
        enumerator = base.soldiers.GetEnumerator();
    Label_0026:
        try
        {
            goto Label_0043;
        Label_002B:
            barbarian = (SoldierBarbarian) enumerator.Current;
            barbarian.UpgradeThrowingAxe(this.throwingLevel);
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

    public bool TwisterLevelUp()
    {
        SoldierBarbarian barbarian;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.twisterLevel >= 3)
        {
            goto Label_0067;
        }
        this.twisterLevel += 1;
        enumerator = base.soldiers.GetEnumerator();
    Label_0026:
        try
        {
            goto Label_0043;
        Label_002B:
            barbarian = (SoldierBarbarian) enumerator.Current;
            barbarian.UpgradeTwister(this.twisterLevel);
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

    public override void Unpause()
    {
        Soldier soldier;
        IEnumerator enumerator;
        TowerModifierHeroDenas denas;
        Transform transform;
        IEnumerator enumerator2;
        Axe axe;
        IDisposable disposable;
        IDisposable disposable2;
        base.isPaused = 0;
        if (base.wasAnimating == null)
        {
            goto Label_001D;
        }
        base.sprite.UnpauseAnim();
    Label_001D:
        enumerator = base.soldiers.GetEnumerator();
    Label_0029:
        try
        {
            goto Label_0040;
        Label_002E:
            soldier = (Soldier) enumerator.Current;
            soldier.Unpause();
        Label_0040:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002E;
            }
            goto Label_0065;
        }
        finally
        {
        Label_0050:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_005D;
            }
        Label_005D:
            disposable.Dispose();
        }
    Label_0065:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_007E;
        }
        denas.Unpause();
    Label_007E:
        enumerator2 = base.transform.GetEnumerator();
    Label_008B:
        try
        {
            goto Label_00B9;
        Label_0090:
            transform = (Transform) enumerator2.Current;
            axe = transform.GetComponent<Axe>();
            if ((axe != null) == null)
            {
                goto Label_00B9;
            }
            axe.Unpause();
        Label_00B9:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_0090;
            }
            goto Label_00E0;
        }
        finally
        {
        Label_00CA:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_00D8;
            }
        Label_00D8:
            disposable2.Dispose();
        }
    Label_00E0:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00FC;
        }
        base.veznanBlock.Unpause();
    Label_00FC:
        return;
    }
}

