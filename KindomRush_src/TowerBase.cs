using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    protected BlackburnBlock blackburnBlock;
    public Transform blackburnBlockPrefab;
    public BuildTerrainClickable buildTerrain;
    public bool canBeBuff;
    public Transform grassTerrain;
    protected GUIBottom guiBottom;
    public Transform iceTerrain;
    protected bool isActive;
    protected bool isPaused;
    public int maxDamage;
    public int minDamange;
    public bool muteInitTaunt;
    protected PackedSprite over;
    public Transform overPrefab;
    public int price;
    public Vector2 rallyPoint;
    public int range;
    protected Transform rangeCircle;
    public Transform rangeCirclePrefab;
    public float reload;
    public Transform smokeConstructionPrefab;
    public Transform smokeSellPrefab;
    protected CreepSpawner spawner;
    protected int spent;
    protected StageBase stage;
    public states state;
    protected Creep target;
    protected PackedSprite terrain;
    public int terrainOffsetY;
    protected float timerReload;
    protected TowerBasicClickable towerClickable;
    protected VeznanBlock veznanBlock;
    public Transform veznanBlockPrefab;
    protected bool wasAnimating;
    public Transform wastelandTerrain;
    protected float xDest;
    public int yAdjust;
    public int yAdjustBuff;
    protected float yDest;
    public int yRangeAdjust;

    protected TowerBase()
    {
        this.isActive = 1;
        this.canBeBuff = 1;
        base..ctor();
        return;
    }

    public virtual void Activate()
    {
        base.gameObject.SetActive(1);
        return;
    }

    public void AddRangeModifier(int r)
    {
        this.range += r;
        return;
    }

    public void AddReloadModifier(float time)
    {
        this.reload -= time;
        return;
    }

    private unsafe void Awake()
    {
        Transform transform;
        StageBase.terrainType type;
        Transform transform2;
        Transform transform3;
        Transform transform4;
        Stage22 stage;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        if ((this.overPrefab != null) == null)
        {
            goto Label_0086;
        }
        transform = UnityEngine.Object.Instantiate(this.overPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -1f) + new Vector3(0f, (float) this.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        this.over = transform.GetComponent<PackedSprite>();
    Label_0086:
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.towerClickable = base.GetComponent<TowerBasicClickable>();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        type = this.stage.GetTerrainType();
        if (type != null)
        {
            goto Label_0179;
        }
        if ((this.grassTerrain != null) == null)
        {
            goto Label_0179;
        }
        transform2 = UnityEngine.Object.Instantiate(this.grassTerrain, new Vector3(&base.transform.position.x, &base.transform.position.y, 0f) + new Vector3(0f, (float) this.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        transform2.name = "terrain";
        this.terrain = transform2.GetComponent<PackedSprite>();
        goto Label_028F;
    Label_0179:
        if (type != 1)
        {
            goto Label_0205;
        }
        transform3 = UnityEngine.Object.Instantiate(this.iceTerrain, new Vector3(&base.transform.position.x, &base.transform.position.y, 0f) + new Vector3(0f, (float) this.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        transform3.name = "terrain";
        this.terrain = transform3.GetComponent<PackedSprite>();
        goto Label_028F;
    Label_0205:
        if (type != 2)
        {
            goto Label_028F;
        }
        transform4 = UnityEngine.Object.Instantiate(this.wastelandTerrain, new Vector3(&base.transform.position.x, &base.transform.position.y, 0f) + new Vector3(0f, (float) this.terrainOffsetY, 0f), base.transform.rotation) as Transform;
        transform4.name = "terrain";
        this.terrain = transform4.GetComponent<PackedSprite>();
    Label_028F:
        if ((this.stage.GetComponent<Stage22>() != null) == null)
        {
            goto Label_02C8;
        }
        this.blackburnBlockPrefab = Resources.Load("Prefabs/Blackburn Block", typeof(Transform)) as Transform;
    Label_02C8:
        return;
    }

    public abstract void BeginFire();
    public unsafe void BlackburnBlockTower()
    {
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, &base.transform.position.z - 1f);
        transform = UnityEngine.Object.Instantiate(this.blackburnBlockPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.blackburnBlock = transform.GetComponent<BlackburnBlock>();
        this.blackburnBlock.SetTower(this);
        this.SetActive(0, 0);
        return;
    }

    public Creep CheckRange(float range, Vector3 position)
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        IDisposable disposable;
        creep = null;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_0098;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            if (creep2.IsActive() == null)
            {
                goto Label_0098;
            }
            if (creep2.IsDead() != null)
            {
                goto Label_0098;
            }
            if (IronUtils.ellipseContainPoint(transform.position, range * 0.7f, range, position + new Vector3(0f, (float) -(this.yAdjust + this.yRangeAdjust), 0f)) == null)
            {
                goto Label_0098;
            }
            if ((creep == null) != null)
            {
                goto Label_0096;
            }
            if (this.IsNearExit(creep, creep2) == null)
            {
                goto Label_0098;
            }
        Label_0096:
            creep = creep2;
        Label_0098:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00BD;
        }
        finally
        {
        Label_00A8:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00B5;
            }
        Label_00B5:
            disposable.Dispose();
        }
    Label_00BD:
        return creep;
    }

    public void DestroyTerrain()
    {
        UnityEngine.Object.Destroy(this.terrain.gameObject);
        if ((this.over != null) == null)
        {
            goto Label_0031;
        }
        UnityEngine.Object.Destroy(this.over.gameObject);
    Label_0031:
        return;
    }

    public void DettachProjectiles()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0035;
        Label_0011:
            transform = (Transform) enumerator.Current;
            if ((transform.GetComponent<BaseProjectile>() != null) == null)
            {
                goto Label_0035;
            }
            transform.parent = null;
        Label_0035:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0057;
        }
        finally
        {
        Label_0045:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0050;
            }
        Label_0050:
            disposable.Dispose();
        }
    Label_0057:
        return;
    }

    private void EnableCollider()
    {
        base.collider.enabled = 1;
        return;
    }

    private void FixedUpdate()
    {
    }

    public BuildTerrainClickable GetBuildTerrain()
    {
        return this.buildTerrain;
    }

    public Vector2 GetRallyPoint()
    {
        return this.rallyPoint;
    }

    public string GetRange()
    {
        if (this.range < 0)
        {
            goto Label_0022;
        }
        if (this.range >= 0x1c3)
        {
            goto Label_0022;
        }
        return "Short";
    Label_0022:
        if (this.range < 0x1c3)
        {
            goto Label_0048;
        }
        if (this.range >= 0x1fc)
        {
            goto Label_0048;
        }
        return "Average";
    Label_0048:
        if (this.range < 0x1fc)
        {
            goto Label_006E;
        }
        if (this.range >= 0x234)
        {
            goto Label_006E;
        }
        return "Long";
    Label_006E:
        if (this.range < 0x234)
        {
            goto Label_0094;
        }
        if (this.range >= 0x289)
        {
            goto Label_0094;
        }
        return "Great";
    Label_0094:
        if (this.range < 0x289)
        {
            goto Label_00AA;
        }
        return "Extreme";
    Label_00AA:
        return string.Empty;
    }

    public int GetRangeModifier(int percent)
    {
        return ((percent * this.range) / 100);
    }

    public string GetReload()
    {
        if (this.reload < 0f)
        {
            goto Label_0026;
        }
        if (this.reload >= 0.5f)
        {
            goto Label_0026;
        }
        return "Very Fast";
    Label_0026:
        if (this.reload < 0.5f)
        {
            goto Label_004C;
        }
        if (this.reload >= 0.8f)
        {
            goto Label_004C;
        }
        return "Fast";
    Label_004C:
        if (this.reload < 0.8f)
        {
            goto Label_0072;
        }
        if (this.reload >= 1.5f)
        {
            goto Label_0072;
        }
        return "Average";
    Label_0072:
        if (this.reload < 1.5f)
        {
            goto Label_0098;
        }
        if (this.reload >= 2f)
        {
            goto Label_0098;
        }
        return "Slow";
    Label_0098:
        if (this.reload < 2f)
        {
            goto Label_00AE;
        }
        return "Very Slow";
    Label_00AE:
        return string.Empty;
    }

    public float GetReloadModifier(float percent)
    {
        return ((percent * this.reload) / 100f);
    }

    public virtual int GetReturnValue()
    {
        return Mathf.RoundToInt(((float) this.spent) * 0.6f);
    }

    public int GetSpent()
    {
        return this.spent;
    }

    public states GetState()
    {
        return this.state;
    }

    public float GetTimerReload()
    {
        return this.timerReload;
    }

    public void HideMouseOver()
    {
        if ((this.over != null) == null)
        {
            goto Label_001D;
        }
        this.over.Hide(1);
    Label_001D:
        return;
    }

    public void HideRangeCircle()
    {
        if ((this.rangeCircle != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.rangeCircle.gameObject);
    Label_0021:
        return;
    }

    public bool IsActive()
    {
        return this.isActive;
    }

    public bool IsNearExit(Creep enemy, Creep enemyNew)
    {
        if ((enemy.GetSubPathCount() - enemy.GetCurrentNodeIndex()) <= (enemyNew.GetSubPathCount() - enemyNew.GetCurrentNodeIndex()))
        {
            goto Label_0021;
        }
        return 1;
    Label_0021:
        return 0;
    }

    public virtual bool IsRallySelected()
    {
        return 0;
    }

    protected virtual unsafe void LookForTarget(float range)
    {
        Creep creep;
        Transform transform;
        IEnumerator enumerator;
        Creep creep2;
        Vector3 vector;
        IDisposable disposable;
        Vector3 vector2;
        Vector3 vector3;
        creep = null;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_00C5;
        Label_0018:
            transform = (Transform) enumerator.Current;
            creep2 = transform.GetComponent<Creep>();
            vector = creep2.transform.position + new Vector3(&creep2.anchorPoint.x, &creep2.anchorPoint.y, 0f);
            if (creep2.IsActive() == null)
            {
                goto Label_00C5;
            }
            if (IronUtils.ellipseContainPoint(vector, range * 0.7f, range, base.transform.position + new Vector3(0f, (float) -(this.yAdjust + this.yRangeAdjust), 0f)) == null)
            {
                goto Label_00C5;
            }
            if ((creep == null) != null)
            {
                goto Label_00C3;
            }
            if (this.IsNearExit(creep, creep2) == null)
            {
                goto Label_00C5;
            }
        Label_00C3:
            creep = creep2;
        Label_00C5:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_00EA;
        }
        finally
        {
        Label_00D5:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E2;
            }
        Label_00E2:
            disposable.Dispose();
        }
    Label_00EA:
        if ((creep != null) == null)
        {
            goto Label_0137;
        }
        this.xDest = &creep.transform.position.x;
        this.yDest = &creep.transform.position.y;
        this.target = creep;
        this.BeginFire();
    Label_0137:
        return;
    }

    protected void OnMouseEnter()
    {
        GameSoundManager.PlayGUIQuickMenuOver();
        if ((this.over != null) == null)
        {
            goto Label_0032;
        }
        if (this.guiBottom.IsHeroSelected() != null)
        {
            goto Label_0032;
        }
        this.over.Hide(0);
    Label_0032:
        return;
    }

    protected void OnMouseExit()
    {
        if ((this.over != null) == null)
        {
            goto Label_002D;
        }
        if (this.towerClickable.IsSelected() != null)
        {
            goto Label_002D;
        }
        this.over.Hide(1);
    Label_002D:
        return;
    }

    public virtual void Pause()
    {
    }

    public void RemoveRangeModifier(int r)
    {
        this.range -= r;
        return;
    }

    public void RemoveReloadModifier(float time)
    {
        this.reload += time;
        return;
    }

    protected void ResetReload()
    {
        this.timerReload = 0f;
        this.state = 0;
        return;
    }

    public virtual void Sell()
    {
        this.DettachProjectiles();
        UnityEngine.Object.Instantiate(this.smokeSellPrefab, base.transform.position, Quaternion.identity);
        this.stage.AddGold((int) (((float) this.spent) * 0.6f));
        UnityEngine.Object.Destroy(this.terrain.gameObject);
        if ((this.over != null) == null)
        {
            goto Label_006C;
        }
        UnityEngine.Object.Destroy(this.over.gameObject);
    Label_006C:
        this.buildTerrain.gameObject.SetActive(1);
        this.stage.AddSellTowerAchievement();
        GameSoundManager.PlayTowerSell();
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    public void SetActive(bool a, bool hide = true)
    {
        Transform transform;
        IEnumerator enumerator;
        Transform transform2;
        IEnumerator enumerator2;
        Quickmenu quickmenu;
        Clickable clickable;
        IDisposable disposable;
        IDisposable disposable2;
        this.isActive = a;
        if (this.isActive == null)
        {
            goto Label_008C;
        }
        base.GetComponent<PackedSprite>().Hide(0);
        base.GetComponent<PackedSprite>().RevertToStatic();
        base.Invoke("EnableCollider", 0.4f);
        enumerator = base.transform.GetEnumerator();
    Label_0045:
        try
        {
            goto Label_0062;
        Label_004A:
            transform = (Transform) enumerator.Current;
            transform.gameObject.SetActive(1);
        Label_0062:
            if (enumerator.MoveNext() != null)
            {
                goto Label_004A;
            }
            goto Label_0087;
        }
        finally
        {
        Label_0072:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007F;
            }
        Label_007F:
            disposable.Dispose();
        }
    Label_0087:
        goto Label_0145;
    Label_008C:
        if (hide == null)
        {
            goto Label_00EC;
        }
        base.GetComponent<PackedSprite>().Hide(1);
        enumerator2 = base.transform.GetEnumerator();
    Label_00AA:
        try
        {
            goto Label_00C7;
        Label_00AF:
            transform2 = (Transform) enumerator2.Current;
            transform2.gameObject.SetActive(0);
        Label_00C7:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_00AF;
            }
            goto Label_00EC;
        }
        finally
        {
        Label_00D7:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_00E4;
            }
        Label_00E4:
            disposable2.Dispose();
        }
    Label_00EC:
        this.HideRangeCircle();
        base.collider.enabled = 0;
        quickmenu = GameObject.Find("Quickmenu").GetComponent<Quickmenu>();
        clickable = quickmenu.GetCurrentSelect();
        if ((clickable != null) == null)
        {
            goto Label_0145;
        }
        if ((clickable.GetComponent<TowerBase>() == this) == null)
        {
            goto Label_0145;
        }
        quickmenu.HideUpgradeRanges();
        quickmenu.Hide();
    Label_0145:
        return;
    }

    public unsafe void SetBuildTerrain(BuildTerrainClickable bt)
    {
        this.buildTerrain = bt;
        &this.rallyPoint.x = &bt.rallyPoint.x;
        &this.rallyPoint.y = &bt.rallyPoint.y;
        return;
    }

    public void SetPrice(int p)
    {
        this.price = p;
        return;
    }

    public unsafe void SetRallyPoint(float x, float y)
    {
        &this.rallyPoint.Set(x, y);
        return;
    }

    public void SetSpent(int s)
    {
        this.spent += s;
        this.stage.RemoveGold(s);
        return;
    }

    public void SetSpentBase(int s)
    {
        this.spent = s;
        return;
    }

    public void SetState(states s)
    {
        this.state = s;
        return;
    }

    public void SetTimerReload(float f)
    {
        this.timerReload = f;
        return;
    }

    public unsafe Transform ShowRangeCircle(Vector3 pos)
    {
        Vector3 vector;
        Vector3 vector2;
        if ((this.rangeCirclePrefab != null) == null)
        {
            goto Label_0105;
        }
        if ((pos != Vector3.zero) == null)
        {
            goto Label_0059;
        }
        this.rangeCircle = UnityEngine.Object.Instantiate(this.rangeCirclePrefab, new Vector3(&pos.x, &pos.y, -839f), Quaternion.identity) as Transform;
        goto Label_00B3;
    Label_0059:
        this.rangeCircle = UnityEngine.Object.Instantiate(this.rangeCirclePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - ((float) (this.yAdjust + this.yRangeAdjust)), -839f), Quaternion.identity) as Transform;
    Label_00B3:
        this.range = GameSettings.GetTowerRange(base.transform.name);
        this.rangeCircle.localScale = new Vector3(((float) this.range) / 385f, (((float) this.range) * 0.7f) / 385f, 1f);
        return this.rangeCircle;
    Label_0105:
        return null;
    }

    public unsafe void ShowUpgradeSmoke()
    {
        Vector3 vector;
        Vector3 vector2;
        UnityEngine.Object.Instantiate(this.smokeConstructionPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 32f, -900f), Quaternion.identity);
        this.guiBottom.SetSelected(base.GetComponent<UnitClickable>());
        this.guiBottom.HideInfo(base.GetComponent<UnitClickable>());
        return;
    }

    private void Start()
    {
    }

    public virtual void Unpause()
    {
    }

    public unsafe void VeznanBlockTower()
    {
        Vector3 vector;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, &base.transform.position.z - 1f);
        transform = UnityEngine.Object.Instantiate(this.veznanBlockPrefab, vector, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.veznanBlock = transform.GetComponent<VeznanBlock>();
        this.veznanBlock.SetTower(this);
        this.SetActive(0, 0);
        return;
    }

    public enum states
    {
        IDLE,
        FIRING,
        RELOADING
    }
}

