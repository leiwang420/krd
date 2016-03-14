using System;
using System.Collections;
using UnityEngine;

public class MageTower : TowerBase
{
    private int frame;
    public Transform projectile;
    private Shooter shooter;
    public Transform shooterPrefab;
    private PackedSprite towerSprite;
    public float xOffset;
    public float yOffset;

    public MageTower()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        this.FlipArcher();
        this.towerSprite.PlayAnim("fire");
        return;
    }

    private unsafe void Fire()
    {
        Transform transform;
        Bolt bolt;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        transform = UnityEngine.Object.Instantiate(this.projectile, new Vector3(&base.transform.position.x, &base.transform.position.y, -900f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        if (base.yDest <= &this.shooter.transform.position.y)
        {
            goto Label_00B4;
        }
        transform.position += new Vector3(this.xOffset + 8f, this.yOffset + 2f, 0f);
        goto Label_00E7;
    Label_00B4:
        transform.position += new Vector3(this.xOffset - 4f, this.yOffset + 2f, 0f);
    Label_00E7:
        bolt = transform.GetComponent<Bolt>();
        bolt.SetDamage(UnityEngine.Random.Range(base.minDamange, base.maxDamage));
        if ((base.target == null) != null)
        {
            goto Label_0136;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0136;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_0154;
        }
    Label_0136:
        base.target = base.CheckRange((float) base.range, base.transform.position);
    Label_0154:
        bolt.SetTarget(base.target, base.xDest, base.yDest);
        bolt.SetStage(base.stage);
        GameSoundManager.PlayBoltSound();
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
            goto Label_00DF;
        }
        if (base.state != null)
        {
            goto Label_0034;
        }
        this.LookForTarget((float) base.range);
        goto Label_00DF;
    Label_0034:
        if (base.state != 1)
        {
            goto Label_009E;
        }
        this.frame += 1;
        base.timerReload += Time.deltaTime;
        if (this.frame != 9)
        {
            goto Label_0078;
        }
        this.Fire();
        goto Label_0099;
    Label_0078:
        if (this.frame != 15)
        {
            goto Label_00DF;
        }
        base.state = 2;
        this.frame = 0;
        this.SwitchIdleAnim();
    Label_0099:
        goto Label_00DF;
    Label_009E:
        if (base.state != 2)
        {
            goto Label_00DF;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_00DF;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_00DF:
        return;
    }

    private unsafe void FlipArcher()
    {
        float num;
        Vector3 vector;
        num = &this.shooter.transform.position.y;
        if (base.yDest <= num)
        {
            goto Label_003A;
        }
        this.shooter.PlayAnim("fireUp");
        goto Label_004A;
    Label_003A:
        this.shooter.PlayAnim("fire");
    Label_004A:
        return;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 1;
        base.wasAnimating = this.towerSprite.IsAnimating();
        this.towerSprite.PauseAnim();
        this.shooter.PauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_003A:
        try
        {
            goto Label_0064;
        Label_003F:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0064;
            }
            projectile.Pause();
        Label_0064:
            if (enumerator.MoveNext() != null)
            {
                goto Label_003F;
            }
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
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00A2;
        }
        denas.Pause();
    Label_00A2:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00BE;
        }
        base.veznanBlock.Pause();
    Label_00BE:
        return;
    }

    private void Start()
    {
        Transform transform;
        this.towerSprite = (PackedSprite) base.GetComponent("PackedSprite");
        transform = UnityEngine.Object.Instantiate(this.shooterPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        this.shooter = (Shooter) transform.GetComponent("Shooter");
        this.shooter.transform.localPosition = new Vector3(this.xOffset, this.yOffset, -1f);
        base.state = 2;
        this.frame = 0;
        if (base.name.EndsWith("1") == null)
        {
            goto Label_0105;
        }
        base.price = (int) GameSettings.GetTowerSetting("mage_level1", "price");
        base.range = (int) GameSettings.GetTowerSetting("mage_level1", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("mage_level1", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("mage_level1", "maxDamage");
        goto Label_01E4;
    Label_0105:
        if (base.name.EndsWith("2") == null)
        {
            goto Label_0177;
        }
        base.price = (int) GameSettings.GetTowerSetting("mage_level2", "price");
        base.range = (int) GameSettings.GetTowerSetting("mage_level2", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("mage_level2", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("mage_level2", "maxDamage");
        goto Label_01E4;
    Label_0177:
        if (base.name.EndsWith("3") == null)
        {
            goto Label_01E4;
        }
        base.price = (int) GameSettings.GetTowerSetting("mage_level3", "price");
        base.range = (int) GameSettings.GetTowerSetting("mage_level3", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("mage_level3", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("mage_level3", "maxDamage");
    Label_01E4:
        if (base.muteInitTaunt != null)
        {
            goto Label_01F4;
        }
        GameSoundManager.PlayMageTaunt();
    Label_01F4:
        return;
    }

    private unsafe void SwitchIdleAnim()
    {
        float num;
        Vector3 vector;
        num = &this.shooter.transform.position.y;
        this.shooter.Reset();
        if (base.yDest <= num)
        {
            goto Label_0045;
        }
        this.shooter.PlayAnim("up");
        goto Label_0050;
    Label_0045:
        this.shooter.RevertToStatic();
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
        if (base.wasAnimating == null)
        {
            goto Label_001D;
        }
        this.towerSprite.UnpauseAnim();
    Label_001D:
        this.shooter.UnpauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_0034:
        try
        {
            goto Label_005E;
        Label_0039:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_005E;
            }
            projectile.Unpause();
        Label_005E:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0039;
            }
            goto Label_0083;
        }
        finally
        {
        Label_006E:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007B;
            }
        Label_007B:
            disposable.Dispose();
        }
    Label_0083:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_009C;
        }
        denas.Unpause();
    Label_009C:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00B8;
        }
        base.veznanBlock.Unpause();
    Label_00B8:
        return;
    }
}

