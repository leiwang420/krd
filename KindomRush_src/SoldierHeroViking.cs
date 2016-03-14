using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class SoldierHeroViking : SoldierHero
{
    private int bearAttackChargeTime;
    private int bearAttackChargeTimeCounter;
    private int bearDurationTime;
    private int bearDurationTimeCounter;
    private int bearLevel;
    private int bearMaxDamage;
    private int bearMinDamage;
    private int bearMinHealthActivate;
    private int bearRegenerateLife;
    private int bearRegenerateTime;
    private int bearRegenerateTimeCounter;
    private int bearReloadTime;
    private int bearReloadTimeCounter;
    private int callAncestorsChargeTime;
    private int callAncestorsChargeTimeCounter;
    private int callAncestorsLevel;
    private int callAncestorsMax;
    private int callAncestorsReloadTime;
    private int callAncestorsReloadTimeCounter;
    private bool isBear;
    private bool isCallingAncestors;
    private bool isGoingBear;
    private bool isGoingViking;
    private bool isPrimaryAttack;
    private int referenceNode;
    private int referencePath;
    public Transform vikingAncestorPrefab;
    public Transform vikingDecalPrefab;

    public SoldierHeroViking()
    {
        base..ctor();
        return;
    }

    protected override void AfterDamage()
    {
        base.AfterDamage();
        if (((base.health * 100) / base.initHealth) >= this.bearMinHealthActivate)
        {
            goto Label_0028;
        }
        this.EvalBear();
    Label_0028:
        return;
    }

    protected void AnimationDelegate(SpriteBase sprt)
    {
        if (this.isGoingBear == null)
        {
            goto Label_0016;
        }
        this.GoingBearEnd();
        goto Label_0078;
    Label_0016:
        if (this.isGoingViking == null)
        {
            goto Label_0032;
        }
        this.GoingVikingEnd();
        base.RecoverAnimationState();
        goto Label_0078;
    Label_0032:
        if (this.isBear == null)
        {
            goto Label_0078;
        }
        if (base.isWalking != null)
        {
            goto Label_0078;
        }
        if (base.sprite.GetCurAnim() == null)
        {
            goto Label_0078;
        }
        if (base.sprite.IsAnimating() != null)
        {
            goto Label_0078;
        }
        base.sprite.PlayAnim("bearIdle");
    Label_0078:
        return;
    }

    protected bool CanAncestors()
    {
        return 1;
    }

    public override bool ChangeRallyPointHero(Vector2 newRallyPoint)
    {
        if (this.isGoingBear != null)
        {
            goto Label_0016;
        }
        if (this.isGoingViking == null)
        {
            goto Label_0018;
        }
    Label_0016:
        return 1;
    Label_0018:
        if (base.isDead != null)
        {
            goto Label_0073;
        }
        if (base.ChangeRallyPointHero(newRallyPoint) != null)
        {
            goto Label_0031;
        }
        return 0;
    Label_0031:
        base.rangePoint = newRallyPoint + new Vector2(0f, base.yAdjust);
        this.FindReferenceNode();
        base.GetMyPath();
        if (this.isBear != null)
        {
            goto Label_006E;
        }
        GameSoundManager.PlayHeroVikingTaunt();
        goto Label_0073;
    Label_006E:
        GameSoundManager.PlayHeroVikingBearTransform();
    Label_0073:
        return 1;
    }

    protected override void CustomInit()
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, base.yAdjust, 0f);
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.attackChargeTime = 0x26;
        base.attackChargeDamageTime = 0x11;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_viking", "range", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_viking", "regenReload", 1)) * 30;
        base.deadTime = ((int) GameSettings.GetHeroSetting("hero_viking", "respawn", 1)) * 30;
        base.attackReloadTime = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_viking", "reload", 1) * 30f) - base.attackChargeTime;
        base.abilityModifierOne = GameSettings.GetHeroSetting("hero_viking", "ancestorsModifier", 1);
        base.abilityModifierTwo = GameSettings.GetHeroSetting("hero_viking", "bearModifier", 1);
        base.xpMultiplier = GameSettings.GetHeroSetting("hero_viking", "xpMultiplier", 1);
        base.adjustAbducted = new Vector2(0f, 32f);
        base.levelUpChargeTime = 0x17;
        base.respawnTime = 0x13;
        base.levelUpSoundShoot = 5;
        this.bearAttackChargeTime = 60;
        this.bearRegenerateTime = ((int) GameSettings.GetHeroSetting("hero_viking", "bearRegenerateTime", 1)) * 30;
        this.bearRegenerateTimeCounter = 0;
        this.bearRegenerateLife = (int) GameSettings.GetHeroSetting("hero_viking", "bearRegenerateLife", 1);
        base.level = 1;
        this.LevelUpWithAnimation(0);
        base.speed = 3.5f;
        base.lifes = 1;
        base.idleTime = 30;
        this.callAncestorsReloadTimeCounter = 0;
        this.callAncestorsChargeTimeCounter = 0;
        this.bearReloadTimeCounter = 0;
        this.bearDurationTimeCounter = 0;
        this.bearAttackChargeTimeCounter = 0;
        base.isActive = 0;
        base.isDead = 1;
        base.deadTimeCounter = base.deadTime - 1;
        this.FindReferenceNode();
        base.sprite.SetAnimCompleteDelegate(new SpriteBase.AnimCompleteDelegate(this.AnimationDelegate));
        return;
    }

    protected unsafe void DoAncestors()
    {
        Vector2 vector;
        int num;
        Transform transform;
        SoldierHeroVikingAncestor ancestor;
        vector = this.GetAncestorsPosition(0);
        num = 0;
        goto Label_007C;
    Label_000F:
        transform = UnityEngine.Object.Instantiate(this.vikingAncestorPrefab, new Vector3(&vector.x, &vector.y, -1f), Quaternion.identity) as Transform;
        ancestor = transform.GetComponent<SoldierHeroVikingAncestor>();
        ancestor.Init(this.callAncestorsLevel, vector);
        base.stage.AddReinforce(ancestor.transform);
        base.stage.AddSoldier(ancestor);
        vector = this.GetAncestorsPosition(num + 1);
        num += 1;
    Label_007C:
        if (num < this.callAncestorsMax)
        {
            goto Label_000F;
        }
        return;
    }

    protected bool EvalAncestors()
    {
        if (this.isBear == null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.isCallingAncestors != null)
        {
            goto Label_0073;
        }
        if (base.isWalking == null)
        {
            goto Label_0025;
        }
        return 0;
    Label_0025:
        if (this.callAncestorsReloadTimeCounter >= this.callAncestorsReloadTime)
        {
            goto Label_0038;
        }
        return 0;
    Label_0038:
        base.isCharging = 0;
        this.isCallingAncestors = 1;
        this.callAncestorsReloadTimeCounter = 0;
        this.callAncestorsChargeTimeCounter = 0;
        base.sprite.PlayAnim("horn");
        base.GainXpByAbilityModifier(1, this.callAncestorsLevel);
        return 1;
    Label_0073:
        if (this.callAncestorsChargeTimeCounter >= this.callAncestorsChargeTime)
        {
            goto Label_00B8;
        }
        this.callAncestorsChargeTimeCounter += 1;
        if (this.callAncestorsChargeTimeCounter != 5)
        {
            goto Label_00A3;
        }
        GameSoundManager.PlayHeroVikingCall();
    Label_00A3:
        if (this.callAncestorsChargeTimeCounter != 15)
        {
            goto Label_00B6;
        }
        this.DoAncestors();
    Label_00B6:
        return 1;
    Label_00B8:
        this.isCallingAncestors = 0;
        this.callAncestorsReloadTimeCounter = 0;
        base.RecoverAnimationState();
        return 0;
    }

    protected bool EvalBear()
    {
        if (this.bearLevel == null)
        {
            goto Label_0016;
        }
        if (this.isCallingAncestors == null)
        {
            goto Label_0018;
        }
    Label_0016:
        return 0;
    Label_0018:
        if (this.isBear != null)
        {
            goto Label_008A;
        }
        if (base.isWalking == null)
        {
            goto Label_0030;
        }
        return 0;
    Label_0030:
        if (this.bearReloadTimeCounter >= this.bearReloadTime)
        {
            goto Label_0043;
        }
        return 0;
    Label_0043:
        base.isCharging = 0;
        this.isGoingBear = 1;
        this.isBear = 1;
        this.bearReloadTimeCounter = 0;
        this.bearDurationTimeCounter = 0;
        base.sprite.PlayAnim("toBear");
        base.GainXpByAbilityModifier(2, this.bearLevel);
        GameSoundManager.PlayHeroVikingBearTransform();
        return 1;
    Label_008A:
        if (this.isGoingViking != null)
        {
            goto Label_00A0;
        }
        if (this.isGoingBear == null)
        {
            goto Label_00A2;
        }
    Label_00A0:
        return 1;
    Label_00A2:
        if (this.bearDurationTimeCounter >= this.bearDurationTime)
        {
            goto Label_00C3;
        }
        this.bearDurationTimeCounter += 1;
        return 0;
    Label_00C3:
        if (base.isWalking == null)
        {
            goto Label_00D0;
        }
        return 0;
    Label_00D0:
        this.isGoingViking = 1;
        base.sprite.PlayAnim("toViking");
        return 1;
    }

    protected void EvalRegenerate()
    {
        if (this.isBear == null)
        {
            goto Label_009A;
        }
        if (this.isGoingBear != null)
        {
            goto Label_009A;
        }
        if (this.isGoingViking != null)
        {
            goto Label_009A;
        }
        if (base.regenerateTimeCounter >= base.regenerateTime)
        {
            goto Label_0041;
        }
        base.regenerateTimeCounter += 1;
        return;
    Label_0041:
        if (base.health >= base.initHealth)
        {
            goto Label_0093;
        }
        base.health += this.bearRegenerateLife;
        GameAchievements.AddRegeneration(this.bearRegenerateLife);
        if (base.health <= base.initHealth)
        {
            goto Label_008D;
        }
        base.health = base.initHealth;
    Label_008D:
        this.UpdateLifeBar();
    Label_0093:
        base.regenerateTimeCounter = 0;
    Label_009A:
        return;
    }

    protected override unsafe void Fight()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        if (this.isBear != null)
        {
            goto Label_0211;
        }
        base.attackChargeTimeCounter += 1;
        if (base.attackChargeTimeCounter >= base.attackChargeTime)
        {
            goto Label_0203;
        }
        if (base.attackChargeTimeCounter != base.attackChargeDamageTime)
        {
            goto Label_0046;
        }
        GameSoundManager.PlayHeroVikingAttackHit();
        this.HitEnemy();
    Label_0046:
        if (this.isPrimaryAttack != null)
        {
            goto Label_0121;
        }
        if (base.attackChargeTimeCounter != base.attackChargeDamageTime)
        {
            goto Label_0121;
        }
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_00D2;
        }
        UnityEngine.Object.Instantiate(this.vikingDecalPrefab, new Vector3(&base.transform.position.x + 35f, &base.transform.position.y - base.yAdjust, -1f), Quaternion.identity);
        goto Label_0121;
    Label_00D2:
        UnityEngine.Object.Instantiate(this.vikingDecalPrefab, new Vector3(&base.transform.position.x - 35f, &base.transform.position.y - base.yAdjust, -1f), Quaternion.identity);
    Label_0121:
        if (this.isPrimaryAttack == null)
        {
            goto Label_0202;
        }
        if (base.attackChargeTimeCounter != (base.attackChargeDamageTime - 2))
        {
            goto Label_0202;
        }
        if (&base.transform.localScale.x != -1f)
        {
            goto Label_01B2;
        }
        UnityEngine.Object.Instantiate(this.vikingDecalPrefab, new Vector3(&base.transform.position.x - 68f, &base.transform.position.y - base.yAdjust, -1f), Quaternion.identity);
        goto Label_0202;
    Label_01B2:
        UnityEngine.Object.Instantiate(this.vikingDecalPrefab, new Vector3(&base.transform.position.x + 68f, &base.transform.position.y - base.yAdjust, -1f), Quaternion.identity);
    Label_0202:
        return;
    Label_0203:
        base.attackChargeTimeCounter = 0;
        base.isCharging = 0;
    Label_0211:
        this.bearAttackChargeTimeCounter += 1;
        if (this.bearAttackChargeTimeCounter >= this.bearAttackChargeTime)
        {
            goto Label_0263;
        }
        if (this.bearAttackChargeTimeCounter == 0x19)
        {
            goto Label_0257;
        }
        if (this.bearAttackChargeTimeCounter == 0x23)
        {
            goto Label_0257;
        }
        if (this.bearAttackChargeTimeCounter != 0x2d)
        {
            goto Label_0262;
        }
    Label_0257:
        GameSoundManager.PlayHeroVikingAttackHit();
        this.HitEnemy();
    Label_0262:
        return;
    Label_0263:
        this.bearAttackChargeTimeCounter = 0;
        base.isCharging = 0;
        return;
    }

    protected unsafe void FindReferenceNode()
    {
        float num;
        float num2;
        Vector2[][][] vectorArray;
        int num3;
        int num4;
        num = 0f;
        num2 = 0f;
        vectorArray = base.stage.GetPath();
        num3 = 0;
        goto Label_00E0;
    Label_001F:
        num4 = 0;
        goto Label_00CE;
    Label_0027:
        if (base.stage.StageHasTunnels() == null)
        {
            goto Label_0045;
        }
        if (base.OnTunnel(num3, num4) != null)
        {
            goto Label_00C8;
        }
    Label_0045:
        num2 = Mathf.Sqrt(Mathf.Pow(&(vectorArray[num3][0][num4]).y - &this.rangeCenterPosition.y, 2f) + Mathf.Pow(&(vectorArray[num3][0][num4]).x - &this.rangeCenterPosition.x, 2f));
        if (num2 >= 61f)
        {
            goto Label_00C8;
        }
        if (num == 0f)
        {
            goto Label_00B7;
        }
        if (num <= num2)
        {
            goto Label_00C8;
        }
    Label_00B7:
        this.referencePath = num3;
        this.referenceNode = num4;
        num = num2;
    Label_00C8:
        num4 += 1;
    Label_00CE:
        if (num4 < ((int) vectorArray[num3][0].Length))
        {
            goto Label_0027;
        }
        num3 += 1;
    Label_00E0:
        if (num3 < ((int) vectorArray.Length))
        {
            goto Label_001F;
        }
        return;
    }

    protected unsafe Vector2 GetAncestorsPosition(int i)
    {
        int num;
        int num2;
        Vector2[][][] vectorArray;
        if (i <= 2)
        {
            goto Label_000A;
        }
        i = 0;
    Label_000A:
        num = UnityEngine.Random.Range(4, 8) * ((UnityEngine.Random.Range(0f, 1f) >= 0.5f) ? -1 : 1);
        num2 = this.referenceNode;
        vectorArray = base.stage.GetPath();
        if ((num2 + num) >= 0)
        {
            goto Label_0063;
        }
        if ((num2 + num) >= ((int) vectorArray[this.referencePath][i].Length))
        {
            goto Label_0067;
        }
    Label_0063:
        num2 += num;
    Label_0067:
        return *(&(vectorArray[this.referencePath][i][num2]));
    }

    protected override int GetDamage()
    {
        if (this.isBear != null)
        {
            goto Label_001F;
        }
        return UnityEngine.Random.Range(base.minDamage, base.maxDamage + 1);
    Label_001F:
        return UnityEngine.Random.Range(this.bearMinDamage, this.bearMaxDamage + 1);
    }

    protected void GoingBearEnd()
    {
        Transform transform1;
        this.isGoingBear = 0;
        base.attackReloadTime = 90 - this.bearAttackChargeTime;
        base.attackReloadTimeCounter = base.attackReloadTime - 1;
        transform1 = base.lifeBar.transform.parent;
        transform1.position += new Vector3(5f, 2f, 0f);
        return;
    }

    protected void GoingVikingEnd()
    {
        this.isGoingViking = 0;
        this.isBear = 0;
        this.bearReloadTimeCounter = 0;
        base.attackReloadTime = Mathf.RoundToInt(GameSettings.GetHeroSetting("hero_viking", "reload", 1) * 30f) - base.attackChargeTime;
        base.lifeBar.transform.parent.localPosition = new Vector3(0f, (float) base.yLifebarOffset, 0f);
        return;
    }

    protected override void LevelUpWithAnimation(bool playAnimation)
    {
        int num;
        if (playAnimation == null)
        {
            goto Label_0018;
        }
        if (this.isBear != null)
        {
            goto Label_0018;
        }
        base.LevelUpWithAnimation(playAnimation);
    Label_0018:
        base.health = base.initHealth = (int) GameSettings.GetHeroSetting("hero_viking", "health", base.level);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_viking", "regen", base.level);
        base.armor = (int) GameSettings.GetHeroSetting("hero_viking", "armor", base.level);
        base.minDamage = (int) GameSettings.GetHeroSetting("hero_viking", "minDamage", base.level);
        base.maxDamage = (int) GameSettings.GetHeroSetting("hero_viking", "maxDamage", base.level);
        this.UpdateLifeBar();
        this.UpgradeBear();
        this.UpgradeAncestors();
        return;
    }

    protected override void PlayAnimationAttack()
    {
        if (this.isBear == null)
        {
            goto Label_0021;
        }
        base.sprite.PlayAnim("bearAttack");
        GameSoundManager.PlayHeroVikingBearAttackStart();
        return;
    Label_0021:
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0056;
        }
        this.isPrimaryAttack = 1;
        base.sprite.PlayAnim("attack");
        goto Label_006D;
    Label_0056:
        this.isPrimaryAttack = 0;
        base.sprite.PlayAnim("attack2");
    Label_006D:
        return;
    }

    protected override void PlayAnimationWalk()
    {
        if (this.isBear == null)
        {
            goto Label_0020;
        }
        base.sprite.PlayAnim("bearWalk");
        goto Label_0030;
    Label_0020:
        base.sprite.PlayAnim("walk");
    Label_0030:
        return;
    }

    protected override void PlayDeathSound()
    {
        GameSoundManager.PlayHeroVikingDeath();
        return;
    }

    protected override void PlayIntroTaunt()
    {
        GameSoundManager.PlayHeroVikingTauntIntro();
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
        if (this.isBear != null)
        {
            goto Label_004B;
        }
        base.sprite.RevertToStatic();
        goto Label_005B;
    Label_004B:
        base.sprite.PlayAnim("bearIdle");
    Label_005B:
        return;
    }

    protected override bool RunSpecial()
    {
        this.bearReloadTimeCounter += 1;
        this.callAncestorsReloadTimeCounter += 1;
        if (base.RunSpecial() == null)
        {
            goto Label_0029;
        }
        return 1;
    Label_0029:
        this.EvalRegenerate();
        if (this.isBear == null)
        {
            goto Label_0047;
        }
        if (this.EvalBear() == null)
        {
            goto Label_0047;
        }
        return 1;
    Label_0047:
        if (this.callAncestorsLevel <= 0)
        {
            goto Label_0060;
        }
        if (this.EvalAncestors() == null)
        {
            goto Label_0060;
        }
        return 1;
    Label_0060:
        return 0;
    }

    public override void SetDamage(int damage, bool ignoresArmor = false)
    {
        if (this.isBear != null)
        {
            goto Label_0013;
        }
        base.SetDamage(damage, ignoresArmor);
    Label_0013:
        return;
    }

    protected override void StopOnDead()
    {
        base.StopOnDead();
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isBear = 0;
        this.isGoingBear = 0;
        this.isGoingViking = 0;
        this.isCallingAncestors = 0;
        return;
    }

    protected override void StopSpecial()
    {
        base.StopSpecial();
        base.isCharging = 0;
        base.isLevelUp = 0;
        this.isCallingAncestors = 0;
        return;
    }

    protected void UpgradeAncestors()
    {
        if (base.level == 2)
        {
            goto Label_0025;
        }
        if (base.level == 5)
        {
            goto Label_0025;
        }
        if (base.level == 8)
        {
            goto Label_0025;
        }
        return;
    Label_0025:
        if (base.level != 2)
        {
            goto Label_0038;
        }
        this.callAncestorsLevel = 1;
    Label_0038:
        if (base.level != 5)
        {
            goto Label_004B;
        }
        this.callAncestorsLevel = 2;
    Label_004B:
        if (base.level != 8)
        {
            goto Label_005E;
        }
        this.callAncestorsLevel = 3;
    Label_005E:
        this.callAncestorsReloadTime = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsReloadTime", 1)) * 30;
        this.callAncestorsChargeTime = 40;
        this.callAncestorsMax = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsMax", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsMaxIncrement", 1)) * this.callAncestorsLevel);
        return;
    }

    protected void UpgradeBear()
    {
        if (base.level == 4)
        {
            goto Label_0026;
        }
        if (base.level == 7)
        {
            goto Label_0026;
        }
        if (base.level == 10)
        {
            goto Label_0026;
        }
        return;
    Label_0026:
        if (base.level != 4)
        {
            goto Label_0039;
        }
        this.bearLevel = 1;
    Label_0039:
        if (base.level != 7)
        {
            goto Label_004C;
        }
        this.bearLevel = 2;
    Label_004C:
        if (base.level != 10)
        {
            goto Label_0060;
        }
        this.bearLevel = 3;
    Label_0060:
        this.bearReloadTime = ((int) GameSettings.GetHeroSetting("hero_viking", "bearReloadTime", 1)) * 30;
        this.bearReloadTimeCounter = 0;
        this.bearDurationTime = (((int) GameSettings.GetHeroSetting("hero_viking", "bearDuration", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "bearDurationIncrement", 1)) * this.bearLevel)) * 30;
        this.bearMinDamage = ((int) GameSettings.GetHeroSetting("hero_viking", "bearMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "bearDamageIncrement", 1)) * this.bearLevel);
        this.bearMaxDamage = ((int) GameSettings.GetHeroSetting("hero_viking", "bearMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "bearDamageIncrement", 1)) * this.bearLevel);
        this.bearMinHealthActivate = (int) GameSettings.GetHeroSetting("hero_viking", "bearMinLifeActivate", 1);
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
        if (base.path.Count != null)
        {
            goto Label_0017;
        }
        return base.Walk();
    Label_0017:
        vector = ((AStarNode) base.path[base.currentPathNode - 1]).GetNodeRealPosition() + new Vector2(0f, 5f);
        if (this.DestinationReachOnPath(vector) == null)
        {
            goto Label_0089;
        }
        base.currentPathNode -= 1;
        if ((base.currentPathNode - 1) != null)
        {
            goto Label_0089;
        }
        base.path.Clear();
        base.currentPathNode = 0;
        return base.Walk();
    Label_0089:
        node = (AStarNode) base.path[base.currentPathNode - 1];
        vector2 = node.GetNodeRealPosition() + new Vector2(0f, 5f);
        num = Mathf.Atan2(&vector2.y - &base.transform.position.y, &vector2.x - &base.transform.position.x);
        if (&vector2.x >= &base.transform.position.x)
        {
            goto Label_013F;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_014F;
    Label_013F:
        base.transform.localScale = Vector3.one;
    Label_014F:
        this.AddWalkParticle();
        base.transform.position = new Vector3(&base.transform.position.x + (Mathf.Cos(num) * base.speed), &base.transform.position.y + (Mathf.Sin(num) * base.speed), &base.transform.position.z);
        return 0;
    }
}

