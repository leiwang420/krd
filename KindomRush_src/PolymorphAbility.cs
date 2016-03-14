using System;
using UnityEngine;

public class PolymorphAbility : AbilityBase
{
    public Transform circleEffectPrefab;
    public Transform flyingSheepPrefab;
    public Transform rayPrefab;
    private bool ready;
    private float reloadTimer;
    public Transform sheepPrefab;
    private GameObject spawner;
    private Creep target;
    private float xDest;
    private float yDest;

    public PolymorphAbility()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    public bool CanFire()
    {
        return (((this.target != null) == null) ? 0 : this.ready);
    }

    public unsafe void Fire()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        transform = UnityEngine.Object.Instantiate(this.rayPrefab, new Vector3(&base.transform.position.x + 8f, &base.transform.position.y, -990f), base.transform.rotation) as Transform;
        transform.parent = base.transform;
        if (this.yDest <= &base.transform.position.y)
        {
            goto Label_00A6;
        }
        transform.position += new Vector3(6f, 40f, 0f);
        goto Label_00CB;
    Label_00A6:
        transform.position += new Vector3(-6f, 40f, 0f);
    Label_00CB:
        if ((this.target == null) == null)
        {
            goto Label_00E2;
        }
        this.LookForTarget();
    Label_00E2:
        ((BaseProjectile) transform.GetComponent("BaseProjectile")).SetTarget(this.target, this.xDest, this.yDest);
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
        if (base.level <= 0)
        {
            goto Label_0058;
        }
        if (this.ready != null)
        {
            goto Label_0058;
        }
        this.reloadTimer += Time.deltaTime;
        if (this.reloadTimer < base.reload)
        {
            goto Label_0058;
        }
        this.ready = 1;
        this.reloadTimer = 0f;
    Label_0058:
        return;
    }

    public bool IsReady()
    {
        return this.ready;
    }

    public override void LevelUp()
    {
        base.level += 1;
        base.reload -= 2f;
        return;
    }

    public unsafe void LookForTarget()
    {
        Creep creep;
        Vector3 vector;
        Vector3 vector2;
        if (base.level <= 0)
        {
            goto Label_00A1;
        }
        creep = base.tower.CheckRange((float) base.tower.range, base.transform.position);
        if ((creep != null) == null)
        {
            goto Label_00A1;
        }
        if (creep.IsActive() == null)
        {
            goto Label_00A1;
        }
        if (creep.IsDead() != null)
        {
            goto Label_00A1;
        }
        if (creep.IsPolymorphable() == null)
        {
            goto Label_00A1;
        }
        this.xDest = &creep.transform.position.x;
        this.yDest = &creep.transform.position.y;
        this.target = creep;
        base.tower.SetState(1);
    Label_00A1:
        return;
    }

    public void Reset()
    {
        this.target = null;
        this.ready = 0;
        return;
    }

    public unsafe void ShowEffect()
    {
        Transform transform;
        Vector3 vector;
        Vector3 vector2;
        transform = UnityEngine.Object.Instantiate(this.circleEffectPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 64f, -990f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        return;
    }

    public unsafe void SpawnSheep()
    {
        Transform transform;
        float num;
        Sheep sheep;
        if ((this.target != null) == null)
        {
            goto Label_0174;
        }
        if (this.target.IsActive() == null)
        {
            goto Label_0174;
        }
        num = &this.target.anchorPoint.y;
        if (this.target.isFlying == null)
        {
            goto Label_0086;
        }
        transform = UnityEngine.Object.Instantiate(this.flyingSheepPrefab, this.target.transform.position + new Vector3(0f, 15f, 0f), Quaternion.identity) as Transform;
        goto Label_00C1;
    Label_0086:
        transform = UnityEngine.Object.Instantiate(this.sheepPrefab, this.target.transform.position + new Vector3(0f, num, 0f), Quaternion.identity) as Transform;
    Label_00C1:
        sheep = transform.GetComponent<Sheep>();
        sheep.speed = this.target.GetOriginalSpeed() * 1.5f;
        sheep.SetPathIndexes(this.target.GetCurrentNodeIndex(), this.target.GetCurrentPath(), this.target.GetCurrentSubPath());
        sheep.life = this.target.life / 2;
        sheep.SetTotalLife(this.target.GetTotalLife() / 2);
        sheep.cost = this.target.cost;
        sheep.gold = this.target.gold;
        UnityEngine.Object.Destroy(this.target.gameObject);
        sheep.transform.parent = this.spawner.transform;
    Label_0174:
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner");
        base.tower = base.transform.GetComponent("SorcererTower") as SorcererTower;
        base.reload = 22f;
        return;
    }
}

