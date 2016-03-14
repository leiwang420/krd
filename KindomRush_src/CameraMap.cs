using System;
using UnityEngine;

public class CameraMap : MonoBehaviour
{
    private float aspectRatio;
    private float limit;
    private PackedSprite overlay;
    private const float ratio43 = 1.33333f;
    private float speed;

    public CameraMap()
    {
        base..ctor();
        return;
    }

    public void SetFarRightPosition()
    {
        if (Mathf.Abs(this.aspectRatio - 1.33333f) >= 0.1f)
        {
            goto Label_003B;
        }
        base.transform.position = new Vector3(this.limit, 0f, -999f);
    Label_003B:
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        this.aspectRatio = ((float) Screen.width) / ((float) Screen.height);
        this.speed = 250f;
        this.overlay = GameObject.Find("Overlay").GetComponent<PackedSprite>();
        this.limit = 240f;
        if (Mathf.Abs(this.aspectRatio - 1.33333f) >= 0.1f)
        {
            goto Label_0096;
        }
        base.transform.position = new Vector3(-this.limit, &base.transform.position.y, &base.transform.position.z);
    Label_0096:
        return;
    }

    private unsafe void Update()
    {
        Transform transform2;
        Transform transform1;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        if (Mathf.Abs(this.aspectRatio - 1.33333f) >= 0.1f)
        {
            goto Label_01A0;
        }
        if (this.overlay.IsHidden() != null)
        {
            goto Label_002C;
        }
        return;
    Label_002C:
        vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (&vector.x < 0.9f)
        {
            goto Label_00EE;
        }
        if (&vector.y < 0.15f)
        {
            goto Label_00EE;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(this.speed * Time.deltaTime, 0f, 0f);
        if (&base.transform.position.x <= this.limit)
        {
            goto Label_01A0;
        }
        base.transform.position = new Vector3(this.limit, &base.transform.position.y, &base.transform.position.z);
        goto Label_01A0;
    Label_00EE:
        if (&vector.x > 0.1f)
        {
            goto Label_01A0;
        }
        if (&vector.y > 0.9f)
        {
            goto Label_01A0;
        }
        transform2 = base.transform;
        transform2.position -= new Vector3(this.speed * Time.deltaTime, 0f, 0f);
        if (&base.transform.position.x >= -this.limit)
        {
            goto Label_01A0;
        }
        base.transform.position = new Vector3(-this.limit, &base.transform.position.y, &base.transform.position.z);
    Label_01A0:
        return;
    }
}

