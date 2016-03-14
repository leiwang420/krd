using System;

public class PoisonAbility : AbilityBase
{
    public PoisonAbility()
    {
        base..ctor();
        return;
    }

    public void ApplyPoison(Arrow arrow)
    {
        EnemyModifierPoison poison;
        if (base.level <= 0)
        {
            goto Label_0024;
        }
        arrow.gameObject.AddComponent<EnemyModifierPoison>().SetProperties(base.level);
    Label_0024:
        return;
    }

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("ArcherTower") as ArcherTower;
        return;
    }
}

