using System;
using System.Collections;
using UnityEngine;

public class BFGTower : TowerBase
{
    public float area;
    private ClusterAbility cluster;
    protected int frame;
    protected int frameCluster;
    protected int frameMissile;
    private MissileAbility missile;
    public Transform projectile;
    protected PackedSprite towerSprite;

    public BFGTower()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        this.towerSprite.PlayAnim("fire");
        return;
    }

    protected unsafe void Fire()
    {
        Transform transform;
        Bomb bomb;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.projectile, new Vector3(&base.transform.position.x, &base.transform.position.y + 6f, -900f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        bomb = transform.GetComponent<Bomb>();
        bomb.SetDest(base.xDest, base.yDest);
        bomb.SetArea(this.area);
        bomb.SetDamage(base.minDamange, base.maxDamage);
        bomb.SetT1(31f);
        bomb.SetStage(base.stage);
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
            goto Label_013E;
        }
        if (base.state != null)
        {
            goto Label_0074;
        }
        if (this.cluster.IsReady() == null)
        {
            goto Label_0042;
        }
        this.cluster.LookForTarget();
        goto Label_006F;
    Label_0042:
        if (this.missile.IsReady() == null)
        {
            goto Label_0062;
        }
        this.missile.LookForTarget();
        goto Label_006F;
    Label_0062:
        this.LookForTarget((float) base.range);
    Label_006F:
        goto Label_013E;
    Label_0074:
        if (base.state != 1)
        {
            goto Label_00FD;
        }
        base.timerReload += Time.deltaTime;
        this.frame += 1;
        this.frameCluster += 1;
        this.frameMissile += 1;
        if (this.cluster.CanFire() == null)
        {
            goto Label_00D7;
        }
        this.SetupCluster();
        goto Label_00F8;
    Label_00D7:
        if (this.missile.CanFire() == null)
        {
            goto Label_00F2;
        }
        this.SetupMissile();
        goto Label_00F8;
    Label_00F2:
        this.SetupNormalShot();
    Label_00F8:
        goto Label_013E;
    Label_00FD:
        if (base.state != 2)
        {
            goto Label_013E;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_013E;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_013E:
        return;
    }

    public int GetClusterLevel()
    {
        return this.cluster.GetLevel();
    }

    public int GetMissileLevel()
    {
        return this.missile.GetLevel();
    }

    protected virtual unsafe void LookForTarget(float range)
    {
        Creep creep;
        Vector3 vector;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        int num;
        Vector2 vector2;
        int num2;
        CreepVeznan veznan;
        IDisposable disposable;
        creep = null;
        base.target = null;
        vector = Vector3.zero;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0020:
        try
        {
            goto Label_00DD;
        Label_0025:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            num = creep2.GetNodesSpeed();
            vector2 = creep2.GetNode(num);
            &vector.Set(&vector2.x, &vector2.y, 0f);
            if (creep2.isFlying != null)
            {
                goto Label_00DD;
            }
            if (creep2.IsActive() == null)
            {
                goto Label_00DD;
            }
            if (IronUtils.ellipseContainPoint(vector, range * 0.7f, range, base.transform.position + new Vector3(0f, (float) -(base.yAdjust + base.yRangeAdjust), 0f)) == null)
            {
                goto Label_00DD;
            }
            if ((creep == null) != null)
            {
                goto Label_00DA;
            }
            if (base.IsNearExit(creep, creep2) == null)
            {
                goto Label_00DD;
            }
        Label_00DA:
            creep = creep2;
        Label_00DD:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0025;
            }
            goto Label_0102;
        }
        finally
        {
        Label_00ED:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00FA;
            }
        Label_00FA:
            disposable.Dispose();
        }
    Label_0102:
        if ((creep != null) == null)
        {
            goto Label_01A0;
        }
        base.target = creep;
        num2 = base.target.GetNodesSpeed();
        vector = base.target.GetNode(num2);
        veznan = base.target.GetComponent<CreepVeznan>();
        if ((veznan != null) == null)
        {
            goto Label_0180;
        }
        if (veznan.IsDemon() == null)
        {
            goto Label_0180;
        }
        base.xDest = &vector.x;
        base.yDest = &vector.y - 40f;
        goto Label_019A;
    Label_0180:
        base.xDest = &vector.x;
        base.yDest = &vector.y;
    Label_019A:
        this.BeginFire();
    Label_01A0:
        return;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        ParticleEffect effect;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 1;
        base.wasAnimating = this.towerSprite.IsAnimating();
        this.towerSprite.PauseAnim();
        this.missile.Pause();
        this.cluster.Pause();
        enumerator = base.transform.GetEnumerator();
    Label_0045:
        try
        {
            goto Label_008D;
        Label_004A:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0074;
            }
            projectile.Pause();
            goto Label_008D;
        Label_0074:
            effect = transform.GetComponent<ParticleEffect>();
            if ((effect != null) == null)
            {
                goto Label_008D;
            }
            effect.Pause();
        Label_008D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004A;
            }
            goto Label_00B2;
        }
        finally
        {
        Label_009D:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00AA;
            }
        Label_00AA:
            disposable.Dispose();
        }
    Label_00B2:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00CE;
        }
        denas.Pause();
    Label_00CE:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00EA;
        }
        base.veznanBlock.Pause();
    Label_00EA:
        return;
    }

    protected void SetupCluster()
    {
        if (this.frameCluster != 0x17)
        {
            goto Label_001D;
        }
        this.cluster.Fire();
        goto Label_0046;
    Label_001D:
        if (this.frameCluster != 0x31)
        {
            goto Label_0046;
        }
        base.state = 2;
        this.frame = 0;
        this.frameCluster = 0;
        this.frameMissile = 0;
    Label_0046:
        return;
    }

    protected void SetupMissile()
    {
        if (this.frameMissile != 1)
        {
            goto Label_0021;
        }
        this.towerSprite.PlayAnim("fireMissile");
        goto Label_0072;
    Label_0021:
        if (this.frameMissile != 0x11)
        {
            goto Label_003E;
        }
        this.missile.Fire();
        goto Label_0072;
    Label_003E:
        if (this.frameMissile != 30)
        {
            goto Label_0072;
        }
        this.missile.Reset();
        base.state = 2;
        this.frame = 0;
        this.frameCluster = 0;
        this.frameMissile = 0;
    Label_0072:
        return;
    }

    protected void SetupNormalShot()
    {
        if (this.frame != 0x17)
        {
            goto Label_0018;
        }
        this.Fire();
        goto Label_0041;
    Label_0018:
        if (this.frame != 0x31)
        {
            goto Label_0041;
        }
        base.state = 2;
        this.frame = 0;
        this.frameCluster = 0;
        this.frameMissile = 0;
    Label_0041:
        return;
    }

    private void Start()
    {
        this.towerSprite = (PackedSprite) base.GetComponent("PackedSprite");
        this.cluster = base.GetComponent<ClusterAbility>();
        this.missile = base.GetComponent<MissileAbility>();
        base.state = 2;
        base.timerReload = 0f;
        base.price = (int) GameSettings.GetTowerSetting("artillery_bfg", "price");
        base.range = (int) GameSettings.GetTowerSetting("artillery_bfg", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("artillery_bfg", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("artillery_bfg", "maxDamage");
        GameSoundManager.PlayArtilleryBfgTaunt();
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        ParticleEffect effect;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 0;
        this.missile.Unpause();
        this.cluster.Unpause();
        if (base.wasAnimating == null)
        {
            goto Label_0033;
        }
        this.towerSprite.UnpauseAnim();
    Label_0033:
        enumerator = base.transform.GetEnumerator();
    Label_003F:
        try
        {
            goto Label_0087;
        Label_0044:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_006E;
            }
            projectile.Unpause();
            goto Label_0087;
        Label_006E:
            effect = transform.GetComponent<ParticleEffect>();
            if ((effect != null) == null)
            {
                goto Label_0087;
            }
            effect.Unpause();
        Label_0087:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0044;
            }
            goto Label_00AC;
        }
        finally
        {
        Label_0097:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A4;
            }
        Label_00A4:
            disposable.Dispose();
        }
    Label_00AC:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00C8;
        }
        denas.Unpause();
    Label_00C8:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00E4;
        }
        base.veznanBlock.Unpause();
    Label_00E4:
        return;
    }
}

