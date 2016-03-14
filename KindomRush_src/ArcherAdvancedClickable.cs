using System;
using UnityEngine;

public class ArcherAdvancedClickable : TowerBasicClickable
{
    public TowerButton musketeerButton;
    public TowerBase musketeerTower;
    public TowerButton rangerButton;
    public TowerBase rangerTower;

    public ArcherAdvancedClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public void BuildMusketeer(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        base2 = UnityEngine.Object.Instantiate(this.musketeerTower, base.transform.position, base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        base2.SetPrice((int) GameSettings.GetTowerSetting("archer_musketeer", "price"));
        base2.SetSpentBase(spent);
        base2.SetSpent((int) GameSettings.GetTowerSetting("archer_musketeer", "price"));
        base2.name = "ArcherMusketeer";
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerMusketeer();
        return;
    }

    public void BuildRanger(BuildTerrainClickable bt, int spent)
    {
        TowerBase base2;
        base2 = UnityEngine.Object.Instantiate(this.rangerTower, base.transform.position, base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(bt);
        base2.ShowUpgradeSmoke();
        base2.SetPrice((int) GameSettings.GetTowerSetting("archer_ranger", "price"));
        base2.SetSpentBase(spent);
        base2.SetSpent((int) GameSettings.GetTowerSetting("archer_ranger", "price"));
        base2.name = "ArcherRanger";
        GameAchievements.BuildTower();
        GameAchievements.BuildTowerRanger();
        return;
    }

    protected override bool CanBuyTower(string tower)
    {
        if ((tower == "RangerButton") == null)
        {
            goto Label_0031;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("archer_ranger", "price")) == 0);
    Label_0031:
        if ((tower == "MusketeerButton") == null)
        {
            goto Label_0062;
        }
        return ((((float) base.stage.GetGold()) < GameSettings.GetTowerSetting("archer_musketeer", "price")) == 0);
    Label_0062:
        return 0;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), ((base.CanUpgrade("ArcherRanger") == null) ? this.MakeButton("locked", &this.rangerButton.localPos.x, &this.rangerButton.localPos.y) : this.MakeButton("RangerButton", &this.rangerButton.localPos.x, &this.rangerButton.localPos.y)), ((base.CanUpgrade("ArcherMusketeer") == null) ? this.MakeButton("locked", &this.musketeerButton.localPos.x, &this.musketeerButton.localPos.y) : this.MakeButton("MusketeerButton", &this.musketeerButton.localPos.x, &this.musketeerButton.localPos.y)) };
    }

    public void HideUpgradeRange(string tower)
    {
        if ((tower == "Ranger") == null)
        {
            goto Label_0031;
        }
        if ((this.rangerTower != null) == null)
        {
            goto Label_0031;
        }
        this.rangerTower.HideRangeCircle();
        goto Label_005D;
    Label_0031:
        if ((tower == "Musketeer") == null)
        {
            goto Label_005D;
        }
        if ((this.musketeerTower != null) == null)
        {
            goto Label_005D;
        }
        this.musketeerTower.HideRangeCircle();
    Label_005D:
        return;
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        string str;
        button2 = null;
        str = null;
        if ((button == "RangerButton") == null)
        {
            goto Label_0046;
        }
        button2 = UnityEngine.Object.Instantiate(this.rangerButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "ArcherRanger";
        goto Label_0103;
    Label_0046:
        if ((button == "SellButton") == null)
        {
            goto Label_007F;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_007F:
        if ((button == "MusketeerButton") == null)
        {
            goto Label_00C1;
        }
        button2 = UnityEngine.Object.Instantiate(this.musketeerButton, base.transform.position, base.transform.rotation) as TowerButton;
        str = "ArcherMusketeer";
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
        if ((tower == "Ranger") == null)
        {
            goto Label_0033;
        }
        if ((this.rangerTower != null) == null)
        {
            goto Label_0033;
        }
        this.rangerTower.ShowRangeCircle(position);
        goto Label_0061;
    Label_0033:
        if ((tower == "Musketeer") == null)
        {
            goto Label_0061;
        }
        if ((this.musketeerTower != null) == null)
        {
            goto Label_0061;
        }
        this.musketeerTower.ShowRangeCircle(position);
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

