using System;
using System.Collections;
using UnityEngine;

public class SorcererTower : TowerBase
{
    private ElementalAbility elemental;
    public Transform elementalPrefab;
    private SoldierElemental elementalSoldier;
    private int frame;
    private int framePolymorph;
    private PolymorphAbility polymorph;
    public Transform projectile;
    protected Transform rallyCircle;
    public Transform rallyCirclePrefab;
    public Transform rallyFeedbackPrefab;
    private PackedSprite rallyPointCursor;
    public Transform rallyPointCursorPrefab;
    private int rallyRangeHeight;
    private int rallyRangeWidth;
    protected bool rallySelect;
    protected bool selected;
    private Shooter shooter;
    public Transform shooterPrefab;
    private PackedSprite towerSprite;
    public float xOffset;
    public float yOffset;

    public SorcererTower()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
        base.state = 1;
        this.FlipArcher();
        this.towerSprite.PlayAnim("fire");
        return;
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
        Vector2 vector;
        if (this.CanChangeRallyPoint(newPosition) != null)
        {
            goto Label_000E;
        }
        return 0;
    Label_000E:
        base.rallyPoint = newPosition;
        num = 0;
        vector = IronUtils.ellipseGetPointOfDegree((float) num, 48f, 75f, new Vector2(&this.rallyPoint.x, &this.rallyPoint.y + 17f));
        this.elementalSoldier.ChangeRallyPoint(vector);
        this.elementalSoldier.SetRangeCenterPosition(vector);
        GameSoundManager.PlayRockElementalRally();
        return 1;
    }

    private unsafe void Fire()
    {
        Transform transform;
        SorcererBolt bolt;
        Vector3 vector;
        transform = UnityEngine.Object.Instantiate(this.projectile, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        if (base.yDest <= &base.transform.position.y)
        {
            goto Label_0089;
        }
        transform.position += new Vector3(this.xOffset + 10f, this.yOffset - 2f, 0f);
        goto Label_00BC;
    Label_0089:
        transform.position += new Vector3(this.xOffset - 10f, this.yOffset - 2f, 0f);
    Label_00BC:
        bolt = transform.GetComponent<SorcererBolt>();
        bolt.SetDamage(UnityEngine.Random.Range(base.minDamange, base.maxDamage));
        if ((base.target == null) != null)
        {
            goto Label_010B;
        }
        if (base.target.IsActive() == null)
        {
            goto Label_010B;
        }
        if (base.target.IsDead() == null)
        {
            goto Label_0118;
        }
    Label_010B:
        this.LookForTarget((float) base.range);
    Label_0118:
        bolt.SetTarget(base.target, base.xDest, base.yDest);
        bolt.SetStage(base.stage);
        GameSoundManager.PlayBoltSorcererSound();
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.isActive == null)
        {
            goto Label_00F0;
        }
        if (base.state != null)
        {
            goto Label_004F;
        }
        this.LookForTarget((float) base.range);
        if (this.polymorph.IsReady() == null)
        {
            goto Label_00F0;
        }
        this.polymorph.LookForTarget();
        goto Label_00F0;
    Label_004F:
        if (base.state != 1)
        {
            goto Label_00AF;
        }
        this.frame += 1;
        this.framePolymorph += 1;
        base.timerReload += Time.deltaTime;
        if (this.polymorph.CanFire() == null)
        {
            goto Label_00A4;
        }
        this.SetupPolymorph();
        goto Label_00AA;
    Label_00A4:
        this.SetupNormalShot();
    Label_00AA:
        goto Label_00F0;
    Label_00AF:
        if (base.state != 2)
        {
            goto Label_00F0;
        }
        base.timerReload += Time.deltaTime;
        if (base.timerReload < base.reload)
        {
            goto Label_00F0;
        }
        base.timerReload = 0f;
        base.state = 0;
    Label_00F0:
        return;
    }

    private unsafe void FlipArcher()
    {
        float num;
        Vector3 vector;
        num = &this.shooter.transform.position.y;
        if (base.yDest <= num)
        {
            goto Label_003A;
        }
        this.shooter.PlayAnim("fireUp");
        goto Label_004A;
    Label_003A:
        this.shooter.PlayAnim("fire");
    Label_004A:
        return;
    }

    public bool HasElemental()
    {
        return (this.elementalSoldier != null);
    }

    protected override unsafe void LookForTarget(float range)
    {
        Creep creep;
        Creep creep2;
        Transform transform;
        IEnumerator enumerator;
        Creep creep3;
        Vector3 vector;
        IDisposable disposable;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        creep = null;
        creep2 = null;
        enumerator = base.spawner.transform.GetEnumerator();
    Label_0015:
        try
        {
            goto Label_0107;
        Label_001A:
            transform = (Transform) enumerator.Current;
            creep3 = transform.GetComponent<Creep>();
            vector = creep3.transform.position + new Vector3(&creep3.anchorPoint.x, &creep3.anchorPoint.y, 0f);
            if (creep3.IsActive() == null)
            {
                goto Label_0107;
            }
            if (IronUtils.ellipseContainPoint(vector, range * 0.7f, range, base.transform.position + new Vector3(0f, (float) -(base.yAdjust + base.yRangeAdjust), 0f)) == null)
            {
                goto Label_0107;
            }
            if ((creep3.GetModifier("EnemyModifierCurse") == null) == null)
            {
                goto Label_00EA;
            }
            if ((creep == null) != null)
            {
                goto Label_00E2;
            }
            if (base.IsNearExit(creep, creep3) == null)
            {
                goto Label_0107;
            }
        Label_00E2:
            creep = creep3;
            goto Label_0107;
        Label_00EA:
            if ((creep2 == null) != null)
            {
                goto Label_0104;
            }
            if (base.IsNearExit(creep2, creep3) == null)
            {
                goto Label_0107;
            }
        Label_0104:
            creep2 = creep3;
        Label_0107:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
            goto Label_012C;
        }
        finally
        {
        Label_0117:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0124;
            }
        Label_0124:
            disposable.Dispose();
        }
    Label_012C:
        if ((creep != null) == null)
        {
            goto Label_017A;
        }
        base.xDest = &creep.transform.position.x;
        base.yDest = &creep.transform.position.y;
        base.target = creep;
        this.BeginFire();
        return;
    Label_017A:
        if ((creep2 != null) == null)
        {
            goto Label_01C7;
        }
        base.xDest = &creep2.transform.position.x;
        base.yDest = &creep2.transform.position.y;
        base.target = creep2;
        this.BeginFire();
    Label_01C7:
        return;
    }

    protected bool OnTunnel(int i, int j)
    {
        return 0;
    }

    public override void Pause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 1;
        base.wasAnimating = this.towerSprite.IsAnimating();
        this.towerSprite.PauseAnim();
        this.shooter.PauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_003A:
        try
        {
            goto Label_0064;
        Label_003F:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_0064;
            }
            projectile.Pause();
        Label_0064:
            if (enumerator.MoveNext() != null)
            {
                goto Label_003F;
            }
            goto Label_0089;
        }
        finally
        {
        Label_0074:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0081;
            }
        Label_0081:
            disposable.Dispose();
        }
    Label_0089:
        if ((this.elemental != null) == null)
        {
            goto Label_00B6;
        }
        if ((this.elementalSoldier != null) == null)
        {
            goto Label_00B6;
        }
        this.elementalSoldier.Pause();
    Label_00B6:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00CF;
        }
        denas.Pause();
    Label_00CF:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00EB;
        }
        base.veznanBlock.Pause();
    Label_00EB:
        return;
    }

    public unsafe void Rally()
    {
        Vector3 vector;
        Vector3 vector2;
        this.rallySelect = 1;
        Screen.showCursor = 0;
        this.rallyCircle = UnityEngine.Object.Instantiate(this.rallyCirclePrefab, new Vector3(&base.transform.position.x, &base.transform.position.y - 25f, -2f), Quaternion.identity) as Transform;
        this.rallyCircle.localScale = new Vector3(((float) this.rallyRangeWidth) / 385f, (((float) this.rallyRangeWidth) * 0.7f) / 385f, 1f);
        this.rallyPointCursor = ((Transform) UnityEngine.Object.Instantiate(this.rallyPointCursorPrefab, base.transform.position, Quaternion.identity)).GetComponent<PackedSprite>();
        base.stage.DisableTowers();
        base.stage.IgnoreHeroClick();
        return;
    }

    public void SelectElemental()
    {
        if ((this.elementalSoldier != null) == null)
        {
            goto Label_0028;
        }
        this.selected = 1;
        this.elementalSoldier.GetComponent<UnitClickable>().Select();
    Label_0028:
        return;
    }

    public override void Sell()
    {
        base.Sell();
        if ((this.elementalSoldier != null) == null)
        {
            goto Label_0027;
        }
        UnityEngine.Object.Destroy(this.elementalSoldier.gameObject);
    Label_0027:
        return;
    }

    protected void SetRallyOff()
    {
        UnityEngine.Object.Destroy(this.rallyPointCursor.gameObject);
        UnityEngine.Object.Destroy(this.rallyCircle.gameObject);
        this.rallySelect = 0;
        Screen.showCursor = 1;
        this.UnselectElemental();
        return;
    }

    private void SetupNormalShot()
    {
        if (this.frame != 10)
        {
            goto Label_0018;
        }
        this.Fire();
        goto Label_0040;
    Label_0018:
        if (this.frame != 0x15)
        {
            goto Label_0040;
        }
        base.state = 2;
        this.frame = 0;
        this.framePolymorph = 0;
        this.SwitchIdleAnim();
    Label_0040:
        return;
    }

    private void SetupPolymorph()
    {
        if (this.frame != 1)
        {
            goto Label_0037;
        }
        this.shooter.RevertToStatic();
        this.towerSprite.PlayAnim("fire");
        this.polymorph.ShowEffect();
        goto Label_0092;
    Label_0037:
        if (this.frame != 10)
        {
            goto Label_0054;
        }
        this.polymorph.Fire();
        goto Label_0092;
    Label_0054:
        if (this.frame != 20)
        {
            goto Label_0092;
        }
        this.polymorph.SpawnSheep();
        this.polymorph.Reset();
        base.state = 2;
        this.frame = 0;
        this.framePolymorph = 0;
        this.SwitchIdleAnim();
    Label_0092:
        return;
    }

    public unsafe void SpawnElemental()
    {
        Transform transform;
        transform = UnityEngine.Object.Instantiate(this.elementalPrefab, new Vector3(&this.rallyPoint.x, &this.rallyPoint.y, -1f), Quaternion.identity) as Transform;
        this.elementalSoldier = transform.GetComponent<SoldierElemental>();
        this.elementalSoldier.SetRallyPoint(base.rallyPoint);
        this.elementalSoldier.SetRangeCenterPosition(base.rallyPoint);
        this.elementalSoldier.SetTower(this);
        base.stage.AddSoldier(this.elementalSoldier);
        base.stage.AddElementalAchievement();
        return;
    }

    private void Start()
    {
        Transform transform;
        this.towerSprite = (PackedSprite) base.GetComponent("PackedSprite");
        transform = UnityEngine.Object.Instantiate(this.shooterPrefab, base.transform.position, base.transform.rotation) as Transform;
        transform.parent = base.transform;
        this.shooter = (Shooter) transform.GetComponent("Shooter");
        this.shooter.transform.localPosition = new Vector3(this.xOffset, this.yOffset, -1f);
        base.state = 2;
        this.frame = 0;
        this.framePolymorph = 0;
        this.polymorph = base.GetComponent<PolymorphAbility>();
        this.elemental = base.GetComponent<ElementalAbility>();
        this.rallyRangeWidth = 0x1fc;
        this.rallyRangeHeight = Mathf.RoundToInt(((float) this.rallyRangeWidth) * 0.7f);
        base.price = (int) GameSettings.GetTowerSetting("mage_sorcerer", "price");
        base.range = (int) GameSettings.GetTowerSetting("mage_sorcerer", "range");
        base.minDamange = (int) GameSettings.GetTowerSetting("mage_sorcerer", "minDamage");
        base.maxDamage = (int) GameSettings.GetTowerSetting("mage_sorcerer", "maxDamage");
        GameSoundManager.PlayMageSorcererTaunt();
        return;
    }

    private unsafe void SwitchIdleAnim()
    {
        float num;
        Vector3 vector;
        num = &this.shooter.transform.position.y;
        this.shooter.Reset();
        if (base.yDest <= num)
        {
            goto Label_0045;
        }
        this.shooter.PlayAnim("up");
        goto Label_0050;
    Label_0045:
        this.shooter.RevertToStatic();
    Label_0050:
        return;
    }

    public override void Unpause()
    {
        Transform transform;
        IEnumerator enumerator;
        BaseProjectile projectile;
        TowerModifierHeroDenas denas;
        IDisposable disposable;
        base.isPaused = 0;
        if (base.wasAnimating == null)
        {
            goto Label_001D;
        }
        this.towerSprite.UnpauseAnim();
    Label_001D:
        this.shooter.UnpauseAnim();
        enumerator = base.transform.GetEnumerator();
    Label_0034:
        try
        {
            goto Label_005E;
        Label_0039:
            transform = (Transform) enumerator.Current;
            projectile = transform.GetComponent<BaseProjectile>();
            if ((projectile != null) == null)
            {
                goto Label_005E;
            }
            projectile.Unpause();
        Label_005E:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0039;
            }
            goto Label_0083;
        }
        finally
        {
        Label_006E:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_007B;
            }
        Label_007B:
            disposable.Dispose();
        }
    Label_0083:
        if ((this.elemental != null) == null)
        {
            goto Label_00B0;
        }
        if ((this.elementalSoldier != null) == null)
        {
            goto Label_00B0;
        }
        this.elementalSoldier.Unpause();
    Label_00B0:
        denas = base.GetComponent<TowerModifierHeroDenas>();
        if ((denas != null) == null)
        {
            goto Label_00C9;
        }
        denas.Unpause();
    Label_00C9:
        if ((base.veznanBlock != null) == null)
        {
            goto Label_00E5;
        }
        base.veznanBlock.Unpause();
    Label_00E5:
        return;
    }

    public void UnselectElemental()
    {
        if ((this.elementalSoldier != null) == null)
        {
            goto Label_0033;
        }
        if (this.selected == null)
        {
            goto Label_0033;
        }
        this.selected = 0;
        this.elementalSoldier.GetComponent<UnitClickable>().UnSelect();
    Label_0033:
        return;
    }

    private unsafe void Update()
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
            goto Label_012D;
        }
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        vector = camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, camera.nearClipPlane));
        this.rallyPointCursor.transform.position = new Vector3(&vector.x, &vector.y, -2f);
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_0105;
        }
        &vector2 = new Vector2(&vector.x, &vector.y);
        if (this.ChangeRallyPoint(vector2) == null)
        {
            goto Label_00F0;
        }
        this.SetRallyOff();
        UnityEngine.Object.Instantiate(this.rallyFeedbackPrefab, this.rallyPointCursor.transform.position, Quaternion.identity);
        this.UnselectElemental();
        base.stage.EnableTowers();
        base.stage.EnableHero();
        goto Label_0100;
    Label_00F0:
        this.rallyPointCursor.PlayAnim("error");
    Label_0100:
        goto Label_012D;
    Label_0105:
        if (Input.GetKeyDown(0x20) == null)
        {
            goto Label_012D;
        }
        this.SetRallyOff();
        base.stage.EnableTowers();
        base.stage.EnableHero();
    Label_012D:
        return;
    }

    public void UpgradeElemental(int level)
    {
        this.elementalSoldier.Upgrade(level);
        return;
    }
}

