using System;
using UnityEngine;

public class AchievementScreenPageButton : MonoBehaviour
{
    private AchievementScreen achievementScreen;
    private int pageNumber;
    private PackedSprite sprite;
    private PackedSprite spriteNumber;

    public AchievementScreenPageButton()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.achievementScreen = base.transform.parent.parent.GetComponent<AchievementScreen>();
        this.spriteNumber = base.transform.FindChild("PageNumber").GetComponent<PackedSprite>();
        return;
    }

    public void Fade()
    {
        ParticleFadeOut @out;
        ParticleFadeOut out2;
        if ((base.GetComponent<ParticleFadeOut>() == null) == null)
        {
            goto Label_006B;
        }
        @out = base.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        out2 = this.spriteNumber.gameObject.AddComponent<ParticleFadeOut>();
        out2.fadeSpeed = 0.3f;
        out2.finalOpacity = 0f;
        out2.Fade();
        goto Label_0086;
    Label_006B:
        base.GetComponent<ParticleFadeOut>().Fade();
        this.spriteNumber.GetComponent<ParticleFadeOut>().Fade();
    Label_0086:
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseEnter()
    {
        if (this.achievementScreen.GetCurrentPageNumber() == this.pageNumber)
        {
            goto Label_0036;
        }
        this.sprite.PlayAnim("over");
        this.spriteNumber.PlayAnim("over");
    Label_0036:
        return;
    }

    private void OnMouseExit()
    {
        if (this.achievementScreen.GetCurrentPageNumber() == this.pageNumber)
        {
            goto Label_002C;
        }
        this.sprite.RevertToStatic();
        this.spriteNumber.RevertToStatic();
    Label_002C:
        return;
    }

    private void OnMouseUp()
    {
        if (this.achievementScreen.GetCurrentPageNumber() == this.pageNumber)
        {
            goto Label_004C;
        }
        this.sprite.PlayAnim("selected");
        this.spriteNumber.PlayAnim("selected");
        this.achievementScreen.SelectPage(this.pageNumber);
        GameSoundManager.PlayGUIButtonCommon();
    Label_004C:
        return;
    }

    public void Reset()
    {
        if (this.pageNumber != 1)
        {
            goto Label_0031;
        }
        this.sprite.PlayAnim("selected");
        this.spriteNumber.PlayAnim("selected");
        goto Label_0047;
    Label_0031:
        this.sprite.RevertToStatic();
        this.spriteNumber.RevertToStatic();
    Label_0047:
        this.ResetFade();
        return;
    }

    public void ResetFade()
    {
        if ((base.GetComponent<ParticleFadeOut>() == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        this.spriteNumber.GetComponent<ParticleFadeOut>().Reset();
        base.GetComponent<ParticleFadeOut>().Reset();
        return;
    }

    public void RevertToStatic()
    {
        this.sprite.RevertToStatic();
        this.spriteNumber.RevertToStatic();
        return;
    }

    public void SetPageNumber(int num)
    {
        this.pageNumber = num;
        return;
    }

    public void SetSelected()
    {
        this.sprite.PlayAnim("selected");
        this.spriteNumber.PlayAnim("selected");
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.achievementScreen = base.transform.parent.parent.GetComponent<AchievementScreen>();
        if (this.pageNumber != 1)
        {
            goto Label_0053;
        }
        this.sprite.PlayAnim("selected");
        this.spriteNumber.PlayAnim("selected");
    Label_0053:
        return;
    }
}

