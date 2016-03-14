using System;
using UnityEngine;

public class HeroRoomPortrait : MonoBehaviour
{
    private PackedSprite glowSprite;
    private HeroRoom heroRoom;
    private GameUpgrades.heroType heroType;
    private PackedSprite lockSprite;
    private PackedSprite outlineSprite;
    private PackedSprite sprite;
    private PackedSprite tickSprite;

    public HeroRoomPortrait()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.tickSprite = base.transform.FindChild("Tick").GetComponent<PackedSprite>();
        this.outlineSprite = base.transform.FindChild("Outline").GetComponent<PackedSprite>();
        this.lockSprite = base.transform.FindChild("Lock").GetComponent<PackedSprite>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void HideLock()
    {
        this.lockSprite.Hide(1);
        return;
    }

    public void HideOutline()
    {
        this.outlineSprite.Hide(1);
        return;
    }

    public void HideTick()
    {
        this.tickSprite.Hide(1);
        return;
    }

    public void Init(GameUpgrades.heroType t)
    {
        this.heroType = t;
        if (GameUpgrades.CanSelectHero(t) != null)
        {
            goto Label_0052;
        }
        this.tickSprite.Hide(1);
        this.outlineSprite.Hide(1);
        this.sprite.PlayAnim("off");
        this.sprite.PauseAnim();
        this.lockSprite.Hide(0);
        return;
    Label_0052:
        this.lockSprite.Hide(1);
        if (this.heroType != GameUpgrades.SelectedHero)
        {
            goto Label_008B;
        }
        this.tickSprite.Hide(0);
        this.outlineSprite.Hide(0);
        goto Label_00A3;
    Label_008B:
        this.tickSprite.Hide(1);
        this.outlineSprite.Hide(1);
    Label_00A3:
        return;
    }

    private void OnMouseDown()
    {
        this.heroRoom.SetInfoHero(this.heroType);
        GameSoundManager.PlayGUIQuickMenuOpen();
        return;
    }

    private void OnMouseEnter()
    {
        this.glowSprite.Hide(0);
        return;
    }

    private void OnMouseExit()
    {
        this.glowSprite.Hide(1);
        return;
    }

    public void ShowLock()
    {
        this.tickSprite.Hide(1);
        this.outlineSprite.Hide(1);
        this.sprite.PlayAnim("off");
        this.sprite.PauseAnim();
        this.lockSprite.Hide(0);
        return;
    }

    public void ShowOutline()
    {
        this.outlineSprite.Hide(0);
        return;
    }

    public void ShowTick()
    {
        this.tickSprite.Hide(0);
        return;
    }

    private void Start()
    {
        this.heroRoom = base.transform.parent.GetComponent<HeroRoom>();
        this.tickSprite = base.transform.FindChild("Tick").GetComponent<PackedSprite>();
        this.glowSprite = base.transform.FindChild("Glow").GetComponent<PackedSprite>();
        this.outlineSprite = base.transform.FindChild("Outline").GetComponent<PackedSprite>();
        return;
    }
}

