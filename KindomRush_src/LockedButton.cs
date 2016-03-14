using System;

public class LockedButton : TowerButton
{
    public LockedButton()
    {
        base..ctor();
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        return;
    }

    private void Update()
    {
    }
}

