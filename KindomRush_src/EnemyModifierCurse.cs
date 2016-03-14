using System;
using UnityEngine;

public class EnemyModifierCurse : EnemyModifier
{
    private int armorReduced;
    private float armorReducePercentage;
    private int damage;
    private int damageBase;
    private float damageTime;
    private float damageTimeCounter;

    public EnemyModifierCurse()
    {
        this.damage = 10;
        this.armorReducePercentage = 0.5f;
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
            goto Label_00A5;
        }
        base.durationTimer += Time.deltaTime;
        this.damageTimeCounter += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_0075;
        }
        base.target.HideCurse();
        base.target.AddArmor(this.armorReduced);
        UnityEngine.Object.Destroy(this);
        return;
    Label_0075:
        if (this.damageTimeCounter < this.damageTime)
        {
            goto Label_00A5;
        }
        this.damageTimeCounter = 0f;
        base.target.Damage(this.damage, 0, 0, 0);
    Label_00A5:
        return;
    }

    protected void ReduceArmor()
    {
        this.armorReduced = (int) (((float) base.target.GetTotalArmor()) * this.armorReducePercentage);
        base.target.RemoveArmor(this.armorReduced);
        return;
    }

    public override void ResetToLevel(int lvl)
    {
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
        this.damageTime = 1f;
        base.duration = 5f;
        base.target = base.GetComponent<Creep>();
        base.target.ShowCurse();
        this.ReduceArmor();
        return;
    }
}

