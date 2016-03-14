using System;
using System.Collections;
using UnityEngine;

public class TweenFade : MonoBehaviour
{
    private ArrayList children;
    private float fadeSpeed;
    private float fromAlpha;
    private float opacity;
    private float opacityDiff;
    private PackedSprite sprite;
    private float toAlpha;

    public TweenFade()
    {
        base..ctor();
        return;
    }

    private void AddChildren()
    {
        Transform transform;
        IEnumerator enumerator;
        PackedSprite sprite;
        IDisposable disposable;
        enumerator = base.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_003C;
        Label_0011:
            transform = (Transform) enumerator.Current;
            sprite = transform.GetComponent<PackedSprite>();
            if (sprite == null)
            {
                goto Label_003C;
            }
            this.children.Add(sprite);
        Label_003C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_005E;
        }
        finally
        {
        Label_004C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0057;
            }
        Label_0057:
            disposable.Dispose();
        }
    Label_005E:
        return;
    }

    public void Fade(float fromA, float toA, float time)
    {
        float num;
        this.sprite = base.GetComponent<PackedSprite>();
        this.children = new ArrayList();
        this.fromAlpha = fromA;
        this.toAlpha = toA;
        this.opacity = this.fromAlpha;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        num = Mathf.Abs(this.fromAlpha - this.toAlpha);
        this.opacityDiff = num / (time * 30f);
        this.AddChildren();
        this.SetChildrenAlpha(this.opacity);
        return;
    }

    private void FixedUpdate()
    {
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        this.SetChildrenAlpha(this.opacity);
        if (this.fromAlpha >= this.toAlpha)
        {
            goto Label_00AE;
        }
        this.opacity += this.opacityDiff;
        if (this.opacity < this.toAlpha)
        {
            goto Label_0115;
        }
        this.opacity = this.toAlpha;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        this.SetChildrenAlpha(this.opacity);
        UnityEngine.Object.Destroy(this);
        goto Label_0115;
    Label_00AE:
        this.opacity -= this.opacityDiff;
        if (this.opacity > this.toAlpha)
        {
            goto Label_0115;
        }
        this.opacity = this.toAlpha;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        this.SetChildrenAlpha(this.opacity);
        UnityEngine.Object.Destroy(this);
    Label_0115:
        return;
    }

    private void SetChildrenAlpha(float a)
    {
        PackedSprite sprite;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.children.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0038;
        Label_0011:
            sprite = (PackedSprite) enumerator.Current;
            sprite.SetColor(new Color(1f, 1f, 1f, a));
        Label_0038:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_005A;
        }
        finally
        {
        Label_0048:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0053;
            }
        Label_0053:
            disposable.Dispose();
        }
    Label_005A:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

