using System;

public class MainMenuButtonDeleteNo : MainMenuButtonConfirm
{
    private MainMenuDialogDeleteSlot dialogDelete;

    public MainMenuButtonDeleteNo()
    {
        base..ctor();
        return;
    }

    protected override void Action()
    {
        this.dialogDelete.Hide();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        base.sprite = base.GetComponent<PackedSprite>();
        this.dialogDelete = base.transform.parent.GetComponent<MainMenuDialogDeleteSlot>();
        return;
    }
}

