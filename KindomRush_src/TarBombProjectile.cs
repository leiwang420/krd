using System;
using UnityEngine;

public class TarBombProjectile : Arrow
{
    private int level;
    public TarBomb tarBombPrefab;

    public TarBombProjectile()
    {
        base..ctor();
        return;
    }

    protected override unsafe void Rotate()
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        float num6;
        Vector3 vector;
        Vector3 vector2;
        base.t0 += 1f;
        num = (base.yOrig + (base.t0 * base.ySpeed)) + (((base.g * base.t0) * base.t0) / 2f);
        num2 = base.xOrig + (base.t0 * base.xSpeed);
        base.t0 -= 1f;
        num3 = num - &base.transform.position.y;
        num4 = num2 - &base.transform.position.x;
        num5 = Mathf.Atan2(num3, num4);
        num6 = 180f - ((Mathf.Atan2(Mathf.Sin(num5) * 20f, Mathf.Cos(num5) * 20f) * 180f) / 3.14f);
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(0f, 0f, -num6);
        return;
    }

    public void SetLevel(int l)
    {
        this.level = l;
        return;
    }

    public override unsafe void ShowDecal()
    {
        TarBomb bomb;
        Vector3 vector;
        Vector3 vector2;
        GameSoundManager.PlayHeroDwarfBreaHit();
        bomb = UnityEngine.Object.Instantiate(this.tarBombPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -1f), Quaternion.identity) as TarBomb;
        bomb.SetLevel(this.level);
        bomb.SetStage(base.stage);
        base.stage.AddProjectile(bomb.transform);
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }
}

