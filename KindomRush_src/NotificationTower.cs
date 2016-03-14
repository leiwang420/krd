using System;
using UnityEngine;

public class NotificationTower : MonoBehaviour
{
    private Transform buttonOk;
    private Transform frame;
    private bool isDisplayed;
    private Transform level2;
    private Transform level3;
    private Transform portraitMusketeer;
    private Transform portraitRanger;
    private Transform portraitSorcerer;
    private Transform portraitTesla;
    private StageBase stage;
    private TextMesh textDescription;
    private TextMesh textExtra;
    private TextMesh textTitle;
    private Transform title1;
    private Transform title2;
    private Transform title3;
    private Constants.notificationType type;

    public NotificationTower()
    {
        base..ctor();
        return;
    }

    private void Deactivate()
    {
        this.SetNotificationAsShown();
        this.stage.UnPause(1);
        base.gameObject.SetActive(0);
        this.isDisplayed = 0;
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        object[] objArray1;
        GameSoundManager.Unpause();
        GameSoundManager.PlayGUINotificationClose();
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1a, "oncomplete", "Deactivate" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void HideAll()
    {
        this.portraitMusketeer.gameObject.SetActive(0);
        this.portraitRanger.gameObject.SetActive(0);
        this.portraitSorcerer.gameObject.SetActive(0);
        this.portraitTesla.gameObject.SetActive(0);
        this.frame.gameObject.SetActive(0);
        this.textDescription.gameObject.SetActive(0);
        this.textExtra.gameObject.SetActive(0);
        this.textTitle.gameObject.SetActive(0);
        this.level2.gameObject.SetActive(0);
        this.level3.gameObject.SetActive(0);
        this.title1.gameObject.SetActive(0);
        this.title2.gameObject.SetActive(0);
        this.title3.gameObject.SetActive(0);
        return;
    }

    public bool IsDisplayed()
    {
        return this.isDisplayed;
    }

    private void PopIn()
    {
        object[] objArray1;
        GameSoundManager.PlayGUINotificationOpen();
        base.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1b };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        this.isDisplayed = 1;
        return;
    }

    private void SetNotificationAsShown()
    {
        Constants.notificationType type;
        type = this.type;
        switch ((type - 12))
        {
            case 0:
                goto Label_0036;

            case 1:
                goto Label_0053;

            case 2:
                goto Label_0070;
        }
        switch ((type - 0x19))
        {
            case 0:
                goto Label_008B;

            case 1:
                goto Label_00A1;

            case 2:
                goto Label_0096;
        }
        goto Label_00AC;
    Label_0036:
        GameData.notificationTowerArchersLevel2 = 1;
        GameData.notificationTowerEngineersLevel2 = 1;
        GameData.notificationTowerMagesLevel2 = 1;
        GameData.notificationTowerSoldiersLevel2 = 1;
        goto Label_00B1;
    Label_0053:
        GameData.notificationTowerArchersLevel3 = 1;
        GameData.notificationTowerEngineersLevel3 = 1;
        GameData.notificationTowerMagesLevel3 = 1;
        GameData.notificationTowerSoldiersLevel3 = 1;
        goto Label_00B1;
    Label_0070:
        GameData.notificationTowerArchersRanger = 1;
        ((Stage5) this.stage).EnableRangerTower();
        goto Label_00B1;
    Label_008B:
        GameData.notificationTowerArchersMusketeer = 1;
        goto Label_00B1;
    Label_0096:
        GameData.notificationTowerMagesSorcerer = 1;
        goto Label_00B1;
    Label_00A1:
        GameData.notificationTowerEngineersTesla = 1;
        goto Label_00B1;
    Label_00AC:;
    Label_00B1:
        return;
    }

