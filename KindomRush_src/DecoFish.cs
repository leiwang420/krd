using System;
using UnityEngine;

public class DecoFish : MonoBehaviour
{
    private PackedSprite sprite;

    public DecoFish()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        if (this.sprite.IsHidden() != null)
        {
            goto Label_0015;
        }
        GameAchievements.CatchAFish();
    Label_0015:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

