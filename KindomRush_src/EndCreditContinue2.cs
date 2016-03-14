using System;
using UnityEngine;

public class EndCreditContinue2 : MonoBehaviour
{
    public EndCreditContinue2()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        base.transform.parent.parent.GetComponent<EndGame>().ToMap();
        return;
    }

    private void Start()
    {
    }
}

