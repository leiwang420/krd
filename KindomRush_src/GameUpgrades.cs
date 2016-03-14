using System;
using System.Collections.Generic;
using UnityEngine;

public class GameUpgrades
{
    private bool archersUpEagleEye;
    private bool archersUpFarShots;
    private int archersUpLevel;
    private bool archersUpPiercing;
    private bool archersUpPrecision;
    private bool archersUpSalvage;
    private bool barracksUpBarbedArmor;
    private bool barracksUpBetterArmor;
    private bool barracksUpImprovedDeployment;
    private int barracksUpLevel;
    private bool barracksUpSurvival;
    private bool barracksUpSurvival2;
    private bool engineersUpConcentratedFire;
    private bool engineersUpEfficiency;
    private bool engineersUpFieldLogistics;
    private bool engineersUpIndustrialization;
    private int engineersUpLevel;
    private bool engineersUpRangeFinder;
    private int heroesCost;
    private bool heroesEnabled;
    private static GameUpgrades instance;
    private bool magesUpArcaneShatter;
    private int magesUpArcaneShatterDamage;
    private bool magesUpEmpoweredMagic;
    private bool magesUpHermeticStudy;
    private int magesUpLevel;
    private bool magesUpSlowCurse;
    private bool magesUpSpellReach;
    private bool rainUpBiggerAndMeaner;
    private bool rainUpBlazingEarth;
    private bool rainUpBlazingSkies;
    private bool rainUpCataclysm;
    private int rainUpLevel;
    private bool rainUpScorchedEarth;
    private int reinforcementLevel;
    private int selectedHero;

    public GameUpgrades()
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

    public static void BuyUpgrade(upgradeType type)
    {
        upgradeType type2;
        type2 = type;
        switch (type2)
        {
            case 0:
                goto Label_0085;

            case 1:
                goto Label_00A0;

            case 2:
                goto Label_00BB;

            case 3:
                goto Label_00D6;

            case 4:
                goto Label_00F1;

            case 5:
                goto Label_010C;

            case 6:
                goto Label_0127;

            case 7:
                goto Label_0142;

            case 8:
                goto Label_0178;

            case 9:
                goto Label_015D;

            case 10:
                goto Label_0193;

            case 11:
                goto Label_01AE;

            case 12:
                goto Label_01C9;

            case 13:
                goto Label_01E4;

            case 14:
                goto Label_01FF;

            case 15:
                goto Label_021A;

            case 0x10:
                goto Label_0235;

            case 0x11:
                goto Label_0250;

            case 0x12:
                goto Label_026B;

            case 0x13:
                goto Label_0286;

            case 20:
                goto Label_02A1;

            case 0x15:
                goto Label_02BC;

            case 0x16:
                goto Label_02D7;

            case 0x17:
                goto Label_02F2;

            case 0x18:
                goto Label_030D;

            case 0x19:
                goto Label_0328;

            case 0x1a:
                goto Label_0338;

            case 0x1b:
                goto Label_0348;

            case 0x1c:
                goto Label_0358;

            case 0x1d:
                goto Label_0368;
        }
        goto Label_0378;
    Label_0085:
        Instance.archersUpLevel = 1;
        Instance.archersUpSalvage = 1;
        goto Label_037D;
    Label_00A0:
        Instance.archersUpLevel = 2;
        Instance.archersUpEagleEye = 1;
        goto Label_037D;
    Label_00BB:
        Instance.archersUpLevel = 3;
        Instance.archersUpPiercing = 1;
        goto Label_037D;
    Label_00D6:
        Instance.archersUpLevel = 4;
        Instance.archersUpFarShots = 1;
        goto Label_037D;
    Label_00F1:
        Instance.archersUpLevel = 5;
        Instance.archersUpPrecision = 1;
        goto Label_037D;
    Label_010C:
        Instance.barracksUpLevel = 1;
        Instance.barracksUpSurvival = 1;
        goto Label_037D;
    Label_0127:
        Instance.barracksUpLevel = 2;
        Instance.barracksUpBetterArmor = 1;
        goto Label_037D;
    Label_0142:
        Instance.barracksUpLevel = 3;
        Instance.barracksUpImprovedDeployment = 1;
        goto Label_037D;
    Label_015D:
        Instance.barracksUpLevel = 4;
        Instance.barracksUpSurvival2 = 1;
        goto Label_037D;
    Label_0178:
        Instance.barracksUpLevel = 5;
        Instance.barracksUpBarbedArmor = 1;
        goto Label_037D;
    Label_0193:
        Instance.magesUpLevel = 1;
        Instance.magesUpSpellReach = 1;
        goto Label_037D;
    Label_01AE:
        Instance.magesUpLevel = 2;
        Instance.magesUpArcaneShatter = 1;
        goto Label_037D;
    Label_01C9:
        Instance.magesUpLevel = 3;
        Instance.magesUpHermeticStudy = 1;
        goto Label_037D;
    Label_01E4:
        Instance.magesUpLevel = 4;
        Instance.magesUpEmpoweredMagic = 1;
        goto Label_037D;
    Label_01FF:
        Instance.magesUpLevel = 5;
        Instance.magesUpSlowCurse = 1;
        goto Label_037D;
    Label_021A:
        Instance.engineersUpLevel = 1;
        Instance.engineersUpConcentratedFire = 1;
        goto Label_037D;
    Label_0235:
        Instance.engineersUpLevel = 2;
        Instance.engineersUpRangeFinder = 1;
        goto Label_037D;
    Label_0250:
        Instance.engineersUpLevel = 3;
        Instance.engineersUpFieldLogistics = 1;
        goto Label_037D;
    Label_026B:
        Instance.engineersUpLevel = 4;
        Instance.engineersUpIndustrialization = 1;
        goto Label_037D;
    Label_0286:
        Instance.engineersUpLevel = 5;
        Instance.engineersUpEfficiency = 1;
        goto Label_037D;
    Label_02A1:
        Instance.rainUpLevel = 1;
        Instance.rainUpBlazingSkies = 1;
        goto Label_037D;
    Label_02BC:
        Instance.rainUpLevel = 2;
        Instance.rainUpScorchedEarth = 1;
        goto Label_037D;
    Label_02D7:
        Instance.rainUpLevel = 3;
        Instance.rainUpBiggerAndMeaner = 1;
        goto Label_037D;
    Label_02F2:
        Instance.rainUpLevel = 4;
        Instance.rainUpBlazingEarth = 1;
        goto Label_037D;
    Label_030D:
        Instance.rainUpLevel = 5;
        Instance.rainUpCataclysm = 1;
        goto Label_037D;
    Label_0328:
        Instance.reinforcementLevel = 1;
        goto Label_037D;
    Label_0338:
        Instance.reinforcementLevel = 2;
        goto Label_037D;
    Label_0348:
        Instance.reinforcementLevel = 3;
        goto Label_037D;
    Label_0358:
        Instance.reinforcementLevel = 4;
        goto Label_037D;
    Label_0368:
        Instance.reinforcementLevel = 5;
        goto Label_037D;
    Label_0378:;
    Label_037D:
        return;
    }

