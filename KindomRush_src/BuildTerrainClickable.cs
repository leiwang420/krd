using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BuildTerrainClickable : Clickable
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map3;
    public ArcherTower archer;
    public TowerButton archerButton;
    public ConstructingTower archerConstruction;
    public ArtilleryTower artillery;
    public TowerButton artilleryButton;
    public ConstructingTower artilleryConstruction;
    public BarrackTower barrack;
    public ConstructingTower barrackConstruction;
    public TowerButton barracksButton;
    public TowerButton lockedButton;
    public MageTower mage;
    public TowerButton mageButton;
    public ConstructingTower mageConstruction;
    private Quickmenu menu;
    public Vector2 rallyPoint;
    private GameSettings settings;
    private PackedSprite sprite;
    private StageBase stage;

    public BuildTerrainClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public void BuildArcher()
    {
        TowerBase base2;
        ConstructingTower tower;
        base2 = UnityEngine.Object.Instantiate(this.archer, base.transform.position + new Vector3(0f, (float) this.archer.yAdjust, 0f), base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(this);
        base2.name = "ArcherLvl1";
        base2.gameObject.SetActive(0);
        base2.SetPrice((int) GameSettings.GetTowerSetting("archer_level1", "price"));
        base2.SetSpent((int) GameSettings.GetTowerSetting("archer_level1", "price"));
        tower = UnityEngine.Object.Instantiate(this.archerConstruction, base.transform.position + new Vector3(0f, (float) this.archer.yAdjust, 0f), base.transform.rotation) as ConstructingTower;
        tower.SetTower(base2);
        base.gameObject.SetActive(0);
        GameAchievements.BuildTower();
        return;
    }

    public void BuildArtillery()
    {
        TowerBase base2;
        ConstructingTower tower;
        base2 = UnityEngine.Object.Instantiate(this.artillery, base.transform.position + new Vector3(0f, (float) this.artillery.yAdjust, 0f), base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(this);
        base2.name = "ArtilleryLvl1";
        base2.gameObject.SetActive(0);
        base2.SetPrice((int) GameSettings.GetTowerSetting("artillery_level1", "price"));
        base2.SetSpent((int) GameSettings.GetTowerSetting("artillery_level1", "price"));
        tower = UnityEngine.Object.Instantiate(this.artilleryConstruction, base.transform.position + new Vector3(0f, (float) this.artillery.yAdjust, 0f), base.transform.rotation) as ConstructingTower;
        tower.SetTower(base2);
        base.gameObject.SetActive(0);
        GameAchievements.BuildTower();
        return;
    }

    public unsafe void BuildBarrack()
    {
        TowerBase base2;
        ConstructingTower tower;
        base2 = UnityEngine.Object.Instantiate(this.barrack, base.transform.position + new Vector3(0f, (float) this.barrack.yAdjust, 0f), base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(this);
        base2.GetComponent<BarrackTower>().SetRallyPoint(&this.rallyPoint.x, &this.rallyPoint.y);
        base2.name = "BarrackLvl1";
        base2.gameObject.SetActive(0);
        base2.SetPrice((int) GameSettings.GetTowerSetting("barrack_level1", "price"));
        base2.SetSpent((int) GameSettings.GetTowerSetting("barrack_level1", "price"));
        tower = UnityEngine.Object.Instantiate(this.barrackConstruction, base.transform.position + new Vector3(0f, (float) this.barrack.yAdjust, 0f), base.transform.rotation) as ConstructingTower;
        tower.SetTower(base2);
        base.gameObject.SetActive(0);
        GameAchievements.BuildTower();
        return;
    }

    public void BuildMage()
    {
        TowerBase base2;
        ConstructingTower tower;
        base2 = UnityEngine.Object.Instantiate(this.mage, base.transform.position + new Vector3(0f, (float) this.mage.yAdjust, 0f), base.transform.rotation) as TowerBase;
        base2.SetBuildTerrain(this);
        base2.name = "MageLvl1";
        base2.gameObject.SetActive(0);
        base2.SetPrice((int) GameSettings.GetTowerSetting("mage_level1", "price"));
        base2.SetSpent((int) GameSettings.GetTowerSetting("mage_level1", "price"));
        tower = UnityEngine.Object.Instantiate(this.mageConstruction, base.transform.position + new Vector3(0f, (float) this.mage.yAdjust, 0f), base.transform.rotation) as ConstructingTower;
        tower.SetTower(base2);
        base.gameObject.SetActive(0);
        GameAchievements.BuildTower();
        return;
    }

    private unsafe bool CanBuyTower(string tower)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = tower;
        if (str == null)
        {
            goto Label_0112;
        }
        if (<>f__switch$map3 != null)
        {
            goto Label_005B;
        }
        dictionary = new Dictionary<string, int>(5);
        dictionary.Add("ArcherLvl1", 0);
        dictionary.Add("ArtilleryLvl1", 1);
        dictionary.Add("BarrackLvl1", 2);
        dictionary.Add("MageLvl1", 3);
        dictionary.Add("locked", 4);
        <>f__switch$map3 = dictionary;
    Label_005B:
        if (<>f__switch$map3.TryGetValue(str, &num) == null)
        {
            goto Label_0112;
        }
        switch (num)
        {
            case 0:
                goto Label_008C;

            case 1:
                goto Label_00AD;

            case 2:
                goto Label_00CE;

            case 3:
                goto Label_00EF;

            case 4:
                goto Label_0110;
        }
        goto Label_0112;
    Label_008C:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("archer_level1", "price")) == 0);
    Label_00AD:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("artillery_level1", "price")) == 0);
    Label_00CE:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("barrack_level1", "price")) == 0);
    Label_00EF:
        return ((((float) this.stage.GetGold()) < GameSettings.GetTowerSetting("mage_level1", "price")) == 0);
    Label_0110:
        return 1;
    Label_0112:
        return 0;
    }

    private unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { ((this.stage.CanBuildTower("ArcherLvl1") == null) ? this.MakeButton("locked", &this.archerButton.localPos.x, &this.archerButton.localPos.y) : this.MakeButton("ArcherLvl1", &this.archerButton.localPos.x, &this.archerButton.localPos.y)), ((this.stage.CanBuildTower("ArtilleryLvl1") == null) ? this.MakeButton("locked", &this.artilleryButton.localPos.x, &this.artilleryButton.localPos.y) : this.MakeButton("ArtilleryLvl1", &this.artilleryButton.localPos.x, &this.artilleryButton.localPos.y)), ((this.stage.CanBuildTower("BarrackLvl1") == null) ? this.MakeButton("locked", &this.barracksButton.localPos.x, &this.barracksButton.localPos.y) : this.MakeButton("BarrackLvl1", &this.barracksButton.localPos.x, &this.barracksButton.localPos.y)), ((this.stage.CanBuildTower("MageLvl1") == null) ? this.MakeButton("locked", &this.mageButton.localPos.x, &this.mageButton.localPos.y) : this.MakeButton("MageLvl1", &this.mageButton.localPos.x, &this.mageButton.localPos.y)) };
    }

    private TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "ArcherLvl1") == null)
        {
            goto Label_003E;
        }
        button2 = UnityEngine.Object.Instantiate(this.archerButton, base.transform.position, base.transform.rotation) as TowerButton;
        goto Label_0119;
    Label_003E:
        if ((button == "ArtilleryLvl1") == null)
        {
            goto Label_007A;
        }
        button2 = UnityEngine.Object.Instantiate(this.artilleryButton, base.transform.position, base.transform.rotation) as TowerButton;
        goto Label_0119;
    Label_007A:
        if ((button == "BarrackLvl1") == null)
        {
            goto Label_00B6;
        }
        button2 = UnityEngine.Object.Instantiate(this.barracksButton, base.transform.position, base.transform.rotation) as TowerButton;
        goto Label_0119;
    Label_00B6:
        if ((button == "MageLvl1") == null)
        {
            goto Label_00F2;
        }
        button2 = UnityEngine.Object.Instantiate(this.mageButton, base.transform.position, base.transform.rotation) as TowerButton;
        goto Label_0119;
    Label_00F2:
        button2 = UnityEngine.Object.Instantiate(this.lockedButton, base.transform.position, base.transform.rotation) as TowerButton;
    Label_0119:
        if ((button != "locked") == null)
        {
            goto Label_0135;
        }
        button2.SetPrice(GameSettings.GetTowerPrice(button));
    Label_0135:
        if (this.CanBuyTower(button) != null)
        {
            goto Label_0148;
        }
        button2.SetAvailable(0);
    Label_0148:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    protected override void MissClick()
    {
        base.isSelected = 0;
        this.sprite.RevertToStatic();
        return;
    }

    protected override unsafe void OnClick()
    {
        Vector3 vector;
        Vector3 vector2;
        if (base.CheckButtonPriority() != null)
        {
            goto Label_0091;
        }
        if (base.isSelected != null)
        {
            goto Label_008A;
        }
        this.menu.Show(this, this.CreateButtons());
        this.menu.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y + 10f, -850f);
        base.isSelected = 1;
        this.sprite.PlayAnim("over");
        goto Label_0091;
    Label_008A:
        base.isSelected = 0;
    Label_0091:
        return;
    }

    protected void OnMouseEnter()
    {
        GameSoundManager.PlayGUIQuickMenuOver();
        this.sprite.PlayAnim("over");
        return;
    }

    protected void OnMouseExit()
    {
        if (base.isSelected != null)
        {
            goto Label_0016;
        }
        this.sprite.RevertToStatic();
    Label_0016:
        return;
    }

    private void Start()
    {
        base.isSelected = 0;
        this.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

