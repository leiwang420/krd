using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameSettings
{
    private Dictionary<string, int> abilityPrices;
    private Dictionary<string, Dictionary<string, float[]>> heroesMasterTable;
    private static GameSettings instance;
    private Dictionary<string, Dictionary<string, int>> powerSettings;
    private Dictionary<string, Dictionary<string, int>> powerSettingsReal;
    private Dictionary<string, int> towerPrices;
    private Dictionary<string, Dictionary<string, float>> towersSettings;
    private Dictionary<string, Dictionary<string, float>> towersSettingsReal;

    public GameSettings()
    {
        base..ctor();
        if (instance == null)
        {
            goto Label_001B;
        }
        Debug.LogError("Cannot have two instances of singleton.");
        return;
    Label_001B:
        instance = this;
        this.Init();
        return;
    }

    private Dictionary<string, Dictionary<string, int>> ClonePowerRealSettings()
    {
        Dictionary<string, Dictionary<string, int>> dictionary;
        Dictionary<string, int> dictionary2;
        Dictionary<string, int> dictionary3;
        Dictionary<string, int> dictionary4;
        Dictionary<string, int> dictionary5;
        Dictionary<string, int> dictionary6;
        Dictionary<string, int> dictionary7;
        Dictionary<string, int> dictionary8;
        dictionary = new Dictionary<string, Dictionary<string, int>>();
        dictionary8 = new Dictionary<string, int>();
        dictionary8.Add("coolDown", 80);
        dictionary8.Add("range", 170);
        dictionary8.Add("minDamage", 30);
        dictionary8.Add("maxDamage", 60);
        dictionary8.Add("scorchedEarthRange", 0xb7);
        dictionary8.Add("scorchedEarthMinDamage", 10);
        dictionary8.Add("scorchedEarthMaxDamage", 20);
        dictionary8.Add("scorchedEarthDamageTime", 1);
        dictionary8.Add("scorchedEarthDuration", 5);
        dictionary8.Add("blazingEarthRange", 0xb7);
        dictionary8.Add("blazingEarthMinDamage", 20);
        dictionary8.Add("blazingEarthMaxDamage", 30);
        dictionary8.Add("blazingEarthDamageTime", 1);
        dictionary8.Add("blazingEarthDuration", 10);
        dictionary2 = dictionary8;
        dictionary.Add("power_fireball", dictionary2);
        dictionary8 = new Dictionary<string, int>();
        dictionary8.Add("coolDown", 10);
        dictionary8.Add("range", 170);
        dictionary8.Add("health", 30);
        dictionary8.Add("armor", 0);
        dictionary8.Add("minDamage", 1);
        dictionary8.Add("maxDamage", 2);
        dictionary8.Add("reload", 1);
        dictionary8.Add("lifeTime", 20);
        dictionary8.Add("regen", 3);
        dictionary8.Add("regenReload", 1);
        dictionary3 = dictionary8;
        dictionary.Add("power_reinforcement_farmer", dictionary3);
        dictionary8 = new Dictionary<string, int>();
        dictionary8.Add("coolDown", 10);
        dictionary8.Add("range", 170);
        dictionary8.Add("health", 50);
        dictionary8.Add("armor", 0);
        dictionary8.Add("minDamage", 1);
        dictionary8.Add("maxDamage", 3);
        dictionary8.Add("reload", 1);
        dictionary8.Add("lifeTime", 20);
        dictionary8.Add("regen", 6);
        dictionary8.Add("regenReload", 1);
        dictionary4 = dictionary8;
        dictionary.Add("power_reinforcement_farmer_wellfeed", dictionary4);
        dictionary8 = new Dictionary<string, int>();
        dictionary8.Add("coolDown", 10);
        dictionary8.Add("range", 170);
        dictionary8.Add("health", 70);
        dictionary8.Add("armor", 10);
        dictionary8.Add("minDamage", 2);
        dictionary8.Add("maxDamage", 4);
        dictionary8.Add("reload", 1);
        dictionary8.Add("lifeTime", 20);
        dictionary8.Add("regen", 9);
        dictionary8.Add("regenReload", 1);
        dictionary5 = dictionary8;
        dictionary.Add("power_reinforcement_conscript", dictionary5);
        dictionary8 = new Dictionary<string, int>();
        dictionary8.Add("coolDown", 10);
        dictionary8.Add("range", 170);
        dictionary8.Add("health", 90);
        dictionary8.Add("armor", 20);
        dictionary8.Add("minDamage", 3);
        dictionary8.Add("maxDamage", 6);
        dictionary8.Add("reload", 1);
        dictionary8.Add("lifeTime", 20);
        dictionary8.Add("regen", 12);
        dictionary8.Add("regenReload", 1);
        dictionary6 = dictionary8;
        dictionary.Add("power_reinforcement_warrior", dictionary6);
        dictionary8 = new Dictionary<string, int>();
        dictionary8.Add("coolDown", 10);
        dictionary8.Add("range", 170);
        dictionary8.Add("health", 110);
        dictionary8.Add("armor", 30);
        dictionary8.Add("minDamage", 6);
        dictionary8.Add("maxDamage", 10);
        dictionary8.Add("reload", 1);
        dictionary8.Add("lifeTime", 20);
        dictionary8.Add("regen", 15);
        dictionary8.Add("regenReload", 1);
        dictionary8.Add("spearCoolDown", 1);
        dictionary8.Add("spearRange", 0x1d1);
        dictionary8.Add("spearMinRange", 0x36);
        dictionary8.Add("spearMinDamage", 0x18);
        dictionary8.Add("spearMaxDamage", 40);
        dictionary7 = dictionary8;
        dictionary.Add("power_reinforcement_leggionaire", dictionary7);
        return dictionary;
    }

    private Dictionary<string, Dictionary<string, float>> CloneRealSettings()
    {
        Dictionary<string, Dictionary<string, float>> dictionary;
        Dictionary<string, float> dictionary2;
        Dictionary<string, float> dictionary3;
        Dictionary<string, float> dictionary4;
        Dictionary<string, float> dictionary5;
        Dictionary<string, float> dictionary6;
        Dictionary<string, float> dictionary7;
        Dictionary<string, float> dictionary8;
        Dictionary<string, float> dictionary9;
        Dictionary<string, float> dictionary10;
        Dictionary<string, float> dictionary11;
        Dictionary<string, float> dictionary12;
        Dictionary<string, float> dictionary13;
        Dictionary<string, float> dictionary14;
        Dictionary<string, float> dictionary15;
        Dictionary<string, float> dictionary16;
        Dictionary<string, float> dictionary17;
        Dictionary<string, float> dictionary18;
        Dictionary<string, float> dictionary19;
        Dictionary<string, float> dictionary20;
        Dictionary<string, float> dictionary21;
        Dictionary<string, float> dictionary22;
        dictionary = new Dictionary<string, Dictionary<string, float>>();
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 70f);
        dictionary22.Add("range", 395f);
        dictionary22.Add("minDamage", 4f);
        dictionary22.Add("maxDamage", 6f);
        dictionary22.Add("reload", 0.8f);
        dictionary2 = dictionary22;
        dictionary.Add("archer_level1", dictionary2);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 110f);
        dictionary22.Add("range", 450f);
        dictionary22.Add("minDamage", 7f);
        dictionary22.Add("maxDamage", 11f);
        dictionary22.Add("reload", 0.6f);
        dictionary3 = dictionary22;
        dictionary.Add("archer_level2", dictionary3);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 160f);
        dictionary22.Add("range", 507f);
        dictionary22.Add("minDamage", 10f);
        dictionary22.Add("maxDamage", 16f);
        dictionary22.Add("reload", 0.5f);
        dictionary4 = dictionary22;
        dictionary.Add("archer_level3", dictionary4);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 230f);
        dictionary22.Add("range", 564f);
        dictionary22.Add("minDamage", 13f);
        dictionary22.Add("maxDamage", 19f);
        dictionary22.Add("reload", 0.4f);
        dictionary22.Add("poisonPrice", 250f);
        dictionary22.Add("poisonPriceLevel", 250f);
        dictionary22.Add("poisonDuration", 3f);
        dictionary22.Add("poisonDamage", 5f);
        dictionary22.Add("poisonLevels", 3f);
        dictionary22.Add("thornPrice", 300f);
        dictionary22.Add("thornPriceLevel", 150f);
        dictionary22.Add("thornMinEnemies", 2f);
        dictionary22.Add("thornMaxEnemies", 2f);
        dictionary22.Add("thornDuration", 1f);
        dictionary22.Add("thornDamageTime", 1f);
        dictionary22.Add("thornDamage", 40f);
        dictionary22.Add("thornCoolDown", 8f);
        dictionary22.Add("thornMaxTimes", 3f);
        dictionary22.Add("thornLevels", 3f);
        dictionary5 = dictionary22;
        dictionary.Add("archer_ranger", dictionary5);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 230f);
        dictionary22.Add("range", 663f);
        dictionary22.Add("minDamage", 35f);
        dictionary22.Add("maxDamage", 65f);
        dictionary22.Add("reload", 1.5f);
        dictionary22.Add("sniperPrice", 250f);
        dictionary22.Add("sniperPriceLevel", 250f);
        dictionary22.Add("sniperRange", 1.5f);
        dictionary22.Add("sniperDamagePercent", 20f);
        dictionary22.Add("sniperCoolDown", 14f);
        dictionary22.Add("sniperLevels", 3f);
        dictionary22.Add("shrapnelPrice", 300f);
        dictionary22.Add("shrapnelPriceLevel", 300f);
        dictionary22.Add("shrapnelRange", 0.5f);
        dictionary22.Add("shrapnelArea", 90f);
        dictionary22.Add("shrapnelMinDamage", 10f);
        dictionary22.Add("shrapnelMaxDamage", 40f);
        dictionary22.Add("shrapnelCoolDown", 9f);
        dictionary22.Add("shrapnelLevels", 3f);
        dictionary6 = dictionary22;
        dictionary.Add("archer_musketeer", dictionary6);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 70f);
        dictionary22.Add("rangeRally", 409f);
        dictionary22.Add("range", 170f);
        dictionary22.Add("minDamage", 1f);
        dictionary22.Add("maxDamage", 3f);
        dictionary22.Add("reload", 1f);
        dictionary22.Add("health", 50f);
        dictionary22.Add("armor", 0f);
        dictionary22.Add("respawn", 10f);
        dictionary22.Add("regen", 5f);
        dictionary22.Add("regenReload", 1f);
        dictionary7 = dictionary22;
        dictionary.Add("barrack_level1", dictionary7);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 110f);
        dictionary22.Add("rangeRally", 409f);
        dictionary22.Add("range", 170f);
        dictionary22.Add("minDamage", 3f);
        dictionary22.Add("maxDamage", 4f);
        dictionary22.Add("reload", 1f);
        dictionary22.Add("health", 100f);
        dictionary22.Add("armor", 15f);
        dictionary22.Add("respawn", 10f);
        dictionary22.Add("regen", 7f);
        dictionary22.Add("regenReload", 1f);
        dictionary8 = dictionary22;
        dictionary.Add("barrack_level2", dictionary8);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 160f);
        dictionary22.Add("rangeRally", 409f);
        dictionary22.Add("range", 170f);
        dictionary22.Add("minDamage", 6f);
        dictionary22.Add("maxDamage", 10f);
        dictionary22.Add("reload", 1f);
        dictionary22.Add("health", 150f);
        dictionary22.Add("armor", 30f);
        dictionary22.Add("respawn", 10f);
        dictionary22.Add("regen", 10f);
        dictionary22.Add("regenReload", 1f);
        dictionary9 = dictionary22;
        dictionary.Add("barrack_level3", dictionary9);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 230f);
        dictionary22.Add("rangeRally", 409f);
        dictionary22.Add("range", 170f);
        dictionary22.Add("minDamage", 12f);
        dictionary22.Add("maxDamage", 18f);
        dictionary22.Add("reload", 1f);
        dictionary22.Add("health", 200f);
        dictionary22.Add("armor", 50f);
        dictionary22.Add("respawn", 14f);
        dictionary22.Add("regen", 25f);
        dictionary22.Add("regenReload", 1f);
        dictionary22.Add("holyStrikePrice", 220f);
        dictionary22.Add("holyStrikePriceLevel", 150f);
        dictionary22.Add("holyStrikeRange", 141f);
        dictionary22.Add("holyStrikeMinEnemies", 1f);
        dictionary22.Add("holyStrikeMinDamage", 25f);
        dictionary22.Add("holyStrikeMaxDamage", 45f);
        dictionary22.Add("holyStrikeChance", 10f);
        dictionary22.Add("holyStrikeLevels", 3f);
        dictionary22.Add("healingPrice", 150f);
        dictionary22.Add("healingPriceLevel", 150f);
        dictionary22.Add("healingMin", 40f);
        dictionary22.Add("healingMax", 60f);
        dictionary22.Add("healingCoolDown", 10f);
        dictionary22.Add("healingLevels", 3f);
        dictionary22.Add("shieldPrice", 250f);
        dictionary22.Add("shieldPriceLevel", 100f);
        dictionary22.Add("shieldArmor", 15f);
        dictionary22.Add("shieldLevels", 1f);
        dictionary10 = dictionary22;
        dictionary.Add("barrack_paladin", dictionary10);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 230f);
        dictionary22.Add("rangeRally", 409f);
        dictionary22.Add("range", 170f);
        dictionary22.Add("minDamage", 16f);
        dictionary22.Add("maxDamage", 24f);
        dictionary22.Add("reload", 1f);
        dictionary22.Add("health", 250f);
        dictionary22.Add("armor", 0f);
        dictionary22.Add("respawn", 10f);
        dictionary22.Add("regen", 20f);
        dictionary22.Add("regenReload", 1f);
        dictionary22.Add("dualWeaponsPrice", 300f);
        dictionary22.Add("dualWeaponsPriceLevel", 100f);
        dictionary22.Add("dualWeaponsIncrementDamage", 10f);
        dictionary22.Add("dualWeaponsLevels", 3f);
        dictionary22.Add("throwingPrice", 200f);
        dictionary22.Add("throwingPriceLevel", 100f);
        dictionary22.Add("throwingCoolDown", 3f);
        dictionary22.Add("throwingRange", 60f);
        dictionary22.Add("throwingMinRange", 437f);
        dictionary22.Add("throwingMinDamage", 24f);
        dictionary22.Add("throwingMaxDamage", 32f);
        dictionary22.Add("throwingIncrementDamage", 10f);
        dictionary22.Add("throwingIncrementRange", 37f);
        dictionary22.Add("throwingLevels", 3f);
        dictionary22.Add("twisterPrice", 150f);
        dictionary22.Add("twisterPriceLevel", 100f);
        dictionary22.Add("twisterRange", 113f);
        dictionary22.Add("twisterMinDamage", 10f);
        dictionary22.Add("twisterMaxDamage", 30f);
        dictionary22.Add("twisterIncrementDamage", 15f);
        dictionary22.Add("twisterChance", 10f);
        dictionary22.Add("twisterIncrementChance", 5f);
        dictionary22.Add("twisterLevels", 3f);
        dictionary11 = dictionary22;
        dictionary.Add("barrack_barbarian", dictionary11);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 100f);
        dictionary22.Add("range", 395f);
        dictionary22.Add("minDamage", 9f);
        dictionary22.Add("maxDamage", 17f);
        dictionary22.Add("reload", 1.5f);
        dictionary12 = dictionary22;
        dictionary.Add("mage_level1", dictionary12);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 160f);
        dictionary22.Add("range", 451f);
        dictionary22.Add("minDamage", 23f);
        dictionary22.Add("maxDamage", 43f);
        dictionary22.Add("reload", 1.5f);
        dictionary13 = dictionary22;
        dictionary.Add("mage_level2", dictionary13);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 240f);
        dictionary22.Add("range", 508f);
        dictionary22.Add("minDamage", 40f);
        dictionary22.Add("maxDamage", 74f);
        dictionary22.Add("reload", 1.5f);
        dictionary14 = dictionary22;
        dictionary.Add("mage_level3", dictionary14);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 300f);
        dictionary22.Add("range", 564f);
        dictionary22.Add("minDamage", 42f);
        dictionary22.Add("maxDamage", 78f);
        dictionary22.Add("reload", 1.5f);
        dictionary22.Add("curseDamage", 10f);
        dictionary22.Add("curseArmorReduce", 50f);
        dictionary22.Add("curseDuration", 5f);
        dictionary22.Add("polymorphPrice", 300f);
        dictionary22.Add("polymorphPriceLevel", 150f);
        dictionary22.Add("polymorphDamage", 50f);
        dictionary22.Add("polymorphCoolDown", 22f);
        dictionary22.Add("polymorphLessCoolDown", 2f);
        dictionary22.Add("polymorphSpeedMultiplier", 1.5f);
        dictionary22.Add("polymorphLevels", 3f);
        dictionary22.Add("elementalPrice", 350f);
        dictionary22.Add("elementalPriceLevel", 150f);
        dictionary22.Add("elementalRallyRange", 508f);
        dictionary22.Add("elementalRange", 212f);
        dictionary22.Add("elementalHealth", 500f);
        dictionary22.Add("elementalExtraHealth", 100f);
        dictionary22.Add("elementalRegen", 20f);
        dictionary22.Add("elementalRegenReload", 1f);
        dictionary22.Add("elementalAreaAttackRangeWidth", 106f);
        dictionary22.Add("elementalAreaAttackMaxEnemies", 4f);
        dictionary22.Add("elementalMinDamage", 20f);
        dictionary22.Add("elementalMaxDamage", 40f);
        dictionary22.Add("elementalDamageExtra", 10f);
        dictionary22.Add("elementalArmor", 30f);
        dictionary22.Add("elementalArmorExtra", 10f);
        dictionary22.Add("elementalReload", 2f);
        dictionary22.Add("elementalRespawnTime", 8f);
        dictionary22.Add("elementalLevels", 3f);
        dictionary15 = dictionary22;
        dictionary.Add("mage_sorcerer", dictionary15);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 300f);
        dictionary22.Add("range", 564f);
        dictionary22.Add("minDamage", 76f);
        dictionary22.Add("maxDamage", 140f);
        dictionary22.Add("reload", 2f);
        dictionary22.Add("desintegratePrice", 350f);
        dictionary22.Add("desintegratePriceLevel", 200f);
        dictionary22.Add("desintegrateCoolDown", 22f);
        dictionary22.Add("desintegrateLessCoolDown", 2f);
        dictionary22.Add("desintegrateLevels", 3f);
        dictionary22.Add("teleportPrice", 300f);
        dictionary22.Add("teleportPriceLevel", 100f);
        dictionary22.Add("teleportRange", 28f);
        dictionary22.Add("teleportMaxEnemies", 3f);
        dictionary22.Add("teleportExtraEnemies", 1f);
        dictionary22.Add("teleportNodes", 20f);
        dictionary22.Add("teleportExtraNodes", 5f);
        dictionary22.Add("teleportCoolDown", 10f);
        dictionary22.Add("teleportMaxTimes", 3f);
        dictionary22.Add("teleportLevels", 3f);
        dictionary16 = dictionary22;
        dictionary.Add("mage_arcane", dictionary16);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 125f);
        dictionary22.Add("range", 451f);
        dictionary22.Add("area", 113f);
        dictionary22.Add("minDamage", 8f);
        dictionary22.Add("maxDamage", 15f);
        dictionary22.Add("reload", 3f);
        dictionary17 = dictionary22;
        dictionary.Add("artillery_level1", dictionary17);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 220f);
        dictionary22.Add("range", 451f);
        dictionary22.Add("area", 113f);
        dictionary22.Add("minDamage", 20f);
        dictionary22.Add("maxDamage", 40f);
        dictionary22.Add("reload", 3f);
        dictionary18 = dictionary22;
        dictionary.Add("artillery_level2", dictionary18);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 320f);
        dictionary22.Add("range", 508f);
        dictionary22.Add("area", 127f);
        dictionary22.Add("minDamage", 30f);
        dictionary22.Add("maxDamage", 60f);
        dictionary22.Add("reload", 3f);
        dictionary19 = dictionary22;
        dictionary.Add("artillery_level3", dictionary19);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 400f);
        dictionary22.Add("range", 508f);
        dictionary22.Add("area", 127f);
        dictionary22.Add("minDamage", 50f);
        dictionary22.Add("maxDamage", 100f);
        dictionary22.Add("reload", 3.5f);
        dictionary22.Add("missilePrice", 250f);
        dictionary22.Add("missilePriceLevel", 100f);
        dictionary22.Add("missileRangeIncrement", 0.2f);
        dictionary22.Add("missileArea", 78f);
        dictionary22.Add("missileMinDamage", 60f);
        dictionary22.Add("missileMaxDamage", 100f);
        dictionary22.Add("missileIncrementDamage", 40f);
        dictionary22.Add("missileCoolDown", 11f);
        dictionary22.Add("missileLevels", 3f);
        dictionary22.Add("clusterPrice", 250f);
        dictionary22.Add("clusterPriceLevel", 150f);
        dictionary22.Add("clusterArea", 100f);
        dictionary22.Add("clusterMinDamage", 60f);
        dictionary22.Add("clusterMaxDamage", 80f);
        dictionary22.Add("clusterMinBombs", 1f);
        dictionary22.Add("clusterIncrementBombs", 2f);
        dictionary22.Add("clusterCoolDown", 17f);
        dictionary22.Add("clusterLevels", 3f);
        dictionary20 = dictionary22;
        dictionary.Add("artillery_bfg", dictionary20);
        dictionary22 = new Dictionary<string, float>();
        dictionary22.Add("price", 375f);
        dictionary22.Add("range", 465f);
        dictionary22.Add("minDamage", 55f);
        dictionary22.Add("maxDamage", 105f);
        dictionary22.Add("reload", 2.2f);
        dictionary22.Add("chargedBoltPrice", 250f);
        dictionary22.Add("chargedBoltPriceLevel", 250f);
        dictionary22.Add("chargedBoltEnemies", 3f);
        dictionary22.Add("chargedBoltIncrementEnemies", 1f);
        dictionary22.Add("chargedBoltCoolDown", 6f);
        dictionary22.Add("chargedBoltLevels", 2f);
        dictionary22.Add("chargedBoltRange", 113f);
        dictionary22.Add("overchargePrice", 250f);
        dictionary22.Add("overchargePriceLevel", 125f);
        dictionary22.Add("overchargeArea", 465f);
        dictionary22.Add("overchargeMinDamage", 0f);
        dictionary22.Add("overchargeMaxDamage", 10f);
        dictionary22.Add("overchargeDamageIncrement", 10f);
        dictionary22.Add("overchargeCoolDown", 6f);
        dictionary22.Add("overchargeLevels", 3f);
        dictionary22.Add("overchargeDisplayRatio", 0.7f);
        dictionary21 = dictionary22;
        dictionary.Add("artillery_tesla", dictionary21);
        return dictionary;
    }

    public static int GetAbilityPrice(string ability)
    {
        if ((ability == "sniperPrice") != null)
        {
            goto Label_0040;
        }
        if ((ability == "sniperPriceLevel") != null)
        {
            goto Label_0040;
        }
        if ((ability == "shrapnelPrice") != null)
        {
            goto Label_0040;
        }
        if ((ability == "shrapnelPriceLevel") == null)
        {
            goto Label_005C;
        }
    Label_0040:
        return (int) Instance.towersSettings["archer_musketeer"][ability];
    Label_005C:
        if ((ability == "poisonPrice") != null)
        {
            goto Label_009C;
        }
        if ((ability == "poisonPriceLevel") != null)
        {
            goto Label_009C;
        }
        if ((ability == "thornPrice") != null)
        {
            goto Label_009C;
        }
        if ((ability == "thornPriceLevel") == null)
        {
            goto Label_00B8;
        }
    Label_009C:
        return (int) Instance.towersSettings["archer_ranger"][ability];
    Label_00B8:
        if ((ability == "holyStrikePrice") != null)
        {
            goto Label_0118;
        }
        if ((ability == "holyStrikePriceLevel") != null)
        {
            goto Label_0118;
        }
        if ((ability == "healingPrice") != null)
        {
            goto Label_0118;
        }
        if ((ability == "healingPriceLevel") != null)
        {
            goto Label_0118;
        }
        if ((ability == "shieldPrice") != null)
        {
            goto Label_0118;
        }
        if ((ability == "shieldPriceLevel") == null)
        {
            goto Label_0134;
        }
    Label_0118:
        return (int) Instance.towersSettings["barrack_paladin"][ability];
    Label_0134:
        if ((ability == "dualWeaponsPrice") != null)
        {
            goto Label_0194;
        }
        if ((ability == "dualWeaponsPriceLevel") != null)
        {
            goto Label_0194;
        }
        if ((ability == "throwingPrice") != null)
        {
            goto Label_0194;
        }
        if ((ability == "throwingPriceLevel") != null)
        {
            goto Label_0194;
        }
        if ((ability == "twisterPrice") != null)
        {
            goto Label_0194;
        }
        if ((ability == "twisterPriceLevel") == null)
        {
            goto Label_01B0;
        }
    Label_0194:
        return (int) Instance.towersSettings["barrack_barbarian"][ability];
    Label_01B0:
        if ((ability == "polymorphPrice") != null)
        {
            goto Label_01F0;
        }
        if ((ability == "polymorphPriceLevel") != null)
        {
            goto Label_01F0;
        }
        if ((ability == "elementalPrice") != null)
        {
            goto Label_01F0;
        }
        if ((ability == "elementalPriceLevel") == null)
        {
            goto Label_020C;
        }
    Label_01F0:
        return (int) Instance.towersSettings["mage_sorcerer"][ability];
    Label_020C:
        if ((ability == "desintegratePrice") != null)
        {
            goto Label_024C;
        }
        if ((ability == "desintegratePriceLevel") != null)
        {
            goto Label_024C;
        }
        if ((ability == "teleportPrice") != null)
        {
            goto Label_024C;
        }
        if ((ability == "teleportPriceLevel") == null)
        {
            goto Label_0268;
        }
    Label_024C:
        return (int) Instance.towersSettings["mage_arcane"][ability];
    Label_0268:
        if ((ability == "missilePrice") != null)
        {
            goto Label_02A8;
        }
        if ((ability == "missilePriceLevel") != null)
        {
            goto Label_02A8;
        }
        if ((ability == "clusterPrice") != null)
        {
            goto Label_02A8;
        }
        if ((ability == "clusterPriceLevel") == null)
        {
            goto Label_02C4;
        }
    Label_02A8:
        return (int) Instance.towersSettings["artillery_bfg"][ability];
    Label_02C4:
        if ((ability == "chargedBoltPrice") != null)
        {
            goto Label_0304;
        }
        if ((ability == "chargedBoltPriceLevel") != null)
        {
            goto Label_0304;
        }
        if ((ability == "overchargePrice") != null)
        {
            goto Label_0304;
        }
        if ((ability == "overchargePriceLevel") == null)
        {
            goto Label_0320;
        }
    Label_0304:
        return (int) Instance.towersSettings["artillery_tesla"][ability];
    Label_0320:
        return 0;
    }

    public static float GetHeroSetting(string heroName, string setting, int level = 1)
    {
        return Instance.heroesMasterTable[heroName][setting][level - 1];
    }

    public static int GetPowerSetting(string power, string setting)
    {
        return Instance.powerSettings[power][setting];
    }

    public static unsafe int GetTowerPrice(string tower)
    {
        ReformatTowerName(&tower);
        return (int) Instance.towersSettings[tower]["price"];
    }

    public static unsafe int GetTowerRange(string tower)
    {
        ReformatTowerName(&tower);
        return (int) Instance.towersSettings[tower]["range"];
    }

    public static float GetTowerSetting(string tower, string setting)
    {
        return Instance.towersSettings[tower][setting];
    }

    private void Init()
    {
        this.towerPrices = new Dictionary<string, int>();
        this.abilityPrices = new Dictionary<string, int>();
        this.towersSettingsReal = new Dictionary<string, Dictionary<string, float>>();
        this.powerSettingsReal = new Dictionary<string, Dictionary<string, int>>();
        this.heroesMasterTable = new Dictionary<string, Dictionary<string, float[]>>();
        this.LoadTowerPrices();
        this.LoadAbilityPrices();
        this.LoadEnemies();
        this.LoadTowers();
        this.LoadPowers();
        this.LoadHeroes();
        return;
    }

    private void LoadAbilityPrices()
    {
        this.abilityPrices.Add("Poison", 250);
        this.abilityPrices.Add("PoisonLevel", 250);
        this.abilityPrices.Add("Thorn", 300);
        this.abilityPrices.Add("ThornLevel", 150);
        this.abilityPrices.Add("Sniper", 250);
        this.abilityPrices.Add("SniperLevel", 250);
        this.abilityPrices.Add("Shrapnel", 300);
        this.abilityPrices.Add("ShrapnelLevel", 300);
        this.abilityPrices.Add("Teleport", 300);
        this.abilityPrices.Add("TeleportLevel", 100);
        this.abilityPrices.Add("Desintegrate", 350);
        this.abilityPrices.Add("DesintegrateLevel", 200);
        this.abilityPrices.Add("Polymorph", 300);
        this.abilityPrices.Add("PolymorphLevel", 150);
        this.abilityPrices.Add("Elemental", 350);
        this.abilityPrices.Add("ElementalLevel", 150);
        this.abilityPrices.Add("HolyStrike", 220);
        this.abilityPrices.Add("HolyStrikeLevel", 150);
        this.abilityPrices.Add("Healing", 150);
        this.abilityPrices.Add("HealingLevel", 150);
        this.abilityPrices.Add("Shield", 250);
        this.abilityPrices.Add("ShieldLevel", 100);
        this.abilityPrices.Add("Twister", 150);
        this.abilityPrices.Add("TwisterLevel", 100);
        this.abilityPrices.Add("DualWeapons", 300);
        this.abilityPrices.Add("DualWeaponsLevel", 100);
        this.abilityPrices.Add("ThrowingAxe", 200);
        this.abilityPrices.Add("ThrowingAxeLevel", 100);
        this.abilityPrices.Add("Missile", 250);
        this.abilityPrices.Add("MissileLevel", 100);
        this.abilityPrices.Add("Cluster", 250);
        this.abilityPrices.Add("ClusterLevel", 150);
        this.abilityPrices.Add("Overcharge", 250);
        this.abilityPrices.Add("OverchargeLevel", 0x7d);
        this.abilityPrices.Add("Supercharge", 300);
        this.abilityPrices.Add("SuperchargeLevel", 300);
        return;
    }

    private void LoadEnemies()
    {
    }

    private void LoadHeroes()
    {
        float[] singleArray305;
        float[] singleArray304;
        float[] singleArray303;
        float[] singleArray302;
        float[] singleArray301;
        float[] singleArray300;
        float[] singleArray299;
        float[] singleArray298;
        float[] singleArray297;
        float[] singleArray296;
        float[] singleArray295;
        float[] singleArray294;
        float[] singleArray293;
        float[] singleArray292;
        float[] singleArray291;
        float[] singleArray290;
        float[] singleArray289;
        float[] singleArray288;
        float[] singleArray287;
        float[] singleArray286;
        float[] singleArray285;
        float[] singleArray284;
        float[] singleArray283;
        float[] singleArray282;
        float[] singleArray281;
        float[] singleArray280;
        float[] singleArray279;
        float[] singleArray278;
        float[] singleArray277;
        float[] singleArray276;
        float[] singleArray275;
        float[] singleArray274;
        float[] singleArray273;
        float[] singleArray272;
        float[] singleArray271;
        float[] singleArray270;
        float[] singleArray269;
        float[] singleArray268;
        float[] singleArray267;
        float[] singleArray266;
        float[] singleArray265;
        float[] singleArray264;
        float[] singleArray263;
        float[] singleArray262;
        float[] singleArray261;
        float[] singleArray260;
        float[] singleArray259;
        float[] singleArray258;
        float[] singleArray257;
        float[] singleArray256;
        float[] singleArray255;
        float[] singleArray254;
        float[] singleArray253;
        float[] singleArray252;
        float[] singleArray251;
        float[] singleArray250;
        float[] singleArray249;
        float[] singleArray248;
        float[] singleArray247;
        float[] singleArray246;
        float[] singleArray245;
        float[] singleArray244;
        float[] singleArray243;
        float[] singleArray242;
        float[] singleArray241;
        float[] singleArray240;
        float[] singleArray239;
        float[] singleArray238;
        float[] singleArray237;
        float[] singleArray236;
        float[] singleArray235;
        float[] singleArray234;
        float[] singleArray233;
        float[] singleArray232;
        float[] singleArray231;
        float[] singleArray230;
        float[] singleArray229;
        float[] singleArray228;
        float[] singleArray227;
        float[] singleArray226;
        float[] singleArray225;
        float[] singleArray224;
        float[] singleArray223;
        float[] singleArray222;
        float[] singleArray221;
        float[] singleArray220;
        float[] singleArray219;
        float[] singleArray218;
        float[] singleArray217;
        float[] singleArray216;
        float[] singleArray215;
        float[] singleArray214;
        float[] singleArray213;
        float[] singleArray212;
        float[] singleArray211;
        float[] singleArray210;
        float[] singleArray209;
        float[] singleArray208;
        float[] singleArray207;
        float[] singleArray206;
        float[] singleArray205;
        float[] singleArray204;
        float[] singleArray203;
        float[] singleArray202;
        float[] singleArray201;
        float[] singleArray200;
        float[] singleArray199;
        float[] singleArray198;
        float[] singleArray197;
        float[] singleArray196;
        float[] singleArray195;
        float[] singleArray194;
        float[] singleArray193;
        float[] singleArray192;
        float[] singleArray191;
        float[] singleArray190;
        float[] singleArray189;
        float[] singleArray188;
        float[] singleArray187;
        float[] singleArray186;
        float[] singleArray185;
        float[] singleArray184;
        float[] singleArray183;
        float[] singleArray182;
        float[] singleArray181;
        float[] singleArray180;
        float[] singleArray179;
        float[] singleArray178;
        float[] singleArray177;
        float[] singleArray176;
        float[] singleArray175;
        float[] singleArray174;
        float[] singleArray173;
        float[] singleArray172;
        float[] singleArray171;
        float[] singleArray170;
        float[] singleArray169;
        float[] singleArray168;
        float[] singleArray167;
        float[] singleArray166;
        float[] singleArray165;
        float[] singleArray164;
        float[] singleArray163;
        float[] singleArray162;
        float[] singleArray161;
        float[] singleArray160;
        float[] singleArray159;
        float[] singleArray158;
        float[] singleArray157;
        float[] singleArray156;
        float[] singleArray155;
        float[] singleArray154;
        float[] singleArray153;
        float[] singleArray152;
        float[] singleArray151;
        float[] singleArray150;
        float[] singleArray149;
        float[] singleArray148;
        float[] singleArray147;
        float[] singleArray146;
        float[] singleArray145;
        float[] singleArray144;
        float[] singleArray143;
        float[] singleArray142;
        float[] singleArray141;
        float[] singleArray140;
        float[] singleArray139;
        float[] singleArray138;
        float[] singleArray137;
        float[] singleArray136;
        float[] singleArray135;
        float[] singleArray134;
        float[] singleArray133;
        float[] singleArray132;
        float[] singleArray131;
        float[] singleArray130;
        float[] singleArray129;
        float[] singleArray128;
        float[] singleArray127;
        float[] singleArray126;
        float[] singleArray125;
        float[] singleArray124;
        float[] singleArray123;
        float[] singleArray122;
        float[] singleArray121;
        float[] singleArray120;
        float[] singleArray119;
        float[] singleArray118;
        float[] singleArray117;
        float[] singleArray116;
        float[] singleArray115;
        float[] singleArray114;
        float[] singleArray113;
        float[] singleArray112;
        float[] singleArray111;
        float[] singleArray110;
        float[] singleArray109;
        float[] singleArray108;
        float[] singleArray107;
        float[] singleArray106;
        float[] singleArray105;
        float[] singleArray104;
        float[] singleArray103;
        float[] singleArray102;
        float[] singleArray101;
        float[] singleArray100;
        float[] singleArray99;
        float[] singleArray98;
        float[] singleArray97;
        float[] singleArray96;
        float[] singleArray95;
        float[] singleArray94;
        float[] singleArray93;
        float[] singleArray92;
        float[] singleArray91;
        float[] singleArray90;
        float[] singleArray89;
        float[] singleArray88;
        float[] singleArray87;
        float[] singleArray86;
        float[] singleArray85;
        float[] singleArray84;
        float[] singleArray83;
        float[] singleArray82;
        float[] singleArray81;
        float[] singleArray80;
        float[] singleArray79;
        float[] singleArray78;
        float[] singleArray77;
        float[] singleArray76;
        float[] singleArray75;
        float[] singleArray74;
        float[] singleArray73;
        float[] singleArray72;
        float[] singleArray71;
        float[] singleArray70;
        float[] singleArray69;
        float[] singleArray68;
        float[] singleArray67;
        float[] singleArray66;
        float[] singleArray65;
        float[] singleArray64;
        float[] singleArray63;
        float[] singleArray62;
        float[] singleArray61;
        float[] singleArray60;
        float[] singleArray59;
        float[] singleArray58;
        float[] singleArray57;
        float[] singleArray56;
        float[] singleArray55;
        float[] singleArray54;
        float[] singleArray53;
        float[] singleArray52;
        float[] singleArray51;
        float[] singleArray50;
        float[] singleArray49;
        float[] singleArray48;
        float[] singleArray47;
        float[] singleArray46;
        float[] singleArray45;
        float[] singleArray44;
        float[] singleArray43;
        float[] singleArray42;
        float[] singleArray41;
        float[] singleArray40;
        float[] singleArray39;
        float[] singleArray38;
        float[] singleArray37;
        float[] singleArray36;
        float[] singleArray35;
        float[] singleArray34;
        float[] singleArray33;
        float[] singleArray32;
        float[] singleArray31;
        float[] singleArray30;
        float[] singleArray29;
        float[] singleArray28;
        float[] singleArray27;
        float[] singleArray26;
        float[] singleArray25;
        float[] singleArray24;
        float[] singleArray23;
        float[] singleArray22;
        float[] singleArray21;
        float[] singleArray20;
        float[] singleArray19;
        float[] singleArray18;
        float[] singleArray17;
        float[] singleArray16;
        float[] singleArray15;
        float[] singleArray14;
        float[] singleArray13;
        float[] singleArray12;
        float[] singleArray11;
        float[] singleArray10;
        float[] singleArray9;
        float[] singleArray8;
        float[] singleArray7;
        float[] singleArray6;
        float[] singleArray5;
        float[] singleArray4;
        float[] singleArray3;
        float[] singleArray2;
        float[] singleArray1;
        Dictionary<string, float[]> dictionary;
        Dictionary<string, float[]> dictionary2;
        Dictionary<string, float[]> dictionary3;
        Dictionary<string, float[]> dictionary4;
        Dictionary<string, float[]> dictionary5;
        Dictionary<string, float[]> dictionary6;
        Dictionary<string, float[]> dictionary7;
        Dictionary<string, float[]> dictionary8;
        Dictionary<string, float[]> dictionary9;
        Dictionary<string, float[]> dictionary10;
        Dictionary<string, float[]> dictionary11;
        Dictionary<string, float[]> dictionary12;
        Dictionary<string, float[]> dictionary13;
        dictionary = new Dictionary<string, float[]>();
        dictionary.Add("master_xp", new float[] { 0f, 300f, 900f, 2000f, 4000f, 8000f, 12000f, 16000f, 20000f, 26000f });
        this.heroesMasterTable.Add("common_tables", dictionary);
        dictionary2 = new Dictionary<string, float[]>();
        dictionary2.Add("health", new float[] { 400f, 420f, 440f, 460f, 480f, 500f, 520f, 540f, 560f, 580f });
        dictionary2.Add("regen", new float[] { 100f, 105f, 110f, 115f, 120f, 125f, 130f, 135f, 140f, 145f });
        dictionary2.Add("armor", new float[] { 30f, 30f, 40f, 40f, 50f, 50f, 60f, 60f, 70f, 80f });
        dictionary2.Add("minDamage", new float[] { 11f, 12f, 14f, 15f, 17f, 18f, 20f, 21f, 23f, 24f });
        dictionary2.Add("maxDamage", new float[] { 18f, 20f, 23f, 25f, 28f, 30f, 33f, 35f, 38f, 40f });
        singleArray1 = new float[] { 1f };
        dictionary2.Add("reload", singleArray1);
        singleArray2 = new float[] { 183f };
        dictionary2.Add("range", singleArray2);
        singleArray3 = new float[] { 1f };
        dictionary2.Add("regenReload", singleArray3);
        singleArray4 = new float[] { 15f };
        dictionary2.Add("respawn", singleArray4);
        singleArray5 = new float[] { 3f };
        dictionary2.Add("xpMultiplier", singleArray5);
        singleArray6 = new float[] { 2f };
        dictionary2.Add("blockCounterModifier", singleArray6);
        singleArray7 = new float[] { 10f };
        dictionary2.Add("blockCounterMinDamage", singleArray7);
        singleArray8 = new float[] { 20f };
        dictionary2.Add("blockCounterMaxDamage", singleArray8);
        singleArray9 = new float[] { 50f };
        dictionary2.Add("blockCounterDamageReturn", singleArray9);
        singleArray10 = new float[] { 50f };
        dictionary2.Add("blockCounterDamageReturnIncrement", singleArray10);
        dictionary2.Add("blockCounterChance", new float[1]);
        singleArray11 = new float[] { 20f };
        dictionary2.Add("blockCounterChanceIncrement", singleArray11);
        singleArray12 = new float[] { 1f };
        dictionary2.Add("courageModifier", singleArray12);
        singleArray13 = new float[] { 254f };
        dictionary2.Add("courageRangeWidth", singleArray13);
        singleArray14 = new float[] { 6f };
        dictionary2.Add("courageReloadTime", singleArray14);
        singleArray15 = new float[] { 6f };
        dictionary2.Add("courageDurationTime", singleArray15);
        singleArray16 = new float[] { 15f };
        dictionary2.Add("courageHealPercent", singleArray16);
        dictionary2.Add("courageArmor", new float[1]);
        singleArray17 = new float[] { 5f };
        dictionary2.Add("courageArmorIncrement", singleArray17);
        dictionary2.Add("courageDamage", new float[1]);
        singleArray18 = new float[] { 2f };
        dictionary2.Add("courageDamageIncrement", singleArray18);
        singleArray19 = new float[] { 8f };
        dictionary2.Add("stat_health", singleArray19);
        singleArray20 = new float[] { 6f };
        dictionary2.Add("stat_attack", singleArray20);
        dictionary2.Add("stat_range", new float[1]);
        singleArray21 = new float[] { 5f };
        dictionary2.Add("stat_speed", singleArray21);
        this.heroesMasterTable.Add("hero_general", dictionary2);
        dictionary3 = new Dictionary<string, float[]>();
        dictionary3.Add("health", new float[] { 450f, 480f, 510f, 540f, 570f, 600f, 630f, 660f, 690f, 720f });
        dictionary3.Add("regen", new float[] { 113f, 120f, 128f, 135f, 143f, 150f, 158f, 165f, 173f, 180f });
        dictionary3.Add("armor", new float[] { 0f, 10f, 10f, 20f, 20f, 30f, 30f, 40f, 40f, 50f });
        dictionary3.Add("minDamage", new float[] { 14f, 16f, 18f, 19f, 21f, 22f, 24f, 26f, 27f, 29f });
        dictionary3.Add("maxDamage", new float[] { 22f, 24f, 26f, 29f, 31f, 34f, 36f, 38f, 41f, 43f });
        singleArray22 = new float[] { 1f };
        dictionary3.Add("reload", singleArray22);
        singleArray23 = new float[] { 183f };
        dictionary3.Add("range", singleArray23);
        singleArray24 = new float[] { 1f };
        dictionary3.Add("regenReload", singleArray24);
        singleArray25 = new float[] { 15f };
        dictionary3.Add("respawn", singleArray25);
        singleArray26 = new float[] { 1.7f };
        dictionary3.Add("xpMultiplier", singleArray26);
        singleArray27 = new float[] { 1f };
        dictionary3.Add("smashModifier", singleArray27);
        singleArray28 = new float[] { 170f };
        dictionary3.Add("smashRangeWidth", singleArray28);
        singleArray29 = new float[] { 6f };
        dictionary3.Add("smashReloadTime", singleArray29);
        dictionary3.Add("smashMinDamage", new float[1]);
        singleArray30 = new float[] { 20f };
        dictionary3.Add("smashMaxDamage", singleArray30);
        singleArray31 = new float[] { 20f };
        dictionary3.Add("smashDamageIncrement", singleArray31);
        singleArray32 = new float[] { 1f };
        dictionary3.Add("fissureModifier", singleArray32);
        singleArray33 = new float[] { 113f };
        dictionary3.Add("fissureRangeWidth", singleArray33);
        singleArray34 = new float[] { 14f };
        dictionary3.Add("fissureReloadTime", singleArray34);
        singleArray35 = new float[] { 2f };
        dictionary3.Add("fissureStuntDurationTime", singleArray35);
        dictionary3.Add("fissureMinDamage", new float[1]);
        singleArray36 = new float[] { 20f };
        dictionary3.Add("fissureMaxDamage", singleArray36);
        singleArray37 = new float[] { 20f };
        dictionary3.Add("fissureDamageIncrement", singleArray37);
        singleArray38 = new float[] { 8f };
        dictionary3.Add("stat_health", singleArray38);
        singleArray39 = new float[] { 7f };
        dictionary3.Add("stat_attack", singleArray39);
        dictionary3.Add("stat_range", new float[1]);
        singleArray40 = new float[] { 4f };
        dictionary3.Add("stat_speed", singleArray40);
        this.heroesMasterTable.Add("hero_hammer", dictionary3);
        dictionary4 = new Dictionary<string, float[]>();
        dictionary4.Add("health", new float[] { 400f, 430f, 460f, 490f, 520f, 550f, 580f, 610f, 640f, 670f });
        dictionary4.Add("regen", new float[] { 100f, 108f, 115f, 123f, 130f, 138f, 145f, 153f, 160f, 168f });
        dictionary4.Add("armor", new float[10]);
        dictionary4.Add("minDamage", new float[] { 9f, 11f, 12f, 14f, 15f, 17f, 18f, 20f, 21f, 23f });
        dictionary4.Add("maxDamage", new float[] { 15f, 18f, 20f, 23f, 25f, 28f, 30f, 33f, 35f, 38f });
        dictionary4.Add("minRangeDamage", new float[] { 9f, 11f, 12f, 14f, 15f, 17f, 18f, 20f, 21f, 23f });
        dictionary4.Add("maxRangeDamage", new float[] { 15f, 18f, 20f, 23f, 25f, 28f, 30f, 33f, 35f, 38f });
        singleArray41 = new float[] { 1f };
        dictionary4.Add("reload", singleArray41);
        singleArray42 = new float[] { 183f };
        dictionary4.Add("range", singleArray42);
        singleArray43 = new float[] { 1f };
        dictionary4.Add("regenReload", singleArray43);
        singleArray44 = new float[] { 15f };
        dictionary4.Add("respawn", singleArray44);
        singleArray45 = new float[] { 3f };
        dictionary4.Add("xpMultiplier", singleArray45);
        singleArray46 = new float[] { 465f };
        dictionary4.Add("rangeShootRangeWidth", singleArray46);
        singleArray47 = new float[] { 2f };
        dictionary4.Add("rangeShootReloadTime", singleArray47);
        singleArray48 = new float[] { 70f };
        dictionary4.Add("rangeShootMinDistance", singleArray48);
        singleArray49 = new float[] { 2f };
        dictionary4.Add("rangeShootMaxShoots", singleArray49);
        singleArray50 = new float[] { 1f };
        dictionary4.Add("rangeShootMaxShootsIncrement", singleArray50);
        singleArray51 = new float[] { 0.5f };
        dictionary4.Add("mineModifier", singleArray51);
        singleArray52 = new float[] { 170f };
        dictionary4.Add("mineRangeWidth", singleArray52);
        singleArray53 = new float[] { 6f };
        dictionary4.Add("mineReloadTime", singleArray53);
        singleArray54 = new float[] { 10f };
        dictionary4.Add("mineMax", singleArray54);
        singleArray55 = new float[] { 20f };
        dictionary4.Add("mineMaxIncrement", singleArray55);
        singleArray56 = new float[] { 28f };
        dictionary4.Add("mineActiveRangeWidth", singleArray56);
        singleArray57 = new float[] { 50f };
        dictionary4.Add("mineDuration", singleArray57);
        dictionary4.Add("mineMinDamage", new float[1]);
        singleArray58 = new float[] { 20f };
        dictionary4.Add("mineMaxDamage", singleArray58);
        singleArray59 = new float[] { 10f };
        dictionary4.Add("mineDamageIncrement", singleArray59);
        singleArray60 = new float[] { 1f };
        dictionary4.Add("tarModifier", singleArray60);
        singleArray61 = new float[] { 564f };
        dictionary4.Add("tarRangeWidth", singleArray61);
        singleArray62 = new float[] { 14f };
        dictionary4.Add("tarReloadTime", singleArray62);
        singleArray63 = new float[] { 2f };
        dictionary4.Add("tarDurationTime", singleArray63);
        singleArray64 = new float[] { 2f };
        dictionary4.Add("tarDurationTimeIncrement", singleArray64);
        singleArray65 = new float[] { 141f };
        dictionary4.Add("tarMinDistance", singleArray65);
        singleArray66 = new float[] { 127f };
        dictionary4.Add("tarRangeApplyWidth", singleArray66);
        singleArray67 = new float[] { 1f };
        dictionary4.Add("tarDurationBuffTime", singleArray67);
        singleArray68 = new float[] { 6f };
        dictionary4.Add("stat_health", singleArray68);
        singleArray69 = new float[] { 5f };
        dictionary4.Add("stat_attack", singleArray69);
        singleArray70 = new float[] { 5f };
        dictionary4.Add("stat_range", singleArray70);
        singleArray71 = new float[] { 4f };
        dictionary4.Add("stat_speed", singleArray71);
        this.heroesMasterTable.Add("hero_dwarf", dictionary4);
        dictionary5 = new Dictionary<string, float[]>();
        dictionary5.Add("health", new float[] { 250f, 270f, 290f, 310f, 330f, 350f, 370f, 390f, 410f, 430f });
        dictionary5.Add("regen", new float[] { 63f, 68f, 73f, 78f, 83f, 88f, 93f, 98f, 103f, 108f });
        dictionary5.Add("armor", new float[10]);
        dictionary5.Add("minDamage", new float[] { 2f, 4f, 6f, 7f, 9f, 10f, 12f, 14f, 15f, 17f });
        dictionary5.Add("maxDamage", new float[] { 4f, 6f, 8f, 11f, 13f, 16f, 18f, 20f, 23f, 25f });
        dictionary5.Add("minRangeDamage", new float[] { 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 14f, 15f });
        dictionary5.Add("maxRangeDamage", new float[] { 12f, 14f, 15f, 17f, 18f, 20f, 21f, 23f, 24f, 26f });
        singleArray72 = new float[] { 1f };
        dictionary5.Add("reload", singleArray72);
        singleArray73 = new float[] { 127f };
        dictionary5.Add("range", singleArray73);
        singleArray74 = new float[] { 1f };
        dictionary5.Add("regenReload", singleArray74);
        singleArray75 = new float[] { 15f };
        dictionary5.Add("respawn", singleArray75);
        singleArray76 = new float[] { 2.5f };
        dictionary5.Add("xpMultiplier", singleArray76);
        singleArray77 = new float[] { 564f };
        dictionary5.Add("rangeShootRangeWidth", singleArray77);
        singleArray78 = new float[] { 0.6f };
        dictionary5.Add("rangeShootReloadTime", singleArray78);
        singleArray79 = new float[] { 70f };
        dictionary5.Add("rangeShootMinDistance", singleArray79);
        singleArray80 = new float[] { 0.5f };
        dictionary5.Add("multiShootModifier", singleArray80);
        singleArray81 = new float[] { 282f };
        dictionary5.Add("multiShootRangeWidthNear", singleArray81);
        singleArray82 = new float[] { 3f };
        dictionary5.Add("multiShootReloadTime", singleArray82);
        singleArray83 = new float[] { 1f };
        dictionary5.Add("multiShootArrows", singleArray83);
        singleArray84 = new float[] { 1f };
        dictionary5.Add("multiShootArrowsIncrement", singleArray84);
        singleArray85 = new float[] { 1f };
        dictionary5.Add("callOfWildModifier", singleArray85);
        singleArray86 = new float[] { 20f };
        dictionary5.Add("callOfWildReloadTime", singleArray86);
        singleArray87 = new float[] { 338f };
        dictionary5.Add("callOfWildRangeRally", singleArray87);
        singleArray88 = new float[] { 338f };
        dictionary5.Add("callOfWildRange", singleArray88);
        dictionary5.Add("callOfWildHealth", new float[1]);
        singleArray89 = new float[] { 250f };
        dictionary5.Add("callOfWildHealthIncrement", singleArray89);
        dictionary5.Add("callOfWildArmor", new float[1]);
        singleArray90 = new float[] { 2f };
        dictionary5.Add("callOfWildMinDamage", singleArray90);
        singleArray91 = new float[] { 4f };
        dictionary5.Add("callOfWildMaxDamage", singleArray91);
        singleArray92 = new float[] { 4f };
        dictionary5.Add("callOfWildDamageIncrement", singleArray92);
        singleArray93 = new float[] { 1f };
        dictionary5.Add("callOfWildReload", singleArray93);
        singleArray94 = new float[] { 10f };
        dictionary5.Add("callOfWildRespawn", singleArray94);
        singleArray95 = new float[] { 75f };
        dictionary5.Add("callOfWildRegen", singleArray95);
        singleArray96 = new float[] { 1f };
        dictionary5.Add("callOfWildRegenReload", singleArray96);
        singleArray97 = new float[] { 3f };
        dictionary5.Add("stat_health", singleArray97);
        singleArray98 = new float[] { 3f };
        dictionary5.Add("stat_attack", singleArray98);
        singleArray99 = new float[] { 6f };
        dictionary5.Add("stat_range", singleArray99);
        singleArray100 = new float[] { 6f };
        dictionary5.Add("stat_speed", singleArray100);
        this.heroesMasterTable.Add("hero_archer", dictionary5);
        dictionary6 = new Dictionary<string, float[]>();
        dictionary6.Add("health", new float[] { 170f, 190f, 210f, 230f, 250f, 270f, 290f, 310f, 330f, 350f });
        dictionary6.Add("regen", new float[] { 43f, 48f, 53f, 58f, 63f, 68f, 73f, 78f, 83f, 88f });
        dictionary6.Add("armor", new float[10]);
        dictionary6.Add("minDamage", new float[] { 1f, 2f, 2f, 3f, 4f, 5f, 6f, 6f, 7f, 8f });
        dictionary6.Add("maxDamage", new float[] { 2f, 4f, 5f, 6f, 7f, 8f, 10f, 11f, 12f, 13f });
        dictionary6.Add("minRangeDamage", new float[] { 9f, 11f, 12f, 14f, 15f, 17f, 18f, 20f, 21f, 23f });
        dictionary6.Add("maxRangeDamage", new float[] { 27f, 32f, 36f, 41f, 45f, 50f, 54f, 59f, 63f, 68f });
        singleArray101 = new float[] { 1f };
        dictionary6.Add("reload", singleArray101);
        singleArray102 = new float[] { 127f };
        dictionary6.Add("range", singleArray102);
        singleArray103 = new float[] { 1f };
        dictionary6.Add("regenReload", singleArray103);
        singleArray104 = new float[] { 15f };
        dictionary6.Add("respawn", singleArray104);
        singleArray105 = new float[] { 2.1f };
        dictionary6.Add("xpMultiplier", singleArray105);
        singleArray106 = new float[] { 423f };
        dictionary6.Add("rangeShootRangeWidth", singleArray106);
        singleArray107 = new float[] { 1f };
        dictionary6.Add("rangeShootReloadTime", singleArray107);
        singleArray108 = new float[] { 70f };
        dictionary6.Add("rangeShootMinDistance", singleArray108);
        singleArray109 = new float[] { 1f };
        dictionary6.Add("mirageModifier", singleArray109);
        singleArray110 = new float[] { 10f };
        dictionary6.Add("mirageReloadTime", singleArray110);
        dictionary6.Add("mirageIllusions", new float[1]);
        singleArray111 = new float[] { 1f };
        dictionary6.Add("mirageIllusionsIncrement", singleArray111);
        singleArray112 = new float[] { 4f };
        dictionary6.Add("mirageIllusionsHealthPercent", singleArray112);
        singleArray113 = new float[] { 1f };
        dictionary6.Add("mirageIllusionsDamagePercent", singleArray113);
        singleArray114 = new float[] { 10f };
        dictionary6.Add("mirageIllusionsDuration", singleArray114);
        singleArray115 = new float[] { 127f };
        dictionary6.Add("mirageRangeRally", singleArray115);
        singleArray116 = new float[] { 338f };
        dictionary6.Add("mirageRange", singleArray116);
        singleArray117 = new float[] { 50f };
        dictionary6.Add("mirageHealth", singleArray117);
        singleArray118 = new float[] { 20f };
        dictionary6.Add("mirageHealthIncrement", singleArray118);
        dictionary6.Add("mirageArmor", new float[1]);
        singleArray119 = new float[] { 8f };
        dictionary6.Add("mirageMinDamage", singleArray119);
        singleArray120 = new float[] { 12f };
        dictionary6.Add("mirageMaxDamage", singleArray120);
        singleArray121 = new float[] { 3f };
        dictionary6.Add("mirageDamageIncrement", singleArray121);
        singleArray122 = new float[] { 1f };
        dictionary6.Add("mirageReload", singleArray122);
        singleArray123 = new float[] { 10f };
        dictionary6.Add("mirageRespawn", singleArray123);
        dictionary6.Add("mirageRegen", new float[1]);
        singleArray124 = new float[] { 1f };
        dictionary6.Add("mirageRegenReload", singleArray124);
        singleArray125 = new float[] { 10f };
        dictionary6.Add("lifeTime", singleArray125);
        singleArray126 = new float[] { 1f };
        dictionary6.Add("thunderModifier", singleArray126);
        singleArray127 = new float[] { 14f };
        dictionary6.Add("thunderReloadTime", singleArray127);
        singleArray128 = new float[] { 6f };
        dictionary6.Add("thunderProjectilesPerLevel", singleArray128);
        singleArray129 = new float[] { 2f };
        dictionary6.Add("thunderDuration", singleArray129);
        singleArray130 = new float[] { 1f };
        dictionary6.Add("thunderDurationIncrement", singleArray130);
        singleArray131 = new float[] { 20f };
        dictionary6.Add("thunderMinDamage", singleArray131);
        singleArray132 = new float[] { 20f };
        dictionary6.Add("thunderMaxDamage", singleArray132);
        dictionary6.Add("thunderDamageIncrement", new float[1]);
        singleArray133 = new float[] { 113f };
        dictionary6.Add("thunderRangeWidth", singleArray133);
        singleArray134 = new float[] { 564f };
        dictionary6.Add("thunderShootRangeWidth", singleArray134);
        singleArray135 = new float[] { 70f };
        dictionary6.Add("thunderMinDistance", singleArray135);
        singleArray136 = new float[] { 2f };
        dictionary6.Add("stat_health", singleArray136);
        singleArray137 = new float[] { 2f };
        dictionary6.Add("stat_attack", singleArray137);
        singleArray138 = new float[] { 8f };
        dictionary6.Add("stat_range", singleArray138);
        singleArray139 = new float[] { 8f };
        dictionary6.Add("stat_speed", singleArray139);
        this.heroesMasterTable.Add("hero_mage", dictionary6);
        dictionary7 = new Dictionary<string, float[]>();
        dictionary7.Add("health", new float[] { 400f, 430f, 460f, 490f, 520f, 550f, 580f, 610f, 640f, 670f });
        dictionary7.Add("regen", new float[] { 100f, 108f, 115f, 123f, 130f, 138f, 145f, 153f, 160f, 168f });
        dictionary7.Add("armor", new float[10]);
        dictionary7.Add("minDamage", new float[] { 18f, 20f, 21f, 23f, 24f, 26f, 27f, 29f, 30f, 32f });
        dictionary7.Add("maxDamage", new float[] { 30f, 33f, 35f, 38f, 40f, 43f, 45f, 48f, 50f, 53f });
        singleArray140 = new float[] { 1f };
        dictionary7.Add("reload", singleArray140);
        singleArray141 = new float[] { 170f };
        dictionary7.Add("range", singleArray141);
        singleArray142 = new float[] { 1f };
        dictionary7.Add("regenReload", singleArray142);
        singleArray143 = new float[] { 12f };
        dictionary7.Add("respawn", singleArray143);
        singleArray144 = new float[] { 2f };
        dictionary7.Add("xpMultiplier", singleArray144);
        singleArray145 = new float[] { 1f };
        dictionary7.Add("surgeOfFlameModifier", singleArray145);
        singleArray146 = new float[] { 4f };
        dictionary7.Add("surgeOfFlameReloadTime", singleArray146);
        singleArray147 = new float[] { 70f };
        dictionary7.Add("surgeOfFlameRangeWidth", singleArray147);
        singleArray148 = new float[] { 18f };
        dictionary7.Add("surgeOfFlameSpeed", singleArray148);
        dictionary7.Add("surgeOfFlameMinDamage", new float[1]);
        singleArray149 = new float[] { 10f };
        dictionary7.Add("surgeOfFlameMaxDamage", singleArray149);
        singleArray150 = new float[] { 10f };
        dictionary7.Add("surgeOfFlameDamageIncrement", singleArray150);
        singleArray151 = new float[] { 367f };
        dictionary7.Add("surgeOfFlameBlockRangeWidth", singleArray151);
        singleArray152 = new float[] { 56f };
        dictionary7.Add("surgeOfFlameBlockMinDistance", singleArray152);
        singleArray153 = new float[] { 2f };
        dictionary7.Add("flamingFrenzyModifier", singleArray153);
        singleArray154 = new float[] { 254f };
        dictionary7.Add("flamingFrenzyRangeWidth", singleArray154);
        dictionary7.Add("flamingFrenzyMinDamage", new float[1]);
        singleArray155 = new float[] { 10f };
        dictionary7.Add("flamingFrenzyMaxDamage", singleArray155);
        singleArray156 = new float[] { 20f };
        dictionary7.Add("flamingFrenzyDamageIncrement", singleArray156);
        singleArray157 = new float[] { 6f };
        dictionary7.Add("stat_health", singleArray157);
        singleArray158 = new float[] { 8f };
        dictionary7.Add("stat_attack", singleArray158);
        dictionary7.Add("stat_range", new float[1]);
        singleArray159 = new float[] { 6f };
        dictionary7.Add("stat_speed", singleArray159);
        this.heroesMasterTable.Add("hero_fire", dictionary7);
        dictionary8 = new Dictionary<string, float[]>();
        dictionary8.Add("health", new float[] { 300f, 320f, 340f, 360f, 380f, 400f, 420f, 440f, 460f, 480f });
        dictionary8.Add("regen", new float[] { 75f, 80f, 85f, 90f, 95f, 100f, 105f, 110f, 115f, 120f });
        dictionary8.Add("armor", new float[10]);
        dictionary8.Add("minDamage", new float[] { 11f, 14f, 17f, 20f, 23f, 25f, 28f, 31f, 34f, 37f });
        dictionary8.Add("maxDamage", new float[] { 19f, 23f, 28f, 33f, 38f, 42f, 47f, 52f, 56f, 61f });
        dictionary8.Add("minRangeDamage", new float[] { 11f, 14f, 17f, 20f, 23f, 25f, 28f, 31f, 34f, 37f });
        dictionary8.Add("maxRangeDamage", new float[] { 19f, 23f, 28f, 33f, 38f, 42f, 47f, 52f, 56f, 61f });
        singleArray160 = new float[] { 1.5f };
        dictionary8.Add("reload", singleArray160);
        singleArray161 = new float[] { 127f };
        dictionary8.Add("range", singleArray161);
        singleArray162 = new float[] { 1f };
        dictionary8.Add("regenReload", singleArray162);
        singleArray163 = new float[] { 15f };
        dictionary8.Add("respawn", singleArray163);
        singleArray164 = new float[] { 2.2f };
        dictionary8.Add("xpMultiplier", singleArray164);
        singleArray165 = new float[] { 395f };
        dictionary8.Add("rangeShootRangeWidth", singleArray165);
        singleArray166 = new float[] { 1.5f };
        dictionary8.Add("rangeShootReloadTime", singleArray166);
        singleArray167 = new float[] { 70f };
        dictionary8.Add("rangeShootMinDistance", singleArray167);
        singleArray168 = new float[] { 1f };
        dictionary8.Add("buffModifier", singleArray168);
        singleArray169 = new float[] { 15f };
        dictionary8.Add("buffReloadTime", singleArray169);
        singleArray170 = new float[] { 437f };
        dictionary8.Add("buffRangeWidth", singleArray170);
        singleArray171 = new float[] { 20f };
        dictionary8.Add("buffLessReloadPercent", singleArray171);
        singleArray172 = new float[] { 20f };
        dictionary8.Add("buffMoreRangePercent", singleArray172);
        singleArray173 = new float[] { 2f };
        dictionary8.Add("buffDurationTime", singleArray173);
        singleArray174 = new float[] { 3f };
        dictionary8.Add("buffDurationTimeIncrement", singleArray174);
        singleArray175 = new float[] { 2f };
        dictionary8.Add("catapultModifier", singleArray175);
        singleArray176 = new float[] { 10f };
        dictionary8.Add("catapultReloadTime", singleArray176);
        singleArray177 = new float[] { 465f };
        dictionary8.Add("catapultRangeWidth", singleArray177);
        singleArray178 = new float[] { 70f };
        dictionary8.Add("catapultMinRangeWidth", singleArray178);
        dictionary8.Add("catapultMinDamage", new float[1]);
        singleArray179 = new float[] { 20f };
        dictionary8.Add("catapultMaxDamage", singleArray179);
        singleArray180 = new float[] { 10f };
        dictionary8.Add("catapultDamageIncrement", singleArray180);
        singleArray181 = new float[] { 1f };
        dictionary8.Add("catapultRocks", singleArray181);
        singleArray182 = new float[] { 2f };
        dictionary8.Add("catapultRocksIncrement", singleArray182);
        singleArray183 = new float[] { 127f };
        dictionary8.Add("catapultRangeRock", singleArray183);
        singleArray184 = new float[] { 5f };
        dictionary8.Add("stat_health", singleArray184);
        singleArray185 = new float[] { 6f };
        dictionary8.Add("stat_attack", singleArray185);
        singleArray186 = new float[] { 6f };
        dictionary8.Add("stat_range", singleArray186);
        singleArray187 = new float[] { 3f };
        dictionary8.Add("stat_speed", singleArray187);
        this.heroesMasterTable.Add("hero_denas", dictionary8);
        dictionary9 = new Dictionary<string, float[]>();
        dictionary9.Add("health", new float[] { 430f, 460f, 490f, 520f, 550f, 580f, 610f, 640f, 670f, 670f });
        dictionary9.Add("regen", new float[] { 108f, 115f, 123f, 130f, 138f, 145f, 153f, 160f, 168f, 175f });
        dictionary9.Add("armor", new float[] { 10f, 10f, 15f, 15f, 20f, 20f, 25f, 25f, 30f, 40f });
        dictionary9.Add("minDamage", new float[] { 23f, 25f, 27f, 29f, 32f, 34f, 36f, 38f, 41f, 43f });
        dictionary9.Add("maxDamage", new float[] { 38f, 41f, 45f, 49f, 53f, 56f, 60f, 64f, 68f, 71f });
        singleArray188 = new float[] { 1.5f };
        dictionary9.Add("reload", singleArray188);
        singleArray189 = new float[] { 235f };
        dictionary9.Add("range", singleArray189);
        singleArray190 = new float[] { 1f };
        dictionary9.Add("regenReload", singleArray190);
        singleArray191 = new float[] { 15f };
        dictionary9.Add("respawn", singleArray191);
        singleArray192 = new float[] { 2f };
        dictionary9.Add("xpMultiplier", singleArray192);
        singleArray193 = new float[] { 2f };
        dictionary9.Add("bearModifier", singleArray193);
        singleArray194 = new float[] { 10f };
        dictionary9.Add("bearReloadTime", singleArray194);
        singleArray195 = new float[] { 60f };
        dictionary9.Add("bearMinLifeActivate", singleArray195);
        singleArray196 = new float[] { 10f };
        dictionary9.Add("bearMinDamage", singleArray196);
        singleArray197 = new float[] { 30f };
        dictionary9.Add("bearMaxDamage", singleArray197);
        singleArray198 = new float[] { 10f };
        dictionary9.Add("bearDamageIncrement", singleArray198);
        singleArray199 = new float[] { 8f };
        dictionary9.Add("bearDuration", singleArray199);
        singleArray200 = new float[] { 2f };
        dictionary9.Add("bearDurationIncrement", singleArray200);
        singleArray201 = new float[] { 3f };
        dictionary9.Add("bearRegenerateTime", singleArray201);
        singleArray202 = new float[] { 2f };
        dictionary9.Add("bearRegenerateLife", singleArray202);
        singleArray203 = new float[] { 2f };
        dictionary9.Add("ancestorsModifier", singleArray203);
        singleArray204 = new float[] { 14f };
        dictionary9.Add("ancestorsReloadTime", singleArray204);
        dictionary9.Add("ancestorsMax", new float[1]);
        singleArray205 = new float[] { 1f };
        dictionary9.Add("ancestorsMaxIncrement", singleArray205);
        singleArray206 = new float[] { 10f };
        dictionary9.Add("ancestorsLifeTime", singleArray206);
        singleArray207 = new float[] { 360f };
        dictionary9.Add("ancestorsRangeRally", singleArray207);
        singleArray208 = new float[] { 360f };
        dictionary9.Add("ancestorsRange", singleArray208);
        singleArray209 = new float[] { 50f };
        dictionary9.Add("ancestorsHealth", singleArray209);
        singleArray210 = new float[] { 50f };
        dictionary9.Add("ancestorsHealthIncrement", singleArray210);
        singleArray211 = new float[] { 25f };
        dictionary9.Add("ancestorsArmor", singleArray211);
        dictionary9.Add("ancestorsMinDamage", new float[1]);
        singleArray212 = new float[] { 4f };
        dictionary9.Add("ancestorsMaxDamage", singleArray212);
        singleArray213 = new float[] { 2f };
        dictionary9.Add("ancestorsDamageIncrement", singleArray213);
        singleArray214 = new float[] { 1f };
        dictionary9.Add("ancestorsReload", singleArray214);
        singleArray215 = new float[] { 10f };
        dictionary9.Add("ancestorsRespawn", singleArray215);
        dictionary9.Add("ancestorsRegen", new float[1]);
        dictionary9.Add("ancestorsRegenReload", new float[1]);
        singleArray216 = new float[] { 8f };
        dictionary9.Add("stat_health", singleArray216);
        singleArray217 = new float[] { 8f };
        dictionary9.Add("stat_attack", singleArray217);
        dictionary9.Add("stat_range", new float[1]);
        singleArray218 = new float[] { 5f };
        dictionary9.Add("stat_speed", singleArray218);
        this.heroesMasterTable.Add("hero_viking", dictionary9);
        dictionary10 = new Dictionary<string, float[]>();
        dictionary10.Add("health", new float[] { 270f, 290f, 310f, 330f, 350f, 370f, 390f, 410f, 430f, 450f });
        dictionary10.Add("regen", new float[] { 68f, 73f, 78f, 83f, 88f, 93f, 98f, 103f, 108f, 113f });
        dictionary10.Add("armor", new float[] { 20f, 20f, 20f, 30f, 30f, 30f, 40f, 40f, 40f, 50f });
        dictionary10.Add("minDamage", new float[] { 1f, 2f, 4f, 6f, 7f, 9f, 10f, 12f, 14f, 15f });
        dictionary10.Add("maxDamage", new float[] { 2f, 4f, 6f, 8f, 11f, 13f, 16f, 18f, 20f, 23f });
        dictionary10.Add("minRangeDamage", new float[] { 14f, 16f, 18f, 20f, 23f, 25f, 27f, 29f, 32f, 34f });
        dictionary10.Add("maxRangeDamage", new float[] { 41f, 47f, 54f, 61f, 68f, 74f, 81f, 88f, 95f, 101f });
        singleArray219 = new float[] { 1.5f };
        dictionary10.Add("reload", singleArray219);
        singleArray220 = new float[] { 127f };
        dictionary10.Add("range", singleArray220);
        singleArray221 = new float[] { 1f };
        dictionary10.Add("regenReload", singleArray221);
        singleArray222 = new float[] { 15f };
        dictionary10.Add("respawn", singleArray222);
        singleArray223 = new float[] { 2f };
        dictionary10.Add("xpMultiplier", singleArray223);
        singleArray224 = new float[] { 65f };
        dictionary10.Add("rangedShotMinRange", singleArray224);
        singleArray225 = new float[] { 469f };
        dictionary10.Add("rangedShotMaxRange", singleArray225);
        singleArray226 = new float[] { 2.5f };
        dictionary10.Add("abilityOneModifier", singleArray226);
        singleArray227 = new float[] { 8f };
        dictionary10.Add("chillCooldown", singleArray227);
        singleArray228 = new float[] { 3f, 3f, 3f };
        dictionary10.Add("chillSlowDuration", singleArray228);
        singleArray229 = new float[] { 0.6f, 0.7f, 0.8f };
        dictionary10.Add("chillSlowFactor", singleArray229);
        singleArray230 = new float[] { 54f, 54f, 54f };
        dictionary10.Add("chillCastMinRange", singleArray230);
        singleArray231 = new float[] { 433f, 469f, 505f };
        dictionary10.Add("chillCastMaxRange", singleArray231);
        singleArray232 = new float[] { 126f };
        dictionary10.Add("chillGroundFreezeSlowRange", singleArray232);
        singleArray233 = new float[] { 6f, 8f, 10f };
        dictionary10.Add("chillGroundFreezeProjectiles", singleArray233);
        singleArray234 = new float[] { 2f };
        dictionary10.Add("abilityTwoModifier", singleArray234);
        singleArray235 = new float[] { 10f };
        dictionary10.Add("iceStormCooldown", singleArray235);
        singleArray236 = new float[] { 3f, 5f, 8f };
        dictionary10.Add("iceStormProjectiles", singleArray236);
        singleArray237 = new float[] { 20f, 20f, 30f };
        dictionary10.Add("iceStormMinDamage", singleArray237);
        singleArray238 = new float[] { 40f, 50f, 60f };
        dictionary10.Add("iceStormMaxDamage", singleArray238);
        singleArray239 = new float[] { 108f, 108f, 108f };
        dictionary10.Add("iceStormCastMinRange", singleArray239);
        singleArray240 = new float[] { 433f, 469f, 505f };
        dictionary10.Add("iceStormCastMaxRange", singleArray240);
        singleArray241 = new float[] { 144f };
        dictionary10.Add("iceStormSpikeRange", singleArray241);
        singleArray242 = new float[] { 1.41f };
        dictionary10.Add("aceleration", singleArray242);
        singleArray243 = new float[] { 14.1f };
        dictionary10.Add("maxAceleration", singleArray243);
        singleArray244 = new float[] { 0.5f };
        dictionary10.Add("slowFactor", singleArray244);
        singleArray245 = new float[] { 2f };
        dictionary10.Add("slowDuration", singleArray245);
        singleArray246 = new float[] { 20f };
        dictionary10.Add("freezeChance", singleArray246);
        singleArray247 = new float[] { 2f };
        dictionary10.Add("freezeDuration", singleArray247);
        singleArray248 = new float[] { 3f };
        dictionary10.Add("stat_health", singleArray248);
        singleArray249 = new float[] { 2f };
        dictionary10.Add("stat_attack", singleArray249);
        singleArray250 = new float[] { 8f };
        dictionary10.Add("stat_range", singleArray250);
        singleArray251 = new float[] { 7f };
        dictionary10.Add("stat_speed", singleArray251);
        this.heroesMasterTable.Add("hero_frost_sorcerer", dictionary10);
        dictionary11 = new Dictionary<string, float[]>();
        dictionary11.Add("health", new float[] { 380f, 410f, 440f, 470f, 500f, 530f, 560f, 590f, 620f, 650f });
        dictionary11.Add("regen", new float[] { 95f, 103f, 110f, 118f, 125f, 133f, 140f, 148f, 155f, 163f });
        dictionary11.Add("armor", new float[] { 40f, 40f, 40f, 50f, 50f, 50f, 60f, 60f, 60f, 70f });
        dictionary11.Add("minDamage", new float[] { 25f, 27f, 29f, 32f, 34f, 36f, 38f, 40f, 42f, 44f });
        dictionary11.Add("maxDamage", new float[] { 31f, 34f, 36f, 39f, 42f, 44f, 47f, 49f, 52f, 55f });
        singleArray252 = new float[] { 1.5f };
        dictionary11.Add("reload", singleArray252);
        singleArray253 = new float[] { 183f };
        dictionary11.Add("range", singleArray253);
        singleArray254 = new float[] { 1f };
        dictionary11.Add("regenReload", singleArray254);
        singleArray255 = new float[] { 15f };
        dictionary11.Add("respawn", singleArray255);
        singleArray256 = new float[] { 2.1f };
        dictionary11.Add("xpMultiplier", singleArray256);
        singleArray257 = new float[] { 1f };
        dictionary11.Add("chainAbilityOneModifier", singleArray257);
        singleArray258 = new float[] { 25f, 25f, 25f };
        dictionary11.Add("chainChance", singleArray258);
        singleArray259 = new float[] { 40f, 60f, 80f };
        dictionary11.Add("chainMainDamage", singleArray259);
        singleArray260 = new float[] { 40f, 40f, 40f };
        dictionary11.Add("chainChainMainDamage", singleArray260);
        singleArray261 = new float[] { 2f, 3f, 4f };
        dictionary11.Add("chainMaxJumps", singleArray261);
        singleArray262 = new float[] { 310f };
        dictionary11.Add("chainArea", singleArray262);
        singleArray263 = new float[] { 112f };
        dictionary11.Add("chainMinArea", singleArray263);
        singleArray264 = new float[] { 1f };
        dictionary11.Add("thunderclapAbilityTwoModifier", singleArray264);
        singleArray265 = new float[] { 14f };
        dictionary11.Add("thunderclapReload", singleArray265);
        singleArray266 = new float[] { 705f };
        dictionary11.Add("thunderclapRange", singleArray266);
        singleArray267 = new float[] { 113f };
        dictionary11.Add("thunderclapMinDistance", singleArray267);
        singleArray268 = new float[] { 60f, 80f, 120f };
        dictionary11.Add("thunderclapMainDamage", singleArray268);
        singleArray269 = new float[] { 50f, 70f, 90f };
        dictionary11.Add("thunderclapSecondaryDamage", singleArray269);
        singleArray270 = new float[] { 197f, 211f, 225f };
        dictionary11.Add("thunderclapArea", singleArray270);
        singleArray271 = new float[] { 2f, 2f, 2f };
        dictionary11.Add("thunderclapMinStunDuration", singleArray271);
        singleArray272 = new float[] { 3f, 4f, 6f };
        dictionary11.Add("thunderclapMaxStunDuration", singleArray272);
        singleArray273 = new float[] { 7f };
        dictionary11.Add("stat_health", singleArray273);
        singleArray274 = new float[] { 8f };
        dictionary11.Add("stat_attack", singleArray274);
        dictionary11.Add("stat_range", new float[1]);
        singleArray275 = new float[] { 5f };
        dictionary11.Add("stat_speed", singleArray275);
        this.heroesMasterTable.Add("hero_thor", dictionary11);
        dictionary12 = new Dictionary<string, float[]>();
        dictionary12.Add("health", new float[] { 425f, 450f, 475f, 500f, 525f, 550f, 575f, 600f, 625f, 650f });
        dictionary12.Add("regen", new float[] { 106f, 113f, 119f, 125f, 131f, 138f, 144f, 150f, 156f, 163f });
        dictionary12.Add("armor", new float[] { 30f, 30f, 30f, 40f, 40f, 40f, 50f, 50f, 60f, 60f });
        dictionary12.Add("minDamage", new float[] { 14f, 15f, 16f, 18f, 19f, 20f, 21f, 23f, 24f, 25f });
        dictionary12.Add("maxDamage", new float[] { 41f, 45f, 49f, 49f, 53f, 56f, 60f, 64f, 68f, 71f });
        singleArray276 = new float[] { 183f };
        dictionary12.Add("range", singleArray276);
        singleArray277 = new float[] { 1f };
        dictionary12.Add("regenReload", singleArray277);
        singleArray278 = new float[] { 18f };
        dictionary12.Add("respawn", singleArray278);
        singleArray279 = new float[] { 1.25f };
        dictionary12.Add("reload", singleArray279);
        singleArray280 = new float[] { 2.5f };
        dictionary12.Add("xpMultiplier", singleArray280);
        singleArray281 = new float[] { 1f };
        dictionary12.Add("tormentModifier", singleArray281);
        singleArray282 = new float[] { 14f, 14f, 14f };
        dictionary12.Add("tormentReloadTime", singleArray282);
        singleArray283 = new float[] { 2f };
        dictionary12.Add("tormentMinEnemiesToCast", singleArray283);
        singleArray284 = new float[] { 282f };
        dictionary12.Add("tormentRangeWidth", singleArray284);
        singleArray285 = new float[] { 50f, 80f, 110f };
        dictionary12.Add("tormentMinDamage", singleArray285);
        singleArray286 = new float[] { 80f, 110f, 140f };
        dictionary12.Add("tormentMaxDamage", singleArray286);
        singleArray287 = new float[] { 1f };
        dictionary12.Add("deathStrikeModifier", singleArray287);
        singleArray288 = new float[] { 10f, 10f, 10f };
        dictionary12.Add("deathStrikeReloadTime", singleArray288);
        singleArray289 = new float[] { 180f, 260f, 340f };
        dictionary12.Add("deathStrikeDamage", singleArray289);
        singleArray290 = new float[] { 10f, 15f, 20f };
        dictionary12.Add("deathStrikeChance", singleArray290);
        this.heroesMasterTable.Add("hero_samurai", dictionary12);
        dictionary13 = new Dictionary<string, float[]>();
        dictionary13.Add("health", new float[] { 420f, 440f, 460f, 480f, 500f, 520f, 540f, 560f, 580f, 600f });
        dictionary13.Add("regen", new float[] { 105f, 110f, 115f, 120f, 125f, 130f, 135f, 140f, 145f, 150f });
        dictionary13.Add("armor", new float[] { 50f, 50f, 50f, 60f, 60f, 60f, 70f, 70f, 70f, 80f });
        dictionary13.Add("minDamage", new float[] { 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 17f, 18f });
        dictionary13.Add("maxDamage", new float[] { 27f, 30f, 33f, 36f, 39f, 42f, 45f, 48f, 51f, 54f });
        singleArray291 = new float[] { 183f };
        dictionary13.Add("range", singleArray291);
        singleArray292 = new float[] { 1f };
        dictionary13.Add("regenReload", singleArray292);
        singleArray293 = new float[] { 15f };
        dictionary13.Add("respawn", singleArray293);
        singleArray294 = new float[] { 1.2f };
        dictionary13.Add("reload", singleArray294);
        singleArray295 = new float[] { 2.5f };
        dictionary13.Add("xpMultiplier", singleArray295);
        singleArray296 = new float[] { 1f };
        dictionary13.Add("timberModifier", singleArray296);
        singleArray297 = new float[] { 35f, 30f, 25f };
        dictionary13.Add("timberReloadTime", singleArray297);
        singleArray298 = new float[] { 1f };
        dictionary13.Add("sawbladeModifier", singleArray298);
        singleArray299 = new float[] { 8f, 8f, 8f };
        dictionary13.Add("sawbladeReloadTime", singleArray299);
        singleArray300 = new float[] { 45f, 45f, 45f };
        dictionary13.Add("sawbladeDamage", singleArray300);
        singleArray301 = new float[] { 2f, 4f, 6f };
        dictionary13.Add("sawbladeJumps", singleArray301);
        singleArray302 = new float[] { 423f };
        dictionary13.Add("sawbladeRange", singleArray302);
        singleArray303 = new float[] { 18f };
        dictionary13.Add("sawbladeMaxAcceleration", singleArray303);
        singleArray304 = new float[] { 70f };
        dictionary13.Add("sawbladeMinDistance", singleArray304);
        singleArray305 = new float[] { 423f, 423f, 423f };
        dictionary13.Add("sawbladeBounceRange", singleArray305);
        this.heroesMasterTable.Add("hero_robot", dictionary13);
        return;
    }

    public static void LoadLevelSettings(int maxUpgradeLevel)
    {
        float num;
        Dictionary<string, float> dictionary;
        Dictionary<string, float> dictionary2;
        Dictionary<string, float> dictionary3;
        Dictionary<string, float> dictionary4;
        Dictionary<string, float> dictionary5;
        Dictionary<string, float> dictionary6;
        Dictionary<string, float> dictionary7;
        Dictionary<string, float> dictionary8;
        Dictionary<string, float> dictionary9;
        Dictionary<string, float> dictionary10;
        float num2;
        Dictionary<string, float> dictionary11;
        Dictionary<string, float> dictionary12;
        Dictionary<string, float> dictionary13;
        Dictionary<string, float> dictionary14;
        Dictionary<string, float> dictionary15;
        float num3;
        Dictionary<string, float> dictionary16;
        Dictionary<string, float> dictionary17;
        Dictionary<string, float> dictionary18;
        Dictionary<string, float> dictionary19;
        Dictionary<string, float> dictionary20;
        float num4;
        float num5;
        Dictionary<string, float> dictionary21;
        Dictionary<string, float> dictionary22;
        Dictionary<string, float> dictionary23;
        Dictionary<string, float> dictionary24;
        Dictionary<string, float> dictionary25;
        float num6;
        Dictionary<string, float> dictionary26;
        Dictionary<string, float> dictionary27;
        Dictionary<string, float> dictionary28;
        Dictionary<string, float> dictionary29;
        Dictionary<string, float> dictionary30;
        float num7;
        Dictionary<string, float> dictionary31;
        Dictionary<string, float> dictionary32;
        Dictionary<string, float> dictionary33;
        Dictionary<string, float> dictionary34;
        Dictionary<string, float> dictionary35;
        float num8;
        Dictionary<string, float> dictionary36;
        Dictionary<string, float> dictionary37;
        Dictionary<string, float> dictionary38;
        Dictionary<string, float> dictionary39;
        Dictionary<string, float> dictionary40;
        float num9;
        Dictionary<string, float> dictionary41;
        Dictionary<string, float> dictionary42;
        Dictionary<string, float> dictionary43;
        Dictionary<string, float> dictionary44;
        Dictionary<string, float> dictionary45;
        float num10;
        Dictionary<string, float> dictionary46;
        Dictionary<string, float> dictionary47;
        Dictionary<string, float> dictionary48;
        Dictionary<string, float> dictionary49;
        Dictionary<string, float> dictionary50;
        float num11;
        Dictionary<string, float> dictionary51;
        Dictionary<string, float> dictionary52;
        Dictionary<string, float> dictionary53;
        Dictionary<string, float> dictionary54;
        Dictionary<string, float> dictionary55;
        float num12;
        Dictionary<string, float> dictionary56;
        Dictionary<string, float> dictionary57;
        Dictionary<string, int> dictionary58;
        Dictionary<string, int> dictionary59;
        Dictionary<string, int> dictionary60;
        Dictionary<string, int> dictionary61;
        Instance.towersSettings = Instance.CloneRealSettings();
        Instance.powerSettings = Instance.ClonePowerRealSettings();
        if (GameUpgrades.ArchersUpEagleEye == null)
        {
            goto Label_0188;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_003F;
        }
        if (maxUpgradeLevel < 2)
        {
            goto Label_0188;
        }
    Label_003F:
        num = 0.1f;
        dictionary = Instance.towersSettings["archer_level1"];
        dictionary["range"] += (float) Mathf.CeilToInt(dictionary["range"] * num);
        dictionary2 = Instance.towersSettings["archer_level2"];
        dictionary2["range"] += (float) Mathf.CeilToInt(dictionary2["range"] * num);
        dictionary3 = Instance.towersSettings["archer_level3"];
        dictionary3["range"] += (float) Mathf.CeilToInt(dictionary3["range"] * num);
        dictionary4 = Instance.towersSettings["archer_ranger"];
        dictionary4["range"] += (float) Mathf.CeilToInt(dictionary4["range"] * num);
        dictionary5 = Instance.towersSettings["archer_musketeer"];
        dictionary5["range"] += (float) Mathf.CeilToInt(dictionary5["range"] * num);
    Label_0188:
        if (GameUpgrades.ArchersUpFarShots == null)
        {
            goto Label_02F4;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_019F;
        }
        if (maxUpgradeLevel < 4)
        {
            goto Label_02F4;
        }
    Label_019F:
        num = 0.1f;
        dictionary6 = Instance.towersSettings["archer_level1"];
        dictionary6["range"] += (float) Mathf.CeilToInt(dictionary6["range"] * num);
        dictionary7 = Instance.towersSettings["archer_level2"];
        dictionary7["range"] += (float) Mathf.CeilToInt(dictionary7["range"] * num);
        dictionary8 = Instance.towersSettings["archer_level3"];
        dictionary8["range"] += (float) Mathf.CeilToInt(dictionary8["range"] * num);
        dictionary9 = Instance.towersSettings["archer_ranger"];
        dictionary9["range"] += (float) Mathf.CeilToInt(dictionary9["range"] * num);
        dictionary10 = Instance.towersSettings["archer_musketeer"];
        dictionary10["range"] += (float) Mathf.CeilToInt(dictionary10["range"] * num);
    Label_02F4:
        if (GameUpgrades.BarracksUpSurvival == null)
        {
            goto Label_0477;
        }
        num2 = 0.1f;
        if (GameUpgrades.BarracksUpSurvival2 == null)
        {
            goto Label_0323;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_031C;
        }
        if (maxUpgradeLevel < 4)
        {
            goto Label_0323;
        }
    Label_031C:
        num2 = 0.2f;
    Label_0323:
        dictionary11 = Instance.towersSettings["barrack_level1"];
        dictionary11["health"] += (float) Mathf.CeilToInt(dictionary11["health"] * num2);
        dictionary12 = Instance.towersSettings["barrack_level2"];
        dictionary12["health"] += (float) Mathf.CeilToInt(dictionary12["health"] * num2);
        dictionary13 = Instance.towersSettings["barrack_level3"];
        dictionary13["health"] += (float) Mathf.CeilToInt(dictionary13["health"] * num2);
        dictionary14 = Instance.towersSettings["barrack_paladin"];
        dictionary14["health"] += (float) Mathf.CeilToInt(dictionary14["health"] * num2);
        dictionary15 = Instance.towersSettings["barrack_barbarian"];
        dictionary15["health"] += (float) Mathf.CeilToInt(dictionary15["health"] * num2);
    Label_0477:
        if (GameUpgrades.BarracksUpBetterArmor == null)
        {
            goto Label_058A;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_048E;
        }
        if (maxUpgradeLevel < 2)
        {
            goto Label_058A;
        }
    Label_048E:
        num3 = 10f;
        dictionary16 = Instance.towersSettings["barrack_level1"];
        dictionary16["armor"] += num3;
        dictionary17 = Instance.towersSettings["barrack_level2"];
        dictionary17["armor"] += num3;
        dictionary18 = Instance.towersSettings["barrack_level3"];
        dictionary18["armor"] += num3;
        dictionary19 = Instance.towersSettings["barrack_paladin"];
        dictionary19["armor"] += num3;
        dictionary20 = Instance.towersSettings["barrack_barbarian"];
        dictionary20["armor"] += num3;
    Label_058A:
        if (GameUpgrades.BarracksUpImprovedDeployment == null)
        {
            goto Label_07E9;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_05A1;
        }
        if (maxUpgradeLevel < 3)
        {
            goto Label_07E9;
        }
    Label_05A1:
        num4 = 0.2f;
        num5 = 0.2f;
        dictionary21 = Instance.towersSettings["barrack_level1"];
        dictionary21["respawn"] -= (float) Mathf.CeilToInt(dictionary21["respawn"] * num4);
        dictionary21["rangeRally"] += (float) Mathf.CeilToInt(dictionary21["rangeRally"] * num5);
        dictionary22 = Instance.towersSettings["barrack_level2"];
        dictionary22["respawn"] -= (float) Mathf.CeilToInt(dictionary22["respawn"] * num4);
        dictionary22["rangeRally"] += (float) Mathf.CeilToInt(dictionary22["rangeRally"] * num5);
        dictionary23 = Instance.towersSettings["barrack_level3"];
        dictionary23["respawn"] -= (float) Mathf.CeilToInt(dictionary23["respawn"] * num4);
        dictionary23["rangeRally"] += (float) Mathf.CeilToInt(dictionary23["rangeRally"] * num5);
        dictionary24 = Instance.towersSettings["barrack_paladin"];
        dictionary24["respawn"] -= (float) Mathf.CeilToInt(dictionary24["respawn"] * num4);
        dictionary24["rangeRally"] += (float) Mathf.CeilToInt(dictionary24["rangeRally"] * num5);
        dictionary25 = Instance.towersSettings["barrack_barbarian"];
        dictionary25["respawn"] -= (float) Mathf.CeilToInt(dictionary25["respawn"] * num4);
        dictionary25["rangeRally"] += (float) Mathf.CeilToInt(dictionary25["rangeRally"] * num5);
    Label_07E9:
        if (GameUpgrades.MagesUpSpellReach == null)
        {
            goto Label_094E;
        }
        num6 = 0.1f;
        dictionary26 = Instance.towersSettings["mage_level1"];
        dictionary26["range"] += (float) Mathf.CeilToInt(dictionary26["range"] * num6);
        dictionary27 = Instance.towersSettings["mage_level2"];
        dictionary27["range"] += (float) Mathf.CeilToInt(dictionary27["range"] * num6);
        dictionary28 = Instance.towersSettings["mage_level3"];
        dictionary28["range"] += (float) Mathf.CeilToInt(dictionary28["range"] * num6);
        dictionary29 = Instance.towersSettings["mage_arcane"];
        dictionary29["range"] += (float) Mathf.CeilToInt(dictionary29["range"] * num6);
        dictionary30 = Instance.towersSettings["mage_sorcerer"];
        dictionary30["range"] += (float) Mathf.CeilToInt(dictionary30["range"] * num6);
    Label_094E:
        if (GameUpgrades.MagesUpEmpoweredMagic == null)
        {
            goto Label_0BA6;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_0965;
        }
        if (maxUpgradeLevel < 4)
        {
            goto Label_0BA6;
        }
    Label_0965:
        num7 = 0.15f;
        dictionary31 = Instance.towersSettings["mage_level1"];
        dictionary31["minDamage"] += (float) Mathf.CeilToInt(dictionary31["minDamage"] * num7);
        dictionary31["maxDamage"] += (float) Mathf.CeilToInt(dictionary31["maxDamage"] * num7);
        dictionary32 = Instance.towersSettings["mage_level2"];
        dictionary32["minDamage"] += (float) Mathf.CeilToInt(dictionary32["minDamage"] * num7);
        dictionary32["maxDamage"] += (float) Mathf.CeilToInt(dictionary32["maxDamage"] * num7);
        dictionary33 = Instance.towersSettings["mage_level3"];
        dictionary33["minDamage"] += (float) Mathf.CeilToInt(dictionary33["minDamage"] * num7);
        dictionary33["maxDamage"] += (float) Mathf.CeilToInt(dictionary33["maxDamage"] * num7);
        dictionary34 = Instance.towersSettings["mage_arcane"];
        dictionary34["minDamage"] += (float) Mathf.CeilToInt(dictionary34["minDamage"] * num7);
        dictionary34["maxDamage"] += (float) Mathf.CeilToInt(dictionary34["maxDamage"] * num7);
        dictionary35 = Instance.towersSettings["mage_sorcerer"];
        dictionary35["minDamage"] += (float) Mathf.CeilToInt(dictionary35["minDamage"] * num7);
        dictionary35["maxDamage"] += (float) Mathf.CeilToInt(dictionary35["maxDamage"] * num7);
    Label_0BA6:
        if (GameUpgrades.MagesUpHermeticStudy == null)
        {
            goto Label_0D18;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_0BBD;
        }
        if (maxUpgradeLevel < 3)
        {
            goto Label_0D18;
        }
    Label_0BBD:
        num8 = 0.1f;
        dictionary36 = Instance.towersSettings["mage_level1"];
        dictionary36["price"] -= (float) Mathf.CeilToInt(dictionary36["price"] * num8);
        dictionary37 = Instance.towersSettings["mage_level2"];
        dictionary37["price"] -= (float) Mathf.CeilToInt(dictionary37["price"] * num8);
        dictionary38 = Instance.towersSettings["mage_level3"];
        dictionary38["price"] -= (float) Mathf.CeilToInt(dictionary38["price"] * num8);
        dictionary39 = Instance.towersSettings["mage_arcane"];
        dictionary39["price"] -= (float) Mathf.CeilToInt(dictionary39["price"] * num8);
        dictionary40 = Instance.towersSettings["mage_sorcerer"];
        dictionary40["price"] -= (float) Mathf.CeilToInt(dictionary40["price"] * num8);
    Label_0D18:
        if (GameUpgrades.EngineersUpConcentratedFire == null)
        {
            goto Label_0F63;
        }
        num9 = 0.1f;
        dictionary41 = Instance.towersSettings["artillery_level1"];
        dictionary41["minDamage"] += (float) Mathf.CeilToInt(dictionary41["minDamage"] * num9);
        dictionary41["maxDamage"] += (float) Mathf.CeilToInt(dictionary41["maxDamage"] * num9);
        dictionary42 = Instance.towersSettings["artillery_level2"];
        dictionary42["minDamage"] += (float) Mathf.CeilToInt(dictionary42["minDamage"] * num9);
        dictionary42["maxDamage"] += (float) Mathf.CeilToInt(dictionary42["maxDamage"] * num9);
        dictionary43 = Instance.towersSettings["artillery_level3"];
        dictionary43["minDamage"] += (float) Mathf.CeilToInt(dictionary43["minDamage"] * num9);
        dictionary43["maxDamage"] += (float) Mathf.CeilToInt(dictionary43["maxDamage"] * num9);
        dictionary44 = Instance.towersSettings["artillery_bfg"];
        dictionary44["minDamage"] += (float) Mathf.CeilToInt(dictionary44["minDamage"] * num9);
        dictionary44["maxDamage"] += (float) Mathf.CeilToInt(dictionary44["maxDamage"] * num9);
        dictionary45 = Instance.towersSettings["artillery_tesla"];
        dictionary45["minDamage"] += (float) Mathf.CeilToInt(dictionary45["minDamage"] * num9);
        dictionary45["maxDamage"] += (float) Mathf.CeilToInt(dictionary45["maxDamage"] * num9);
    Label_0F63:
        if (GameUpgrades.EngineersUpRangeFinder == null)
        {
            goto Label_10D5;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_0F7A;
        }
        if (maxUpgradeLevel < 2)
        {
            goto Label_10D5;
        }
    Label_0F7A:
        num10 = 0.1f;
        dictionary46 = Instance.towersSettings["artillery_level1"];
        dictionary46["range"] += (float) Mathf.CeilToInt(dictionary46["range"] * num10);
        dictionary47 = Instance.towersSettings["artillery_level2"];
        dictionary47["range"] += (float) Mathf.CeilToInt(dictionary47["range"] * num10);
        dictionary48 = Instance.towersSettings["artillery_level3"];
        dictionary48["range"] += (float) Mathf.CeilToInt(dictionary48["range"] * num10);
        dictionary49 = Instance.towersSettings["artillery_bfg"];
        dictionary49["range"] += (float) Mathf.CeilToInt(dictionary49["range"] * num10);
        dictionary50 = Instance.towersSettings["artillery_tesla"];
        dictionary50["range"] += (float) Mathf.CeilToInt(dictionary50["range"] * num10);
    Label_10D5:
        if (GameUpgrades.EngineersUpFieldLogistics == null)
        {
            goto Label_1247;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_10EC;
        }
        if (maxUpgradeLevel < 3)
        {
            goto Label_1247;
        }
    Label_10EC:
        num11 = 0.1f;
        dictionary51 = Instance.towersSettings["artillery_level1"];
        dictionary51["price"] -= (float) Mathf.CeilToInt(dictionary51["price"] * num11);
        dictionary52 = Instance.towersSettings["artillery_level2"];
        dictionary52["price"] -= (float) Mathf.CeilToInt(dictionary52["price"] * num11);
        dictionary53 = Instance.towersSettings["artillery_level3"];
        dictionary53["price"] -= (float) Mathf.CeilToInt(dictionary53["price"] * num11);
        dictionary54 = Instance.towersSettings["artillery_bfg"];
        dictionary54["price"] -= (float) Mathf.CeilToInt(dictionary54["price"] * num11);
        dictionary55 = Instance.towersSettings["artillery_tesla"];
        dictionary55["price"] -= (float) Mathf.CeilToInt(dictionary55["price"] * num11);
    Label_1247:
        if (GameUpgrades.EngineersUpIndustrialization == null)
        {
            goto Label_1401;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_125E;
        }
        if (maxUpgradeLevel < 4)
        {
            goto Label_1401;
        }
    Label_125E:
        num12 = 0.25f;
        dictionary56 = Instance.towersSettings["artillery_bfg"];
        dictionary56["missilePrice"] -= (float) Mathf.CeilToInt(dictionary56["missilePrice"] * num12);
        dictionary56["missilePriceLevel"] -= (float) Mathf.CeilToInt(dictionary56["missilePriceLevel"] * num12);
        dictionary56["clusterPrice"] -= (float) Mathf.CeilToInt(dictionary56["clusterPrice"] * num12);
        dictionary56["clusterPriceLevel"] -= (float) Mathf.CeilToInt(dictionary56["clusterPriceLevel"] * num12);
        dictionary57 = Instance.towersSettings["artillery_tesla"];
        dictionary57["chargedBoltPrice"] -= (float) Mathf.CeilToInt(dictionary57["chargedBoltPrice"] * num12);
        dictionary57["chargedBoltPriceLevel"] -= (float) Mathf.CeilToInt(dictionary57["chargedBoltPriceLevel"] * num12);
        dictionary57["overchargePrice"] -= (float) Mathf.CeilToInt(dictionary57["overchargePrice"] * num12);
        dictionary57["overchargePriceLevel"] -= (float) Mathf.CeilToInt(dictionary57["overchargePriceLevel"] * num12);
    Label_1401:
        if (GameUpgrades.RainUpBlazingSkies == null)
        {
            goto Label_1457;
        }
        dictionary58 = Instance.powerSettings["power_fireball"];
        dictionary58["minDamage"] += 20;
        dictionary58["maxDamage"] += 20;
    Label_1457:
        if (GameUpgrades.RainUpBiggerAndMeaner == null)
        {
            goto Label_1506;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_146E;
        }
        if (maxUpgradeLevel < 3)
        {
            goto Label_1506;
        }
    Label_146E:
        dictionary59 = Instance.powerSettings["power_fireball"];
        dictionary59["range"] += Mathf.CeilToInt(((float) dictionary59["range"]) * 0.25f);
        dictionary59["minDamage"] += 40;
        dictionary59["maxDamage"] += 40;
        dictionary59["coolDown"] -= 10;
    Label_1506:
        if (GameUpgrades.RainUpBlazingEarth == null)
        {
            goto Label_154E;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_151D;
        }
        if (maxUpgradeLevel < 4)
        {
            goto Label_154E;
        }
    Label_151D:
        dictionary60 = Instance.powerSettings["power_fireball"];
        dictionary60["coolDown"] -= 10;
    Label_154E:
        if (GameUpgrades.RainUpCataclysm == null)
        {
            goto Label_15B1;
        }
        if (maxUpgradeLevel == null)
        {
            goto Label_1565;
        }
        if (maxUpgradeLevel != 5)
        {
            goto Label_15B1;
        }
    Label_1565:
        dictionary61 = Instance.powerSettings["power_fireball"];
        dictionary61["minDamage"] += 60;
        dictionary61["maxDamage"] += 60;
    Label_15B1:
        return;
    }

    private void LoadPowers()
    {
        Dictionary<string, int> dictionary;
        Dictionary<string, int> dictionary2;
        Dictionary<string, int> dictionary3;
        Dictionary<string, int> dictionary4;
        Dictionary<string, int> dictionary5;
        Dictionary<string, int> dictionary6;
        Dictionary<string, int> dictionary7;
        dictionary7 = new Dictionary<string, int>();
        dictionary7.Add("coolDown", 80);
        dictionary7.Add("range", 170);
        dictionary7.Add("minDamage", 30);
        dictionary7.Add("maxDamage", 60);
        dictionary7.Add("scorchedEarthRange", 0x108);
        dictionary7.Add("scorchedEarthMinDamage", 10);
        dictionary7.Add("scorchedEarthMaxDamage", 20);
        dictionary7.Add("scorchedEarthDamageTime", 1);
        dictionary7.Add("scorchedEarthDuration", 5);
        dictionary7.Add("blazingEarthRange", 0x108);
        dictionary7.Add("blazingEarthMinDamage", 20);
        dictionary7.Add("blazingEarthMaxDamage", 30);
        dictionary7.Add("blazingEarthDamageTime", 1);
        dictionary7.Add("blazingEarthDuration", 10);
        dictionary = dictionary7;
        this.powerSettingsReal.Add("power_fireball", dictionary);
        dictionary7 = new Dictionary<string, int>();
        dictionary7.Add("coolDown", 10);
        dictionary7.Add("range", 170);
        dictionary7.Add("health", 30);
        dictionary7.Add("armor", 0);
        dictionary7.Add("minDamage", 1);
        dictionary7.Add("maxDamage", 2);
        dictionary7.Add("reload", 1);
        dictionary7.Add("lifeTime", 20);
        dictionary7.Add("regen", 3);
        dictionary7.Add("regenReload", 1);
        dictionary2 = dictionary7;
        this.powerSettingsReal.Add("power_reinforcement_farmer", dictionary2);
        dictionary7 = new Dictionary<string, int>();
        dictionary7.Add("coolDown", 10);
        dictionary7.Add("range", 170);
        dictionary7.Add("health", 50);
        dictionary7.Add("armor", 0);
        dictionary7.Add("minDamage", 1);
        dictionary7.Add("maxDamage", 3);
        dictionary7.Add("reload", 1);
        dictionary7.Add("lifeTime", 20);
        dictionary7.Add("regen", 6);
        dictionary7.Add("regenReload", 1);
        dictionary3 = dictionary7;
        this.powerSettingsReal.Add("power_reinforcement_farmer_wellfeed", dictionary3);
        dictionary7 = new Dictionary<string, int>();
        dictionary7.Add("coolDown", 10);
        dictionary7.Add("range", 170);
        dictionary7.Add("health", 70);
        dictionary7.Add("armor", 10);
        dictionary7.Add("minDamage", 2);
        dictionary7.Add("maxDamage", 4);
        dictionary7.Add("reload", 1);
        dictionary7.Add("lifeTime", 20);
        dictionary7.Add("regen", 9);
        dictionary7.Add("regenReload", 1);
        dictionary4 = dictionary7;
        this.powerSettingsReal.Add("power_reinforcement_conscript", dictionary4);
        dictionary7 = new Dictionary<string, int>();
        dictionary7.Add("coolDown", 10);
        dictionary7.Add("range", 170);
        dictionary7.Add("health", 90);
        dictionary7.Add("armor", 20);
        dictionary7.Add("minDamage", 3);
        dictionary7.Add("maxDamage", 6);
        dictionary7.Add("reload", 1);
        dictionary7.Add("lifeTime", 20);
        dictionary7.Add("regen", 12);
        dictionary7.Add("regenReload", 1);
        dictionary5 = dictionary7;
        this.powerSettingsReal.Add("power_reinforcement_warrior", dictionary5);
        dictionary7 = new Dictionary<string, int>();
        dictionary7.Add("coolDown", 10);
        dictionary7.Add("range", 170);
        dictionary7.Add("health", 110);
        dictionary7.Add("armor", 30);
        dictionary7.Add("minDamage", 6);
        dictionary7.Add("maxDamage", 10);
        dictionary7.Add("reload", 1);
        dictionary7.Add("lifeTime", 20);
        dictionary7.Add("regen", 15);
        dictionary7.Add("regenReload", 1);
        dictionary7.Add("spearCoolDown", 1);
        dictionary7.Add("spearRange", 0x1d1);
        dictionary7.Add("spearMinRange", 0x36);
        dictionary7.Add("spearMinDamage", 0x18);
        dictionary7.Add("spearMaxDamage", 40);
        dictionary6 = dictionary7;
        this.powerSettingsReal.Add("power_reinforcement_leggionaire", dictionary6);
        return;
    }

    private void LoadTowerPrices()
    {
        this.towerPrices.Add("ArcherLvl1", 70);
        this.towerPrices.Add("ArcherLvl2", 110);
        this.towerPrices.Add("ArcherLvl3", 160);
        this.towerPrices.Add("ArcherRanger", 230);
        this.towerPrices.Add("ArcherMusketeer", 230);
        this.towerPrices.Add("ArtilleryLvl1", 0x7d);
        this.towerPrices.Add("ArtilleryLvl2", 220);
        this.towerPrices.Add("ArtilleryLvl3", 320);
        this.towerPrices.Add("ArtilleryBFG", 400);
        this.towerPrices.Add("ArtilleryTesla", 0x177);
        this.towerPrices.Add("BarrackLvl1", 70);
        this.towerPrices.Add("BarrackLvl2", 110);
        this.towerPrices.Add("BarrackLvl3", 160);
        this.towerPrices.Add("BarrackHolyOrder", 230);
        this.towerPrices.Add("BarrackBarbarian", 230);
        this.towerPrices.Add("MageLvl1", 100);
        this.towerPrices.Add("MageLvl2", 160);
        this.towerPrices.Add("MageLvl3", 240);
        this.towerPrices.Add("MageSorcerer", 300);
        this.towerPrices.Add("MageArcane", 300);
        return;
    }

    private void LoadTowers()
    {
        Dictionary<string, float> dictionary;
        Dictionary<string, float> dictionary2;
        Dictionary<string, float> dictionary3;
        Dictionary<string, float> dictionary4;
        Dictionary<string, float> dictionary5;
        Dictionary<string, float> dictionary6;
        Dictionary<string, float> dictionary7;
        Dictionary<string, float> dictionary8;
        Dictionary<string, float> dictionary9;
        Dictionary<string, float> dictionary10;
        Dictionary<string, float> dictionary11;
        Dictionary<string, float> dictionary12;
        Dictionary<string, float> dictionary13;
        Dictionary<string, float> dictionary14;
        Dictionary<string, float> dictionary15;
        Dictionary<string, float> dictionary16;
        Dictionary<string, float> dictionary17;
        Dictionary<string, float> dictionary18;
        Dictionary<string, float> dictionary19;
        Dictionary<string, float> dictionary20;
        Dictionary<string, float> dictionary21;
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 70f);
        dictionary21.Add("range", 395f);
        dictionary21.Add("minDamage", 4f);
        dictionary21.Add("maxDamage", 6f);
        dictionary21.Add("reload", 0.8f);
        dictionary = dictionary21;
        this.towersSettingsReal.Add("archer_level1", dictionary);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 110f);
        dictionary21.Add("range", 450f);
        dictionary21.Add("minDamage", 7f);
        dictionary21.Add("maxDamage", 11f);
        dictionary21.Add("reload", 0.6f);
        dictionary2 = dictionary21;
        this.towersSettingsReal.Add("archer_level2", dictionary2);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 160f);
        dictionary21.Add("range", 507f);
        dictionary21.Add("minDamage", 10f);
        dictionary21.Add("maxDamage", 16f);
        dictionary21.Add("reload", 0.5f);
        dictionary3 = dictionary21;
        this.towersSettingsReal.Add("archer_level3", dictionary3);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 230f);
        dictionary21.Add("range", 564f);
        dictionary21.Add("minDamage", 13f);
        dictionary21.Add("maxDamage", 19f);
        dictionary21.Add("reload", 0.4f);
        dictionary21.Add("poisonPrice", 250f);
        dictionary21.Add("poisonPriceLevel", 250f);
        dictionary21.Add("poisonDuration", 3f);
        dictionary21.Add("poisonDamage", 5f);
        dictionary21.Add("poisonLevels", 3f);
        dictionary21.Add("thornPrice", 300f);
        dictionary21.Add("thornPriceLevel", 150f);
        dictionary21.Add("thornMinEnemies", 2f);
        dictionary21.Add("thornMaxEnemies", 2f);
        dictionary21.Add("thornDuration", 1f);
        dictionary21.Add("thornDamageTime", 1f);
        dictionary21.Add("thornDamage", 40f);
        dictionary21.Add("thornCoolDown", 8f);
        dictionary21.Add("thornMaxTimes", 3f);
        dictionary21.Add("thornLevels", 3f);
        dictionary4 = dictionary21;
        this.towersSettingsReal.Add("archer_ranger", dictionary4);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 230f);
        dictionary21.Add("range", 663f);
        dictionary21.Add("minDamage", 35f);
        dictionary21.Add("maxDamage", 65f);
        dictionary21.Add("reload", 1.5f);
        dictionary21.Add("sniperPrice", 250f);
        dictionary21.Add("sniperPriceLevel", 250f);
        dictionary21.Add("sniperRange", 1.5f);
        dictionary21.Add("sniperDamagePercent", 20f);
        dictionary21.Add("sniperCoolDown", 14f);
        dictionary21.Add("sniperLevels", 3f);
        dictionary21.Add("shrapnelPrice", 300f);
        dictionary21.Add("shrapnelPriceLevel", 300f);
        dictionary21.Add("shrapnelRange", 0.5f);
        dictionary21.Add("shrapnelArea", 90f);
        dictionary21.Add("shrapnelMinDamage", 10f);
        dictionary21.Add("shrapnelMaxDamage", 40f);
        dictionary21.Add("shrapnelCoolDown", 9f);
        dictionary21.Add("shrapnelLevels", 3f);
        dictionary5 = dictionary21;
        this.towersSettingsReal.Add("archer_musketeer", dictionary5);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 70f);
        dictionary21.Add("rangeRally", 409f);
        dictionary21.Add("range", 170f);
        dictionary21.Add("minDamage", 1f);
        dictionary21.Add("maxDamage", 3f);
        dictionary21.Add("reload", 1f);
        dictionary21.Add("health", 50f);
        dictionary21.Add("armor", 0f);
        dictionary21.Add("respawn", 10f);
        dictionary21.Add("regen", 5f);
        dictionary21.Add("regenReload", 1f);
        dictionary6 = dictionary21;
        this.towersSettingsReal.Add("barrack_level1", dictionary6);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 110f);
        dictionary21.Add("rangeRally", 409f);
        dictionary21.Add("range", 170f);
        dictionary21.Add("minDamage", 3f);
        dictionary21.Add("maxDamage", 4f);
        dictionary21.Add("reload", 1f);
        dictionary21.Add("health", 100f);
        dictionary21.Add("armor", 15f);
        dictionary21.Add("respawn", 10f);
        dictionary21.Add("regen", 7f);
        dictionary21.Add("regenReload", 1f);
        dictionary7 = dictionary21;
        this.towersSettingsReal.Add("barrack_level2", dictionary7);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 160f);
        dictionary21.Add("rangeRally", 409f);
        dictionary21.Add("range", 170f);
        dictionary21.Add("minDamage", 6f);
        dictionary21.Add("maxDamage", 10f);
        dictionary21.Add("reload", 1f);
        dictionary21.Add("health", 150f);
        dictionary21.Add("armor", 30f);
        dictionary21.Add("respawn", 10f);
        dictionary21.Add("regen", 10f);
        dictionary21.Add("regenReload", 1f);
        dictionary8 = dictionary21;
        this.towersSettingsReal.Add("barrack_level3", dictionary8);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 230f);
        dictionary21.Add("rangeRally", 409f);
        dictionary21.Add("range", 170f);
        dictionary21.Add("minDamage", 12f);
        dictionary21.Add("maxDamage", 18f);
        dictionary21.Add("reload", 1f);
        dictionary21.Add("health", 200f);
        dictionary21.Add("armor", 50f);
        dictionary21.Add("respawn", 14f);
        dictionary21.Add("regen", 25f);
        dictionary21.Add("regenReload", 1f);
        dictionary21.Add("holyStrikePrice", 220f);
        dictionary21.Add("holyStrikePriceLevel", 150f);
        dictionary21.Add("holyStrikeRange", 141f);
        dictionary21.Add("holyStrikeMinEnemies", 1f);
        dictionary21.Add("holyStrikeMinDamage", 25f);
        dictionary21.Add("holyStrikeMaxDamage", 45f);
        dictionary21.Add("holyStrikeChance", 10f);
        dictionary21.Add("holyStrikeLevels", 3f);
        dictionary21.Add("healingPrice", 150f);
        dictionary21.Add("healingPriceLevel", 150f);
        dictionary21.Add("healingMin", 40f);
        dictionary21.Add("healingMax", 60f);
        dictionary21.Add("healingCoolDown", 10f);
        dictionary21.Add("healingLevels", 3f);
        dictionary21.Add("shieldPrice", 250f);
        dictionary21.Add("shieldPriceLevel", 100f);
        dictionary21.Add("shieldArmor", 15f);
        dictionary21.Add("shieldLevels", 1f);
        dictionary9 = dictionary21;
        this.towersSettingsReal.Add("barrack_paladin", dictionary9);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 230f);
        dictionary21.Add("rangeRally", 409f);
        dictionary21.Add("range", 170f);
        dictionary21.Add("minDamage", 16f);
        dictionary21.Add("maxDamage", 24f);
        dictionary21.Add("reload", 1f);
        dictionary21.Add("health", 250f);
        dictionary21.Add("armor", 0f);
        dictionary21.Add("respawn", 10f);
        dictionary21.Add("regen", 20f);
        dictionary21.Add("regenReload", 1f);
        dictionary21.Add("dualWeaponsPrice", 300f);
        dictionary21.Add("dualWeaponsPriceLevel", 100f);
        dictionary21.Add("dualWeaponsIncrementDamage", 10f);
        dictionary21.Add("dualWeaponsLevels", 3f);
        dictionary21.Add("throwingPrice", 200f);
        dictionary21.Add("throwingPriceLevel", 100f);
        dictionary21.Add("throwingCoolDown", 3f);
        dictionary21.Add("throwingRange", 60f);
        dictionary21.Add("throwingMinRange", 437f);
        dictionary21.Add("throwingMinDamage", 24f);
        dictionary21.Add("throwingMaxDamage", 32f);
        dictionary21.Add("throwingIncrementDamage", 10f);
        dictionary21.Add("throwingIncrementRange", 37f);
        dictionary21.Add("throwingLevels", 3f);
        dictionary21.Add("twisterPrice", 150f);
        dictionary21.Add("twisterPriceLevel", 100f);
        dictionary21.Add("twisterRange", 113f);
        dictionary21.Add("twisterMinDamage", 10f);
        dictionary21.Add("twisterMaxDamage", 30f);
        dictionary21.Add("twisterIncrementDamage", 15f);
        dictionary21.Add("twisterChance", 10f);
        dictionary21.Add("twisterIncrementChance", 5f);
        dictionary21.Add("twisterLevels", 3f);
        dictionary10 = dictionary21;
        this.towersSettingsReal.Add("barrack_barbarian", dictionary10);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 100f);
        dictionary21.Add("range", 395f);
        dictionary21.Add("minDamage", 9f);
        dictionary21.Add("maxDamage", 17f);
        dictionary21.Add("reload", 1.5f);
        dictionary11 = dictionary21;
        this.towersSettingsReal.Add("mage_level1", dictionary11);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 160f);
        dictionary21.Add("range", 451f);
        dictionary21.Add("minDamage", 23f);
        dictionary21.Add("maxDamage", 43f);
        dictionary21.Add("reload", 1.5f);
        dictionary12 = dictionary21;
        this.towersSettingsReal.Add("mage_level2", dictionary12);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 240f);
        dictionary21.Add("range", 508f);
        dictionary21.Add("minDamage", 40f);
        dictionary21.Add("maxDamage", 74f);
        dictionary21.Add("reload", 1.5f);
        dictionary13 = dictionary21;
        this.towersSettingsReal.Add("mage_level3", dictionary13);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 300f);
        dictionary21.Add("range", 564f);
        dictionary21.Add("minDamage", 42f);
        dictionary21.Add("maxDamage", 78f);
        dictionary21.Add("reload", 1.5f);
        dictionary21.Add("curseDamage", 10f);
        dictionary21.Add("curseArmorReduce", 50f);
        dictionary21.Add("curseDuration", 5f);
        dictionary21.Add("polymorphPrice", 300f);
        dictionary21.Add("polymorphPriceLevel", 150f);
        dictionary21.Add("polymorphDamage", 50f);
        dictionary21.Add("polymorphCoolDown", 22f);
        dictionary21.Add("polymorphLessCoolDown", 2f);
        dictionary21.Add("polymorphSpeedMultiplier", 1.5f);
        dictionary21.Add("polymorphLevels", 3f);
        dictionary21.Add("elementalPrice", 350f);
        dictionary21.Add("elementalPriceLevel", 150f);
        dictionary21.Add("elementalRallyRange", 508f);
        dictionary21.Add("elementalRange", 212f);
        dictionary21.Add("elementalHealth", 500f);
        dictionary21.Add("elementalExtraHealth", 100f);
        dictionary21.Add("elementalRegen", 20f);
        dictionary21.Add("elementalRegenReload", 1f);
        dictionary21.Add("elementalAreaAttackRangeWidth", 106f);
        dictionary21.Add("elementalAreaAttackMaxEnemies", 4f);
        dictionary21.Add("elementalMinDamage", 20f);
        dictionary21.Add("elementalMaxDamage", 40f);
        dictionary21.Add("elementalDamageExtra", 10f);
        dictionary21.Add("elementalArmor", 30f);
        dictionary21.Add("elementalArmorExtra", 10f);
        dictionary21.Add("elementalReload", 2f);
        dictionary21.Add("elementalRespawnTime", 8f);
        dictionary21.Add("elementalLevels", 3f);
        dictionary14 = dictionary21;
        this.towersSettingsReal.Add("mage_sorcerer", dictionary14);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 300f);
        dictionary21.Add("range", 564f);
        dictionary21.Add("minDamage", 76f);
        dictionary21.Add("maxDamage", 140f);
        dictionary21.Add("reload", 2f);
        dictionary21.Add("desintegratePrice", 350f);
        dictionary21.Add("desintegratePriceLevel", 200f);
        dictionary21.Add("desintegrateCoolDown", 22f);
        dictionary21.Add("desintegrateLessCoolDown", 2f);
        dictionary21.Add("desintegrateLevels", 3f);
        dictionary21.Add("teleportPrice", 300f);
        dictionary21.Add("teleportPriceLevel", 100f);
        dictionary21.Add("teleportRange", 28f);
        dictionary21.Add("teleportMaxEnemies", 3f);
        dictionary21.Add("teleportExtraEnemies", 1f);
        dictionary21.Add("teleportNodes", 20f);
        dictionary21.Add("teleportExtraNodes", 5f);
        dictionary21.Add("teleportCoolDown", 10f);
        dictionary21.Add("teleportMaxTimes", 3f);
        dictionary21.Add("teleportLevels", 3f);
        dictionary15 = dictionary21;
        this.towersSettingsReal.Add("mage_arcane", dictionary15);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 125f);
        dictionary21.Add("range", 451f);
        dictionary21.Add("area", 113f);
        dictionary21.Add("minDamage", 8f);
        dictionary21.Add("maxDamage", 15f);
        dictionary21.Add("reload", 3f);
        dictionary16 = dictionary21;
        this.towersSettingsReal.Add("artillery_level1", dictionary16);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 220f);
        dictionary21.Add("range", 451f);
        dictionary21.Add("area", 113f);
        dictionary21.Add("minDamage", 20f);
        dictionary21.Add("maxDamage", 40f);
        dictionary21.Add("reload", 3f);
        dictionary17 = dictionary21;
        this.towersSettingsReal.Add("artillery_level2", dictionary17);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 320f);
        dictionary21.Add("range", 508f);
        dictionary21.Add("area", 127f);
        dictionary21.Add("minDamage", 30f);
        dictionary21.Add("maxDamage", 60f);
        dictionary21.Add("reload", 3f);
        dictionary18 = dictionary21;
        this.towersSettingsReal.Add("artillery_level3", dictionary18);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 400f);
        dictionary21.Add("range", 508f);
        dictionary21.Add("area", 127f);
        dictionary21.Add("minDamage", 50f);
        dictionary21.Add("maxDamage", 100f);
        dictionary21.Add("reload", 3.5f);
        dictionary21.Add("missilePrice", 250f);
        dictionary21.Add("missilePriceLevel", 150f);
        dictionary21.Add("missileRangeIncrement", 0.2f);
        dictionary21.Add("missileArea", 78f);
        dictionary21.Add("missileMinDamage", 60f);
        dictionary21.Add("missileMaxDamage", 100f);
        dictionary21.Add("missileIncrementDamage", 40f);
        dictionary21.Add("missileCoolDown", 11f);
        dictionary21.Add("missileLevels", 3f);
        dictionary21.Add("clusterPrice", 250f);
        dictionary21.Add("clusterPriceLevel", 150f);
        dictionary21.Add("clusterArea", 100f);
        dictionary21.Add("clusterMinDamage", 60f);
        dictionary21.Add("clusterMaxDamage", 80f);
        dictionary21.Add("clusterMinBombs", 1f);
        dictionary21.Add("clusterIncrementBombs", 2f);
        dictionary21.Add("clusterCoolDown", 17f);
        dictionary21.Add("clusterLevels", 3f);
        dictionary19 = dictionary21;
        this.towersSettingsReal.Add("artillery_bfg", dictionary19);
        dictionary21 = new Dictionary<string, float>();
        dictionary21.Add("price", 375f);
        dictionary21.Add("range", 465f);
        dictionary21.Add("minDamage", 60f);
        dictionary21.Add("maxDamage", 110f);
        dictionary21.Add("reload", 2.2f);
        dictionary21.Add("chargedBoltPrice", 250f);
        dictionary21.Add("chargedBoltPriceLevel", 250f);
        dictionary21.Add("chargedBoltEnemies", 3f);
        dictionary21.Add("chargedBoltIncrementEnemies", 1f);
        dictionary21.Add("chargedBoltCoolDown", 6f);
        dictionary21.Add("chargedBoltLevels", 2f);
        dictionary21.Add("chargedBoltRange", 113f);
        dictionary21.Add("overchargePrice", 250f);
        dictionary21.Add("overchargePriceLevel", 125f);
        dictionary21.Add("overchargeArea", 465f);
        dictionary21.Add("overchargeMinDamage", 0f);
        dictionary21.Add("overchargeMaxDamage", 10f);
        dictionary21.Add("overchargeDamageIncrement", 10f);
        dictionary21.Add("overchargeCoolDown", 6f);
        dictionary21.Add("overchargeLevels", 3f);
        dictionary21.Add("overchargeDisplayRatio", 0.7f);
        dictionary20 = dictionary21;
        this.towersSettingsReal.Add("artillery_tesla", dictionary20);
        return;
    }

    private static void ReformatTowerName(ref string t)
    {
        if ((*(t) == "MageLvl1") == null)
        {
            goto Label_001D;
        }
        *(t) = "mage_level1";
        goto Label_023F;
    Label_001D:
        if ((*(t) == "MageLvl2") == null)
        {
            goto Label_003A;
        }
        *(t) = "mage_level2";
        goto Label_023F;
    Label_003A:
        if ((*(t) == "MageLvl3") == null)
        {
            goto Label_0057;
        }
        *(t) = "mage_level3";
        goto Label_023F;
    Label_0057:
        if ((*(t) == "MageSorcerer") == null)
        {
            goto Label_0074;
        }
        *(t) = "mage_sorcerer";
        goto Label_023F;
    Label_0074:
        if ((*(t) == "MageArcane") == null)
        {
            goto Label_0091;
        }
        *(t) = "mage_arcane";
        goto Label_023F;
    Label_0091:
        if ((*(t) == "ArcherLvl1") == null)
        {
            goto Label_00AE;
        }
        *(t) = "archer_level1";
        goto Label_023F;
    Label_00AE:
        if ((*(t) == "ArcherLvl2") == null)
        {
            goto Label_00CB;
        }
        *(t) = "archer_level2";
        goto Label_023F;
    Label_00CB:
        if ((*(t) == "ArcherLvl3") == null)
        {
            goto Label_00E8;
        }
        *(t) = "archer_level3";
        goto Label_023F;
    Label_00E8:
        if ((*(t) == "ArcherRanger") == null)
        {
            goto Label_0105;
        }
        *(t) = "archer_ranger";
        goto Label_023F;
    Label_0105:
        if ((*(t) == "ArcherMusketeer") == null)
        {
            goto Label_0122;
        }
        *(t) = "archer_musketeer";
        goto Label_023F;
    Label_0122:
        if ((*(t) == "BarrackLvl1") == null)
        {
            goto Label_013F;
        }
        *(t) = "barrack_level1";
        goto Label_023F;
    Label_013F:
        if ((*(t) == "BarrackLvl2") == null)
        {
            goto Label_015C;
        }
        *(t) = "barrack_level2";
        goto Label_023F;
    Label_015C:
        if ((*(t) == "BarrackLvl3") == null)
        {
            goto Label_0179;
        }
        *(t) = "barrack_level3";
        goto Label_023F;
    Label_0179:
        if ((*(t) == "BarrackHolyOrder") == null)
        {
            goto Label_0196;
        }
        *(t) = "barrack_paladin";
        goto Label_023F;
    Label_0196:
        if ((*(t) == "BarrackBarbarian") == null)
        {
            goto Label_01B3;
        }
        *(t) = "barrack_barbarian";
        goto Label_023F;
    Label_01B3:
        if ((*(t) == "ArtilleryLvl1") == null)
        {
            goto Label_01D0;
        }
        *(t) = "artillery_level1";
        goto Label_023F;
    Label_01D0:
        if ((*(t) == "ArtilleryLvl2") == null)
        {
            goto Label_01ED;
        }
        *(t) = "artillery_level2";
        goto Label_023F;
    Label_01ED:
        if ((*(t) == "ArtilleryLvl3") == null)
        {
            goto Label_020A;
        }
        *(t) = "artillery_level3";
        goto Label_023F;
    Label_020A:
        if ((*(t) == "ArtilleryTesla") == null)
        {
            goto Label_0227;
        }
        *(t) = "artillery_tesla";
        goto Label_023F;
    Label_0227:
        if ((*(t) == "ArtilleryBFG") == null)
        {
            goto Label_023F;
        }
        *(t) = "artillery_bfg";
    Label_023F:
        return;
    }

    public static GameSettings Instance
    {
        get
        {
            if (instance != null)
            {
                goto Label_0010;
            }
            new GameSettings();
        Label_0010:
            return instance;
        }
    }
}

