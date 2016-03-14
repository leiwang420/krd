using System;
using UnityEngine;

internal class ArtilleryTowerButton : TowerButton
{
    private Transform ghost;
    public Transform ghostPrefab;

    public ArtilleryTowerButton()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        if (base.available == null)
        {
            goto Label_0095;
        }
        ((BuildTerrainClickable) base.menu.GetCurrentSelect()).BuildArtillery();
        base.menu.Hide();
        if ((base.glow != null) == null)
        {
            goto Label_0053;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_0053:
        if ((base.tooltip != null) == null)
        {
            goto Label_0074;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_0074:
        if ((this.ghost != null) == null)
        {
            goto Label_0095;
        }
        UnityEngine.Object.Destroy(this.ghost.gameObject);
    Label_0095:
        return;
    }

    protected void OnMouseEnter()
    {
        if (base.available == null)
        {
            goto Label_005B;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_005B:
        this.ShowTooltip("ArtilleryLvl1", 0);
        this.ShowGhost();
        return;
    }

    protected void OnMouseExit()
    {
        base.DestroyGlow();
        if ((this.ghost != null) == null)
        {
            goto Label_0027;
        }
        UnityEngine.Object.Destroy(this.ghost.gameObject);
    Label_0027:
        if ((base.tooltip != null) == null)
        {
            goto Label_0048;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_0048:
        return;
    }

    private unsafe void ShowGhost()
    {
        Vector3 vector;
        Vector3 vector2;
        if ((base.menu == null) != null)
        {
            goto Label_0027;
        }
        if ((base.menu.GetCurrentSelect() == null) == null)
        {
            goto Label_0028;
        }
    Label_0027:
        return;
    Label_0028:
        vector = base.menu.GetCurrentSelect().transform.position;
        &vector2 = new Vector3(&vector.x, &vector.y + 25f, -800f);
        this.ghost = UnityEngine.Object.Instantiate(this.ghostPrefab, vector2, base.transform.rotation) as Transform;
        this.ghost.GetComponent<TowerGhost>().SetRange(GameSettings.GetTowerSetting("artillery_level1", "range"));
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        base.sprite = base.GetComponent<PackedSprite>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.ShowPrice();
        base.available = (base.stage.GetGold() < GameSettings.GetTowerPrice("ArtilleryLvl1")) == 0;
        this.CheckAvailable("ArtilleryLvl1");
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable("ArtilleryLvl1");
        return;
    }
}

