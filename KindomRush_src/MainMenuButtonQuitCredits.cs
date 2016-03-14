using System;
using UnityEngine;

public class MainMenuButtonQuitCredits : MonoBehaviour
{
    private MainMenuCredits screenCredits;
    private PackedSprite sprite;

    public MainMenuButtonQuitCredits()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
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

    private void OnMouseUp()
    {
        this.sprite.RevertToStatic();
        this.screenCredits.Close();
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.screenCredits = base.transform.parent.GetComponent<MainMenuCredits>();
        return;
    }
}

