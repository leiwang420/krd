using System;
using UnityEngine;

public class SasquashButton : TowerButton
{
    public SasquashButton()
    {
        base..ctor();
        return;
    }

    protected override void CheckAvailable(string tower)
    {
        if ((base.menu.GetCurrentSelect() == null) == null)
        {
            goto Label_0017;
        }
        return;
    Label_0017:
        if (base.available != null)
        {
            goto Label_00DA;
        }
        if ((base.stage != null) == null)
        {
            goto Label_01AC;
        }
        if (base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsOpen() == null)
        {
            goto Label_01AC;
        }
        if (base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsSasquashAlive() != null)
        {
            goto Label_01AC;
        }
        if (base.stage.GetGold() < base.price)
        {
            goto Label_01AC;
        }
        MonoBehaviour.print("true");
        base.available = 1;
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
        goto Label_01AC;
    Label_00DA:
        if ((base.stage != null) == null)
        {
            goto Label_0101;
        }
        if (base.stage.GetGold() < base.price)
        {
            goto Label_011B;
        }
    Label_0101:
        if (base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsSasquashAlive() == null)
        {
            goto Label_0142;
        }
    Label_011B:
        base.priceText.gameObject.SetActive(0);
        base.priceOffText.gameObject.SetActive(1);
        goto Label_01AC;
    Label_0142:
        if ((base.stage != null) == null)
        {
            goto Label_01AC;
        }
        if (base.stage.GetGold() < base.price)
        {
            goto Label_01AC;
        }
        if (base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsSasquashAlive() != null)
        {
            goto Label_01AC;
        }
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
        base.available = 1;
    Label_01AC:
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        if (base.available == null)
        {
            goto Label_0064;
        }
        base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().ReleaseSasquash();
        base.stage.RemoveGold(base.price);
        base.menu.Hide();
        if ((base.glow != null) == null)
        {
            goto Label_0064;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_0064:
        return;
    }

    private void OnMouseEnter()
    {
        if (base.available == null)
        {
            goto Label_005B;
        }
        base.glow = UnityEngine.Object.Instantiate(base.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        base.glow.parent = base.transform;
    Label_005B:
        if (base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsOpen() != null)
        {
            goto Label_0086;
        }
        this.ShowTooltip("SasquashOff", 0);
        goto Label_0092;
    Label_0086:
        this.ShowTooltip("Sasquash", 0);
    Label_0092:
        return;
    }

    private void OnMouseExit()
    {
        base.DestroyGlow();
        if ((base.tooltip != null) == null)
        {
            goto Label_0027;
        }
        UnityEngine.Object.Destroy(base.tooltip.gameObject);
    Label_0027:
        return;
    }

    private void Start()
    {
        base.menu = base.transform.parent.GetComponent("Quickmenu") as Quickmenu;
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.price = 400;
        base.ShowPrice();
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        this.SetAvailable(((base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsOpen() == null) || (base.menu.GetCurrentSelect().GetComponent<TowerSasquatch>().IsSasquashAlive() != null)) ? 0 : ((base.stage.GetGold() < base.price) == 0));
        this.CheckAvailable(string.Empty);
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable(string.Empty);
        return;
    }
}

