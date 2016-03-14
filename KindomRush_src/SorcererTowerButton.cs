using System;
using UnityEngine;

public class SorcererTowerButton : TowerButton
{
    public SorcererTowerButton()
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
        ((MageAdvancedClickable) base.menu.GetCurrentSelect().GetComponent("MageAdvancedClickable")).BuildSorcerer(clickable, base.menu.GetCurrentSelect().GetComponent<TowerBase>().GetSpent());
        base.menu.GetCurrentSelect().GetComponent<MageAdvancedClickable>().HideUpgradeRange("Sorcerer");
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().DestroyTerrain();
        UnityEngine.Object.Destroy(base.menu.GetCurrentSelect().gameObject);
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
        base.menu.GetCurrentSelect().GetComponent<MageAdvancedClickable>().ShowUpgradeRange(vector, "Sorcerer");
        if (base.available == null)
        {
            goto Label_00AE;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_00AE:
        this.ShowTooltip("MageSorcerer", 0);
        return;
    }

    private void OnMouseExit()
    {
        if ((base.menu.GetCurrentSelect() != null) == null)
        {
            goto Label_0030;
        }
        base.menu.GetCurrentSelect().GetComponent<MageAdvancedClickable>().HideUpgradeRange("Sorcerer");
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
        base.available = (base.stage.GetGold() < GameSettings.GetTowerPrice("MageSorcerer")) == 0;
        this.CheckAvailable("MageSorcerer");
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable("MageSorcerer");
        return;
    }
}

