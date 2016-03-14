using System;
using UnityEngine;

public class DenasBuff : MonoBehaviour
{
    public Transform denasBuffCirclePrefab;
    private PackedSprite sprite;
    private float timeCounter;
    private float timeLifeCounter;

    public DenasBuff()
    {
        base..ctor();
        return;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        this.timeCounter += Time.deltaTime;
        this.timeLifeCounter += Time.deltaTime;
        if (this.timeCounter < 0.4f)
        {
            goto Label_00A2;
        }
        transform = UnityEngine.Object.Instantiate(this.denasBuffCirclePrefab, new Vector3(&base.transform.position.x + 5f, &base.transform.position.y - 34f, -1f), Quaternion.identity) as Transform;
        transform.parent = base.transform.parent;
        this.timeCounter = 0f;
    Label_00A2:
        if (this.timeLifeCounter < 2.76f)
        {
            goto Label_00BD;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00BD:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        return;
    }
}

