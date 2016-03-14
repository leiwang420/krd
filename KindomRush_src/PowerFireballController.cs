using System;
using UnityEngine;

public class PowerFireballController : MonoBehaviour
{
    private int durationCataclysmTime;
    private int durationCataclysmTimeCounter;
    private int durationTime;
    private int durationTimeCounter;
    public Transform fireballPrefab;
    private bool hasCataclysm;
    private Vector2 initPoint;
    private bool isPaused;
    private int maxDesviation;
    private int maxHeight;
    private int minDesviation;
    private int minHeight;
    private StageBase stage;
    private Vector2 targetPoint;

    public PowerFireballController()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.durationTime != this.durationTimeCounter)
        {
            goto Label_0030;
        }
        if (this.hasCataclysm != null)
        {
            goto Label_0030;
        }
        base.enabled = 0;
        return;
    Label_0030:
        if (this.hasCataclysm == null)
        {
            goto Label_0054;
        }
        if (this.durationCataclysmTime != this.durationCataclysmTimeCounter)
        {
            goto Label_0054;
        }
        base.enabled = 0;
        return;
    Label_0054:
        this.durationTimeCounter += 1;
        this.durationCataclysmTimeCounter += 1;
        if (this.durationTimeCounter >= this.durationTime)
        {
            goto Label_0095;
        }
        if ((this.durationTimeCounter % 10) != null)
        {
            goto Label_0095;
        }
        this.FreeFireball();
    Label_0095:
        if (this.hasCataclysm == null)
        {
            goto Label_00C5;
        }
        if (this.durationCataclysmTimeCounter >= this.durationCataclysmTime)
        {
            goto Label_00C5;
        }
        if ((this.durationCataclysmTimeCounter % 10) != null)
        {
            goto Label_00C5;
        }
        this.FreeFireballCataclysm();
    Label_00C5:
        return;
    }

    private unsafe void FreeFireball()
    {
        float num;
        float num2;
        float num3;
        float num4;
        Vector2 vector;
        Transform transform;
        num = this.GetSign();
        num2 = this.GetSign();
        num3 = &this.initPoint.x + (num * ((float) UnityEngine.Random.Range(this.minDesviation, this.maxDesviation + 1)));
        num4 = 540f;
        &vector = new Vector2(&this.targetPoint.x + (num * ((float) UnityEngine.Random.Range(this.minDesviation, this.maxDesviation + 1))), &this.targetPoint.y + (num2 * ((float) UnityEngine.Random.Range(this.minDesviation, this.maxDesviation + 1))));
        transform = UnityEngine.Object.Instantiate(this.fireballPrefab, new Vector3(num3, num4, -900f), Quaternion.identity) as Transform;
        transform.GetComponent<PowerFireball>().InitWithPosition(new Vector2(num3, num4), vector);
        this.stage.AddProjectile(transform);
        return;
    }

    private unsafe void FreeFireballCataclysm()
    {
        Vector2 vector;
        float num;
        float num2;
        Transform transform;
        vector = this.GetCataclysmDestination();
        num = &vector.x;
        num2 = 540f;
        transform = UnityEngine.Object.Instantiate(this.fireballPrefab, new Vector3(num, num2, -900f), Quaternion.identity) as Transform;
        transform.GetComponent<PowerFireball>().InitWithPosition(new Vector2(num, num2), vector);
        this.stage.AddProjectile(transform);
        return;
    }

    private unsafe Vector2 GetCataclysmDestination()
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        int num3;
        vectorArray = this.stage.GetPath();
        num = 0;
        num2 = UnityEngine.Random.Range(0, (int) vectorArray.Length);
        num3 = 0;
        num = UnityEngine.Random.Range(0, (int) vectorArray[num2][num3].Length);
        return *(&(vectorArray[num2][num3][num]));
    }

    private float GetRandomHeight()
    {
        return (float) UnityEngine.Random.Range(this.minHeight, this.maxHeight + 1);
    }

    private float GetSign()
    {
        if (((double) UnityEngine.Random.Range(0f, 1f)) < 0.5)
        {
            goto Label_0024;
        }
        return 1f;
    Label_0024:
        return -1f;
    }

    public unsafe void InitWithPosition(Vector2 pos)
    {
        this.targetPoint = pos;
        this.initPoint = new Vector2(&this.targetPoint.x, &this.targetPoint.y);
        this.durationTime = 0x1f;
        this.durationTimeCounter = 0;
        this.durationCataclysmTime = 0x33;
        this.durationCataclysmTimeCounter = 0;
        this.minHeight = 0x20a;
        this.maxHeight = 540;
        this.minDesviation = 0;
        this.maxDesviation = 0x1c;
        if (GameUpgrades.RainUpBlazingSkies == null)
        {
            goto Label_0084;
        }
        this.durationTime += 20;
    Label_0084:
        if (GameUpgrades.RainUpBiggerAndMeaner == null)
        {
            goto Label_00BE;
        }
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_00AF;
        }
        if (this.stage.MaxUpgradeLevel < 3)
        {
            goto Label_00BE;
        }
    Label_00AF:
        this.maxDesviation += 10;
    Label_00BE:
        if (GameUpgrades.RainUpCataclysm == null)
        {
            goto Label_00F5;
        }
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_00E9;
        }
        if (this.stage.MaxUpgradeLevel != 5)
        {
            goto Label_00F5;
        }
    Label_00E9:
        this.hasCataclysm = 1;
        goto Label_00FC;
    Label_00F5:
        this.hasCataclysm = 0;
    Label_00FC:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void Start()
    {
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

