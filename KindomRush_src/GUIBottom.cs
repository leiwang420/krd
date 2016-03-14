using System;
using System.Collections;
using UnityEngine;

public class GUIBottom : MonoBehaviour
{
    private PackedSprite armorIcon;
    public Transform armorIconPrefab;
    private PackedSprite armorMagicIcon;
    private Transform barBack;
    private Transform barLife;
    private PackedSprite costIcon;
    public Transform costIconPrefab;
    private Creep creep;
    private PackedSprite damageIcon;
    public Transform damageIconPrefab;
    private Vector3 damageTextPosition;
    private Vector2 endPos2d;
    private Vector3 endPosition;
    private bool fireballActive;
    private PowerFireballPortrait fireballPower;
    private PackedSprite healthIcon;
    public Transform healthIconPrefab;
    public GUIStyle healthStyle;
    private bool heroChangedRallyPoint;
    private bool heroMoving;
    private HeroPortrait heroPortrait;
    private bool hidden;
    private float horizRatio;
    private Transform infoPanel;
    private Transform infoPanelCreep;
    private Vector3 infoPanelHidePosition;
    private Vector3 infoPanelOriginalPosition;
    private Transform infoPanelSoldier;
    private Transform infoPanelTowerBarrack;
    private Transform infoPanelTowerGeneral;
    public GUIStyle infoStyle;
    private bool isPaused;
    private PackedSprite mageDamageIcon;
    public Transform mageDamageIconPrefab;
    public Transform magicArmorIconPrefab;
    private float nameLabelY;
    public GUIStyle nameStyle;
    private Transform portrait;
    private Quickmenu quickmenu;
    private PackedSprite rangeIcon;
    public Transform rangeIconPrefab;
    private bool reinforcementActive;
    private PowerReinforcementPortrait reinforcementPower;
    private PackedSprite reloadIcon;
    public Transform reloadIconPrefab;
    private PackedSprite respawnIcon;
    public Transform respawnIconPrefab;
    private UnitClickable selectedHero;
    private UnitClickable selectedUnit;
    private UnitClickable selection;
    private int selectionID;
    private bool selectionOnThisFrame;
    private Soldier soldier;
    private PackedSprite sprite;
    private StageBase stage;
    private float starttime;
    private TextMesh textCreepArmor;
    private TextMesh textCreepCost;
    private TextMesh textCreepDamage;
    private TextMesh textCreepHealth;
    private TextMesh textCreepHealthShadow;
    private TextMesh textSoldierArmor;
    private TextMesh textSoldierDamage;
    private TextMesh textSoldierHealth;
    private TextMesh textSoldierHealthShadow;
    private TextMesh textSoldierRespawn;
    private TextMesh textTitle;
    private Vector3 textTitleDefaultPosition;
    private TextMesh textTowerBarrackArmor;
    private TextMesh textTowerBarrackDamage;
    private TextMesh textTowerBarrackHealth;
    private TextMesh textTowerBarrackRespawn;
    private TextMesh textTowerGeneralDamage;
    private TextMesh textTowerGeneralRange;
    private TextMesh textTowerGeneralReload;
    private TowerBase tower;
    private Vector3 tweenDir;
    private float tweenDistance;
    private float tweenSpeed;
    private float tweenTime;
    private float vertRatio;

    public GUIBottom()
    {
        this.nameLabelY = 1025f;
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.infoPanel = base.transform.FindChild("InfoPanel");
        this.barBack = this.infoPanel.FindChild("BarBack");
        this.barLife = this.barBack.FindChild("Bar");
        this.infoPanelSoldier = this.infoPanel.FindChild("InfoSoldier");
        this.infoPanelCreep = this.infoPanel.FindChild("InfoCreep");
        this.infoPanelTowerGeneral = this.infoPanel.FindChild("InfoTowerGeneral");
        this.infoPanelTowerBarrack = this.infoPanel.FindChild("InfoTowerBarrack");
        this.infoPanelHidePosition = this.infoPanel.transform.position;
        this.infoPanelOriginalPosition = this.infoPanelHidePosition + new Vector3(0f, 100f, 0f);
        return;
    }

