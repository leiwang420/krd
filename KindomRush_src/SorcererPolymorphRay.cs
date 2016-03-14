using System;
using UnityEngine;

public class SorcererPolymorphRay : Ray
{
    private bool firstHit;

    public SorcererPolymorphRay()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        if ((base.target == null) == null)
        {
            goto Label_001D;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_001D:
        base.durationTimeCounter += 1;
        this.Hit();
        if (base.durationTimeCounter <= base.durationTime)
        {
            goto Label_0054;
        }
        base.durationTimeCounter = 0;
        UnityEngine.Object.Destroy(base.gameObject);
    Label_0054:
        base.Follow();
        base.Rotate();
        return;
    }

    public override void Hit()
    {
        if (this.firstHit != null)
        {
            goto Label_002D;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0026;
        }
        base.target.ShowSmoke();
    Label_0026:
        this.firstHit = 1;
    Label_002D:
        return;
    }

    private void Start()
    {
        base.sprite = base.GetComponent<PackedSprite>();
        base.GetDamage();
        base.durationTimeCounter = 0;
        base.durationTime = 10;
        base.anchorPoint = new Vector3(0f, 24f, 0f) + base.transform.position;
        base.originalPosition = base.transform.position;
        base.Follow();
        base.Rotate();
        GameSoundManager.PlayPolymorphSound();
        return;
    }
}

