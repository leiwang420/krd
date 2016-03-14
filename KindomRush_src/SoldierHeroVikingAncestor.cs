using System;
using UnityEngine;

public class SoldierHeroVikingAncestor : SoldierReinforcement
{
    public SoldierHeroVikingAncestor()
    {
        base..ctor();
        return;
    }

    public unsafe void Init(int myLevel, Vector2 rPoint)
    {
        int num;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        base.rallyPoint = rPoint;
        base.rangePoint = rPoint - new Vector2(base.xAdjust, base.yAdjust);
        base.attackChargeTime = 0x1c;
        base.attackChargeDamageTime = 15;
        base.rangeWidth = (int) GameSettings.GetHeroSetting("hero_viking", "ancestorsRangeRally", 1);
        base.rangeHeight = Mathf.RoundToInt(((float) base.rangeWidth) * 0.7f);
        base.regenerateHealth = (int) GameSettings.GetHeroSetting("hero_viking", "ancestorsRegen", 1);
        base.regenerateTime = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsRegenReload", 1)) * 30;
        base.armor = (int) GameSettings.GetHeroSetting("hero_viking", "ancestorsArmor", 1);
        base.deadTime = 30;
        base.attackReloadTime = (((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsReload", 1)) * 30) - base.attackChargeTime;
        base.health = base.initHealth = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsHealth", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsHealthIncrement", 1)) * myLevel);
        base.minDamage = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsDamageIncrement", 1)) * myLevel);
        base.maxDamage = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsDamageIncrement", 1)) * myLevel);
        base.respawnTime = 0x24;
        base.speed = 4.1f;
        base.lifes = 1;
        base.xAdjust = 8f;
        base.idleTime = 30;
        base.isActive = 0;
        base.isDead = 1;
        base.isLifeTimed = 1;
        base.lifeTime = ((int) GameSettings.GetHeroSetting("hero_viking", "ancestorsLifeTime", 1)) * 30;
        base.lifeTimeCounter = 0;
        base.deadTimeCounter = base.deadTime - 1;
        base.mainBar = UnityEngine.Object.Instantiate(base.lifeBarPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yLifebarOffset), &base.transform.position.z + 1f), Quaternion.identity) as Transform;
        base.mainBar.parent = base.transform;
        base.lifeBar = base.mainBar.FindChild("Bar");
        return;
    }

    private void Start()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.sprite.PlayAnim("respawn");
        return;
    }
}

