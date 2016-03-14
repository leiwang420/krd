using System;
using UnityEngine;

public class MenuOptionsButtonAspect : MonoBehaviour
{
    private MenuOptionsAspectBox boxAspect;
    private MenuOptionsResBox boxRes16By10;
    private MenuOptionsResBox boxRes16By9;
    private MenuOptionsResBox boxRes4By3;

    public MenuOptionsButtonAspect()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.boxRes4By3.Hide();
        this.boxRes16By9.Hide();
        this.boxRes16By10.Hide();
        this.boxAspect.ShowMenu();
        return;
    }

    private void Start()
    {
        this.boxAspect = base.transform.parent.GetComponent<MenuOptionsAspectBox>();
        this.boxRes4By3 = base.transform.parent.parent.FindChild("Aspect4By3").GetComponent<MenuOptionsResBox>();
        this.boxRes16By9 = base.transform.parent.parent.FindChild("Aspect16By9").GetComponent<MenuOptionsResBox>();
        this.boxRes16By10 = base.transform.parent.parent.FindChild("Aspect16By10").GetComponent<MenuOptionsResBox>();
        return;
    }
}

