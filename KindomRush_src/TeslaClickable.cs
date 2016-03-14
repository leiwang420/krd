using System;
using UnityEngine;

public class TeslaClickable : TowerBasicClickable
{
    public TowerButton overchargeButton;
    public TowerButton superchargeButton;

    public TeslaClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        base.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        return;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("SuperchargeButton", &this.superchargeButton.localPos.x, &this.superchargeButton.localPos.y), this.MakeButton("OverchargeButton", &this.overchargeButton.localPos.x, &this.overchargeButton.localPos.y) };
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "OverchargeButton") == null)
        {
            goto Label_0065;
        }
        button2 = UnityEngine.Object.Instantiate(this.overchargeButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("overchargePrice"));
        if (base.CanBuyAbility("overchargePrice") != null)
        {
            goto Label_00FC;
        }
        button2.SetAvailable(0);
        goto Label_00FC;
    Label_0065:
        if ((button == "SellButton") == null)
        {
            goto Label_009E;
        }
        button2 = UnityEngine.Object.Instantiate(base.sellButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_009E:
        if ((button == "SuperchargeButton") == null)
        {
            goto Label_00FC;
        }
        button2 = UnityEngine.Object.Instantiate(this.superchargeButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("superchargePrice"));
        if (base.CanBuyAbility("superchargePrice") != null)
        {
            goto Label_00FC;
        }
        button2.SetAvailable(0);
    Label_00FC:
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