    public static bool CanSelectHero(heroType h)
    {
        heroType type;
        type = h;
        switch ((type - 1))
        {
            case 0:
                goto Label_005C;

            case 1:
                goto Label_003F;

            case 2:
                goto Label_004E;

            case 3:
                goto Label_0055;

            case 4:
                goto Label_006B;

            case 5:
                goto Label_0063;

            case 6:
                goto Label_0046;

            case 7:
                goto Label_0072;

            case 8:
                goto Label_007A;

            case 9:
                goto Label_0082;

            case 10:
                goto Label_008A;

            case 11:
                goto Label_0092;
        }
        goto Label_009A;
    Label_003F:
        return GameData.IsStageCompleted(5);
    Label_0046:
        return GameData.IsStageCompleted(11);
    Label_004E:
        return GameData.IsStageCompleted(7);
    Label_0055:
        return GameData.IsStageCompleted(8);
    Label_005C:
        return GameData.IsStageCompleted(3);
    Label_0063:
        return GameData.IsStageCompleted(10);
    Label_006B:
        return GameData.IsStageCompleted(7);
    Label_0072:
        return GameData.IsStageCompleted(12);
    Label_007A:
        return GameData.IsStageCompleted(12);
    Label_0082:
        return GameData.IsStageCompleted(12);
    Label_008A:
        return GameData.IsStageCompleted(12);
    Label_0092:
        return GameData.IsStageCompleted(12);
    Label_009A:;
    Label_009F:
        return 0;
    }

