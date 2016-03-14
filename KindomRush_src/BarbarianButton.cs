using System;
using UnityEngine;

public class BarbarianButton : TowerButton
{
    public BarbarianButton()
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
            goto Label_00DE;
        }
        clickable = ((TowerBase) base.menu.GetCurrentSelect().GetComponent("TowerBase")).GetBuildTerrain();
        base.menu.GetCurrentSelect().GetComponent<BarrackAdvancedClickable>().BuildBarbarian(clickable);
        base.menu.GetCurrentSelect().GetComponent<BarrackAdvancedClickable>().HideUpgradeRange("Barbarian");
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().DestroyTerrain();
        UnityEngine.Object.Destroy(base.menu.GetCurrentSelect().gameObject);
        base.menu.Hide();
        GameSoundManager.PlayTowerUpgrade();
        if ((base.glow != null) == null)
        {
            goto Label_00BD;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_00BD:
        if ((base.tooltip != null) == null)
        {
            goto Label_00DE;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_00DE:
        return;
    }

    private void OnMouseEnter()
    {
        TowerBase base2;
        Vector3 vector;
        base2 = base.menu.GetCurrentSelect().GetComponent<TowerBase>();
        vector = base2.transform.position - new Vector3(0f, (float) base2.yAdjust, 0f);
        base.menu.GetCurrentSelect().GetComponent<BarrackAdvancedClickable>().ShowUpgradeRange(vector, "Barbarian");
        if (base.available == null)
        {
            goto Label_00AE;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_00AE:
        this.ShowTooltip("BarrackBarbarian", 0);
        return;
    }

    private void OnMouseExit()
    {
        if ((base.menu.GetCurrentSelect() != null) == null)
        {
            goto Label_0030;
        }
        base.menu.GetCurrentSelect().GetComponent<BarrackAdvancedClickable>().HideUpgradeRange("Barbarian");
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
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.ShowPrice();
        base.available = (base.stage.GetGold() < GameSettings.GetTowerPrice("BarrackBarbarian")) == 0;
        this.CheckAvailable("BarrackBarbarian");
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable("BarrackBarbarian");
        return;
    }
}

