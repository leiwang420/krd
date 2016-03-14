using System;
using UnityEngine;

public class BarrackBarbarianClickable : BarrackAdvancedClickable
{
    public TowerButton doubleButton;
    public TowerButton throwingButton;
    public TowerButton twisterButton;

    public BarrackBarbarianClickable()
    {
        base..ctor();
        return;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("ThrowingButton", &this.throwingButton.localPos.x, &this.throwingButton.localPos.y), this.MakeButton("DoubleButton", &this.doubleButton.localPos.x, &this.doubleButton.localPos.y), this.MakeButton("TwisterButton", &this.twisterButton.localPos.x, &this.twisterButton.localPos.y), this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y) };
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "ThrowingButton") == null)
        {
            goto Label_0065;
        }
        button2 = UnityEngine.Object.Instantiate(this.throwingButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("throwingPrice"));
        if (base.CanBuyAbility("throwingPrice") != null)
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
        if ((button == "DoubleButton") == null)
        {
            goto Label_0101;
        }
        button2 = UnityEngine.Object.Instantiate(this.doubleButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("dualWeaponsPrice"));
        if (base.CanBuyAbility("dualWeaponsPrice") != null)
        {
            goto Label_019D;
        }
        button2.SetAvailable(0);
        goto Label_019D;
    Label_0101:
        if ((button == "TwisterButton") == null)
        {
            goto Label_0164;
        }
        button2 = UnityEngine.Object.Instantiate(this.twisterButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("twisterPrice"));
        if (base.CanBuyAbility("twisterPrice") != null)
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

