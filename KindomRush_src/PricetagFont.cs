using System;
using UnityEngine;

public class PricetagFont : MonoBehaviour
{
    public PricetagFont()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void SetPrice(int price)
    {
        ((TextMesh) base.GetComponent("TextMesh")).text = &price.ToString();
        return;
    }

    private void Start()
    {
        base.renderer.material.color = new Color(0.96f, 0.85f, 0.3f);
        return;
    }
}

