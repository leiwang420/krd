using System;
using UnityEngine;

public class MainMenuSlotsBackground : MonoBehaviour
{
    public MainMenuSlotsBackground()
    {
        base..ctor();
        return;
    }

    private void AfterHide()
    {
        base.gameObject.SetActive(0);
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-552f, -330f, 0f), "time", (float) 0.2f, "onComplete", "AfterHide" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    public unsafe void RefreshSlot(int num)
    {
        Transform transform;
        Transform transform2;
        MainMenuButtonNewGame game;
        base.transform.FindChild("Slot" + &num.ToString()).gameObject.SetActive(0);
        transform2 = base.transform.FindChild("NewGame" + &num.ToString());
        transform2.gameObject.SetActive(1);
        transform2.gameObject.AddComponent<MainMenuButtonNewGame>().SlotNumber = num;
        return;
    }

    private unsafe void SetupSlots()
    {
        int num;
        MainMenuButtonSlot slot;
        MainMenuButtonNewGame game;
        num = 1;
        goto Label_0095;
    Label_0007:
        if (GameData.IsSlotUsed(num) == null)
        {
            goto Label_0057;
        }
        slot = base.transform.FindChild("Slot" + &num.ToString()).gameObject.AddComponent<MainMenuButtonSlot>();
        slot.gameObject.SetActive(1);
        slot.SlotNumber = num;
        slot.LoadInfo();
        goto Label_0091;
    Label_0057:
        game = base.transform.FindChild("NewGame" + &num.ToString()).gameObject.AddComponent<MainMenuButtonNewGame>();
        game.gameObject.SetActive(1);
        game.SlotNumber = num;
    Label_0091:
        num += 1;
    Label_0095:
        if (num < 4)
        {
            goto Label_0007;
        }
        return;
    }

    public void Show()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(-197f, -330f, 0f), "time", (float) 0.25f, "easetype", (iTween.EaseType) 7 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.SetupSlots();
        return;
    }
}