    public static Dictionary<string, bool> GetDataBool()
    {
        Dictionary<string, bool> dictionary;
        dictionary = new Dictionary<string, bool>();
        dictionary.Add("archersUpSalvage", Instance.archersUpSalvage);
        dictionary.Add("archersUpEagleEye", Instance.archersUpEagleEye);
        dictionary.Add("archersUpPiercing", Instance.archersUpPiercing);
        dictionary.Add("archersUpFarShots", Instance.archersUpFarShots);
        dictionary.Add("archersUpPrecision", Instance.archersUpPrecision);
        dictionary.Add("barracksUpSurvival", Instance.barracksUpSurvival);
        dictionary.Add("barracksUpBetterArmor", Instance.barracksUpBetterArmor);
        dictionary.Add("barracksUpImprovedDeployment", Instance.barracksUpImprovedDeployment);
        dictionary.Add("barracksUpBarbedArmor", Instance.barracksUpBarbedArmor);
        dictionary.Add("barracksUpSurvival2", Instance.barracksUpSurvival2);
        dictionary.Add("magesUpSpellReach", Instance.magesUpSpellReach);
        dictionary.Add("magesUpArcaneShatter", Instance.magesUpArcaneShatter);
        dictionary.Add("magesUpHermeticStudy", Instance.magesUpHermeticStudy);
        dictionary.Add("magesUpEmpoweredMagic", Instance.magesUpEmpoweredMagic);
        dictionary.Add("magesUpSlowCurse", Instance.magesUpSlowCurse);
        dictionary.Add("magesUpSpellReach", Instance.magesUpSpellReach);
        dictionary.Add("magesUpArcaneShatter", Instance.magesUpArcaneShatter);
        dictionary.Add("magesUpHermeticStudy", Instance.magesUpHermeticStudy);
        dictionary.Add("magesUpEmpoweredMagic", Instance.magesUpEmpoweredMagic);
        dictionary.Add("magesUpSlowCurse", Instance.magesUpSlowCurse);
        dictionary.Add("engineersUpConcentratedFire", Instance.engineersUpConcentratedFire);
        dictionary.Add("engineersUpRangeFinder", Instance.engineersUpRangeFinder);
        dictionary.Add("engineersUpFieldLogistics", Instance.engineersUpFieldLogistics);
        dictionary.Add("engineersUpIndustrialization", Instance.engineersUpIndustrialization);
        dictionary.Add("engineersUpEfficiency", Instance.engineersUpEfficiency);
        dictionary.Add("rainUpBlazingSkies", Instance.rainUpBlazingSkies);
        dictionary.Add("rainUpScorchedEarth", Instance.rainUpScorchedEarth);
        dictionary.Add("rainUpBiggerAndMeaner", Instance.rainUpBiggerAndMeaner);
        dictionary.Add("rainUpBlazingEarth", Instance.rainUpBlazingEarth);
        dictionary.Add("rainUpCataclysm", Instance.rainUpCataclysm);
        return dictionary;
    }

    public static Dictionary<string, int> GetDataInt()
    {
        Dictionary<string, int> dictionary;
        dictionary = new Dictionary<string, int>();
        dictionary.Add("archersUpLevel", Instance.archersUpLevel);
        dictionary.Add("barracksUpLevel", Instance.barracksUpLevel);
        dictionary.Add("magesUpLevel", Instance.magesUpLevel);
        dictionary.Add("engineersUpLevel", Instance.engineersUpLevel);
        dictionary.Add("rainUpLevel", Instance.rainUpLevel);
        dictionary.Add("reinforcementLevel", Instance.reinforcementLevel);
        return dictionary;
    }

    private void Init()
    {
        this.magesUpArcaneShatterDamage = 3;
        this.heroesEnabled = 1;
        this.selectedHero = 0;
        this.heroesCost = 15;
        return;
    }

    public static bool IsBought(upgradeType type)
    {
        upgradeType type2;
        type2 = type;
        switch (type2)
        {
            case 0:
                goto Label_0085;

            case 1:
                goto Label_0090;

            case 2:
                goto Label_009B;

            case 3:
                goto Label_00A6;

            case 4:
                goto Label_00B1;

            case 5:
                goto Label_00BC;

            case 6:
                goto Label_00C7;

            case 7:
                goto Label_00D2;

            case 8:
                goto Label_00E8;

            case 9:
                goto Label_00DD;

            case 10:
                goto Label_00F3;

            case 11:
                goto Label_00FE;

            case 12:
                goto Label_0109;

            case 13:
                goto Label_0114;

            case 14:
                goto Label_011F;

            case 15:
                goto Label_012A;

            case 0x10:
                goto Label_0135;

            case 0x11:
                goto Label_0140;

            case 0x12:
                goto Label_014B;

            case 0x13:
                goto Label_0156;

            case 20:
                goto Label_0161;

            case 0x15:
                goto Label_016C;

            case 0x16:
                goto Label_0177;

            case 0x17:
                goto Label_0182;

            case 0x18:
                goto Label_018D;

            case 0x19:
                goto Label_0198;

            case 0x1a:
                goto Label_01AC;

            case 0x1b:
                goto Label_01C0;

            case 0x1c:
                goto Label_01D4;

            case 0x1d:
                goto Label_01E8;
        }
        goto Label_01FC;
    Label_0085:
        return Instance.archersUpSalvage;
    Label_0090:
        return Instance.archersUpEagleEye;
    Label_009B:
        return Instance.archersUpPiercing;
    Label_00A6:
        return Instance.archersUpFarShots;
    Label_00B1:
        return Instance.archersUpPrecision;
    Label_00BC:
        return Instance.barracksUpSurvival;
    Label_00C7:
        return Instance.barracksUpBetterArmor;
    Label_00D2:
        return Instance.barracksUpImprovedDeployment;
    Label_00DD:
        return Instance.barracksUpSurvival2;
    Label_00E8:
        return Instance.barracksUpBarbedArmor;
    Label_00F3:
        return Instance.magesUpSpellReach;
    Label_00FE:
        return Instance.magesUpArcaneShatter;
    Label_0109:
        return Instance.magesUpHermeticStudy;
    Label_0114:
        return Instance.magesUpEmpoweredMagic;
    Label_011F:
        return Instance.magesUpSlowCurse;
    Label_012A:
        return Instance.engineersUpConcentratedFire;
    Label_0135:
        return Instance.engineersUpRangeFinder;
    Label_0140:
        return Instance.engineersUpFieldLogistics;
    Label_014B:
        return Instance.engineersUpIndustrialization;
    Label_0156:
        return Instance.engineersUpEfficiency;
    Label_0161:
        return Instance.rainUpBlazingSkies;
    Label_016C:
        return Instance.rainUpScorchedEarth;
    Label_0177:
        return Instance.rainUpBiggerAndMeaner;
    Label_0182:
        return Instance.rainUpBlazingEarth;
    Label_018D:
        return Instance.rainUpCataclysm;
    Label_0198:
        if (Instance.reinforcementLevel < 1)
        {
            goto Label_01AA;
        }
        return 1;
    Label_01AA:
        return 0;
    Label_01AC:
        if (Instance.reinforcementLevel < 2)
        {
            goto Label_01BE;
        }
        return 1;
    Label_01BE:
        return 0;
    Label_01C0:
        if (Instance.reinforcementLevel < 3)
        {
            goto Label_01D2;
        }
        return 1;
    Label_01D2:
        return 0;
    Label_01D4:
        if (Instance.reinforcementLevel < 4)
        {
            goto Label_01E6;
        }
        return 1;
    Label_01E6:
        return 0;
    Label_01E8:
        if (Instance.reinforcementLevel < 5)
        {
            goto Label_01FA;
        }
        return 1;
    Label_01FA:
        return 0;
    Label_01FC:;
    Label_0201:
        return 0;
    }

