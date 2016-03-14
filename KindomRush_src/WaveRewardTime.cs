using System;
using UnityEngine;

public class WaveRewardTime : MonoBehaviour
{
    private PackedSprite centenaSprite;
    private PackedSprite decimalSprite;
    public float offsetY;
    private Transform tick;
    public float tweenTime;
    private PackedSprite unitSprite;

    public WaveRewardTime()
    {
        this.tweenTime = 3f;
        base..ctor();
        return;
    }

    private void Awake()
    {
        Transform transform;
        this.decimalSprite = base.transform.FindChild("Decimal").GetComponent<PackedSprite>();
        this.unitSprite = base.transform.FindChild("Unit").GetComponent<PackedSprite>();
        this.tick = base.transform.FindChild("Tick");
        transform = base.transform.FindChild("Centena");
        if ((transform != null) == null)
        {
            goto Label_0075;
        }
        this.centenaSprite = transform.GetComponent<PackedSprite>();
    Label_0075:
        return;
    }

    private void FixedUpdate()
    {
    }

    private void KillMe()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    public void Launch()
    {
        object[] objArray1;
        Vector3 vector;
        vector = base.transform.position + new Vector3(0f, this.offsetY, 0f);
        objArray1 = new object[] { "position", (Vector3) vector, "time", (float) this.tweenTime, "easetype", (iTween.EaseType) 0x1b, "oncomplete", "KillMe" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    public void SetGold(int gold)
    {
        Transform transform2;
        Transform transform1;
        int num;
        int num2;
        int num3;
        num = gold / 100;
        num2 = gold / 10;
        num3 = gold % 10;
        if (num != null)
        {
            goto Label_00B2;
        }
        this.centenaSprite.Hide(1);
        transform1 = this.tick.transform;
        transform1.position += new Vector3(15f, 0f, 0f);
        if (num2 != null)
        {
            goto Label_0096;
        }
        this.decimalSprite.Hide(1);
        transform2 = this.tick.transform;
        transform2.position += new Vector3(15f, 0f, 0f);
        goto Label_00AD;
    Label_0096:
        this.decimalSprite.PlayAnim(num2);
        this.decimalSprite.PauseAnim();
    Label_00AD:
        goto Label_00E3;
    Label_00B2:
        this.centenaSprite.PlayAnim(num);
        this.centenaSprite.PauseAnim();
        this.decimalSprite.PlayAnim(num2 % 10);
        this.decimalSprite.PauseAnim();
    Label_00E3:
        this.unitSprite.PlayAnim(num3);
        this.unitSprite.PauseAnim();
        return;
    }

    public void SetTime(int time)
    {
        Transform transform1;
        int num;
        int num2;
        num = time / 10;
        num2 = time % 10;
        if (num != null)
        {
            goto Label_0050;
        }
        this.decimalSprite.Hide(1);
        transform1 = this.tick.transform;
        transform1.position += new Vector3(15f, 0f, 0f);
        goto Label_0067;
    Label_0050:
        this.decimalSprite.PlayAnim(num);
        this.decimalSprite.PauseAnim();
    Label_0067:
        this.unitSprite.PlayAnim(num2);
        this.unitSprite.PauseAnim();
        return;
    }
}

