using System;
using System.Collections;
using UnityEngine;

public class ArtilleryTower : TowerBase
{
    public float area;
    protected float fireAnimDT;
    public float fireDelay;
    public Transform projectile;
    protected PackedSprite towerSprite;

    public ArtilleryTower()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        this.fireAnimDT = 0f;
        this.towerSprite.PlayAnim("fire");
        return;
    }

    protected unsafe void Fire()
    {
        Transform transform;
        Bomb bomb;
        Vector3 vector;
        Vector3 vector2;
        if ((base.target == null) != null)
        {
            goto Label_0031;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0031;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_0037;
        }
    Label_0031:
        this.BeginFire();
    Label_0037:
        transform = UnityEngine.Object.Instantiate(this.projectile, new Vector3(&base.transform.position.x, &base.transform.position.y + 22f, -900f), base.transform.rotation) as Transform;
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
        goto Label_00C9;
    Label_0035:
        if (base.state != 1)
        {
            goto Label_0088;
        }
        this.fireAnimDT += Time.deltaTime;
        base.timerReload += Time.deltaTime;
        if (this.fireAnimDT <= this.fireDelay)
        {
            goto Label_00C9;
        }
        this.Fire();
        base.state = 2;
        goto Label_00C9;
    Label_0088:
        if (base.state != 2)
        {
            goto Label_00C9;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_00C9;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_00C9:
        return;
    }

    protected override unsafe void LookForTarget(float range)
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
            goto Label_00D6;
        Label_0025:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            num = creep2.GetNodesSpeed();
            vector2 = creep2.GetNode(num);
            &vector.Set(&vector2.x, &vector2.y, 0f);
            if (creep2.isFlying != null)
            {
                goto Label_00D6;
            }
            if (creep2.IsActive() == null)
            {
                goto Label_00D6;
            }
            if (IronUtils.ellipseContainPoint(vector, range * 0.7f, range, base.transform.position + new Vector3(0f, (float) -base.yAdjust, 0f)) == null)
            {
                goto Label_00D6;
            }
            if ((creep == null) != null)
            {
                goto Label_00D3;
            }
            if (base.IsNearExit(creep, creep2) == null)
            {
                goto Label_00D6;
            }
        Label_00D3:
            creep = creep2;
        Label_00D6:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0025;
            }
            goto Label_00FB;
        }
        finally
        {
        Label_00E6:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00F3;
            }
        Label_00F3:
            disposable.Dispose();
        }
    Label_00FB:
        if ((creep != null) == null)
        {
            goto Label_0199;
        }
        base.target = creep;
        num2 = base.target.GetNodesSpeed();
        vector = base.target.GetNode(num2);
        veznan = base.target.GetComponent<CreepVeznan>();
        if ((veznan != null) == null)
        {
            goto Label_0179;
        }
        if (veznan.IsDemon() == null)
        {
            goto Label_0179;
        }
        base.xDest = &vector.x;
        base.yDest = &vector.y - 40f;
        goto Label_0193;
    Label_0179:
        base.xDest = &vector.x;
        base.yDest = &vector.y;
    Label_0193:
        this.BeginFire();
    Label_0199:
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
        enumerator = base.transform.GetEnumerator();
    Label_002F:
        try
        {
            goto Label_0059;
        Label_0034:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0059;
            }
            projectile.Pause();
        Label_0059:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0034;
            }
            goto Label_007E;
        }
        finally
        {
        Label_0069:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0076;
            }
        Label_0076:
            disposable.Dispose();
        }
    Label_007E:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_0097;
        }
        denas.Pause();
    Label_0097:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00B3;
        }
        base.veznanBlock.Pause();
    Label_00B3:
        return;
    }

    private void Start()
    {
        this.fireAnimDT = 0f;
        this.towerSprite = (PackedSprite) base.GetComponent("PackedSprite");
        base.state = 2;
        base.timerReload = 0f;
        if (base.name.EndsWith("1") == null)
        {
            goto Label_00A5;
        }
        base.price = (int) GameSettings.GetTowerSetting("artillery_level1", "price");
        base.range = (int) GameSettings.GetTowerSetting("artillery_level1", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("artillery_level1", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("artillery_level1", "maxDamage");
        goto Label_0184;
    Label_00A5:
        if (base.name.EndsWith("2") == null)
        {
            goto Label_0117;
        }
        base.price = (int) GameSettings.GetTowerSetting("artillery_level2", "price");
        base.range = (int) GameSettings.GetTowerSetting("artillery_level2", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("artillery_level2", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("artillery_level2", "maxDamage");
        goto Label_0184;
    Label_0117:
        if (base.name.EndsWith("3") == null)
        {
            goto Label_0184;
        }
        base.price = (int) GameSettings.GetTowerSetting("artillery_level3", "price");
        base.range = (int) GameSettings.GetTowerSetting("artillery_level3", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("artillery_level3", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("artillery_level3", "maxDamage");
    Label_0184:
        GameSoundManager.PlayArtilleryTaunt();
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
        enumerator = base.transform.GetEnumerator();
    Label_0029:
        try
        {
            goto Label_0053;
        Label_002E:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0053;
            }
            projectile.Unpause();
        Label_0053:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002E;
            }
            goto Label_0078;
        }
        finally
        {
        Label_0063:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0070;
            }
        Label_0070:
            disposable.Dispose();
        }
    Label_0078:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_0091;
        }
        denas.Unpause();
    Label_0091:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00AD;
        }
        base.veznanBlock.Unpause();
    Label_00AD:
        return;
    }
}

