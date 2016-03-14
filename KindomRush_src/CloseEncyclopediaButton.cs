using System;
using UnityEngine;

public class CloseEncyclopediaButton : MonoBehaviour
{
    private EncyclopediaScreen encyclopedia;
    private PackedSprite sprite;

    public CloseEncyclopediaButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
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

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.encyclopedia = base.transform.parent.GetComponent<EncyclopediaScreen>();
        return;
    }
}

