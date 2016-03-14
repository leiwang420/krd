using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EncyclopediaTowerItem : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> switchmapB;
    private EncyclopediaContainerTowers containerTowers;
    private bool selected;
    private PackedSprite sprite;
    private PackedSprite spriteDecoration;
    private string type;

    public EncyclopediaTowerItem()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.containerTowers = base.transform.parent.GetComponent<EncyclopediaContainerTowers>();
        this.spriteDecoration = base.transform.FindChild("Decoration").GetComponent<PackedSprite>();
        this.spriteDecoration.transform.localPosition = new Vector3(0f, 0f, -1f);
        return;
    }

    private unsafe void CheckLock()
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = this.type;
        if (str == null)
        {
            goto Label_03F9;
        }
        if (switchmapB != null)
        {
            goto Label_00EC;
        }
        dictionary = new Dictionary<string, int>(0x10);
        dictionary.Add("archer_level2", 0);
        dictionary.Add("archer_level3", 1);
        dictionary.Add("archer_ranger", 2);
        dictionary.Add("archer_musketeer", 3);
        dictionary.Add("barrack_level2", 4);
        dictionary.Add("barrack_level3", 5);
        dictionary.Add("barrack_paladin", 6);
        dictionary.Add("barrack_barbarian", 7);
        dictionary.Add("mage_level2", 8);
        dictionary.Add("mage_level3", 9);
        dictionary.Add("mage_arcane", 10);
        dictionary.Add("mage_sorcerer", 11);
        dictionary.Add("artillery_level2", 12);
        dictionary.Add("artillery_level3", 13);
        dictionary.Add("artillery_bfg", 14);
        dictionary.Add("artillery_tesla", 15);
        switchmapB = dictionary;
    Label_00EC:
        if (switchmapB.TryGetValue(str, &num) == null)
        {
            goto Label_03F9;
        }
        switch (num)
        {
            case 0:
                goto Label_0149;

            case 1:
                goto Label_0174;

            case 2:
                goto Label_019F;

            case 3:
                goto Label_01CA;

            case 4:
                goto Label_01F5;

            case 5:
                goto Label_0220;

            case 6:
                goto Label_024B;

            case 7:
                goto Label_0276;

            case 8:
                goto Label_02A1;

            case 9:
                goto Label_02CC;

            case 10:
                goto Label_02F7;

            case 11:
                goto Label_0322;

            case 12:
                goto Label_034D;

            case 13:
                goto Label_0378;

            case 14:
                goto Label_03A3;

            case 15:
                goto Label_03CE;
        }
        goto Label_03F9;
    Label_0149:
        if (GameData.notificationTowerArchersLevel2 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_0174:
        if (GameData.notificationTowerArchersLevel3 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_019F:
        if (GameData.notificationTowerArchersRanger != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_01CA:
        if (GameData.notificationTowerArchersMusketeer != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_01F5:
        if (GameData.notificationTowerSoldiersLevel2 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_0220:
        if (GameData.notificationTowerSoldiersLevel3 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_024B:
        if (GameData.notificationTowerSoldiersPaladin != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_0276:
        if (GameData.notificationTowerSoldiersBarbarian != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_02A1:
        if (GameData.notificationTowerMagesLevel2 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_02CC:
        if (GameData.notificationTowerMagesLevel3 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_02F7:
        if (GameData.notificationTowerMagesArcane != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_0322:
        if (GameData.notificationTowerMagesSorcerer != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_034D:
        if (GameData.notificationTowerEngineersLevel2 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_0378:
        if (GameData.notificationTowerEngineersLevel3 != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_03A3:
        if (GameData.notificationTowerEngineersBfg != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_03F9;
    Label_03CE:
        if (GameData.notificationTowerEngineersTesla != null)
        {
            goto Label_03F9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
    Label_03F9:
        return;
    }

    public void Deselect()
    {
        this.spriteDecoration.Hide(1);
        this.selected = 0;
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.containerTowers.Select(this.type);
        this.spriteDecoration.Hide(0);
        this.spriteDecoration.RevertToStatic();
        this.selected = 1;
        GameSoundManager.PlayGUINotificationPaperOver();
        return;
    }

    private void OnMouseEnter()
    {
        if (this.selected != null)
        {
            goto Label_0027;
        }
        this.spriteDecoration.Hide(0);
        this.spriteDecoration.PlayAnim("over");
    Label_0027:
        return;
    }

    private void OnMouseExit()
    {
        if (this.selected != null)
        {
            goto Label_0017;
        }
        this.spriteDecoration.Hide(1);
    Label_0017:
        return;
    }

    public void Select()
    {
        this.containerTowers.Select(this.type);
        this.spriteDecoration.Hide(0);
        this.spriteDecoration.RevertToStatic();
        this.selected = 1;
        return;
    }

    public void SetType(string t)
    {
        this.type = t;
        if ((this.type != "archer_level1") == null)
        {
            goto Label_0061;
        }
        if ((this.type != "barrack_level1") == null)
        {
            goto Label_0061;
        }
        if ((this.type != "mage_level1") == null)
        {
            goto Label_0061;
        }
        if ((this.type != "artillery_level") == null)
        {
            goto Label_0061;
        }
        this.CheckLock();
    Label_0061:
        return;
    }

    private void ShowInfo()
    {
        MonoBehaviour.print("show info " + this.type);
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.containerTowers = base.transform.parent.GetComponent<EncyclopediaContainerTowers>();
        this.spriteDecoration = base.transform.FindChild("Decoration").GetComponent<PackedSprite>();
        this.spriteDecoration.transform.localPosition = new Vector3(0f, 0f, -1f);
        return;
    }

    public void UnSelect()
    {
    }

    public string Type
    {
        get
        {
            return this.type;
        }
    }
}

