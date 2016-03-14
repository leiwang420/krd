using System;
using UnityEngine;

public class EnemyModifierPoison : EnemyModifier
{
    private int damage;
    private int damageBase;
    private float damageTime;
    private float damageTimeCounter;

    public EnemyModifierPoison()
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
        if ((base.target != null) == null)
        {
            goto Label_00A3;
        }
        base.durationTimer += Time.deltaTime;
        this.damageTimeCounter += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_005E;
        }
        base.target.HidePoison();
        return;
    Label_005E:
        if (this.damageTimeCounter < this.damageTime)
        {
            goto Label_00A3;
        }
        this.damageTimeCounter = 0f;
        base.target.Damage(this.damage, 0, 0, 0);
        if (base.target.IsDead() == null)
        {
            goto Label_00A3;
        }
        GameAchievements.PoisonEnemy();
    Label_00A3:
        return;
    }

    public override void ResetToLevel(int lvl)
    {
        this.SetProperties(lvl);
        base.durationTimer = 0f;
        this.damageTimeCounter = 0f;
        return;
    }

    public override void SetProperties(int l)
    {
        this.damage = this.damageBase * l;
        base.level = l;
        return;
    }

    public override void Show()
    {
    }

    private void Start()
    {
        this.damage = 5;
        this.damageBase = 5;
        this.damageTime = 1f;
        this.damageTimeCounter = 0f;
        base.durationTimer = 0f;
        base.duration = 3f;
        base.target = base.GetComponent<Creep>();
        if ((base.target != null) == null)
        {
            goto Label_0062;
        }
        base.target.ShowPoison();
    Label_0062:
        return;
    }
}

