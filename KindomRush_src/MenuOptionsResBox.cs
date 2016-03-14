using System;
using System.Collections;
using UnityEngine;

public class MenuOptionsResBox : MonoBehaviour
{
    private ArrayList resList;
    private TextMesh textCurrentRes;

    public MenuOptionsResBox()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        if (this.resList != null)
        {
            goto Label_0011;
        }
        this.InitList();
    Label_0011:
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.resList.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0029;
        Label_0011:
            transform = (Transform) enumerator.Current;
            transform.gameObject.SetActive(0);
        Label_0029:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_004B;
        }
        finally
        {
        Label_0039:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0044;
            }
        Label_0044:
            disposable.Dispose();
        }
    Label_004B:
        return;
    }

    private unsafe void InitList()
    {
        int num;
        Transform transform;
        this.resList = new ArrayList();
        num = 1;
        goto Label_004C;
    Label_0012:
        transform = base.transform.FindChild("ResOption" + &num.ToString());
        if ((transform != null) == null)
        {
            goto Label_0048;
        }
        this.resList.Add(transform);
    Label_0048:
        num += 1;
    Label_004C:
        if (num <= 4)
        {
            goto Label_0012;
        }
        return;
    }

    public unsafe void SetResolution(int width, int height)
    {
        this.Hide();
        this.textCurrentRes.text = &width.ToString() + "x" + &height.ToString();
        return;
    }

    public void Show()
    {
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if (((Transform) this.resList[0]).gameObject.activeSelf != null)
        {
            goto Label_0070;
        }
        enumerator = this.resList.GetEnumerator();
    Label_002C:
        try
        {
            goto Label_0049;
        Label_0031:
            transform = (Transform) enumerator.Current;
            transform.gameObject.SetActive(1);
        Label_0049:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0031;
            }
            goto Label_006B;
        }
        finally
        {
        Label_0059:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0064;
            }
        Label_0064:
            disposable.Dispose();
        }
    Label_006B:
        goto Label_0076;
    Label_0070:
        this.Hide();
    Label_0076:
        return;
    }

    private void Start()
    {
        this.textCurrentRes = base.transform.FindChild("CurrentRes").GetComponent<TextMesh>();
        if (this.resList != null)
        {
            goto Label_002C;
        }
        this.InitList();
    Label_002C:
        return;
    }
}

