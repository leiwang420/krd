using System;
using UnityEngine;

public class BFGClickable : TowerBasicClickable
{
    public TowerButton clusterButton;
    public TowerButton missileButton;

    public BFGClickable()
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
        return new TowerButton[] { this.MakeButton("SellButton", &base.sellButton.localPos.x, &base.sellButton.localPos.y), this.MakeButton("MissileButton", &this.missileButton.localPos.x, &this.missileButton.localPos.y), this.MakeButton("ClusterButton", &this.clusterButton.localPos.x, &this.clusterButton.localPos.y) };
    }

    protected TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "MissileButton") == null)
        {
            goto Label_0065;
        }
        button2 = UnityEngine.Object.Instantiate(this.missileButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("missilePrice"));
        if (base.CanBuyAbility("missilePrice") != null)
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
        if ((button == "ClusterButton") == null)
        {
            goto Label_00FC;
        }
        button2 = UnityEngine.Object.Instantiate(this.clusterButton, base.transform.position, base.transform.rotation) as AbilityButton;
        button2.SetPrice(GameSettings.GetAbilityPrice("clusterPrice"));
        if (base.CanBuyAbility("clusterPrice") != null)
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

    protected override unsafe void ShowMenu()
    {
        Vector3 vector;
        Vector3 vector2;
        base.menu.Show(this, this.CreateButtons());
        base.menu.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y - 31f, -900f);
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

