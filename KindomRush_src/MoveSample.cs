using System;
using UnityEngine;

public class MoveSample : MonoBehaviour
{
    public MoveSample()
    {
        base..ctor();
        return;
    }

    private void Start()
    {
        object[] objArray1;
        objArray1 = new object[] { "x", (int) 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", (double) 0.1 };
        iTween.MoveBy(base.gameObject, iTween.Hash(objArray1));
        return;
    }
}

