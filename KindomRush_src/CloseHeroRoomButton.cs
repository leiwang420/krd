using System;
using UnityEngine;

public class CloseHeroRoomButton : MonoBehaviour
{
    private HeroRoom heroRoom;
    private Map map;
    private PackedSprite sprite;

    public CloseHeroRoomButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.heroRoom.Close();
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

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.heroRoom = base.transform.parent.GetComponent<HeroRoom>();
        return;
    }
}

