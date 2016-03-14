using System;
using System.Collections;
using UnityEngine;

public class HeroRoomHolder : MonoBehaviour
{
    private bool animating;
    private ArrayList barsAttack;
    private ArrayList barsHealth;
    private ArrayList barsRanged;
    private ArrayList barsSpeed;
    private int counterAttack;
    private int counterHealth;
    private int counterRanged;
    private int counterSpeed;
    private const float time = 0.15f;
    private float timeAttack;
    private float timeCounterAttack;
    private float timeCounterHealth;
    private float timeCounterRanged;
    private float timeCounterSpeed;
    private float timeHealth;
    private float timeRanged;
    private float timeSpeed;

    public HeroRoomHolder()
    {
        base..ctor();
        return;
    }

    private unsafe void Awake()
    {
        Transform transform;
        Transform transform2;
        Transform transform3;
        Transform transform4;
        int num;
        this.barsAttack = new ArrayList();
        this.barsHealth = new ArrayList();
        this.barsRanged = new ArrayList();
        this.barsSpeed = new ArrayList();
        num = 1;
        goto Label_0112;
    Label_0034:
        transform = base.transform.FindChild("BarAttack" + &num.ToString());
        if ((transform != null) == null)
        {
            goto Label_006A;
        }
        this.barsAttack.Add(transform);
    Label_006A:
        transform2 = base.transform.FindChild("BarHealth" + &num.ToString());
        if ((transform2 != null) == null)
        {
            goto Label_00A0;
        }
        this.barsHealth.Add(transform2);
    Label_00A0:
        transform3 = base.transform.FindChild("BarRanged" + &num.ToString());
        if ((transform3 != null) == null)
        {
            goto Label_00D6;
        }
        this.barsRanged.Add(transform3);
    Label_00D6:
        transform4 = base.transform.FindChild("BarSpeed" + &num.ToString());
        if ((transform4 != null) == null)
        {
            goto Label_010C;
        }
        this.barsSpeed.Add(transform4);
    Label_010C:
        num += 1;
    Label_0112:
        if (num <= 8)
        {
            goto Label_0034;
        }
        this.timeAttack = 0.15f / ((float) this.barsAttack.Count);
        this.timeHealth = 0.15f / ((float) this.barsHealth.Count);
        this.timeRanged = 0.15f / ((float) this.barsRanged.Count);
        this.timeSpeed = 0.15f / ((float) this.barsSpeed.Count);
        return;
    }

    public void Enable()
    {
        Transform transform;
        IEnumerator enumerator;
        Transform transform2;
        IEnumerator enumerator2;
        Transform transform3;
        IEnumerator enumerator3;
        Transform transform4;
        IEnumerator enumerator4;
        IDisposable disposable;
        IDisposable disposable2;
        IDisposable disposable3;
        IDisposable disposable4;
        this.animating = 1;
        this.timeCounterAttack = 0f;
        this.timeCounterHealth = 0f;
        this.timeCounterRanged = 0f;
        this.timeCounterSpeed = 0f;
        this.counterAttack = 0;
        this.counterHealth = 0;
        this.counterRanged = 0;
        this.counterSpeed = 0;
        enumerator = this.barsAttack.GetEnumerator();
    Label_005B:
        try
        {
            goto Label_0078;
        Label_0060:
            transform = (Transform) enumerator.Current;
            transform.gameObject.SetActive(0);
        Label_0078:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0060;
            }
            goto Label_009D;
        }
        finally
        {
        Label_0088:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0095;
            }
        Label_0095:
            disposable.Dispose();
        }
    Label_009D:
        enumerator2 = this.barsHealth.GetEnumerator();
    Label_00A9:
        try
        {
            goto Label_00C6;
        Label_00AE:
            transform2 = (Transform) enumerator2.Current;
            transform2.gameObject.SetActive(0);
        Label_00C6:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_00AE;
            }
            goto Label_00EB;
        }
        finally
        {
        Label_00D6:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_00E3;
            }
        Label_00E3:
            disposable2.Dispose();
        }
    Label_00EB:
        enumerator3 = this.barsRanged.GetEnumerator();
    Label_00F8:
        try
        {
            goto Label_0118;
        Label_00FD:
            transform3 = (Transform) enumerator3.Current;
            transform3.gameObject.SetActive(0);
        Label_0118:
            if (enumerator3.MoveNext() != null)
            {
                goto Label_00FD;
            }
            goto Label_013F;
        }
        finally
        {
        Label_0129:
            disposable3 = enumerator3 as IDisposable;
            if (disposable3 != null)
            {
                goto Label_0137;
            }
        Label_0137:
            disposable3.Dispose();
        }
    Label_013F:
        enumerator4 = this.barsSpeed.GetEnumerator();
    Label_014C:
        try
        {
            goto Label_016C;
        Label_0151:
            transform4 = (Transform) enumerator4.Current;
            transform4.gameObject.SetActive(0);
        Label_016C:
            if (enumerator4.MoveNext() != null)
            {
                goto Label_0151;
            }
            goto Label_0193;
        }
        finally
        {
        Label_017D:
            disposable4 = enumerator4 as IDisposable;
            if (disposable4 != null)
            {
                goto Label_018B;
            }
        Label_018B:
            disposable4.Dispose();
        }
    Label_0193:
        return;
    }

    private void FixedUpdate()
    {
        Transform transform;
        Transform transform2;
        Transform transform3;
        Transform transform4;
        if (this.animating == null)
        {
            goto Label_01DF;
        }
        if (this.counterAttack >= this.barsAttack.Count)
        {
            goto Label_0080;
        }
        this.timeCounterAttack += Time.deltaTime;
        if (this.timeCounterAttack < this.timeAttack)
        {
            goto Label_0080;
        }
        this.timeCounterAttack = 0f;
        transform = (Transform) this.barsAttack[this.counterAttack];
        transform.gameObject.SetActive(1);
        this.counterAttack += 1;
    Label_0080:
        if (this.counterHealth >= this.barsHealth.Count)
        {
            goto Label_00F5;
        }
        this.timeCounterHealth += Time.deltaTime;
        if (this.timeCounterHealth < this.timeHealth)
        {
            goto Label_00F5;
        }
        this.timeCounterHealth = 0f;
        transform2 = (Transform) this.barsHealth[this.counterHealth];
        transform2.gameObject.SetActive(1);
        this.counterHealth += 1;
    Label_00F5:
        if (this.counterRanged >= this.barsRanged.Count)
        {
            goto Label_016A;
        }
        this.timeCounterRanged += Time.deltaTime;
        if (this.timeCounterRanged < this.timeRanged)
        {
            goto Label_016A;
        }
        this.timeCounterRanged = 0f;
        transform3 = (Transform) this.barsRanged[this.counterRanged];
        transform3.gameObject.SetActive(1);
        this.counterRanged += 1;
    Label_016A:
        if (this.counterSpeed >= this.barsSpeed.Count)
        {
            goto Label_01DF;
        }
        this.timeCounterSpeed += Time.deltaTime;
        if (this.timeCounterSpeed < this.timeSpeed)
        {
            goto Label_01DF;
        }
        this.timeCounterSpeed = 0f;
        transform4 = (Transform) this.barsSpeed[this.counterSpeed];
        transform4.gameObject.SetActive(1);
        this.counterSpeed += 1;
    Label_01DF:
        return;
    }
}

