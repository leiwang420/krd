using System;
using UnityEngine;

public class NotificationTipCard : MonoBehaviour
{
    private Transform buttonOk;
    private NotificationIcon icon;
    private bool isDisplayed;
    private PackedSprite sprite;
    private StageBase stage;
    private Transform title;

    public NotificationTipCard()
    {
        base..ctor();
        return;
    }

    private void Deactivate()
    {
        this.isDisplayed = 0;
        this.stage.UnPause(1);
        base.gameObject.SetActive(0);
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
        this.icon.Hide();
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1a, "oncomplete", "Deactivate" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
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

    public void Setup(Constants.notificationType type, NotificationIcon icon)
    {
        Constants.notificationType type2;
        this.icon = icon;
        base.gameObject.SetActive(1);
        type2 = type;
        switch ((type2 - 4))
        {
            case 0:
                goto Label_003E;

            case 1:
                goto Label_00FA;

            case 2:
                goto Label_01C2;

            case 3:
                goto Label_0226;

            case 4:
                goto Label_0096;
        }
        if (type2 == 0x34)
        {
            goto Label_015E;
        }
        goto Label_028A;
    Label_003E:
        this.sprite.RevertToStatic();
        this.title.transform.localPosition = new Vector3(0f, 262f, 1f);
        this.buttonOk.transform.localPosition = new Vector3(167f, -256f, 1f);
        goto Label_028A;
    Label_0096:
        this.sprite.PlayAnim(3);
        this.sprite.PauseAnim();
        this.title.transform.localPosition = new Vector3(0f, 271f, 1f);
        this.buttonOk.transform.localPosition = new Vector3(167f, -263f, 1f);
        goto Label_028A;
    Label_00FA:
        this.sprite.PlayAnim(0);
        this.sprite.PauseAnim();
        this.title.transform.localPosition = new Vector3(0f, 262f, 1f);
        this.buttonOk.transform.localPosition = new Vector3(167f, -256f, 1f);
        goto Label_028A;
    Label_015E:
        this.sprite.PlayAnim(5);
        this.sprite.PauseAnim();
        this.title.transform.localPosition = new Vector3(0f, 245f, 1f);
        this.buttonOk.transform.localPosition = new Vector3(125f, -232f, 1f);
        goto Label_028A;
    Label_01C2:
        this.sprite.PlayAnim(1);
        this.sprite.PauseAnim();
        this.title.transform.localPosition = new Vector3(0f, 280f, 1f);
        this.buttonOk.transform.localPosition = new Vector3(167f, -276f, 1f);
        goto Label_028A;
    Label_0226:
        this.sprite.PlayAnim(2);
        this.sprite.PauseAnim();
        this.title.transform.localPosition = new Vector3(0f, 271f, 1f);
        this.buttonOk.transform.localPosition = new Vector3(167f, -263f, 1f);
    Label_028A:
        this.PopIn();
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.title = base.transform.FindChild("Title");
        this.buttonOk = base.transform.FindChild("ButtonOk");
        base.gameObject.SetActive(0);
        return;
    }
}

