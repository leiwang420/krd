using System;
using UnityEngine;

public class UpgradeScreenTooltip : MonoBehaviour
{
    public bool adjustFor43;
    private Transform textDescription;
    private Transform textTitle;

    public UpgradeScreenTooltip()
    {
        base..ctor();
        return;
    }

    private unsafe void Start()
    {
        Color color;
        PackedSprite sprite;
        &color = new Color(1f, 1f, 1f, 0.9f);
        base.transform.FindChild("Tool Tip").GetComponent<PackedSprite>().SetColor(color);
        base.transform.FindChild("Arrow").GetComponent<PackedSprite>().SetColor(color);
        this.textTitle = base.transform.FindChild("Title");
        this.textDescription = base.transform.FindChild("Description");
        if (this.adjustFor43 == null)
        {
            goto Label_0147;
        }
        if (GameData.AspectRatio != null)
        {
            goto Label_0147;
        }
        base.transform.localScale = new Vector3(-1f, 1f, 1f);
        this.textTitle.localScale = new Vector3(-1f, 1f, 1f);
        this.textDescription.localScale = new Vector3(-1f, 1f, 1f);
        this.textTitle.position -= new Vector3(235f, 0f, 0f);
        this.textDescription.position -= new Vector3(235f, 0f, 0f);
    Label_0147:
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        Vector3 vector2;
        if ((Camera.current != null) == null)
        {
            goto Label_005D;
        }
        vector = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        base.transform.position = new Vector3(&vector.x + 15f, &vector.y + 15f, &base.transform.position.z);
    Label_005D:
        return;
    }
}