    public static bool IsPreviousBought(upgradeType type)
    {
        upgradeType type2;
        type2 = type;
        switch (type2)
        {
            case 0:
                goto Label_0085;

            case 1:
                goto Label_0087;

            case 2:
                goto Label_0092;

            case 3:
                goto Label_009D;

            case 4:
                goto Label_00A8;

            case 5:
                goto Label_00B3;

            case 6:
                goto Label_00B5;

            case 7:
                goto Label_00C0;

            case 8:
                goto Label_00D6;

            case 9:
                goto Label_00CB;

            case 10:
                goto Label_00E1;

            case 11:
                goto Label_00E3;

            case 12:
                goto Label_00EE;

            case 13:
                goto Label_00F9;

            case 14:
                goto Label_0104;

            case 15:
                goto Label_010F;

            case 0x10:
                goto Label_0111;

            case 0x11:
                goto Label_011C;

            case 0x12:
                goto Label_0127;

            case 0x13:
                goto Label_0132;

            case 20:
                goto Label_013D;

            case 0x15:
                goto Label_013F;

            case 0x16:
                goto Label_014A;

            case 0x17:
                goto Label_0155;

            case 0x18:
                goto Label_0160;

            case 0x19:
                goto Label_016B;

            case 0x1a:
                goto Label_016D;

            case 0x1b:
                goto Label_0181;

            case 0x1c:
                goto Label_0195;

            case 0x1d:
                goto Label_01A9;
        }
        goto Label_01BD;
    Label_0085:
        return 1;
    Label_0087:
        return Instance.archersUpSalvage;
    Label_0092:
        return Instance.archersUpEagleEye;
    Label_009D:
        return Instance.archersUpPiercing;
    Label_00A8:
        return Instance.archersUpFarShots;
    Label_00B3:
        return 1;
    Label_00B5:
        return Instance.barracksUpSurvival;
    Label_00C0:
        return Instance.barracksUpBetterArmor;
    Label_00CB:
        return Instance.barracksUpImprovedDeployment;
    Label_00D6:
        return Instance.barracksUpSurvival2;
    Label_00E1:
        return 1;
    Label_00E3:
        return Instance.magesUpSpellReach;
    Label_00EE:
        return Instance.magesUpArcaneShatter;
    Label_00F9:
        return Instance.magesUpHermeticStudy;
    Label_0104:
        return Instance.magesUpEmpoweredMagic;
    Label_010F:
        return 1;
    Label_0111:
        return Instance.engineersUpConcentratedFire;
    Label_011C:
        return Instance.engineersUpRangeFinder;
    Label_0127:
        return Instance.engineersUpFieldLogistics;
    Label_0132:
        return Instance.engineersUpIndustrialization;
    Label_013D:
        return 1;
    Label_013F:
        return Instance.rainUpBlazingSkies;
    Label_014A:
        return Instance.rainUpScorchedEarth;
    Label_0155:
        return Instance.rainUpBiggerAndMeaner;
    Label_0160:
        return Instance.rainUpBlazingEarth;
    Label_016B:
        return 1;
    Label_016D:
        if (Instance.reinforcementLevel < 1)
        {
            goto Label_017F;
        }
        return 1;
    Label_017F:
        return 0;
    Label_0181:
        if (Instance.reinforcementLevel < 2)
        {
            goto Label_0193;
        }
        return 1;
    Label_0193:
        return 0;
    Label_0195:
        if (Instance.reinforcementLevel < 3)
        {
            goto Label_01A7;
        }
        return 1;
    Label_01A7:
        return 0;
    Label_01A9:
        if (Instance.reinforcementLevel < 4)
        {
            goto Label_01BB;
        }
        return 1;
    Label_01BB:
        return 0;
    Label_01BD:;
    Label_01C2:
        return 0;
    }

