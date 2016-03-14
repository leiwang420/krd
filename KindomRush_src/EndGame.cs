using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private Transform balloon1;
    private Transform balloon10;
    private Transform balloon11;
    private Transform balloon12;
    private Transform balloon13;
    private Transform balloon2;
    private Transform balloon3;
    private Transform balloon4;
    private Transform balloon5;
    private Transform balloon6;
    private Transform balloon7;
    private Transform balloon8;
    private Transform balloon9;
    private Transform buttonContinue1;
    private Transform buttonContinue2;
    private Transform comic1;
    private Transform comic2;
    private Transform comic3;
    private Transform comic4;
    private Transform comic5;
    private Transform comic6;
    private Transform credits;
    private LoadingScreen loadingScreen;
    private AudioSource musicSuspense;
    private AudioSource musicVictory;
    private Transform scrollBkg;
    private bool showing;
    private StageBase stage;

    public EndGame()
    {
        base..ctor();
        return;
    }

    private int GetStars()
    {
        int num;
        num = this.stage.GetLives();
        if (num < 0x12)
        {
            goto Label_0016;
        }
        return 3;
    Label_0016:
        if (num < 6)
        {
            goto Label_001F;
        }
        return 2;
    Label_001F:
        return 1;
    }

    private void HideBalloon5()
    {
        ParticleFadeOut @out;
        @out = this.balloon5.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.2f;
        @out.initialOpacity = 1f;
        @out.finalOpacity = 0f;
        @out.Fade();
        return;
    }

    public void HideComic()
    {
        object[] objArray3;
        object[] objArray2;
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-1200f, 272f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic1.gameObject, iTween.Hash(objArray1));
        objArray2 = new object[] { "position", (Vector3) new Vector3(-1200f, 272f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic2.gameObject, iTween.Hash(objArray2));
        objArray3 = new object[] { "position", (Vector3) new Vector3(0f, -850f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic3.gameObject, iTween.Hash(objArray3));
        base.Invoke("RollCredits", 1f);
        return;
    }

    public void Launch()
    {
        ParticleFadeIn @in;
        this.musicVictory.volume = GameSoundManager.GetVolumeMusic();
        this.musicVictory.Play();
        this.showing = 1;
        @in = base.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.05f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        base.transform.position = new Vector3(0f, 0f, -990f);
        base.Invoke("ShowFirstComic", 2f);
        return;
    }

    private void RollCredits()
    {
        ParticleFadeIn @in;
        this.scrollBkg.gameObject.SetActive(1);
        @in = this.scrollBkg.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.07f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        this.credits.gameObject.SetActive(1);
        this.credits.GetComponent<EndGameCredits>().Show();
        return;
    }

    private void ShowBalloon1()
    {
        ParticleFadeIn @in;
        this.balloon1.gameObject.SetActive(1);
        @in = this.balloon1.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon11()
    {
        ParticleFadeIn @in;
        this.balloon11.gameObject.SetActive(1);
        @in = this.balloon11.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.2f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon12()
    {
        ParticleFadeIn @in;
        this.balloon12.gameObject.SetActive(1);
        @in = this.balloon12.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon13()
    {
        ParticleFadeIn @in;
        this.balloon13.gameObject.SetActive(1);
        @in = this.balloon13.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon2()
    {
        ParticleFadeIn @in;
        this.balloon2.gameObject.SetActive(1);
        @in = this.balloon2.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon3()
    {
        ParticleFadeIn @in;
        this.balloon3.gameObject.SetActive(1);
        @in = this.balloon3.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon4()
    {
        ParticleFadeIn @in;
        this.balloon4.gameObject.SetActive(1);
        @in = this.balloon4.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon5()
    {
        ParticleFadeIn @in;
        this.balloon5.gameObject.SetActive(1);
        @in = this.balloon5.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon6()
    {
        ParticleFadeIn @in;
        this.balloon6.gameObject.SetActive(1);
        @in = this.balloon6.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowBalloon9And10()
    {
        ParticleFadeIn @in;
        this.balloon9.gameObject.SetActive(1);
        this.balloon10.gameObject.SetActive(1);
        @in = this.balloon9.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.2f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        @in = this.balloon10.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.2f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowChat()
    {
        ParticleFadeIn @in;
        this.balloon7.gameObject.SetActive(1);
        this.balloon8.gameObject.SetActive(1);
        @in = this.balloon7.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.2f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        @in = this.balloon8.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.2f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        base.Invoke("ShowBalloon9And10", 0.5f);
        base.Invoke("ShowBalloon11", 0.75f);
        base.Invoke("ShowContinue1", 2f);
        return;
    }

    private void ShowContinue1()
    {
        ParticleFadeIn @in;
        this.buttonContinue1.gameObject.SetActive(1);
        @in = this.buttonContinue1.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    private void ShowContinue2()
    {
        ParticleFadeIn @in;
        this.buttonContinue2.gameObject.SetActive(1);
        @in = this.buttonContinue2.gameObject.AddComponent<ParticleFadeIn>();
        @in.fadeSpeed = 0.1f;
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.FadeIn();
        return;
    }

    public void ShowEndComic()
    {
        ParticleFadeOut @out;
        @out = this.scrollBkg.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.07f;
        @out.finalOpacity = 0f;
        @out.Fade();
        this.scrollBkg.gameObject.SetActive(0);
        this.ShowFourthComic();
        return;
    }

    private void ShowFifthComic()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(242f, 272f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic5.gameObject, iTween.Hash(objArray1));
        base.Invoke("ShowBalloon12", 1f);
        base.Invoke("ShowSixthComic", 1.5f);
        return;
    }

    private void ShowFirstComic()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-243f, 272f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic1.gameObject, iTween.Hash(objArray1));
        base.Invoke("ShowBalloon1", 1.5f);
        base.Invoke("ShowBalloon2", 2.5f);
        base.Invoke("ShowSecondComic", 3.5f);
        return;
    }

    private void ShowFourthComic()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-243f, 272f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic4.gameObject, iTween.Hash(objArray1));
        base.Invoke("ShowFifthComic", 1.5f);
        return;
    }

    private void ShowSecondComic()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(242f, 272f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic2.gameObject, iTween.Hash(objArray1));
        base.Invoke("ShowBalloon3", 1f);
        base.Invoke("ShowBalloon4", 2.5f);
        base.Invoke("ShowThirdComic", 3.5f);
        return;
    }

    private void ShowSixthComic()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, -232f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic6.gameObject, iTween.Hash(objArray1));
        base.Invoke("ShowBalloon13", 1f);
        base.Invoke("ShowContinue2", 3f);
        return;
    }

    private void ShowThirdComic()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, -232f, -991f), "time", (float) 0.5f };
        iTween.MoveTo(this.comic3.gameObject, iTween.Hash(objArray1));
        base.Invoke("ShowBalloon5", 1f);
        base.Invoke("HideBalloon5", 2.5f);
        base.Invoke("ShowBalloon6", 3f);
        base.Invoke("ShowChat", 4f);
        return;
    }

    private void Start()
    {
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.musicVictory = this.stage.transform.FindChild("Music Victory").GetComponent<AudioSource>();
        this.musicSuspense = this.stage.transform.FindChild("Music Suspense").GetComponent<AudioSource>();
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        this.scrollBkg = base.transform.FindChild("ScrollBkg");
        this.scrollBkg.gameObject.SetActive(0);
        this.credits = base.transform.FindChild("Scroll");
        this.credits.gameObject.SetActive(0);
        this.comic1 = base.transform.FindChild("Comic1");
        this.comic2 = base.transform.FindChild("Comic2");
        this.comic3 = base.transform.FindChild("Comic3");
        this.comic4 = base.transform.FindChild("Comic4");
        this.comic5 = base.transform.FindChild("Comic5");
        this.comic6 = base.transform.FindChild("Comic6");
        this.balloon1 = this.comic1.FindChild("Balloon1");
        this.balloon2 = this.comic1.FindChild("Balloon2");
        this.balloon3 = this.comic2.FindChild("Balloon3");
        this.balloon4 = this.comic2.FindChild("Balloon4");
        this.balloon5 = this.comic3.FindChild("Balloon5");
        this.balloon6 = this.comic3.FindChild("Balloon6");
        this.balloon7 = this.comic3.FindChild("Balloon7");
        this.balloon8 = this.comic3.FindChild("Balloon8");
        this.balloon9 = this.comic3.FindChild("Balloon9");
        this.balloon10 = this.comic3.FindChild("Balloon10");
        this.balloon11 = this.comic3.FindChild("Balloon11");
        this.balloon12 = this.comic5.FindChild("Balloon12");
        this.balloon13 = this.comic6.FindChild("Balloon13");
        this.balloon1.gameObject.SetActive(0);
        this.balloon2.gameObject.SetActive(0);
        this.balloon3.gameObject.SetActive(0);
        this.balloon4.gameObject.SetActive(0);
        this.balloon4.gameObject.SetActive(0);
        this.balloon5.gameObject.SetActive(0);
        this.balloon6.gameObject.SetActive(0);
        this.balloon7.gameObject.SetActive(0);
        this.balloon8.gameObject.SetActive(0);
        this.balloon9.gameObject.SetActive(0);
        this.balloon10.gameObject.SetActive(0);
        this.balloon11.gameObject.SetActive(0);
        this.balloon12.gameObject.SetActive(0);
        this.balloon13.gameObject.SetActive(0);
        this.buttonContinue1 = this.comic3.FindChild("ButtonContinue");
        this.buttonContinue2 = this.comic6.FindChild("ButtonContinue");
        this.buttonContinue1.gameObject.SetActive(0);
        this.buttonContinue2.gameObject.SetActive(0);
        return;
    }

    public void SwitchMusic()
    {
        this.musicVictory.Stop();
        this.musicSuspense.volume = GameSoundManager.GetVolumeMusic();
        this.musicSuspense.Play();
        return;
    }

    public void ToMap()
    {
        if (GameData.GetGameMode() != null)
        {
            goto Label_001A;
        }
        GameData.GetCurrentStageData().Win(this.GetStars());
    Label_001A:
        this.musicSuspense.Stop();
        GameData.LastLevelCompleted = 12;
        GameData.LevelToLoad = 1;
        this.loadingScreen.Launch();
        base.gameObject.SetActive(0);
        return;
    }

    private void Update()
    {
        if (this.showing == null)
        {
            goto Label_0028;
        }
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_0028;
        }
        this.ToMap();
        this.musicVictory.Stop();
    Label_0028:
        return;
    }
}

