using ManagedSteam;
using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Stats()
    {
        base..ctor();
        return;
    }

    private void Start()
    {
        IStats stats;
        if (Steamworks.SteamInterface != null)
        {
            goto Label_0015;
        }
        Debug.LogError("SteamInterface startup failed!");
        return;
    Label_0015:
        stats = Steamworks.SteamInterface.Stats;
        stats.UserStatsReceived += new CallbackEvent<ManagedSteam.CallbackStructures.UserStatsReceived>(this.UserStatsReceived);
        stats.UserStatsStored += new CallbackEvent<ManagedSteam.CallbackStructures.UserStatsStored>(this.UserStatsStored);
        stats.RequestCurrentStats();
        return;
    }

    private unsafe void UserStatsReceived(ManagedSteam.CallbackStructures.UserStatsReceived value)
    {
        IStats stats;
        int num;
        float num2;
        AppID pid;
        AppID pid2;
        Debug.Log("value.GameID: " + &&value.GameID.ToString() + "; Steamworks.SteamInterface.AppID: " + &Steamworks.SteamInterface.AppID.ToString());
        Debug.Log("value.Result: " + ((Result) &value.Result));
        if ((&value.GameID == Steamworks.SteamInterface.AppID) == null)
        {
            goto Label_013C;
        }
        if (&value.Result == 1)
        {
            goto Label_0084;
        }
        Debug.LogError("Failed to download stats.");
        return;
    Label_0084:
        stats = Steamworks.SteamInterface.Stats;
        if (stats.GetStat("TestStatInt", &num) != null)
        {
            goto Label_00AB;
        }
        Debug.LogWarning("Failed to read TestStatInt");
    Label_00AB:
        if (stats.GetStat("TestStatFloat", &num2) != null)
        {
            goto Label_00C7;
        }
        Debug.LogWarning("Failed to read TestStatFloat");
    Label_00C7:
        Debug.Log("TestStatInt = " + &num.ToString());
        Debug.Log("TestStatFloat = " + &num2.ToString());
        num += 1;
        num2 += 0.5f;
        if (stats.SetStat("TestStatInt", num) != null)
        {
            goto Label_011A;
        }
        Debug.LogWarning("Failed to write TestStatInt");
    Label_011A:
        if (stats.SetStat("TestStatFloat", num2) != null)
        {
            goto Label_0135;
        }
        Debug.LogWarning("Failed to write TestStatFloat");
    Label_0135:
        stats.StoreStats();
    Label_013C:
        return;
    }

    private unsafe void UserStatsStored(ManagedSteam.CallbackStructures.UserStatsStored value)
    {
        if ((&value.GameID == Steamworks.SteamInterface.AppID) == null)
        {
            goto Label_0041;
        }
        if (&value.Result != 1)
        {
            goto Label_0037;
        }
        Debug.Log("Stats saved to the server successfully.");
        goto Label_0041;
    Label_0037:
        Debug.LogWarning("Failed to save stats to the server.");
    Label_0041:
        return;
    }
}

