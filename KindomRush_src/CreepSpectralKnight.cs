using System;
using System.Collections;
using UnityEngine;

public class CreepSpectralKnight : CreepBlackburn
{
    protected bool activated;
    public Transform auraAreaEffect;
    public EnemyModifierRage auraModifier;
    public int auraRange;

    public CreepSpectralKnight()
    {
        base..ctor();
        return;
    }

    protected void applyAura()
    {
        Transform transform;
        IEnumerator enumerator;
        CreepFallenKnight knight;
        IDisposable disposable;
        if (this.activated != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        enumerator = base.spawner.transform.GetEnumerator();
    Label_001D:
        try
        {
            goto Label_009F;
        Label_0022:
            transform = (Transform) enumerator.Current;
            knight = transform.GetComponent<CreepFallenKnight>();
            if ((knight != null) == null)
            {
                goto Label_009F;
            }
            if (knight.IsActive() == null)
            {
                goto Label_009F;
            }
            if (this.isEnemyInRange(knight, new Vector3(0f, 0f, 0f)) == null)
            {
                goto Label_009F;
            }
            if ((knight.GetModifier("EnemyModifierFallenKnightAura") == null) == null)
            {
                goto Label_0093;
            }
            knight.gameObject.AddComponent<EnemyModifierFallenKnightAura>();
            goto Label_009F;
        Label_0093:
            knight.GetComponent<EnemyModifierFallenKnightAura>().ResetToLevel(0);
        Label_009F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0022;
            }
            goto Label_00C1;
        }
        finally
        {
        Label_00AF:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00BA;
            }
        Label_00BA:
            disposable.Dispose();
        }
    Label_00C1:
        return;
    }

    protected override void FixedUpdate()
    {
        Transform transform;
        base.FixedUpdate();
        if (this.activated != null)
        {
            goto Label_0088;
        }
        if (base.isRespawning != null)
        {
            goto Label_0088;
        }
        base.mainBar.gameObject.SetActive(1);
        this.activated = 1;
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.transform.parent = base.spawner.transform;
        transform = base.transform.FindChild("SpectralKnight Aura");
        if ((transform != null) == null)
        {
            goto Label_0088;
        }
        transform.GetComponent<PackedSprite>().Hide(0);
    Label_0088:
        return;
    }

    public override int GetArmorDamage(Constants.damageType damageType, int damage, int ignoreArmor)
    {
        if (damageType == 2)
        {
            goto Label_000F;
        }
        if (damageType == null)
        {
            goto Label_000F;
        }
        return 0;
    Label_000F:
        return base.GetArmorDamage(damageType, damage, ignoreArmor);
    }

    private float GetOffset(Creep creep)
    {
        return (Mathf.Round(creep.GetComponent<PackedSprite>().height / 2f) - 20f);
    }

    public void HideAura()
    {
    }

    protected override void InitCustomSettings()
    {
        base.isRespawning = 1;
        base.isActive = 0;
        base.respawnTime = 40;
        base.respawnTimeCounter = 0;
        base.mainBar.gameObject.SetActive(0);
        return;
    }

    protected bool isEnemyInRange(Creep creep, Vector3 point)
    {
        return IronUtils.ellipseContainPoint(creep.transform.position - new Vector3(0f, creep.yAdjust, 0f), ((float) this.auraRange) * 0.7f, (float) this.auraRange, base.transform.position + base.anchorPoint);
    }

    public void ShowAura()
    {
    }

    protected override void SpecialPasivePower()
    {
        base.SpecialPasivePower();
        this.applyAura();
        return;
    }
}

