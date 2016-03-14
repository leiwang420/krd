using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepRottenLesser : Creep
{
    protected bool exploded;
    protected int explodeDamageTime;
    public int explodeMaxDamage;
    public int explodeMinDamage;
    protected int explodeRangeHeight;
    protected int explodeRangeWidth;

    public CreepRottenLesser()
    {
        base..ctor();
        return;
    }

    public override void BloodSplatter()
    {
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        base.Damage(dmg, damageType, ignoreArmor, shieldOn);
        if (base.life > 0)
        {
            goto Label_002F;
        }
        if (this.exploded != null)
        {
            goto Label_002F;
        }
        this.exploded = 1;
        this.LesserExplodeAttack();
    Label_002F:
        return;
    }

    public override bool evalRespawn()
    {
        if (base.respawnTimeCounter != 1)
        {
            goto Label_0011;
        }
        GameSoundManager.PlayMushroomCreepBorn();
    Label_0011:
        return base.evalRespawn();
    }

    protected override void InitCustomSettings()
    {
        this.explodeRangeWidth = 170;
        this.explodeRangeHeight = Mathf.RoundToInt(((float) this.explodeRangeWidth) * 0.7f);
        this.explodeDamageTime = 5;
        base.isRespawning = 1;
        base.isActive = 0;
        base.respawnTimeCounter = 0;
        return;
    }

    protected void LesserExplodeAttack()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        SoldierModifierPoison poison;
        IDisposable disposable;
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0015:
        try
        {
            goto Label_0095;
        Label_001A:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_0095;
            }
            if (soldier.IsDead() != null)
            {
                goto Label_0095;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_0095;
            }
            if (this.OnRangeExplode(soldier) == null)
            {
                goto Label_0095;
            }
            poison = soldier.GetComponent<SoldierModifierPoison>();
            if ((poison != null) == null)
            {
                goto Label_007C;
            }
            poison.ResetToLevel(1);
            soldier.ShowPoison();
            goto Label_0091;
        Label_007C:
            soldier.gameObject.AddComponent<SoldierModifierPoison>().SetProperties(1);
        Label_0091:
            num += 1;
        Label_0095:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
            goto Label_00BA;
        }
        finally
        {
        Label_00A5:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B2;
            }
        Label_00B2:
            disposable.Dispose();
        }
    Label_00BA:
        if (num != null)
        {
            goto Label_00C5;
        }
        GameAchievements.SporeFunc();
    Label_00C5:
        return;
    }

    protected bool OnRangeExplode(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), (float) this.explodeRangeHeight, (float) this.explodeRangeWidth, base.transform.position + base.anchorPoint);
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayMushroomCreepDeath();
        return;
    }
}

