using System;
using UnityEngine;

public class DeathRay : Ray
{
    public DeathRay()
    {
        base..ctor();
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
        this.Hit();
        return;
    }

    public override void Hit()
    {
        if ((base.target != null) == null)
        {
            goto Label_0045;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_0045;
        }
        base.target.Damage(base.damage, 0, 0, 0);
        base.target.Desintegrate();
        GameAchievements.DesintegrateEnemy();
    Label_0045:
        return;
    }

    public override void Pause()
    {
        base.isPaused = 1;
        base.sprite.PauseAnim();
        return;
    }

    private unsafe void Start()
    {
        Transform transform2;
        Transform transform1;
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        base.sprite = base.GetComponent<PackedSprite>();
        base.GetDamage();
        base.durationTimeCounter = 0;
        base.durationTime = 10;
        base.originalPosition = base.transform.position;
        base.anchorPoint = new Vector3(0f, 24f, 0f) + base.transform.position;
        base.Follow();
        base.Rotate();
        &vector = new Vector3(&base.target.transform.position.x, &base.target.transform.position.y, -840f);
        transform = UnityEngine.Object.Instantiate(base.hitPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.target.transform;
        GameSoundManager.PlayDesintegrateSound();
        if (&base.target.transform.position.y <= &this.towerPos.y)
        {
            goto Label_0152;
        }
        if (&base.target.transform.position.x >= &this.towerPos.x)
        {
            goto Label_0152;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(5f, 10f, 0f);
        goto Label_01CE;
    Label_0152:
        if (&base.target.transform.position.y >= &this.towerPos.y)
        {
            goto Label_01CE;
        }
        if (&base.target.transform.position.x >= &this.towerPos.x)
        {
            goto Label_01CE;
        }
        transform2 = base.transform;
        transform2.position += new Vector3(-5f, 5f, 0f);
    Label_01CE:
        return;
    }

    public override void Unpause()
    {
        base.isPaused = 0;
        base.sprite.UnpauseAnim();
        return;
    }
}

