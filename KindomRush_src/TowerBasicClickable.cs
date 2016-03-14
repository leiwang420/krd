using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class TowerBasicClickable : Clickable
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map0;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map1;
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map2;
    public TowerButton lockedButton;
    protected Quickmenu menu;
    protected Transform rangeCircle;
    public TowerButton respawnButton;
    protected TowerBase selectedTower;
    public TowerButton sellButton;
    protected StageBase stage;
    public TowerButton upgradeButton;
    public TowerBase upgradeTower;

    public TowerBasicClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public virtual unsafe void BuildUpgrade(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        string str;
        int num;
        string str2;
        Dictionary<string, int> dictionary;
        int num2;
        base2 = UnityEngine.Object.Instantiate(this.upgradeTower, base.transform.position, base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        str = base2.name;
        base2.name = base2.name.Remove(str.IndexOf("("));
        num = 0;
        str2 = base2.name;
        if (str2 == null)
        {
            goto Label_01F3;
        }
        if (<>f__switch$map2 != null)
        {
            goto Label_00E7;
        }
        dictionary = new Dictionary<string, int>(8);
        dictionary.Add("ArcherLvl2", 0);
        dictionary.Add("ArcherLvl3", 1);
        dictionary.Add("ArtilleryLvl2", 2);
        dictionary.Add("ArtilleryLvl3", 3);
        dictionary.Add("BarrackLvl2", 4);
        dictionary.Add("BarrackLvl3", 5);
        dictionary.Add("MageLvl2", 6);
        dictionary.Add("MageLvl3", 7);
        <>f__switch$map2 = dictionary;
    Label_00E7:
        if (<>f__switch$map2.TryGetValue(str2, &num2) == null)
        {
            goto Label_01F3;
        }
        switch (num2)
        {
            case 0:
                goto Label_0125;

            case 1:
                goto Label_013B;

            case 2:
                goto Label_015B;

            case 3:
                goto Label_0171;

            case 4:
                goto Label_0191;

            case 5:
                goto Label_01A7;

            case 6:
                goto Label_01BD;

            case 7:
                goto Label_01D3;
        }
        goto Label_01F3;
    Label_0125:
        num = (int) GameSettings.GetTowerSetting("archer_level2", "price");
        goto Label_01F3;
    Label_013B:
        num = (int) GameSettings.GetTowerSetting("archer_level3", "price");
        GameAchievements.UpgradeTowerLevel3("archer");
        goto Label_01F3;
    Label_015B:
        num = (int) GameSettings.GetTowerSetting("artillery_level2", "price");
        goto Label_01F3;
    Label_0171:
        num = (int) GameSettings.GetTowerSetting("artillery_level3", "price");
        GameAchievements.UpgradeTowerLevel3("engineer");
        goto Label_01F3;
    Label_0191:
        num = (int) GameSettings.GetTowerSetting("barrack_level2", "price");
        goto Label_01F3;
    Label_01A7:
        num = (int) GameSettings.GetTowerSetting("barrack_level3", "price");
        goto Label_01F3;
    Label_01BD:
        num = (int) GameSettings.GetTowerSetting("mage_level2", "price");
        goto Label_01F3;
    Label_01D3:
        num = (int) GameSettings.GetTowerSetting("mage_level3", "price");
        GameAchievements.UpgradeTowerLevel3("mage");
    Label_01F3:
        base2.SetSpentBase(spent);
        base2.SetSpent(num);
        GameAchievements.BuildTower();
        return;
    }

    protected bool CanBuyAbility(string ability)
    {
        return ((this.stage.GetGold() < GameSettings.GetAbilityPrice(ability)) == 0);
    }

    protected virtual unsafe bool CanBuyTower(string tower)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = tower;
        if (str == null)
        {
            goto Label_01D7;
        }
        if (<>f__switch$map1 != null)
        {
            goto Label_008C;
        }
        dictionary = new Dictionary<string, int>(9);
        dictionary.Add("ArcherLvl1", 0);
        dictionary.Add("ArcherLvl2", 1);
        dictionary.Add("ArtilleryLvl1", 2);
        dictionary.Add("ArtilleryLvl2", 3);
        dictionary.Add("BarrackLvl1", 4);
        dictionary.Add("BarrackLvl2", 5);
        dictionary.Add("MageLvl1", 6);
        dictionary.Add("MageLvl2", 7);
        dictionary.Add("locked", 8);
        <>f__switch$map1 = dictionary;
    Label_008C:
        if (<>f__switch$map1.TryGetValue(str, &num) == null)
        {
            goto Label_01D7;
        }
        switch (num)
        {
            case 0:
                goto Label_00CD;

            case 1:
                goto Label_00EE;

            case 2:
                goto Label_010F;

            case 3:
                goto Label_0130;

            case 4:
                goto Label_0151;

            case 5:
                goto Label_0172;

            case 6:
                goto Label_0193;

            case 7:
                goto Label_01B4;

            case 8:
                goto Label_01D5;
        }
        goto Label_01D7;
    Label_00CD:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("archer_level2", "price")) == 0);
    Label_00EE:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("archer_level3", "price")) == 0);
    Label_010F:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("artillery_level2", "price")) == 0);
    Label_0130:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("artillery_level3", "price")) == 0);
    Label_0151:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("barrack_level2", "price")) == 0);
    Label_0172:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("barrack_level3", "price")) == 0);
    Label_0193:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("mage_level2", "price")) == 0);
    Label_01B4:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("mage_level3", "price")) == 0);
    Label_01D5:
        return 1;
    Label_01D7:
        return 0;
    }

    protected unsafe bool CanUpgrade(string upgradeName = null)
    {
        string str;
        string str2;
        Dictionary<string, int> dictionary;
        int num;
        if (upgradeName == null)
        {
            goto Label_0013;
        }
        return this.stage.CanBuildTower(upgradeName);
    Label_0013:
        str2 = this.selectedTower.name;
        if (str2 == null)
        {
            goto Label_0163;
        }
        if (<>f__switch$map0 != null)
        {
            goto Label_009E;
        }
        dictionary = new Dictionary<string, int>(8);
        dictionary.Add("ArcherLvl1", 0);
        dictionary.Add("ArcherLvl2", 1);
        dictionary.Add("ArtilleryLvl1", 2);
        dictionary.Add("ArtilleryLvl2", 3);
        dictionary.Add("BarrackLvl1", 4);
        dictionary.Add("BarrackLvl2", 5);
        dictionary.Add("MageLvl1", 6);
        dictionary.Add("MageLvl2", 7);
        <>f__switch$map0 = dictionary;
    Label_009E:
        if (<>f__switch$map0.TryGetValue(str2, &num) == null)
        {
            goto Label_0163;
        }
        switch (num)
        {
            case 0:
                goto Label_00DB;

            case 1:
                goto Label_00EC;

            case 2:
                goto Label_00FD;

            case 3:
                goto Label_010E;

            case 4:
                goto Label_011F;

            case 5:
                goto Label_0130;

            case 6:
                goto Label_0141;

            case 7:
                goto Label_0152;
        }
        goto Label_0163;
    Label_00DB:
        return this.stage.CanBuildTower("ArcherLvl2");
    Label_00EC:
        return this.stage.CanBuildTower("ArcherLvl3");
    Label_00FD:
        return this.stage.CanBuildTower("ArtilleryLvl2");
    Label_010E:
        return this.stage.CanBuildTower("ArtilleryLvl3");
    Label_011F:
        return this.stage.CanBuildTower("BarrackLvl2");
    Label_0130:
        return this.stage.CanBuildTower("BarrackLvl3");
    Label_0141:
        return this.stage.CanBuildTower("MageLvl2");
    Label_0152:
        return this.stage.CanBuildTower("MageLvl3");
    Label_0163:
        return 0;
    }

    protected virtual unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { ((this.CanUpgrade(null) == null) ? this.MakeButton("locked", &this.upgradeButton.localPos.x, &this.upgradeButton.localPos.y) : this.MakeButton("UpgradeButton", &this.upgradeButton.localPos.x, &this.upgradeButton.localPos.y)), this.MakeButton("SellButton", &this.sellButton.localPos.x, &this.sellButton.localPos.y) };
    }

    public void HideUpgradeRange()
    {
        this.upgradeTower.HideRangeCircle();
        return;
    }

    public void HideUpgradeRangeCircle()
    {
        if ((this.rangeCircle != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.rangeCircle.gameObject);
    Label_0021:
        return;
    }

    public bool IsSelected()
    {
        return base.isSelected;
    }

    protected virtual TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "UpgradeButton") == null)
        {
            goto Label_003E;
        }
        button2 = UnityEngine.Object.Instantiate(this.upgradeButton, base.transform.position, base.transform.rotation) as TowerButton;
        goto Label_00F2;
    Label_003E:
        if ((button == "SellButton") == null)
        {
            goto Label_0077;
        }
        button2 = UnityEngine.Object.Instantiate(this.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_0077:
        if ((button == "RespawnButton") == null)
        {
            goto Label_00B0;
        }
        button2 = UnityEngine.Object.Instantiate(this.respawnButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_00B0:
        button2 = UnityEngine.Object.Instantiate(this.lockedButton, base.transform.position, base.transform.rotation) as TowerButton;
        button2.localPos = new Vector2(posX, posY);
        button2.SetAvailable(0);
        return button2;
    Label_00F2:
        button2.SetPrice(GameSettings.GetTowerPrice(this.upgradeTower.name));
        if (this.CanBuyTower(button) != null)
        {
            goto Label_011B;
        }
        button2.SetAvailable(0);
    Label_011B:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    protected override void MissClick()
    {
        base.isSelected = 0;
        return;
    }

    protected override void OnClick()
    {
        if (base.CheckButtonPriority() != null)
        {
            goto Label_005C;
        }
        if (base.isSelected != null)
        {
            goto Label_0039;
        }
        this.ShowMenu();
        base.isSelected = 1;
        this.selectedTower.ShowRangeCircle(Vector3.zero);
        goto Label_005C;
    Label_0039:
        base.isSelected = 0;
        this.menu.Hide();
        base.guiBottom.HideInfo(base.GetComponent<UnitClickable>());
    Label_005C:
        return;
    }

    protected virtual unsafe void ShowMenu()
    {
        Vector3 vector;
        Vector3 vector2;
        this.menu.Show(this, this.CreateButtons());
        this.menu.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -900f);
        return;
    }

    public virtual void ShowUpgradeRange(Vector3 position)
    {
        this.rangeCircle = this.upgradeTower.ShowRangeCircle(position);
        return;
    }

    private void Start()
    {
        base.isSelected = 0;
        this.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.selectedTower = base.GetComponent<TowerBase>();
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

