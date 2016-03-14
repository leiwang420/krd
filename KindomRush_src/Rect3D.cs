using System;
using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential)]
public struct Rect3D
{
    private Vector3 m_tl;
    private Vector3 m_tr;
    private Vector3 m_bl;
    private Vector3 m_br;
    private float m_width;
    private float m_height;
    public Rect3D(Vector3 tl, Vector3 tr, Vector3 bl)
    {
        Vector3 vector;
        float num;
        this.m_tl = this.m_tr = this.m_bl = this.m_br = Vector3.zero;
        this.m_width = this.m_height = 0f;
        this.FromPoints(tl, tr, bl);
        return;
    }

    public Rect3D(Rect r)
    {
        Vector3 vector;
        float num;
        this.m_tl = this.m_tr = this.m_bl = this.m_br = Vector3.zero;
        this.m_width = this.m_height = 0f;
        this.FromRect(r);
        return;
    }

    public Vector3 topLeft
    {
        get
        {
            return this.m_tl;
        }
    }
    public Vector3 topRight
    {
        get
        {
            return this.m_tr;
        }
    }
    public Vector3 bottomLeft
    {
        get
        {
            return this.m_bl;
        }
    }
    public Vector3 bottomRight
    {
        get
        {
            return this.m_br;
        }
    }
    public float width
    {
        get
        {
            if (float.IsNaN(this.m_width) == null)
            {
                goto Label_0027;
            }
            this.m_width = Vector3.Distance(this.m_tr, this.m_tl);
        Label_0027:
            return this.m_width;
        }
    }
    public float height
    {
        get
        {
            if (float.IsNaN(this.m_height) == null)
            {
                goto Label_0027;
            }
            this.m_height = Vector3.Distance(this.m_tl, this.m_bl);
        Label_0027:
            return this.m_height;
        }
    }
    public void FromPoints(Vector3 tl, Vector3 tr, Vector3 bl)
    {
        float num;
        this.m_tl = tl;
        this.m_tr = tr;
        this.m_bl = bl;
        this.m_br = tr + (bl - tl);
        this.m_width = this.m_height = (float) 1.0 / (float) 0.0;
        return;
    }

    public unsafe Rect GetRect()
    {
        return Rect.MinMaxRect(&this.m_bl.x, &this.m_bl.y, &this.m_tr.x, &this.m_tl.y);
    }

    public unsafe void FromRect(Rect r)
    {
        this.FromPoints(new Vector3(&r.xMin, &r.yMax, 0f), new Vector3(&r.xMax, &r.yMax, 0f), new Vector3(&r.xMin, &r.yMin, 0f));
        return;
    }

    public unsafe void MultFast(Matrix4x4 matrix)
    {
        float num;
        this.m_tl = &matrix.MultiplyPoint3x4(this.m_tl);
        this.m_tr = &matrix.MultiplyPoint3x4(this.m_tr);
        this.m_bl = &matrix.MultiplyPoint3x4(this.m_bl);
        this.m_br = &matrix.MultiplyPoint3x4(this.m_br);
        this.m_width = this.m_height = (float) 1.0 / (float) 0.0;
        return;
    }

    public static unsafe Rect3D MultFast(Rect3D rect, Matrix4x4 matrix)
    {
        return new Rect3D(&matrix.MultiplyPoint3x4(&rect.m_tl), &matrix.MultiplyPoint3x4(&rect.m_tr), &matrix.MultiplyPoint3x4(&rect.m_bl));
    }
}