    public static void LoadFromSave(SaveGame s)
    {
        Instance.archersUpLevel = s.ArchersUpLevel;
        Instance.archersUpSalvage = s.ArchersUpSalvage;
        Instance.archersUpEagleEye = s.ArchersUpEagleEye;
        Instance.archersUpPiercing = s.ArchersUpPiercing;
        Instance.archersUpFarShots = s.ArchersUpFarShots;
        Instance.archersUpPrecision = s.ArchersUpPrecision;
        Instance.barracksUpLevel = s.BarracksUpLevel;
        Instance.barracksUpSurvival = s.BarracksUpSurvival;
        Instance.barracksUpBetterArmor = s.BarracksUpBetterArmor;
        Instance.barracksUpImprovedDeployment = s.BarracksUpImprovedDeployment;
        Instance.barracksUpBarbedArmor = s.BarracksUpBarbedArmor;
        Instance.barracksUpSurvival2 = s.BarracksUpSurvival2;
        Instance.magesUpLevel = s.MagesUpLevel;
        Instance.magesUpSpellReach = s.MagesUpSpellReach;
        Instance.magesUpArcaneShatter = s.MagesUpArcaneShatter;
        Instance.magesUpHermeticStudy = s.MagesUpHermeticStudy;
        Instance.magesUpEmpoweredMagic = s.MagesUpEmpoweredMagic;
        Instance.magesUpSlowCurse = s.MagesUpSlowCurse;
        Instance.magesUpArcaneShatterDamage = s.MagesUpArcaneShatterDamage;
        Instance.engineersUpLevel = s.EngineersUpLevel;
        Instance.engineersUpConcentratedFire = s.EngineersUpConcentratedFire;
        Instance.engineersUpRangeFinder = s.EngineersUpRangeFinder;
        Instance.engineersUpFieldLogistics = s.EngineersUpFieldLogistics;
        Instance.engineersUpIndustrialization = s.EngineersUpIndustrialization;
        Instance.engineersUpEfficiency = s.EngineersUpEfficiency;
        Instance.rainUpLevel = s.RainUpLevel;
        Instance.rainUpBlazingSkies = s.RainUpBlazingSkies;
        Instance.rainUpScorchedEarth = s.RainUpScorchedEarth;
        Instance.rainUpBiggerAndMeaner = s.RainUpBiggerAndMeaner;
        Instance.rainUpBlazingEarth = s.RainUpBlazingEarth;
        Instance.rainUpCataclysm = s.RainUpCataclysm;
        Instance.reinforcementLevel = s.ReinforcementLevel;
        Instance.selectedHero = s.SelectedHero;
        Instance.heroesEnabled = s.HeroesEnabled;
        return;
    }

    public static void Reset()
    {
        Instance.archersUpLevel = 0;
        Instance.archersUpEagleEye = 0;
        Instance.archersUpFarShots = 0;
        Instance.archersUpPiercing = 0;
        Instance.archersUpPrecision = 0;
        Instance.archersUpSalvage = 0;
        Instance.barracksUpLevel = 0;
        Instance.barracksUpSurvival = 0;
        Instance.barracksUpBetterArmor = 0;
        Instance.barracksUpImprovedDeployment = 0;
        Instance.barracksUpSurvival2 = 0;
        Instance.barracksUpBarbedArmor = 0;
        Instance.magesUpLevel = 0;
        Instance.magesUpSpellReach = 0;
        Instance.magesUpArcaneShatter = 0;
        Instance.magesUpHermeticStudy = 0;
        Instance.magesUpEmpoweredMagic = 0;
        Instance.magesUpSlowCurse = 0;
        Instance.engineersUpLevel = 0;
        Instance.engineersUpConcentratedFire = 0;
        Instance.engineersUpRangeFinder = 0;
        Instance.engineersUpFieldLogistics = 0;
        Instance.engineersUpIndustrialization = 0;
        Instance.engineersUpEfficiency = 0;
        Instance.rainUpLevel = 0;
        Instance.rainUpBlazingSkies = 0;
        Instance.rainUpScorchedEarth = 0;
        Instance.rainUpBiggerAndMeaner = 0;
        Instance.rainUpBlazingEarth = 0;
        Instance.rainUpCataclysm = 0;
        Instance.reinforcementLevel = 0;
        return;
    }

