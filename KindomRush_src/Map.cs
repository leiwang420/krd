using System;
using System.Collections;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject achievementButton;
    private int auxFlagIndex;
    private GameObject configButton;
    private GameObject encyclopediaButton;
    private GameObject heroRoomButton;
    private int lastActiveLevel;
    private int lastCompletedLevel;
    private int lastCompletedLevelNew;
    public Transform mapFlagPrefab;
    public Transform mapFlagWingsPrefab;
    private AudioSource music;
    private PackedSprite overlaySprite;
    private ArrayList roadAnimationTime;
    private ArrayList roadPaths;
    private PackedSprite spriteBalloonHero;
    private PackedSprite spriteBalloonStart;
    private PackedSprite spriteBalloonUpgrades;
    private GameObject upgradesButton;

    public Map()
    {
        base..ctor();
        return;
    }

    private void AddExtraWinLevels()
    {
        if (((StageData) GameData.GetCampaign()[15]).Status == 3)
        {
            goto Label_0054;
        }
        if (((StageData) GameData.GetCampaign()[15]).Status == 5)
        {
            goto Label_0054;
        }
        if (((StageData) GameData.GetCampaign()[15]).Status != 4)
        {
            goto Label_009D;
        }
    Label_0054:
        if (((StageData) GameData.GetCampaign()[0x10]).Status != null)
        {
            goto Label_009D;
        }
        ((StageData) GameData.GetCampaign()[0x10]).ChangeStatus(1);
        this.AddFlag((StageData) GameData.GetCampaign()[0x10]);
    Label_009D:
        if (((StageData) GameData.GetCampaign()[0x11]).Status == 3)
        {
            goto Label_00F1;
        }
        if (((StageData) GameData.GetCampaign()[0x11]).Status == 5)
        {
            goto Label_00F1;
        }
        if (((StageData) GameData.GetCampaign()[0x11]).Status != 4)
        {
            goto Label_013A;
        }
    Label_00F1:
        if (((StageData) GameData.GetCampaign()[0x12]).Status != null)
        {
            goto Label_013A;
        }
        ((StageData) GameData.GetCampaign()[0x12]).ChangeStatus(1);
        this.AddFlag((StageData) GameData.GetCampaign()[0x12]);
    Label_013A:
        if (((StageData) GameData.GetCampaign()[0x13]).Status == 3)
        {
            goto Label_018E;
        }
        if (((StageData) GameData.GetCampaign()[0x13]).Status == 5)
        {
            goto Label_018E;
        }
        if (((StageData) GameData.GetCampaign()[0x13]).Status != 4)
        {
            goto Label_01D7;
        }
    Label_018E:
        if (((StageData) GameData.GetCampaign()[20]).Status != null)
        {
            goto Label_01D7;
        }
        ((StageData) GameData.GetCampaign()[20]).ChangeStatus(1);
        this.AddFlag((StageData) GameData.GetCampaign()[20]);
    Label_01D7:
        return;
    }

    private void AddFlag(StageData data)
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.mapFlagPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.GetComponent<MapFlag>().Init(data);
        return;
    }

    public void AddRoadAndNewFlag(int index, bool withAnimation)
    {
        PackedSprite sprite;
        StageData data;
        int num;
        if (index < 12)
        {
            goto Label_0009;
        }
        return;
    Label_0009:
        sprite = (PackedSprite) this.roadPaths[index - 1];
        sprite.Hide(0);
        if (withAnimation == null)
        {
            goto Label_0079;
        }
        sprite.PlayAnim(0);
        this.auxFlagIndex = index;
        data = (StageData) GameData.GetCampaign()[index];
        data.Status = 1;
        base.Invoke("PlayFlagAnim", ((float) this.roadAnimationTime[index - 1]) + 0.25f);
        goto Label_0094;
    Label_0079:
        num = sprite.GetAnim("New Animation").GetFrameCount() - 1;
        sprite.PlayAnim(0, num);
    Label_0094:
        return;
    }

    private unsafe void AddWings(Vector3 p, bool animated)
    {
        Transform transform;
        PackedSprite sprite;
        transform = UnityEngine.Object.Instantiate(this.mapFlagWingsPrefab, new Vector3(&p.x - 2f, &p.y, &p.z + 1f), Quaternion.identity) as Transform;
        sprite = transform.GetComponent<PackedSprite>();
        if (animated == null)
        {
            goto Label_0050;
        }
        sprite.PlayAnim(0);
    Label_0050:
        return;
    }

    private void Awake()
    {
        this.music = GameObject.Find("MapMusic").GetComponent<AudioSource>();
        this.music.volume = GameSoundManager.GetVolumeMusic();
        this.music.Play();
        return;
    }

    public void CheckAchievements()
    {
        bool flag;
        ArrayList list;
        int num;
        int num2;
        int num3;
        flag = 1;
        list = GameData.GetCampaign();
        if (GameAchievements.GreatDefender != null)
        {
            goto Label_0064;
        }
        num = 0;
        goto Label_0050;
    Label_0019:
        if (((StageData) list[num]).CampaignWin == null)
        {
            goto Label_0045;
        }
        if (((StageData) list[num]).CampaignDifficulty == null)
        {
            goto Label_004C;
        }
    Label_0045:
        flag = 0;
        goto Label_0058;
    Label_004C:
        num += 1;
    Label_0050:
        if (num < 12)
        {
            goto Label_0019;
        }
    Label_0058:
        if (flag == null)
        {
            goto Label_0064;
        }
        GameAchievements.ChkGreatDefender(0);
    Label_0064:
        if (GameAchievements.GreatDefenderHeroic != null)
        {
            goto Label_00C2;
        }
        flag = 1;
        num2 = 0;
        goto Label_00AE;
    Label_0077:
        if (((StageData) list[num2]).HeroicModeWin == null)
        {
            goto Label_00A3;
        }
        if (((StageData) list[num2]).HeroicDifficulty == null)
        {
            goto Label_00AA;
        }
    Label_00A3:
        flag = 0;
        goto Label_00B6;
    Label_00AA:
        num2 += 1;
    Label_00AE:
        if (num2 < 12)
        {
            goto Label_0077;
        }
    Label_00B6:
        if (flag == null)
        {
            goto Label_00C2;
        }
        GameAchievements.ChkGreatDefenderHeroic(0);
    Label_00C2:
        if (GameAchievements.GreatDefenderIron != null)
        {
            goto Label_0126;
        }
        flag = 1;
        num3 = 0;
        goto Label_0111;
    Label_00D6:
        if (((StageData) list[num3]).IronModeWin == null)
        {
            goto Label_0104;
        }
        if (((StageData) list[num3]).IronDifficulty == null)
        {
            goto Label_010B;
        }
    Label_0104:
        flag = 0;
        goto Label_011A;
    Label_010B:
        num3 += 1;
    Label_0111:
        if (num3 < 12)
        {
            goto Label_00D6;
        }
    Label_011A:
        if (flag == null)
        {
            goto Label_0126;
        }
        GameAchievements.ChkGreatDefenderIron(0);
    Label_0126:
        GameAchievements.SendAllAchievements();
        return;
    }

    private void CreateGameProgress()
    {
        ArrayList list;
        int num;
        StageData data;
        IEnumerator enumerator;
        StageData data2;
        int num2;
        IDisposable disposable;
        this.lastCompletedLevel = 0;
        this.lastCompletedLevelNew = 0;
        this.lastActiveLevel = 0;
        list = GameData.GetCampaign();
        num = 1;
        enumerator = list.GetEnumerator();
    Label_0024:
        try
        {
            goto Label_00C7;
        Label_0029:
            data = (StageData) enumerator.Current;
            if (data.Status == null)
            {
                goto Label_00C3;
            }
            this.lastActiveLevel = num;
            if (data.Status == 1)
            {
                goto Label_0080;
            }
            if (data.Status == 2)
            {
                goto Label_0080;
            }
            this.lastCompletedLevel = num;
            if (data.Status != 4)
            {
                goto Label_0080;
            }
            this.lastCompletedLevelNew = num;
            this.UpdateBalloonHero(num);
        Label_0080:
            if (data.HeroicModeWin == null)
            {
                goto Label_00BC;
            }
            if (data.HeroicModeRecentlyWon == null)
            {
                goto Label_00AF;
            }
            data.HeroicModeRecentlyWon = 0;
            this.AddWings(data.Position, 1);
            goto Label_00BC;
        Label_00AF:
            this.AddWings(data.Position, 0);
        Label_00BC:
            this.AddFlag(data);
        Label_00C3:
            num += 1;
        Label_00C7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0029;
            }
            goto Label_00EC;
        }
        finally
        {
        Label_00D7:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E4;
            }
        Label_00E4:
            disposable.Dispose();
        }
    Label_00EC:
        if (this.lastActiveLevel < 12)
        {
            goto Label_0101;
        }
        this.lastActiveLevel = 12;
    Label_0101:
        if (this.lastCompletedLevelNew != 12)
        {
            goto Label_0119;
        }
        this.EnableExtraLevels();
        goto Label_019B;
    Label_0119:
        if (this.lastCompletedLevelNew != null)
        {
            goto Label_019B;
        }
        if (this.lastCompletedLevel == null)
        {
            goto Label_019B;
        }
        if (this.lastCompletedLevel >= 12)
        {
            goto Label_019B;
        }
        if (((StageData) list[this.lastCompletedLevel]).Status != null)
        {
            goto Label_019B;
        }
        this.lastActiveLevel += 1;
        ((StageData) list[this.lastCompletedLevel]).Status = 2;
        data2 = (StageData) GameData.GetCampaign()[this.lastCompletedLevel];
        this.AddFlag(data2);
    Label_019B:
        num2 = 1;
        goto Label_01B2;
    Label_01A3:
        this.AddRoadAndNewFlag(num2, 0);
        num2 += 1;
    Label_01B2:
        if (num2 < this.lastActiveLevel)
        {
            goto Label_01A3;
        }
        this.AddExtraWinLevels();
        return;
    }

    private void DelayedStart()
    {
        this.CreateGameProgress();
        this.CheckAchievements();
        return;
    }

    private void DeleteMapFlags()
    {
        MapFlag[] flagArray;
        MapFlag flag;
        MapFlag[] flagArray2;
        int num;
        flagArray = UnityEngine.Object.FindObjectsOfType(typeof(MapFlag)) as MapFlag[];
        flagArray2 = flagArray;
        num = 0;
        goto Label_0031;
    Label_001E:
        flag = flagArray2[num];
        UnityEngine.Object.Destroy(flag.gameObject);
        num += 1;
    Label_0031:
        if (num < ((int) flagArray2.Length))
        {
            goto Label_001E;
        }
        return;
    }

    public void DisableMapButtons()
    {
        MapFlag[] flagArray;
        MapFlag flag;
        MapFlag[] flagArray2;
        int num;
        flagArray = UnityEngine.Object.FindObjectsOfType(typeof(MapFlag)) as MapFlag[];
        flagArray2 = flagArray;
        num = 0;
        goto Label_0032;
    Label_001E:
        flag = flagArray2[num];
        flag.collider.enabled = 0;
        num += 1;
    Label_0032:
        if (num < ((int) flagArray2.Length))
        {
            goto Label_001E;
        }
        this.heroRoomButton.collider.enabled = 0;
        this.upgradesButton.collider.enabled = 0;
        this.encyclopediaButton.collider.enabled = 0;
        this.achievementButton.collider.enabled = 0;
        this.configButton.collider.enabled = 0;
        return;
    }

    private void EnableExtraLevels()
    {
        StageData data;
        data = (StageData) GameData.GetCampaign()[12];
        data.ChangeStatus(1);
        this.AddFlag(data);
        data = (StageData) GameData.GetCampaign()[13];
        data.ChangeStatus(1);
        this.AddFlag(data);
        data = (StageData) GameData.GetCampaign()[14];
        data.ChangeStatus(1);
        this.AddFlag(data);
        data = (StageData) GameData.GetCampaign()[15];
        data.ChangeStatus(1);
        this.AddFlag(data);
        data = (StageData) GameData.GetCampaign()[0x11];
        data.ChangeStatus(1);
        this.AddFlag(data);
        data = (StageData) GameData.GetCampaign()[0x13];
        data.ChangeStatus(1);
        this.AddFlag(data);
        return;
    }

    public void EnableMapButtons()
    {
        MapFlag[] flagArray;
        MapFlag flag;
        MapFlag[] flagArray2;
        int num;
        flagArray = UnityEngine.Object.FindObjectsOfType(typeof(MapFlag)) as MapFlag[];
        flagArray2 = flagArray;
        num = 0;
        goto Label_0032;
    Label_001E:
        flag = flagArray2[num];
        flag.collider.enabled = 1;
        num += 1;
    Label_0032:
        if (num < ((int) flagArray2.Length))
        {
            goto Label_001E;
        }
        this.heroRoomButton.collider.enabled = 1;
        this.upgradesButton.collider.enabled = 1;
        this.encyclopediaButton.collider.enabled = 1;
        this.achievementButton.collider.enabled = 1;
        this.configButton.collider.enabled = 1;
        return;
    }

    private void FixedUpdate()
    {
    }

    public void HideBallonUpgrades()
    {
        this.spriteBalloonUpgrades.Hide(1);
        return;
    }

    public void HideOverlay()
    {
        this.overlaySprite.Hide(1);
        return;
    }

    private void HideRoads()
    {
        PackedSprite sprite;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.roadPaths.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0024;
        Label_0011:
            sprite = (PackedSprite) enumerator.Current;
            sprite.Hide(1);
        Label_0024:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0046;
        }
        finally
        {
        Label_0034:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_003F;
            }
        Label_003F:
            disposable.Dispose();
        }
    Label_0046:
        return;
    }

    public void PlayFlagAnim()
    {
        StageData data;
        data = (StageData) GameData.GetCampaign()[this.auxFlagIndex];
        this.AddFlag(data);
        return;
    }

    public void ShowBalloonStart()
    {
        this.spriteBalloonStart.Hide(0);
        return;
    }

    public void ShowBalloonUpgrades()
    {
        this.spriteBalloonUpgrades.Hide(0);
        return;
    }

    public void ShowOverlay()
    {
        this.overlaySprite.Hide(0);
        this.overlaySprite.GetComponent<ParticleFadeIn>().FadeIn();
        return;
    }

    private void Start()
    {
        CameraMap map;
        Application.targetFrameRate = 60;
        Screen.showCursor = 1;
        this.heroRoomButton = GameObject.Find("HeroRoomButton");
        this.upgradesButton = GameObject.Find("UpgradesButton");
        this.encyclopediaButton = GameObject.Find("EncyclopediaButton");
        this.achievementButton = GameObject.Find("AchievementButton");
        this.configButton = GameObject.Find("ButtonConfig");
        this.overlaySprite = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        this.overlaySprite.GetComponent<ParticleFadeOut>().Fade();
        this.spriteBalloonStart = GameObject.Find("BallonStart").GetComponent<PackedSprite>();
        this.spriteBalloonUpgrades = GameObject.Find("BalloonUpgrades").GetComponent<PackedSprite>();
        this.spriteBalloonHero = GameObject.Find("BalloonHero").GetComponent<PackedSprite>();
        this.roadPaths = new ArrayList();
        this.roadPaths.Add(base.transform.FindChild("Path1").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path2").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path3").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path4").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path5").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path6").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path7").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path8").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path9").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path10").GetComponent<PackedSprite>());
        this.roadPaths.Add(base.transform.FindChild("Path11").GetComponent<PackedSprite>());
        this.roadAnimationTime = new ArrayList();
        this.roadAnimationTime.Add((float) 0.3f);
        this.roadAnimationTime.Add((float) 0.3f);
        this.roadAnimationTime.Add((float) 0.8f);
        this.roadAnimationTime.Add((float) 0.96f);
        this.roadAnimationTime.Add((float) 1.93f);
        this.roadAnimationTime.Add((float) 1.63f);
        this.roadAnimationTime.Add((float) 1.1f);
        this.roadAnimationTime.Add((float) 3.83f);
        this.roadAnimationTime.Add((float) 2.96f);
        this.roadAnimationTime.Add((float) 0.8f);
        this.roadAnimationTime.Add((float) 2.33f);
        if (((StageData) GameData.GetCampaign()[0]).Status != 1)
        {
            goto Label_0364;
        }
        base.Invoke("DelayedStart", 0.1f);
        goto Label_036A;
    Label_0364:
        this.DelayedStart();
    Label_036A:
        if (GameData.LastLevelCompleted == null)
        {
            goto Label_03C6;
        }
        if (GameData.LastLevelCompleted == 9)
        {
            goto Label_03B0;
        }
        if (GameData.LastLevelCompleted == 10)
        {
            goto Label_03B0;
        }
        if (GameData.LastLevelCompleted == 11)
        {
            goto Label_03B0;
        }
        if (GameData.LastLevelCompleted == 12)
        {
            goto Label_03B0;
        }
        if (GameData.LastLevelCompleted != 15)
        {
            goto Label_03C6;
        }
    Label_03B0:
        GameObject.Find("Main Camera Map").GetComponent<CameraMap>().SetFarRightPosition();
    Label_03C6:
        return;
    }

    private void UnWin(int i)
    {
        ArrayList list;
        StageData data;
        list = GameData.GetCampaign();
        data = (StageData) list[i];
        data.Reset();
        data = (StageData) list[i - 1];
        data.Reset();
        if ((i - 1) != null)
        {
            goto Label_003D;
        }
        data.Status = 1;
    Label_003D:
        return;
    }

    private void UpdateBalloonHero(int levelIndex)
    {
        if (levelIndex == 3)
        {
            goto Label_0034;
        }
        if (levelIndex == 5)
        {
            goto Label_0034;
        }
        if (levelIndex == 7)
        {
            goto Label_0034;
        }
        if (levelIndex == 8)
        {
            goto Label_0034;
        }
        if (levelIndex == 10)
        {
            goto Label_0034;
        }
        if (levelIndex == 11)
        {
            goto Label_0034;
        }
        if (levelIndex != 12)
        {
            goto Label_0040;
        }
    Label_0034:
        this.spriteBalloonHero.Hide(0);
    Label_0040:
        return;
    }
}

