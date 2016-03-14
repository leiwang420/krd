using System;
using UnityEngine;

public class EncyclopediaContainerMain : MonoBehaviour
{
    private EncyclopediaScreen encyclopedia;

    public EncyclopediaContainerMain()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        this.encyclopedia = base.transform.parent.GetComponent<EncyclopediaScreen>();
        return;
    }
}