    protected unsafe bool CheckHeroPortraitClick()
    {
        RaycastHit hit;
        UnityEngine.Ray ray;
        if ((this.heroPortrait == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return this.heroPortrait.collider.Raycast(ray, &hit, 1000f);
    }

    private unsafe bool ClickAbilityButton()
    {
        Transform transform;
        IEnumerator enumerator;
        RaycastHit hit;
        UnityEngine.Ray ray;
        bool flag;
        IDisposable disposable;
        if ((this.quickmenu.GetCurrentSelect() != null) == null)
        {
            goto Label_009E;
        }
        enumerator = this.quickmenu.transform.GetEnumerator();
    Label_0027:
        try
        {
            goto Label_0079;
        Label_002C:
            transform = (Transform) enumerator.Current;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (transform.collider.Raycast(ray, &hit, 1000f) == null)
            {
                goto Label_0079;
            }
            if ((transform.GetComponent<AbilityButton>() != null) == null)
            {
                goto Label_0079;
            }
            flag = 1;
            goto Label_00A0;
        Label_0079:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002C;
            }
            goto Label_009E;
        }
        finally
        {
        Label_0089:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0096;
            }
        Label_0096:
            disposable.Dispose();
        }
    Label_009E:
        return 0;
    Label_00A0:
        return flag;
    }

    private void DeselectHero()
    {
        if ((this.heroPortrait != null) == null)
        {
            goto Label_001C;
        }
        this.heroPortrait.UnselectHero();
    Label_001C:
        return;
    }

