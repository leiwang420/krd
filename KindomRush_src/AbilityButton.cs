using System;
using UnityEngine;

public abstract class AbilityButton : TowerButton
{
    protected AbilityBase ability;
    protected PackedSprite effectBuy;

    protected AbilityButton()
    {
        base..ctor();
        return;
    }

    protected void CheckAvailable(string abilityName)
    {
        if (base.available != null)
        {
            goto Label_008C;
        }
        if ((base.stage != null) == null)
        {
            goto Label_016A;
        }
        if (base.stage.GetGold() < GameSettings.GetAbilityPrice(abilityName))
        {
            goto Label_016A;
        }
        base.available = 1;
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        this.SetRanks(abilityName);
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
        goto Label_016A;
    Label_008C:
        if (base.stage.GetGold() >= GameSettings.GetAbilityPrice(abilityName))
        {
            goto Label_0106;
        }
        base.available = 0;
        base.sprite.PlayAnim("disabled");
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().PlayAnim("disabled");
        this.SetRanks(abilityName);
        base.priceText.gameObject.SetActive(0);
        base.priceOffText.gameObject.SetActive(1);
        goto Label_016A;
    Label_0106:
        if (base.stage.GetGold() < GameSettings.GetAbilityPrice(abilityName))
        {
            goto Label_016A;
        }
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        this.SetRanks(abilityName);
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
    Label_016A:
        return;
    }

    protected virtual void DisableMaxLevelPricetag()
    {
        if (this.ability.IsMaxLevel() == null)
        {
            goto Label_0021;
        }
        base.priceTag.gameObject.SetActive(0);
    Label_0021:
        return;
    }

    protected void PlayEffectBuy()
    {
        this.effectBuy.Hide(0);
        this.effectBuy.PlayAnim(0);
        return;
    }

    public override void SetAvailable(bool a)
    {
        Transform transform;
        PackedSprite sprite;
        base.available = a;
        if ((base.sprite == null) == null)
        {
            goto Label_0024;
        }
        base.sprite = base.GetComponent<PackedSprite>();
    Label_0024:
        if (base.available != null)
        {
            goto Label_007A;
        }
        base.sprite.PlayAnim("disabled");
        transform = base.transform.FindChild("Pricetag");
        if ((transform != null) == null)
        {
            goto Label_007A;
        }
        sprite = transform.GetComponent<PackedSprite>();
        if ((sprite != null) == null)
        {
            goto Label_007A;
        }
        sprite.PlayAnim("disabled");
    Label_007A:
        return;
    }

    protected virtual void SetRanks(string abilityName)
    {
        if (this.ability.GetLevel() != 1)
        {
            goto Label_011E;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        if (base.available == null)
        {
            goto Label_009E;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_0119;
    Label_009E:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_0119:
        goto Label_03FB;
    Label_011E:
        if (this.ability.GetLevel() != 2)
        {
            goto Label_0241;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        if (base.available == null)
        {
            goto Label_01C1;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_023C;
    Label_01C1:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOn");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_023C:
        goto Label_03FB;
    Label_0241:
        if (this.ability.GetLevel() != 3)
        {
            goto Label_02E9;
        }
        base.price = GameSettings.GetAbilityPrice(abilityName);
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        base.sprite.RevertToStatic();
        goto Label_03FB;
    Label_02E9:
        base.price = GameSettings.GetAbilityPrice(abilityName.Replace("Level", string.Empty));
        if (base.available == null)
        {
            goto Label_0380;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).RevertToStatic();
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).RevertToStatic();
        goto Label_03FB;
    Label_0380:
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank2").GetComponent("PackedSprite")).PlayAnim("disabledOff");
        ((PackedSprite) base.transform.Find("powerrank3").GetComponent("PackedSprite")).PlayAnim("disabledOff");
    Label_03FB:
        base.ShowPrice();
        return;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}

