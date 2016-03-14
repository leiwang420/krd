using System;
using UnityEngine;

public class CreepTrollAxe : CreepShadowArcher
{
    public CreepTrollAxe()
    {
        base..ctor();
        return;
    }

    protected override unsafe void FireArrow()
    {
        Transform transform;
        int num;
        Axe axe;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        transform = UnityEngine.Object.Instantiate(base.arrowPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -900f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.localScale = new Vector3(1f, 1f, 1f);
        if (&this.destinyPoint.x < &base.transform.position.x)
        {
            goto Label_0098;
        }
        num = 1;
        goto Label_009A;
    Label_0098:
        num = -1;
    Label_009A:
        axe = transform.GetComponent<Axe>();
        axe.SetT1(25f);
        axe.SetTarget(base.arrowTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        axe.SetDamage(base.GetArrowDamage());
        axe.SetRotation(num);
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.arrowReloadTime = 30;
        base.arrowRangeWidth = 0x199 + UnityEngine.Random.Range(-100, 0x2b);
        base.arrowRangeHeight = Mathf.RoundToInt(((float) base.arrowRangeWidth) * 0.7f);
        base.arrowMinRange = 0x4d;
        base.arrowMinDamage = 40;
        base.arrowMaxDamage = 80;
        base.arrowChargeTime = 15;
        base.regenerateTime = 5;
        base.regenerateHealPoints = 2;
        return;
    }

    protected virtual unsafe void SetDestinyPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        base.destinyPoint = new Vector2(&base.arrowTarget.transform.position.x, &base.arrowTarget.transform.position.y - 18f);
        return;
    }
}

