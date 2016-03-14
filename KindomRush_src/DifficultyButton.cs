using System;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    private PackedSprite sprite;

    public DifficultyButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        MonoBehaviour.print("change difficulty");
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

