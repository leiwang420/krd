using ManagedSteam;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class User : MonoBehaviour
{
    [CompilerGenerated]
    private static string _Path_k__BackingField;
    private IUser user;

    public User()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private unsafe void Start()
    {
        UserGetUserDataFolder folder;
        if (Steamworks.SteamInterface != null)
        {
            goto Label_0015;
        }
        Debug.LogError("SteamInterface startup failed!");
        return;
    Label_0015:
        this.user = Steamworks.SteamInterface.User;
        Path = &this.user.GetUserDataFolder().Path;
        return;
    }

    public static string Path
    {
        [CompilerGenerated]
        get
        {
            return _Path_k__BackingField;
        }
        [CompilerGenerated]
        private set
        {
            _Path_k__BackingField = value;
            return;
        }
    }
}

