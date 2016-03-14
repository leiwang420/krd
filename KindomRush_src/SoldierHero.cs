using System;
using System.Collections;
using UnityEngine;

public class SoldierHero : SoldierReinforcement
{
    protected float abilityModifierOne;
    protected float abilityModifierTwo;
    protected Vector2 adjustAbducted;
    protected int currentPathNode;
    protected bool isLevelUp;
    protected int level;
    protected int levelUpChargeTime;
    protected int levelUpChargeTimeCounter;
    protected int levelUpSoundShoot;
    protected ArrayList path;
    protected HeroPortrait portrait;
    public int rangeShootMaxDamage;
    public int rangeShootMinDamage;
    protected bool readyToMove;
    protected PackedSprite spriteAbducted;
    protected int xp;
    protected float xpMultiplier;

    public SoldierHero()
    {
        base..ctor();
        return;
    }

    public virtual unsafe bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        if (base.isRespawning == null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        vectorArray = base.stage.GetPath();
        num = 0;
        goto Label_00CE;
    Label_0020:
        num2 = 0;
        goto Label_00BD;
    Label_0027:
        if (base.stage.StageHasTunnels() == null)
        {
            goto Label_0044;
        }
        if (base.OnTunnel(num, num2) != null)
        {
            goto Label_00B9;
        }
    Label_0044:
        if (Mathf.Sqrt(Mathf.Pow(&(vectorArray[num][0][num2]).y - &newRallyPoint.y, 2f) + Mathf.Pow(&(vectorArray[num][0][num2]).x - &newRallyPoint.x, 2f)) >= 60f)
        {
            goto Label_00B9;
        }
        base.SetRangeCenterPosition(newRallyPoint);
        this.ChangeRallyPoint(newRallyPoint);
        base.gui.HideInfo(base.GetComponent<UnitClickable>());
        return 1;
    Label_00B9:
        num2 += 1;
    Label_00BD:
        if (num2 < ((int) vectorArray[num][0].Length))
        {
            goto Label_0027;
        }
        num += 1;
    Label_00CE:
        if (num < ((int) vectorArray.Length))
        {
            goto Label_0020;
        }
        return 0;
    }

    protected virtual void CustomInit()
    {
    }

