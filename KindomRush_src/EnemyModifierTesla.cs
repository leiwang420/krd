using System;
using UnityEngine;

public class EnemyModifierTesla : EnemyModifier
{
    private int damage;
    private int damageBase;
    private float damageTime;
    private float damageTimeCounter;

    public EnemyModifierTesla()
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
            goto Label_005E;
        }
        base.durationTimer += Time.deltaTime;
        this.damageTimeCounter += Time.deltaTime;
        if (base.durationTimer < base.duration)
        {
            goto Label_005E;
        }
        base.target.HideTeslaHit();
        return;
    Label_005E:
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
        this.damage = 0;
        this.damageBase = 0;
        this.damageTime = 0f;
        this.damageTimeCounter = 0f;
        base.durationTimer = 20f;
        base.duration = 20f;
        base.target = base.GetComponent<Creep>();
        if ((base.target != null) == null)
        {
            goto Label_0076;
        }
        base.target.ShowTeslaHit();
        MonoBehaviour.print("INSIDE IT");
        Debug.Log("INSIDE IT");
    Label_0076:
        return;
    }
}

