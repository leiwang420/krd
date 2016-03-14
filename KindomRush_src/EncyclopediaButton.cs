using System;
using UnityEngine;

public class EncyclopediaButton : MonoBehaviour
{
    private EncyclopediaScreen encyclopedia;
    private Map map;
    private PackedSprite sprite;

    public EncyclopediaButton()
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
        this.map.DisableMapButtons();
        this.map.ShowOverlay();
        this.encyclopedia.ShowScreen();
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.encyclopedia = GameObject.Find("Encyclopedia").GetComponent<EncyclopediaScreen>();
        return;
    }
}

