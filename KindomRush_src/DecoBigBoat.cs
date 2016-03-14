using System;
using UnityEngine;

public class DecoBigBoat : MonoBehaviour
{
    private bool atDocks;
    private float counterAtDocks;
    private Vector3 dockPosition;
    private float journeyLength;
    private bool sailingToDocks;
    private bool sailingToWherever;
    private PackedSprite sprite;
    private float startTime;
    private float timeAtDocks;
    private Vector3 whereverPosition;

    public DecoBigBoat()
    {
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        if ((this.sprite.GetCurAnim().name == "fade") == null)
        {
            goto Label_002F;
        }
        this.sprite.PlayAnim("idleDockEnd");
    Label_002F:
        return;
    }

    private unsafe void FixedUpdate()
    {
        float num;
        float num2;
        float num3;
        float num4;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if (this.sailingToDocks == null)
        {
            goto Label_00F6;
        }
        num = (Time.time - this.startTime) * 20f;
        num2 = num / this.journeyLength;
        base.transform.position = Vector3.Lerp(this.whereverPosition, this.dockPosition, num2);
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), -2f);
        if (&base.transform.position.x != &this.dockPosition.x)
        {
            goto Label_02AA;
        }
        if (&base.transform.position.y != &this.dockPosition.y)
        {
            goto Label_02AA;
        }
        this.sailingToDocks = 0;
        this.atDocks = 1;
        this.sprite.PlayAnim("idleDockStart");
        goto Label_02AA;
    Label_00F6:
        if (this.atDocks == null)
        {
            goto Label_01C0;
        }
        this.counterAtDocks += Time.deltaTime;
        if (this.counterAtDocks < 2f)
        {
            goto Label_0176;
        }
        if ((this.sprite.GetCurAnim().name != "fade") == null)
        {
            goto Label_0176;
        }
        if ((this.sprite.GetCurAnim().name != "idleDockEnd") == null)
        {
            goto Label_0176;
        }
        this.sprite.PlayAnim("fade");
        goto Label_01BB;
    Label_0176:
        if (this.counterAtDocks < this.timeAtDocks)
        {
            goto Label_02AA;
        }
        this.counterAtDocks = 0f;
        this.atDocks = 0;
        this.sailingToWherever = 1;
        this.startTime = Time.time;
        this.sprite.PlayAnim("sailingWherever");
    Label_01BB:
        goto Label_02AA;
    Label_01C0:
        if (this.sailingToWherever == null)
        {
            goto Label_02AA;
        }
        num3 = (Time.time - this.startTime) * 20f;
        num4 = num3 / this.journeyLength;
        base.transform.position = Vector3.Lerp(this.dockPosition, this.whereverPosition, num4);
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), -2f);
        if (&base.transform.position.x != &this.whereverPosition.x)
        {
            goto Label_02AA;
        }
        if (&base.transform.position.y != &this.whereverPosition.y)
        {
            goto Label_02AA;
        }
        this.sailingToDocks = 0;
        base.Invoke("Restart", 4f);
    Label_02AA:
        return;
    }

    private void Restart()
    {
        this.startTime = Time.time;
        this.sprite.PlayAnim("sailingDocks");
        this.sailingToDocks = 1;
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        this.sprite.PlayAnim("sailingDocks");
        this.timeAtDocks = 5f;
        this.startTime = Time.time;
        this.whereverPosition = new Vector3(-1014f, -499f, -2f);
        this.dockPosition = new Vector3(-704f, -390f, -2f);
        this.journeyLength = Vector3.Distance(this.whereverPosition, this.dockPosition);
        this.sailingToDocks = 1;
        return;
    }
}

