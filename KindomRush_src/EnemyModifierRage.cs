using System;
using UnityEngine;

public class EnemyModifierRage : EnemyModifier
{
    private int addedArmor;
    private int addedMaxDamage;
    private int addedMinDamage;
    private float addedSpeed;
    private int healingPoints;

    public EnemyModifierRage()
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
            goto Label_0040;
        }
        this.Remove();
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0040:
        return;
    }

    private void Remove()
    {
        base.target.minDamage -= this.addedMinDamage;
        base.target.maxDamage -= this.addedMaxDamage;
        base.target.speed -= this.addedSpeed;
        base.target.RemoveArmor(this.addedArmor);
        if (base.target.speed > 0f)
        {
            goto Label_0079;
        }
        base.target.ResetSpeed();
    Label_0079:
        return;
    }

    public void SetTarget(Creep c)
    {
        base.target = c;
        return;
    }

    public override void Show()
    {
        base.GetComponent<PackedSprite>().Hide(0);
        return;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, &base.transform.parent.position.z + 1f);
        base.duration = 180f;
        this.healingPoints = 50;
        this.addedMinDamage = 15;
        this.addedMaxDamage = 30;
        this.addedSpeed = 1.44f;
        this.addedArmor = 50;
        base.target.Heal(this.healingPoints);
        base.target.minDamage += this.addedMinDamage;
        base.target.maxDamage += this.addedMaxDamage;
        base.target.speed += this.addedSpeed;
        base.target.armor += this.addedArmor;
        return;
    }
}

