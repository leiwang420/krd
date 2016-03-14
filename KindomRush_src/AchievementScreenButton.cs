using System;
using UnityEngine;

public class AchievementScreenButton : MonoBehaviour
{
    private AchievementScreen achievementScreen;
    private Map map;
    private PackedSprite sprite;

    public AchievementScreenButton()
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
        this.achievementScreen.Show();
        GameSoundManager.PlayGUIButtonCommon();
        return;
    }

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.achievementScreen = GameObject.Find("Achievement Screen").GetComponent<AchievementScreen>();
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

