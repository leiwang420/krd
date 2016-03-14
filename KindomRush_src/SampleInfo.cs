﻿using System;
using UnityEngine;

public class SampleInfo : MonoBehaviour
{
    public SampleInfo()
    {
        base..ctor();
        return;
    }

    private void OnGUI()
    {
        GUILayout.Label("iTween can spin, shake, punch, move, handle audio, fade color and transparency \nand much more with each task needing only one line of code.", new GUILayoutOption[0]);
        GUILayout.BeginHorizontal(new GUILayoutOption[0]);
        GUILayout.Label("iTween works with C#, JavaScript and Boo. For full documentation and examples visit:", new GUILayoutOption[0]);
        if (GUILayout.Button("http://itween.pixelplacement.com", new GUILayoutOption[0]) == null)
        {
            goto Label_004A;
        }
        Application.OpenURL("http://itween.pixelplacement.com");
    Label_004A:
        GUILayout.EndHorizontal();
        return;
    }
}

