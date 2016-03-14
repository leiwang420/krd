using System;
using UnityEngine;

public class TutorialButtonClose : MonoBehaviour
{
    private PackedSprite sprite;
    private StageBase stage;
    private TutorialScreen tutorialScreen;

    public TutorialButtonClose()
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
        this.sprite.RevertToStatic();
        this.tutorialScreen.Close();
        GameSoundManager.PlayGUINotificationClose();
        return;
    }

    private void Start()
    {
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        return;
    }
}

