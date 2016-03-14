using System;

public class RallyButton : TowerButton
{
    public RallyButton()
    {
        base..ctor();
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        BarrackTower tower;
        tower = base.menu.GetCurrentSelect().GetComponent<BarrackTower>();
        base.menu.Hide();
        if ((tower != null) == null)
        {
            goto Label_0034;
        }
        tower.SelectSoldiers();
        tower.Rally();
    Label_0034:
        base.DestroyGlow();
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

