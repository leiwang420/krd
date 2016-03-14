using System;
using System.Collections;
using UnityEngine;

public class CreepBossRotten : Creep
{
    protected int bombChargeTime;
    protected int bombChargeTimeCounter;
    protected int bombMaxBombs;
    protected int bombMaxDamage;
    protected int bombMinDamage;
    public Transform bombPrefab;
    protected int bombReloadTime;
    protected int bombReloadTimeCounter;
    protected bool isBombing;

    public CreepBossRotten()
    {
        base..ctor();
        return;
    }

    public override unsafe void Block(Soldier mySoldier)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.soldier = mySoldier;
        base.isBlocked = 1;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        if (this.isBombing != null)
        {
            goto Label_0077;
        }
        base.creepSprite.RevertToStatic();
    Label_0077:
        return;
    }

    protected bool CanFireBomb()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0036;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() != null)
            {
                goto Label_0036;
            }
            flag = 1;
            goto Label_005D;
        Label_0036:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_005B;
        }
        finally
        {
        Label_0046:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0053;
            }
        Label_0053:
            disposable.Dispose();
        }
    Label_005B:
        return 0;
    Label_005D:
        return flag;
    }

    private void DisableTreantSpawn()
    {
        ((Stage15) base.stage).DisableRottenSpawn();
        return;
    }

    protected unsafe void FireBombs()
    {
        int num;
        ArrayList list;
        ArrayList list2;
        Soldier soldier;
        IEnumerator enumerator;
        Soldier soldier2;
        IEnumerator enumerator2;
        Transform transform;
        BombZapper zapper;
        int num2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        IDisposable disposable2;
        num = 0;
        list = base.stage.GetSoldiers();
        list2 = new ArrayList();
        enumerator = list.GetEnumerator();
    Label_001C:
        try
        {
            goto Label_0041;
        Label_0021:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0041;
            }
            list2.Add(soldier);
        Label_0041:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0021;
            }
            goto Label_0068;
        }
        finally
        {
        Label_0052:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0060;
            }
        Label_0060:
            disposable.Dispose();
        }
    Label_0068:
        num = list2.Count;
        if (num != null)
        {
            goto Label_0076;
        }
        return;
    Label_0076:
        if (num >= this.bombMaxBombs)
        {
            goto Label_0198;
        }
        enumerator2 = list2.GetEnumerator();
    Label_008A:
        try
        {
            goto Label_016C;
        Label_008F:
            soldier2 = (Soldier) enumerator2.Current;
            if (soldier2.IsActive() == null)
            {
                goto Label_016C;
            }
            transform = UnityEngine.Object.Instantiate(this.bombPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 127f, -840f), Quaternion.identity) as Transform;
            zapper = transform.GetComponent<BombZapper>();
            zapper.SetTarget(soldier2, &soldier2.transform.position.x, &soldier2.transform.position.y);
            zapper.SetDamage(this.bombMinDamage, this.bombMaxDamage);
            zapper.SetArea(127f);
            zapper.SetT1(30f);
            zapper.SetStage(base.stage);
        Label_016C:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_008F;
            }
            goto Label_0193;
        }
        finally
        {
        Label_017D:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_018B;
            }
        Label_018B:
            disposable2.Dispose();
        }
    Label_0193:
        goto Label_01BF;
    Label_0198:
        num2 = 0;
        goto Label_01B2;
    Label_01A0:
        this.FireRandomBomb(list2, num);
        num -= 1;
        num2 += 1;
    Label_01B2:
        if (num2 < this.bombMaxBombs)
        {
            goto Label_01A0;
        }
    Label_01BF:
        return;
    }

    protected unsafe void FireRandomBomb(ArrayList tmpSoldiers, int index)
    {
        int num;
        Transform transform;
        Soldier soldier;
        BombZapper zapper;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num = UnityEngine.Random.Range(0, index);
        transform = UnityEngine.Object.Instantiate(this.bombPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 141f, -890f), Quaternion.identity) as Transform;
        soldier = (Soldier) tmpSoldiers[num];
        zapper = transform.GetComponent<BombZapper>();
        zapper.SetTarget(soldier, &soldier.transform.position.x, &soldier.transform.position.y);
        zapper.SetDamage(this.bombMinDamage, this.bombMaxDamage);
        zapper.SetArea(127f);
        zapper.SetT1(30f);
        zapper.SetStage(base.stage);
        tmpSoldiers.RemoveAt(num);
        return;
    }

    protected override unsafe void FixedUpdate()
    {
        Vector3 vector;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.isFading == null)
        {
            goto Label_0042;
        }
        base.fadingTimeCounter += 1;
        if (base.fadingTimeCounter != base.fadingTime)
        {
            goto Label_0041;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0041:
        return;
    Label_0042:
        base.UpdateLifeBar();
        if (base.life > 0)
        {
            goto Label_007F;
        }
        GameAchievements.KillEnemy();
        base.active = 0;
        base.HidePoison();
        base.HideCurse();
        base.ToGraveyard();
        this.DisableTreantSpawn();
        this.Die();
        return;
    Label_007F:
        if (base.active == null)
        {
            goto Label_00A1;
        }
        if (base.isCharging != null)
        {
            goto Label_00A1;
        }
        if (this.SpecialPower() == null)
        {
            goto Label_00A1;
        }
        return;
    Label_00A1:
        if (base.isBlocked == null)
        {
            goto Label_00E3;
        }
        if ((base.soldier == null) != null)
        {
            goto Label_00DD;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_00DD;
        }
        if (base.soldier.IsFighting() != null)
        {
            goto Label_00E3;
        }
    Label_00DD:
        this.StopFighting();
    Label_00E3:
        if (base.isFighting == null)
        {
            goto Label_0182;
        }
        if ((base.soldier == null) != null)
        {
            goto Label_010F;
        }
        if (base.soldier.IsActive() != null)
        {
            goto Label_011A;
        }
    Label_010F:
        this.StopFighting();
        goto Label_017D;
    Label_011A:
        if (base.isCharging == null)
        {
            goto Label_0176;
        }
        if (this.ReadyToDamage() != null)
        {
            goto Label_0131;
        }
        return;
    Label_0131:
        base.isCharging = 0;
        this.Attack();
        if (base.isDead != null)
        {
            goto Label_0154;
        }
        if (base.active != null)
        {
            goto Label_0155;
        }
    Label_0154:
        return;
    Label_0155:
        base.creepSprite.RevertToStatic();
        if (base.isDead == null)
        {
            goto Label_0188;
        }
        this.StopFighting();
        goto Label_017D;
    Label_0176:
        base.ReadyToAttack();
    Label_017D:
        goto Label_0188;
    Label_0182:
        base.Move();
    Label_0188:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_01C9;
        }
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_01E8;
    Label_01C9:
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_01E8:
        return;
    }

    protected override unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_004F;
        }
        return new Vector2(&base.transform.position.x + 49f, &base.transform.position.y);
    Label_004F:
        return new Vector2(&base.transform.position.x - 49f, &base.transform.position.y);
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.bombReloadTime = 180;
        this.bombMaxBombs = 7;
        this.bombChargeTime = 0x22;
        this.bombMinDamage = 80;
        this.bombMaxDamage = 160;
        GameData.notificationEnemyBossTreant = 1;
        base.stage.PlayMusicBossFight();
        return;
    }

    protected override bool ReadyToDamage()
    {
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter < base.attackChargeTime)
        {
            goto Label_0028;
        }
        base.attackChargeTimeCounter = 0;
        return 1;
    Label_0028:
        if (base.attackChargeTimeCounter != 11)
        {
            goto Label_003B;
        }
        base.AreaAttack();
    Label_003B:
        return 0;
    }

    protected bool SpecialBombing()
    {
        if (this.isBombing != null)
        {
            goto Label_004B;
        }
        if (this.bombReloadTimeCounter >= this.bombReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        if (this.CanFireBomb() != null)
        {
            goto Label_002B;
        }
        return 0;
    Label_002B:
        this.isBombing = 1;
        this.bombChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("bombing");
        return 1;
    Label_004B:
        if (this.bombChargeTimeCounter >= this.bombChargeTime)
        {
            goto Label_007F;
        }
        this.bombChargeTimeCounter += 1;
        if (this.bombChargeTimeCounter != 13)
        {
            goto Label_007D;
        }
        this.FireBombs();
    Label_007D:
        return 1;
    Label_007F:
        this.bombReloadTimeCounter = 0;
        this.isBombing = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_00A5;
        }
        this.CheckFacing();
    Label_00A5:
        return 0;
    }

    protected override bool SpecialPower()
    {
        this.bombReloadTimeCounter += 1;
        if (this.SpecialBombing() == null)
        {
            goto Label_001B;
        }
        return 1;
    Label_001B:
        return 0;
    }

    public override unsafe void StartFighting()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.isFighting = 1;
        if (this.isBombing != null)
        {
            goto Label_0072;
        }
        base.facing = 4;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.ChargeAttack();
    Label_0072:
        return;
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        this.isBombing = 0;
        return;
    }
}

