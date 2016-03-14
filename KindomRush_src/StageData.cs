using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class StageData : ISerializable
{
    private Constants.gameDifficulty campaignDifficulty;
    private bool campaignWin;
    private bool extraModesView;
    private Constants.gameDifficulty heroicDifficulty;
    private bool heroicModeRecentlyWon;
    private bool heroicModeWin;
    private int index;
    private Constants.gameDifficulty ironDifficulty;
    private bool ironModeRecentlyWon;
    private bool ironModeWin;
    private Vector3 position;
    private int starsLastMatch;
    private int starsWon;
    private Constants.levelStatus status;

    public StageData()
    {
        base..ctor();
        return;
    }

    public StageData(SaveGame save)
    {
        base..ctor();
        return;
    }

    public StageData(int i, Vector3 pos)
    {
        base..ctor();
        this.index = i;
        this.position = pos;
        this.campaignWin = 0;
        this.heroicModeWin = 0;
        this.ironModeWin = 0;
        this.heroicModeRecentlyWon = 0;
        this.ironModeRecentlyWon = 0;
        this.campaignDifficulty = 0;
        this.heroicDifficulty = 0;
        this.ironDifficulty = 0;
        this.starsWon = 0;
        this.starsLastMatch = 0;
        this.extraModesView = 0;
        this.status = 0;
        return;
    }

    public StageData(SerializationInfo info, StreamingContext context)
    {
        float num;
        float num2;
        float num3;
        base..ctor();
        this.index = (int) info.GetValue("index", typeof(int));
        num = (float) info.GetValue("positionX", typeof(float));
        num2 = (float) info.GetValue("positionY", typeof(float));
        num3 = (float) info.GetValue("positionZ", typeof(float));
        this.campaignWin = (bool) info.GetValue("campaignWin", typeof(bool));
        this.heroicModeWin = (bool) info.GetValue("heroicModeWin", typeof(bool));
        this.ironModeWin = (bool) info.GetValue("ironModeWin", typeof(bool));
        this.heroicModeRecentlyWon = (bool) info.GetValue("heroicModeRecentlyWon", typeof(bool));
        this.ironModeRecentlyWon = (bool) info.GetValue("ironModeRecentlyWon", typeof(bool));
        this.campaignDifficulty = (int) info.GetValue("campaignDifficulty", typeof(Constants.gameDifficulty));
        this.heroicDifficulty = (int) info.GetValue("heroicDifficulty", typeof(Constants.gameDifficulty));
        this.ironDifficulty = (int) info.GetValue("ironDifficulty", typeof(Constants.gameDifficulty));
        this.starsWon = (int) info.GetValue("starsWon", typeof(int));
        this.starsLastMatch = (int) info.GetValue("starsLastMatch", typeof(int));
        this.extraModesView = (bool) info.GetValue("extraModesView", typeof(bool));
        this.status = (int) info.GetValue("status", typeof(Constants.levelStatus));
        this.position = new Vector3(num, num2, num3);
        return;
    }

    public void ChangeStatus(Constants.levelStatus newStatus)
    {
        this.status = newStatus;
        GameData.SaveGameData();
        return;
    }

    public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("index", (int) this.index, typeof(int));
        info.AddValue("positionX", (float) &this.position.x, typeof(float));
        info.AddValue("positionY", (float) &this.position.y, typeof(float));
        info.AddValue("positionZ", (float) &this.position.z, typeof(float));
        info.AddValue("campaignWin", (bool) this.campaignWin, typeof(bool));
        info.AddValue("heroicModeWin", (bool) this.heroicModeWin, typeof(bool));
        info.AddValue("ironModeWin", (bool) this.ironModeWin, typeof(bool));
        info.AddValue("heroicModeRecentlyWon", (bool) this.heroicModeRecentlyWon, typeof(bool));
        info.AddValue("ironModeRecentlyWon", (bool) this.ironModeRecentlyWon, typeof(bool));
        info.AddValue("campaignDifficulty", (Constants.gameDifficulty) this.campaignDifficulty, typeof(Constants.gameDifficulty));
        info.AddValue("heroicDifficulty", (Constants.gameDifficulty) this.heroicDifficulty, typeof(Constants.gameDifficulty));
        info.AddValue("ironDifficulty", (Constants.gameDifficulty) this.ironDifficulty, typeof(Constants.gameDifficulty));
        info.AddValue("starsWon", (int) this.starsWon, typeof(int));
        info.AddValue("starsLastMatch", (int) this.starsLastMatch, typeof(int));
        info.AddValue("extraModesView", (bool) this.extraModesView, typeof(bool));
        info.AddValue("status", (Constants.levelStatus) this.status, typeof(Constants.levelStatus));
        return;
    }

    public void Reset()
    {
        this.campaignWin = 0;
        this.heroicModeWin = 0;
        this.ironModeWin = 0;
        this.heroicModeRecentlyWon = 0;
        this.ironModeRecentlyWon = 0;
        this.campaignDifficulty = 0;
        this.heroicDifficulty = 0;
        this.ironDifficulty = 0;
        this.starsWon = 0;
        this.starsLastMatch = 0;
        this.extraModesView = 0;
        this.status = 0;
        return;
    }

    public void Win(int stars)
    {
        if (this.starsWon >= stars)
        {
            goto Label_0026;
        }
        GameData.AddStarsWon(stars - this.starsWon);
        GameData.AddStarsToSpent(stars - this.starsWon);
    Label_0026:
        this.starsLastMatch = stars;
        if (this.campaignDifficulty != null)
        {
            goto Label_0043;
        }
        if (this.campaignWin != null)
        {
            goto Label_004E;
        }
    Label_0043:
        this.campaignDifficulty = GameData.SelectedDifficulty();
    Label_004E:
        if (this.status == 1)
        {
            goto Label_0066;
        }
        if (this.status != 2)
        {
            goto Label_0072;
        }
    Label_0066:
        this.status = 4;
        goto Label_0085;
    Label_0072:
        if (this.starsWon >= stars)
        {
            goto Label_0085;
        }
        this.status = 5;
    Label_0085:
        if (this.starsWon >= stars)
        {
            goto Label_0098;
        }
        this.starsWon = stars;
    Label_0098:
        this.campaignWin = 1;
        GameAchievements.CheckStars(GameData.StarsWon);
        GameData.SaveGameData();
        return;
    }

    public void WinHeroic()
    {
        if (this.heroicModeWin == null)
        {
            goto Label_0027;
        }
        if (this.heroicDifficulty == null)
        {
            goto Label_0026;
        }
        this.heroicDifficulty = GameData.SelectedDifficulty();
        GameData.SaveGameData();
    Label_0026:
        return;
    Label_0027:
        this.heroicModeWin = 1;
        this.heroicModeRecentlyWon = 1;
        this.heroicDifficulty = GameData.SelectedDifficulty();
        GameData.AddStarsWon(1);
        GameData.AddStarsToSpent(1);
        GameAchievements.CheckStars(GameData.StarsWon);
        GameData.SaveGameData();
        return;
    }

    public void WinIron()
    {
        if (this.ironModeWin == null)
        {
            goto Label_0027;
        }
        if (this.ironDifficulty == null)
        {
            goto Label_0026;
        }
        this.ironDifficulty = GameData.SelectedDifficulty();
        GameData.SaveGameData();
    Label_0026:
        return;
    Label_0027:
        this.ironModeWin = 1;
        this.ironModeRecentlyWon = 1;
        this.ironDifficulty = GameData.SelectedDifficulty();
        GameData.AddStarsWon(1);
        GameData.AddStarsToSpent(1);
        GameAchievements.CheckStars(GameData.StarsWon);
        GameData.SaveGameData();
        return;
    }

    public Constants.gameDifficulty CampaignDifficulty
    {
        get
        {
            return this.campaignDifficulty;
        }
        set
        {
            this.campaignDifficulty = value;
            return;
        }
    }

    public bool CampaignWin
    {
        get
        {
            return this.campaignWin;
        }
        set
        {
            this.campaignWin = value;
            return;
        }
    }

    public bool ExtraModesView
    {
        get
        {
            return this.extraModesView;
        }
        set
        {
            this.extraModesView = value;
            return;
        }
    }

    public Constants.gameDifficulty HeroicDifficulty
    {
        get
        {
            return this.heroicDifficulty;
        }
        set
        {
            this.heroicDifficulty = value;
            return;
        }
    }

    public bool HeroicModeRecentlyWon
    {
        get
        {
            return this.heroicModeRecentlyWon;
        }
        set
        {
            this.heroicModeRecentlyWon = value;
            return;
        }
    }

    public bool HeroicModeWin
    {
        get
        {
            return this.heroicModeWin;
        }
        set
        {
            this.heroicModeWin = value;
            return;
        }
    }

    public int Index
    {
        get
        {
            return this.index;
        }
        set
        {
            this.index = value;
            return;
        }
    }

    public Constants.gameDifficulty IronDifficulty
    {
        get
        {
            return this.ironDifficulty;
        }
        set
        {
            this.ironDifficulty = value;
            return;
        }
    }

    public bool IronModeRecentlyWon
    {
        get
        {
            return this.ironModeRecentlyWon;
        }
        set
        {
            this.ironModeRecentlyWon = value;
            return;
        }
    }

    public bool IronModeWin
    {
        get
        {
            return this.ironModeWin;
        }
        set
        {
            this.ironModeWin = value;
            return;
        }
    }

    public Vector3 Position
    {
        get
        {
            return this.position;
        }
    }

    public int StarsLastMatch
    {
        get
        {
            return this.starsLastMatch;
        }
        set
        {
            this.starsLastMatch = value;
            return;
        }
    }

    public int StarsWon
    {
        get
        {
            return this.starsWon;
        }
        set
        {
            this.starsWon = value;
            return;
        }
    }

    public Constants.levelStatus Status
    {
        get
        {
            return this.status;
        }
        set
        {
            this.status = value;
            return;
        }
    }
}

