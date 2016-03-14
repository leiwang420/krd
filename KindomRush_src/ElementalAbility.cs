using System;

public class ElementalAbility : AbilityBase
{
    public ElementalAbility()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public override void LevelUp()
    {
        base.level += 1;
        if (base.level != 1)
        {
            goto Label_002F;
        }
        ((SorcererTower) base.tower).SpawnElemental();
        goto Label_0045;
    Label_002F:
        ((SorcererTower) base.tower).UpgradeElemental(base.level);
    Label_0045:
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent("SorcererTower") as SorcererTower;
        return;
    }
}

