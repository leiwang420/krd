using System;
using System.Collections;
using UnityEngine;

public class SoldierWildCat : SoldierReinforcement
{
    private int currentPathNode;
    private SoldierHeroArcher hero;
    private int level;
    private ArrayList path;

    public SoldierWildCat()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.path = new ArrayList();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.unitClickable = base.GetComponent<UnitClickable>();
        return;
    }

    public bool ChangeRallyPointHero(Vector2 newRallyPoint, ArrayList myPath)
    {
        if (base.isDead != null)
        {
            goto Label_0045;
        }
        if (base.isRespawning != null)
        {
            goto Label_0045;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0024;
        }
        return 0;
    Label_0024:
        base.rangePoint = newRallyPoint;
        this.path = myPath;
        this.currentPathNode = this.path.Count - 1;
    Label_0045:
        return 1;
    }

    protected unsafe bool DestinationReachOnPath(Vector2 destinationToReach)
    {
        Vector3 vector;
        Vector3 vector2;
        if (Mathf.Sqrt(Mathf.Pow(&destinationToReach.y - &base.transform.position.y, 2f) + Mathf.Pow(&destinationToReach.x - &base.transform.position.x, 2f)) > base.speed)
        {
            goto Label_005D;
        }
        return 1;
    Label_005D:
        return 0;
    }

    public override void Eat()
    {
        this.hero.WildCatIsDead();
        base.Eat();
        return;
    }

    protected override void Fight()
    {
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter >= base.attackChargeTime)
        {
            goto Label_003C;
        }
        if (base.attackChargeTimeCounter != base.attackChargeDamageTime)
        {
            goto Label_003B;
        }
        GameSoundManager.PlayHeroArcherWildCatHit();
        this.HitEnemy();
    Label_003B:
        return;
    Label_003C:
        base.attackChargeTimeCounter = 0;
        base.isCharging = 0;
        return;
    }

    public void InitWithPosition(Vector2 pos, Vector2 pRallyPoint, int pNameMax, bool pRespawnOnInit, Vector2 myRangePoint, int myLevel, SoldierHeroArcher myHero)
    {
        base.InitWithPosition(pos, pRallyPoint, pNameMax, pRespawnOnInit, myRangePoint);
        base.isLifeTimed = 0;
        base.attackChargeTime = 0x10;
        base.attackChargeDamageTime = 9;
        this.hero = myHero;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_archer", "callOfWildRangeRally", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_archer", "callOfWildRegen", 1);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildRegenReload", 1)) * 30;
        base.armor = (int) GameSettings.GetHeroSetting("hero_archer", "callOfWildArmor", 1);
        base.deadTime = 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildReload", 1)) * 30) - base.attackChargeTime;
        this.LevelUp(myLevel);
        base.respawnTime = 20;
        base.speed = 4.2f;
        base.lifes = 1;
        base.xAdjust = 7f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        base.canBeCourage = 0;
        base.sprite.PlayAnim("respawn");
        return;
    }

    public void LevelUp(int myLevel)
    {
        int num;
        this.level = myLevel;
        base.health = base.initHealth = ((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildHealth", 1)) + (((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildHealthIncrement", 1)) * this.level);
        base.minDamage = ((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildDamageIncrement", 1)) * this.level);
        base.maxDamage = ((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_archer", "callOfWildDamageIncrement", 1)) * this.level);
        this.UpdateLifeBar();
        return;
    }

    protected override void PlayAnimationDeath()
    {
        base.sprite.PlayAnim("death");
        this.hero.WildCatIsDead();
        return;
    }

    private void Start()
    {
    }

    protected override void StopSpecial()
    {
        base.isCharging = 0;
        return;
    }

    protected override void ToSwamp()
    {
    }

    protected override unsafe bool Walk()
    {
        Vector2 vector;
        AStarNode node;
        Vector2 vector2;
        float num;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if (this.path.Count != null)
        {
            goto Label_0017;
        }
        return base.Walk();
    Label_0017:
        vector = ((AStarNode) this.path[this.currentPathNode - 1]).GetNodeRealPosition();
        if (this.DestinationReachOnPath(vector) == null)
        {
            goto Label_0075;
        }
        this.currentPathNode -= 1;
        if ((this.currentPathNode - 1) != null)
        {
            goto Label_0075;
        }
        this.path.Clear();
        this.currentPathNode = 0;
        return base.Walk();
    Label_0075:
        node = (AStarNode) this.path[this.currentPathNode - 1];
        vector2 = node.GetNodeRealPosition();
        num = Mathf.Atan2(&vector2.y - &base.transform.position.y, &vector2.x - &base.transform.position.x);
        if (&vector2.x >= &base.transform.position.x)
        {
            goto Label_0117;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0127;
    Label_0117:
        base.transform.localScale = Vector3.one;
    Label_0127:
        this.AddWalkParticle();
        base.transform.position = new Vector3(&base.transform.position.x + (Mathf.Cos(num) * base.speed), &base.transform.position.y + (Mathf.Sin(num) * base.speed), &base.transform.position.z);
        return 0;
    }
}

