using ManagedSteam;
using ManagedSteam.CallbackStructures;
using ManagedSteam.Exceptions;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Steamworks : MonoBehaviour
{
    [CompilerGenerated]
    private static Steam <SteamInterface>k__BackingField;
    private static Steamworks activeInstance;
    private string status;

    public Steamworks()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        bool flag;
        AlreadyLoadedException exception;
        SteamInitializeFailedException exception2;
        SteamInterfaceInitializeFailedException exception3;
        DllNotFoundException exception4;
        if (SteamInterface != null)
        {
            goto Label_015F;
        }
        flag = 0;
    Label_000C:
        try
        {
            SteamInterface = Steam.Initialize();
            goto Label_00C9;
        }
        catch (AlreadyLoadedException exception1)
        {
        Label_001B:
            exception = exception1;
            this.status = "The native dll is already loaded, this should not happen if ReleaseManagedResources is used and Steam.Initialize() is only called once.";
            Debug.LogError(this.status, this);
            Debug.LogError(exception.Message, this);
            flag = 1;
            goto Label_00C9;
        }
        catch (SteamInitializeFailedException exception5)
        {
        Label_0046:
            exception2 = exception5;
            this.status = "Could not initialize the native Steamworks API.";
            Debug.LogError(this.status, this);
            Debug.LogError(exception2.Message, this);
            flag = 1;
            goto Label_00C9;
        }
        catch (SteamInterfaceInitializeFailedException exception6)
        {
        Label_0071:
            exception3 = exception6;
            this.status = "Could not initialize the wanted versions of the Steamworks API. Make sure that you have the correct Steamworks SDK version. See the documentation for more info.";
            Debug.LogError(this.status, this);
            Debug.LogError(exception3.Message, this);
            flag = 1;
            goto Label_00C9;
        }
        catch (DllNotFoundException exception7)
        {
        Label_009C:
            exception4 = exception7;
            this.status = "Could not load a dll file. Make sure that the steam_api.dll/libsteam_api.dylib file is placed at the correct location. See the documentation for more info.";
            Debug.LogError(this.status, this);
            Debug.LogError(exception4.Message, this);
            flag = 1;
            goto Label_00C9;
        }
    Label_00C9:
        if (flag == null)
        {
            goto Label_00DF;
        }
        SteamInterface = null;
        Application.Quit();
        goto Label_015A;
    Label_00DF:
        this.status = "Steamworks initialized and ready to use.";
        if (SteamInterface.RestartAppIfNecessary(0x3c294) == null)
        {
            goto Label_010D;
        }
        Debug.Log("RestartAppIfNecesarry returned true, quitting application");
        Application.Quit();
    Label_010D:
        UnityEngine.Object.DontDestroyOnLoad(this);
        activeInstance = this;
        SteamInterface.ExceptionThrown += new Steam.ExceptionDelegate(this.ExceptionThrown);
        SteamInterface.Friends.GameOverlayActivated += new CallbackEvent<GameOverlayActivated>(this.OverlayToggle);
        SteamInterface.Stats.RequestCurrentStats();
    Label_015A:
        goto Label_0165;
    Label_015F:
        UnityEngine.Object.Destroy(this);
    Label_0165:
        return;
    }

    private void Cleanup()
    {
        if (SteamInterface == null)
        {
            goto Label_0033;
        }
        if (Application.isEditor == null)
        {
            goto Label_0023;
        }
        SteamInterface.ReleaseManagedResources();
        goto Label_002D;
    Label_0023:
        SteamInterface.Shutdown();
    Label_002D:
        SteamInterface = null;
    Label_0033:
        return;
    }

    private void ExceptionThrown(Exception e)
    {
        string[] textArray1;
        textArray1 = new string[] { e.GetType().Name, ": ", e.Message, "\n", e.StackTrace };
        Debug.LogError(string.Concat(textArray1));
        return;
    }

    private void OnApplicationQuit()
    {
        this.Cleanup();
        return;
    }

    private void OnDestroy()
    {
        if ((activeInstance == this) == null)
        {
            goto Label_001C;
        }
        activeInstance = null;
        this.Cleanup();
    Label_001C:
        return;
    }

    private unsafe void OverlayToggle(GameOverlayActivated value)
    {
        GameObject obj2;
        StageBase base2;
        StageBase.states states;
        if (&value.Active == null)
        {
            goto Label_0067;
        }
        Debug.Log("Overlay shown");
        obj2 = GameObject.Find("Stage");
        if ((obj2 != null) == null)
        {
            goto Label_0071;
        }
        base2 = obj2.GetComponent<StageBase>();
        if ((base2 != null) == null)
        {
            goto Label_0071;
        }
        states = base2.GetStatus();
        if (states == 3)
        {
            goto Label_0071;
        }
        if (states == 2)
        {
            goto Label_0071;
        }
        if (states == 4)
        {
            goto Label_0071;
        }
        base2.EscapePause();
        goto Label_0071;
    Label_0067:
        Debug.Log("Overlay closed");
    Label_0071:
        return;
    }

    public void SetAchievement(string id)
    {
        if (SteamInterface == null)
        {
            goto Label_003F;
        }
        SteamInterface.Stats.SetAchievement(id);
        if (SteamInterface.Stats.StoreStats() != null)
        {
            goto Label_003F;
        }
        Debug.Log("Error on StoreStats() for achievement: " + id);
    Label_003F:
        return;
    }

    private void Update()
    {
        if (SteamInterface == null)
        {
            goto Label_0014;
        }
        SteamInterface.Update();
    Label_0014:
        return;
    }

    public static Steam SteamInterface
    {
        [CompilerGenerated]
        get
        {
            return <SteamInterface>k__BackingField;
        }
        [CompilerGenerated]
        private set
        {
            <SteamInterface>k__BackingField = value;
            return;
        }
    }
}