    public static unsafe void SetDataBool(Dictionary<string, bool> myData)
    {
        myData.TryGetValue("archersUpSalvage", &Instance.archersUpSalvage);
        myData.TryGetValue("archersUpEagleEye", &Instance.archersUpEagleEye);
        myData.TryGetValue("archersUpPiercing", &Instance.archersUpPiercing);
        myData.TryGetValue("archersUpFarShots", &Instance.archersUpFarShots);
        myData.TryGetValue("archersUpPrecision", &Instance.archersUpPrecision);
        myData.TryGetValue("barracksUpSurvival", &Instance.barracksUpSurvival);
        myData.TryGetValue("barracksUpBetterArmor", &Instance.barracksUpBetterArmor);
        myData.TryGetValue("barracksUpImprovedDeployment", &Instance.barracksUpImprovedDeployment);
        myData.TryGetValue("barracksUpBarbedArmor", &Instance.barracksUpBarbedArmor);
        myData.TryGetValue("barracksUpSurvival2", &Instance.barracksUpSurvival2);
        myData.TryGetValue("magesUpSpellReach", &Instance.magesUpSpellReach);
        myData.TryGetValue("magesUpArcaneShatter", &Instance.magesUpArcaneShatter);
        myData.TryGetValue("magesUpHermeticStudy", &Instance.magesUpHermeticStudy);
        myData.TryGetValue("magesUpEmpoweredMagic", &Instance.magesUpEmpoweredMagic);
        myData.TryGetValue("magesUpSlowCurse", &Instance.magesUpSlowCurse);
        myData.TryGetValue("engineersUpConcentratedFire", &Instance.engineersUpConcentratedFire);
        myData.TryGetValue("engineersUpRangeFinder", &Instance.engineersUpRangeFinder);
        myData.TryGetValue("engineersUpFieldLogistics", &Instance.engineersUpFieldLogistics);
        myData.TryGetValue("engineersUpIndustrialization", &Instance.engineersUpIndustrialization);
        myData.TryGetValue("engineersUpEfficiency", &Instance.engineersUpEfficiency);
        myData.TryGetValue("rainUpBlazingSkies", &Instance.rainUpBlazingSkies);
        myData.TryGetValue("rainUpScorchedEarth", &Instance.rainUpScorchedEarth);
        myData.TryGetValue("rainUpBiggerAndMeaner", &Instance.rainUpBiggerAndMeaner);
        myData.TryGetValue("rainUpBlazingEarth", &Instance.rainUpBlazingEarth);
        myData.TryGetValue("rainUpCataclysm", &Instance.rainUpCataclysm);
        return;
    }

    public static unsafe void SetDataInt(Dictionary<string, int> myData)
    {
        myData.TryGetValue("archersUpLevel", &Instance.archersUpLevel);
        myData.TryGetValue("barracksUpLevel", &Instance.barracksUpLevel);
        myData.TryGetValue("magesUpLevel", &Instance.magesUpLevel);
        myData.TryGetValue("engineersUpLevel", &Instance.engineersUpLevel);
        myData.TryGetValue("rainUpLevel", &Instance.rainUpLevel);
        myData.TryGetValue("reinforcementLevel", &Instance.reinforcementLevel);
        return;
    }

