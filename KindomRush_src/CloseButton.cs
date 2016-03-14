using System;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    private PackedSprite sprite;
    private StageSelect stageSelect;

    public CloseButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.stageSelect.Hide();
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
        this.stageSelect = base.transform.parent.GetComponent<StageSelect>();
        return;
    }
}