    protected virtual unsafe bool DestinationReachOnPath(Vector2 destinationToReach)
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
        base.Eat();
        this.portrait.StartLoading();
        this.PlayAbducted();
        return;
    }

    protected bool EvalLevelUp()
    {
        if (this.levelUpChargeTimeCounter >= this.levelUpChargeTime)
        {
            goto Label_0037;
        }
        this.levelUpChargeTimeCounter += 1;
        if (this.levelUpChargeTimeCounter != this.levelUpSoundShoot)
        {
            goto Label_0035;
        }
        GameSoundManager.PlayHeroLevelUp();
    Label_0035:
        return 1;
    Label_0037:
        this.isLevelUp = 0;
        this.levelUpChargeTimeCounter = 0;
        return 0;
    }

    protected void GainXp(int gainedXp)
    {
        int num;
        if (base.isDead == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.xp += gainedXp;
        this.portrait.UpdateXpBar();
        if (this.level != 10)
        {
            goto Label_0033;
        }
        return;
    Label_0033:
        num = (int) GameSettings.GetHeroSetting("common_tables", "master_xp", this.level + 1);
        if (this.xp < num)
        {
            goto Label_00A7;
        }
        this.level += 1;
        this.LevelUpWithAnimation(1);
        this.portrait.UpdateLevel();
        if (this.level != 5)
        {
            goto Label_008E;
        }
        GameAchievements.LevelHeroMediumFunc();
        goto Label_00A0;
    Label_008E:
        if (this.level != 10)
        {
            goto Label_00A0;
        }
        GameAchievements.LevelHeroHardFunc();
    Label_00A0:
        this.GainXp(0);
    Label_00A7:
        return;
    }

    protected void GainXpByAbilityModifier(int ability, int abilityLevel)
    {
        if (ability != 1)
        {
            goto Label_0023;
        }
        this.GainXp(Mathf.RoundToInt(((float) (50 * abilityLevel)) * this.abilityModifierOne));
        goto Label_003A;
    Label_0023:
        this.GainXp(Mathf.RoundToInt(((float) (50 * abilityLevel)) * this.abilityModifierTwo));
    Label_003A:
        return;
    }

    public void GainXpByDamage(int damage)
    {
        if (damage != null)
        {
            goto Label_0007;
        }
        return;
    Label_0007:
        this.GainXp(Mathf.RoundToInt(((float) damage) * this.xpMultiplier));
        return;
    }

    protected void GainXpByNearByKill(int enemyHealth)
    {
    }

    public void GainXpByTargetKill(int enemyHealth)
    {
        int num;
        num = (enemyHealth * 20) / 100;
        if (num >= 1)
        {
            goto Label_0011;
        }
        num = 1;
    Label_0011:
        this.GainXp(num);
        return;
    }

    public int GetLevel()
    {
        return this.level;
    }

    protected unsafe void GetMyPath()
    {
        AStarNode node;
        AStarNode node2;
        Vector3 vector;
        Vector3 vector2;
        Vector2 vector3;
        Vector2 vector4;
        Vector2 vector5;
        Vector2 vector6;
        base.stage.PathFinder.Grid.GetNodeAtPosition(0, 0);
        node = null;
        node2 = null;
        node = base.stage.PathFinder.Grid.GetNodeAtPosition((((int) &base.transform.position.x) + 960) / 20, (540 - ((int) &base.transform.position.y)) / 20);
        node2 = base.stage.PathFinder.Grid.GetNodeAtPosition((((int) &this.rangePoint.x) + 960) / 20, (540 - ((int) &this.rangePoint.y)) / 20);
        if (node == null)
        {
            goto Label_00B8;
        }
        if (node2 != null)
        {
            goto Label_00B9;
        }
    Label_00B8:
        return;
    Label_00B9:
        base.stage.PathFinder.Grid.SetStartNodePosition((int) &node.Position.x, (int) &node.Position.y);
        base.stage.PathFinder.Grid.SetEndNodePosition((int) &node2.Position.x, (int) &node2.Position.y);
        if (base.stage.PathFinder.FindPath() == null)
        {
            goto Label_0191;
        }
        if (base.stage.PathFinder.GetPath().Count <= 2)
        {
            goto Label_01A3;
        }
        this.path.Clear();
        this.path.AddRange(base.stage.PathFinder.GetPath());
        this.currentPathNode = this.path.Count - 1;
        goto Label_01A3;
    Label_0191:
        this.path.Clear();
        this.currentPathNode = 0;
    Label_01A3:
        return;
    }

    public int GetXp()
    {
        return this.xp;
    }

    protected override void HitEnemy()
    {
        int num;
        if ((base.enemy == null) != null)
        {
            goto Label_0021;
        }
        if (base.enemy.IsActive() != null)
        {
            goto Label_002E;
        }
    Label_0021:
        base.UnBlock();
        this.SetGoToIdleStatus();
        return;
    Label_002E:
        if (base.enemy.DodgeAttack() != null)
        {
            goto Label_00C1;
        }
        num = this.GetDamage();
        this.GainXpByDamage(base.enemy.GetArmorDamage(1, num, 0));
        base.enemy.Damage(num, 1, 0, 0);
        if ((base.enemy != null) == null)
        {
            goto Label_00C1;
        }
        if (base.enemy.IsActive() != null)
        {
            goto Label_00C1;
        }
        if ((base.enemy != null) == null)
        {
            goto Label_00BB;
        }
        if (base.enemy.IsDead() == null)
        {
            goto Label_00BB;
        }
        this.GainXpByTargetKill(base.enemy.GetTotalLife());
    Label_00BB:
        base.UnBlock();
    Label_00C1:
        return;
    }

    public bool IsSelected()
    {
        if ((base.unitClickable != null) == null)
        {
            goto Label_001D;
        }
        return base.unitClickable.IsSelected();
    Label_001D:
        return 0;
    }

    protected virtual void LevelUpWithAnimation(bool playAnimation)
    {
        this.StopSpecial();
        base.sprite.PlayAnim("levelup");
        this.isLevelUp = 1;
        this.levelUpChargeTimeCounter = 0;
        return;
    }

    protected override unsafe bool OnRange(Creep myEnemy)
    {
        Vector3 vector;
        vector = myEnemy.transform.position + new Vector3(&myEnemy.anchorPoint.x, &myEnemy.anchorPoint.y, 0f);
        return IronUtils.ellipseContainPoint(vector, (float) base.rangeHeight, (float) base.rangeWidth, base.rangeCenterPosition);
    }

    protected unsafe void PlayAbducted()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_007A;
        }
        this.spriteAbducted.transform.position = new Vector3(&base.transform.position.x + &this.adjustAbducted.x, &base.transform.position.y + &this.adjustAbducted.y, -3f);
        goto Label_00D3;
    Label_007A:
        this.spriteAbducted.transform.position = new Vector3(&base.transform.position.x - &this.adjustAbducted.x, &base.transform.position.y + &this.adjustAbducted.y, -3f);
    Label_00D3:
        base.sprite.Hide(1);
        this.spriteAbducted.Hide(0);
        base.gameObject.layer = 2;
        return;
    }

    protected override void PlayAnimationDeath()
    {
        this.PlayDeathSound();
        base.PlayAnimationDeath();
        this.portrait.StartLoading();
        base.mainBar.gameObject.SetActive(0);
        return;
    }

    protected virtual void PlayAnimationRespawn()
    {
        base.sprite.PlayAnim("respawn");
        return;
    }

    protected virtual void PlayIntroTaunt()
    {
    }

    public bool ReadyToMove()
    {
        return this.readyToMove;
    }

    protected override bool ReadyToRespawn()
    {
        base.deadTimeCounter += 1;
        if (base.deadTimeCounter < base.deadTime)
        {
            goto Label_0097;
        }
        base.isDead = 0;
        base.doorQueed = 0;
        base.isRespawning = 1;
        base.overrideDodge = 1;
        base.collider.enabled = 1;
        base.sprite.Hide(0);
        this.spriteAbducted.Hide(1);
        this.PlayAnimationRespawn();
        base.lifes += 1;
        if ((this.portrait != null) == null)
        {
            goto Label_008F;
        }
        this.portrait.EndLoading();
    Label_008F:
        this.PlayIntroTaunt();
        return 1;
    Label_0097:
        if (base.deadTimeCounter != 60)
        {
            goto Label_00AA;
        }
        this.PlayAbducted();
    Label_00AA:
        this.portrait.UpdateLoading((float) base.deadTime, (float) base.deadTimeCounter);
        return 0;
    }

    public void RefreshPortrait()
    {
        this.portrait.Refresh();
        return;
    }

    protected override unsafe void Respawn()
    {
        base.isActive = 1;
        base.isDead = 0;
        base.isRespawning = 0;
        base.isWalking = 1;
        base.isCharging = 0;
        base.isBlocking = 0;
        base.isFighting = 0;
        base.isIdle = 0;
        base.canBeCourage = 0;
        if (base.lifes != 2)
        {
            goto Label_00A5;
        }
        base.transform.position = new Vector3(&this.rallyPoint.x, &this.rallyPoint.y + base.yAdjust, -3f);
        base.destinationPoint = new Vector2(&this.rallyPoint.x, &this.rallyPoint.y + base.yAdjust);
    Label_00A5:
        base.health = base.initHealth;
        base.deadTimeCounter = 0;
        base.respawnTimeCounter = 0;
        base.sprite.Hide(0);
        this.spriteAbducted.Hide(1);
        base.mainBar.gameObject.SetActive(1);
        base.gameObject.layer = 9;
        base.RecoverAnimationState();
        return;
    }

    protected override void RevertToStatic()
    {
        if (base.sprite.IsAnimating() == null)
        {
            goto Label_0030;
        }
        if ((base.sprite.GetCurAnim().name == "respawn") == null)
        {
            goto Label_0030;
        }
        return;
    Label_0030:
        base.sprite.RevertToStatic();
        return;
    }

    protected override bool RunSpecial()
    {
        if (this.isLevelUp == null)
        {
            goto Label_0014;
        }
        this.EvalLevelUp();
        return 1;
    Label_0014:
        return 0;
    }

    public void SelectPortrait()
    {
        this.portrait.GetComponent<PackedSprite>().PlayAnim("over");
        return;
    }

    public void SetPortrait(HeroPortrait p)
    {
        this.portrait = p;
        return;
    }

    protected void Start()
    {
        Transform transform;
        base.isLifeTimed = 0;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.path = new ArrayList();
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        transform = Resources.Load("Prefabs/Soldiers & units/HeroAbducted", typeof(Transform)) as Transform;
        transform = UnityEngine.Object.Instantiate(transform, Vector3.zero, Quaternion.identity) as Transform;
        this.spriteAbducted = transform.GetComponent<PackedSprite>();
        base.stage.AddSoldier(this);
        this.CustomInit();
        base.Invoke("TurnHeroSelectionOn", 0.5f);
        base.canBeSkeleteon = 0;
        return;
    }

    protected override void StopOnDead()
    {
        this.StopSpecial();
        return;
    }

    protected override void StopSpecial()
    {
        this.isLevelUp = 0;
        base.isCharging = 0;
        return;
    }

    protected override void ToSwamp()
    {
    }

    protected void TurnHeroSelectionOn()
    {
        this.readyToMove = 1;
        return;
    }

    protected override void UpdateLifeBar()
    {
        base.UpdateLifeBar();
        if ((this.portrait != null) == null)
        {
            goto Label_0022;
        }
        this.portrait.UpdateLifeBar();
    Label_0022:
        return;
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
        vector = ((AStarNode) this.path[this.currentPathNode - 1]).GetNodeRealPosition() + new Vector2(0f, base.yAdjust);
        if (this.DestinationReachOnPath(vector) == null)
        {
            goto Label_008A;
        }
        this.currentPathNode -= 1;
        if ((this.currentPathNode - 1) != null)
        {
            goto Label_008A;
        }
        this.path.Clear();
        this.currentPathNode = 0;
        return base.Walk();
    Label_008A:
        node = (AStarNode) this.path[this.currentPathNode - 1];
        vector2 = node.GetNodeRealPosition() + new Vector2(0f, base.yAdjust);
        num = Mathf.Atan2(&vector2.y - &base.transform.position.y, &vector2.x - &base.transform.position.x);
        if (&vector2.x >= &base.transform.position.x)
        {
            goto Label_0141;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0151;
    Label_0141:
        base.transform.localScale = Vector3.one;
    Label_0151:
        this.AddWalkParticle();
        base.transform.position = new Vector3(&base.transform.position.x + (Mathf.Cos(num) * base.speed), &base.transform.position.y + (Mathf.Sin(num) * base.speed), &base.transform.position.z);
        return 0;
    }
}

