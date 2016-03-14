using System;
using UnityEngine;

public class SorcererClickable : TowerBasicClickable
{
    public TowerButton elementalButton;
    public TowerButton polymorphButton;

    public SorcererClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("PolymorphButton", &this.polymorphButton.localPos.x, &this.polymorphButton.localPos.y), this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y), this.MakeButton("ElementalButton", &this.elementalButton.localPos.x, &this.elementalButton.localPos.y) };
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "PolymorphButton") == null)
        {
            goto Label_0065;
        }
        button2 = UnityEngine.Object.Instantiate(this.polymorphButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("polymorphPrice"));
        if (base.CanBuyAbility("polymorphPrice") != null)
        {
            goto Label_013A;
        }
        button2.SetAvailable(0);
        goto Label_013A;
    Label_0065:
        if ((button == "SellButton") == null)
        {
            goto Label_009E;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_009E:
        if ((button == "ElementalButton") == null)
        {
            goto Label_0101;
        }
        button2 = UnityEngine.Object.Instantiate(this.elementalButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("elementalPrice"));
        if (base.CanBuyAbility("elementalPrice") != null)
        {
            goto Label_013A;
        }
        button2.SetAvailable(0);
        goto Label_013A;
    Label_0101:
        if ((button == "RespawnButton") == null)
        {
            goto Label_013A;
        }
        button2 = UnityEngine.Object.Instantiate(base.respawnButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_013A:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    protected override void MissClick()
    {
        if (base.menu.IsActive() != null)
        {
            goto Label_0016;
        }
        base.Unselect();
    Label_0016:
        base.isSelected = 0;
        return;
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

