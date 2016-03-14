using System;
using UnityEngine;

public class OverchargeButton : AbilityButton
{
    public OverchargeButton()
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
        this.SetRanks("overchargePriceLevel");
        GameSoundManager.PlayArtilleryTeslaOverchargeTaunt();
        base.HideTooltip();
        if (base.ability.GetLevel() == 3)
        {
            goto Label_0084;
        }
        this.ShowTooltip("Overcharge", base.ability.GetLevel());
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
        if (base.ability.GetLevel() == 3)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Overcharge", base.ability.GetLevel());
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
        base.ability = base.menu.GetCurrentSelect().GetComponent<OverchargeAbility>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("overchargePriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (base.ability.GetLevel() < 1)
        {
            goto Label_00D9;
        }
        base.CheckAvailable("overchargePriceLevel");
        goto Label_00E4;
    Label_00D9:
        base.CheckAvailable("overchargePrice");
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
        base.CheckAvailable("overchargePriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("overchargePrice");
    Label_0032:
        return;
    }
}

