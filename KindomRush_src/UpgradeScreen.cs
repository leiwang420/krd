using System;
using System.Collections;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
    private Transform archerBar;
    private UpgradeScreenItem archerEagleEye;
    private UpgradeScreenItem archerFarshots;
    private UpgradeScreenItem archerPiercingShots;
    private UpgradeScreenItem archerPrecision;
    private UpgradeScreenItem archerSalvage;
    private Transform artilleryBar;
    private UpgradeScreenItem artilleryConcentratedFire;
    private UpgradeScreenItem artilleryFieldLogistic;
    private UpgradeScreenItem artilleryIndustrialization;
    private UpgradeScreenItem artilleryRangeFinder;
    private UpgradeScreenItem artillerySmartTargeting;
    private Transform barrackBar;
    private UpgradeScreenItem barrackBarbedArmor;
    private UpgradeScreenItem barrackBetterArmor;
    private UpgradeScreenItem barrackImprovedDeployment;
    private UpgradeScreenItem barrackSurvival;
    private UpgradeScreenItem barrackSurvival2;
    private UpgradeBuyButton buyButton;
    private Transform fireballBar;
    private UpgradeScreenItem fireballBiggerAndMeaner;
    private UpgradeScreenItem fireballBlazingEarth;
    private UpgradeScreenItem fireballBlazingSkies;
    private UpgradeScreenItem fireballCataclysm;
    private UpgradeScreenItem fireballScorchedEarth;
    private UpgradeScreenItem mageArcaneShatter;
    private Transform mageBar;
    private UpgradeScreenItem mageEmpoweredMagic;
    private UpgradeScreenItem mageHermeticStudy;
    private UpgradeScreenItem mageSlowCurse;
    private UpgradeScreenItem mageSpellReach;
    private Map map;
    private UpgradeScreenItem reinforceConscripts;
    private Transform reinforcementBar;
    private UpgradeScreenItem reinforcementLegionnaires;
    private UpgradeScreenItem reinforcementSpearThrow;
    private UpgradeScreenItem reinforcementsWarriors;
    private UpgradeScreenItem reinforcementWellFed;
    private UpgradeResetButton resetButton;
    private ArrayList sessionUpgrades;
    private TextMesh starCount;
    private UpgradeUndoButton undoButton;
    private UpgradeScreenButton upgradeScreenButton;
    private UpgradeScreenItem upgradeSelected;

    public UpgradeScreen()
    {
        base..ctor();
        return;
    }

    public void Buy()
    {
        if ((this.upgradeSelected != null) == null)
        {
            goto Label_00AB;
        }
        if (GameUpgrades.IsPreviousBought(this.upgradeSelected.Type) == null)
        {
            goto Label_00AB;
        }
        if (GameUpgrades.IsBought(this.upgradeSelected.Type) != null)
        {
            goto Label_00AB;
        }
        GameUpgrades.BuyUpgrade(this.upgradeSelected.Type);
        GameData.StarsSpent += this.upgradeSelected.Cost;
        GameData.StarsToSpent -= this.upgradeSelected.Cost;
        this.sessionUpgrades.Add(this.upgradeSelected);
        this.upgradeSelected.HideBorder();
        this.UpdateBars();
        this.RefreshButtonStatus();
        this.UpdateStarCount();
        GameSoundManager.PlayGUIBuyUpgrade();
    Label_00AB:
        return;
    }

    private void CleanUp()
    {
        base.transform.position = new Vector3(0f, 1600f, -910f);
        this.ResetFade(base.transform);
        return;
    }

    private void Fade(Transform t)
    {
        ParticleFadeOut @out;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if ((t.name == "hover") == null)
        {
            goto Label_0016;
        }
        return;
    Label_0016:
        if (t.GetComponent<PackedSprite>() == null)
        {
            goto Label_00B9;
        }
        if ((t.name == "bought") == null)
        {
            goto Label_004B;
        }
        if (t.GetComponent<PackedSprite>().IsHidden() != null)
        {
            goto Label_0070;
        }
    Label_004B:
        if ((t.name == "EffectClick") != null)
        {
            goto Label_0070;
        }
        if (t.GetComponent<PackedSprite>().IsHidden() == null)
        {
            goto Label_0071;
        }
    Label_0070:
        return;
    Label_0071:
        if (t.GetComponent<ParticleFadeOut>() != null)
        {
            goto Label_00AE;
        }
        @out = t.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        goto Label_00B9;
    Label_00AE:
        t.GetComponent<ParticleFadeOut>().Fade();
    Label_00B9:
        enumerator = t.GetEnumerator();
    Label_00C0:
        try
        {
            goto Label_00D8;
        Label_00C5:
            transform = (Transform) enumerator.Current;
            this.Fade(transform);
        Label_00D8:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00C5;
            }
            goto Label_00FA;
        }
        finally
        {
        Label_00E8:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00F3;
            }
        Label_00F3:
            disposable.Dispose();
        }
    Label_00FA:
        return;
    }

    public UpgradeScreenItem GetSelected()
    {
        return this.upgradeSelected;
    }

    public void Hide()
    {
        object[] objArray1;
        this.upgradeScreenButton.RefreshStars();
        this.sessionUpgrades.Clear();
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 81f, -910f), "time", (double) 0.2, "easetype", (iTween.EaseType) 7, "oncomplete", "CleanUp" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        this.Fade(base.transform);
        return;
    }

    private void RefreshButtonStatus()
    {
        this.archerPrecision.CheckStatus();
        this.archerFarshots.CheckStatus();
        this.archerPiercingShots.CheckStatus();
        this.archerEagleEye.CheckStatus();
        this.archerSalvage.CheckStatus();
        this.barrackSurvival.CheckStatus();
        this.barrackBetterArmor.CheckStatus();
        this.barrackImprovedDeployment.CheckStatus();
        this.barrackSurvival2.CheckStatus();
        this.barrackBarbedArmor.CheckStatus();
        this.mageSpellReach.CheckStatus();
        this.mageArcaneShatter.CheckStatus();
        this.mageHermeticStudy.CheckStatus();
        this.mageEmpoweredMagic.CheckStatus();
        this.mageSlowCurse.CheckStatus();
        this.artilleryConcentratedFire.CheckStatus();
        this.artilleryRangeFinder.CheckStatus();
        this.artilleryFieldLogistic.CheckStatus();
        this.artilleryIndustrialization.CheckStatus();
        this.artillerySmartTargeting.CheckStatus();
        this.fireballBlazingSkies.CheckStatus();
        this.fireballScorchedEarth.CheckStatus();
        this.fireballBiggerAndMeaner.CheckStatus();
        this.fireballBlazingEarth.CheckStatus();
        this.fireballCataclysm.CheckStatus();
        this.reinforcementWellFed.CheckStatus();
        this.reinforceConscripts.CheckStatus();
        this.reinforcementsWarriors.CheckStatus();
        this.reinforcementLegionnaires.CheckStatus();
        this.reinforcementSpearThrow.CheckStatus();
        if (GameData.StarsSpent != null)
        {
            goto Label_0164;
        }
        this.resetButton.Disable();
        goto Label_016F;
    Label_0164:
        this.resetButton.Enable();
    Label_016F:
        if (this.sessionUpgrades.Count != null)
        {
            goto Label_018F;
        }
        this.undoButton.Disable();
        goto Label_019A;
    Label_018F:
        this.undoButton.Enable();
    Label_019A:
        return;
    }

    public void Reset()
    {
        GameData.StarsSpent = 0;
        GameData.StarsToSpent = GameData.StarsWon;
        GameUpgrades.Reset();
        this.sessionUpgrades.Clear();
        this.UpdateStarCount();
        this.RefreshButtonStatus();
        this.UpdateBars();
        return;
    }

    private void ResetFade(Transform t)
    {
        ParticleFadeOut @out;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        @out = t.GetComponent<ParticleFadeOut>();
        if ((@out != null) == null)
        {
            goto Label_0019;
        }
        @out.Reset();
    Label_0019:
        enumerator = t.GetEnumerator();
    Label_0020:
        try
        {
            goto Label_0038;
        Label_0025:
            transform = (Transform) enumerator.Current;
            this.ResetFade(transform);
        Label_0038:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0025;
            }
            goto Label_005A;
        }
        finally
        {
        Label_0048:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0053;
            }
        Label_0053:
            disposable.Dispose();
        }
    Label_005A:
        return;
    }

    public void SetSelected(UpgradeScreenItem s)
    {
        this.upgradeSelected = s;
        return;
    }

    public void Show()
    {
        object[] objArray1;
        base.transform.position = new Vector3(0f, 90f, -910f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 40f, -910f), "time", (double) 0.25, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        if (GameData.StarsSpent != null)
        {
            goto Label_009D;
        }
        this.resetButton.Disable();
        goto Label_00A8;
    Label_009D:
        this.resetButton.Enable();
    Label_00A8:
        if (this.sessionUpgrades.Count != null)
        {
            goto Label_00C8;
        }
        this.undoButton.Disable();
        goto Label_00D3;
    Label_00C8:
        this.undoButton.Enable();
    Label_00D3:
        return;
    }

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.upgradeScreenButton = GameObject.Find("UpgradesButton").GetComponent<UpgradeScreenButton>();
        this.sessionUpgrades = new ArrayList();
        this.archerBar = GameObject.Find("ArcherBar").GetComponent<Transform>();
        this.barrackBar = GameObject.Find("BarrackBar").GetComponent<Transform>();
        this.mageBar = GameObject.Find("MageBar").GetComponent<Transform>();
        this.artilleryBar = GameObject.Find("ArtilleryBar").GetComponent<Transform>();
        this.fireballBar = GameObject.Find("FireballBar").GetComponent<Transform>();
        this.reinforcementBar = GameObject.Find("ReinforcementBar").GetComponent<Transform>();
        this.archerPrecision = base.transform.FindChild("ArcherBase").FindChild("Precision").GetComponent<UpgradeScreenItem>();
        this.archerFarshots = base.transform.FindChild("ArcherBase").FindChild("Far Shots").GetComponent<UpgradeScreenItem>();
        this.archerPiercingShots = base.transform.FindChild("ArcherBase").FindChild("Piercing Shots").GetComponent<UpgradeScreenItem>();
        this.archerEagleEye = base.transform.FindChild("ArcherBase").FindChild("Eagle Eye").GetComponent<UpgradeScreenItem>();
        this.archerSalvage = base.transform.FindChild("ArcherBase").FindChild("Salvage").GetComponent<UpgradeScreenItem>();
        this.archerPrecision.Init(4, 3);
        this.archerFarshots.Init(3, 2);
        this.archerPiercingShots.Init(2, 2);
        this.archerEagleEye.Init(1, 1);
        this.archerSalvage.Init(0, 1);
        this.barrackSurvival = base.transform.FindChild("BarrackBase").FindChild("Survival").GetComponent<UpgradeScreenItem>();
        this.barrackBetterArmor = base.transform.FindChild("BarrackBase").FindChild("BetterArmor").GetComponent<UpgradeScreenItem>();
        this.barrackImprovedDeployment = base.transform.FindChild("BarrackBase").FindChild("ImprovedDeployment").GetComponent<UpgradeScreenItem>();
        this.barrackSurvival2 = base.transform.FindChild("BarrackBase").FindChild("Survival2").GetComponent<UpgradeScreenItem>();
        this.barrackBarbedArmor = base.transform.FindChild("BarrackBase").FindChild("BarbedArmor").GetComponent<UpgradeScreenItem>();
        this.barrackSurvival.Init(5, 1);
        this.barrackBetterArmor.Init(6, 1);
        this.barrackImprovedDeployment.Init(7, 2);
        this.barrackSurvival2.Init(9, 2);
        this.barrackBarbedArmor.Init(8, 3);
        this.mageSpellReach = base.transform.FindChild("MageBase").FindChild("SpellReach").GetComponent<UpgradeScreenItem>();
        this.mageArcaneShatter = base.transform.FindChild("MageBase").FindChild("ArcaneShatter").GetComponent<UpgradeScreenItem>();
        this.mageHermeticStudy = base.transform.FindChild("MageBase").FindChild("HermeticStudy").GetComponent<UpgradeScreenItem>();
        this.mageEmpoweredMagic = base.transform.FindChild("MageBase").FindChild("EmpoweredMagic").GetComponent<UpgradeScreenItem>();
        this.mageSlowCurse = base.transform.FindChild("MageBase").FindChild("SlowCurse").GetComponent<UpgradeScreenItem>();
        this.mageSpellReach.Init(10, 1);
        this.mageArcaneShatter.Init(11, 1);
        this.mageHermeticStudy.Init(12, 2);
        this.mageEmpoweredMagic.Init(13, 2);
        this.mageSlowCurse.Init(14, 3);
        this.artilleryConcentratedFire = base.transform.FindChild("ArtilleryBase").FindChild("ConcentratedFire").GetComponent<UpgradeScreenItem>();
        this.artilleryRangeFinder = base.transform.FindChild("ArtilleryBase").FindChild("RangeFinder").GetComponent<UpgradeScreenItem>();
        this.artilleryFieldLogistic = base.transform.FindChild("ArtilleryBase").FindChild("FieldLogistics").GetComponent<UpgradeScreenItem>();
        this.artilleryIndustrialization = base.transform.FindChild("ArtilleryBase").FindChild("Industralization").GetComponent<UpgradeScreenItem>();
        this.artillerySmartTargeting = base.transform.FindChild("ArtilleryBase").FindChild("SmartTargeting").GetComponent<UpgradeScreenItem>();
        this.artilleryConcentratedFire.Init(15, 1);
        this.artilleryRangeFinder.Init(0x10, 1);
        this.artilleryFieldLogistic.Init(0x11, 2);
        this.artilleryIndustrialization.Init(0x12, 3);
        this.artillerySmartTargeting.Init(0x13, 3);
        this.fireballBlazingSkies = base.transform.FindChild("FireballBase").FindChild("BlazingSkies").GetComponent<UpgradeScreenItem>();
        this.fireballScorchedEarth = base.transform.FindChild("FireballBase").FindChild("ScorchedEarth").GetComponent<UpgradeScreenItem>();
        this.fireballBiggerAndMeaner = base.transform.FindChild("FireballBase").FindChild("BiggerAndMeaner").GetComponent<UpgradeScreenItem>();
        this.fireballBlazingEarth = base.transform.FindChild("FireballBase").FindChild("BlazingEarth").GetComponent<UpgradeScreenItem>();
        this.fireballCataclysm = base.transform.FindChild("FireballBase").FindChild("Cataclysm").GetComponent<UpgradeScreenItem>();
        this.fireballBlazingSkies.Init(20, 2);
        this.fireballScorchedEarth.Init(0x15, 2);
        this.fireballBiggerAndMeaner.Init(0x16, 3);
        this.fireballBlazingEarth.Init(0x17, 3);
        this.fireballCataclysm.Init(0x18, 3);
        this.reinforcementWellFed = base.transform.FindChild("ReinforcementBase").FindChild("WellFed").GetComponent<UpgradeScreenItem>();
        this.reinforceConscripts = base.transform.FindChild("ReinforcementBase").FindChild("Conscripts").GetComponent<UpgradeScreenItem>();
        this.reinforcementsWarriors = base.transform.FindChild("ReinforcementBase").FindChild("Warriors").GetComponent<UpgradeScreenItem>();
        this.reinforcementLegionnaires = base.transform.FindChild("ReinforcementBase").FindChild("Legionnaires").GetComponent<UpgradeScreenItem>();
        this.reinforcementSpearThrow = base.transform.FindChild("ReinforcementBase").FindChild("SpearThrow").GetComponent<UpgradeScreenItem>();
        this.reinforcementWellFed.Init(0x19, 2);
        this.reinforceConscripts.Init(0x1a, 3);
        this.reinforcementsWarriors.Init(0x1b, 3);
        this.reinforcementLegionnaires.Init(0x1c, 3);
        this.reinforcementSpearThrow.Init(0x1d, 4);
        this.starCount = base.transform.FindChild("StarContainer").FindChild("StarCount").GetComponent<TextMesh>();
        this.resetButton = base.transform.FindChild("ButtonReset").GetComponent<UpgradeResetButton>();
        this.undoButton = base.transform.FindChild("ButtonUndo").GetComponent<UpgradeUndoButton>();
        this.UpdateStarCount();
        this.UpdateBars();
        this.RefreshButtonStatus();
        return;
    }

    public void UnDo()
    {
        UpgradeScreenItem item;
        IEnumerator enumerator;
        IDisposable disposable;
        this.sessionUpgrades.Reverse();
        enumerator = this.sessionUpgrades.GetEnumerator();
    Label_0017:
        try
        {
            goto Label_0055;
        Label_001C:
            item = (UpgradeScreenItem) enumerator.Current;
            GameUpgrades.UndoUpgrade(item.Type);
            GameData.StarsSpent -= item.Cost;
            GameData.StarsToSpent += item.Cost;
        Label_0055:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001C;
            }
            goto Label_0077;
        }
        finally
        {
        Label_0065:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0070;
            }
        Label_0070:
            disposable.Dispose();
        }
    Label_0077:
        this.sessionUpgrades.Clear();
        this.RefreshButtonStatus();
        this.UpdateStarCount();
        this.UpdateBars();
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_0045;
        }
        if (&base.transform.position.y != 40f)
        {
            goto Label_0045;
        }
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.Hide();
    Label_0045:
        return;
    }

    private void UpdateBars()
    {
        int num;
        num = 0;
        num = GameUpgrades.ArchersUpLevel;
        if (num != 1)
        {
            goto Label_0033;
        }
        this.archerBar.localScale = new Vector3(1f, 0.1f, 1f);
        goto Label_00FE;
    Label_0033:
        if (num != 2)
        {
            goto Label_005E;
        }
        this.archerBar.localScale = new Vector3(1f, 0.3f, 1f);
        goto Label_00FE;
    Label_005E:
        if (num != 3)
        {
            goto Label_0089;
        }
        this.archerBar.localScale = new Vector3(1f, 0.5f, 1f);
        goto Label_00FE;
    Label_0089:
        if (num != 4)
        {
            goto Label_00B4;
        }
        this.archerBar.localScale = new Vector3(1f, 0.8f, 1f);
        goto Label_00FE;
    Label_00B4:
        if (num != 5)
        {
            goto Label_00DF;
        }
        this.archerBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00FE;
    Label_00DF:
        this.archerBar.localScale = new Vector3(1f, 0f, 1f);
    Label_00FE:
        num = GameUpgrades.BarracksUpLevel;
        if (num != 1)
        {
            goto Label_012F;
        }
        this.barrackBar.localScale = new Vector3(1f, 0.1f, 1f);
        goto Label_01FA;
    Label_012F:
        if (num != 2)
        {
            goto Label_015A;
        }
        this.barrackBar.localScale = new Vector3(1f, 0.3f, 1f);
        goto Label_01FA;
    Label_015A:
        if (num != 3)
        {
            goto Label_0185;
        }
        this.barrackBar.localScale = new Vector3(1f, 0.5f, 1f);
        goto Label_01FA;
    Label_0185:
        if (num != 4)
        {
            goto Label_01B0;
        }
        this.barrackBar.localScale = new Vector3(1f, 0.8f, 1f);
        goto Label_01FA;
    Label_01B0:
        if (num != 5)
        {
            goto Label_01DB;
        }
        this.barrackBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_01FA;
    Label_01DB:
        this.barrackBar.localScale = new Vector3(1f, 0f, 1f);
    Label_01FA:
        num = GameUpgrades.MagesUpLevel;
        if (num != 1)
        {
            goto Label_022B;
        }
        this.mageBar.localScale = new Vector3(1f, 0.1f, 1f);
        goto Label_02F6;
    Label_022B:
        if (num != 2)
        {
            goto Label_0256;
        }
        this.mageBar.localScale = new Vector3(1f, 0.3f, 1f);
        goto Label_02F6;
    Label_0256:
        if (num != 3)
        {
            goto Label_0281;
        }
        this.mageBar.localScale = new Vector3(1f, 0.5f, 1f);
        goto Label_02F6;
    Label_0281:
        if (num != 4)
        {
            goto Label_02AC;
        }
        this.mageBar.localScale = new Vector3(1f, 0.8f, 1f);
        goto Label_02F6;
    Label_02AC:
        if (num != 5)
        {
            goto Label_02D7;
        }
        this.mageBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_02F6;
    Label_02D7:
        this.mageBar.localScale = new Vector3(1f, 0f, 1f);
    Label_02F6:
        num = GameUpgrades.EngineersUpLevel;
        if (num != 1)
        {
            goto Label_0327;
        }
        this.artilleryBar.localScale = new Vector3(1f, 0.1f, 1f);
        goto Label_03F2;
    Label_0327:
        if (num != 2)
        {
            goto Label_0352;
        }
        this.artilleryBar.localScale = new Vector3(1f, 0.3f, 1f);
        goto Label_03F2;
    Label_0352:
        if (num != 3)
        {
            goto Label_037D;
        }
        this.artilleryBar.localScale = new Vector3(1f, 0.5f, 1f);
        goto Label_03F2;
    Label_037D:
        if (num != 4)
        {
            goto Label_03A8;
        }
        this.artilleryBar.localScale = new Vector3(1f, 0.8f, 1f);
        goto Label_03F2;
    Label_03A8:
        if (num != 5)
        {
            goto Label_03D3;
        }
        this.artilleryBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_03F2;
    Label_03D3:
        this.artilleryBar.localScale = new Vector3(1f, 0f, 1f);
    Label_03F2:
        num = GameUpgrades.RainUpLevel;
        if (num != 1)
        {
            goto Label_0423;
        }
        this.fireballBar.localScale = new Vector3(1f, 0.1f, 1f);
        goto Label_04EE;
    Label_0423:
        if (num != 2)
        {
            goto Label_044E;
        }
        this.fireballBar.localScale = new Vector3(1f, 0.3f, 1f);
        goto Label_04EE;
    Label_044E:
        if (num != 3)
        {
            goto Label_0479;
        }
        this.fireballBar.localScale = new Vector3(1f, 0.5f, 1f);
        goto Label_04EE;
    Label_0479:
        if (num != 4)
        {
            goto Label_04A4;
        }
        this.fireballBar.localScale = new Vector3(1f, 0.8f, 1f);
        goto Label_04EE;
    Label_04A4:
        if (num != 5)
        {
            goto Label_04CF;
        }
        this.fireballBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_04EE;
    Label_04CF:
        this.fireballBar.localScale = new Vector3(1f, 0f, 1f);
    Label_04EE:
        num = GameUpgrades.ReinforcementLevel;
        if (num != 1)
        {
            goto Label_051F;
        }
        this.reinforcementBar.localScale = new Vector3(1f, 0.1f, 1f);
        goto Label_05EA;
    Label_051F:
        if (num != 2)
        {
            goto Label_054A;
        }
        this.reinforcementBar.localScale = new Vector3(1f, 0.3f, 1f);
        goto Label_05EA;
    Label_054A:
        if (num != 3)
        {
            goto Label_0575;
        }
        this.reinforcementBar.localScale = new Vector3(1f, 0.5f, 1f);
        goto Label_05EA;
    Label_0575:
        if (num != 4)
        {
            goto Label_05A0;
        }
        this.reinforcementBar.localScale = new Vector3(1f, 0.8f, 1f);
        goto Label_05EA;
    Label_05A0:
        if (num != 5)
        {
            goto Label_05CB;
        }
        this.reinforcementBar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_05EA;
    Label_05CB:
        this.reinforcementBar.localScale = new Vector3(1f, 0f, 1f);
    Label_05EA:
        return;
    }

    private unsafe void UpdateStarCount()
    {
        int num;
        this.starCount.text = &GameData.StarsToSpent.ToString();
        return;
    }
}

