using System;
using UnityEngine;

public class MenuOptionsResItem : MonoBehaviour
{
    public int height;
    private MenuOptions menu;
    private MenuOptionsResBox resBox;
    private PackedSprite sprite;
    public int width;

    public MenuOptionsResItem()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        MonoBehaviour.print(((int) this.width) + " " + ((int) this.height));
        this.resBox.SetResolution(this.width, this.height);
        Screen.SetResolution(this.width, this.height, 1);
        this.RefreshSprites();
        return;
    }

    private void OnMouseEnter()
    {
        this.sprite.PlayAnim("over");
        return;
    }

    private void OnMouseExit()
    {
        this.sprite.RevertToStatic();
        return;
    }

    private void RefreshSprites()
    {
        AspectRatioCamMod[] modArray;
        AspectRatioCamMod mod;
        AspectRatioCamMod[] modArray2;
        int num;
        AspectRatioMod[] modArray3;
        AspectRatioMod mod2;
        AspectRatioMod[] modArray4;
        int num2;
        modArray = UnityEngine.Object.FindObjectsOfType(typeof(AspectRatioCamMod)) as AspectRatioCamMod[];
        modArray2 = modArray;
        num = 0;
        goto Label_0038;
    Label_001E:
        mod = modArray2[num];
        mod.Refresh(this.width, this.height);
        num += 1;
    Label_0038:
        if (num < ((int) modArray2.Length))
        {
            goto Label_001E;
        }
        modArray3 = UnityEngine.Object.FindObjectsOfType(typeof(AspectRatioMod)) as AspectRatioMod[];
        modArray4 = modArray3;
        num2 = 0;
        goto Label_0083;
    Label_0063:
        mod2 = modArray4[num2];
        mod2.Refresh(this.width, this.height);
        num2 += 1;
    Label_0083:
        if (num2 < ((int) modArray4.Length))
        {
            goto Label_0063;
        }
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.resBox = base.transform.parent.GetComponent<MenuOptionsResBox>();
        this.menu = base.transform.parent.parent.GetComponent<MenuOptions>();
        return;
    }
}

