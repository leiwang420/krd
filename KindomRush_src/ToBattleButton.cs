using System;
using UnityEngine;

public class ToBattleButton : MonoBehaviour
{
    private PackedSprite sprite;
    private StageSelect stageSelect;

    public ToBattleButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.stageSelect.LaunchStage();
        return;
    }

    private void OnMouseEnter()
    {
        if (GameData.GetGameMode() != null)
        {
            goto Label_001F;
        }
        this.sprite.PlayAnim("overCampaign");
        goto Label_005A;
    Label_001F:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_003F;
        }
        this.sprite.PlayAnim("overHeroic");
        goto Label_005A;
    Label_003F:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_005A;
        }
        this.sprite.PlayAnim("overIron");
    Label_005A:
        return;
    }

    private void OnMouseExit()
    {
        if (GameData.GetGameMode() != null)
        {
            goto Label_001A;
        }
        this.sprite.RevertToStatic();
        goto Label_0055;
    Label_001A:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_003A;
        }
        this.sprite.PlayAnim("heroic");
        goto Label_0055;
    Label_003A:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_0055;
        }
        this.sprite.PlayAnim("iron");
    Label_0055:
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

