using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private MainMenuOptions menuOptions;
    private MainMenuSlotsBackground menuStart;
    private Transform mousePrefab;
    private AudioSource music;
    private PackedSprite spriteLogo;

    public MainMenu()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        this.menuOptions = base.transform.FindChild("OptionsBackground").GetComponent<MainMenuOptions>();
        this.menuOptions.gameObject.SetActive(0);
        this.menuStart = base.transform.FindChild("SlotsBackground").GetComponent<MainMenuSlotsBackground>();
        this.menuStart.gameObject.SetActive(0);
        this.spriteLogo = base.transform.parent.FindChild("Logo").GetComponent<PackedSprite>();
        this.music = GameObject.Find("MusicTheme").GetComponent<AudioSource>();
        this.SetMusicVol();
        this.music.Play();
        base.Invoke("ShowLogo", 0.3f);
        return;
    }

    private void OpenMenuOptions()
    {
        this.menuOptions.gameObject.SetActive(1);
        this.menuOptions.Show();
        return;
    }

    private void OpenMenuStart()
    {
        this.menuStart.gameObject.SetActive(1);
        this.menuStart.Show();
        return;
    }

    public void SetMusicVol()
    {
        this.music.volume = GameSoundManager.GetVolumeMusic();
        return;
    }

    private void ShowLogo()
    {
        this.spriteLogo.Hide(0);
        this.spriteLogo.PlayAnim(0);
        return;
    }

    public void ShowMenuOptions()
    {
        if (this.menuOptions.gameObject.activeSelf != null)
        {
            goto Label_0055;
        }
        if (this.menuStart.gameObject.activeSelf == null)
        {
            goto Label_004A;
        }
        this.menuStart.Hide();
        base.Invoke("OpenMenuOptions", 0.2f);
        goto Label_0050;
    Label_004A:
        this.OpenMenuOptions();
    Label_0050:
        goto Label_0060;
    Label_0055:
        this.menuOptions.Hide();
    Label_0060:
        return;
    }

    public void ShowMenuStart()
    {
        if (this.menuStart.gameObject.activeSelf != null)
        {
            goto Label_0055;
        }
        if (this.menuOptions.gameObject.activeSelf == null)
        {
            goto Label_004A;
        }
        this.menuOptions.Hide();
        base.Invoke("OpenMenuStart", 0.2f);
        goto Label_0050;
    Label_004A:
        this.OpenMenuStart();
    Label_0050:
        goto Label_0060;
    Label_0055:
        this.menuStart.Hide();
    Label_0060:
        return;
    }

    private void Update()
    {
    }
}

