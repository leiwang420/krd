using System;
using UnityEngine;

public class VeznanSoulController : MonoBehaviour
{
    private int initTime;
    private int initTimeCounter;
    private int particleCurrent;
    private int particleMax;
    private float particleMaxAngle;
    private float particleMinAngle;
    private Vector3 particlePoint;
    private int particleTime;
    private int particleTimeCounter;
    public Transform soulPrefab;

    public VeznanSoulController()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        Transform transform;
        Transform transform2;
        if (this.initTimeCounter >= this.initTime)
        {
            goto Label_0020;
        }
        this.initTimeCounter += 1;
        return;
    Label_0020:
        if (this.particleMax != this.particleCurrent)
        {
            goto Label_0032;
        }
        return;
    Label_0032:
        if (this.particleTimeCounter >= this.particleTime)
        {
            goto Label_0052;
        }
        this.particleTimeCounter += 1;
        return;
    Label_0052:
        if (UnityEngine.Random.Range(0f, 1f) <= 0.75f)
        {
            goto Label_00A9;
        }
        transform = UnityEngine.Object.Instantiate(this.soulPrefab, this.particlePoint, Quaternion.identity) as Transform;
        transform.GetComponent<VeznanSoul>().SetAngle(UnityEngine.Random.Range(this.particleMinAngle, this.particleMaxAngle + 1f));
    Label_00A9:
        transform2 = UnityEngine.Object.Instantiate(this.soulPrefab, this.particlePoint, Quaternion.identity) as Transform;
        transform2.GetComponent<VeznanSoul>().SetAngle(UnityEngine.Random.Range(this.particleMinAngle, this.particleMaxAngle + 1f));
        this.particleCurrent += 1;
        this.particleTimeCounter = 0;
        if (this.particleTime < 2)
        {
            goto Label_0116;
        }
        this.particleTime -= 1;
    Label_0116:
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        this.particlePoint = new Vector3(&base.transform.position.x, &base.transform.position.y - 60f, -890f);
        this.particleMax = 60;
        this.particleCurrent = 0;
        this.particleMaxAngle = 130f;
        this.particleMinAngle = 30f;
        this.particleTime = 10;
        this.particleTimeCounter = 10;
        return;
    }
}

