using System;
using UnityEngine;

public class SoldierModifierGiantRatPoison : SoldierModifier
{
    public int damage;
    public float damageReduced;
    public float damageTime;
    public float damageTimeCounter;
    protected int origTargetMaxDamage;
    protected int origTargetMinDamage;
    public int poisonDuration;

    public SoldierModifierGiantRatPoison()
    {
        base..ctor();
        return;
    }

    public void applyWeakness()
    {
        int num;
        int num2;
        num = Mathf.RoundToInt(((float) base.target.minDamage) * (this.damageReduced / 100f));
        num2 = Mathf.RoundToInt(((float) base.target.maxDamage) * (this.damageReduced / 100f));
        Debug.Log(((float) this.damageReduced) + "damageReduced");
        Debug.Log(((int) base.target.maxDamage) + "target.maxDamage");
        Debug.Log(((int) num) + "newDamageMin");
        this.origTargetMaxDamage = base.target.maxDamage;
        this.origTargetMinDamage = base.target.minDamage;
        base.target.minDamage -= num;
        base.target.maxDamage -= num2;
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
            goto Label_009C;
        }
        if (base.target.IsDead() != null)
        {
            goto Label_009C;
        }
        base.durationTimer += Time.deltaTime;
        this.damageTimeCounter += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_006E;
        }
        base.target.HideRatPoison();
        return;
    Label_006E:
        if (this.damageTimeCounter < this.damageTime)
        {
            goto Label_009C;
        }
        this.damageTimeCounter = 0f;
        base.target.SetDamage(this.damage, 1);
    Label_009C:
        return;
    }

    public void removeWeakness()
    {
        base.target.minDamage = this.origTargetMinDamage;
        base.target.maxDamage = this.origTargetMaxDamage;
        return;
    }

    public override void ResetToLevel(int lvl)
    {
        this.SetProperties(lvl);
        return;
    }

    public override void SetProperties(int l)
    {
        base.level = l;
        base.durationTimer = 0f;
        return;
    }

    public override void Show()
    {
    }

    private void Start()
    {
        this.damageTimeCounter = 0f;
        base.durationTimer = 0f;
        base.duration = (float) this.poisonDuration;
        base.target = base.GetComponent<Soldier>();
        if ((base.target != null) == null)
        {
            goto Label_0051;
        }
        base.target.ShowRatPoison();
        this.applyWeakness();
    Label_0051:
        return;
    }
}

