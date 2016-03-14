using System;
using UnityEngine;

public class EncyclopediaTowerButton : MonoBehaviour
{
    private EncyclopediaScreen encyclopedia;
    private PackedSprite sprite;

    public EncyclopediaTowerButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.encyclopedia.ShowContainer("towers");
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    private void OnMouseExit()
    {
        if (this.encyclopedia.IsTowerContainerActive() != null)
        {
            goto Label_0020;
        }
        this.sprite.RevertToStatic();
        goto Label_0030;
    Label_0020:
        this.sprite.PlayAnim("off");
    Label_0030:
        return;
    }

    private void OnMouseOver()
    {
        if (this.encyclopedia.IsTowerContainerActive() != null)
        {
            goto Label_0020;
        }
        this.sprite.PlayAnim("over");
    Label_0020:
        return;
    }

    private void OnMouseUp()
    {
        this.sprite.PlayAnim("off");
        return;
    }

    private void Start()
    {
        this.encyclopedia = base.transform.parent.GetComponent<EncyclopediaScreen>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.sprite.PlayAnim("off");
        return;
    }
}

