using System;
using UnityEngine;

public class NotificationIcon : MonoBehaviour
{
    private GameGui gui;
    private GUIBottom guiBottom;
    private NotificationHolder holder;
    private int index;
    private PackedSprite sprite;
    private Constants.notificationType type;

    public NotificationIcon()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        object[] objArray1;
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1a, "oncomplete", "KillMe" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    public void Init(Constants.notificationType type, int index, NotificationHolder holder, GameGui gui, GUIBottom guiBottom)
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.type = type;
        this.index = index;
        this.holder = holder;
        this.gui = gui;
        this.guiBottom = guiBottom;
        this.SetIcon();
        GameSoundManager.PlayGUINotificationSecondLevel();
        return;
    }

    private void KillMe()
    {
        GameSoundManager.Unpause();
        this.holder.RemoveNotification(this.index);
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void OnMouseDown()
    {
        this.guiBottom.SetPowerReinforcementActive(0);
        this.guiBottom.SetPowerFireballActive(0);
        this.gui.AddNotificationPause(this.type, this);
        return;
    }

    private void PopIn()
    {
        object[] objArray1;
        base.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.25f, "easetype", (iTween.EaseType) 0x1c, "oncomplete", "TweenScale" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void SetIcon()
    {
        Constants.notificationType type;
        switch (this.type)
        {
            case 0:
                goto Label_018C;

            case 1:
                goto Label_01A1;

            case 2:
                goto Label_053D;

            case 3:
                goto Label_053D;

            case 4:
                goto Label_010E;

            case 5:
                goto Label_0138;

            case 6:
                goto Label_0162;

            case 7:
                goto Label_0177;

            case 8:
                goto Label_0123;

            case 9:
                goto Label_01B6;

            case 10:
                goto Label_01CB;

            case 11:
                goto Label_01E0;

            case 12:
                goto Label_053D;

            case 13:
                goto Label_053D;

            case 14:
                goto Label_053D;

            case 15:
                goto Label_053D;

            case 0x10:
                goto Label_01F5;

            case 0x11:
                goto Label_020A;

            case 0x12:
                goto Label_021F;

            case 0x13:
                goto Label_0234;

            case 20:
                goto Label_0249;

            case 0x15:
                goto Label_025E;

            case 0x16:
                goto Label_0273;

            case 0x17:
                goto Label_0288;

            case 0x18:
                goto Label_029D;

            case 0x19:
                goto Label_053D;

            case 0x1a:
                goto Label_053D;

            case 0x1b:
                goto Label_053D;

            case 0x1c:
                goto Label_053D;

            case 0x1d:
                goto Label_02B2;

            case 30:
                goto Label_02C7;

            case 0x1f:
                goto Label_02DC;

            case 0x20:
                goto Label_02F1;

            case 0x21:
                goto Label_0306;

            case 0x22:
                goto Label_031B;

            case 0x23:
                goto Label_0330;

            case 0x24:
                goto Label_0345;

            case 0x25:
                goto Label_035A;

            case 0x26:
                goto Label_036F;

            case 0x27:
                goto Label_0384;

            case 40:
                goto Label_0399;

            case 0x29:
                goto Label_03AE;

            case 0x2a:
                goto Label_03C3;

            case 0x2b:
                goto Label_03D8;

            case 0x2c:
                goto Label_03ED;

            case 0x2d:
                goto Label_0402;

            case 0x2e:
                goto Label_0417;

            case 0x2f:
                goto Label_042C;

            case 0x30:
                goto Label_0441;

            case 0x31:
                goto Label_053D;

            case 50:
                goto Label_0456;

            case 0x33:
                goto Label_046B;

            case 0x34:
                goto Label_014D;

            case 0x35:
                goto Label_0480;

            case 0x36:
                goto Label_0495;

            case 0x37:
                goto Label_053D;

            case 0x38:
                goto Label_04AA;

            case 0x39:
                goto Label_04BF;

            case 0x3a:
                goto Label_04D4;

            case 0x3b:
                goto Label_04E9;

            case 60:
                goto Label_04FE;

            case 0x3d:
                goto Label_0513;

            case 0x3e:
                goto Label_0528;
        }
        goto Label_053D;
    Label_010E:
        this.sprite.PlayAnim("tipArmor");
        goto Label_0542;
    Label_0123:
        this.sprite.PlayAnim("tipArmorHard");
        goto Label_0542;
    Label_0138:
        this.sprite.PlayAnim("tipArmorMagic");
        goto Label_0542;
    Label_014D:
        this.sprite.PlayAnim("tipHeroes");
        goto Label_0542;
    Label_0162:
        this.sprite.PlayAnim("tipRally");
        goto Label_0542;
    Label_0177:
        this.sprite.PlayAnim("tipStrategy");
        goto Label_0542;
    Label_018C:
        this.sprite.PlayAnim("enemyGoblin");
        goto Label_0542;
    Label_01A1:
        this.sprite.PlayAnim("enemyOrc");
        goto Label_0542;
    Label_01B6:
        this.sprite.PlayAnim("enemyWulf");
        goto Label_0542;
    Label_01CB:
        this.sprite.PlayAnim("enemyShaman");
        goto Label_0542;
    Label_01E0:
        this.sprite.PlayAnim("enemyOgre");
        goto Label_0542;
    Label_01F5:
        this.sprite.PlayAnim("enemyBandit");
        goto Label_0542;
    Label_020A:
        this.sprite.PlayAnim("enemyBrigand");
        goto Label_0542;
    Label_021F:
        this.sprite.PlayAnim("enemyDarkKnight");
        goto Label_0542;
    Label_0234:
        this.sprite.PlayAnim("enemyMarauder");
        goto Label_0542;
    Label_0249:
        this.sprite.PlayAnim("enemyGiantSpider");
        goto Label_0542;
    Label_025E:
        this.sprite.PlayAnim("enemySpider");
        goto Label_0542;
    Label_0273:
        this.sprite.PlayAnim("enemyShadowArcher");
        goto Label_0542;
    Label_0288:
        this.sprite.PlayAnim("enemyGargoyle");
        goto Label_0542;
    Label_029D:
        this.sprite.PlayAnim("enemyWorg");
        goto Label_0542;
    Label_02B2:
        this.sprite.PlayAnim("enemyTroll");
        goto Label_0542;
    Label_02C7:
        this.sprite.PlayAnim("enemyTrollAxe");
        goto Label_0542;
    Label_02DC:
        this.sprite.PlayAnim("enemyTrollChieftain");
        goto Label_0542;
    Label_02F1:
        this.sprite.PlayAnim("enemyWinterWolf");
        goto Label_0542;
    Label_0306:
        this.sprite.PlayAnim("enemyDarkSlayer");
        goto Label_0542;
    Label_031B:
        this.sprite.PlayAnim("enemyYeti");
        goto Label_0542;
    Label_0330:
        this.sprite.PlayAnim("enemyRocketeer");
        goto Label_0542;
    Label_0345:
        this.sprite.PlayAnim("enemyDemon");
        goto Label_0542;
    Label_035A:
        this.sprite.PlayAnim("enemyDemonMage");
        goto Label_0542;
    Label_036F:
        this.sprite.PlayAnim("enemyDemonImp");
        goto Label_0542;
    Label_0384:
        this.sprite.PlayAnim("enemyDemonWolf");
        goto Label_0542;
    Label_0399:
        this.sprite.PlayAnim("enemyNecromancer");
        goto Label_0542;
    Label_03AE:
        this.sprite.PlayAnim("enemyLavaElemental");
        goto Label_0542;
    Label_03C3:
        this.sprite.PlayAnim("enemySonOfSarelgaz");
        goto Label_0542;
    Label_03D8:
        this.sprite.PlayAnim("enemyGoblinZapper");
        goto Label_0542;
    Label_03ED:
        this.sprite.PlayAnim("enemyOrcRider");
        goto Label_0542;
    Label_0402:
        this.sprite.PlayAnim("enemyOrcArmored");
        goto Label_0542;
    Label_0417:
        this.sprite.PlayAnim("enemyForestTroll");
        goto Label_0542;
    Label_042C:
        this.sprite.PlayAnim("enemyHusk");
        goto Label_0542;
    Label_0441:
        this.sprite.PlayAnim("enemyNoxiousCreeper");
        goto Label_0542;
    Label_0456:
        this.sprite.PlayAnim("enemyTreant");
        goto Label_0542;
    Label_046B:
        this.sprite.PlayAnim("enemySwampThing");
        goto Label_0542;
    Label_0480:
        this.sprite.PlayAnim("enemyRaider");
        goto Label_0542;
    Label_0495:
        this.sprite.PlayAnim("enemyPillager");
        goto Label_0542;
    Label_04AA:
        this.sprite.PlayAnim("enemyTrollSkater");
        goto Label_0542;
    Label_04BF:
        this.sprite.PlayAnim("enemyTrollBrute");
        goto Label_0542;
    Label_04D4:
        this.sprite.PlayAnim("enemyCerberus");
        goto Label_0542;
    Label_04E9:
        this.sprite.PlayAnim("enemyLegion");
        goto Label_0542;
    Label_04FE:
        this.sprite.PlayAnim("enemyFlareon");
        goto Label_0542;
    Label_0513:
        this.sprite.PlayAnim("enemyGulaemon");
        goto Label_0542;
    Label_0528:
        this.sprite.PlayAnim("enemyRottenLesser");
        goto Label_0542;
    Label_053D:;
    Label_0542:
        this.sprite.PauseAnim();
        return;
    }

    private void Start()
    {
        this.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.PopIn();
        return;
    }

    private void TweenScale()
    {
        object[] objArray1;
        base.transform.localScale = new Vector3(0.95f, 0.95f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.3f, "easetype", (iTween.EaseType) 2, "looptype", (iTween.LoopType) 2 };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    public int Index
    {
        get
        {
            return this.index;
        }
    }
}

