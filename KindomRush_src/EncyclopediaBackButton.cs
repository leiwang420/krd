using System;
using UnityEngine;

public class EncyclopediaBackButton : MonoBehaviour
{
    private EncyclopediaScreen encyclopedia;
    private PackedSprite sprite;

    public EncyclopediaBackButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.encyclopedia.ShowContainer("main");
        this.sprite.RevertToStatic();
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void OnMouseOver()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.encyclopedia = GameObject.Find("Encyclopedia").GetComponent<EncyclopediaScreen>();
        return;
    }
}

