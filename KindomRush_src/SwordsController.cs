using System;
using UnityEngine;

public class SwordsController : MonoBehaviour
{
    private PackedSprite sprite;
    public SoldierHeroSamuraiSwordEffect swordPrefab;

    public SwordsController()
    {
        base..ctor();
        return;
    }

    protected void SpawnAll()
    {
        base.Invoke("SpawnCircle1", 0.01f);
        base.Invoke("SpawnCircle2", 0.2f);
        base.Invoke("SpawnCircle3", 0.3f);
        return;
    }

    protected unsafe void SpawnCircle(int width)
    {
        int num;
        int num2;
        Vector2 vector;
        SoldierHeroSamuraiSwordEffect effect;
        width = UnityEngine.Random.Range(width - 5, width + 5);
        num = UnityEngine.Random.Range(0, 360);
        num2 = 0;
        goto Label_007F;
    Label_0020:
        vector = IronUtils.ellipseGetPointOfDegree((float) num, (float) Mathf.RoundToInt(((float) width) * 0.7f), (float) width, base.transform.position);
        effect = UnityEngine.Object.Instantiate(this.swordPrefab, new Vector3(&vector.x, &vector.y, -890f), Quaternion.identity) as SoldierHeroSamuraiSwordEffect;
        num += 0x2d;
        num2 += 1;
    Label_007F:
        if (num2 < 8)
        {
            goto Label_0020;
        }
        return;
    }

    protected void SpawnCircle1()
    {
        this.SpawnCircle(0x38);
        return;
    }

    protected void SpawnCircle2()
    {
        this.SpawnCircle(0x6a);
        return;
    }

    protected void SpawnCircle3()
    {
        this.SpawnCircle(0x9b);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.SpawnAll();
        return;
    }
}

