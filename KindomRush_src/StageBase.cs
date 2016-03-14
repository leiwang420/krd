using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class StageBase : MonoBehaviour
{
    protected ArrayList activeWaves;
    protected Camera camera;
    protected bool canUseHeroes;
    protected int currentGold;
    public int currentLives;
    protected int currentWave;
    public Transform defeatScreenPrefab;
    protected Vector2 defendPoint;
    protected Vector2[] defendPoints;
    protected Transform effectsContainer;
    protected int elementals;
    protected Creep[] enemies;
    protected Transform explosionContainer;
    protected bool fearless;
    protected int fireballCounter;
    protected bool firstWaveSign;
    protected ArrayList flags;
    protected Vector3[][] flagsPositions;
    protected Vector3[][] flagsPositions1610;
    protected Vector3[][] flagsPositions43;
    protected GameGui gui;
    protected GUIBottom guiBottom;
    protected bool hasIce;
    protected bool hasTunnels;
    protected SoldierHero hero;
    private HeroPortrait heroPortrait;
    private Transform heroPortraitPrefab;
    protected bool heroTipShowed;
    protected Transform hud;
    protected int[][] ice;
    protected int indexWaves;
    protected int intervalWaveCounter;
    protected bool isHeroAdded;
    protected bool isReadyToWin;
    protected int maxUpgradeLevel;
    protected int maxWaves;
    protected AudioSource musicBattle;
    protected AudioSource musicPreparation;
    protected NextWaveButton nextWaveButton;
    protected PackedSprite overlayPause;
    protected Vector2[][][] path;
    protected AStar pathFinder;
    protected Transform pauseButton;
    protected PowerFireballPortrait powerFireball;
    protected PowerReinforcementPortrait powerReinforcement;
    protected int preWinTime;
    protected int preWinTimeCounter;
    protected Transform projectilesContainer;
    protected Quickmenu quickmenu;
    protected Transform rallyError;
    protected Transform rallyOk;
    protected int readyToWinTime;
    protected int readyToWinTimeCounter;
    protected Transform reinforceContainer;
    protected int sellTowersCounter;
    protected ArrayList soldiers;
    protected CreepSpawner spawner;
    protected states status;
    protected terrainType terrain;
    protected int teslas;
    protected int[][] tunnels;
    protected Dictionary<string, bool> unlockedTowers;
    public Transform victoryNormalPrefab;
    protected bool waveCalled;
    private bool waveCalledThisFrame;
    private bool waveRecentlyCalled;
    protected Wave[] waves;
    public Transform waveSpawnFlagPrefab;
    public Transform waveSpawnFlyFlagPrefab;

    protected StageBase()
    {
        this.activeWaves = new ArrayList();
        this.readyToWinTime = 30;
        this.defendPoint = Vector2.zero;
        base..ctor();
        return;
    }

    public void AddEffect(Transform eff)
    {
        eff.parent = this.effectsContainer;
        return;
    }

    public void AddElementalAchievement()
    {
        this.elementals += 1;
        if (this.elementals != 5)
        {
            goto Label_001F;
        }
        GameAchievements.EvalElentalist();
    Label_001F:
        return;
    }

    public void AddExplosion(Transform exp)
    {
        exp.parent = this.explosionContainer;
        return;
    }

    public void AddFireballAchievement()
    {
        this.fireballCounter += 1;
        if (this.fireballCounter != 5)
        {
            goto Label_001F;
        }
        GameAchievements.CheckArmaggedon();
    Label_001F:
        return;
    }

    public void AddGold(int gold)
    {
        this.currentGold += gold;
        return;
    }

    public void AddProjectile(Transform p)
    {
        p.parent = this.projectilesContainer;
        return;
    }

    public void AddReinforce(Transform r)
    {
        r.parent = this.reinforceContainer;
        return;
    }

    public void AddSellTowerAchievement()
    {
        this.sellTowersCounter += 1;
        if (this.sellTowersCounter != 5)
        {
            goto Label_001F;
        }
        GameAchievements.DoIndecisive();
    Label_001F:
        GameAchievements.SellTower();
        return;
    }

    public void AddSoldier(Soldier s)
    {
        if (this.soldiers != null)
        {
            goto Label_0016;
        }
        this.soldiers = new ArrayList();
    Label_0016:
        this.soldiers.Add(s);
        return;
    }

    public void AddTeslaAchievement()
    {
        this.teslas += 1;
        if (this.teslas != 4)
        {
            goto Label_001F;
        }
        GameAchievements.EvalEnergyNetwork();
    Label_001F:
        return;
    }

    protected virtual void AfterNextWaveFlagShow()
    {
    }

    protected virtual void AfterNextWaveStart()
    {
    }

    protected void Awake()
    {
        this.gui = base.gameObject.AddComponent<GameGui>();
        this.musicPreparation = base.transform.FindChild("Music Preparation").GetComponent<AudioSource>();
        this.musicBattle = base.transform.FindChild("Music Battle").GetComponent<AudioSource>();
        this.musicPreparation.volume = 1f * GameSoundManager.GetVolumeMusic();
        this.musicBattle.volume = 1f * GameSoundManager.GetVolumeMusic();
        this.musicPreparation.Play();
        return;
    }

    public unsafe bool CanBuildTower(string tower)
    {
        bool flag;
        this.unlockedTowers.TryGetValue(tower, &flag);
        return flag;
    }

    protected unsafe bool CheckHeroPortraitClick()
    {
        RaycastHit hit;
        UnityEngine.Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return this.heroPortrait.collider.Raycast(ray, &hit, 1000f);
    }

    protected void CheckLevelAchievements()
    {
        if (this.fearless == null)
        {
            goto Label_001C;
        }
        if (this.maxWaves <= 1)
        {
            goto Label_001C;
        }
        GameAchievements.DoFearless();
    Label_001C:
        this.CheckLevelSpecialAchievements();
        return;
    }

    protected virtual void checkLevelSpecialAchievements()
    {
    }

    protected virtual void CheckLevelSpecialAchievements()
    {
    }

    public unsafe bool CheckWaveFlagClick()
    {
        RaycastHit hit;
        UnityEngine.Ray ray;
        Transform transform;
        IEnumerator enumerator;
        WaveSpawnFlag flag;
        bool flag2;
        IDisposable disposable;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        enumerator = this.flags.GetEnumerator();
    Label_001C:
        try
        {
            goto Label_0056;
        Label_0021:
            transform = (Transform) enumerator.Current;
            if (transform.GetComponent<WaveSpawnFlag>().collider.Raycast(ray, &hit, 1000f) == null)
            {
                goto Label_0056;
            }
            flag2 = 1;
            goto Label_007D;
        Label_0056:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0021;
            }
            goto Label_007B;
        }
        finally
        {
        Label_0066:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0073;
            }
        Label_0073:
            disposable.Dispose();
        }
    Label_007B:
        return 0;
    Label_007D:
        return flag2;
    }

    public void DestroyFlags()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.flags.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0028;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<WaveSpawnFlag>().KillFlag();
        Label_0028:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004A;
        }
        finally
        {
        Label_0038:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0043;
            }
        Label_0043:
            disposable.Dispose();
        }
    Label_004A:
        this.flags.Clear();
        return;
    }

    protected void DisableDecos()
    {
        Transform transform;
        Transform transform2;
        IEnumerator enumerator;
        IDisposable disposable;
        transform = base.transform.FindChild("Decos");
        if ((transform != null) == null)
        {
            goto Label_00B7;
        }
        enumerator = transform.GetEnumerator();
    Label_0024:
        try
        {
            goto Label_0095;
        Label_0029:
            transform2 = (Transform) enumerator.Current;
            if ((transform2.name == "SheepBig") != null)
            {
                goto Label_0089;
            }
            if ((transform2.name == "SheepSmall") != null)
            {
                goto Label_0089;
            }
            if ((transform2.name == "GoatFlip") != null)
            {
                goto Label_0089;
            }
            if ((transform2.name == "Goat") == null)
            {
                goto Label_0095;
            }
        Label_0089:
            transform2.collider.enabled = 0;
        Label_0095:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0029;
            }
            goto Label_00B7;
        }
        finally
        {
        Label_00A5:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B0;
            }
        Label_00B0:
            disposable.Dispose();
        }
    Label_00B7:
        return;
    }

    protected void DisableFlags()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.flags.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0029;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.gameObject.layer = 2;
        Label_0029:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004B;
        }
        finally
        {
        Label_0039:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0044;
            }
        Label_0044:
            disposable.Dispose();
        }
    Label_004B:
        return;
    }

    protected void DisableGUI()
    {
        this.guiBottom.gameObject.SetActive(0);
        if ((this.heroPortrait != null) == null)
        {
            goto Label_0033;
        }
        this.heroPortrait.gameObject.SetActive(0);
    Label_0033:
        this.pauseButton.parent.gameObject.SetActive(0);
        this.hud.gameObject.SetActive(0);
        return;
    }

    public void DisableHero()
    {
        if ((this.hero != null) == null)
        {
            goto Label_002E;
        }
        this.hero.gameObject.layer = 2;
        this.hero.enabled = 0;
    Label_002E:
        return;
    }

    public void DisableNextWaveButton()
    {
        this.nextWaveButton.Disable();
        return;
    }

    protected void DisablePauseButton()
    {
        this.pauseButton.gameObject.layer = 2;
        return;
    }

    public virtual void DisablePowers()
    {
        this.guiBottom.SetPowerReinforcementActive(0);
        this.guiBottom.SetPowerFireballActive(0);
        return;
    }

    public void DisableTowers()
    {
        Clickable[] clickableArray;
        Clickable clickable;
        Clickable[] clickableArray2;
        int num;
        clickableArray = UnityEngine.Object.FindObjectsOfType(typeof(Clickable)) as Clickable[];
        clickableArray2 = clickableArray;
        num = 0;
        goto Label_004E;
    Label_001E:
        clickable = clickableArray2[num];
        if ((clickable.name != "Quickmenu") == null)
        {
            goto Label_004A;
        }
        clickable.enabled = 0;
        clickable.gameObject.layer = 2;
    Label_004A:
        num += 1;
    Label_004E:
        if (num < ((int) clickableArray2.Length))
        {
            goto Label_001E;
        }
        return;
    }

    public void EnableFlags()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.flags.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_002A;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.gameObject.layer = 9;
        Label_002A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004C;
        }
        finally
        {
        Label_003A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0045;
            }
        Label_0045:
            disposable.Dispose();
        }
    Label_004C:
        return;
    }

    public void EnableHero()
    {
        if ((this.hero != null) == null)
        {
            goto Label_0023;
        }
        this.hero.gameObject.layer = 9;
    Label_0023:
        return;
    }

    protected void EnableNextWaveButton()
    {
        this.nextWaveButton.Enable();
        return;
    }

    public void EnablePower(Constants.notificationType p)
    {
        Constants.notificationType type;
        type = p;
        if (type == 2)
        {
            goto Label_0025;
        }
        if (type == 3)
        {
            goto Label_0015;
        }
        goto Label_0035;
    Label_0015:
        this.powerFireball.Open();
        goto Label_003A;
    Label_0025:
        this.powerReinforcement.Open();
        goto Label_003A;
    Label_0035:;
    Label_003A:
        return;
    }

    public void EnableTowers()
    {
        Clickable[] clickableArray;
        Clickable clickable;
        Clickable[] clickableArray2;
        int num;
        clickableArray = UnityEngine.Object.FindObjectsOfType(typeof(Clickable)) as Clickable[];
        clickableArray2 = clickableArray;
        num = 0;
        goto Label_003A;
    Label_001E:
        clickable = clickableArray2[num];
        clickable.enabled = 1;
        clickable.gameObject.layer = 9;
        num += 1;
    Label_003A:
        if (num < ((int) clickableArray2.Length))
        {
            goto Label_001E;
        }
        return;
    }

    public unsafe void EnterTunnel(int pathIndex)
    {
        Transform transform;
        *((int*) &(this.tunnels[pathIndex][5])) += 1;
        if (this.tunnels[pathIndex][5] != 1)
        {
            goto Label_0088;
        }
        if (pathIndex != 1)
        {
            goto Label_0058;
        }
        transform = base.transform.FindChild("Glow1");
        if ((transform != null) == null)
        {
            goto Label_0088;
        }
        transform.gameObject.SetActive(1);
        goto Label_0088;
    Label_0058:
        if (pathIndex != 2)
        {
            goto Label_0088;
        }
        transform = base.transform.FindChild("Glow2");
        if ((transform != null) == null)
        {
            goto Label_0088;
        }
        transform.gameObject.SetActive(1);
    Label_0088:
        return;
    }

    public virtual void EscapePause()
    {
        if (this.status == 4)
        {
            goto Label_0021;
        }
        this.pauseButton.GetComponent<PauseButton>().Pause();
        goto Label_0033;
    Label_0021:
        this.pauseButton.GetComponent<PauseButton>().UnPause(1, 1);
    Label_0033:
        return;
    }

    public unsafe void ExitTunnel(int pathIndex)
    {
        Transform transform;
        *((int*) &(this.tunnels[pathIndex][5])) -= 1;
        if (this.tunnels[pathIndex][5] != null)
        {
            goto Label_0087;
        }
        if (pathIndex != 1)
        {
            goto Label_0057;
        }
        transform = base.transform.FindChild("Glow1");
        if ((transform != null) == null)
        {
            goto Label_0087;
        }
        transform.gameObject.SetActive(0);
        goto Label_0087;
    Label_0057:
        if (pathIndex != 2)
        {
            goto Label_0087;
        }
        transform = base.transform.FindChild("Glow2");
        if ((transform != null) == null)
        {
            goto Label_0087;
        }
        transform.gameObject.SetActive(0);
    Label_0087:
        return;
    }

    public unsafe int FindNearestNodeInPath(int pathIndex, int subPath, Vector3 position)
    {
        int num;
        int num2;
        int num3;
        Vector2[] vectorArray;
        int num4;
        Vector2 vector;
        num = 0x7fffffff;
        num2 = 0;
        num3 = 0;
        vectorArray = this.path[pathIndex][subPath];
        num4 = 0;
        goto Label_008A;
    Label_001D:
        if (this.IsIlegal(pathIndex, num4) != null)
        {
            goto Label_0084;
        }
        vector = *(&(vectorArray[num4]));
        float introduced6 = Mathf.Pow(&vector.y - &position.y, 2f);
        num3 = Mathf.RoundToInt(Mathf.Sqrt(introduced6 + Mathf.Pow(&vector.x - &position.x, 2f)));
        if (num3 >= num)
        {
            goto Label_0084;
        }
        num = num3;
        num2 = num4;
    Label_0084:
        num4 += 1;
    Label_008A:
        if (num4 < ((int) vectorArray.Length))
        {
            goto Label_001D;
        }
        return num2;
    }

    public Vector3 FindNearestNodeToPosition(Vector3 position)
    {
        int num;
        num = 0x7fffffff;
        return this.FindNearestNodeToPosition(position, (float) num);
    }

    public unsafe Vector3 FindNearestNodeToPosition(Vector3 position, float minDistance)
    {
        int num;
        Vector3 vector;
        int num2;
        int num3;
        Vector2[] vectorArray;
        int num4;
        Vector2 vector2;
        &vector = new Vector3(0f, 0f, 0f);
        num2 = 0;
        goto Label_00DC;
    Label_001D:
        num3 = 0;
        goto Label_00D1;
    Label_0024:
        vectorArray = this.path[num2][num3];
        num4 = 0;
        goto Label_00C2;
    Label_0038:
        if (this.IsIlegal(num2, num4) != null)
        {
            goto Label_00BC;
        }
        vector2 = *(&(vectorArray[num4]));
        float introduced7 = Mathf.Pow(&vector2.y - &position.y, 2f);
        num = Mathf.RoundToInt(Mathf.Sqrt(introduced7 + Mathf.Pow(&vector2.x - &position.x, 2f)));
        if (((float) num) >= minDistance)
        {
            goto Label_00BC;
        }
        minDistance = (float) num;
        &vector.x = (float) num2;
        &vector.y = (float) num3;
        &vector.z = (float) num4;
    Label_00BC:
        num4 += 1;
    Label_00C2:
        if (num4 < ((int) vectorArray.Length))
        {
            goto Label_0038;
        }
        num3 += 1;
    Label_00D1:
        if (num3 < 3)
        {
            goto Label_0024;
        }
        num2 += 1;
    Label_00DC:
        if (num2 < ((int) this.path.Length))
        {
            goto Label_001D;
        }
        return vector;
    }

    protected virtual void FixedUpdate()
    {
        if (this.status == 2)
        {
            goto Label_0024;
        }
        if (this.status == 3)
        {
            goto Label_0024;
        }
        if (this.status != 4)
        {
            goto Label_0025;
        }
    Label_0024:
        return;
    Label_0025:
        if (this.canUseHeroes == null)
        {
            goto Label_0063;
        }
        if (GameUpgrades.SelectedHero == null)
        {
            goto Label_0063;
        }
        if (GameData.notificationTipHeroes != null)
        {
            goto Label_0063;
        }
        if (this.heroTipShowed != null)
        {
            goto Label_0063;
        }
        this.gui.AddNotificationSecondLevel(0x34);
        this.heroTipShowed = 1;
    Label_0063:
        this.SpawnEnemies();
        if (this.status != 1)
        {
            goto Label_00D8;
        }
        if (this.preWinTimeCounter >= this.preWinTime)
        {
            goto Label_00B4;
        }
        this.preWinTimeCounter += 1;
        if (this.preWinTimeCounter != (this.preWinTime - 10))
        {
            goto Label_00B3;
        }
        this.quickmenu.Hide();
    Label_00B3:
        return;
    Label_00B4:
        this.status = 2;
        this.ShowMenuVictory();
        GameSoundManager.StopMeleeFight();
        this.DisablePowers();
        this.DisablePauseButton();
        this.DisableDecos();
    Label_00D8:
        GameSoundManager.CheckSoldiersFight();
        this.waveCalledThisFrame = 0;
        return;
    }

    public int GetCurrentWaveNumber()
    {
        return this.currentWave;
    }

    private unsafe Vector3 GetFlagPosition(int index)
    {
        float num;
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_0038;
        }
        return *(&(this.flagsPositions43[index][0]));
    Label_0038:
        if (Mathf.Abs(num - 1.6f) >= 0.1f)
        {
            goto Label_0062;
        }
        return *(&(this.flagsPositions1610[index][0]));
    Label_0062:
        return *(&(this.flagsPositions[index][0]));
    }

    public int GetGold()
    {
        return this.currentGold;
    }

    public int GetIcePathCount(int path)
    {
        return (int) this.ice[path].Length;
    }

    public int GetIcePathValue(int path, int index)
    {
        return this.ice[path][index];
    }

    public int GetLives()
    {
        return this.currentLives;
    }

    public Vector2[][][] GetPath()
    {
        return this.path;
    }

    public ArrayList GetSoldiers()
    {
        return this.soldiers;
    }

    public states GetStatus()
    {
        return this.status;
    }

    public terrainType GetTerrainType()
    {
        return this.terrain;
    }

    public int GetTotalWaveNumber()
    {
        int num;
        int num2;
        int num3;
        num = 0;
        num2 = (int) this.waves.Length;
        num3 = 0;
        goto Label_0046;
    Label_0012:
        num += 1;
        num3 += 1;
        goto Label_003F;
    Label_001F:
        if (this.waves[num3].GetInterval() != null)
        {
            goto Label_0046;
        }
        num3 += 1;
        goto Label_003F;
        goto Label_0046;
    Label_003F:
        if (num3 < num2)
        {
            goto Label_001F;
        }
    Label_0046:
        if (num3 < num2)
        {
            goto Label_0012;
        }
        return num;
    }

    public int[][] GetTunnels()
    {
        return this.tunnels;
    }

    public bool GetWaveCalledThisFrame()
    {
        return this.waveCalledThisFrame;
    }

    public bool GetWaveRecentlyCalled()
    {
        return this.waveRecentlyCalled;
    }

    protected virtual bool HasEnemies()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Transform transform2;
        IEnumerator enumerator2;
        Creep creep2;
        IDisposable disposable;
        bool flag;
        IDisposable disposable2;
        if (this.isReadyToWin == null)
        {
            goto Label_00B2;
        }
        if (this.readyToWinTimeCounter >= this.readyToWinTime)
        {
            goto Label_00B0;
        }
        this.readyToWinTimeCounter += 1;
        if ((this.readyToWinTimeCounter % 10) != null)
        {
            goto Label_00AE;
        }
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0049:
        try
        {
            goto Label_0089;
        Label_004E:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsBoss() == null)
            {
                goto Label_0082;
            }
            if (creep.IsBoss() == null)
            {
                goto Label_0089;
            }
            if (creep.IsDead() != null)
            {
                goto Label_0089;
            }
        Label_0082:
            this.isReadyToWin = 0;
        Label_0089:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004E;
            }
            goto Label_00AE;
        }
        finally
        {
        Label_0099:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A6;
            }
        Label_00A6:
            disposable.Dispose();
        }
    Label_00AE:
        return 1;
    Label_00B0:
        return 0;
    Label_00B2:
        enumerator2 = this.spawner.transform.GetEnumerator();
    Label_00C4:
        try
        {
            goto Label_010A;
        Label_00C9:
            transform2 = (Transform) enumerator2.Current;
            creep2 = transform2.GetComponent<Creep>();
            if (creep2.IsBoss() == null)
            {
                goto Label_0102;
            }
            if (creep2.IsBoss() == null)
            {
                goto Label_010A;
            }
            if (creep2.IsDead() != null)
            {
                goto Label_010A;
            }
        Label_0102:
            flag = 1;
            goto Label_0141;
        Label_010A:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_00C9;
            }
            goto Label_0131;
        }
        finally
        {
        Label_011B:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_0129;
            }
        Label_0129:
            disposable2.Dispose();
        }
    Label_0131:
        this.isReadyToWin = 1;
        this.readyToWinTimeCounter = 0;
        return 1;
    Label_0141:
        return flag;
    }

    public bool HasIce()
    {
        return this.hasIce;
    }

    public bool HasIceOnPath(int path)
    {
        return ((this.hasIce == null) ? 0 : ((this.ice[path][0] == 0) == 0));
    }

    public bool HasTunnels(int path)
    {
        return ((this.hasTunnels == null) ? 0 : ((this.tunnels[path][0] == 0) == 0));
    }

    public void HideGUI()
    {
        object[] objArray4;
        object[] objArray3;
        object[] objArray2;
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) (this.guiBottom.transform.position + new Vector3(0f, -400f, 0f)), "time", (float) 1f, "oncomplete", "DisableGUI" };
        iTween.MoveTo(this.guiBottom.gameObject, iTween.Hash(objArray1));
        if ((this.heroPortrait != null) == null)
        {
            goto Label_00F3;
        }
        objArray2 = new object[] { "position", (Vector3) (this.heroPortrait.transform.position + new Vector3(0f, -400f, 0f)), "time", (float) 1f };
        iTween.MoveTo(this.heroPortrait.gameObject, iTween.Hash(objArray2));
    Label_00F3:
        objArray3 = new object[] { "position", (Vector3) (this.pauseButton.transform.position + new Vector3(0f, 200f, 0f)), "time", (float) 1f };
        iTween.MoveTo(this.pauseButton.parent.gameObject, iTween.Hash(objArray3));
        objArray4 = new object[] { "position", (Vector3) (this.hud.transform.position + new Vector3(0f, 200f, 0f)), "time", (float) 1f };
        iTween.MoveTo(this.hud.gameObject, iTween.Hash(objArray4));
        return;
    }

    public void IgnoreHeroClick()
    {
        if ((this.hero != null) == null)
        {
            goto Label_0022;
        }
        this.hero.gameObject.layer = 2;
    Label_0022:
        return;
    }

    protected abstract void InitCustom();
    protected virtual void InitPathGrid()
    {
    }

    public bool IsIlegal(int i, int j)
    {
        if (this.hasTunnels == null)
        {
            goto Label_003D;
        }
        if (this.tunnels[i][0] != 1)
        {
            goto Label_003D;
        }
        if (j < this.tunnels[i][1])
        {
            goto Label_003D;
        }
        if (j > this.tunnels[i][4])
        {
            goto Label_003D;
        }
        return 1;
    Label_003D:
        if (j < 0)
        {
            goto Label_0056;
        }
        if (j <= ((int) this.path[i][0].Length))
        {
            goto Label_0058;
        }
    Label_0056:
        return 1;
    Label_0058:
        return 0;
    }

    public void IterateThroughEnemiesNear(Vector3 pos, int minRange, int maxRange, object target, string methodName)
    {
        object[] objArray1;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        MethodInfo info;
        object obj2;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0101;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_0081;
            }
            if (minRange <= 0)
            {
                goto Label_0081;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position - new Vector3(0f, creep.yAdjust, 0f), (float) minRange, (float) Mathf.RoundToInt(((float) minRange) * 0.7f), pos) == null)
            {
                goto Label_0081;
            }
            goto Label_0101;
        Label_0081:
            if (IronUtils.ellipseContainPoint(creep.transform.position - new Vector3(0f, creep.yAdjust, 0f), (float) maxRange, (float) Mathf.RoundToInt(((float) maxRange) * 0.7f), pos) != null)
            {
                goto Label_00C6;
            }
            goto Label_0101;
        Label_00C6:
            objArray1 = new object[] { creep };
            obj2 = target.GetType().GetMethod(methodName).Invoke(target, objArray1);
            if (obj2 == null)
            {
                goto Label_0101;
            }
            if (((bool) obj2) == null)
            {
                goto Label_0101;
            }
            goto Label_0126;
        Label_0101:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_0126;
        }
        finally
        {
        Label_0111:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_011E;
            }
        Label_011E:
            disposable.Dispose();
        }
    Label_0126:
        return;
    }

    protected virtual void LoadCampaignMode()
    {
    }

    protected virtual void LoadCampaignModeData()
    {
        GameSettings.LoadLevelSettings(5);
        this.LoadCampaignTowers();
        this.currentLives = 20;
        this.canUseHeroes = 1;
        return;
    }

    protected virtual void LoadCampaignTowers()
    {
    }

    protected virtual void LoadCampaignWaves()
    {
    }

    protected abstract void LoadFlagPositions();
    protected unsafe void LoadHero()
    {
        SoldierHero hero;
        int num;
        if (this.isHeroAdded != null)
        {
            goto Label_0807;
        }
        if (GameUpgrades.HeroesEnabled == null)
        {
            goto Label_0800;
        }
        if (this.canUseHeroes == null)
        {
            goto Label_0800;
        }
        switch ((GameUpgrades.SelectedHero - 1))
        {
            case 0:
                goto Label_0063;

            case 1:
                goto Label_0105;

            case 2:
                goto Label_01A7;

            case 3:
                goto Label_0249;

            case 4:
                goto Label_038D;

            case 5:
                goto Label_02EB;

            case 6:
                goto Label_042F;

            case 7:
                goto Label_0573;

            case 8:
                goto Label_04D1;

            case 9:
                goto Label_0615;

            case 10:
                goto Label_06B7;

            case 11:
                goto Label_0759;
        }
        goto Label_07FB;
    Label_0063:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroLightseeker", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_0105:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroAlleria", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_01A7:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroBolin", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.LoadHeroPortrait();
        this.hero.SetRangeCenterPosition(this.defendPoint);
        goto Label_0800;
    Label_0249:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroMagnus", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_02EB:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroIgnus", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_038D:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroMalik", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_042F:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroDenas", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_04D1:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroViking", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_0573:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroElora", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_0615:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroThor", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_06B7:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroSamurai", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_0759:
        hero = Resources.Load("Prefabs/Soldiers & units/HeroRobot", typeof(SoldierHero)) as SoldierHero;
        this.hero = UnityEngine.Object.Instantiate(hero, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -2f), Quaternion.identity) as SoldierHero;
        this.hero.InitWithPosition(this.defendPoint, this.defendPoint, 40, 0, this.defendPoint);
        this.hero.transform.parent = base.transform;
        this.hero.SetRangeCenterPosition(this.defendPoint);
        this.LoadHeroPortrait();
        goto Label_0800;
    Label_07FB:;
    Label_0800:
        this.isHeroAdded = 1;
    Label_0807:
        return;
    }

    protected abstract void LoadHeroicMode();
    protected virtual void LoadHeroicModeData()
    {
        GameSettings.LoadLevelSettings(5);
        this.maxUpgradeLevel = 5;
        this.LoadHeroicTowers();
        this.currentLives = 1;
        this.canUseHeroes = 1;
        return;
    }

    protected abstract void LoadHeroicTowers();
    protected abstract void LoadHeroicWaves();
    private void LoadHeroPortrait()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.heroPortraitPrefab, new Vector3(0f, 0f, -903f), Quaternion.identity) as Transform;
        this.heroPortrait = transform.GetComponent<HeroPortrait>();
        this.heroPortrait.transform.name = "HeroPortrait";
        this.heroPortrait.SetHero();
        this.heroPortrait.GetComponent<AspectRatioMod>().Refresh(Screen.width, Screen.height);
        return;
    }

    protected virtual void LoadIce()
    {
    }

    protected abstract void LoadIronMode();
    protected virtual void LoadIronModeData()
    {
        GameSettings.LoadLevelSettings(5);
        this.maxUpgradeLevel = 5;
        this.LoadIronTowers();
        this.currentLives = 1;
        this.canUseHeroes = 1;
        return;
    }

    protected abstract void LoadIronTowers();
    protected abstract void LoadIronWaves();
    protected abstract void LoadNextLevel();
    protected void LoadPath()
    {
        float num;
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_002F;
        }
        this.LoadPath43();
        goto Label_0035;
    Label_002F:
        this.LoadPathWideScreen();
    Label_0035:
        return;
    }

    protected abstract void LoadPath43();
    protected abstract void LoadPathWideScreen();
    protected abstract void LoadPreviousLevel();
    protected virtual void LoadTunnels()
    {
    }

    public virtual void MuteMusic()
    {
        this.musicBattle.volume = 0f;
        this.musicPreparation.volume = 0f;
        return;
    }

    protected virtual void OnPreWin()
    {
    }

    public void Pause(bool withOverlay = true)
    {
        if (this.status == 3)
        {
            goto Label_001F;
        }
        if (this.status == 2)
        {
            goto Label_001F;
        }
        this.status = 4;
    Label_001F:
        if (withOverlay == null)
        {
            goto Label_0062;
        }
        this.overlayPause.GetComponent<ParticleFadeOut>().Pause();
        this.overlayPause.Hide(0);
        this.overlayPause.GetComponent<ParticleFadeIn>().enabled = 1;
        this.overlayPause.GetComponent<ParticleFadeIn>().FadeIn();
    Label_0062:
        this.PauseTowers();
        this.PauseCreeps();
        this.PauseExplosions();
        this.PauseEffects();
        this.PauseReinforcement();
        this.PauseCustom();
        this.PauseProjectiles();
        this.DisableTowers();
        this.DisableFlags();
        this.nextWaveButton.Disable();
        this.PauseFlags();
        this.gui.DisableNotificationTips();
        this.guiBottom.Pause();
        if ((this.hero != null) == null)
        {
            goto Label_00DB;
        }
        this.hero.Pause();
    Label_00DB:
        return;
    }

    protected void PauseCreeps()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_003B;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_003B;
            }
            creep.Pause();
        Label_003B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_005D;
        }
        finally
        {
        Label_004B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0056;
            }
        Label_0056:
            disposable.Dispose();
        }
    Label_005D:
        return;
    }

    protected virtual void PauseCustom()
    {
    }

    protected void PauseEffects()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        ParticleFade fade;
        PowerFireballParticle particle;
        ParticleEffect effect;
        IDisposable disposable;
        enumerator = this.effectsContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_007B;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<PackedSprite>().PauseAnim();
            fade = transform.GetComponent<ParticleFade>();
            if ((fade != null) == null)
            {
                goto Label_0043;
            }
            fade.Pause();
        Label_0043:
            particle = transform.GetComponent<PowerFireballParticle>();
            if ((particle != null) == null)
            {
                goto Label_005F;
            }
            particle.Pause();
        Label_005F:
            effect = transform.GetComponent<ParticleEffect>();
            if ((effect != null) == null)
            {
                goto Label_007B;
            }
            effect.Pause();
        Label_007B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_00A0;
        }
        finally
        {
        Label_008B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0098;
            }
        Label_0098:
            disposable.Dispose();
        }
    Label_00A0:
        return;
    }

    protected void PauseExplosions()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        IDisposable disposable;
        enumerator = this.explosionContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_002A;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<PackedSprite>().PauseAnim();
        Label_002A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004C;
        }
        finally
        {
        Label_003A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0045;
            }
        Label_0045:
            disposable.Dispose();
        }
    Label_004C:
        return;
    }

    protected void PauseFlags()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.flags.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0028;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<WaveSpawnFlag>().Pause();
        Label_0028:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004A;
        }
        finally
        {
        Label_0038:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0043;
            }
        Label_0043:
            disposable.Dispose();
        }
    Label_004A:
        return;
    }

    public virtual void PauseMusic()
    {
        if (this.firstWaveSign == null)
        {
            goto Label_001B;
        }
        this.musicPreparation.Pause();
        goto Label_0026;
    Label_001B:
        this.musicBattle.Pause();
    Label_0026:
        return;
    }

    protected void PauseProjectiles()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        Mine mine;
        TarBomb bomb;
        PowerFireball fireball;
        CreepSpiderEgg egg;
        IDisposable disposable;
        enumerator = this.projectilesContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_00A8;
        Label_0011:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_003B;
            }
            projectile.Pause();
            goto Label_00A8;
        Label_003B:
            mine = transform.GetComponent<Mine>();
            if ((mine != null) == null)
            {
                goto Label_0054;
            }
            mine.Pause();
        Label_0054:
            bomb = transform.GetComponent<TarBomb>();
            if ((bomb != null) == null)
            {
                goto Label_0070;
            }
            bomb.Pause();
        Label_0070:
            fireball = transform.GetComponent<PowerFireball>();
            if ((fireball != null) == null)
            {
                goto Label_008C;
            }
            fireball.Pause();
        Label_008C:
            egg = transform.GetComponent<CreepSpiderEgg>();
            if ((egg != null) == null)
            {
                goto Label_00A8;
            }
            egg.Pause();
        Label_00A8:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_00CD;
        }
        finally
        {
        Label_00B8:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C5;
            }
        Label_00C5:
            disposable.Dispose();
        }
    Label_00CD:
        return;
    }

    protected void PauseReinforcement()
    {
        Transform transform;
        IEnumerator enumerator;
        SoldierReinforcement reinforcement;
        IDisposable disposable;
        enumerator = this.reinforceContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0046;
        Label_0011:
            transform = (Transform) enumerator.Current;
            reinforcement = transform.GetComponent<SoldierReinforcement>();
            if ((reinforcement != null) == null)
            {
                goto Label_003B;
            }
            reinforcement.Pause();
            goto Label_0046;
        Label_003B:
            transform.GetComponent<Arrow>().Pause();
        Label_0046:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0068;
        }
        finally
        {
        Label_0056:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0061;
            }
        Label_0061:
            disposable.Dispose();
        }
    Label_0068:
        return;
    }

    protected void PauseTowers()
    {
        TowerBase[] baseArray;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        baseArray2 = baseArray;
        num = 0;
        goto Label_002C;
    Label_001E:
        base2 = baseArray2[num];
        base2.Pause();
        num += 1;
    Label_002C:
        if (num < ((int) baseArray2.Length))
        {
            goto Label_001E;
        }
        return;
    }

    public virtual void PlayMusicBossFight()
    {
    }

    public virtual void RemoveGold(int gold)
    {
        this.currentGold -= gold;
        return;
    }

    public virtual void RemoveLives(int lives)
    {
        if (this.currentLives > 0)
        {
            goto Label_000D;
        }
        return;
    Label_000D:
        GameSoundManager.PlayGUILoseLife();
        this.currentLives -= lives;
        if (this.currentLives > 0)
        {
            goto Label_0058;
        }
        this.currentLives = 0;
        this.StageDefeat();
        this.status = 3;
        this.ShowDefeatScreen();
        this.DisablePauseButton();
        this.DisablePowers();
        this.DisableDecos();
    Label_0058:
        return;
    }

    public void RemoveSoldier(Soldier s)
    {
        this.soldiers.Remove(s);
        return;
    }

    public void RemoveWave(Wave wave)
    {
        this.activeWaves.Remove(wave);
        return;
    }

    public void SendNextWave(WaveSpawnFlag flag = null)
    {
        int num;
        this.waveCalledThisFrame = 1;
        this.waveRecentlyCalled = 1;
        base.Invoke("WaveRecentlyCalledReset", 0.1f);
        if (this.firstWaveSign == null)
        {
            goto Label_006B;
        }
        if (GameData.GetCurrentStageData().Index != 1)
        {
            goto Label_0043;
        }
        if (GameData.GetGameMode() == null)
        {
            goto Label_0059;
        }
    Label_0043:
        this.powerFireball.Open();
        this.powerReinforcement.Open();
    Label_0059:
        this.firstWaveSign = 0;
        this.StartBattleMusic();
        goto Label_0084;
    Label_006B:
        if ((this.intervalWaveCounter / 30) > 3)
        {
            goto Label_007F;
        }
        GameAchievements.CheckImpatient();
    Label_007F:
        GameAchievements.CheckDaring();
    Label_0084:
        if (this.indexWaves == null)
        {
            goto Label_0127;
        }
        this.waveCalled = 1;
        this.powerFireball.CompensateTime(this.waves[this.indexWaves].GetInterval() - this.intervalWaveCounter);
        this.powerReinforcement.CompensateTime(this.waves[this.indexWaves].GetInterval() - this.intervalWaveCounter);
        num = Mathf.RoundToInt((float) (this.waves[this.indexWaves].GetInterval() - this.intervalWaveCounter)) / 30;
        if (num < 1)
        {
            goto Label_0127;
        }
        if ((flag != null) == null)
        {
            goto Label_011B;
        }
        flag.ShowGold(num);
    Label_011B:
        this.AddGold(num);
        GameSoundManager.PlayGUICoins();
    Label_0127:
        this.intervalWaveCounter = this.waves[this.indexWaves].GetInterval();
        this.DestroyFlags();
        return;
    }

    protected void ShowDefeatScreen()
    {
        this.quickmenu.Hide();
        UnityEngine.Object.Instantiate(this.defeatScreenPrefab, new Vector3(0f, 800f, -907f), Quaternion.identity);
        GameSoundManager.StopMeleeFight();
        this.Pause(1);
        return;
    }

    protected unsafe void ShowDefendFlag()
    {
        Transform transform;
        int num;
        transform = ((GameObject) Resources.Load("Prefabs/GUI/DefendFlag")).GetComponent<Transform>();
        if ((this.defendPoint == Vector2.zero) == null)
        {
            goto Label_0097;
        }
        this.defendPoint = *(&(this.defendPoints[1]));
        num = 0;
        goto Label_0084;
    Label_0048:
        UnityEngine.Object.Instantiate(transform, new Vector3(&(this.defendPoints[num]).x, &(this.defendPoints[num]).y, -1f), Quaternion.identity);
        num += 1;
    Label_0084:
        if (num < ((int) this.defendPoints.Length))
        {
            goto Label_0048;
        }
        goto Label_00C3;
    Label_0097:
        UnityEngine.Object.Instantiate(transform, new Vector3(&this.defendPoint.x, &this.defendPoint.y, -1f), Quaternion.identity);
    Label_00C3:
        return;
    }

    protected void ShowMenuVictory()
    {
        UnityEngine.Object.Instantiate(this.victoryNormalPrefab, new Vector3(0f, 206f, -910f), Quaternion.identity);
        GameData.LastLevelCompleted = GameData.GetCurrentStageData().Index;
        this.Pause(1);
        return;
    }

    public unsafe void ShowWaveSpawnFlag(int pathIndex, bool isFlying, bool tmpFirst, int myInterval, Wave wave)
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        vector = this.GetFlagPosition(pathIndex);
        vector2 = *(&(this.flagsPositions[pathIndex][1]));
        if (isFlying != null)
        {
            goto Label_003E;
        }
        transform = UnityEngine.Object.Instantiate(this.waveSpawnFlagPrefab, vector, Quaternion.identity) as Transform;
        goto Label_0055;
    Label_003E:
        transform = UnityEngine.Object.Instantiate(this.waveSpawnFlyFlagPrefab, vector, Quaternion.identity) as Transform;
    Label_0055:
        transform.GetComponent<WaveSpawnFlag>().Init(myInterval, tmpFirst, vector2, wave);
        transform.parent = base.transform;
        this.flags.Add(transform);
        this.EnableNextWaveButton();
        return;
    }

    protected void SpawnEnemies()
    {
        int num;
        int num2;
        int num3;
        int num4;
        ArrayList list;
        Wave wave;
        IEnumerator enumerator;
        IDisposable disposable;
        num = this.activeWaves.Count;
        if (this.currentWave != null)
        {
            goto Label_0023;
        }
        if (this.firstWaveSign == null)
        {
            goto Label_0023;
        }
        return;
    Label_0023:
        if (num != null)
        {
            goto Label_02F5;
        }
        if (this.indexWaves >= ((int) this.waves.Length))
        {
            goto Label_02D7;
        }
        if (this.waves[this.indexWaves].GetInterval() != this.intervalWaveCounter)
        {
            goto Label_0182;
        }
        if (this.indexWaves == null)
        {
            goto Label_00AA;
        }
        if (this.waves[this.indexWaves].Notification.Equals(string.Empty) != null)
        {
            goto Label_00AA;
        }
        num2 = Convert.ToInt32(this.waves[this.indexWaves].Notification);
        this.gui.AddNotificationPause(num2, null);
    Label_00AA:
        this.currentWave += 1;
        this.activeWaves.Add(this.waves[this.indexWaves]);
        this.intervalWaveCounter = 0;
        this.indexWaves += 1;
        GameSoundManager.PlayGUINextWaveIncoming();
        if (this.indexWaves == 1)
        {
            goto Label_0109;
        }
        if (this.waveCalled != null)
        {
            goto Label_0109;
        }
        this.fearless = 0;
    Label_0109:
        this.waveCalled = 0;
        this.DestroyFlags();
        this.nextWaveButton.Disable();
        this.AfterNextWaveStart();
        goto Label_0153;
    Label_012C:
        this.activeWaves.Add(this.waves[this.indexWaves]);
        this.indexWaves += 1;
    Label_0153:
        if (this.indexWaves >= ((int) this.waves.Length))
        {
            goto Label_02F5;
        }
        if (this.waves[this.indexWaves].GetInterval() == null)
        {
            goto Label_012C;
        }
        goto Label_02D2;
    Label_0182:
        if (this.indexWaves != null)
        {
            goto Label_01D3;
        }
        if (this.waves[this.indexWaves].Notification.Equals(string.Empty) != null)
        {
            goto Label_01D3;
        }
        num3 = Convert.ToInt32(this.waves[this.indexWaves].Notification);
        this.gui.AddNotificationPause(num3, null);
    Label_01D3:
        if (this.intervalWaveCounter != 50)
        {
            goto Label_01F7;
        }
        if (this.waves[this.indexWaves].GetInterval() != null)
        {
            goto Label_020D;
        }
    Label_01F7:
        if (this.intervalWaveCounter != null)
        {
            goto Label_029F;
        }
        if (this.indexWaves != null)
        {
            goto Label_029F;
        }
    Label_020D:
        this.waves[this.indexWaves].ShowWaveFlag(this.waves[this.indexWaves].GetInterval() - 50, this.indexWaves);
        GameSoundManager.PlayGUINextWaveReady();
        num4 = this.indexWaves + 1;
        goto Label_0279;
    Label_024D:
        this.waves[num4].ShowWaveFlag(this.waves[this.indexWaves].GetInterval() - 50, this.indexWaves);
        num4 += 1;
    Label_0279:
        if (num4 >= ((int) this.waves.Length))
        {
            goto Label_0299;
        }
        if (this.waves[num4].GetInterval() == null)
        {
            goto Label_024D;
        }
    Label_0299:
        this.AfterNextWaveFlagShow();
    Label_029F:
        if (this.indexWaves != null)
        {
            goto Label_02C4;
        }
        this.firstWaveSign = 1;
        this.intervalWaveCounter += 1;
        goto Label_02D2;
    Label_02C4:
        this.intervalWaveCounter += 1;
    Label_02D2:
        goto Label_02F5;
    Label_02D7:
        if (this.HasEnemies() != null)
        {
            goto Label_02F5;
        }
        this.status = 1;
        this.OnPreWin();
        this.CheckLevelAchievements();
    Label_02F5:
        list = this.activeWaves.Clone() as ArrayList;
        enumerator = list.GetEnumerator();
    Label_0310:
        try
        {
            goto Label_032B;
        Label_0315:
            wave = (Wave) enumerator.Current;
            wave.SpawnEnemies();
        Label_032B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0315;
            }
            goto Label_0352;
        }
        finally
        {
        Label_033C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_034A;
            }
        Label_034A:
            disposable.Dispose();
        }
    Label_0352:
        return;
    }

    public virtual void SpawnZombie(int health)
    {
    }

    protected virtual void StageDefeat()
    {
    }

    public bool StageHasTunnels()
    {
        return this.hasTunnels;
    }

    protected void Start()
    {
        LoadWavesFromXML mxml;
        this.pauseButton = GameObject.Find("Pause Button").transform.FindChild("Button");
        base.transform.FindChild("Notifications").FindChild("NotificationAchievement").GetComponent<NotificationAchievement>().Init();
        GameAchievements.LoadNotificationAchievement();
        this.heroPortraitPrefab = ((GameObject) Resources.Load("Prefabs/GUI/HeroPortrait")).GetComponent<Transform>();
        this.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.nextWaveButton = this.guiBottom.transform.FindChild("Next Wave").GetComponent<NextWaveButton>();
        this.rallyOk = ((GameObject) Resources.Load("Prefabs/GUI/RallyOk")).GetComponent<Transform>();
        this.rallyError = ((GameObject) Resources.Load("Prefabs/GUI/RallyError")).GetComponent<Transform>();
        this.quickmenu = GameObject.Find("Quickmenu").GetComponent<Quickmenu>();
        Screen.showCursor = 1;
        this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.overlayPause = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        this.victoryNormalPrefab = ((GameObject) Resources.Load("Prefabs/Screens/Victory Normal")).GetComponent<Transform>();
        this.defeatScreenPrefab = ((GameObject) Resources.Load("Prefabs/Screens/Defeat Screen")).GetComponent<Transform>();
        this.status = 0;
        this.preWinTime = 30;
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.powerFireball = GameObject.Find("Fireball Portrait").GetComponent<PowerFireballPortrait>();
        this.powerReinforcement = GameObject.Find("Reinforcement Portrait").GetComponent<PowerReinforcementPortrait>();
        this.hud = GameObject.Find("HUD").GetComponent<Transform>();
        this.explosionContainer = base.transform.FindChild("Explosions");
        this.effectsContainer = base.transform.FindChild("Effects");
        this.reinforceContainer = base.transform.FindChild("Reinforce");
        this.projectilesContainer = base.transform.FindChild("Projectiles");
        this.InitCustom();
        this.ShowDefendFlag();
        this.overlayPause.GetComponent<ParticleFadeOut>().Fade();
        if (this.soldiers != null)
        {
            goto Label_0231;
        }
        this.soldiers = new ArrayList();
    Label_0231:
        this.flags = new ArrayList();
        this.LoadPath();
        mxml = base.GetComponent<LoadWavesFromXML>();
        if (mxml == null)
        {
            goto Label_025F;
        }
        if (mxml.enabled != null)
        {
            goto Label_02A0;
        }
    Label_025F:
        if (GameData.GetGameMode() != null)
        {
            goto Label_0274;
        }
        this.LoadCampaignMode();
        goto Label_029B;
    Label_0274:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_028A;
        }
        this.LoadHeroicMode();
        goto Label_029B;
    Label_028A:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_02FF;
        }
        this.LoadIronMode();
    Label_029B:
        goto Label_02FF;
    Label_02A0:
        mxml.LoadWaves(GameData.GetGameMode());
        this.waves = mxml.waves;
        this.currentGold = mxml.gold;
        if (GameData.GetGameMode() != null)
        {
            goto Label_02D8;
        }
        this.LoadCampaignModeData();
        goto Label_02FF;
    Label_02D8:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_02EE;
        }
        this.LoadHeroicModeData();
        goto Label_02FF;
    Label_02EE:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_02FF;
        }
        this.LoadIronModeData();
    Label_02FF:
        this.LoadFlagPositions();
        this.fearless = 1;
        this.maxWaves = this.GetTotalWaveNumber();
        this.InitPathGrid();
        this.LoadHero();
        if (GameSoundManager.IsMusicMuted() == null)
        {
            goto Label_0334;
        }
        this.MuteMusic();
    Label_0334:
        return;
    }

    protected void StartBattleMusic()
    {
        this.musicPreparation.Stop();
        this.musicBattle.volume = 1f * GameSoundManager.GetVolumeMusic();
        this.musicBattle.Play();
        return;
    }

    public int TunnelEnd(int path)
    {
        return this.tunnels[path][4];
    }

    public int TunnelEndShow(int path)
    {
        return this.tunnels[path][3];
    }

    public int TunnelStart(int path)
    {
        return this.tunnels[path][1];
    }

    public int TunnelStartHide(int path)
    {
        return this.tunnels[path][2];
    }

    public virtual void UnmuteMusic()
    {
        this.musicBattle.volume = 1f * GameSoundManager.GetVolumeMusic();
        this.musicPreparation.volume = 1f * GameSoundManager.GetVolumeMusic();
        return;
    }

    public void UnPause(bool hideOverlay)
    {
        if (this.status != 3)
        {
            goto Label_000D;
        }
        return;
    Label_000D:
        this.status = 0;
        if (hideOverlay == null)
        {
            goto Label_0026;
        }
        this.overlayPause.Hide(1);
    Label_0026:
        this.UnpauseTowers();
        this.UnpauseCreeps();
        this.UnpauseExplosions();
        this.UnpauseEffects();
        this.UnpauseReinforcement();
        this.UnpauseCustom();
        this.UnpauseProjectiles();
        this.EnableTowers();
        this.EnableFlags();
        this.UnpauseFlags();
        this.nextWaveButton.Enable();
        if ((this.hero != null) == null)
        {
            goto Label_0089;
        }
        this.hero.Unpause();
    Label_0089:
        this.gui.EnableNotificationTips();
        this.guiBottom.Unpause();
        return;
    }

    protected void UnpauseCreeps()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_003B;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_003B;
            }
            creep.Unpause();
        Label_003B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_005D;
        }
        finally
        {
        Label_004B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0056;
            }
        Label_0056:
            disposable.Dispose();
        }
    Label_005D:
        return;
    }

    protected virtual void UnpauseCustom()
    {
    }

    protected void UnpauseEffects()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        ParticleFade fade;
        PowerFireballParticle particle;
        ParticleEffect effect;
        IDisposable disposable;
        enumerator = this.effectsContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_007B;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<PackedSprite>().UnpauseAnim();
            fade = transform.GetComponent<ParticleFade>();
            if ((fade != null) == null)
            {
                goto Label_0043;
            }
            fade.Unpause();
        Label_0043:
            particle = transform.GetComponent<PowerFireballParticle>();
            if ((particle != null) == null)
            {
                goto Label_005F;
            }
            particle.Unpause();
        Label_005F:
            effect = transform.GetComponent<ParticleEffect>();
            if ((effect != null) == null)
            {
                goto Label_007B;
            }
            effect.Unpause();
        Label_007B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_00A0;
        }
        finally
        {
        Label_008B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0098;
            }
        Label_0098:
            disposable.Dispose();
        }
    Label_00A0:
        return;
    }

    protected void UnpauseExplosions()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        IDisposable disposable;
        enumerator = this.explosionContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_002A;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<PackedSprite>().UnpauseAnim();
        Label_002A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004C;
        }
        finally
        {
        Label_003A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0045;
            }
        Label_0045:
            disposable.Dispose();
        }
    Label_004C:
        return;
    }

    protected void UnpauseFlags()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.flags.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0028;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<WaveSpawnFlag>().Unpause();
        Label_0028:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004A;
        }
        finally
        {
        Label_0038:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0043;
            }
        Label_0043:
            disposable.Dispose();
        }
    Label_004A:
        return;
    }

    public virtual void UnpauseMusic()
    {
        if (this.firstWaveSign == null)
        {
            goto Label_0031;
        }
        this.musicPreparation.volume = 1f * GameSoundManager.GetVolumeMusic();
        this.musicPreparation.Play();
        goto Label_0052;
    Label_0031:
        this.musicBattle.volume = 1f * GameSoundManager.GetVolumeMusic();
        this.musicBattle.Play();
    Label_0052:
        return;
    }

    protected void UnpauseProjectiles()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        Mine mine;
        TarBomb bomb;
        PowerFireball fireball;
        CreepSpiderEgg egg;
        IDisposable disposable;
        enumerator = this.projectilesContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_00A8;
        Label_0011:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_003B;
            }
            projectile.Unpause();
            goto Label_00A8;
        Label_003B:
            mine = transform.GetComponent<Mine>();
            if ((mine != null) == null)
            {
                goto Label_0054;
            }
            mine.Unpause();
        Label_0054:
            bomb = transform.GetComponent<TarBomb>();
            if ((bomb != null) == null)
            {
                goto Label_0070;
            }
            bomb.Unpause();
        Label_0070:
            fireball = transform.GetComponent<PowerFireball>();
            if ((fireball != null) == null)
            {
                goto Label_008C;
            }
            fireball.Unpause();
        Label_008C:
            egg = transform.GetComponent<CreepSpiderEgg>();
            if ((egg != null) == null)
            {
                goto Label_00A8;
            }
            egg.Unpause();
        Label_00A8:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_00CD;
        }
        finally
        {
        Label_00B8:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C5;
            }
        Label_00C5:
            disposable.Dispose();
        }
    Label_00CD:
        return;
    }

    protected void UnpauseReinforcement()
    {
        Transform transform;
        IEnumerator enumerator;
        SoldierReinforcement reinforcement;
        IDisposable disposable;
        enumerator = this.reinforceContainer.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0046;
        Label_0011:
            transform = (Transform) enumerator.Current;
            reinforcement = transform.GetComponent<SoldierReinforcement>();
            if ((reinforcement != null) == null)
            {
                goto Label_003B;
            }
            reinforcement.Unpause();
            goto Label_0046;
        Label_003B:
            transform.GetComponent<Arrow>().Unpause();
        Label_0046:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0068;
        }
        finally
        {
        Label_0056:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0061;
            }
        Label_0061:
            disposable.Dispose();
        }
    Label_0068:
        return;
    }

    protected void UnpauseTowers()
    {
        TowerBase[] baseArray;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        baseArray2 = baseArray;
        num = 0;
        goto Label_002C;
    Label_001E:
        base2 = baseArray2[num];
        base2.Unpause();
        num += 1;
    Label_002C:
        if (num < ((int) baseArray2.Length))
        {
            goto Label_001E;
        }
        return;
    }

    protected virtual unsafe void Update()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_003A;
        }
        if (this.status == 2)
        {
            goto Label_003A;
        }
        if (this.status == 3)
        {
            goto Label_003A;
        }
        if (this.gui.IsNotificationDisplayed() != null)
        {
            goto Label_003A;
        }
        this.EscapePause();
    Label_003A:
        if ((this.hero != null) == null)
        {
            goto Label_0165;
        }
        if (this.hero.IsSelected() == null)
        {
            goto Label_0165;
        }
        if (this.hero.ReadyToMove() == null)
        {
            goto Label_0165;
        }
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_0165;
        }
        if (this.waveCalledThisFrame != null)
        {
            goto Label_0165;
        }
        vector = this.camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, this.camera.nearClipPlane));
        &vector2 = new Vector3(&vector.x, &vector.y, -839f);
        this.hero.RefreshPortrait();
        this.guiBottom.HeroMoved();
        if (this.CheckHeroPortraitClick() == null)
        {
            goto Label_00F3;
        }
        return;
    Label_00F3:
        if (this.hero.ChangeRallyPointHero(new Vector2(&vector.x, &vector.y)) == null)
        {
            goto Label_014E;
        }
        UnityEngine.Object.Instantiate(this.rallyOk, vector2, Quaternion.identity);
        this.guiBottom.HeroChangedRallyPoint();
        this.guiBottom.HideInfo(this.hero.GetComponent<UnitClickable>());
        goto Label_0160;
    Label_014E:
        UnityEngine.Object.Instantiate(this.rallyError, vector2, Quaternion.identity);
    Label_0160:;
    Label_0165:
        return;
    }

    protected void UpdateFlags(float p)
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.flags.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0029;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<WaveSpawnFlag>().UpdateProgress(p);
        Label_0029:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004B;
        }
        finally
        {
        Label_0039:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0044;
            }
        Label_0044:
            disposable.Dispose();
        }
    Label_004B:
        return;
    }

    protected unsafe void UpdateHAX()
    {
        object[] objArray1;
        float num;
        if (Input.GetKeyDown(0x114) == null)
        {
            goto Label_002B;
        }
        GameData.SetCurrentStage(GameData.GetCurrentStageData().Index - 1);
        this.LoadPreviousLevel();
        goto Label_0051;
    Label_002B:
        if (Input.GetKeyDown(0x113) == null)
        {
            goto Label_0051;
        }
        GameData.SetCurrentStage(GameData.GetCurrentStageData().Index + 1);
        this.LoadNextLevel();
    Label_0051:
        if (Input.GetKeyDown(0x125) == null)
        {
            goto Label_00AA;
        }
        objArray1 = new object[] { "Screenshot-", (int) GameData.GetCurrentStageData().Index, "-", &Time.time.ToString(), ".png" };
        Application.CaptureScreenshot(string.Concat(objArray1));
    Label_00AA:
        return;
    }

    private void WaveRecentlyCalledReset()
    {
        this.waveRecentlyCalled = 0;
        return;
    }

    public int MaxUpgradeLevel
    {
        get
        {
            return this.maxUpgradeLevel;
        }
        set
        {
            this.maxUpgradeLevel = value;
            return;
        }
    }

    public AStar PathFinder
    {
        get
        {
            return this.pathFinder;
        }
    }

    public enum states
    {
        LEVEL_NORMAL,
        LEVEL_PRE_WIN,
        LEVEL_WON,
        LEVEL_DEFEAT,
        LEVEL_PAUSE
    }

    public enum terrainType
    {
        GRASS,
        ICE,
        WASTELAND
    }
}

