using System;
using UnityEngine;

public class MenuOptionsButtonMusic : MonoBehaviour
{
    private Transform bar;
    private Camera cam;
    private bool dragging;
    private float lastX;
    private Map map;
    private float offset;
    private float percentage;
    private PackedSprite sprite;

    public MenuOptionsButtonMusic()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private unsafe void OnMouseDown()
    {
        Vector3 vector;
        Vector3 vector2;
        this.lastX = &this.cam.ScreenToWorldPoint(Input.mousePosition).x;
        this.offset = &base.transform.position.x - this.lastX;
        this.sprite.PlayAnim("click");
        this.dragging = 1;
        return;
    }

    private unsafe void OnMouseDrag()
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
        num = &this.cam.ScreenToWorldPoint(Input.mousePosition).x;
        if (num <= this.lastX)
        {
            goto Label_005F;
        }
        base.transform.position = new Vector3(Mathf.Round(num + this.offset), &base.transform.position.y, -923f);
        goto Label_00A0;
    Label_005F:
        if (num >= this.lastX)
        {
            goto Label_00A0;
        }
        base.transform.position = new Vector3(Mathf.Round(num + this.offset), &base.transform.position.y, -923f);
    Label_00A0:
        if (&base.transform.position.x >= -203f)
        {
            goto Label_00F1;
        }
        base.transform.position = new Vector3(-203f, &base.transform.position.y, -923f);
        goto Label_013D;
    Label_00F1:
        if (&base.transform.position.x <= 193f)
        {
            goto Label_013D;
        }
        base.transform.position = new Vector3(193f, &base.transform.position.y, -923f);
    Label_013D:
        this.lastX = &this.cam.ScreenToWorldPoint(Input.mousePosition).x;
        this.percentage = (&base.transform.position.x + 203f) / 396f;
        this.SetVolAndScale();
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        if (this.dragging != null)
        {
            goto Label_0016;
        }
        this.sprite.RevertToStatic();
    Label_0016:
        return;
    }

    private void OnMouseUp()
    {
        this.sprite.RevertToStatic();
        this.dragging = 0;
        return;
    }

    private void SetVolAndScale()
    {
        this.bar.transform.localScale = new Vector3(this.percentage, 1f, 1f);
        GameSoundManager.SetVolumeMusic(this.percentage);
        if ((this.map != null) == null)
        {
            goto Label_005A;
        }
        GameObject.Find("MapMusic").GetComponent<AudioSource>().volume = GameSoundManager.GetVolumeMusic();
    Label_005A:
        return;
    }

    private unsafe void Start()
    {
        GameObject obj2;
        Vector3 vector;
        this.cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.bar = base.transform.parent.FindChild("BarMusic");
        this.sprite = base.GetComponent<PackedSprite>();
        obj2 = GameObject.Find("Map");
        if ((obj2 != null) == null)
        {
            goto Label_005F;
        }
        this.map = obj2.GetComponent<Map>();
    Label_005F:
        this.percentage = GameSoundManager.GetVolumeMusic();
        base.transform.position = new Vector3(Mathf.Round((this.percentage * 396f) - 203f), &base.transform.position.y, -923f);
        this.SetVolAndScale();
        return;
    }
}

