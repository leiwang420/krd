using System;
using UnityEngine;

public class SasquatchClickable : TowerBasicClickable
{
    public TowerButton sasquashButton;

    public SasquatchClickable()
    {
        base..ctor();
        return;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        return new TowerButton[] { this.MakeButton("SasquashButton", &this.sasquashButton.localPos.x, &this.sasquashButton.localPos.y), this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y) };
    }

    protected override TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "SasquashButton") == null)
        {
            goto Label_003B;
        }
        button2 = UnityEngine.Object.Instantiate(this.sasquashButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_003B:
        if ((button == "RespawnButton") == null)
        {
            goto Label_0074;
        }
        button2 = UnityEngine.Object.Instantiate(base.respawnButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_0074:
        button2.SetPrice(GameSettings.GetTowerPrice(base.upgradeTower.name));
        if (this.CanBuyTower(button) != null)
        {
            goto Label_009D;
        }
        button2.SetAvailable(0);
    Label_009D:
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
        base.GetComponent<BarrackTower>().UnselectSoldiers();
        return;
    }

    protected override unsafe void OnClick()
    {
        Vector3 vector;
        Vector3 vector2;
        base.menu.Show(this, this.CreateButtons());
        base.menu.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y + 25f, -900f);
        base.isSelected = 1;
        return;
    }

    private void Start()
    {
        base.isSelected = 0;
        base.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

