using System;
using UnityEngine;

public class DecoCloud : MonoBehaviour
{
    private Vector3 endPosition;
    private float journeyLength;
    private float scale;
    private float sleepCounter;
    private bool sleeping;
    private float speed;
    private Vector3 startPosition;
    private float timeSleep;
    private float timeStart;
    private float timeTravel;
    private int[] xPositions;
    private int[] yPositions;

    public DecoCloud()
    {
        int[] numArray1;
        this.yPositions = new int[] { 0x1e2, 0x285, -632, -439 };
        numArray1 = new int[] { -1180, 0x49c };
        this.xPositions = numArray1;
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.sleeping != null)
        {
            goto Label_00F3;
        }
        num = (Time.time - this.timeStart) * this.speed;
        num2 = num / this.journeyLength;
        base.transform.position = Vector3.Lerp(this.startPosition, this.endPosition, num2);
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), -5f);
        if (&base.transform.position.x != &this.endPosition.x)
        {
            goto Label_00F3;
        }
        if (&base.transform.position.y != &this.endPosition.y)
        {
            goto Label_00F3;
        }
        this.sleeping = 1;
        this.timeSleep = UnityEngine.Random.Range(5f, 15f);
    Label_00F3:
        return;
    }

    public bool IsSleeping()
    {
        return this.sleeping;
    }

    public void Launch()
    {
        this.sleeping = 0;
        this.timeStart = Time.time;
        this.SetRandomStats();
        return;
    }

    private void SetRandomStats()
    {
        float num;
        float num2;
        num = (float) this.xPositions[0];
        if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
        {
            goto Label_0039;
        }
        num2 = (float) UnityEngine.Random.Range(0x1e2, 0x286);
        goto Label_004A;
    Label_0039:
        num2 = (float) UnityEngine.Random.Range(-632, -440);
    Label_004A:
        this.startPosition = new Vector3(num, num2, -5f);
        this.endPosition = new Vector3(-num, num2, -5f);
        this.journeyLength = Vector3.Distance(this.startPosition, this.endPosition);
        base.transform.position = this.startPosition;
        this.timeTravel = UnityEngine.Random.Range(40f, 75f);
        this.speed = this.journeyLength / this.timeTravel;
        this.scale = UnityEngine.Random.Range(0.5f, 1f);
        base.transform.localScale = new Vector3(this.scale, this.scale, 1f);
        return;
    }

    private void Start()
    {
        this.sleeping = 1;
        this.timeSleep = UnityEngine.Random.Range(5f, 30f);
        return;
    }
}

