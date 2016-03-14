using System;
using UnityEngine;

public class MainMenuButtonQuit : MonoBehaviour
{
    private MainMenuDialogQuit dialogQuit;
    private PackedSprite overlay;
    private PackedSprite sprite;

    public MainMenuButtonQuit()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void OnMouseUp()
    {
        GameSoundManager.PlayGUIButtonCommon();
        this.sprite.RevertToStatic();
        this.dialogQuit.Show();
        this.overlay.Hide(0);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.dialogQuit = GameObject.Find("DialogQuit").GetComponent<MainMenuDialogQuit>();
        this.overlay = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        return;
    }
}

