using System;
using UnityEngine;

public class NotificationTipPower : MonoBehaviour
{
    private bool isDisplayed;
    private Transform portraitFireball;
    private Transform portraitReinforcement;
    private StageBase stage;
    private TextMesh textDescription;
    private TextMesh textTitle;
    private Constants.notificationType type;

    public NotificationTipPower()
    {
        base..ctor();
        return;
    }

    private void Deactivate()
    {
        Constants.notificationType type;
        type = this.type;
        if (type == 2)
        {
            goto Label_003C;
        }
        if (type == 3)
        {
            goto Label_001A;
        }
        goto Label_005E;
    Label_001A:
        this.stage.EnablePower(3);
        ((Stage1) this.stage).ShowBalloonPower(3);
        goto Label_0063;
    Label_003C:
        this.stage.EnablePower(2);
        ((Stage1) this.stage).ShowBalloonPower(2);
        goto Label_0063;
    Label_005E:;
    Label_0063:
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
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1a, "oncomplete", "Deactivate" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void HideAll()
    {
        this.portraitFireball.gameObject.SetActive(0);
        this.portraitReinforcement.gameObject.SetActive(0);
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

    public void Setup(Constants.notificationType type)
    {
        Constants.notificationType type2;
        this.type = type;
        base.gameObject.SetActive(1);
        this.HideAll();
        type2 = type;
        if (type2 == 2)
        {
            goto Label_0064;
        }
        if (type2 == 3)
        {
            goto Label_002E;
        }
        goto Label_009A;
    Label_002E:
        this.portraitFireball.gameObject.SetActive(1);
        this.textTitle.text = "Rain of Fire";
        this.textDescription.text = "Blast your enemies with fire\nfrom the skies!.\n\nRain of fire is best saved for\nan emergency or a great\nopportunity since it has a very\nlong cooldown.";
        goto Label_009F;
    Label_0064:
        this.portraitReinforcement.gameObject.SetActive(1);
        this.textTitle.text = "Reinforcements";
        this.textDescription.text = "You can summon troops to help\nyou in the battlefield.\n\nReinforcements are free and\nyou can call them every 10\nseconds.";
        goto Label_009F;
    Label_009A:;
    Label_009F:
        this.PopIn();
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        this.textDescription = base.transform.FindChild("TextDescription").GetComponent<TextMesh>();
        this.textTitle = base.transform.FindChild("TextTitle").GetComponent<TextMesh>();
        this.portraitFireball = base.transform.FindChild("Portrait").FindChild("Fireball");
        this.portraitReinforcement = base.transform.FindChild("Portrait").FindChild("Reinforcement");
        base.gameObject.SetActive(0);
        return;
    }
}

