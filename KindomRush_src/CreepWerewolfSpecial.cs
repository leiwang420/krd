using System;
using UnityEngine;

public class CreepWerewolfSpecial : CreepBlackburn
{
    protected int disableLycantrophyNodes;
    public int lifeRemaining;
    protected Transform lycantrophy;
    protected float spreadLycantrophyCurseChance;
    public Transform werewolfPrefab;

    public CreepWerewolfSpecial()
    {
        base..ctor();
        return;
    }

    protected override unsafe void Attack()
    {
        Transform transform;
        CreepWerewolf werewolf;
        Vector3 vector;
        Vector3 vector2;
        base.Attack();
        if (base.attackIsDodged == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        if ((base.soldier == null) != null)
        {
            goto Label_0043;
        }
        if (base.soldier.IsActive() == null)
        {
            goto Label_0043;
        }
        if (base.soldier.IsDead() == null)
        {
            goto Label_0044;
        }
    Label_0043:
        return;
    Label_0044:
        if (base.soldier.CanBeConvertedToWerewolf() != null)
        {
            goto Label_0055;
        }
        return;
    Label_0055:
        if (base.DistanceInNodes() >= this.disableLycantrophyNodes)
        {
            goto Label_0067;
        }
        return;
    Label_0067:
        if (this.spreadLycantrophyCurseChance > 0f)
        {
            goto Label_0078;
        }
        return;
    Label_0078:
        if (UnityEngine.Random.Range(0f, 1f) >= this.spreadLycantrophyCurseChance)
        {
            goto Label_0181;
        }
        transform = UnityEngine.Object.Instantiate(this.werewolfPrefab, base.soldier.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.spawner.transform;
        werewolf = transform.GetComponent<CreepWerewolf>();
        werewolf.name = "Werewolf";
        werewolf.InitSprite();
        vector = base.stage.FindNearestNodeToPosition(base.soldier.transform.position);
        werewolf.SetPathIndex((int) &vector.x);
        werewolf.SetSubPath((int) &vector.y);
        werewolf.SetCurrentNode((int) &vector.z);
        werewolf.SetActive(1);
        werewolf.roadNodesTillActive = 0;
        if (&base.soldier.transform.localScale.x != -1f)
        {
            goto Label_0176;
        }
        werewolf.transform.localScale = new Vector3(-1f, 1f, 1f);
    Label_0176:
        base.soldier.Eat();
    Label_0181:
        return;
    }

    protected override void InitCustomSettings()
    {
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        base.regenerateTimeCounter = 0;
        base.regenerateTime = 8;
        base.regenerateHealPoints = 4;
        this.disableLycantrophyNodes = 50;
        this.spreadLycantrophyCurseChance = 0.2f;
        base.life = 700 + this.lifeRemaining;
        if ((base.soldier != null) == null)
        {
            goto Label_0072;
        }
        this.Block(base.soldier);
        this.StartFighting();
    Label_0072:
        return;
    }
}

