using System;
using UnityEngine;

public class SoldierHeroSamuraiSwordEffect : MonoBehaviour
{
    private int i;
    private PackedSprite sprite;

    public SoldierHeroSamuraiSwordEffect()
    {
        base..ctor();
        return;
    }

    protected void GoIn()
    {
        int num;
        this.i = UnityEngine.Random.Range(1, 5);
        switch ((this.i - 1))
        {
            case 0:
                goto Label_002D;

            case 1:
                goto Label_0042;

            case 2:
                goto Label_0057;
        }
        goto Label_006C;
    Label_002D:
        this.sprite.PlayAnim("animationIn1");
        goto Label_0081;
    Label_0042:
        this.sprite.PlayAnim("animationIn2");
        goto Label_0081;
    Label_0057:
        this.sprite.PlayAnim("animationIn3");
        goto Label_0081;
    Label_006C:
        this.sprite.PlayAnim("animationIn1");
    Label_0081:
        base.Invoke("GoOut", 1.5f);
        return;
    }

    protected void GoOut()
    {
        int num;
        switch ((this.i - 1))
        {
            case 0:
                goto Label_0020;

            case 1:
                goto Label_0035;

            case 2:
                goto Label_004A;
        }
        goto Label_005F;
    Label_0020:
        this.sprite.PlayAnim("animationOut1");
        goto Label_0074;
    Label_0035:
        this.sprite.PlayAnim("animationOut2");
        goto Label_0074;
    Label_004A:
        this.sprite.PlayAnim("animationOut3");
        goto Label_0074;
    Label_005F:
        this.sprite.PlayAnim("animationOut1");
    Label_0074:
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.GoIn();
        return;
    }
}

