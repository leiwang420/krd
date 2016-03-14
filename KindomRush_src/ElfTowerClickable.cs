using System;
using UnityEngine;

public class ElfTowerClickable : TowerBasicClickable
{
    public TowerButton elfButton;
    public TowerButton repairButton;
    private TowerBase tower;

    public ElfTowerClickable()
    {
        base..ctor();
        return;
    }

    protected override unsafe TowerButton[] CreateButtons()
    {
        TowerButton[] buttonArray;
        buttonArray = null;
        if (this.tower.IsActive() != null)
        {
            goto Label_004C;
        }
        buttonArray = new TowerButton[] { this.MakeButton("RepairButton", &this.repairButton.localPos.x, &this.repairButton.localPos.y) };
        goto Label_00AF;
    Label_004C:
        buttonArray = new TowerButton[] { this.MakeButton("RespawnButton", &base.respawnButton.localPos.x, &base.respawnButton.localPos.y), this.MakeButton("ElfButton", &this.elfButton.localPos.x, &this.elfButton.localPos.y) };
    Label_00AF:
        return buttonArray;
    }

    protected override TowerButton MakeButton(string button, float posX, float posY)
    {
        TowerButton button2;
        button2 = null;
        if ((button == "RepairButton") == null)
        {
            goto Label_003E;
        }
        button2 = UnityEngine.Object.Instantiate(this.repairButton, base.transform.position, base.transform.rotation) as TowerButton;
        goto Label_00AE;
    Label_003E:
        if ((button == "RespawnButton") == null)
        {
            goto Label_0077;
        }
        button2 = UnityEngine.Object.Instantiate(base.respawnButton, base.transform.position, base.transform.rotation) as TowerButton;
        return button2;
    Label_0077:
        if ((button == "ElfButton") == null)
        {
            goto Label_00AE;
        }
        button2 = UnityEngine.Object.Instantiate(this.elfButton, base.transform.position, base.transform.rotation) as TowerButton;
    Label_00AE:
        button2.SetPrice(100);
        if (base.stage.GetGold() >= 100)
        {
            goto Label_00CF;
        }
        button2.SetAvailable(0);
    Label_00CF:
        button2.localPos = new Vector2(posX, posY);
        return button2;
    }

    protected override void MissClick()
    {
        base.isSelected = 0;
        base.GetComponent<ElfTower>().UnselectSoldiers();
        this.tower.HideMouseOver();
        return;
    }

    protected override unsafe void OnClick()
    {
        Vector3 vector;
        Vector3 vector2;
        if (base.CheckButtonPriority() != null)
        {
            goto Label_00BE;
        }
        if (base.isSelected != null)
        {
            goto Label_0085;
        }
        base.menu.Show(this, this.CreateButtons());
        base.menu.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y + 10f, -900f);
        base.isSelected = 1;
        base.GetComponent<ElfTower>().SelectSoldiers();
        goto Label_00BE;
    Label_0085:
        base.menu.Hide();
        base.isSelected = 0;
        base.GetComponent<ElfTower>().UnselectSoldiers();
        this.tower.HideMouseOver();
        base.guiBottom.HideInfo(base.GetComponent<UnitClickable>());
    Label_00BE:
        return;
    }

    private void Start()
    {
        base.isSelected = 0;
        base.menu = GameObject.Find("Quickmenu").GetComponent("Quickmenu") as Quickmenu;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.tower = base.GetComponent<TowerBase>();
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

