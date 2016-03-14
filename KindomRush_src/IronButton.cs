using System;
using UnityEngine;

public class IronButton : MonoBehaviour
{
    private PackedSprite sprite;
    private StageSelect stageSelect;
    private Transform tip;

    public IronButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        if ((this.sprite.GetCurAnim().name == "locked") == null)
        {
            goto Label_0020;
        }
        return;
    Label_0020:
        if (GameData.GetGameMode() == 2)
        {
            goto Label_0052;
        }
        this.stageSelect.SetGameMode(2);
        this.stageSelect.SetupIron();
        this.sprite.RevertToStatic();
        GameSoundManager.PlayGUIButtonCommon();
    Label_0052:
        return;
    }

    private void OnMouseEnter()
    {
        if ((this.sprite.GetCurAnim().name == "locked") == null)
        {
            goto Label_0031;
        }
        this.tip.gameObject.SetActive(1);
        return;
    Label_0031:
        if (GameData.GetGameMode() == 2)
        {
            goto Label_0051;
        }
        this.sprite.PlayAnim("over");
        GameSoundManager.PlayGUIQuickMenuOver();
    Label_0051:
        return;
    }

    private void OnMouseExit()
    {
        if ((this.sprite.GetCurAnim().name == "locked") == null)
        {
            goto Label_0031;
        }
        this.tip.gameObject.SetActive(0);
        return;
    Label_0031:
        if (GameData.GetGameMode() == 2)
        {
            goto Label_004C;
        }
        this.sprite.PlayAnim("off");
    Label_004C:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.stageSelect = base.transform.parent.GetComponent<StageSelect>();
        this.tip = base.transform.FindChild("IronTip");
        this.tip.gameObject.SetActive(0);
        return;
    }

    public PackedSprite Sprite
    {
        get
        {
            return this.sprite;
        }
    }
}

