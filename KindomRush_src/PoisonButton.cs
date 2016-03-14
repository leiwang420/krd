using System;
using UnityEngine;

public class PoisonButton : AbilityButton
{
    private ArcherTower tower;

    public PoisonButton()
    {
        base..ctor();
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        if (base.ability.IsMaxLevel() != null)
        {
            goto Label_008A;
        }
        if (base.available == null)
        {
            goto Label_008A;
        }
        base.PlayEffectBuy();
        base.ability.LevelUp();
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().SetSpent(base.price);
        this.SetRanks("poisonPriceLevel");
        GameSoundManager.PlayerRangerPoisonTaunt();
        base.HideTooltip();
        if (this.tower.GetPoisonLevel() == 3)
        {
            goto Label_0084;
        }
        this.ShowTooltip("Poison", this.tower.GetPoisonLevel());
    Label_0084:
        this.DisableMaxLevelPricetag();
    Label_008A:
        return;
    }

    private void OnMouseEnter()
    {
        if (base.available == null)
        {
            goto Label_0042;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position, Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_0042:
        if (this.tower.GetPoisonLevel() == 3)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Poison", this.tower.GetPoisonLevel());
    Label_0069:
        return;
    }

    private void OnMouseExit()
    {
        base.DestroyGlow();
        base.HideTooltip();
        return;
    }

    private void Start()
    {
        base.effectBuy = base.transform.FindChild("EffectBuy").GetComponent<PackedSprite>();
        base.priceTag = base.transform.FindChild("Pricetag");
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        this.tower = base.menu.GetCurrentSelect().GetComponent<ArcherTower>();
        base.ability = this.tower.GetComponent<PoisonAbility>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("poisonPriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (base.ability.GetLevel() < 1)
        {
            goto Label_00EA;
        }
        base.CheckAvailable("poisonPriceLevel");
        goto Label_00F5;
    Label_00EA:
        base.CheckAvailable("poisonPrice");
    Label_00F5:
        this.DisableMaxLevelPricetag();
        return;
    }

    private void Update()
    {
        base.Update();
        if (base.ability.GetLevel() < 1)
        {
            goto Label_0027;
        }
        base.CheckAvailable("poisonPriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("poisonPrice");
    Label_0032:
        return;
    }
}

