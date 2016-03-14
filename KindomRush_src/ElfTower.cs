using System;
using System.Collections;
using UnityEngine;

public class ElfTower : BarrackTower
{
    public ElfTower()
    {
        base..ctor();
        return;
    }

    public override void Activate()
    {
        GameObject obj2;
        base.isActive = 1;
        base.sprite.PlayAnim("active");
        obj2 = GameObject.Find("Stage");
        if ((obj2 != null) == null)
        {
            goto Label_0045;
        }
        if ((obj2.GetComponent<Stage22>() == null) == null)
        {
            goto Label_0045;
        }
        base.ShowUpgradeSmoke();
    Label_0045:
        return;
    }

    public unsafe void AddElf()
    {
        Transform transform;
        SoldierElf elf;
        Vector3 vector;
        int num;
        int num2;
        SoldierElf elf2;
        IEnumerator enumerator;
        Vector2 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        IDisposable disposable;
        GameSoundManager.PlayElfTaunt();
        transform = UnityEngine.Object.Instantiate(base.soldierPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        elf = transform.GetComponent<SoldierElf>();
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) base.yPositionAdjust), &base.transform.position.z);
        elf.SetSpawnPosition(vector);
        elf.SetTower(this);
        base.soldiers.Add(elf);
        base.stage.AddSoldier(elf);
        num = Mathf.RoundToInt(360f / ((float) base.soldiers.Count));
        num2 = 0;
        enumerator = base.soldiers.GetEnumerator();
    Label_00D8:
        try
        {
            goto Label_0138;
        Label_00DD:
            elf2 = (SoldierElf) enumerator.Current;
            vector2 = IronUtils.ellipseGetPointOfDegree((float) num2, 48f, 90f, new Vector2(&this.rallyPoint.x, &this.rallyPoint.y - 12f));
            elf2.ChangeRallyPointOnly(vector2);
            elf2.SetRangeCenterPosition(vector2);
            num2 += num;
        Label_0138:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00DD;
            }
            goto Label_015F;
        }
        finally
        {
        Label_0149:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0157;
            }
        Label_0157:
            disposable.Dispose();
        }
    Label_015F:
        if (base.soldiers.Count != 4)
        {
            goto Label_0175;
        }
        GameAchievements.CheckMaxElves();
    Label_0175:
        return;
    }

    private unsafe void Awake()
    {
        Transform transform;
        StageBase.terrainType type;
        Transform transform2;
        Transform transform3;
        Transform transform4;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if ((base.overPrefab != null) == null)
        {
            goto Label_0086;
        }
        transform = UnityEngine.Object.Instantiate(base.overPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -1f) + new Vector3(0f, (float) base.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        base.over = transform.GetComponent<PackedSprite>();
    Label_0086:
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        base.towerClickable = base.GetComponent<TowerBasicClickable>();
        base.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        type = base.stage.GetTerrainType();
        if (type != null)
        {
            goto Label_0179;
        }
        if ((base.grassTerrain != null) == null)
        {
            goto Label_0179;
        }
        transform2 = UnityEngine.Object.Instantiate(base.grassTerrain, new Vector3(&base.transform.position.x, &base.transform.position.y, 0f) + new Vector3(0f, (float) base.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        transform2.name = "terrain";
        base.terrain = transform2.GetComponent<PackedSprite>();
        goto Label_028F;
    Label_0179:
        if (type != 1)
        {
            goto Label_0205;
        }
        transform3 = UnityEngine.Object.Instantiate(base.iceTerrain, new Vector3(&base.transform.position.x, &base.transform.position.y, 0f) + new Vector3(0f, (float) base.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        transform3.name = "terrain";
        base.terrain = transform3.GetComponent<PackedSprite>();
        goto Label_028F;
    Label_0205:
        if (type != 2)
        {
            goto Label_028F;
        }
        transform4 = UnityEngine.Object.Instantiate(base.wastelandTerrain, new Vector3(&base.transform.position.x, &base.transform.position.y, 0f) + new Vector3(0f, (float) base.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        transform4.name = "terrain";
        base.terrain = transform4.GetComponent<PackedSprite>();
    Label_028F:
        base.sprite = base.GetComponent<PackedSprite>();
        base.isActive = 0;
        return;
    }

    public override void BeginFire()
    {
    }

    protected override unsafe bool ChangeRallyPoint(Vector2 newPosition)
    {
        int num;
        int num2;
        SoldierElf elf;
        IEnumerator enumerator;
        Vector2 vector;
        IDisposable disposable;
        if (base.CanChangeRallyPoint(newPosition) != null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        if (base.soldiers.Count != null)
        {
            goto Label_0020;
        }
        return 1;
    Label_0020:
        base.rallyPoint = newPosition;
        num = 0;
        num2 = Mathf.RoundToInt(360f / ((float) base.soldiers.Count));
        enumerator = base.soldiers.GetEnumerator();
    Label_004D:
        try
        {
            goto Label_00A6;
        Label_0052:
            elf = (SoldierElf) enumerator.Current;
            vector = IronUtils.ellipseGetPointOfDegree((float) num, 48f, 90f, new Vector2(&this.rallyPoint.x, &this.rallyPoint.y - 12f));
            elf.ChangeRallyPoint(vector);
            elf.SetRangeCenterPosition(vector);
            num += num2;
        Label_00A6:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0052;
            }
            goto Label_00CB;
        }
        finally
        {
        Label_00B6:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00C3;
            }
        Label_00C3:
            disposable.Dispose();
        }
    Label_00CB:
        this.PlayRallyPointMoveSound();
        return 1;
    }

    public int GetElfCount()
    {
        return base.soldiers.Count;
    }

    protected override void PlayRallyPointMoveSound()
    {
        GameSoundManager.PlayElfTaunt();
        return;
    }

    public void RemoveElf(SoldierElf elf)
    {
        base.soldiers.Remove(elf);
        base.stage.RemoveSoldier(elf);
        return;
    }

    private void Start()
    {
        base.soldiers = new ArrayList();
        base.doorStatus = 2;
        base.rallyRangeWidth = base.rangeRally;
        base.rallyRangeHeight = Mathf.CeilToInt(((float) base.rangeRally) * 0.7f);
        return;
    }
}

