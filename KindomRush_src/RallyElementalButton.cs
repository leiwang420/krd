using System;

public class RallyElementalButton : TowerButton
{
    public RallyElementalButton()
    {
        base..ctor();
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        SorcererTower tower;
        if (base.available == null)
        {
            goto Label_0045;
        }
        tower = base.menu.GetCurrentSelect().GetComponent<SorcererTower>();
        if ((tower != null) == null)
        {
            goto Label_0034;
        }
        tower.SelectElemental();
        tower.Rally();
    Label_0034:
        base.menu.Hide();
        base.DestroyGlow();
    Label_0045:
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        base.sprite = base.GetComponent<PackedSprite>();
        if (base.menu.GetCurrentSelect().GetComponent<SorcererTower>().HasElemental() == null)
        {
            goto Label_0059;
        }
        base.available = 1;
        this.SetAvailable(1);
        goto Label_0067;
    Label_0059:
        base.available = 0;
        this.SetAvailable(0);
    Label_0067:
        return;
    }

    private void Update()
    {
        Clickable clickable;
        base.Update();
        clickable = base.menu.GetCurrentSelect();
        if ((clickable != null) == null)
        {
            goto Label_0041;
        }
        if (clickable.GetComponent<SorcererTower>().HasElemental() == null)
        {
            goto Label_0041;
        }
        base.available = 1;
        this.SetAvailable(1);
        goto Label_004F;
    Label_0041:
        base.available = 0;
        this.SetAvailable(0);
    Label_004F:
        return;
    }
}

