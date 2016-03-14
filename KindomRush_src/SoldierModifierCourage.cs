using System;
using UnityEngine;

public class SoldierModifierCourage : MonoBehaviour
{
    private int addedArmor;
    private int addedMaxDamage;
    private int addedMinDamage;
    private int durationTime;
    private int durationTimeCounter;
    private int healingPoints;
    private int level;
    private Soldier target;
    private BarrackTower tower;

    public SoldierModifierCourage()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        this.durationTimeCounter += 1;
        if (this.durationTimeCounter < this.durationTime)
        {
            goto Label_0025;
        }
        this.Remove();
    Label_0025:
        return;
    }

    public void Init(int lvl, Soldier t)
    {
        Transform transform1;
        this.level = lvl;
        this.target = t;
        this.durationTime = ((int) GameSettings.GetHeroSetting("hero_general", "courageDurationTime", 1)) * 30;
        this.healingPoints = (int) GameSettings.GetHeroSetting("hero_general", "courageHealPercent", 1);
        this.addedMinDamage = ((int) GameSettings.GetHeroSetting("hero_general", "courageDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_general", "courageDamageIncrement", 1)) * this.level);
        this.addedMaxDamage = this.addedMinDamage;
        this.addedArmor = ((int) GameSettings.GetHeroSetting("hero_general", "courageArmor", 1)) + (((int) GameSettings.GetHeroSetting("hero_general", "courageArmorIncrement", 1)) * this.level);
        this.durationTimeCounter = 0;
        if ((t.GetComponent<SoldierReinforcement>() != null) == null)
        {
            goto Label_00ED;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(0f, 5f, 0f);
    Label_00ED:
        return;
    }

    protected void Remove()
    {
        this.target.minDamage -= this.addedMinDamage;
        this.target.maxDamage -= this.addedMaxDamage;
        this.target.armor -= this.addedArmor;
        if ((this.tower != null) == null)
        {
            goto Label_0073;
        }
        this.tower.armor -= this.addedArmor / 3;
    Label_0073:
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void Start()
    {
        this.target.Heal((this.target.GetInitHealth() * this.healingPoints) / 100);
        this.target.minDamage += this.addedMinDamage;
        this.target.maxDamage += this.addedMaxDamage;
        this.target.armor += this.addedArmor;
        this.tower = (BarrackTower) this.target.GetTower();
        if ((this.tower != null) == null)
        {
            goto Label_00A9;
        }
        this.tower.armor += this.addedArmor / 3;
    Label_00A9:
        return;
    }
}

