using System;

public class MainMenuButtonConfirmClose : MainMenuButtonConfirm
{
    private MainMenuDialogQuit dialogQuit;

    public MainMenuButtonConfirmClose()
    {
        base..ctor();
        return;
    }

    protected override void Action()
    {
        this.dialogQuit.Hide();
        return;
    }

    private void Awake()
    {
        this.dialogQuit = base.transform.parent.GetComponent<MainMenuDialogQuit>();
        return;
    }

    private void FixedUpdate()
    {
    }
}

