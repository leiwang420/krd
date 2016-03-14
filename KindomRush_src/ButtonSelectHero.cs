using System;
using UnityEngine;

public class ButtonSelectHero : MonoBehaviour
{
    private HeroRoom heroRoom;
    private HeroRoomButton heroRoomButton;
    private PackedSprite sprite;

    public ButtonSelectHero()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        if (GameUpgrades.CanSelectHero(this.heroRoom.GetClickedHero()) != null)
        {
            goto Label_0016;
        }
        return;
    Label_0016:
        if (GameUpgrades.SelectedHero != this.heroRoom.GetClickedHero())
        {
            goto Label_0040;
        }
        this.heroRoom.DeselectHero();
        GameSoundManager.PlayGUIButtonCommon();
        goto Label_0193;
    Label_0040:
        this.heroRoom.SelectHero();
        GameSoundManager.PlayGUIBuyUpgrade();
        if (this.heroRoom.GetClickedHero() != 1)
        {
            goto Label_006B;
        }
        GameSoundManager.PlayHeroPaladinTauntSelect();
        goto Label_0193;
    Label_006B:
        if (this.heroRoom.GetClickedHero() != 2)
        {
            goto Label_0086;
        }
        GameSoundManager.PlayHeroArcherTauntSelect();
        goto Label_0193;
    Label_0086:
        if (this.heroRoom.GetClickedHero() != 7)
        {
            goto Label_00A1;
        }
        GameSoundManager.PlayHeroDenasTauntSelect();
        goto Label_0193;
    Label_00A1:
        if (this.heroRoom.GetClickedHero() != 3)
        {
            goto Label_00BC;
        }
        GameSoundManager.PlayHeroDwarfTauntSelect();
        goto Label_0193;
    Label_00BC:
        if (this.heroRoom.GetClickedHero() != 4)
        {
            goto Label_00D7;
        }
        GameSoundManager.PlayHeroMageTauntSelect();
        goto Label_0193;
    Label_00D7:
        if (this.heroRoom.GetClickedHero() != 6)
        {
            goto Label_00F2;
        }
        GameSoundManager.PlayHeroRainOfFireTauntSelect();
        goto Label_0193;
    Label_00F2:
        if (this.heroRoom.GetClickedHero() != 5)
        {
            goto Label_010D;
        }
        GameSoundManager.PlayHeroReinforcementTauntSelect();
        goto Label_0193;
    Label_010D:
        if (this.heroRoom.GetClickedHero() != 9)
        {
            goto Label_0129;
        }
        GameSoundManager.PlayHeroVikingTauntSelect();
        goto Label_0193;
    Label_0129:
        if (this.heroRoom.GetClickedHero() != 8)
        {
            goto Label_0144;
        }
        GameSoundManager.PlayHeroFrostTauntSelect();
        goto Label_0193;
    Label_0144:
        if (this.heroRoom.GetClickedHero() != 12)
        {
            goto Label_0160;
        }
        GameSoundManager.PlayHeroRobotTauntSelect();
        goto Label_0193;
    Label_0160:
        if (this.heroRoom.GetClickedHero() != 11)
        {
            goto Label_017C;
        }
        GameSoundManager.PlayHeroSamuraiTauntSelect();
        goto Label_0193;
    Label_017C:
        if (this.heroRoom.GetClickedHero() != 10)
        {
            goto Label_0193;
        }
        GameSoundManager.PlayHeroThorTauntSelect();
    Label_0193:
        this.heroRoomButton.Refresh();
        return;
    }

    private void OnMouseEnter()
    {
        if (GameUpgrades.CanSelectHero(this.heroRoom.GetClickedHero()) != null)
        {
            goto Label_0016;
        }
        return;
    Label_0016:
        if (GameUpgrades.SelectedHero != this.heroRoom.GetClickedHero())
        {
            goto Label_0040;
        }
        this.sprite.PlayAnim("deselectOver");
        goto Label_0050;
    Label_0040:
        this.sprite.PlayAnim("over");
    Label_0050:
        return;
    }

    private void OnMouseExit()
    {
        if (GameUpgrades.CanSelectHero(this.heroRoom.GetClickedHero()) != null)
        {
            goto Label_0016;
        }
        return;
    Label_0016:
        if (GameUpgrades.SelectedHero != this.heroRoom.GetClickedHero())
        {
            goto Label_0040;
        }
        this.sprite.PlayAnim("deselect");
        goto Label_004B;
    Label_0040:
        this.sprite.RevertToStatic();
    Label_004B:
        return;
    }

    public void Refresh()
    {
        GameUpgrades.heroType type;
        type = this.heroRoom.GetClickedHero();
        if (GameUpgrades.CanSelectHero(type) != null)
        {
            goto Label_01C3;
        }
        if (type != 1)
        {
            goto Label_003E;
        }
        this.sprite.PlayAnim("lock3");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_003E:
        if (type != 2)
        {
            goto Label_0065;
        }
        this.sprite.PlayAnim("lock5");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_0065:
        if (type != 5)
        {
            goto Label_008C;
        }
        this.sprite.PlayAnim("lock7");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_008C:
        if (type != 3)
        {
            goto Label_00B3;
        }
        this.sprite.PlayAnim("lock7");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_00B3:
        if (type != 4)
        {
            goto Label_00DA;
        }
        this.sprite.PlayAnim("lock8");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_00DA:
        if (type != 6)
        {
            goto Label_0101;
        }
        this.sprite.PlayAnim("lock10");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_0101:
        if (type != 7)
        {
            goto Label_0128;
        }
        this.sprite.PlayAnim("lock11");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_0128:
        if (type != 9)
        {
            goto Label_0150;
        }
        this.sprite.PlayAnim("lock12");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_0150:
        if (type != 8)
        {
            goto Label_0177;
        }
        this.sprite.PlayAnim("lock12");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_0177:
        if (type != 12)
        {
            goto Label_019F;
        }
        this.sprite.PlayAnim("lock12");
        this.sprite.PauseAnim();
        goto Label_01C2;
    Label_019F:
        if (type != 11)
        {
            goto Label_01C2;
        }
        this.sprite.PlayAnim("lock12");
        this.sprite.PauseAnim();
    Label_01C2:
        return;
    Label_01C3:
        if (GameUpgrades.SelectedHero != this.heroRoom.GetClickedHero())
        {
            goto Label_01ED;
        }
        this.sprite.PlayAnim("deselect");
        goto Label_01F8;
    Label_01ED:
        this.sprite.RevertToStatic();
    Label_01F8:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.heroRoom = base.transform.parent.GetComponent<HeroRoom>();
        this.heroRoomButton = GameObject.Find("HeroRoomButton").GetComponent<HeroRoomButton>();
        if (GameUpgrades.SelectedHero == null)
        {
            goto Label_0051;
        }
        this.sprite.PlayAnim("deselect");
    Label_0051:
        return;
    }
}

