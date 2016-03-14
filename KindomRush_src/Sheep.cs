using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Sheep : Creep
{
    private int clickCounter;
    private int clicks;
    private bool exploded;

    public Sheep()
    {
        base..ctor();
        return;
    }

    public override void Damage(int dmg, Constants.damageType damageType, int ignoreArmor = 0, bool shieldOn = false)
    {
        if (damageType == null)
        {
            goto Label_0021;
        }
        base.life -= this.GetArmorDamage(damageType, dmg, ignoreArmor);
        goto Label_002F;
    Label_0021:
        base.life -= dmg;
    Label_002F:
        if (base.life >= 0)
        {
            goto Label_0048;
        }
        base.life = 0;
        this.Die();
    Label_0048:
        return;
    }

    protected override void Die()
    {
        if (base.isDead != null)
        {
            goto Label_0076;
        }
        base.isDead = 1;
        base.active = 0;
        base.stage.AddGold(base.gold);
        base.gui.HideInfo(base.clickable);
        base.clickable.UnSelect();
        if (base.desintegrate != null)
        {
            goto Label_006B;
        }
        base.creepSprite.PlayAnim("gibs");
        GameSoundManager.PlayDeathExplosion();
        goto Label_0071;
    Label_006B:
        base.SpawnDesintegrate();
    Label_0071:
        goto Label_009E;
    Label_0076:
        if (this.exploded == null)
        {
            goto Label_0082;
        }
        return;
    Label_0082:
        this.exploded = 1;
        base.creepSprite.PlayAnim("gibs");
        GameSoundManager.PlayDeathExplosion();
    Label_009E:
        return;
    }

    private unsafe void FixedUpdate()
    {
        Vector3 vector;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.UpdateLifeBar();
        if (base.life > 0)
        {
            goto Label_0025;
        }
        this.Die();
        return;
    Label_0025:
        if (base.EvalFreeze() == null)
        {
            goto Label_0031;
        }
        return;
    Label_0031:
        if (base.EvalThorns() == null)
        {
            goto Label_003D;
        }
        return;
    Label_003D:
        if (base.teleporting != null)
        {
            goto Label_0059;
        }
        if (base.isDead != null)
        {
            goto Label_0059;
        }
        base.Move();
    Label_0059:
        if (&base.transform.localScale.x >= 0f)
        {
            goto Label_009A;
        }
        base.mainBar.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_00B9;
    Label_009A:
        base.mainBar.localScale = new Vector3(1f, 1f, 1f);
    Label_00B9:
        return;
    }

    private void OnMouseDown()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.clickCounter += 1;
        if (this.clickCounter != this.clicks)
        {
            goto Label_004E;
        }
        base.isDead = 1;
        base.active = 0;
        base.creepSprite.PlayAnim("gibs");
        GameSoundManager.PlayDeathExplosion();
    Label_004E:
        return;
    }

    public unsafe void SetPathIndexes(int current, int pathInd, int subPath)
    {
        Vector2 vector;
        base.currentNode = current;
        base.pathIndex = pathInd;
        base.subpathIndex = subPath;
        base.path = GameObject.Find("Stage").GetComponent<StageBase>().GetPath();
        vector = *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode]));
        if (base.isFlying == null)
        {
            goto Label_008D;
        }
        base.transform.position = new Vector3(&vector.x, &vector.y + 30f, -1f);
        goto Label_00B6;
    Label_008D:
        base.transform.position = new Vector3(&vector.x, &vector.y + 12f, -1f);
    Label_00B6:
        return;
    }

    public void SetTotalLife(int t)
    {
        base.totalLife = t;
        return;
    }

    private unsafe void Start()
    {
        string str;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.creepSprite = base.transform.GetComponent("PackedSprite") as PackedSprite;
        base.popHeadshotPrefab = Resources.Load("Prefabs/Particles & fx/PopHeadshot", typeof(Transform)) as Transform;
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.clickable = base.GetComponent<UnitClickable>();
        base.creepSprite.PlayAnim("walk");
        base.facing = 3;
        base.isStopped = 0;
        base.totalLife = base.life;
        base.gibs = 0;
        base.desintegrate = 0;
        base.active = 1;
        base.totalArmor = base.armor;
        base.totalMagicArmor = base.magicArmor;
        base.originalSpeed = base.speed;
        base.thornSpecial = 0;
        base.thornCount = 0;
        base.thornMaxTimes = 3;
        base.thornDamageTimeCounter = 0f;
        base.thornDamageTime = 1f;
        base.thornDurationCounter = 0f;
        base.thornDamage = 0;
        base.teleportCount = 0;
        base.teleportMaxTimes = 3;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x + ((float) base.xLifebarOffset), &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        base.facing = -1;
        this.CheckFacing();
        GameAchievements.PolymorphEnemy();
        this.clicks = 8;
        base.iceBlock = null;
        str = string.Empty;
        if (base.isFlying == null)
        {
            goto Label_01D5;
        }
        str = "Prefabs/CreepIceBlockFlying";
        goto Label_01DB;
    Label_01D5:
        str = "Prefabs/CreepIceBlock";
    Label_01DB:
        base.iceBlockPrefab = Resources.Load(str, typeof(Transform)) as Transform;
        return;
    }
}

