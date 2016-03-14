using System;
using UnityEngine;

public class MainMenuButtonConfirmQuit : MainMenuButtonConfirm
{
    public MainMenuButtonConfirmQuit()
    {
        base..ctor();
        return;
    }

    protected override void Action()
    {
        Application.Quit();
        return;
    }

    private void FixedUpdate()
    {
    }
}

