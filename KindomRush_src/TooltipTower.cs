using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class TooltipTower : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> switchmap5;
    protected PackedSprite background;
    protected Transform containerArmor;
    protected Transform containerDamage;
    protected Transform containerDamageMagic;
    protected Transform containerLife;
    protected Transform containerReload;
    protected Transform containerRespawn;
    protected PackedSprite iconArmor;
    protected PackedSprite iconDamage;
    protected PackedSprite iconDamageMagic;
    protected PackedSprite iconLife;
    protected PackedSprite iconReload;
    protected PackedSprite iconRespawn;
    protected Vector3 posTextDescription;
    protected Vector3 posTextTitle;
    protected TextMesh textArmor;
    protected TextMesh textBottom;
    protected TextMesh textDamage;
    protected TextMesh textDamageMagic;
    protected TextMesh textDescription;
    protected TextMesh textLife;
    protected TextMesh textReload;
    protected TextMesh textRespawn;
    protected TextMesh textTitle;

    public TooltipTower()
    {
        base..ctor();
        return;
    }

    private string ArmorToString(float armor)
    {
        if (armor != 0f)
        {
            goto Label_0011;
        }
        return "None";
    Label_0011:
        if (armor < 1f)
        {
            goto Label_002D;
        }
        if (armor > 30f)
        {
            goto Label_002D;
        }
        return "Low";
    Label_002D:
        if (armor < 31f)
        {
            goto Label_0049;
        }
        if (armor > 60f)
        {
            goto Label_0049;
        }
        return "Medium";
    Label_0049:
        if (armor < 61f)
        {
            goto Label_0065;
        }
        if (armor > 90f)
        {
            goto Label_0065;
        }
        return "High";
    Label_0065:
        if (armor < 90f)
        {
            goto Label_0076;
        }
        return "Great";
    Label_0076:
        return string.Empty;
    }

    private void Awake()
    {
        this.background = base.GetComponent<PackedSprite>();
        this.textTitle = base.transform.FindChild("Text Title").GetComponent<TextMesh>();
        this.textDescription = base.transform.FindChild("Text Description").GetComponent<TextMesh>();
        this.textDamage = base.transform.FindChild("Text Damage").GetComponent<TextMesh>();
        this.textReload = base.transform.FindChild("Text Reload").GetComponent<TextMesh>();
        this.textLife = base.transform.FindChild("Text Life").GetComponent<TextMesh>();
        this.textArmor = base.transform.FindChild("Text Armor").GetComponent<TextMesh>();
        this.textRespawn = base.transform.FindChild("Text Respawn").GetComponent<TextMesh>();
        this.textDamageMagic = base.transform.FindChild("Text Damage Magic").GetComponent<TextMesh>();
        this.textBottom = base.transform.FindChild("Text Bottom").GetComponent<TextMesh>();
        this.iconDamage = base.transform.FindChild("IconDamage").GetComponent<PackedSprite>();
        this.iconDamageMagic = base.transform.FindChild("IconDamageMagic").GetComponent<PackedSprite>();
        this.iconReload = base.transform.FindChild("IconReload").GetComponent<PackedSprite>();
        this.iconLife = base.transform.FindChild("IconLife").GetComponent<PackedSprite>();
        this.iconArmor = base.transform.FindChild("IconArmor").GetComponent<PackedSprite>();
        this.iconRespawn = base.transform.FindChild("IconRespawn").GetComponent<PackedSprite>();
        this.containerDamage = base.transform.FindChild("ContainerDamage");
        this.containerDamageMagic = base.transform.FindChild("ContainerDamageMagic");
        this.containerReload = base.transform.FindChild("ContainerReload");
        this.containerLife = base.transform.FindChild("ContainerLife");
        this.containerArmor = base.transform.FindChild("ContainerArmor");
        this.containerRespawn = base.transform.FindChild("ContainerRespawn");
        this.posTextTitle = this.textTitle.transform.localPosition;
        this.posTextDescription = this.textTitle.transform.localPosition;
        this.textBottom.gameObject.SetActive(0);
        return;
    }

    private void FixedUpdate()
    {
    }

    private string RangeToString(int range)
    {
        if (range < 0)
        {
            goto Label_0018;
        }
        if (range >= 0x1c3)
        {
            goto Label_0018;
        }
        return "Short";
    Label_0018:
        if (range < 0x1c3)
        {
            goto Label_0034;
        }
        if (range >= 0x1fc)
        {
            goto Label_0034;
        }
        return "Average";
    Label_0034:
        if (range < 0x1fc)
        {
            goto Label_0050;
        }
        if (range >= 0x234)
        {
            goto Label_0050;
        }
        return "Long";
    Label_0050:
        if (range < 0x234)
        {
            goto Label_006C;
        }
        if (range >= 0x289)
        {
            goto Label_006C;
        }
        return "Great";
    Label_006C:
        if (range < 0x289)
        {
            goto Label_007D;
        }
        return "Extreme";
    Label_007D:
        return string.Empty;
    }

    private string ReloadToString(float reload)
    {
        if (reload < 0f)
        {
            goto Label_001C;
        }
        if (reload >= 0.5f)
        {
            goto Label_001C;
        }
        return "Very Fast";
    Label_001C:
        if (reload < 0.5f)
        {
            goto Label_0038;
        }
        if (reload >= 0.8f)
        {
            goto Label_0038;
        }
        return "Fast";
    Label_0038:
        if (reload < 0.8f)
        {
            goto Label_0054;
        }
        if (reload >= 1.5f)
        {
            goto Label_0054;
        }
        return "Average";
    Label_0054:
        if (reload < 1.5f)
        {
            goto Label_0070;
        }
        if (reload >= 2f)
        {
            goto Label_0070;
        }
        return "Slow";
    Label_0070:
        if (reload < 2f)
        {
            goto Label_0081;
        }
        return "Very Slow";
    Label_0081:
        return string.Empty;
    }

    protected void Resize(float xScale, float yScale)
    {
        this.textTitle.transform.parent = null;
        this.textDescription.transform.parent = null;
        this.textDamage.transform.parent = null;
        this.textDamageMagic.transform.parent = null;
        this.textReload.transform.parent = null;
        this.textLife.transform.parent = null;
        this.textArmor.transform.parent = null;
        this.textRespawn.transform.parent = null;
        this.textBottom.transform.parent = null;
        this.iconDamageMagic.transform.parent = null;
        this.iconDamage.transform.parent = null;
        this.iconReload.transform.parent = null;
        this.iconLife.transform.parent = null;
        this.iconArmor.transform.parent = null;
        this.iconRespawn.transform.parent = null;
        base.transform.localScale = new Vector3(xScale, yScale, 1f);
        this.textTitle.transform.parent = base.transform;
        this.textBottom.transform.parent = base.transform;
        this.textDescription.transform.parent = base.transform;
        this.textDamage.transform.parent = this.containerDamage;
        this.textReload.transform.parent = this.containerReload;
        this.iconDamage.transform.parent = this.containerDamage;
        this.iconReload.transform.parent = this.containerReload;
        this.iconLife.transform.parent = this.containerLife;
        this.textLife.transform.parent = this.containerLife;
        this.iconArmor.transform.parent = this.containerArmor;
        this.textArmor.transform.parent = this.containerArmor;
        this.iconRespawn.transform.parent = this.containerRespawn;
        this.textRespawn.transform.parent = this.containerRespawn;
        this.textDamageMagic.transform.parent = this.containerDamageMagic;
        this.iconDamageMagic.transform.parent = this.containerDamageMagic;
        return;
    }

    public unsafe void Setup(string name, int level = 0)
    {
        Transform transform75;
        Transform transform74;
        Transform transform73;
        Transform transform72;
        Transform transform71;
        Transform transform70;
        Transform transform69;
        Transform transform68;
        Transform transform67;
        Transform transform66;
        Transform transform65;
        Transform transform64;
        Transform transform63;
        Transform transform62;
        Transform transform61;
        Transform transform60;
        Transform transform59;
        Transform transform58;
        Transform transform57;
        Transform transform56;
        Transform transform55;
        Transform transform54;
        Transform transform53;
        Transform transform52;
        Transform transform51;
        Transform transform50;
        Transform transform49;
        Transform transform48;
        Transform transform47;
        Transform transform46;
        Transform transform45;
        Transform transform44;
        Transform transform43;
        Transform transform42;
        Transform transform41;
        Transform transform40;
        Transform transform39;
        Transform transform38;
        Transform transform37;
        Transform transform36;
        Transform transform35;
        Transform transform34;
        Transform transform33;
        Transform transform32;
        Transform transform31;
        Transform transform30;
        Transform transform29;
        Transform transform28;
        Transform transform27;
        Transform transform26;
        Transform transform25;
        Transform transform24;
        Transform transform23;
        Transform transform22;
        Transform transform21;
        Transform transform20;
        Transform transform19;
        Transform transform18;
        Transform transform17;
        Transform transform16;
        Transform transform15;
        Transform transform14;
        Transform transform13;
        Transform transform12;
        Transform transform11;
        Transform transform10;
        Transform transform9;
        Transform transform8;
        Transform transform7;
        Transform transform6;
        Transform transform5;
        Transform transform4;
        Transform transform3;
        Transform transform2;
        Transform transform1;
        string str;
        Dictionary<string, int> dictionary;
        int num;
        float num2;
        float num3;
        float num4;
        float num5;
        float num6;
        float num7;
        Vector3 vector;
        Vector3 vector2;
        float num8;
        float num9;
        Vector3 vector3;
        Vector3 vector4;
        Vector3 vector5;
        float num10;
        float num11;
        Vector3 vector6;
        Vector3 vector7;
        Vector3 vector8;
        float num12;
        float num13;
        float num14;
        float num15;
        float num16;
        float num17;
        float num18;
        float num19;
        Vector3 vector9;
        Vector3 vector10;
        Vector3 vector11;
        float num20;
        float num21;
        Vector3 vector12;
        Vector3 vector13;
        Vector3 vector14;
        float num22;
        float num23;
        float num24;
        float num25;
        float num26;
        float num27;
        float num28;
        float num29;
        Vector3 vector15;
        Vector3 vector16;
        Vector3 vector17;
        Vector3 vector18;
        float num30;
        float num31;
        Vector3 vector19;
        Vector3 vector20;
        Vector3 vector21;
        float num32;
        float num33;
        float num34;
        float num35;
        float num36;
        float num37;
        float num38;
        float num39;
        float num40;
        float num41;
        float num42;
        float num43;
        Vector3 vector22;
        Vector3 vector23;
        float num44;
        float num45;
        float num46;
        float num47;
        Vector3 vector24;
        Vector3 vector25;
        Vector3 vector26;
        Vector3 vector27;
        Vector3 vector28;
        Vector3 vector29;
        float num48;
        float num49;
        float num50;
        float num51;
        Vector3 vector30;
        Vector3 vector31;
        Vector3 vector32;
        Vector3 vector33;
        Vector3 vector34;
        Vector3 vector35;
        str = name;
        if (str == null)
        {
            goto Label_5D2F;
        }
        if (switchmap5 != null)
        {
            goto Label_0246;
        }
        dictionary = new Dictionary<string, int>(0x2b);
        dictionary.Add("ArcherLvl1", 0);
        dictionary.Add("ArcherLvl2", 1);
        dictionary.Add("ArcherLvl3", 2);
        dictionary.Add("ArcherRanger", 3);
        dictionary.Add("Poison", 4);
        dictionary.Add("Thorns", 5);
        dictionary.Add("ArcherMusketeer", 6);
        dictionary.Add("Sniper", 7);
        dictionary.Add("Shrapnel", 8);
        dictionary.Add("MageLvl1", 9);
        dictionary.Add("MageLvl2", 10);
        dictionary.Add("MageLvl3", 11);
        dictionary.Add("MageArcane", 12);
        dictionary.Add("Teleport", 13);
        dictionary.Add("Death Ray", 14);
        dictionary.Add("MageSorcerer", 15);
        dictionary.Add("Polymorph", 0x10);
        dictionary.Add("Elemental", 0x11);
        dictionary.Add("ArtilleryLvl1", 0x12);
        dictionary.Add("ArtilleryLvl2", 0x13);
        dictionary.Add("ArtilleryLvl3", 20);
        dictionary.Add("ArtilleryBFG", 0x15);
        dictionary.Add("Missile", 0x16);
        dictionary.Add("Cluster", 0x17);
        dictionary.Add("ArtilleryTesla", 0x18);
        dictionary.Add("Supercharge", 0x19);
        dictionary.Add("Overcharge", 0x1a);
        dictionary.Add("BarrackLvl1", 0x1b);
        dictionary.Add("BarrackLvl2", 0x1c);
        dictionary.Add("BarrackLvl3", 0x1d);
        dictionary.Add("BarrackPaladin", 30);
        dictionary.Add("Healing", 0x1f);
        dictionary.Add("Holy Strike", 0x20);
        dictionary.Add("Shield", 0x21);
        dictionary.Add("BarrackBarbarian", 0x22);
        dictionary.Add("Throwing axes", 0x23);
        dictionary.Add("Twister", 0x24);
        dictionary.Add("Double Axe", 0x25);
        dictionary.Add("Sasquash", 0x26);
        dictionary.Add("SasquashOff", 0x27);
        dictionary.Add("Sell", 40);
        dictionary.Add("ElfTower", 0x29);
        dictionary.Add("Elf", 0x2a);
        switchmap5 = dictionary;
    Label_0246:
        if (switchmap5.TryGetValue(str, &num) == null)
        {
            goto Label_5D2F;
        }
        switch (num)
        {
            case 0:
                goto Label_030F;

            case 1:
                goto Label_04C1;

            case 2:
                goto Label_0674;

            case 3:
                goto Label_08BC;

            case 4:
                goto Label_0AB7;

            case 5:
                goto Label_0C8D;

            case 6:
                goto Label_0E63;

            case 7:
                goto Label_105E;

            case 8:
                goto Label_133C;

            case 9:
                goto Label_161A;

            case 10:
                goto Label_17CD;

            case 11:
                goto Label_1980;

            case 12:
                goto Label_1B33;

            case 13:
                goto Label_1D2E;

            case 14:
                goto Label_202E;

            case 15:
                goto Label_230C;

            case 0x10:
                goto Label_2507;

            case 0x11:
                goto Label_27E5;

            case 0x12:
                goto Label_29BB;

            case 0x13:
                goto Label_2B6E;

            case 20:
                goto Label_2D21;

            case 0x15:
                goto Label_2ED4;

            case 0x16:
                goto Label_30CF;

            case 0x17:
                goto Label_33FA;

            case 0x18:
                goto Label_36F8;

            case 0x19:
                goto Label_38F3;

            case 0x1a:
                goto Label_3B41;

            case 0x1b:
                goto Label_3E3F;

            case 0x1c:
                goto Label_4099;

            case 0x1d:
                goto Label_42F3;

            case 30:
                goto Label_45E2;

            case 0x1f:
                goto Label_4884;

            case 0x20:
                goto Label_4AA7;

            case 0x21:
                goto Label_4DD2;

            case 0x22:
                goto Label_4F50;

            case 0x23:
                goto Label_51F2;

            case 0x24:
                goto Label_5415;

            case 0x25:
                goto Label_55EB;

            case 0x26:
                goto Label_580E;

            case 0x27:
                goto Label_58EE;

            case 40:
                goto Label_59CE;

            case 0x29:
                goto Label_5B02;

            case 0x2a:
                goto Label_5C25;
        }
        goto Label_5D2F;
    Label_030F:
        this.textTitle.text = "archer tower";
        this.textDescription.text = "archers ready to strike at\nyour enemies from a\ndistance.";
        this.textDamage.text = &GameSettings.GetTowerSetting("archer_level1", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("archer_level1", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("archer_level1", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_04C1:
        this.textTitle.text = "marksmen tower";
        this.textDescription.text = "marksmen shoot broadhead\narrows, dealing more\ndamage. Their longbows\nhave longer attack range.";
        this.textDamage.text = &GameSettings.GetTowerSetting("archer_level2", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("archer_level2", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("archer_level2", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_0674:
        this.textTitle.text = "sharpshooter tower";
        this.textDescription.text = "once archers reach the\nsharpshooter level, their\nattack range and damage\npotential increases above\nany other archer's.";
        this.textDamage.text = &GameSettings.GetTowerSetting("archer_level3", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("archer_level3", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("archer_level3", "reload"));
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -27f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -27f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -34f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -33f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_086F;
        }
        transform1 = base.transform;
        transform1.position += new Vector3(0f, -10f, 0f);
        goto Label_08B7;
    Label_086F:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform2 = base.transform;
        transform2.position += new Vector3(0f, 10f, 0f);
    Label_08B7:
        goto Label_5D2F;
    Label_08BC:
        this.textTitle.text = "rangers hideout";
        this.textDescription.text = "legendary masters of the\nbow, they can unleash a\nhail of arrows faster and\nfurther than any other\nforce in the realm.";
        this.textDamage.text = &GameSettings.GetTowerSetting("archer_ranger", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("archer_ranger", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("archer_ranger", "reload"));
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -27f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -27f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -34f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -33f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform3 = base.transform;
        transform3.position += new Vector3(0f, 9f, 0f);
        goto Label_5D2F;
    Label_0AB7:
        this.textBottom.text = "It won't hurt... for long.";
        if (level != null)
        {
            goto Label_0AF2;
        }
        this.textTitle.text = "poison arrows";
        this.textDescription.text = "poisons enemies dealing\n15 damage over 3 seconds.";
        goto Label_0B45;
    Label_0AF2:
        if (level != 1)
        {
            goto Label_0B1E;
        }
        this.textTitle.text = "poison arrows ii";
        this.textDescription.text = "poisons becomes more\nlethal, dealing 30 damage\nover 3 seconds.";
        goto Label_0B45;
    Label_0B1E:
        if (level != 2)
        {
            goto Label_0B45;
        }
        this.textTitle.text = "poison arrows iii";
        this.textDescription.text = "poisons becomes more\nlethal, dealing 45 damage\nover 3 seconds.";
    Label_0B45:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform4 = this.textBottom.transform;
        transform4.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform5 = base.transform;
        transform5.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_0C8D:
        this.textBottom.text = "It's a trap!";
        if (level != null)
        {
            goto Label_0CC8;
        }
        this.textTitle.text = "wrath of the forest";
        this.textDescription.text = "summons thorns and vines\nthat trap enemies and deal\n40 damage every second\nfor 1 second.";
        goto Label_0D1B;
    Label_0CC8:
        if (level != 1)
        {
            goto Label_0CF4;
        }
        this.textTitle.text = "wrath of the forest ii";
        this.textDescription.text = "increases spell duration\nto 2 seconds, allowing\nthorns to deal more\ndamage.";
        goto Label_0D1B;
    Label_0CF4:
        if (level != 2)
        {
            goto Label_0D1B;
        }
        this.textTitle.text = "wrath of the forest iii";
        this.textDescription.text = "increases spell duration\nto 3 seconds, allowing\nthorns to deal even more\ndamage.";
    Label_0D1B:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform6 = this.textBottom.transform;
        transform6.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform7 = base.transform;
        transform7.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_0E63:
        this.textTitle.text = "musketeer garrison";
        this.textDescription.text = "patient, careful, and deadly\naccurate long-range\ndeadeye shooters, with\nadvanced weaponry.";
        this.textDamage.text = &GameSettings.GetTowerSetting("archer_musketeer", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("archer_musketeer", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("archer_musketeer", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform8 = base.transform;
        transform8.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_105E:
        this.textBottom.text = "One shot... one kill...";
        if (level != null)
        {
            goto Label_111D;
        }
        this.textTitle.text = "sniper shot";
        this.textDescription.text = "long range shot with 20%\nchance of instantly\nkilling an enemy or\ndeal massive damage.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform9 = this.textBottom.transform;
        transform9.position += new Vector3(10f, -24f, 0f);
        goto Label_1278;
    Label_111D:
        if (level != 1)
        {
            goto Label_11CD;
        }
        this.textTitle.text = "sniper shot ii";
        this.textDescription.text = "increases chance of\ninstantly killing an enemy\nby 40%.";
        this.Resize(0.75f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform10 = this.textBottom.transform;
        transform10.position += new Vector3(14f, -24f, 0f);
        goto Label_1278;
    Label_11CD:
        if (level != 2)
        {
            goto Label_1278;
        }
        this.textTitle.text = "sniper shot iii";
        this.textDescription.text = "increases chance of\ninstantly killing an enemy\nby 60%.";
        this.Resize(0.75f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform11 = this.textBottom.transform;
        transform11.position += new Vector3(14f, -24f, 0f);
    Label_1278:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform12 = base.transform;
        transform12.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_133C:
        this.textBottom.text = "Eat grapeshot!";
        if (level != null)
        {
            goto Label_13FB;
        }
        this.textTitle.text = "shrapnel shot";
        this.textDescription.text = "short range shot that\nblasts an area for 50-200\ndamage.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform13 = this.textBottom.transform;
        transform13.position += new Vector3(10f, -24f, 0f);
        goto Label_1556;
    Label_13FB:
        if (level != 1)
        {
            goto Label_14AB;
        }
        this.textTitle.text = "shrapnel shot ii";
        this.textDescription.text = "improves shrapnel shot\narea damage to 100-400\npoints.";
        this.Resize(0.75f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform14 = this.textBottom.transform;
        transform14.position += new Vector3(14f, -24f, 0f);
        goto Label_1556;
    Label_14AB:
        if (level != 2)
        {
            goto Label_1556;
        }
        this.textTitle.text = "shrapnel shot iii";
        this.textDescription.text = "improves shrapnel shot\narea damage to 150-600\npoints.";
        this.Resize(0.75f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform15 = this.textBottom.transform;
        transform15.position += new Vector3(14f, -24f, 0f);
    Label_1556:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform16 = base.transform;
        transform16.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_161A:
        this.textTitle.text = "mage tower";
        this.textDescription.text = "mages cast armor piercing\nbolts at your enemies,\nignoring any physical\nprotection.";
        this.textDamageMagic.text = &GameSettings.GetTowerSetting("mage_level1", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("mage_level1", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("mage_level1", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamageMagic.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamageMagic.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_17CD:
        this.textTitle.text = "adept tower";
        this.textDescription.text = "adepts cast enhanced bolts,\nwhich can tear through\narmor, flesh and bone.";
        this.textDamageMagic.text = &GameSettings.GetTowerSetting("mage_level2", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("mage_level2", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("mage_level2", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamageMagic.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamageMagic.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_1980:
        this.textTitle.text = "wizard tower";
        this.textDescription.text = "wizards cast high-energy\nbolts, which rip apart the\nvery essence of enemy\ntroops.";
        this.textDamageMagic.text = &GameSettings.GetTowerSetting("mage_level3", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("mage_level3", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("mage_level3", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamageMagic.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamageMagic.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_1B33:
        this.textTitle.text = "arcane wizard";
        this.textDescription.text = "arcane wizards focus on\naltering reality; as well\nas shooting the deadliest\nmagical ray known to man.";
        this.textDamageMagic.text = &GameSettings.GetTowerSetting("mage_arcane", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("mage_arcane", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("mage_arcane", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamageMagic.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamageMagic.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform17 = base.transform;
        transform17.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_1D2E:
        this.textBottom.text = "Space is merely a perception";
        if (level != null)
        {
            goto Label_1DFE;
        }
        this.textTitle.text = "teleport";
        this.textDescription.text = "Teleports a group of up\nto 4 enemies a random\ndistance back down the path\nevery 10 seconds.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform18 = this.textBottom.transform;
        transform18.position += new Vector3(10f, -22f, 0f);
        this.textBottom.gameObject.SetActive(1);
        goto Label_1F7B;
    Label_1DFE:
        if (level != 1)
        {
            goto Label_1EBF;
        }
        this.textTitle.text = "teleport ii";
        this.textDescription.text = "increases the maximum\namount of enemies\nteleported to 5.";
        this.Resize(0.7f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform19 = this.textBottom.transform;
        transform19.position += new Vector3(23f, -20f, 0f);
        this.textBottom.gameObject.SetActive(1);
        goto Label_1F7B;
    Label_1EBF:
        if (level != 2)
        {
            goto Label_1F7B;
        }
        this.textTitle.text = "teleport iii";
        this.textDescription.text = "increases the maximum\namount of enemies\nteleported to 6.";
        this.Resize(0.7f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform20 = this.textBottom.transform;
        transform20.position += new Vector3(23f, -20f, 0f);
        this.textBottom.gameObject.SetActive(1);
    Label_1F7B:
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform21 = base.transform;
        transform21.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_202E:
        this.textBottom.text = "Avada Kedavra!";
        if (level != null)
        {
            goto Label_20ED;
        }
        this.textTitle.text = "death ray";
        this.textDescription.text = "disintegrates one enemy\ninto fine creep dust every\n20 seconds.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform22 = this.textBottom.transform;
        transform22.position += new Vector3(10f, -24f, 0f);
        goto Label_2248;
    Label_20ED:
        if (level != 1)
        {
            goto Label_219D;
        }
        this.textTitle.text = "death ray ii";
        this.textDescription.text = "reduces spell cooldown\nfrom 20 to 18 seconds.";
        this.Resize(0.7f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform23 = this.textBottom.transform;
        transform23.position += new Vector3(23f, -16f, 0f);
        goto Label_2248;
    Label_219D:
        if (level != 2)
        {
            goto Label_2248;
        }
        this.textTitle.text = "death ray iii";
        this.textDescription.text = "reduces spell cooldown\nfrom 18 to 16 seconds.";
        this.Resize(0.7f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform24 = this.textBottom.transform;
        transform24.position += new Vector3(23f, -16f, 0f);
    Label_2248:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform25 = base.transform;
        transform25.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_230C:
        this.textTitle.text = "sorcerer mage";
        this.textDescription.text = "sorcerers handle forces\nthat are close to darkness,\nweaving spells that\ntemporarily lower enemy\narmor and deal damage.";
        this.textDamageMagic.text = &GameSettings.GetTowerSetting("mage_sorcerer", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("mage_sorcerer", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("mage_sorcerer", "reload"));
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamageMagic.transform.localPosition = new Vector3(-100f, -27f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -27f, -1f);
        this.iconDamageMagic.transform.localPosition = new Vector3(-117f, -34f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -33f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform26 = base.transform;
        transform26.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_2507:
        this.textBottom.text = "Meeeeeh!";
        if (level != null)
        {
            goto Label_25C6;
        }
        this.textTitle.text = "polymorph";
        this.textDescription.text = "polymorphs enemies into\nharmless sheep. Sheep are\nvery weak but cannot\nbe blocked.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform27 = this.textBottom.transform;
        transform27.position += new Vector3(10f, -24f, 0f);
        goto Label_2721;
    Label_25C6:
        if (level != 1)
        {
            goto Label_2676;
        }
        this.textTitle.text = "polymorph ii";
        this.textDescription.text = "reduces spell cooldown\nfrom 20 to 18 seconds.";
        this.Resize(0.7f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform28 = this.textBottom.transform;
        transform28.position += new Vector3(23f, -16f, 0f);
        goto Label_2721;
    Label_2676:
        if (level != 2)
        {
            goto Label_2721;
        }
        this.textTitle.text = "polymorph iii";
        this.textDescription.text = "reduces spell cooldown\nfrom 18 to 16 seconds.";
        this.Resize(0.7f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        transform29 = this.textBottom.transform;
        transform29.position += new Vector3(23f, -16f, 0f);
    Label_2721:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform30 = base.transform;
        transform30.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_27E5:
        this.textBottom.text = "Rock is eternal.";
        if (level != null)
        {
            goto Label_2820;
        }
        this.textTitle.text = "summon elemental";
        this.textDescription.text = "summons an earth\nelemental, stout avatar of\nthe land's power, to block\nand attack your enemies.";
        goto Label_2873;
    Label_2820:
        if (level != 1)
        {
            goto Label_284C;
        }
        this.textTitle.text = "summon elemental ii";
        this.textDescription.text = "elementals gain increased\nlife, armor and attack\ndamage.";
        goto Label_2873;
    Label_284C:
        if (level != 2)
        {
            goto Label_2873;
        }
        this.textTitle.text = "summon elemental iii";
        this.textDescription.text = "elementals gain another\nboost to life, armor and\nattack damage.";
    Label_2873:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform31 = this.textBottom.transform;
        transform31.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform32 = base.transform;
        transform32.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_29BB:
        this.textTitle.text = "dwarven bombard";
        this.textDescription.text = "bombards ground enemies\ndealing area damage.";
        this.textDamage.text = &GameSettings.GetTowerSetting("artillery_level1", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("artillery_level1", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("artillery_level1", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_2B6E:
        this.textTitle.text = "dwarven artillery";
        this.textDescription.text = "enhanced dwarven ordnance,\nthis artillery will blast an\neven larger area.";
        this.textDamage.text = &GameSettings.GetTowerSetting("artillery_level2", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("artillery_level2", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("artillery_level2", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_2D21:
        this.textTitle.text = "dwarven howitzer";
        this.textDescription.text = "they build them bigger and\nbigger, don't they? your\nenemies stand no chance!";
        this.textDamage.text = &GameSettings.GetTowerSetting("artillery_level3", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("artillery_level3", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("artillery_level3", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_2ED4:
        this.textTitle.text = "500mm Big Bertha";
        this.textDescription.text = "the 500mm siege gun aka\n\"Big Bertha\" is the biggest,\nbaddest piece of artillery\nin the block.";
        this.textDamage.text = &GameSettings.GetTowerSetting("artillery_bfg", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("artillery_bfg", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("artillery_bfg", "reload"));
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -25f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -32f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-32f, -32f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform33 = base.transform;
        transform33.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_30CF:
        this.textBottom.text = "Guaranteed mayhem. Use with\ndiscretion.";
        if (level != null)
        {
            goto Label_318E;
        }
        this.textTitle.text = "dragonbreath launcher";
        this.textDescription.text = "launches seeking missiles\nwith extended range that\nnever miss and deal 140 to\n180 damage.";
        this.Resize(0.8f, 1.7f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        transform34 = this.textBottom.transform;
        transform34.position += new Vector3(10f, -21f, 0f);
        goto Label_32E9;
    Label_318E:
        if (level != 1)
        {
            goto Label_323E;
        }
        this.textTitle.text = "dragonbreath launcher ii";
        this.textDescription.text = "Improves missile area\ndamage to 180-220.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform35 = this.textBottom.transform;
        transform35.position += new Vector3(10f, -10f, 0f);
        goto Label_32E9;
    Label_323E:
        if (level != 2)
        {
            goto Label_32E9;
        }
        this.textTitle.text = "dragonbreath launcher iii";
        this.textDescription.text = "Improves missile area\ndamage to 220-260.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform36 = this.textBottom.transform;
        transform36.position += new Vector3(10f, -10f, 0f);
    Label_32E9:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_33AD;
        }
        transform37 = base.transform;
        transform37.position += new Vector3(0f, -5f, 0f);
        goto Label_33F5;
    Label_33AD:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform38 = base.transform;
        transform38.position += new Vector3(0f, 15f, 0f);
    Label_33F5:
        goto Label_5D2F;
    Label_33FA:
        this.textTitle.text = "cluster launcher xtreme";
        this.textDescription.text = "Fires a special bomb that\nwill explode in mid air\ndropping additional\nbomblets into a wide area.";
        this.textBottom.text = "I love the smell of napalm in\nthe morning...";
        if (level != null)
        {
            goto Label_34D9;
        }
        this.textTitle.text = "cluster launcher";
        this.textDescription.text = "fires a bomb that will\nexplode into 3 bomblets\nover a wide area, dealing\n60 to 80 damage each.";
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        transform39 = this.textBottom.transform;
        transform39.position += new Vector3(10f, -18f, 0f);
        goto Label_3634;
    Label_34D9:
        if (level != 1)
        {
            goto Label_3589;
        }
        this.textTitle.text = "cluster launcher ii";
        this.textDescription.text = "bomblet ammount is\nincreased to 5 thus\ncovering a bigger area.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform40 = this.textBottom.transform;
        transform40.position += new Vector3(10f, -10f, 0f);
        goto Label_3634;
    Label_3589:
        if (level != 2)
        {
            goto Label_3634;
        }
        this.textTitle.text = "cluster launcher iii";
        this.textDescription.text = "bomblet ammount is\nincreased to 7 thus\ncovering an even bigger\narea.";
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        transform41 = this.textBottom.transform;
        transform41.position += new Vector3(10f, -18f, 0f);
    Label_3634:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform42 = base.transform;
        transform42.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_36F8:
        this.textTitle.text = "tesla x104";
        this.textDescription.text = "dwarven engineering at it's\nfinest, harnessing the\npower of a thousand\nthunderstorms. Who shall\nwe aim it at?";
        this.textDamage.text = &GameSettings.GetTowerSetting("artillery_tesla", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("artillery_tesla", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("artillery_tesla", "reload"));
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-100f, -27f, -1f);
        this.textReload.transform.localPosition = new Vector3(-18f, -27f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-117f, -34f, -1f);
        this.iconReload.transform.localPosition = new Vector3(-35f, -33f, -1f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform43 = base.transform;
        transform43.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_38F3:
        this.textTitle.text = "supercharged bolt";
        this.textDescription.text = "Supercharged Bolts will\narc to additional targets.";
        this.textBottom.text = "You've been - thunderstruck!";
        if (level != null)
        {
            goto Label_39D2;
        }
        this.textTitle.text = "supercharged bolt";
        this.textDescription.text = "supercharged Bolts will\narc to a maximum of 4\ntargets.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform44 = this.textBottom.transform;
        transform44.position += new Vector3(10f, -24f, 0f);
        goto Label_3A7D;
    Label_39D2:
        if (level != 1)
        {
            goto Label_3A7D;
        }
        this.textTitle.text = "supercharged bolt ii";
        this.textDescription.text = "maximum targets are\nincreased to 5.";
        this.Resize(0.8f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 14f, 0f);
        transform45 = this.textBottom.transform;
        transform45.position += new Vector3(10f, -16f, 0f);
    Label_3A7D:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform46 = base.transform;
        transform46.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_3B41:
        this.textTitle.text = "overcharge";
        this.textDescription.text = "Overcharges the tower\ncreating a static field that\ndamages all enemies in\nproximity.";
        this.textBottom.text = "Ride the Lightning!";
        if (level != null)
        {
            goto Label_3C20;
        }
        this.textTitle.text = "overcharge";
        this.textDescription.text = "overcharges the tower\ncreating a static field\nthat damages all enemies\nin proximity for 5 to 15\nlife.";
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        transform47 = this.textBottom.transform;
        transform47.position += new Vector3(10f, -32f, 0f);
        goto Label_3D7B;
    Label_3C20:
        if (level != 1)
        {
            goto Label_3CD0;
        }
        this.textTitle.text = "overcharge ii";
        this.textDescription.text = "increases Overcharge\nstatic field damage to\n10-20.";
        this.Resize(0.8f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 14f, 0f);
        transform48 = this.textBottom.transform;
        transform48.position += new Vector3(10f, -16f, 0f);
        goto Label_3D7B;
    Label_3CD0:
        if (level != 2)
        {
            goto Label_3D7B;
        }
        this.textTitle.text = "overcharge iii";
        this.textDescription.text = "increases Overcharge\nstatic field damage to\n15-25.";
        this.Resize(0.8f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 14f, 0f);
        transform49 = this.textBottom.transform;
        transform49.position += new Vector3(10f, -16f, 0f);
    Label_3D7B:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform50 = base.transform;
        transform50.position += new Vector3(0f, 10f, 0f);
        goto Label_5D2F;
    Label_3E3F:
        this.textTitle.text = "barracks";
        this.textDescription.text = "trains militia, tough\nsoldiers that block and\ndamage your enemies.";
        this.textDamage.text = &GameSettings.GetTowerSetting("barrack_level1", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("barrack_level1", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("barrack_level1", "reload"));
        this.textLife.text = &GameSettings.GetTowerSetting("barrack_level1", "health").ToString();
        this.textArmor.text = this.ArmorToString(GameSettings.GetTowerSetting("barrack_level1", "armor"));
        this.textRespawn.text = &GameSettings.GetTowerSetting("barrack_level1", "respawn").ToString() + "s";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-13f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-25f, -32f, -1f);
        this.textLife.transform.localPosition = new Vector3(-107f, -25f, -1f);
        this.iconLife.transform.localPosition = new Vector3(-119f, -32f, -1f);
        this.textArmor.transform.localPosition = new Vector3(81f, -25f, -1f);
        this.iconArmor.transform.localPosition = new Vector3(66f, -32f, -1f);
        this.containerReload.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_4099:
        this.textTitle.text = "footmen barracks";
        this.textDescription.text = "footmen are better trained\nand equipped than basic\nmilitia. They can become the\nbackbone of a good army.";
        this.textDamage.text = &GameSettings.GetTowerSetting("barrack_level2", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("barrack_level2", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("barrack_level2", "reload"));
        this.textLife.text = &GameSettings.GetTowerSetting("barrack_level2", "health").ToString();
        this.textArmor.text = this.ArmorToString(GameSettings.GetTowerSetting("barrack_level2", "armor"));
        this.textRespawn.text = &GameSettings.GetTowerSetting("barrack_level2", "respawn").ToString() + "s";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-13f, -25f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-25f, -32f, -1f);
        this.textLife.transform.localPosition = new Vector3(-107f, -25f, -1f);
        this.iconLife.transform.localPosition = new Vector3(-119f, -32f, -1f);
        this.textArmor.transform.localPosition = new Vector3(91f, -25f, -1f);
        this.iconArmor.transform.localPosition = new Vector3(76f, -32f, -1f);
        this.containerReload.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_42F3:
        this.textTitle.text = "knights barracks";
        this.textDescription.text = "knights are professional\nsoldiers with heavy armor.\ndedicated to his majesty,\nthey will stop your enemies'\nadvance.";
        this.textDamage.text = &GameSettings.GetTowerSetting("barrack_level3", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("barrack_level3", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("barrack_level3", "reload"));
        this.textLife.text = &GameSettings.GetTowerSetting("barrack_level3", "health").ToString();
        this.textArmor.text = this.ArmorToString(GameSettings.GetTowerSetting("barrack_level3", "armor"));
        this.textRespawn.text = &GameSettings.GetTowerSetting("barrack_level3", "respawn").ToString() + "s";
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-13f, -27f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-25f, -34f, -1f);
        this.textLife.transform.localPosition = new Vector3(-107f, -27f, -1f);
        this.iconLife.transform.localPosition = new Vector3(-119f, -34f, -1f);
        this.textArmor.transform.localPosition = new Vector3(71f, -27f, -1f);
        this.iconArmor.transform.localPosition = new Vector3(56f, -34f, -1f);
        this.containerReload.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_4595;
        }
        transform51 = base.transform;
        transform51.position += new Vector3(0f, -10f, 0f);
        goto Label_45DD;
    Label_4595:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform52 = base.transform;
        transform52.position += new Vector3(0f, 10f, 0f);
    Label_45DD:
        goto Label_5D2F;
    Label_45E2:
        this.textTitle.text = "knights barracks";
        this.textDescription.text = "trains paladins, an order\nof holy warriors.\nThey are paragons of divine\nprotection and heavenly\ndefense.";
        this.textDamage.text = &GameSettings.GetTowerSetting("barrack_paladin", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("barrack_paladin", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("barrack_paladin", "reload"));
        this.textLife.text = &GameSettings.GetTowerSetting("barrack_paladin", "health").ToString();
        this.textArmor.text = this.ArmorToString(GameSettings.GetTowerSetting("barrack_paladin", "armor"));
        this.textRespawn.text = &GameSettings.GetTowerSetting("barrack_paladin", "respawn").ToString() + "s";
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-23f, -27f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-35f, -34f, -1f);
        this.textLife.transform.localPosition = new Vector3(-107f, -27f, -1f);
        this.iconLife.transform.localPosition = new Vector3(-119f, -34f, -1f);
        this.textArmor.transform.localPosition = new Vector3(70f, -27f, -1f);
        this.iconArmor.transform.localPosition = new Vector3(57f, -34f, -1f);
        this.containerReload.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform53 = base.transform;
        transform53.position += new Vector3(0f, 9f, 0f);
        goto Label_5D2F;
    Label_4884:
        this.textBottom.text = "There shall be light!";
        if (level != null)
        {
            goto Label_48BF;
        }
        this.textTitle.text = "healing light";
        this.textDescription.text = "Paladins can heal\nthemselves for 40 to 60\nlife every 10 seconds.";
        goto Label_4912;
    Label_48BF:
        if (level != 1)
        {
            goto Label_48EB;
        }
        this.textTitle.text = "healing light ii";
        this.textDescription.text = "improves the amount of\nhealing done to 80-120\nlife.";
        goto Label_4912;
    Label_48EB:
        if (level != 2)
        {
            goto Label_4912;
        }
        this.textTitle.text = "healing light iii";
        this.textDescription.text = "improves the amount of\nhealing done to 120-180\nlife.";
    Label_4912:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform54 = this.textBottom.transform;
        transform54.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_4A5A;
        }
        transform55 = base.transform;
        transform55.position += new Vector3(0f, -18f, 0f);
        goto Label_4AA2;
    Label_4A5A:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform56 = base.transform;
        transform56.position += new Vector3(0f, 50f, 0f);
    Label_4AA2:
        goto Label_5D2F;
    Label_4AA7:
        this.textBottom.text = "By Holy fire be Purged!";
        if (level != null)
        {
            goto Label_4B66;
        }
        this.textTitle.text = "holy strike";
        this.textDescription.text = "paladin attacks have a\nchance of becoming a\nholy strike, dealing 25 to\n45 holy area damage.";
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform57 = this.textBottom.transform;
        transform57.position += new Vector3(10f, -24f, 0f);
        goto Label_4CC1;
    Label_4B66:
        if (level != 1)
        {
            goto Label_4C16;
        }
        this.textTitle.text = "holy strike ii";
        this.textDescription.text = "increases holy strike area\ndamage to 50-90 points.";
        this.Resize(0.8f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 14f, 0f);
        transform58 = this.textBottom.transform;
        transform58.position += new Vector3(10f, -16f, 0f);
        goto Label_4CC1;
    Label_4C16:
        if (level != 2)
        {
            goto Label_4CC1;
        }
        this.textTitle.text = "holy strike iii";
        this.textDescription.text = "increases holy strike area\ndamage to 75-135 points.";
        this.Resize(0.8f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 14f, 0f);
        transform59 = this.textBottom.transform;
        transform59.position += new Vector3(10f, -16f, 0f);
    Label_4CC1:
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_4D85;
        }
        transform60 = base.transform;
        transform60.position += new Vector3(0f, -18f, 0f);
        goto Label_4DCD;
    Label_4D85:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform61 = base.transform;
        transform61.position += new Vector3(0f, 50f, 0f);
    Label_4DCD:
        goto Label_5D2F;
    Label_4DD2:
        this.textBottom.text = "No retreat, No surrender!";
        if (level != null)
        {
            goto Label_4E08;
        }
        this.textTitle.text = "shield of valor";
        this.textDescription.text = "Enhances paladins\nprotection, making them\nmore resilient.";
    Label_4E08:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform62 = this.textBottom.transform;
        transform62.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform63 = base.transform;
        transform63.position += new Vector3(0f, 31f, 0f);
        goto Label_5D2F;
    Label_4F50:
        this.textTitle.text = "Barbarian Hall";
        this.textDescription.text = "barbarians are savage\nwarriors that will quickly\nclear a battlefield, usually\nat the cost of their own\nlives.";
        this.textDamage.text = &GameSettings.GetTowerSetting("barrack_barbarian", "minDamage").ToString() + "-" + &GameSettings.GetTowerSetting("barrack_barbarian", "maxDamage").ToString();
        this.textReload.text = this.ReloadToString(GameSettings.GetTowerSetting("barrack_barbarian", "reload"));
        this.textLife.text = &GameSettings.GetTowerSetting("barrack_barbarian", "health").ToString();
        this.textArmor.text = this.ArmorToString(GameSettings.GetTowerSetting("barrack_barbarian", "armor"));
        this.textRespawn.text = &GameSettings.GetTowerSetting("barrack_barbarian", "respawn").ToString() + "s";
        this.Resize(0.8f, 1.6f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 10f, 0f);
        this.textDamage.transform.localPosition = new Vector3(-25f, -27f, -1f);
        this.iconDamage.transform.localPosition = new Vector3(-37f, -34f, -1f);
        this.textLife.transform.localPosition = new Vector3(-107f, -27f, -1f);
        this.iconLife.transform.localPosition = new Vector3(-119f, -34f, -1f);
        this.textArmor.transform.localPosition = new Vector3(80f, -27f, -1f);
        this.iconArmor.transform.localPosition = new Vector3(65f, -34f, -1f);
        this.containerReload.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform64 = base.transform;
        transform64.position += new Vector3(0f, 9f, 0f);
        goto Label_5D2F;
    Label_51F2:
        this.textBottom.text = "May our axes split our enemies in\ntwo!";
        if (level != null)
        {
            goto Label_522D;
        }
        this.textTitle.text = "throwing axes";
        this.textDescription.text = "barbarians can throw great\naxes at ground and flying\nenemies in range.";
        goto Label_5280;
    Label_522D:
        if (level != 1)
        {
            goto Label_5259;
        }
        this.textTitle.text = "throwing axes ii";
        this.textDescription.text = "better axes can be thrown\nfarther and deal 44-54\ndamage.";
        goto Label_5280;
    Label_5259:
        if (level != 2)
        {
            goto Label_5280;
        }
        this.textTitle.text = "throwing axes iii";
        this.textDescription.text = "improved axes can be\nthrown farther and deal\n54-62 damage.";
    Label_5280:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform65 = this.textBottom.transform;
        transform65.position += new Vector3(10f, -11f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_53C8;
        }
        transform66 = base.transform;
        transform66.position += new Vector3(0f, -18f, 0f);
        goto Label_5410;
    Label_53C8:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform67 = base.transform;
        transform67.position += new Vector3(0f, 50f, 0f);
    Label_5410:
        goto Label_5D2F;
    Label_5415:
        this.textBottom.text = "I got something to axe you...";
        if (level != null)
        {
            goto Label_5450;
        }
        this.textTitle.text = "whirlwind attack";
        this.textDescription.text = "when struck, barbarians\nhave a chance of dealing 25\nto 45 damage to all nearby\nenemies.";
        goto Label_54A3;
    Label_5450:
        if (level != 1)
        {
            goto Label_547C;
        }
        this.textTitle.text = "whirlwind attack ii";
        this.textDescription.text = "improves the chance of\nwhirlwind attack to 20%\nand damage to 40-60";
        goto Label_54A3;
    Label_547C:
        if (level != 2)
        {
            goto Label_54A3;
        }
        this.textTitle.text = "whirlwind attack iii";
        this.textDescription.text = "improves the chance of\nwhirlwind attack to 25%\nand damage to 55-75";
    Label_54A3:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform68 = this.textBottom.transform;
        transform68.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_5D2F;
        }
        transform69 = base.transform;
        transform69.position += new Vector3(0f, 31f, 0f);
        goto Label_5D2F;
    Label_55EB:
        this.textBottom.text = "Double the axes, double the fun!";
        if (level != null)
        {
            goto Label_5626;
        }
        this.textTitle.text = "more axes";
        this.textDescription.text = "barbarians equip an\nadditional axe to deliver an\nextra 10 damage on every\nattack.";
        goto Label_5679;
    Label_5626:
        if (level != 1)
        {
            goto Label_5652;
        }
        this.textTitle.text = "more axes ii";
        this.textDescription.text = "improves barbarian attack\ndamage by an extra 10\npoints.";
        goto Label_5679;
    Label_5652:
        if (level != 2)
        {
            goto Label_5679;
        }
        this.textTitle.text = "more axes iii";
        this.textDescription.text = "improves barbarian attack\ndamage by an extra 10\npoints.";
    Label_5679:
        this.Resize(0.8f, 1.4f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 12f, 0f);
        transform70 = this.textBottom.transform;
        transform70.position += new Vector3(10f, -24f, 0f);
        this.textBottom.gameObject.SetActive(1);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        if (&base.transform.localPosition.y >= 0f)
        {
            goto Label_57C1;
        }
        transform71 = base.transform;
        transform71.position += new Vector3(0f, -18f, 0f);
        goto Label_5809;
    Label_57C1:
        if (&base.transform.localPosition.y <= 0f)
        {
            goto Label_5D2F;
        }
        transform72 = base.transform;
        transform72.position += new Vector3(0f, 50f, 0f);
    Label_5809:
        goto Label_5D2F;
    Label_580E:
        this.textTitle.text = "sasquatch";
        this.textDescription.text = "the legendary sasquatch\nwill help you for an\noffering in food, gold and\nsometimes women.";
        this.Resize(0.8f, 1.2f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_58EE:
        this.textTitle.text = "mysterious cave";
        this.textDescription.text = "this cave has been frozen\nsolid for ages...";
        this.Resize(0.75f, 1.1f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_59CE:
        this.textTitle.text = "sell tower";
        this.textDescription.text = "sell this tower and get a\n" + &level.ToString() + " gp refund.";
        this.Resize(0.75f, 0.8f);
        transform73 = base.transform;
        transform73.position -= new Vector3(0f, 25f, 0f);
        this.textTitle.transform.localPosition = this.posTextTitle - new Vector3(0f, 4f, 0f);
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 24f, 0f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_5B02:
        this.textTitle.text = "repair";
        this.textDescription.text = "this elven building was\nonce a training hall of\nsylvan elf warriors";
        this.Resize(0.7f, 0.9f);
        transform74 = base.transform;
        transform74.position += new Vector3(0f, 55f, 0f);
        this.textTitle.transform.localPosition = this.posTextTitle - new Vector3(0f, 2f, 0f);
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 21f, 0f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
        goto Label_5D2F;
    Label_5C25:
        this.textTitle.text = "sylvan elf";
        this.textDescription.text = "sylvan elves are masters\nof bow and blade. they\nwill join your cause...\nfor a price.";
        this.Resize(0.75f, 1.1f);
        transform75 = base.transform;
        transform75.position += new Vector3(0f, 30f, 0f);
        this.textTitle.transform.localPosition = this.posTextTitle;
        this.textDescription.transform.localPosition = this.posTextTitle - new Vector3(0f, 16f, 0f);
        this.containerLife.gameObject.SetActive(0);
        this.containerArmor.gameObject.SetActive(0);
        this.containerRespawn.gameObject.SetActive(0);
        this.containerDamageMagic.gameObject.SetActive(0);
        this.containerDamage.gameObject.SetActive(0);
        this.containerReload.gameObject.SetActive(0);
    Label_5D2F:
        return;
    }

    private void Start()
    {
    }
}

