using System;
using System.Collections;
using UnityEngine;

public class GroundFreeze : MonoBehaviour
{
    private float delay;
    private float duration;
    private int durationInFrames;
    private bool isActive;
    private int level;
    private int range;
    private float slowFactor;
    private int slowReloadTime;
    private int slowReloadTimeCounter;
    private CreepSpawner spawner;
    private PackedSprite sprite;
    private int type;

    public GroundFreeze()
    {
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        base.Invoke("FadeOut", this.duration - this.delay);
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }

    private void FadeOut()
    {
        EffectFadeOutTimed timed;
        this.isActive = 0;
        base.gameObject.AddComponent<EffectFadeOutTimed>().Init(0.2f);
        return;
    }

    private void FixedUpdate()
    {
        float num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        if (this.isActive != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.durationInFrames -= 1;
        this.slowReloadTimeCounter += 1;
        if (this.slowReloadTimeCounter >= this.slowReloadTime)
        {
            goto Label_003A;
        }
        return;
    Label_003A:
        num = 0.7f;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0051:
        try
        {
            goto Label_0109;
        Label_0056:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0109;
            }
            if (creep.IsDead() != null)
            {
                goto Label_0109;
            }
            if (creep.isFlying != null)
            {
                goto Label_0109;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) Mathf.RoundToInt(((float) this.range) * num), (float) this.range, base.transform.position) == null)
            {
                goto Label_0109;
            }
            if ((creep.GetComponent<EnemyModifierSlow>() != null) == null)
            {
                goto Label_00ED;
            }
            creep.GetComponent<EnemyModifierSlow>().Reset(this.slowFactor, this.GetSlowDuration());
            goto Label_0109;
        Label_00ED:
            creep.gameObject.AddComponent<EnemyModifierSlow>().Init(this.slowFactor, this.GetSlowDuration());
        Label_0109:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0056;
            }
            goto Label_012E;
        }
        finally
        {
        Label_0119:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0126;
            }
        Label_0126:
            disposable.Dispose();
        }
    Label_012E:
        this.slowReloadTimeCounter = 0;
        return;
    }

    private float GetSlowDuration()
    {
        float num;
        float num2;
        num = ((float) (this.slowReloadTime + 1)) / 30f;
        num2 = ((float) this.durationInFrames) / 30f;
        if (num >= 0f)
        {
            goto Label_0034;
        }
        num = 2.147484E+09f;
        goto Label_0045;
    Label_0034:
        if (num2 >= 0f)
        {
            goto Label_0045;
        }
        num2 = 2.147484E+09f;
    Label_0045:
        return Mathf.Min(num, num2);
    }

    public void Init(float delay, int type, float slowFactor, int range, float duration, int abilityChillLevel)
    {
        this.duration = duration;
        this.durationInFrames = Mathf.RoundToInt(duration * 30f);
        this.slowFactor = slowFactor;
        this.range = range;
        this.delay = delay;
        this.slowReloadTime = 10;
        this.level = this.level;
        this.isActive = 1;
        this.type = type - 1;
        base.Invoke("PlayAnimation", delay);
        this.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        return;
    }

    private void PlayAnimation()
    {
        this.sprite.PlayAnim(this.type);
        this.sprite.Hide(0);
        return;
    }

    private void Start()
    {
    }
}

