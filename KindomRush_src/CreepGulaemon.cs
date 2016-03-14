using System;
using UnityEngine;

public class CreepGulaemon : CreepDemon
{
    private int flyingChargeTime;
    private int flyingChargeTimeCounter;
    private int flyingDurationTime;
    private int flyingDurationTimeCounter;
    private int flyingEndChargeTime;
    private int flyingEndChargeTimeCounter;
    private int flyingMinNodes;
    private int flyingMinNodesToGoDown;
    private int flyingReloadTime;
    private int flyingReloadTimeCounter;
    private Transform iceBlockFlyingPrefab;
    private Transform iceBlockNormalPrefab;
    private bool isEndFlying;
    private bool isGoingFlying;
    private PackedSprite spriteShadow;

    public CreepGulaemon()
    {
        base..ctor();
        return;
    }

    public override void Block(Soldier mySoldier)
    {
        if (this.CanInitFly() == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.Block(mySoldier);
        return;
    }

    private bool CanInitFly()
    {
        if (this.isGoingFlying != null)
        {
            goto Label_0050;
        }
        if (this.flyingReloadTimeCounter >= this.flyingReloadTime)
        {
            goto Label_001E;
        }
        return 0;
    Label_001E:
        if ((base.currentNode + this.flyingMinNodes) < ((int) base.path[base.pathIndex][base.subpathIndex].Length))
        {
            goto Label_0048;
        }
        return 0;
    Label_0048:
        this.DoInitFlying();
        return 1;
    Label_0050:
        return 0;
    }

    public override unsafe void CheckFacing()
    {
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        double num;
        Vector3 vector4;
        Vector3 vector5;
        if (base.isStunned == null)
        {
            goto Label_0016;
        }
        base.creepSprite.RevertToStatic();
    Label_0016:
        if (base.path != null)
        {
            goto Label_0032;
        }
        base.path = base.stage.GetPath();
    Label_0032:
        vector = ((base.currentNode + 1) >= ((int) base.path[base.pathIndex][base.subpathIndex].Length)) ? *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode])) : *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode + 1]));
        &vector2 = new Vector2(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y);
        vector3 = vector - vector2;
        &vector3.Normalize();
        num = ((double) (Mathf.Atan2(&vector3.y, &vector3.x) * 180f)) / 3.14;
        if (num >= 0.0)
        {
            goto Label_012F;
        }
        num += 360.0;
    Label_012F:
        if (num <= 55.0)
        {
            goto Label_0195;
        }
        if (num >= 135.0)
        {
            goto Label_0195;
        }
        if (base.facing == 1)
        {
            goto Label_02EB;
        }
        base.facing = 1;
        if (base.isFlying == null)
        {
            goto Label_0180;
        }
        base.creepSprite.PlayAnim("flyUp");
        goto Label_0190;
    Label_0180:
        base.creepSprite.PlayAnim("walkUp");
    Label_0190:
        goto Label_02EB;
    Label_0195:
        if (num < 135.0)
        {
            goto Label_021F;
        }
        if (num > 240.0)
        {
            goto Label_021F;
        }
        if (base.facing == 2)
        {
            goto Label_02EB;
        }
        base.facing = 2;
        if (base.isFlying == null)
        {
            goto Label_01E6;
        }
        base.creepSprite.PlayAnim("fly");
        goto Label_01F6;
    Label_01E6:
        base.creepSprite.PlayAnim("walk");
    Label_01F6:
        base.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_02EB;
    Label_021F:
        if (num <= 240.0)
        {
            goto Label_0284;
        }
        if (num >= 315.0)
        {
            goto Label_0284;
        }
        if (base.facing == null)
        {
            goto Label_02EB;
        }
        base.facing = 0;
        if (base.isFlying == null)
        {
            goto Label_026F;
        }
        base.creepSprite.PlayAnim("flyDown");
        goto Label_027F;
    Label_026F:
        base.creepSprite.PlayAnim("walkDown");
    Label_027F:
        goto Label_02EB;
    Label_0284:
        if (base.facing == 3)
        {
            goto Label_02EB;
        }
        base.facing = 3;
        if (base.isFlying == null)
        {
            goto Label_02B7;
        }
        base.creepSprite.PlayAnim("fly");
        goto Label_02C7;
    Label_02B7:
        base.creepSprite.PlayAnim("walk");
    Label_02C7:
        base.creepSprite.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_02EB:
        return;
    }

    protected virtual void Die()
    {
        if (base.isDead != null)
        {
            goto Label_00ED;
        }
        if ((base.iceBlock != null) == null)
        {
            goto Label_002C;
        }
        UnityEngine.Object.Destroy(base.iceBlock.gameObject);
    Label_002C:
        if (base.gibs == null)
        {
            goto Label_0042;
        }
        base.SpawnGibs();
        goto Label_0095;
    Label_0042:
        if (base.desintegrate == null)
        {
            goto Label_0058;
        }
        base.SpawnDesintegrate();
        goto Label_0095;
    Label_0058:
        if (base.isFlying == null)
        {
            goto Label_0078;
        }
        base.creepSprite.PlayAnim("flyDeath");
        goto Label_0088;
    Label_0078:
        base.creepSprite.PlayAnim("death");
    Label_0088:
        base.isFading = 1;
        this.PlayDeathSound();
    Label_0095:
        if (base.useGold == null)
        {
            goto Label_00B1;
        }
        base.stage.AddGold(base.gold);
    Label_00B1:
        base.BloodDecal();
        base.isDead = 1;
        base.active = 0;
        base.gui.HideInfo(base.clickable);
        base.clickable.UnSelect();
        base.collider.enabled = 0;
    Label_00ED:
        return;
    }

    private void DoEndFlying()
    {
        this.isEndFlying = 1;
        base.canBeBlocked = 1;
        this.flyingEndChargeTimeCounter = 0;
        this.RunAnimationEndFlying();
        return;
    }

    private void DoInitFlying()
    {
        this.isGoingFlying = 1;
        base.canBeBlocked = 0;
        base.canBeThorned = 0;
        this.flyingChargeTimeCounter = 0;
        this.RunAnimationInitFlying();
        return;
    }

    private void EndEndFlying()
    {
        base.isFlying = 0;
        this.isEndFlying = 0;
        base.canBeThorned = 1;
        this.flyingEndChargeTimeCounter = 0;
        this.flyingReloadTimeCounter = 0;
        base.RemoveAllSlowModifiers();
        base.speed = 1.08f;
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_004C;
        }
        this.CheckFacing();
    Label_004C:
        this.SetGroundSettings();
        return;
    }

    private void EndInitFlying()
    {
        base.isFlying = 1;
        this.isGoingFlying = 0;
        this.flyingChargeTimeCounter = 0;
        this.flyingReloadTimeCounter = 0;
        this.flyingDurationTimeCounter = 0;
        base.RemoveAllSlowModifiers();
        base.speed = 3.1f;
        base.facing = -1;
        if (base.isBlocked != null)
        {
            goto Label_004C;
        }
        this.CheckFacing();
    Label_004C:
        this.SetFlyingSettings();
        return;
    }

    protected override unsafe void InitCustomSettings()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.explodeRangeWidth = 170;
        base.explodeRangeHeight = Mathf.RoundToInt(((float) base.explodeRangeWidth) * 0.7f);
        base.explodeDamageTime = 5;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y - 10f, -780f);
        UnityEngine.Object.Instantiate(base.portalVeznan, vector, Quaternion.identity);
        this.CheckFacing();
        this.spriteShadow = base.transform.FindChild("Shadow").GetComponent<PackedSprite>();
        this.flyingMinNodes = 30;
        this.flyingMinNodesToGoDown = 20;
        this.flyingReloadTime = 450;
        this.flyingReloadTimeCounter = 0;
        this.flyingChargeTime = 3;
        this.flyingChargeTimeCounter = 0;
        this.flyingDurationTime = 60;
        this.flyingDurationTimeCounter = 0;
        this.flyingEndChargeTime = 5;
        this.flyingEndChargeTimeCounter = 0;
        this.iceBlockNormalPrefab = Resources.Load("Prefabs/CreepIceBlock", typeof(Transform)) as Transform;
        this.iceBlockFlyingPrefab = Resources.Load("Prefabs/CreepIceBlockFlying", typeof(Transform)) as Transform;
        return;
    }

    private void RunAnimationEndFlying()
    {
        if (base.facing != 1)
        {
            goto Label_0021;
        }
        base.creepSprite.PlayAnim("endFlyUp");
        goto Label_0051;
    Label_0021:
        if (base.facing != null)
        {
            goto Label_0041;
        }
        base.creepSprite.PlayAnim("endFlyDown");
        goto Label_0051;
    Label_0041:
        base.creepSprite.PlayAnim("endFly");
    Label_0051:
        return;
    }

    private void RunAnimationInitFlying()
    {
        if (base.facing != 1)
        {
            goto Label_0021;
        }
        base.creepSprite.PlayAnim("initFlyUp");
        goto Label_0051;
    Label_0021:
        if (base.facing != null)
        {
            goto Label_0041;
        }
        base.creepSprite.PlayAnim("initFlyDown");
        goto Label_0051;
    Label_0041:
        base.creepSprite.PlayAnim("initFly");
    Label_0051:
        return;
    }

    private void SetFlyingSettings()
    {
        Transform transform5;
        Transform transform4;
        Transform transform3;
        Transform transform2;
        Transform transform1;
        base.yModifierAdjust = 30f;
        base.yAdjust = 30f;
        transform1 = base.mainBar.transform;
        transform1.position += new Vector3(0f, 33f, 0f);
        if ((base.poisonEffect != null) == null)
        {
            goto Label_0085;
        }
        transform2 = base.poisonEffect.transform;
        transform2.position += new Vector3(0f, 30f, 0f);
    Label_0085:
        if ((base.burnEffect != null) == null)
        {
            goto Label_00C5;
        }
        transform3 = base.burnEffect.transform;
        transform3.position += new Vector3(0f, 30f, 0f);
    Label_00C5:
        if ((base.curseEffect != null) == null)
        {
            goto Label_0105;
        }
        transform4 = base.curseEffect.transform;
        transform4.position += new Vector3(0f, 30f, 0f);
    Label_0105:
        if ((base.teslaEffect != null) == null)
        {
            goto Label_0145;
        }
        transform5 = base.teslaEffect.transform;
        transform5.position += new Vector3(0f, 30f, 0f);
    Label_0145:
        if ((base.shield != null) == null)
        {
            goto Label_0180;
        }
        base.shield.position += new Vector3(0f, 30f, 0f);
    Label_0180:
        base.iceBlockPrefab = this.iceBlockFlyingPrefab;
        return;
    }

    private unsafe void SetGroundSettings()
    {
        Transform transform4;
        Transform transform3;
        Transform transform2;
        Transform transform1;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.yModifierAdjust = 0f;
        base.yAdjust = 0f;
        base.mainBar.transform.position = new Vector3(&base.transform.position.x + ((float) base.xLifebarOffset), &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z);
        if ((base.poisonEffect != null) == null)
        {
            goto Label_00B4;
        }
        transform1 = base.poisonEffect.transform;
        transform1.position -= new Vector3(0f, 30f, 0f);
    Label_00B4:
        if ((base.burnEffect != null) == null)
        {
            goto Label_00F4;
        }
        transform2 = base.burnEffect.transform;
        transform2.position -= new Vector3(0f, 30f, 0f);
    Label_00F4:
        if ((base.curseEffect != null) == null)
        {
            goto Label_0134;
        }
        transform3 = base.curseEffect.transform;
        transform3.position -= new Vector3(0f, 30f, 0f);
    Label_0134:
        if ((base.teslaEffect != null) == null)
        {
            goto Label_0174;
        }
        transform4 = base.teslaEffect.transform;
        transform4.position -= new Vector3(0f, 30f, 0f);
    Label_0174:
        if ((base.shield != null) == null)
        {
            goto Label_01AF;
        }
        base.shield.position -= new Vector3(0f, 30f, 0f);
    Label_01AF:
        base.iceBlockPrefab = this.iceBlockNormalPrefab;
        return;
    }

    private bool SpecialEndFlying()
    {
        if (this.isEndFlying != null)
        {
            goto Label_000D;
        }
        return 0;
    Label_000D:
        if (this.flyingEndChargeTimeCounter >= this.flyingEndChargeTime)
        {
            goto Label_002E;
        }
        this.flyingEndChargeTimeCounter += 1;
        return 1;
    Label_002E:
        this.EndEndFlying();
        return 0;
    }

    private bool SpecialInitFlying()
    {
        if (base.isFlying != null)
        {
            goto Label_0016;
        }
        if (this.isGoingFlying != null)
        {
            goto Label_0018;
        }
    Label_0016:
        return 0;
    Label_0018:
        if (this.flyingChargeTimeCounter >= this.flyingChargeTime)
        {
            goto Label_0039;
        }
        this.flyingChargeTimeCounter += 1;
        return 1;
    Label_0039:
        this.EndInitFlying();
        return 0;
    }

    protected override void SpecialPasivePower()
    {
        base.SpecialPasivePower();
        if (base.isFlying == null)
        {
            goto Label_006A;
        }
        if (this.isEndFlying != null)
        {
            goto Label_006A;
        }
        if (this.flyingDurationTimeCounter >= this.flyingDurationTime)
        {
            goto Label_0064;
        }
        this.flyingDurationTimeCounter += 1;
        if ((base.currentNode + this.flyingMinNodesToGoDown) >= ((int) base.path[base.pathIndex][base.subpathIndex].Length))
        {
            goto Label_0064;
        }
        return;
    Label_0064:
        this.DoEndFlying();
    Label_006A:
        return;
    }

    protected override bool SpecialPower()
    {
        if (this.SpecialInitFlying() == null)
        {
            goto Label_000D;
        }
        return 1;
    Label_000D:
        if (this.SpecialEndFlying() == null)
        {
            goto Label_001A;
        }
        return 1;
    Label_001A:
        return base.SpecialPower();
    }

    protected override void StopSpecialPower()
    {
        base.StopSpecialPower();
        if (base.isFlying == null)
        {
            goto Label_0017;
        }
        this.EndInitFlying();
    Label_0017:
        return;
    }

    protected override void UpdateSpecialPowerCooldowns()
    {
        this.flyingReloadTimeCounter += 1;
        return;
    }
}

