using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AchievementItem : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap7;
    private PackedSprite icon;
    private Transform textOff;
    private Transform textOn;

    public AchievementItem()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.icon = base.transform.FindChild("Icon").GetComponent<PackedSprite>();
        this.textOn = base.transform.FindChild("Text On");
        this.textOff = base.transform.FindChild("Text Off");
        return;
    }

    public unsafe void CheckStatus()
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = base.transform.name;
        if (str == null)
        {
            goto Label_203E;
        }
        if (switchmap7 != null)
        {
            goto Label_0361;
        }
        dictionary = new Dictionary<string, int>(0x40);
        dictionary.Add("Armaggedon", 0);
        dictionary.Add("Bloodlust", 1);
        dictionary.Add("Constructor", 2);
        dictionary.Add("Daring", 3);
        dictionary.Add("FirstBlood", 4);
        dictionary.Add("Home Improvement", 5);
        dictionary.Add("Nuts and Bolts", 6);
        dictionary.Add("Starry", 7);
        dictionary.Add("Super Mario", 8);
        dictionary.Add("What's That?", 9);
        dictionary.Add("Engineer", 10);
        dictionary.Add("Is He Dead Yet?", 11);
        dictionary.Add("Slayer", 12);
        dictionary.Add("Death from Above", 13);
        dictionary.Add("Tactician", 14);
        dictionary.Add("Superstar", 15);
        dictionary.Add("The Architect", 0x10);
        dictionary.Add("This is the End!", 0x11);
        dictionary.Add("Terminator", 0x12);
        dictionary.Add("Die Hard", 0x13);
        dictionary.Add("Cannon Fodder", 20);
        dictionary.Add("Fearless", 0x15);
        dictionary.Add("Forest Diplomacy", 0x16);
        dictionary.Add("G.I. Joe", 0x17);
        dictionary.Add("Impatient", 0x18);
        dictionary.Add("Imperial Saviour", 0x19);
        dictionary.Add("Indecisive", 0x1a);
        dictionary.Add("Like a Henderson", 0x1b);
        dictionary.Add("Real Estate", 0x1c);
        dictionary.Add("Specialist", 0x1d);
        dictionary.Add("50 Shots 50 Kills", 30);
        dictionary.Add("Are you not entertained?", 0x1f);
        dictionary.Add("Axe Rain", 0x20);
        dictionary.Add("Beam me up Scotty", 0x21);
        dictionary.Add("Dust to Dust", 0x22);
        dictionary.Add("Elementalist", 0x23);
        dictionary.Add("Entangled", 0x24);
        dictionary.Add("Medic", 0x25);
        dictionary.Add("Sheperd", 0x26);
        dictionary.Add("Toxicity", 0x27);
        dictionary.Add("AC/DC", 40);
        dictionary.Add("Clustered", 0x29);
        dictionary.Add("Energy Network", 0x2a);
        dictionary.Add("Great Defender", 0x2b);
        dictionary.Add("Heroic Defender", 0x2c);
        dictionary.Add("Holy Chorus", 0x2d);
        dictionary.Add("Iron Defender", 0x2e);
        dictionary.Add("Ovinophobia", 0x2f);
        dictionary.Add("Rocketeer", 0x30);
        dictionary.Add("Twin Rivers Angler", 0x31);
        dictionary.Add("Arachnophobia", 50);
        dictionary.Add("Champion of Linirea", 0x33);
        dictionary.Add("Free Fredo", 0x34);
        dictionary.Add("I'am the Law", 0x35);
        dictionary.Add("Legend of Linirea", 0x36);
        dictionary.Add("Lumberjack", 0x37);
        dictionary.Add("Orcs must die", 0x38);
        dictionary.Add("Cool Runnings", 0x39);
        dictionary.Add("Scrat's Meal", 0x3a);
        dictionary.Add("Plants vs Trolls", 0x3b);
        dictionary.Add("Dont feed the troll", 60);
        dictionary.Add("Army of one", 0x3d);
        dictionary.Add("Dine in Hell", 0x3e);
        dictionary.Add("Hell-o!", 0x3f);
        switchmap7 = dictionary;
    Label_0361:
        if (switchmap7.TryGetValue(str, &num) == null)
        {
            goto Label_203E;
        }
        switch (num)
        {
            case 0:
                goto Label_047E;

            case 1:
                goto Label_04ED;

            case 2:
                goto Label_055C;

            case 3:
                goto Label_05CB;

            case 4:
                goto Label_063A;

            case 5:
                goto Label_06A9;

            case 6:
                goto Label_0718;

            case 7:
                goto Label_0787;

            case 8:
                goto Label_07F6;

            case 9:
                goto Label_0865;

            case 10:
                goto Label_08D4;

            case 11:
                goto Label_0943;

            case 12:
                goto Label_09B2;

            case 13:
                goto Label_0A21;

            case 14:
                goto Label_0A90;

            case 15:
                goto Label_0AFF;

            case 0x10:
                goto Label_0B6E;

            case 0x11:
                goto Label_0BDD;

            case 0x12:
                goto Label_0C4C;

            case 0x13:
                goto Label_0CBB;

            case 20:
                goto Label_0D2A;

            case 0x15:
                goto Label_0D99;

            case 0x16:
                goto Label_0E08;

            case 0x17:
                goto Label_0E77;

            case 0x18:
                goto Label_0EE6;

            case 0x19:
                goto Label_0F55;

            case 0x1a:
                goto Label_0FC4;

            case 0x1b:
                goto Label_1033;

            case 0x1c:
                goto Label_10A2;

            case 0x1d:
                goto Label_1111;

            case 30:
                goto Label_1180;

            case 0x1f:
                goto Label_11EF;

            case 0x20:
                goto Label_125E;

            case 0x21:
                goto Label_12CD;

            case 0x22:
                goto Label_133C;

            case 0x23:
                goto Label_13AB;

            case 0x24:
                goto Label_141A;

            case 0x25:
                goto Label_1489;

            case 0x26:
                goto Label_14F8;

            case 0x27:
                goto Label_1567;

            case 40:
                goto Label_15D6;

            case 0x29:
                goto Label_1645;

            case 0x2a:
                goto Label_16B4;

            case 0x2b:
                goto Label_1723;

            case 0x2c:
                goto Label_1792;

            case 0x2d:
                goto Label_1801;

            case 0x2e:
                goto Label_1870;

            case 0x2f:
                goto Label_18DF;

            case 0x30:
                goto Label_194E;

            case 0x31:
                goto Label_19BD;

            case 50:
                goto Label_1A2C;

            case 0x33:
                goto Label_1A9B;

            case 0x34:
                goto Label_1B0A;

            case 0x35:
                goto Label_1B79;

            case 0x36:
                goto Label_1BE8;

            case 0x37:
                goto Label_1C57;

            case 0x38:
                goto Label_1CC6;

            case 0x39:
                goto Label_1D35;

            case 0x3a:
                goto Label_1DA4;

            case 0x3b:
                goto Label_1E13;

            case 60:
                goto Label_1E82;

            case 0x3d:
                goto Label_1EF1;

            case 0x3e:
                goto Label_1F60;

            case 0x3f:
                goto Label_1FCF;
        }
        goto Label_203E;
    Label_047E:
        if (GameAchievements.Armaggedon == null)
        {
            goto Label_04BA;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_04E8;
    Label_04BA:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_04E8:
        goto Label_203E;
    Label_04ED:
        if (GameAchievements.Bloodlust == null)
        {
            goto Label_0529;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0557;
    Label_0529:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0557:
        goto Label_203E;
    Label_055C:
        if (GameAchievements.Bloodlust == null)
        {
            goto Label_0598;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_05C6;
    Label_0598:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_05C6:
        goto Label_203E;
    Label_05CB:
        if (GameAchievements.Daring == null)
        {
            goto Label_0607;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0635;
    Label_0607:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0635:
        goto Label_203E;
    Label_063A:
        if (GameAchievements.FirstBlood == null)
        {
            goto Label_0676;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_06A4;
    Label_0676:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_06A4:
        goto Label_203E;
    Label_06A9:
        if (GameAchievements.TowerUpgradeLevel3 == null)
        {
            goto Label_06E5;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0713;
    Label_06E5:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0713:
        goto Label_203E;
    Label_0718:
        if (GameAchievements.KillJuggernaut == null)
        {
            goto Label_0754;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0782;
    Label_0754:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0782:
        goto Label_203E;
    Label_0787:
        if (GameAchievements.Earn15Stars == null)
        {
            goto Label_07C3;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_07F1;
    Label_07C3:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_07F1:
        goto Label_203E;
    Label_07F6:
        if (GameAchievements.Earn30Stars == null)
        {
            goto Label_0832;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0860;
    Label_0832:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0860:
        goto Label_203E;
    Label_0865:
        if (GameAchievements.WhatsThat == null)
        {
            goto Label_08A1;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_08CF;
    Label_08A1:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_08CF:
        goto Label_203E;
    Label_08D4:
        if (GameAchievements.MediumTowerBuilder == null)
        {
            goto Label_0910;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_093E;
    Label_0910:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_093E:
        goto Label_203E;
    Label_0943:
        if (GameAchievements.KillMountainBoss == null)
        {
            goto Label_097F;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_09AD;
    Label_097F:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_09AD:
        goto Label_203E;
    Label_09B2:
        if (GameAchievements.Slayer == null)
        {
            goto Label_09EE;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0A1C;
    Label_09EE:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0A1C:
        goto Label_203E;
    Label_0A21:
        if (GameAchievements.DeathFromAbove == null)
        {
            goto Label_0A5D;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0A8B;
    Label_0A5D:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0A8B:
        goto Label_203E;
    Label_0A90:
        if (GameAchievements.Tactician == null)
        {
            goto Label_0ACC;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0AFA;
    Label_0ACC:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0AFA:
        goto Label_203E;
    Label_0AFF:
        if (GameAchievements.Earn45Stars == null)
        {
            goto Label_0B3B;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0B69;
    Label_0B3B:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0B69:
        goto Label_203E;
    Label_0B6E:
        if (GameAchievements.HardTowerBuilder == null)
        {
            goto Label_0BAA;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0BD8;
    Label_0BAA:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0BD8:
        goto Label_203E;
    Label_0BDD:
        if (GameAchievements.KillEndBoss == null)
        {
            goto Label_0C19;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0C47;
    Label_0C19:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0C47:
        goto Label_203E;
    Label_0C4C:
        if (GameAchievements.MultiKill == null)
        {
            goto Label_0C88;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0CB6;
    Label_0C88:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0CB6:
        goto Label_203E;
    Label_0CBB:
        if (GameAchievements.DieHard == null)
        {
            goto Label_0CF7;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0D25;
    Label_0CF7:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0D25:
        goto Label_203E;
    Label_0D2A:
        if (GameAchievements.CannonFodder == null)
        {
            goto Label_0D66;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0D94;
    Label_0D66:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0D94:
        goto Label_203E;
    Label_0D99:
        if (GameAchievements.Fearless == null)
        {
            goto Label_0DD5;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0E03;
    Label_0DD5:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0E03:
        goto Label_203E;
    Label_0E08:
        if (GameAchievements.MaxElves == null)
        {
            goto Label_0E44;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0E72;
    Label_0E44:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0E72:
        goto Label_203E;
    Label_0E77:
        if (GameAchievements.GiJoe == null)
        {
            goto Label_0EB3;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0EE1;
    Label_0EB3:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0EE1:
        goto Label_203E;
    Label_0EE6:
        if (GameAchievements.Impatient == null)
        {
            goto Label_0F22;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0F50;
    Label_0F22:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0F50:
        goto Label_203E;
    Label_0F55:
        if (GameAchievements.ImperialSaviour == null)
        {
            goto Label_0F91;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_0FBF;
    Label_0F91:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_0FBF:
        goto Label_203E;
    Label_0FC4:
        if (GameAchievements.Indecisive == null)
        {
            goto Label_1000;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_102E;
    Label_1000:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_102E:
        goto Label_203E;
    Label_1033:
        if (GameAchievements.Henderson == null)
        {
            goto Label_106F;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_109D;
    Label_106F:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_109D:
        goto Label_203E;
    Label_10A2:
        if (GameAchievements.RealEstate == null)
        {
            goto Label_10DE;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_110C;
    Label_10DE:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_110C:
        goto Label_203E;
    Label_1111:
        if (GameAchievements.Specialization == null)
        {
            goto Label_114D;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_117B;
    Label_114D:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_117B:
        goto Label_203E;
    Label_1180:
        if (GameAchievements.Sniper == null)
        {
            goto Label_11BC;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_11EA;
    Label_11BC:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_11EA:
        goto Label_203E;
    Label_11EF:
        if (GameAchievements.BarbarianRush == null)
        {
            goto Label_122B;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1259;
    Label_122B:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1259:
        goto Label_203E;
    Label_125E:
        if (GameAchievements.AxeRainer == null)
        {
            goto Label_129A;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_12C8;
    Label_129A:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_12C8:
        goto Label_203E;
    Label_12CD:
        if (GameAchievements.BeamMeUp == null)
        {
            goto Label_1309;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1337;
    Label_1309:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1337:
        goto Label_203E;
    Label_133C:
        if (GameAchievements.DustToDust == null)
        {
            goto Label_1378;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_13A6;
    Label_1378:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_13A6:
        goto Label_203E;
    Label_13AB:
        if (GameAchievements.Elementalist == null)
        {
            goto Label_13E7;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1415;
    Label_13E7:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1415:
        goto Label_203E;
    Label_141A:
        if (GameAchievements.Entangled == null)
        {
            goto Label_1456;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1484;
    Label_1456:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1484:
        goto Label_203E;
    Label_1489:
        if (GameAchievements.Medic == null)
        {
            goto Label_14C5;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_14F3;
    Label_14C5:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_14F3:
        goto Label_203E;
    Label_14F8:
        if (GameAchievements.Shepard == null)
        {
            goto Label_1534;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1562;
    Label_1534:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1562:
        goto Label_203E;
    Label_1567:
        if (GameAchievements.Toxicity == null)
        {
            goto Label_15A3;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_15D1;
    Label_15A3:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_15D1:
        goto Label_203E;
    Label_15D6:
        if (GameAchievements.ACDC == null)
        {
            goto Label_1612;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1640;
    Label_1612:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1640:
        goto Label_203E;
    Label_1645:
        if (GameAchievements.ClusterRain == null)
        {
            goto Label_1681;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_16AF;
    Label_1681:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_16AF:
        goto Label_203E;
    Label_16B4:
        if (GameAchievements.EnergyNetwork == null)
        {
            goto Label_16F0;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_171E;
    Label_16F0:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_171E:
        goto Label_203E;
    Label_1723:
        if (GameAchievements.GreatDefender == null)
        {
            goto Label_175F;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_178D;
    Label_175F:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_178D:
        goto Label_203E;
    Label_1792:
        if (GameAchievements.GreatDefenderHeroic == null)
        {
            goto Label_17CE;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_17FC;
    Label_17CE:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_17FC:
        goto Label_203E;
    Label_1801:
        if (GameAchievements.HolyChorus == null)
        {
            goto Label_183D;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_186B;
    Label_183D:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_186B:
        goto Label_203E;
    Label_1870:
        if (GameAchievements.GreatDefenderIron == null)
        {
            goto Label_18AC;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_18DA;
    Label_18AC:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_18DA:
        goto Label_203E;
    Label_18DF:
        if (GameAchievements.SheepKiller == null)
        {
            goto Label_191B;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1949;
    Label_191B:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1949:
        goto Label_203E;
    Label_194E:
        if (GameAchievements.Rocketeer == null)
        {
            goto Label_198A;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_19B8;
    Label_198A:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_19B8:
        goto Label_203E;
    Label_19BD:
        if (GameAchievements.Fisherman == null)
        {
            goto Label_19F9;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1A27;
    Label_19F9:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1A27:
        goto Label_203E;
    Label_1A2C:
        if (GameAchievements.KillSarelgaz == null)
        {
            goto Label_1A68;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1A96;
    Label_1A68:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1A96:
        goto Label_203E;
    Label_1A9B:
        if (GameAchievements.LevelHeroMedium == null)
        {
            goto Label_1AD7;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1B05;
    Label_1AD7:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1B05:
        goto Label_203E;
    Label_1B0A:
        if (GameAchievements.FreeFredo == null)
        {
            goto Label_1B46;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1B74;
    Label_1B46:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1B74:
        goto Label_203E;
    Label_1B79:
        if (GameAchievements.KillKingpin == null)
        {
            goto Label_1BB5;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1BE3;
    Label_1BB5:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1BE3:
        goto Label_203E;
    Label_1BE8:
        if (GameAchievements.LevelHeroMax == null)
        {
            goto Label_1C24;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1C52;
    Label_1C24:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1C52:
        goto Label_203E;
    Label_1C57:
        if (GameAchievements.KillGreenmuck == null)
        {
            goto Label_1C93;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1CC1;
    Label_1C93:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1CC1:
        goto Label_203E;
    Label_1CC6:
        if (GameAchievements.KillGulthak == null)
        {
            goto Label_1D02;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1D30;
    Label_1D02:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1D30:
        goto Label_203E;
    Label_1D35:
        if (GameAchievements.CoolRunning == null)
        {
            goto Label_1D71;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1D9F;
    Label_1D71:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1D9F:
        goto Label_203E;
    Label_1DA4:
        if (GameAchievements.Acorn == null)
        {
            goto Label_1DE0;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1E0E;
    Label_1DE0:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1E0E:
        goto Label_203E;
    Label_1E13:
        if (GameAchievements.Mushroom == null)
        {
            goto Label_1E4F;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1E7D;
    Label_1E4F:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1E7D:
        goto Label_203E;
    Label_1E82:
        if (GameAchievements.KillTrollBoss == null)
        {
            goto Label_1EBE;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1EEC;
    Label_1EBE:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1EEC:
        goto Label_203E;
    Label_1EF1:
        if (GameAchievements.ArmyOfOne == null)
        {
            goto Label_1F2D;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1F5B;
    Label_1F2D:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1F5B:
        goto Label_203E;
    Label_1F60:
        if (GameAchievements.DineInHell == null)
        {
            goto Label_1F9C;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_1FCA;
    Label_1F9C:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_1FCA:
        goto Label_203E;
    Label_1FCF:
        if (GameAchievements.KillDemon == null)
        {
            goto Label_200B;
        }
        this.icon.RevertToStatic();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(0);
        goto Label_2039;
    Label_200B:
        this.icon.PlayAnim(0);
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(1);
    Label_2039:;
    Label_203E:
        return;
    }

    public void Fade()
    {
        ParticleFadeOut @out;
        ParticleFadeOut out2;
        this.textOn.gameObject.SetActive(0);
        this.textOff.gameObject.SetActive(0);
        if ((base.GetComponent<ParticleFadeOut>() == null) == null)
        {
            goto Label_008D;
        }
        @out = base.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        out2 = this.icon.gameObject.AddComponent<ParticleFadeOut>();
        out2.fadeSpeed = 0.3f;
        out2.finalOpacity = 0f;
        out2.Fade();
        goto Label_00A8;
    Label_008D:
        base.GetComponent<ParticleFadeOut>().Fade();
        this.icon.GetComponent<ParticleFadeOut>().Fade();
    Label_00A8:
        return;
    }

    private void FixedUpdate()
    {
    }

    public void ResetFade()
    {
        if ((base.GetComponent<ParticleFadeOut>() == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        this.icon.GetComponent<ParticleFadeOut>().Reset();
        base.GetComponent<ParticleFadeOut>().Reset();
        this.textOn.gameObject.SetActive(1);
        this.textOff.gameObject.SetActive(1);
        return;
    }

    private void SetColors()
    {
        Transform transform;
        IEnumerator enumerator;
        TextMesh mesh;
        Transform transform2;
        IEnumerator enumerator2;
        TextMesh mesh2;
        IDisposable disposable;
        IDisposable disposable2;
        enumerator = this.textOn.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0088;
        Label_0011:
            transform = (Transform) enumerator.Current;
            mesh = transform.GetComponent<TextMesh>();
            if ((mesh != null) == null)
            {
                goto Label_0088;
            }
            if ((transform.name == "Text Title") == null)
            {
                goto Label_0069;
            }
            mesh.color = new Color(0.913f, 0.878f, 0.694f, 1f);
            goto Label_0088;
        Label_0069:
            mesh.color = new Color(0.612f, 0.596f, 0.494f, 1f);
        Label_0088:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_00AD;
        }
        finally
        {
        Label_0098:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A5;
            }
        Label_00A5:
            disposable.Dispose();
        }
    Label_00AD:
        enumerator2 = this.textOff.GetEnumerator();
    Label_00BA:
        try
        {
            goto Label_0101;
        Label_00BF:
            transform2 = (Transform) enumerator2.Current;
            mesh2 = transform2.GetComponent<TextMesh>();
            if ((mesh2 != null) == null)
            {
                goto Label_0101;
            }
            mesh2.color = new Color(0.42f, 0.384f, 0.341f, 1f);
        Label_0101:
            if (enumerator2.MoveNext() != null)
            {
                goto Label_00BF;
            }
            goto Label_0128;
        }
        finally
        {
        Label_0112:
            disposable2 = enumerator2 as IDisposable;
            if (disposable2 != null)
            {
                goto Label_0120;
            }
        Label_0120:
            disposable2.Dispose();
        }
    Label_0128:
        return;
    }

    private void Start()
    {
        this.icon = base.transform.FindChild("Icon").GetComponent<PackedSprite>();
        this.textOn = base.transform.FindChild("Text On");
        this.textOff = base.transform.FindChild("Text Off");
        this.CheckStatus();
        this.SetColors();
        return;
    }
}

