using System;
using UnityEngine;

public class NotificationTowerDouble : MonoBehaviour
{
    private bool isDisplayed;
    private Transform portraitArcane;
    private Transform portraitBarbarian;
    private Transform portraitBfg;
    private Transform portraitPaladin;
    private StageBase stage;
    private TextMesh textDescription1;
    private TextMesh textDescription2;
    private TextMesh textExtra1;
    private TextMesh textExtra2;
    private TextMesh textTitle1;
    private TextMesh textTitle2;
    private Constants.notificationType type;

    public NotificationTowerDouble()
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
        this.portraitArcane.gameObject.SetActive(0);
        this.portraitBarbarian.gameObject.SetActive(0);
        this.portraitBfg.gameObject.SetActive(0);
        this.portraitPaladin.gameObject.SetActive(0);
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
        if (type == 15)
        {
            goto Label_001C;
        }
        if (type == 0x1c)
        {
            goto Label_002D;
        }
        goto Label_003E;
    Label_001C:
        GameData.notificationTowerSoldiersPaladin = 1;
        GameData.notificationTowerMagesArcane = 1;
        goto Label_0043;
    Label_002D:
        GameData.notificationTowerSoldiersBarbarian = 1;
        GameData.notificationTowerEngineersBfg = 1;
        goto Label_0043;
    Label_003E:;
    Label_0043:
        return;
    }

    public void Setup(Constants.notificationType type)
    {
        Constants.notificationType type2;
        base.gameObject.SetActive(1);
        this.type = type;
        this.HideAll();
        type2 = type;
        if (type2 == 15)
        {
            goto Label_0030;
        }
        if (type2 == 0x1c)
        {
            goto Label_00B7;
        }
        goto Label_013E;
    Label_0030:
        this.portraitPaladin.gameObject.SetActive(1);
        this.portraitArcane.gameObject.SetActive(1);
        this.textTitle1.text = "Arcane";
        this.textDescription1.text = "Arcane wizards focus on altering\nreality, as well as shooting the\ndeadliest magical ray known to\nman.";
        this.textExtra1.text = "Very high damage. Excellent against armored\nenemies.";
        this.textTitle2.text = "Holy Order";
        this.textDescription2.text = "Trains paladins, an order of holy\nwarriors. They are paragons of\ndivine protection and heavenly\ndefense.";
        this.textExtra2.text = "Spawns paladins with full plate armor that\ncan block enemies longer.";
        goto Label_0143;
    Label_00B7:
        this.portraitBfg.gameObject.SetActive(1);
        this.portraitBarbarian.gameObject.SetActive(1);
        this.textTitle1.text = "Big Bertha";
        this.textDescription1.text = "The 500mm siege gun aka\n\"Big Bertha\" is the biggest,\nbaddest piece of artillery in the\nblock.";
        this.textExtra1.text = "Biggest piece of artillery that deals very high\narea damage.";
        this.textTitle2.text = "Barbarian Hall";
        this.textDescription2.text = "Barbarians are savage warriors\nthat will quickly clear a\nbattlefield, usually at the cost\nof their own lives.";
        this.textExtra2.text = "Spawns axe wielding barbarians that can\nobliterate most foes.";
        goto Label_0143;
    Label_013E:;
    Label_0143:
        this.PopIn();
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        this.textDescription1 = base.transform.FindChild("CardTower1").FindChild("TextDescription").GetComponent<TextMesh>();
        this.textTitle1 = base.transform.FindChild("CardTower1").FindChild("TextTitle").GetComponent<TextMesh>();
        this.textExtra1 = base.transform.FindChild("CardTower1").FindChild("TextExtra").GetComponent<TextMesh>();
        this.textDescription2 = base.transform.FindChild("CardTower2").FindChild("TextDescription").GetComponent<TextMesh>();
        this.textTitle2 = base.transform.FindChild("CardTower2").FindChild("TextTitle").GetComponent<TextMesh>();
        this.textExtra2 = base.transform.FindChild("CardTower2").FindChild("TextExtra").GetComponent<TextMesh>();
        this.portraitArcane = base.transform.FindChild("CardTower1").FindChild("Portrait").FindChild("Arcane");
        this.portraitBfg = base.transform.FindChild("CardTower1").FindChild("Portrait").FindChild("BFG");
        this.portraitBarbarian = base.transform.FindChild("CardTower2").FindChild("Portrait").FindChild("Barbarian");
        this.portraitPaladin = base.transform.FindChild("CardTower2").FindChild("Portrait").FindChild("Paladin");
        base.gameObject.SetActive(0);
        return;
    }
}

