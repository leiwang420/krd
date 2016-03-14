using System;
using UnityEngine;

public class MainMenuButtonSound : MainMenuButtonBase
{
    protected Transform bar;
    protected Camera cam;
    protected bool dragging;
    protected float lastX;
    protected float offset;
    protected float percentage;

    public MainMenuButtonSound()
    {
        base..ctor();
        return;
    }

    protected override void CustomInit()
    {
        this.cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        base.menu = base.transform.parent.parent.GetComponent<MainMenu>();
        this.SetVolAndScale();
        return;
    }

    private void FixedUpdate()
    {
    }

    protected override unsafe void OnMouseDown()
    {
        Vector3 vector;
        Vector3 vector2;
        this.lastX = &this.cam.ScreenToWorldPoint(Input.mousePosition).x;
        this.offset = &base.transform.position.x - this.lastX;
        base.sprite.PlayAnim("click");
        this.dragging = 1;
        return;
    }

    protected unsafe void OnMouseDrag()
    {
        float num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        Vector3 vector11;
        num = &this.cam.ScreenToWorldPoint(Input.mousePosition).x;
        if (num <= this.lastX)
        {
            goto Label_0078;
        }
        base.transform.localPosition = new Vector3(Mathf.Round(Mathf.Abs(num - this.lastX) + &base.transform.localPosition.x), &base.transform.localPosition.y, -2f);
        goto Label_00D4;
    Label_0078:
        if (num >= this.lastX)
        {
            goto Label_00D4;
        }
        base.transform.localPosition = new Vector3(Mathf.Round(&base.transform.localPosition.x - Mathf.Abs(num - this.lastX)), &base.transform.localPosition.y, -2f);
    Label_00D4:
        if (&base.transform.localPosition.x >= -134f)
        {
            goto Label_0125;
        }
        base.transform.localPosition = new Vector3(-134f, &base.transform.localPosition.y, -2f);
        goto Label_0171;
    Label_0125:
        if (&base.transform.localPosition.x <= 144f)
        {
            goto Label_0171;
        }
        base.transform.localPosition = new Vector3(144f, &base.transform.localPosition.y, -2f);
    Label_0171:
        this.lastX = &this.cam.ScreenToWorldPoint(Input.mousePosition).x;
        this.percentage = (&base.transform.localPosition.x + 134f) / 280f;
        this.SetVolAndScale();
        return;
    }

    protected override void OnMouseExit()
    {
        if (this.dragging != null)
        {
            goto Label_0016;
        }
        base.sprite.RevertToStatic();
    Label_0016:
        return;
    }

    protected override void OnMouseUp()
    {
        base.sprite.RevertToStatic();
        this.dragging = 0;
        return;
    }

    protected virtual void SetVolAndScale()
    {
    }
}

