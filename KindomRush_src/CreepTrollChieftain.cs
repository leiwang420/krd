using System;
using System.Collections;
using UnityEngine;

public class CreepTrollChieftain : Creep
{
    private bool isRaging;
    private int rageAnimationOneTime;
    private int rageAnimationSecondTime;
    private int rageAnimationThirdTime;
    private int rageAnimationTime;
    private int rageAnimationTimeCounter;
    private int rageCooldownTime;
    private int rageCooldownTimeCounter;
    private int rageMaxEnemies;
    public EnemyModifierRage rageModifier;
    private int rageRangeHeight;
    private int rageRangeWidth;

    public CreepTrollChieftain()
    {
        base..ctor();
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        this.isRaging = 0;
        base.creepSprite.RevertToStatic();
        return;
    }

    private bool FCanRage(Creep target)
    {
        if ((target.transform.FindChild("Rage") == null) == null)
        {
            goto Label_0038;
        }
        if ((target.transform.FindChild("Slow") == null) == null)
        {
            goto Label_0038;
        }
        return 1;
    Label_0038:
        return 0;
    }

    private float GetOffset(Creep creep)
    {
        return (Mathf.Round(creep.GetComponent<PackedSprite>().height / 2f) - 20f);
    }

    private bool HasRageTargets()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        bool flag;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0080;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0080;
            }
            if (creep.canRage == null)
            {
                goto Label_0080;
            }
            if (this.FCanRage(creep) == null)
            {
                goto Label_0080;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.rageRangeHeight, (float) this.rageRangeWidth, base.transform.position) == null)
            {
                goto Label_0080;
            }
            flag = 1;
            goto Label_00A7;
        Label_0080:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_00A5;
        }
        finally
        {
        Label_0090:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_009D;
            }
        Label_009D:
            disposable.Dispose();
        }
    Label_00A5:
        return 0;
    Label_00A7:
        return flag;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.rageCooldownTime = 180;
        this.rageRangeWidth = 0x1fc;
        this.rageRangeHeight = Mathf.RoundToInt(((float) this.rageRangeWidth) * 0.7f);
        this.rageMaxEnemies = 3;
        this.rageAnimationTime = 50;
        this.rageAnimationOneTime = 7;
        this.rageAnimationSecondTime = 0x16;
        this.rageAnimationThirdTime = 0x26;
        base.regenerateTime = 5;
        base.regenerateHealPoints = 4;
        return;
    }

    private void RageTargets()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        EnemyModifierRage rage;
        IDisposable disposable;
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_00F3;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00F3;
            }
            if (creep.canRage == null)
            {
                goto Label_00F3;
            }
            if (this.FCanRage(creep) == null)
            {
                goto Label_00F3;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.rageRangeHeight, (float) this.rageRangeWidth, base.transform.position) == null)
            {
                goto Label_00F3;
            }
            rage = UnityEngine.Object.Instantiate(this.rageModifier, creep.transform.position - new Vector3(0f, this.GetOffset(creep), 0f), Quaternion.identity) as EnemyModifierRage;
            rage.name = "Rage";
            rage.SetTarget(creep);
            rage.transform.parent = creep.transform;
            num += 1;
            if (num != this.rageMaxEnemies)
            {
                goto Label_00F3;
            }
            goto Label_00FE;
        Label_00F3:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
        Label_00FE:
            goto Label_0118;
        }
        finally
        {
        Label_0103:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0110;
            }
        Label_0110:
            disposable.Dispose();
        }
    Label_0118:
        return;
    }

    protected override bool SpecialPower()
    {
        if (base.isBlocked == null)
        {
            goto Label_0014;
        }
        this.rageCooldownTimeCounter = 0;
        return 0;
    Label_0014:
        if (this.isRaging != null)
        {
            goto Label_006D;
        }
        if (this.rageCooldownTimeCounter >= this.rageCooldownTime)
        {
            goto Label_0040;
        }
        this.rageCooldownTimeCounter += 1;
        return 0;
    Label_0040:
        if (this.HasRageTargets() != null)
        {
            goto Label_004D;
        }
        return 0;
    Label_004D:
        this.isRaging = 1;
        base.creepSprite.PlayAnim("special");
        this.rageAnimationTimeCounter = 0;
        return 1;
    Label_006D:
        if (this.rageAnimationTimeCounter >= this.rageAnimationTime)
        {
            goto Label_0109;
        }
        this.rageAnimationTimeCounter += 1;
        if (this.rageAnimationTimeCounter == this.rageAnimationOneTime)
        {
            goto Label_00BF;
        }
        if (this.rageAnimationTimeCounter == this.rageAnimationSecondTime)
        {
            goto Label_00BF;
        }
        if (this.rageAnimationTimeCounter != this.rageAnimationThirdTime)
        {
            goto Label_0107;
        }
    Label_00BF:
        this.RageTargets();
        if (this.rageAnimationTimeCounter != this.rageAnimationOneTime)
        {
            goto Label_00DB;
        }
        GameSoundManager.PlayEnemyChieftain();
    Label_00DB:
        if (this.rageAnimationTimeCounter != this.rageAnimationSecondTime)
        {
            goto Label_00F1;
        }
        GameSoundManager.PlayEnemyChieftain();
    Label_00F1:
        if (this.rageAnimationTimeCounter != this.rageAnimationThirdTime)
        {
            goto Label_0107;
        }
        GameSoundManager.PlayEnemyChieftain();
    Label_0107:
        return 1;
    Label_0109:
        this.isRaging = 0;
        this.rageCooldownTimeCounter = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_012F;
        }
        this.CheckFacing();
    Label_012F:
        return 0;
    }
}

