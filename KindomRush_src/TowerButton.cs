using System;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class TowerButton : Clickable
{
    protected bool available;
    protected Transform glow;
    public Transform glowPrefab;
    private float horizRatio;
    public Vector3 localPos;
    protected Quickmenu menu;
    protected Transform prefabTooltip;
    protected int price;
    protected TextMesh priceOffText;
    protected Transform priceTag;
    protected TextMesh priceText;
    protected int range;
    protected PackedSprite sprite;
    protected StageBase stage;
    protected TooltipTower tooltip;
    private float vertRatio;

    protected TowerButton()
    {
        this.available = 1;
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    protected virtual void CheckAvailable(string tower)
    {
        if (this.available != null)
        {
            goto Label_0085;
        }
        if ((this.stage != null) == null)
        {
            goto Label_011C;
        }
        if (this.stage.GetGold() < GameSettings.GetTowerPrice(tower))
        {
            goto Label_011C;
        }
        this.available = 1;
        this.sprite.RevertToStatic();
        base.transform.FindChild("Pricetag").GetComponent<PackedSprite>().RevertToStatic();
        this.priceText.gameObject.SetActive(1);
        this.priceOffText.gameObject.SetActive(0);
        goto Label_011C;
    Label_0085:
        if ((this.stage != null) == null)
        {
            goto Label_00D3;
        }
        if (this.stage.GetGold() >= GameSettings.GetTowerPrice(tower))
        {
            goto Label_00D3;
        }
        this.priceText.gameObject.SetActive(0);
        this.priceOffText.gameObject.SetActive(1);
        goto Label_011C;
    Label_00D3:
        if ((this.stage != null) == null)
        {
            goto Label_011C;
        }
        if (this.stage.GetGold() < GameSettings.GetTowerPrice(tower))
        {
            goto Label_011C;
        }
        this.priceText.gameObject.SetActive(1);
        this.priceOffText.gameObject.SetActive(0);
    Label_011C:
        return;
    }

    public void DestroyGlow()
    {
        if ((this.glow != null) == null)
        {
            goto Label_0028;
        }
        UnityEngine.Object.Destroy(this.glow.gameObject);
        this.glow = null;
    Label_0028:
        return;
    }

    protected void HideTooltip()
    {
        if ((this.tooltip != null) == null)
        {
            goto Label_0021;
        }
        UnityEngine.Object.Destroy(this.tooltip.gameObject);
    Label_0021:
        return;
    }

    protected void OnMouseEnter()
    {
        if (this.available == null)
        {
            goto Label_006C;
        }
        if ((this.glowPrefab != null) == null)
        {
            goto Label_006C;
        }
        this.glow = UnityEngine.Object.Instantiate(this.glowPrefab, base.transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity) as Transform;
        this.glow.parent = base.transform;
    Label_006C:
        return;
    }

    protected void OnMouseExit()
    {
        this.DestroyGlow();
        return;
    }

    public virtual void SetAvailable(bool a)
    {
        Transform transform;
        PackedSprite sprite;
        this.available = a;
        if ((this.sprite == null) == null)
        {
            goto Label_0024;
        }
        this.sprite = base.GetComponent<PackedSprite>();
    Label_0024:
        if (this.available != null)
        {
            goto Label_0099;
        }
        if ((base.transform.name != "LockedButton(Clone)") == null)
        {
            goto Label_00A4;
        }
        this.sprite.PlayAnim("disabled");
        transform = base.transform.FindChild("Pricetag");
        if ((transform != null) == null)
        {
            goto Label_00A4;
        }
        sprite = transform.GetComponent<PackedSprite>();
        if ((sprite != null) == null)
        {
            goto Label_00A4;
        }
        sprite.PlayAnim("disabled");
        goto Label_00A4;
    Label_0099:
        this.sprite.RevertToStatic();
    Label_00A4:
        return;
    }

    public unsafe void SetInfo(buttonInfo info)
    {
        this.price = &info.price;
        this.range = &info.range;
        return;
    }

    public void SetPrice(int p)
    {
        this.price = p;
        return;
    }

    protected void SetRange(int r)
    {
        this.range = r;
        return;
    }

    protected unsafe void ShowPrice()
    {
        this.priceText = base.transform.FindChild("Pricetag").FindChild("Price").GetComponent<TextMesh>();
        this.priceOffText = base.transform.FindChild("Pricetag").FindChild("PriceOff").GetComponent<TextMesh>();
        if ((this.priceText != null) == null)
        {
            goto Label_0071;
        }
        this.priceText.text = &this.price.ToString();
    Label_0071:
        if ((this.priceOffText != null) == null)
        {
            goto Label_0098;
        }
        this.priceOffText.text = &this.price.ToString();
    Label_0098:
        return;
    }

    protected virtual unsafe void ShowTooltip(string name, int level = 0)
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
        num = Mathf.Abs(&base.transform.position.y - &this.menu.transform.position.y) + 110f;
        if (-230f >= &this.menu.transform.position.y)
        {
            goto Label_00CA;
        }
        if (&this.menu.transform.position.y >= 230f)
        {
            goto Label_00CA;
        }
        &vector = new Vector3(&this.menu.transform.position.x, &this.menu.transform.position.y + num, -920f);
        goto Label_0178;
    Label_00CA:
        if (&this.menu.transform.position.y < 230f)
        {
            goto Label_0138;
        }
        &vector = new Vector3(&this.menu.transform.position.x, (&this.menu.transform.position.y - num) - 20f, -920f);
        goto Label_0178;
    Label_0138:
        &vector = new Vector3(&this.menu.transform.position.x, &this.menu.transform.position.y + num, -920f);
    Label_0178:
        transform = UnityEngine.Object.Instantiate(this.prefabTooltip, vector, Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.tooltip = transform.GetComponent<TooltipTower>();
        this.tooltip.Setup(name, level);
        return;
    }

    private void Start()
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct buttonInfo
    {
        public int price;
        public int range;
    }
}

