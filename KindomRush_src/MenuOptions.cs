using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    private Transform barFx;
    private Transform barMusic;
    private Transform boxAspect16By10;
    private Transform boxAspect16By9;
    private Transform boxAspect4By3;
    private MenuOptionsAspectBox boxAspectRatio;
    private Transform buttonFx;
    private Transform buttonMusic;
    private int selectedHeight;
    private int selectedWidth;
    private TextMesh textCurrentRatio;
    private TextMesh textCurrentRes16By10;
    private TextMesh textCurrentRes16By9;
    private TextMesh textCurrentRes4By3;

    public MenuOptions()
    {
        base..ctor();
        return;
    }

    private void CleanUp()
    {
        base.transform.position = new Vector3(0f, 1600f, -920f);
        this.ResetFade(base.transform);
        return;
    }

    public void Close(bool fade = true)
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 116f, -920f), "time", (double) 0.2, "easetype", (iTween.EaseType) 7, "oncomplete", "CleanUp" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        if (fade == null)
        {
            goto Label_0086;
        }
        this.Fade(base.transform);
    Label_0086:
        return;
    }

    private void Fade(Transform t)
    {
        ParticleFadeOut @out;
        TextMesh mesh;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if (t.GetComponent<PackedSprite>() == null)
        {
            goto Label_0058;
        }
        if (t.GetComponent<ParticleFadeOut>() != null)
        {
            goto Label_004D;
        }
        @out = t.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        goto Label_0058;
    Label_004D:
        t.GetComponent<ParticleFadeOut>().Fade();
    Label_0058:
        mesh = t.GetComponent<TextMesh>();
        if ((mesh != null) == null)
        {
            goto Label_0077;
        }
        mesh.gameObject.SetActive(0);
    Label_0077:
        enumerator = t.GetEnumerator();
    Label_007E:
        try
        {
            goto Label_0096;
        Label_0083:
            transform = (Transform) enumerator.Current;
            this.Fade(transform);
        Label_0096:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0083;
            }
            goto Label_00BB;
        }
        finally
        {
        Label_00A6:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B3;
            }
        Label_00B3:
            disposable.Dispose();
        }
    Label_00BB:
        return;
    }

    private void FixedUpdate()
    {
    }

    private void ResetFade(Transform t)
    {
        ParticleFadeOut @out;
        TextMesh mesh;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        @out = t.GetComponent<ParticleFadeOut>();
        if ((@out != null) == null)
        {
            goto Label_0019;
        }
        @out.Reset();
    Label_0019:
        mesh = t.GetComponent<TextMesh>();
        if ((mesh != null) == null)
        {
            goto Label_0038;
        }
        mesh.gameObject.SetActive(1);
    Label_0038:
        enumerator = t.GetEnumerator();
    Label_003F:
        try
        {
            goto Label_0057;
        Label_0044:
            transform = (Transform) enumerator.Current;
            this.ResetFade(transform);
        Label_0057:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0044;
            }
            goto Label_007C;
        }
        finally
        {
        Label_0067:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0074;
            }
        Label_0074:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    private void SetActiveRes(TextMesh resText)
    {
    }

    public void SetAspect(GameData.aspectRatioEnum ratio)
    {
    }

    public void Show()
    {
        object[] objArray1;
        base.transform.position = new Vector3(0f, 125f, -920f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(0f, 75f, -920f), "time", (float) 0.25f, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        this.buttonFx = base.transform.FindChild("ButtonFx");
        this.buttonMusic = base.transform.FindChild("ButtonMusic");
        this.barFx = base.transform.FindChild("BarFx");
        this.barMusic = base.transform.FindChild("BarMusic");
        this.SetAspect(GameData.AspectRatio);
        return;
    }
}

