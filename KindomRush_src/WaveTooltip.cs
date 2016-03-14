using System;
using UnityEngine;

public class WaveTooltip : MonoBehaviour
{
    private Transform arrowBL;
    private Transform arrowBR;
    private Transform arrowTL;
    private Transform arrowTR;
    private TextMesh info;
    private Transform title;

    public WaveTooltip()
    {
        base..ctor();
        return;
    }

    public void AdjustPositionForLines(int lines, float y)
    {
        Transform transform2;
        Transform transform1;
        if (y > -334f)
        {
            goto Label_0072;
        }
        if (lines != 2)
        {
            goto Label_0041;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(0f, 10f, 0f);
        goto Label_0072;
    Label_0041:
        if (lines != 3)
        {
            goto Label_0072;
        }
        transform2 = base.transform;
        transform2.position += new Vector3(0f, 20f, 0f);
    Label_0072:
        return;
    }

    private void Awake()
    {
        this.info = base.transform.FindChild("Text").GetComponent<TextMesh>();
        this.title = base.transform.FindChild("Title");
        this.arrowBL = base.transform.FindChild("ArrowBL");
        this.arrowBR = base.transform.FindChild("ArrowBR");
        this.arrowTL = base.transform.FindChild("ArrowTL");
        this.arrowTR = base.transform.FindChild("ArrowTR");
        return;
    }

    private void FixedUpdate()
    {
    }

    public unsafe void ResizeForLines(int lines)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        this.title.parent = null;
        this.info.transform.parent = null;
        if (lines != 1)
        {
            goto Label_0056;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 0.6f, 1f);
        goto Label_01E4;
    Label_0056:
        if (lines != 2)
        {
            goto Label_008F;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 0.75f, 1f);
        goto Label_01E4;
    Label_008F:
        if (lines != 3)
        {
            goto Label_00C8;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 0.9f, 1f);
        goto Label_01E4;
    Label_00C8:
        if (lines != 4)
        {
            goto Label_0101;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 1.1f, 1f);
        goto Label_01E4;
    Label_0101:
        if (lines != 5)
        {
            goto Label_013B;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 1.25f, 1f);
        goto Label_01E4;
    Label_013B:
        if (lines != 6)
        {
            goto Label_0175;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 1.3f, 1f);
        goto Label_01E4;
    Label_0175:
        if (lines != 7)
        {
            goto Label_01AF;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 1.45f, 1f);
        goto Label_01E4;
    Label_01AF:
        if (lines != 8)
        {
            goto Label_01E4;
        }
        base.transform.localScale = new Vector3(&base.transform.localScale.x, 1.65f, 1f);
    Label_01E4:
        this.title.parent = base.transform;
        this.info.transform.parent = base.transform;
        return;
    }

    public void SetArrowBL()
    {
        this.arrowBL.gameObject.SetActive(1);
        return;
    }

    public void SetArrowBR()
    {
        this.arrowBR.gameObject.SetActive(1);
        return;
    }

    public void SetArrowTL()
    {
        this.arrowTL.gameObject.SetActive(1);
        return;
    }

    public void SetArrowTR()
    {
        this.arrowTR.gameObject.SetActive(1);
        return;
    }

    public void SetText(string t)
    {
        this.info.text = t;
        this.info.alignment = 1;
        return;
    }

    private void Start()
    {
    }
}

