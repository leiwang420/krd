using System;
using System.Collections;
using UnityEngine;

public class NotificationHolder : MonoBehaviour
{
    private GameGui gui;
    private GUIBottom guiBottom;
    private Vector3 initPosition;
    private int notificationCount;
    private Transform prefabIcon;
    private StageBase stage;

    public NotificationHolder()
    {
        base..ctor();
        return;
    }

    public void AddNotification(Constants.notificationType n)
    {
        if (this.AlreadyShown(n) == null)
        {
            goto Label_000D;
        }
        return;
    Label_000D:
        this.notificationCount += 1;
        this.ShowNotificationIcon(n);
        this.SetAsShown(n);
        if (GameData.GetCurrentStageData().Index != 1)
        {
            goto Label_0059;
        }
        if (GameData.GetGameMode() != null)
        {
            goto Label_0059;
        }
        if (n != null)
        {
            goto Label_0059;
        }
        ((Stage1) this.stage).ShowBalloonNotification();
    Label_0059:
        return;
    }

    private bool AlreadyShown(Constants.notificationType n)
    {
        Constants.notificationType type;
        type = n;
        switch (type)
        {
            case 0:
                goto Label_0109;

            case 1:
                goto Label_010F;

            case 2:
                goto Label_021D;

            case 3:
                goto Label_021D;

            case 4:
                goto Label_021D;

            case 5:
                goto Label_021D;

            case 6:
                goto Label_021D;

            case 7:
                goto Label_021D;

            case 8:
                goto Label_021D;

            case 9:
                goto Label_0115;

            case 10:
                goto Label_011B;

            case 11:
                goto Label_0121;

            case 12:
                goto Label_021D;

            case 13:
                goto Label_021D;

            case 14:
                goto Label_021D;

            case 15:
                goto Label_021D;

            case 0x10:
                goto Label_0127;

            case 0x11:
                goto Label_012D;

            case 0x12:
                goto Label_0133;

            case 0x13:
                goto Label_0139;

            case 20:
                goto Label_013F;

            case 0x15:
                goto Label_0145;

            case 0x16:
                goto Label_014B;

            case 0x17:
                goto Label_0151;

            case 0x18:
                goto Label_0157;

            case 0x19:
                goto Label_021D;

            case 0x1a:
                goto Label_021D;

            case 0x1b:
                goto Label_021D;

            case 0x1c:
                goto Label_021D;

            case 0x1d:
                goto Label_015D;

            case 30:
                goto Label_0163;

            case 0x1f:
                goto Label_0169;

            case 0x20:
                goto Label_016F;

            case 0x21:
                goto Label_0175;

            case 0x22:
                goto Label_017B;

            case 0x23:
                goto Label_0181;

            case 0x24:
                goto Label_0187;

            case 0x25:
                goto Label_018D;

            case 0x26:
                goto Label_0193;

            case 0x27:
                goto Label_0199;

            case 40:
                goto Label_019F;

            case 0x29:
                goto Label_01A5;

            case 0x2a:
                goto Label_01AB;

            case 0x2b:
                goto Label_01B1;

            case 0x2c:
                goto Label_01B7;

            case 0x2d:
                goto Label_01BD;

            case 0x2e:
                goto Label_01C3;

            case 0x2f:
                goto Label_01C9;

            case 0x30:
                goto Label_01CF;

            case 0x31:
                goto Label_021D;

            case 50:
                goto Label_01D5;

            case 0x33:
                goto Label_01DB;

            case 0x34:
                goto Label_0217;

            case 0x35:
                goto Label_01E1;

            case 0x36:
                goto Label_01E7;

            case 0x37:
                goto Label_021D;

            case 0x38:
                goto Label_01ED;

            case 0x39:
                goto Label_01F3;

            case 0x3a:
                goto Label_01F9;

            case 0x3b:
                goto Label_01FF;

            case 60:
                goto Label_0205;

            case 0x3d:
                goto Label_020B;

            case 0x3e:
                goto Label_0211;
        }
        goto Label_021D;
    Label_0109:
        return GameData.notificationEnemyGoblin;
    Label_010F:
        return GameData.notificationEnemyFatOrc;
    Label_0115:
        return GameData.notificationEnemySmallWolf;
    Label_011B:
        return GameData.notificationEnemyShaman;
    Label_0121:
        return GameData.notificationEnemyOgre;
    Label_0127:
        return GameData.notificationEnemyBandit;
    Label_012D:
        return GameData.notificationEnemyBrigand;
    Label_0133:
        return GameData.notificationEnemyDarkKnight;
    Label_0139:
        return GameData.notificationEnemyMarauder;
    Label_013F:
        return GameData.notificationEnemySpider;
    Label_0145:
        return GameData.notificationEnemySpiderSmall;
    Label_014B:
        return GameData.notificationEnemyShadowArcher;
    Label_0151:
        return GameData.notificationEnemyGargoyle;
    Label_0157:
        return GameData.notificationEnemyWolf;
    Label_015D:
        return GameData.notificationEnemyTroll;
    Label_0163:
        return GameData.notificationEnemyTrollAxeThrower;
    Label_0169:
        return GameData.notificationEnemyTrollChieftain;
    Label_016F:
        return GameData.notificationEnemyWhiteWolf;
    Label_0175:
        return GameData.notificationEnemyDarkSlayer;
    Label_017B:
        return GameData.notificationEnemyYeti;
    Label_0181:
        return GameData.notificationEnemyRocketeer;
    Label_0187:
        return GameData.notificationEnemyDemon;
    Label_018D:
        return GameData.notificationEnemyDemonMage;
    Label_0193:
        return GameData.notificationEnemyDemonImp;
    Label_0199:
        return GameData.notificationEnemyDemonWolf;
    Label_019F:
        return GameData.notificationEnemyNecromancer;
    Label_01A5:
        return GameData.notificationEnemyLavaElemental;
    Label_01AB:
        return GameData.notificationEnemySarelgazSmall;
    Label_01B1:
        return GameData.notificationEnemyGoblinZapper;
    Label_01B7:
        return GameData.notificationEnemyOrcRider;
    Label_01BD:
        return GameData.notificationEnemyOrcArmored;
    Label_01C3:
        return GameData.notificationEnemyForestTroll;
    Label_01C9:
        return GameData.notificationEnemyZombie;
    Label_01CF:
        return GameData.notificationEnemyRottenSpider;
    Label_01D5:
        return GameData.notificationEnemyRottenTree;
    Label_01DB:
        return GameData.notificationEnemySwampThing;
    Label_01E1:
        return GameData.notificationEnemyRaider;
    Label_01E7:
        return GameData.notificationEnemyPillager;
    Label_01ED:
        return GameData.notificationEnemyTrollSkater;
    Label_01F3:
        return GameData.notificationEnemyTrollBrute;
    Label_01F9:
        return GameData.notificationEnemyCerberus;
    Label_01FF:
        return GameData.notificationEnemyLegion;
    Label_0205:
        return GameData.notificationEnemyFlareon;
    Label_020B:
        return GameData.notificationEnemyGulaemon;
    Label_0211:
        return GameData.notificationEnemyRottenLesser;
    Label_0217:
        return GameData.notificationTipHeroes;
    Label_021D:
        return 0;
    }

