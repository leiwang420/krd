using System;
using UnityEngine;

public class UnitClickable : MonoBehaviour
{
    private GUIBottom gui;
    public string name;
    public Transform portrait;
    private bool selected;
    public Transform selectionRingPrefab;
    public float xOffset;
    public float yOffset;

    public UnitClickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        return;
    }

    public bool IsSelected()
    {
        return this.selected;
    }

    private void OnMouseUp()
    {
        if (this.gui.IsDeployingReinforcement() == null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        if (this.selected != null)
        {
            goto Label_0033;
        }
        this.Select();
        this.gui.SetSelected(this);
        goto Label_0045;
    Label_0033:
        this.UnSelect();
        this.gui.HideInfo(this);
    Label_0045:
        return;
    }

    public unsafe void Select()
    {
        Soldier soldier;
        Transform transform;
        Transform transform2;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        Vector3 vector6;
        if ((this.selectionRingPrefab != null) == null)
        {
            goto Label_0151;
        }
        soldier = base.GetComponent<Soldier>();
        if ((soldier != null) == null)
        {
            goto Label_00BC;
        }
        if (soldier.IsTowerSelected() != null)
        {
            goto Label_00BC;
        }
        transform = UnityEngine.Object.Instantiate(this.selectionRingPrefab, new Vector3(&base.transform.position.x + this.xOffset, &base.transform.position.y + this.yOffset, &base.transform.position.z + 1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        transform.name = "selectionRing";
        this.selected = 1;
        goto Label_0151;
    Label_00BC:
        if ((soldier == null) == null)
        {
            goto Label_0151;
        }
        transform2 = UnityEngine.Object.Instantiate(this.selectionRingPrefab, new Vector3(&base.transform.position.x + this.xOffset, &base.transform.position.y + this.yOffset, &base.transform.position.z + 1f), Quaternion.identity) as Transform;
        transform2.parent = base.transform;
        transform2.name = "selectionRing";
        this.selected = 1;
    Label_0151:
        return;
    }

    private void Start()
    {
    }

    public void UnSelect()
    {
        Transform transform;
        if ((this.selectionRingPrefab != null) == null)
        {
            goto Label_0042;
        }
        transform = base.transform.FindChild("selectionRing");
        if ((transform != null) == null)
        {
            goto Label_0039;
        }
        UnityEngine.Object.Destroy(transform.gameObject);
    Label_0039:
        this.selected = 0;
        transform = null;
    Label_0042:
        return;
    }

    private void Update()
    {
    }
}

