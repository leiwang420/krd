using System;
using UnityEngine;

public class ElementalButton : AbilityButton
{
    public ElementalButton()
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
            goto Label_0085;
        }
        if (base.available == null)
        {
            goto Label_0085;
        }
        base.PlayEffectBuy();
        base.ability.LevelUp();
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().SetSpent(base.price);
        this.SetRanks("elementalPriceLevel");
        base.HideTooltip();
        if (base.ability.GetLevel() == 3)
        {
            goto Label_007F;
        }
        this.ShowTooltip("Elemental", base.ability.GetLevel());
    Label_007F:
        this.DisableMaxLevelPricetag();
    Label_0085:
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
        if (base.ability.GetLevel() == 3)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Elemental", base.ability.GetLevel());
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
        base.ability = base.menu.GetCurrentSelect().GetComponent<ElementalAbility>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("elementalPriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (base.ability.GetLevel() < 1)
        {
            goto Label_00D9;
        }
        base.CheckAvailable("elementalPriceLevel");
        goto Label_00E4;
    Label_00D9:
        base.CheckAvailable("elementalPrice");
    Label_00E4:
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
        base.CheckAvailable("elementalPriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("elementalPrice");
    Label_0032:
        return;
    }
}

