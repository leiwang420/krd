using System;
using System.Collections;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    private PackedSprite badgeHeroic;
    private PackedSprite badgeIron;
    private PackedSprite badgeStar1;
    private PackedSprite badgeStar2;
    private PackedSprite badgeStar3;
    private PackedSprite campaignButton;
    private PackedSprite heroicButton;
    private Transform holderCampaign;
    private Transform holderHeroic;
    private Transform holderIron;
    private PackedSprite ironButton;
    private StageData lData;
    private LoadingScreen loadingScreen;
    private Map map;
    private Transform thumbnail;
    private Transform thumbnailFrame;
    private PackedSprite toBattleButton;

    public StageSelect()
    {
        base..ctor();
        return;
    }

    private void BadgeSetup()
    {
        if (this.lData.CampaignWin == null)
        {
            goto Label_009F;
        }
        if (this.lData.StarsWon < 1)
        {
            goto Label_002D;
        }
        this.badgeStar1.PlayAnim(0);
    Label_002D:
        if (this.lData.StarsWon < 2)
        {
            goto Label_004A;
        }
        this.badgeStar2.PlayAnim(0);
    Label_004A:
        if (this.lData.StarsWon != 3)
        {
            goto Label_0067;
        }
        this.badgeStar3.PlayAnim(0);
    Label_0067:
        if (this.lData.HeroicModeWin == null)
        {
            goto Label_0083;
        }
        this.badgeHeroic.PlayAnim(0);
    Label_0083:
        if (this.lData.IronModeWin == null)
        {
            goto Label_009F;
        }
        this.badgeIron.PlayAnim(0);
    Label_009F:
        return;
    }

    private void ButtonSetup()
    {
        this.campaignButton.RevertToStatic();
        this.toBattleButton.RevertToStatic();
        if (this.lData.CampaignWin == null)
        {
            goto Label_0037;
        }
        if (this.lData.StarsWon >= 3)
        {
            goto Label_005C;
        }
    Label_0037:
        this.heroicButton.PlayAnim("locked");
        this.ironButton.PlayAnim("locked");
        goto Label_007C;
    Label_005C:
        this.heroicButton.PlayAnim("off");
        this.ironButton.PlayAnim("off");
    Label_007C:
        return;
    }

    private void CleanUp()
    {
        this.map.EnableMapButtons();
        base.transform.position = new Vector3(0f, 1600f, -910f);
        this.ResetFade(base.transform);
        this.badgeStar1.RevertToStatic();
        this.badgeStar2.RevertToStatic();
        this.badgeStar3.RevertToStatic();
        this.badgeHeroic.RevertToStatic();
        this.badgeIron.RevertToStatic();
        return;
    }

    private void Fade(Transform t)
    {
        ParticleFadeOut @out;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if (t.GetComponent<PackedSprite>() == null)
        {
            goto Label_005D;
        }
        if (t.GetComponent<ParticleFadeOut>() != null)
        {
            goto Label_004D;
        }
        @out = t.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        goto Label_0058;
    Label_004D:
        t.GetComponent<ParticleFadeOut>().Fade();
    Label_0058:
        goto Label_007A;
    Label_005D:
        if ((t.GetComponent<TextMesh>() != null) == null)
        {
            goto Label_007A;
        }
        t.gameObject.SetActive(0);
    Label_007A:
        enumerator = t.GetEnumerator();
    Label_0081:
        try
        {
            goto Label_0099;
        Label_0086:
            transform = (Transform) enumerator.Current;
            this.Fade(transform);
        Label_0099:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0086;
            }
            goto Label_00BB;
        }
        finally
        {
        Label_00A9:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B4;
            }
        Label_00B4:
            disposable.Dispose();
        }
    Label_00BB:
        return;
    }

    public void Hide()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 80f, -910f), "time", (double) 0.25, "easetype", (iTween.EaseType) 7, "oncomplete", "CleanUp" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        this.Fade(base.transform);
        this.map.HideOverlay();
        return;
    }

    public void LaunchStage()
    {
        this.map.DisableMapButtons();
        GameData.LevelToLoad = this.lData.Index + 1;
        this.loadingScreen.Launch();
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
            goto Label_001E;
        }
        @out.Reset();
        goto Label_003B;
    Label_001E:
        if ((t.GetComponent<TextMesh>() != null) == null)
        {
            goto Label_003B;
        }
        t.gameObject.SetActive(1);
    Label_003B:
        enumerator = t.GetEnumerator();
    Label_0042:
        try
        {
            goto Label_005A;
        Label_0047:
            transform = (Transform) enumerator.Current;
            this.ResetFade(transform);
        Label_005A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0047;
            }
            goto Label_007C;
        }
        finally
        {
        Label_006A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0075;
            }
        Label_0075:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    public void SetData(StageData data)
    {
        this.lData = data;
        return;
    }

    public void SetGameMode(Constants.gameMode mode)
    {
        if (GameData.GetGameMode() != null)
        {
            goto Label_001F;
        }
        this.campaignButton.PlayAnim("off");
        goto Label_0098;
    Label_001F:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_005E;
        }
        if ((this.heroicButton.GetCurAnim().name != "locked") == null)
        {
            goto Label_005E;
        }
        this.heroicButton.PlayAnim("off");
        goto Label_0098;
    Label_005E:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_0098;
        }
        if ((this.ironButton.GetCurAnim().name != "locked") == null)
        {
            goto Label_0098;
        }
        this.ironButton.PlayAnim("off");
    Label_0098:
        if (mode != null)
        {
            goto Label_00BE;
        }
        this.campaignButton.PlayAnim("over");
        this.toBattleButton.RevertToStatic();
        goto Label_0111;
    Label_00BE:
        if (mode != 1)
        {
            goto Label_00EA;
        }
        this.heroicButton.PlayAnim("over");
        this.toBattleButton.PlayAnim("heroic");
        goto Label_0111;
    Label_00EA:
        if (mode != 2)
        {
            goto Label_0111;
        }
        this.ironButton.PlayAnim("over");
        this.toBattleButton.PlayAnim("iron");
    Label_0111:
        GameData.SetGameMode(mode);
        return;
    }

    public unsafe void Setup()
    {
        int num;
        Transform transform;
        int num2;
        int num3;
        this.campaignButton.gameObject.layer = 10;
        this.heroicButton.gameObject.layer = 10;
        this.ironButton.gameObject.layer = 10;
        GameData.SetGameMode(0);
        this.map.DisableMapButtons();
        num = 1;
        goto Label_0139;
    Label_004E:
        if (this.lData.Index != num)
        {
            goto Label_00E7;
        }
        transform = base.transform.FindChild("Stage" + &num.ToString());
        transform.gameObject.SetActive(1);
        this.holderCampaign = transform.FindChild("HolderCampaign");
        this.holderHeroic = transform.FindChild("HolderHeroic");
        this.holderIron = transform.FindChild("HolderIron");
        base.transform.FindChild("Title" + &num.ToString()).gameObject.SetActive(1);
        goto Label_0135;
    Label_00E7:
        base.transform.FindChild("Stage" + &num.ToString()).gameObject.SetActive(0);
        base.transform.FindChild("Title" + &num.ToString()).gameObject.SetActive(0);
    Label_0135:
        num += 1;
    Label_0139:
        if (num < 0x19)
        {
            goto Label_004E;
        }
        this.thumbnail = base.transform.FindChild("Stage" + &this.lData.Index.ToString()).FindChild("Thumb");
        this.thumbnailFrame = base.transform.FindChild("Stage" + &this.lData.Index.ToString()).FindChild("ThumbFrame");
        this.ButtonSetup();
        this.BadgeSetup();
        this.SetupCampaign();
        return;
    }

    public void SetupCampaign()
    {
        this.holderCampaign.gameObject.SetActive(1);
        this.holderHeroic.gameObject.SetActive(0);
        this.holderIron.gameObject.SetActive(0);
        return;
    }

    public void SetupHeroic()
    {
        this.holderCampaign.gameObject.SetActive(0);
        this.holderHeroic.gameObject.SetActive(1);
        this.holderIron.gameObject.SetActive(0);
        return;
    }

    public void SetupIron()
    {
        this.holderCampaign.gameObject.SetActive(0);
        this.holderHeroic.gameObject.SetActive(0);
        this.holderIron.gameObject.SetActive(1);
        return;
    }

    public void Show()
    {
        object[] objArray1;
        if ((base.transform.position != new Vector3(0f, 1600f, -910f)) == null)
        {
            goto Label_002A;
        }
        return;
    Label_002A:
        this.map.ShowOverlay();
        base.transform.position = new Vector3(0f, 50f, -910f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 0f, -910f), "time", (double) 0.25, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        this.toBattleButton = base.transform.FindChild("ToBattle").GetComponent<PackedSprite>();
        this.campaignButton = base.transform.FindChild("ButtonCampaign").GetComponent<PackedSprite>();
        this.heroicButton = base.transform.FindChild("ButtonHeroic").GetComponent<PackedSprite>();
        this.ironButton = base.transform.FindChild("ButtonIron").GetComponent<PackedSprite>();
        this.badgeStar1 = base.transform.FindChild("BadgeStar1").GetComponent<PackedSprite>();
        this.badgeStar2 = base.transform.FindChild("BadgeStar2").GetComponent<PackedSprite>();
        this.badgeStar3 = base.transform.FindChild("BadgeStar3").GetComponent<PackedSprite>();
        this.badgeHeroic = base.transform.FindChild("BadgeHeroic").GetComponent<PackedSprite>();
        this.badgeIron = base.transform.FindChild("BadgeIron").GetComponent<PackedSprite>();
        this.map = GameObject.Find("Map").GetComponent<Map>();
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_002F;
        }
        if (&base.transform.position.y != 0f)
        {
            goto Label_002F;
        }
        this.Hide();
    Label_002F:
        return;
    }
}

