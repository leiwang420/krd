using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map4;
    public Creep abomination;
    public Creep bandit;
    public Creep blackburnBoss;
    public Creep bossBandit;
    public Creep brigand;
    public Creep cerberus;
    private int creepCount;
    public Creep darkKnight;
    public Creep demon;
    public Creep demonFlareon;
    public Creep demonImp;
    public Creep demonLegion;
    public Creep demonMage;
    public Creep demonWolf;
    private float dt;
    public Creep fallenKnight;
    public Creep forestTroll;
    public Creep gargoyle;
    public Creep giantRat;
    public Creep goblin;
    public Creep goblinChieftain;
    public Creep goblinZapper;
    public Creep gulaemon;
    private int i;
    public Creep JT;
    public Creep juggernaut;
    public Creep lavaElemental;
    private int layer;
    public Creep lycan;
    public Creep marauder;
    public Creep myconidBoss;
    public Creep necromancer;
    public Creep ogre;
    public Creep orc;
    public Creep orcAmored;
    public Creep orcWolfRider;
    public Creep pillager;
    public Creep raider;
    public Creep rocketeer;
    public Creep rottenBoss;
    public Creep rottenLesser;
    public Creep rottenTree;
    public Creep sarelgaz;
    public Creep sarelgazSmall;
    public Creep shadowArcher;
    public Creep shaman;
    public Creep slayer;
    public Creep spectralKnight;
    public Creep spiderMedium;
    public Creep spiderRotten;
    public Creep spiderSmall;
    public Creep swampThing;
    public Creep troll;
    public Creep trollAxe;
    public Creep trollBoss;
    public Creep trollBrute;
    public Creep trollChieftain;
    public Creep trollSkater;
    public Creep wererat;
    public Creep werewolf;
    public Creep werewolfSpecial;
    public Creep winterwolf;
    public Creep witch;
    public Creep worg;
    public Creep wulf;
    public Creep yeti;
    public Creep zombie;

    public CreepSpawner()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
    }

    public int GetSkeletonCount()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        num = 0;
        enumerator = base.transform.GetEnumerator();
    Label_000E:
        try
        {
            goto Label_004D;
        Label_0013:
            transform = (Transform) enumerator.Current;
            if ((transform.name == "Skeleton") != null)
            {
                goto Label_0049;
            }
            if ((transform.name == "Skeleton Warrior") == null)
            {
                goto Label_004D;
            }
        Label_0049:
            num += 1;
        Label_004D:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0013;
            }
            goto Label_006F;
        }
        finally
        {
        Label_005D:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0068;
            }
        Label_0068:
            disposable.Dispose();
        }
    Label_006F:
        return num;
    }

    public unsafe void Spawn(string enemyType, int pathIndex, int subPath)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = enemyType;
        if (str == null)
        {
            goto Label_0796;
        }
        if (<>f__switch$map4 != null)
        {
            goto Label_034A;
        }
        dictionary = new Dictionary<string, int>(0x3f);
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
        dictionary.Add("EnemyTrollSkater", 0x2c);
        dictionary.Add("EnemyTrollBrute", 0x2d);
        dictionary.Add("EnemyTrollBoss", 0x2e);
        dictionary.Add("EnemyDemonGulaemon", 0x2f);
        dictionary.Add("EnemyDemonCerberus", 0x30);
        dictionary.Add("EnemyDemonLegion", 0x31);
        dictionary.Add("EnemyDemonFlareon", 50);
        dictionary.Add("EnemyRottenLesser", 0x33);
        dictionary.Add("EnemyMyconidBoss", 0x34);
        dictionary.Add("EnemyWerewolf", 0x35);
        dictionary.Add("EnemyLycan", 0x36);
        dictionary.Add("EnemyWerewolfSpecial", 0x37);
        dictionary.Add("EnemyAbomination", 0x38);
        dictionary.Add("EnemyGiantRat", 0x39);
        dictionary.Add("EnemyFallenKnight", 0x3a);
        dictionary.Add("EnemySpectralKnight", 0x3b);
        dictionary.Add("EnemyWererat", 60);
        dictionary.Add("EnemyWitch", 0x3d);
        dictionary.Add("EnemyBlackburnBoss", 0x3e);
        <>f__switch$map4 = dictionary;
    Label_034A:
        if (<>f__switch$map4.TryGetValue(str, &num) == null)
        {
            goto Label_0796;
        }
        switch (num)
        {
            case 0:
                goto Label_0463;

            case 1:
                goto Label_0470;

            case 2:
                goto Label_047D;

            case 3:
                goto Label_048A;

            case 4:
                goto Label_0497;

            case 5:
                goto Label_04A4;

            case 6:
                goto Label_04B1;

            case 7:
                goto Label_04BE;

            case 8:
                goto Label_04CB;

            case 9:
                goto Label_04D8;

            case 10:
                goto Label_04E5;

            case 11:
                goto Label_04F2;

            case 12:
                goto Label_04FF;

            case 13:
                goto Label_050C;

            case 14:
                goto Label_0519;

            case 15:
                goto Label_0526;

            case 0x10:
                goto Label_0533;

            case 0x11:
                goto Label_0540;

            case 0x12:
                goto Label_054D;

            case 0x13:
                goto Label_055A;

            case 20:
                goto Label_0567;

            case 0x15:
                goto Label_0574;

            case 0x16:
                goto Label_0581;

            case 0x17:
                goto Label_058E;

            case 0x18:
                goto Label_059B;

            case 0x19:
                goto Label_05A8;

            case 0x1a:
                goto Label_05B5;

            case 0x1b:
                goto Label_05C2;

            case 0x1c:
                goto Label_05CF;

            case 0x1d:
                goto Label_05DC;

            case 30:
                goto Label_05E9;

            case 0x1f:
                goto Label_05F6;

            case 0x20:
                goto Label_0603;

            case 0x21:
                goto Label_0610;

            case 0x22:
                goto Label_061D;

            case 0x23:
                goto Label_062A;

            case 0x24:
                goto Label_0637;

            case 0x25:
                goto Label_0644;

            case 0x26:
                goto Label_0651;

            case 0x27:
                goto Label_065E;

            case 40:
                goto Label_066B;

            case 0x29:
                goto Label_0678;

            case 0x2a:
                goto Label_0685;

            case 0x2b:
                goto Label_0692;

            case 0x2c:
                goto Label_069F;

            case 0x2d:
                goto Label_06AC;

            case 0x2e:
                goto Label_06B9;

            case 0x2f:
                goto Label_06C6;

            case 0x30:
                goto Label_06D3;

            case 0x31:
                goto Label_06E0;

            case 50:
                goto Label_06ED;

            case 0x33:
                goto Label_06FA;

            case 0x34:
                goto Label_0707;

            case 0x35:
                goto Label_0714;

            case 0x36:
                goto Label_0721;

            case 0x37:
                goto Label_072E;

            case 0x38:
                goto Label_073B;

            case 0x39:
                goto Label_0748;

            case 0x3a:
                goto Label_0755;

            case 0x3b:
                goto Label_0762;

            case 60:
                goto Label_076F;

            case 0x3d:
                goto Label_077C;

            case 0x3e:
                goto Label_0789;
        }
        goto Label_0796;
    Label_0463:
        this.SpawnDemon(pathIndex, subPath);
        goto Label_0796;
    Label_0470:
        this.SpawnGoblin(pathIndex, subPath);
        goto Label_0796;
    Label_047D:
        this.SpawnFatOrc(pathIndex, subPath);
        goto Label_0796;
    Label_048A:
        this.SpawnWolfSmall(pathIndex, subPath);
        goto Label_0796;
    Label_0497:
        this.SpawnShaman(pathIndex, subPath);
        goto Label_0796;
    Label_04A4:
        this.SpawnOgre(pathIndex, subPath);
        goto Label_0796;
    Label_04B1:
        this.SpawnBrigand(pathIndex, subPath);
        goto Label_0796;
    Label_04BE:
        this.SpawnBandit(pathIndex, subPath);
        goto Label_0796;
    Label_04CB:
        this.SpawnWolf(pathIndex, subPath);
        goto Label_0796;
    Label_04D8:
        this.SpawnSpiderSmall(pathIndex, subPath);
        goto Label_0796;
    Label_04E5:
        this.SpawnSpider(pathIndex, subPath);
        goto Label_0796;
    Label_04F2:
        this.SpawnMarauder(pathIndex, subPath);
        goto Label_0796;
    Label_04FF:
        this.SpawnDarkKnight(pathIndex, subPath);
        goto Label_0796;
    Label_050C:
        this.SpawnShadowArcher(pathIndex, subPath);
        goto Label_0796;
    Label_0519:
        this.SpawnGargoyle(pathIndex, subPath);
        goto Label_0796;
    Label_0526:
        this.SpawnJuggernaut(pathIndex, subPath);
        goto Label_0796;
    Label_0533:
        this.SpawnTroll(pathIndex, subPath);
        goto Label_0796;
    Label_0540:
        this.SpawnWinterWolf(pathIndex, subPath);
        goto Label_0796;
    Label_054D:
        this.SpawnTrollAxeThrower(pathIndex, subPath);
        goto Label_0796;
    Label_055A:
        this.SpawnTrollChieftain(pathIndex, subPath);
        goto Label_0796;
    Label_0567:
        this.SpawnYeti(pathIndex, subPath);
        goto Label_0796;
    Label_0574:
        this.SpawnSlayer(pathIndex, subPath);
        goto Label_0796;
    Label_0581:
        this.SpawnRocketeer(pathIndex, subPath);
        goto Label_0796;
    Label_058E:
        this.SpawnJT(pathIndex, subPath);
        goto Label_0796;
    Label_059B:
        this.SpawnDemonWolf(pathIndex, subPath);
        goto Label_0796;
    Label_05A8:
        this.SpawnDemonMage(pathIndex, subPath);
        goto Label_0796;
    Label_05B5:
        this.SpawnLavaElemental(pathIndex, subPath);
        goto Label_0796;
    Label_05C2:
        this.SpawnNecromancer(pathIndex, subPath);
        goto Label_0796;
    Label_05CF:
        this.SpawnDemonImp(pathIndex, subPath);
        goto Label_0796;
    Label_05DC:
        this.SpawnSarelgazSmall(pathIndex, subPath);
        goto Label_0796;
    Label_05E9:
        this.SpawnSarelgaz(pathIndex, subPath);
        goto Label_0796;
    Label_05F6:
        this.SpawnOrcArmored(pathIndex, subPath);
        goto Label_0796;
    Label_0603:
        this.SpawnGoblinZapper(pathIndex, subPath);
        goto Label_0796;
    Label_0610:
        this.SpawnForestTroll(pathIndex, subPath);
        goto Label_0796;
    Label_061D:
        this.SpawnOrcWolfRider(pathIndex, subPath);
        goto Label_0796;
    Label_062A:
        this.SpawnGoblinChieftain(pathIndex, subPath);
        goto Label_0796;
    Label_0637:
        this.SpawnZombie(pathIndex, subPath);
        goto Label_0796;
    Label_0644:
        this.SpawnSpiderRotten(pathIndex, subPath);
        goto Label_0796;
    Label_0651:
        this.SpawnRottenTree(pathIndex, subPath);
        goto Label_0796;
    Label_065E:
        this.SpawnSwampThing(pathIndex, subPath);
        goto Label_0796;
    Label_066B:
        this.SpawnRottenBoss(pathIndex, subPath);
        goto Label_0796;
    Label_0678:
        this.SpawnRaider(pathIndex, subPath);
        goto Label_0796;
    Label_0685:
        this.SpawnPillager(pathIndex, subPath);
        goto Label_0796;
    Label_0692:
        this.SpawnBossBandit(pathIndex, subPath);
        goto Label_0796;
    Label_069F:
        this.SpawnTrollSkater(pathIndex, subPath);
        goto Label_0796;
    Label_06AC:
        this.SpawnTrollBrute(pathIndex, subPath);
        goto Label_0796;
    Label_06B9:
        this.SpawnTrollBoss(pathIndex, subPath);
        goto Label_0796;
    Label_06C6:
        this.SpawnGulaemon(pathIndex, subPath);
        goto Label_0796;
    Label_06D3:
        this.SpawnCerberus(pathIndex, subPath);
        goto Label_0796;
    Label_06E0:
        this.SpawnDemonLegion(pathIndex, subPath);
        goto Label_0796;
    Label_06ED:
        this.SpawnDemonFlareon(pathIndex, subPath);
        goto Label_0796;
    Label_06FA:
        this.SpawnRottenLesser(pathIndex, subPath);
        goto Label_0796;
    Label_0707:
        this.SpawnMyconidBoss(pathIndex, subPath);
        goto Label_0796;
    Label_0714:
        this.SpawnWerewolf(pathIndex, subPath);
        goto Label_0796;
    Label_0721:
        this.SpawnLycan(pathIndex, subPath);
        goto Label_0796;
    Label_072E:
        this.SpawnWerewolfSpecial(pathIndex, subPath);
        goto Label_0796;
    Label_073B:
        this.SpawnAbomination(pathIndex, subPath);
        goto Label_0796;
    Label_0748:
        this.SpawnGiantRat(pathIndex, subPath);
        goto Label_0796;
    Label_0755:
        this.SpawnFallenKnight(pathIndex, subPath);
        goto Label_0796;
    Label_0762:
        this.SpawnSpectralKnight(pathIndex, subPath);
        goto Label_0796;
    Label_076F:
        this.SpawnWererat(pathIndex, subPath);
        goto Label_0796;
    Label_077C:
        this.SpawnWitch(pathIndex, subPath);
        goto Label_0796;
    Label_0789:
        this.SpawnBlackburnBoss(pathIndex, subPath);
    Label_0796:
        return;
    }

    private void SpawnAbomination(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.abomination, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Abomination";
        return;
    }

    private void SpawnBandit(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.bandit, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Bandit";
        return;
    }

    private void SpawnBlackburnBoss(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.blackburnBoss, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Blackburn";
        return;
    }

    private void SpawnBossBandit(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.bossBandit, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnBrigand(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.brigand, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Brigand";
        return;
    }

    private void SpawnCerberus(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.cerberus, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Cerberus";
        return;
    }

    private void SpawnDarkKnight(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.darkKnight, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Dark Knight";
        return;
    }

    private void SpawnDemon(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.demon, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Demon";
        return;
    }

    private void SpawnDemonFlareon(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.demonFlareon, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Demon Flareon";
        return;
    }

    private void SpawnDemonImp(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.demonImp, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Demon Imp";
        return;
    }

    private void SpawnDemonLegion(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.demonLegion, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Demon Legion";
        return;
    }

    private void SpawnDemonMage(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.demonMage, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Demon Mage";
        return;
    }

    private void SpawnDemonWolf(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.demonWolf, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Demon Wolf";
        return;
    }

    private void SpawnFallenKnight(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.fallenKnight, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Fallen Knight";
        return;
    }

    private void SpawnFatOrc(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.orc, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Fat Orc";
        return;
    }

    private void SpawnForestTroll(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.forestTroll, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Forest Troll";
        return;
    }

    private void SpawnGargoyle(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.gargoyle, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Gargoyle";
        return;
    }

    private void SpawnGiantRat(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.giantRat, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Giant Rat";
        return;
    }

    private void SpawnGoblin(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.goblin, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Goblin";
        return;
    }

    private void SpawnGoblinChieftain(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.goblinChieftain, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Gulthak";
        return;
    }

    private void SpawnGoblinZapper(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.goblinZapper, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Goblin Zapper";
        return;
    }

    private void SpawnGulaemon(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.gulaemon, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Gulaemon";
        return;
    }

    private void SpawnJT(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.JT, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnJuggernaut(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.juggernaut, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnLavaElemental(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.lavaElemental, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Lava Elemental";
        return;
    }

    private void SpawnLycan(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.lycan, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Lycan";
        return;
    }

    private void SpawnMarauder(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.marauder, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Marauder";
        return;
    }

    private void SpawnMyconidBoss(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.myconidBoss, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Myconid Boss";
        return;
    }

    private void SpawnNecromancer(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.necromancer, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Necromancer";
        return;
    }

    private void SpawnOgre(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.ogre, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Ogre";
        return;
    }

    private void SpawnOrcArmored(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.orcAmored, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Orc Champion";
        return;
    }

    private void SpawnOrcWolfRider(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.orcWolfRider, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Orc Rider";
        return;
    }

    private void SpawnPillager(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.pillager, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Pillager";
        return;
    }

    private void SpawnRaider(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.raider, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Raider";
        return;
    }

    private void SpawnRocketeer(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.rocketeer, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnRottenBoss(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.rottenBoss, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnRottenLesser(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.rottenLesser, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Rotten Lesser";
        return;
    }

    private void SpawnRottenTree(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.rottenTree, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Rotten Tree";
        return;
    }

    private void SpawnSarelgaz(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.sarelgaz, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnSarelgazSmall(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.sarelgazSmall, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnShadowArcher(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.shadowArcher, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Shadow Archer";
        return;
    }

    private void SpawnShaman(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.shaman, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Shaman";
        return;
    }

    private void SpawnSlayer(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.slayer, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Slayer";
        return;
    }

    private void SpawnSpectralKnight(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.spectralKnight, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Spectral Knight";
        return;
    }

    private void SpawnSpider(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.spiderMedium, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        return;
    }

    private void SpawnSpiderRotten(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.spiderRotten, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Spider Rotten";
        return;
    }

    private void SpawnSpiderSmall(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.spiderSmall, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Spider Small";
        return;
    }

    private void SpawnSwampThing(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.swampThing, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Swamp Thing";
        return;
    }

    private void SpawnTroll(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.troll, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Troll";
        return;
    }

    private void SpawnTrollAxeThrower(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.trollAxe, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Troll Axe Thrower";
        return;
    }

    private void SpawnTrollBoss(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.trollBoss, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Troll Boss";
        return;
    }

    private void SpawnTrollBrute(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.trollBrute, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Troll Brute";
        return;
    }

    private void SpawnTrollChieftain(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.trollChieftain, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Troll Chieftain";
        return;
    }

    private void SpawnTrollSkater(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.trollSkater, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Troll Skater";
        return;
    }

    private void SpawnWererat(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.wererat, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Wererat";
        return;
    }

    private void SpawnWerewolf(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.werewolf, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Werewolf";
        return;
    }

    private void SpawnWerewolfSpecial(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.werewolfSpecial, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Werewolf Special";
        return;
    }

    private void SpawnWinterWolf(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.winterwolf, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "White Wolf";
        return;
    }

    private void SpawnWitch(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.witch, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Witch";
        return;
    }

    private void SpawnWolf(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.worg, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Wolf";
        return;
    }

    private void SpawnWolfSmall(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.wulf, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Wolf Small";
        return;
    }

    private void SpawnYeti(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.yeti, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Yeti";
        return;
    }

    private void SpawnZombie(int pathIndex, int subPath)
    {
        Creep creep;
        creep = UnityEngine.Object.Instantiate(this.zombie, base.transform.position, base.transform.rotation) as Creep;
        creep.transform.parent = base.transform;
        creep.SetSubPath(subPath);
        creep.SetPathIndex(pathIndex);
        creep.InitPosition();
        creep.name = "Zombie";
        return;
    }

    private void Start()
    {
        this.dt = 0f;
        this.creepCount = 0;
        return;
    }
}

