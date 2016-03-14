using System;
using UnityEngine;

public class ElfButton : TowerButton
{
    public ElfButton()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    protected override void CheckAvailable(string tower)
    {
        Clickable clickable;
        clickable = base.menu.GetCurrentSelect();
        if (base.available != null)
        {
            goto Label_00AE;
        }
        if ((base.stage != null) == null)
        {
            goto Label_0147;
        }
        if (base.stage.GetGold() < base.price)
        {
            goto Label_0147;
        }
        if ((clickable != null) == null)
        {
            goto Label_0147;
        }
        if (clickable.GetComponent<ElfTower>().GetElfCount() >= 4)
        {
            goto Label_0147;
        }
        base.available = 1;
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
        goto Label_0147;
    Label_00AE:
        if ((clickable != null) == null)
        {
            goto Label_0100;
        }
        if (clickable.GetComponent<ElfTower>().GetElfCount() != 4)
        {
            goto Label_0100;
        }
        base.available = 0;
        this.SetAvailable(0);
        base.priceText.gameObject.SetActive(0);
        base.priceOffText.gameObject.SetActive(1);
        goto Label_0147;
    Label_0100:
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
    Label_0147:
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        if (base.available == null)
        {
            goto Label_0060;
        }
        base.menu.GetCurrentSelect().GetComponent<ElfTower>().AddElf();
        base.menu.Hide();
        base.stage.RemoveGold(100);
        if ((base.glow != null) == null)
        {
            goto Label_0060;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_0060:
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
        this.ShowTooltip("Elf", 0);
        return;
    }

    protected void OnMouseExit()
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
        base.sprite = base.GetComponent<PackedSprite>();
        base.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        base.ShowPrice();
        this.CheckAvailable(null);
        base.prefabTooltip = Resources.Load("Prefabs/GUI/TooltipTower", typeof(Transform)) as Transform;
        return;
    }

    private void Update()
    {
        base.Update();
        this.CheckAvailable(null);
        return;
    }
}

