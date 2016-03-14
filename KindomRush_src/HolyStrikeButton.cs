using System;
using UnityEngine;

public class HolyStrikeButton : AbilityButton
{
    private BarrackHolyOrderTower tower;

    public HolyStrikeButton()
    {
        base..ctor();
        return;
    }

    protected override void DisableMaxLevelPricetag()
    {
        if (this.tower.GetHolyStrikeLevel() != 3)
        {
            goto Label_0022;
        }
        base.priceTag.gameObject.SetActive(0);
    Label_0022:
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        if (base.available == null)
        {
            goto Label_007F;
        }
        if (this.tower.HolyStrikeLevelUp() == null)
        {
            goto Label_007F;
        }
        base.PlayEffectBuy();
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().SetSpent(base.price);
        this.SetRanks("holyStrikePriceLevel");
        GameSoundManager.PlayBarrackPaladinHolyStrikeTaunt();
        base.HideTooltip();
        if (this.tower.GetHolyStrikeLevel() == 3)
        {
            goto Label_0079;
        }
        this.ShowTooltip("Holy Strike", this.tower.GetHolyStrikeLevel());
    Label_0079:
        this.DisableMaxLevelPricetag();
    Label_007F:
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
        if (this.tower.GetHolyStrikeLevel() == 3)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Holy Strike", this.tower.GetHolyStrikeLevel());
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
        int num;
        num = this.tower.GetHolyStrikeLevel();
        if (num != 1)
        {
            goto Label_0120;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        if (base.available == null)
        {
            goto Label_00A0;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_011B;
    Label_00A0:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_011B:
        goto Label_03DE;
    Label_0120:
        if (num != 2)
        {
            goto Label_0239;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        if (base.available == null)
        {
            goto Label_01B9;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_0234;
    Label_01B9:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_0234:
        goto Label_03DE;
    Label_0239:
        if (num != 3)
        {
            goto Label_02D7;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        base.sprite.RevertToStatic();
        goto Label_03DE;
    Label_02D7:
        base.price = GameSettings.GetAbilityPrice("holyStrikePrice");
        if (base.available == null)
        {
            goto Label_0363;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_03DE;
    Label_0363:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_03DE:
        base.ShowPrice();
        return;
    }

    private void Start()
    {
        base.effectBuy = base.transform.FindChild("EffectBuy").GetComponent<PackedSprite>();
        base.priceTag = base.transform.FindChild("Pricetag");
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        this.tower = base.menu.GetCurrentSelect().GetComponent<BarrackHolyOrderTower>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.SetRanks("holyStrikePriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (this.tower.GetHolyStrikeLevel() < 1)
        {
            goto Label_00D9;
        }
        base.CheckAvailable("holyStrikePriceLevel");
        goto Label_00E4;
    Label_00D9:
        base.CheckAvailable("holyStrikePrice");
    Label_00E4:
        this.DisableMaxLevelPricetag();
        return;
    }

    private void Update()
    {
        base.Update();
        if (this.tower.GetHolyStrikeLevel() < 1)
        {
            goto Label_0027;
        }
        base.CheckAvailable("holyStrikePriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("holyStrikePrice");
    Label_0032:
        return;
    }
}

