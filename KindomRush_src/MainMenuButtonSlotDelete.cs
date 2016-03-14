using System;
using UnityEngine;

public class MainMenuButtonSlotDelete : MonoBehaviour
{
    private MainMenuDialogDeleteSlot dialogDelete;
    private PackedSprite overlay;
    private PackedSprite sprite;

    public MainMenuButtonSlotDelete()
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
        int num;
        this.sprite.RevertToStatic();
        GameSoundManager.PlayGUIButtonCommon();
        this.dialogDelete.Show();
        num = base.transform.parent.GetComponent<MainMenuButtonSlot>().SlotNumber;
        this.dialogDelete.SetSlot(num);
        this.overlay.Hide(0);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.dialogDelete = GameObject.Find("DialogDelete").GetComponent<MainMenuDialogDeleteSlot>();
        this.overlay = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        return;
    }
}

