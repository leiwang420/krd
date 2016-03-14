using System;
using UnityEngine;

public class MainMenuButtonSlot : MainMenuButtonBase
{
    private Transform deleteButton;
    private LoadingScreen loadingScreen;
    private int slotNumber;
    private TextMesh textHeroicWins;
    private TextMesh textIronWins;
    private TextMesh textStars;

    public MainMenuButtonSlot()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();
        this.textStars = base.transform.FindChild("TextStars").GetComponent<TextMesh>();
        this.textIronWins = base.transform.FindChild("TextIron").GetComponent<TextMesh>();
        this.textHeroicWins = base.transform.FindChild("TextHeroic").GetComponent<TextMesh>();
        this.deleteButton = base.transform.FindChild("Delete");
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void LoadInfo()
    {
        int num;
        int num2;
        int num3;
        int num4;
        num = GameData.GetStarsWonForSlot(this.slotNumber);
        num2 = GameData.GetTotalStarsForSlot(this.slotNumber);
        num3 = GameData.GetHeroicWinsForSlot(this.slotNumber);
        num4 = GameData.GetIronWinsForSlot(this.slotNumber);
        this.textStars.text = &num.ToString() + "/" + &num2.ToString();
        this.textHeroicWins.text = &num3.ToString();
        this.textIronWins.text = &num4.ToString();
        return;
    }

    protected override void OnMouseDown()
    {
        Transform transform4;
        Transform transform3;
        Transform transform2;
        Transform transform1;
        base.OnMouseDown();
        transform1 = this.textStars.transform;
        transform1.localPosition -= new Vector3(2f, 2f, 0f);
        transform2 = this.textIronWins.transform;
        transform2.localPosition -= new Vector3(2f, 2f, 0f);
        transform3 = this.textHeroicWins.transform;
        transform3.localPosition -= new Vector3(2f, 2f, 0f);
        transform4 = this.deleteButton.transform;
        transform4.localPosition -= new Vector3(2f, 2f, 0f);
        return;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        GameData.CurrentSlot = this.slotNumber;
        GameData.LevelToLoad = 1;
        GameData.LoadGameData();
        this.loadingScreen.Launch();
        return;
    }

    public int SlotNumber
    {
        get
        {
            return this.slotNumber;
        }
        set
        {
            this.slotNumber = value;
            return;
        }
    }
}

