using System;
using UnityEngine;

public class Layer : MonoBehaviour
{
    private LayerManager manager;
    public float offset;
    public float yAdjust;

    public Layer()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnDisable()
    {
        if ((this.manager != null) == null)
        {
            goto Label_001D;
        }
        this.manager.Remove(this);
    Label_001D:
        return;
    }

    public void Remove()
    {
        this.manager.Remove(this);
        return;
    }

    private void Start()
    {
        this.manager = GameObject.Find("Stage").GetComponent<LayerManager>();
        this.manager.Add(this);
        if (this.offset != 0f)
        {
            goto Label_0048;
        }
        this.offset = base.GetComponent<PackedSprite>().height / 2f;
    Label_0048:
        return;
    }

    public void UpdateOffset()
    {
        this.offset = base.GetComponent<PackedSprite>().height / 2f;
        return;
    }
}

