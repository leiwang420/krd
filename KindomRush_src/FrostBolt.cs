using System;
using UnityEngine;

public class FrostBolt : Bolt
{
    private int freezeChance;
    private float freezeDuration;
    private int level;
    private float slowDuration;
    private float slowFactor;

    public FrostBolt()
    {
        base..ctor();
        return;
    }

    public override void Hit()
    {
        EnemyModifierSlow slow;
        if ((base.target == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        if (base.target.IsActive() == null)
        {
            goto Label_00C3;
        }
        base.target.Damage(base.damage, 2, 0, 0);
        if (base.target.IsDead() != null)
        {
            goto Label_00C3;
        }
        if (UnityEngine.Random.Range(0, 0x65) >= this.freezeChance)
        {
            goto Label_008A;
        }
        if (base.target.IsBoss() != null)
        {
            goto Label_008A;
        }
        base.target.HitFreeze(Mathf.RoundToInt(this.freezeDuration * 30f));
        goto Label_00C3;
    Label_008A:
        if ((base.target.GetComponent<EnemyModifierSlow>() == null) == null)
        {
            goto Label_00C3;
        }
        base.target.gameObject.AddComponent<EnemyModifierSlow>().Init(this.slowFactor, this.slowDuration);
    Label_00C3:
        return;
    }

    public void Init(int damage, int level)
    {
        base.damage = damage;
        this.level = level;
        base.acceleration = GameSettings.GetHeroSetting("hero_frost_sorcerer", "aceleration", 1);
        base.maxAcceleration = GameSettings.GetHeroSetting("hero_frost_sorcerer", "maxAceleration", 1);
        this.slowFactor = GameSettings.GetHeroSetting("hero_frost_sorcerer", "slowFactor", 1);
        this.slowDuration = GameSettings.GetHeroSetting("hero_frost_sorcerer", "slowDuration", 1);
        this.freezeChance = (int) GameSettings.GetHeroSetting("hero_frost_sorcerer", "freezeChance", 1);
        this.freezeDuration = GameSettings.GetHeroSetting("hero_frost_sorcerer", "freezeDuration", 1);
        return;
    }
}

