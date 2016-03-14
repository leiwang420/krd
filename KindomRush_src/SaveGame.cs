using System;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class SaveGame : ISerializable
{
    private bool acdc;
    private int acdcKills;
    private bool acorn;
    private int archersTowerUpgradeLevel3;
    private bool archersUpEagleEye;
    private bool archersUpFarShots;
    private int archersUpLevel;
    private bool archersUpPiercing;
    private bool archersUpPrecision;
    private bool archersUpSalvage;
    private bool armaggedon;
    private bool armyOfOne;
    private int armyOfOneCounter;
    private bool axeRainer;
    private int axesFire;
    private bool barbarianRush;
    private bool barracksUpBarbedArmor;
    private bool barracksUpBetterArmor;
    private bool barracksUpImprovedDeployment;
    private int barracksUpLevel;
    private bool barracksUpSurvival;
    private bool barracksUpSurvival2;
    private bool bloodlust;
    private int buildArcanes;
    private int buildBarbarians;
    private int buildBfg;
    private int buildMusketeers;
    private int buildPaladins;
    private int buildRangers;
    private int buildSorcerers;
    private int buildTesla;
    [NonSerialized]
    private ArrayList campaignLevels;
    private bool cannonFodder;
    private bool challengeTipShowed;
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
    private bool engineersUpConcentratedFire;
    private bool engineersUpEfficiency;
    private bool engineersUpFieldLogistics;
    private bool engineersUpIndustrialization;
    private int engineersUpLevel;
    private bool engineersUpRangeFinder;
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
    private int heroesCost;
    private bool heroesEnabled;
    private bool holyChorus;
    private int holyChorusCount;
    private bool impatient;
    private bool imperialSaviour;
    private bool inAppHelpShow;
    private bool indecisive;
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
    private bool levelSelectHelpShowed;
    private bool mageBeamMeUp;
    private int mageBeamMeUpEnemies;
    private int magesTowerUpgradeLevel3;
    private bool magesUpArcaneShatter;
    private int magesUpArcaneShatterDamage;
    private bool magesUpEmpoweredMagic;
    private bool magesUpHermeticStudy;
    private int magesUpLevel;
    private bool magesUpSlowCurse;
    private bool magesUpSpellReach;
    private bool maxElves;
    private bool medic;
    private bool mediumTowerBuilder;
    private int missilesFire;
    private bool multiKill;
    private bool mushroom;
    private int notificationEnemy;
    private bool notificationEnemyBandit;
    private bool notificationEnemyBossBandit;
    private bool notificationEnemyBossDemonMoloch;
    private bool notificationEnemyBossMyconid;
    private bool notificationEnemyBossTreant;
    private bool notificationEnemyBrigand;
    private bool notificationEnemyCerberus;
    private bool notificationEnemyDarkKnight;
    private bool notificationEnemyDarkSlayer;
    private bool notificationEnemyDemon;
    private bool notificationEnemyDemonImp;
    private bool notificationEnemyDemonMage;
    private bool notificationEnemyDemonWolf;
    private bool notificationEnemyFatOrc;
    private bool notificationEnemyFlareon;
    private bool notificationEnemyForestTroll;
    private bool notificationEnemyGargoyle;
    private bool notificationEnemyGoblin;
    private bool notificationEnemyGoblinZapper;
    private bool notificationEnemyGolemHead;
    private bool notificationEnemyGulaemon;
    private bool notificationEnemyGulThak;
    private bool notificationEnemyJuggernaut;
    private bool notificationEnemyLavaElemental;
    private bool notificationEnemyLegion;
    private bool notificationEnemyMarauder;
    private bool notificationEnemyNecromancer;
    private bool notificationEnemyOgre;
    private bool notificationEnemyOrcArmored;
    private bool notificationEnemyOrcRider;
    private bool notificationEnemyPillager;
    private bool notificationEnemyRaider;
    private bool notificationEnemyRocketeer;
    private bool notificationEnemyRottenLesser;
    private bool notificationEnemyRottenSpider;
    private bool notificationEnemyRottenTree;
    private bool notificationEnemySarelgaz;
    private bool notificationEnemySarelgazSmall;
    private bool notificationEnemyShadowArcher;
    private bool notificationEnemyShaman;
    private bool notificationEnemySkeletor;
    private bool notificationEnemySkeletorBig;
    private bool notificationEnemySmallWolf;
    private bool notificationEnemySpider;
    private bool notificationEnemySpiderSmall;
    private bool notificationEnemySwampThing;
    private bool notificationEnemyTroll;
    private bool notificationEnemyTrollAxeThrower;
    private bool notificationEnemyTrollBoss;
    private bool notificationEnemyTrollBrute;
    private bool notificationEnemyTrollChieftain;
    private bool notificationEnemyTrollSkater;
    private bool notificationEnemyVeznan;
    private bool notificationEnemyWhiteWolf;
    private bool notificationEnemyWolf;
    private bool notificationEnemyYeti;
    private bool notificationEnemyYetiBoss;
    private bool notificationEnemyZombie;
    private bool notificationTipHeroes;
    private bool notificationTowerArchersLevel2;
    private bool notificationTowerArchersLevel3;
    private bool notificationTowerArchersMusketeer;
    private bool notificationTowerArchersRanger;
    private bool notificationTowerEngineersBfg;
    private bool notificationTowerEngineersLevel2;
    private bool notificationTowerEngineersLevel3;
    private bool notificationTowerEngineersTesla;
    private bool notificationTowerMagesArcane;
    private bool notificationTowerMagesLevel2;
    private bool notificationTowerMagesLevel3;
    private bool notificationTowerMagesSorcerer;
    private bool notificationTowerSoldiersBarbarian;
    private bool notificationTowerSoldiersLevel2;
    private bool notificationTowerSoldiersLevel3;
    private bool notificationTowerSoldiersPaladin;
    private int paladinHeals;
    private int poisonKills;
    private int polymorphKills;
    private bool rainUpBiggerAndMeaner;
    private bool rainUpBlazingEarth;
    private bool rainUpBlazingSkies;
    private bool rainUpCataclysm;
    private int rainUpLevel;
    private bool rainUpScorchedEarth;
    private int rallyChanges;
    private bool realEstate;
    private int reinforcementLevel;
    private bool rocketeer;
    private int selectedHero;
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
    private float soundFxVolume;
    private float soundMusicVolume;
    private bool specialization;
    private bool spore;
    private int sporeCount;
    private StageData stage1;
    private StageData stage10;
    private StageData stage11;
    private StageData stage12;
    private StageData stage13;
    private StageData stage14;
    private StageData stage15;
    private StageData stage16;
    private StageData stage17;
    private StageData stage2;
    private StageData stage3;
    private StageData stage4;
    private StageData stage5;
    private StageData stage6;
    private StageData stage7;
    private StageData stage8;
    private StageData stage9;
    private int starsSpent;
    private int starsToSpent;
    private int starsTotal;
    private int starsWon;
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

    public SaveGame()
    {
        base..ctor();
        return;
    }

    public SaveGame(SerializationInfo info, StreamingContext context)
    {
        Exception exception;
        SerializationException exception2;
        SerializationException exception3;
        SerializationException exception4;
        base..ctor();
        this.towerBuilded = (int) info.GetValue("towerBuilded", typeof(int));
        this.easyTowerBuilder = (bool) info.GetValue("easyTowerBuilder", typeof(bool));
        this.mediumTowerBuilder = (bool) info.GetValue("mediumTowerBuilder", typeof(bool));
        this.hardTowerBuilder = (bool) info.GetValue("hardTowerBuilder", typeof(bool));
        this.earn15Stars = (bool) info.GetValue("earn15Stars", typeof(bool));
        this.earn30Stars = (bool) info.GetValue("earn30Stars", typeof(bool));
        this.earn45Stars = (bool) info.GetValue("earn45Stars", typeof(bool));
        this.whatsThat = (bool) info.GetValue("whatsThat", typeof(bool));
        this.notificationEnemy = (int) info.GetValue("notificationEnemy", typeof(int));
        this.earlyWavesCalled = (int) info.GetValue("earlyWavesCalled", typeof(int));
        this.daring = (bool) info.GetValue("daring", typeof(bool));
        this.towerUpgradeLevel3 = (bool) info.GetValue("towerUpgradeLevel3", typeof(bool));
        this.magesTowerUpgradeLevel3 = (int) info.GetValue("magesTowerUpgradeLevel3", typeof(int));
        this.archersTowerUpgradeLevel3 = (int) info.GetValue("archersTowerUpgradeLevel3", typeof(int));
        this.soldiersTowerUpgradeLevel3 = (int) info.GetValue("soldiersTowerUpgradeLevel3", typeof(int));
        this.engineersTowerUpgradeLevel3 = (int) info.GetValue("engineersTowerUpgradeLevel3", typeof(int));
        this.killedEnemies = (int) info.GetValue("killedEnemies", typeof(int));
        this.firstBlood = (bool) info.GetValue("firstBlood", typeof(bool));
        this.bloodlust = (bool) info.GetValue("bloodlust", typeof(bool));
        this.mageBeamMeUp = (bool) info.GetValue("mageBeamMeUp", typeof(bool));
        this.mageBeamMeUpEnemies = (int) info.GetValue("mageBeamMeUpEnemies", typeof(int));
        this.armaggedon = (bool) info.GetValue("armaggedon", typeof(bool));
        this.fireballKills = (int) info.GetValue("fireballKills", typeof(int));
        this.deathFromAbove = (bool) info.GetValue("deathFromAbove", typeof(bool));
        this.killMountainBoss = (bool) info.GetValue("killMountainBoss", typeof(bool));
        this.killJuggernaut = (bool) info.GetValue("killJuggernaut", typeof(bool));
        this.slayer = (bool) info.GetValue("slayer", typeof(bool));
        this.specialization = (bool) info.GetValue("specialization", typeof(bool));
        this.buildRangers = (int) info.GetValue("buildRangers", typeof(int));
        this.buildMusketeers = (int) info.GetValue("buildMusketeers", typeof(int));
        this.buildPaladins = (int) info.GetValue("buildPaladins", typeof(int));
        this.buildBarbarians = (int) info.GetValue("buildBarbarians", typeof(int));
        this.buildArcanes = (int) info.GetValue("buildArcanes", typeof(int));
        this.buildSorcerers = (int) info.GetValue("buildSorcerers", typeof(int));
        this.buildBfg = (int) info.GetValue("buildBfg", typeof(int));
        this.buildTesla = (int) info.GetValue("buildTesla", typeof(int));
        this.rallyChanges = (int) info.GetValue("rallyChanges", typeof(int));
        this.tactician = (bool) info.GetValue("tactician", typeof(bool));
        this.killEndBoss = (bool) info.GetValue("killEndBoss", typeof(bool));
        this.soldiersTrained = (int) info.GetValue("soldiersTrained", typeof(int));
        this.soldiersKilled = (int) info.GetValue("soldiersKilled", typeof(int));
        this.soldiersRegeneration = (int) info.GetValue("soldiersRegeneration", typeof(int));
        this.multiKill = (bool) info.GetValue("multiKill", typeof(bool));
        this.giJoe = (bool) info.GetValue("giJoe", typeof(bool));
        this.dieHard = (bool) info.GetValue("dieHard", typeof(bool));
        this.cannonFodder = (bool) info.GetValue("cannonFodder", typeof(bool));
        this.fearless = (bool) info.GetValue("fearless", typeof(bool));
        this.sellTowers = (int) info.GetValue("sellTowers", typeof(int));
        this.sunrayShots = (int) info.GetValue("sunrayShots", typeof(int));
        this.realEstate = (bool) info.GetValue("realEstate", typeof(bool));
        this.indecisive = (bool) info.GetValue("indecisive", typeof(bool));
        this.impatient = (bool) info.GetValue("impatient", typeof(bool));
        this.maxElves = (bool) info.GetValue("maxElves", typeof(bool));
        this.imperialSaviour = (bool) info.GetValue("imperialSaviour", typeof(bool));
        this.henderson = (bool) info.GetValue("henderson", typeof(bool));
        this.sunburner = (bool) info.GetValue("sunburner", typeof(bool));
        this.desintegrateKills = (int) info.GetValue("desintegrateKills", typeof(int));
        this.polymorphKills = (int) info.GetValue("polymorphKills", typeof(int));
        this.missilesFire = (int) info.GetValue("missilesFire", typeof(int));
        this.poisonKills = (int) info.GetValue("poisonKills", typeof(int));
        this.sniperKills = (int) info.GetValue("sniperKills", typeof(int));
        this.axesFire = (int) info.GetValue("axesFire", typeof(int));
        this.dustToDust = (bool) info.GetValue("dustToDust", typeof(bool));
        this.shepard = (bool) info.GetValue("shepard", typeof(bool));
        this.rocketeer = (bool) info.GetValue("rocketeer", typeof(bool));
        this.toxicity = (bool) info.GetValue("toxicity", typeof(bool));
        this.sniper = (bool) info.GetValue("sniper", typeof(bool));
        this.axeRainer = (bool) info.GetValue("axeRainer", typeof(bool));
        this.thornsEnemies = (int) info.GetValue("thornsEnemies", typeof(int));
        this.energyNetwork = (bool) info.GetValue("energyNetwork", typeof(bool));
        this.elementalist = (bool) info.GetValue("elementalist", typeof(bool));
        this.entangled = (bool) info.GetValue("entangled", typeof(bool));
        this.barbarianRush = (bool) info.GetValue("barbarianRush", typeof(bool));
        this.clustersFire = (int) info.GetValue("clustersFire", typeof(int));
        this.acdcKills = (int) info.GetValue("acdcKills", typeof(int));
        this.paladinHeals = (int) info.GetValue("paladinHeals", typeof(int));
        this.holyChorusCount = (int) info.GetValue("holyChorusCount", typeof(int));
        this.sheepsKilled = (int) info.GetValue("sheepsKilled", typeof(int));
        this.clusterRain = (bool) info.GetValue("clusterRain", typeof(bool));
        this.acdc = (bool) info.GetValue("acdc", typeof(bool));
        this.medic = (bool) info.GetValue("medic", typeof(bool));
        this.holyChorus = (bool) info.GetValue("holyChorus", typeof(bool));
        this.fisherman = (bool) info.GetValue("fisherman", typeof(bool));
        this.sheepKiller = (bool) info.GetValue("sheepKiller", typeof(bool));
        this.greatDefender = (bool) info.GetValue("greatDefender", typeof(bool));
        this.greatDefenderHeroic = (bool) info.GetValue("greatDefenderHeroic", typeof(bool));
        this.greatDefenderIron = (bool) info.GetValue("greatDefenderIron", typeof(bool));
        this.killSarelgaz = (bool) info.GetValue("killSarelgaz", typeof(bool));
        this.freeFredo = (bool) info.GetValue("freeFredo", typeof(bool));
        this.killGulThak = (bool) info.GetValue("killGulThak", typeof(bool));
        this.killTreant = (bool) info.GetValue("killTreant", typeof(bool));
        this.levelHeroMedium = (bool) info.GetValue("levelHeroMedium", typeof(bool));
        this.levelHeroMax = (bool) info.GetValue("levelHeroMax", typeof(bool));
        this.killKingping = (bool) info.GetValue("killKingping", typeof(bool));
        this.acorn = (bool) info.GetValue("acorn", typeof(bool));
        this.mushroom = (bool) info.GetValue("mushroom", typeof(bool));
        this.coolRunning = (bool) info.GetValue("coolRunning", typeof(bool));
        this.coolRunningKilledTrolls = (int) info.GetValue("coolRunningKilledTrolls", typeof(int));
        this.killTrollBoss = (bool) info.GetValue("killTrollBoss", typeof(bool));
    Label_0C66:
        try
        {
            this.dineInHell = (bool) info.GetValue("dineInHell", typeof(bool));
            this.dineInHellCounter = (int) info.GetValue("dineInHellCounter", typeof(int));
            this.armyOfOne = (bool) info.GetValue("armyOfOne", typeof(bool));
            this.armyOfOneCounter = (int) info.GetValue("armyOfOneCounter", typeof(int));
            this.killDemon = (bool) info.GetValue("killDemon", typeof(bool));
            this.killMushroom = (bool) info.GetValue("killMushroom", typeof(bool));
            this.sporeCount = (int) info.GetValue("sporeCount", typeof(int));
            this.spore = (bool) info.GetValue("spore", typeof(bool));
            this.stillCountsAsOne = (bool) info.GetValue("stillCountsAsOne", typeof(bool));
            this.stillCountsAsOneCount = (int) info.GetValue("stillCountsAsOneCount", typeof(int));
            goto Label_0DB7;
        }
        catch (Exception exception1)
        {
        Label_0DAB:
            exception = exception1;
            Debug.Log(exception);
            goto Label_0DB7;
        }
    Label_0DB7:
        this.archersUpLevel = (int) info.GetValue("archersUpLevel", typeof(int));
        this.archersUpSalvage = (bool) info.GetValue("archersUpSalvage", typeof(bool));
        this.archersUpEagleEye = (bool) info.GetValue("archersUpEagleEye", typeof(bool));
        this.archersUpPiercing = (bool) info.GetValue("archersUpPiercing", typeof(bool));
        this.archersUpFarShots = (bool) info.GetValue("archersUpFarShots", typeof(bool));
        this.archersUpPrecision = (bool) info.GetValue("archersUpPrecision", typeof(bool));
        this.barracksUpLevel = (int) info.GetValue("barracksUpLevel", typeof(int));
        this.barracksUpSurvival = (bool) info.GetValue("barracksUpSurvival", typeof(bool));
        this.barracksUpBetterArmor = (bool) info.GetValue("barracksUpBetterArmor", typeof(bool));
        this.barracksUpImprovedDeployment = (bool) info.GetValue("barracksUpImprovedDeployment", typeof(bool));
        this.barracksUpBarbedArmor = (bool) info.GetValue("barracksUpBarbedArmor", typeof(bool));
        this.barracksUpSurvival2 = (bool) info.GetValue("barracksUpSurvival2", typeof(bool));
        this.magesUpLevel = (int) info.GetValue("magesUpLevel", typeof(int));
        this.magesUpSpellReach = (bool) info.GetValue("magesUpSpellReach", typeof(bool));
        this.magesUpArcaneShatter = (bool) info.GetValue("magesUpArcaneShatter", typeof(bool));
        this.magesUpHermeticStudy = (bool) info.GetValue("magesUpHermeticStudy", typeof(bool));
        this.magesUpEmpoweredMagic = (bool) info.GetValue("magesUpEmpoweredMagic", typeof(bool));
        this.magesUpSlowCurse = (bool) info.GetValue("magesUpSlowCurse", typeof(bool));
        this.magesUpArcaneShatterDamage = (int) info.GetValue("magesUpArcaneShatterDamage", typeof(int));
        this.engineersUpLevel = (int) info.GetValue("engineersUpLevel", typeof(int));
        this.engineersUpConcentratedFire = (bool) info.GetValue("engineersUpConcentratedFire", typeof(bool));
        this.engineersUpRangeFinder = (bool) info.GetValue("engineersUpRangeFinder", typeof(bool));
        this.engineersUpFieldLogistics = (bool) info.GetValue("engineersUpFieldLogistics", typeof(bool));
        this.engineersUpIndustrialization = (bool) info.GetValue("engineersUpIndustrialization", typeof(bool));
        this.engineersUpEfficiency = (bool) info.GetValue("engineersUpEfficiency", typeof(bool));
        this.rainUpLevel = (int) info.GetValue("rainUpLevel", typeof(int));
        this.rainUpBlazingSkies = (bool) info.GetValue("rainUpBlazingSkies", typeof(bool));
        this.rainUpScorchedEarth = (bool) info.GetValue("rainUpScorchedEarth", typeof(bool));
        this.rainUpBiggerAndMeaner = (bool) info.GetValue("rainUpBiggerAndMeaner", typeof(bool));
        this.rainUpBlazingEarth = (bool) info.GetValue("rainUpBlazingEarth", typeof(bool));
        this.rainUpCataclysm = (bool) info.GetValue("rainUpCataclysm", typeof(bool));
        this.reinforcementLevel = (int) info.GetValue("reinforcementLevel", typeof(int));
        this.heroesEnabled = (bool) info.GetValue("heroesEnabled", typeof(bool));
        this.selectedHero = (int) info.GetValue("selectedHero", typeof(int));
        this.heroesCost = (int) info.GetValue("heroesCost", typeof(int));
        this.starsTotal = (int) info.GetValue("starsTotal", typeof(int));
        this.starsWon = (int) info.GetValue("starsWon", typeof(int));
        this.starsToSpent = (int) info.GetValue("starsToSpent", typeof(int));
        this.starsSpent = (int) info.GetValue("starsSpent", typeof(int));
        this.challengeTipShowed = (bool) info.GetValue("challengeTipShowed", typeof(bool));
        this.levelSelectHelpShowed = (bool) info.GetValue("levelSelectHelpShowed", typeof(bool));
        this.campaignLevels = (ArrayList) info.GetValue("campaignLevels", typeof(ArrayList));
        this.notificationTowerArchersLevel2 = (bool) info.GetValue("notificationTowerArchersLevel2", typeof(bool));
        this.notificationTowerArchersLevel3 = (bool) info.GetValue("notificationTowerArchersLevel3", typeof(bool));
        this.notificationTowerArchersRanger = (bool) info.GetValue("notificationTowerArchersRanger", typeof(bool));
        this.notificationTowerArchersMusketeer = (bool) info.GetValue("notificationTowerArchersMusketeer", typeof(bool));
        this.notificationTowerSoldiersLevel2 = (bool) info.GetValue("notificationTowerSoldiersLevel2", typeof(bool));
        this.notificationTowerSoldiersLevel3 = (bool) info.GetValue("notificationTowerSoldiersLevel3", typeof(bool));
        this.notificationTowerSoldiersPaladin = (bool) info.GetValue("notificationTowerSoldiersPaladin", typeof(bool));
        this.notificationTowerSoldiersBarbarian = (bool) info.GetValue("notificationTowerSoldiersBarbarian", typeof(bool));
        this.notificationTowerMagesLevel2 = (bool) info.GetValue("notificationTowerMagesLevel2", typeof(bool));
        this.notificationTowerMagesLevel3 = (bool) info.GetValue("notificationTowerMagesLevel3", typeof(bool));
        this.notificationTowerMagesArcane = (bool) info.GetValue("notificationTowerMagesArcane", typeof(bool));
        this.notificationTowerMagesSorcerer = (bool) info.GetValue("notificationTowerMagesSorcerer", typeof(bool));
        this.notificationTowerEngineersLevel2 = (bool) info.GetValue("notificationTowerEngineersLevel2", typeof(bool));
        this.notificationTowerEngineersLevel3 = (bool) info.GetValue("notificationTowerEngineersLevel3", typeof(bool));
        this.notificationTowerEngineersBfg = (bool) info.GetValue("notificationTowerEngineersBfg", typeof(bool));
        this.notificationTowerEngineersTesla = (bool) info.GetValue("notificationTowerEngineersTesla", typeof(bool));
        this.notificationEnemyGoblin = (bool) info.GetValue("notificationEnemyGoblin", typeof(bool));
        this.notificationEnemyFatOrc = (bool) info.GetValue("notificationEnemyFatOrc", typeof(bool));
        this.notificationEnemyShaman = (bool) info.GetValue("notificationEnemyShaman", typeof(bool));
        this.notificationEnemyOgre = (bool) info.GetValue("notificationEnemyOgre", typeof(bool));
        this.notificationEnemyBandit = (bool) info.GetValue("notificationEnemyBandit", typeof(bool));
        this.notificationEnemyBrigand = (bool) info.GetValue("notificationEnemyBrigand", typeof(bool));
        this.notificationEnemyMarauder = (bool) info.GetValue("notificationEnemyMarauder", typeof(bool));
        this.notificationEnemySpider = (bool) info.GetValue("notificationEnemySpider", typeof(bool));
        this.notificationEnemySpiderSmall = (bool) info.GetValue("notificationEnemySpiderSmall", typeof(bool));
        this.notificationEnemyGargoyle = (bool) info.GetValue("notificationEnemyGargoyle", typeof(bool));
        this.notificationEnemyShadowArcher = (bool) info.GetValue("notificationEnemyShadowArcher", typeof(bool));
        this.notificationEnemyDarkKnight = (bool) info.GetValue("notificationEnemyDarkKnight", typeof(bool));
        this.notificationEnemySmallWolf = (bool) info.GetValue("notificationEnemySmallWolf", typeof(bool));
        this.notificationEnemyWolf = (bool) info.GetValue("notificationEnemyWolf", typeof(bool));
        this.notificationEnemyGolemHead = (bool) info.GetValue("notificationEnemyGolemHead", typeof(bool));
        this.notificationEnemyWhiteWolf = (bool) info.GetValue("notificationEnemyWhiteWolf", typeof(bool));
        this.notificationEnemyTroll = (bool) info.GetValue("notificationEnemyTroll", typeof(bool));
        this.notificationEnemyTrollAxeThrower = (bool) info.GetValue("notificationEnemyTrollAxeThrower", typeof(bool));
        this.notificationEnemyTrollChieftain = (bool) info.GetValue("notificationEnemyTrollChieftain", typeof(bool));
        this.notificationEnemyYeti = (bool) info.GetValue("notificationEnemyYeti", typeof(bool));
        this.notificationEnemyRocketeer = (bool) info.GetValue("notificationEnemyRocketeer", typeof(bool));
        this.notificationEnemyDarkSlayer = (bool) info.GetValue("notificationEnemyDarkSlayer", typeof(bool));
        this.notificationEnemyDemon = (bool) info.GetValue("notificationEnemyDemon", typeof(bool));
        this.notificationEnemyDemonMage = (bool) info.GetValue("notificationEnemyDemonMage", typeof(bool));
        this.notificationEnemyDemonWolf = (bool) info.GetValue("notificationEnemyDemonWolf", typeof(bool));
        this.notificationEnemyDemonImp = (bool) info.GetValue("notificationEnemyDemonImp", typeof(bool));
        this.notificationEnemyNecromancer = (bool) info.GetValue("notificationEnemyNecromancer", typeof(bool));
        this.notificationEnemySkeletor = (bool) info.GetValue("notificationEnemySkeletor", typeof(bool));
        this.notificationEnemySkeletorBig = (bool) info.GetValue("notificationEnemySkeletorBig", typeof(bool));
        this.notificationEnemyLavaElemental = (bool) info.GetValue("notificationEnemyLavaElemental", typeof(bool));
        this.notificationEnemyJuggernaut = (bool) info.GetValue("notificationEnemyJuggernaut", typeof(bool));
        this.notificationEnemyYetiBoss = (bool) info.GetValue("notificationEnemyYetiBoss", typeof(bool));
        this.notificationEnemyVeznan = (bool) info.GetValue("notificationEnemyVeznan", typeof(bool));
        this.notificationEnemySarelgaz = (bool) info.GetValue("notificationEnemySarelgaz", typeof(bool));
        this.notificationEnemySarelgazSmall = (bool) info.GetValue("notificationEnemySarelgazSmall", typeof(bool));
        this.notificationEnemyGoblinZapper = (bool) info.GetValue("notificationEnemyGoblinZapper", typeof(bool));
        this.notificationEnemyOrcRider = (bool) info.GetValue("notificationEnemyOrcRider", typeof(bool));
        this.notificationEnemyOrcArmored = (bool) info.GetValue("notificationEnemyOrcArmored", typeof(bool));
        this.notificationEnemyForestTroll = (bool) info.GetValue("notificationEnemyForestTroll", typeof(bool));
        this.notificationEnemyGulThak = (bool) info.GetValue("notificationEnemyGulThak", typeof(bool));
        this.notificationEnemyZombie = (bool) info.GetValue("notificationEnemyZombie", typeof(bool));
        this.notificationEnemyRottenSpider = (bool) info.GetValue("notificationEnemyRottenSpider", typeof(bool));
        this.notificationEnemyRottenTree = (bool) info.GetValue("notificationEnemyRottenTree", typeof(bool));
        this.notificationEnemySwampThing = (bool) info.GetValue("notificationEnemySwampThing", typeof(bool));
        this.notificationEnemyBossTreant = (bool) info.GetValue("notificationEnemyBossTreant", typeof(bool));
        this.notificationTipHeroes = (bool) info.GetValue("notificationTipHeroes", typeof(bool));
        this.notificationEnemyRaider = (bool) info.GetValue("notificationEnemyRaider", typeof(bool));
        this.notificationEnemyPillager = (bool) info.GetValue("notificationEnemyPillager", typeof(bool));
        this.notificationEnemyBossBandit = (bool) info.GetValue("notificationEnemyBossBandit", typeof(bool));
        this.notificationEnemyTrollSkater = (bool) info.GetValue("notificationEnemyTrollSkater", typeof(bool));
        this.notificationEnemyTrollBrute = (bool) info.GetValue("notificationEnemyTrollBrute", typeof(bool));
    Label_1B57:
        try
        {
            this.soundFxVolume = (float) info.GetValue("soundFxVolume", typeof(float));
            this.soundMusicVolume = (float) info.GetValue("soundMusicVolume", typeof(float));
            goto Label_1BC2;
        }
        catch (SerializationException exception5)
        {
        Label_1B9C:
            exception2 = exception5;
            Debug.Log("No previous sound settings detected on save, setting defaults");
            this.soundFxVolume = 1f;
            this.soundMusicVolume = 0.7f;
            goto Label_1BC2;
        }
    Label_1BC2:
        try
        {
            this.notificationEnemyTrollBoss = (bool) info.GetValue("notificationEnemyTrollBoss", typeof(bool));
            goto Label_1BFD;
        }
        catch (SerializationException exception6)
        {
        Label_1BE7:
            exception3 = exception6;
            Debug.Log("Error loading save slot: " + exception3);
            goto Label_1BFD;
        }
    Label_1BFD:
        try
        {
            this.notificationEnemyCerberus = (bool) info.GetValue("notificationEnemyCerberus", typeof(bool));
            this.notificationEnemyLegion = (bool) info.GetValue("notificationEnemyLegion", typeof(bool));
            this.notificationEnemyFlareon = (bool) info.GetValue("notificationEnemyFlareon", typeof(bool));
            this.notificationEnemyGulaemon = (bool) info.GetValue("notificationEnemyGulaemon", typeof(bool));
            this.notificationEnemyRottenLesser = (bool) info.GetValue("notificationEnemyRottenLesser", typeof(bool));
            this.notificationEnemyBossDemonMoloch = (bool) info.GetValue("notificationEnemyBossDemonMoloch", typeof(bool));
            this.notificationEnemyBossMyconid = (bool) info.GetValue("notificationEnemyBossMyconid", typeof(bool));
            goto Label_1CF8;
        }
        catch (SerializationException exception7)
        {
        Label_1CE2:
            exception4 = exception7;
            Debug.Log("Error loading save slot: " + exception4);
            goto Label_1CF8;
        }
    Label_1CF8:
        return;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("towerBuilded", (int) this.towerBuilded, typeof(int));
        info.AddValue("easyTowerBuilder", (bool) this.easyTowerBuilder, typeof(bool));
        info.AddValue("mediumTowerBuilder", (bool) this.mediumTowerBuilder, typeof(bool));
        info.AddValue("hardTowerBuilder", (bool) this.hardTowerBuilder, typeof(bool));
        info.AddValue("earn15Stars", (bool) this.earn15Stars, typeof(bool));
        info.AddValue("earn30Stars", (bool) this.earn30Stars, typeof(bool));
        info.AddValue("earn45Stars", (bool) this.earn45Stars, typeof(bool));
        info.AddValue("whatsThat", (bool) this.whatsThat, typeof(bool));
        info.AddValue("notificationEnemy", (int) this.notificationEnemy, typeof(int));
        info.AddValue("earlyWavesCalled", (int) this.earlyWavesCalled, typeof(int));
        info.AddValue("daring", (bool) this.daring, typeof(bool));
        info.AddValue("towerUpgradeLevel3", (bool) this.towerUpgradeLevel3, typeof(bool));
        info.AddValue("magesTowerUpgradeLevel3", (int) this.magesTowerUpgradeLevel3, typeof(int));
        info.AddValue("archersTowerUpgradeLevel3", (int) this.archersTowerUpgradeLevel3, typeof(int));
        info.AddValue("soldiersTowerUpgradeLevel3", (int) this.soldiersTowerUpgradeLevel3, typeof(int));
        info.AddValue("engineersTowerUpgradeLevel3", (int) this.engineersTowerUpgradeLevel3, typeof(int));
        info.AddValue("killedEnemies", (int) this.killedEnemies, typeof(int));
        info.AddValue("firstBlood", (bool) this.firstBlood, typeof(bool));
        info.AddValue("bloodlust", (bool) this.bloodlust, typeof(bool));
        info.AddValue("mageBeamMeUp", (bool) this.mageBeamMeUp, typeof(bool));
        info.AddValue("mageBeamMeUpEnemies", (int) this.mageBeamMeUpEnemies, typeof(int));
        info.AddValue("armaggedon", (bool) this.armaggedon, typeof(bool));
        info.AddValue("fireballKills", (int) this.fireballKills, typeof(int));
        info.AddValue("deathFromAbove", (bool) this.deathFromAbove, typeof(bool));
        info.AddValue("killMountainBoss", (bool) this.killMountainBoss, typeof(bool));
        info.AddValue("killJuggernaut", (bool) this.killJuggernaut, typeof(bool));
        info.AddValue("slayer", (bool) this.slayer, typeof(bool));
        info.AddValue("specialization", (bool) this.specialization, typeof(bool));
        info.AddValue("buildRangers", (int) this.buildRangers, typeof(int));
        info.AddValue("buildMusketeers", (int) this.buildMusketeers, typeof(int));
        info.AddValue("buildPaladins", (int) this.buildPaladins, typeof(int));
        info.AddValue("buildBarbarians", (int) this.buildBarbarians, typeof(int));
        info.AddValue("buildArcanes", (int) this.buildArcanes, typeof(int));
        info.AddValue("buildSorcerers", (int) this.buildSorcerers, typeof(int));
        info.AddValue("buildBfg", (int) this.buildBfg, typeof(int));
        info.AddValue("buildTesla", (int) this.buildTesla, typeof(int));
        info.AddValue("rallyChanges", (int) this.rallyChanges, typeof(int));
        info.AddValue("tactician", (bool) this.tactician, typeof(bool));
        info.AddValue("killEndBoss", (bool) this.killEndBoss, typeof(bool));
        info.AddValue("soldiersTrained", (int) this.soldiersTrained, typeof(int));
        info.AddValue("soldiersKilled", (int) this.soldiersKilled, typeof(int));
        info.AddValue("soldiersRegeneration", (int) this.soldiersRegeneration, typeof(int));
        info.AddValue("multiKill", (bool) this.multiKill, typeof(bool));
        info.AddValue("giJoe", (bool) this.giJoe, typeof(bool));
        info.AddValue("dieHard", (bool) this.dieHard, typeof(bool));
        info.AddValue("cannonFodder", (bool) this.cannonFodder, typeof(bool));
        info.AddValue("fearless", (bool) this.fearless, typeof(bool));
        info.AddValue("sellTowers", (int) this.sellTowers, typeof(int));
        info.AddValue("sunrayShots", (int) this.sunrayShots, typeof(int));
        info.AddValue("realEstate", (bool) this.realEstate, typeof(bool));
        info.AddValue("indecisive", (bool) this.indecisive, typeof(bool));
        info.AddValue("impatient", (bool) this.impatient, typeof(bool));
        info.AddValue("maxElves", (bool) this.maxElves, typeof(bool));
        info.AddValue("imperialSaviour", (bool) this.imperialSaviour, typeof(bool));
        info.AddValue("henderson", (bool) this.henderson, typeof(bool));
        info.AddValue("sunburner", (bool) this.sunburner, typeof(bool));
        info.AddValue("desintegrateKills", (int) this.desintegrateKills, typeof(int));
        info.AddValue("polymorphKills", (int) this.polymorphKills, typeof(int));
        info.AddValue("missilesFire", (int) this.missilesFire, typeof(int));
        info.AddValue("poisonKills", (int) this.poisonKills, typeof(int));
        info.AddValue("sniperKills", (int) this.sniperKills, typeof(int));
        info.AddValue("axesFire", (int) this.axesFire, typeof(int));
        info.AddValue("dustToDust", (bool) this.dustToDust, typeof(bool));
        info.AddValue("shepard", (bool) this.shepard, typeof(bool));
        info.AddValue("rocketeer", (bool) this.rocketeer, typeof(bool));
        info.AddValue("toxicity", (bool) this.toxicity, typeof(bool));
        info.AddValue("sniper", (bool) this.sniper, typeof(bool));
        info.AddValue("axeRainer", (bool) this.axeRainer, typeof(bool));
        info.AddValue("thornsEnemies", (int) this.thornsEnemies, typeof(int));
        info.AddValue("energyNetwork", (bool) this.energyNetwork, typeof(bool));
        info.AddValue("elementalist", (bool) this.elementalist, typeof(bool));
        info.AddValue("entangled", (bool) this.entangled, typeof(bool));
        info.AddValue("barbarianRush", (bool) this.barbarianRush, typeof(bool));
        info.AddValue("clustersFire", (int) this.clustersFire, typeof(int));
        info.AddValue("acdcKills", (int) this.acdcKills, typeof(int));
        info.AddValue("paladinHeals", (int) this.paladinHeals, typeof(int));
        info.AddValue("holyChorusCount", (int) this.holyChorusCount, typeof(int));
        info.AddValue("sheepsKilled", (int) this.sheepsKilled, typeof(int));
        info.AddValue("clusterRain", (bool) this.clusterRain, typeof(bool));
        info.AddValue("acdc", (bool) this.acdc, typeof(bool));
        info.AddValue("medic", (bool) this.medic, typeof(bool));
        info.AddValue("holyChorus", (bool) this.holyChorus, typeof(bool));
        info.AddValue("fisherman", (bool) this.fisherman, typeof(bool));
        info.AddValue("sheepKiller", (bool) this.sheepKiller, typeof(bool));
        info.AddValue("greatDefender", (bool) this.greatDefender, typeof(bool));
        info.AddValue("greatDefenderHeroic", (bool) this.greatDefenderHeroic, typeof(bool));
        info.AddValue("greatDefenderIron", (bool) this.greatDefenderIron, typeof(bool));
        info.AddValue("killSarelgaz", (bool) this.killSarelgaz, typeof(bool));
        info.AddValue("freeFredo", (bool) this.freeFredo, typeof(bool));
        info.AddValue("killGulThak", (bool) this.killGulThak, typeof(bool));
        info.AddValue("killTreant", (bool) this.killTreant, typeof(bool));
        info.AddValue("levelHeroMedium", (bool) this.levelHeroMedium, typeof(bool));
        info.AddValue("levelHeroMax", (bool) this.levelHeroMax, typeof(bool));
        info.AddValue("killKingping", (bool) this.killKingping, typeof(bool));
        info.AddValue("acorn", (bool) this.acorn, typeof(bool));
        info.AddValue("mushroom", (bool) this.mushroom, typeof(bool));
        info.AddValue("coolRunning", (bool) this.coolRunning, typeof(bool));
        info.AddValue("coolRunningKilledTrolls", (int) this.coolRunningKilledTrolls, typeof(int));
        info.AddValue("killTrollBoss", (bool) this.killTrollBoss, typeof(bool));
        info.AddValue("dineInHell", (bool) this.dineInHell, typeof(bool));
        info.AddValue("dineInHellCounter", (int) this.dineInHellCounter, typeof(int));
        info.AddValue("armyOfOne", (bool) this.armyOfOne, typeof(bool));
        info.AddValue("armyOfOneCounter", (int) this.armyOfOneCounter, typeof(int));
        info.AddValue("killDemon", (bool) this.killDemon, typeof(bool));
        info.AddValue("killMushroom", (bool) this.killMushroom, typeof(bool));
        info.AddValue("sporeCount", (int) this.sporeCount, typeof(int));
        info.AddValue("spore", (bool) this.spore, typeof(bool));
        info.AddValue("stillCountsAsOne", (bool) this.stillCountsAsOne, typeof(bool));
        info.AddValue("stillCountsAsOneCount", (int) this.stillCountsAsOneCount, typeof(int));
        info.AddValue("archersUpLevel", (int) this.archersUpLevel, typeof(int));
        info.AddValue("archersUpSalvage", (bool) this.archersUpSalvage, typeof(bool));
        info.AddValue("archersUpEagleEye", (bool) this.archersUpEagleEye, typeof(bool));
        info.AddValue("archersUpPiercing", (bool) this.archersUpPiercing, typeof(bool));
        info.AddValue("archersUpFarShots", (bool) this.archersUpFarShots, typeof(bool));
        info.AddValue("archersUpPrecision", (bool) this.archersUpPrecision, typeof(bool));
        info.AddValue("barracksUpLevel", (int) this.barracksUpLevel, typeof(int));
        info.AddValue("barracksUpSurvival", (bool) this.barracksUpSurvival, typeof(bool));
        info.AddValue("barracksUpBetterArmor", (bool) this.barracksUpBetterArmor, typeof(bool));
        info.AddValue("barracksUpImprovedDeployment", (bool) this.barracksUpImprovedDeployment, typeof(bool));
        info.AddValue("barracksUpBarbedArmor", (bool) this.barracksUpBarbedArmor, typeof(bool));
        info.AddValue("barracksUpSurvival2", (bool) this.barracksUpSurvival2, typeof(bool));
        info.AddValue("magesUpLevel", (int) this.magesUpLevel, typeof(int));
        info.AddValue("magesUpSpellReach", (bool) this.magesUpSpellReach, typeof(bool));
        info.AddValue("magesUpArcaneShatter", (bool) this.magesUpArcaneShatter, typeof(bool));
        info.AddValue("magesUpHermeticStudy", (bool) this.magesUpHermeticStudy, typeof(bool));
        info.AddValue("magesUpEmpoweredMagic", (bool) this.magesUpEmpoweredMagic, typeof(bool));
        info.AddValue("magesUpSlowCurse", (bool) this.magesUpSlowCurse, typeof(bool));
        info.AddValue("magesUpArcaneShatterDamage", (int) this.magesUpArcaneShatterDamage, typeof(int));
        info.AddValue("engineersUpLevel", (int) this.engineersUpLevel, typeof(int));
        info.AddValue("engineersUpConcentratedFire", (bool) this.engineersUpConcentratedFire, typeof(bool));
        info.AddValue("engineersUpRangeFinder", (bool) this.engineersUpRangeFinder, typeof(bool));
        info.AddValue("engineersUpFieldLogistics", (bool) this.engineersUpFieldLogistics, typeof(bool));
        info.AddValue("engineersUpIndustrialization", (bool) this.engineersUpIndustrialization, typeof(bool));
        info.AddValue("engineersUpEfficiency", (bool) this.engineersUpEfficiency, typeof(bool));
        info.AddValue("rainUpLevel", (int) this.rainUpLevel, typeof(int));
        info.AddValue("rainUpBlazingSkies", (bool) this.rainUpBlazingSkies, typeof(bool));
        info.AddValue("rainUpScorchedEarth", (bool) this.rainUpScorchedEarth, typeof(bool));
        info.AddValue("rainUpBiggerAndMeaner", (bool) this.rainUpBiggerAndMeaner, typeof(bool));
        info.AddValue("rainUpBlazingEarth", (bool) this.rainUpBlazingEarth, typeof(bool));
        info.AddValue("rainUpCataclysm", (bool) this.rainUpCataclysm, typeof(bool));
        info.AddValue("reinforcementLevel", (int) this.reinforcementLevel, typeof(int));
        info.AddValue("heroesEnabled", (bool) this.heroesEnabled, typeof(bool));
        info.AddValue("selectedHero", (int) this.selectedHero, typeof(int));
        info.AddValue("heroesCost", (int) this.heroesCost, typeof(int));
        info.AddValue("starsTotal", (int) this.starsTotal, typeof(int));
        info.AddValue("starsWon", (int) this.starsWon, typeof(int));
        info.AddValue("starsToSpent", (int) this.starsToSpent, typeof(int));
        info.AddValue("starsSpent", (int) this.starsSpent, typeof(int));
        info.AddValue("challengeTipShowed", (bool) this.challengeTipShowed, typeof(bool));
        info.AddValue("levelSelectHelpShowed", (bool) this.levelSelectHelpShowed, typeof(bool));
        info.AddValue("campaignLevels", this.campaignLevels, typeof(ArrayList));
        info.AddValue("notificationTowerArchersLevel2", (bool) this.notificationTowerArchersLevel2, typeof(bool));
        info.AddValue("notificationTowerArchersLevel3", (bool) this.notificationTowerArchersLevel3, typeof(bool));
        info.AddValue("notificationTowerArchersRanger", (bool) this.notificationTowerArchersRanger, typeof(bool));
        info.AddValue("notificationTowerArchersMusketeer", (bool) this.notificationTowerArchersMusketeer, typeof(bool));
        info.AddValue("notificationTowerSoldiersLevel2", (bool) this.notificationTowerSoldiersLevel2, typeof(bool));
        info.AddValue("notificationTowerSoldiersLevel3", (bool) this.notificationTowerSoldiersLevel3, typeof(bool));
        info.AddValue("notificationTowerSoldiersPaladin", (bool) this.notificationTowerSoldiersPaladin, typeof(bool));
        info.AddValue("notificationTowerSoldiersBarbarian", (bool) this.notificationTowerSoldiersBarbarian, typeof(bool));
        info.AddValue("notificationTowerMagesLevel2", (bool) this.notificationTowerMagesLevel2, typeof(bool));
        info.AddValue("notificationTowerMagesLevel3", (bool) this.notificationTowerMagesLevel3, typeof(bool));
        info.AddValue("notificationTowerMagesArcane", (bool) this.notificationTowerMagesArcane, typeof(bool));
        info.AddValue("notificationTowerMagesSorcerer", (bool) this.notificationTowerMagesSorcerer, typeof(bool));
        info.AddValue("notificationTowerEngineersLevel2", (bool) this.notificationTowerEngineersLevel2, typeof(bool));
        info.AddValue("notificationTowerEngineersLevel3", (bool) this.notificationTowerEngineersLevel3, typeof(bool));
        info.AddValue("notificationTowerEngineersBfg", (bool) this.notificationTowerEngineersBfg, typeof(bool));
        info.AddValue("notificationTowerEngineersTesla", (bool) this.notificationTowerEngineersTesla, typeof(bool));
        info.AddValue("notificationEnemyGoblin", (bool) this.notificationEnemyGoblin, typeof(bool));
        info.AddValue("notificationEnemyFatOrc", (bool) this.notificationEnemyFatOrc, typeof(bool));
        info.AddValue("notificationEnemyShaman", (bool) this.notificationEnemyShaman, typeof(bool));
        info.AddValue("notificationEnemyOgre", (bool) this.notificationEnemyOgre, typeof(bool));
        info.AddValue("notificationEnemyBandit", (bool) this.notificationEnemyBandit, typeof(bool));
        info.AddValue("notificationEnemyBrigand", (bool) this.notificationEnemyBrigand, typeof(bool));
        info.AddValue("notificationEnemyMarauder", (bool) this.notificationEnemyMarauder, typeof(bool));
        info.AddValue("notificationEnemySpider", (bool) this.notificationEnemySpider, typeof(bool));
        info.AddValue("notificationEnemySpiderSmall", (bool) this.notificationEnemySpiderSmall, typeof(bool));
        info.AddValue("notificationEnemyGargoyle", (bool) this.notificationEnemyGargoyle, typeof(bool));
        info.AddValue("notificationEnemyShadowArcher", (bool) this.notificationEnemyShadowArcher, typeof(bool));
        info.AddValue("notificationEnemyDarkKnight", (bool) this.notificationEnemyDarkKnight, typeof(bool));
        info.AddValue("notificationEnemySmallWolf", (bool) this.notificationEnemySmallWolf, typeof(bool));
        info.AddValue("notificationEnemyWolf", (bool) this.notificationEnemyWolf, typeof(bool));
        info.AddValue("notificationEnemyGolemHead", (bool) this.notificationEnemyGolemHead, typeof(bool));
        info.AddValue("notificationEnemyWhiteWolf", (bool) this.notificationEnemyWhiteWolf, typeof(bool));
        info.AddValue("notificationEnemyTroll", (bool) this.notificationEnemyTroll, typeof(bool));
        info.AddValue("notificationEnemyTrollAxeThrower", (bool) this.notificationEnemyTrollAxeThrower, typeof(bool));
        info.AddValue("notificationEnemyTrollChieftain", (bool) this.notificationEnemyTrollChieftain, typeof(bool));
        info.AddValue("notificationEnemyYeti", (bool) this.notificationEnemyYeti, typeof(bool));
        info.AddValue("notificationEnemyRocketeer", (bool) this.notificationEnemyRocketeer, typeof(bool));
        info.AddValue("notificationEnemyDarkSlayer", (bool) this.notificationEnemyDarkSlayer, typeof(bool));
        info.AddValue("notificationEnemyDemon", (bool) this.notificationEnemyDemon, typeof(bool));
        info.AddValue("notificationEnemyDemonMage", (bool) this.notificationEnemyDemonMage, typeof(bool));
        info.AddValue("notificationEnemyDemonWolf", (bool) this.notificationEnemyDemonWolf, typeof(bool));
        info.AddValue("notificationEnemyDemonImp", (bool) this.notificationEnemyDemonImp, typeof(bool));
        info.AddValue("notificationEnemyNecromancer", (bool) this.notificationEnemyNecromancer, typeof(bool));
        info.AddValue("notificationEnemySkeletor", (bool) this.notificationEnemySkeletor, typeof(bool));
        info.AddValue("notificationEnemySkeletorBig", (bool) this.notificationEnemySkeletorBig, typeof(bool));
        info.AddValue("notificationEnemyLavaElemental", (bool) this.notificationEnemyLavaElemental, typeof(bool));
        info.AddValue("notificationEnemyJuggernaut", (bool) this.notificationEnemyJuggernaut, typeof(bool));
        info.AddValue("notificationEnemyYetiBoss", (bool) this.notificationEnemyYetiBoss, typeof(bool));
        info.AddValue("notificationEnemyVeznan", (bool) this.notificationEnemyVeznan, typeof(bool));
        info.AddValue("notificationEnemySarelgaz", (bool) this.notificationEnemySarelgaz, typeof(bool));
        info.AddValue("notificationEnemySarelgazSmall", (bool) this.notificationEnemySarelgazSmall, typeof(bool));
        info.AddValue("notificationEnemyGoblinZapper", (bool) this.notificationEnemyGoblinZapper, typeof(bool));
        info.AddValue("notificationEnemyOrcRider", (bool) this.notificationEnemyOrcRider, typeof(bool));
        info.AddValue("notificationEnemyOrcArmored", (bool) this.notificationEnemyOrcArmored, typeof(bool));
        info.AddValue("notificationEnemyForestTroll", (bool) this.notificationEnemyForestTroll, typeof(bool));
        info.AddValue("notificationEnemyGulThak", (bool) this.notificationEnemyGulThak, typeof(bool));
        info.AddValue("notificationEnemyZombie", (bool) this.notificationEnemyZombie, typeof(bool));
        info.AddValue("notificationEnemyRottenSpider", (bool) this.notificationEnemyRottenSpider, typeof(bool));
        info.AddValue("notificationEnemyRottenTree", (bool) this.notificationEnemyRottenTree, typeof(bool));
        info.AddValue("notificationEnemySwampThing", (bool) this.notificationEnemySwampThing, typeof(bool));
        info.AddValue("notificationEnemyBossTreant", (bool) this.notificationEnemyBossTreant, typeof(bool));
        info.AddValue("notificationTipHeroes", (bool) this.notificationTipHeroes, typeof(bool));
        info.AddValue("notificationEnemyRaider", (bool) this.notificationEnemyRaider, typeof(bool));
        info.AddValue("notificationEnemyPillager", (bool) this.notificationEnemyPillager, typeof(bool));
        info.AddValue("notificationEnemyBossBandit", (bool) this.notificationEnemyBossBandit, typeof(bool));
        info.AddValue("notificationEnemyTrollSkater", (bool) this.notificationEnemyTrollSkater, typeof(bool));
        info.AddValue("notificationEnemyTrollBrute", (bool) this.notificationEnemyTrollBrute, typeof(bool));
        info.AddValue("notificationEnemyTrollBoss", (bool) this.notificationEnemyTrollBoss, typeof(bool));
        info.AddValue("notificationEnemyCerberus", (bool) this.notificationEnemyCerberus, typeof(bool));
        info.AddValue("notificationEnemyLegion", (bool) this.notificationEnemyLegion, typeof(bool));
        info.AddValue("notificationEnemyFlareon", (bool) this.notificationEnemyFlareon, typeof(bool));
        info.AddValue("notificationEnemyGulaemon", (bool) this.notificationEnemyGulaemon, typeof(bool));
        info.AddValue("notificationEnemyRottenLesser", (bool) this.notificationEnemyRottenLesser, typeof(bool));
        info.AddValue("notificationEnemyBossDemonMoloch", (bool) this.notificationEnemyBossDemonMoloch, typeof(bool));
        info.AddValue("notificationEnemyBossMyconid", (bool) this.notificationEnemyBossMyconid, typeof(bool));
        info.AddValue("soundFxVolume", (float) this.soundFxVolume, typeof(float));
        info.AddValue("soundMusicVolume", (float) this.soundMusicVolume, typeof(float));
        return;
    }

    public int GetTotalHeroicWins()
    {
        int num;
        int num2;
        num = 0;
        num2 = 0;
        goto Label_0032;
    Label_0009:
        num += (((StageData) this.campaignLevels[num2]).HeroicModeWin == null) ? 0 : 1;
        num2 += 1;
    Label_0032:
        if (num2 < this.campaignLevels.Count)
        {
            goto Label_0009;
        }
        return num;
    }

    public int GetTotalIronWins()
    {
        int num;
        int num2;
        num = 0;
        num2 = 0;
        goto Label_0032;
    Label_0009:
        num += (((StageData) this.campaignLevels[num2]).IronModeWin == null) ? 0 : 1;
        num2 += 1;
    Label_0032:
        if (num2 < this.campaignLevels.Count)
        {
            goto Label_0009;
        }
        return num;
    }

    public void LoadAchievements()
    {
        this.towerBuilded = GameAchievements.TowerBuilded;
        this.easyTowerBuilder = GameAchievements.EasyTowerBuilder;
        this.mediumTowerBuilder = GameAchievements.MediumTowerBuilder;
        this.hardTowerBuilder = GameAchievements.HardTowerBuilder;
        this.earn15Stars = GameAchievements.Earn15Stars;
        this.earn30Stars = GameAchievements.Earn30Stars;
        this.earn45Stars = GameAchievements.Earn45Stars;
        this.whatsThat = GameAchievements.WhatsThat;
        this.notificationEnemy = GameAchievements.NotificationEnemy;
        this.earlyWavesCalled = GameAchievements.EarlyWavesCalled;
        this.daring = GameAchievements.Daring;
        this.towerUpgradeLevel3 = GameAchievements.TowerUpgradeLevel3;
        this.magesTowerUpgradeLevel3 = GameAchievements.MagesTowerUpgradeLevel3;
        this.archersTowerUpgradeLevel3 = GameAchievements.ArchersTowerUpgradeLevel3;
        this.soldiersTowerUpgradeLevel3 = GameAchievements.SoldiersTowerUpgradeLevel3;
        this.engineersTowerUpgradeLevel3 = GameAchievements.EngineersTowerUpgradeLevel3;
        this.killedEnemies = GameAchievements.KilledEnemies;
        this.firstBlood = GameAchievements.FirstBlood;
        this.bloodlust = GameAchievements.Bloodlust;
        this.mageBeamMeUp = GameAchievements.BeamMeUp;
        this.mageBeamMeUpEnemies = GameAchievements.MageBeamMeUpEnemies;
        this.armaggedon = GameAchievements.Armaggedon;
        this.fireballKills = GameAchievements.FireballKills;
        this.deathFromAbove = GameAchievements.DeathFromAbove;
        this.killMountainBoss = GameAchievements.KillMountainBoss;
        this.killJuggernaut = GameAchievements.KillJuggernaut;
        this.slayer = GameAchievements.Slayer;
        this.specialization = GameAchievements.Specialization;
        this.buildRangers = GameAchievements.BuildRangers;
        this.buildMusketeers = GameAchievements.BuildMusketeers;
        this.buildPaladins = GameAchievements.BuildPaladins;
        this.buildBarbarians = GameAchievements.BuildBarbarians;
        this.buildArcanes = GameAchievements.BuildArcanes;
        this.buildSorcerers = GameAchievements.BuildSorcerers;
        this.buildBfg = GameAchievements.BuildBfg;
        this.buildTesla = GameAchievements.BuildTesla;
        this.rallyChanges = GameAchievements.RallyChanges;
        this.tactician = GameAchievements.Tactician;
        this.killEndBoss = GameAchievements.KillEndBoss;
        this.soldiersTrained = GameAchievements.SoldiersTrained;
        this.soldiersKilled = GameAchievements.SoldiersKilled;
        this.soldiersRegeneration = GameAchievements.SoldiersRegeneration;
        this.multiKill = GameAchievements.MultiKill;
        this.giJoe = GameAchievements.GiJoe;
        this.dieHard = GameAchievements.DieHard;
        this.cannonFodder = GameAchievements.CannonFodder;
        this.fearless = GameAchievements.Fearless;
        this.sellTowers = GameAchievements.SellTowers;
        this.sunrayShots = GameAchievements.SunrayShots;
        this.realEstate = GameAchievements.RealEstate;
        this.indecisive = GameAchievements.Indecisive;
        this.impatient = GameAchievements.Impatient;
        this.maxElves = GameAchievements.MaxElves;
        this.imperialSaviour = GameAchievements.ImperialSaviour;
        this.henderson = GameAchievements.Henderson;
        this.sunburner = GameAchievements.Sunburner;
        this.desintegrateKills = GameAchievements.DesintegrateKills;
        this.polymorphKills = GameAchievements.PolymorphKills;
        this.missilesFire = GameAchievements.MissilesFire;
        this.poisonKills = GameAchievements.PoisonKills;
        this.sniperKills = GameAchievements.SniperKills;
        this.axesFire = GameAchievements.AxesFire;
        this.dustToDust = GameAchievements.DustToDust;
        this.shepard = GameAchievements.Shepard;
        this.rocketeer = GameAchievements.Rocketeer;
        this.toxicity = GameAchievements.Toxicity;
        this.sniper = GameAchievements.Sniper;
        this.axeRainer = GameAchievements.AxeRainer;
        this.thornsEnemies = GameAchievements.ThornsEnemies;
        this.energyNetwork = GameAchievements.EnergyNetwork;
        this.elementalist = GameAchievements.Elementalist;
        this.entangled = GameAchievements.Entangled;
        this.barbarianRush = GameAchievements.BarbarianRush;
        this.clustersFire = GameAchievements.ClustersFire;
        this.acdcKills = GameAchievements.AcdcKills;
        this.paladinHeals = GameAchievements.PaladinHeals;
        this.holyChorusCount = GameAchievements.HolyChorusCount;
        this.sheepsKilled = GameAchievements.SheepsKilled;
        this.clusterRain = GameAchievements.ClusterRain;
        this.acdc = GameAchievements.ACDC;
        this.medic = GameAchievements.Medic;
        this.holyChorus = GameAchievements.HolyChorus;
        this.fisherman = GameAchievements.Fisherman;
        this.sheepKiller = GameAchievements.SheepKiller;
        this.greatDefender = GameAchievements.GreatDefender;
        this.greatDefenderHeroic = GameAchievements.GreatDefenderHeroic;
        this.greatDefenderIron = GameAchievements.GreatDefenderIron;
        this.killSarelgaz = GameAchievements.KillSarelgaz;
        this.freeFredo = GameAchievements.FreeFredo;
        this.killGulThak = GameAchievements.KillGulthak;
        this.killTreant = GameAchievements.KillTreant;
        this.levelHeroMedium = GameAchievements.LevelHeroMedium;
        this.levelHeroMax = GameAchievements.LevelHeroMax;
        this.killKingping = GameAchievements.KillKingpin;
        this.acorn = GameAchievements.Acorn;
        this.mushroom = GameAchievements.Mushroom;
        this.coolRunning = GameAchievements.CoolRunning;
        this.coolRunningKilledTrolls = GameAchievements.CoolRunningKilledTrolls;
        this.killTrollBoss = GameAchievements.KillTrollBoss;
        this.dineInHell = GameAchievements.DineInHell;
        this.dineInHellCounter = GameAchievements.DineInHellCounter;
        this.armyOfOne = GameAchievements.ArmyOfOne;
        this.armyOfOneCounter = GameAchievements.ArmyOfOneCounter;
        this.killDemon = GameAchievements.KillDemon;
        this.killMushroom = GameAchievements.KillMushroom;
        this.sporeCount = GameAchievements.SporeCount;
        this.spore = GameAchievements.Spore;
        this.stillCountsAsOne = GameAchievements.StillCountsAsOne;
        this.stillCountsAsOneCount = GameAchievements.StillCountsAsOneCount;
        return;
    }

    public void LoadGameData()
    {
        this.starsTotal = GameData.StarsTotal;
        this.starsWon = GameData.StarsWon;
        this.starsToSpent = GameData.StarsToSpent;
        this.starsSpent = GameData.StarsSpent;
        this.challengeTipShowed = GameData.ChallengeTipShowed;
        this.levelSelectHelpShowed = GameData.LevelSelectHelpShowed;
        this.campaignLevels = GameData.GetCampaign();
        return;
    }

    public void LoadNotifications()
    {
        this.notificationTowerArchersLevel2 = GameData.notificationTowerArchersLevel2;
        this.notificationTowerArchersLevel3 = GameData.notificationTowerArchersLevel3;
        this.notificationTowerArchersRanger = GameData.notificationTowerArchersRanger;
        this.notificationTowerArchersMusketeer = GameData.notificationTowerArchersMusketeer;
        this.notificationTowerSoldiersLevel2 = GameData.notificationTowerSoldiersLevel2;
        this.notificationTowerSoldiersLevel3 = GameData.notificationTowerSoldiersLevel3;
        this.notificationTowerSoldiersPaladin = GameData.notificationTowerSoldiersPaladin;
        this.notificationTowerSoldiersBarbarian = GameData.notificationTowerSoldiersBarbarian;
        this.notificationTowerMagesLevel2 = GameData.notificationTowerMagesLevel2;
        this.notificationTowerMagesLevel3 = GameData.notificationTowerMagesLevel3;
        this.notificationTowerMagesArcane = GameData.notificationTowerMagesArcane;
        this.notificationTowerMagesSorcerer = GameData.notificationTowerMagesSorcerer;
        this.notificationTowerEngineersLevel2 = GameData.notificationTowerEngineersLevel2;
        this.notificationTowerEngineersLevel3 = GameData.notificationTowerEngineersLevel3;
        this.notificationTowerEngineersBfg = GameData.notificationTowerEngineersBfg;
        this.notificationTowerEngineersTesla = GameData.notificationTowerEngineersTesla;
        this.notificationEnemyGoblin = GameData.notificationEnemyGoblin;
        this.notificationEnemyFatOrc = GameData.notificationEnemyFatOrc;
        this.notificationEnemyShaman = GameData.notificationEnemyShaman;
        this.notificationEnemyOgre = GameData.notificationEnemyOgre;
        this.notificationEnemyBandit = GameData.notificationEnemyBandit;
        this.notificationEnemyBrigand = GameData.notificationEnemyBrigand;
        this.notificationEnemyMarauder = GameData.notificationEnemyMarauder;
        this.notificationEnemySpider = GameData.notificationEnemySpider;
        this.notificationEnemySpiderSmall = GameData.notificationEnemySpiderSmall;
        this.notificationEnemyGargoyle = GameData.notificationEnemyGargoyle;
        this.notificationEnemyShadowArcher = GameData.notificationEnemyShadowArcher;
        this.notificationEnemyDarkKnight = GameData.notificationEnemyDarkKnight;
        this.notificationEnemySmallWolf = GameData.notificationEnemySmallWolf;
        this.notificationEnemyWolf = GameData.notificationEnemyWolf;
        this.notificationEnemyGolemHead = GameData.notificationEnemyGolemHead;
        this.notificationEnemyWhiteWolf = GameData.notificationEnemyWhiteWolf;
        this.notificationEnemyTroll = GameData.notificationEnemyTroll;
        this.notificationEnemyTrollAxeThrower = GameData.notificationEnemyTrollAxeThrower;
        this.notificationEnemyTrollChieftain = GameData.notificationEnemyTrollChieftain;
        this.notificationEnemyYeti = GameData.notificationEnemyYeti;
        this.notificationEnemyRocketeer = GameData.notificationEnemyRocketeer;
        this.notificationEnemyDarkSlayer = GameData.notificationEnemyDarkSlayer;
        this.notificationEnemyDemon = GameData.notificationEnemyDemon;
        this.notificationEnemyDemonMage = GameData.notificationEnemyDemonMage;
        this.notificationEnemyDemonWolf = GameData.notificationEnemyDemonWolf;
        this.notificationEnemyDemonImp = GameData.notificationEnemyDemonImp;
        this.notificationEnemyNecromancer = GameData.notificationEnemyNecromancer;
        this.notificationEnemySkeletor = GameData.notificationEnemySkeletor;
        this.notificationEnemySkeletorBig = GameData.notificationEnemySkeletorBig;
        this.notificationEnemyLavaElemental = GameData.notificationEnemyLavaElemental;
        this.notificationEnemyJuggernaut = GameData.notificationEnemyJuggernaut;
        this.notificationEnemyYetiBoss = GameData.notificationEnemyYetiBoss;
        this.notificationEnemyVeznan = GameData.notificationEnemyVeznan;
        this.notificationEnemySarelgaz = GameData.notificationEnemySarelgaz;
        this.notificationEnemySarelgazSmall = GameData.notificationEnemySarelgazSmall;
        this.notificationEnemyGoblinZapper = GameData.notificationEnemyGoblinZapper;
        this.notificationEnemyOrcRider = GameData.notificationEnemyOrcRider;
        this.notificationEnemyOrcArmored = GameData.notificationEnemyOrcArmored;
        this.notificationEnemyForestTroll = GameData.notificationEnemyForestTroll;
        this.notificationEnemyGulThak = GameData.notificationEnemyGulThak;
        this.notificationEnemyZombie = GameData.notificationEnemyZombie;
        this.notificationEnemyRottenSpider = GameData.notificationEnemyRottenSpider;
        this.notificationEnemyRottenTree = GameData.notificationEnemyRottenTree;
        this.notificationEnemySwampThing = GameData.notificationEnemySwampThing;
        this.notificationEnemyBossTreant = GameData.notificationEnemyBossTreant;
        this.notificationTipHeroes = GameData.notificationTipHeroes;
        this.notificationEnemyRaider = GameData.notificationEnemyRaider;
        this.notificationEnemyPillager = GameData.notificationEnemyPillager;
        this.notificationEnemyBossBandit = GameData.notificationEnemyBossBandit;
        this.notificationEnemyTrollSkater = GameData.notificationEnemyTrollSkater;
        this.notificationEnemyTrollBrute = GameData.notificationEnemyTrollBrute;
        this.notificationEnemyTrollBoss = GameData.notificationEnemyTrollBoss;
        this.notificationEnemyCerberus = GameData.notificationEnemyCerberus;
        this.notificationEnemyLegion = GameData.notificationEnemyLegion;
        this.notificationEnemyFlareon = GameData.notificationEnemyFlareon;
        this.notificationEnemyGulaemon = GameData.notificationEnemyGulaemon;
        this.notificationEnemyRottenLesser = GameData.notificationEnemyRottenLesser;
        this.notificationEnemyBossDemonMoloch = GameData.notificationEnemyBossDemonMoloch;
        this.notificationEnemyBossMyconid = GameData.notificationEnemyBossMyconid;
        return;
    }

    public void LoadSoundSettings()
    {
        this.soundFxVolume = GameSoundManager.GetVolumeFx();
        this.soundMusicVolume = GameSoundManager.GetVolumeMusic();
        return;
    }

    public void LoadUpgrades()
    {
        this.archersUpLevel = GameUpgrades.ArchersUpLevel;
        this.archersUpSalvage = GameUpgrades.ArchersUpSalvage;
        this.archersUpEagleEye = GameUpgrades.ArchersUpEagleEye;
        this.archersUpPiercing = GameUpgrades.ArchersUpPiercing;
        this.archersUpFarShots = GameUpgrades.ArchersUpFarShots;
        this.archersUpPrecision = GameUpgrades.ArchersUpPrecision;
        this.barracksUpLevel = GameUpgrades.BarracksUpLevel;
        this.barracksUpSurvival = GameUpgrades.BarracksUpSurvival;
        this.barracksUpBetterArmor = GameUpgrades.BarracksUpBetterArmor;
        this.barracksUpImprovedDeployment = GameUpgrades.BarracksUpImprovedDeployment;
        this.barracksUpBarbedArmor = GameUpgrades.BarracksUpBarbedArmor;
        this.barracksUpSurvival2 = GameUpgrades.BarracksUpSurvival2;
        this.magesUpLevel = GameUpgrades.MagesUpLevel;
        this.magesUpSpellReach = GameUpgrades.MagesUpSpellReach;
        this.magesUpArcaneShatter = GameUpgrades.MagesUpArcaneShatter;
        this.magesUpHermeticStudy = GameUpgrades.MagesUpHermeticStudy;
        this.magesUpEmpoweredMagic = GameUpgrades.MagesUpEmpoweredMagic;
        this.magesUpSlowCurse = GameUpgrades.MagesUpSlowCurse;
        this.magesUpArcaneShatterDamage = GameUpgrades.MagesUpArcaneShatterDamage;
        this.engineersUpLevel = GameUpgrades.EngineersUpLevel;
        this.engineersUpConcentratedFire = GameUpgrades.EngineersUpConcentratedFire;
        this.engineersUpRangeFinder = GameUpgrades.EngineersUpRangeFinder;
        this.engineersUpFieldLogistics = GameUpgrades.EngineersUpFieldLogistics;
        this.engineersUpIndustrialization = GameUpgrades.EngineersUpIndustrialization;
        this.engineersUpEfficiency = GameUpgrades.EngineersUpEfficiency;
        this.rainUpLevel = GameUpgrades.RainUpLevel;
        this.rainUpBlazingSkies = GameUpgrades.RainUpBlazingSkies;
        this.rainUpScorchedEarth = GameUpgrades.RainUpScorchedEarth;
        this.rainUpBiggerAndMeaner = GameUpgrades.RainUpBiggerAndMeaner;
        this.rainUpBlazingEarth = GameUpgrades.RainUpBlazingEarth;
        this.rainUpCataclysm = GameUpgrades.RainUpCataclysm;
        this.reinforcementLevel = GameUpgrades.ReinforcementLevel;
        this.heroesEnabled = GameUpgrades.HeroesEnabled;
        this.selectedHero = GameUpgrades.SelectedHero;
        return;
    }

    public bool Acdc
    {
        get
        {
            return this.acdc;
        }
    }

    public int AcdcKills
    {
        get
        {
            return this.acdcKills;
        }
    }

    public bool Acorn
    {
        get
        {
            return this.acorn;
        }
    }

    public int ArchersTowerUpgradeLevel3
    {
        get
        {
            return this.archersTowerUpgradeLevel3;
        }
    }

    public bool ArchersUpEagleEye
    {
        get
        {
            return this.archersUpEagleEye;
        }
    }

    public bool ArchersUpFarShots
    {
        get
        {
            return this.archersUpFarShots;
        }
    }

    public int ArchersUpLevel
    {
        get
        {
            return this.archersUpLevel;
        }
    }

    public bool ArchersUpPiercing
    {
        get
        {
            return this.archersUpPiercing;
        }
    }

    public bool ArchersUpPrecision
    {
        get
        {
            return this.archersUpPrecision;
        }
    }

    public bool ArchersUpSalvage
    {
        get
        {
            return this.archersUpSalvage;
        }
    }

    public bool Armaggedon
    {
        get
        {
            return this.armaggedon;
        }
    }

    public bool ArmyOfOne
    {
        get
        {
            return this.armyOfOne;
        }
    }

    public int ArmyOfOneCounter
    {
        get
        {
            return this.armyOfOneCounter;
        }
    }

    public bool AxeRainer
    {
        get
        {
            return this.axeRainer;
        }
    }

    public int AxesFire
    {
        get
        {
            return this.axesFire;
        }
    }

    public bool BarbarianRush
    {
        get
        {
            return this.barbarianRush;
        }
    }

    public bool BarracksUpBarbedArmor
    {
        get
        {
            return this.barracksUpBarbedArmor;
        }
    }

    public bool BarracksUpBetterArmor
    {
        get
        {
            return this.barracksUpBetterArmor;
        }
    }

    public bool BarracksUpImprovedDeployment
    {
        get
        {
            return this.barracksUpImprovedDeployment;
        }
    }

    public int BarracksUpLevel
    {
        get
        {
            return this.barracksUpLevel;
        }
    }

    public bool BarracksUpSurvival
    {
        get
        {
            return this.barracksUpSurvival;
        }
    }

    public bool BarracksUpSurvival2
    {
        get
        {
            return this.barracksUpSurvival2;
        }
    }

    public bool Bloodlust
    {
        get
        {
            return this.bloodlust;
        }
    }

    public int BuildArcanes
    {
        get
        {
            return this.buildArcanes;
        }
    }

    public int BuildBarbarians
    {
        get
        {
            return this.buildBarbarians;
        }
    }

    public int BuildBfg
    {
        get
        {
            return this.buildBfg;
        }
    }

    public int BuildMusketeers
    {
        get
        {
            return this.buildMusketeers;
        }
    }

    public int BuildPaladins
    {
        get
        {
            return this.buildPaladins;
        }
    }

    public int BuildRangers
    {
        get
        {
            return this.buildRangers;
        }
    }

    public int BuildSorcerers
    {
        get
        {
            return this.buildSorcerers;
        }
    }

    public int BuildTesla
    {
        get
        {
            return this.buildTesla;
        }
    }

    public ArrayList CampaignLevels
    {
        get
        {
            return this.campaignLevels;
        }
    }

    public bool CannonFodder
    {
        get
        {
            return this.cannonFodder;
        }
    }

    public bool ChallengeTipShowed
    {
        get
        {
            return this.challengeTipShowed;
        }
    }

    public bool ClusterRain
    {
        get
        {
            return this.clusterRain;
        }
    }

    public int ClustersFire
    {
        get
        {
            return this.clustersFire;
        }
    }

    public bool CoolRunning
    {
        get
        {
            return this.coolRunning;
        }
    }

    public int CoolRunningKilledTrolls
    {
        get
        {
            return this.coolRunningKilledTrolls;
        }
    }

    public bool Daring
    {
        get
        {
            return this.daring;
        }
    }

    public bool DeathFromAbove
    {
        get
        {
            return this.deathFromAbove;
        }
    }

    public int DesintegrateKills
    {
        get
        {
            return this.desintegrateKills;
        }
    }

    public bool DieHard
    {
        get
        {
            return this.dieHard;
        }
    }

    public bool DineInHell
    {
        get
        {
            return this.dineInHell;
        }
    }

    public int DineInHellCounter
    {
        get
        {
            return this.dineInHellCounter;
        }
    }

    public bool DustToDust
    {
        get
        {
            return this.dustToDust;
        }
    }

    public int EarlyWavesCalled
    {
        get
        {
            return this.earlyWavesCalled;
        }
    }

    public bool Earn15Stars
    {
        get
        {
            return this.earn15Stars;
        }
    }

    public bool Earn30Stars
    {
        get
        {
            return this.earn30Stars;
        }
    }

    public bool Earn45Stars
    {
        get
        {
            return this.earn45Stars;
        }
    }

    public bool EasyTowerBuilder
    {
        get
        {
            return this.easyTowerBuilder;
        }
    }

    public bool Elementalist
    {
        get
        {
            return this.elementalist;
        }
    }

    public bool EnergyNetwork
    {
        get
        {
            return this.energyNetwork;
        }
    }

    public int EngineersTowerUpgradeLevel3
    {
        get
        {
            return this.engineersTowerUpgradeLevel3;
        }
    }

    public bool EngineersUpConcentratedFire
    {
        get
        {
            return this.engineersUpConcentratedFire;
        }
    }

    public bool EngineersUpEfficiency
    {
        get
        {
            return this.engineersUpEfficiency;
        }
    }

    public bool EngineersUpFieldLogistics
    {
        get
        {
            return this.engineersUpFieldLogistics;
        }
    }

    public bool EngineersUpIndustrialization
    {
        get
        {
            return this.engineersUpIndustrialization;
        }
    }

    public int EngineersUpLevel
    {
        get
        {
            return this.engineersUpLevel;
        }
    }

    public bool EngineersUpRangeFinder
    {
        get
        {
            return this.engineersUpRangeFinder;
        }
    }

    public bool Entangled
    {
        get
        {
            return this.entangled;
        }
    }

    public bool Fearless
    {
        get
        {
            return this.fearless;
        }
    }

    public int FireballKills
    {
        get
        {
            return this.fireballKills;
        }
    }

    public bool FirstBlood
    {
        get
        {
            return this.firstBlood;
        }
    }

    public bool Fisherman
    {
        get
        {
            return this.fisherman;
        }
    }

    public bool FreeFredo
    {
        get
        {
            return this.freeFredo;
        }
    }

    public bool GiJoe
    {
        get
        {
            return this.giJoe;
        }
    }

    public bool GreatDefender
    {
        get
        {
            return this.greatDefender;
        }
    }

    public bool GreatDefenderHeroic
    {
        get
        {
            return this.greatDefenderHeroic;
        }
    }

    public bool GreatDefenderIron
    {
        get
        {
            return this.greatDefenderIron;
        }
    }

    public bool HardTowerBuilder
    {
        get
        {
            return this.hardTowerBuilder;
        }
    }

    public bool Henderson
    {
        get
        {
            return this.henderson;
        }
    }

    public int HeroesCost
    {
        get
        {
            return this.heroesCost;
        }
    }

    public bool HeroesEnabled
    {
        get
        {
            return this.heroesEnabled;
        }
    }

    public bool HolyChorus
    {
        get
        {
            return this.holyChorus;
        }
    }

    public int HolyChorusCount
    {
        get
        {
            return this.holyChorusCount;
        }
    }

    public bool Impatient
    {
        get
        {
            return this.impatient;
        }
    }

    public bool ImperialSaviour
    {
        get
        {
            return this.imperialSaviour;
        }
    }

    public bool InAppHelpShow
    {
        get
        {
            return this.inAppHelpShow;
        }
    }

    public bool Indecisive
    {
        get
        {
            return this.indecisive;
        }
    }

    public bool KillDemon
    {
        get
        {
            return this.killDemon;
        }
    }

    public int KilledEnemies
    {
        get
        {
            return this.killedEnemies;
        }
    }

    public bool KillEndBoss
    {
        get
        {
            return this.killEndBoss;
        }
    }

    public bool KillGulThak
    {
        get
        {
            return this.killGulThak;
        }
    }

    public bool KillJuggernaut
    {
        get
        {
            return this.killJuggernaut;
        }
    }

    public bool KillKingping
    {
        get
        {
            return this.killKingping;
        }
    }

    public bool KillMountainBoss
    {
        get
        {
            return this.killMountainBoss;
        }
    }

    public bool KillMushroom
    {
        get
        {
            return this.killMushroom;
        }
    }

    public bool KillSarelgaz
    {
        get
        {
            return this.killSarelgaz;
        }
    }

    public bool KillTreant
    {
        get
        {
            return this.killTreant;
        }
    }

    public bool KillTrollBoss
    {
        get
        {
            return this.killTrollBoss;
        }
    }

    public bool LevelHeroMax
    {
        get
        {
            return this.levelHeroMax;
        }
    }

    public bool LevelHeroMedium
    {
        get
        {
            return this.levelHeroMedium;
        }
    }

    public bool LevelSelectHelpShowed
    {
        get
        {
            return this.levelSelectHelpShowed;
        }
    }

    public bool MageBeamMeUp
    {
        get
        {
            return this.mageBeamMeUp;
        }
    }

    public int MageBeamMeUpEnemies
    {
        get
        {
            return this.mageBeamMeUpEnemies;
        }
    }

    public int MagesTowerUpgradeLevel3
    {
        get
        {
            return this.magesTowerUpgradeLevel3;
        }
    }

    public bool MagesUpArcaneShatter
    {
        get
        {
            return this.magesUpArcaneShatter;
        }
    }

    public int MagesUpArcaneShatterDamage
    {
        get
        {
            return this.magesUpArcaneShatterDamage;
        }
    }

    public bool MagesUpEmpoweredMagic
    {
        get
        {
            return this.magesUpEmpoweredMagic;
        }
    }

    public bool MagesUpHermeticStudy
    {
        get
        {
            return this.magesUpHermeticStudy;
        }
    }

    public int MagesUpLevel
    {
        get
        {
            return this.magesUpLevel;
        }
    }

    public bool MagesUpSlowCurse
    {
        get
        {
            return this.magesUpSlowCurse;
        }
    }

    public bool MagesUpSpellReach
    {
        get
        {
            return this.magesUpSpellReach;
        }
    }

    public bool MaxElves
    {
        get
        {
            return this.maxElves;
        }
    }

    public bool Medic
    {
        get
        {
            return this.medic;
        }
    }

    public bool MediumTowerBuilder
    {
        get
        {
            return this.mediumTowerBuilder;
        }
    }

    public int MissilesFire
    {
        get
        {
            return this.missilesFire;
        }
    }

    public bool MultiKill
    {
        get
        {
            return this.multiKill;
        }
    }

    public bool Mushroom
    {
        get
        {
            return this.mushroom;
        }
    }

    public int NotificationEnemy
    {
        get
        {
            return this.notificationEnemy;
        }
    }

    public bool NotificationEnemyBandit
    {
        get
        {
            return this.notificationEnemyBandit;
        }
    }

    public bool NotificationEnemyBossBandit
    {
        get
        {
            return this.notificationEnemyBossBandit;
        }
    }

    public bool NotificationEnemyBossDemonMoloch
    {
        get
        {
            return this.notificationEnemyBossDemonMoloch;
        }
    }

    public bool NotificationEnemyBossMyconid
    {
        get
        {
            return this.notificationEnemyBossMyconid;
        }
    }

    public bool NotificationEnemyBossTreant
    {
        get
        {
            return this.notificationEnemyBossTreant;
        }
    }

    public bool NotificationEnemyBrigand
    {
        get
        {
            return this.notificationEnemyBrigand;
        }
    }

    public bool NotificationEnemyCerberus
    {
        get
        {
            return this.notificationEnemyCerberus;
        }
    }

    public bool NotificationEnemyDarkKnight
    {
        get
        {
            return this.notificationEnemyDarkKnight;
        }
    }

    public bool NotificationEnemyDarkSlayer
    {
        get
        {
            return this.notificationEnemyDarkSlayer;
        }
    }

    public bool NotificationEnemyDemon
    {
        get
        {
            return this.notificationEnemyDemon;
        }
    }

    public bool NotificationEnemyDemonImp
    {
        get
        {
            return this.notificationEnemyDemonImp;
        }
    }

    public bool NotificationEnemyDemonMage
    {
        get
        {
            return this.notificationEnemyDemonMage;
        }
    }

    public bool NotificationEnemyDemonWolf
    {
        get
        {
            return this.notificationEnemyDemonWolf;
        }
    }

    public bool NotificationEnemyFatOrc
    {
        get
        {
            return this.notificationEnemyFatOrc;
        }
    }

    public bool NotificationEnemyFlareon
    {
        get
        {
            return this.notificationEnemyFlareon;
        }
    }

    public bool NotificationEnemyForestTroll
    {
        get
        {
            return this.notificationEnemyForestTroll;
        }
    }

    public bool NotificationEnemyGargoyle
    {
        get
        {
            return this.notificationEnemyGargoyle;
        }
    }

    public bool NotificationEnemyGoblin
    {
        get
        {
            return this.notificationEnemyGoblin;
        }
    }

    public bool NotificationEnemyGoblinZapper
    {
        get
        {
            return this.notificationEnemyGoblinZapper;
        }
    }

    public bool NotificationEnemyGolemHead
    {
        get
        {
            return this.notificationEnemyGolemHead;
        }
    }

    public bool NotificationEnemyGulaemon
    {
        get
        {
            return this.notificationEnemyGulaemon;
        }
    }

    public bool NotificationEnemyGulThak
    {
        get
        {
            return this.notificationEnemyGulThak;
        }
    }

    public bool NotificationEnemyJuggernaut
    {
        get
        {
            return this.notificationEnemyJuggernaut;
        }
    }

    public bool NotificationEnemyLavaElemental
    {
        get
        {
            return this.notificationEnemyLavaElemental;
        }
    }

    public bool NotificationEnemyLegion
    {
        get
        {
            return this.notificationEnemyLegion;
        }
    }

    public bool NotificationEnemyMarauder
    {
        get
        {
            return this.notificationEnemyMarauder;
        }
    }

    public bool NotificationEnemyNecromancer
    {
        get
        {
            return this.notificationEnemyNecromancer;
        }
    }

    public bool NotificationEnemyOgre
    {
        get
        {
            return this.notificationEnemyOgre;
        }
    }

    public bool NotificationEnemyOrcArmored
    {
        get
        {
            return this.notificationEnemyOrcArmored;
        }
    }

    public bool NotificationEnemyOrcRider
    {
        get
        {
            return this.notificationEnemyOrcRider;
        }
    }

    public bool NotificationEnemyPillager
    {
        get
        {
            return this.notificationEnemyPillager;
        }
    }

    public bool NotificationEnemyRaider
    {
        get
        {
            return this.notificationEnemyRaider;
        }
    }

    public bool NotificationEnemyRocketeer
    {
        get
        {
            return this.notificationEnemyRocketeer;
        }
    }

    public bool NotificationEnemyRottenLesser
    {
        get
        {
            return this.notificationEnemyRottenLesser;
        }
    }

    public bool NotificationEnemyRottenSpider
    {
        get
        {
            return this.notificationEnemyRottenSpider;
        }
    }

    public bool NotificationEnemyRottenTree
    {
        get
        {
            return this.notificationEnemyRottenTree;
        }
    }

    public bool NotificationEnemySarelgaz
    {
        get
        {
            return this.notificationEnemySarelgaz;
        }
    }

    public bool NotificationEnemySarelgazSmall
    {
        get
        {
            return this.notificationEnemySarelgazSmall;
        }
    }

    public bool NotificationEnemyShadowArcher
    {
        get
        {
            return this.notificationEnemyShadowArcher;
        }
    }

    public bool NotificationEnemyShaman
    {
        get
        {
            return this.notificationEnemyShaman;
        }
    }

    public bool NotificationEnemySkeletor
    {
        get
        {
            return this.notificationEnemySkeletor;
        }
    }

    public bool NotificationEnemySkeletorBig
    {
        get
        {
            return this.notificationEnemySkeletorBig;
        }
    }

    public bool NotificationEnemySmallWolf
    {
        get
        {
            return this.notificationEnemySmallWolf;
        }
    }

    public bool NotificationEnemySpider
    {
        get
        {
            return this.notificationEnemySpider;
        }
    }

    public bool NotificationEnemySpiderSmall
    {
        get
        {
            return this.notificationEnemySpiderSmall;
        }
    }

    public bool NotificationEnemySwampThing
    {
        get
        {
            return this.notificationEnemySwampThing;
        }
    }

    public bool NotificationEnemyTroll
    {
        get
        {
            return this.notificationEnemyTroll;
        }
    }

    public bool NotificationEnemyTrollAxeThrower
    {
        get
        {
            return this.notificationEnemyTrollAxeThrower;
        }
    }

    public bool NotificationEnemyTrollBoss
    {
        get
        {
            return this.notificationEnemyTrollBoss;
        }
    }

    public bool NotificationEnemyTrollBrute
    {
        get
        {
            return this.notificationEnemyTrollBrute;
        }
    }

    public bool NotificationEnemyTrollChieftain
    {
        get
        {
            return this.notificationEnemyTrollChieftain;
        }
    }

    public bool NotificationEnemyTrollSkater
    {
        get
        {
            return this.notificationEnemyTrollSkater;
        }
    }

    public bool NotificationEnemyVeznan
    {
        get
        {
            return this.notificationEnemyVeznan;
        }
    }

    public bool NotificationEnemyWhiteWolf
    {
        get
        {
            return this.notificationEnemyWhiteWolf;
        }
    }

    public bool NotificationEnemyWolf
    {
        get
        {
            return this.notificationEnemyWolf;
        }
    }

    public bool NotificationEnemyYeti
    {
        get
        {
            return this.notificationEnemyYeti;
        }
    }

    public bool NotificationEnemyYetiBoss
    {
        get
        {
            return this.notificationEnemyYetiBoss;
        }
    }

    public bool NotificationEnemyZombie
    {
        get
        {
            return this.notificationEnemyZombie;
        }
    }

    public bool NotificationTipHeroes
    {
        get
        {
            return this.notificationTipHeroes;
        }
    }

    public bool NotificationTowerArchersLevel2
    {
        get
        {
            return this.notificationTowerArchersLevel2;
        }
    }

    public bool NotificationTowerArchersLevel3
    {
        get
        {
            return this.notificationTowerArchersLevel3;
        }
    }

    public bool NotificationTowerArchersMusketeer
    {
        get
        {
            return this.notificationTowerArchersMusketeer;
        }
    }

    public bool NotificationTowerArchersRanger
    {
        get
        {
            return this.notificationTowerArchersRanger;
        }
    }

    public bool NotificationTowerEngineersBfg
    {
        get
        {
            return this.notificationTowerEngineersBfg;
        }
    }

    public bool NotificationTowerEngineersLevel2
    {
        get
        {
            return this.notificationTowerEngineersLevel2;
        }
    }

    public bool NotificationTowerEngineersLevel3
    {
        get
        {
            return this.notificationTowerEngineersLevel3;
        }
    }

    public bool NotificationTowerEngineersTesla
    {
        get
        {
            return this.notificationTowerEngineersTesla;
        }
    }

    public bool NotificationTowerMagesArcane
    {
        get
        {
            return this.notificationTowerMagesArcane;
        }
    }

    public bool NotificationTowerMagesLevel2
    {
        get
        {
            return this.notificationTowerMagesLevel2;
        }
    }

    public bool NotificationTowerMagesLevel3
    {
        get
        {
            return this.notificationTowerMagesLevel3;
        }
    }

    public bool NotificationTowerMagesSorcerer
    {
        get
        {
            return this.notificationTowerMagesSorcerer;
        }
    }

    public bool NotificationTowerSoldiersBarbarian
    {
        get
        {
            return this.notificationTowerSoldiersBarbarian;
        }
    }

    public bool NotificationTowerSoldiersLevel2
    {
        get
        {
            return this.notificationTowerSoldiersLevel2;
        }
    }

    public bool NotificationTowerSoldiersLevel3
    {
        get
        {
            return this.notificationTowerSoldiersLevel3;
        }
    }

    public bool NotificationTowerSoldiersPaladin
    {
        get
        {
            return this.notificationTowerSoldiersPaladin;
        }
    }

    public int PaladinHeals
    {
        get
        {
            return this.paladinHeals;
        }
    }

    public int PoisonKills
    {
        get
        {
            return this.poisonKills;
        }
    }

    public int PolymorphKills
    {
        get
        {
            return this.polymorphKills;
        }
    }

    public bool RainUpBiggerAndMeaner
    {
        get
        {
            return this.rainUpBiggerAndMeaner;
        }
    }

    public bool RainUpBlazingEarth
    {
        get
        {
            return this.rainUpBlazingEarth;
        }
    }

    public bool RainUpBlazingSkies
    {
        get
        {
            return this.rainUpBlazingSkies;
        }
    }

    public bool RainUpCataclysm
    {
        get
        {
            return this.rainUpCataclysm;
        }
    }

    public int RainUpLevel
    {
        get
        {
            return this.rainUpLevel;
        }
    }

    public bool RainUpScorchedEarth
    {
        get
        {
            return this.rainUpScorchedEarth;
        }
    }

    public int RallyChanges
    {
        get
        {
            return this.rallyChanges;
        }
    }

    public bool RealEstate
    {
        get
        {
            return this.realEstate;
        }
    }

    public int ReinforcementLevel
    {
        get
        {
            return this.reinforcementLevel;
        }
    }

    public bool Rocketeer
    {
        get
        {
            return this.rocketeer;
        }
    }

    public int SelectedHero
    {
        get
        {
            return this.selectedHero;
        }
    }

    public int SellTowers
    {
        get
        {
            return this.sellTowers;
        }
    }

    public bool SheepKiller
    {
        get
        {
            return this.sheepKiller;
        }
    }

    public int SheepsKilled
    {
        get
        {
            return this.sheepsKilled;
        }
    }

    public bool Shepard
    {
        get
        {
            return this.shepard;
        }
    }

    public bool Slayer
    {
        get
        {
            return this.slayer;
        }
    }

    public bool Sniper
    {
        get
        {
            return this.sniper;
        }
    }

    public int SniperKills
    {
        get
        {
            return this.sniperKills;
        }
    }

    public int SoldiersKilled
    {
        get
        {
            return this.soldiersKilled;
        }
    }

    public int SoldiersRegeneration
    {
        get
        {
            return this.soldiersRegeneration;
        }
    }

    public int SoldiersTowerUpgradeLevel3
    {
        get
        {
            return this.soldiersTowerUpgradeLevel3;
        }
    }

    public int SoldiersTrained
    {
        get
        {
            return this.soldiersTrained;
        }
    }

    public float SoundFxVolume
    {
        get
        {
            return this.soundFxVolume;
        }
    }

    public float SoundMusicVolume
    {
        get
        {
            return this.soundMusicVolume;
        }
    }

    public bool Specialization
    {
        get
        {
            return this.specialization;
        }
    }

    public bool Spore
    {
        get
        {
            return this.spore;
        }
    }

    public int SporeCount
    {
        get
        {
            return this.sporeCount;
        }
    }

    public int StarsSpent
    {
        get
        {
            return this.starsSpent;
        }
    }

    public int StarsToSpent
    {
        get
        {
            return this.starsToSpent;
        }
    }

    public int StarsTotal
    {
        get
        {
            return this.starsTotal;
        }
    }

    public int StarsWon
    {
        get
        {
            return this.starsWon;
        }
    }

    public bool StillCountsAsOne
    {
        get
        {
            return this.stillCountsAsOne;
        }
    }

    public int StillCountsAsOneCount
    {
        get
        {
            return this.stillCountsAsOneCount;
        }
    }

    public bool Sunburner
    {
        get
        {
            return this.sunburner;
        }
    }

    public int SunrayShots
    {
        get
        {
            return this.sunrayShots;
        }
    }

    public bool Tactician
    {
        get
        {
            return this.tactician;
        }
    }

    public int ThornsEnemies
    {
        get
        {
            return this.thornsEnemies;
        }
    }

    public int TowerBuilded
    {
        get
        {
            return this.towerBuilded;
        }
    }

    public bool TowerUpgradeLevel3
    {
        get
        {
            return this.towerUpgradeLevel3;
        }
    }

    public bool Toxicity
    {
        get
        {
            return this.toxicity;
        }
    }

    public bool WhatsThat
    {
        get
        {
            return this.whatsThat;
        }
    }
}

