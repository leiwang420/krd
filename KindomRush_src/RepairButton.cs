using System;
using UnityEngine;

public class RepairButton : TowerButton
{
    public RepairButton()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    protected override void CheckAvailable(string tower)
    {
        if (base.available != null)
        {
            goto Label_00DB;
        }
        if ((base.stage != null) == null)
        {
            goto Label_0085;
        }
        if (base.stage.GetGold() < base.price)
        {
            goto Label_0085;
        }
        base.available = 1;
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
        goto Label_00D6;
    Label_0085:
        base.sprite.PlayAnim("disabled");
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().PlayAnim("disabled");
        base.priceText.gameObject.SetActive(0);
        base.priceOffText.gameObject.SetActive(1);
    Label_00D6:
        goto Label_01A6;
    Label_00DB:
        if ((base.stage != null) == null)
        {
            goto Label_015F;
        }
        if (base.stage.GetGold() >= base.price)
        {
            goto Label_015F;
        }
        base.available = 0;
        base.sprite.PlayAnim("disabled");
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().PlayAnim("disabled");
        base.priceText.gameObject.SetActive(0);
        base.priceOffText.gameObject.SetActive(1);
        goto Label_01A6;
    Label_015F:
        base.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        base.priceText.gameObject.SetActive(1);
        base.priceOffText.gameObject.SetActive(0);
    Label_01A6:
        return;
    }

    protected override void MissClick()
    {
    }

    protected override void OnClick()
    {
        if (base.available == null)
        {
            goto Label_0065;
        }
        base.menu.GetCurrentSelect().GetComponent<ElfTower>().Activate();
        base.menu.Hide();
        base.stage.RemoveGold(100);
        GameSoundManager.PlayTowerUpgrade();
        if ((base.glow != null) == null)
        {
            goto Label_0065;
        }
        UnityEngine.Object.Destroy(base.glow.gameObject);
        base.glow = null;
    Label_0065:
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
        this.ShowTooltip("ElfTower", 0);
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
        base.available = (base.stage.GetGold() < base.price) == 0;
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

