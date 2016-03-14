using System;
using UnityEngine;

public class TextMeshFade : MonoBehaviour
{
    private Color textColor;

    public TextMeshFade()
    {
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        &this.textColor.a -= 0.25f * Time.deltaTime;
        base.gameObject.renderer.material.color = this.textColor;
        return;
    }

    private void Start()
    {
        base.gameObject.renderer.material.color = this.textColor;
        return;
    }
}

