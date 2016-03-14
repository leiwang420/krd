using System;
using UnityEngine;

public class DenasBuffCircle : MonoBehaviour
{
    private bool fadeIn;
    private bool fadeOut;
    private float opacity;
    private PackedSprite sprite;

    public DenasBuffCircle()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.fadeIn == null)
        {
            goto Label_0076;
        }
        this.opacity += 2.7f * Time.deltaTime;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity < 0.8f)
        {
            goto Label_00D9;
        }
        this.opacity = 1f;
        this.fadeIn = 0;
        this.fadeOut = 1;
        goto Label_00D9;
    Label_0076:
        if (this.fadeOut == null)
        {
            goto Label_00D9;
        }
        this.opacity -= 1.5f * Time.deltaTime;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity > 0f)
        {
            goto Label_00D9;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00D9:
        return;
    }

    private void Start()
    {
        object[] objArray1;
        this.sprite = base.GetComponent<PackedSprite>();
        this.opacity = 0.1f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        this.fadeIn = 1;
        this.fadeOut = 0;
        objArray1 = new object[] { "x", (float) 1.8f, "y", (float) 1.8f, "time", (float) 1.3f };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }
}

