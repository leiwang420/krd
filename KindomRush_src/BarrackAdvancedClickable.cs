using System;
using System.Collections;
using UnityEngine;

public class BarrackAdvancedClickable : BarrackBasicClickable
{
    public TowerButton barbarianButton;
    public BarrackTower barbarianTower;
    public TowerButton holyOrderButton;
    public BarrackTower holyOrderTower;

    public BarrackAdvancedClickable()
    {
        base..ctor();
        return;
    }

    public void BuildBarbarian(BuildTerrainClickable bt)
    {
        BarrackTower tower;
        ArrayList list;
        Vector2 vector;
        BarrackTower tower2;
        Soldier soldier;
        Soldier soldier2;
        IEnumerator enumerator;
        IDisposable disposable;
        tower = base.menu.GetCurrentSelect().GetComponent<BarrackTower>();
        list = tower.GetSoldiers();
        vector = tower.GetRallyPoint();
        tower.RemoveSoldiersFromStage();
        tower2 = UnityEngine.Object.Instantiate(this.barbarianTower, base.transform.position, base.transform.rotation) as BarrackTower;
        tower2.SetBuildTerrain(bt);
        tower2.ShowUpgradeSmoke();
        tower2.SetPrice((int) GameSettings.GetTowerSetting("barrack_barbarian", "price"));
        tower2.SetSpentBase(tower.GetSpent());
        tower2.SetSpent((int) GameSettings.GetTowerSetting("barrack_barbarian", "price"));
        tower2.name = "BarrackBarbarian";
        soldier = null;
        enumerator = list.GetEnumerator();
    Label_00A7:
        try
        {
            goto Label_00DE;
        Label_00AC:
            soldier2 = (Soldier) enumerator.Current;
            soldier = soldier2.SwapSoldier("barbarian", tower2, 0);
            UnityEngine.Object.Destroy(soldier2.gameObject);
            tower2.AddSoldier(soldier);
        Label_00DE:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00AC;
            }
            goto Label_0105;
        }
        finally
        {
        Label_00EF:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00FD;
            }
        Label_00FD:
            disposable.Dispose();
        }
    Label_0105:
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerBarbarian();
        return;
    }

    public void BuildHolyOrder(BuildTerrainClickable bt)
    {
        BarrackTower tower;
        ArrayList list;
        Vector2 vector;
        BarrackTower tower2;
        Soldier soldier;
        Soldier soldier2;
        IEnumerator enumerator;
        IDisposable disposable;
        tower = base.menu.GetCurrentSelect().GetComponent<BarrackTower>();
        list = tower.GetSoldiers();
        vector = tower.GetRallyPoint();
        tower.RemoveSoldiersFromStage();
        tower2 = UnityEngine.Object.Instantiate(this.holyOrderTower, base.transform.position, base.transform.rotation) as BarrackTower;
        tower2.SetBuildTerrain(bt);
        tower2.ShowUpgradeSmoke();
        tower2.SetPrice((int) GameSettings.GetTowerSetting("barrack_paladin", "price"));
        tower2.SetSpentBase(tower.GetSpent());
        tower2.SetSpent((int) GameSettings.GetTowerSetting("barrack_paladin", "price"));
        tower2.name = "BarrackHolyOrder";
        soldier = null;
        enumerator = list.GetEnumerator();
    Label_00A7:
        try
        {
            goto Label_00DE;
        Label_00AC:
            soldier2 = (Soldier) enumerator.Current;
            soldier = soldier2.SwapSoldier("holyOrder", tower2, 0);
            UnityEngine.Object.Destroy(soldier2.gameObject);
            tower2.AddSoldier(soldier);
        Label_00DE:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00AC;
            }
            goto Label_0105;
        }
        finally
        {
        Label_00EF:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00FD;
            }
        Label_00FD:
            disposable.Dispose();
        }
    Label_0105:
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerPaladin();
        return;
    }

    protected override bool CanBuyTower(string tower)
    {
        if ((tower == "HolyOrderButton") == null)
        {
            goto Label_0031;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("barrack_paladin", "price")) == 0);
    Label_0031:
        if ((tower == "BarbarianButton") == null)
        {
            goto Label_0062;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("barrack_barbarian", "price")) == 0);
    Label_0062:
        return 0;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y), ((base.CanUpgrade("BarrackHolyOrder") == null) ? this.MakeButton("locked", &this.holyOrderButton.localPos.x, &this.holyOrderButton.localPos.y) : this.MakeButton("HolyOrderButton", &this.holyOrderButton.localPos.x, &this.holyOrderButton.localPos.y)), ((base.CanUpgrade("BarrackBarbarian") == null) ? this.MakeButton("locked", &this.barbarianButton.localPos.x, &this.barbarianButton.localPos.y) : this.MakeButton("BarbarianButton", &this.barbarianButton.localPos.x, &this.barbarianButton.localPos.y)) };
    }

    public void HideUpgradeRange(string tower)
    {
        if ((tower == "HolyOrder") == null)
        {
            goto Label_0031;
        }
        if ((this.holyOrderTower != null) == null)
        {
            goto Label_0031;
        }
        this.holyOrderTower.HideRangeCircle();
        goto Label_005D;
    Label_0031:
        if ((tower == "Barbarian") == null)
        {
            goto Label_005D;
        }
        if ((this.barbarianTower != null) == null)
        {
            goto Label_005D;
        }
        this.barbarianTower.HideRangeCircle();
    Label_005D:
        return;
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        string str;
        button2 = null;
        str = null;
        if ((button == "HolyOrderButton") == null)
        {
            goto Label_0046;
        }
        button2 = UnityEngine.Object.Instantiate(this.holyOrderButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "BarrackHolyOrder";
        goto Label_013C;
    Label_0046:
        if ((button == "BarbarianButton") == null)
        {
            goto Label_0088;
        }
        button2 = UnityEngine.Object.Instantiate(this.barbarianButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "BarrackBarbarian";
        goto Label_013C;
    Label_0088:
        if ((button == "SellButton") == null)
        {
            goto Label_00C1;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_00C1:
        if ((button == "RespawnButton") == null)
        {
            goto Label_00FA;
        }
        button2 = UnityEngine.Object.Instantiate(base.respawnButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_00FA:
        button2 = UnityEngine.Object.Instantiate(base.lockedButton, base.transform.position, base.transform.rotation) as TowerButton;
        button2.localPos = new Vector2(posX, posY);
        button2.SetAvailable(0);
        return button2;
    Label_013C:
        button2.SetPrice(GameSettings.GetTowerPrice(str));
        if (this.CanBuyTower(button) != null)
        {
            goto Label_015B;
        }
        button2.SetAvailable(0);
    Label_015B:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    public void ShowUpgradeRange(Vector3 position, string tower)
    {
        if ((tower == "HolyOrder") == null)
        {
            goto Label_0033;
        }
        if ((this.holyOrderTower != null) == null)
        {
            goto Label_0033;
        }
        this.holyOrderTower.ShowRangeCircle(position);
        goto Label_0061;
    Label_0033:
        if ((tower == "Barbarian") == null)
        {
            goto Label_0061;
        }
        if ((this.barbarianTower != null) == null)
        {
            goto Label_0061;
        }
        this.barbarianTower.ShowRangeCircle(position);
    Label_0061:
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

    private void Update()
    {
        base.Update();
        return;
    }
}

