using System;
using UnityEngine;

public class AchievementScreenButtonDone : MonoBehaviour
{
    private AchievementScreen achievementScreen;
    private Map map;
    private PackedSprite sprite;

    public AchievementScreenButtonDone()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("pressed");
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
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.achievementScreen.Hide();
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

