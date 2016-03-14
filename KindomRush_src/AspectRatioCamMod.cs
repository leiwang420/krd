using System;
using UnityEngine;

public class AspectRatioCamMod : MonoBehaviour
{
    private const float ratio1610 = 1.6f;
    private const float ratio43 = 1.33333f;

    public AspectRatioCamMod()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Refresh(int width, int height)
    {
        float num;
        num = ((float) width) / ((float) height);
        if (Mathf.Abs(num - 1.33333f) >= 0.1f)
        {
            goto Label_0021;
        }
        goto Label_005C;
    Label_0021:
        if (Mathf.Abs(num - 1.6f) >= 0.1f)
        {
            goto Label_004C;
        }
        base.camera.orthographicSize = 600f;
        goto Label_005C;
    Label_004C:
        base.camera.orthographicSize = 540f;
    Label_005C:
        return;
    }

    private void Start()
    {
        this.Refresh(Screen.width, Screen.height);
        return;
    }
}

