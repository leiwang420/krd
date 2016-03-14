using System;
using UnityEngine;

public class MainMenuCredits : MonoBehaviour
{
    private bool isMoving;
    private Transform overlay;
    private Transform scroll;

    public MainMenuCredits()
    {
        base..ctor();
        return;
    }

    public void Close()
    {
        this.isMoving = 0;
        this.Hide();
        return;
    }

    private void Hide()
    {
        base.transform.position = new Vector3(0f, 0f, 10f);
        this.scroll.localPosition = new Vector3(0f, 2110f, -1f);
        return;
    }

    private void Reset()
    {
        this.scroll.localPosition = new Vector3(0f, 0f, -1f);
        return;
    }

    public void Show()
    {
        this.Reset();
        base.transform.position = new Vector3(0f, 0f, -901f);
        this.overlay.GetComponent<ParticleFadeOut>().Fade();
        base.Invoke("StartScroll", 0.25f);
        return;
    }

    private void Start()
    {
        this.scroll = base.transform.FindChild("Scroll");
        this.overlay = base.transform.FindChild("OverlayFade");
        return;
    }

    private void StartScroll()
    {
        this.isMoving = 1;
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        if (this.isMoving == null)
        {
            goto Label_0087;
        }
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_001D;
        }
        this.Close();
    Label_001D:
        this.scroll.localPosition += new Vector3(0f, (float) Mathf.RoundToInt(70f * Time.deltaTime), 0f);
        if (&this.scroll.position.y < 4450f)
        {
            goto Label_0087;
        }
        this.isMoving = 0;
        base.Invoke("Hide", 1f);
    Label_0087:
        return;
    }
}

