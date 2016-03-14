using System;
using System.Collections;
using UnityEngine;

public class ArcaneTower : TowerBase
{
    private DeathRayAbility deathRay;
    private int frame;
    private int frameDeathRay;
    private int frameTeleport;
    public Transform projectile;
    private Shooter shooter;
    public Transform shooterPrefab;
    private TeleportAbility teleport;
    private PackedSprite towerSprite;
    public float xOffset;
    public float yOffset;

    public ArcaneTower()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        this.FlipArcher();
        return;
    }

    private unsafe void Fire()
    {
        Transform transform;
        ArcaneRay ray;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if ((base.target == null) != null)
        {
            goto Label_0021;
        }
        if (base.target.IsActive() != null)
        {
            goto Label_0035;
        }
    Label_0021:
        base.target = null;
        this.LookForTarget((float) base.range);
    Label_0035:
        if ((base.target == null) == null)
        {
            goto Label_0047;
        }
        return;
    Label_0047:
        transform = UnityEngine.Object.Instantiate(this.projectile, new Vector3(&base.transform.position.x + 4f, &base.transform.position.y, -840f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        if (base.yDest <= &base.transform.position.y)
        {
            goto Label_00F6;
        }
        transform.position += new Vector3(this.xOffset + 3f, this.yOffset, 0f);
        goto Label_0123;
    Label_00F6:
        transform.position += new Vector3(this.xOffset - 6f, this.yOffset, 0f);
    Label_0123:
        if (base.xDest >= &base.transform.position.x)
        {
            goto Label_0167;
        }
        transform.position += new Vector3(3f, 0f, 0f);
    Label_0167:
        ray = transform.GetComponent<ArcaneRay>();
        ray.SetDamage(UnityEngine.Random.Range(base.minDamange, base.maxDamage));
        ray.SetTarget(base.target, base.xDest, base.yDest);
        ray.SetStage(base.stage);
        ray.SetTowerPos(&base.transform.position.x, &base.transform.position.y);
        transform.parent = base.transform;
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
            goto Label_0070;
        }
        this.LookForTarget((float) base.range);
        if (this.teleport.IsReady() == null)
        {
            goto Label_0050;
        }
        this.teleport.LookForTarget();
        goto Label_006B;
    Label_0050:
        if (this.deathRay.IsReady() == null)
        {
            goto Label_013A;
        }
        this.deathRay.LookForTarget();
    Label_006B:
        goto Label_013A;
    Label_0070:
        if (base.state != 1)
        {
            goto Label_00F9;
        }
        base.timerReload += Time.deltaTime;
        this.frameDeathRay += 1;
        this.frameTeleport += 1;
        this.frame += 1;
        if (this.deathRay.CanFire() == null)
        {
            goto Label_00D3;
        }
        this.SetupDeathRay();
        goto Label_00F4;
    Label_00D3:
        if (this.teleport.CanFire() == null)
        {
            goto Label_00EE;
        }
        this.SetupTeleport();
        goto Label_00F4;
    Label_00EE:
        this.SetupNormalShot();
    Label_00F4:
        goto Label_013A;
    Label_00F9:
        if (base.state != 2)
        {
            goto Label_013A;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_013A;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_013A:
        return;
    }

    private unsafe void FlipArcher()
    {
        float num;
        float num2;
        Vector3 vector;
        Vector3 vector2;
        num = &this.shooter.transform.position.x;
        num2 = &this.shooter.transform.position.y;
        if (base.yDest <= num2)
        {
            goto Label_0053;
        }
        this.shooter.PlayAnim("fireUp");
        goto Label_0063;
    Label_0053:
        this.shooter.PlayAnim("fire");
    Label_0063:
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
        this.teleport.Pause();
        this.deathRay.Pause();
        enumerator = base.transform.GetEnumerator();
    Label_0050:
        try
        {
            goto Label_007A;
        Label_0055:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_007A;
            }
            projectile.Pause();
        Label_007A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0055;
            }
            goto Label_009F;
        }
        finally
        {
        Label_008A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0097;
            }
        Label_0097:
            disposable.Dispose();
        }
    Label_009F:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00B8;
        }
        denas.Pause();
    Label_00B8:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00D4;
        }
        base.veznanBlock.Pause();
    Label_00D4:
        return;
    }

    private void SetupDeathRay()
    {
        if (this.frameDeathRay != 1)
        {
            goto Label_0021;
        }
        this.towerSprite.PlayAnim("fire");
        goto Label_006D;
    Label_0021:
        if (this.frameDeathRay != 0x18)
        {
            goto Label_003E;
        }
        this.deathRay.Fire();
        goto Label_006D;
    Label_003E:
        if (this.frameDeathRay != 0x31)
        {
            goto Label_006D;
        }
        base.state = 2;
        this.frameDeathRay = 0;
        this.frame = 0;
        this.frameTeleport = 0;
        this.SwitchIdleAnim();
    Label_006D:
        return;
    }

    private void SetupNormalShot()
    {
        if (this.frame != 1)
        {
            goto Label_0021;
        }
        this.towerSprite.PlayAnim("fire");
        goto Label_0068;
    Label_0021:
        if (this.frame != 0x13)
        {
            goto Label_0039;
        }
        this.Fire();
        goto Label_0068;
    Label_0039:
        if (this.frame != 0x31)
        {
            goto Label_0068;
        }
        base.state = 2;
        this.frame = 0;
        this.frameDeathRay = 0;
        this.frameTeleport = 0;
        this.SwitchIdleAnim();
    Label_0068:
        return;
    }

    private void SetupTeleport()
    {
        if (this.frameTeleport != 1)
        {
            goto Label_002C;
        }
        this.towerSprite.PlayAnim("teleport");
        this.teleport.ShowEffect();
        goto Label_0066;
    Label_002C:
        if (this.frameTeleport != 12)
        {
            goto Label_0066;
        }
        this.teleport.Fire();
        base.state = 2;
        this.frameDeathRay = 0;
        this.frame = 0;
        this.frameTeleport = 0;
        this.SwitchIdleAnim();
    Label_0066:
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
        this.frameDeathRay = 0;
        this.deathRay = base.GetComponent<DeathRayAbility>();
        this.teleport = base.GetComponent<TeleportAbility>();
        base.price = (int) GameSettings.GetTowerSetting("mage_arcane", "price");
        base.range = (int) GameSettings.GetTowerSetting("mage_arcane", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("mage_arcane", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("mage_arcane", "maxDamage");
        GameSoundManager.PlayMageArcaneTaunt();
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
        this.teleport.Unpause();
        this.deathRay.Unpause();
        if (base.wasAnimating == null)
        {
            goto Label_0033;
        }
        this.towerSprite.UnpauseAnim();
    Label_0033:
        this.shooter.UnpauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_004A:
        try
        {
            goto Label_0074;
        Label_004F:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0074;
            }
            projectile.Unpause();
        Label_0074:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004F;
            }
            goto Label_0099;
        }
        finally
        {
        Label_0084:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0091;
            }
        Label_0091:
            disposable.Dispose();
        }
    Label_0099:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00B2;
        }
        denas.Unpause();
    Label_00B2:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00CE;
        }
        base.veznanBlock.Unpause();
    Label_00CE:
        return;
    }
}

