using System;
using UnityEngine;

public class RotateSample : MonoBehaviour
{
    public RotateSample()
    {
        base..ctor();
        return;
    }

    private void Start()
    {
        object[] objArray1;
        objArray1 = new object[] { "x", (double) 0.25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", (double) 0.4 };
        iTween.RotateBy(base.gameObject, iTween.Hash(objArray1));
        return;
    }
}

