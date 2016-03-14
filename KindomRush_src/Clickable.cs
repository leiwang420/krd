using System;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    protected GUIBottom guiBottom;
    private RaycastHit hit;
    protected bool isSelected;

    protected Clickable()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    protected unsafe bool CheckButtonPriority()
    {
        TowerButton[] buttonArray;
        TowerButton button;
        RaycastHit hit;
        UnityEngine.Ray ray;
        TowerButton button2;
        TowerButton[] buttonArray2;
        int num;
        buttonArray = UnityEngine.Object.FindObjectsOfType(typeof(TowerButton)) as TowerButton[];
        button = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        buttonArray2 = buttonArray;
        num = 0;
        goto Label_005A;
    Label_0032:
        button2 = buttonArray2[num];
        if (button2.collider.Raycast(ray, &hit, 1000f) == null)
        {
            goto Label_0054;
        }
        return 1;
    Label_0054:
        num += 1;
    Label_005A:
        if (num < ((int) buttonArray2.Length))
        {
            goto Label_0032;
        }
        return 0;
    }

    protected abstract void MissClick();
    protected abstract void OnClick();
    private void Start()
    {
    }

    public void Unselect()
    {
        this.isSelected = 0;
        return;
    }

    protected unsafe void Update()
    {
        UnityEngine.Ray ray;
        if ((this.guiBottom == null) == null)
        {
            goto Label_0026;
        }
        this.guiBottom = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
    Label_0026:
        if (this.guiBottom.IsPowerActive() != null)
        {
            goto Label_00CE;
        }
        if (base.collider.enabled == null)
        {
            goto Label_00CE;
        }
        if (this.guiBottom.IsLaunchingFireball() != null)
        {
            goto Label_00CE;
        }
        if (this.guiBottom.IsDeployingReinforcement() != null)
        {
            goto Label_00CE;
        }
        if (this.guiBottom.IsHeroMoving() != null)
        {
            goto Label_00CE;
        }
        if (this.guiBottom.IsHeroSelected() != null)
        {
            goto Label_00CE;
        }
        if (Input.GetMouseButtonDown(0) == null)
        {
            goto Label_00CE;
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (base.collider.Raycast(ray, &this.hit, 1000f) == null)
        {
            goto Label_00C8;
        }
        this.OnClick();
        goto Label_00CE;
    Label_00C8:
        this.MissClick();
    Label_00CE:
        return;
    }
}

