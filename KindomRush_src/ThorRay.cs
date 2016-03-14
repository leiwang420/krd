using System;
using System.Collections;
using UnityEngine;

public class ThorRay : Ray
{
    private int jumpCurrent;
    private ArrayList jumpEnemies;
    private int jumpMax;
    private int jumpRange;
    public Transform rayPrefab;
    private CreepSpawner spawner;

    public ThorRay()
    {
        base..ctor();
        return;
    }

    private bool CanJump(Creep myEnemy)
    {
        return (this.jumpEnemies.Contains((int) myEnemy.GetInstanceID()) == 0);
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if ((base.target == null) == null)
        {
            goto Label_0029;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0029:
        base.durationTimeCounter += 1;
        this.Hit();
        if (base.durationTimeCounter <= base.durationTime)
        {
            goto Label_0061;
        }
        base.durationTimeCounter = 0;
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0061:
        if (base.durationTimeCounter != 2)
        {
            goto Label_0084;
        }
        if (this.jumpCurrent >= this.jumpMax)
        {
            goto Label_0084;
        }
        this.Jump();
    Label_0084:
        base.Follow();
        base.Rotate();
        return;
    }

    public override void Hit()
    {
        int num;
        num = base.damage / base.durationTime;
        if ((base.durationTimeCounter + 1) != base.durationTime)
        {
            goto Label_002A;
        }
        num += base.extraDamage;
    Label_002A:
        if (base.target.IsActive() == null)
        {
            goto Label_0049;
        }
        base.target.Damage(num, 3, 0, 0);
    Label_0049:
        if ((base.target != null) == null)
        {
            goto Label_006F;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_006F;
        }
        GameAchievements.TeslaKill();
    Label_006F:
        return;
    }

    public unsafe void Init(Creep t, int jMax, int jCurrent, ref ArrayList je, StageBase s)
    {
        Vector3 vector;
        Vector3 vector2;
        base.stage = s;
        if ((t != null) == null)
        {
            goto Label_00B7;
        }
        base.target = t;
        base.xDest = &t.transform.position.x;
        base.yDest = &t.transform.position.y + t.yAdjust;
        this.jumpMax = jMax;
        this.jumpCurrent = jCurrent;
        this.jumpEnemies = *(je);
        this.jumpEnemies.Add((int) base.target.GetInstanceID());
        if (this.jumpMax <= 1)
        {
            goto Label_00AC;
        }
        base.yScale = 1f - (((float) this.jumpCurrent) * 0.12f);
    Label_00AC:
        base.GetDamage();
        goto Label_00C2;
    Label_00B7:
        UnityEngine.Object.Destroy(base.gameObject);
    Label_00C2:
        return;
    }

    private unsafe void Jump()
    {
        Creep creep;
        int num;
        int num2;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        Transform transform2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        creep = null;
        num = 0;
        num2 = 0;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0018:
        try
        {
            goto Label_00AB;
        Label_001D:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_00AB;
            }
            if (this.OnDistance(creep2) == null)
            {
                goto Label_00AB;
            }
            if (this.CanJump(creep2) == null)
            {
                goto Label_00AB;
            }
            if ((creep != null) == null)
            {
                goto Label_0095;
            }
            num2 = Mathf.Abs(base.target.GetCurrentNodeIndex() - creep.GetCurrentNodeIndex());
            num = Mathf.Abs(base.target.GetCurrentNodeIndex() - creep2.GetCurrentNodeIndex());
        Label_0095:
            if ((creep == null) != null)
            {
                goto Label_00A8;
            }
            if (num >= num2)
            {
                goto Label_00AB;
            }
        Label_00A8:
            creep = creep2;
        Label_00AB:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001D;
            }
            goto Label_00D2;
        }
        finally
        {
        Label_00BC:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00CA;
            }
        Label_00CA:
            disposable.Dispose();
        }
    Label_00D2:
        if ((creep != null) == null)
        {
            goto Label_0176;
        }
        transform2 = UnityEngine.Object.Instantiate(this.rayPrefab, new Vector3(&base.target.transform.position.x, &base.target.transform.position.y - 24f, -890f), base.transform.rotation) as Transform;
        transform2.GetComponent<TeslaRay>().Init(creep, this.jumpMax, this.jumpCurrent + 1, &this.jumpEnemies, base.stage);
        transform2.parent = base.transform.parent;
    Label_0176:
        return;
    }

    private unsafe bool OnDistance(Creep myEnemy)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = (&myEnemy.transform.position.x - &base.target.transform.position.x) + base.target.xAdjust;
        num3 = (&myEnemy.transform.position.y - &base.target.transform.position.y) + base.target.yAdjust;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) > ((float) this.jumpRange))
        {
            goto Label_0091;
        }
        return 1;
    Label_0091:
        return 0;
    }

    public override void Pause()
    {
        base.Pause();
        base.sprite.PauseAnim();
        return;
    }

    public void SetDamage(int min, int max)
    {
        base.minDamage = (float) min;
        base.maxDamage = (float) max;
        return;
    }

    private unsafe void Start()
    {
        Transform transform2;
        Transform transform1;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        base.sprite = base.GetComponent<PackedSprite>();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.durationTimeCounter = 0;
        base.durationTime = 14;
        base.anchorPoint = new Vector3(3f, 30f, 0f) + base.transform.position;
        base.originalPosition = base.transform.position;
        this.jumpRange = 150;
        base.Follow();
        base.Rotate();
        if ((base.target != null) == null)
        {
            goto Label_00AE;
        }
        if (base.target.IsDead() != null)
        {
            goto Label_00AE;
        }
        base.target.ShowTeslaHit();
    Label_00AE:
        if ((base.target != null) == null)
        {
            goto Label_013E;
        }
        if (&base.target.transform.position.x >= &this.towerPos.x)
        {
            goto Label_013E;
        }
        if (&base.target.transform.position.y >= &this.towerPos.y)
        {
            goto Label_013E;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(0f, 7f, 0f);
        goto Label_01EE;
    Label_013E:
        if ((base.target != null) == null)
        {
            goto Label_01EE;
        }
        if (&base.target.transform.position.x >= &this.towerPos.x)
        {
            goto Label_01EE;
        }
        if (&base.target.transform.position.y < &this.towerPos.y)
        {
            goto Label_01EE;
        }
        transform2 = base.transform;
        transform2.position += new Vector3(3f, 10f, 0f);
        base.anchorPoint += new Vector3(0f, 3f, 0f);
    Label_01EE:
        return;
    }

    public override void Unpause()
    {
        base.Unpause();
        base.sprite.UnpauseAnim();
        return;
    }
}

