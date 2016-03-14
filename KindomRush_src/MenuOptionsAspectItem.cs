using System;
using UnityEngine;

public class MenuOptionsAspectItem : MonoBehaviour
{
    private MenuOptions menu;
    public GameData.aspectRatioEnum ratio;
    private PackedSprite sprite;

    public MenuOptionsAspectItem()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.menu.SetAspect(this.ratio);
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
        this.menu = base.transform.parent.parent.GetComponent<MenuOptions>();
        return;
    }
}

