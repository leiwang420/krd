using System;
using UnityEngine;

public class RangerTowerButton : TowerButton
{
    public RangerTowerButton()
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
        BuildTerrainClickable clickable;
        if (base.available == null)
        {
            goto Label_00FD;
        }
        clickable = ((TowerBase) base.menu.GetCurrentSelect().GetComponent("TowerBase")).GetBuildTerrain();
        ((ArcherAdvancedClickable) base.menu.GetCurrentSelect().GetComponent("ArcherAdvancedClickable")).BuildRanger(clickable, base.menu.GetCurrentSelect().GetComponent<TowerBase>().GetSpent());
        base.menu.GetCurrentSelect().GetComponent<ArcherAdvancedClickable>().HideUpgradeRange("Ranger");
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
        base.menu.GetCurrentSelect().GetComponent<ArcherAdvancedClickable>().ShowUpgradeRange(vector, "Ranger");
        if (base.available == null)
        {
            goto Label_00AE;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_00AE:
        this.ShowTooltip("ArcherRanger", 0);
        return;
    }

    private void OnMouseExit()
    {
        if ((base.menu.GetCurrentSelect() != null) == null)
        {
            goto Label_0030;
        }
        base.menu.GetCurrentSelect().GetComponent<ArcherAdvancedClickable>().HideUpgradeRange("Ranger");
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
        base.available = (base.stage.GetGold() < GameSettings.GetTowerPrice("ArcherRanger")) == 0;
        this.CheckAvailable("ArcherRanger");
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable("ArcherRanger");
        return;
    }
}

