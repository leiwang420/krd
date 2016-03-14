using System;
using UnityEngine;

public class ArcaneClickable : TowerBasicClickable
{
    public TowerButton deathRayButton;
    public TowerButton teleportButton;

    public ArcaneClickable()
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
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("DesintegrateButton", &this.deathRayButton.localPos.x, &this.deathRayButton.localPos.y), this.MakeButton("TeleportButton", &this.teleportButton.localPos.x, &this.teleportButton.localPos.y) };
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "TeleportButton") == null)
        {
            goto Label_0065;
        }
        button2 = UnityEngine.Object.Instantiate(this.teleportButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("teleportPrice"));
        if (base.CanBuyAbility("teleportPrice") != null)
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
        if ((button == "DesintegrateButton") == null)
        {
            goto Label_00FC;
        }
        button2 = UnityEngine.Object.Instantiate(this.deathRayButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("desintegratePrice"));
        if (base.CanBuyAbility("desintegratePrice") != null)
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

