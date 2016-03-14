using System;
using UnityEngine;

public class SniperButton : AbilityButton
{
    private MusketeerTower tower;

    public SniperButton()
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
        this.SetRanks("sniperPriceLevel");
        GameSoundManager.PlayMusketeerSniperTaunt();
        base.HideTooltip();
        if (this.tower.GetSniperLevel() == 3)
        {
            goto Label_0084;
        }
        this.ShowTooltip("Sniper", this.tower.GetSniperLevel());
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
        if (this.tower.GetSniperLevel() == 3)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Sniper", this.tower.GetSniperLevel());
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
        base.priceTag = base.transform.FindChild("Pricetag");
        base.effectBuy = base.transform.FindChild("EffectBuy").GetComponent<PackedSprite>();
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        this.tower = base.menu.GetCurrentSelect().GetComponent<MusketeerTower>();
        base.ability = this.tower.GetComponent<SniperAbility>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("sniperPriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (base.ability.GetLevel() < 1)
        {
            goto Label_00EA;
        }
        base.CheckAvailable("sniperPriceLevel");
        goto Label_00F5;
    Label_00EA:
        base.CheckAvailable("sniperPrice");
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
        base.CheckAvailable("sniperPriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("sniperPrice");
    Label_0032:
        return;
    }
}

