using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class MusketeerTower : TowerBase
{
    private bool firingShrapnel;
    private bool firingSniper;
    private int frame;
    private int frameShrapnel;
    private int frameSniper;
    public Transform muzzleFlashPrefab;
    public Transform projectile;
    private int shooter;
    private Shooter shooterOne;
    public Transform shooterPrefab;
    private Shooter shooterTwo;
    private ShrapnelAbility shrapnel;
    public Transform shrapnelPrefab;
    private SniperAbility sniper;
    public float xOffset;
    public float yOffset;

    public MusketeerTower()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        if (this.shooter != null)
        {
            goto Label_0023;
        }
        this.FlipShooter(this.shooterOne);
        goto Label_002F;
    Label_0023:
        this.FlipShooter(this.shooterTwo);
    Label_002F:
        return;
    }

    private void CreateShrapnels()
    {
        int num;
        int num2;
        BombShrapnel shrapnel;
        num = 0;
        num2 = 0;
        goto Label_003F;
    Label_0009:
        shrapnel = this.SpawnShrapnel();
        this.shrapnel.ShrapnelSetup(shrapnel, num);
        shrapnel.SetStage(base.stage);
        num += 70;
        if (num2 != null)
        {
            goto Label_003B;
        }
        shrapnel.SetSound(1);
    Label_003B:
        num2 += 1;
    Label_003F:
        if (num2 < 5)
        {
            goto Label_0009;
        }
        GameSoundManager.PlayShrapnelSound();
        return;
    }

    private unsafe void Fire()
    {
        Transform transform3;
        Transform transform2;
        Transform transform1;
        Bullet bullet;
        Vector2 vector;
        int num;
        Vector3 vector2;
        Vector3 vector3;
        bullet = this.SpawnBullet();
        vector = this.MuzzlePosition(0);
        transform1 = bullet.transform;
        transform1.position += new Vector3(&vector.x, &vector.y);
        if (this.shooter != null)
        {
            goto Label_0082;
        }
        transform2 = bullet.transform;
        transform2.position += new Vector3(-(this.xOffset - 8f), this.yOffset, 0f);
        this.shooter = 1;
        goto Label_00BB;
    Label_0082:
        transform3 = bullet.transform;
        transform3.position += new Vector3(this.xOffset + 8f, this.yOffset, 0f);
        this.shooter = 0;
    Label_00BB:
        num = UnityEngine.Random.Range(base.minDamange, base.maxDamage + 1);
        if (GameUpgrades.ArchersUpPrecision == null)
        {
            goto Label_0117;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_00FA;
        }
        if (base.stage.MaxUpgradeLevel != 5)
        {
            goto Label_0117;
        }
    Label_00FA:
        if (UnityEngine.Random.Range(0f, 1f) > 0.1f)
        {
            goto Label_0117;
        }
        num *= 2;
    Label_0117:
        bullet.SetDamage(num);
        if (GameUpgrades.ArchersUpPiercing == null)
        {
            goto Label_0150;
        }
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_0149;
        }
        if (base.stage.MaxUpgradeLevel < 3)
        {
            goto Label_0150;
        }
    Label_0149:
        bullet.SetIgnoresArmor(1);
    Label_0150:
        if ((base.target == null) != null)
        {
            goto Label_0181;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0181;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_019F;
        }
    Label_0181:
        base.target = base.CheckRange((float) base.range, base.transform.position);
    Label_019F:
        if ((base.target == null) == null)
        {
            goto Label_01CD;
        }
        bullet.SetTarget(base.target, base.xDest, base.yDest);
        goto Label_0212;
    Label_01CD:
        bullet.SetTarget(base.target, &base.target.transform.position.x, &base.target.transform.position.y + ((float) base.yAdjust));
    Label_0212:
        this.MuzzleFlash(0);
        GameSoundManager.PlayShotgunSound();
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
        if (base.isActive == null)
        {
            goto Label_0171;
        }
        if (base.state != null)
        {
            goto Label_0056;
        }
        this.LookForTarget((float) base.range);
        this.firingSniper = this.sniper.LookForTarget();
        this.firingShrapnel = this.shrapnel.LookForTarget();
        goto Label_0171;
    Label_0056:
        if (base.state != 1)
        {
            goto Label_00FF;
        }
        if (this.sniper.CanFire() == null)
        {
            goto Label_009D;
        }
        if (this.firingSniper == null)
        {
            goto Label_009D;
        }
        this.firingShrapnel = 0;
        this.frameSniper += 1;
        this.SetupSniperShot();
        goto Label_00FA;
    Label_009D:
        if (this.shrapnel.CanFire() == null)
        {
            goto Label_00D8;
        }
        if (this.firingShrapnel == null)
        {
            goto Label_00D8;
        }
        this.firingSniper = 0;
        this.frameShrapnel += 1;
        this.SetupShrapnel();
        goto Label_00FA;
    Label_00D8:
        this.firingShrapnel = 0;
        this.firingSniper = 0;
        this.frame += 1;
        this.SetupNormalShot();
    Label_00FA:
        goto Label_0171;
    Label_00FF:
        if (base.state != 2)
        {
            goto Label_0171;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_0171;
        }
        base.timerReload = 0f;
        base.state = 0;
        this.firingShrapnel = 0;
        this.firingSniper = 0;
        this.frame += 1;
        this.frameShrapnel = 0;
        this.frameSniper = 0;
        this.frame = 0;
    Label_0171:
        return;
    }

    private unsafe void FlipShooter(Shooter shooter)
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

    public int GetShrapnelLevel()
    {
        return this.shrapnel.GetLevel();
    }

    public int GetSniperLevel()
    {
        return this.sniper.GetLevel();
    }

    private unsafe void MuzzleFlash(bool isSniper = false)
    {
        Transform transform;
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        if ((this.muzzleFlashPrefab != null) == null)
        {
            goto Label_010D;
        }
        transform = UnityEngine.Object.Instantiate(this.muzzleFlashPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -899f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.name = "muzzleflash";
        vector = this.MuzzlePosition(isSniper);
        if (this.shooter != 1)
        {
            goto Label_00BC;
        }
        transform.position += new Vector3(&vector.x - 12f, &vector.y + 18f, 0f);
        goto Label_00F1;
    Label_00BC:
        transform.position += new Vector3(&vector.x + 12f, &vector.y + 18f, 0f);
    Label_00F1:
        transform.transform.Rotate(0f, 0f, this.MuzzleRotation(isSniper));
    Label_010D:
        return;
    }

    private unsafe Vector2 MuzzlePosition(bool isSniper)
    {
        float num;
        float num2;
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        num = (isSniper == null) ? base.xDest : this.sniper.GetXDest();
        num2 = (isSniper == null) ? base.yDest : this.sniper.GetYDest();
        &vector = new Vector2(num - &base.transform.position.x, num2 - &base.transform.position.y);
        &vector.Normalize();
        vector *= 45f;
        return vector;
    }

    private unsafe float MuzzleRotation(bool isSniper)
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        float num6;
        Vector3 vector;
        Vector3 vector2;
        num = (isSniper == null) ? base.xDest : this.sniper.GetXDest();
        num2 = (isSniper == null) ? base.yDest : this.sniper.GetYDest();
        num3 = num2 - &base.transform.position.y;
        num4 = num - &base.transform.position.x;
        num6 = (Mathf.Atan2(num3, num4) * 180f) / 3.14f;
        return num6;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 1;
        this.shooterOne.PauseAnim();
        this.shooterTwo.PauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_0029:
        try
        {
            goto Label_0078;
        Label_002E:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0058;
            }
            projectile.Pause();
            goto Label_0078;
        Label_0058:
            if ((transform.name == "muzzleflash") == null)
            {
                goto Label_0078;
            }
            transform.GetComponent<PackedSprite>().PauseAnim();
        Label_0078:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002E;
            }
            goto Label_009D;
        }
        finally
        {
        Label_0088:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0095;
            }
        Label_0095:
            disposable.Dispose();
        }
    Label_009D:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00B6;
        }
        denas.Pause();
    Label_00B6:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00D2;
        }
        base.veznanBlock.Pause();
    Label_00D2:
        return;
    }

    public override void Sell()
    {
        float num;
        base.DettachProjectiles();
        num = (GameUpgrades.ArchersUpSalvage == null) ? 0.6f : 0.9f;
        base.stage.AddGold((int) (((float) base.spent) * num));
        UnityEngine.Object.Instantiate(base.smokeSellPrefab, base.transform.position, Quaternion.identity);
        UnityEngine.Object.Destroy(base.terrain.gameObject);
        base.buildTerrain.gameObject.SetActive(1);
        base.stage.AddSellTowerAchievement();
        GameSoundManager.PlayTowerSell();
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void SetupNormalShot()
    {
        if (this.frame != 6)
        {
            goto Label_0028;
        }
        if ((base.target != null) == null)
        {
            goto Label_005D;
        }
        this.Fire();
        goto Label_005D;
    Label_0028:
        if (this.frame != 8)
        {
            goto Label_005D;
        }
        base.state = 2;
        this.frame = 0;
        base.target = null;
        this.SwitchIdleAnim();
        this.firingShrapnel = 0;
        this.firingSniper = 0;
    Label_005D:
        return;
    }

    private unsafe void SetupShrapnel()
    {
        Vector3 vector;
        if (this.frameShrapnel != 1)
        {
            goto Label_00A2;
        }
        this.shooterTwo.transform.localScale = new Vector3(1f, 1f, 1f);
        if (this.shrapnel.GetYDest() <= &this.shooterTwo.transform.position.y)
        {
            goto Label_007D;
        }
        this.shooterOne.PlayAnim("fireShrapnelUp");
        this.shooterTwo.PlayAnim("cordUp");
        goto Label_009D;
    Label_007D:
        this.shooterOne.PlayAnim("fireShrapnel");
        this.shooterTwo.PlayAnim("cord");
    Label_009D:
        goto Label_0109;
    Label_00A2:
        if (this.frameShrapnel != 15)
        {
            goto Label_00BA;
        }
        this.CreateShrapnels();
        goto Label_0109;
    Label_00BA:
        if (this.frameShrapnel != 0x20)
        {
            goto Label_0109;
        }
        base.state = 2;
        this.frameShrapnel = 0;
        this.frameSniper = 0;
        this.frame = 0;
        base.target = null;
        this.SwitchIdleAnimSniper();
        this.shrapnel.Reset();
        this.firingShrapnel = 0;
        this.firingSniper = 0;
    Label_0109:
        return;
    }

    private unsafe void SetupSniperShot()
    {
        Transform transform1;
        Bullet bullet;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (this.frameSniper != 1)
        {
            goto Label_0116;
        }
        if (this.sniper.GetYDest() <= &this.shooterTwo.transform.position.y)
        {
            goto Label_0049;
        }
        this.shooterTwo.PlayAnim("binocularUp");
        goto Label_0059;
    Label_0049:
        this.shooterTwo.PlayAnim("binocular");
    Label_0059:
        if (this.sniper.GetXDest() <= &base.transform.position.x)
        {
            goto Label_00C9;
        }
        this.shooterOne.transform.localScale = new Vector3(1f, 1f, 1f);
        this.shooterTwo.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_0111;
    Label_00C9:
        this.shooterOne.transform.localScale = new Vector3(-1f, 1f, 1f);
        this.shooterTwo.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_0111:
        goto Label_022E;
    Label_0116:
        if (this.frameSniper != 0x15)
        {
            goto Label_0180;
        }
        this.shooterOne.StopAnim();
        if (this.sniper.GetYDest() <= &this.shooterOne.transform.position.y)
        {
            goto Label_016B;
        }
        this.shooterOne.PlayAnim("fireSniperUp");
        goto Label_017B;
    Label_016B:
        this.shooterOne.PlayAnim("fireSniper");
    Label_017B:
        goto Label_022E;
    Label_0180:
        if (this.frameSniper != 0x1b)
        {
            goto Label_01DF;
        }
        bullet = this.SpawnBullet();
        transform1 = bullet.transform;
        transform1.position += new Vector3(-(this.xOffset - 8f), this.yOffset, 0f);
        this.sniper.BulletSetup(bullet);
        this.MuzzleFlash(1);
        goto Label_022E;
    Label_01DF:
        if (this.frameSniper != 0x2d)
        {
            goto Label_022E;
        }
        base.state = 2;
        this.frameSniper = 0;
        this.frameShrapnel = 0;
        this.frame = 0;
        base.target = null;
        this.SwitchIdleAnimSniper();
        this.sniper.Reset();
        this.firingSniper = 0;
        this.firingShrapnel = 0;
    Label_022E:
        return;
    }

    private Bullet SpawnBullet()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.projectile, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        return transform.GetComponent<Bullet>();
    }

    private BombShrapnel SpawnShrapnel()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.shrapnelPrefab, base.transform.position + new Vector3(-(this.xOffset - 8f), this.yOffset, 0f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        return transform.GetComponent<BombShrapnel>();
    }

    private void Start()
    {
        Transform transform;
        this.frame = 0;
        this.frameSniper = 0;
        this.frameShrapnel = 0;
        base.timerReload = 0f;
        this.shooter = 0;
        transform = UnityEngine.Object.Instantiate(this.shooterPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        this.shooterOne = (Shooter) transform.GetComponent("Shooter");
        this.shooterOne.transform.localPosition = new Vector3(-this.xOffset, this.yOffset, -1f);
        transform = UnityEngine.Object.Instantiate(this.shooterPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        this.shooterTwo = (Shooter) transform.GetComponent("Shooter");
        this.shooterTwo.transform.localPosition = new Vector3(this.xOffset, this.yOffset, -1f);
        base.state = 2;
        this.sniper = base.transform.GetComponent("SniperAbility") as SniperAbility;
        this.shrapnel = base.transform.GetComponent("ShrapnelAbility") as ShrapnelAbility;
        base.range = (int) GameSettings.GetTowerSetting("archer_musketeer", "range");
        GameSoundManager.PlayMusketeerTaunt();
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

    private unsafe void SwitchIdleAnimSniper()
    {
        float num;
        Vector3 vector;
        num = &this.shooterTwo.transform.position.y;
        this.shooterTwo.Reset();
        if (base.yDest <= num)
        {
            goto Label_0045;
        }
        this.shooterTwo.PlayAnim("up");
        goto Label_0050;
    Label_0045:
        this.shooterTwo.RevertToStatic();
    Label_0050:
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 0;
        this.shooterOne.UnpauseAnim();
        this.shooterTwo.UnpauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_0029:
        try
        {
            goto Label_0078;
        Label_002E:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0058;
            }
            projectile.Unpause();
            goto Label_0078;
        Label_0058:
            if ((transform.name == "muzzleflash") == null)
            {
                goto Label_0078;
            }
            transform.GetComponent<PackedSprite>().UnpauseAnim();
        Label_0078:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002E;
            }
            goto Label_009D;
        }
        finally
        {
        Label_0088:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0095;
            }
        Label_0095:
            disposable.Dispose();
        }
    Label_009D:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00B6;
        }
        denas.Unpause();
    Label_00B6:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00D2;
        }
        base.veznanBlock.Unpause();
    Label_00D2:
        return;
    }
}

