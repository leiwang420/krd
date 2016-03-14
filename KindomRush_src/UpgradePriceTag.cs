using System;
using UnityEngine;

public class UpgradePriceTag : MonoBehaviour
{
    private int cost;
    private PackedSprite numberSprite;
    private PackedSprite tagSprite;

    public UpgradePriceTag()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Hide()
    {
        this.tagSprite.Hide(1);
        this.numberSprite.Hide(1);
        return;
    }

    public void Off()
    {
        this.tagSprite.Hide(0);
        this.tagSprite.PlayAnim("off");
        this.numberSprite.Hide(0);
        if (this.cost != 1)
        {
            goto Label_0049;
        }
        this.numberSprite.PlayAnim("1off");
        goto Label_00A7;
    Label_0049:
        if (this.cost != 2)
        {
            goto Label_006A;
        }
        this.numberSprite.PlayAnim("2off");
        goto Label_00A7;
    Label_006A:
        if (this.cost != 3)
        {
            goto Label_008B;
        }
        this.numberSprite.PlayAnim("3off");
        goto Label_00A7;
    Label_008B:
        if (this.cost != 4)
        {
            goto Label_00A7;
        }
        this.numberSprite.PlayAnim("4off");
    Label_00A7:
        return;
    }

    public void SetCost(int c)
    {
        this.cost = c;
        if ((this.numberSprite == null) != null)
        {
            goto Label_0029;
        }
        if ((this.tagSprite == null) == null)
        {
            goto Label_0050;
        }
    Label_0029:
        this.numberSprite = base.transform.FindChild("Number").GetComponent<PackedSprite>();
        this.tagSprite = base.GetComponent<PackedSprite>();
    Label_0050:
        if (c != 1)
        {
            goto Label_0067;
        }
        this.numberSprite.RevertToStatic();
        goto Label_0092;
    Label_0067:
        if (c != 2)
        {
            goto Label_007F;
        }
        this.numberSprite.PlayAnim(0);
        goto Label_0092;
    Label_007F:
        if (c != 3)
        {
            goto Label_0092;
        }
        this.numberSprite.PlayAnim(1);
    Label_0092:
        return;
    }

    public void Show()
    {
        this.tagSprite.Hide(0);
        this.numberSprite.Hide(0);
        this.tagSprite.RevertToStatic();
        if (this.cost != 1)
        {
            goto Label_003F;
        }
        this.numberSprite.RevertToStatic();
        goto Label_0095;
    Label_003F:
        if (this.cost != 2)
        {
            goto Label_005C;
        }
        this.numberSprite.PlayAnim(0);
        goto Label_0095;
    Label_005C:
        if (this.cost != 3)
        {
            goto Label_0079;
        }
        this.numberSprite.PlayAnim(1);
        goto Label_0095;
    Label_0079:
        if (this.cost != 4)
        {
            goto Label_0095;
        }
        this.numberSprite.PlayAnim("4");
    Label_0095:
        return;
    }

    private void Start()
    {
        this.tagSprite = base.GetComponent<PackedSprite>();
        this.numberSprite = base.transform.FindChild("Number").GetComponent<PackedSprite>();
        return;
    }
}

