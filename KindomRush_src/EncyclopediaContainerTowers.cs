using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EncyclopediaContainerTowers : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap9;
    private EncyclopediaTowerItem archerLevel1;
    private EncyclopediaTowerItem archerLevel2;
    private EncyclopediaTowerItem archerLevel3;
    private EncyclopediaTowerItem archerMusketeer;
    private EncyclopediaTowerItem archerRanger;
    private EncyclopediaTowerItem artilleryBfg;
    private EncyclopediaTowerItem artilleryLevel1;
    private EncyclopediaTowerItem artilleryLevel2;
    private EncyclopediaTowerItem artilleryLevel3;
    private EncyclopediaTowerItem artilleryTesla;
    private EncyclopediaTowerItem barrackBarbarian;
    private EncyclopediaTowerItem barrackLevel1;
    private EncyclopediaTowerItem barrackLevel2;
    private EncyclopediaTowerItem barrackLevel3;
    private EncyclopediaTowerItem barrackPaladin;
    private EncyclopediaScreen encyclopedia;
    private Transform footer;
    private Transform holderArcane;
    private Transform holderArcher1;
    private Transform holderArcher2;
    private Transform holderArcher3;
    private Transform holderArtillery1;
    private Transform holderArtillery2;
    private Transform holderArtillery3;
    private Transform holderBarbarian;
    private Transform holderBarrack1;
    private Transform holderBarrack2;
    private Transform holderBarrack3;
    private Transform holderBFG;
    private Transform holderMage1;
    private Transform holderMage2;
    private Transform holderMage3;
    private Transform holderMusketeer;
    private Transform holderPaladin;
    private Transform holderRanger;
    private Transform holderSorcerer;
    private Transform holderTesla;
    private EncyclopediaTowerItem mageArcane;
    private EncyclopediaTowerItem mageLevel1;
    private EncyclopediaTowerItem mageLevel2;
    private EncyclopediaTowerItem mageLevel3;
    private EncyclopediaTowerItem mageSorcerer;
    private EncyclopediaTowerItem selectedItem;

    public EncyclopediaContainerTowers()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void InitPositions()
    {
        this.archerLevel1.transform.localPosition = new Vector3(-344f, 189f, -4f);
        this.archerLevel2.transform.localPosition = new Vector3(-344f, 107f, -4f);
        this.archerLevel3.transform.localPosition = new Vector3(-344f, 25f, -4f);
        this.archerRanger.transform.localPosition = new Vector3(-344f, -86f, -4f);
        this.archerMusketeer.transform.localPosition = new Vector3(-344f, -168f, -4f);
        this.barrackLevel1.transform.localPosition = new Vector3(-257f, 189f, -4f);
        this.barrackLevel2.transform.localPosition = new Vector3(-257f, 107f, -4f);
        this.barrackLevel3.transform.localPosition = new Vector3(-257f, 25f, -4f);
        this.barrackPaladin.transform.localPosition = new Vector3(-257f, -86f, -4f);
        this.barrackBarbarian.transform.localPosition = new Vector3(-257f, -168f, -4f);
        this.mageLevel1.transform.localPosition = new Vector3(-167f, 189f, -4f);
        this.mageLevel2.transform.localPosition = new Vector3(-167f, 107f, -4f);
        this.mageLevel3.transform.localPosition = new Vector3(-167f, 25f, -4f);
        this.mageArcane.transform.localPosition = new Vector3(-167f, -86f, -4f);
        this.mageSorcerer.transform.localPosition = new Vector3(-167f, -168f, -4f);
        this.artilleryLevel1.transform.localPosition = new Vector3(-80f, 189f, -4f);
        this.artilleryLevel2.transform.localPosition = new Vector3(-80f, 107f, -4f);
        this.artilleryLevel3.transform.localPosition = new Vector3(-80f, 25f, -4f);
        this.artilleryBfg.transform.localPosition = new Vector3(-80f, -86f, -4f);
        this.artilleryTesla.transform.localPosition = new Vector3(-80f, -168f, -4f);
        return;
    }

    private void InitTypes()
    {
        this.archerLevel1.SetType("archer_level1");
        this.archerLevel2.SetType("archer_level2");
        this.archerLevel3.SetType("archer_level3");
        this.archerRanger.SetType("archer_ranger");
        this.archerMusketeer.SetType("archer_musketeer");
        this.barrackLevel1.SetType("barrack_level1");
        this.barrackLevel2.SetType("barrack_level2");
        this.barrackLevel3.SetType("barrack_level3");
        this.barrackPaladin.SetType("barrack_paladin");
        this.barrackBarbarian.SetType("barrack_barbarian");
        this.mageLevel1.SetType("mage_level1");
        this.mageLevel2.SetType("mage_level2");
        this.mageLevel3.SetType("mage_level3");
        this.mageArcane.SetType("mage_arcane");
        this.mageSorcerer.SetType("mage_sorcerer");
        this.artilleryLevel1.SetType("artillery_level1");
        this.artilleryLevel2.SetType("artillery_level2");
        this.artilleryLevel3.SetType("artillery_level3");
        this.artilleryBfg.SetType("artillery_bfg");
        this.artilleryTesla.SetType("artillery_tesla");
        return;
    }

    public void Reset()
    {
        this.holderArcher1.gameObject.SetActive(1);
        this.archerLevel1.Select();
        this.holderArcher2.gameObject.SetActive(0);
        this.holderArcher3.gameObject.SetActive(0);
        this.holderMusketeer.gameObject.SetActive(0);
        this.holderRanger.gameObject.SetActive(0);
        this.holderArtillery1.gameObject.SetActive(0);
        this.holderArtillery2.gameObject.SetActive(0);
        this.holderArtillery3.gameObject.SetActive(0);
        this.holderBFG.gameObject.SetActive(0);
        this.holderTesla.gameObject.SetActive(0);
        this.holderBarrack1.gameObject.SetActive(0);
        this.holderBarrack2.gameObject.SetActive(0);
        this.holderBarrack3.gameObject.SetActive(0);
        this.holderPaladin.gameObject.SetActive(0);
        this.holderBarbarian.gameObject.SetActive(0);
        this.holderMage1.gameObject.SetActive(0);
        this.holderMage2.gameObject.SetActive(0);
        this.holderMage3.gameObject.SetActive(0);
        this.holderArcane.gameObject.SetActive(0);
        this.holderSorcerer.gameObject.SetActive(0);
        this.footer.gameObject.SetActive(0);
        return;
    }

    private void ResetHolders()
    {
        this.holderArcher1.gameObject.SetActive(0);
        this.holderArcher2.gameObject.SetActive(0);
        this.holderArcher3.gameObject.SetActive(0);
        this.holderMusketeer.gameObject.SetActive(0);
        this.holderRanger.gameObject.SetActive(0);
        this.holderArtillery1.gameObject.SetActive(0);
        this.holderArtillery2.gameObject.SetActive(0);
        this.holderArtillery3.gameObject.SetActive(0);
        this.holderBFG.gameObject.SetActive(0);
        this.holderTesla.gameObject.SetActive(0);
        this.holderBarrack1.gameObject.SetActive(0);
        this.holderBarrack2.gameObject.SetActive(0);
        this.holderBarrack3.gameObject.SetActive(0);
        this.holderPaladin.gameObject.SetActive(0);
        this.holderBarbarian.gameObject.SetActive(0);
        this.holderMage1.gameObject.SetActive(0);
        this.holderMage2.gameObject.SetActive(0);
        this.holderMage3.gameObject.SetActive(0);
        this.holderArcane.gameObject.SetActive(0);
        this.holderSorcerer.gameObject.SetActive(0);
        this.footer.gameObject.SetActive(0);
        return;
    }

    private void ResetItems()
    {
        this.archerLevel1.Deselect();
        this.archerLevel2.Deselect();
        this.archerLevel3.Deselect();
        this.archerRanger.Deselect();
        this.archerMusketeer.Deselect();
        this.artilleryLevel1.Deselect();
        this.artilleryLevel2.Deselect();
        this.artilleryLevel3.Deselect();
        this.artilleryBfg.Deselect();
        this.artilleryTesla.Deselect();
        this.barrackLevel1.Deselect();
        this.barrackLevel2.Deselect();
        this.barrackLevel3.Deselect();
        this.barrackPaladin.Deselect();
        this.barrackBarbarian.Deselect();
        this.mageLevel1.Deselect();
        this.mageLevel2.Deselect();
        this.mageLevel3.Deselect();
        this.mageArcane.Deselect();
        this.mageSorcerer.Deselect();
        return;
    }

    public unsafe void Select(string item)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        this.ResetHolders();
        this.ResetItems();
        str = item;
        if (str == null)
        {
            goto Label_03D4;
        }
        if (switchmap9 != null)
        {
            goto Label_0127;
        }
        dictionary = new Dictionary<string, int>(20);
        dictionary.Add("archer_level1", 0);
        dictionary.Add("archer_level2", 1);
        dictionary.Add("archer_level3", 2);
        dictionary.Add("archer_musketeer", 3);
        dictionary.Add("archer_ranger", 4);
        dictionary.Add("artillery_level1", 5);
        dictionary.Add("artillery_level2", 6);
        dictionary.Add("artillery_level3", 7);
        dictionary.Add("artillery_bfg", 8);
        dictionary.Add("artillery_tesla", 9);
        dictionary.Add("barrack_level1", 10);
        dictionary.Add("barrack_level2", 11);
        dictionary.Add("barrack_level3", 12);
        dictionary.Add("barrack_paladin", 13);
        dictionary.Add("barrack_barbarian", 14);
        dictionary.Add("mage_level1", 15);
        dictionary.Add("mage_level2", 0x10);
        dictionary.Add("mage_level3", 0x11);
        dictionary.Add("mage_arcane", 0x12);
        dictionary.Add("mage_sorcerer", 0x13);
        switchmap9 = dictionary;
    Label_0127:
        if (switchmap9.TryGetValue(str, &num) == null)
        {
            goto Label_03D4;
        }
        switch (num)
        {
            case 0:
                goto Label_0194;

            case 1:
                goto Label_01AA;

            case 2:
                goto Label_01C0;

            case 3:
                goto Label_01D6;

            case 4:
                goto Label_01FD;

            case 5:
                goto Label_0224;

            case 6:
                goto Label_023A;

            case 7:
                goto Label_0250;

            case 8:
                goto Label_0266;

            case 9:
                goto Label_028D;

            case 10:
                goto Label_02B4;

            case 11:
                goto Label_02CA;

            case 12:
                goto Label_02E0;

            case 13:
                goto Label_02F6;

            case 14:
                goto Label_031D;

            case 15:
                goto Label_0344;

            case 0x10:
                goto Label_035A;

            case 0x11:
                goto Label_0370;

            case 0x12:
                goto Label_0386;

            case 0x13:
                goto Label_03AD;
        }
        goto Label_03D4;
    Label_0194:
        this.holderArcher1.gameObject.SetActive(1);
        goto Label_03D4;
    Label_01AA:
        this.holderArcher2.gameObject.SetActive(1);
        goto Label_03D4;
    Label_01C0:
        this.holderArcher3.gameObject.SetActive(1);
        goto Label_03D4;
    Label_01D6:
        this.holderMusketeer.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_01FD:
        this.holderRanger.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_0224:
        this.holderArtillery1.gameObject.SetActive(1);
        goto Label_03D4;
    Label_023A:
        this.holderArtillery2.gameObject.SetActive(1);
        goto Label_03D4;
    Label_0250:
        this.holderArtillery3.gameObject.SetActive(1);
        goto Label_03D4;
    Label_0266:
        this.holderBFG.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_028D:
        this.holderTesla.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_02B4:
        this.holderBarrack1.gameObject.SetActive(1);
        goto Label_03D4;
    Label_02CA:
        this.holderBarrack2.gameObject.SetActive(1);
        goto Label_03D4;
    Label_02E0:
        this.holderBarrack3.gameObject.SetActive(1);
        goto Label_03D4;
    Label_02F6:
        this.holderPaladin.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_031D:
        this.holderBarbarian.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_0344:
        this.holderMage1.gameObject.SetActive(1);
        goto Label_03D4;
    Label_035A:
        this.holderMage2.gameObject.SetActive(1);
        goto Label_03D4;
    Label_0370:
        this.holderMage3.gameObject.SetActive(1);
        goto Label_03D4;
    Label_0386:
        this.holderArcane.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_03D4;
    Label_03AD:
        this.holderSorcerer.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
    Label_03D4:
        return;
    }

    private void Start()
    {
        this.encyclopedia = base.transform.parent.GetComponent<EncyclopediaScreen>();
        this.archerLevel1 = base.transform.FindChild("archer_level1").GetComponent<EncyclopediaTowerItem>();
        this.archerLevel2 = base.transform.FindChild("archer_level2").GetComponent<EncyclopediaTowerItem>();
        this.archerLevel3 = base.transform.FindChild("archer_level3").GetComponent<EncyclopediaTowerItem>();
        this.archerRanger = base.transform.FindChild("archer_ranger").GetComponent<EncyclopediaTowerItem>();
        this.archerMusketeer = base.transform.FindChild("archer_musketeer").GetComponent<EncyclopediaTowerItem>();
        this.artilleryLevel1 = base.transform.FindChild("artillery_level1").GetComponent<EncyclopediaTowerItem>();
        this.artilleryLevel2 = base.transform.FindChild("artillery_level2").GetComponent<EncyclopediaTowerItem>();
        this.artilleryLevel3 = base.transform.FindChild("artillery_level3").GetComponent<EncyclopediaTowerItem>();
        this.artilleryBfg = base.transform.FindChild("artillery_bfg").GetComponent<EncyclopediaTowerItem>();
        this.artilleryTesla = base.transform.FindChild("artillery_tesla").GetComponent<EncyclopediaTowerItem>();
        this.barrackLevel1 = base.transform.FindChild("barrack_level1").GetComponent<EncyclopediaTowerItem>();
        this.barrackLevel2 = base.transform.FindChild("barrack_level2").GetComponent<EncyclopediaTowerItem>();
        this.barrackLevel3 = base.transform.FindChild("barrack_level3").GetComponent<EncyclopediaTowerItem>();
        this.barrackPaladin = base.transform.FindChild("barrack_paladin").GetComponent<EncyclopediaTowerItem>();
        this.barrackBarbarian = base.transform.FindChild("barrack_barbarian").GetComponent<EncyclopediaTowerItem>();
        this.mageLevel1 = base.transform.FindChild("mage_level1").GetComponent<EncyclopediaTowerItem>();
        this.mageLevel2 = base.transform.FindChild("mage_level2").GetComponent<EncyclopediaTowerItem>();
        this.mageLevel3 = base.transform.FindChild("mage_level3").GetComponent<EncyclopediaTowerItem>();
        this.mageArcane = base.transform.FindChild("mage_arcane").GetComponent<EncyclopediaTowerItem>();
        this.mageSorcerer = base.transform.FindChild("mage_sorcerer").GetComponent<EncyclopediaTowerItem>();
        this.holderArcher1 = base.transform.FindChild("HolderArcher1");
        this.holderArcher2 = base.transform.FindChild("HolderArcher2");
        this.holderArcher3 = base.transform.FindChild("HolderArcher3");
        this.holderMusketeer = base.transform.FindChild("HolderMusketeer");
        this.holderRanger = base.transform.FindChild("HolderRanger");
        this.holderArtillery1 = base.transform.FindChild("HolderArtillery1");
        this.holderArtillery2 = base.transform.FindChild("HolderArtillery2");
        this.holderArtillery3 = base.transform.FindChild("HolderArtillery3");
        this.holderBFG = base.transform.FindChild("HolderBFG");
        this.holderTesla = base.transform.FindChild("HolderTesla");
        this.holderBarrack1 = base.transform.FindChild("HolderBarrack1");
        this.holderBarrack2 = base.transform.FindChild("HolderBarrack2");
        this.holderBarrack3 = base.transform.FindChild("HolderBarrack3");
        this.holderPaladin = base.transform.FindChild("HolderPaladin");
        this.holderBarbarian = base.transform.FindChild("HolderBarbarian");
        this.holderMage1 = base.transform.FindChild("HolderMage1");
        this.holderMage2 = base.transform.FindChild("HolderMage2");
        this.holderMage3 = base.transform.FindChild("HolderMage3");
        this.holderArcane = base.transform.FindChild("HolderArcane");
        this.holderSorcerer = base.transform.FindChild("HolderSorcerer");
        this.footer = base.transform.FindChild("Footer");
        this.ResetHolders();
        this.InitPositions();
        this.InitTypes();
        return;
    }
}