    public static void UndoUpgrade(upgradeType type)
    {
        upgradeType type2;
        type2 = type;
        switch (type2)
        {
            case 0:
                goto Label_0085;

            case 1:
                goto Label_00A0;

            case 2:
                goto Label_00BB;

            case 3:
                goto Label_00D6;

            case 4:
                goto Label_00F1;

            case 5:
                goto Label_010C;

            case 6:
                goto Label_0127;

            case 7:
                goto Label_0142;

            case 8:
                goto Label_0178;

            case 9:
                goto Label_015D;

            case 10:
                goto Label_0193;

            case 11:
                goto Label_01AE;

            case 12:
                goto Label_01C9;

            case 13:
                goto Label_01E4;

            case 14:
                goto Label_01FF;

            case 15:
                goto Label_021A;

            case 0x10:
                goto Label_0235;

            case 0x11:
                goto Label_0250;

            case 0x12:
                goto Label_026B;

            case 0x13:
                goto Label_0286;

            case 20:
                goto Label_02A1;

            case 0x15:
                goto Label_02BC;

            case 0x16:
                goto Label_02D7;

            case 0x17:
                goto Label_02F2;

            case 0x18:
                goto Label_030D;

            case 0x19:
                goto Label_0328;

            case 0x1a:
                goto Label_0338;

            case 0x1b:
                goto Label_0348;

            case 0x1c:
                goto Label_0358;

            case 0x1d:
                goto Label_0368;
        }
        goto Label_0378;
    Label_0085:
        Instance.archersUpLevel = 0;
        Instance.archersUpSalvage = 0;
        goto Label_037D;
    Label_00A0:
        Instance.archersUpLevel = 1;
        Instance.archersUpEagleEye = 0;
        goto Label_037D;
    Label_00BB:
        Instance.archersUpLevel = 2;
        Instance.archersUpPiercing = 0;
        goto Label_037D;
    Label_00D6:
        Instance.archersUpLevel = 3;
        Instance.archersUpFarShots = 0;
        goto Label_037D;
    Label_00F1:
        Instance.archersUpLevel = 4;
        Instance.archersUpPrecision = 0;
        goto Label_037D;
    Label_010C:
        Instance.barracksUpLevel = 0;
        Instance.barracksUpSurvival = 0;
        goto Label_037D;
    Label_0127:
        Instance.barracksUpLevel = 1;
        Instance.barracksUpBetterArmor = 0;
        goto Label_037D;
    Label_0142:
        Instance.barracksUpLevel = 2;
        Instance.barracksUpImprovedDeployment = 0;
        goto Label_037D;
    Label_015D:
        Instance.barracksUpLevel = 3;
        Instance.barracksUpSurvival2 = 0;
        goto Label_037D;
    Label_0178:
        Instance.barracksUpLevel = 4;
        Instance.barracksUpBarbedArmor = 0;
        goto Label_037D;
    Label_0193:
        Instance.magesUpLevel = 0;
        Instance.magesUpSpellReach = 0;
        goto Label_037D;
    Label_01AE:
        Instance.magesUpLevel = 1;
        Instance.magesUpArcaneShatter = 0;
        goto Label_037D;
    Label_01C9:
        Instance.magesUpLevel = 2;
        Instance.magesUpHermeticStudy = 0;
        goto Label_037D;
    Label_01E4:
        Instance.magesUpLevel = 3;
        Instance.magesUpEmpoweredMagic = 0;
        goto Label_037D;
    Label_01FF:
        Instance.magesUpLevel = 4;
        Instance.magesUpSlowCurse = 0;
        goto Label_037D;
    Label_021A:
        Instance.engineersUpLevel = 0;
        Instance.engineersUpConcentratedFire = 0;
        goto Label_037D;
    Label_0235:
        Instance.engineersUpLevel = 1;
        Instance.engineersUpRangeFinder = 0;
        goto Label_037D;
    Label_0250:
        Instance.engineersUpLevel = 2;
        Instance.engineersUpFieldLogistics = 0;
        goto Label_037D;
    Label_026B:
        Instance.engineersUpLevel = 3;
        Instance.engineersUpIndustrialization = 0;
        goto Label_037D;
    Label_0286:
        Instance.engineersUpLevel = 4;
        Instance.engineersUpEfficiency = 0;
        goto Label_037D;
    Label_02A1:
        Instance.rainUpLevel = 0;
        Instance.rainUpBlazingSkies = 0;
        goto Label_037D;
    Label_02BC:
        Instance.rainUpLevel = 1;
        Instance.rainUpScorchedEarth = 0;
        goto Label_037D;
    Label_02D7:
        Instance.rainUpLevel = 2;
        Instance.rainUpBiggerAndMeaner = 0;
        goto Label_037D;
    Label_02F2:
        Instance.rainUpLevel = 3;
        Instance.rainUpBlazingEarth = 0;
        goto Label_037D;
    Label_030D:
        Instance.rainUpLevel = 4;
        Instance.rainUpCataclysm = 0;
        goto Label_037D;
    Label_0328:
        Instance.reinforcementLevel = 0;
        goto Label_037D;
    Label_0338:
        Instance.reinforcementLevel = 1;
        goto Label_037D;
    Label_0348:
        Instance.reinforcementLevel = 2;
        goto Label_037D;
    Label_0358:
        Instance.reinforcementLevel = 3;
        goto Label_037D;
    Label_0368:
        Instance.reinforcementLevel = 4;
        goto Label_037D;
    Label_0378:;
    Label_037D:
        return;
    }

    public static bool ArchersUpEagleEye
    {
        get
        {
            return Instance.archersUpEagleEye;
        }
    }

    public static bool ArchersUpFarShots
    {
        get
        {
            return Instance.archersUpFarShots;
        }
    }

    public static int ArchersUpLevel
    {
        get
        {
            return Instance.archersUpLevel;
        }
    }

    public static bool ArchersUpPiercing
    {
        get
        {
            return Instance.archersUpPiercing;
        }
    }

    public static bool ArchersUpPrecision
    {
        get
        {
            return Instance.archersUpPrecision;
        }
    }

    public static bool ArchersUpSalvage
    {
        get
        {
            return Instance.archersUpSalvage;
        }
    }

    public static bool BarracksUpBarbedArmor
    {
        get
        {
            return Instance.barracksUpBarbedArmor;
        }
    }

    public static bool BarracksUpBetterArmor
    {
        get
        {
            return Instance.barracksUpBetterArmor;
        }
    }

    public static bool BarracksUpImprovedDeployment
    {
        get
        {
            return Instance.barracksUpImprovedDeployment;
        }
    }

    public static int BarracksUpLevel
    {
        get
        {
            return Instance.barracksUpLevel;
        }
    }

    public static bool BarracksUpSurvival
    {
        get
        {
            return Instance.barracksUpSurvival;
        }
    }

    public static bool BarracksUpSurvival2
    {
        get
        {
            return Instance.barracksUpSurvival2;
        }
    }

