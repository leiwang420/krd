using System;
using UnityEngine;

public class SellButton : TowerButton
{
    public SellButton()
    {
        base..ctor();
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        TowerBase base2;
        base.menu.GetCurrentSelect().GetComponent<TowerBase>().Sell();
        base.menu.Hide();
        base.guiBottom.HideInfoOverride();
        base.DestroyGlow();
        return;
    }

    private void OnMouseEnter()
    {
        int num;
        if (base.available == null)
        {
            goto Label_005B;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_005B:
        num = Mathf.RoundToInt((float) base.menu.GetCurrentSelect().GetComponent<TowerBase>().GetReturnValue());
        this.ShowTooltip("Sell", num);
        return;
    }

    private void OnMouseExit()
    {
        base.DestroyGlow();
        base.HideTooltip();
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        return;
    }
}

