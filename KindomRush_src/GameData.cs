using System;
using System.Collections;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameData
{
    private aspectRatioEnum aspectRatio;
    private ArrayList bonusLevels;
    private ArrayList campaignLevels;
    private bool challengeTipShowed;
    private int currentLevel;
    private int currentSlot;
    private bool inAppHelpShow;
    private static GameData instance;
    private int lastFlagPlayed;
    public static int LastLevelCompleted;
    private bool levelSelectHelpShowed;
    private int levelToLoad;
    public static bool notificationEnemyBandit;
    public static bool notificationEnemyBossBandit;
    public static bool notificationEnemyBossDemonMoloch;
    public static bool notificationEnemyBossMyconid;
    public static bool notificationEnemyBossTreant;
    public static bool notificationEnemyBrigand;
    public static bool notificationEnemyCerberus;
    public static bool notificationEnemyDarkKnight;
    public static bool notificationEnemyDarkSlayer;
    public static bool notificationEnemyDemon;
    public static bool notificationEnemyDemonImp;
    public static bool notificationEnemyDemonMage;
    public static bool notificationEnemyDemonWolf;
    public static bool notificationEnemyFatOrc;
    public static bool notificationEnemyFlareon;
    public static bool notificationEnemyForestTroll;
    public static bool notificationEnemyGargoyle;
    public static bool notificationEnemyGoblin;
    public static bool notificationEnemyGoblinZapper;
    public static bool notificationEnemyGolemHead;
    public static bool notificationEnemyGulaemon;
    public static bool notificationEnemyGulThak;
    public static bool notificationEnemyJuggernaut;
    public static bool notificationEnemyLavaElemental;
    public static bool notificationEnemyLegion;
    public static bool notificationEnemyMarauder;
    public static bool notificationEnemyNecromancer;
    public static bool notificationEnemyOgre;
    public static bool notificationEnemyOrcArmored;
    public static bool notificationEnemyOrcRider;
    public static bool notificationEnemyPillager;
    public static bool notificationEnemyRaider;
    public static bool notificationEnemyRocketeer;
    public static bool notificationEnemyRottenLesser;
    public static bool notificationEnemyRottenSpider;
    public static bool notificationEnemyRottenTree;
    public static bool notificationEnemySarelgaz;
    public static bool notificationEnemySarelgazSmall;
    public static bool notificationEnemyShadowArcher;
    public static bool notificationEnemyShaman;
    public static bool notificationEnemySkeletor;
    public static bool notificationEnemySkeletorBig;
    public static bool notificationEnemySmallWolf;
    public static bool notificationEnemySpider;
    public static bool notificationEnemySpiderSmall;
    public static bool notificationEnemySwampThing;
    public static bool notificationEnemyTroll;
    public static bool notificationEnemyTrollAxeThrower;
    public static bool notificationEnemyTrollBoss;
    public static bool notificationEnemyTrollBrute;
    public static bool notificationEnemyTrollChieftain;
    public static bool notificationEnemyTrollSkater;
    public static bool notificationEnemyVeznan;
    public static bool notificationEnemyWhiteWolf;
    public static bool notificationEnemyWolf;
    public static bool notificationEnemyYeti;
    public static bool notificationEnemyYetiBoss;
    public static bool notificationEnemyZombie;
    public static bool notificationTipHeroes;
    public static bool notificationTowerArchersLevel2;
    public static bool notificationTowerArchersLevel3;
    public static bool notificationTowerArchersMusketeer;
    public static bool notificationTowerArchersRanger;
    public static bool notificationTowerEngineersBfg;
    public static bool notificationTowerEngineersLevel2;
    public static bool notificationTowerEngineersLevel3;
    public static bool notificationTowerEngineersTesla;
    public static bool notificationTowerMagesArcane;
    public static bool notificationTowerMagesLevel2;
    public static bool notificationTowerMagesLevel3;
    public static bool notificationTowerMagesSorcerer;
    public static bool notificationTowerSoldiersBarbarian;
    public static bool notificationTowerSoldiersLevel2;
    public static bool notificationTowerSoldiersLevel3;
    public static bool notificationTowerSoldiersPaladin;
    private Constants.gameDifficulty selectedDifficulty;
    private Constants.gameMode selectedGameMode;
    private int starsSpent;
    private int starsToSpent;
    private int starsTotal;
    private int starsWon;

    public GameData()
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
        Application.targetFrameRate = 60;
        return;
    }

    public static void AddStarsToSpent(int stars)
    {
        GameData data1;
        data1 = Instance;
        data1.starsToSpent += stars;
        return;
    }

    public static void AddStarsWon(int stars)
    {
        GameData data1;
        data1 = Instance;
        data1.starsWon += stars;
        return;
    }

    private void CreateEmptyData()
    {
        this.starsTotal = 0x69;
        this.starsWon = 0;
        this.starsToSpent = 0;
        this.starsSpent = 0;
        this.challengeTipShowed = 0;
        this.levelSelectHelpShowed = 0;
        this.inAppHelpShow = 0;
        this.lastFlagPlayed = 1;
        this.campaignLevels = new ArrayList();
        this.campaignLevels.Add(new StageData(1, new Vector3(-665f, -264f, -3f)));
        this.campaignLevels.Add(new StageData(2, new Vector3(-618f, -217f, -3f)));
        this.campaignLevels.Add(new StageData(3, new Vector3(-466f, -201f, -3f)));
        this.campaignLevels.Add(new StageData(4, new Vector3(-406f, -120f, -3f)));
        this.campaignLevels.Add(new StageData(5, new Vector3(-718f, 50f, -3f)));
        this.campaignLevels.Add(new StageData(6, new Vector3(-598f, 277f, -3f)));
        this.campaignLevels.Add(new StageData(7, new Vector3(-216f, 352f, -3f)));
        this.campaignLevels.Add(new StageData(8, new Vector3(-102f, 423f, -3f)));
        this.campaignLevels.Add(new StageData(9, new Vector3(132f, 307f, -3f)));
        this.campaignLevels.Add(new StageData(10, new Vector3(562f, 106f, -3f)));
        this.campaignLevels.Add(new StageData(11, new Vector3(754f, 37f, -3f)));
        this.campaignLevels.Add(new StageData(12, new Vector3(744f, -131f, -3f)));
        this.campaignLevels.Add(new StageData(13, new Vector3(-515f, 453f, -3f)));
        this.campaignLevels.Add(new StageData(14, new Vector3(-24f, -96f, -3f)));
        this.campaignLevels.Add(new StageData(15, new Vector3(842f, 276f, -3f)));
        this.campaignLevels.Add(new StageData(0x10, new Vector3(-341f, 233f, -3f)));
        this.campaignLevels.Add(new StageData(0x11, new Vector3(-278f, 203f, -3f)));
        this.campaignLevels.Add(new StageData(0x12, new Vector3(123f, 168f, -3f)));
        this.campaignLevels.Add(new StageData(0x13, new Vector3(204f, 167f, -3f)));
        this.campaignLevels.Add(new StageData(20, new Vector3(831f, -226f, -3f)));
        this.campaignLevels.Add(new StageData(0x15, new Vector3(877f, -162f, -3f)));
        this.ResetNotifications();
        GameAchievements.Reset();
        GameUpgrades.Reset();
        GameUpgrades.SelectedHero = 0;
        GameUpgrades.HeroesEnabled = 1;
        return;
    }

    public static ArrayList GetCampaign()
    {
        return Instance.campaignLevels;
    }

    private ArrayList GetCampaignData()
    {
        return this.campaignLevels;
    }

    public static StageData GetCurrentStageData()
    {
        return (StageData) Instance.campaignLevels[Instance.currentLevel - 1];
    }

    public static Constants.gameMode GetGameMode()
    {
        return Instance.selectedGameMode;
    }

    public static unsafe int GetHeroicWinsForSlot(int slot)
    {
        string str;
        IFormatter formatter;
        FileStream stream;
        SaveGame game;
        FileNotFoundException exception;
        IsolatedStorageException exception2;
        int num;
        if (slot < 1)
        {
            goto Label_000E;
        }
        if (slot <= 3)
        {
            goto Label_0010;
        }
    Label_000E:
        return 0;
    Label_0010:
        str = "slot" + &slot.ToString() + ".data";
    Label_0027:
        try
        {
            formatter = new BinaryFormatter();
            stream = new FileStream(str, 3);
            game = (SaveGame) formatter.Deserialize(stream);
            stream.Close();
            num = game.GetTotalHeroicWins();
            goto Label_0078;
            goto Label_0078;
        }
        catch (FileNotFoundException exception1)
        {
        Label_005A:
            exception = exception1;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
        catch (IsolatedStorageException exception3)
        {
        Label_0069:
            exception2 = exception3;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
    Label_0078:
        return num;
    }

    public static unsafe int GetIronWinsForSlot(int slot)
    {
        string str;
        IFormatter formatter;
        FileStream stream;
        SaveGame game;
        FileNotFoundException exception;
        IsolatedStorageException exception2;
        int num;
        if (slot < 1)
        {
            goto Label_000E;
        }
        if (slot <= 3)
        {
            goto Label_0010;
        }
    Label_000E:
        return 0;
    Label_0010:
        str = "slot" + &slot.ToString() + ".data";
    Label_0027:
        try
        {
            formatter = new BinaryFormatter();
            stream = new FileStream(str, 3);
            game = (SaveGame) formatter.Deserialize(stream);
            stream.Close();
            num = game.GetTotalIronWins();
            goto Label_0078;
            goto Label_0078;
        }
        catch (FileNotFoundException exception1)
        {
        Label_005A:
            exception = exception1;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
        catch (IsolatedStorageException exception3)
        {
        Label_0069:
            exception2 = exception3;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
    Label_0078:
        return num;
    }

    private ArrayList GetNotificationData()
    {
        return null;
    }

    public static unsafe int GetStarsWonForSlot(int slot)
    {
        string str;
        IFormatter formatter;
        FileStream stream;
        SaveGame game;
        FileNotFoundException exception;
        IsolatedStorageException exception2;
        int num;
        if (slot < 1)
        {
            goto Label_000E;
        }
        if (slot <= 3)
        {
            goto Label_0010;
        }
    Label_000E:
        return 0;
    Label_0010:
        str = "slot" + &slot.ToString() + ".data";
    Label_0027:
        try
        {
            formatter = new BinaryFormatter();
            stream = new FileStream(str, 3);
            game = (SaveGame) formatter.Deserialize(stream);
            stream.Close();
            num = game.StarsWon;
            goto Label_0078;
            goto Label_0078;
        }
        catch (FileNotFoundException exception1)
        {
        Label_005A:
            exception = exception1;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
        catch (IsolatedStorageException exception3)
        {
        Label_0069:
            exception2 = exception3;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
    Label_0078:
        return num;
    }

    public static unsafe int GetTotalStarsForSlot(int slot)
    {
        string str;
        IFormatter formatter;
        FileStream stream;
        SaveGame game;
        FileNotFoundException exception;
        IsolatedStorageException exception2;
        int num;
        if (slot < 1)
        {
            goto Label_000E;
        }
        if (slot <= 3)
        {
            goto Label_0010;
        }
    Label_000E:
        return 0;
    Label_0010:
        str = "slot" + &slot.ToString() + ".data";
    Label_0027:
        try
        {
            formatter = new BinaryFormatter();
            stream = new FileStream(str, 3);
            game = (SaveGame) formatter.Deserialize(stream);
            stream.Close();
            num = game.StarsTotal;
            goto Label_0078;
            goto Label_0078;
        }
        catch (FileNotFoundException exception1)
        {
        Label_005A:
            exception = exception1;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
        catch (IsolatedStorageException exception3)
        {
        Label_0069:
            exception2 = exception3;
            num = 0;
            goto Label_0078;
            goto Label_0078;
        }
    Label_0078:
        return num;
    }

    private void Init()
    {
        float num;
        this.campaignLevels = new ArrayList();
        this.bonusLevels = new ArrayList();
        this.selectedGameMode = 0;
        this.lastFlagPlayed = 1;
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_0058;
        }
        Instance.aspectRatio = 0;
        goto Label_0089;
    Label_0058:
        if (Mathf.Abs(num - 1.6f) >= 0.1f)
        {
            goto Label_007E;
        }
        Instance.aspectRatio = 2;
        goto Label_0089;
    Label_007E:
        Instance.aspectRatio = 1;
    Label_0089:
        return;
    }

    public static unsafe bool IsSlotUsed(int num)
    {
        string str;
        IFormatter formatter;
        FileStream stream;
        FileNotFoundException exception;
        IsolatedStorageException exception2;
        bool flag;
        if (num < 1)
        {
            goto Label_000E;
        }
        if (num <= 3)
        {
            goto Label_0010;
        }
    Label_000E:
        return 0;
    Label_0010:
        str = "slot" + &num.ToString() + ".data";
    Label_0027:
        try
        {
            formatter = new BinaryFormatter();
            stream = new FileStream(str, 3);
            stream.Close();
            flag = 1;
            goto Label_0065;
            goto Label_0065;
        }
        catch (FileNotFoundException exception1)
        {
        Label_0048:
            exception = exception1;
            flag = 0;
            goto Label_0065;
            goto Label_0065;
        }
        catch (IsolatedStorageException exception3)
        {
        Label_0056:
            exception2 = exception3;
            flag = 0;
            goto Label_0065;
            goto Label_0065;
        }
    Label_0065:
        return flag;
    }

    public static bool IsStageCompleted(int stageIndex)
    {
        if (((StageData) Instance.campaignLevels[stageIndex - 1]).Status == 3)
        {
            goto Label_0066;
        }
        if (((StageData) Instance.campaignLevels[stageIndex - 1]).Status == 5)
        {
            goto Label_0066;
        }
        if (((StageData) Instance.campaignLevels[stageIndex - 1]).Status != 4)
        {
            goto Label_0068;
        }
    Label_0066:
        return 1;
    Label_0068:
        return 0;
    }

    public static unsafe void LoadGameData()
    {
        IFormatter formatter;
        FileStream stream;
        SaveGame game;
        FileNotFoundException exception;
        IsolatedStorageException exception2;
        Instance.LoadGlobalData();
        Instance.CreateEmptyData();
        ((StageData) instance.campaignLevels[0]).Status = 1;
        formatter = new BinaryFormatter();
        stream = null;
    Label_0037:
        try
        {
            stream = new FileStream("slot" + &Instance.currentSlot.ToString() + ".data", 3);
            game = (SaveGame) formatter.Deserialize(stream);
            stream.Close();
            SetCampaignData(game.CampaignLevels);
            if (game.StarsTotal >= 0x69)
            {
                goto Label_0098;
            }
            Instance.starsTotal = 0x69;
            goto Label_00A8;
        Label_0098:
            Instance.starsTotal = game.StarsTotal;
        Label_00A8:
            Instance.starsWon = game.StarsWon;
            Instance.starsToSpent = game.StarsToSpent;
            Instance.starsSpent = game.StarsSpent;
            Instance.challengeTipShowed = game.ChallengeTipShowed;
            Instance.levelSelectHelpShowed = game.LevelSelectHelpShowed;
            Instance.inAppHelpShow = game.InAppHelpShow;
            GameUpgrades.LoadFromSave(game);
            GameAchievements.LoadFromSave(game);
            Instance.LoadNotificationsFromSave(game);
            GameSoundManager.SetVolumeFx(game.SoundFxVolume);
            GameSoundManager.SetVolumeMusic(game.SoundMusicVolume);
            goto Label_0151;
        }
        catch (FileNotFoundException exception1)
        {
        Label_013A:
            exception = exception1;
            goto Label_0151;
        }
        catch (IsolatedStorageException exception3)
        {
        Label_0140:
            exception2 = exception3;
            Debug.Log("Error when creating save game.");
            goto Label_0151;
        }
    Label_0151:
        return;
    }

    private void LoadGlobalData()
    {
    }

    private void LoadNotificationsFromSave(SaveGame save)
    {
        notificationTowerArchersLevel2 = save.NotificationTowerArchersLevel2;
        notificationTowerArchersLevel3 = save.NotificationTowerArchersLevel3;
        notificationTowerArchersRanger = save.NotificationTowerArchersRanger;
        notificationTowerArchersMusketeer = save.NotificationTowerArchersMusketeer;
        notificationTowerSoldiersLevel2 = save.NotificationTowerSoldiersLevel2;
        notificationTowerSoldiersLevel3 = save.NotificationTowerSoldiersLevel3;
        notificationTowerSoldiersPaladin = save.NotificationTowerSoldiersPaladin;
        notificationTowerSoldiersBarbarian = save.NotificationTowerSoldiersBarbarian;
        notificationTowerMagesLevel2 = save.NotificationTowerMagesLevel2;
        notificationTowerMagesLevel3 = save.NotificationTowerMagesLevel3;
        notificationTowerMagesArcane = save.NotificationTowerMagesArcane;
        notificationTowerMagesSorcerer = save.NotificationTowerMagesSorcerer;
        notificationTowerEngineersLevel2 = save.NotificationTowerEngineersLevel2;
        notificationTowerEngineersLevel3 = save.NotificationTowerEngineersLevel3;
        notificationTowerEngineersBfg = save.NotificationTowerEngineersBfg;
        notificationTowerEngineersTesla = save.NotificationTowerEngineersTesla;
        notificationEnemyGoblin = save.NotificationEnemyGoblin;
        notificationEnemyFatOrc = save.NotificationEnemyFatOrc;
        notificationEnemyShaman = save.NotificationEnemyShaman;
        notificationEnemyOgre = save.NotificationEnemyOgre;
        notificationEnemyBandit = save.NotificationEnemyBandit;
        notificationEnemyBrigand = save.NotificationEnemyBrigand;
        notificationEnemyMarauder = save.NotificationEnemyMarauder;
        notificationEnemySpider = save.NotificationEnemySpider;
        notificationEnemySpiderSmall = save.NotificationEnemySpiderSmall;
        notificationEnemyGargoyle = save.NotificationEnemyGargoyle;
        notificationEnemyShadowArcher = save.NotificationEnemyShadowArcher;
        notificationEnemyDarkKnight = save.NotificationEnemyDarkKnight;
        notificationEnemySmallWolf = save.NotificationEnemySmallWolf;
        notificationEnemyWolf = save.NotificationEnemyWolf;
        notificationEnemyGolemHead = save.NotificationEnemyGolemHead;
        notificationEnemyWhiteWolf = save.NotificationEnemyWhiteWolf;
        notificationEnemyTroll = save.NotificationEnemyTroll;
        notificationEnemyTrollAxeThrower = save.NotificationEnemyTrollAxeThrower;
        notificationEnemyTrollChieftain = save.NotificationEnemyTrollChieftain;
        notificationEnemyYeti = save.NotificationEnemyYeti;
        notificationEnemyRocketeer = save.NotificationEnemyRocketeer;
        notificationEnemyDarkSlayer = save.NotificationEnemyDarkSlayer;
        notificationEnemyDemon = save.NotificationEnemyDemon;
        notificationEnemyDemonMage = save.NotificationEnemyDemonMage;
        notificationEnemyDemonWolf = save.NotificationEnemyDemonWolf;
        notificationEnemyDemonImp = save.NotificationEnemyDemonImp;
        notificationEnemyNecromancer = save.NotificationEnemyNecromancer;
        notificationEnemySkeletor = save.NotificationEnemySkeletor;
        notificationEnemySkeletorBig = save.NotificationEnemySkeletorBig;
        notificationEnemyLavaElemental = save.NotificationEnemyLavaElemental;
        notificationEnemyJuggernaut = save.NotificationEnemyJuggernaut;
        notificationEnemyYetiBoss = save.NotificationEnemyYetiBoss;
        notificationEnemyVeznan = save.NotificationEnemyVeznan;
        notificationEnemySarelgaz = save.NotificationEnemySarelgaz;
        notificationEnemySarelgazSmall = save.NotificationEnemySarelgazSmall;
        notificationEnemyGoblinZapper = save.NotificationEnemyGoblinZapper;
        notificationEnemyOrcRider = save.NotificationEnemyOrcRider;
        notificationEnemyOrcArmored = save.NotificationEnemyOrcArmored;
        notificationEnemyForestTroll = save.NotificationEnemyForestTroll;
        notificationEnemyGulThak = save.NotificationEnemyGulThak;
        notificationEnemyZombie = save.NotificationEnemyZombie;
        notificationEnemyRottenSpider = save.NotificationEnemyRottenSpider;
        notificationEnemyRottenTree = save.NotificationEnemyRottenTree;
        notificationEnemySwampThing = save.NotificationEnemySwampThing;
        notificationEnemyBossTreant = save.NotificationEnemyBossTreant;
        notificationTipHeroes = save.NotificationTipHeroes;
        notificationEnemyRaider = save.NotificationEnemyRaider;
        notificationEnemyPillager = save.NotificationEnemyPillager;
        notificationEnemyBossBandit = save.NotificationEnemyBossBandit;
        notificationEnemyTrollSkater = save.NotificationEnemyTrollSkater;
        notificationEnemyTrollBrute = save.NotificationEnemyTrollBrute;
        notificationEnemyTrollBoss = save.NotificationEnemyTrollBoss;
        notificationEnemyCerberus = save.NotificationEnemyCerberus;
        notificationEnemyLegion = save.NotificationEnemyLegion;
        notificationEnemyFlareon = save.NotificationEnemyFlareon;
        notificationEnemyGulaemon = save.NotificationEnemyGulaemon;
        notificationEnemyRottenLesser = save.NotificationEnemyRottenLesser;
        notificationEnemyBossDemonMoloch = save.NotificationEnemyBossDemonMoloch;
        notificationEnemyBossMyconid = save.NotificationEnemyBossMyconid;
        return;
    }

    private void ResetNotifications()
    {
        notificationTowerArchersLevel2 = 0;
        notificationTowerArchersLevel3 = 0;
        notificationTowerArchersRanger = 0;
        notificationTowerArchersMusketeer = 0;
        notificationTowerSoldiersLevel2 = 0;
        notificationTowerSoldiersLevel3 = 0;
        notificationTowerSoldiersPaladin = 0;
        notificationTowerSoldiersBarbarian = 0;
        notificationTowerMagesLevel2 = 0;
        notificationTowerMagesLevel3 = 0;
        notificationTowerMagesArcane = 0;
        notificationTowerMagesSorcerer = 0;
        notificationTowerEngineersLevel2 = 0;
        notificationTowerEngineersLevel3 = 0;
        notificationTowerEngineersBfg = 0;
        notificationTowerEngineersTesla = 0;
        notificationEnemyGoblin = 0;
        notificationEnemyFatOrc = 0;
        notificationEnemyShaman = 0;
        notificationEnemyOgre = 0;
        notificationEnemyBandit = 0;
        notificationEnemyBrigand = 0;
        notificationEnemyMarauder = 0;
        notificationEnemySpider = 0;
        notificationEnemySpiderSmall = 0;
        notificationEnemyGargoyle = 0;
        notificationEnemyShadowArcher = 0;
        notificationEnemyDarkKnight = 0;
        notificationEnemySmallWolf = 0;
        notificationEnemyWolf = 0;
        notificationEnemyGolemHead = 0;
        notificationEnemyWhiteWolf = 0;
        notificationEnemyTroll = 0;
        notificationEnemyTrollAxeThrower = 0;
        notificationEnemyTrollChieftain = 0;
        notificationEnemyYeti = 0;
        notificationEnemyRocketeer = 0;
        notificationEnemyDarkSlayer = 0;
        notificationEnemyDemon = 0;
        notificationEnemyDemonMage = 0;
        notificationEnemyDemonWolf = 0;
        notificationEnemyDemonImp = 0;
        notificationEnemyNecromancer = 0;
        notificationEnemySkeletor = 0;
        notificationEnemySkeletorBig = 0;
        notificationEnemyLavaElemental = 0;
        notificationEnemyJuggernaut = 0;
        notificationEnemyYetiBoss = 0;
        notificationEnemyVeznan = 0;
        notificationEnemySarelgaz = 0;
        notificationEnemySarelgazSmall = 0;
        notificationEnemyGoblinZapper = 0;
        notificationEnemyOrcRider = 0;
        notificationEnemyOrcArmored = 0;
        notificationEnemyForestTroll = 0;
        notificationEnemyGulThak = 0;
        notificationEnemyZombie = 0;
        notificationEnemyRottenSpider = 0;
        notificationEnemyRottenTree = 0;
        notificationEnemySwampThing = 0;
        notificationEnemyBossTreant = 0;
        notificationEnemyRaider = 0;
        notificationEnemyPillager = 0;
        notificationEnemyBossBandit = 0;
        notificationTipHeroes = 0;
        notificationEnemyTrollSkater = 0;
        notificationEnemyTrollBrute = 0;
        notificationEnemyTrollBoss = 0;
        notificationEnemyCerberus = 0;
        notificationEnemyLegion = 0;
        notificationEnemyFlareon = 0;
        notificationEnemyGulaemon = 0;
        notificationEnemyRottenLesser = 0;
        notificationEnemyBossDemonMoloch = 0;
        notificationEnemyBossMyconid = 0;
        return;
    }

    public static unsafe void SaveGameData()
    {
        SaveGame game;
        IFormatter formatter;
        FileStream stream;
        game = new SaveGame();
        game.LoadUpgrades();
        game.LoadGameData();
        game.LoadNotifications();
        game.LoadAchievements();
        game.LoadSoundSettings();
        formatter = new BinaryFormatter();
        stream = new FileStream("slot" + &Instance.currentSlot.ToString() + ".data", 2);
        formatter.Serialize(stream, game);
        stream.Close();
        return;
    }

    public static Constants.gameDifficulty SelectedDifficulty()
    {
        return Instance.selectedDifficulty;
    }

    private static void SetCampaignData(ArrayList myCampaignData)
    {
        int num;
        StageData data;
        IEnumerator enumerator;
        IDisposable disposable;
        num = 0;
        enumerator = Instance.campaignLevels.GetEnumerator();
    Label_0012:
        try
        {
            goto Label_0154;
        Label_0017:
            data = (StageData) enumerator.Current;
            if ((num + 1) <= myCampaignData.Count)
            {
                goto Label_003C;
            }
            SetEmptyLevel(num);
            goto Label_0150;
        Label_003C:
            data.CampaignWin = ((StageData) myCampaignData[num]).CampaignWin;
            data.HeroicModeWin = ((StageData) myCampaignData[num]).HeroicModeWin;
            data.IronModeWin = ((StageData) myCampaignData[num]).IronModeWin;
            data.HeroicModeRecentlyWon = ((StageData) myCampaignData[num]).HeroicModeRecentlyWon;
            data.IronModeRecentlyWon = ((StageData) myCampaignData[num]).IronModeRecentlyWon;
            data.CampaignDifficulty = ((StageData) myCampaignData[num]).CampaignDifficulty;
            data.HeroicDifficulty = ((StageData) myCampaignData[num]).HeroicDifficulty;
            data.IronDifficulty = ((StageData) myCampaignData[num]).IronDifficulty;
            data.StarsWon = ((StageData) myCampaignData[num]).StarsWon;
            data.StarsLastMatch = ((StageData) myCampaignData[num]).StarsLastMatch;
            data.ExtraModesView = ((StageData) myCampaignData[num]).ExtraModesView;
            data.Status = ((StageData) myCampaignData[num]).Status;
        Label_0150:
            num += 1;
        Label_0154:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0017;
            }
            goto Label_0176;
        }
        finally
        {
        Label_0164:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_016F;
            }
        Label_016F:
            disposable.Dispose();
        }
    Label_0176:
        if (((StageData) Instance.campaignLevels[11]).Status == 3)
        {
            goto Label_01D9;
        }
        if (((StageData) Instance.campaignLevels[11]).Status == 5)
        {
            goto Label_01D9;
        }
        if (((StageData) Instance.campaignLevels[11]).Status != 4)
        {
            goto Label_0341;
        }
    Label_01D9:
        if (((StageData) Instance.campaignLevels[12]).Status != null)
        {
            goto Label_0215;
        }
        ((StageData) Instance.campaignLevels[12]).Status = 2;
    Label_0215:
        if (((StageData) Instance.campaignLevels[13]).Status != null)
        {
            goto Label_0251;
        }
        ((StageData) Instance.campaignLevels[13]).Status = 2;
    Label_0251:
        if (((StageData) Instance.campaignLevels[14]).Status != null)
        {
            goto Label_028D;
        }
        ((StageData) Instance.campaignLevels[14]).Status = 2;
    Label_028D:
        if (((StageData) Instance.campaignLevels[15]).Status != null)
        {
            goto Label_02C9;
        }
        ((StageData) Instance.campaignLevels[15]).Status = 2;
    Label_02C9:
        if (((StageData) Instance.campaignLevels[0x11]).Status != null)
        {
            goto Label_0305;
        }
        ((StageData) Instance.campaignLevels[0x11]).Status = 2;
    Label_0305:
        if (((StageData) Instance.campaignLevels[0x13]).Status != null)
        {
            goto Label_0341;
        }
        ((StageData) Instance.campaignLevels[0x13]).Status = 2;
    Label_0341:
        if (((StageData) Instance.campaignLevels[15]).Status == 3)
        {
            goto Label_03A4;
        }
        if (((StageData) Instance.campaignLevels[15]).Status == 5)
        {
            goto Label_03A4;
        }
        if (((StageData) Instance.campaignLevels[15]).Status != 4)
        {
            goto Label_03E0;
        }
    Label_03A4:
        if (((StageData) Instance.campaignLevels[0x10]).Status != null)
        {
            goto Label_03E0;
        }
        ((StageData) Instance.campaignLevels[0x10]).Status = 2;
    Label_03E0:
        if (((StageData) Instance.campaignLevels[0x11]).Status == 3)
        {
            goto Label_0443;
        }
        if (((StageData) Instance.campaignLevels[0x11]).Status == 5)
        {
            goto Label_0443;
        }
        if (((StageData) Instance.campaignLevels[0x11]).Status != 4)
        {
            goto Label_047F;
        }
    Label_0443:
        if (((StageData) Instance.campaignLevels[0x12]).Status != null)
        {
            goto Label_047F;
        }
        ((StageData) Instance.campaignLevels[0x12]).Status = 2;
    Label_047F:
        if (((StageData) Instance.campaignLevels[0x13]).Status == 3)
        {
            goto Label_04E2;
        }
        if (((StageData) Instance.campaignLevels[0x13]).Status == 5)
        {
            goto Label_04E2;
        }
        if (((StageData) Instance.campaignLevels[0x13]).Status != 4)
        {
            goto Label_051E;
        }
    Label_04E2:
        if (((StageData) Instance.campaignLevels[20]).Status != null)
        {
            goto Label_051E;
        }
        ((StageData) Instance.campaignLevels[20]).Status = 2;
    Label_051E:
        return;
    }

    public static void SetCurrentStage(int i)
    {
        instance.currentLevel = i;
        return;
    }

    private static void SetEmptyLevel(int index)
    {
        if (((StageData) Instance.campaignLevels[11]).Status == 3)
        {
            goto Label_0063;
        }
        if (((StageData) Instance.campaignLevels[11]).Status == 5)
        {
            goto Label_0063;
        }
        if (((StageData) Instance.campaignLevels[11]).Status != 4)
        {
            goto Label_007E;
        }
    Label_0063:
        ((StageData) Instance.campaignLevels[index]).Status = 2;
    Label_007E:
        return;
    }

    public static void SetGameMode(Constants.gameMode mode)
    {
        Instance.selectedGameMode = mode;
        return;
    }

    private void SetNotificationData(ArrayList myData)
    {
    }

    public static aspectRatioEnum AspectRatio
    {
        get
        {
            return Instance.aspectRatio;
        }
        set
        {
            Instance.aspectRatio = value;
            return;
        }
    }

    public static bool ChallengeTipShowed
    {
        get
        {
            return Instance.challengeTipShowed;
        }
    }

    public static int CurrentSlot
    {
        set
        {
            Instance.currentSlot = value;
            return;
        }
    }

    public static bool InAppHelpShow
    {
        get
        {
            return Instance.inAppHelpShow;
        }
    }

    public static GameData Instance
    {
        get
        {
            if (instance != null)
            {
                goto Label_0010;
            }
            new GameData();
        Label_0010:
            return instance;
        }
    }

    public static bool LevelSelectHelpShowed
    {
        get
        {
            return Instance.levelSelectHelpShowed;
        }
    }

    public static int LevelToLoad
    {
        get
        {
            return Instance.levelToLoad;
        }
        set
        {
            Instance.levelToLoad = value;
            return;
        }
    }

    public static int StarsSpent
    {
        get
        {
            return Instance.starsSpent;
        }
        set
        {
            Instance.starsSpent = value;
            return;
        }
    }

    public static int StarsToSpent
    {
        get
        {
            return Instance.starsToSpent;
        }
        set
        {
            Instance.starsToSpent = value;
            return;
        }
    }

    public static int StarsTotal
    {
        get
        {
            return Instance.starsTotal;
        }
        set
        {
            Instance.starsTotal = value;
            return;
        }
    }

    public static int StarsWon
    {
        get
        {
            return Instance.starsWon;
        }
        set
        {
            Instance.starsWon = value;
            return;
        }
    }

    public enum aspectRatioEnum
    {
        ASPECT4BY3,
        ASPECT16BY9,
        ASPECT16BY10
    }
}

