using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class UpgradeButton : TowerButton
{
    private string upgradeName;

    public UpgradeButton()
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
            goto Label_010D;
        }
        clickable = ((TowerBase) base.menu.GetCurrentSelect().GetComponent("TowerBase")).GetBuildTerrain();
        ((TowerBasicClickable) base.menu.GetCurrentSelect().GetComponent("TowerBasicClickable")).BuildUpgrade(clickable, base.menu.GetCurrentSelect().GetComponent<TowerBase>().GetSpent());
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().DettachProjectiles();
        UnityEngine.Object.Destroy(base.menu.GetCurrentSelect().gameObject);
        base.menu.GetCurrentSelect().GetComponent<TowerBasicClickable>().HideUpgradeRange();
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().DestroyTerrain();
        base.menu.Hide();
        GameSoundManager.PlayTowerUpgrade();
        if ((base.glow != null) == null)
        {
            goto Label_00EC;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_00EC:
        if ((base.tooltip != null) == null)
        {
            goto Label_010D;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_010D:
        return;
    }

    private void OnMouseEnter()
    {
        TowerBase base2;
        Vector3 vector;
        base2 = base.menu.GetCurrentSelect().GetComponent<TowerBase>();
        vector = base2.transform.position - new Vector3(0f, (float) base2.yAdjust, 0f);
        base.menu.GetCurrentSelect().GetComponent<TowerBasicClickable>().ShowUpgradeRange(vector);
        if (base.available == null)
        {
            goto Label_00A9;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_00A9:
        this.ShowTooltip(this.upgradeName, 0);
        return;
    }

    private void OnMouseExit()
    {
        if ((base.menu.GetCurrentSelect() != null) == null)
        {
            goto Label_002B;
        }
        base.menu.GetCurrentSelect().GetComponent<TowerBasicClickable>().HideUpgradeRange();
    Label_002B:
        base.DestroyGlow();
        if ((base.tooltip != null) == null)
        {
            goto Label_0052;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_0052:
        return;
    }

    protected override unsafe void ShowTooltip(string name, int level = 0)
    {
        Vector3 vector;
        float num;
        Transform transform;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        Vector3 vector9;
        Vector3 vector10;
        Vector3 vector11;
        Vector3 vector12;
        vector = Vector3.zero;
        num = Mathf.Abs(&base.transform.position.y - &base.menu.transform.position.y) + 110f;
        if (-230f >= &base.menu.transform.position.y)
        {
            goto Label_00CA;
        }
        if (&base.menu.transform.position.y >= 230f)
        {
            goto Label_00CA;
        }
        &vector = new Vector3(&base.menu.transform.position.x, &base.menu.transform.position.y + num, -920f);
        goto Label_0178;
    Label_00CA:
        if (&base.menu.transform.position.y < 230f)
        {
            goto Label_0138;
        }
        &vector = new Vector3(&base.menu.transform.position.x, (&base.menu.transform.position.y - num) + 10f, -920f);
        goto Label_0178;
    Label_0138:
        &vector = new Vector3(&base.menu.transform.position.x, &base.menu.transform.position.y + num, -920f);
    Label_0178:
        transform = UnityEngine.Object.Instantiate(base.prefabTooltip, vector, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        base.tooltip = transform.GetComponent<TooltipTower>();
        base.tooltip.Setup(name, level);
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        this.upgradeName = ((TowerBasicClickable) base.menu.GetCurrentSelect().GetComponent("TowerBasicClickable")).upgradeTower.name;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.ShowPrice();
        this.CheckAvailable(this.upgradeName);
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable(this.upgradeName);
        return;
    }
}

