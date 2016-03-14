using System;
using UnityEngine;

public class UpgradeUndoButton : MonoBehaviour
{
    private PackedSprite sprite;
    private UpgradeScreen upgradeScreen;

    public UpgradeUndoButton()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.upgradeScreen = GameObject.Find("Upgrade Screen").GetComponent<UpgradeScreen>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }

    public void Disable()
    {
        base.collider.enabled = 0;
        this.sprite.SetColor(new Color(1f, 1f, 1f, 0.3f));
        return;
    }

    public void Enable()
    {
        base.collider.enabled = 1;
        this.sprite.SetColor(new Color(1f, 1f, 1f, 1f));
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.upgradeScreen.UnDo();
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
        this.upgradeScreen = GameObject.Find("Upgrade Screen").GetComponent<UpgradeScreen>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

