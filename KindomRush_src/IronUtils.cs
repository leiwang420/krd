using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class IronUtils : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map6;

    public IronUtils()
    {
        base..ctor();
        return;
    }

    public static unsafe bool ellipseContainPoint(Vector3 point, float height, float width, Vector3 center)
    {
        float num;
        float num2;
        float num3;
        float num4;
        num = (float) (((double) width) * 0.5);
        num2 = (float) (((double) height) * 0.5);
        num3 = (float) ((((double) &point.x) - (((double) &center.x) - (((double) width) * 0.5))) - ((double) num));
        num4 = (float) ((((double) &point.y) - (((double) &center.y) - (((double) height) * 0.5))) - ((double) num2));
        return (((Mathf.Pow(num3 / num, 2f) + Mathf.Pow(num4 / num2, 2f)) > 1f) == 0);
    }

    public static unsafe Vector2 ellipseGetPointOfDegree(float degree, float height, float width, Vector2 center)
    {
        float num;
        float num2;
        float num3;
        float num4;
        float num5;
        num = (degree - 90f) * 0.01745329f;
        num2 = width * 0.5f;
        num3 = height * 0.5f;
        num4 = &center.x - (width * 0.5f);
        num5 = &center.y - (height * 0.5f);
        return new Vector2((num4 + num2) + (Mathf.Cos(num) * num2), (num5 + num3) + (Mathf.Sin(num) * num3));
    }

    public static string GetArmor(int armor)
    {
        if (armor != null)
        {
            goto Label_000C;
        }
        return "None";
    Label_000C:
        if (armor < 1)
        {
            goto Label_0021;
        }
        if (armor > 30)
        {
            goto Label_0021;
        }
        return "Low";
    Label_0021:
        if (armor < 0x1f)
        {
            goto Label_0037;
        }
        if (armor > 60)
        {
            goto Label_0037;
        }
        return "Medium";
    Label_0037:
        if (armor < 0x3d)
        {
            goto Label_004D;
        }
        if (armor > 90)
        {
            goto Label_004D;
        }
        return "High";
    Label_004D:
        if (armor < 90)
        {
            goto Label_005B;
        }
        return "Great";
    Label_005B:
        return string.Empty;
    }

    public static unsafe string GetEnemyNameByClassName(string className)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = className;
        if (str == null)
        {
            goto Label_04F7;
        }
        if (<>f__switch$map6 != null)
        {
            goto Label_02C8;
        }
        dictionary = new Dictionary<string, int>(0x35);
        dictionary.Add("EnemyDemon", 0);
        dictionary.Add("EnemyGoblin", 1);
        dictionary.Add("EnemyFatOrc", 2);
        dictionary.Add("EnemyWolfSmall", 3);
        dictionary.Add("EnemyShaman", 4);
        dictionary.Add("EnemyOgre", 5);
        dictionary.Add("EnemyBrigand", 6);
        dictionary.Add("EnemyBandit", 7);
        dictionary.Add("EnemyWolf", 8);
        dictionary.Add("EnemySpiderSmall", 9);
        dictionary.Add("EnemySpider", 10);
        dictionary.Add("EnemyMarauder", 11);
        dictionary.Add("EnemyDarkKnight", 12);
        dictionary.Add("EnemyShadowArcher", 13);
        dictionary.Add("EnemyGargoyle", 14);
        dictionary.Add("EnemyJuggernaut", 15);
        dictionary.Add("EnemyTroll", 0x10);
        dictionary.Add("EnemyWhiteWolf", 0x11);
        dictionary.Add("EnemyTrollAxeThrower", 0x12);
        dictionary.Add("EnemyTrollChieftain", 0x13);
        dictionary.Add("EnemyYeti", 20);
        dictionary.Add("EnemySlayer", 0x15);
        dictionary.Add("EnemyRocketeer", 0x16);
        dictionary.Add("EnemyYetiBoss", 0x17);
        dictionary.Add("EnemyDemonWolf", 0x18);
        dictionary.Add("EnemyDemonMage", 0x19);
        dictionary.Add("EnemyLavaElemental", 0x1a);
        dictionary.Add("EnemyNecromancer", 0x1b);
        dictionary.Add("EnemyDemonImp", 0x1c);
        dictionary.Add("EnemySarelgazSmall", 0x1d);
        dictionary.Add("EnemySarelgaz", 30);
        dictionary.Add("EnemyOrcArmored", 0x1f);
        dictionary.Add("EnemyGoblinZapper", 0x20);
        dictionary.Add("EnemyForestTroll", 0x21);
        dictionary.Add("EnemyOrcWolfRider", 0x22);
        dictionary.Add("EnemyBossGoblinChieftain", 0x23);
        dictionary.Add("EnemyZombie", 0x24);
        dictionary.Add("EnemyRottenSpider", 0x25);
        dictionary.Add("EnemyRottenTree", 0x26);
        dictionary.Add("EnemyThing", 0x27);
        dictionary.Add("EnemyRottenBoss", 40);
        dictionary.Add("EnemyRaider", 0x29);
        dictionary.Add("EnemyPillager", 0x2a);
        dictionary.Add("EnemyBossBandit", 0x2b);
        dictionary.Add("EnemyTrollBrute", 0x2c);
        dictionary.Add("EnemyTrollSkater", 0x2d);
        dictionary.Add("EnemyTrollBoss", 0x2e);
        dictionary.Add("EnemyDemonGulaemon", 0x2f);
        dictionary.Add("EnemyDemonCerberus", 0x30);
        dictionary.Add("EnemyDemonLegion", 0x31);
        dictionary.Add("EnemyDemonFlareon", 50);
        dictionary.Add("EnemyRottenLesser", 0x33);
        dictionary.Add("EnemyMyconidBoss", 0x34);
        <>f__switch$map6 = dictionary;
    Label_02C8:
        if (<>f__switch$map6.TryGetValue(str, &num) == null)
        {
            goto Label_04F7;
        }
        switch (num)
        {
            case 0:
                goto Label_03B9;

            case 1:
                goto Label_03BF;

            case 2:
                goto Label_03C5;

            case 3:
                goto Label_03CB;

            case 4:
                goto Label_03D1;

            case 5:
                goto Label_03D7;

            case 6:
                goto Label_03DD;

            case 7:
                goto Label_03E3;

            case 8:
                goto Label_03E9;

            case 9:
                goto Label_03EF;

            case 10:
                goto Label_03F5;

            case 11:
                goto Label_03FB;

            case 12:
                goto Label_0401;

            case 13:
                goto Label_0407;

            case 14:
                goto Label_040D;

            case 15:
                goto Label_0413;

            case 0x10:
                goto Label_0419;

            case 0x11:
                goto Label_041F;

            case 0x12:
                goto Label_0425;

            case 0x13:
                goto Label_042B;

            case 20:
                goto Label_0431;

            case 0x15:
                goto Label_0437;

            case 0x16:
                goto Label_043D;

            case 0x17:
                goto Label_0443;

            case 0x18:
                goto Label_0449;

            case 0x19:
                goto Label_044F;

            case 0x1a:
                goto Label_0455;

            case 0x1b:
                goto Label_045B;

            case 0x1c:
                goto Label_0461;

            case 0x1d:
                goto Label_0467;

            case 30:
                goto Label_046D;

            case 0x1f:
                goto Label_0473;

            case 0x20:
                goto Label_0479;

            case 0x21:
                goto Label_047F;

            case 0x22:
                goto Label_0485;

            case 0x23:
                goto Label_048B;

            case 0x24:
                goto Label_0491;

            case 0x25:
                goto Label_0497;

            case 0x26:
                goto Label_049D;

            case 0x27:
                goto Label_04A3;

            case 40:
                goto Label_04A9;

            case 0x29:
                goto Label_04AF;

            case 0x2a:
                goto Label_04B5;

            case 0x2b:
                goto Label_04BB;

            case 0x2c:
                goto Label_04C1;

            case 0x2d:
                goto Label_04C7;

            case 0x2e:
                goto Label_04CD;

            case 0x2f:
                goto Label_04D3;

            case 0x30:
                goto Label_04D9;

            case 0x31:
                goto Label_04DF;

            case 50:
                goto Label_04E5;

            case 0x33:
                goto Label_04EB;

            case 0x34:
                goto Label_04F1;
        }
        goto Label_04F7;
    Label_03B9:
        return "Demon Spawn";
    Label_03BF:
        return "Goblin";
    Label_03C5:
        return "Orc";
    Label_03CB:
        return "Wulf";
    Label_03D1:
        return "Shaman";
    Label_03D7:
        return "Ogre";
    Label_03DD:
        return "Brigand";
    Label_03E3:
        return "Bandit";
    Label_03E9:
        return "Worg";
    Label_03EF:
        return "Giant Spider";
    Label_03F5:
        return "Matriarch";
    Label_03FB:
        return "Marauder";
    Label_0401:
        return "Dark Knight";
    Label_0407:
        return "Shadow Archer";
    Label_040D:
        return "Gargoyle";
    Label_0413:
        return "Juggernaut";
    Label_0419:
        return "Troll";
    Label_041F:
        return "White Wolf";
    Label_0425:
        return "Troll Axe Thrower";
    Label_042B:
        return "Troll Chieftain";
    Label_0431:
        return "Yeti";
    Label_0437:
        return "Dark Slayer";
    Label_043D:
        return "Rocketeer";
    Label_0443:
        return "J.T.";
    Label_0449:
        return "Demon Hound";
    Label_044F:
        return "Demon Lord";
    Label_0455:
        return "Lava Elemental";
    Label_045B:
        return "Necromancer";
    Label_0461:
        return "Demon Imp";
    Label_0467:
        return "Son of Sarelgaz";
    Label_046D:
        return "Sarelgaz";
    Label_0473:
        return "Orc Champion";
    Label_0479:
        return "Goblin Zapper";
    Label_047F:
        return "Forest Troll";
    Label_0485:
        return "Orc Wolf Rider";
    Label_048B:
        return "Gul'Thak";
    Label_0491:
        return "Husk";
    Label_0497:
        return "Noxious Creeper";
    Label_049D:
        return "Tainted Treant";
    Label_04A3:
        return "Swamp Thing";
    Label_04A9:
        return "Greenmuck";
    Label_04AF:
        return "Raider";
    Label_04B5:
        return "Pillager";
    Label_04BB:
        return "The Kingpin";
    Label_04C1:
        return "Troll Breaker";
    Label_04C7:
        return "Troll Pathfinder";
    Label_04CD:
        return "Ulguk-Hai";
    Label_04D3:
        return "Gulaemon";
    Label_04D9:
        return "Cerberus";
    Label_04DF:
        return "Demon Legion";
    Label_04E5:
        return "Flareon";
    Label_04EB:
        return "Rotshroom";
    Label_04F1:
        return "Myconid";
    Label_04F7:
        return string.Empty;
    }

    public static bool IsFlyingByCreepType(string creepType)
    {
        if ("EnemyGargoyle".Equals(creepType) != null)
        {
            goto Label_0030;
        }
        if ("EnemyDemonImp".Equals(creepType) != null)
        {
            goto Label_0030;
        }
        if ("EnemyRocketeer".Equals(creepType) == null)
        {
            goto Label_0032;
        }
    Label_0030:
        return 1;
    Label_0032:
        return 0;
    }
}

