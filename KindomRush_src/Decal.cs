using System;
using UnityEngine;

public class Decal : MonoBehaviour
{
    private float dt;
    public float time;

    public Decal()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        this.dt += Time.deltaTime;
        if (this.dt < this.time)
        {
            goto Label_002E;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_002E:
        return;
    }

    private void Start()
    {
        this.dt = 0f;
        return;
    }
}

