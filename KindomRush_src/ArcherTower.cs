using System;
using System.Collections;
using UnityEngine;

public class ArcherTower : TowerBase
{
    private int frame;
    private Arrow lastArrow;
    public int level;
    public Transform muzzleFlashPrefab;
    private PoisonAbility poison;
    public Transform projectile;
    private int shooter;
    private Shooter shooterOne;
    public Transform shooterPrefab;
    private Shooter shooterTwo;
    private ThornsAbility thorns;
    public float xOffset;
    public float yOffset;

    public ArcherTower()
    {
        base..ctor();
        return;
    }

    private void ApplyPoison(Arrow a)
    {
        if ((this.poison != null) == null)
        {
            goto Label_001D;
        }
        this.poison.ApplyPoison(a);
    Label_001D:
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        if (this.shooter != null)
        {
            goto Label_0023;
        }
        this.FlipArcher(this.shooterOne);
        goto Label_002F;
    Label_0023:
        this.FlipArcher(this.shooterTwo);
    Label_002F:
        return;
    }

    private unsafe void Fire()
    {
        Transform transform;
        int num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if (this.shooter != null)
        {
            goto Label_00DF;
        }
        this.shooter = 1;
        transform = UnityEngine.Object.Instantiate(this.projectile, new Vector3(&this.shooterOne.transform.position.x, &this.shooterOne.transform.position.y, -900f), base.transform.rotation) as Transform;
        if (&this.shooterOne.transform.localScale.x != 1f)
        {
            goto Label_00B5;
        }
        transform.position += new Vector3(8f, 0f, 0f);
        goto Label_00DA;
    Label_00B5:
        transform.position += new Vector3(-8f, 0f, 0f);
    Label_00DA:
        goto Label_01B0;
    Label_00DF:
        transform = UnityEngine.Object.Instantiate(this.projectile, new Vector3(&this.shooterTwo.transform.position.x, &this.shooterTwo.transform.position.y, -900f), base.transform.rotation) as Transform;
        this.shooter = 0;
        if (&this.shooterTwo.transform.localScale.x != 1f)
        {
            goto Label_018B;
        }
        transform.position += new Vector3(8f, 0f, 0f);
        goto Label_01B0;
    Label_018B:
        transform.position += new Vector3(-8f, 0f, 0f);
    Label_01B0:
        num = UnityEngine.Random.Range(base.minDamange, base.maxDamage + 1);
        if (GameUpgrades.ArchersUpPrecision == null)
        {
            goto Label_020C;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_01EF;
        }
        if (base.stage.MaxUpgradeLevel != 5)
        {
            goto Label_020C;
        }
    Label_01EF:
        if (UnityEngine.Random.Range(0f, 1f) > 0.1f)
        {
            goto Label_020C;
        }
        num *= 2;
    Label_020C:
        ((BaseProjectile) transform.GetComponent("BaseProjectile")).SetDamage(num);
        if ((base.target == null) != null)
        {
            goto Label_0253;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0253;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_0271;
        }
    Label_0253:
        base.target = base.CheckRange((float) base.range, base.transform.position);
    Label_0271:
        ((BaseProjectile) transform.GetComponent("BaseProjectile")).SetTarget(base.target, base.xDest, base.yDest);
        this.lastArrow = transform.GetComponent("Arrow") as Arrow;
        this.lastArrow.SetT1(22f);
        this.ApplyPoison(this.lastArrow);
        if (GameUpgrades.ArchersUpPiercing == null)
        {
            goto Label_0301;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_02F5;
        }
        if (base.stage.MaxUpgradeLevel < 3)
        {
            goto Label_0301;
        }
    Label_02F5:
        this.lastArrow.ignoresArmor = 1;
    Label_0301:
        transform.parent = base.transform;
        GameSoundManager.PlayArrow();
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.isActive != null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        if (base.state != null)
        {
            goto Label_0035;
        }
        this.LookForTarget((float) base.range);
        goto Label_00DE;
    Label_0035:
        if (base.state != 1)
        {
            goto Label_009D;
        }
        this.frame += 1;
        base.timerReload += Time.deltaTime;
        if (this.frame != 6)
        {
            goto Label_0078;
        }
        this.Fire();
        goto Label_0098;
    Label_0078:
        if (this.frame != 8)
        {
            goto Label_00DE;
        }
        base.state = 2;
        this.frame = 0;
        this.SwitchIdleAnim();
    Label_0098:
        goto Label_00DE;
    Label_009D:
        if (base.state != 2)
        {
            goto Label_00DE;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_00DE;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_00DE:
        return;
    }

    private unsafe void FlipArcher(Shooter shooter)
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        num = &shooter.transform.position.x;
        num2 = &shooter.transform.position.y;
        if (base.yDest <= num2)
        {
            goto Label_0044;
        }
        shooter.PlayAnim("fireUp");
        goto Label_004F;
    Label_0044:
        shooter.PlayAnim("fire");
    Label_004F:
        if (base.xDest <= num)
        {
            goto Label_007F;
        }
        shooter.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_009E;
    Label_007F:
        shooter.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_009E:
        return;
    }

