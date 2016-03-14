using System;
using System.Collections;
using UnityEngine;

public class BarrackBasicClickable : TowerBasicClickable
{
    public BarrackBasicClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public override unsafe void BuildUpgrade(BuildTerrainClickable bt, int spent)
    {
        BarrackTower tower;
        ArrayList list;
        Vector2 vector;
        BarrackTower tower2;
        Soldier soldier;
        string str;
        Soldier soldier2;
        IEnumerator enumerator;
        string str2;
        IDisposable disposable;
        tower = base.menu.GetCurrentSelect().GetComponent<BarrackTower>();
        list = tower.GetSoldiers();
        vector = tower.GetRallyPoint();
        tower.RemoveSoldiersFromStage();
        tower2 = UnityEngine.Object.Instantiate(base.upgradeTower, base.transform.position, base.transform.rotation) as BarrackTower;
        tower2.SetBuildTerrain(bt);
        tower2.ShowUpgradeSmoke();
        soldier = null;
        str = base.upgradeTower.name;
        if ((str == "BarrackLvl2") == null)
        {
            goto Label_00B7;
        }
        tower2.SetPrice((int) GameSettings.GetTowerSetting("barrack_level2", "price"));
        tower2.SetSpentBase(tower.GetSpent());
        tower2.SetSpent((int) GameSettings.GetTowerSetting("barrack_level2", "price"));
        goto Label_010A;
    Label_00B7:
        if ((str == "BarrackLvl3") == null)
        {
            goto Label_010A;
        }
        tower2.SetPrice((int) GameSettings.GetTowerSetting("barrack_level3", "price"));
        tower2.SetSpentBase(tower.GetSpent());
        tower2.SetSpent((int) GameSettings.GetTowerSetting("barrack_level3", "price"));
        GameAchievements.UpgradeTowerLevel3("soldier");
    Label_010A:
        enumerator = list.GetEnumerator();
    Label_0112:
        try
        {
            goto Label_0180;
        Label_0117:
            soldier2 = (Soldier) enumerator.Current;
            if ((str == "BarrackLvl2") == null)
            {
                goto Label_014B;
            }
            soldier = soldier2.SwapSoldier("footmen", tower2, 0);
            goto Label_016C;
        Label_014B:
            if ((str == "BarrackLvl3") == null)
            {
                goto Label_016C;
            }
            soldier = soldier2.SwapSoldier("knight", tower2, 0);
        Label_016C:
            UnityEngine.Object.Destroy(soldier2.gameObject);
            tower2.AddSoldier(soldier);
        Label_0180:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0117;
            }
            goto Label_01A7;
        }
        finally
        {
        Label_0191:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_019F;
            }
        Label_019F:
            disposable.Dispose();
        }
    Label_01A7:
        tower2.SetRallyPoint(&vector.x, &vector.y);
        str2 = tower2.name;
        tower2.name = tower2.name.Remove(str2.IndexOf("("));
        GameAchievements.BuildTower();
        return;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { ((base.CanUpgrade(null) == null) ? this.MakeButton("locked", &base.upgradeButton.localPos.x, &base.upgradeButton.localPos.y) : this.MakeButton("UpgradeButton", &base.upgradeButton.localPos.x, &base.upgradeButton.localPos.y)), this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y) };
    }

    protected override void MissClick()
    {
        base.isSelected = 0;
        return;
    }

    protected override unsafe void OnClick()
    {
        Vector3 vector;
        Vector3 vector2;
        if (base.CheckButtonPriority() != null)
        {
            goto Label_00C3;
        }
        if (base.isSelected != null)
        {
            goto Label_0090;
        }
        base.menu.Show(this, this.CreateButtons());
        base.menu.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -900f);
        base.isSelected = 1;
        base.selectedTower.ShowRangeCircle(Vector3.zero);
        base.GetComponent<BarrackTower>().SelectSoldiers();
        goto Label_00C3;
    Label_0090:
        base.isSelected = 0;
        base.menu.Hide();
        ((BarrackTower) base.selectedTower).UnselectSoldiers();
        base.guiBottom.HideInfo(base.GetComponent<UnitClickable>());
    Label_00C3:
        return;
    }

    private void Start()
    {
        base.isSelected = 0;
        base.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.selectedTower = base.GetComponent<TowerBase>();
        return;
    }

    protected void Update()
    {
        base.Update();
        return;
    }
}

