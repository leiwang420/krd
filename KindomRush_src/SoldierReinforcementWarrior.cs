using System;
using UnityEngine;

public class SoldierReinforcementWarrior : SoldierReinforcement
{
    public SoldierReinforcementWarrior()
    {
        base..ctor();
        return;
    }

    private void Start()
    {
        int num;
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        base.rangeWidth = 170;
        base.rangeHeight = Mathf.CeilToInt(((float) base.rangeWidth) * 0.7f);
        base.unitClickable = base.GetComponent<UnitClickable>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.stage.AddSoldier(this);
        base.yLifebarOffset = 20;
        base.deadTime = 10;
        base.attackChargeTime = 11;
        base.attackChargeDamageTime = 5;
        base.attackReloadTime = (GameSettings.GetPowerSetting("power_reinforcement_warrior", "reload") * 30) - base.attackChargeTime;
        base.minDamage = GameSettings.GetPowerSetting("power_reinforcement_warrior", "minDamage");
        base.maxDamage = GameSettings.GetPowerSetting("power_reinforcement_warrior", "maxDamage");
        base.health = base.initHealth = GameSettings.GetPowerSetting("power_reinforcement_warrior", "health");
        base.armor = GameSettings.GetPowerSetting("power_reinforcement_warrior", "armor");
        base.lifeTime = GameSettings.GetPowerSetting("power_reinforcement_warrior", "lifeTime") * 30;
        base.regenerateHealth = GameSettings.GetPowerSetting("power_reinforcement_warrior", "regen");
        base.regenerateTime = GameSettings.GetPowerSetting("power_reinforcement_warrior", "regenReload") * 30;
        this.LoadNames();
        base.SetRandomName();
        return;
    }
}

