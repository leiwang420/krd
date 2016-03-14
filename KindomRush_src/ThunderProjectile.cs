using System;
using System.Collections;
using UnityEngine;

public class ThunderProjectile : MonoBehaviour
{
    private int maxDamage;
    private int minDamage;
    private int rangeHeight;
    private int rangeWidth;
    private CreepSpawner spawner;
    private StageBase stage;

    public ThunderProjectile()
    {
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_004F;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_004F;
            }
            if (this.OnRange(creep) == null)
            {
                goto Label_004F;
            }
            creep.Damage(this.GetDamage(), 0, 0, 0);
        Label_004F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_0071;
        }
        finally
        {
        Label_005F:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006A;
            }
        Label_006A:
            disposable.Dispose();
        }
    Label_0071:
        return;
    }

    private void FixedUpdate()
    {
    }

    private int GetDamage()
    {
        return UnityEngine.Random.Range(this.minDamage, this.maxDamage + 1);
    }

    public unsafe void Init(int myLevel, CreepSpawner spwn, Vector2 pos)
    {
        base.transform.position = new Vector3(&pos.x, &pos.y + 100f, -890f);
        this.spawner = spwn;
        this.minDamage = ((int) GameSettings.GetHeroSetting("hero_mage", "thunderMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_mage", "thunderDamageIncrement", 1)) * myLevel);
        this.maxDamage = ((int) GameSettings.GetHeroSetting("hero_mage", "thunderMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_mage", "thunderDamageIncrement", 1)) * myLevel);
        this.rangeWidth = (int) GameSettings.GetHeroSetting("hero_mage", "thunderRangeWidth", 1);
        this.rangeHeight = Mathf.RoundToInt(((float) this.rangeWidth) * 0.7f);
        return;
    }

    private bool OnRange(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeHeight, (float) this.rangeWidth, base.transform.position - new Vector3(0f, 40f, 0f));
    }

    public void SetStage(StageBase s)
    {
        this.stage = s;
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.GetComponent<PackedSprite>().SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        GameSoundManager.PlayHeroMageRainDrop();
        return;
    }
}