    public static bool EngineersUpConcentratedFire
    {
        get
        {
            return Instance.engineersUpConcentratedFire;
        }
    }

    public static bool EngineersUpEfficiency
    {
        get
        {
            return Instance.engineersUpEfficiency;
        }
    }

    public static bool EngineersUpFieldLogistics
    {
        get
        {
            return Instance.engineersUpFieldLogistics;
        }
    }

    public static bool EngineersUpIndustrialization
    {
        get
        {
            return Instance.engineersUpIndustrialization;
        }
    }

    public static int EngineersUpLevel
    {
        get
        {
            return Instance.engineersUpLevel;
        }
    }

    public static bool EngineersUpRangeFinder
    {
        get
        {
            return Instance.engineersUpRangeFinder;
        }
    }

    public static bool HeroesEnabled
    {
        get
        {
            return Instance.heroesEnabled;
        }
        set
        {
            Instance.heroesEnabled = value;
            return;
        }
    }

    public static GameUpgrades Instance
    {
        get
        {
            if (instance != null)
            {
                goto Label_0010;
            }
            new GameUpgrades();
        Label_0010:
            return instance;
        }
    }

    public static bool MagesUpArcaneShatter
    {
        get
        {
            return Instance.magesUpArcaneShatter;
        }
    }

    public static int MagesUpArcaneShatterDamage
    {
        get
        {
            return Instance.magesUpArcaneShatterDamage;
        }
    }

    public static bool MagesUpEmpoweredMagic
    {
        get
        {
            return Instance.magesUpEmpoweredMagic;
        }
    }

    public static bool MagesUpHermeticStudy
    {
        get
        {
            return Instance.magesUpHermeticStudy;
        }
    }

    public static int MagesUpLevel
    {
        get
        {
            return Instance.magesUpLevel;
        }
    }

    public static bool MagesUpSlowCurse
    {
        get
        {
            return Instance.magesUpSlowCurse;
        }
    }

    public static bool MagesUpSpellReach
    {
        get
        {
            return Instance.magesUpSpellReach;
        }
    }

    public static bool RainUpBiggerAndMeaner
    {
        get
        {
            return Instance.rainUpBiggerAndMeaner;
        }
    }

    public static bool RainUpBlazingEarth
    {
        get
        {
            return Instance.rainUpBlazingEarth;
        }
    }

    public static bool RainUpBlazingSkies
    {
        get
        {
            return Instance.rainUpBlazingSkies;
        }
    }

    public static bool RainUpCataclysm
    {
        get
        {
            return Instance.rainUpCataclysm;
        }
    }

    public static int RainUpLevel
    {
        get
        {
            return Instance.rainUpLevel;
        }
    }

    public static bool RainUpScorchedEarth
    {
        get
        {
            return Instance.rainUpScorchedEarth;
        }
    }

    public static int ReinforcementLevel
    {
        get
        {
            return Instance.reinforcementLevel;
        }
    }

    public static int SelectedHero
    {
        get
        {
            return Instance.selectedHero;
        }
        set
        {
            Instance.selectedHero = value;
            return;
        }
    }

    public enum heroType
    {
        HERO_ARCHER = 2,
        HERO_DENAS = 7,
        HERO_DWARF = 3,
        HERO_ELORA = 8,
        HERO_HACKSAW = 12,
        HERO_MAGE = 4,
        HERO_PALADIN = 1,
        HERO_RAIN_OF_FIRE = 6,
        HERO_REINFORCEMENT = 5,
        HERO_SAMURAI = 11,
        HERO_THOR = 10,
        HERO_VIKING = 9
    }

    public enum upgradeType
    {
        ARCHER_SALVAGE,
        ARCHER_EAGLE_EYE,
        ARCHER_PIERCING,
        ARCHER_FAR_SHOTS,
        ARCHER_PRECISION,
        BARRACK_SURVIVAL,
        BARRACK_BETTER_ARMOR,
        BARRACK_IMPROVED_DEPLOYMENT,
        BARRACK_BARBED_ARMOR,
        BARRACK_SURVIVAL_2,
        MAGE_SPELL_REACH,
        MAGE_ARCANE_SHATTER,
        MAGE_HERMETIC_STUDY,
        MAGE_EMPOWERED_MAGIC,
        MAGE_SLOW_CURSE,
        ENGINEER_CONCENTRATED_FIRE,
        ENGINEER_RANGE_FINDER,
        ENGINEER_FIELD_LOGISTICS,
        ENGINEER_INDUSTRIALIZATION,
        ENGINEER_EFFICIENCY,
        RAIN_BLAZING_SKIES,
        RAIN_SCORCHED_EARTH,
        RAIN_BIGGER_AND_MEANER,
        RAIN_BLAZING_EARTH,
        RAIN_CATACLYSM,
        REINFORCEMENT_LEVEL_1,
        REINFORCEMENT_LEVEL_2,
        REINFORCEMENT_LEVEL_3,
        REINFORCEMENT_LEVEL_4,
        REINFORCEMENT_LEVEL_5
    }
}

