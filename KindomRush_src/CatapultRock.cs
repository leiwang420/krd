using System;
using UnityEngine;

public class CatapultRock : Bomb
{
    private int level;
    public Transform particlePrefab;
    private Vector2 prevPos;

    public CatapultRock()
    {
        base..ctor();
        return;
    }

    protected void AddParticleWithPosition(float x, float y)
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.particlePrefab, new Vector3(x, y, -890f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        return;
    }

    protected override void InitCustom()
    {
        base.area = GameSettings.GetHeroSetting("hero_denas", "catapultRangeRock", 1);
        base.minDamage = ((int) GameSettings.GetHeroSetting("hero_denas", "catapultMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_denas", "catapultDamageIncrement", 1)) * this.level);
        base.maxDamage = ((int) GameSettings.GetHeroSetting("hero_denas", "catapultMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_denas", "catapultDamageIncrement", 1)) * this.level);
        this.prevPos = Vector2.zero;
        base.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
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
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
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
        this.AddParticleWithPosition(&base.transform.position.x, &base.transform.position.y);
        if (&this.prevPos.x == 0f)
        {
            goto Label_01B9;
        }
        if (&this.prevPos.y == 0f)
        {
            goto Label_01B9;
        }
        vector = new Vector2(&base.transform.position.x, &base.transform.position.y) + this.prevPos;
        vector *= 0.5f;
        this.AddParticleWithPosition(&vector.x, &vector.y);
    Label_01B9:
        this.prevPos = new Vector2(&base.transform.position.x, &base.transform.position.y);
        return;
    }

    public void SetLevel(int l)
    {
        this.level = l;
        return;
    }

    private void Start()
    {
        base.Init();
        return;
    }
}

