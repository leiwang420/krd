using System;
using System.Collections;
using UnityEngine;

public class Quickmenu : Clickable
{
    private bool closing;
    private Clickable currentSelect;
    private bool opening;
    private float scaleFactor;
    private TYPE tipo;

    public Quickmenu()
    {
        this.scaleFactor = 3.3f;
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    private void ClearButtons()
    {
        Transform transform;
        IEnumerator enumerator;
        TowerButton button;
        IDisposable disposable;
        enumerator = base.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0035;
        Label_0011:
            transform = (Transform) enumerator.Current;
            button = transform.GetComponent<TowerButton>();
            button.DestroyGlow();
            UnityEngine.Object.Destroy(button.gameObject);
        Label_0035:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0057;
        }
        finally
        {
        Label_0045:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0050;
            }
        Label_0050:
            disposable.Dispose();
        }
    Label_0057:
        return;
    }

    private void DeselctTower()
    {
        TowerBase base2;
        BarrackTower tower;
        base2 = this.currentSelect.GetComponent<TowerBase>();
        if ((base2 != null) == null)
        {
            goto Label_0063;
        }
        base2.HideMouseOver();
        base2.HideRangeCircle();
        if ((this.currentSelect.GetComponent<TowerBasicClickable>() != null) == null)
        {
            goto Label_004A;
        }
        this.currentSelect.GetComponent<TowerBasicClickable>().HideUpgradeRangeCircle();
    Label_004A:
        tower = base2.GetComponent<BarrackTower>();
        if ((tower != null) == null)
        {
            goto Label_0063;
        }
        tower.UnselectSoldiers();
    Label_0063:
        return;
    }

    private void EnableButtons()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = base.transform.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_003A;
        Label_0011:
            transform = (Transform) enumerator.Current;
            if ((transform.GetComponent<TowerButton>() != null) == null)
            {
                goto Label_003A;
            }
            transform.collider.enabled = 1;
        Label_003A:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_005C;
        }
        finally
        {
        Label_004A:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0055;
            }
        Label_0055:
            disposable.Dispose();
        }
    Label_005C:
        return;
    }

    public Clickable GetCurrentSelect()
    {
        return this.currentSelect;
    }

    public void Hide()
    {
        Transform transform;
        IEnumerator enumerator;
        TowerButton button;
        IDisposable disposable;
        base.collider.enabled = 0;
        if ((this.currentSelect != null) == null)
        {
            goto Label_0041;
        }
        this.HideUpgradeRanges();
        this.DeselctTower();
        this.currentSelect.collider.enabled = 1;
        this.currentSelect = null;
    Label_0041:
        enumerator = base.transform.GetEnumerator();
    Label_004D:
        try
        {
            goto Label_0077;
        Label_0052:
            transform = (Transform) enumerator.Current;
            button = transform.GetComponent<TowerButton>();
            button.DestroyGlow();
            button.collider.enabled = 0;
        Label_0077:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0052;
            }
            goto Label_0099;
        }
        finally
        {
        Label_0087:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0092;
            }
        Label_0092:
            disposable.Dispose();
        }
    Label_0099:
        this.closing = 1;
        return;
    }

    public void HideUpgradeRanges()
    {
        MageAdvancedClickable clickable;
        BarrackAdvancedClickable clickable2;
        ArcherAdvancedClickable clickable3;
        ArtilleryAdvancedClickable clickable4;
        if ((this.currentSelect != null) == null)
        {
            goto Label_00D8;
        }
        clickable = this.currentSelect.GetComponent<MageAdvancedClickable>();
        clickable2 = this.currentSelect.GetComponent<BarrackAdvancedClickable>();
        clickable3 = this.currentSelect.GetComponent<ArcherAdvancedClickable>();
        clickable4 = this.currentSelect.GetComponent<ArtilleryAdvancedClickable>();
        if ((clickable != null) == null)
        {
            goto Label_0068;
        }
        clickable.HideUpgradeRange("Sorcerer");
        clickable.HideUpgradeRange("Arcane");
        goto Label_00D8;
    Label_0068:
        if ((clickable2 != null) == null)
        {
            goto Label_008F;
        }
        clickable2.HideUpgradeRange("HolyOrder");
        clickable2.HideUpgradeRange("Barbarian");
        goto Label_00D8;
    Label_008F:
        if ((clickable3 != null) == null)
        {
            goto Label_00B6;
        }
        clickable3.HideUpgradeRange("Musketeer");
        clickable3.HideUpgradeRange("Ranger");
        goto Label_00D8;
    Label_00B6:
        if ((clickable4 != null) == null)
        {
            goto Label_00D8;
        }
        clickable4.HideUpgradeRange("Tesla");
        clickable4.HideUpgradeRange("BFG");
    Label_00D8:
        return;
    }

    public bool IsActive()
    {
        return (((PackedSprite) base.transform.GetComponent("PackedSprite")).IsHidden() == 0);
    }

    protected override unsafe void MissClick()
    {
        Clickable[] clickableArray;
        Clickable clickable;
        RaycastHit hit;
        UnityEngine.Ray ray;
        Clickable clickable2;
        Clickable[] clickableArray2;
        int num;
        if ((this.currentSelect != null) == null)
        {
            goto Label_009F;
        }
        this.DeselctTower();
        this.currentSelect.Unselect();
        clickableArray = UnityEngine.Object.FindObjectsOfType(typeof(Clickable)) as Clickable[];
        clickable = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickableArray2 = clickableArray;
        num = 0;
        goto Label_0082;
    Label_0054:
        clickable2 = clickableArray2[num];
        if (clickable2.collider.Raycast(ray, &hit, 1000f) == null)
        {
            goto Label_007C;
        }
        clickable = clickable2;
        goto Label_008D;
    Label_007C:
        num += 1;
    Label_0082:
        if (num < ((int) clickableArray2.Length))
        {
            goto Label_0054;
        }
    Label_008D:
        if ((clickable == null) == null)
        {
            goto Label_009F;
        }
        this.Hide();
    Label_009F:
        return;
    }

    protected override unsafe void OnClick()
    {
        RaycastHit hit;
        UnityEngine.Ray ray;
        bool flag;
        Transform transform;
        IEnumerator enumerator;
        Clickable[] clickableArray;
        Clickable clickable;
        Clickable clickable2;
        Clickable[] clickableArray2;
        int num;
        IDisposable disposable;
        flag = 0;
        enumerator = base.transform.GetEnumerator();
    Label_000F:
        try
        {
            goto Label_0057;
        Label_0014:
            transform = (Transform) enumerator.Current;
            transform.collider.enabled = 1;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (transform.collider.Raycast(ray, &hit, 1000f) == null)
            {
                goto Label_0057;
            }
            flag = 1;
        Label_0057:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0014;
            }
            goto Label_007E;
        }
        finally
        {
        Label_0068:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0076;
            }
        Label_0076:
            disposable.Dispose();
        }
    Label_007E:
        if (flag != null)
        {
            goto Label_0125;
        }
        clickableArray = UnityEngine.Object.FindObjectsOfType(typeof(Clickable)) as Clickable[];
        clickable = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickableArray2 = clickableArray;
        num = 0;
        goto Label_00E8;
    Label_00B9:
        clickable2 = clickableArray2[num];
        if (clickable2.collider.Raycast(ray, &hit, 1000f) == null)
        {
            goto Label_00E2;
        }
        clickable = clickable2;
        goto Label_00F3;
    Label_00E2:
        num += 1;
    Label_00E8:
        if (num < ((int) clickableArray2.Length))
        {
            goto Label_00B9;
        }
    Label_00F3:
        if ((clickable == null) != null)
        {
            goto Label_011F;
        }
        if ((clickable == this.currentSelect) != null)
        {
            goto Label_011F;
        }
        if ((clickable == this) == null)
        {
            goto Label_0125;
        }
    Label_011F:
        this.Hide();
    Label_0125:
        return;
    }

    private unsafe void ResizeCollider()
    {
        Bounds bounds;
        &base.collider.bounds.SetMinMax(new Vector3(-100f, -80f, 0f), new Vector3(100f, 110f, 0f));
        base.collider.enabled = 0;
        return;
    }

    public void Show(Clickable bt, TowerButton[] buttons)
    {
        if (this.closing == null)
        {
            goto Label_0012;
        }
        this.closing = 0;
    Label_0012:
        if ((this.currentSelect != null) == null)
        {
            goto Label_0041;
        }
        this.DeselctTower();
        this.currentSelect.collider.enabled = 1;
        this.currentSelect = null;
    Label_0041:
        this.ClearButtons();
        this.currentSelect = bt;
        this.ResizeCollider();
        this.ShowButtons(buttons);
        this.opening = 1;
        base.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        GameSoundManager.PlayGUIQuickMenuOpen();
        return;
    }

    private unsafe void ShowButtons(TowerButton[] buttons)
    {
        int num;
        num = 0;
        goto Label_007E;
    Label_0007:
        buttons[num].transform.parent = base.transform;
        buttons[num].transform.localPosition = new Vector3(&buttons[num].localPos.x, &buttons[num].localPos.y, -1f);
        buttons[num].transform.localScale = new Vector3(1f, 1f, 1f);
        buttons[num].collider.enabled = 0;
        num += 1;
    Label_007E:
        if (num < ((int) buttons.Length))
        {
            goto Label_0007;
        }
        ((PackedSprite) base.transform.GetComponent("PackedSprite")).Hide(0);
        return;
    }

    private void Start()
    {
        this.tipo = 0;
        return;
    }

    private unsafe void Update()
    {
        Transform transform2;
        Transform transform1;
        BarrackTower tower;
        Vector3 vector;
        Vector3 vector2;
        if (this.opening == null)
        {
            goto Label_0091;
        }
        transform1 = base.transform;
        transform1.localScale += new Vector3(this.scaleFactor * Time.deltaTime, this.scaleFactor * Time.deltaTime, 0f);
        if (&base.transform.localScale.x < 1f)
        {
            goto Label_020B;
        }
        this.opening = 0;
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        this.EnableButtons();
        goto Label_020B;
    Label_0091:
        if (this.closing == null)
        {
            goto Label_011E;
        }
        transform2 = base.transform;
        transform2.localScale -= new Vector3(this.scaleFactor * Time.deltaTime, this.scaleFactor * Time.deltaTime, 0f);
        if (&base.transform.localScale.x > 0.6f)
        {
            goto Label_020B;
        }
        this.closing = 0;
        ((PackedSprite) base.transform.GetComponent("PackedSprite")).Hide(1);
        this.ClearButtons();
        goto Label_020B;
    Label_011E:
        base.Update();
        if ((this.currentSelect != null) == null)
        {
            goto Label_0151;
        }
        if (base.collider.enabled != null)
        {
            goto Label_0151;
        }
        base.collider.enabled = 1;
    Label_0151:
        if (Input.GetKeyDown(0x31) != null)
        {
            goto Label_0169;
        }
        if (Input.GetKeyDown(50) == null)
        {
            goto Label_01C1;
        }
    Label_0169:
        if ((this.currentSelect != null) == null)
        {
            goto Label_01A3;
        }
        tower = this.currentSelect.GetComponent<BarrackTower>();
        if ((tower != null) == null)
        {
            goto Label_0198;
        }
        tower.UnselectSoldiers();
    Label_0198:
        this.currentSelect.Unselect();
    Label_01A3:
        base.guiBottom.HideInfoOverride();
        this.Hide();
        base.collider.enabled = 0;
        return;
    Label_01C1:
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_020B;
        }
        if (base.guiBottom.IsPowerClicked() == null)
        {
            goto Label_020B;
        }
        if ((this.currentSelect != null) == null)
        {
            goto Label_01F8;
        }
        this.currentSelect.Unselect();
    Label_01F8:
        this.Hide();
        base.collider.enabled = 0;
        return;
    Label_020B:
        return;
    }

    public enum TYPE
    {
        BUILD_TOWER,
        TOWER_MENU
    }
}

