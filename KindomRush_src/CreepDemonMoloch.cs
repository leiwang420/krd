using System;
using System.Collections;
using UnityEngine;

public class CreepDemonMoloch : Creep
{
    private int areaAttackChargeTime;
    private int areaAttackChargeTimeCounter;
    private int areaAttackMinEnemies;
    private int areaAttackReloadTime;
    private int areaAttackReloadTimeCounter;
    private bool isAreaAttack;
    private bool isOnChair;
    private Vector2 normalAreaAttackPoint;
    private int normalAreaAttackRangeHeight;
    private int normalAreaAttackRangeWidth;
    public Transform ringPrefab;
    public Transform rocksPrefab;
    private GameObject spawner;

    public CreepDemonMoloch()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.normalAreaAttackPoint = this.GetAttackPoint();
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_001F:
        try
        {
            goto Label_0054;
        Label_0024:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0054;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0054;
            }
            soldier.SetDamage(base.GetDamage(), 0);
        Label_0054:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
            }
            goto Label_0076;
        }
        finally
        {
        Label_0064:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006F;
            }
        Label_006F:
            disposable.Dispose();
        }
    Label_0076:
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
        if (this.isAreaAttack != null)
        {
            goto Label_0072;
        }
        this.RevertToStatic();
    Label_0072:
        return;
    }

    private bool CanAreaAttack()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0015:
        try
        {
            goto Label_0061;
        Label_001A:
            soldier = (Soldier) enumerator.Current;
            if ((soldier != null) == null)
            {
                goto Label_0061;
            }
            if (soldier.IsActive() == null)
            {
                goto Label_0061;
            }
            if (this.OnRangeAreaAttack(soldier) == null)
            {
                goto Label_0061;
            }
            num += 1;
            if (num < this.areaAttackMinEnemies)
            {
                goto Label_0061;
            }
            flag = 1;
            goto Label_0088;
        Label_0061:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
            goto Label_0086;
        }
        finally
        {
        Label_0071:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007E;
            }
        Label_007E:
            disposable.Dispose();
        }
    Label_0086:
        return 0;
    Label_0088:
        return flag;
    }

    private void CreepArmaggedon()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_005A;
        Label_0016:
            transform = (Transform) enumerator.Current;
            if ((transform != base.transform) == null)
            {
                goto Label_005A;
            }
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_005A;
            }
            creep.Gib();
            creep.Damage(0x186a0, 0, 0, 0);
        Label_005A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_007C;
        }
        finally
        {
        Label_006A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0075;
            }
        Label_0075:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    private unsafe void DelayedRingDecal()
    {
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        &vector = new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -46 : 0x2e)), &base.transform.position.y - 95f, -3f);
        transform = UnityEngine.Object.Instantiate(this.ringPrefab, vector, Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        return;
    }

    private void DoAreaAttack()
    {
        this.isAreaAttack = 1;
        this.areaAttackChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("areaAttack");
        return;
    }

    private void EndAreaAttack()
    {
        this.isAreaAttack = 0;
        this.areaAttackChargeTimeCounter = 0;
        this.areaAttackReloadTimeCounter = 0;
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_002D;
        }
        this.CheckFacing();
    Label_002D:
        return;
    }

    protected override void FixedUpdate()
    {
        if (this.isOnChair == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.FixedUpdate();
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
            goto Label_005B;
        }
        return new Vector2(&base.transform.position.x + 28f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 28f, &base.transform.position.y + &this.anchorPoint.y);
    }

    private void HitSoldiers()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0047;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0047;
            }
            if (this.OnRangeAreaAttack(soldier) == null)
            {
                goto Label_0047;
            }
            soldier.SetDamage(0x2710, 1);
        Label_0047:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_0069;
        }
        finally
        {
        Label_0057:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0062;
            }
        Label_0062:
            disposable.Dispose();
        }
    Label_0069:
        return;
    }

    protected override void InitCustomSettings()
    {
        this.spawner = GameObject.Find("Spawner");
        this.isOnChair = 1;
        base.pathIndex = 1;
        base.isRespawning = 1;
        base.respawnTime = 14;
        base.respawnTimeCounter = 0;
        base.attackChargeTime = 0x19;
        base.attackChargeTimeCounter = 0;
        base.attackReloadTime = 20;
        base.attackReloadTimeCounter = 0;
        base.fadingTime = 220;
        base.fadingTimeCounter = 0;
        base.xSoldierAdjust = 47f;
        this.normalAreaAttackRangeWidth = 0x71;
        this.normalAreaAttackRangeHeight = Mathf.RoundToInt(((float) this.normalAreaAttackRangeWidth) * 0.7f);
        this.areaAttackMinEnemies = 2;
        this.areaAttackReloadTime = 210;
        base.areaAttackRangeWidth = 0x11a;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        this.areaAttackReloadTimeCounter = 0;
        this.areaAttackChargeTime = 0x2a;
        this.areaAttackChargeTimeCounter = 0;
        GameData.notificationEnemyBossDemonMoloch = 1;
        this.SetSittingFrame();
        base.mainBar.gameObject.SetActive(0);
        return;
    }

    protected override bool OnRange(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) this.normalAreaAttackRangeHeight, (float) this.normalAreaAttackRangeWidth, this.normalAreaAttackPoint);
    }

    private unsafe bool OnRangeAreaAttack(Soldier mySoldier)
    {
        Vector3 vector;
        Vector3 vector2;
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, new Vector3(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y, 0f));
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayInfernoBossDeath();
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
        if (base.attackChargeTimeCounter != 14)
        {
            goto Label_004A;
        }
        GameSoundManager.PlayInfernoBossStomp();
        base.Invoke("DelayedRingDecal", 0.03f);
    Label_004A:
        return 0;
    }

    private void SetSittingFrame()
    {
        base.creepSprite.PlayAnim("respawn");
        base.creepSprite.PauseAnim();
        return;
    }

    private unsafe bool SpecialAreaAttack()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        Vector3 vector11;
        Vector3 vector12;
        Vector3 vector13;
        Vector3 vector14;
        Vector3 vector15;
        Vector3 vector16;
        Vector3 vector17;
        Vector3 vector18;
        if (this.isAreaAttack != null)
        {
            goto Label_0033;
        }
        if (this.areaAttackReloadTimeCounter >= this.areaAttackReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        if (this.CanAreaAttack() != null)
        {
            goto Label_002B;
        }
        return 0;
    Label_002B:
        this.DoAreaAttack();
        return 1;
    Label_0033:
        if (this.areaAttackChargeTimeCounter >= this.areaAttackChargeTime)
        {
            goto Label_0389;
        }
        this.areaAttackChargeTimeCounter += 1;
        if (this.areaAttackChargeTimeCounter != 15)
        {
            goto Label_0387;
        }
        GameSoundManager.PlayInfernoBossHorn();
        transform = UnityEngine.Object.Instantiate(this.rocksPrefab, new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -51 : 0x33)), &base.transform.position.y - 137f, -750f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        transform = UnityEngine.Object.Instantiate(this.rocksPrefab, new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -1 : 1)), &base.transform.position.y - 109f, -750f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        transform = UnityEngine.Object.Instantiate(this.rocksPrefab, new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -127 : 0x7f)), &base.transform.position.y - 127f, -750f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        transform = UnityEngine.Object.Instantiate(this.rocksPrefab, new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -123 : 0x7b)), &base.transform.position.y - 88f, -750f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        transform = UnityEngine.Object.Instantiate(this.rocksPrefab, new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -70 : 70)), &base.transform.position.y - 100f, -750f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        transform = UnityEngine.Object.Instantiate(this.rocksPrefab, new Vector3(&base.transform.position.x + ((float) ((&base.transform.localScale.x != 1f) ? -76 : 0x4c)), &base.transform.position.y - 71f, -750f), Quaternion.identity) as Transform;
        base.stage.AddEffect(transform);
        base.Invoke("DelayedRingDecal", 0.03f);
        this.HitSoldiers();
    Label_0387:
        return 1;
    Label_0389:
        this.EndAreaAttack();
        return 0;
    }

    protected override bool SpecialPower()
    {
        if (this.SpecialAreaAttack() == null)
        {
            goto Label_000D;
        }
        return 1;
    Label_000D:
        return base.SpecialPower();
    }

    public void StandUp()
    {
        base.stage.PlayMusicBossFight();
        base.path = base.stage.GetPath();
        this.isOnChair = 0;
        base.creepSprite.UnpauseAnim();
        base.mainBar.gameObject.SetActive(1);
        base.clickable.yOffset = -110f;
        base.transform.parent = this.spawner.transform;
        return;
    }

    public override unsafe void StartFighting()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.isFighting = 1;
        if (this.isAreaAttack != null)
        {
            goto Label_007D;
        }
        if (base.isStunned != null)
        {
            goto Label_007D;
        }
        base.facing = -1;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.ChargeAttack();
    Label_007D:
        return;
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        if (this.isAreaAttack == null)
        {
            goto Label_0017;
        }
        this.EndAreaAttack();
    Label_0017:
        return;
    }

    protected override void UpdateSpecialPowerCooldowns()
    {
        this.areaAttackReloadTimeCounter += 1;
        return;
    }
}

