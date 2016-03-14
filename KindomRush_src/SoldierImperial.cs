using System;
using System.Collections;
using UnityEngine;

public class SoldierImperial : SoldierReinforcement
{
    private bool dying;

    public SoldierImperial()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.LoadNames();
        return;
    }

    protected override void ChargeAttack()
    {
        if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
        {
            goto Label_002E;
        }
        base.sprite.PlayAnim("attack");
        goto Label_003E;
    Label_002E:
        base.sprite.PlayAnim("attack2");
    Label_003E:
        base.isCharging = 1;
        return;
    }

    public override bool IsTowerSelected()
    {
        return 0;
    }

    private void KillMe()
    {
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    protected override void LoadNames()
    {
        base.nameCandidates = new ArrayList();
        base.nameCandidates.Add("Sir Cooney");
        base.nameCandidates.Add("Sir Betz");
        base.nameCandidates.Add("Sir Royster");
        base.nameCandidates.Add("Sir Roland");
        base.nameCandidates.Add("Sir Nicholas");
        base.nameCandidates.Add("Sir Litto");
        base.nameCandidates.Add("Sir Wallace");
        base.nameCandidates.Add("Sir Vincent");
        base.nameCandidates.Add("Sir Dante");
        base.nameCandidates.Add("Sir Julian");
        base.nameCandidates.Add("Sir Caspian");
        base.nameCandidates.Add("Sir Gaw Ain");
        base.nameCandidates.Add("Sir Alvus");
        base.nameCandidates.Add("Sir Olivier");
        base.nameCandidates.Add("Sir Sande");
        base.nameCandidates.Add("Sir Ulric");
        base.nameCandidates.Add("Sir Magnus");
        base.nameCandidates.Add("Sir Gabini");
        base.nameCandidates.Add("Sir Crisden");
        base.nameCandidates.Add("Sir Guybrush");
        base.nameCandidates.Add("Sir Wiggins");
        base.nameCandidates.Add("Sir Wynants");
        base.nameCandidates.Add("Sir Cavendish");
        base.nameCandidates.Add("Sir LeMond");
        base.nameCandidates.Add("Sir Fignon");
        base.nameCandidates.Add("Sir Ashton");
        base.nameCandidates.Add("Sir Spencer");
        return;
    }

    protected override bool ReadyToRespawn()
    {
        base.deadTimeCounter += 1;
        if (base.deadTimeCounter < base.deadTime)
        {
            goto Label_0080;
        }
        if (base.lifes == 1)
        {
            goto Label_005B;
        }
        base.stage.RemoveSoldier(this);
        if (this.dying != null)
        {
            goto Label_0059;
        }
        this.dying = 1;
        base.Invoke("KillMe", 2f);
    Label_0059:
        return 0;
    Label_005B:
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        base.lifes += 1;
        return 1;
    Label_0080:
        return 0;
    }

    private unsafe void Start()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.stage.AddSoldier(this);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.initHealth = 250;
        base.health = base.initHealth;
        base.armor = 40;
        base.regenerateHealth = 0x19;
        base.regenerateTime = 30;
        base.respawnTime = 60;
        base.rallyPoint = new Vector2(&base.transform.position.x, &base.transform.position.y);
        base.rangeWidth = 170;
        base.rangeHeight = Mathf.CeilToInt(((float) base.rangeWidth) * 0.7f);
        this.LoadNames();
        base.SetRandomName();
        return;
    }
}

