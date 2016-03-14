using System;

public class MainMenuButtonOptions : MainMenuButtonBase
{
    public MainMenuButtonOptions()
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
        base.menu.ShowMenuOptions();
        return;
    }
}

