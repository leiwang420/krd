using System;

public class MainMenuButtonStart : MainMenuButtonBase
{
    public MainMenuButtonStart()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        GameSoundManager.PlayGUIButtonCommon();
        base.menu.ShowMenuStart();
        return;
    }
}

