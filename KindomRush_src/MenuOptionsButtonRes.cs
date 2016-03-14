using System;
using UnityEngine;

public class MenuOptionsButtonRes : MonoBehaviour
{
    private MenuOptionsResBox boxRes;

    public MenuOptionsButtonRes()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.boxRes.Show();
        return;
    }

    private void Start()
    {
        this.boxRes = base.transform.parent.GetComponent<MenuOptionsResBox>();
        return;
    }
}

