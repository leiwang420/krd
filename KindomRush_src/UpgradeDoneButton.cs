using System;
using UnityEngine;

public class UpgradeDoneButton : MonoBehaviour
{
    private Map map;
    private PackedSprite sprite;
    private UpgradeScreen upgradeScreen;

    public UpgradeDoneButton()
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
        this.upgradeScreen.Hide();
        GameSoundManager.PlayGUIButtonCommon();
        GameData.SaveGameData();
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
        this.upgradeScreen = GameObject.Find("Upgrade Screen").GetComponent<UpgradeScreen>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

