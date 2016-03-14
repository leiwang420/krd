using System;
using UnityEngine;

public class ShieldButton : AbilityButton
{
    private BarrackHolyOrderTower tower;

    public ShieldButton()
    {
        base..ctor();
        return;
    }

    protected override void DisableMaxLevelPricetag()
    {
        if (this.tower.GetShieldLevel() != 1)
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
            goto Label_0075;
        }
        if (this.tower.ShieldLevelUp() == null)
        {
            goto Label_0075;
        }
        base.PlayEffectBuy();
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().SetSpent(base.price);
        this.SetRanks("shieldPrice");
        GameSoundManager.PlayBarrackPaladinShieldTaunt();
        base.HideTooltip();
        if (this.tower.GetShieldLevel() == 1)
        {
            goto Label_006F;
        }
        this.ShowTooltip("Shield", 0);
    Label_006F:
        this.DisableMaxLevelPricetag();
    Label_0075:
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
        if (this.tower.GetShieldLevel() == 1)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Shield", this.tower.GetShieldLevel());
    Label_0069:
        return;
    }

    private void OnMouseExit()
    {
        base.DestroyGlow();
        base.HideTooltip();
        return;
    }

    protected override void SetRanks(string ability)
    {
        int num;
        if (this.tower.GetShieldLevel() != 1)
        {
            goto Label_0047;
        }
        ((PackedSprite) base.transform.Find("powerrank1").GetComponent("PackedSprite")).PlayAnim("enabledOn");
        base.sprite.RevertToStatic();
    Label_0047:
        return;
    }

    private void Start()
    {
        base.effectBuy = base.transform.FindChild("EffectBuy").GetComponent<PackedSprite>();
        base.priceTag = base.transform.FindChild("Pricetag");
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        this.tower = base.menu.GetCurrentSelect().GetComponent<BarrackHolyOrderTower>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("ShieldLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        base.CheckAvailable("shieldPrice");
        this.DisableMaxLevelPricetag();
        return;
    }

    private void Update()
    {
        base.Update();
        base.CheckAvailable("shieldPrice");
        return;
    }
}

