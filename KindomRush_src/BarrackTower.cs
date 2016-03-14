using System;
using System.Collections;
using UnityEngine;

public class BarrackTower : TowerBase
{
    public int armor;
    protected doorState doorStatus;
    public int doorTime;
    protected int doorTimeCounter;
    public int doorToCloseTime;
    public int doorToOpenTime;
    public Vector2 globalOffset;
    public int health;
    protected int maxSoldiers;
    protected Transform rallyCircle;
    public Transform rallyCirclePrefab;
    public Transform rallyFeedbackPrefab;
    protected PackedSprite rallyPointCursor;
    public Transform rallyPointCursorPrefab;
    protected int rallyRangeHeight;
    protected int rallyRangeWidth;
    protected bool rallySelect;
    public int rangeRally;
    public int regen;
    public int regenReload;
    public int respawn;
    protected bool selected;
    public Transform soldierPrefab;
    protected ArrayList soldiers;
    protected PackedSprite sprite;
    public int yPositionAdjust;

    public BarrackTower()
    {
        this.doorTime = 0x19;
        this.doorToOpenTime = 12;
        this.doorToCloseTime = 0x16;
        this.maxSoldiers = 3;
        this.globalOffset = Vector2.zero;
        base..ctor();
        return;
    }

    public void AddSoldier(Soldier s)
    {
        if (this.soldiers != null)
        {
            goto Label_0016;
        }
        this.soldiers = new ArrayList();
    Label_0016:
        this.soldiers.Add(s);
        return;
    }

