using System;
using UnityEngine;

public class MenuOptionsAspectBox : MonoBehaviour
{
    private Transform aspectOption1;
    private Transform aspectOption2;
    private Transform aspectOption3;
    private Transform boxAspect16By10;
    private Transform boxAspect16By9;
    private Transform boxAspect4By3;
    private TextMesh textCurrentAspect;

    public MenuOptionsAspectBox()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.textCurrentAspect = base.transform.FindChild("CurrentAspect").GetComponent<TextMesh>();
        this.aspectOption1 = base.transform.FindChild("AspectOption1");
        this.aspectOption2 = base.transform.FindChild("AspectOption2");
        this.aspectOption3 = base.transform.FindChild("AspectOption3");
        this.boxAspect4By3 = base.transform.parent.FindChild("Aspect4By3");
        this.boxAspect16By9 = base.transform.parent.FindChild("Aspect16By9");
        this.boxAspect16By10 = base.transform.parent.FindChild("Aspect16By10");
        return;
    }

    private void FixedUpdate()
    {
    }

    public void SetCurrentAspect(GameData.aspectRatioEnum ratio)
    {
        GameData.aspectRatioEnum enum2;
        this.aspectOption1.gameObject.SetActive(0);
        this.aspectOption2.gameObject.SetActive(0);
        this.aspectOption3.gameObject.SetActive(0);
        enum2 = ratio;
        switch (enum2)
        {
            case 0:
                goto Label_004C;

            case 1:
                goto Label_0061;

            case 2:
                goto Label_0076;
        }
        goto Label_008B;
    Label_004C:
        this.textCurrentAspect.text = "4 : 3";
        goto Label_008B;
    Label_0061:
        this.textCurrentAspect.text = "16 : 9";
        goto Label_008B;
    Label_0076:
        this.textCurrentAspect.text = "16 : 10";
    Label_008B:
        return;
    }

    public void ShowMenu()
    {
        if (this.aspectOption1.gameObject.activeSelf != null)
        {
            goto Label_004D;
        }
        this.aspectOption1.gameObject.SetActive(1);
        this.aspectOption2.gameObject.SetActive(1);
        this.aspectOption3.gameObject.SetActive(1);
        goto Label_0080;
    Label_004D:
        this.aspectOption1.gameObject.SetActive(0);
        this.aspectOption2.gameObject.SetActive(0);
        this.aspectOption3.gameObject.SetActive(0);
    Label_0080:
        return;
    }

    private void Start()
    {
    }
}

