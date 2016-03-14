using System;

public class RallySasquashButton : TowerButton
{
    public RallySasquashButton()
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
        if (base.available == null)
        {
            goto Label_0045;
        }
        tower = base.menu.GetCurrentSelect().GetComponent<BarrackTower>();
        if ((tower != null) == null)
        {
            goto Label_0034;
        }
        tower.SelectSoldiers();
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
        this.SetAvailable(base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsOpen());
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

