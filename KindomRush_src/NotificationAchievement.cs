using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NotificationAchievement : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$mapC;
    private Transform currentIcon;
    private Transform iconAcdc;
    private Transform iconAcorn;
    private Transform iconArmaggedon;
    private Transform iconArmyOfOne;
    private Transform iconAxeRainer;
    private Transform iconBarbarianRush;
    private Transform iconBloodlust;
    private Transform iconBuildArcanes;
    private Transform iconBuildBarbarians;
    private Transform iconBuildBfg;
    private Transform iconBuildMusketeers;
    private Transform iconBuildPaladins;
    private Transform iconBuildRangers;
    private Transform iconBuildSorcerers;
    private Transform iconBuildTesla;
    private Transform iconCannonFodder;
    private Transform iconClusterRain;
    private Transform iconCoolRunning;
    private Transform iconDaring;
    private Transform iconDeathFromAbove;
    private Transform iconDefeatMoloch;
    private Transform iconDefeatMushroom;
    private Transform iconDieHard;
    private Transform iconDineInHell;
    private Transform iconDustToDust;
    private Transform iconEarn15Stars;
    private Transform iconEarn30Stars;
    private Transform iconEarn45Stars;
    private Transform iconEasyTowerBuilder;
    private Transform iconElementalist;
    private Transform iconEnergyNetwork;
    private Transform iconEntangled;
    private Transform iconFearless;
    private Transform iconFirstBlood;
    private Transform iconFisherman;
    private Transform iconFreeFredo;
    private Transform iconGiJoe;
    private Transform iconGreatDefender;
    private Transform iconGreatDefenderHeroic;
    private Transform iconGreatDefenderIron;
    private Transform iconHardTowerBuilder;
    private Transform iconHenderson;
    private Transform iconHolyChorus;
    private Transform iconImpatient;
    private Transform iconImperialSaviour;
    private Transform iconIndecisive;
    private Transform iconKillEndBoss;
    private Transform iconKillGulThak;
    private Transform iconKillJuggernaut;
    private Transform iconKillKingping;
    private Transform iconKillMountainBoss;
    private Transform iconKillSarelgaz;
    private Transform iconKillTreant;
    private Transform iconLevelHeroMax;
    private Transform iconLevelHeroMedium;
    private Transform iconMageBeamMeUp;
    private Transform iconMaxElves;
    private Transform iconMedic;
    private Transform iconMediumTowerBuilder;
    private Transform iconMultiKill;
    private Transform iconMushroom;
    private Transform iconRallyChanges;
    private Transform iconRealEstate;
    private Transform iconRocketeer;
    private Transform iconSheepKiller;
    private Transform iconShepard;
    private Transform iconSlayer;
    private Transform iconSniper;
    private Transform iconSpecialization;
    private Transform iconSpore;
    private Transform iconStillCountsAsOne;
    private Transform iconTowerUpgradeLevel3;
    private Transform iconToxicity;
    private Transform iconTrollBoss;
    private Transform iconWhatsThat;
    private Vector3 showPosition;
    private TextMesh textDescription;
    private TextMesh textTitle;

    public NotificationAchievement()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Init()
    {
        this.LoadIcons();
        this.textDescription = base.transform.FindChild("Description").GetComponent<TextMesh>();
        this.textTitle = base.transform.FindChild("Title").GetComponent<TextMesh>();
        return;
    }

    private void LoadIcons()
    {
        Transform transform;
        transform = base.transform.FindChild("Icons");
        this.iconAcdc = transform.FindChild("IconACDC");
        this.iconArmaggedon = transform.FindChild("IconArmaggedon");
        this.iconKillSarelgaz = transform.FindChild("IconAracnophobia");
        this.iconAxeRainer = transform.FindChild("IconAxeRain");
        this.iconMageBeamMeUp = transform.FindChild("IconBeamMeUp");
        this.iconBloodlust = transform.FindChild("IconBloodlust");
        this.iconCannonFodder = transform.FindChild("IconCannonFodder");
        this.iconLevelHeroMedium = transform.FindChild("IconChampOfLinirea");
        this.iconClusterRain = transform.FindChild("IconClustered");
        this.iconEasyTowerBuilder = transform.FindChild("IconConstructor");
        this.iconDaring = transform.FindChild("IconDaring");
        this.iconDeathFromAbove = transform.FindChild("IconDeathFromAbove");
        this.iconDieHard = transform.FindChild("IconDieHard");
        this.iconDustToDust = transform.FindChild("IconDustToDust");
        this.iconElementalist = transform.FindChild("IconElementalist");
        this.iconEnergyNetwork = transform.FindChild("IconEnergyNetwork");
        this.iconMediumTowerBuilder = transform.FindChild("IconEngineer");
        this.iconEntangled = transform.FindChild("IconEntangled");
        this.iconFearless = transform.FindChild("IconFearless");
        this.iconFirstBlood = transform.FindChild("IconFirstBlood");
        this.iconMaxElves = transform.FindChild("IconForestDiplomacy");
        this.iconFreeFredo = transform.FindChild("IconFreeFredo");
        this.iconGiJoe = transform.FindChild("IconGIJoe");
        this.iconGreatDefender = transform.FindChild("IconGreatDefender");
        this.iconGreatDefenderHeroic = transform.FindChild("IconHeroicDefender");
        this.iconHolyChorus = transform.FindChild("IconHolyChorus");
        this.iconTowerUpgradeLevel3 = transform.FindChild("IconHomeImprovement");
        this.iconKillKingping = transform.FindChild("IconIAmTheLaw");
        this.iconImpatient = transform.FindChild("IconImpatient");
        this.iconImperialSaviour = transform.FindChild("IconImperialSaviour");
        this.iconIndecisive = transform.FindChild("IconIndecisive");
        this.iconGreatDefenderIron = transform.FindChild("IconIronDefender");
        this.iconKillMountainBoss = transform.FindChild("IconIsHeDeadYeti");
        this.iconLevelHeroMax = transform.FindChild("IconLegendOfLinirea");
        this.iconHenderson = transform.FindChild("IconLikeAHenderson");
        this.iconKillTreant = transform.FindChild("IconLumberjack");
        this.iconMedic = transform.FindChild("IconMedic");
        this.iconBarbarianRush = transform.FindChild("IconNotEntertained");
        this.iconKillJuggernaut = transform.FindChild("IconNutsAndBolts");
        this.iconKillGulThak = transform.FindChild("IconOrcsMustDie");
        this.iconSheepKiller = transform.FindChild("IconOvinophobia");
        this.iconRealEstate = transform.FindChild("IconRealEstate");
        this.iconRocketeer = transform.FindChild("IconRocketeer");
        this.iconShepard = transform.FindChild("IconOvinophobia");
        this.iconSlayer = transform.FindChild("IconSlayer");
        this.iconSpecialization = transform.FindChild("IconSpecialist");
        this.iconEarn15Stars = transform.FindChild("IconStarry");
        this.iconEarn30Stars = transform.FindChild("IconSuperMario");
        this.iconEarn45Stars = transform.FindChild("IconSuperstar");
        this.iconRallyChanges = transform.FindChild("IconTactician");
        this.iconMultiKill = transform.FindChild("IconTerminator");
        this.iconHardTowerBuilder = transform.FindChild("IconTheArchitect");
        this.iconKillEndBoss = transform.FindChild("IconThisIsTheEnd");
        this.iconToxicity = transform.FindChild("IconToxicity");
        this.iconFisherman = transform.FindChild("IconTwinRivers");
        this.iconWhatsThat = transform.FindChild("IconWhatsThat");
        this.iconSniper = transform.FindChild("Icon50Shots50Kills");
        this.iconAcorn = transform.FindChild("IconAcorn");
        this.iconMushroom = transform.FindChild("IconMushroom");
        this.iconTrollBoss = transform.FindChild("IconTrollBoss");
        this.iconCoolRunning = transform.FindChild("IconCoolRunning");
        this.iconDineInHell = transform.FindChild("IconDineInHell");
        this.iconArmyOfOne = transform.FindChild("IconArmyOfOne");
        this.iconDefeatMoloch = transform.FindChild("IconDefeatMoloch");
        this.iconSpore = transform.FindChild("IconSpore");
        this.iconDefeatMushroom = transform.FindChild("IconDefeatMushroom");
        this.iconStillCountsAsOne = transform.FindChild("IconStillCountsAsOne");
        return;
    }

    private void PopIn()
    {
        object[] objArray1;
        GameSoundManager.PlayGUIAchievementWin();
        base.transform.position = new Vector3(0f, 454f, -905f);
        base.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.2f, "easetype", (iTween.EaseType) 0x1c, "oncomplete", "PopInEnd" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void PopInEnd()
    {
        base.Invoke("PopOut", 2f);
        return;
    }

    private void PopOut()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) (base.transform.position + new Vector3(0f, 400f, 0f)), "time", (float) 1f, "oncomplete", "PopOutEnd" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void PopOutEnd()
    {
        base.gameObject.SetActive(0);
        if ((this.currentIcon != null) == null)
        {
            goto Label_002E;
        }
        this.currentIcon.gameObject.SetActive(0);
    Label_002E:
        return;
    }

    public unsafe void Setup(string achievement)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        this.PopOutEnd();
        base.transform.position = new Vector3(0f, 854f, -905f);
        base.gameObject.SetActive(1);
        this.textDescription.transform.localPosition = new Vector3(-51f, -12f, -1f);
        str = achievement;
        if (str == null)
        {
            goto Label_16D7;
        }
        if (<>f__switch$mapC != null)
        {
            goto Label_03D3;
        }
        dictionary = new Dictionary<string, int>(0x43);
        dictionary.Add("mageBeamMeUp", 0);
        dictionary.Add("dustToDust", 1);
        dictionary.Add("daring", 2);
        dictionary.Add("firstBlood", 3);
        dictionary.Add("bloodlust", 4);
        dictionary.Add("slayer", 5);
        dictionary.Add("multiKill", 6);
        dictionary.Add("easyTowerBuilder", 7);
        dictionary.Add("mediumTowerBuilder", 8);
        dictionary.Add("hardTowerBuilder", 9);
        dictionary.Add("towerUpgradeLevel3", 10);
        dictionary.Add("whatsThat", 11);
        dictionary.Add("killJuggernaut", 12);
        dictionary.Add("killMountainBoss", 13);
        dictionary.Add("killEndBoss", 14);
        dictionary.Add("giJoe", 15);
        dictionary.Add("maxElves", 0x10);
        dictionary.Add("imperialSaviour", 0x11);
        dictionary.Add("armaggedon", 0x12);
        dictionary.Add("impatient", 0x13);
        dictionary.Add("realEstate", 20);
        dictionary.Add("indecisive", 0x15);
        dictionary.Add("cannonFodder", 0x16);
        dictionary.Add("dieHard", 0x17);
        dictionary.Add("fearless", 0x18);
        dictionary.Add("specialization", 0x19);
        dictionary.Add("deathFromAbove", 0x1a);
        dictionary.Add("tactician", 0x1b);
        dictionary.Add("henderson", 0x1c);
        dictionary.Add("earn15Stars", 0x1d);
        dictionary.Add("earn30Stars", 30);
        dictionary.Add("earn45Stars", 0x1f);
        dictionary.Add("axeRainer", 0x20);
        dictionary.Add("sniper", 0x21);
        dictionary.Add("toxicity", 0x22);
        dictionary.Add("shepard", 0x23);
        dictionary.Add("rocketeer", 0x24);
        dictionary.Add("entangled", 0x25);
        dictionary.Add("energyNetwork", 0x26);
        dictionary.Add("elementalist", 0x27);
        dictionary.Add("barbarianRush", 40);
        dictionary.Add("clusterFire", 0x29);
        dictionary.Add("acdc", 0x2a);
        dictionary.Add("healMe", 0x2b);
        dictionary.Add("holyChorus", 0x2c);
        dictionary.Add("sheepKiller", 0x2d);
        dictionary.Add("fisherman", 0x2e);
        dictionary.Add("greatDefender", 0x2f);
        dictionary.Add("greatDefenderHeroic", 0x30);
        dictionary.Add("greatDefenderIron", 0x31);
        dictionary.Add("killSarelgaz", 50);
        dictionary.Add("freeFredo", 0x33);
        dictionary.Add("killGulthak", 0x34);
        dictionary.Add("killTreant", 0x35);
        dictionary.Add("levelHeroMedium", 0x36);
        dictionary.Add("levelHeroMax", 0x37);
        dictionary.Add("killKingpin", 0x38);
        dictionary.Add("acorn", 0x39);
        dictionary.Add("mushroom", 0x3a);
        dictionary.Add("killTrollBoss", 0x3b);
        dictionary.Add("coolRunning", 60);
        dictionary.Add("dineInHell", 0x3d);
        dictionary.Add("armyOfOne", 0x3e);
        dictionary.Add("killDemon", 0x3f);
        dictionary.Add("killMushroom", 0x40);
        dictionary.Add("spore", 0x41);
        dictionary.Add("stillCountsAsOne", 0x42);
        <>f__switch$mapC = dictionary;
    Label_03D3:
        if (<>f__switch$mapC.TryGetValue(str, &num) == null)
        {
            goto Label_16D7;
        }
        switch (num)
        {
            case 0:
                goto Label_04FC;

            case 1:
                goto Label_053E;

            case 2:
                goto Label_0580;

            case 3:
                goto Label_05C2;

            case 4:
                goto Label_0604;

            case 5:
                goto Label_0646;

            case 6:
                goto Label_0688;

            case 7:
                goto Label_06CA;

            case 8:
                goto Label_070C;

            case 9:
                goto Label_074E;

            case 10:
                goto Label_0790;

            case 11:
                goto Label_07D2;

            case 12:
                goto Label_0814;

            case 13:
                goto Label_0856;

            case 14:
                goto Label_0898;

            case 15:
                goto Label_08DA;

            case 0x10:
                goto Label_091C;

            case 0x11:
                goto Label_095E;

            case 0x12:
                goto Label_09C4;

            case 0x13:
                goto Label_0A06;

            case 20:
                goto Label_0A48;

            case 0x15:
                goto Label_0A8A;

            case 0x16:
                goto Label_0ACC;

            case 0x17:
                goto Label_0B0E;

            case 0x18:
                goto Label_0B50;

            case 0x19:
                goto Label_0B92;

            case 0x1a:
                goto Label_0BD4;

            case 0x1b:
                goto Label_0C16;

            case 0x1c:
                goto Label_0C58;

            case 0x1d:
                goto Label_0C9A;

            case 30:
                goto Label_0CDC;

            case 0x1f:
                goto Label_0D1E;

            case 0x20:
                goto Label_0D60;

            case 0x21:
                goto Label_0DA2;

            case 0x22:
                goto Label_0DE4;

            case 0x23:
                goto Label_0E26;

            case 0x24:
                goto Label_0E68;

            case 0x25:
                goto Label_0EAA;

            case 0x26:
                goto Label_0EEC;

            case 0x27:
                goto Label_0F2E;

            case 40:
                goto Label_0F70;

            case 0x29:
                goto Label_0FB2;

            case 0x2a:
                goto Label_0FF4;

            case 0x2b:
                goto Label_1036;

            case 0x2c:
                goto Label_1078;

            case 0x2d:
                goto Label_10BA;

            case 0x2e:
                goto Label_10FC;

            case 0x2f:
                goto Label_113E;

            case 0x30:
                goto Label_1180;

            case 0x31:
                goto Label_11C2;

            case 50:
                goto Label_1204;

            case 0x33:
                goto Label_1246;

            case 0x34:
                goto Label_1288;

            case 0x35:
                goto Label_12CA;

            case 0x36:
                goto Label_130C;

            case 0x37:
                goto Label_134E;

            case 0x38:
                goto Label_1390;

            case 0x39:
                goto Label_13D2;

            case 0x3a:
                goto Label_1414;

            case 0x3b:
                goto Label_1456;

            case 60:
                goto Label_1498;

            case 0x3d:
                goto Label_14FE;

            case 0x3e:
                goto Label_1564;

            case 0x3f:
                goto Label_15A6;

            case 0x40:
                goto Label_15E8;

            case 0x41:
                goto Label_162A;

            case 0x42:
                goto Label_1690;
        }
        goto Label_16D2;
    Label_04FC:
        this.currentIcon = this.iconMageBeamMeUp;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Beam Me Up Scotty";
        this.textDescription.text = "Teleport 250 or more\nenemies.";
        goto Label_16D7;
    Label_053E:
        this.currentIcon = this.iconDustToDust;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Dust to dust";
        this.textDescription.text = "Disintegrate 50 or more\nenemies.";
        goto Label_16D7;
    Label_0580:
        this.currentIcon = this.iconDaring;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Daring";
        this.textDescription.text = "Call 10 early waves.";
        goto Label_16D7;
    Label_05C2:
        this.currentIcon = this.iconFirstBlood;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "First Blood";
        this.textDescription.text = "Kill one enemy.";
        goto Label_16D7;
    Label_0604:
        this.currentIcon = this.iconBloodlust;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Bloodlust";
        this.textDescription.text = "Kill 50 enemies.";
        goto Label_16D7;
    Label_0646:
        this.currentIcon = this.iconSlayer;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Slayer";
        this.textDescription.text = "Kill 2500 enemies.";
        goto Label_16D7;
    Label_0688:
        this.currentIcon = this.iconMultiKill;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Terminator";
        this.textDescription.text = "Kill 10.000 enemies.";
        goto Label_16D7;
    Label_06CA:
        this.currentIcon = this.iconEasyTowerBuilder;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Constructor";
        this.textDescription.text = "Build 30 towers.";
        goto Label_16D7;
    Label_070C:
        this.currentIcon = this.iconMediumTowerBuilder;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Engineer";
        this.textDescription.text = "Build 100 towers.";
        goto Label_16D7;
    Label_074E:
        this.currentIcon = this.iconHardTowerBuilder;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "The Architect";
        this.textDescription.text = "Build 150 towers.";
        goto Label_16D7;
    Label_0790:
        this.currentIcon = this.iconTowerUpgradeLevel3;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Home Improvement";
        this.textDescription.text = "Upgrade all basic tower\ntypes to level 3.";
        goto Label_16D7;
    Label_07D2:
        this.currentIcon = this.iconWhatsThat;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "What's that?";
        this.textDescription.text = "Open 5 enemy information\ncards.";
        goto Label_16D7;
    Label_0814:
        this.currentIcon = this.iconKillJuggernaut;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Nuts and bolts";
        this.textDescription.text = "Defeat The Juggernaut.";
        goto Label_16D7;
    Label_0856:
        this.currentIcon = this.iconKillMountainBoss;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Is he dead yeti?";
        this.textDescription.text = "Defeat J.T.";
        goto Label_16D7;
    Label_0898:
        this.currentIcon = this.iconKillEndBoss;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "This is the end!";
        this.textDescription.text = "Defeat Vez'nan.";
        goto Label_16D7;
    Label_08DA:
        this.currentIcon = this.iconGiJoe;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "GI Joe";
        this.textDescription.text = "Kill 2500 enemies.";
        goto Label_16D7;
    Label_091C:
        this.currentIcon = this.iconMaxElves;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Forest Diplomacy";
        this.textDescription.text = "Recruit max elves at\nThe Silveroak Outpost.";
        goto Label_16D7;
    Label_095E:
        this.currentIcon = this.iconImperialSaviour;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Imperial Saviour";
        this.textDescription.text = "Have at least 3 Imperial\nGuards survive in\nThe Citadel.";
        this.textDescription.transform.localPosition = new Vector3(-51f, -8f, -1f);
        goto Label_16D7;
    Label_09C4:
        this.currentIcon = this.iconArmaggedon;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Armaggedon";
        this.textDescription.text = "Use rain of fire 5 times\nin a single stage.";
        goto Label_16D7;
    Label_0A06:
        this.currentIcon = this.iconImpatient;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Impatient";
        this.textDescription.text = "Call a wave within 3 seconds\nof the icon showing up.";
        goto Label_16D7;
    Label_0A48:
        this.currentIcon = this.iconRealEstate;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Real Estate";
        this.textDescription.text = "Sell 30 towers.";
        goto Label_16D7;
    Label_0A8A:
        this.currentIcon = this.iconIndecisive;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Indecisive";
        this.textDescription.text = "Sell 5 towers in a single\nmission.";
        goto Label_16D7;
    Label_0ACC:
        this.currentIcon = this.iconCannonFodder;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Cannon Fodder";
        this.textDescription.text = "Send 1.000 soldiers to\ntheir deaths.";
        goto Label_16D7;
    Label_0B0E:
        this.currentIcon = this.iconDieHard;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Die Hard";
        this.textDescription.text = "Have soldiers regenerate a\ntotal of 50.000 life.";
        goto Label_16D7;
    Label_0B50:
        this.currentIcon = this.iconFearless;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Fearless";
        this.textDescription.text = "Call all waves early in\na single mission.";
        goto Label_16D7;
    Label_0B92:
        this.currentIcon = this.iconSpecialization;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Specialist";
        this.textDescription.text = "Build all 8 tower\nspecializations.";
        goto Label_16D7;
    Label_0BD4:
        this.currentIcon = this.iconDeathFromAbove;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Death from above";
        this.textDescription.text = "Kill 100 enemies with the\nmeteor shower.";
        goto Label_16D7;
    Label_0C16:
        this.currentIcon = this.iconRallyChanges;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Tactician";
        this.textDescription.text = "Change soldiers rally\npoint 200 times.";
        goto Label_16D7;
    Label_0C58:
        this.currentIcon = this.iconHenderson;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Like a Henderson";
        this.textDescription.text = "Free the Sasquatch on the\nIcewind Pass.";
        goto Label_16D7;
    Label_0C9A:
        this.currentIcon = this.iconEarn15Stars;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Starry";
        this.textDescription.text = "Earn 15 stars.";
        goto Label_16D7;
    Label_0CDC:
        this.currentIcon = this.iconEarn30Stars;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Super Mario";
        this.textDescription.text = "Earn 30 stars.";
        goto Label_16D7;
    Label_0D1E:
        this.currentIcon = this.iconEarn45Stars;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Superstar";
        this.textDescription.text = "Earn 45 stars.";
        goto Label_16D7;
    Label_0D60:
        this.currentIcon = this.iconAxeRainer;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Axe rain";
        this.textDescription.text = "Throw 500 or more axes.";
        goto Label_16D7;
    Label_0DA2:
        this.currentIcon = this.iconSniper;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "50 shots, 50 kills";
        this.textDescription.text = "Snipe 50 enemies.";
        goto Label_16D7;
    Label_0DE4:
        this.currentIcon = this.iconToxicity;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Toxicity";
        this.textDescription.text = "Kill 50 enemies by\npoison damage.";
        goto Label_16D7;
    Label_0E26:
        this.currentIcon = this.iconShepard;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Shepherd";
        this.textDescription.text = "Polymorph 50 enemies\ninto sheeps.";
        goto Label_16D7;
    Label_0E68:
        this.currentIcon = this.iconRocketeer;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Rocketeer";
        this.textDescription.text = "Shoot 100 missiles.";
        goto Label_16D7;
    Label_0EAA:
        this.currentIcon = this.iconEntangled;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Entangled";
        this.textDescription.text = "Hold 500 or more enemies\nwith Wrath of the Forest.";
        goto Label_16D7;
    Label_0EEC:
        this.currentIcon = this.iconEnergyNetwork;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Energy Network";
        this.textDescription.text = "Build 4 Tesla towers in\nany stage.";
        goto Label_16D7;
    Label_0F2E:
        this.currentIcon = this.iconElementalist;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Elementalist";
        this.textDescription.text = "Summon 5 rock elementals\non a single stage.";
        goto Label_16D7;
    Label_0F70:
        this.currentIcon = this.iconBarbarianRush;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Are you not entertained?";
        this.textDescription.text = "Have a single barbarian\nkill 10 enemies.";
        goto Label_16D7;
    Label_0FB2:
        this.currentIcon = this.iconClusterRain;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Clustered";
        this.textDescription.text = "Drop 1.000 bomblets\nwith the cluster bomb.";
        goto Label_16D7;
    Label_0FF4:
        this.currentIcon = this.iconAcdc;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "AC/DC";
        this.textDescription.text = "Kill 300 enemies with\nelectricity.";
        goto Label_16D7;
    Label_1036:
        this.currentIcon = this.iconMedic;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Medic";
        this.textDescription.text = "Have your Paladins heal a\ntotal of 7000 life.";
        goto Label_16D7;
    Label_1078:
        this.currentIcon = this.iconHolyChorus;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Holy Chorus";
        this.textDescription.text = "Have your Paladins\nperform 100 holy strikes.";
        goto Label_16D7;
    Label_10BA:
        this.currentIcon = this.iconSheepKiller;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Ovinophobia";
        this.textDescription.text = "Kill 10 or more sheep with\nyour hands.";
        goto Label_16D7;
    Label_10FC:
        this.currentIcon = this.iconFisherman;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Twin Rivers Angler";
        this.textDescription.text = "Catch a fish.";
        goto Label_16D7;
    Label_113E:
        this.currentIcon = this.iconGreatDefender;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Great Defender";
        this.textDescription.text = "Complete all campaign\nstages in normal difficulty.";
        goto Label_16D7;
    Label_1180:
        this.currentIcon = this.iconGreatDefenderHeroic;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Heroic Defender";
        this.textDescription.text = "Complete all heroic stages\nin normal difficulty.";
        goto Label_16D7;
    Label_11C2:
        this.currentIcon = this.iconGreatDefenderHeroic;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Iron Defender";
        this.textDescription.text = "Complete all iron stages\nin normal difficulty.";
        goto Label_16D7;
    Label_1204:
        this.currentIcon = this.iconKillSarelgaz;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Arachnophobia";
        this.textDescription.text = "Defeat Sarelgaz and it's\nminions.";
        goto Label_16D7;
    Label_1246:
        this.currentIcon = this.iconFreeFredo;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Free Fredo";
        this.textDescription.text = "Help Fredo escape.";
        goto Label_16D7;
    Label_1288:
        this.currentIcon = this.iconKillGulThak;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Orcs must die";
        this.textDescription.text = "Defeat Gul'Thak and it's\nminions.";
        goto Label_16D7;
    Label_12CA:
        this.currentIcon = this.iconKillTreant;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Lumberjack";
        this.textDescription.text = "Defeat Greenmuck and it's\nminions.";
        goto Label_16D7;
    Label_130C:
        this.currentIcon = this.iconLevelHeroMedium;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Champion of Linirea";
        this.textDescription.text = "Train a hero up to level 5.";
        goto Label_16D7;
    Label_134E:
        this.currentIcon = this.iconLevelHeroMax;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Legend of Linirea";
        this.textDescription.text = "Train a hero up to level 10.";
        goto Label_16D7;
    Label_1390:
        this.currentIcon = this.iconKillKingping;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "I'am the law";
        this.textDescription.text = "Do not let the Kingpin\nescape.";
        goto Label_16D7;
    Label_13D2:
        this.currentIcon = this.iconAcorn;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Scrat's meal";
        this.textDescription.text = "Find the elusive acorn!";
        goto Label_16D7;
    Label_1414:
        this.currentIcon = this.iconMushroom;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Plants vs Trolls";
        this.textDescription.text = "Find the 5 legendary\nlost ice-shrooms.";
        goto Label_16D7;
    Label_1456:
        this.currentIcon = this.iconTrollBoss;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Don't feed the troll";
        this.textDescription.text = "Defeat Ulguk-Hai the\nTroll Warlord.";
        goto Label_16D7;
    Label_1498:
        this.currentIcon = this.iconCoolRunning;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Cool Runnings";
        this.textDescription.text = "Kill 10 Troll Pathfinders\nwhile they're treading on\nice.";
        this.textDescription.transform.localPosition = new Vector3(-51f, -10f, -1f);
        goto Label_16D7;
    Label_14FE:
        this.currentIcon = this.iconDineInHell;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "We dine in hell!";
        this.textDescription.text = "Have your soldiers survive\nthe explosion of 300\ndemons.";
        this.textDescription.transform.localPosition = new Vector3(-51f, -10f, -1f);
        goto Label_16D7;
    Label_1564:
        this.currentIcon = this.iconArmyOfOne;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Army of One";
        this.textDescription.text = "Defeat 9 legions before\nthey replicate.";
        goto Label_16D7;
    Label_15A6:
        this.currentIcon = this.iconDefeatMoloch;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Hell-O!";
        this.textDescription.text = "Defeat Moloch the Demon\nOverlord.";
        goto Label_16D7;
    Label_15E8:
        this.currentIcon = this.iconDefeatMushroom;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Super Mushroom";
        this.textDescription.text = "Defeat Myconid, the\nRotten Fungus.";
        goto Label_16D7;
    Label_162A:
        this.currentIcon = this.iconSpore;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Spore";
        this.textDescription.text = "Kill 25 Shrooms without\nthem poisoning your\nsoldiers.";
        this.textDescription.transform.localPosition = new Vector3(-51f, -10f, -1f);
        goto Label_16D7;
    Label_1690:
        this.currentIcon = this.iconStillCountsAsOne;
        this.currentIcon.gameObject.SetActive(1);
        this.textTitle.text = "Still counts as one";
        this.textDescription.text = "Have your Elves deal\n10000 points of damage.";
        goto Label_16D7;
    Label_16D2:;
    Label_16D7:
        this.PopIn();
        return;
    }

    private void Start()
    {
    }
}

