using System;
using UnityEngine;

public class PowerFireballPortrait : Power
{
    private Camera camera;
    private PowerFireballController fireballController;
    private bool isFiring;
    private Transform pointer;
    public Transform pointerPrefab;
    protected Transform rallyError;
    private StageBase stage;

    public PowerFireballPortrait()
    {
        base..ctor();
        return;
    }

    protected override unsafe void Activate()
    {
        Camera camera;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        if (base.enabled != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        base.guiBottom.SetPowerFireballActive(1);
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        vector = camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, camera.nearClipPlane));
        this.pointer = UnityEngine.Object.Instantiate(this.pointerPrefab, new Vector3(&vector.x, &vector.y, -920f), Quaternion.identity) as Transform;
        Screen.showCursor = 0;
        if (base.guiBottom.IsReinforcementActive() == null)
        {
            goto Label_00A9;
        }
        base.guiBottom.SetPowerReinforcementActive(0);
    Label_00A9:
        if (GameData.GetCurrentStageData().Index != 1)
        {
            goto Label_00D4;
        }
        if (GameData.GetGameMode() != null)
        {
            goto Label_00D4;
        }
        ((Stage1) this.stage).HideBalloonPower(0);
    Label_00D4:
        return;
    }

    private unsafe bool CanDropFireball(Vector3 newPosition)
    {
        Vector2[][][] vectorArray;
        int num;
        int num2;
        vectorArray = this.stage.GetPath();
        num = 0;
        goto Label_00A2;
    Label_0013:
        num2 = 0;
        goto Label_0091;
    Label_001A:
        if (this.stage.StageHasTunnels() == null)
        {
            goto Label_0037;
        }
        if (this.OnTunnel(num, num2) != null)
        {
            goto Label_008D;
        }
    Label_0037:
        if (Mathf.Sqrt(Mathf.Pow(&(vectorArray[num][0][num2]).y - &newPosition.y, 2f) + Mathf.Pow(&(vectorArray[num][0][num2]).x - &newPosition.x, 2f)) >= 60f)
        {
            goto Label_008D;
        }
        return 1;
    Label_008D:
        num2 += 1;
    Label_0091:
        if (num2 < ((int) vectorArray[num][0].Length))
        {
            goto Label_001A;
        }
        num += 1;
    Label_00A2:
        if (num < ((int) vectorArray.Length))
        {
            goto Label_0013;
        }
        return this.CheckSasquatch();
    }

    private bool CheckSasquatch()
    {
        Stage8 stage;
        stage = this.stage.GetComponent<Stage8>();
        if ((stage != null) == null)
        {
            goto Label_001F;
        }
        return stage.MouseOverSasquatchCave();
    Label_001F:
        return 0;
    }

    protected override void Deactivate()
    {
        base.guiBottom.SetPowerFireballActive(0);
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
        if (base.enabled != null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        if (base.reloading == null)
        {
            goto Label_0029;
        }
        base.Reloading();
    Label_0029:
        return;
    }

    public void HidePointer()
    {
        if ((this.pointer != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.pointer.gameObject);
    Label_0021:
        return;
    }

    protected override bool IsActive()
    {
        return base.guiBottom.IsFireballActive();
    }

    public bool IsFiring()
    {
        return this.isFiring;
    }

    private void LoadSettings()
    {
        base.coolDown = GameSettings.GetPowerSetting("power_fireball", "coolDown") * 30;
        return;
    }

    private bool OnTunnel(int i, int j)
    {
        if (this.stage.HasTunnels(i) == null)
        {
            goto Label_0037;
        }
        if (j < this.stage.TunnelStart(i))
        {
            goto Label_0037;
        }
        if (j > this.stage.TunnelEnd(i))
        {
            goto Label_0037;
        }
        return 1;
    Label_0037:
        return 0;
    }

    private void Start()
    {
        this.rallyError = ((GameObject) Resources.Load("Prefabs/GUI/RallyError")).GetComponent<Transform>();
        base.enabled = 0;
        base.guiBottom = base.transform.parent.parent.GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.fireballController = base.GetComponent<PowerFireballController>();
        this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        base.overlay = base.transform.Find("TransparencyBack/TransparencyScale");
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.rewardTimePrefab = Resources.Load("Prefabs/GUI/WaveRewardTime", typeof(Transform)) as Transform;
        base.Invoke("LoadSettings", 0.5f);
        base.sprite.PlayAnim("open");
        base.sprite.PauseAnim();
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (base.enabled != null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        if (base.reloading != null)
        {
            goto Label_01D5;
        }
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_004C;
        }
        if (base.guiBottom.IsFireballActive() == null)
        {
            goto Label_004C;
        }
        base.guiBottom.SetPowerFireballActive(0);
        return;
    Label_004C:
        if (Input.GetKeyDown(0x31) == null)
        {
            goto Label_00AD;
        }
        if (base.guiBottom.IsFireballActive() != null)
        {
            goto Label_00A0;
        }
        if (base.guiBottom.IsReinforcementActive() == null)
        {
            goto Label_0084;
        }
        base.guiBottom.SetPowerReinforcementActive(0);
    Label_0084:
        this.Activate();
        base.sprite.PlayAnim("selected");
        GameSoundManager.PlayGUISpellSelect();
        return;
    Label_00A0:
        base.guiBottom.SetPowerFireballActive(0);
        return;
    Label_00AD:
        if (base.guiBottom.IsFireballActive() == null)
        {
            goto Label_01D5;
        }
        vector = this.camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, this.camera.nearClipPlane));
        this.pointer.transform.position = new Vector3(&vector.x, &vector.y, -920f);
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_01D5;
        }
        if (base.activatedThisFrame == null)
        {
            goto Label_0132;
        }
        return;
    Label_0132:
        if (this.CanDropFireball(vector) == null)
        {
            goto Label_01A9;
        }
        this.stage.AddFireballAchievement();
        this.fireballController.enabled = 1;
        this.fireballController.InitWithPosition(new Vector2(&vector.x, &vector.y));
        base.guiBottom.SetPowerFireballActive(0);
        base.overlay.transform.parent.gameObject.SetActive(1);
        base.reloading = 1;
        this.isFiring = 1;
        return;
    Label_01A9:
        &vector2 = new Vector3(&vector.x, &vector.y, -921f);
        UnityEngine.Object.Instantiate(this.rallyError, vector2, Quaternion.identity);
    Label_01D5:
        this.isFiring = 0;
        base.activatedThisFrame = 0;
        return;
    }
}

