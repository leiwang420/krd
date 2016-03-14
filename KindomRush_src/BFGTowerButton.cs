using System;
using UnityEngine;

public class BFGTowerButton : TowerButton
{
    public BFGTowerButton()
    {
        base..ctor();
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        BuildTerrainClickable clickable;
        if (base.available == null)
        {
            goto Label_00FD;
        }
        clickable = ((TowerBase) base.menu.GetCurrentSelect().GetComponent("TowerBase")).GetBuildTerrain();
        ((ArtilleryAdvancedClickable) base.menu.GetCurrentSelect().GetComponent("ArtilleryAdvancedClickable")).BuildBFG(clickable, base.menu.GetCurrentSelect().GetComponent<TowerBase>().GetSpent());
        base.menu.GetCurrentSelect().GetComponent<ArtilleryAdvancedClickable>().HideUpgradeRange("BFG");
        UnityEngine.Object.Destroy(base.menu.GetCurrentSelect().gameObject);
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().DestroyTerrain();
        base.menu.Hide();
        GameSoundManager.PlayTowerUpgrade();
        if ((base.glow != null) == null)
        {
            goto Label_00DC;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_00DC:
        if ((base.tooltip != null) == null)
        {
            goto Label_00FD;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_00FD:
        return;
    }

    private void OnMouseEnter()
    {
        TowerBase base2;
        Vector3 vector;
        base2 = base.menu.GetCurrentSelect().GetComponent<TowerBase>();
        vector = base2.transform.position - new Vector3(0f, (float) base2.yAdjust, 0f);
        base.menu.GetCurrentSelect().GetComponent<ArtilleryAdvancedClickable>().ShowUpgradeRange(vector, "BFG");
        if (base.available == null)
        {
            goto Label_00AE;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_00AE:
        this.ShowTooltip("ArtilleryBFG", 0);
        return;
    }

    private void OnMouseExit()
    {
        if ((base.menu.GetCurrentSelect() != null) == null)
        {
            goto Label_0030;
        }
        base.menu.GetCurrentSelect().GetComponent<ArtilleryAdvancedClickable>().HideUpgradeRange("BFG");
    Label_0030:
        base.DestroyGlow();
        if ((base.tooltip != null) == null)
        {
            goto Label_0057;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_0057:
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        base.ShowPrice();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.available = (base.stage.GetGold() < GameSettings.GetTowerPrice("ArtilleryBFG")) == 0;
        this.CheckAvailable("ArtilleryBFG");
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable("ArtilleryBFG");
        return;
    }
}

