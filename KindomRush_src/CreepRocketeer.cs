using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CreepRocketeer : Creep
{
    private bool allreadySpeedUp;
    private bool onRampage;

    public CreepRocketeer()
    {
        base..ctor();
        return;
    }

    public override unsafe void CheckFacing()
    {
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        double num;
        Vector3 vector4;
        Vector3 vector5;
        vector = ((base.currentNode + 1) >= ((int) base.path[base.pathIndex][base.subpathIndex].Length)) ? *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode])) : *(&(base.path[base.pathIndex][base.subpathIndex][base.currentNode + 1]));
        &vector2 = new Vector2(&base.transform.position.x, &base.transform.position.y + &this.anchorPoint.y);
        vector3 = vector - vector2;
        &vector3.Normalize();
        num = ((double) (Mathf.Atan2(&vector3.y, &vector3.x) * 180f)) / 3.14;
        if (num >= 0.0)
        {
            goto Label_00FD;
        }
        num += 360.0;
    Label_00FD:
        if (num <= 55.0)
        {
            goto Label_0163;
        }
        if (num >= 135.0)
        {
            goto Label_0163;
        }
        if (base.facing == 1)
        {
            goto Label_0299;
        }
        base.facing = 1;
        if (this.onRampage != null)
        {
            goto Label_014E;
        }
        base.creepSprite.PlayAnim("walkUp");
        goto Label_015E;
    Label_014E:
        base.creepSprite.PlayAnim("turboUp");
    Label_015E:
        goto Label_0299;
    Label_0163:
        if (num < 135.0)
        {
            goto Label_01CD;
        }
        if (num > 240.0)
        {
            goto Label_01CD;
        }
        if (base.facing == 2)
        {
            goto Label_0299;
        }
        base.facing = 2;
        base.creepSprite.PlayAnim("walk");
        base.creepSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        goto Label_0299;
    Label_01CD:
        if (num <= 240.0)
        {
            goto Label_0232;
        }
        if (num >= 315.0)
        {
            goto Label_0232;
        }
        if (base.facing == null)
        {
            goto Label_0299;
        }
        base.facing = 0;
        if (this.onRampage != null)
        {
            goto Label_021D;
        }
        base.creepSprite.PlayAnim("walkDown");
        goto Label_022D;
    Label_021D:
        base.creepSprite.PlayAnim("turboDown");
    Label_022D:
        goto Label_0299;
    Label_0232:
        if (base.facing == 3)
        {
            goto Label_0299;
        }
        base.facing = 3;
        if (this.onRampage != null)
        {
            goto Label_0265;
        }
        base.creepSprite.PlayAnim("walk");
        goto Label_0275;
    Label_0265:
        base.creepSprite.PlayAnim("turbo");
    Label_0275:
        base.creepSprite.transform.localScale = new Vector3(1f, 1f, 1f);
    Label_0299:
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
        if (this.allreadySpeedUp != null)
        {
            goto Label_0077;
        }
        this.allreadySpeedUp = 1;
        if ((base.GetComponent<EnemyModifierRocketeer>() == null) == null)
        {
            goto Label_0077;
        }
        this.onRampage = 1;
        base.facing = 4;
        this.CheckFacing();
        GameSoundManager.PlayEnemyRocketeer();
        base.gameObject.AddComponent<EnemyModifierRocketeer>();
    Label_0077:
        if (base.life > 0)
        {
            goto Label_008F;
        }
        GameSoundManager.PlayBombExplosionSound();
        base.life = 0;
    Label_008F:
        return;
    }

    public override void Pause()
    {
        base.Pause();
        if (this.onRampage == null)
        {
            goto Label_001C;
        }
        base.GetComponent<EnemyModifierRocketeer>().Pause();
    Label_001C:
        return;
    }

    public void StopRampage()
    {
        this.onRampage = 0;
        return;
    }

    public override void Unpause()
    {
        base.Unpause();
        if (this.onRampage == null)
        {
            goto Label_001C;
        }
        base.GetComponent<EnemyModifierRocketeer>().Unpause();
    Label_001C:
        return;
    }
}

