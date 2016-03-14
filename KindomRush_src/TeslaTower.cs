using System;
using System.Collections;
using UnityEngine;

public class TeslaTower : TowerBase
{
    private int frame;
    private OverchargeAbility overcharge;
    public Transform rayPrefab;
    private SuperchargeAbility supercharge;
    private PackedSprite towerSprite;

    public TeslaTower()
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

    private unsafe void Fire()
    {
        Transform transform;
        ArrayList list;
        TeslaRay ray;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        transform = UnityEngine.Object.Instantiate(this.rayPrefab, new Vector3(&base.transform.position.x + 6f, &base.transform.position.y + 22f, -890f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        if ((base.target == null) != null)
        {
            goto Label_0096;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0096;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_00B4;
        }
    Label_0096:
        base.target = base.CheckRange((float) base.range, base.transform.position);
    Label_00B4:
        if ((base.target != null) == null)
        {
            goto Label_00D0;
        }
        this.overcharge.Fire();
    Label_00D0:
        list = new ArrayList();
        ray = transform.GetComponent<TeslaRay>();
        ray.Init(base.target, this.supercharge.GetJumpMax(), 1, &list, base.stage);
        ray.SetTowerPos(&base.transform.position.x, &base.transform.position.y);
        GameSoundManager.PlayTeslaAttack();
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
            goto Label_00AC;
        }
        if (base.state != null)
        {
            goto Label_0034;
        }
        this.LookForTarget((float) base.range);
        goto Label_00AC;
    Label_0034:
        if (base.state != 1)
        {
            goto Label_006B;
        }
        base.timerReload += Time.deltaTime;
        this.frame += 1;
        this.SetupNormalShot();
        goto Label_00AC;
    Label_006B:
        if (base.state != 2)
        {
            goto Label_00AC;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_00AC;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_00AC:
        return;
    }

    public int GetOverchargeLevel()
    {
        return this.overcharge.GetLevel();
    }

    public int GetSuperchargeLevel()
    {
        return this.supercharge.GetLevel();
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
        IDisposable disposable;
        creep = null;
        base.target = null;
        vector = Vector3.zero;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0020:
        try
        {
            goto Label_00CA;
        Label_0025:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            num = creep2.GetNodesSpeed();
            vector2 = creep2.GetNode(num);
            &vector.Set(&vector2.x, &vector2.y, 0f);
            if (creep2.IsActive() == null)
            {
                goto Label_00CA;
            }
            if (IronUtils.ellipseContainPoint(vector, range * 0.7f, range, base.transform.position + new Vector3(0f, (float) -base.yAdjust, 0f)) == null)
            {
                goto Label_00CA;
            }
            if ((creep == null) != null)
            {
                goto Label_00C7;
            }
            if (base.IsNearExit(creep, creep2) == null)
            {
                goto Label_00CA;
            }
        Label_00C7:
            creep = creep2;
        Label_00CA:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0025;
            }
            goto Label_00EF;
        }
        finally
        {
        Label_00DA:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E7;
            }
        Label_00E7:
            disposable.Dispose();
        }
    Label_00EF:
        if ((creep != null) == null)
        {
            goto Label_0142;
        }
        base.target = creep;
        num2 = base.target.GetNodesSpeed();
        vector = base.target.GetNode(num2);
        base.xDest = &vector.x;
        base.yDest = &vector.y;
        this.BeginFire();
    Label_0142:
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
        this.overcharge.Pause();
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

    private void SetupNormalShot()
    {
        if (this.frame != 0x31)
        {
            goto Label_0018;
        }
        this.Fire();
        goto Label_0033;
    Label_0018:
        if (this.frame != 0x41)
        {
            goto Label_0033;
        }
        base.state = 2;
        this.frame = 0;
    Label_0033:
        return;
    }

    private void Start()
    {
        this.towerSprite = base.GetComponent<PackedSprite>();
        this.supercharge = base.GetComponent<SuperchargeAbility>();
        this.overcharge = base.GetComponent<OverchargeAbility>();
        base.price = (int) GameSettings.GetTowerSetting("artillery_tesla", "price");
        base.range = (int) GameSettings.GetTowerSetting("artillery_tesla", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("artillery_tesla", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("artillery_tesla", "maxDamage");
        base.state = 2;
        base.stage.AddTeslaAchievement();
        GameSoundManager.PlayArtilleryTeslaTaunt();
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
        this.overcharge.Unpause();
        if (base.wasAnimating == null)
        {
            goto Label_0028;
        }
        this.towerSprite.UnpauseAnim();
    Label_0028:
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

