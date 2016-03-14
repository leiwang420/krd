using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameAchievements
{
    private bool acdc;
    private int acdcKills;
    private bool acorn;
    private int archersTowerUpgradeLevel3;
    private bool armaggedon;
    private bool armyOfOne;
    private int armyOfOneCounter;
    private bool axeRainer;
    private int axesFire;
    private bool barbarianRush;
    private bool bloodlust;
    private int buildArcanes;
    private int buildBarbarians;
    private int buildBfg;
    private int buildMusketeers;
    private int buildPaladins;
    private int buildRangers;
    private int buildSorcerers;
    private int buildTesla;
    private bool cannonFodder;
    private bool clusterRain;
    private int clustersFire;
    private bool coolRunning;
    private int coolRunningKilledTrolls;
    private bool daring;
    private bool deathFromAbove;
    private int desintegrateKills;
    private bool dieHard;
    private bool dineInHell;
    private int dineInHellCounter;
    private bool dustToDust;
    private int earlyWavesCalled;
    private bool earn15Stars;
    private bool earn30Stars;
    private bool earn45Stars;
    private bool easyTowerBuilder;
    private bool elementalist;
    private bool energyNetwork;
    private int engineersTowerUpgradeLevel3;
    private bool entangled;
    private bool fearless;
    private int fireballKills;
    private bool firstBlood;
    private bool fisherman;
    private bool freeFredo;
    private bool giJoe;
    private bool greatDefender;
    private bool greatDefenderHeroic;
    private bool greatDefenderIron;
    private bool hardTowerBuilder;
    private bool henderson;
    private bool holyChorus;
    private int holyChorusCount;
    private bool impatient;
    private bool imperialSaviour;
    private bool indecisive;
    private static GameAchievements instance;
    private bool killDemon;
    private int killedEnemies;
    private bool killEndBoss;
    private bool killGulThak;
    private bool killJuggernaut;
    private bool killKingping;
    private bool killMountainBoss;
    private bool killMushroom;
    private bool killSarelgaz;
    private bool killTreant;
    private bool killTrollBoss;
    private bool levelHeroMax;
    private bool levelHeroMedium;
    private bool mageBeamMeUp;
    private int mageBeamMeUpEnemies;
    private int magesTowerUpgradeLevel3;
    private bool maxElves;
    private bool medic;
    private bool mediumTowerBuilder;
    private int missilesFire;
    private bool multiKill;
    private bool mushroom;
    private NotificationAchievement notificationAchievement;
    private int notificationEnemy;
    private int paladinHeals;
    private int poisonKills;
    private int polymorphKills;
    private int rallyChanges;
    private bool realEstate;
    private bool rocketeer;
    private int sellTowers;
    private bool sheepKiller;
    private int sheepsKilled;
    private bool shepard;
    private bool slayer;
    private bool sniper;
    private int sniperKills;
    private int soldiersKilled;
    private int soldiersRegeneration;
    private int soldiersTowerUpgradeLevel3;
    private int soldiersTrained;
    private bool specialization;
    private bool spore;
    private int sporeCount;
    private Steamworks steam;
    private bool stillCountsAsOne;
    private int stillCountsAsOneCount;
    private bool sunburner;
    private int sunrayShots;
    private bool tactician;
    private int thornsEnemies;
    private int towerBuilded;
    private bool towerUpgradeLevel3;
    private bool toxicity;
    private bool whatsThat;

    public GameAchievements()
    {
        base..ctor();
        if (instance == null)
        {
            goto Label_001B;
        }
        Debug.LogError("Cannot have two instances of singleton.");
        return;
    Label_001B:
        instance = this;
        this.Init();
        return;
    }

    public static void AcornFound()
    {
        if (Instance.acorn == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.acorn = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_ACORN");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("acorn");
    Label_005D:
        return;
    }

    public static void AddFireballKill()
    {
        GameAchievements achievements1;
        if (Instance.deathFromAbove == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.fireballKills += 1;
        if (Instance.fireballKills != 100)
        {
            goto Label_0080;
        }
        Instance.deathFromAbove = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_DEATH_FROM_ABOVE");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("deathFromAbove");
    Label_0080:
        return;
    }

    public static void AddRegeneration(int regen)
    {
        GameAchievements achievements1;
        if (Instance.dieHard == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.soldiersRegeneration += regen;
        if (Instance.soldiersRegeneration < 0xc350)
        {
            goto Label_0040;
        }
        Instance.DoDieHard();
    Label_0040:
        return;
    }

    public static void ArmyOfOneFunc()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.armyOfOneCounter += 1;
        if (Instance.armyOfOne == null)
        {
            goto Label_0022;
        }
        return;
    Label_0022:
        if (Instance.armyOfOneCounter >= 9)
        {
            goto Label_0034;
        }
        return;
    Label_0034:
        Instance.armyOfOne = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006D;
        }
        Instance.steam.SetAchievement("ACH_ARMYOFONE");
        goto Label_0081;
    Label_006D:
        Instance.notificationAchievement.Setup("armyOfOne");
    Label_0081:
        return;
    }

    public static void AxeFire()
    {
        GameAchievements achievements1;
        if (Instance.axeRainer == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.axesFire += 1;
        if (Instance.axesFire != 500)
        {
            goto Label_0083;
        }
        Instance.axeRainer = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_AXE_RAIN");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("axeRainer");
    Label_0083:
        return;
    }

    public static void BuildTower()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.towerBuilded += 1;
        if (Instance.easyTowerBuilder != null)
        {
            goto Label_007F;
        }
        if (Instance.towerBuilded != 30)
        {
            goto Label_007F;
        }
        Instance.easyTowerBuilder = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006B;
        }
        Instance.steam.SetAchievement("ACH_CONSTRUCTOR");
        goto Label_007F;
    Label_006B:
        Instance.notificationAchievement.Setup("easyTowerBuilder");
    Label_007F:
        if (Instance.mediumTowerBuilder != null)
        {
            goto Label_00EC;
        }
        if (Instance.towerBuilded != 100)
        {
            goto Label_00EC;
        }
        Instance.mediumTowerBuilder = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_00D8;
        }
        Instance.steam.SetAchievement("ACH_ENGINEER");
        goto Label_00EC;
    Label_00D8:
        Instance.notificationAchievement.Setup("mediumTowerBuilder");
    Label_00EC:
        if (Instance.hardTowerBuilder != null)
        {
            goto Label_015C;
        }
        if (Instance.towerBuilded != 150)
        {
            goto Label_015C;
        }
        Instance.hardTowerBuilder = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0148;
        }
        Instance.steam.SetAchievement("ACH_THE_ARCHITECT");
        goto Label_015C;
    Label_0148:
        Instance.notificationAchievement.Setup("hardTowerBuilder");
    Label_015C:
        return;
    }

    public static void BuildTowerArcane()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildArcanes += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerBarbarian()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildBarbarians += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerBfg()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildBfg += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerMusketeer()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildMusketeers += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerPaladin()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildPaladins += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerRanger()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildRangers += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerSorcerer()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildSorcerers += 1;
        CheckSpecialization();
        return;
    }

    public static void BuildTowerTesla()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.buildTesla += 1;
        CheckSpecialization();
        return;
    }

    public static void CatchAFish()
    {
        if (Instance.fisherman == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.fisherman = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_TWIN_RIVERS");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("fisherman");
    Label_005D:
        return;
    }

    public static void ChangeRallyPoint()
    {
        GameAchievements achievements1;
        if (Instance.tactician == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.rallyChanges += 1;
        if (Instance.rallyChanges != 200)
        {
            goto Label_0083;
        }
        Instance.tactician = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_TACTICIAN");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("tactician");
    Label_0083:
        return;
    }

    public static void CheckArmaggedon()
    {
        if (Instance.armaggedon == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.armaggedon = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_ARMAGEDDON");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("armaggedon");
    Label_005D:
        return;
    }

    public static void CheckBeamMeUp()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.mageBeamMeUpEnemies += 1;
        if (Instance.mageBeamMeUp != null)
        {
            goto Label_0082;
        }
        if (Instance.mageBeamMeUpEnemies < 250)
        {
            goto Label_0082;
        }
        Instance.mageBeamMeUp = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006E;
        }
        Instance.steam.SetAchievement("ACH_BEAM_ME_UP");
        goto Label_0082;
    Label_006E:
        Instance.notificationAchievement.Setup("mageBeamMeUp");
    Label_0082:
        return;
    }

    public static void CheckDaring()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.earlyWavesCalled += 1;
        if (Instance.daring != null)
        {
            goto Label_007F;
        }
        if (Instance.earlyWavesCalled != 10)
        {
            goto Label_007F;
        }
        Instance.daring = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006B;
        }
        Instance.steam.SetAchievement("ACH_DARING");
        goto Label_007F;
    Label_006B:
        Instance.notificationAchievement.Setup("daring");
    Label_007F:
        return;
    }

    public static void CheckImpatient()
    {
        if (Instance.impatient == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.impatient = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_IMPATIENT");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("impatient");
    Label_005D:
        return;
    }

    public static void CheckMaxElves()
    {
        if (Instance.maxElves == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.maxElves = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_FOREST_DIPLOMACY");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("maxElves");
    Label_005D:
        return;
    }

    private static void CheckSpecialization()
    {
        if (Instance.specialization == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        if (Instance.buildRangers == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildMusketeers == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildPaladins == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildBarbarians == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildArcanes == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildSorcerers == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildBfg == null)
        {
            goto Label_00D5;
        }
        if (Instance.buildTesla == null)
        {
            goto Label_00D5;
        }
        Instance.specialization = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_00C1;
        }
        Instance.steam.SetAchievement("ACH_SPECIALIST");
        goto Label_00D5;
    Label_00C1:
        Instance.notificationAchievement.Setup("specialization");
    Label_00D5:
        return;
    }

    public static void CheckStars(int stars)
    {
        if (Instance.earn15Stars != null)
        {
            goto Label_0064;
        }
        if (stars < 15)
        {
            goto Label_0064;
        }
        Instance.earn15Stars = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0050;
        }
        Instance.steam.SetAchievement("ACH_STARRY");
        goto Label_0064;
    Label_0050:
        Instance.notificationAchievement.Setup("earn15Stars");
    Label_0064:
        if (Instance.earn30Stars != null)
        {
            goto Label_00C8;
        }
        if (stars < 30)
        {
            goto Label_00C8;
        }
        Instance.earn30Stars = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_00B4;
        }
        Instance.steam.SetAchievement("ACH_SUPER_MARIO");
        goto Label_00C8;
    Label_00B4:
        Instance.notificationAchievement.Setup("earn30Stars");
    Label_00C8:
        if (Instance.earn45Stars != null)
        {
            goto Label_012C;
        }
        if (stars < 0x2d)
        {
            goto Label_012C;
        }
        Instance.earn45Stars = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0118;
        }
        Instance.steam.SetAchievement("ACH_SUPERSTAR");
        goto Label_012C;
    Label_0118:
        Instance.notificationAchievement.Setup("earn45Stars");
    Label_012C:
        return;
    }

    public static void CheckSunBurner()
    {
        GameAchievements achievements1;
        if (Instance.sunburner == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.sunrayShots += 1;
        if (Instance.sunrayShots != 20)
        {
            goto Label_003E;
        }
        Instance.sunburner = 1;
    Label_003E:
        return;
    }

    public static void ChkGreatDefender(bool showNotification = true)
    {
        if (Instance.greatDefender == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.greatDefender = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_GREAT_DEFENDER");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("greatDefender");
    Label_005D:
        return;
    }

    public static void ChkGreatDefenderHeroic(bool showNotification = true)
    {
        if (Instance.greatDefenderHeroic == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.greatDefenderHeroic = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_HEROIC");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("greatDefenderHeroic");
    Label_005D:
        return;
    }

    public static void ChkGreatDefenderIron(bool showNotification = true)
    {
        if (Instance.greatDefenderIron == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.greatDefenderIron = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_IRON");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("greatDefenderIron");
    Label_005D:
        return;
    }

    public static void ClusterFire()
    {
        GameAchievements achievements1;
        if (Instance.clusterRain == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.clustersFire += 1;
        if (Instance.clustersFire != 500)
        {
            goto Label_0083;
        }
        Instance.clusterRain = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_CLUSTERED");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("clusterFire");
    Label_0083:
        return;
    }

    public static void DefeatEndBoss()
    {
        if (Instance.killEndBoss != null)
        {
            goto Label_005C;
        }
        Instance.killEndBoss = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0048;
        }
        Instance.steam.SetAchievement("ACH_VEZNAN");
        goto Label_005C;
    Label_0048:
        Instance.notificationAchievement.Setup("killEndBoss");
    Label_005C:
        return;
    }

    public static void DefeatJuggernaut()
    {
        if (Instance.killJuggernaut != null)
        {
            goto Label_005C;
        }
        Instance.killJuggernaut = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0048;
        }
        Instance.steam.SetAchievement("ACH_NUTS_AND_BOLTS");
        goto Label_005C;
    Label_0048:
        Instance.notificationAchievement.Setup("killJuggernaut");
    Label_005C:
        return;
    }

    public static void DefeatMoloch()
    {
        if (Instance.killDemon == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killDemon = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_KILLDEMON");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killDemon");
    Label_005D:
        return;
    }

    public static void DefeatMushroom()
    {
        if (Instance.killMushroom == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killMushroom = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_KILLMUSHROOM");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killMushroom");
    Label_005D:
        return;
    }

    public static void DefeatYetiBoss()
    {
        if (Instance.killMountainBoss != null)
        {
            goto Label_005C;
        }
        Instance.killMountainBoss = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0048;
        }
        Instance.steam.SetAchievement("ACH_KILL_JT");
        goto Label_005C;
    Label_0048:
        Instance.notificationAchievement.Setup("killMountainBoss");
    Label_005C:
        return;
    }

    public static void DesintegrateEnemy()
    {
        GameAchievements achievements1;
        if (Instance.dustToDust == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.desintegrateKills += 1;
        if (Instance.desintegrateKills != 50)
        {
            goto Label_0080;
        }
        Instance.dustToDust = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_DUST_TO_DUST");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("dustToDust");
    Label_0080:
        return;
    }

    public static void DineInHellFunc()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.dineInHellCounter += 1;
        if (Instance.dineInHell == null)
        {
            goto Label_0022;
        }
        return;
    Label_0022:
        if (Instance.dineInHellCounter >= 300)
        {
            goto Label_0037;
        }
        return;
    Label_0037:
        Instance.dineInHell = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0070;
        }
        Instance.steam.SetAchievement("ACH_DINEINHELL");
        goto Label_0084;
    Label_0070:
        Instance.notificationAchievement.Setup("dineInHell");
    Label_0084:
        return;
    }

    private void DoDieHard()
    {
        if (Instance.dieHard == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.dieHard = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_DIE_HARD");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("dieHard");
    Label_005D:
        return;
    }

    public static void DoFearless()
    {
        if (Instance.fearless == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.fearless = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_FEARLESS");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("fearless");
    Label_005D:
        return;
    }

    public static void DoImperialSaviour()
    {
        Instance.imperialSaviour = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0039;
        }
        Instance.steam.SetAchievement("ACH_IMPERIAL_SAVIOUR");
        goto Label_004D;
    Label_0039:
        Instance.notificationAchievement.Setup("imperialSaviour");
    Label_004D:
        return;
    }

    public static void DoIndecisive()
    {
        if (Instance.indecisive == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.indecisive = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_INDECISIVE");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("indecisive");
    Label_005D:
        return;
    }

    public static void EvalBarbarianRush()
    {
        if (Instance.barbarianRush == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.barbarianRush = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_NOT_ENTERTAINED");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("barbarianRush");
    Label_005D:
        return;
    }

    public static void EvalElentalist()
    {
        if (Instance.elementalist == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.elementalist = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_ELEMENTALIST");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("elementalist");
    Label_005D:
        return;
    }

    public static void EvalEnergyNetwork()
    {
        if (Instance.energyNetwork == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.energyNetwork = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_ENERGY_NETWORK");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("energyNetwork");
    Label_005D:
        return;
    }

    public static void FreeFredoFunc()
    {
        if (Instance.freeFredo == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.freeFredo = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_FREDO");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("freeFredo");
    Label_005D:
        return;
    }

    public static Dictionary<string, bool> GetDataBool()
    {
        Dictionary<string, bool> dictionary;
        dictionary = new Dictionary<string, bool>();
        dictionary.Add("easyTowerBuilder", Instance.easyTowerBuilder);
        dictionary.Add("mediumTowerBuilder", Instance.mediumTowerBuilder);
        dictionary.Add("hardTowerBuilder", Instance.hardTowerBuilder);
        dictionary.Add("earn15Stars", Instance.earn15Stars);
        dictionary.Add("earn30Stars", Instance.earn30Stars);
        dictionary.Add("earn45Stars", Instance.earn45Stars);
        dictionary.Add("whatsThat", Instance.whatsThat);
        dictionary.Add("daring", Instance.daring);
        dictionary.Add("firstBlood", Instance.firstBlood);
        dictionary.Add("bloodlust", Instance.bloodlust);
        dictionary.Add("mageBeamMeUp", Instance.mageBeamMeUp);
        dictionary.Add("armaggedon", Instance.armaggedon);
        dictionary.Add("deathFromAbove", Instance.deathFromAbove);
        dictionary.Add("killMountainBoss", Instance.killMountainBoss);
        dictionary.Add("killJuggernaut", Instance.killJuggernaut);
        dictionary.Add("slayer", Instance.slayer);
        dictionary.Add("specialization", Instance.specialization);
        dictionary.Add("tactician", Instance.tactician);
        dictionary.Add("killEndBoss", Instance.killEndBoss);
        dictionary.Add("multiKill", Instance.multiKill);
        dictionary.Add("giJoe", Instance.giJoe);
        dictionary.Add("dieHard", Instance.dieHard);
        dictionary.Add("cannonFodder", Instance.cannonFodder);
        dictionary.Add("fearless", Instance.fearless);
        dictionary.Add("realEstate", Instance.realEstate);
        dictionary.Add("indecisive", Instance.indecisive);
        dictionary.Add("impatient", Instance.impatient);
        dictionary.Add("maxElves", Instance.maxElves);
        dictionary.Add("imperialSaviour", Instance.imperialSaviour);
        dictionary.Add("henderson", Instance.henderson);
        dictionary.Add("sunburner", Instance.sunburner);
        dictionary.Add("dustToDust", Instance.dustToDust);
        dictionary.Add("shepard", Instance.shepard);
        dictionary.Add("rocketeer", Instance.rocketeer);
        dictionary.Add("toxicity", Instance.toxicity);
        dictionary.Add("sniper", Instance.sniper);
        dictionary.Add("axeRainer", Instance.axeRainer);
        dictionary.Add("energyNetwork", Instance.energyNetwork);
        dictionary.Add("elementalist", Instance.elementalist);
        dictionary.Add("entangled", Instance.entangled);
        dictionary.Add("barbarianRush", Instance.barbarianRush);
        dictionary.Add("clusterRain", Instance.clusterRain);
        dictionary.Add("acdc", Instance.acdc);
        dictionary.Add("medic", Instance.medic);
        dictionary.Add("holyChorus", Instance.holyChorus);
        dictionary.Add("fisherman", Instance.fisherman);
        dictionary.Add("sheepKiller", Instance.sheepKiller);
        dictionary.Add("greatDefender", Instance.greatDefender);
        dictionary.Add("greatDefenderHeroic", Instance.greatDefenderHeroic);
        dictionary.Add("greatDefenderIron", Instance.greatDefenderIron);
        dictionary.Add("freeFredo", Instance.freeFredo);
        dictionary.Add("killSarelgaz", Instance.killSarelgaz);
        dictionary.Add("killGulThak", Instance.killGulThak);
        dictionary.Add("killKingping", Instance.killKingping);
        dictionary.Add("acorn", Instance.acorn);
        dictionary.Add("mushroom", Instance.mushroom);
        dictionary.Add("coolRunning", Instance.coolRunning);
        dictionary.Add("killTrollBoss", Instance.killTrollBoss);
        dictionary.Add("dineInHell", Instance.dineInHell);
        dictionary.Add("armyOfOne", Instance.armyOfOne);
        dictionary.Add("killDemon", Instance.killDemon);
        dictionary.Add("killMushroom", Instance.killMushroom);
        dictionary.Add("spore", Instance.spore);
        dictionary.Add("stillCountsAsOne", Instance.stillCountsAsOne);
        return dictionary;
    }

    public static Dictionary<string, int> GetDataInt()
    {
        Dictionary<string, int> dictionary;
        dictionary = new Dictionary<string, int>();
        dictionary.Add("towerBuilded", Instance.towerBuilded);
        dictionary.Add("notificationEnemy", Instance.notificationEnemy);
        dictionary.Add("earlyWavesCalled", Instance.earlyWavesCalled);
        dictionary.Add("magesTowerUpgradeLevel3", Instance.magesTowerUpgradeLevel3);
        dictionary.Add("archersTowerUpgradeLevel3", Instance.archersTowerUpgradeLevel3);
        dictionary.Add("soldiersTowerUpgradeLevel3", Instance.soldiersTowerUpgradeLevel3);
        dictionary.Add("engineersTowerUpgradeLevel3", Instance.engineersTowerUpgradeLevel3);
        dictionary.Add("killedEnemies", Instance.killedEnemies);
        dictionary.Add("mageBeamMeUpEnemies", Instance.mageBeamMeUpEnemies);
        dictionary.Add("fireballKills", Instance.fireballKills);
        dictionary.Add("buildRangers", Instance.buildRangers);
        dictionary.Add("buildMusketeers", Instance.buildMusketeers);
        dictionary.Add("buildPaladins", Instance.buildPaladins);
        dictionary.Add("buildBarbarians", Instance.buildBarbarians);
        dictionary.Add("buildArcanes", Instance.buildArcanes);
        dictionary.Add("buildSorcerers", Instance.buildSorcerers);
        dictionary.Add("buildBfg", Instance.buildBfg);
        dictionary.Add("buildTesla", Instance.buildTesla);
        dictionary.Add("rallyChanges", Instance.rallyChanges);
        dictionary.Add("soldiersTrained", Instance.soldiersTrained);
        dictionary.Add("soldiersKilled", Instance.soldiersKilled);
        dictionary.Add("soldiersRegeneration", Instance.soldiersRegeneration);
        dictionary.Add("sellTowers", Instance.sellTowers);
        dictionary.Add("sunrayShots", Instance.sunrayShots);
        dictionary.Add("desintegrateKills", Instance.desintegrateKills);
        dictionary.Add("polymorphKills", Instance.polymorphKills);
        dictionary.Add("missilesFire", Instance.missilesFire);
        dictionary.Add("poisonKills", Instance.poisonKills);
        dictionary.Add("sniperKills", Instance.sniperKills);
        dictionary.Add("axesFire", Instance.axesFire);
        dictionary.Add("thornsEnemies", Instance.thornsEnemies);
        dictionary.Add("clustersFire", Instance.clustersFire);
        dictionary.Add("acdcKills", Instance.acdcKills);
        dictionary.Add("paladinHeals", Instance.paladinHeals);
        dictionary.Add("holyChorusCount", Instance.holyChorusCount);
        dictionary.Add("sheepsKilled", Instance.sheepsKilled);
        dictionary.Add("coolRunningKilledTrolls", Instance.coolRunningKilledTrolls);
        return dictionary;
    }

    public static bool HasImperialSaviour()
    {
        return Instance.imperialSaviour;
    }

    public static void HealMe(int healingPoints)
    {
        GameAchievements achievements1;
        if (Instance.medic == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.paladinHeals += healingPoints;
        if (Instance.paladinHeals < 0x1b58)
        {
            goto Label_0083;
        }
        Instance.medic = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_MEDIC");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("healMe");
    Label_0083:
        return;
    }

    public static void HolyStrike()
    {
        GameAchievements achievements1;
        if (Instance.holyChorus == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.holyChorusCount += 1;
        if (Instance.holyChorusCount != 100)
        {
            goto Label_0080;
        }
        Instance.holyChorus = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_HOLY_CHORUS");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("holyChorus");
    Label_0080:
        return;
    }

    private void Init()
    {
        GameObject obj2;
        obj2 = GameObject.Find("Steamworks");
        if ((obj2 != null) == null)
        {
            goto Label_0028;
        }
        this.steam = obj2.GetComponent<Steamworks>();
        goto Label_002F;
    Label_0028:
        this.steam = null;
    Label_002F:
        return;
    }

    public static void KillEnemy()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.killedEnemies += 1;
        if (Instance.firstBlood != null)
        {
            goto Label_006E;
        }
        Instance.firstBlood = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_005A;
        }
        Instance.steam.SetAchievement("ACH_FIRST_BLOOD");
        goto Label_006E;
    Label_005A:
        Instance.notificationAchievement.Setup("firstBlood");
    Label_006E:
        if (Instance.bloodlust != null)
        {
            goto Label_00DE;
        }
        if (Instance.killedEnemies != 500)
        {
            goto Label_00DE;
        }
        Instance.bloodlust = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_00CA;
        }
        Instance.steam.SetAchievement("ACH_BLOODLUST");
        goto Label_00DE;
    Label_00CA:
        Instance.notificationAchievement.Setup("bloodlust");
    Label_00DE:
        if (Instance.slayer != null)
        {
            goto Label_014E;
        }
        if (Instance.killedEnemies != 0x9c4)
        {
            goto Label_014E;
        }
        Instance.slayer = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_013A;
        }
        Instance.steam.SetAchievement("ACH_SLAYER");
        goto Label_014E;
    Label_013A:
        Instance.notificationAchievement.Setup("slayer");
    Label_014E:
        if (Instance.multiKill != null)
        {
            goto Label_01BE;
        }
        if (Instance.killedEnemies != 0x2710)
        {
            goto Label_01BE;
        }
        Instance.multiKill = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_01AA;
        }
        Instance.steam.SetAchievement("ACH_TERMINATOR");
        goto Label_01BE;
    Label_01AA:
        Instance.notificationAchievement.Setup("multiKill");
    Label_01BE:
        return;
    }

    public static void KillGulThakFunc()
    {
        if (Instance.killGulThak == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killGulThak = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_ORCS");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killGulthak");
    Label_005D:
        return;
    }

    public static void KillKingpingFunc()
    {
        if (Instance.killKingping == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killKingping = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_LAW");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killKingpin");
    Label_005D:
        return;
    }

    public static void KillSarelgazFunc()
    {
        if (Instance.killSarelgaz == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killSarelgaz = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_ARACHNOPHOBIA");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killSarelgaz");
    Label_005D:
        return;
    }

    public static void KillSheep()
    {
        GameAchievements achievements1;
        if (Instance.sheepKiller == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.sheepsKilled += 1;
        if (Instance.sheepsKilled < 10)
        {
            goto Label_0080;
        }
        Instance.sheepKiller = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_OVINOPHOBIA");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("sheepKiller");
    Label_0080:
        return;
    }

    public static void KillSoldier()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.soldiersKilled += 1;
        if (Instance.cannonFodder != null)
        {
            goto Label_0082;
        }
        if (Instance.soldiersKilled != 0x3e8)
        {
            goto Label_0082;
        }
        Instance.cannonFodder = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006E;
        }
        Instance.steam.SetAchievement("ACH_CANNON_FODDER");
        goto Label_0082;
    Label_006E:
        Instance.notificationAchievement.Setup("cannonFodder");
    Label_0082:
        return;
    }

    public static void KillTreantFunc()
    {
        if (Instance.killTreant == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killTreant = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_LUMBERJACK");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killTreant");
    Label_005D:
        return;
    }

    public static void KillTrollFunc()
    {
        if (Instance.killTrollBoss == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.killTrollBoss = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_TROLL_BOSS");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("killTrollBoss");
    Label_005D:
        return;
    }

    public static void LevelHeroHardFunc()
    {
        if (Instance.levelHeroMax == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.levelHeroMax = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_LEGEND");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("levelHeroMax");
    Label_005D:
        return;
    }

    public static void LevelHeroMediumFunc()
    {
        if (Instance.levelHeroMedium == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.levelHeroMedium = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_CHAMPION");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("levelHeroMedium");
    Label_005D:
        return;
    }

    public static void LikeAHenderson()
    {
        if (Instance.henderson == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        Instance.henderson = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0049;
        }
        Instance.steam.SetAchievement("ACH_HENDERSON");
        goto Label_005D;
    Label_0049:
        Instance.notificationAchievement.Setup("henderson");
    Label_005D:
        return;
    }

    public static void LoadFromSave(SaveGame s)
    {
        Instance.towerBuilded = s.TowerBuilded;
        Instance.easyTowerBuilder = s.EasyTowerBuilder;
        Instance.mediumTowerBuilder = s.MediumTowerBuilder;
        Instance.hardTowerBuilder = s.HardTowerBuilder;
        Instance.earn15Stars = s.Earn15Stars;
        Instance.earn30Stars = s.Earn30Stars;
        Instance.earn45Stars = s.Earn45Stars;
        Instance.whatsThat = s.WhatsThat;
        Instance.notificationEnemy = s.NotificationEnemy;
        Instance.earlyWavesCalled = s.EarlyWavesCalled;
        Instance.daring = s.Daring;
        Instance.towerUpgradeLevel3 = s.TowerUpgradeLevel3;
        Instance.magesTowerUpgradeLevel3 = s.MagesTowerUpgradeLevel3;
        Instance.archersTowerUpgradeLevel3 = s.ArchersTowerUpgradeLevel3;
        Instance.soldiersTowerUpgradeLevel3 = s.SoldiersTowerUpgradeLevel3;
        Instance.engineersTowerUpgradeLevel3 = s.EngineersTowerUpgradeLevel3;
        Instance.killedEnemies = s.KilledEnemies;
        Instance.firstBlood = s.FirstBlood;
        Instance.bloodlust = s.Bloodlust;
        Instance.mageBeamMeUp = s.MageBeamMeUp;
        Instance.mageBeamMeUpEnemies = s.MageBeamMeUpEnemies;
        Instance.armaggedon = s.Armaggedon;
        Instance.fireballKills = s.FireballKills;
        Instance.deathFromAbove = s.DeathFromAbove;
        Instance.killMountainBoss = s.KillMountainBoss;
        Instance.killJuggernaut = s.KillJuggernaut;
        Instance.slayer = s.Slayer;
        Instance.specialization = s.Specialization;
        Instance.buildRangers = s.BuildRangers;
        Instance.buildMusketeers = s.BuildMusketeers;
        Instance.buildPaladins = s.BuildPaladins;
        Instance.buildBarbarians = s.BuildBarbarians;
        Instance.buildArcanes = s.BuildArcanes;
        Instance.buildSorcerers = s.BuildSorcerers;
        Instance.buildBfg = s.BuildBfg;
        Instance.buildTesla = s.BuildTesla;
        Instance.rallyChanges = s.RallyChanges;
        Instance.tactician = s.Tactician;
        Instance.killEndBoss = s.KillEndBoss;
        Instance.soldiersTrained = s.SoldiersTrained;
        Instance.soldiersKilled = s.SoldiersKilled;
        Instance.soldiersRegeneration = s.SoldiersRegeneration;
        Instance.multiKill = s.MultiKill;
        Instance.giJoe = s.GiJoe;
        Instance.dieHard = s.DieHard;
        Instance.cannonFodder = s.CannonFodder;
        Instance.fearless = s.Fearless;
        Instance.sellTowers = s.SellTowers;
        Instance.sunrayShots = s.SunrayShots;
        Instance.realEstate = s.RealEstate;
        Instance.indecisive = s.Indecisive;
        Instance.impatient = s.Impatient;
        Instance.maxElves = s.MaxElves;
        Instance.imperialSaviour = s.ImperialSaviour;
        Instance.henderson = s.Henderson;
        Instance.sunburner = s.Sunburner;
        Instance.desintegrateKills = s.DesintegrateKills;
        Instance.polymorphKills = s.PolymorphKills;
        Instance.missilesFire = s.MissilesFire;
        Instance.poisonKills = s.PoisonKills;
        Instance.sniperKills = s.SniperKills;
        Instance.axesFire = s.AxesFire;
        Instance.dustToDust = s.DustToDust;
        Instance.shepard = s.Shepard;
        Instance.rocketeer = s.Rocketeer;
        Instance.toxicity = s.Toxicity;
        Instance.axeRainer = s.AxeRainer;
        Instance.sniper = s.Sniper;
        Instance.thornsEnemies = s.ThornsEnemies;
        Instance.energyNetwork = s.EnergyNetwork;
        Instance.elementalist = s.Elementalist;
        Instance.entangled = s.Entangled;
        Instance.barbarianRush = s.BarbarianRush;
        Instance.clustersFire = s.ClustersFire;
        Instance.acdcKills = s.AcdcKills;
        Instance.paladinHeals = s.PaladinHeals;
        Instance.holyChorusCount = s.HolyChorusCount;
        Instance.sheepsKilled = s.SheepsKilled;
        Instance.clusterRain = s.ClusterRain;
        Instance.acdc = s.Acdc;
        Instance.medic = s.Medic;
        Instance.holyChorus = s.HolyChorus;
        Instance.fisherman = s.Fisherman;
        Instance.sheepKiller = s.SheepKiller;
        Instance.greatDefender = s.GreatDefender;
        Instance.greatDefenderHeroic = s.GreatDefenderHeroic;
        Instance.greatDefenderIron = s.GreatDefenderIron;
        Instance.killSarelgaz = s.KillSarelgaz;
        Instance.freeFredo = s.FreeFredo;
        Instance.killGulThak = s.KillGulThak;
        Instance.killTreant = s.KillTreant;
        Instance.levelHeroMedium = s.LevelHeroMedium;
        Instance.levelHeroMax = s.LevelHeroMax;
        Instance.killKingping = s.KillKingping;
        Instance.acorn = s.Acorn;
        Instance.mushroom = s.Mushroom;
        Instance.coolRunning = s.CoolRunning;
        Instance.coolRunningKilledTrolls = s.CoolRunningKilledTrolls;
        Instance.killTrollBoss = s.KillTrollBoss;
        Instance.dineInHell = s.DineInHell;
        Instance.armyOfOne = s.ArmyOfOne;
        Instance.killDemon = s.KillDemon;
        Instance.killMushroom = s.KillMushroom;
        Instance.spore = s.Spore;
        Instance.stillCountsAsOne = s.StillCountsAsOne;
        return;
    }

    public static void LoadNotificationAchievement()
    {
        Instance.notificationAchievement = GameObject.Find("NotificationAchievement").GetComponent<NotificationAchievement>();
        Instance.notificationAchievement.gameObject.SetActive(0);
        return;
    }

    public static void MissileFire()
    {
        GameAchievements achievements1;
        if (Instance.rocketeer == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.missilesFire += 1;
        if (Instance.missilesFire != 130)
        {
            goto Label_0083;
        }
        Instance.rocketeer = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_ROCKETEER");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("rocketeer");
    Label_0083:
        return;
    }

    public static void MushroomFound(int m)
    {
        if (Instance.mushroom != null)
        {
            goto Label_0016;
        }
        if (m >= 5)
        {
            goto Label_0017;
        }
    Label_0016:
        return;
    Label_0017:
        Instance.mushroom = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0050;
        }
        Instance.steam.SetAchievement("ACH_PLANTS_TROLLS");
        goto Label_0064;
    Label_0050:
        Instance.notificationAchievement.Setup("mushroom");
    Label_0064:
        return;
    }

    public static void PoisonEnemy()
    {
        GameAchievements achievements1;
        if (Instance.toxicity == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.poisonKills += 1;
        if (Instance.poisonKills != 50)
        {
            goto Label_0080;
        }
        Instance.toxicity = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_TOXICITY");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("toxicity");
    Label_0080:
        return;
    }

    public static void PolymorphEnemy()
    {
        GameAchievements achievements1;
        if (Instance.shepard == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.polymorphKills += 1;
        if (Instance.polymorphKills != 50)
        {
            goto Label_0080;
        }
        Instance.shepard = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_SHEPHERD");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("shepard");
    Label_0080:
        return;
    }

    public static void Reset()
    {
        Instance.towerBuilded = 0;
        Instance.easyTowerBuilder = 0;
        Instance.mediumTowerBuilder = 0;
        Instance.hardTowerBuilder = 0;
        Instance.earn15Stars = 0;
        Instance.earn30Stars = 0;
        Instance.earn45Stars = 0;
        Instance.whatsThat = 0;
        Instance.notificationEnemy = 0;
        Instance.earlyWavesCalled = 0;
        Instance.daring = 0;
        Instance.towerUpgradeLevel3 = 0;
        Instance.magesTowerUpgradeLevel3 = 0;
        Instance.archersTowerUpgradeLevel3 = 0;
        Instance.soldiersTowerUpgradeLevel3 = 0;
        Instance.engineersTowerUpgradeLevel3 = 0;
        Instance.killedEnemies = 0;
        Instance.firstBlood = 0;
        Instance.bloodlust = 0;
        Instance.mageBeamMeUp = 0;
        Instance.mageBeamMeUpEnemies = 0;
        Instance.armaggedon = 0;
        Instance.fireballKills = 0;
        Instance.deathFromAbove = 0;
        Instance.killMountainBoss = 0;
        Instance.killJuggernaut = 0;
        Instance.slayer = 0;
        Instance.specialization = 0;
        Instance.buildRangers = 0;
        Instance.buildMusketeers = 0;
        Instance.buildPaladins = 0;
        Instance.buildBarbarians = 0;
        Instance.buildArcanes = 0;
        Instance.buildSorcerers = 0;
        Instance.buildBfg = 0;
        Instance.buildTesla = 0;
        Instance.rallyChanges = 0;
        Instance.tactician = 0;
        Instance.killEndBoss = 0;
        Instance.soldiersTrained = 0;
        Instance.soldiersKilled = 0;
        Instance.soldiersRegeneration = 0;
        Instance.multiKill = 0;
        Instance.giJoe = 0;
        Instance.dieHard = 0;
        Instance.cannonFodder = 0;
        Instance.fearless = 0;
        Instance.sellTowers = 0;
        Instance.sunrayShots = 0;
        Instance.realEstate = 0;
        Instance.indecisive = 0;
        Instance.impatient = 0;
        Instance.maxElves = 0;
        Instance.imperialSaviour = 0;
        Instance.henderson = 0;
        Instance.sunburner = 0;
        Instance.desintegrateKills = 0;
        Instance.polymorphKills = 0;
        Instance.missilesFire = 0;
        Instance.poisonKills = 0;
        Instance.sniperKills = 0;
        Instance.axesFire = 0;
        Instance.dustToDust = 0;
        Instance.shepard = 0;
        Instance.rocketeer = 0;
        Instance.toxicity = 0;
        Instance.sniper = 0;
        Instance.axeRainer = 0;
        Instance.thornsEnemies = 0;
        Instance.energyNetwork = 0;
        Instance.elementalist = 0;
        Instance.entangled = 0;
        Instance.barbarianRush = 0;
        Instance.clustersFire = 0;
        Instance.acdcKills = 0;
        Instance.paladinHeals = 0;
        Instance.holyChorusCount = 0;
        Instance.sheepsKilled = 0;
        Instance.clusterRain = 0;
        Instance.acdc = 0;
        Instance.medic = 0;
        Instance.holyChorus = 0;
        Instance.fisherman = 0;
        Instance.sheepKiller = 0;
        Instance.greatDefender = 0;
        Instance.greatDefenderHeroic = 0;
        Instance.greatDefenderIron = 0;
        Instance.freeFredo = 0;
        Instance.killSarelgaz = 0;
        Instance.killGulThak = 0;
        Instance.killTreant = 0;
        Instance.levelHeroMax = 0;
        Instance.levelHeroMedium = 0;
        Instance.killKingping = 0;
        Instance.acorn = 0;
        Instance.mushroom = 0;
        Instance.coolRunningKilledTrolls = 0;
        Instance.coolRunning = 0;
        Instance.killTrollBoss = 0;
        Instance.dineInHell = 0;
        Instance.dineInHellCounter = 0;
        Instance.armyOfOne = 0;
        Instance.armyOfOneCounter = 0;
        Instance.killDemon = 0;
        Instance.killMushroom = 0;
        Instance.sporeCount = 0;
        Instance.spore = 0;
        Instance.stillCountsAsOne = 0;
        Instance.stillCountsAsOneCount = 0;
        return;
    }

    public static void SellTower()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.sellTowers += 1;
        if (Instance.realEstate != null)
        {
            goto Label_007F;
        }
        if (Instance.sellTowers != 30)
        {
            goto Label_007F;
        }
        Instance.realEstate = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006B;
        }
        Instance.steam.SetAchievement("ACH_REAL_ESTATE");
        goto Label_007F;
    Label_006B:
        Instance.notificationAchievement.Setup("realEstate");
    Label_007F:
        return;
    }

    public static void SendAllAchievements()
    {
        if ((Instance.steam == null) == null)
        {
            goto Label_0016;
        }
        return;
    Label_0016:
        if (Instance.greatDefender == null)
        {
            goto Label_0039;
        }
        Instance.steam.SetAchievement("ACH_GREAT_DEFENDER");
    Label_0039:
        if (Instance.greatDefenderHeroic == null)
        {
            goto Label_005C;
        }
        Instance.steam.SetAchievement("ACH_HEROIC");
    Label_005C:
        if (Instance.greatDefenderIron == null)
        {
            goto Label_007F;
        }
        Instance.steam.SetAchievement("ACH_IRON");
    Label_007F:
        if (Instance.killMountainBoss == null)
        {
            goto Label_00A2;
        }
        Instance.steam.SetAchievement("ACH_KILL_JT");
    Label_00A2:
        return;
    }

    public static unsafe void SetDataBool(Dictionary<string, bool> myData)
    {
        myData.TryGetValue("easyTowerBuilder", &Instance.easyTowerBuilder);
        myData.TryGetValue("mediumTowerBuilder", &Instance.mediumTowerBuilder);
        myData.TryGetValue("hardTowerBuilder", &Instance.hardTowerBuilder);
        myData.TryGetValue("earn15Stars", &Instance.earn15Stars);
        myData.TryGetValue("earn30Stars", &Instance.earn30Stars);
        myData.TryGetValue("earn45Stars", &Instance.earn45Stars);
        myData.TryGetValue("whatsThat", &Instance.whatsThat);
        myData.TryGetValue("daring", &Instance.daring);
        myData.TryGetValue("firstBlood", &Instance.firstBlood);
        myData.TryGetValue("bloodlust", &Instance.bloodlust);
        myData.TryGetValue("mageBeamMeUp", &Instance.mageBeamMeUp);
        myData.TryGetValue("armaggedon", &Instance.armaggedon);
        myData.TryGetValue("deathFromAbove", &Instance.deathFromAbove);
        myData.TryGetValue("killMountainBoss", &Instance.killMountainBoss);
        myData.TryGetValue("killJuggernaut", &Instance.killJuggernaut);
        myData.TryGetValue("slayer", &Instance.slayer);
        myData.TryGetValue("specialization", &Instance.specialization);
        myData.TryGetValue("tactician", &Instance.tactician);
        myData.TryGetValue("killEndBoss", &Instance.killEndBoss);
        myData.TryGetValue("multiKill", &Instance.multiKill);
        myData.TryGetValue("giJoe", &Instance.giJoe);
        myData.TryGetValue("dieHard", &Instance.dieHard);
        myData.TryGetValue("cannonFodder", &Instance.cannonFodder);
        myData.TryGetValue("fearless", &Instance.fearless);
        myData.TryGetValue("realEstate", &Instance.realEstate);
        myData.TryGetValue("indecisive", &Instance.indecisive);
        myData.TryGetValue("impatient", &Instance.impatient);
        myData.TryGetValue("maxElves", &Instance.maxElves);
        myData.TryGetValue("imperialSaviour", &Instance.imperialSaviour);
        myData.TryGetValue("henderson", &Instance.henderson);
        myData.TryGetValue("sunburner", &Instance.sunburner);
        myData.TryGetValue("dustToDust", &Instance.dustToDust);
        myData.TryGetValue("shepard", &Instance.shepard);
        myData.TryGetValue("rocketeer", &Instance.rocketeer);
        myData.TryGetValue("toxicity", &Instance.toxicity);
        myData.TryGetValue("sniper", &Instance.sniper);
        myData.TryGetValue("axeRainer", &Instance.axeRainer);
        myData.TryGetValue("energyNetwork", &Instance.energyNetwork);
        myData.TryGetValue("elementalist", &Instance.elementalist);
        myData.TryGetValue("entangled", &Instance.entangled);
        myData.TryGetValue("barbarianRush", &Instance.barbarianRush);
        myData.TryGetValue("clusterRain", &Instance.clusterRain);
        myData.TryGetValue("acdc", &Instance.acdc);
        myData.TryGetValue("medic", &Instance.medic);
        myData.TryGetValue("holyChorus", &Instance.holyChorus);
        myData.TryGetValue("fisherman", &Instance.fisherman);
        myData.TryGetValue("sheepKiller", &Instance.sheepKiller);
        myData.TryGetValue("greatDefender", &Instance.greatDefender);
        myData.TryGetValue("greatDefenderHeroic", &Instance.greatDefenderHeroic);
        myData.TryGetValue("greatDefenderIron", &Instance.greatDefenderIron);
        myData.TryGetValue("freeFredo", &Instance.freeFredo);
        myData.TryGetValue("killSarelgaz", &Instance.killSarelgaz);
        myData.TryGetValue("killGulThak", &Instance.killGulThak);
        myData.TryGetValue("killKingping", &Instance.killKingping);
        myData.TryGetValue("acorn", &Instance.acorn);
        myData.TryGetValue("mushroom", &Instance.mushroom);
        myData.TryGetValue("coolRunning", &Instance.coolRunning);
        myData.TryGetValue("killTrollBoss", &Instance.killTrollBoss);
        myData.TryGetValue("dineInHell", &Instance.dineInHell);
        myData.TryGetValue("armyOfOne", &Instance.armyOfOne);
        myData.TryGetValue("killDemon", &Instance.killDemon);
        myData.TryGetValue("killMushroom", &Instance.killMushroom);
        myData.TryGetValue("spore", &Instance.spore);
        myData.TryGetValue("stillCountsAsOne", &Instance.stillCountsAsOne);
        return;
    }

    public static unsafe void SetDataInt(Dictionary<string, int> myData)
    {
        myData.TryGetValue("towerBuilded", &Instance.towerBuilded);
        myData.TryGetValue("notificationEnemy", &Instance.notificationEnemy);
        myData.TryGetValue("earlyWavesCalled", &Instance.earlyWavesCalled);
        myData.TryGetValue("magesTowerUpgradeLevel3", &Instance.magesTowerUpgradeLevel3);
        myData.TryGetValue("archersTowerUpgradeLevel3", &Instance.archersTowerUpgradeLevel3);
        myData.TryGetValue("soldiersTowerUpgradeLevel3", &Instance.soldiersTowerUpgradeLevel3);
        myData.TryGetValue("killedEnemies", &Instance.killedEnemies);
        myData.TryGetValue("mageBeamMeUpEnemies", &Instance.mageBeamMeUpEnemies);
        myData.TryGetValue("fireballKills", &Instance.fireballKills);
        myData.TryGetValue("buildRangers", &Instance.buildRangers);
        myData.TryGetValue("buildMusketeers", &Instance.buildMusketeers);
        myData.TryGetValue("buildPaladins", &Instance.buildPaladins);
        myData.TryGetValue("buildBarbarians", &Instance.buildBarbarians);
        myData.TryGetValue("buildArcanes", &Instance.buildArcanes);
        myData.TryGetValue("buildSorcerers", &Instance.buildSorcerers);
        myData.TryGetValue("buildBfg", &Instance.buildBfg);
        myData.TryGetValue("buildTesla", &Instance.buildTesla);
        myData.TryGetValue("rallyChanges", &Instance.rallyChanges);
        myData.TryGetValue("soldiersTrained", &Instance.soldiersTrained);
        myData.TryGetValue("soldiersKilled", &Instance.soldiersKilled);
        myData.TryGetValue("soldiersRegeneration", &Instance.soldiersRegeneration);
        myData.TryGetValue("sellTowers", &Instance.sellTowers);
        myData.TryGetValue("sunrayShots", &Instance.sunrayShots);
        myData.TryGetValue("desintegrateKills", &Instance.desintegrateKills);
        myData.TryGetValue("polymorphKills", &Instance.polymorphKills);
        myData.TryGetValue("missilesFire", &Instance.missilesFire);
        myData.TryGetValue("poisonKills", &Instance.poisonKills);
        myData.TryGetValue("sniperKills", &Instance.sniperKills);
        myData.TryGetValue("axesFire", &Instance.axesFire);
        myData.TryGetValue("thornsEnemies", &Instance.thornsEnemies);
        myData.TryGetValue("clustersFire", &Instance.clustersFire);
        myData.TryGetValue("acdcKills", &Instance.acdcKills);
        myData.TryGetValue("paladinHeals", &Instance.paladinHeals);
        myData.TryGetValue("holyChorusCount", &Instance.holyChorusCount);
        myData.TryGetValue("sheepsKilled", &Instance.sheepsKilled);
        myData.TryGetValue("coolRunningKilledTrolls", &Instance.coolRunningKilledTrolls);
        return;
    }

    public static void SniperEnemy()
    {
        GameAchievements achievements1;
        if (Instance.sniper == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.sniperKills += 1;
        if (Instance.sniperKills != 50)
        {
            goto Label_0080;
        }
        Instance.sniper = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_SNIPER");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("sniper");
    Label_0080:
        return;
    }

    public static void SporeFunc()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.sporeCount += 1;
        if (Instance.spore == null)
        {
            goto Label_0022;
        }
        return;
    Label_0022:
        if (Instance.sporeCount >= 0x19)
        {
            goto Label_0034;
        }
        return;
    Label_0034:
        Instance.spore = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006D;
        }
        Instance.steam.SetAchievement("ACH_SPORE");
        goto Label_0081;
    Label_006D:
        Instance.notificationAchievement.Setup("spore");
    Label_0081:
        return;
    }

    public static void StillCountsAsOneFunc(int d)
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.stillCountsAsOneCount += d;
        if (Instance.stillCountsAsOne == null)
        {
            goto Label_0022;
        }
        return;
    Label_0022:
        if (Instance.stillCountsAsOneCount >= 0x2710)
        {
            goto Label_0037;
        }
        return;
    Label_0037:
        Instance.stillCountsAsOne = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_0070;
        }
        Instance.steam.SetAchievement("ACH_STILLCOUNTSASONE");
        goto Label_0084;
    Label_0070:
        Instance.notificationAchievement.Setup("stillCountsAsOne");
    Label_0084:
        return;
    }

    public static void TeslaKill()
    {
        GameAchievements achievements1;
        if (Instance.acdc == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.acdcKills += 1;
        if (Instance.acdcKills != 300)
        {
            goto Label_0083;
        }
        Instance.acdc = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_ACDC");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("acdc");
    Label_0083:
        return;
    }

    public static void ThornEnemy()
    {
        GameAchievements achievements1;
        if (Instance.entangled == null)
        {
            goto Label_0010;
        }
        return;
    Label_0010:
        achievements1 = Instance;
        achievements1.thornsEnemies += 1;
        if (Instance.thornsEnemies != 500)
        {
            goto Label_0083;
        }
        Instance.entangled = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006F;
        }
        Instance.steam.SetAchievement("ACH_ENTANGLED");
        goto Label_0083;
    Label_006F:
        Instance.notificationAchievement.Setup("entangled");
    Label_0083:
        return;
    }

    public static void TrainSoldier()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.soldiersTrained += 1;
        if (Instance.giJoe != null)
        {
            goto Label_0082;
        }
        if (Instance.soldiersTrained != 0x3e8)
        {
            goto Label_0082;
        }
        Instance.giJoe = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006E;
        }
        Instance.steam.SetAchievement("ACH_GI_JOE");
        goto Label_0082;
    Label_006E:
        Instance.notificationAchievement.Setup("giJoe");
    Label_0082:
        return;
    }

    public static void TrollSkaterKilled()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.coolRunningKilledTrolls += 1;
        if (Instance.coolRunning != null)
        {
            goto Label_0032;
        }
        if (Instance.coolRunningKilledTrolls >= 10)
        {
            goto Label_0033;
        }
    Label_0032:
        return;
    Label_0033:
        Instance.coolRunning = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006C;
        }
        Instance.steam.SetAchievement("ACH_COOLRUNNING");
        goto Label_0080;
    Label_006C:
        Instance.notificationAchievement.Setup("coolRunning");
    Label_0080:
        return;
    }

    public static void UpgradeTowerLevel3(string towerType)
    {
        GameAchievements achievements4;
        GameAchievements achievements3;
        GameAchievements achievements2;
        GameAchievements achievements1;
        if (towerType.Equals("archer") == null)
        {
            goto Label_0027;
        }
        achievements1 = Instance;
        achievements1.archersTowerUpgradeLevel3 += 1;
        goto Label_0097;
    Label_0027:
        if (towerType.Equals("soldier") == null)
        {
            goto Label_004E;
        }
        achievements2 = Instance;
        achievements2.soldiersTowerUpgradeLevel3 += 1;
        goto Label_0097;
    Label_004E:
        if (towerType.Equals("mage") == null)
        {
            goto Label_0075;
        }
        achievements3 = Instance;
        achievements3.magesTowerUpgradeLevel3 += 1;
        goto Label_0097;
    Label_0075:
        if (towerType.Equals("engineer") == null)
        {
            goto Label_0097;
        }
        achievements4 = Instance;
        achievements4.engineersTowerUpgradeLevel3 += 1;
    Label_0097:
        if (Instance.towerUpgradeLevel3 != null)
        {
            goto Label_012F;
        }
        if (Instance.archersTowerUpgradeLevel3 == null)
        {
            goto Label_012F;
        }
        if (Instance.soldiersTowerUpgradeLevel3 == null)
        {
            goto Label_012F;
        }
        if (Instance.magesTowerUpgradeLevel3 == null)
        {
            goto Label_012F;
        }
        if (Instance.engineersTowerUpgradeLevel3 == null)
        {
            goto Label_012F;
        }
        Instance.towerUpgradeLevel3 = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_011B;
        }
        Instance.steam.SetAchievement("ACH_HOME_IMPROVEMENT");
        goto Label_012F;
    Label_011B:
        Instance.notificationAchievement.Setup("towerUpgradeLevel3");
    Label_012F:
        return;
    }

    public static void ViewNotification()
    {
        GameAchievements achievements1;
        achievements1 = Instance;
        achievements1.notificationEnemy += 1;
        if (Instance.whatsThat != null)
        {
            goto Label_007E;
        }
        if (Instance.notificationEnemy != 5)
        {
            goto Label_007E;
        }
        Instance.whatsThat = 1;
        if ((Instance.steam != null) == null)
        {
            goto Label_006A;
        }
        Instance.steam.SetAchievement("ACH_WHATS_THAT");
        goto Label_007E;
    Label_006A:
        Instance.notificationAchievement.Setup("whatsThat");
    Label_007E:
        return;
    }

    public static bool ACDC
    {
        get
        {
            return Instance.acdc;
        }
    }

    public static int AcdcKills
    {
        get
        {
            return Instance.acdcKills;
        }
    }

    public static bool Acorn
    {
        get
        {
            return Instance.acorn;
        }
    }

    public static int ArchersTowerUpgradeLevel3
    {
        get
        {
            return Instance.archersTowerUpgradeLevel3;
        }
    }

    public static bool Armaggedon
    {
        get
        {
            return Instance.armaggedon;
        }
    }

    public static bool ArmyOfOne
    {
        get
        {
            return Instance.armyOfOne;
        }
    }

    public static int ArmyOfOneCounter
    {
        get
        {
            return Instance.armyOfOneCounter;
        }
    }

    public static bool AxeRainer
    {
        get
        {
            return Instance.axeRainer;
        }
    }

    public static int AxesFire
    {
        get
        {
            return Instance.axesFire;
        }
    }

    public static bool BarbarianRush
    {
        get
        {
            return Instance.barbarianRush;
        }
    }

    public static bool BeamMeUp
    {
        get
        {
            return Instance.mageBeamMeUp;
        }
    }

    public static bool Bloodlust
    {
        get
        {
            return Instance.bloodlust;
        }
    }

    public static int BuildArcanes
    {
        get
        {
            return Instance.buildArcanes;
        }
    }

    public static int BuildBarbarians
    {
        get
        {
            return Instance.buildBarbarians;
        }
    }

    public static int BuildBfg
    {
        get
        {
            return Instance.buildBfg;
        }
    }

    public static int BuildMusketeers
    {
        get
        {
            return Instance.buildMusketeers;
        }
    }

    public static int BuildPaladins
    {
        get
        {
            return Instance.buildPaladins;
        }
    }

    public static int BuildRangers
    {
        get
        {
            return Instance.buildRangers;
        }
    }

    public static int BuildSorcerers
    {
        get
        {
            return Instance.buildSorcerers;
        }
    }

    public static int BuildTesla
    {
        get
        {
            return Instance.buildTesla;
        }
    }

    public static bool CannonFodder
    {
        get
        {
            return Instance.cannonFodder;
        }
    }

    public static bool ClusterRain
    {
        get
        {
            return Instance.clusterRain;
        }
    }

    public static int ClustersFire
    {
        get
        {
            return Instance.clustersFire;
        }
    }

    public static bool CoolRunning
    {
        get
        {
            return Instance.coolRunning;
        }
    }

    public static int CoolRunningKilledTrolls
    {
        get
        {
            return Instance.coolRunningKilledTrolls;
        }
    }

    public static bool Daring
    {
        get
        {
            return Instance.daring;
        }
    }

    public static bool DeathFromAbove
    {
        get
        {
            return Instance.deathFromAbove;
        }
    }

    public static int DesintegrateKills
    {
        get
        {
            return Instance.desintegrateKills;
        }
    }

    public static bool DieHard
    {
        get
        {
            return Instance.dieHard;
        }
    }

    public static bool DineInHell
    {
        get
        {
            return Instance.dineInHell;
        }
    }

    public static int DineInHellCounter
    {
        get
        {
            return Instance.dineInHellCounter;
        }
    }

    public static bool DustToDust
    {
        get
        {
            return Instance.dustToDust;
        }
    }

    public static int EarlyWavesCalled
    {
        get
        {
            return Instance.earlyWavesCalled;
        }
    }

    public static bool Earn15Stars
    {
        get
        {
            return Instance.earn15Stars;
        }
    }

    public static bool Earn30Stars
    {
        get
        {
            return Instance.earn30Stars;
        }
    }

    public static bool Earn45Stars
    {
        get
        {
            return Instance.earn45Stars;
        }
    }

    public static bool EasyTowerBuilder
    {
        get
        {
            return Instance.easyTowerBuilder;
        }
    }

    public static bool Elementalist
    {
        get
        {
            return Instance.elementalist;
        }
    }

    public static bool EnergyNetwork
    {
        get
        {
            return Instance.energyNetwork;
        }
    }

    public static int EngineersTowerUpgradeLevel3
    {
        get
        {
            return Instance.engineersTowerUpgradeLevel3;
        }
    }

    public static bool Entangled
    {
        get
        {
            return Instance.entangled;
        }
    }

    public static bool Fearless
    {
        get
        {
            return Instance.fearless;
        }
    }

    public static int FireballKills
    {
        get
        {
            return Instance.fireballKills;
        }
    }

    public static bool FirstBlood
    {
        get
        {
            return Instance.firstBlood;
        }
    }

    public static bool Fisherman
    {
        get
        {
            return Instance.fisherman;
        }
    }

    public static bool FreeFredo
    {
        get
        {
            return Instance.freeFredo;
        }
    }

    public static bool GiJoe
    {
        get
        {
            return Instance.giJoe;
        }
    }

    public static bool GreatDefender
    {
        get
        {
            return Instance.greatDefender;
        }
    }

    public static bool GreatDefenderHeroic
    {
        get
        {
            return Instance.greatDefenderHeroic;
        }
    }

    public static bool GreatDefenderIron
    {
        get
        {
            return Instance.greatDefenderIron;
        }
    }

    public static bool HardTowerBuilder
    {
        get
        {
            return Instance.hardTowerBuilder;
        }
    }

    public static bool Henderson
    {
        get
        {
            return Instance.henderson;
        }
    }

    public static bool HolyChorus
    {
        get
        {
            return Instance.holyChorus;
        }
    }

    public static int HolyChorusCount
    {
        get
        {
            return Instance.holyChorusCount;
        }
    }

    public static bool Impatient
    {
        get
        {
            return Instance.impatient;
        }
    }

    public static bool ImperialSaviour
    {
        get
        {
            return Instance.imperialSaviour;
        }
    }

    public static bool Indecisive
    {
        get
        {
            return Instance.indecisive;
        }
    }

    public static GameAchievements Instance
    {
        get
        {
            if (instance != null)
            {
                goto Label_0010;
            }
            new GameAchievements();
        Label_0010:
            return instance;
        }
    }

    public static bool KillDemon
    {
        get
        {
            return Instance.killDemon;
        }
    }

    public static int KilledEnemies
    {
        get
        {
            return Instance.killedEnemies;
        }
    }

    public static bool KillEndBoss
    {
        get
        {
            return Instance.killEndBoss;
        }
    }

    public static bool KillGreenmuck
    {
        get
        {
            return Instance.killTreant;
        }
    }

    public static bool KillGulthak
    {
        get
        {
            return Instance.killGulThak;
        }
    }

    public static bool KillJuggernaut
    {
        get
        {
            return Instance.killJuggernaut;
        }
    }

    public static bool KillKingpin
    {
        get
        {
            return Instance.killKingping;
        }
    }

    public static bool KillMountainBoss
    {
        get
        {
            return Instance.killMountainBoss;
        }
    }

    public static bool KillMushroom
    {
        get
        {
            return Instance.killMushroom;
        }
    }

    public static bool KillSarelgaz
    {
        get
        {
            return Instance.killSarelgaz;
        }
    }

    public static bool KillTreant
    {
        get
        {
            return Instance.killTreant;
        }
    }

    public static bool KillTrollBoss
    {
        get
        {
            return Instance.killTrollBoss;
        }
    }

    public static bool LevelHeroMax
    {
        get
        {
            return Instance.levelHeroMax;
        }
    }

    public static bool LevelHeroMedium
    {
        get
        {
            return Instance.levelHeroMedium;
        }
    }

    public static int MageBeamMeUpEnemies
    {
        get
        {
            return Instance.mageBeamMeUpEnemies;
        }
    }

    public static int MagesTowerUpgradeLevel3
    {
        get
        {
            return Instance.magesTowerUpgradeLevel3;
        }
    }

    public static bool MaxElves
    {
        get
        {
            return Instance.maxElves;
        }
    }

    public static bool Medic
    {
        get
        {
            return Instance.medic;
        }
    }

    public static bool MediumTowerBuilder
    {
        get
        {
            return Instance.mediumTowerBuilder;
        }
    }

    public static int MissilesFire
    {
        get
        {
            return Instance.missilesFire;
        }
    }

    public static bool MultiKill
    {
        get
        {
            return Instance.multiKill;
        }
    }

    public static bool Mushroom
    {
        get
        {
            return Instance.mushroom;
        }
    }

    public static int NotificationEnemy
    {
        get
        {
            return Instance.notificationEnemy;
        }
    }

    public static int PaladinHeals
    {
        get
        {
            return Instance.paladinHeals;
        }
    }

    public static int PoisonKills
    {
        get
        {
            return Instance.poisonKills;
        }
    }

    public static int PolymorphKills
    {
        get
        {
            return Instance.polymorphKills;
        }
    }

    public static int RallyChanges
    {
        get
        {
            return Instance.rallyChanges;
        }
    }

    public static bool RealEstate
    {
        get
        {
            return Instance.realEstate;
        }
    }

    public static bool Rocketeer
    {
        get
        {
            return Instance.rocketeer;
        }
    }

    public static int SellTowers
    {
        get
        {
            return Instance.sellTowers;
        }
    }

    public static bool SheepKiller
    {
        get
        {
            return Instance.sheepKiller;
        }
    }

    public static int SheepsKilled
    {
        get
        {
            return Instance.sheepsKilled;
        }
    }

    public static bool Shepard
    {
        get
        {
            return Instance.shepard;
        }
    }

    public static bool Slayer
    {
        get
        {
            return Instance.slayer;
        }
    }

    public static bool Sniper
    {
        get
        {
            return Instance.sniper;
        }
    }

    public static int SniperKills
    {
        get
        {
            return Instance.sniperKills;
        }
    }

    public static int SoldiersKilled
    {
        get
        {
            return Instance.soldiersKilled;
        }
    }

    public static int SoldiersRegeneration
    {
        get
        {
            return Instance.soldiersRegeneration;
        }
    }

    public static int SoldiersTowerUpgradeLevel3
    {
        get
        {
            return Instance.soldiersTowerUpgradeLevel3;
        }
    }

    public static int SoldiersTrained
    {
        get
        {
            return Instance.soldiersTrained;
        }
    }

    public static bool Specialization
    {
        get
        {
            return Instance.specialization;
        }
    }

    public static bool Spore
    {
        get
        {
            return Instance.spore;
        }
    }

    public static int SporeCount
    {
        get
        {
            return Instance.sporeCount;
        }
    }

    public static bool StillCountsAsOne
    {
        get
        {
            return Instance.stillCountsAsOne;
        }
    }

    public static int StillCountsAsOneCount
    {
        get
        {
            return Instance.stillCountsAsOneCount;
        }
    }

    public static bool Sunburner
    {
        get
        {
            return Instance.sunburner;
        }
    }

    public static int SunrayShots
    {
        get
        {
            return Instance.sunrayShots;
        }
    }

    public static bool Tactician
    {
        get
        {
            return Instance.tactician;
        }
    }

    public static int ThornsEnemies
    {
        get
        {
            return Instance.thornsEnemies;
        }
    }

    public static int TowerBuilded
    {
        get
        {
            return Instance.towerBuilded;
        }
    }

    public static bool TowerUpgradeLevel3
    {
        get
        {
            return Instance.towerUpgradeLevel3;
        }
    }

    public static bool Toxicity
    {
        get
        {
            return Instance.toxicity;
        }
    }

    public static bool WhatsThat
    {
        get
        {
            return Instance.whatsThat;
        }
    }
}