    public void Setup(Constants.notificationType type)
    {
        Constants.notificationType type2;
        base.gameObject.SetActive(1);
        this.type = type;
        this.HideAll();
        type2 = type;
        switch ((type2 - 12))
        {
            case 0:
                goto Label_004A;

            case 1:
                goto Label_011F;

            case 2:
                goto Label_01F4;
        }
        switch ((type2 - 0x19))
        {
            case 0:
                goto Label_02FB;

            case 1:
                goto Label_0509;

            case 2:
                goto Label_0402;
        }
        goto Label_0610;
    Label_004A:
        this.level2.gameObject.SetActive(1);
        this.textTitle.gameObject.SetActive(1);
        this.textDescription.gameObject.SetActive(1);
        this.title3.gameObject.SetActive(1);
        this.textDescription.transform.localPosition = new Vector3(-317f, 85f, -1f);
        this.textTitle.transform.localPosition = new Vector3(-262f, 153f, -1f);
        this.buttonOk.transform.localPosition = new Vector3(212f, -250f, 1f);
        this.textTitle.text = "Towers level 2 available";
        this.textDescription.text = "You can now upgrade your towers up to level 2.";
        goto Label_0615;
    Label_011F:
        this.level3.gameObject.SetActive(1);
        this.textTitle.gameObject.SetActive(1);
        this.textDescription.gameObject.SetActive(1);
        this.title3.gameObject.SetActive(1);
        this.textDescription.transform.localPosition = new Vector3(-317f, 85f, -1f);
        this.textTitle.transform.localPosition = new Vector3(-262f, 153f, -1f);
        this.buttonOk.transform.localPosition = new Vector3(212f, -250f, 1f);
        this.textTitle.text = "Towers level 3 available";
        this.textDescription.text = "You can now upgrade your towers up to level 3.";
        goto Label_0615;
    Label_01F4:
        this.frame.gameObject.SetActive(1);
        this.textTitle.gameObject.SetActive(1);
        this.textDescription.gameObject.SetActive(1);
        this.textExtra.gameObject.SetActive(1);
        this.portraitRanger.gameObject.SetActive(1);
        this.title2.gameObject.SetActive(1);
        this.textTitle.transform.localPosition = new Vector3(-82f, 141f, -1f);
        this.textDescription.transform.localPosition = new Vector3(-82f, 85f, -1f);
        this.buttonOk.transform.localPosition = new Vector3(200f, -190f, 1f);
        this.textTitle.text = "Rangers";
        this.textDescription.text = "Legendary masters of the bow,\nthey can unleash a hail of arrows\nfaster and further than any\nother force in the realm.";
        this.textExtra.text = "Fastest rate of fire and excellent range.";
        goto Label_0615;
    Label_02FB:
        this.frame.gameObject.SetActive(1);
        this.textTitle.gameObject.SetActive(1);
        this.textDescription.gameObject.SetActive(1);
        this.textExtra.gameObject.SetActive(1);
        this.portraitMusketeer.gameObject.SetActive(1);
        this.title2.gameObject.SetActive(1);
        this.textTitle.transform.localPosition = new Vector3(-82f, 141f, -1f);
        this.textDescription.transform.localPosition = new Vector3(-82f, 85f, -1f);
        this.buttonOk.transform.localPosition = new Vector3(200f, -190f, 1f);
        this.textTitle.text = "Musketeer";
        this.textDescription.text = "Patient, careful, and deadly\naccurate long-range deadeye\nshooters, with advanced weaponry.";
        this.textExtra.text = "Greatest range and very high damage.";
        goto Label_0615;
    Label_0402:
        this.frame.gameObject.SetActive(1);
        this.textTitle.gameObject.SetActive(1);
        this.textDescription.gameObject.SetActive(1);
        this.textExtra.gameObject.SetActive(1);
        this.portraitSorcerer.gameObject.SetActive(1);
        this.title2.gameObject.SetActive(1);
        this.textTitle.transform.localPosition = new Vector3(-82f, 141f, -1f);
        this.textDescription.transform.localPosition = new Vector3(-82f, 85f, -1f);
        this.buttonOk.transform.localPosition = new Vector3(200f, -190f, 1f);
        this.textTitle.text = "Sorcerer";
        this.textDescription.text = "Sorcerers handle forces that\nare close to darkness, weaving\nspells that temporary lower\nenemy armor and deal damage.";
        this.textExtra.text = "Curses enemies damaging them and reducing\ntheir armor for a while.";
        goto Label_0615;
    Label_0509:
        this.frame.gameObject.SetActive(1);
        this.textTitle.gameObject.SetActive(1);
        this.textDescription.gameObject.SetActive(1);
        this.textExtra.gameObject.SetActive(1);
        this.portraitTesla.gameObject.SetActive(1);
        this.title2.gameObject.SetActive(1);
        this.textTitle.transform.localPosition = new Vector3(-82f, 141f, -1f);
        this.textDescription.transform.localPosition = new Vector3(-82f, 85f, -1f);
        this.buttonOk.transform.localPosition = new Vector3(200f, -190f, 1f);
        this.textTitle.text = "Tesla x104";
        this.textDescription.text = "Dwarven engineering at its finest,\nharnessing the power of a\nthousand thunderstorms.\nWho shall we aim it at?";
        this.textExtra.text = "Shoots bolts of lightning that can strike\nmultiple ground and flying enemies.";
        goto Label_0615;
    Label_0610:;
    Label_0615:
        this.PopIn();
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        this.textDescription = base.transform.FindChild("TextDescription").GetComponent<TextMesh>();
        this.textTitle = base.transform.FindChild("TextTitle").GetComponent<TextMesh>();
        this.textExtra = base.transform.FindChild("TextExtra").GetComponent<TextMesh>();
        this.portraitMusketeer = base.transform.FindChild("Portrait").FindChild("Musketeer");
        this.portraitRanger = base.transform.FindChild("Portrait").FindChild("Ranger");
        this.portraitSorcerer = base.transform.FindChild("Portrait").FindChild("Sorcerer");
        this.portraitTesla = base.transform.FindChild("Portrait").FindChild("Tesla");
        this.frame = base.transform.FindChild("Frame");
        this.level2 = base.transform.FindChild("Level2");
        this.level3 = base.transform.FindChild("Level3");
        this.buttonOk = base.transform.FindChild("ButtonOk");
        this.title1 = base.transform.FindChild("Title1");
        this.title2 = base.transform.FindChild("Title2");
        this.title3 = base.transform.FindChild("Title3");
        base.gameObject.SetActive(0);
        return;
    }
}

