using System;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    protected bool isActive;
    protected PackedSprite sprite;

    public Barricade()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public bool IsActive()
    {
        return this.isActive;
    }

    public void Kill()
    {
        this.sprite.PlayAnim(0);
        this.isActive = 0;
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.isActive = 1;
        return;
    }
}

