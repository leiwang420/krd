using System;
using UnityEngine;

public class circle : MonoBehaviour
{
    private int counter;
    private bool first;
    private float fraction;
    private float timeCounter;
    private float totalTime;

    public circle()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.first != null)
        {
            goto Label_0022;
        }
        this.timeCounter += Time.deltaTime;
    Label_0022:
        return;
    }

    public void SetCutoff(float c)
    {
        if (c >= 0.01f)
        {
            goto Label_0012;
        }
        c = 0.01f;
    Label_0012:
        base.renderer.material.SetFloat("_Cutoff", c);
        return;
    }

    private void Start()
    {
        this.first = 1;
        this.totalTime = 10f;
        this.fraction = this.totalTime / 16f;
        this.fraction -= 0.1f;
        return;
    }
}

