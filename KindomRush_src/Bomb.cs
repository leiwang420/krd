using System;
using System.Collections;
using UnityEngine;

public class Bomb : Parabola
{
    protected float area;
    public Transform explosionPrefab;
    public float explosionYAdjust;
    protected int maxDamage;
    protected int minDamage;
    protected int rotDir;

    public Bomb()
    {
        this.explosionYAdjust = 20f;
        this.rotDir = 1;
        base..ctor();
        return;
    }

    protected virtual unsafe int CalculateDamage()
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
        if (GameUpgrades.EngineersUpEfficiency == null)
        {
            goto Label_0032;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_002B;
        }
        if (base.stage.MaxUpgradeLevel != 5)
        {
            goto Label_0032;
        }
    Label_002B:
        return this.maxDamage;
    Label_0032:
        num = (Mathf.Atan2(&base.target.transform.position.x - base.xDest, &base.target.transform.position.y - base.yDest) * 180f) / 3.141593f;
        vector = IronUtils.ellipseGetPointOfDegree(num, this.area * 0.7f, this.area, new Vector2(base.xDest, base.yDest));
        num2 = Mathf.Sqrt(((&vector.x - base.xDest) * (&vector.x - base.xDest)) + ((&vector.y - base.yDest) * (&vector.y - base.yDest)));
        num3 = Mathf.Sqrt(((&base.target.transform.position.x - base.xDest) * (&base.target.transform.position.x - base.xDest)) + ((&base.target.transform.position.y - &base.transform.position.y) * (&base.target.transform.position.y - &base.transform.position.y)));
        num4 = (float) (this.maxDamage - this.minDamage);
        num5 = ((int) (num4 - ((num3 * num4) / num2))) + this.minDamage;
        return num5;
    }

    protected void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.Rotate();
        base.Travel();
        if (this.TravelEnd() == null)
        {
            goto Label_003B;
        }
        this.PlayExplosionSound();
        this.Hit();
        this.ShowExplosion();
        this.ShowDecal();
    Label_003B:
        return;
    }

    public override void Hit()
    {
        GameObject obj2;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = GameObject.Find("Spawner").transform.GetEnumerator();
    Label_0017:
        try
        {
            goto Label_00C9;
        Label_001C:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (IronUtils.ellipseContainPoint(transform.position + creep.anchorPoint, this.area * 0.7f, this.area, base.transform.position) == null)
            {
                goto Label_00C9;
            }
            if ((transform != null) == null)
            {
                goto Label_00C9;
            }
            base.target = (Creep) transform.GetComponent("Creep");
            if (base.target.IsActive() == null)
            {
                goto Label_00C9;
            }
            base.target.Damage(this.CalculateDamage(), 3, 0, 0);
            if (base.target.GetHealth() > 0)
            {
                goto Label_00C9;
            }
            base.target.Gib();
        Label_00C9:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001C;
            }
            goto Label_00EE;
        }
        finally
        {
        Label_00D9:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E6;
            }
        Label_00E6:
            disposable.Dispose();
        }
    Label_00EE:
        return;
    }

    protected virtual void PlayExplosionSound()
    {
        GameSoundManager.PlayBombExplosionSound();
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
        if (base.spinning == null)
        {
            goto Label_002F;
        }
        base.transform.Rotate(0f, 0f, (float) (20 * this.rotDir));
        goto Label_0134;
    Label_002F:
        base.t0 += 1f;
        num = (base.yOrig + (base.t0 * base.ySpeed)) + (((base.g * base.t0) * base.t0) / 2f);
        num2 = base.xOrig + (base.t0 * base.xSpeed);
        base.t0 -= 1f;
        num3 = num - &base.transform.position.y;
        num4 = num2 - &base.transform.position.x;
        num5 = Mathf.Atan2(num3, num4);
        num6 = (float) (180.0 - (((double) (Mathf.Atan2(Mathf.Sin(num5) * 20f, Mathf.Cos(num5) * 20f) * 180f)) / 3.14));
        base.transform.rotation = Quaternion.identity;
        base.transform.Rotate(0f, 0f, -num6);
    Label_0134:
        return;
    }

    public void SetArea(float a)
    {
        this.area = a;
        return;
    }

    public void SetDamage(int min, int max)
    {
        this.minDamage = min;
        this.maxDamage = max;
        return;
    }

    protected virtual unsafe void ShowExplosion()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.explosionPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + this.explosionYAdjust, -840f), Quaternion.identity) as Transform;
        base.stage.AddExplosion(transform);
        return;
    }

    private void Start()
    {
        base.Init();
        GameSoundManager.PlayBombShootSound();
        return;
    }
}

