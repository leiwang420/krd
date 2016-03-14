using System;
using System.IO;
using UnityEngine;

public class MainMenuDialogDeleteSlot : MonoBehaviour
{
    private PackedSprite overlay;
    private int slot;
    private MainMenuSlotsBackground slotManager;

    public MainMenuDialogDeleteSlot()
    {
        base..ctor();
        return;
    }

    public unsafe void DeleteSlot()
    {
        File.Delete("slot" + &this.slot.ToString() + ".data");
        this.slotManager.RefreshSlot(this.slot);
        this.Hide();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        base.transform.position = new Vector3(0f, 1600f, -900f);
        this.overlay.Hide(1);
        return;
    }

    public void SetSlot(int i)
    {
        this.slot = i;
        return;
    }

    public void Show()
    {
        object[] objArray1;
        this.slotManager = GameObject.Find("SlotsBackground").GetComponent<MainMenuSlotsBackground>();
        base.transform.position = new Vector3(0f, 90f, -910f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 40f, -910f), "time", (double) 0.25, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.overlay = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        return;
    }
}