    public void HeroChangedRallyPoint()
    {
        if ((this.heroPortrait == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        this.heroChangedRallyPoint = 1;
        return;
    }

    public void HeroMoved()
    {
        if ((this.heroPortrait == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        this.heroMoving = 1;
        return;
    }

    private void HideIcons()
    {
        this.barBack.gameObject.SetActive(0);
        this.healthIcon.Hide(1);
        this.damageIcon.Hide(1);
        this.armorIcon.Hide(1);
        this.armorMagicIcon.Hide(1);
        this.respawnIcon.Hide(1);
        this.costIcon.Hide(1);
        this.rangeIcon.Hide(1);
        this.reloadIcon.Hide(1);
        this.mageDamageIcon.Hide(1);
        return;
    }

    public void HideInfo(UnitClickable u)
    {
        object[] objArray1;
        if ((u != this.selectedUnit) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        if ((this.portrait != null) == null)
        {
            goto Label_0033;
        }
        UnityEngine.Object.Destroy(this.portrait.gameObject);
    Label_0033:
        if ((this.selectedUnit != null) == null)
        {
            goto Label_0056;
        }
        this.selectedUnit.UnSelect();
        this.selectedUnit = null;
    Label_0056:
        this.hidden = 1;
        this.HideIcons();
        this.soldier = null;
        this.creep = null;
        this.tower = null;
        objArray1 = new object[] { "position", (Vector3) this.infoPanelHidePosition, "time", (float) 0.25f };
        iTween.MoveTo(this.infoPanel.gameObject, iTween.Hash(objArray1));
        return;
    }

    public void HideInfoOverride()
    {
        object[] objArray1;
        if ((this.portrait != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.portrait.gameObject);
    Label_0021:
        if ((this.selectedUnit != null) == null)
        {
            goto Label_0044;
        }
        this.selectedUnit.UnSelect();
        this.selectedUnit = null;
    Label_0044:
        this.hidden = 1;
        this.HideIcons();
        this.soldier = null;
        this.creep = null;
        this.tower = null;
        objArray1 = new object[] { "position", (Vector3) this.infoPanelHidePosition, "time", (float) 0.25f };
        iTween.MoveTo(this.infoPanel.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void InitIcons()
    {
        Transform transform;
        this.horizRatio = ((float) Screen.width) / 1920f;
        this.vertRatio = ((float) Screen.height) / 1080f;
        transform = null;
        transform = UnityEngine.Object.Instantiate(this.healthIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(-215f, -14f, -1f);
        this.healthIcon = transform.GetComponent<PackedSprite>();
        this.healthIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.damageIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(-57f, -14f, -1f);
        this.damageIcon = transform.GetComponent<PackedSprite>();
        this.damageIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.armorIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(100f, -14f, -1f);
        this.armorIcon = transform.GetComponent<PackedSprite>();
        this.armorIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.magicArmorIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(100f, -14f, -1f);
        this.armorMagicIcon = transform.GetComponent<PackedSprite>();
        this.armorMagicIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.respawnIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(260f, -14f, -1f);
        this.respawnIcon = transform.GetComponent<PackedSprite>();
        this.respawnIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.costIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(170f, -14f, -1f);
        this.costIcon = transform.GetComponent<PackedSprite>();
        this.costIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.rangeIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(170f, -14f, -1f);
        this.rangeIcon = transform.GetComponent<PackedSprite>();
        this.rangeIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.reloadIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(170f, -14f, -1f);
        this.reloadIcon = transform.GetComponent<PackedSprite>();
        this.reloadIcon.Hide(1);
        transform = UnityEngine.Object.Instantiate(this.mageDamageIconPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = this.infoPanel;
        transform.localPosition = new Vector3(-215f, -14f, -1f);
        this.mageDamageIcon = transform.GetComponent<PackedSprite>();
        this.mageDamageIcon.Hide(1);
        return;
    }

    public bool IsDeployingReinforcement()
    {
        return this.reinforcementPower.IsDeploying();
    }

    public bool IsFireballActive()
    {
        return this.fireballActive;
    }

    public bool IsHeroMoving()
    {
        if ((this.heroPortrait == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return this.heroMoving;
    }

    public unsafe bool IsHeroPortraitClicked()
    {
        UnityEngine.Ray ray;
        RaycastHit hit;
        if ((this.heroPortrait == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return this.heroPortrait.collider.Raycast(ray, &hit, 1000f);
    }

    public bool IsHeroSelected()
    {
        if ((this.heroPortrait == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return this.heroPortrait.IsSelected();
    }

    public bool IsLaunchingFireball()
    {
        return this.fireballPower.IsFiring();
    }

    public bool IsPowerActive()
    {
        return ((this.reinforcementActive != null) ? 1 : this.fireballActive);
    }

    public unsafe bool IsPowerClicked()
    {
        UnityEngine.Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ((this.fireballPower.collider.Raycast(ray, &hit, 1000f) != null) ? 1 : this.reinforcementPower.collider.Raycast(ray, &hit, 1000f));
    }

    public bool IsReinforcementActive()
    {
        return this.reinforcementActive;
    }

    private unsafe void LateUpdate()
    {
        UnitClickable[] clickableArray;
        UnitClickable clickable;
        RaycastHit hit;
        UnityEngine.Ray ray;
        UnitClickable clickable2;
        UnitClickable[] clickableArray2;
        int num;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_0104;
        }
        if (this.selectionOnThisFrame != null)
        {
            goto Label_0104;
        }
        if (this.CheckHeroPortraitClick() == null)
        {
            goto Label_002E;
        }
        return;
    Label_002E:
        clickableArray = UnityEngine.Object.FindObjectsOfType(typeof(UnitClickable)) as UnitClickable[];
        clickable = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickableArray2 = clickableArray;
        num = 0;
        goto Label_008E;
    Label_0060:
        clickable2 = clickableArray2[num];
        if (clickable2.collider.Raycast(ray, &hit, 1000f) == null)
        {
            goto Label_0088;
        }
        clickable = clickable2;
        goto Label_0099;
    Label_0088:
        num += 1;
    Label_008E:
        if (num < ((int) clickableArray2.Length))
        {
            goto Label_0060;
        }
    Label_0099:
        if ((clickable == null) == null)
        {
            goto Label_0104;
        }
        if (this.ClickAbilityButton() != null)
        {
            goto Label_0104;
        }
        if (this.stage.GetWaveRecentlyCalled() != null)
        {
            goto Label_0104;
        }
        if ((this.heroPortrait == null) != null)
        {
            goto Label_00F8;
        }
        if ((this.selectedUnit != null) == null)
        {
            goto Label_0104;
        }
        if ((this.selectedUnit.GetComponent<SoldierHero>() == null) == null)
        {
            goto Label_0104;
        }
    Label_00F8:
        this.HideInfo(this.selectedUnit);
    Label_0104:
        if ((this.selectedUnit != null) == null)
        {
            goto Label_011B;
        }
        this.UpdateInfo();
    Label_011B:
        this.selectionOnThisFrame = 0;
        this.heroMoving = 0;
        this.heroChangedRallyPoint = 0;
        return;
    }

    private void LoadPortrait()
    {
        GameObject obj2;
        obj2 = GameObject.Find("HeroPortrait");
        if ((obj2 != null) == null)
        {
            goto Label_0023;
        }
        this.heroPortrait = obj2.GetComponent<HeroPortrait>();
    Label_0023:
        return;
    }

    public void Pause()
    {
        this.fireballPower.gameObject.layer = 2;
        this.reinforcementPower.gameObject.layer = 2;
        this.isPaused = 1;
        this.fireballPower.Pause();
        this.fireballPower.GetComponent<PowerFireballController>().Pause();
        this.reinforcementPower.Pause();
        return;
    }

    public void RefreshTowerDamage(int min, int max)
    {
    }

    public void SelectHero(UnitClickable h)
    {
        this.selectedHero = h;
        return;
    }

    public void SetPowerFireballActive(bool active)
    {
        Stage1 stage;
        stage = this.stage.GetComponent<Stage1>();
        if (GameData.GetGameMode() != null)
        {
            goto Label_002E;
        }
        if ((stage != null) == null)
        {
            goto Label_002E;
        }
        if (stage.IsFireballNotificationShown() != null)
        {
            goto Label_002E;
        }
        return;
    Label_002E:
        this.DeselectHero();
        this.fireballActive = active;
        if (this.fireballActive != null)
        {
            goto Label_0062;
        }
        this.fireballPower.Deselect();
        this.fireballPower.HidePointer();
        Screen.showCursor = 1;
    Label_0062:
        return;
    }

    public void SetPowerReinforcementActive(bool active)
    {
        Stage1 stage;
        stage = this.stage.GetComponent<Stage1>();
        if (GameData.GetGameMode() != null)
        {
            goto Label_002E;
        }
        if ((stage != null) == null)
        {
            goto Label_002E;
        }
        if (stage.IsReinforceNotificationShown() != null)
        {
            goto Label_002E;
        }
        return;
    Label_002E:
        this.DeselectHero();
        this.reinforcementActive = active;
        if (this.reinforcementActive != null)
        {
            goto Label_0062;
        }
        this.reinforcementPower.Deselect();
        this.reinforcementPower.HidePointer();
        Screen.showCursor = 1;
    Label_0062:
        return;
    }

    public void SetSelected(UnitClickable u)
    {
        object[] objArray1;
        if (this.IsHeroSelected() == null)
        {
            goto Label_001D;
        }
        if ((u.GetComponent<SoldierHero>() == null) == null)
        {
            goto Label_001D;
        }
        return;
    Label_001D:
        if ((this.selectedUnit != null) == null)
        {
            goto Label_005A;
        }
        if ((this.selectedUnit.GetComponent<SoldierHero>() != null) == null)
        {
            goto Label_004F;
        }
        this.heroPortrait.Refresh();
    Label_004F:
        this.selectedUnit.UnSelect();
    Label_005A:
        this.selectedUnit = u;
        if ((this.selectedUnit != null) == null)
        {
            goto Label_00E3;
        }
        this.selectionOnThisFrame = 1;
        this.Show(this.selectedUnit);
        this.UpdateInfo();
        if (this.hidden == null)
        {
            goto Label_00E3;
        }
        objArray1 = new object[] { "position", (Vector3) this.infoPanelOriginalPosition, "time", (float) 0.25f };
        iTween.MoveTo(this.infoPanel.gameObject, iTween.Hash(objArray1));
        this.hidden = 0;
    Label_00E3:
        return;
    }

    private void SetupInfoPanel()
    {
        this.infoPanelHidePosition = this.infoPanel.transform.position;
        this.infoPanelOriginalPosition = this.infoPanelHidePosition + new Vector3(0f, 100f, 0f);
        return;
    }

    private void Show(UnitClickable s)
    {
        this.selection = s;
        this.textTitle.text = s.name;
        this.textTitle.transform.localPosition = this.textTitleDefaultPosition;
        if ((this.portrait != null) == null)
        {
            goto Label_004F;
        }
        UnityEngine.Object.Destroy(this.portrait.gameObject);
    Label_004F:
        this.portrait = UnityEngine.Object.Instantiate(this.selection.portrait, base.transform.position, Quaternion.identity) as Transform;
        this.portrait.parent = this.infoPanel;
        this.portrait.localPosition = new Vector3(-284f, -1f, -1f);
        this.soldier = this.selection.GetComponent<Soldier>();
        this.creep = this.selection.GetComponent<Creep>();
        this.tower = this.selection.GetComponent<TowerBase>();
        this.HideIcons();
        if ((this.soldier != null) == null)
        {
            goto Label_019A;
        }
        this.barBack.gameObject.SetActive(1);
        this.damageIcon.Hide(0);
        this.damageIcon.transform.localPosition = new Vector3(-53f, -14f, -1f);
        this.armorIcon.Hide(0);
        this.armorIcon.transform.localPosition = new Vector3(96f, -14f, -1f);
        this.respawnIcon.Hide(0);
        this.respawnIcon.transform.localPosition = new Vector3(258f, -14f, -1f);
        goto Label_05C7;
    Label_019A:
        if ((this.creep != null) == null)
        {
            goto Label_02D2;
        }
        this.barBack.gameObject.SetActive(1);
        this.damageIcon.Hide(0);
        this.damageIcon.transform.localPosition = new Vector3(-53f, -14f, -1f);
        this.armorIcon.Hide(0);
        this.armorIcon.transform.localPosition = new Vector3(96f, -14f, -1f);
        this.costIcon.Hide(0);
        this.costIcon.transform.localPosition = new Vector3(258f, -14f, -1f);
        if (this.creep.magicArmor == null)
        {
            goto Label_029D;
        }
        this.armorIcon.Hide(1);
        this.armorMagicIcon.Hide(0);
        this.armorMagicIcon.transform.localPosition = new Vector3(96f, -14f, -1f);
        goto Label_02CD;
    Label_029D:
        this.armorIcon.Hide(0);
        this.armorIcon.transform.localPosition = new Vector3(96f, -14f, -1f);
    Label_02CD:
        goto Label_05C7;
    Label_02D2:
        if ((this.tower != null) == null)
        {
            goto Label_05C7;
        }
        if ((this.selection.name == "Mage Tower") != null)
        {
            goto Label_0365;
        }
        if ((this.selection.name == "Adept Tower") != null)
        {
            goto Label_0365;
        }
        if ((this.selection.name == "Wizard Tower") != null)
        {
            goto Label_0365;
        }
        if ((this.selection.name == "Arcane Wizard") != null)
        {
            goto Label_0365;
        }
        if ((this.selection.name == "Sorcerer Mage") == null)
        {
            goto Label_03D6;
        }
    Label_0365:
        this.mageDamageIcon.Hide(0);
        this.rangeIcon.Hide(0);
        this.reloadIcon.Hide(0);
        this.rangeIcon.transform.localPosition = new Vector3(-23f, -14f, -1f);
        this.reloadIcon.transform.localPosition = new Vector3(170f, -14f, -1f);
        goto Label_05C7;
    Label_03D6:
        if ((this.selection.name == "Barracks") != null)
        {
            goto Label_0472;
        }
        if ((this.selection.name == "Footmen") != null)
        {
            goto Label_0472;
        }
        if ((this.selection.name == "Knights") != null)
        {
            goto Label_0472;
        }
        if ((this.selection.name == "Holy Order") != null)
        {
            goto Label_0472;
        }
        if ((this.selection.name == "Barbarian Hall") != null)
        {
            goto Label_0472;
        }
        if ((this.selection.name == "Sylvan Elves") == null)
        {
            goto Label_0537;
        }
    Label_0472:
        this.damageIcon.Hide(0);
        this.damageIcon.transform.localPosition = new Vector3(-57f, -14f, -1f);
        this.armorIcon.Hide(0);
        this.armorIcon.transform.localPosition = new Vector3(100f, -14f, -1f);
        this.healthIcon.Hide(0);
        this.healthIcon.transform.localPosition = new Vector3(-215f, -14f, -1f);
        this.respawnIcon.Hide(0);
        this.respawnIcon.transform.localPosition = new Vector3(260f, -14f, -1f);
        goto Label_05C7;
    Label_0537:
        this.damageIcon.Hide(0);
        this.damageIcon.transform.localPosition = new Vector3(-215f, -14f, -1f);
        this.rangeIcon.Hide(0);
        this.rangeIcon.transform.localPosition = new Vector3(-23f, -14f, -1f);
        this.reloadIcon.Hide(0);
        this.reloadIcon.transform.localPosition = new Vector3(170f, -14f, -1f);
    Label_05C7:
        return;
    }

    private void Start()
    {
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.quickmenu = GameObject.Find("Quickmenu").GetComponent<Quickmenu>();
        this.hidden = 1;
        this.selectionOnThisFrame = 0;
        this.selectedUnit = null;
        base.Invoke("LoadPortrait", 0.5f);
        this.fireballPower = base.transform.FindChild("PowersBackground").FindChild("Fireball Portrait").GetComponent<PowerFireballPortrait>();
        this.reinforcementPower = base.transform.FindChild("PowersBackground").FindChild("Reinforcement Portrait").GetComponent<PowerReinforcementPortrait>();
        this.barBack.gameObject.SetActive(0);
        this.InitIcons();
        this.textTitle = this.infoPanel.FindChild("Title").GetComponent<TextMesh>();
        this.textTitleDefaultPosition = this.textTitle.transform.localPosition;
        this.textSoldierArmor = this.infoPanelSoldier.FindChild("Armor").GetComponent<TextMesh>();
        this.textSoldierDamage = this.infoPanelSoldier.FindChild("Damage").GetComponent<TextMesh>();
        this.textSoldierHealth = this.infoPanelSoldier.FindChild("Health").GetComponent<TextMesh>();
        this.textSoldierHealthShadow = this.infoPanelSoldier.FindChild("HealthShadow").GetComponent<TextMesh>();
        this.textSoldierRespawn = this.infoPanelSoldier.FindChild("Respawn").GetComponent<TextMesh>();
        this.textCreepArmor = this.infoPanelCreep.FindChild("Armor").GetComponent<TextMesh>();
        this.textCreepDamage = this.infoPanelCreep.FindChild("Damage").GetComponent<TextMesh>();
        this.textCreepHealth = this.infoPanelCreep.FindChild("Health").GetComponent<TextMesh>();
        this.textCreepHealthShadow = this.infoPanelCreep.FindChild("HealthShadow").GetComponent<TextMesh>();
        this.textCreepCost = this.infoPanelCreep.FindChild("Cost").GetComponent<TextMesh>();
        this.textTowerGeneralDamage = this.infoPanelTowerGeneral.FindChild("Damage").GetComponent<TextMesh>();
        this.textTowerGeneralRange = this.infoPanelTowerGeneral.FindChild("Range").GetComponent<TextMesh>();
        this.textTowerGeneralReload = this.infoPanelTowerGeneral.FindChild("Reload").GetComponent<TextMesh>();
        this.textTowerBarrackArmor = this.infoPanelTowerBarrack.FindChild("Armor").GetComponent<TextMesh>();
        this.textTowerBarrackDamage = this.infoPanelTowerBarrack.FindChild("Damage").GetComponent<TextMesh>();
        this.textTowerBarrackHealth = this.infoPanelTowerBarrack.FindChild("Health").GetComponent<TextMesh>();
        this.textTowerBarrackRespawn = this.infoPanelTowerBarrack.FindChild("Respawn").GetComponent<TextMesh>();
        return;
    }

    public void Unpause()
    {
        this.fireballPower.gameObject.layer = 9;
        this.reinforcementPower.gameObject.layer = 9;
        this.isPaused = 0;
        this.fireballPower.Unpause();
        this.fireballPower.GetComponent<PowerFireballController>().Unpause();
        this.reinforcementPower.Unpause();
        return;
    }

    private unsafe void UpdateInfo()
    {
        int num;
        int num2;
        int num3;
        int num4;
        int num5;
        int num6;
        int num7;
        int num8;
        int num9;
        this.infoPanelSoldier.gameObject.SetActive(0);
        this.infoPanelCreep.gameObject.SetActive(0);
        this.infoPanelTowerGeneral.gameObject.SetActive(0);
        this.infoPanelTowerBarrack.gameObject.SetActive(0);
        if ((this.soldier != null) == null)
        {
            goto Label_0305;
        }
        this.UpdateLifeBar();
        this.infoPanelSoldier.gameObject.SetActive(1);
        this.textSoldierHealth.text = &this.soldier.GetHealth().ToString() + "/" + &this.soldier.GetInitHealth().ToString();
        this.textSoldierHealthShadow.text = &this.soldier.GetHealth().ToString() + "/" + &this.soldier.GetInitHealth().ToString();
        this.textSoldierDamage.text = &this.soldier.minDamage.ToString() + "-" + &this.soldier.maxDamage.ToString();
        this.textSoldierArmor.text = this.soldier.GetArmor().ToString();
        if ((this.soldier.GetComponent<SoldierHero>() != null) == null)
        {
            goto Label_023A;
        }
        num5 = this.soldier.deadTime / 30;
        this.textSoldierRespawn.text = &num5.ToString() + "s";
        if ((this.selectedUnit.name == "Alleria Swiftwind") != null)
        {
            goto Label_01F6;
        }
        if ((this.selectedUnit.name == "Bolin Farslayer") != null)
        {
            goto Label_01F6;
        }
        if ((this.selectedUnit.name == "King Denas") != null)
        {
            goto Label_01F6;
        }
        if ((this.selectedUnit.name == "Elora") != null)
        {
            goto Label_01F6;
        }
        if ((this.selectedUnit.name == "Magnus Spellbane") == null)
        {
            goto Label_064A;
        }
    Label_01F6:
        this.textSoldierDamage.text = &((SoldierHero) this.soldier).rangeShootMinDamage.ToString() + "-" + &((SoldierHero) this.soldier).rangeShootMaxDamage.ToString();
        goto Label_0300;
    Label_023A:
        if ((this.soldier.GetComponent<SoldierElf>() != null) != null)
        {
            goto Label_027C;
        }
        if ((this.soldier.GetComponent<SoldierImperial>() != null) != null)
        {
            goto Label_027C;
        }
        if ((this.soldier.GetTower() == null) == null)
        {
            goto Label_0291;
        }
    Label_027C:
        this.textSoldierRespawn.text = "-";
        goto Label_0300;
    Label_0291:
        if ((this.soldier.GetComponent<SoldierElemental>() != null) == null)
        {
            goto Label_02D1;
        }
        this.textSoldierRespawn.text = &this.soldier.respawnTime.ToString() + "s";
        goto Label_0300;
    Label_02D1:
        this.textSoldierRespawn.text = &((BarrackTower) this.soldier.GetTower()).respawn.ToString() + "s";
    Label_0300:
        goto Label_064A;
    Label_0305:
        if ((this.creep != null) == null)
        {
            goto Label_0447;
        }
        this.UpdateLifeBar();
        this.infoPanelCreep.gameObject.SetActive(1);
        this.textCreepHealth.text = &this.creep.GetHealth().ToString() + "/" + &this.creep.GetTotalLife().ToString();
        this.textCreepHealthShadow.text = &this.creep.GetHealth().ToString() + "/" + &this.creep.GetTotalLife().ToString();
        this.textCreepDamage.text = &this.creep.minDamage.ToString() + "-" + &this.creep.maxDamage.ToString();
        if (this.creep.magicArmor == null)
        {
            goto Label_040C;
        }
        this.textCreepArmor.text = this.creep.GetMagicArmor().ToString();
        goto Label_0427;
    Label_040C:
        this.textCreepArmor.text = this.creep.GetArmor().ToString();
    Label_0427:
        this.textCreepCost.text = &this.creep.cost.ToString();
        goto Label_064A;
    Label_0447:
        if ((this.tower != null) == null)
        {
            goto Label_064A;
        }
        if ((this.selection.name == "Barracks") != null)
        {
            goto Label_04F4;
        }
        if ((this.selection.name == "Footmen") != null)
        {
            goto Label_04F4;
        }
        if ((this.selection.name == "Knights") != null)
        {
            goto Label_04F4;
        }
        if ((this.selection.name == "Holy Order") != null)
        {
            goto Label_04F4;
        }
        if ((this.selection.name == "Barbarian Hall") != null)
        {
            goto Label_04F4;
        }
        if ((this.selection.name == "Sylvan Elves") == null)
        {
            goto Label_05CE;
        }
    Label_04F4:
        this.infoPanelTowerBarrack.gameObject.SetActive(1);
        this.textTowerBarrackArmor.text = IronUtils.GetArmor(((BarrackTower) this.tower).armor);
        this.textTowerBarrackDamage.text = &this.tower.minDamange.ToString() + "-" + &this.tower.maxDamage.ToString();
        this.textTowerBarrackHealth.text = &((BarrackTower) this.tower).health.ToString();
        if ((this.selection.name == "Sylvan Elves") == null)
        {
            goto Label_05A9;
        }
        this.textTowerBarrackRespawn.text = "-";
        goto Label_05C9;
    Label_05A9:
        this.textTowerBarrackRespawn.text = &((BarrackTower) this.tower).respawn.ToString();
    Label_05C9:
        goto Label_064A;
    Label_05CE:
        this.infoPanelTowerGeneral.gameObject.SetActive(1);
        this.textTowerGeneralDamage.text = &this.tower.minDamange.ToString() + "-" + &this.tower.maxDamage.ToString();
        this.textTowerGeneralRange.text = this.tower.GetRange().ToString();
        this.textTowerGeneralReload.text = this.tower.GetReload().ToString();
    Label_064A:
        return;
    }

    private void UpdateLifeBar()
    {
        float num;
        float num2;
        float num3;
        num = 1f;
        if ((this.soldier != null) == null)
        {
            goto Label_0049;
        }
        num2 = (float) this.soldier.GetHealth();
        if (num2 >= 0f)
        {
            goto Label_0035;
        }
        num2 = 0f;
    Label_0035:
        num = num2 / ((float) this.soldier.GetInitHealth());
        goto Label_0087;
    Label_0049:
        if ((this.creep != null) == null)
        {
            goto Label_0087;
        }
        num3 = (float) this.creep.GetHealth();
        if (num3 >= 0f)
        {
            goto Label_0078;
        }
        num3 = 0f;
    Label_0078:
        num = num3 / ((float) this.creep.GetTotalLife());
    Label_0087:
        if ((this.barLife != null) == null)
        {
            goto Label_00DA;
        }
        if (num < 3.402823E+38f)
        {
            goto Label_00AE;
        }
        num = 1f;
        goto Label_00BF;
    Label_00AE:
        if (num > -3.402823E+38f)
        {
            goto Label_00BF;
        }
        num = 0f;
    Label_00BF:
        this.barLife.localScale = new Vector3(num, 1f, 1f);
    Label_00DA:
        return;
    }
}

