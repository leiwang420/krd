using System;
using UnityEngine;

public class TowerModifierHeroDenas : MonoBehaviour
{
    private int durationTime;
    private int durationTimeCounter;
    private PackedSprite effect;
    private bool isPaused;
    private float lessReloadTime;
    private int level;
    private int moreRange;
    private TowerBase target;
    private Transform tmp;

    public TowerModifierHeroDenas()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        ParticleFade fade;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.durationTimeCounter += 1;
        if (this.durationTimeCounter < this.durationTime)
        {
            goto Label_006F;
        }
        this.target.RemoveReloadModifier(this.lessReloadTime);
        this.target.RemoveRangeModifier(this.moreRange);
        this.effect.gameObject.AddComponent<ParticleFade>().fadeSpeed = 0.05f;
        UnityEngine.Object.Destroy(this);
    Label_006F:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.effect.PauseAnim();
        return;
    }

    public void SetLevel(int l)
    {
        this.level = l;
        return;
    }

    private void SetProperties()
    {
        this.lessReloadTime = this.target.GetReloadModifier((float) ((int) GameSettings.GetHeroSetting("hero_denas", "buffLessReloadPercent", 1)));
        this.moreRange = this.target.GetRangeModifier((int) GameSettings.GetHeroSetting("hero_denas", "buffMoreRangePercent", 1));
        this.durationTime = ((int) GameSettings.GetHeroSetting("hero_denas", "buffDurationTime", 1)) + ((this.level * ((int) GameSettings.GetHeroSetting("hero_denas", "buffDurationTimeIncrement", 1))) * 30);
        this.durationTimeCounter = 0;
        return;
    }

    public void SetTower(TowerBase t)
    {
        this.target = t;
        return;
    }

    private void Start()
    {
        Transform transform;
        Transform transform2;
        transform = Resources.Load("Prefabs/Particles & fx/TowerBuff", typeof(Transform)) as Transform;
        transform2 = UnityEngine.Object.Instantiate(transform, base.transform.position + new Vector3(0f, (float) this.target.yAdjustBuff, 0f), Quaternion.identity) as Transform;
        transform2.parent = this.target.transform;
        transform2.name = "TowerBuff";
        this.effect = transform2.GetComponent<PackedSprite>();
        this.SetProperties();
        this.target.AddReloadModifier(this.lessReloadTime);
        this.target.AddRangeModifier(this.moreRange);
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.effect.UnpauseAnim();
        return;
    }
}

