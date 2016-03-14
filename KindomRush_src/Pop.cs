using System;
using UnityEngine;

public class Pop : MonoBehaviour
{
    public Pop()
    {
        base..ctor();
        return;
    }

    private void Delay()
    {
        base.Invoke("Kill", 0.5f);
        return;
    }

    private void FixedUpdate()
    {
    }

    private float GetRandomAngle()
    {
        float num;
        num = UnityEngine.Random.Range(0f, 21f) * 0.01745329f;
        if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
        {
            goto Label_0037;
        }
        return (num * -1f);
    Label_0037:
        return num;
    }

    private void Kill()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void ScaleDownOne()
    {
        object[] objArray1;
        objArray1 = new object[] { "x", (double) 0.75, "y", (double) 0.75, "time", (float) 0.15f, "oncomplete", "Delay", "easetype", (iTween.EaseType) 1 };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void Start()
    {
        object[] objArray1;
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, 14f, 0f);
        base.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        base.transform.RotateAround(Vector3.forward, this.GetRandomAngle());
        objArray1 = new object[] { "x", (float) 0.9f, "y", (float) 0.9f, "time", (float) 0.15f, "oncomplete", "ScaleDownOne" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }
}

