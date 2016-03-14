using System;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    private int currentPage;
    private PackedSprite sprite;
    private PackedSprite spriteButtonGotIt;
    private PackedSprite spriteButtonNext;
    private PackedSprite spriteButtonSkip;
    private PackedSprite spriteTitle;
    private StageBase stage;

    public TutorialScreen()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.stage = base.transform.parent.GetComponent<StageBase>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.spriteButtonGotIt = base.transform.FindChild("ButtonGotIt").GetComponent<PackedSprite>();
        this.spriteButtonNext = base.transform.FindChild("ButtonNext").GetComponent<PackedSprite>();
        this.spriteButtonSkip = base.transform.FindChild("ButtonSkip").GetComponent<PackedSprite>();
        this.spriteTitle = base.transform.FindChild("Title").GetComponent<PackedSprite>();
        this.currentPage = 0;
        this.ShowNextPage();
        return;
    }

    public void Close()
    {
        object[] objArray1;
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1a, "oncomplete", "KillMe" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void FixedUpdate()
    {
    }

    private void KillMe()
    {
        this.stage.UnPause(1);
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    public void PopIn()
    {
        object[] objArray1;
        GameSoundManager.PlayGUINotificationOpen();
        base.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1b };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    public void ShowNextPage()
    {
        this.currentPage += 1;
        if (this.currentPage != 1)
        {
            goto Label_009C;
        }
        this.spriteButtonGotIt.gameObject.SetActive(0);
        this.spriteTitle.transform.localPosition = new Vector3(0f, 267f, 1f);
        this.spriteButtonSkip.transform.localPosition = new Vector3(-131f, -250f, 1f);
        this.spriteButtonNext.transform.localPosition = new Vector3(131f, -250f, 1f);
        goto Label_01D6;
    Label_009C:
        if (this.currentPage != 2)
        {
            goto Label_0134;
        }
        this.sprite.PlayAnim("page2");
        this.sprite.PauseAnim();
        this.spriteTitle.transform.localPosition = new Vector3(0f, 231f, 1f);
        this.spriteButtonSkip.transform.localPosition = new Vector3(-131f, -217f, 1f);
        this.spriteButtonNext.transform.localPosition = new Vector3(131f, -217f, 1f);
        goto Label_01D6;
    Label_0134:
        if (this.currentPage != 3)
        {
            goto Label_01D6;
        }
        this.sprite.PlayAnim("page3");
        this.sprite.PauseAnim();
        this.spriteTitle.transform.localPosition = new Vector3(0f, 231f, 1f);
        this.spriteButtonSkip.gameObject.SetActive(0);
        this.spriteButtonNext.gameObject.SetActive(0);
        this.spriteButtonGotIt.gameObject.SetActive(1);
        this.spriteButtonGotIt.transform.localPosition = new Vector3(0f, -221f, 1f);
    Label_01D6:
        return;
    }

    private void Start()
    {
    }
}

