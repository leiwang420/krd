using System;
using UnityEngine;

public class EncyclopediaButtonClose : MonoBehaviour
{
    private EncyclopediaScreen encyclopedia;
    private Map map;
    private PackedSprite sprite;

    public EncyclopediaButtonClose()
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
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.encyclopedia.HideScreen();
        GameSoundManager.PlayGUIButtonCommon();
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
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.encyclopedia = base.transform.parent.GetComponent<EncyclopediaScreen>();
        this.map = GameObject.Find("Map").GetComponent<Map>();
        return;
    }
}

