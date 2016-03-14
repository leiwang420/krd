using System;
using System.Collections;
using UnityEngine;

public class RobotSawblade : MonoBehaviour
{
    private float acceleration;
    private int bounceCount;
    private int bounceMax;
    private int bounceRange;
    private int damage;
    private bool isActive;
    private Vector3 lastDestination;
    private float maxAcceleration;
    private int particleReloadTime;
    private int particleReloadTimeCounter;
    public Transform prefabParticle;
    public Transform prefabParticleHit;
    private Vector3 previousPosition;
    private StageBase stage;
    private Creep target;
    private float totalDamage;
    private Vector2 velocity;
    private ArrayList visitedTargets;

    public RobotSawblade()
    {
        base..ctor();
        return;
    }

    private unsafe void AddHitParticle(Creep enemy)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        UnityEngine.Object.Instantiate(this.prefabParticleHit, new Vector3(&enemy.transform.position.x, &enemy.transform.position.y + enemy.yAdjust, &enemy.transform.position.z - 1f), Quaternion.identity);
        return;
    }

    private void AddParticle(Vector3 position, float rotation)
    {
        object[] objArray1;
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.prefabParticle, position, Quaternion.identity) as Transform;
        transform.Rotate(new Vector3(0f, 0f, rotation));
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.4f };
        iTween.ScaleTo(transform.gameObject, iTween.Hash(objArray1));
        return;
    }

    private unsafe void AddParticles()
    {
        int num;
        Vector3 vector;
        int num2;
        Vector3 vector2;
        Vector3 vector3;
        float num3;
        Vector3 vector4;
        Vector3 vector5;
        num = 2;
        &vector = new Vector3(&base.transform.position.x - &this.previousPosition.x, &base.transform.position.y - &this.previousPosition.y, -749f);
        num2 = 0;
        goto Label_00C2;
    Label_0055:
        vector2 = vector * (1f - (((float) num2) / ((float) num)));
        &vector3 = new Vector3(&this.previousPosition.x + &vector2.x, &this.previousPosition.y + &vector2.y, -749f);
        num3 = 57.29578f * Mathf.Atan2(&vector.x, &vector.y);
        this.AddParticle(vector3, num3);
        num2 += 1;
    Label_00C2:
        if (num2 < num)
        {
            goto Label_0055;
        }
        return;
    }

    private void FixedUpdate()
    {
        Creep creep;
        if (this.isActive != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.previousPosition = base.transform.position;
        if (this.Travel() == null)
        {
            goto Label_01BD;
        }
        if ((this.target != null) == null)
        {
            goto Label_00A1;
        }
        if (this.target.IsActive() == null)
        {
            goto Label_00A1;
        }
        this.target.BloodSplatter();
        this.AddHitParticle(this.target);
        this.visitedTargets.Add(this.target);
        this.target.Damage(this.damage, 0, 0, 0);
        this.totalDamage += (float) this.damage;
        this.target = null;
    Label_00A1:
        if (this.bounceCount >= this.bounceMax)
        {
            goto Label_0182;
        }
        this.stage.IterateThroughEnemiesNear(base.transform.position - new Vector3(0f, 55f, 0f), 0, this.bounceRange, this, "IteratorFilter");
        if ((this.target == null) == null)
        {
            goto Label_0182;
        }
        if (this.visitedTargets.Count <= 0)
        {
            goto Label_0182;
        }
        creep = (Creep) this.visitedTargets[this.visitedTargets.Count - 1];
        this.visitedTargets.Clear();
        this.visitedTargets.Add(creep);
        this.stage.IterateThroughEnemiesNear(base.transform.position - new Vector3(0f, 55f, 0f), 0, this.bounceRange, this, "IteratorFilter");
    Label_0182:
        if ((this.target == null) == null)
        {
            goto Label_01AF;
        }
        this.isActive = 0;
        base.Invoke("KillMe", 0.0333f);
        goto Label_01BD;
    Label_01AF:
        this.bounceCount += 1;
    Label_01BD:
        this.particleReloadTimeCounter += 1;
        if (this.particleReloadTimeCounter < this.particleReloadTime)
        {
            goto Label_01E9;
        }
        this.AddParticles();
        this.particleReloadTimeCounter = 0;
    Label_01E9:
        return;
    }

    public unsafe void Init(Creep t, int level, Vector3 targetPosition, StageBase s)
    {
        Vector3 vector;
        this.target = t;
        this.totalDamage = 0f;
        this.stage = s;
        this.damage = (int) GameSettings.GetHeroSetting("hero_robot", "sawbladeDamage", level);
        this.bounceRange = (int) GameSettings.GetHeroSetting("hero_robot", "sawbladeBounceRange", level);
        this.bounceMax = (int) GameSettings.GetHeroSetting("hero_robot", "sawbladeJumps", level);
        this.bounceCount = 0;
        this.maxAcceleration = GameSettings.GetHeroSetting("hero_robot", "sawbladeMaxAcceleration", 1);
        this.acceleration = this.maxAcceleration;
        this.lastDestination = new Vector3(&targetPosition.x, &targetPosition.y + this.target.yAdjust, &base.transform.position.z);
        this.isActive = 1;
        this.particleReloadTime = 1;
        this.particleReloadTimeCounter = 0;
        this.visitedTargets = new ArrayList();
        return;
    }

    public bool IteratorFilter(Creep enemy)
    {
        if (enemy.IsActive() == null)
        {
            goto Label_0016;
        }
        if (enemy.IsDead() == null)
        {
            goto Label_0018;
        }
    Label_0016:
        return 0;
    Label_0018:
        if (this.visitedTargets.Contains(enemy) == null)
        {
            goto Label_002B;
        }
        return 0;
    Label_002B:
        this.target = enemy;
        return 1;
    }

    private void KillMe()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void Start()
    {
    }

    private unsafe bool Travel()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if ((this.target == null) != null)
        {
            goto Label_0021;
        }
        if (this.target.IsActive() != null)
        {
            goto Label_0028;
        }
    Label_0021:
        this.target = null;
    Label_0028:
        if ((this.target != null) == null)
        {
            goto Label_0093;
        }
        this.lastDestination = new Vector3(&this.target.transform.position.x, &this.target.transform.position.y + this.target.yAdjust, &base.transform.position.z);
    Label_0093:
        return this.TravelToDestination(this.lastDestination, this.acceleration);
    }

    private unsafe bool TravelToDestination(Vector3 destination, float distance)
    {
        float num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        num = Mathf.Atan2(&destination.y - &base.transform.position.y, &destination.x - &base.transform.position.x);
        if (this.acceleration >= this.maxAcceleration)
        {
            goto Label_0088;
        }
        this.acceleration += Mathf.Ceil(this.acceleration * 0.07f);
        if (this.acceleration < this.maxAcceleration)
        {
            goto Label_0088;
        }
        this.acceleration = this.maxAcceleration;
    Label_0088:
        &this.velocity.y = Mathf.Sin(num) * this.acceleration;
        &this.velocity.x = Mathf.Cos(num) * this.acceleration;
        &vector = new Vector3(&base.transform.position.x + &this.velocity.x, &base.transform.position.y + &this.velocity.y, &base.transform.position.z);
        if (Vector3.Distance(destination, base.transform.position) >= Vector3.Distance(vector, base.transform.position))
        {
            goto Label_0148;
        }
        base.transform.position = destination;
        return 1;
    Label_0148:
        base.transform.position = new Vector3(&base.transform.position.x + &this.velocity.x, &base.transform.position.y + &this.velocity.y, &base.transform.position.z);
        return 0;
    }
}

