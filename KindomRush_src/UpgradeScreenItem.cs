using System;
using UnityEngine;

public class UpgradeScreenItem : MonoBehaviour
{
    private PackedSprite boughtSprite;
    private int cost;
    private PackedSprite effectClickSprite;
    private PackedSprite hoverSprite;
    private UpgradePriceTag priceTag;
    private PackedSprite sprite;
    private Transform tooltip;
    private GameUpgrades.upgradeType type;
    private UpgradeScreen upgradeScreen;

    public UpgradeScreenItem()
    {
        base..ctor();
        return;
    }

    public void CheckStatus()
    {
        if (GameUpgrades.IsPreviousBought(this.type) == null)
        {
            goto Label_003B;
        }
        if (GameData.StarsToSpent < this.cost)
        {
            goto Label_003B;
        }
        this.sprite.RevertToStatic();
        this.priceTag.Show();
        goto Label_0056;
    Label_003B:
        this.sprite.PlayAnim("off");
        this.priceTag.Off();
    Label_0056:
        if (GameUpgrades.IsBought(this.type) == null)
        {
            goto Label_008D;
        }
        this.boughtSprite.Hide(0);
        this.sprite.RevertToStatic();
        this.priceTag.Hide();
        goto Label_0099;
    Label_008D:
        this.boughtSprite.Hide(1);
    Label_0099:
        return;
    }

    private void FixedUpdate()
    {
    }

    public void HideBorder()
    {
        this.hoverSprite.Hide(1);
        return;
    }

    public void Init(GameUpgrades.upgradeType t, int c)
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.boughtSprite = base.transform.FindChild("bought").GetComponent<PackedSprite>();
        this.hoverSprite = base.transform.FindChild("hover").GetComponent<PackedSprite>();
        this.priceTag = base.transform.FindChild("Pricetag").GetComponent<UpgradePriceTag>();
        this.tooltip = base.transform.FindChild("ToolTipHolder");
        this.effectClickSprite = base.transform.FindChild("EffectClick").GetComponent<PackedSprite>();
        this.type = t;
        this.cost = c;
        this.priceTag.SetCost(this.cost);
        this.CheckStatus();
        this.tooltip.gameObject.AddComponent<UpgradeScreenTooltip>();
        return;
    }

    private void OnMouseDown()
    {
        if (GameUpgrades.IsPreviousBought(this.type) == null)
        {
            goto Label_005F;
        }
        if (GameUpgrades.IsBought(this.type) != null)
        {
            goto Label_005F;
        }
        if (GameData.StarsToSpent < this.cost)
        {
            goto Label_005F;
        }
        this.effectClickSprite.PlayAnim(0);
        this.effectClickSprite.Hide(0);
        this.upgradeScreen.SetSelected(this);
        this.upgradeScreen.Buy();
    Label_005F:
        return;
    }

    private void OnMouseEnter()
    {
        this.tooltip.gameObject.SetActive(1);
        if (GameUpgrades.IsBought(this.type) != null)
        {
            goto Label_004D;
        }
        if (GameUpgrades.IsPreviousBought(this.type) == null)
        {
            goto Label_004D;
        }
        if (GameData.StarsToSpent < this.cost)
        {
            goto Label_004D;
        }
        this.hoverSprite.Hide(0);
    Label_004D:
        return;
    }

    private void OnMouseExit()
    {
        this.hoverSprite.Hide(1);
        this.tooltip.gameObject.SetActive(0);
        return;
    }

    public void ShowBorder()
    {
        this.hoverSprite.Hide(0);
        return;
    }

    private void Start()
    {
        BoxCollider collider;
        if ((this.sprite == null) == null)
        {
            goto Label_001D;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_001D:
        this.upgradeScreen = GameObject.Find("Upgrade Screen").GetComponent<UpgradeScreen>();
        collider = base.gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = 1;
        collider.size = new Vector3(55f, 60f, 0f);
        collider.center = Vector3.zero;
        return;
    }

    public int Cost
    {
        get
        {
            return this.cost;
        }
    }

    public GameUpgrades.upgradeType Type
    {
        get
        {
            return this.type;
        }
    }
}

