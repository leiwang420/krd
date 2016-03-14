using System;
using UnityEngine;

public class UpgradeScreenButton : MonoBehaviour
{
    private Map map;
    private PackedSprite sprite;
    private Transform star;
    private TextMesh starText;
    private UpgradeScreen upgradeScreen;

    public UpgradeScreenButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void OnMouseUp()
    {
        this.map.HideBallonUpgrades();
        this.sprite.RevertToStatic();
        this.map.DisableMapButtons();
        this.map.ShowOverlay();
        this.upgradeScreen.Show();
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    public unsafe void RefreshStars()
    {
        object[] objArray1;
        int num;
        num = GameData.StarsToSpent;
        if (num <= 0)
        {
            goto Label_00D2;
        }
        this.star.gameObject.SetActive(1);
        this.starText.text = &num.ToString();
        this.star.localScale = new Vector3(0.95f, 0.95f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.25f, "easetype", (iTween.EaseType) 2, "looptype", (iTween.LoopType) 2 };
        iTween.ScaleTo(this.star.gameObject, iTween.Hash(objArray1));
        goto Label_00E3;
    Label_00D2:
        this.star.gameObject.SetActive(0);
    Label_00E3:
        return;
    }

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.upgradeScreen = GameObject.Find("Upgrade Screen").GetComponent<UpgradeScreen>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.star = base.transform.FindChild("Star");
        this.starText = this.star.FindChild("Text").GetComponent<TextMesh>();
        this.RefreshStars();
        return;
    }
}

