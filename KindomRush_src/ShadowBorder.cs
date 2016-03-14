using System;
using UnityEngine;

public class ShadowBorder : MonoBehaviour
{
    private Transform aspect_1610;
    private Transform aspect_169;
    private Transform aspect_43;
    private const float ratio1610 = 1.6f;
    private const float ratio43 = 1.33333f;

    public ShadowBorder()
    {
        base..ctor();
        return;
    }

    private void SetBorder()
    {
        float num;
        num = ((float) Screen.width) / ((float) Screen.height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_003A;
        }
        this.aspect_43.gameObject.SetActive(1);
        goto Label_0077;
    Label_003A:
        if (Mathf.Abs(num - 1.6f) >= 0.1f)
        {
            goto Label_0066;
        }
        this.aspect_1610.gameObject.SetActive(1);
        goto Label_0077;
    Label_0066:
        this.aspect_169.gameObject.SetActive(1);
    Label_0077:
        return;
    }

    private void Start()
    {
        this.aspect_43 = base.transform.FindChild("43");
        this.aspect_169 = base.transform.FindChild("169");
        this.aspect_1610 = base.transform.FindChild("1610");
        this.SetBorder();
        return;
    }

    private void Update()
    {
    }
}

