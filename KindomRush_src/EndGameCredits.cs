using System;
using UnityEngine;

public class EndGameCredits : MonoBehaviour
{
    private bool isMoving;
    private Transform scroll;
    private bool switchMusic;

    public EndGameCredits()
    {
        base..ctor();
        return;
    }

    private void Hide()
    {
        base.transform.position = new Vector3(0f, 0f, 10f);
        return;
    }

    private void Reset()
    {
        this.scroll.localPosition = new Vector3(0f, 0f, -1f);
        return;
    }

    public void Show()
    {
        base.transform.localPosition = new Vector3(0f, -1000f, -2f);
        this.isMoving = 1;
        return;
    }

    private void Start()
    {
        this.scroll = base.transform.FindChild("Scroll");
        return;
    }

    private unsafe void Update()
    {
        Transform transform1;
        Vector3 vector;
        Vector3 vector2;
        if (this.isMoving == null)
        {
            goto Label_00E1;
        }
        transform1 = base.transform;
        transform1.localPosition += new Vector3(0f, Mathf.Round(100f * Time.deltaTime), 0f);
        if (&base.transform.position.y < 4350f)
        {
            goto Label_009D;
        }
        base.transform.localPosition = new Vector3(2000f, 2110f, -1f);
        this.isMoving = 0;
        base.transform.parent.GetComponent<EndGame>().ShowEndComic();
        goto Label_00E1;
    Label_009D:
        if (this.switchMusic != null)
        {
            goto Label_00E1;
        }
        if (&base.transform.position.y < 4250f)
        {
            goto Label_00E1;
        }
        this.switchMusic = 1;
        base.transform.parent.GetComponent<EndGame>().SwitchMusic();
    Label_00E1:
        return;
    }
}

