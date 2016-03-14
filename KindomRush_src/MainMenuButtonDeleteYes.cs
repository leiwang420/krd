using System;

public class MainMenuButtonDeleteYes : MainMenuButtonConfirm
{
    private MainMenuDialogDeleteSlot dialogDelete;

    public MainMenuButtonDeleteYes()
    {
        base..ctor();
        return;
    }

    protected override void Action()
    {
        base.transform.parent.GetComponent<MainMenuDialogDeleteSlot>().DeleteSlot();
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

