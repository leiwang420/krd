using System;
using UnityEngine;

public class StarContainer : MonoBehaviour
{
    private PackedSprite currentDecimal;
    private PackedSprite currentHundredth;
    private PackedSprite currentUnit;
    private PackedSprite totalDecimal;
    private PackedSprite totalHundredth;
    private PackedSprite totalUnit;

    public StarContainer()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void Start()
    {
        int num;
        int num2;
        int num3;
        int num4;
        int num5;
        int num6;
        this.currentHundredth = base.transform.FindChild("NumberCurrentHundredth").GetComponent<PackedSprite>();
        this.currentDecimal = base.transform.FindChild("NumberCurrentDecimal").GetComponent<PackedSprite>();
        this.currentUnit = base.transform.FindChild("NumberCurrentUnit").GetComponent<PackedSprite>();
        this.totalHundredth = base.transform.FindChild("NumberTotalHundredth").GetComponent<PackedSprite>();
        this.totalDecimal = base.transform.FindChild("NumberTotalDecimal").GetComponent<PackedSprite>();
        this.totalUnit = base.transform.FindChild("NumberTotalUnit").GetComponent<PackedSprite>();
        num = GameData.StarsTotal / 100;
        num2 = (GameData.StarsTotal / 10) % 10;
        num3 = GameData.StarsTotal % 10;
        if (num == null)
        {
            goto Label_00D4;
        }
        this.totalHundredth.PlayAnim(num - 1);
    Label_00D4:
        if (num2 == null)
        {
            goto Label_00E8;
        }
        this.totalDecimal.PlayAnim(num2 - 1);
    Label_00E8:
        if (num3 == null)
        {
            goto Label_00FC;
        }
        this.totalUnit.PlayAnim(num3 - 1);
    Label_00FC:
        num4 = GameData.StarsWon / 100;
        num5 = (GameData.StarsWon / 10) % 10;
        num6 = GameData.StarsWon % 10;
        if (num4 == null)
        {
            goto Label_0135;
        }
        this.currentHundredth.PlayAnim(num4 - 1);
        goto Label_0141;
    Label_0135:
        this.currentHundredth.Hide(1);
    Label_0141:
        if (num5 != null)
        {
            goto Label_014E;
        }
        if (num4 == null)
        {
            goto Label_0169;
        }
    Label_014E:
        if (num5 == null)
        {
            goto Label_0175;
        }
        this.currentDecimal.PlayAnim(num5 - 1);
        goto Label_0175;
    Label_0169:
        this.currentDecimal.Hide(1);
    Label_0175:
        if (num6 == null)
        {
            goto Label_018B;
        }
        this.currentUnit.PlayAnim(num6 - 1);
    Label_018B:
        return;
    }
}

