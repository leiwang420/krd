using System;

public class SuperchargeAbility : AbilityBase
{
    private int jumpMax;

    public SuperchargeAbility()
    {
        this.jumpMax = 3;
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public int GetJumpMax()
    {
        return this.jumpMax;
    }

    public override void LevelUp()
    {
        base.level += 1;
        this.jumpMax += 1;
        return;
    }

    private void Start()
    {
        base.tower = base.transform.GetComponent<TeslaTower>();
        return;
    }
}

