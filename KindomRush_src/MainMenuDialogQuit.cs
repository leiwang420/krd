using System;
using UnityEngine;

public class MainMenuDialogQuit : MonoBehaviour
{
    private GameObject buttonCredits;
    private GameObject buttonOptions;
    private GameObject buttonStart;
    private MainMenuOptions options;
    private PackedSprite overlay;
    private MainMenuSlotsBackground slots;

    public MainMenuDialogQuit()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        this.buttonStart.gameObject.layer = 0;
        this.buttonOptions.gameObject.layer = 0;
        this.buttonCredits.gameObject.layer = 0;
        base.transform.position = new Vector3(0f, 1600f, -900f);
        this.overlay.Hide(1);
        return;
    }

    public void Show()
    {
        object[] objArray1;
        this.buttonStart.gameObject.layer = 2;
        this.buttonOptions.gameObject.layer = 2;
        this.buttonCredits.gameObject.layer = 2;
        this.slots.Hide();
        this.options.Hide();
        base.transform.position = new Vector3(0f, 90f, -910f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 40f, -910f), "time", (double) 0.25, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.overlay = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        this.slots = GameObject.Find("ButtonBackground").transform.FindChild("SlotsBackground").GetComponent<MainMenuSlotsBackground>();
        this.options = GameObject.Find("ButtonBackground").transform.FindChild("OptionsBackground").GetComponent<MainMenuOptions>();
        this.buttonStart = GameObject.Find("ButtonStart");
        this.buttonOptions = GameObject.Find("ButtonOptions");
        this.buttonCredits = GameObject.Find("ButtonCredits");
        return;
    }
}

