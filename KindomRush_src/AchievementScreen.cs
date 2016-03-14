using System;
using System.Collections;
using UnityEngine;

public class AchievementScreen : MonoBehaviour
{
    private PackedSprite buttonClose;
    private Transform containerPageButtons;
    private int currentPage;
    private Map map;
    private Transform page1;
    private Transform page2;
    private Transform page3;
    private Transform page4;
    private Transform page5;
    private Transform page6;
    private ArrayList pages;
    private Vector2 scrollViewVector;
    private PackedSprite sprite;

    public AchievementScreen()
    {
        this.scrollViewVector = Vector2.zero;
        base..ctor();
        return;
    }

    public void CleanUp()
    {
        Transform transform;
        IEnumerator enumerator;
        Transform transform2;
        IEnumerator enumerator2;
        Transform transform3;
        IEnumerator enumerator3;
        Transform transform4;
        IEnumerator enumerator4;
        Transform transform5;
        IEnumerator enumerator5;
        Transform transform6;
        IEnumerator enumerator6;
        Transform transform7;
        IEnumerator enumerator7;
        Transform transform8;
        IEnumerator enumerator8;
        IDisposable disposable;
        IDisposable disposable2;
        IDisposable disposable3;
        IDisposable disposable4;
        IDisposable disposable5;
        IDisposable disposable6;
        IDisposable disposable7;
        IDisposable disposable8;
        base.transform.position = new Vector3(0f, 1600f, -910f);
        enumerator = this.containerPageButtons.GetEnumerator();
    Label_002B:
        try
        {
            goto Label_0047;
        Label_0030:
            transform = (Transform) enumerator.Current;
            transform.GetComponent<AchievementScreenPageButton>().Reset();
        Label_0047:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0030;
            }
            goto Label_006C;
        }
        finally
        {
        Label_0057:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0064;
            }
        Label_0064:
            disposable.Dispose();
        }
    Label_006C:
        this.containerPageButtons.gameObject.SetActive(0);
        enumerator2 = this.page1.GetEnumerator();
    Label_0089:
        try
        {
            goto Label_00A5;
        Label_008E:
            transform2 = (Transform) enumerator2.Current;
            transform2.GetComponent<AchievementItem>().ResetFade();
        Label_00A5:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_008E;
            }
            goto Label_00CA;
        }
        finally
        {
        Label_00B5:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_00C2;
            }
        Label_00C2:
            disposable2.Dispose();
        }
    Label_00CA:
        enumerator3 = this.page2.GetEnumerator();
    Label_00D7:
        try
        {
            goto Label_00F6;
        Label_00DC:
            transform3 = (Transform) enumerator3.Current;
            transform3.GetComponent<AchievementItem>().ResetFade();
        Label_00F6:
            if (enumerator3.MoveNext() != null)
            {
                goto Label_00DC;
            }
            goto Label_011D;
        }
        finally
        {
        Label_0107:
            disposable3 = enumerator3 as IDisposable;
            if (disposable3 != null)
            {
                goto Label_0115;
            }
        Label_0115:
            disposable3.Dispose();
        }
    Label_011D:
        enumerator4 = this.page3.GetEnumerator();
    Label_012A:
        try
        {
            goto Label_0149;
        Label_012F:
            transform4 = (Transform) enumerator4.Current;
            transform4.GetComponent<AchievementItem>().ResetFade();
        Label_0149:
            if (enumerator4.MoveNext() != null)
            {
                goto Label_012F;
            }
            goto Label_0170;
        }
        finally
        {
        Label_015A:
            disposable4 = enumerator4 as IDisposable;
            if (disposable4 != null)
            {
                goto Label_0168;
            }
        Label_0168:
            disposable4.Dispose();
        }
    Label_0170:
        enumerator5 = this.page4.GetEnumerator();
    Label_017D:
        try
        {
            goto Label_019C;
        Label_0182:
            transform5 = (Transform) enumerator5.Current;
            transform5.GetComponent<AchievementItem>().ResetFade();
        Label_019C:
            if (enumerator5.MoveNext() != null)
            {
                goto Label_0182;
            }
            goto Label_01C3;
        }
        finally
        {
        Label_01AD:
            disposable5 = enumerator5 as IDisposable;
            if (disposable5 != null)
            {
                goto Label_01BB;
            }
        Label_01BB:
            disposable5.Dispose();
        }
    Label_01C3:
        enumerator6 = this.page5.GetEnumerator();
    Label_01D0:
        try
        {
            goto Label_01EF;
        Label_01D5:
            transform6 = (Transform) enumerator6.Current;
            transform6.GetComponent<AchievementItem>().ResetFade();
        Label_01EF:
            if (enumerator6.MoveNext() != null)
            {
                goto Label_01D5;
            }
            goto Label_0216;
        }
        finally
        {
        Label_0200:
            disposable6 = enumerator6 as IDisposable;
            if (disposable6 != null)
            {
                goto Label_020E;
            }
        Label_020E:
            disposable6.Dispose();
        }
    Label_0216:
        enumerator7 = this.page6.GetEnumerator();
    Label_0223:
        try
        {
            goto Label_0242;
        Label_0228:
            transform7 = (Transform) enumerator7.Current;
            transform7.GetComponent<AchievementItem>().ResetFade();
        Label_0242:
            if (enumerator7.MoveNext() != null)
            {
                goto Label_0228;
            }
            goto Label_0269;
        }
        finally
        {
        Label_0253:
            disposable7 = enumerator7 as IDisposable;
            if (disposable7 != null)
            {
                goto Label_0261;
            }
        Label_0261:
            disposable7.Dispose();
        }
    Label_0269:
        enumerator8 = this.containerPageButtons.GetEnumerator();
    Label_0276:
        try
        {
            goto Label_0295;
        Label_027B:
            transform8 = (Transform) enumerator8.Current;
            transform8.GetComponent<ParticleFadeOut>().Reset();
        Label_0295:
            if (enumerator8.MoveNext() != null)
            {
                goto Label_027B;
            }
            goto Label_02BC;
        }
        finally
        {
        Label_02A6:
            disposable8 = enumerator8 as IDisposable;
            if (disposable8 != null)
            {
                goto Label_02B4;
            }
        Label_02B4:
            disposable8.Dispose();
        }
    Label_02BC:
        base.GetComponent<ParticleFadeOut>().Reset();
        this.buttonClose.GetComponent<ParticleFadeOut>().Reset();
        this.page1.gameObject.SetActive(0);
        this.page2.gameObject.SetActive(0);
        this.page3.gameObject.SetActive(0);
        this.page4.gameObject.SetActive(0);
        this.page5.gameObject.SetActive(0);
        this.page6.gameObject.SetActive(0);
        return;
    }

    public int GetCurrentPageNumber()
    {
        return (this.currentPage + 1);
    }

    public void Hide()
    {
        object[] objArray1;
        Transform transform;
        Transform transform2;
        IEnumerator enumerator;
        ParticleFadeOut @out;
        Transform transform3;
        IEnumerator enumerator2;
        ParticleFadeOut out2;
        Transform transform4;
        IEnumerator enumerator3;
        IDisposable disposable;
        IDisposable disposable2;
        IDisposable disposable3;
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 80f, -910f), "time", (double) 0.2, "easetype", (iTween.EaseType) 7, "oncomplete", "CleanUp" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        transform = null;
        if (this.currentPage != null)
        {
            goto Label_008D;
        }
        transform = this.page1;
        goto Label_0100;
    Label_008D:
        if (this.currentPage != 1)
        {
            goto Label_00A5;
        }
        transform = this.page2;
        goto Label_0100;
    Label_00A5:
        if (this.currentPage != 2)
        {
            goto Label_00BD;
        }
        transform = this.page3;
        goto Label_0100;
    Label_00BD:
        if (this.currentPage != 3)
        {
            goto Label_00D5;
        }
        transform = this.page4;
        goto Label_0100;
    Label_00D5:
        if (this.currentPage != 4)
        {
            goto Label_00ED;
        }
        transform = this.page5;
        goto Label_0100;
    Label_00ED:
        if (this.currentPage != 5)
        {
            goto Label_0100;
        }
        transform = this.page6;
    Label_0100:
        enumerator = transform.GetEnumerator();
    Label_0107:
        try
        {
            goto Label_0123;
        Label_010C:
            transform2 = (Transform) enumerator.Current;
            transform2.GetComponent<AchievementItem>().Fade();
        Label_0123:
            if (enumerator.MoveNext() != null)
            {
                goto Label_010C;
            }
            goto Label_0148;
        }
        finally
        {
        Label_0133:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0140;
            }
        Label_0140:
            disposable.Dispose();
        }
    Label_0148:
        if ((base.GetComponent<ParticleFadeOut>() == null) == null)
        {
            goto Label_0206;
        }
        @out = base.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        @out = this.buttonClose.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        enumerator2 = this.containerPageButtons.GetEnumerator();
    Label_01BB:
        try
        {
            goto Label_01DA;
        Label_01C0:
            transform3 = (Transform) enumerator2.Current;
            transform3.GetComponent<AchievementScreenPageButton>().Fade();
        Label_01DA:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_01C0;
            }
            goto Label_0201;
        }
        finally
        {
        Label_01EB:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_01F9;
            }
        Label_01F9:
            disposable2.Dispose();
        }
    Label_0201:
        goto Label_0278;
    Label_0206:
        base.GetComponent<ParticleFadeOut>().Fade();
        this.buttonClose.GetComponent<ParticleFadeOut>().Fade();
        enumerator3 = this.containerPageButtons.GetEnumerator();
    Label_0232:
        try
        {
            goto Label_0251;
        Label_0237:
            transform4 = (Transform) enumerator3.Current;
            transform4.GetComponent<AchievementScreenPageButton>().Fade();
        Label_0251:
            if (enumerator3.MoveNext() != null)
            {
                goto Label_0237;
            }
            goto Label_0278;
        }
        finally
        {
        Label_0262:
            disposable3 = enumerator3 as IDisposable;
            if (disposable3 != null)
            {
                goto Label_0270;
            }
        Label_0270:
            disposable3.Dispose();
        }
    Label_0278:
        return;
    }

    private void RefreshPage(Transform page)
    {
        Transform transform;
        IEnumerator enumerator;
        AchievementItem item;
        IDisposable disposable;
        enumerator = page.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0036;
        Label_0011:
            transform = (Transform) enumerator.Current;
            item = transform.GetComponent<AchievementItem>();
            if ((item != null) == null)
            {
                goto Label_0036;
            }
            item.CheckStatus();
        Label_0036:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0058;
        }
        finally
        {
        Label_0046:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0051;
            }
        Label_0051:
            disposable.Dispose();
        }
    Label_0058:
        return;
    }

    private void Reset()
    {
        this.currentPage = 0;
        this.page1.gameObject.SetActive(1);
        this.page2.gameObject.SetActive(0);
        this.page3.gameObject.SetActive(0);
        this.page4.gameObject.SetActive(0);
        this.page5.gameObject.SetActive(0);
        this.page6.gameObject.SetActive(0);
        this.containerPageButtons.gameObject.SetActive(1);
        this.containerPageButtons.FindChild("ButtonPage1").GetComponent<AchievementScreenPageButton>().SetSelected();
        this.RefreshPage(this.page1);
        return;
    }

    public unsafe void SelectPage(int number)
    {
        int num;
        num = this.currentPage + 1;
        this.containerPageButtons.FindChild("ButtonPage" + &num.ToString()).GetComponent<AchievementScreenPageButton>().RevertToStatic();
        ((Transform) this.pages[this.currentPage]).gameObject.SetActive(0);
        this.currentPage = number - 1;
        ((Transform) this.pages[this.currentPage]).gameObject.SetActive(1);
        this.RefreshPage((Transform) this.pages[this.currentPage]);
        return;
    }

    public void Show()
    {
        object[] objArray1;
        this.Reset();
        base.transform.position = new Vector3(0f, 89f, -910f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 39f, -910f), "time", (float) 0.35f, "easetype", (iTween.EaseType) 7 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.buttonClose = base.transform.FindChild("ButtonClose").GetComponent<PackedSprite>();
        this.containerPageButtons = base.transform.FindChild("PageButtons");
        this.sprite = base.GetComponent<PackedSprite>();
        this.page1 = base.transform.FindChild("Page1");
        this.page2 = base.transform.FindChild("Page2");
        this.page3 = base.transform.FindChild("Page3");
        this.page4 = base.transform.FindChild("Page4");
        this.page5 = base.transform.FindChild("Page5");
        this.page6 = base.transform.FindChild("Page6");
        this.pages = new ArrayList();
        this.pages.Add(this.page1);
        this.pages.Add(this.page2);
        this.pages.Add(this.page3);
        this.pages.Add(this.page4);
        this.pages.Add(this.page5);
        this.pages.Add(this.page6);
        enumerator = this.containerPageButtons.GetEnumerator();
    Label_0159:
        try
        {
            goto Label_0249;
        Label_015E:
            transform = (Transform) enumerator.Current;
            if ((transform.name == "ButtonPage1") == null)
            {
                goto Label_0190;
            }
            transform.GetComponent<AchievementScreenPageButton>().SetPageNumber(1);
            goto Label_0249;
        Label_0190:
            if ((transform.name == "ButtonPage2") == null)
            {
                goto Label_01B6;
            }
            transform.GetComponent<AchievementScreenPageButton>().SetPageNumber(2);
            goto Label_0249;
        Label_01B6:
            if ((transform.name == "ButtonPage3") == null)
            {
                goto Label_01DC;
            }
            transform.GetComponent<AchievementScreenPageButton>().SetPageNumber(3);
            goto Label_0249;
        Label_01DC:
            if ((transform.name == "ButtonPage4") == null)
            {
                goto Label_0202;
            }
            transform.GetComponent<AchievementScreenPageButton>().SetPageNumber(4);
            goto Label_0249;
        Label_0202:
            if ((transform.name == "ButtonPage5") == null)
            {
                goto Label_0228;
            }
            transform.GetComponent<AchievementScreenPageButton>().SetPageNumber(5);
            goto Label_0249;
        Label_0228:
            if ((transform.name == "ButtonPage6") == null)
            {
                goto Label_0249;
            }
            transform.GetComponent<AchievementScreenPageButton>().SetPageNumber(6);
        Label_0249:
            if (enumerator.MoveNext() != null)
            {
                goto Label_015E;
            }
            goto Label_026B;
        }
        finally
        {
        Label_0259:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0264;
            }
        Label_0264:
            disposable.Dispose();
        }
    Label_026B:
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_0045;
        }
        if (&base.transform.position.y != 39f)
        {
            goto Label_0045;
        }
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.Hide();
    Label_0045:
        return;
    }
}

