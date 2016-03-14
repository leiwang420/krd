using System;
using UnityEngine;

public class TutorialButtonNext : MonoBehaviour
{
    private PackedSprite sprite;
    private TutorialScreen tutorialScreen;

    public TutorialButtonNext()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.tutorialScreen = base.transform.parent.GetComponent<TutorialScreen>();
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
        GameSoundManager.PlayGUINotificationPaperOver();
        this.sprite.RevertToStatic();
        this.tutorialScreen.ShowNextPage();
        return;
    }
}

