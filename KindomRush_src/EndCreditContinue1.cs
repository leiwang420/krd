using System;
using UnityEngine;

public class EndCreditContinue1 : MonoBehaviour
{
    public EndCreditContinue1()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        base.transform.parent.parent.GetComponent<EndGame>().HideComic();
        return;
    }

    private void Start()
    {
    }
}

