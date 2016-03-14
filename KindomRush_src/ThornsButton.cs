using System;
using UnityEngine;

public class ThornsButton : AbilityButton
{
    private ArcherTower tower;

    public ThornsButton()
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
            goto Label_00AB;
        }
        if (base.available == null)
        {
            goto Label_00AB;
        }
        base.PlayEffectBuy();
        base.ability.LevelUp();
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().SetSpent(base.price);
        this.SetRanks("thornPriceLevel");
        if (base.ability.GetLevel() != 1)
        {
            goto Label_0073;
        }
        ((ThornsAbility) base.ability).SpawnDruid();
    Label_0073:
        GameSoundManager.PlayerRangerThornTaunt();
        base.HideTooltip();
        if (this.tower.GetThornsLevel() == 3)
        {
            goto Label_00A5;
        }
        this.ShowTooltip("Thorns", this.tower.GetThornsLevel());
    Label_00A5:
        this.DisableMaxLevelPricetag();
    Label_00AB:
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
        if (this.tower.GetThornsLevel() == 3)
        {
            goto Label_0069;
        }
        this.ShowTooltip("Thorns", this.tower.GetThornsLevel());
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
        base.ability = this.tower.GetComponent<ThornsAbility>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.SetRanks("thornPriceLevel");
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        if (base.ability.GetLevel() < 1)
        {
            goto Label_00EA;
        }
        base.CheckAvailable("thornPriceLevel");
        goto Label_00F5;
    Label_00EA:
        base.CheckAvailable("thornPrice");
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
        base.CheckAvailable("thornPriceLevel");
        goto Label_0032;
    Label_0027:
        base.CheckAvailable("thornPrice");
    Label_0032:
        return;
    }
}

