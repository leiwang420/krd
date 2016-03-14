using System;
using UnityEngine;

public class PowerReinforcementPortrait : Power
{
    private bool isDeploying;
    protected Transform pointer;
    public Transform pointerPrefab;
    protected Transform rallyError;
    protected Transform[] reinforcementConscriptPrefabs;
    protected Transform[] reinforcementFarmerPrefabs;
    protected Transform[] reinforcementLegionnairesPrefabs;
    protected Transform[] reinforcementWarriorsPrefabs;
    protected Transform[] reinforcementWellFedPrefabs;
    private StageBase stage;

    public PowerReinforcementPortrait()
    {
        base..ctor();
        return;
    }

    protected override unsafe void Activate()
    {
        Camera camera;
        Vector3 vector;
        int num;
        PackedSprite sprite;
        Vector3 vector2;
        Vector3 vector3;
        int num2;
        if (base.enabled != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        vector = camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, camera.nearClipPlane));
        this.pointer = UnityEngine.Object.Instantiate(this.pointerPrefab, new Vector3(&vector.x, &vector.y, -920f), Quaternion.identity) as Transform;
        Screen.showCursor = 0;
        base.guiBottom.SetPowerReinforcementActive(1);
        num = GameUpgrades.ReinforcementLevel;
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_00C6;
        }
        if (this.stage.MaxUpgradeLevel >= GameUpgrades.ReinforcementLevel)
        {
            goto Label_00C6;
        }
        num = this.stage.MaxUpgradeLevel;
    Label_00C6:
        sprite = this.pointer.GetComponent<PackedSprite>();
        num2 = num;
        switch (num2)
        {
            case 0:
                goto Label_00F9;

            case 1:
                goto Label_0104;

            case 2:
                goto Label_010F;

            case 3:
                goto Label_0121;

            case 4:
                goto Label_0133;

            case 5:
                goto Label_0145;
        }
        goto Label_0157;
    Label_00F9:
        sprite.RevertToStatic();
        goto Label_0162;
    Label_0104:
        sprite.RevertToStatic();
        goto Label_0162;
    Label_010F:
        sprite.PlayAnim(0);
        sprite.PauseAnim();
        goto Label_0162;
    Label_0121:
        sprite.PlayAnim(1);
        sprite.PauseAnim();
        goto Label_0162;
    Label_0133:
        sprite.PlayAnim(2);
        sprite.PauseAnim();
        goto Label_0162;
    Label_0145:
        sprite.PlayAnim(2);
        sprite.PauseAnim();
        goto Label_0162;
    Label_0157:
        sprite.RevertToStatic();
    Label_0162:
        if (base.guiBottom.IsFireballActive() == null)
        {
            goto Label_017E;
        }
        base.guiBottom.SetPowerFireballActive(0);
    Label_017E:
        if (GameData.GetCurrentStageData().Index != 1)
        {
            goto Label_01A9;
        }
        if (GameData.GetGameMode() != null)
        {
            goto Label_01A9;
        }
        ((Stage1) this.stage).HideBalloonPower(1);
    Label_01A9:
        return;
    }

    protected void AddFadeInEffect(Transform t)
    {
        ParticleFadeIn @in;
        @in = t.gameObject.AddComponent<ParticleFadeIn>();
        @in.removeWhenDone = 1;
        @in.finalOpacity = 1f;
        @in.fadeSpeed = 0.1f;
        @in.FadeIn();
        return;
    }

    private unsafe bool CanDropReinforcement(Vector3 newPosition)
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
        return 0;
    }

    protected override void Deactivate()
    {
        base.guiBottom.SetPowerReinforcementActive(0);
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
        return base.guiBottom.IsReinforcementActive();
    }

    public bool IsDeploying()
    {
        return this.isDeploying;
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

    private void ResetDeploy()
    {
        this.isDeploying = 0;
        return;
    }

    protected unsafe void SendReinforcement(Vector3 pos3d)
    {
        int num;
        Transform[] transformArray;
        Transform transform;
        int num2;
        num = GameUpgrades.ReinforcementLevel;
        if (this.stage.MaxUpgradeLevel == null)
        {
            goto Label_0037;
        }
        if (this.stage.MaxUpgradeLevel >= GameUpgrades.ReinforcementLevel)
        {
            goto Label_0037;
        }
        num = this.stage.MaxUpgradeLevel;
    Label_0037:
        transformArray = null;
        num2 = num;
        switch (num2)
        {
            case 0:
                goto Label_005E;

            case 1:
                goto Label_006A;

            case 2:
                goto Label_0076;

            case 3:
                goto Label_0082;

            case 4:
                goto Label_008E;

            case 5:
                goto Label_009A;
        }
        goto Label_00A6;
    Label_005E:
        transformArray = this.reinforcementFarmerPrefabs;
        goto Label_00B2;
    Label_006A:
        transformArray = this.reinforcementWellFedPrefabs;
        goto Label_00B2;
    Label_0076:
        transformArray = this.reinforcementConscriptPrefabs;
        goto Label_00B2;
    Label_0082:
        transformArray = this.reinforcementWarriorsPrefabs;
        goto Label_00B2;
    Label_008E:
        transformArray = this.reinforcementLegionnairesPrefabs;
        goto Label_00B2;
    Label_009A:
        transformArray = this.reinforcementLegionnairesPrefabs;
        goto Label_00B2;
    Label_00A6:
        transformArray = this.reinforcementFarmerPrefabs;
    Label_00B2:
        transform = UnityEngine.Object.Instantiate(transformArray[UnityEngine.Random.Range(0, 3)], new Vector3(&pos3d.x - 15f, &pos3d.y + 12f, -2f), Quaternion.identity) as Transform;
        transform.GetComponent<SoldierReinforcement>().enabled = 1;
        transform.GetComponent<SoldierReinforcement>().InitWithPosition(new Vector2(&pos3d.x, &pos3d.y), new Vector2(&pos3d.x - 15f, &pos3d.y + 12f), 0, 0, new Vector2(&pos3d.x, &pos3d.y));
        this.AddFadeInEffect(transform);
        this.stage.AddReinforce(transform);
        transform = UnityEngine.Object.Instantiate(transformArray[UnityEngine.Random.Range(0, 3)], new Vector3(&pos3d.x + 15f, &pos3d.y - 12f, -2f), Quaternion.identity) as Transform;
        transform.GetComponent<SoldierReinforcement>().enabled = 1;
        transform.GetComponent<SoldierReinforcement>().InitWithPosition(new Vector2(&pos3d.x, &pos3d.y), new Vector2(&pos3d.x + 15f, &pos3d.y - 12f), 0, 0, new Vector2(&pos3d.x, &pos3d.y));
        this.AddFadeInEffect(transform);
        this.stage.AddReinforce(transform);
        base.guiBottom.SetPowerReinforcementActive(0);
        base.overlay.transform.parent.gameObject.SetActive(1);
        base.reloading = 1;
        GameSoundManager.PlayReinforcementTaunt();
        return;
    }

    private void Start()
    {
        base.enabled = 0;
        this.rallyError = ((GameObject) Resources.Load("Prefabs/GUI/RallyError")).GetComponent<Transform>();
        base.guiBottom = base.transform.parent.parent.GetComponent<GUIBottom>();
        base.sprite = base.GetComponent<PackedSprite>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.overlay = base.transform.Find("TransparencyBack/TransparencyScale");
        this.reinforcementFarmerPrefabs = new Transform[] { ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement A0")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement B0")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement C0")).GetComponent<Transform>() };
        this.reinforcementWellFedPrefabs = new Transform[] { ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement A0")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement B0")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement C0")).GetComponent<Transform>() };
        this.reinforcementConscriptPrefabs = new Transform[] { ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement A1")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement B1")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement C1")).GetComponent<Transform>() };
        this.reinforcementWarriorsPrefabs = new Transform[] { ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement A2")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement B2")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement C2")).GetComponent<Transform>() };
        this.reinforcementLegionnairesPrefabs = new Transform[] { ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement A3")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement B3")).GetComponent<Transform>(), ((GameObject) Resources.Load("Prefabs/Powers/Reinforcements/Reinforcement C3")).GetComponent<Transform>() };
        base.coolDown = 300;
        base.rewardTimePrefab = Resources.Load("Prefabs/GUI/WaveRewardTime", typeof(Transform)) as Transform;
        base.sprite.PlayAnim("open");
        base.sprite.PauseAnim();
        return;
    }

    private unsafe void Update()
    {
        Camera camera;
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
            goto Label_01C8;
        }
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_004C;
        }
        if (base.guiBottom.IsReinforcementActive() == null)
        {
            goto Label_004C;
        }
        base.guiBottom.SetPowerReinforcementActive(0);
        return;
    Label_004C:
        if (Input.GetKeyDown(50) == null)
        {
            goto Label_00B7;
        }
        if (base.guiBottom.IsReinforcementActive() != null)
        {
            goto Label_00AA;
        }
        if (base.guiBottom.IsFireballActive() == null)
        {
            goto Label_0084;
        }
        base.guiBottom.SetPowerFireballActive(0);
    Label_0084:
        base.Invoke("Activate", 0.01f);
        base.sprite.PlayAnim("selected");
        GameSoundManager.PlayGUISpellSelect();
        return;
    Label_00AA:
        base.guiBottom.SetPowerReinforcementActive(0);
        return;
    Label_00B7:
        if (base.guiBottom.IsReinforcementActive() == null)
        {
            goto Label_01C8;
        }
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        vector = camera.ScreenToWorldPoint(new Vector3(&Input.mousePosition.x, &Input.mousePosition.y, camera.nearClipPlane));
        this.pointer.transform.position = new Vector3(&vector.x, &vector.y, -920f);
        &vector2 = new Vector3(&vector.x, &vector.y, -800f);
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_01C8;
        }
        if (base.activatedThisFrame == null)
        {
            goto Label_015D;
        }
        return;
    Label_015D:
        this.isDeploying = 1;
        base.Invoke("ResetDeploy", 0.1f);
        if (this.CanDropReinforcement(vector) == null)
        {
            goto Label_01B6;
        }
        this.SendReinforcement(vector);
        if (GameData.GetCurrentStageData().Index != 1)
        {
            goto Label_01C8;
        }
        if (GameData.GetGameMode() != null)
        {
            goto Label_01C8;
        }
        ((Stage1) this.stage).HideBalloonRoad();
        goto Label_01C8;
    Label_01B6:
        UnityEngine.Object.Instantiate(this.rallyError, vector2, Quaternion.identity);
    Label_01C8:
        base.activatedThisFrame = 0;
        return;
    }
}