    public void AddSoldiersToStage()
    {
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.soldiers.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0029;
        Label_0011:
            soldier = (Soldier) enumerator.Current;
            base.stage.AddSoldier(soldier);
        Label_0029:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004B;
        }
        finally
        {
        Label_0039:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0044;
            }
        Label_0044:
            disposable.Dispose();
        }
    Label_004B:
        return;
    }

    public override void BeginFire()
    {
    }

    protected unsafe bool CanChangeRallyPoint(Vector2 newPosition)
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (IronUtils.ellipseContainPoint(newPosition, (float) this.rallyRangeHeight, (float) this.rallyRangeWidth, new Vector3(&base.transform.position.x, &base.transform.position.y - 25f, &base.transform.position.z)) != null)
        {
            goto Label_0066;
        }
        return 0;
    Label_0066:
        vectorArray = base.stage.GetPath();
        num = 0;
        goto Label_0108;
    Label_0079:
        num2 = 0;
        goto Label_00F7;
    Label_0080:
        if (base.stage.StageHasTunnels() == null)
        {
            goto Label_009D;
        }
        if (this.OnTunnel(num, num2) != null)
        {
            goto Label_00F3;
        }
    Label_009D:
        if (Mathf.Sqrt(Mathf.Pow(&(vectorArray[num][0][num2]).y - &newPosition.y, 2f) + Mathf.Pow(&(vectorArray[num][0][num2]).x - &newPosition.x, 2f)) >= 60f)
        {
            goto Label_00F3;
        }
        return 1;
    Label_00F3:
        num2 += 1;
    Label_00F7:
        if (num2 < ((int) vectorArray[num][0].Length))
        {
            goto Label_0080;
        }
        num += 1;
    Label_0108:
        if (num < ((int) vectorArray.Length))
        {
            goto Label_0079;
        }
        return 0;
    }

    protected virtual unsafe bool ChangeRallyPoint(Vector2 newPosition)
    {
        int num;
        Soldier soldier;
        IEnumerator enumerator;
        Vector2 vector;
        IDisposable disposable;
        if (this.CanChangeRallyPoint(newPosition) != null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        base.rallyPoint = newPosition;
        num = 0;
        enumerator = this.soldiers.GetEnumerator();
    Label_0023:
        try
        {
            goto Label_0079;
        Label_0028:
            soldier = (Soldier) enumerator.Current;
            vector = IronUtils.ellipseGetPointOfDegree((float) num, 48f, 75f, new Vector2(&this.rallyPoint.x, &this.rallyPoint.y));
            soldier.SetRangeCenterPosition(base.rallyPoint);
            soldier.ChangeRallyPoint(vector);
            num += 120;
        Label_0079:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0028;
            }
            goto Label_009E;
        }
        finally
        {
        Label_0089:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0096;
            }
        Label_0096:
            disposable.Dispose();
        }
    Label_009E:
        this.PlayRallyPointMoveSound();
        return 1;
    }

    protected void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.isActive == null)
        {
            goto Label_0083;
        }
        if (this.doorStatus == 2)
        {
            goto Label_0083;
        }
        if (this.doorTimeCounter >= this.doorTime)
        {
            goto Label_007C;
        }
        if (this.doorTimeCounter != this.doorToOpenTime)
        {
            goto Label_0051;
        }
        this.doorStatus = 0;
        goto Label_0069;
    Label_0051:
        if (this.doorTimeCounter <= this.doorToCloseTime)
        {
            goto Label_0069;
        }
        this.doorStatus = 3;
    Label_0069:
        this.doorTimeCounter += 1;
        goto Label_0083;
    Label_007C:
        this.doorStatus = 2;
    Label_0083:
        return;
    }

    public int GetDoorTimeCounter()
    {
        return this.doorTimeCounter;
    }

    public ArrayList GetSoldiers()
    {
        return this.soldiers;
    }

    public bool IsDoorClosed()
    {
        return (this.doorStatus == 2);
    }

    public bool IsDoorOpening()
    {
        return (this.doorStatus == 1);
    }

    public override bool IsRallySelected()
    {
        return this.rallySelect;
    }

    protected bool OnTunnel(int i, int j)
    {
        if (base.stage.HasTunnels(i) == null)
        {
            goto Label_0037;
        }
        if (j < base.stage.TunnelStart(i))
        {
            goto Label_0037;
        }
        if (j > base.stage.TunnelEnd(i))
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        return 0;
    }

    public void OpenDoor()
    {
        if (this.doorStatus != 2)
        {
            goto Label_0055;
        }
        GameSoundManager.PlayGUITowerOpenDoor();
        this.doorStatus = 1;
        if ((this.sprite != null) == null)
        {
            goto Label_004E;
        }
        if (this.sprite.GetAnim("open") == null)
        {
            goto Label_004E;
        }
        this.sprite.PlayAnim("open");
    Label_004E:
        this.doorTimeCounter = 0;
    Label_0055:
        return;
    }

    public override void Pause()
    {
        Soldier soldier;
        IEnumerator enumerator;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 1;
        base.wasAnimating = this.sprite.IsAnimating();
        this.sprite.PauseAnim();
        enumerator = this.soldiers.GetEnumerator();
    Label_002F:
        try
        {
            goto Label_0046;
        Label_0034:
            soldier = (Soldier) enumerator.Current;
            soldier.Pause();
        Label_0046:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0034;
            }
            goto Label_0068;
        }
        finally
        {
        Label_0056:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0061;
            }
        Label_0061:
            disposable.Dispose();
        }
    Label_0068:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_0081;
        }
        denas.Pause();
    Label_0081:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_009D;
        }
        base.veznanBlock.Pause();
    Label_009D:
        return;
    }

    protected virtual void PlayRallyPointMoveSound()
    {
        GameSoundManager.PlayBarrackTaunt();
        return;
    }

    public unsafe void Rally()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        this.rallySelect = 1;
        Screen.showCursor = 0;
        this.rallyCircle = UnityEngine.Object.Instantiate(this.rallyCirclePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 25f, -839f), Quaternion.identity) as Transform;
        this.rallyCircle.localScale = new Vector3(((float) this.rangeRally) / 385f, (((float) this.rangeRally) * 0.7f) / 385f, 1f);
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, -800f);
        this.rallyPointCursor = ((Transform) UnityEngine.Object.Instantiate(this.rallyPointCursorPrefab, vector, Quaternion.identity)).GetComponent<PackedSprite>();
        base.stage.DisableTowers();
        base.stage.IgnoreHeroClick();
        return;
    }

    public void RemoveSoldier(Soldier s)
    {
        this.soldiers.Remove(s);
        return;
    }

    public void RemoveSoldiersFromStage()
    {
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.soldiers.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0029;
        Label_0011:
            soldier = (Soldier) enumerator.Current;
            base.stage.RemoveSoldier(soldier);
        Label_0029:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004B;
        }
        finally
        {
        Label_0039:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0044;
            }
        Label_0044:
            disposable.Dispose();
        }
    Label_004B:
        return;
    }

    public void SelectSoldiers()
    {
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        this.selected = 1;
        enumerator = this.soldiers.GetEnumerator();
    Label_0013:
        try
        {
            goto Label_002F;
        Label_0018:
            soldier = (Soldier) enumerator.Current;
            soldier.GetComponent<UnitClickable>().Select();
        Label_002F:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0018;
            }
            goto Label_0051;
        }
        finally
        {
        Label_003F:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_004A;
            }
        Label_004A:
            disposable.Dispose();
        }
    Label_0051:
        return;
    }

    public override void Sell()
    {
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        UnityEngine.Object.Instantiate(base.smokeSellPrefab, base.transform.position, Quaternion.identity);
        this.RemoveSoldiersFromStage();
        enumerator = this.soldiers.GetEnumerator();
    Label_002E:
        try
        {
            goto Label_004A;
        Label_0033:
            soldier = (Soldier) enumerator.Current;
            UnityEngine.Object.Destroy(soldier.gameObject);
        Label_004A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0033;
            }
            goto Label_006C;
        }
        finally
        {
        Label_005A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0065;
            }
        Label_0065:
            disposable.Dispose();
        }
    Label_006C:
        base.stage.AddGold((int) (((float) base.spent) * 0.6f));
        UnityEngine.Object.Destroy(base.terrain.gameObject);
        UnityEngine.Object.Destroy(base.gameObject);
        base.buildTerrain.gameObject.SetActive(1);
        base.stage.AddSellTowerAchievement();
        GameSoundManager.PlayTowerSell();
        return;
    }

    protected void SetRallyOff()
    {
        UnityEngine.Object.Destroy(this.rallyPointCursor.gameObject);
        UnityEngine.Object.Destroy(this.rallyCircle.gameObject);
        this.rallySelect = 0;
        Screen.showCursor = 1;
        this.UnselectSoldiers();
        return;
    }

    public void SetSoldiers(ArrayList s)
    {
        this.soldiers = s;
        return;
    }

    protected unsafe void SpawnSoldiers()
    {
        Transform transform;
        Vector3 vector;
        int num;
        int num2;
        Soldier soldier;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.soldiers != null)
        {
            goto Label_0143;
        }
        if ((this.sprite != null) == null)
        {
            goto Label_002C;
        }
        this.sprite.PlayAnim("open");
    Label_002C:
        this.soldiers = new ArrayList();
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y + ((float) this.yPositionAdjust), &base.transform.position.z);
        num = 0;
        num2 = 0;
        goto Label_0137;
    Label_008B:
        transform = UnityEngine.Object.Instantiate(this.soldierPrefab, vector, Quaternion.identity) as Transform;
        soldier = transform.GetComponent<Soldier>();
        soldier.SetSpawnPosition(vector);
        soldier.SetTower(this);
        soldier.ChangeRallyPoint(IronUtils.ellipseGetPointOfDegree((float) num, 48f, 75f, new Vector2(&this.rallyPoint.x, &this.rallyPoint.y - 10f)));
        soldier.SetRangeCenterPosition(base.rallyPoint - new Vector2(0f, 10f));
        soldier.SetRandomName();
        this.soldiers.Add(soldier);
        num += 120;
        num2 += 1;
    Label_0137:
        if (num2 < this.maxSoldiers)
        {
            goto Label_008B;
        }
    Label_0143:
        return;
    }

    private void Start()
    {
        int num;
        this.doorStatus = 2;
        this.sprite = base.GetComponent<PackedSprite>();
        if (base.name.EndsWith("1") == null)
        {
            goto Label_00BA;
        }
        this.rallyRangeWidth = this.rangeRally = (int) GameSettings.GetTowerSetting("barrack_level1", "rangeRally");
        base.minDamange = (int) GameSettings.GetTowerSetting("barrack_level1", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("barrack_level1", "maxDamage");
        this.respawn = (int) GameSettings.GetTowerSetting("barrack_level1", "respawn");
        this.health = (int) GameSettings.GetTowerSetting("barrack_level1", "health");
        this.armor = (int) GameSettings.GetTowerSetting("barrack_level1", "armor");
        goto Label_0203;
    Label_00BA:
        if (base.name.EndsWith("2") == null)
        {
            goto Label_0161;
        }
        this.rallyRangeWidth = this.rangeRally = (int) GameSettings.GetTowerSetting("barrack_level2", "rangeRally");
        base.minDamange = (int) GameSettings.GetTowerSetting("barrack_level2", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("barrack_level2", "maxDamage");
        this.respawn = (int) GameSettings.GetTowerSetting("barrack_level2", "respawn");
        this.health = (int) GameSettings.GetTowerSetting("barrack_level2", "health");
        this.armor = (int) GameSettings.GetTowerSetting("barrack_level2", "armor");
        goto Label_0203;
    Label_0161:
        if (base.name.EndsWith("3") == null)
        {
            goto Label_0203;
        }
        this.rallyRangeWidth = this.rangeRally = (int) GameSettings.GetTowerSetting("barrack_level3", "rangeRally");
        base.minDamange = (int) GameSettings.GetTowerSetting("barrack_level3", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("barrack_level3", "maxDamage");
        this.respawn = (int) GameSettings.GetTowerSetting("barrack_level3", "respawn");
        this.health = (int) GameSettings.GetTowerSetting("barrack_level3", "health");
        this.armor = (int) GameSettings.GetTowerSetting("barrack_level3", "armor");
    Label_0203:
        this.rallyRangeHeight = Mathf.CeilToInt(((float) this.rallyRangeWidth) * 0.7f);
        this.SpawnSoldiers();
        this.AddSoldiersToStage();
        if (base.muteInitTaunt != null)
        {
            goto Label_0237;
        }
        GameSoundManager.PlayBarrackTaunt();
    Label_0237:
        return;
    }

    public override void Unpause()
    {
        Soldier soldier;
        IEnumerator enumerator;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 0;
        if (base.wasAnimating == null)
        {
            goto Label_001D;
        }
        this.sprite.UnpauseAnim();
    Label_001D:
        enumerator = this.soldiers.GetEnumerator();
    Label_0029:
        try
        {
            goto Label_0040;
        Label_002E:
            soldier = (Soldier) enumerator.Current;
            soldier.Unpause();
        Label_0040:
            if (enumerator.MoveNext() != null)
            {
                goto Label_002E;
            }
            goto Label_0062;
        }
        finally
        {
        Label_0050:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_005B;
            }
        Label_005B:
            disposable.Dispose();
        }
    Label_0062:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_007B;
        }
        denas.Unpause();
    Label_007B:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_0097;
        }
        base.veznanBlock.Unpause();
    Label_0097:
        return;
    }

    public void UnselectSoldiers()
    {
        Soldier soldier;
        IEnumerator enumerator;
        IDisposable disposable;
        if (this.selected == null)
        {
            goto Label_005C;
        }
        this.selected = 0;
        enumerator = this.soldiers.GetEnumerator();
    Label_001E:
        try
        {
            goto Label_003A;
        Label_0023:
            soldier = (Soldier) enumerator.Current;
            soldier.GetComponent<UnitClickable>().UnSelect();
        Label_003A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0023;
            }
            goto Label_005C;
        }
        finally
        {
        Label_004A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0055;
            }
        Label_0055:
            disposable.Dispose();
        }
    Label_005C:
        return;
    }

    protected unsafe void Update()
    {
        Camera camera;
        Vector3 vector;
        Vector2 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.rallySelect == null)
        {
            goto Label_01AF;
        }
        if (Input.GetKeyDown(0x31) != null)
        {
            goto Label_002F;
        }
        if (Input.GetKeyDown(50) == null)
        {
            goto Label_004C;
        }
    Label_002F:
        this.SetRallyOff();
        base.stage.EnableTowers();
        base.stage.EnableHero();
        return;
    Label_004C:
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        vector = camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, camera.nearClipPlane));
        this.rallyPointCursor.transform.position = new Vector3(&vector.x, &vector.y, -800f);
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_017B;
        }
        if (base.guiBottom.IsPowerClicked() != null)
        {
            goto Label_00DC;
        }
        if (base.guiBottom.IsHeroPortraitClicked() == null)
        {
            goto Label_00F9;
        }
    Label_00DC:
        this.SetRallyOff();
        base.stage.EnableTowers();
        base.stage.EnableHero();
        return;
    Label_00F9:
        &vector2 = new Vector2(&vector.x, &vector.y);
        if (this.ChangeRallyPoint(vector2) == null)
        {
            goto Label_0166;
        }
        GameAchievements.ChangeRallyPoint();
        this.SetRallyOff();
        GameSoundManager.PlayRallyPoint();
        UnityEngine.Object.Instantiate(this.rallyFeedbackPrefab, this.rallyPointCursor.transform.position, Quaternion.identity);
        base.stage.EnableTowers();
        base.stage.EnableHero();
        goto Label_0176;
    Label_0166:
        this.rallyPointCursor.PlayAnim("error");
    Label_0176:
        goto Label_01AF;
    Label_017B:
        if (Input.GetKeyDown(0x71) != null)
        {
            goto Label_0193;
        }
        if (Input.GetKeyDown(0x20) == null)
        {
            goto Label_01AF;
        }
    Label_0193:
        this.SetRallyOff();
        base.stage.EnableTowers();
        base.stage.EnableHero();
    Label_01AF:
        return;
    }

    protected enum doorState
    {
        OPEN,
        OPENING,
        CLOSED,
        CLOSING
    }
}

