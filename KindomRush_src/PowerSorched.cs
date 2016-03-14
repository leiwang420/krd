using System;
using System.Collections;
using UnityEngine;

public class PowerSorched : MonoBehaviour
{
    private int damage;
    private int damageTime;
    private int damageTimeCounter;
    private int durationTime;
    private int durationTimeCounter;
    private bool isActive;
    private int maxDamage;
    private int minDamage;
    private int rangeHeight;
    private int rangeWidth;
    private CreepSpawner spawner;
    private StageBase stage;

    public PowerSorched()
    {
        base..ctor();
        return;
    }

    private void DamageEnemies()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_007C;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_007C;
            }
            if (creep.isFlying != null)
            {
                goto Label_007C;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.rangeHeight, (float) this.rangeWidth, base.transform.position) == null)
            {
                goto Label_007C;
            }
            creep.Damage(this.damage, 1, 0, 0);
        Label_007C:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_009E;
        }
        finally
        {
        Label_008C:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0097;
            }
        Label_0097:
            disposable.Dispose();
        }
    Label_009E:
        return;
    }

    private void FadeOut()
    {
        ParticleFade fade;
        base.gameObject.AddComponent<ParticleFade>().fadeSpeed = 0.1f;
        return;
    }

    private void FixedUpdate()
    {
        if (this.isActive != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.durationTimeCounter += 1;
        this.damageTimeCounter += 1;
        if (this.durationTimeCounter < this.durationTime)
        {
            goto Label_0047;
        }
        this.isActive = 0;
        this.FadeOut();
        return;
    Label_0047:
        if (this.damageTimeCounter < this.damageTime)
        {
            goto Label_0065;
        }
        this.DamageEnemies();
        this.damageTimeCounter = 0;
    Label_0065:
        return;
    }

    public void Pause()
    {
        this.isActive = 0;
        return;
    }

    public void SetStage(StageBase s)
    {
        this.stage = s;
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.isActive = 1;
        this.durationTimeCounter = 0;
        this.damageTimeCounter = 0;
        if (GameUpgrades.RainUpBlazingEarth == null)
        {
            goto Label_00E1;
        }
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_0055;
        }
        if (this.stage.MaxUpgradeLevel < 4)
        {
            goto Label_00E1;
        }
    Label_0055:
        this.minDamage = GameSettings.GetPowerSetting("power_fireball", "blazingEarthMinDamage");
        this.maxDamage = GameSettings.GetPowerSetting("power_fireball", "blazingEarthMaxDamage");
        this.rangeWidth = GameSettings.GetPowerSetting("power_fireball", "blazingEarthRange");
        this.rangeHeight = Mathf.RoundToInt(((float) this.rangeWidth) * 0.7f);
        this.damageTime = GameSettings.GetPowerSetting("power_fireball", "blazingEarthDamageTime") * 30;
        this.durationTime = GameSettings.GetPowerSetting("power_fireball", "blazingEarthDuration") * 30;
        goto Label_0168;
    Label_00E1:
        this.minDamage = GameSettings.GetPowerSetting("power_fireball", "scorchedEarthMinDamage");
        this.maxDamage = GameSettings.GetPowerSetting("power_fireball", "scorchedEarthMaxDamage");
        this.rangeWidth = GameSettings.GetPowerSetting("power_fireball", "scorchedEarthRange");
        this.rangeHeight = Mathf.RoundToInt(((float) this.rangeWidth) * 0.7f);
        this.damageTime = GameSettings.GetPowerSetting("power_fireball", "scorchedEarthDamageTime") * 30;
        this.durationTime = GameSettings.GetPowerSetting("power_fireball", "scorchedEarthDuration") * 30;
    Label_0168:
        this.damage = this.minDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.maxDamage - this.minDamage)));
        return;
    }

    public void Unpause()
    {
        this.isActive = 1;
        return;
    }
}

