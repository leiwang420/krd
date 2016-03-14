using System;
using System.Collections;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private Transform bar;
    private PackedSprite bgGrass;
    private PackedSprite bgIce;
    private PackedSprite bgWasteland;
    private bool isLoading;
    private AsyncOperation loadingOperation;
    private Transform overlay;
    private Transform textContainer;
    private ArrayList textPositionX;
    private TextMesh tip;
    private ArrayList tipAdjustList;
    private ArrayList tipList;
    private Transform tipTitle;

    public LoadingScreen()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.bar = base.transform.FindChild("Bar");
        this.textContainer = base.transform.FindChild("Text");
        this.tip = this.textContainer.FindChild("Tip").GetComponent<TextMesh>();
        this.bgGrass = base.transform.FindChild("BgGrass").GetComponent<PackedSprite>();
        this.bgIce = base.transform.FindChild("BgIce").GetComponent<PackedSprite>();
        this.bgWasteland = base.transform.FindChild("BgWasteland").GetComponent<PackedSprite>();
        this.overlay = base.transform.FindChild("OverlayFade");
        return;
    }

    private unsafe void FixedUpdate()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.isLoading != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.loadingOperation.progress >= 0.9f)
        {
            goto Label_00B8;
        }
        if (&this.bar.localScale.x >= 1f)
        {
            goto Label_0100;
        }
        this.bar.localScale = new Vector3(&this.bar.localScale.x + (Time.deltaTime * 1.5f), 1f, 1f);
        if (&this.bar.localScale.x <= 1f)
        {
            goto Label_0100;
        }
        this.bar.localScale = new Vector3(1f, 1f, 1f);
        goto Label_0100;
    Label_00B8:
        if (&this.bar.localScale.x >= 1f)
        {
            goto Label_00F4;
        }
        this.bar.localScale = new Vector3(1f, 1f, 1f);
    Label_00F4:
        this.loadingOperation.allowSceneActivation = 1;
    Label_0100:
        return;
    }

    public void Launch()
    {
        GameSoundManager.StopMusic();
        this.overlay.GetComponent<ParticleFadeOut>().Fade();
        Screen.showCursor = 0;
        this.isLoading = 1;
        base.transform.position = new Vector3(0f, 0f, -920f);
        this.loadingOperation = Application.LoadLevelAsync(GameData.LevelToLoad);
        this.loadingOperation.allowSceneActivation = 0;
        this.SetBackground(GameData.LevelToLoad - 1);
        return;
    }

    private void LoadTips()
    {
        this.tipList = new ArrayList();
        this.tipList.Add("Enemies and Soldiers with armor\nreceive less physical damage.");
        this.tipList.Add("Support barracks with ranged towers\nto maximize enemy exposure.");
        this.tipList.Add("Reinforcements are a great way to\nsplit enemy forces.");
        this.tipList.Add("Artillery works best against high\nconcentration of enemies.");
        this.tipList.Add("Artillery damage is higher in the\ncenter of the explosion.");
        this.tipList.Add("Use reinforcements constantly to slow\nand damage the enemy.");
        this.tipList.Add("Always aim rain of fire a little\nahead of your target.");
        this.tipList.Add("With the Salvage upgrade you can sell\narcher towers with only a 10% loss.");
        this.tipList.Add("Magic damage is the best way to deal\nwith armored enemies.");
        this.tipList.Add("Flying enemies cannot be blocked by barracks\nand won't be targeted by most artillery.");
        this.tipList.Add("Enemies with magic resistance receive\nless damage from magic attacks.");
        this.tipList.Add("Adjust the rally point of soldiers to create\nbetter strategies.");
        this.tipList.Add("Sometimes it is better to build more towers\ninstead of upgrading a few.");
        this.tipList.Add("Poison damage ignores armor.");
        this.tipList.Add("Upgrading a barrack instantly trains\nnew soldiers.");
        this.tipList.Add("Calling an early wave gives bonus cash and\nreduces spell cooldowns a bit.");
        this.tipList.Add("Artillery explosions can damage flying\nenemies although they cannot target\nthem directly.");
        this.tipList.Add("Use barracks or reinforcement to isolate\ntroublesome enemies.");
        this.tipList.Add("Barbarians with the right upgrades are\ncapable of dealing with flying enemies.");
        this.tipList.Add("Earth elementals are very tough and deal\narea damage every time they strike.");
        this.tipList.Add("You can check the incoming wave enemies\nby hovering over the wave icon.");
        this.tipAdjustList = new ArrayList();
        this.tipAdjustList.Add((float) 380f);
        this.tipAdjustList.Add((float) 410f);
        this.tipAdjustList.Add((float) 340f);
        this.tipAdjustList.Add((float) 365f);
        this.tipAdjustList.Add((float) 350f);
        this.tipAdjustList.Add((float) 375f);
        this.tipAdjustList.Add((float) 320f);
        this.tipAdjustList.Add((float) 450f);
        this.tipAdjustList.Add((float) 375f);
        this.tipAdjustList.Add((float) 505f);
        this.tipAdjustList.Add((float) 425f);
        this.tipAdjustList.Add((float) 365f);
        this.tipAdjustList.Add((float) 430f);
        this.tipAdjustList.Add((float) 205f);
        this.tipAdjustList.Add((float) 310f);
        this.tipAdjustList.Add((float) 430f);
        this.tipAdjustList.Add((float) 530f);
        this.tipAdjustList.Add((float) 380f);
        this.tipAdjustList.Add((float) 460f);
        this.tipAdjustList.Add((float) 460f);
        this.tipAdjustList.Add((float) 440f);
        this.textPositionX = new ArrayList();
        this.textPositionX.Add((float) 33f);
        this.textPositionX.Add((float) 30f);
        this.textPositionX.Add((float) 28f);
        this.textPositionX.Add((float) 28f);
        this.textPositionX.Add((float) 34f);
        this.textPositionX.Add((float) 35f);
        this.textPositionX.Add((float) 35f);
        this.textPositionX.Add((float) 34f);
        this.textPositionX.Add((float) 29f);
        this.textPositionX.Add((float) 29f);
        this.textPositionX.Add((float) 31f);
        this.textPositionX.Add((float) 25f);
        this.textPositionX.Add((float) 26f);
        this.textPositionX.Add((float) 22f);
        this.textPositionX.Add((float) 27f);
        this.textPositionX.Add((float) 28f);
        this.textPositionX.Add((float) 28f);
        this.textPositionX.Add((float) 24f);
        this.textPositionX.Add((float) 30f);
        this.textPositionX.Add((float) 30f);
        this.textPositionX.Add((float) 30f);
        return;
    }

    private void SelectTip()
    {
        int num;
        int num2;
        num = UnityEngine.Random.Range(0, this.tipList.Count);
        this.tip.text = (string) this.tipList[num];
        num2 = this.tip.text.Length;
        this.textContainer.localPosition = new Vector3(0f, -398f, -5f);
        return;
    }

    private void SetBackground(int index)
    {
        if (index == 1)
        {
            goto Label_0048;
        }
        if (index == 2)
        {
            goto Label_0048;
        }
        if (index == 3)
        {
            goto Label_0048;
        }
        if (index == 4)
        {
            goto Label_0048;
        }
        if (index == 5)
        {
            goto Label_0048;
        }
        if (index == 6)
        {
            goto Label_0048;
        }
        if (index == 14)
        {
            goto Label_0048;
        }
        if (index == 0x10)
        {
            goto Label_0048;
        }
        if (index == 0x11)
        {
            goto Label_0048;
        }
        if (index != null)
        {
            goto Label_0059;
        }
    Label_0048:
        this.bgGrass.Hide(0);
        goto Label_00A4;
    Label_0059:
        if (index == 7)
        {
            goto Label_0087;
        }
        if (index == 8)
        {
            goto Label_0087;
        }
        if (index == 9)
        {
            goto Label_0087;
        }
        if (index == 13)
        {
            goto Label_0087;
        }
        if (index == 0x12)
        {
            goto Label_0087;
        }
        if (index != 0x13)
        {
            goto Label_0098;
        }
    Label_0087:
        this.bgIce.Hide(0);
        goto Label_00A4;
    Label_0098:
        this.bgWasteland.Hide(0);
    Label_00A4:
        return;
    }

    private void Start()
    {
        this.LoadTips();
        this.SelectTip();
        this.bar.localScale = new Vector3(0f, 1f, 1f);
        return;
    }
}

