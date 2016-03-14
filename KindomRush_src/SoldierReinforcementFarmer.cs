using System;
using UnityEngine;

public class SoldierReinforcementFarmer : SoldierReinforcement
{
    public SoldierReinforcementFarmer()
    {
        base..ctor();
        return;
    }

    private void Start()
    {
        int num;
        int num2;
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
        base.attackReloadTime = (GameSettings.GetPowerSetting("power_reinforcement_conscript", "reload") * 30) - base.attackChargeTime;
        num = GameUpgrades.ReinforcementLevel;
        if (base.stage.MaxUpgradeLevel == null)
        {
            goto Label_00FB;
        }
        if (base.stage.MaxUpgradeLevel >= GameUpgrades.ReinforcementLevel)
        {
            goto Label_00FB;
        }
        num = base.stage.MaxUpgradeLevel;
    Label_00FB:
        if (num != null)
        {
            goto Label_01A8;
        }
        base.minDamage = GameSettings.GetPowerSetting("power_reinforcement_farmer", "minDamage");
        base.maxDamage = GameSettings.GetPowerSetting("power_reinforcement_farmer", "maxDamage");
        base.health = base.initHealth = GameSettings.GetPowerSetting("power_reinforcement_farmer", "health");
        base.armor = GameSettings.GetPowerSetting("power_reinforcement_farmer", "armor");
        base.lifeTime = GameSettings.GetPowerSetting("power_reinforcement_farmer", "lifeTime") * 30;
        base.regenerateHealth = GameSettings.GetPowerSetting("power_reinforcement_farmer", "regen");
        base.regenerateTime = GameSettings.GetPowerSetting("power_reinforcement_farmer", "regenReload") * 30;
        goto Label_0251;
    Label_01A8:
        if (num != 1)
        {
            goto Label_0251;
        }
        base.minDamage = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "minDamage");
        base.maxDamage = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "maxDamage");
        base.health = base.initHealth = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "health");
        base.armor = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "armor");
        base.lifeTime = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "lifeTime") * 30;
        base.regenerateHealth = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "regen");
        base.regenerateTime = GameSettings.GetPowerSetting("power_reinforcement_farmer_wellfeed", "regenReload") * 30;
    Label_0251:
        this.LoadNames();
        base.SetRandomName();
        return;
    }
}

