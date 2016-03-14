using System;
using UnityEngine;

public class EnemyModifierFallenKnightAura : EnemyModifier
{
    private int addedMaxDamage;
    private int addedMinDamage;

    public EnemyModifierFallenKnightAura()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.durationTimer += 1f;
        if (base.durationTimer < base.duration)
        {
            goto Label_003B;
        }
        this.Remove();
        UnityEngine.Object.Destroy(this);
    Label_003B:
        return;
    }

    private void Remove()
    {
        CreepFallenKnight knight;
        base.target.minDamage -= this.addedMinDamage;
        base.target.maxDamage -= this.addedMaxDamage;
        knight = (CreepFallenKnight) base.target;
        knight.HideAuraEffect();
        return;
    }

    public override void ResetToLevel(int lvl)
    {
        base.durationTimer = 0f;
        return;
    }

    public void SetTarget(Creep c)
    {
        base.target = c;
        return;
    }

    private void Start()
    {
        CreepFallenKnight knight;
        base.target = base.GetComponent<Creep>();
        base.duration = 6f;
        knight = (CreepFallenKnight) base.target;
        knight.ShowAuraEffect();
        this.addedMinDamage = base.target.minDamage * (knight.bonusAuraPercent / 100);
        this.addedMaxDamage = base.target.maxDamage * (knight.bonusAuraPercent / 100);
        base.target.minDamage += this.addedMinDamage;
        base.target.maxDamage += this.addedMaxDamage;
        return;
    }
}

