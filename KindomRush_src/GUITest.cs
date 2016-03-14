using System;
using UnityEngine;

public class GUITest : MonoBehaviour
{
    private float x;

    public GUITest()
    {
        this.x = 437f;
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        Transform transform1;
        float num;
        num = Time.deltaTime;
        transform1 = base.transform;
        transform1.position += new Vector3(10f * num, 0f, 0f);
        return;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(this.x, 334f, 150f, 100f), "I am a button") == null)
        {
            goto Label_0039;
        }
        MonoBehaviour.print("You clicked the button!");
        Application.LoadLevel(1);
    Label_0039:
        if (this.x >= 850f)
        {
            goto Label_0061;
        }
        this.x += 100f * Time.deltaTime;
    Label_0061:
        return;
    }
}

