using System;
using UnityEngine;

public class VeznanSoul : MonoBehaviour
{
    private float aceleration;
    private float angle;
    private float angleVariationCurrent;
    private int angleVariationDirection;
    private float angleVariationMax;
    private float angleVariationMin;
    private int hitTime;
    private int hitTimeCounter;
    private bool isActive;
    public Transform particlePrefab;
    private float xSpeed;
    private float ySpeed;

    public VeznanSoul()
    {
        base..ctor();
        return;
    }

    private void AddParticle(float x, float y)
    {
        Transform transform;
        if (base.transform.GetChildCount() != null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        transform = base.transform.GetChild(base.transform.GetChildCount() - 1);
        transform.GetComponent<VeznanSoulParticle>().Go();
        transform.parent = null;
        return;
    }

    private void FixedUpdate()
    {
        this.MoveMe();
        return;
    }

    private unsafe void FreeParticles()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        this.AddParticle(&base.transform.position.x - 1f, &base.transform.position.y);
        this.AddParticle(&base.transform.position.x + 1f, &base.transform.position.y);
        return;
    }

    private unsafe void MoveMe()
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if (&base.transform.position.x > 960f)
        {
            goto Label_0076;
        }
        if (&base.transform.position.x < -960f)
        {
            goto Label_0076;
        }
        if (&base.transform.position.y < -540f)
        {
            goto Label_0076;
        }
        if (&base.transform.position.y <= 540f)
        {
            goto Label_0082;
        }
    Label_0076:
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0082:
        num = 0f;
        num = num = ((this.angle + this.angleVariationCurrent) * 3.141593f) / 180f;
        this.ySpeed = Mathf.Sin(num) * this.aceleration;
        this.xSpeed = Mathf.Cos(num) * this.aceleration;
        num2 = 360f - ((Mathf.Atan2(this.ySpeed, this.xSpeed) * 180f) / 3.141593f);
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(0f, 0f, -num2);
        base.transform.position = new Vector3(&base.transform.position.x + this.xSpeed, &base.transform.position.y + this.ySpeed, -890f);
        this.FreeParticles();
        if (this.angleVariationDirection != 1)
        {
            goto Label_01A2;
        }
        if (this.angleVariationCurrent < this.angleVariationMax)
        {
            goto Label_018B;
        }
        this.angleVariationDirection = -1;
        return;
    Label_018B:
        this.angleVariationCurrent += 5f;
        goto Label_01CD;
    Label_01A2:
        if (this.angleVariationCurrent > this.angleVariationMin)
        {
            goto Label_01BB;
        }
        this.angleVariationDirection = 1;
        return;
    Label_01BB:
        this.angleVariationCurrent -= 5f;
    Label_01CD:
        return;
    }

    public void SetAngle(float a)
    {
        this.angle = a;
        return;
    }

    private void Start()
    {
        this.aceleration = UnityEngine.Random.Range(6f, 15f);
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_003A;
        }
        this.angleVariationDirection = 1;
        goto Label_0041;
    Label_003A:
        this.angleVariationDirection = -1;
    Label_0041:
        this.isActive = 1;
        this.angleVariationMin = -70f;
        this.angleVariationMax = 70f;
        this.hitTime = 6;
        return;
    }
}

