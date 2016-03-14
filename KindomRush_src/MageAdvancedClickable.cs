using System;
using UnityEngine;

public class MageAdvancedClickable : TowerBasicClickable
{
    public TowerButton arcaneButton;
    public TowerBase arcaneTower;
    public TowerButton sorcererButton;
    public TowerBase sorcererTower;

    public MageAdvancedClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public void BuildArcane(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        base2 = UnityEngine.Object.Instantiate(this.arcaneTower, base.transform.position + new Vector3(0f, (float) this.arcaneTower.yAdjust, 0f), base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        base2.SetPrice((int) GameSettings.GetTowerSetting("mage_arcane", "price"));
        base2.SetSpentBase(spent);
        base2.SetSpent((int) GameSettings.GetTowerSetting("mage_arcane", "price"));
        base2.name = "MageArcane";
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerArcane();
        return;
    }

    public void BuildSorcerer(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        base2 = UnityEngine.Object.Instantiate(this.sorcererTower, base.transform.position, base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        base2.SetPrice((int) GameSettings.GetTowerSetting("mage_sorcerer", "price"));
        base2.SetSpentBase(spent);
        base2.SetSpent((int) GameSettings.GetTowerSetting("mage_sorcerer", "price"));
        base2.name = "MageSorcerer";
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerSorcerer();
        return;
    }

    protected override bool CanBuyTower(string tower)
    {
        if ((tower == "SorcererButton") == null)
        {
            goto Label_0031;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("mage_sorcerer", "price")) == 0);
    Label_0031:
        if ((tower == "ArcaneButton") == null)
        {
            goto Label_0062;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("mage_arcane", "price")) == 0);
    Label_0062:
        return 0;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), ((base.CanUpgrade("MageArcane") == null) ? this.MakeButton("locked", &this.arcaneButton.localPos.x, &this.arcaneButton.localPos.y) : this.MakeButton("ArcaneButton", &this.arcaneButton.localPos.x, &this.arcaneButton.localPos.y)), ((base.CanUpgrade("MageSorcerer") == null) ? this.MakeButton("locked", &this.sorcererButton.localPos.x, &this.sorcererButton.localPos.y) : this.MakeButton("SorcererButton", &this.sorcererButton.localPos.x, &this.sorcererButton.localPos.y)) };
    }

    public void HideUpgradeRange(string tower)
    {
        if ((tower == "Sorcerer") == null)
        {
            goto Label_0031;
        }
        if ((this.sorcererTower != null) == null)
        {
            goto Label_0031;
        }
        this.sorcererTower.HideRangeCircle();
        goto Label_005D;
    Label_0031:
        if ((tower == "Arcane") == null)
        {
            goto Label_005D;
        }
        if ((this.arcaneTower != null) == null)
        {
            goto Label_005D;
        }
        this.arcaneTower.HideRangeCircle();
    Label_005D:
        return;
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        string str;
        button2 = null;
        str = null;
        if ((button == "SorcererButton") == null)
        {
            goto Label_0046;
        }
        button2 = UnityEngine.Object.Instantiate(this.sorcererButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "MageSorcerer";
        goto Label_0103;
    Label_0046:
        if ((button == "SellButton") == null)
        {
            goto Label_007F;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_007F:
        if ((button == "ArcaneButton") == null)
        {
            goto Label_00C1;
        }
        button2 = UnityEngine.Object.Instantiate(this.arcaneButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "MageArcane";
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
        if ((tower == "Sorcerer") == null)
        {
            goto Label_0033;
        }
        if ((this.sorcererTower != null) == null)
        {
            goto Label_0033;
        }
        this.sorcererTower.ShowRangeCircle(position);
        goto Label_0061;
    Label_0033:
        if ((tower == "Arcane") == null)
        {
            goto Label_0061;
        }
        if ((this.arcaneTower != null) == null)
        {
            goto Label_0061;
        }
        this.arcaneTower.ShowRangeCircle(position);
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

