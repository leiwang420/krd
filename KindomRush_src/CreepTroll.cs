using System;

public class CreepTroll : Creep
{
    public CreepTroll()
    {
        base..ctor();
        return;
    }

    protected override void DoSpecial()
    {
        base.life += base.regenerateHealPoints;
        if (base.life <= base.totalLife)
        {
            goto Label_0030;
        }
        base.life = base.totalLife;
    Label_0030:
        return;
    }

    protected override void InitCustomSettings()
    {
        int num;
        base.basicCooldownTime = base.regenerateTime = 5;
        base.regenerateHealPoints = 1;
        base.basicAnimationStartTime = 1;
        base.basicAnimationTime = 1;
        return;
    }
}