    public Arrow GetLastArrow()
    {
        return this.lastArrow;
    }

    public int GetPoisonLevel()
    {
        return this.poison.GetLevel();
    }

    public override int GetReturnValue()
    {
        if (GameUpgrades.ArchersUpSalvage == null)
        {
            goto Label_001D;
        }
        return Mathf.RoundToInt(((float) base.spent) * 0.9f);
    Label_001D:
        return Mathf.RoundToInt(((float) base.spent) * 0.6f);
    }

    public int GetThornsLevel()
    {
        return this.thorns.GetLevel();
    }

    protected override unsafe void LookForTarget(float range)
    {
        Creep creep;
        Creep creep2;
        Transform transform;
        IEnumerator enumerator;
        Creep creep3;
        Vector3 vector;
        IDisposable disposable;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        creep = null;
        creep2 = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0015:
        try
        {
            goto Label_0135;
        Label_001A:
            transform = (Transform) enumerator.Current;
            creep3 = transform.GetComponent<Creep>();
            vector = creep3.transform.position + new Vector3(&creep3.anchorPoint.x, &creep3.anchorPoint.y, 0f);
            if (creep3.IsActive() == null)
            {
                goto Label_0135;
            }
            if (creep3.IsDead() != null)
            {
                goto Label_0135;
            }
            if (IronUtils.ellipseContainPoint(vector, range * 0.7f, range, base.transform.position + new Vector3(0f, (float) -(base.yAdjust + base.yRangeAdjust), 0f)) == null)
            {
                goto Label_0135;
            }
            if ((creep3.GetModifier("EnemyModifierPoison") == null) == null)
            {
                goto Label_0118;
            }
            if ((this.poison != null) == null)
            {
                goto Label_0118;
            }
            if (this.poison.GetLevel() <= 0)
            {
                goto Label_0118;
            }
            if ((creep == null) != null)
            {
                goto Label_0110;
            }
            if (base.IsNearExit(creep, creep3) == null)
            {
                goto Label_0135;
            }
        Label_0110:
            creep = creep3;
            goto Label_0135;
        Label_0118:
            if ((creep2 == null) != null)
            {
                goto Label_0132;
            }
            if (base.IsNearExit(creep2, creep3) == null)
            {
                goto Label_0135;
            }
        Label_0132:
            creep2 = creep3;
        Label_0135:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
            goto Label_015A;
        }
        finally
        {
        Label_0145:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0152;
            }
        Label_0152:
            disposable.Dispose();
        }
    Label_015A:
        if ((creep != null) == null)
        {
            goto Label_01A8;
        }
        base.xDest = &creep.transform.position.x;
        base.yDest = &creep.transform.position.y;
        base.target = creep;
        this.BeginFire();
        return;
    Label_01A8:
        if ((creep2 != null) == null)
        {
            goto Label_01F5;
        }
        base.xDest = &creep2.transform.position.x;
        base.yDest = &creep2.transform.position.y;
        base.target = creep2;
        this.BeginFire();
    Label_01F5:
        return;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        Arrow arrow;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 1;
        if ((this.thorns != null) == null)
        {
            goto Label_0023;
        }
        this.thorns.Pause();
    Label_0023:
        this.shooterOne.PauseAnim();
        this.shooterTwo.PauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_0045:
        try
        {
            goto Label_006F;
        Label_004A:
            transform = (Transform) enumerator.Current;
            arrow = transform.GetComponent<Arrow>();
            if ((arrow != null) == null)
            {
                goto Label_006F;
            }
            arrow.Pause();
        Label_006F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004A;
            }
            goto Label_0094;
        }
        finally
        {
        Label_007F:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_008C;
            }
        Label_008C:
            disposable.Dispose();
        }
    Label_0094:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00AD;
        }
        denas.Pause();
    Label_00AD:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00C9;
        }
        base.veznanBlock.Pause();
    Label_00C9:
        return;
    }

    public override void Sell()
    {
        float num;
        base.DettachProjectiles();
        num = (GameUpgrades.ArchersUpSalvage == null) ? 0.6f : 0.9f;
        base.stage.AddGold(Mathf.RoundToInt(((float) base.spent) * num));
        UnityEngine.Object.Instantiate(base.smokeSellPrefab, base.transform.position, Quaternion.identity);
        UnityEngine.Object.Destroy(base.terrain.gameObject);
        base.buildTerrain.gameObject.SetActive(1);
        base.stage.AddSellTowerAchievement();
        GameSoundManager.PlayTowerSell();
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private unsafe void Start()
    {
        Transform transform;
        this.frame = 0;
        base.timerReload = 0f;
        this.shooter = 0;
        transform = UnityEngine.Object.Instantiate(this.shooterPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        this.shooterOne = (Shooter) transform.GetComponent("Shooter");
        this.shooterOne.transform.localPosition = new Vector3(-this.xOffset + 2f, this.yOffset, -1f);
        transform = UnityEngine.Object.Instantiate(this.shooterPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        this.shooterTwo = (Shooter) transform.GetComponent("Shooter");
        this.shooterTwo.transform.localPosition = new Vector3(this.xOffset + 2f, this.yOffset, -1f);
        base.state = 2;
        this.poison = base.transform.GetComponent<PoisonAbility>();
        this.thorns = base.transform.GetComponent<ThornsAbility>();
        if (this.level < 1)
        {
            goto Label_0170;
        }
        if (this.level > 3)
        {
            goto Label_0170;
        }
        base.range = (int) GameSettings.GetTowerSetting("archer_level" + &this.level.ToString(), "range");
        goto Label_0186;
    Label_0170:
        base.range = (int) GameSettings.GetTowerSetting("archer_ranger", "range");
    Label_0186:
        if (this.level == 1)
        {
            goto Label_01AA;
        }
        if (this.level == 2)
        {
            goto Label_01AA;
        }
        if (this.level != 3)
        {
            goto Label_01BF;
        }
    Label_01AA:
        if (base.muteInitTaunt != null)
        {
            goto Label_01BF;
        }
        GameSoundManager.PlayArcherTaunt();
        goto Label_01DB;
    Label_01BF:
        if (this.level != 4)
        {
            goto Label_01DB;
        }
        if (base.muteInitTaunt != null)
        {
            goto Label_01DB;
        }
        GameSoundManager.PlayRangerTaunt();
    Label_01DB:
        return;
    }

    private unsafe void SwitchIdleAnim()
    {
        float num;
        Vector3 vector;
        num = &this.shooterOne.transform.position.y;
        if (this.shooter != null)
        {
            goto Label_0060;
        }
        this.shooterTwo.Reset();
        if (base.yDest <= num)
        {
            goto Label_0050;
        }
        this.shooterTwo.PlayAnim("up");
        goto Label_005B;
    Label_0050:
        this.shooterTwo.RevertToStatic();
    Label_005B:
        goto Label_0097;
    Label_0060:
        this.shooterOne.Reset();
        if (base.yDest <= num)
        {
            goto Label_008C;
        }
        this.shooterOne.PlayAnim("up");
        goto Label_0097;
    Label_008C:
        this.shooterOne.RevertToStatic();
    Label_0097:
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        Arrow arrow;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 0;
        if ((this.thorns != null) == null)
        {
            goto Label_0023;
        }
        this.thorns.Unpause();
    Label_0023:
        this.shooterOne.UnpauseAnim();
        this.shooterTwo.UnpauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_0045:
        try
        {
            goto Label_006F;
        Label_004A:
            transform = (Transform) enumerator.Current;
            arrow = transform.GetComponent<Arrow>();
            if ((arrow != null) == null)
            {
                goto Label_006F;
            }
            arrow.Unpause();
        Label_006F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004A;
            }
            goto Label_0094;
        }
        finally
        {
        Label_007F:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_008C;
            }
        Label_008C:
            disposable.Dispose();
        }
    Label_0094:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00AD;
        }
        denas.Unpause();
    Label_00AD:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00C9;
        }
        base.veznanBlock.Unpause();
    Label_00C9:
        return;
    }
}

