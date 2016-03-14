using System;
using System.Collections;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    private ArrayList sprites;

    public LayerManager()
    {
        base..ctor();
        return;
    }

    public void Add(Layer t)
    {
        this.sprites.Add(t);
        return;
    }

    private void Awake()
    {
        this.sprites = new ArrayList();
        return;
    }

    private unsafe void FixedUpdate()
    {
        int num;
        Layer layer;
        IEnumerator enumerator;
        Vector3 vector;
        Vector3 vector2;
        IDisposable disposable;
        this.Reorder();
        num = -3;
        enumerator = this.sprites.GetEnumerator();
    Label_0015:
        try
        {
            goto Label_0063;
        Label_001A:
            layer = (Layer) enumerator.Current;
            layer.transform.position = new Vector3(&layer.transform.position.x, &layer.transform.position.y, (float) num);
            num -= 2;
        Label_0063:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001A;
            }
            goto Label_0088;
        }
        finally
        {
        Label_0073:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0080;
            }
        Label_0080:
            disposable.Dispose();
        }
    Label_0088:
        return;
    }

    public void Remove(Layer t)
    {
        this.sprites.Remove(t);
        return;
    }

    private unsafe void Reorder()
    {
        int num;
        Layer layer;
        int num2;
        int num3;
        Vector3 vector;
        Vector3 vector2;
        num = this.sprites.Count;
        if (num != null)
        {
            goto Label_0013;
        }
        return;
    Label_0013:
        num3 = 1;
        goto Label_00E6;
    Label_001A:
        layer = (Layer) this.sprites[num3];
        num2 = num3 - 1;
        goto Label_0053;
    Label_0035:
        this.sprites[num2 + 1] = this.sprites[num2];
        num2 -= 1;
    Label_0053:
        if (num2 < 0)
        {
            goto Label_00D3;
        }
        if ((&layer.transform.position.y - (layer.offset + layer.yAdjust)) > (&((Layer) this.sprites[num2]).transform.position.y - (((Layer) this.sprites[num2]).offset + ((Layer) this.sprites[num2]).yAdjust)))
        {
            goto Label_0035;
        }
    Label_00D3:
        this.sprites[num2 + 1] = layer;
        num3 += 1;
    Label_00E6:
        if (num3 < num)
        {
            goto Label_001A;
        }
        return;
    }

    private void Start()
    {
    }
}

