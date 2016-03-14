using System;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    private float acceleration;
    private float scale;
    private bool scaleDown;
    private float scaleFactor;
    private float scaleFactor0;
    private float scaleMax;
    private float scaleMin;
    private bool scaleUp;

    public TweenScale()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.scaleUp == null)
        {
            goto Label_00AF;
        }
        this.scale += this.scaleFactor * Time.deltaTime;
        this.scaleFactor -= this.acceleration * Time.deltaTime;
        base.transform.localScale = new Vector3(this.scale, this.scale, 1f);
        if (this.scale < this.scaleMax)
        {
            goto Label_0159;
        }
        base.transform.localScale = new Vector3(this.scaleMax, this.scaleMax, 1f);
        this.scaleUp = 0;
        this.scaleDown = 1;
        this.scaleFactor = this.scaleFactor0;
        goto Label_0159;
    Label_00AF:
        if (this.scaleDown == null)
        {
            goto Label_0159;
        }
        this.scale -= this.scaleFactor * Time.deltaTime;
        this.scaleFactor -= this.acceleration * Time.deltaTime;
        base.transform.localScale = new Vector3(this.scale, this.scale, 1f);
        if (this.scale > this.scaleMin)
        {
            goto Label_0159;
        }
        base.transform.localScale = new Vector3(this.scaleMin, this.scaleMin, 1f);
        this.scaleUp = 1;
        this.scaleDown = 0;
        this.scaleFactor = this.scaleFactor0;
    Label_0159:
        return;
    }

    private void Start()
    {
        this.scaleFactor0 = 0.1f;
        this.scaleFactor = this.scaleFactor0;
        this.acceleration = 0.005f;
        this.scaleMax = 1.02f;
        this.scaleMin = 0.98f;
        this.scale = this.scaleMin;
        base.transform.localScale = new Vector3(this.scale, this.scale, 1f);
        this.scaleUp = 1;
        return;
    }
}

