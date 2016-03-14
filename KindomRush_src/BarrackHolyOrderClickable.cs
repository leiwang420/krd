using System;
using UnityEngine;

public class BarrackHolyOrderClickable : BarrackAdvancedClickable
{
    public TowerButton healingButton;
    public TowerButton holyStrikeButton;
    public TowerButton shieldButton;

    public BarrackHolyOrderClickable()
    {
        base..ctor();
        return;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("HolyStrikeButton", &this.holyStrikeButton.localPos.x, &this.holyStrikeButton.localPos.y), this.MakeButton("HealingButton", &this.healingButton.localPos.x, &this.healingButton.localPos.y), this.MakeButton("ShieldButton", &this.shieldButton.localPos.x, &this.shieldButton.localPos.y), this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y) };
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "HolyStrikeButton") == null)
        {
            goto Label_0065;
        }
        button2 = UnityEngine.Object.Instantiate(this.holyStrikeButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("holyStrikePrice"));
        if (base.CanBuyAbility("holyStrikePrice") != null)
        {
            goto Label_019D;
        }
        button2.SetAvailable(0);
        goto Label_019D;
    Label_0065:
        if ((button == "SellButton") == null)
        {
            goto Label_009E;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_009E:
        if ((button == "HealingButton") == null)
        {
            goto Label_0101;
        }
        button2 = UnityEngine.Object.Instantiate(this.healingButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("healingPrice"));
        if (base.CanBuyAbility("healingPrice") != null)
        {
            goto Label_019D;
        }
        button2.SetAvailable(0);
        goto Label_019D;
    Label_0101:
        if ((button == "ShieldButton") == null)
        {
            goto Label_0164;
        }
        button2 = UnityEngine.Object.Instantiate(this.shieldButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("shieldPrice"));
        if (base.CanBuyAbility("shieldPrice") != null)
        {
            goto Label_019D;
        }
        button2.SetAvailable(0);
        goto Label_019D;
    Label_0164:
        if ((button == "RespawnButton") == null)
        {
            goto Label_019D;
        }
        button2 = UnityEngine.Object.Instantiate(base.respawnButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_019D:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    private void Start()
    {
        base.isSelected = 0;
        base.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.selectedTower = base.GetComponent<TowerBase>();
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

