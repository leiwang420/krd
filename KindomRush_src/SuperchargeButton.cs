using System;
using UnityEngine;

public class SuperchargeButton : AbilityButton
{
    public SuperchargeButton()
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
        this.SetRanks("chargedBoltPriceLevel");
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().SetSpent(base.price);
        GameSoundManager.PlayArtilleryTeslaChargedBoltTaunt();
        base.HideTooltip();
        if (base.ability.GetLevel() == 2)
        {
            goto Label_0084;
        }
        this.ShowTooltip("Supercharge", base.ability.GetLevel());
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
        if (base.ability.GetLevel() == 2)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Supercharge", base.ability.GetLevel());
    Label_0069:
        return;
    }

    private void OnMouseExit()
    {
        base.DestroyGlow();
        base.HideTooltip();
        return;
    }

    protected override void SetRanks(string abilityName)
    {
        if (base.ability.GetLevel() != 1)
        {
            goto Label_00D1;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        if (base.available == null)
        {
            goto Label_007A;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_00CC;
    Label_007A:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_00CC:
        goto Label_0215;
    Label_00D1:
        if (base.ability.GetLevel() != 2)
        {
            goto Label_0150;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        base.sprite.RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        goto Label_0215;
    Label_0150:
        base.price = GameSettings.GetAbilityPrice(abilityName.Replace("Level", string.Empty));
        if (base.available == null)
        {
            goto Label_01C3;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_0215;
    Label_01C3:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_0215:
        base.ShowPrice();
        return;
    }

    private void Start()
    {
        base.effectBuy = base.transform.FindChild("EffectBuy").GetComponent<PackedSprite>();
        base.priceTag = base.transform.FindChild("Pricetag");
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        base.ability = base.menu.GetCurrentSelect().GetComponent<SuperchargeAbility>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("chargedBoltPriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (base.ability.GetLevel() < 1)
        {
            goto Label_00D9;
        }
        base.CheckAvailable("chargedBoltPriceLevel");
        goto Label_00E4;
    Label_00D9:
        base.CheckAvailable("chargedBoltPrice");
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
        base.CheckAvailable("chargedBoltPriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("chargedBoltPrice");
    Label_0032:
        return;
    }
}

