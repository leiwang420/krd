using System;
using System.Collections;
using UnityEngine;

public class SoldierHeroDwarf : SoldierHero
{
    public Bullet bulletPrefab;
    private bool isMining;
    private bool isRangeShooting;
    private bool isReloading;
    private bool isTarBomb;
    private int mineChargeTime;
    private int mineChargeTimeCounter;
    private int mineCurrent;
    private int mineLevel;
    private int mineMax;
    private Vector2 minePoint;
    public MineProjectile mineProjectilePrefab;
    private int mineRangeHeight;
    private int mineRangeWidth;
    private int mineReloadTime;
    private int mineReloadTimeCounter;
    private int rangeShootChargeTime;
    private int rangeShootChargeTimeCounter;
    private int rangeShootCurrentShoot;
    private int rangeShootHeight;
    private int rangeShootMaxShoots;
    private int rangeShootMinDistance;
    private int rangeShootNearHeight;
    private int rangeShootNearWidth;
    private Vector2 rangeShootPoint;
    private Vector2 rangeShootPointOriginal;
    private int rangeShootReloadTime;
    private int rangeShootReloadTimeCounter;
    private Creep rangeShootTarget;
    private Creep rangeShootTargetOriginal;
    private int rangeShootWidth;
    private int referenceNode;
    private int referencePath;
    private int reloadChargeTime;
    private int reloadChargeTimeCounter;
    private shootDirType shootDir;
    private ArrayList shootEnemies;
    private int tarBombChargeTime;
    private int tarBombChargeTimeCounter;
    private int tarBombLevel;
    private int tarBombMinDistance;
    private Vector2 tarBombPoint;
    public TarBombProjectile tarBombProjectilePrefab;
    private int tarBombRangeHeight;
    private int tarBombRangeWidth;
    private int tarBombReloadTime;
    private int tarBombReloadTimeCounter;

    public SoldierHeroDwarf()
    {
        base..ctor();
        return;
    }

    protected void AdjustBulletPosition(Bullet bullet)
    {
        Transform transform1;
        if (this.shootDir != null)
        {
            goto Label_0035;
        }
        transform1 = bullet.transform;
        transform1.position -= new Vector3(0f, 7f, 0f);
    Label_0035:
        return;
    }

    protected unsafe bool CanMine()
    {
        int num;
        int num2;
        Vector2[][][] vectorArray;
        num = UnityEngine.Random.Range(0, 3);
        num2 = UnityEngine.Random.Range(-12, 4);
        vectorArray = base.stage.GetPath();
        if ((this.referenceNode + num2) < ((int) vectorArray[this.referencePath][0].Length))
        {
            goto Label_003D;
        }
        num2 = 0;
        goto Label_004D;
    Label_003D:
        if ((this.referenceNode + num2) >= 0)
        {
            goto Label_004D;
        }
        num2 = 0;
    Label_004D:
        this.minePoint = *(&(vectorArray[this.referencePath][num][this.referenceNode + num2]));
        return 1;
    }

