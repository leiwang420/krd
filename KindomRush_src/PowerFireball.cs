using System;
using System.Collections;
using UnityEngine;

public class PowerFireball : MonoBehaviour
{
    private float aceleration;
    public Transform bombCraterDecalPrefab;
    private int damage;
    public Transform explosionPrefab;
    public Transform fireballParticlePrefab;
    private bool isActive;
    private bool isPaused;
    private float maxAceleration;
    private int particleCounter;
    private int rangeHeight;
    private int rangeWidth;
    public Transform scorchedEarthPrefab;
    private Transform shadow;
    public Transform shadowPrefab;
    private CreepSpawner spawner;
    private StageBase stage;
    private Vector2 targetPoint;
    private int totalParticles;
    private float xSpeed;
    private float ySpeed;

    public PowerFireball()
    {
        this.totalParticles = 10;
        base..ctor();
        return;
    }

    private void DamageEnemies()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Stage8 stage;
        TowerSasquatch sasquatch;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_008D;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_008D;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.rangeHeight, (float) this.rangeWidth, base.transform.position) == null)
            {
                goto Label_008D;
            }
            creep.Damage(this.damage, 0, 0, 0);
            if ((creep != null) == null)
            {
                goto Label_008D;
            }
            if (creep.IsDead() == null)
            {
                goto Label_008D;
            }
            GameAchievements.AddFireballKill();
        Label_008D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
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
        stage = GameObject.Find("Stage").GetComponent<Stage8>();
        if ((stage != null) == null)
        {
            goto Label_011B;
        }
        sasquatch = stage.transform.FindChild("Sasquash Cave Top").GetComponent<TowerSasquatch>();
        if (IronUtils.ellipseContainPoint(sasquatch.transform.position, (float) this.rangeHeight, (float) this.rangeWidth, base.transform.position) == null)
        {
            goto Label_011B;
        }
        sasquatch.OpenCave();
    Label_011B:
        return;
    }

    private void FixedUpdate()
    {
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.Fly();
        return;
    }

    private unsafe void Fly()
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        num = 0f;
        num2 = 0f;
        num3 = 0f;
        num = &this.targetPoint.y - &base.transform.position.y;
        num2 = &this.targetPoint.x - &base.transform.position.x;
        num3 = Mathf.Atan2(num, num2);
        if (this.aceleration >= this.maxAceleration)
        {
            goto Label_00A7;
        }
        this.aceleration += Mathf.Ceil(this.aceleration * 0.05f);
        if (this.aceleration < this.maxAceleration)
        {
            goto Label_00A7;
        }
        this.aceleration = this.maxAceleration;
    Label_00A7:
        this.ySpeed = Mathf.Sin(num3) * this.aceleration;
        this.xSpeed = Mathf.Cos(num3) * this.aceleration;
        base.transform.rotation = Quaternion.Euler(0f, 0f, 360f - (Mathf.Atan2(this.ySpeed, this.xSpeed) * 57.29578f));
        base.transform.position = new Vector3(&base.transform.position.x + this.xSpeed, &base.transform.position.y + this.ySpeed, -900f);
        this.FreeParticles();
        float introduced9 = Mathf.Pow(&this.targetPoint.y - &base.transform.position.y, 2f);
        if (Mathf.Sqrt(introduced9 + Mathf.Pow(&this.targetPoint.x - &base.transform.position.x, 2f)) >= this.aceleration)
        {
            goto Label_01C0;
        }
        this.Hit();
    Label_01C0:
        return;
    }

    private unsafe void FreeParticles()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        transform = UnityEngine.Object.Instantiate(this.fireballParticlePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 40f, -899f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform);
        transform = UnityEngine.Object.Instantiate(this.fireballParticlePrefab, new Vector3(&base.transform.position.x + (this.xSpeed / 2f), (&base.transform.position.y + 40f) + (this.ySpeed / 2f), -899f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform);
        return;
    }

    private unsafe void FreeScorchedEarth()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        if (GameUpgrades.RainUpScorchedEarth == null)
        {
            goto Label_00A0;
        }
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_002B;
        }
        if (this.stage.MaxUpgradeLevel < 2)
        {
            goto Label_00A0;
        }
    Label_002B:
        transform = UnityEngine.Object.Instantiate(this.scorchedEarthPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 20f, -2f), Quaternion.identity) as Transform;
        transform.GetComponent<PowerSorched>().SetStage(this.stage);
        this.stage.AddProjectile(transform);
        this.stage.AddEffect(transform);
    Label_00A0:
        return;
    }

    private unsafe void Hit()
    {
        Transform transform;
        Transform transform2;
        this.isActive = 0;
        this.aceleration = 0f;
        transform = UnityEngine.Object.Instantiate(this.bombCraterDecalPrefab, new Vector3(&this.targetPoint.x, &this.targetPoint.y - 20f, -1f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform);
        transform2 = UnityEngine.Object.Instantiate(this.explosionPrefab, new Vector3(&this.targetPoint.x, &this.targetPoint.y + 5f, -840f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform2);
        UnityEngine.Object.Destroy(this.shadow.gameObject);
        this.DamageEnemies();
        this.FreeScorchedEarth();
        UnityEngine.Object.Destroy(base.gameObject);
        GameSoundManager.PlayFireballHit();
        return;
    }

    public unsafe void InitWithPosition(Vector2 pos, Vector2 tPoint)
    {
        base.transform.position = new Vector3(&pos.x, &pos.y, -900f);
        this.targetPoint = tPoint;
        this.maxAceleration = 21.15f;
        this.aceleration = 14.1f;
        this.damage = UnityEngine.Random.Range(GameSettings.GetPowerSetting("power_fireball", "minDamage"), GameSettings.GetPowerSetting("power_fireball", "minDamage") + 1);
        this.rangeWidth = GameSettings.GetPowerSetting("power_fireball", "range");
        this.rangeHeight = Mathf.CeilToInt(((float) this.rangeWidth) * 0.7f);
        this.shadow = UnityEngine.Object.Instantiate(this.shadowPrefab, new Vector3(&this.targetPoint.x, &this.targetPoint.y, -900f), Quaternion.identity) as Transform;
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        base.GetComponent<PackedSprite>().PauseAnim();
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        GameSoundManager.PlayFireballRelease();
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        base.GetComponent<PackedSprite>().UnpauseAnim();
        return;
    }
}

