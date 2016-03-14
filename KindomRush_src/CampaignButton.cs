using System;
using UnityEngine;

public class CampaignButton : MonoBehaviour
{
    private PackedSprite sprite;
    private StageSelect stageSelect;

    public CampaignButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        if (GameData.GetGameMode() == null)
        {
            goto Label_0031;
        }
        this.stageSelect.SetGameMode(0);
        this.stageSelect.SetupCampaign();
        this.sprite.RevertToStatic();
        GameSoundManager.PlayGUIButtonCommon();
    Label_0031:
        return;
    }

    private void OnMouseEnter()
    {
        if (GameData.GetGameMode() == null)
        {
            goto Label_001F;
        }
        this.sprite.PlayAnim("over");
        GameSoundManager.PlayGUIQuickMenuOver();
    Label_001F:
        return;
    }

    private void OnMouseExit()
    {
        if (GameData.GetGameMode() == null)
        {
            goto Label_001A;
        }
        this.sprite.PlayAnim("off");
    Label_001A:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.stageSelect = base.transform.parent.GetComponent<StageSelect>();
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