    protected bool CanTar()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        int num;
        IDisposable disposable;
        creep = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0060;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_0060;
            }
            if (creep2.isFlying != null)
            {
                goto Label_0060;
            }
            if (this.MinTarBombDistance(creep2) == null)
            {
                goto Label_0060;
            }
            if (this.OnRangeTar(creep2) == null)
            {
                goto Label_0060;
            }
            creep = creep2;
            goto Label_006B;
        Label_0060:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
        Label_006B:
            goto Label_0085;
        }
        finally
        {
        Label_0070:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007D;
            }
        Label_007D:
            disposable.Dispose();
        }
    Label_0085:
        if ((creep != null) == null)
        {
            goto Label_00ED;
        }
        if (creep.IsStopped() != null)
        {
            goto Label_00A7;
        }
        if (creep.IsBlocked() == null)
        {
            goto Label_00B4;
        }
    Label_00A7:
        num = creep.GetCurrentNodeIndex();
        goto Label_00DE;
    Label_00B4:
        if ((creep.GetCurrentNodeIndex() + 5) <= creep.GetSubPathCount())
        {
            goto Label_00D4;
        }
        num = creep.GetCurrentNodeIndex();
        goto Label_00DE;
    Label_00D4:
        num = creep.GetCurrentNodeIndex() + 5;
    Label_00DE:
        this.tarBombPoint = creep.GetNode(0);
        return 1;
    Label_00ED:
        return 0;
    }

    protected bool CanTarget(Creep myEnemy)
    {
        Creep creep;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        enumerator = this.shootEnemies.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0030;
        Label_0011:
            creep = (Creep) enumerator.Current;
            if ((creep == myEnemy) == null)
            {
                goto Label_0030;
            }
            flag = 0;
            goto Label_0054;
        Label_0030:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0052;
        }
        finally
        {
        Label_0040:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_004B;
            }
        Label_004B:
            disposable.Dispose();
        }
    Label_0052:
        return 1;
    Label_0054:
        return flag;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (base.IsDead() != null)
        {
            goto Label_0031;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0019;
        }
        return 0;
    Label_0019:
        base.rangePoint = newRallyPoint;
        this.FindReferenceNode();
        base.GetMyPath();
        GameSoundManager.PlayHeroDwarfTaunt();
    Label_0031:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.shootEnemies = new ArrayList();
        base.attackChargeTime = 0x11;
        base.attackChargeDamageTime = 5;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_dwarf", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "respawn", 1)) * 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_dwarf", "reload", 1)) * 30) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_dwarf", "mineModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_dwarf", "tarModifier", 1);
        this.rangeShootReloadTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "rangeShootReloadTime", 1)) * 30;
        this.rangeShootWidth = (int) GameSettings.GetHeroSetting("hero_dwarf", "rangeShootRangeWidth", 1);
        this.rangeShootHeight = Mathf.RoundToInt(((float) this.rangeShootWidth) * 0.7f);
        this.rangeShootMinDistance = (int) GameSettings.GetHeroSetting("hero_dwarf", "rangeShootMinDistance", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_dwarf", "xpMultiplier", 1);
        this.rangeShootNearWidth = 0x71;
        this.rangeShootNearHeight = Mathf.RoundToInt(((float) this.rangeShootNearWidth) * 0.7f);
        base.adjustAbducted = new Vector2(10f, 30f);
        base.levelUpChargeTime = 0x12;
        base.respawnTime = 0x12;
        this.tarBombChargeTime = 0x1b;
        this.mineChargeTime = 0x13;
        this.rangeShootChargeTime = 0x1c;
        this.rangeShootCurrentShoot = 0;
        this.reloadChargeTime = 0x17;
        base.levelUpSoundShoot = 5;
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.6f;
        base.lifes = 1;
        base.xAdjust = 7f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        this.FindReferenceNode();
        base.damageType = 5;
        return;
    }

    protected unsafe void DoMine()
    {
        MineProjectile projectile;
        projectile = UnityEngine.Object.Instantiate(this.mineProjectilePrefab, base.transform.position + new Vector3(0f, 17f, 0f), Quaternion.identity) as MineProjectile;
        base.stage.AddProjectile(projectile.transform);
        projectile.SetStage(base.stage);
        projectile.SetG(-0.6f);
        projectile.SetT1(22f);
        projectile.SetDest(&this.minePoint.x, &this.minePoint.y - 10f);
        projectile.SetLevel(this.mineLevel);
        GameSoundManager.PlayHeroDwarfMine();
        return;
    }

    protected void DoReload()
    {
        this.isReloading = 1;
        this.reloadChargeTimeCounter = 0;
        base.sprite.PlayAnim("reload");
        if (this.rangeShootCurrentShoot < this.rangeShootMaxShoots)
        {
            goto Label_004E;
        }
        this.rangeShootReloadTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "rangeShootReloadTime", 1)) * 30;
        goto Label_0071;
    Label_004E:
        this.rangeShootReloadTime = (((int) GameSettings.GetHeroSetting("hero_dwarf", "rangeShootReloadTime", 1)) - (3 - this.rangeShootCurrentShoot)) * 30;
    Label_0071:
        return;
    }

    protected unsafe void DoTar()
    {
        Vector3 vector;
        TarBombProjectile projectile;
        Vector3 vector2;
        Vector3 vector3;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y + 17f, -800f);
        projectile = UnityEngine.Object.Instantiate(this.tarBombProjectilePrefab, vector, Quaternion.identity) as TarBombProjectile;
        base.stage.AddProjectile(projectile.transform);
        projectile.SetStage(base.stage);
        projectile.SetT1(34f);
        projectile.SetG(-0.6f);
        projectile.SetDest(&this.tarBombPoint.x, &this.tarBombPoint.y);
        projectile.SetLevel(this.tarBombLevel);
        GameSoundManager.PlayHeroDwarfBrea();
        return;
    }

    protected unsafe bool EvalMine()
    {
        Vector3 vector;
        if (this.isTarBomb != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (base.isWalking != null)
        {
            goto Label_002C;
        }
        if (this.isRangeShooting == null)
        {
            goto Label_002E;
        }
    Label_002C:
        return 0;
    Label_002E:
        if (this.isMining != null)
        {
            goto Label_00E4;
        }
        if (this.mineReloadTimeCounter >= this.mineReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanMine() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        if (&this.minePoint.x < &base.transform.position.x)
        {
            goto Label_0091;
        }
        base.transform.localScale = Vector3.one;
        goto Label_00B0;
    Label_0091:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00B0:
        this.isMining = 1;
        this.mineChargeTimeCounter = 0;
        this.mineReloadTimeCounter = 0;
        base.sprite.PlayAnim("mine");
        base.GainXpByAbilityModifier(1, this.mineLevel);
        return 1;
    Label_00E4:
        if (this.mineChargeTimeCounter >= this.mineChargeTime)
        {
            goto Label_0117;
        }
        this.mineChargeTimeCounter += 1;
        if (this.mineChargeTimeCounter != 7)
        {
            goto Label_0115;
        }
        this.DoMine();
    Label_0115:
        return 1;
    Label_0117:
        this.isMining = 0;
        this.mineReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalRangeShoot()
    {
        int num;
        Bullet bullet;
        Vector3 vector;
        Vector3 vector2;
        if (this.isTarBomb != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (this.isMining != null)
        {
            goto Label_002C;
        }
        if (base.isWalking == null)
        {
            goto Label_002E;
        }
    Label_002C:
        return 0;
    Label_002E:
        if (this.isRangeShooting != null)
        {
            goto Label_0102;
        }
        if (this.rangeShootReloadTimeCounter >= this.rangeShootReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        if (&this.rangeShootTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_009E;
        }
        base.transform.localScale = Vector3.one;
        goto Label_00BD;
    Label_009E:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00BD:
        this.isRangeShooting = 1;
        this.rangeShootChargeTimeCounter = 0;
        this.rangeShootCurrentShoot = 0;
        this.rangeShootReloadTimeCounter = 0;
        this.shootEnemies.Clear();
        this.FindShootAngle(base.transform.position, this.rangeShootPoint);
        return 1;
    Label_0102:
        if (this.rangeShootChargeTimeCounter >= this.rangeShootChargeTime)
        {
            goto Label_028B;
        }
        if (this.rangeShootCurrentShoot > 3)
        {
            goto Label_028B;
        }
        this.rangeShootChargeTimeCounter += 1;
        if (this.rangeShootChargeTimeCounter != this.rangeShootMaxShoots)
        {
            goto Label_01D8;
        }
        if (this.rangeShootCurrentShoot <= 0)
        {
            goto Label_01D8;
        }
        num = this.GetDamageRangeShoot();
        bullet = UnityEngine.Object.Instantiate(this.bulletPrefab, base.transform.position + new Vector3(0f, 14f, 0f), Quaternion.identity) as Bullet;
        base.stage.AddProjectile(bullet.transform);
        bullet.SetDamage(num);
        bullet.SetTarget(this.rangeShootTarget, &this.rangeShootPoint.x, &this.rangeShootPoint.y);
        this.AdjustBulletPosition(bullet);
        GameSoundManager.PlayShotgunSound();
        base.GainXpByDamage(num);
    Label_01D8:
        if (this.rangeShootChargeTimeCounter != 10)
        {
            goto Label_01F0;
        }
        if (this.rangeShootCurrentShoot == null)
        {
            goto Label_0209;
        }
    Label_01F0:
        if (this.rangeShootChargeTimeCounter != 14)
        {
            goto Label_0289;
        }
        if (this.rangeShootCurrentShoot <= 0)
        {
            goto Label_0289;
        }
    Label_0209:
        this.shootEnemies.Add(this.rangeShootTarget);
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_0263;
        }
        this.shootEnemies.Clear();
        if (this.FindRangeShootTarget() != null)
        {
            goto Label_0263;
        }
        this.isRangeShooting = 0;
        this.rangeShootReloadTimeCounter = 0;
        this.rangeShootCurrentShoot = 0;
        base.sprite.PlayAnim("reload");
        return 0;
    Label_0263:
        this.rangeShootCurrentShoot += 1;
        this.rangeShootChargeTimeCounter = 0;
        this.PlayAnimationShootCurrent();
        this.shootEnemies.Clear();
    Label_0289:
        return 1;
    Label_028B:
        this.isRangeShooting = 0;
        this.rangeShootReloadTimeCounter = 0;
        this.rangeShootCurrentShoot = 0;
        base.sprite.PlayAnim("reload");
        return 0;
    }

    protected bool EvalReload()
    {
        if (this.reloadChargeTimeCounter >= this.reloadChargeTime)
        {
            goto Label_0021;
        }
        this.reloadChargeTimeCounter += 1;
        return 1;
    Label_0021:
        this.isReloading = 0;
        this.reloadChargeTimeCounter = 0;
        return 0;
    }

    protected unsafe bool EvalTar()
    {
        Vector3 vector;
        if (this.isMining != null)
        {
            goto Label_002C;
        }
        if (base.isFighting != null)
        {
            goto Label_002C;
        }
        if (base.isWalking != null)
        {
            goto Label_002C;
        }
        if (this.isRangeShooting == null)
        {
            goto Label_002E;
        }
    Label_002C:
        return 0;
    Label_002E:
        if (this.isTarBomb != null)
        {
            goto Label_00E4;
        }
        if (this.tarBombReloadTimeCounter >= this.tarBombReloadTime)
        {
            goto Label_004C;
        }
        return 0;
    Label_004C:
        if (this.CanTar() != null)
        {
            goto Label_0059;
        }
        return 0;
    Label_0059:
        if (&this.tarBombPoint.x < &base.transform.position.x)
        {
            goto Label_0091;
        }
        base.transform.localScale = Vector3.one;
        goto Label_00B0;
    Label_0091:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00B0:
        this.isTarBomb = 1;
        this.tarBombChargeTimeCounter = 0;
        this.tarBombReloadTimeCounter = 0;
        base.sprite.PlayAnim("tar");
        base.GainXpByAbilityModifier(2, this.tarBombLevel);
        return 1;
    Label_00E4:
        if (this.tarBombChargeTimeCounter >= this.tarBombChargeTime)
        {
            goto Label_0118;
        }
        this.tarBombChargeTimeCounter += 1;
        if (this.tarBombChargeTimeCounter != 13)
        {
            goto Label_0116;
        }
        this.DoTar();
    Label_0116:
        return 1;
    Label_0118:
        this.isTarBomb = 0;
        this.tarBombReloadTimeCounter = 0;
        return 0;
    }

    protected unsafe bool FindRangeShootTarget()
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        creep = null;
        this.rangeShootTarget = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001A:
        try
        {
            goto Label_0068;
        Label_001F:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_0068;
            }
            if (this.MinRangeShootDistance(creep2) == null)
            {
                goto Label_0068;
            }
            if (this.OnRangeShoot(creep2) == null)
            {
                goto Label_0068;
            }
            if (this.CanTarget(creep2) == null)
            {
                goto Label_0068;
            }
            creep = creep2;
            goto Label_0073;
        Label_0068:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
        Label_0073:
            goto Label_008D;
        }
        finally
        {
        Label_0078:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0085;
            }
        Label_0085:
            disposable.Dispose();
        }
    Label_008D:
        if ((creep != null) == null)
        {
            goto Label_0106;
        }
        this.rangeShootTarget = creep;
        this.rangeShootPoint = new Vector2(&creep.transform.position.x + creep.xAdjust, &creep.transform.position.y + creep.yAdjust);
        if (this.rangeShootCurrentShoot != null)
        {
            goto Label_0104;
        }
        this.rangeShootPointOriginal = this.rangeShootPoint;
        this.rangeShootTargetOriginal = this.rangeShootTarget;
    Label_0104:
        return 1;
    Label_0106:
        return 0;
    }

    protected unsafe void FindReferenceNode()
    {
        int num;
        int num2;
        Vector2[][][] vectorArray;
        int num3;
        int num4;
        num = 0;
        num2 = 0;
        vectorArray = base.stage.GetPath();
        num3 = 0;
        goto Label_00D5;
    Label_0017:
        num4 = 0;
        goto Label_00C3;
    Label_001F:
        if (base.stage.StageHasTunnels() == null)
        {
            goto Label_003D;
        }
        if (this.OnTunnel(num3, num4) != null)
        {
            goto Label_00BD;
        }
    Label_003D:
        num2 = Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow(&(vectorArray[num3][0][num4]).y - &this.rangeCenterPosition.y, 2f) + Mathf.Pow(&(vectorArray[num3][0][num4]).x - &this.rangeCenterPosition.x, 2f)));
        if (num2 >= 60)
        {
            goto Label_00BD;
        }
        if (num == null)
        {
            goto Label_00AC;
        }
        if (num <= num2)
        {
            goto Label_00BD;
        }
    Label_00AC:
        this.referencePath = num3;
        this.referenceNode = num4;
        num = num2;
    Label_00BD:
        num4 += 1;
    Label_00C3:
        if (num4 < ((int) vectorArray[num3][0].Length))
        {
            goto Label_001F;
        }
        num3 += 1;
    Label_00D5:
        if (num3 < ((int) vectorArray.Length))
        {
            goto Label_0017;
        }
        return;
    }

    protected unsafe void FindShootAngle(Vector2 initPos, Vector2 desPos)
    {
        float num;
        float num2;
        double num3;
        num = &desPos.y - &initPos.y;
        num2 = &desPos.x - &initPos.x;
        num3 = (double) Mathf.Round((Mathf.Atan2(num, num2) * 180f) / 3.14f);
        if (num3 >= 0.0)
        {
            goto Label_0055;
        }
        num3 += 360.0;
    Label_0055:
        if (num3 <= 45.0)
        {
            goto Label_008F;
        }
        if (num3 >= 135.0)
        {
            goto Label_008F;
        }
        base.sprite.PlayAnim("shootAimUp");
        this.shootDir = 0;
        goto Label_011A;
    Label_008F:
        if (num3 < 135.0)
        {
            goto Label_00C9;
        }
        if (num3 > 240.0)
        {
            goto Label_00C9;
        }
        base.sprite.PlayAnim("shootAimLateral");
        this.shootDir = 1;
        goto Label_011A;
    Label_00C9:
        if (num3 <= 240.0)
        {
            goto Label_0103;
        }
        if (num3 >= 315.0)
        {
            goto Label_0103;
        }
        base.sprite.PlayAnim("shootAimDown");
        this.shootDir = 2;
        goto Label_011A;
    Label_0103:
        base.sprite.PlayAnim("shootAimLateral");
        this.shootDir = 1;
    Label_011A:
        return;
    }

    protected int GetDamageRangeShoot()
    {
        return UnityEngine.Random.Range(base.rangeShootMinDamage, base.rangeShootMaxDamage);
    }

    public override unsafe void InitWithPosition(Vector2 pos, Vector2 pRallyPoint, int pNameMax, bool pRespawnOnInit, Vector2 myRangePoint)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.rallyPoint = pRallyPoint;
        base.targetedTime = 60;
        base.respawnOnInit = pRespawnOnInit;
        base.rangePoint = myRangePoint;
        base.regenerateTime = 30;
        base.xAdjust = 5f;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.isLifeTimed = 1;
        base.lifeTimeCounter = 0;
        base.deadTimeCounter = base.deadTime - 1;
        return;
    }

    protected bool IsNearExit(Creep enemyOld, Creep enemyNew)
    {
        if ((enemyOld.GetSubPathCount() - enemyOld.GetCurrentNodeIndex()) <= (enemyNew.GetSubPathCount() - enemyNew.GetCurrentNodeIndex()))
        {
            goto Label_0021;
        }
        return 1;
    Label_0021:
        return 0;
    }

    protected override void LevelUpWithAnimation(bool playAnimation)
    {
        int num;
        if (playAnimation == null)
        {
            goto Label_000D;
        }
        base.LevelUpWithAnimation(playAnimation);
    Label_000D:
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_dwarf", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_dwarf", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_dwarf", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_dwarf", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_dwarf", "maxDamage", base.level);
        base.rangeShootMinDamage = (int) GameSettings.GetHeroSetting("hero_dwarf", "minRangeDamage", base.level);
        base.rangeShootMaxDamage = (int) GameSettings.GetHeroSetting("hero_dwarf", "maxRangeDamage", base.level);
        if (base.level != 1)
        {
            goto Label_00F2;
        }
        this.rangeShootMaxShoots = 2;
        goto Label_011E;
    Label_00F2:
        if (base.level != 5)
        {
            goto Label_010A;
        }
        this.rangeShootMaxShoots = 3;
        goto Label_011E;
    Label_010A:
        if (base.level != 10)
        {
            goto Label_011E;
        }
        this.rangeShootMaxShoots = 4;
    Label_011E:
        this.UpdateLifeBar();
        this.UpgradeMine();
        this.UpgradeTar();
        return;
    }

    protected unsafe bool MinRangeShootDistance(Creep myEnemy)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &myEnemy.transform.position.x - &base.transform.position.x;
        num3 = &myEnemy.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.rangeShootMinDistance))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected unsafe bool MinTarBombDistance(Creep myEnemy)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &myEnemy.transform.position.x - &base.transform.position.x;
        num3 = &myEnemy.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.tarBombMinDistance))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected bool OnRangeShoot(Creep myEnemy)
    {
        if (this.rangeShootCurrentShoot != null)
        {
            goto Label_0035;
        }
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeShootHeight, (float) this.rangeShootWidth, base.transform.position);
    Label_0035:
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeShootNearHeight, (float) this.rangeShootNearWidth, this.rangeShootPointOriginal);
    }

    protected bool OnRangeTar(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.tarBombRangeHeight, (float) this.tarBombRangeWidth, base.transform.position);
    }

    protected bool OnTunnel(int i, int j)
    {
        if (base.stage.HasTunnels(i) == null)
        {
            goto Label_0037;
        }
        if (j < base.stage.TunnelStart(i))
        {
            goto Label_0037;
        }
        if (j > base.stage.TunnelEnd(i))
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        return 0;
    }

    protected void PlayAnimationShootCurrent()
    {
        if (this.shootDir != 2)
        {
            goto Label_0021;
        }
        base.sprite.PlayAnim("shootDown");
        goto Label_005D;
    Label_0021:
        if (this.shootDir != 1)
        {
            goto Label_0042;
        }
        base.sprite.PlayAnim("shootLateral");
        goto Label_005D;
    Label_0042:
        if (this.shootDir != null)
        {
            goto Label_005D;
        }
        base.sprite.PlayAnim("shootUp");
    Label_005D:
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroDwarfDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroDwarfTauntIntro();
        return;
    }

    protected override bool RunSpecial()
    {
        this.rangeShootReloadTimeCounter += 1;
        this.tarBombReloadTimeCounter += 1;
        this.mineReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        if (this.EvalRangeShoot() == null)
        {
            goto Label_0044;
        }
        return 1;
    Label_0044:
        if (this.tarBombLevel == null)
        {
            goto Label_005C;
        }
        if (this.EvalTar() == null)
        {
            goto Label_005C;
        }
        return 1;
    Label_005C:
        if (this.mineLevel == null)
        {
            goto Label_0074;
        }
        if (this.EvalMine() == null)
        {
            goto Label_0074;
        }
        return 1;
    Label_0074:
        return 0;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        this.isTarBomb = 0;
        this.isMining = 0;
        this.isRangeShooting = 0;
        base.isCharging = 0;
        base.isLevelUp = 0;
        base.isFighting = 0;
        this.rangeShootCurrentShoot = 0;
        return;
    }

    protected void UpgradeMine()
    {
        if (base.level == 2)
        {
            goto Label_0025;
        }
        if (base.level == 5)
        {
            goto Label_0025;
        }
        if (base.level == 8)
        {
            goto Label_0025;
        }
        return;
    Label_0025:
        if (base.level != 2)
        {
            goto Label_003D;
        }
        this.mineLevel = 1;
        goto Label_0068;
    Label_003D:
        if (base.level != 5)
        {
            goto Label_0055;
        }
        this.mineLevel = 2;
        goto Label_0068;
    Label_0055:
        if (base.level != 8)
        {
            goto Label_0068;
        }
        this.mineLevel = 3;
    Label_0068:
        this.mineRangeWidth = (int) GameSettings.GetHeroSetting("hero_dwarf", "mineRangeWidth", 1);
        this.mineRangeHeight = Mathf.RoundToInt(((float) this.mineRangeWidth) * 0.7f);
        this.mineReloadTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "mineReloadTime", 1)) * 30;
        this.mineMax = ((int) GameSettings.GetHeroSetting("hero_dwarf", "mineMax", 1)) + (((int) GameSettings.GetHeroSetting("hero_dwarf", "mineMaxIncrement", 1)) * this.mineLevel);
        return;
    }

    protected void UpgradeTar()
    {
        if (base.level == 4)
        {
            goto Label_0026;
        }
        if (base.level == 7)
        {
            goto Label_0026;
        }
        if (base.level == 10)
        {
            goto Label_0026;
        }
        return;
    Label_0026:
        if (base.level != 4)
        {
            goto Label_003E;
        }
        this.tarBombLevel = 1;
        goto Label_006A;
    Label_003E:
        if (base.level != 7)
        {
            goto Label_0056;
        }
        this.tarBombLevel = 2;
        goto Label_006A;
    Label_0056:
        if (base.level != 10)
        {
            goto Label_006A;
        }
        this.tarBombLevel = 3;
    Label_006A:
        this.tarBombRangeWidth = (int) GameSettings.GetHeroSetting("hero_dwarf", "tarRangeWidth", 1);
        this.tarBombRangeHeight = Mathf.RoundToInt(((float) this.tarBombRangeWidth) * 0.7f);
        this.tarBombReloadTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "tarReloadTime", 1)) * 30;
        this.tarBombMinDistance = (int) GameSettings.GetHeroSetting("hero_dwarf", "tarMinDistance", 1);
        return;
    }

    private enum shootDirType
    {
        shootUp,
        shootLateral,
        shootDown
    }
}

