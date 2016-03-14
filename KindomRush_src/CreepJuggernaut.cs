using System;
using System.Collections;
using UnityEngine;

public class CreepJuggernaut : Creep
{
    public Transform bombPrefab;
    private Vector2 destinyPoint;
    private bool isMissile;
    private bool isSpawning;
    private int missileChargeTime;
    private int missileChargeTimeCounter;
    private int missileMaxDamage;
    private int missileMinDamage;
    private int missileMinRange;
    public Transform missilePrefab;
    private int missileReloadTime;
    private int missileReloadTimeCounter;
    private Soldier missileTarget;
    public Transform smokeEffectPrefab;
    private int spawningChargeTime;
    private int spawningChargeTimeCounter;
    private int spawningNodeIndex;
    private int spawningNodePath;
    private int spawningReloadTime;
    private int spawningReloadTimeCounter;

    public CreepJuggernaut()
    {
        base..ctor();
        return;
    }

    private void AttackArea()
    {
        int num;
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        base.areaAttackPoint = this.GetAttackPoint();
        num = 0;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_0021:
        try
        {
            goto Label_006B;
        Label_0026:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_006B;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_006B;
            }
            soldier.SetDamage(base.GetDamage(), 0);
            num += 1;
            if (num != base.areaAttackMax)
            {
                goto Label_006B;
            }
            goto Label_0076;
        Label_006B:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0026;
            }
        Label_0076:
            goto Label_0090;
        }
        finally
        {
        Label_007B:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0088;
            }
        Label_0088:
            disposable.Dispose();
        }
    Label_0090:
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
        if (this.isMissile != null)
        {
            goto Label_0082;
        }
        if (this.isSpawning != null)
        {
            goto Label_0082;
        }
        base.creepSprite.RevertToStatic();
    Label_0082:
        return;
    }

    public override unsafe void BloodSplatter()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if ((base.bloodSplatter != null) == null)
        {
            goto Label_007C;
        }
        GameSoundManager.PlayHitSound();
        transform = UnityEngine.Object.Instantiate(base.bloodSplatter, new Vector3(&base.transform.position.x, &base.transform.position.y, &base.transform.position.z - 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
    Label_007C:
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
            goto Label_0076;
        }
        GameAchievements.KillEnemy();
        GameAchievements.DefeatJuggernaut();
        GameSoundManager.PlayJuggernautDeath();
        this.KillAllies();
        base.HidePoison();
        this.Die();
        return;
    Label_0076:
        if (base.active == null)
        {
            goto Label_0098;
        }
        if (base.isCharging != null)
        {
            goto Label_0098;
        }
        if (this.SpecialPower() == null)
        {
            goto Label_0098;
        }
        return;
    Label_0098:
        if (base.isBlocked == null)
        {
            goto Label_00E5;
        }
        if (base.isCharging != null)
        {
            goto Label_00E5;
        }
        if ((base.soldier == null) != null)
        {
            goto Label_00DF;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_00DF;
        }
        if (base.soldier.IsFighting() != null)
        {
            goto Label_00E5;
        }
    Label_00DF:
        this.StopFighting();
    Label_00E5:
        if (base.isFighting == null)
        {
            goto Label_0169;
        }
        if (base.isCharging == null)
        {
            goto Label_015D;
        }
        if (this.ReadyToDamage() != null)
        {
            goto Label_0107;
        }
        return;
    Label_0107:
        base.isCharging = 0;
        this.Attack();
        if (base.isDead != null)
        {
            goto Label_0136;
        }
        if (base.life <= 0)
        {
            goto Label_0136;
        }
        if (base.active != null)
        {
            goto Label_0137;
        }
    Label_0136:
        return;
    Label_0137:
        base.creepSprite.RevertToStatic();
        if (base.soldier.IsDead() == null)
        {
            goto Label_016F;
        }
        this.StopFighting();
        goto Label_0164;
    Label_015D:
        base.ReadyToAttack();
    Label_0164:
        goto Label_016F;
    Label_0169:
        base.Move();
    Label_016F:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_01B0;
        }
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_01CF;
    Label_01B0:
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_01CF:
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
        return new Vector2(&base.transform.position.x + 56f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 56f, &base.transform.position.y + &this.anchorPoint.y);
    }

    private unsafe Vector2 GetBallDestination()
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        int num3;
        vectorArray = base.stage.GetPath();
        num = UnityEngine.Random.Range(0, (int) vectorArray.Length);
        this.spawningNodePath = num;
        num2 = UnityEngine.Random.Range(0, (int) vectorArray[num].Length);
        num3 = UnityEngine.Random.Range(0, ((int) vectorArray[num][num2].Length) - 50);
        this.spawningNodeIndex = num3;
        return *(&(vectorArray[num][num2][num3]));
    }

    private bool GetMissileTarget()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.missileTarget = null;
        enumerator = base.stage.GetSoldiers().GetEnumerator();
    Label_001A:
        try
        {
            goto Label_004E;
        Label_001F:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_004E;
            }
            if (this.MinDistance(soldier) == null)
            {
                goto Label_004E;
            }
            this.missileTarget = soldier;
            goto Label_0059;
        Label_004E:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_0059:
            goto Label_0070;
        }
        finally
        {
        Label_005E:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0069;
            }
        Label_0069:
            disposable.Dispose();
        }
    Label_0070:
        if ((this.missileTarget != null) == null)
        {
            goto Label_0083;
        }
        return 1;
    Label_0083:
        return 0;
    }

    private unsafe Vector2 GetSpecialPosition()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != 1f)
        {
            goto Label_0055;
        }
        return new Vector2(&base.transform.position.x - 35.25f, &base.transform.position.y + 45f);
    Label_0055:
        return new Vector2(&base.transform.position.x + 35.25f, &base.transform.position.y + 45f);
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.areaAttackRangeWidth = 0x7f;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        base.areaAttackMax = 10;
        this.missileReloadTime = 330;
        this.missileMinRange = 0x8d;
        this.missileMinDamage = 150;
        this.missileMaxDamage = 250;
        this.spawningReloadTime = 180;
        this.missileChargeTime = 0x31;
        this.spawningReloadTime = 120;
        this.spawningChargeTime = 0x31;
        base.fadingTime = 200;
        base.fadingTimeCounter = 0;
        base.stage.PlayMusicBossFight();
        GameData.notificationEnemyJuggernaut = 1;
        GameData.notificationEnemyGolemHead = 1;
        return;
    }

    private void KillAllies()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        BombJuggernaut[] juggernautArray;
        BombJuggernaut juggernaut;
        BombJuggernaut[] juggernautArray2;
        int num;
        IDisposable disposable;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0048;
        Label_0016:
            transform = (Transform) enumerator.Current;
            if ((transform != base.transform) == null)
            {
                goto Label_0048;
            }
            transform.GetComponent<Creep>().Damage(0x4e20, 1, 0, 0);
        Label_0048:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_006D;
        }
        finally
        {
        Label_0058:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0065;
            }
        Label_0065:
            disposable.Dispose();
        }
    Label_006D:
        juggernautArray = UnityEngine.Object.FindObjectsOfType(typeof(BombJuggernaut)) as BombJuggernaut[];
        juggernautArray2 = juggernautArray;
        num = 0;
        goto Label_00A6;
    Label_008D:
        juggernaut = juggernautArray2[num];
        UnityEngine.Object.Destroy(juggernaut.gameObject);
        num += 1;
    Label_00A6:
        if (num < ((int) juggernautArray2.Length))
        {
            goto Label_008D;
        }
        return;
    }

    private unsafe bool MinDistance(Soldier tmpSoldier)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &tmpSoldier.transform.position.x - &base.transform.position.x;
        num3 = &tmpSoldier.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.missileMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    private bool OnRange(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, base.areaAttackPoint);
    }

    protected override unsafe bool ReadyToDamage()
    {
        Vector2 vector;
        int num;
        Transform transform;
        Vector3 vector2;
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter < base.attackChargeTime)
        {
            goto Label_0028;
        }
        base.attackChargeTimeCounter = 0;
        return 1;
    Label_0028:
        if (base.attackChargeTimeCounter != 15)
        {
            goto Label_00B8;
        }
        vector = this.GetAttackPoint();
        num = (&base.transform.localScale.x != 1f) ? -1 : 1;
        transform = UnityEngine.Object.Instantiate(this.smokeEffectPrefab, new Vector3(&vector.x, &vector.y, -840f), Quaternion.identity) as Transform;
        transform.localScale = new Vector3((float) num, 1f, 1f);
        base.stage.AddEffect(transform);
        this.AttackArea();
    Label_00B8:
        return 0;
    }

    private unsafe bool SpecialMissile()
    {
        Vector2 vector;
        Vector2 vector2;
        Transform transform;
        Vector3 vector3;
        Vector3 vector4;
        if (this.isMissile != null)
        {
            goto Label_0094;
        }
        if (this.missileReloadTimeCounter >= this.missileReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        if (this.GetMissileTarget() != null)
        {
            goto Label_002B;
        }
        return 0;
    Label_002B:
        this.destinyPoint = new Vector2(&this.missileTarget.transform.position.x, &this.missileTarget.transform.position.y + 10f);
        this.isMissile = 1;
        base.isStopped = 1;
        this.missileChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("missile");
        return 1;
    Label_0094:
        if (this.missileChargeTimeCounter >= this.missileChargeTime)
        {
            goto Label_0184;
        }
        this.missileChargeTimeCounter += 1;
        if (this.missileChargeTimeCounter != 0x18)
        {
            goto Label_0182;
        }
        vector = this.destinyPoint;
        if ((this.missileTarget == null) != null)
        {
            goto Label_00E8;
        }
        if (this.missileTarget.IsActive() != null)
        {
            goto Label_00FA;
        }
    Label_00E8:
        if (this.GetMissileTarget() != null)
        {
            goto Label_00FA;
        }
        vector = this.destinyPoint;
    Label_00FA:
        vector2 = this.GetSpecialPosition();
        transform = UnityEngine.Object.Instantiate(this.missilePrefab, new Vector3(&vector2.x, &vector2.y, -899f), Quaternion.identity) as Transform;
        transform.GetComponent<MissileJuggernaut>().Init(new Vector3(&vector2.x, &vector2.y, -899f), this.missileTarget, 1, 0);
        transform.GetComponent<MissileJuggernaut>().SetDamage(this.missileMinDamage, this.missileMaxDamage);
        base.stage.AddProjectile(transform);
    Label_0182:
        return 1;
    Label_0184:
        this.isMissile = 0;
        this.missileReloadTimeCounter = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_01AA;
        }
        this.CheckFacing();
    Label_01AA:
        return 0;
    }

    protected override bool SpecialPower()
    {
        this.missileReloadTimeCounter += 1;
        this.spawningReloadTimeCounter += 1;
        if (this.isSpawning != null)
        {
            goto Label_0034;
        }
        if (this.SpecialMissile() == null)
        {
            goto Label_0034;
        }
        return 1;
    Label_0034:
        if (this.isMissile != null)
        {
            goto Label_004C;
        }
        if (this.SpecialSpawnEnemies() == null)
        {
            goto Label_004C;
        }
        return 1;
    Label_004C:
        return 0;
    }

    private unsafe bool SpecialSpawnEnemies()
    {
        Vector2 vector;
        Vector2 vector2;
        Transform transform;
        if (this.isSpawning != null)
        {
            goto Label_003E;
        }
        if (this.spawningReloadTimeCounter >= this.spawningReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        this.isSpawning = 1;
        this.spawningChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("missile");
        return 1;
    Label_003E:
        if (this.spawningChargeTimeCounter >= this.spawningChargeTime)
        {
            goto Label_00CC;
        }
        this.spawningChargeTimeCounter += 1;
        if (this.spawningChargeTimeCounter != 0x18)
        {
            goto Label_00CA;
        }
        vector = this.GetBallDestination();
        vector2 = this.GetSpecialPosition();
        transform = UnityEngine.Object.Instantiate(this.bombPrefab, new Vector3(&vector2.x, &vector2.y, -899f), Quaternion.identity) as Transform;
        transform.GetComponent<BombJuggernaut>().InitBomb(vector, this.spawningNodePath, this.spawningNodeIndex);
        base.stage.AddProjectile(transform);
    Label_00CA:
        return 1;
    Label_00CC:
        this.spawningReloadTimeCounter = 0;
        this.isSpawning = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_00F2;
        }
        this.CheckFacing();
    Label_00F2:
        return 0;
    }

    public override unsafe void StartFighting()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.isFighting = 1;
        if (this.isMissile != null)
        {
            goto Label_007D;
        }
        if (this.isSpawning != null)
        {
            goto Label_007D;
        }
        base.facing = 4;
        base.transform.position = new Vector3(Mathf.Round(&base.transform.position.x), Mathf.Round(&base.transform.position.y), &base.transform.position.z);
        this.ChargeAttack();
    Label_007D:
        return;
    }

    private void StopSpecialPower()
    {
        this.isMissile = 0;
        this.isSpawning = 0;
        return;
    }
}

