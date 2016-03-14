using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepJT : Creep
{
    private int areaFrozeAttackMax;
    private int areaFrozeAttackRangeHeight;
    private int areaFrozeAttackRangeWidth;
    private int breathDuration;
    private int breathDurationTimeCounter;
    private int breathSoundTime;
    private int breathSoundTimeCounter;
    private Transform click;
    public Transform clickMe;
    private bool eating;
    private int frozeChargeTime;
    private int frozeChargeTimeCounter;
    private int frozeMaxTowers;
    public Transform frozePrefab;
    private int frozeRangeHeight;
    private int frozeRangeWidth;
    private int frozeReloadTime;
    private int frozeReloadTimeCounter;
    private bool isBreathing;
    private bool isFrozing;
    private bool isPreDying;
    private bool isWaitingClick;
    private int preDeathTime;
    private int preDeathTimeCounter;
    private int wolfSpawnCooldownTime;
    private int wolfSpawnCooldownTimeCounter;
    public Transform yetiEggPrefab;
    private int yetisSpawnCooldownTime;
    private int yetisSpawnCooldownTimeCounter;

    public CreepJT()
    {
        base..ctor();
        return;
    }

    protected override void Attack()
    {
        this.eating = 0;
        base.soldier = null;
        return;
    }

    private void AutoKill()
    {
        base.creepSprite.PlayAnim("death");
        GameSoundManager.PlayJTExplode();
        base.isFading = 1;
        this.isPreDying = 0;
        this.isWaitingClick = 0;
        base.collider.enabled = 0;
        if ((this.click != null) == null)
        {
            goto Label_0057;
        }
        UnityEngine.Object.Destroy(this.click.gameObject);
    Label_0057:
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        base.soldier = mySoldier;
        base.isBlocked = 1;
        if (this.isFrozing != null)
        {
            goto Label_002F;
        }
        if (this.isBreathing != null)
        {
            goto Label_002F;
        }
        base.creepSprite.RevertToStatic();
    Label_002F:
        return;
    }

    protected bool CanFroze()
    {
        TowerBase[] baseArray;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        baseArray2 = baseArray;
        num = 0;
        goto Label_003F;
    Label_001E:
        base2 = baseArray2[num];
        if (base2.IsActive() == null)
        {
            goto Label_003B;
        }
        if (this.OnRangeFroze(base2) == null)
        {
            goto Label_003B;
        }
        return 1;
    Label_003B:
        num += 1;
    Label_003F:
        if (num < ((int) baseArray2.Length))
        {
            goto Label_001E;
        }
        return 0;
    }

    public override void ChargeAttack()
    {
        base.creepSprite.PlayAnim("attack");
        base.isCharging = 1;
        this.eating = 1;
        return;
    }

    protected unsafe void CheckSpawnEnemies()
    {
        Vector3 vector;
        Transform transform;
        Transform transform2;
        Vector3 vector2;
        Vector3 vector3;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f);
        if (this.wolfSpawnCooldownTimeCounter < this.wolfSpawnCooldownTime)
        {
            goto Label_0072;
        }
        transform = UnityEngine.Object.Instantiate(this.yetiEggPrefab, vector, Quaternion.identity) as Transform;
        transform.GetComponent<YetiEgg>().InitWithPosition(vector, 1, 0, this, 1);
        this.wolfSpawnCooldownTimeCounter = 0;
    Label_0072:
        if (this.yetisSpawnCooldownTimeCounter < this.yetisSpawnCooldownTime)
        {
            goto Label_00B1;
        }
        transform2 = UnityEngine.Object.Instantiate(this.yetiEggPrefab, vector, Quaternion.identity) as Transform;
        transform2.GetComponent<YetiEgg>().InitWithPosition(vector, 2, 0, this, 0);
        this.yetisSpawnCooldownTimeCounter = 0;
    Label_00B1:
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (damageType == null)
        {
            goto Label_0021;
        }
        base.life -= this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002F;
    Label_0021:
        base.life -= dmg;
    Label_002F:
        if (base.life > 0)
        {
            goto Label_00BB;
        }
        base.gui.HideInfo(base.GetComponent<UnitClickable>());
        if ((base.clickable != null) == null)
        {
            goto Label_0073;
        }
        base.clickable.UnSelect();
        UnityEngine.Object.Destroy(base.clickable);
    Label_0073:
        base.life = 0;
        base.active = 0;
        this.isPreDying = 1;
        base.mainBar.gameObject.SetActive(0);
        base.creepSprite.PlayAnim("endDeath");
        base.HidePoison();
        base.HideCurse();
        GameSoundManager.PlayJTDeath();
        return;
    Label_00BB:
        return;
    }

    protected void EatSoldiers()
    {
        ArrayList list;
        int num;
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        base.areaAttackPoint = this.GetEatPoint();
        list = base.stage.GetSoldiers();
        num = 0;
        enumerator = list.GetEnumerator();
    Label_0021:
        try
        {
            goto Label_0064;
        Label_0026:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0064;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0064;
            }
            soldier.Eat();
            num += 1;
            if (num != base.areaAttackMax)
            {
                goto Label_0064;
            }
            goto Label_006F;
        Label_0064:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0026;
            }
        Label_006F:
            goto Label_0089;
        }
        finally
        {
        Label_0074:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0081;
            }
        Label_0081:
            disposable.Dispose();
        }
    Label_0089:
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
        if (this.isPreDying == null)
        {
            goto Label_0064;
        }
        if (this.isWaitingClick != null)
        {
            goto Label_0063;
        }
        if (this.preDeathTimeCounter >= this.preDeathTime)
        {
            goto Label_0046;
        }
        this.preDeathTimeCounter += 1;
        goto Label_0063;
    Label_0046:
        base.gui.HideInfo(base.GetComponent<UnitClickable>());
        base.CreepArmaggedon();
        this.AutoKill();
    Label_0063:
        return;
    Label_0064:
        if (base.isFading == null)
        {
            goto Label_0099;
        }
        base.fadingTimeCounter += 1;
        if (base.fadingTimeCounter != base.fadingTime)
        {
            goto Label_0098;
        }
        GameAchievements.KillEnemy();
        GameAchievements.DefeatYetiBoss();
    Label_0098:
        return;
    Label_0099:
        base.UpdateLifeBar();
        if (base.isDead == null)
        {
            goto Label_00AB;
        }
        return;
    Label_00AB:
        if (base.isActive == null)
        {
            goto Label_00CD;
        }
        if (base.isCharging != null)
        {
            goto Label_00CD;
        }
        if (this.SpecialPower() == null)
        {
            goto Label_00CD;
        }
        return;
    Label_00CD:
        if (base.isBlocked == null)
        {
            goto Label_011A;
        }
        if (this.eating != null)
        {
            goto Label_011A;
        }
        if ((base.soldier == null) != null)
        {
            goto Label_0114;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_0114;
        }
        if (base.soldier.IsFighting() != null)
        {
            goto Label_011A;
        }
    Label_0114:
        this.StopFighting();
    Label_011A:
        if (base.isFighting == null)
        {
            goto Label_0191;
        }
        if (base.isCharging == null)
        {
            goto Label_0185;
        }
        if (this.ReadyToDamage() != null)
        {
            goto Label_013C;
        }
        return;
    Label_013C:
        this.Attack();
        if (this.isPreDying == null)
        {
            goto Label_014E;
        }
        return;
    Label_014E:
        base.creepSprite.RevertToStatic();
        if ((base.soldier == null) != null)
        {
            goto Label_017A;
        }
        if (base.soldier.IsDead() == null)
        {
            goto Label_0197;
        }
    Label_017A:
        this.StopFighting();
        goto Label_018C;
    Label_0185:
        base.ReadyToAttack();
    Label_018C:
        goto Label_0197;
    Label_0191:
        base.Move();
    Label_0197:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_01D8;
        }
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_01F7;
    Label_01D8:
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_01F7:
        return;
    }

    protected unsafe void FreezeTower(TowerBase tower)
    {
        Vector3 vector;
        Transform transform;
        IceBlock block;
        Vector3 vector2;
        Vector3 vector3;
        tower.SetActive(0, 1);
        &vector = new Vector3(&tower.transform.position.x, &tower.transform.position.y, -800f);
        transform = UnityEngine.Object.Instantiate(this.frozePrefab, vector, Quaternion.identity) as Transform;
        transform.GetComponent<IceBlock>().SetTower(tower);
        return;
    }

    protected void Froze()
    {
        int num;
        TowerBase[] baseArray;
        TowerBase base2;
        TowerBase[] baseArray2;
        int num2;
        num = 0;
        baseArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerBase)) as TowerBase[];
        baseArray2 = baseArray;
        num2 = 0;
        goto Label_005F;
    Label_0021:
        base2 = baseArray2[num2];
        if (base2.IsActive() == null)
        {
            goto Label_0059;
        }
        if (this.OnRangeFroze(base2) == null)
        {
            goto Label_0059;
        }
        this.FreezeTower(base2);
        num += 1;
        if (num != this.frozeMaxTowers)
        {
            goto Label_0059;
        }
        goto Label_0069;
    Label_0059:
        num2 += 1;
    Label_005F:
        if (num2 < ((int) baseArray2.Length))
        {
            goto Label_0021;
        }
    Label_0069:
        return;
    }

    protected void FrozeAttack()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Soldier soldier;
        IDisposable disposable;
        base.areaAttackPoint = this.GetAttackPoint();
        num = 0;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001F:
        try
        {
            goto Label_0070;
        Label_0024:
            transform = (Transform) enumerator.Current;
            soldier = transform.GetComponent<Soldier>();
            if (soldier.IsActive() == null)
            {
                goto Label_0070;
            }
            if (this.OnRangeFrozeAttack(soldier) == null)
            {
                goto Label_0070;
            }
            soldier.SetDamage(base.GetDamage(), 0);
            num += 1;
            if (num != this.areaFrozeAttackMax)
            {
                goto Label_0070;
            }
            goto Label_007B;
        Label_0070:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0024;
            }
        Label_007B:
            goto Label_0095;
        }
        finally
        {
        Label_0080:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_008D;
            }
        Label_008D:
            disposable.Dispose();
        }
    Label_0095:
        return;
    }

    protected unsafe Vector2 GetAttackPoint()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x == 1f)
        {
            goto Label_005B;
        }
        return new Vector2(&base.transform.position.x + 113f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 113f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected unsafe Vector2 GetEatPoint()
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
        return new Vector2(&base.transform.position.x + 100f, &base.transform.position.y + &this.anchorPoint.y);
    Label_005B:
        return new Vector2(&base.transform.position.x - 100f, &base.transform.position.y + &this.anchorPoint.y);
    }

    protected override void InitCustomSettings()
    {
        this.breathDuration = 120;
        this.breathSoundTime = 0x22;
        this.areaFrozeAttackRangeWidth = 0x7f;
        this.areaFrozeAttackRangeHeight = Mathf.RoundToInt(((float) this.areaFrozeAttackRangeWidth) * 0.7f);
        this.areaFrozeAttackMax = 10;
        base.areaAttackRangeWidth = 0x7f;
        base.areaAttackRangeHeight = Mathf.RoundToInt(((float) base.areaAttackRangeWidth) * 0.7f);
        base.areaAttackMax = 5;
        this.frozeMaxTowers = 4;
        this.frozeRangeWidth = 0x21d;
        this.frozeRangeHeight = Mathf.RoundToInt(((float) this.frozeRangeWidth) * 0.7f);
        this.frozeReloadTime = 300;
        this.frozeChargeTime = 0x1b;
        this.yetisSpawnCooldownTime = 570;
        this.wolfSpawnCooldownTime = 280;
        this.preDeathTime = 0x2d;
        this.preDeathTimeCounter = 0;
        this.isPreDying = 0;
        this.isWaitingClick = 0;
        base.isActive = 1;
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        GameData.notificationEnemyYetiBoss = 1;
        base.stage.PlayMusicBossFight();
        return;
    }

    public override bool IsDead()
    {
        if (this.isWaitingClick == null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        return ((base.life > 0) == 0);
    }

    private void OnMouseDown()
    {
        if (this.isWaitingClick == null)
        {
            goto Label_0011;
        }
        this.AutoKill();
    Label_0011:
        return;
    }

    protected bool OnRange(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) base.areaAttackRangeHeight, (float) base.areaAttackRangeWidth, base.areaAttackPoint);
    }

    protected bool OnRangeFroze(TowerBase myTower)
    {
        return IronUtils.ellipseContainPoint(myTower.transform.position, (float) this.frozeRangeHeight, (float) this.frozeRangeWidth, base.transform.position);
    }

    protected bool OnRangeFrozeAttack(Soldier mySoldier)
    {
        return IronUtils.ellipseContainPoint(mySoldier.transform.position, (float) this.areaFrozeAttackRangeHeight, (float) this.areaFrozeAttackRangeWidth, base.areaAttackPoint);
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
            goto Label_003F;
        }
        GameSoundManager.PlayJTEat();
        goto Label_0052;
    Label_003F:
        if (base.attackChargeTimeCounter != 15)
        {
            goto Label_0052;
        }
        this.EatSoldiers();
    Label_0052:
        return 0;
    }

    protected bool SpecialBreath()
    {
        if (this.isBreathing != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.breathDurationTimeCounter >= this.breathDuration)
        {
            goto Label_0059;
        }
        this.breathDurationTimeCounter += 1;
        this.breathSoundTimeCounter += 1;
        if (this.breathSoundTimeCounter != this.breathSoundTime)
        {
            goto Label_0057;
        }
        this.breathSoundTimeCounter = 0;
        GameSoundManager.PlayJTRest();
    Label_0057:
        return 1;
    Label_0059:
        this.isBreathing = 0;
        base.facing = 4;
        if (base.isBlocked != null)
        {
            goto Label_0078;
        }
        this.CheckFacing();
    Label_0078:
        return 0;
    }

    protected bool SpecialFroze()
    {
        if (this.isFrozing != null)
        {
            goto Label_0052;
        }
        if (this.frozeReloadTimeCounter >= this.frozeReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        if (this.CanFroze() != null)
        {
            goto Label_002B;
        }
        return 0;
    Label_002B:
        this.isFrozing = 1;
        base.isStopped = 1;
        this.frozeChargeTimeCounter = 0;
        base.creepSprite.PlayAnim("froze");
        return 1;
    Label_0052:
        if (this.frozeChargeTimeCounter >= this.frozeChargeTime)
        {
            goto Label_0097;
        }
        this.frozeChargeTimeCounter += 1;
        if (this.frozeChargeTimeCounter != 6)
        {
            goto Label_0082;
        }
        GameSoundManager.PlayJTAttack();
    Label_0082:
        if (this.frozeChargeTimeCounter != 0x10)
        {
            goto Label_0095;
        }
        this.Froze();
    Label_0095:
        return 1;
    Label_0097:
        this.isFrozing = 0;
        this.frozeReloadTimeCounter = 0;
        this.StartBreath();
        if ((base.soldier != null) == null)
        {
            goto Label_00C7;
        }
        base.soldier.UnBlock();
    Label_00C7:
        base.isBlocked = 0;
        base.isFighting = 0;
        base.isCharging = 0;
        base.soldier = null;
        this.eating = 0;
        return 1;
    }

    protected override bool SpecialPower()
    {
        this.frozeReloadTimeCounter += 1;
        this.yetisSpawnCooldownTimeCounter += 1;
        this.wolfSpawnCooldownTimeCounter += 1;
        this.CheckSpawnEnemies();
        if (this.SpecialBreath() == null)
        {
            goto Label_003D;
        }
        return 1;
    Label_003D:
        if (this.SpecialFroze() == null)
        {
            goto Label_004A;
        }
        return 1;
    Label_004A:
        return 0;
    }

    protected void StartBreath()
    {
        this.isBreathing = 1;
        this.breathDurationTimeCounter = 0;
        this.breathSoundTimeCounter = 0;
        GameSoundManager.PlayJTRest();
        return;
    }

    public override void StartFighting()
    {
        base.isFighting = 1;
        if (this.isFrozing != null)
        {
            goto Label_002A;
        }
        if (this.isBreathing != null)
        {
            goto Label_002A;
        }
        base.facing = 4;
        this.ChargeAttack();
    Label_002A:
        return;
    }

    protected void StopSpecialPower()
    {
        this.isFrozing = 0;
        this.isBreathing = 0;
        return;
    }
}

