using System;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public int animationIndex;
    public int animationIndexMax;
    public int animationIndexMin;
    public float animationPause;
    private float animationPauseCounter;
    public float animationPauseMax;
    public float animationPauseMin;
    private bool animationStarted;
    private bool isPaused;
    public float maxStart;
    public float minStart;
    private bool paused;
    public bool randomAnimation;
    public bool randomEachTime;
    public bool randomPause;
    public bool randomStart;
    private PackedSprite sprite;
    public float startupDelay;
    private float startupDelayCounter;

    public AnimationDelay()
    {
        this.startupDelay = 1f;
        this.animationPause = 1f;
        this.animationPauseMin = 1f;
        this.animationPauseMax = 2f;
        this.minStart = 0.5f;
        this.maxStart = 2f;
        this.animationIndex = -1;
        base..ctor();
        return;
    }

    private void AnimationDelegate(SpriteBase sprt)
    {
        this.paused = 1;
        this.animationPauseCounter = 0f;
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
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
        if (this.animationIndex == -1)
        {
            goto Label_013B;
        }
        if (this.startupDelayCounter >= this.startupDelay)
        {
            goto Label_003C;
        }
        this.startupDelayCounter += Time.deltaTime;
        return;
    Label_003C:
        if (this.animationStarted != null)
        {
            goto Label_0099;
        }
        this.sprite.Hide(0);
        this.animationStarted = 1;
        if (this.randomAnimation == null)
        {
            goto Label_0088;
        }
        this.sprite.PlayAnim(UnityEngine.Random.Range(this.animationIndexMin, this.animationIndexMax + 1));
        goto Label_0099;
    Label_0088:
        this.sprite.PlayAnim(this.animationIndex);
    Label_0099:
        if (this.paused == null)
        {
            goto Label_013B;
        }
        this.animationPauseCounter += Time.deltaTime;
        if (this.animationPauseCounter < this.animationPause)
        {
            goto Label_013B;
        }
        this.paused = 0;
        this.sprite.Hide(0);
        if (this.randomAnimation == null)
        {
            goto Label_0108;
        }
        this.sprite.PlayAnim(UnityEngine.Random.Range(this.animationIndexMin, this.animationIndexMax + 1));
        goto Label_0119;
    Label_0108:
        this.sprite.PlayAnim(this.animationIndex);
    Label_0119:
        if (this.randomEachTime == null)
        {
            goto Label_013B;
        }
        this.animationPause = UnityEngine.Random.Range(this.animationPauseMin, this.animationPauseMax);
    Label_013B:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public void SetCurrentAnim(int index)
    {
        this.animationIndex = index;
        if (this.animationIndex == null)
        {
            goto Label_002E;
        }
        this.sprite.PlayAnim(this.animationIndex);
        this.sprite.PauseAnim();
    Label_002E:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        if (this.randomPause == null)
        {
            goto Label_004C;
        }
        this.animationPause *= UnityEngine.Random.Range(this.animationPauseMin, this.animationPauseMax);
    Label_004C:
        if (this.randomStart == null)
        {
            goto Label_0075;
        }
        this.startupDelay *= UnityEngine.Random.Range(this.minStart, this.maxStart);
    Label_0075:
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

