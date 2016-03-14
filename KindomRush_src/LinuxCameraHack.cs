using System;
using UnityEngine;

public class LinuxCameraHack : MonoBehaviour
{
    public LinuxCameraHack()
    {
        base..ctor();
        return;
    }

    private unsafe void Start()
    {
        Resolution resolution;
        Resolution resolution2;
        if (Screen.fullScreen == null)
        {
            goto Label_002E;
        }
        Screen.SetResolution(&Screen.currentResolution.width, &Screen.currentResolution.height, Screen.fullScreen);
    Label_002E:
        return;
    }

    private void Update()
    {
    }
}