    public void DisableTips()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0029;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.gameObject.layer = 2;
        Label_0029:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004B;
        }
        finally
        {
        Label_0039:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0044;
            }
        Label_0044:
            disposable.Dispose();
        }
    Label_004B:
        return;
    }

    public void EnableTips()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_002A;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.gameObject.layer = 9;
        Label_002A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004C;
        }
        finally
        {
        Label_003A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0045;
            }
        Label_0045:
            disposable.Dispose();
        }
    Label_004C:
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void RemoveNotification(int index)
    {
        object[] objArray1;
        Transform transform;
        IEnumerator enumerator;
        NotificationIcon icon;
        IDisposable disposable;
        if (index != this.notificationCount)
        {
            goto Label_001B;
        }
        this.notificationCount -= 1;
        return;
    Label_001B:
        enumerator = base.transform.GetEnumerator();
    Label_0027:
        try
        {
            goto Label_00B2;
        Label_002C:
            transform = (Transform) enumerator.Current;
            icon = transform.GetComponent<NotificationIcon>();
            if (icon.Index <= index)
            {
                goto Label_00B2;
            }
            objArray1 = new object[] { "position", (Vector3) (this.initPosition - new Vector3(0f, (float) ((icon.Index - 2) * 100), &this.initPosition.z)), "time", (float) 0.5f };
            iTween.MoveTo(icon.gameObject, iTween.Hash(objArray1));
        Label_00B2:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002C;
            }
            goto Label_00D4;
        }
        finally
        {
        Label_00C2:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00CD;
            }
        Label_00CD:
            disposable.Dispose();
        }
    Label_00D4:
        this.notificationCount -= 1;
        return;
    }

    private void SetAsShown(Constants.notificationType n)
    {
        Constants.notificationType type;
        type = n;
        switch (type)
        {
            case 0:
                goto Label_0109;

            case 1:
                goto Label_0114;

            case 2:
                goto Label_0303;

            case 3:
                goto Label_0303;

            case 4:
                goto Label_0303;

            case 5:
                goto Label_0303;

            case 6:
                goto Label_0303;

            case 7:
                goto Label_0303;

            case 8:
                goto Label_0303;

            case 9:
                goto Label_011F;

            case 10:
                goto Label_012A;

            case 11:
                goto Label_0135;

            case 12:
                goto Label_0303;

            case 13:
                goto Label_0303;

            case 14:
                goto Label_0303;

            case 15:
                goto Label_0303;

            case 0x10:
                goto Label_0140;

            case 0x11:
                goto Label_014B;

            case 0x12:
                goto Label_0156;

            case 0x13:
                goto Label_0161;

            case 20:
                goto Label_016C;

            case 0x15:
                goto Label_0177;

            case 0x16:
                goto Label_0182;

            case 0x17:
                goto Label_018D;

            case 0x18:
                goto Label_0198;

            case 0x19:
                goto Label_0303;

            case 0x1a:
                goto Label_0303;

            case 0x1b:
                goto Label_0303;

            case 0x1c:
                goto Label_0303;

            case 0x1d:
                goto Label_01A3;

            case 30:
                goto Label_01AE;

            case 0x1f:
                goto Label_01B9;

            case 0x20:
                goto Label_01C4;

            case 0x21:
                goto Label_01CF;

            case 0x22:
                goto Label_01DA;

            case 0x23:
                goto Label_01E5;

            case 0x24:
                goto Label_01F0;

            case 0x25:
                goto Label_01FB;

            case 0x26:
                goto Label_0206;

            case 0x27:
                goto Label_0211;

            case 40:
                goto Label_021C;

            case 0x29:
                goto Label_0227;

            case 0x2a:
                goto Label_0232;

            case 0x2b:
                goto Label_023D;

            case 0x2c:
                goto Label_0248;

            case 0x2d:
                goto Label_0253;

            case 0x2e:
                goto Label_025E;

            case 0x2f:
                goto Label_0269;

            case 0x30:
                goto Label_0274;

            case 0x31:
                goto Label_0303;

            case 50:
                goto Label_027F;

            case 0x33:
                goto Label_028A;

            case 0x34:
                goto Label_02F8;

            case 0x35:
                goto Label_0295;

            case 0x36:
                goto Label_02A0;

            case 0x37:
                goto Label_0303;

            case 0x38:
                goto Label_02AB;

            case 0x39:
                goto Label_02B6;

            case 0x3a:
                goto Label_02C1;

            case 0x3b:
                goto Label_02CC;

            case 60:
                goto Label_02D7;

            case 0x3d:
                goto Label_02E2;

            case 0x3e:
                goto Label_02ED;
        }
        goto Label_0303;
    Label_0109:
        GameData.notificationEnemyGoblin = 1;
        goto Label_0308;
    Label_0114:
        GameData.notificationEnemyFatOrc = 1;
        goto Label_0308;
    Label_011F:
        GameData.notificationEnemySmallWolf = 1;
        goto Label_0308;
    Label_012A:
        GameData.notificationEnemyShaman = 1;
        goto Label_0308;
    Label_0135:
        GameData.notificationEnemyOgre = 1;
        goto Label_0308;
    Label_0140:
        GameData.notificationEnemyBandit = 1;
        goto Label_0308;
    Label_014B:
        GameData.notificationEnemyBrigand = 1;
        goto Label_0308;
    Label_0156:
        GameData.notificationEnemyDarkKnight = 1;
        goto Label_0308;
    Label_0161:
        GameData.notificationEnemyMarauder = 1;
        goto Label_0308;
    Label_016C:
        GameData.notificationEnemySpider = 1;
        goto Label_0308;
    Label_0177:
        GameData.notificationEnemySpiderSmall = 1;
        goto Label_0308;
    Label_0182:
        GameData.notificationEnemyShadowArcher = 1;
        goto Label_0308;
    Label_018D:
        GameData.notificationEnemyGargoyle = 1;
        goto Label_0308;
    Label_0198:
        GameData.notificationEnemyWolf = 1;
        goto Label_0308;
    Label_01A3:
        GameData.notificationEnemyTroll = 1;
        goto Label_0308;
    Label_01AE:
        GameData.notificationEnemyTrollAxeThrower = 1;
        goto Label_0308;
    Label_01B9:
        GameData.notificationEnemyTrollChieftain = 1;
        goto Label_0308;
    Label_01C4:
        GameData.notificationEnemyWhiteWolf = 1;
        goto Label_0308;
    Label_01CF:
        GameData.notificationEnemyDarkSlayer = 1;
        goto Label_0308;
    Label_01DA:
        GameData.notificationEnemyYeti = 1;
        goto Label_0308;
    Label_01E5:
        GameData.notificationEnemyRocketeer = 1;
        goto Label_0308;
    Label_01F0:
        GameData.notificationEnemyDemon = 1;
        goto Label_0308;
    Label_01FB:
        GameData.notificationEnemyDemonMage = 1;
        goto Label_0308;
    Label_0206:
        GameData.notificationEnemyDemonImp = 1;
        goto Label_0308;
    Label_0211:
        GameData.notificationEnemyDemonWolf = 1;
        goto Label_0308;
    Label_021C:
        GameData.notificationEnemyNecromancer = 1;
        goto Label_0308;
    Label_0227:
        GameData.notificationEnemyLavaElemental = 1;
        goto Label_0308;
    Label_0232:
        GameData.notificationEnemySarelgazSmall = 1;
        goto Label_0308;
    Label_023D:
        GameData.notificationEnemyGoblinZapper = 1;
        goto Label_0308;
    Label_0248:
        GameData.notificationEnemyOrcRider = 1;
        goto Label_0308;
    Label_0253:
        GameData.notificationEnemyOrcArmored = 1;
        goto Label_0308;
    Label_025E:
        GameData.notificationEnemyForestTroll = 1;
        goto Label_0308;
    Label_0269:
        GameData.notificationEnemyZombie = 1;
        goto Label_0308;
    Label_0274:
        GameData.notificationEnemyRottenSpider = 1;
        goto Label_0308;
    Label_027F:
        GameData.notificationEnemyRottenTree = 1;
        goto Label_0308;
    Label_028A:
        GameData.notificationEnemySwampThing = 1;
        goto Label_0308;
    Label_0295:
        GameData.notificationEnemyRaider = 1;
        goto Label_0308;
    Label_02A0:
        GameData.notificationEnemyPillager = 1;
        goto Label_0308;
    Label_02AB:
        GameData.notificationEnemyTrollSkater = 1;
        goto Label_0308;
    Label_02B6:
        GameData.notificationEnemyTrollBrute = 1;
        goto Label_0308;
    Label_02C1:
        GameData.notificationEnemyCerberus = 1;
        goto Label_0308;
    Label_02CC:
        GameData.notificationEnemyLegion = 1;
        goto Label_0308;
    Label_02D7:
        GameData.notificationEnemyFlareon = 1;
        goto Label_0308;
    Label_02E2:
        GameData.notificationEnemyGulaemon = 1;
        goto Label_0308;
    Label_02ED:
        GameData.notificationEnemyRottenLesser = 1;
        goto Label_0308;
    Label_02F8:
        GameData.notificationTipHeroes = 1;
        goto Label_0308;
    Label_0303:;
    Label_0308:
        return;
    }

    private void SetInitPosition()
    {
        float num;
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_0043;
        }
        this.initPosition = new Vector3(-595f, 400f, -901f);
        goto Label_0092;
    Label_0043:
        if (Mathf.Abs(num - 1.6f) >= 0.1f)
        {
            goto Label_0078;
        }
        this.initPosition = new Vector3(-760f, 400f, -901f);
        goto Label_0092;
    Label_0078:
        this.initPosition = new Vector3(-820f, 400f, -901f);
    Label_0092:
        return;
    }

    private void ShowNotificationIcon(Constants.notificationType n)
    {
        Vector3 vector;
        Transform transform;
        vector = this.initPosition - new Vector3(0f, (float) (100 * (this.notificationCount - 1)), 0f);
        transform = UnityEngine.Object.Instantiate(this.prefabIcon, vector, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.GetComponent<NotificationIcon>().Init(n, this.notificationCount, this, this.gui, this.guiBottom);
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        this.prefabIcon = Resources.Load("Prefabs/Notifications/IconTip", typeof(Transform)) as Transform;
        this.gui = base.transform.parent.parent.GetComponent<GameGui>();
        this.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.SetInitPosition();
        return;
    }
}

