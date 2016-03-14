using System;
using UnityEngine;

public class Fredo : MonoBehaviour
{
    private int clicks;
    private PackedSprite sprite;

    public Fredo()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.clicks += 1;
        if (this.clicks != 8)
        {
            goto Label_0040;
        }
        this.sprite.PlayAnim("fall");
        GameAchievements.FreeFredoFunc();
        base.collider.enabled = 0;
        goto Label_0050;
    Label_0040:
        this.sprite.PlayAnim("touch");
    Label_0050:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

