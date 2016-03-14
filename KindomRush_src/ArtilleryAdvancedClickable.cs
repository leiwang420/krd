using System;
using UnityEngine;

public class ArtilleryAdvancedClickable : TowerBasicClickable
{
    public TowerButton bfgButton;
    public TowerBase bfgTower;
    public TowerButton teslaButton;
    public TowerBase teslaTower;

    public ArtilleryAdvancedClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public void BuildBFG(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        base2 = UnityEngine.Object.Instantiate(this.bfgTower, base.transform.position + new Vector3(0f, (float) this.bfgTower.yAdjust, 0f), base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        base2.SetPrice((int) GameSettings.GetTowerSetting("artillery_bfg", "price"));
        base2.SetSpentBase(spent);
        base2.SetSpent((int) GameSettings.GetTowerSetting("artillery_bfg", "price"));
        base2.name = "ArtilleryBFG";
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerBfg();
        return;
    }

    public void BuildTesla(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        base2 = UnityEngine.Object.Instantiate(this.teslaTower, base.transform.position, base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        base2.SetPrice((int) GameSettings.GetTowerSetting("artillery_tesla", "price"));
        base2.SetSpentBase(spent);
        base2.SetSpent((int) GameSettings.GetTowerSetting("artillery_tesla", "price"));
        base2.name = "ArtilleryTesla";
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerTesla();
        return;
    }

    protected override bool CanBuyTower(string tower)
    {
        if ((tower == "BFGButton") == null)
        {
            goto Label_0031;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("artillery_bfg", "price")) == 0);
    Label_0031:
        if ((tower == "TeslaButton") == null)
        {
            goto Label_0062;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("artillery_tesla", "price")) == 0);
    Label_0062:
        return 0;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), ((base.CanUpgrade("ArtilleryBFG") == null) ? this.MakeButton("locked", &this.bfgButton.localPos.x, &this.bfgButton.localPos.y) : this.MakeButton("BFGButton", &this.bfgButton.localPos.x, &this.bfgButton.localPos.y)), ((base.CanUpgrade("ArtilleryTesla") == null) ? this.MakeButton("locked", &this.teslaButton.localPos.x, &this.teslaButton.localPos.y) : this.MakeButton("TeslaButton", &this.teslaButton.localPos.x, &this.teslaButton.localPos.y)) };
    }

    public void HideUpgradeRange(string tower)
    {
        if ((tower == "BFG") == null)
        {
            goto Label_0031;
        }
        if ((this.bfgTower != null) == null)
        {
            goto Label_0031;
        }
        this.bfgTower.HideRangeCircle();
        goto Label_005D;
    Label_0031:
        if ((tower == "Tesla") == null)
        {
            goto Label_005D;
        }
        if ((this.teslaTower != null) == null)
        {
            goto Label_005D;
        }
        this.teslaTower.HideRangeCircle();
    Label_005D:
        return;
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        string str;
        button2 = null;
        str = null;
        if ((button == "TeslaButton") == null)
        {
            goto Label_0046;
        }
        button2 = UnityEngine.Object.Instantiate(this.teslaButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "ArtilleryTesla";
        goto Label_0103;
    Label_0046:
        if ((button == "SellButton") == null)
        {
            goto Label_007F;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_007F:
        if ((button == "BFGButton") == null)
        {
            goto Label_00C1;
        }
        button2 = UnityEngine.Object.Instantiate(this.bfgButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "ArtilleryBFG";
        goto Label_0103;
    Label_00C1:
        button2 = UnityEngine.Object.Instantiate(base.lockedButton, base.transform.position, base.transform.rotation) as TowerButton;
        button2.localPos = new Vector2(posX, posY);
        button2.SetAvailable(0);
        return button2;
    Label_0103:
        button2.SetPrice(GameSettings.GetTowerPrice(str));
        if (this.CanBuyTower(button) != null)
        {
            goto Label_0122;
        }
        button2.SetAvailable(0);
    Label_0122:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    public void ShowUpgradeRange(Vector3 position, string tower)
    {
        if ((tower == "BFG") == null)
        {
            goto Label_0033;
        }
        if ((this.bfgTower != null) == null)
        {
            goto Label_0033;
        }
        this.bfgTower.ShowRangeCircle(position);
        goto Label_0061;
    Label_0033:
        if ((tower == "Tesla") == null)
        {
            goto Label_0061;
        }
        if ((this.teslaTower != null) == null)
        {
            goto Label_0061;
        }
        this.teslaTower.ShowRangeCircle(position);
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

