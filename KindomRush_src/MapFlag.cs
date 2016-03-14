using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class MapFlag : MonoBehaviour
{
    private ButtonConfig buttonConfig;
    private StageData lData;
    private Map map;
    private PackedSprite sprite;
    private StageSelect stageSelect;
    private PackedSprite star1;
    private PackedSprite star2;
    private PackedSprite star3;

    public MapFlag()
    {
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        Constants.levelStatus status;
        switch ((this.lData.Status - 1))
        {
            case 0:
                goto Label_002D;

            case 1:
                goto Label_0032;

            case 2:
                goto Label_0087;

            case 3:
                goto Label_003D;

            case 4:
                goto Label_00EA;
        }
        goto Label_00EF;
    Label_002D:
        goto Label_00F4;
    Label_0032:
        this.SetNewIdle();
        goto Label_00F4;
    Label_003D:
        if (this.lData.IronModeWin == null)
        {
            goto Label_006A;
        }
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(6);
        goto Label_0082;
    Label_006A:
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(7);
    Label_0082:
        goto Label_00F4;
    Label_0087:
        if (this.lData.IronModeWin == null)
        {
            goto Label_00AC;
        }
        base.Invoke("IronIdle", 0.65f);
        goto Label_00E5;
    Label_00AC:
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(7);
        if (this.lData.Index != 1)
        {
            goto Label_00F4;
        }
        base.Invoke("ShowBalloonUpgrades", 0.75f);
    Label_00E5:
        goto Label_00F4;
    Label_00EA:
        goto Label_00F4;
    Label_00EF:;
    Label_00F4:
        return;
    }

    private void Awake()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        this.star1 = base.transform.FindChild("Star1").GetComponent<PackedSprite>();
        this.star2 = base.transform.FindChild("Star2").GetComponent<PackedSprite>();
        this.star3 = base.transform.FindChild("Star3").GetComponent<PackedSprite>();
        return;
    }

    private void EvalStatus()
    {
        Constants.levelStatus status;
        switch (this.lData.Status)
        {
            case 0:
                goto Label_0093;

            case 1:
                goto Label_002F;

            case 2:
                goto Label_0046;

            case 3:
                goto Label_006F;

            case 4:
                goto Label_0051;

            case 5:
                goto Label_0081;
        }
        goto Label_00AE;
    Label_002F:
        this.PlayNewFlag();
        this.lData.ChangeStatus(2);
        goto Label_00B3;
    Label_0046:
        this.SetNewIdle();
        goto Label_00B3;
    Label_0051:
        this.PlayWonCampaign();
        this.LoadStars(1);
        this.lData.ChangeStatus(3);
        goto Label_00B3;
    Label_006F:
        this.SetOldIdle();
        this.LoadStars(0);
        goto Label_00B3;
    Label_0081:
        this.PlayWonCampaign();
        this.LoadStars(1);
        goto Label_00B3;
    Label_0093:
        this.PlayNewFlag();
        base.Invoke("SetNewIdle", 0.8f);
        goto Label_00B3;
    Label_00AE:;
    Label_00B3:
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Init(StageData myData)
    {
        base.transform.position = myData.Position;
        this.lData = myData;
        if (this.lData.Index != 0x11)
        {
            goto Label_002A;
        }
    Label_002A:
        this.EvalStatus();
        return;
    }

    private void IronIdle()
    {
        if (this.sprite.IsAnimating() == null)
        {
            goto Label_0027;
        }
        if (this.sprite.GetCurAnim().index != 6)
        {
            goto Label_0027;
        }
        return;
    Label_0027:
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(6);
        return;
    }

    private void LoadStars(bool animated = true)
    {
        if (this.lData.Status == 3)
        {
            goto Label_0033;
        }
        if (this.lData.Status == 5)
        {
            goto Label_0033;
        }
        if (this.lData.Status != 4)
        {
            goto Label_00D6;
        }
    Label_0033:
        if (animated == null)
        {
            goto Label_004E;
        }
        base.Invoke("ShowStar1Anim", 0.25f);
        goto Label_005E;
    Label_004E:
        base.Invoke("ShowStar1", 0.05f);
    Label_005E:
        if (this.lData.StarsWon <= 1)
        {
            goto Label_009A;
        }
        if (animated == null)
        {
            goto Label_008A;
        }
        base.Invoke("ShowStar2Anim", 0.85f);
        goto Label_009A;
    Label_008A:
        base.Invoke("ShowStar2", 0.05f);
    Label_009A:
        if (this.lData.StarsWon <= 2)
        {
            goto Label_00D6;
        }
        if (animated == null)
        {
            goto Label_00C6;
        }
        base.Invoke("ShowStar3Anim", 1.35f);
        goto Label_00D6;
    Label_00C6:
        base.Invoke("ShowStar3", 0.05f);
    Label_00D6:
        return;
    }

    private void OnMouseDown()
    {
        GameData.SetCurrentStage(this.lData.Index);
        this.stageSelect.SetData(this.lData);
        this.stageSelect.Setup();
        this.stageSelect.Show();
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    private void OnMouseEnter()
    {
        if (this.lData.IronModeWin == null)
        {
            goto Label_0025;
        }
        this.sprite.PlayAnim("ironOver");
        goto Label_005A;
    Label_0025:
        if (this.lData.CampaignWin == null)
        {
            goto Label_004A;
        }
        this.sprite.PlayAnim("newCompletedOver");
        goto Label_005A;
    Label_004A:
        this.sprite.PlayAnim("newOver");
    Label_005A:
        base.GetComponent<AnimationDelay>().Pause();
        GameSoundManager.PlayGUIQuickMenuOver();
        return;
    }

    private void OnMouseExit()
    {
        if (this.lData.IronModeWin == null)
        {
            goto Label_0030;
        }
        this.sprite.PlayAnim("ironIdle");
        this.sprite.PauseAnim();
        goto Label_007B;
    Label_0030:
        if (this.lData.CampaignWin == null)
        {
            goto Label_0060;
        }
        this.sprite.PlayAnim("completedIdle");
        this.sprite.PauseAnim();
        goto Label_007B;
    Label_0060:
        this.sprite.PlayAnim("newIdle");
        this.sprite.PauseAnim();
    Label_007B:
        base.GetComponent<AnimationDelay>().Unpause();
        return;
    }

    private void PlayAnimDelay()
    {
        base.GetComponent<AnimationDelay>().SetCurrentAnim(2);
        return;
    }

    private void PlayNewFlag()
    {
        this.sprite.PlayAnim("newFlag");
        GameSoundManager.PlayGUIMapNewFlag();
        return;
    }

    private void PlayWonCampaign()
    {
        if (this.lData.Status == 4)
        {
            goto Label_0022;
        }
        if (this.lData.Status != 5)
        {
            goto Label_0037;
        }
    Label_0022:
        this.sprite.PlayAnim("newCompleted");
        goto Label_0047;
    Label_0037:
        base.Invoke("PlayAnimDelay", 0.8f);
    Label_0047:
        base.Invoke("PlayWonCampaignEnd", 2.5f);
        return;
    }

    private void PlayWonCampaignEnd()
    {
        if (this.lData.Status != 5)
        {
            goto Label_001E;
        }
        this.lData.ChangeStatus(3);
        return;
    Label_001E:
        if (this.lData.Index >= GameData.GetCampaign().Count)
        {
            goto Label_004F;
        }
        this.map.AddRoadAndNewFlag(this.lData.Index, 1);
    Label_004F:
        return;
    }

    private void PlayWonIron()
    {
        this.sprite.PlayAnim("iron");
        base.Invoke("IronIdle", 1f);
        this.lData.IronModeRecentlyWon = 0;
        GameData.SaveGameData();
        return;
    }

    private void SetIdle()
    {
        Constants.levelStatus status;
        status = this.lData.Status;
        if (status == 2)
        {
            goto Label_001F;
        }
        if (status == 3)
        {
            goto Label_002A;
        }
        goto Label_0035;
    Label_001F:
        this.SetNewIdle();
        goto Label_003A;
    Label_002A:
        this.SetOldIdle();
        goto Label_003A;
    Label_0035:;
    Label_003A:
        return;
    }

    private void SetNewIdle()
    {
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(8);
        if (this.lData.Index != 1)
        {
            goto Label_0039;
        }
        base.Invoke("ShowBallonDelay", 0.5f);
    Label_0039:
        return;
    }

    private void SetOldIdle()
    {
        if (this.lData.IronModeRecentlyWon == null)
        {
            goto Label_0025;
        }
        base.Invoke("PlayWonIron", 0.01f);
        goto Label_006A;
    Label_0025:
        if (this.lData.IronModeWin != null)
        {
            goto Label_0052;
        }
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(7);
        goto Label_006A;
    Label_0052:
        base.GetComponent<AnimationDelay>().enabled = 1;
        base.GetComponent<AnimationDelay>().SetCurrentAnim(6);
    Label_006A:
        return;
    }

    private void ShowBallonDelay()
    {
        this.map.ShowBalloonStart();
        return;
    }

    private void ShowBalloonUpgrades()
    {
        this.map.ShowBalloonUpgrades();
        return;
    }

    private void ShowStar1()
    {
        this.star1.Hide(0);
        return;
    }

    private void ShowStar1Anim()
    {
        this.star1.Hide(0);
        this.star1.PlayAnim(0);
        GameSoundManager.PlayGUIWinStars();
        return;
    }

    private void ShowStar2()
    {
        this.star2.Hide(0);
        return;
    }

    private void ShowStar2Anim()
    {
        this.star2.Hide(0);
        this.star2.PlayAnim(0);
        GameSoundManager.PlayGUIWinStars();
        return;
    }

    private void ShowStar3()
    {
        this.star3.Hide(0);
        return;
    }

    private void ShowStar3Anim()
    {
        this.star3.Hide(0);
        this.star3.PlayAnim(0);
        GameSoundManager.PlayGUIWinStars();
        return;
    }

    private void Start()
    {
        this.buttonConfig = GameObject.Find("ButtonConfig").GetComponent<ButtonConfig>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.stageSelect = GameObject.Find("Stage Select").GetComponent<StageSelect>();
        return;
    }
}

