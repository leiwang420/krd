using System;
using System.Collections;
using UnityEngine;

public class SoldierElf : Soldier
{
    private int animationArrow;
    private int arrowChargeTime;
    private int arrowChargeTimeCounter;
    private int arrowMaxDamage;
    private int arrowMinDamage;
    private int arrowMinRange;
    public Transform arrowPrefab;
    private int arrowRangeHeight;
    private int arrowRangeWidth;
    private int arrowReloadTime;
    private int arrowReloadTimeCounter;
    private Creep arrowTarget;
    private Vector2 destinyPoint;
    private bool isArrowing;
    private int lifes;

    public SoldierElf()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.LoadNames();
        return;
    }

    private unsafe bool EvalArrow()
    {
        Vector2 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (this.isArrowing != null)
        {
            goto Label_012D;
        }
        if (this.arrowReloadTimeCounter >= this.arrowReloadTime)
        {
            goto Label_002C;
        }
        this.arrowReloadTimeCounter += 1;
        return 0;
    Label_002C:
        if (base.isIdle != null)
        {
            goto Label_0039;
        }
        return 0;
    Label_0039:
        if (this.FindArrowTarget() != null)
        {
            goto Label_0046;
        }
        return 0;
    Label_0046:
        if (&this.arrowTarget.transform.position.x < &base.transform.position.x)
        {
            goto Label_009A;
        }
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        goto Label_00B9;
    Label_009A:
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_00B9:
        this.destinyPoint = new Vector2(&this.arrowTarget.transform.position.x + this.arrowTarget.xAdjust, &this.arrowTarget.transform.position.y + this.arrowTarget.yAdjust);
        this.isArrowing = 1;
        this.arrowChargeTimeCounter = 0;
        base.sprite.PlayAnim("attackArrow");
        return 1;
    Label_012D:
        if (this.arrowChargeTimeCounter >= this.arrowChargeTime)
        {
            goto Label_019A;
        }
        this.arrowChargeTimeCounter += 1;
        if (this.arrowChargeTimeCounter != 7)
        {
            goto Label_0198;
        }
        vector = this.destinyPoint;
        if ((this.arrowTarget == null) != null)
        {
            goto Label_0180;
        }
        if (this.arrowTarget.IsActive() != null)
        {
            goto Label_0192;
        }
    Label_0180:
        if (this.FindArrowTarget() != null)
        {
            goto Label_0192;
        }
        vector = this.destinyPoint;
    Label_0192:
        this.FireArrow();
    Label_0198:
        return 1;
    Label_019A:
        this.isArrowing = 0;
        this.arrowReloadTimeCounter = 0;
        return 0;
    }

    private bool FindArrowTarget()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        this.arrowTarget = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0018:
        try
        {
            goto Label_0081;
        Label_001D:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0081;
            }
            if (this.MinDistance(creep) == null)
            {
                goto Label_0081;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) this.arrowRangeHeight, (float) this.arrowRangeWidth, base.transform.position) == null)
            {
                goto Label_0081;
            }
            this.arrowTarget = creep;
            goto Label_008C;
        Label_0081:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001D;
            }
        Label_008C:
            goto Label_00A3;
        }
        finally
        {
        Label_0091:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_009C;
            }
        Label_009C:
            disposable.Dispose();
        }
    Label_00A3:
        if ((this.arrowTarget != null) == null)
        {
            goto Label_00B6;
        }
        return 1;
    Label_00B6:
        return 0;
    }

    private unsafe void FireArrow()
    {
        Transform transform;
        Arrow arrow;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        transform = UnityEngine.Object.Instantiate(this.arrowPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 900f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        arrow = transform.GetComponent<Arrow>();
        arrow.SetT1(15f);
        arrow.SetTarget(this.arrowTarget, &this.destinyPoint.x, &this.destinyPoint.y);
        arrow.SetDamage(this.GetArrowDamage());
        arrow.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -900f);
        return;
    }

    private int GetArrowDamage()
    {
        int num;
        num = this.arrowMinDamage + Mathf.CeilToInt(UnityEngine.Random.Range(0f, 1f) * ((float) (this.arrowMaxDamage - this.arrowMinDamage)));
        return num;
    }

    protected override void LoadNames()
    {
        base.nameCandidates = new ArrayList();
        base.nameCandidates.Add("Elirond");
        base.nameCandidates.Add("Legalas");
        base.nameCandidates.Add("Elladon");
        base.nameCandidates.Add("Fingolin");
        base.nameCandidates.Add("Gil-alad");
        base.nameCandidates.Add("Finwer");
        base.nameCandidates.Add("Elwen");
        base.nameCandidates.Add("Silvius");
        base.nameCandidates.Add("Ellune");
        base.nameCandidates.Add("Illiban");
        return;
    }

    private unsafe bool MinDistance(Creep myEnemy)
    {
        float num;
        float num2;
        float num3;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        num2 = &myEnemy.transform.position.x - &base.transform.position.x;
        num3 = &myEnemy.transform.position.y - &base.transform.position.y;
        if (Mathf.Sqrt((num2 * num2) + (num3 * num3)) <= ((float) this.arrowMinRange))
        {
            goto Label_006F;
        }
        return 1;
    Label_006F:
        return 0;
    }

    protected override void OnEnemyDamaged(int damage)
    {
        GameAchievements.StillCountsAsOneFunc(damage);
        return;
    }

    protected override bool ReadyToRespawn()
    {
        base.deadTimeCounter += 1;
        if (base.deadTimeCounter < base.deadTime)
        {
            goto Label_0060;
        }
        if (this.lifes != 1)
        {
            goto Label_0049;
        }
        ((ElfTower) base.tower).RemoveElf(this);
        UnityEngine.Object.Destroy(base.gameObject);
        return 0;
    Label_0049:
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        return 1;
    Label_0060:
        return 0;
    }

    protected override bool RunSpecial()
    {
        if (base.isActive != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.EvalArrow() == null)
        {
            goto Label_001A;
        }
        return 1;
    Label_001A:
        return 0;
    }

    private unsafe void Start()
    {
        int num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.sprite = base.GetComponent<PackedSprite>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.health = base.initHealth = 100;
        base.regenerateHealth = 20;
        base.regenerateTime = 15;
        this.lifes = 1;
        base.rangeWidth = 210;
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        this.isArrowing = 0;
        this.arrowReloadTime = 30;
        this.arrowRangeWidth = 0x242;
        this.arrowRangeHeight = Mathf.RoundToInt(((float) this.arrowRangeWidth) * 0.7f);
        this.arrowMinRange = 70;
        this.arrowMinDamage = 0x19;
        this.arrowMaxDamage = 50;
        this.arrowChargeTime = 15;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        this.LoadNames();
        base.SetRandomName();
        return;
    }

    protected override void StopSpecial()
    {
        if (this.isArrowing == null)
        {
            goto Label_0012;
        }
        this.isArrowing = 0;
    Label_0012:
        return;
    }
}

