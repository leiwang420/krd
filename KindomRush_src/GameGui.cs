using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameGui : MonoBehaviour
{
    private NotificationTipEnemy enemyCard;
    private NotificationHolder notificationHolder;
    private Transform overlay;
    private NotificationTipPower powerCard;
    private Quickmenu quickmenu;
    private StageBase stage;
    private NotificationTipCard tipCard;
    private NotificationTower towerCard;
    private NotificationTowerDouble towerDoubleCard;

    public GameGui()
    {
        base..ctor();
        return;
    }

    public void AddNotificationPause(Constants.notificationType type, NotificationIcon icon = null)
    {
        Constants.notificationType type2;
        this.stage.Pause(1);
        GameSoundManager.Pause();
        this.quickmenu.Hide();
        type2 = type;
        switch (type2)
        {
            case 0:
                goto Label_0249;

            case 1:
                goto Label_025B;

            case 2:
                goto Label_01C6;

            case 3:
                goto Label_01B5;

            case 4:
                goto Label_01D7;

            case 5:
                goto Label_01FB;

            case 6:
                goto Label_0220;

            case 7:
                goto Label_0232;

            case 8:
                goto Label_01E9;

            case 9:
                goto Label_026D;

            case 10:
                goto Label_0280;

            case 11:
                goto Label_0293;

            case 12:
                goto Label_0125;

            case 13:
                goto Label_0137;

            case 14:
                goto Label_0149;

            case 15:
                goto Label_0191;

            case 0x10:
                goto Label_02A6;

            case 0x11:
                goto Label_02B9;

            case 0x12:
                goto Label_02CC;

            case 0x13:
                goto Label_02DF;

            case 20:
                goto Label_02F2;

            case 0x15:
                goto Label_0305;

            case 0x16:
                goto Label_0318;

            case 0x17:
                goto Label_032B;

            case 0x18:
                goto Label_033E;

            case 0x19:
                goto Label_015B;

            case 0x1a:
                goto Label_017F;

            case 0x1b:
                goto Label_016D;

            case 0x1c:
                goto Label_01A3;

            case 0x1d:
                goto Label_0351;

            case 30:
                goto Label_0364;

            case 0x1f:
                goto Label_0377;

            case 0x20:
                goto Label_038A;

            case 0x21:
                goto Label_039D;

            case 0x22:
                goto Label_03B0;

            case 0x23:
                goto Label_03C3;

            case 0x24:
                goto Label_03D6;

            case 0x25:
                goto Label_03E9;

            case 0x26:
                goto Label_03FC;

            case 0x27:
                goto Label_040F;

            case 40:
                goto Label_0422;

            case 0x29:
                goto Label_0435;

            case 0x2a:
                goto Label_0448;

            case 0x2b:
                goto Label_045B;

            case 0x2c:
                goto Label_046E;

            case 0x2d:
                goto Label_0481;

            case 0x2e:
                goto Label_0494;

            case 0x2f:
                goto Label_04A7;

            case 0x30:
                goto Label_04BA;

            case 0x31:
                goto Label_059E;

            case 50:
                goto Label_04CD;

            case 0x33:
                goto Label_04E0;

            case 0x34:
                goto Label_020D;

            case 0x35:
                goto Label_04F3;

            case 0x36:
                goto Label_0506;

            case 0x37:
                goto Label_0244;

            case 0x38:
                goto Label_0519;

            case 0x39:
                goto Label_052C;

            case 0x3a:
                goto Label_053F;

            case 0x3b:
                goto Label_0552;

            case 60:
                goto Label_0565;

            case 0x3d:
                goto Label_0578;

            case 0x3e:
                goto Label_058B;
        }
        goto Label_059E;
    Label_0125:
        this.towerCard.Setup(12);
        goto Label_05A3;
    Label_0137:
        this.towerCard.Setup(13);
        goto Label_05A3;
    Label_0149:
        this.towerCard.Setup(14);
        goto Label_05A3;
    Label_015B:
        this.towerCard.Setup(0x19);
        goto Label_05A3;
    Label_016D:
        this.towerCard.Setup(0x1b);
        goto Label_05A3;
    Label_017F:
        this.towerCard.Setup(0x1a);
        goto Label_05A3;
    Label_0191:
        this.towerDoubleCard.Setup(15);
        goto Label_05A3;
    Label_01A3:
        this.towerDoubleCard.Setup(0x1c);
        goto Label_05A3;
    Label_01B5:
        this.powerCard.Setup(3);
        goto Label_05A3;
    Label_01C6:
        this.powerCard.Setup(2);
        goto Label_05A3;
    Label_01D7:
        this.tipCard.Setup(4, icon);
        goto Label_05A3;
    Label_01E9:
        this.tipCard.Setup(8, icon);
        goto Label_05A3;
    Label_01FB:
        this.tipCard.Setup(5, icon);
        goto Label_05A3;
    Label_020D:
        this.tipCard.Setup(0x34, icon);
        goto Label_05A3;
    Label_0220:
        this.tipCard.Setup(6, icon);
        goto Label_05A3;
    Label_0232:
        this.tipCard.Setup(7, icon);
        goto Label_05A3;
    Label_0244:
        goto Label_05A3;
    Label_0249:
        this.enemyCard.Setup(0, icon);
        goto Label_05A3;
    Label_025B:
        this.enemyCard.Setup(1, icon);
        goto Label_05A3;
    Label_026D:
        this.enemyCard.Setup(9, icon);
        goto Label_05A3;
    Label_0280:
        this.enemyCard.Setup(10, icon);
        goto Label_05A3;
    Label_0293:
        this.enemyCard.Setup(11, icon);
        goto Label_05A3;
    Label_02A6:
        this.enemyCard.Setup(0x10, icon);
        goto Label_05A3;
    Label_02B9:
        this.enemyCard.Setup(0x11, icon);
        goto Label_05A3;
    Label_02CC:
        this.enemyCard.Setup(0x12, icon);
        goto Label_05A3;
    Label_02DF:
        this.enemyCard.Setup(0x13, icon);
        goto Label_05A3;
    Label_02F2:
        this.enemyCard.Setup(20, icon);
        goto Label_05A3;
    Label_0305:
        this.enemyCard.Setup(0x15, icon);
        goto Label_05A3;
    Label_0318:
        this.enemyCard.Setup(0x16, icon);
        goto Label_05A3;
    Label_032B:
        this.enemyCard.Setup(0x17, icon);
        goto Label_05A3;
    Label_033E:
        this.enemyCard.Setup(0x18, icon);
        goto Label_05A3;
    Label_0351:
        this.enemyCard.Setup(0x1d, icon);
        goto Label_05A3;
    Label_0364:
        this.enemyCard.Setup(30, icon);
        goto Label_05A3;
    Label_0377:
        this.enemyCard.Setup(0x1f, icon);
        goto Label_05A3;
    Label_038A:
        this.enemyCard.Setup(0x20, icon);
        goto Label_05A3;
    Label_039D:
        this.enemyCard.Setup(0x21, icon);
        goto Label_05A3;
    Label_03B0:
        this.enemyCard.Setup(0x22, icon);
        goto Label_05A3;
    Label_03C3:
        this.enemyCard.Setup(0x23, icon);
        goto Label_05A3;
    Label_03D6:
        this.enemyCard.Setup(0x24, icon);
        goto Label_05A3;
    Label_03E9:
        this.enemyCard.Setup(0x25, icon);
        goto Label_05A3;
    Label_03FC:
        this.enemyCard.Setup(0x26, icon);
        goto Label_05A3;
    Label_040F:
        this.enemyCard.Setup(0x27, icon);
        goto Label_05A3;
    Label_0422:
        this.enemyCard.Setup(40, icon);
        goto Label_05A3;
    Label_0435:
        this.enemyCard.Setup(0x29, icon);
        goto Label_05A3;
    Label_0448:
        this.enemyCard.Setup(0x2a, icon);
        goto Label_05A3;
    Label_045B:
        this.enemyCard.Setup(0x2b, icon);
        goto Label_05A3;
    Label_046E:
        this.enemyCard.Setup(0x2c, icon);
        goto Label_05A3;
    Label_0481:
        this.enemyCard.Setup(0x2d, icon);
        goto Label_05A3;
    Label_0494:
        this.enemyCard.Setup(0x2e, icon);
        goto Label_05A3;
    Label_04A7:
        this.enemyCard.Setup(0x2f, icon);
        goto Label_05A3;
    Label_04BA:
        this.enemyCard.Setup(0x30, icon);
        goto Label_05A3;
    Label_04CD:
        this.enemyCard.Setup(50, icon);
        goto Label_05A3;
    Label_04E0:
        this.enemyCard.Setup(0x33, icon);
        goto Label_05A3;
    Label_04F3:
        this.enemyCard.Setup(0x35, icon);
        goto Label_05A3;
    Label_0506:
        this.enemyCard.Setup(0x36, icon);
        goto Label_05A3;
    Label_0519:
        this.enemyCard.Setup(0x38, icon);
        goto Label_05A3;
    Label_052C:
        this.enemyCard.Setup(0x39, icon);
        goto Label_05A3;
    Label_053F:
        this.enemyCard.Setup(0x3a, icon);
        goto Label_05A3;
    Label_0552:
        this.enemyCard.Setup(0x3b, icon);
        goto Label_05A3;
    Label_0565:
        this.enemyCard.Setup(60, icon);
        goto Label_05A3;
    Label_0578:
        this.enemyCard.Setup(0x3d, icon);
        goto Label_05A3;
    Label_058B:
        this.enemyCard.Setup(0x3e, icon);
        goto Label_05A3;
    Label_059E:;
    Label_05A3:
        return;
    }

    public void AddNotificationSecondLevel(Constants.notificationType type)
    {
        this.notificationHolder.AddNotification(type);
        return;
    }

    public void DisableNotificationTips()
    {
        this.notificationHolder.DisableTips();
        return;
    }

    public void EnableNotificationTips()
    {
        this.notificationHolder.EnableTips();
        return;
    }

    private void FixedUpdate()
    {
    }

    public bool IsNotificationDisplayed()
    {
        return ((((this.tipCard.IsDisplayed() != null) || (this.enemyCard.IsDisplayed() != null)) || ((this.powerCard.IsDisplayed() != null) || (this.towerCard.IsDisplayed() != null))) ? 1 : this.towerDoubleCard.IsDisplayed());
    }

    private void Start()
    {
        this.notificationHolder = base.transform.FindChild("Notifications").FindChild("Holder").GetComponent<NotificationHolder>();
        this.tipCard = base.transform.FindChild("Notifications").FindChild("CardTips").GetComponent<NotificationTipCard>();
        this.enemyCard = base.transform.FindChild("Notifications").FindChild("CardEnemy").GetComponent<NotificationTipEnemy>();
        this.powerCard = base.transform.FindChild("Notifications").FindChild("CardPower").GetComponent<NotificationTipPower>();
        this.towerCard = base.transform.FindChild("Notifications").FindChild("CardTower").GetComponent<NotificationTower>();
        this.towerDoubleCard = base.transform.FindChild("Notifications").FindChild("CardTowerDouble").GetComponent<NotificationTowerDouble>();
        this.stage = base.GetComponent<StageBase>();
        this.overlay = GameObject.Find("Overlay").GetComponent<Transform>();
        this.quickmenu = GameObject.Find("Quickmenu").GetComponent<Quickmenu>();
        return;
    }
}

