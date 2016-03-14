using ManagedSteam;
using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private bool bGamepadTextInputDismissed;

    public Utils()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void GamepadTextInputDismissedFunc(GamepadTextInputDismissed value)
    {
        this.bGamepadTextInputDismissed = 1;
        return;
    }

    public unsafe string GetGamepadTextInput()
    {
        IUtils utils;
        UtilsGetEnteredGamepadTextInputResult result;
        utils = Steamworks.SteamInterface.Utils;
        this.bGamepadTextInputDismissed = 0;
        if (utils.ShowGamepadTextInput(0, 0, "Example text input", 0x40) == null)
        {
            goto Label_0036;
        }
    Label_002B:
        if (this.bGamepadTextInputDismissed == null)
        {
            goto Label_002B;
        }
    Label_0036:
        return &utils.GetEnteredGamepadTextInput().Text;
    }

    public unsafe Texture2D GetTextureFromSteamID(SteamID steamId)
    {
        IFriends friends;
        IUtils utils;
        ImageHandle handle;
        uint num;
        uint num2;
        Texture2D textured;
        Color32[] colorArray;
        GCHandle handle2;
        IntPtr ptr;
        int num3;
        int num4;
        Color32 color;
        friends = Steamworks.SteamInterface.Friends;
        utils = Steamworks.SteamInterface.Utils;
        handle = friends.GetLargeFriendAvatar(steamId);
        if (&handle.IsValid == null)
        {
            goto Label_0139;
        }
        if (utils.GetImageSize(handle, &num, &num2) == null)
        {
            goto Label_0139;
        }
        textured = new Texture2D(num, num2, 4, 1);
        colorArray = new Color32[(IntPtr) (num * num2)];
        handle2 = GCHandle.Alloc(colorArray, 3);
    Label_005C:
        try
        {
            ptr = Marshal.UnsafeAddrOfPinnedArrayElement(colorArray, 0);
            if (utils.GetImageRGBA(handle, ptr, (num * num2) * 4) == null)
            {
                goto Label_0129;
            }
            num3 = 0;
            goto Label_010F;
        Label_0082:
            num4 = 0;
            goto Label_00FC;
        Label_008A:
            color = *(&(colorArray[(IntPtr) (((long) num3) + (((ulong) num) * ((long) num4)))]));
            *(&(colorArray[(IntPtr) (((long) num3) + (((ulong) num) * ((long) num4)))])) = *(&(colorArray[(IntPtr) (((long) num3) + (((ulong) num) * (((ulong) (num2 - 1)) - ((long) num4))))]));
            *(&(colorArray[(IntPtr) (((long) num3) + (((ulong) num) * (((ulong) (num2 - 1)) - ((long) num4))))])) = color;
            num4 += 1;
        Label_00FC:
            if (((long) num4) < ((ulong) (num2 / 2)))
            {
                goto Label_008A;
            }
            num3 += 1;
        Label_010F:
            if (((long) num3) < ((ulong) num))
            {
                goto Label_0082;
            }
            textured.SetPixels32(colorArray);
            textured.Apply();
        Label_0129:
            goto Label_0136;
        }
        finally
        {
        Label_012E:
            &handle2.Free();
        }
    Label_0136:
        return textured;
    Label_0139:
        return null;
    }

    private void LowBatteryPowerFunc(LowBatteryPower value)
    {
    }

    private void Start()
    {
        IUtils utils;
        if (Steamworks.SteamInterface != null)
        {
            goto Label_0015;
        }
        Debug.LogError("SteamInterface startup failed!");
        return;
    Label_0015:
        utils = Steamworks.SteamInterface.Utils;
        utils.LowBatteryPower += new CallbackEvent<LowBatteryPower>(this.LowBatteryPowerFunc);
        utils.SteamShutdown += new CallbackEvent<SteamShutdown>(this.SteamShutdownFunc);
        utils.GamepadTextInputDismissed += new CallbackEvent<GamepadTextInputDismissed>(this.GamepadTextInputDismissedFunc);
        return;
    }

    private void SteamShutdownFunc(SteamShutdown value)
    {
        Application.Quit();
        return;
    }
}

