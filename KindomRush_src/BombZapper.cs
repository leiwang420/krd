using System;
using System.Collections;
using UnityEngine;

public class BombZapper : Bomb
{
    public BombZapper()
    {
        base..ctor();
        return;
    }

    protected override unsafe int CalculateDamage()
    {
        float num;
        Vector2 vector;
        float num2;
        float num3;
        float num4;
        int num5;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        num = (Mathf.Atan2(&base.targetSoldier.transform.position.x - base.xDest, &base.targetSoldier.transform.position.y - base.yDest) * 180f) / 3.141593f;
        vector = IronUtils.ellipseGetPointOfDegree(num, base.area * 0.7f, base.area, new Vector2(base.xDest, base.yDest));
        num2 = Mathf.Sqrt(((&vector.x - base.xDest) * (&vector.x - base.xDest)) + ((&vector.y - base.yDest) * (&vector.y - base.yDest)));
        num3 = Mathf.Sqrt(((&base.targetSoldier.transform.position.x - base.xDest) * (&base.targetSoldier.transform.position.x - base.xDest)) + ((&base.targetSoldier.transform.position.y - &base.transform.position.y) * (&base.targetSoldier.transform.position.y - &base.transform.position.y)));
        num4 = (float) (base.maxDamage - base.minDamage);
        num5 = ((int) (num4 - ((num3 * num4) / num2))) + base.minDamage;
        return num5;
    }

    public override void Hit()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_00A1;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_00A1;
            }
            if (IronUtils.ellipseContainPoint(soldier.transform.position, base.area * 0.7f, base.area, base.transform.position) == null)
            {
                goto Label_00A1;
            }
            base.targetSoldier = soldier.GetComponent<Soldier>();
            if ((base.targetSoldier != null) == null)
            {
                goto Label_00A1;
            }
            if (base.targetSoldier.IsActive() == null)
            {
                goto Label_00A1;
            }
            base.targetSoldier.SetDamage(this.CalculateDamage(), 0);
        Label_00A1:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00C3;
        }
        finally
        {
        Label_00B1:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00BC;
            }
        Label_00BC:
            disposable.Dispose();
        }
    Label_00C3:
        return;
    }

    private void Start()
    {
        base.Init();
        GameSoundManager.PlayBombShootSound();
        return;
    }
}

