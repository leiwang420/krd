using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EncyclopediaContainerCreeps : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map8;
    private EncyclopediaCreepItem bandit;
    private EncyclopediaCreepItem brigand;
    private EncyclopediaCreepPageButton buttonPage1;
    private EncyclopediaCreepPageButton buttonPage2;
    private EncyclopediaCreepItem cerberus;
    private Transform containerPage1;
    private Transform containerPage2;
    private int currentPage;
    private EncyclopediaCreepItem darkKnight;
    private EncyclopediaCreepItem darkKnightSlayer;
    private EncyclopediaCreepItem demon;
    private EncyclopediaCreepItem demonImp;
    private EncyclopediaCreepItem demonLegion;
    private EncyclopediaCreepItem demonMage;
    private EncyclopediaCreepItem demonMoloch;
    private EncyclopediaCreepItem demonWolf;
    private EncyclopediaCreepItem fatOrc;
    private EncyclopediaCreepItem flareon;
    private Transform footer;
    private EncyclopediaCreepItem forestTroll;
    private EncyclopediaCreepItem gargoyle;
    private EncyclopediaCreepItem giantSpider;
    private EncyclopediaCreepItem goblin;
    private EncyclopediaCreepItem goblinZapper;
    private EncyclopediaCreepItem golemHead;
    private EncyclopediaCreepItem greenmuck;
    private EncyclopediaCreepItem gulaemon;
    private EncyclopediaCreepItem gulthak;
    private Transform holderBandit;
    private Transform holderBrigand;
    private Transform holderCerberus;
    private Transform holderDarkKnight;
    private Transform holderDarkKnightSlayer;
    private Transform holderDemon;
    private Transform holderDemonImp;
    private Transform holderDemonLegion;
    private Transform holderDemonMage;
    private Transform holderDemonMoloch;
    private Transform holderDemonWolf;
    private Transform holderFatOrc;
    private Transform holderFlareon;
    private Transform holderForestTroll;
    private Transform holderGargoyle;
    private Transform holderGiantSpider;
    private Transform holderGoblin;
    private Transform holderGoblinZapper;
    private Transform holderGolemHead;
    private Transform holderGreenmuck;
    private Transform holderGulaemon;
    private Transform holderGulthak;
    private Transform holderHusk;
    private Transform holderJt;
    private Transform holderJuggernaut;
    private Transform holderKingpin;
    private Transform holderLavaElemental;
    private Transform holderMarauder;
    private Transform holderMyconid;
    private Transform holderNecromancer;
    private Transform holderNoxiousCreeper;
    private Transform holderOgre;
    private Transform holderOrcChampion;
    private Transform holderPillager;
    private Transform holderRaider;
    private Transform holderRocketeer;
    private Transform holderRottenLesser;
    private Transform holderSarelgaz;
    private Transform holderShadowArcher;
    private Transform holderShaman;
    private Transform holderSkeleton;
    private Transform holderSkeletonWarrior;
    private Transform holderSonOfSarelgaz;
    private Transform holderSpiderMatriarch;
    private Transform holderSwampThing;
    private Transform holderTreant;
    private Transform holderTroll;
    private Transform holderTrollBoss;
    private Transform holderTrollBrute;
    private Transform holderTrollChampion;
    private Transform holderTrollChieftain;
    private Transform holderTrollSkater;
    private Transform holderVeznan;
    private Transform holderWinterWolf;
    private Transform holderWorg;
    private Transform holderWorgRider;
    private Transform holderWulf;
    private Transform holderYeti;
    private EncyclopediaCreepItem husk;
    private EncyclopediaCreepItem jt;
    private EncyclopediaCreepItem juggernaut;
    private EncyclopediaCreepItem kingpin;
    private EncyclopediaCreepItem lavaElemental;
    private EncyclopediaCreepItem marauder;
    private EncyclopediaCreepItem myconid;
    private EncyclopediaCreepItem necromancer;
    private EncyclopediaCreepItem noxiousCreeper;
    private EncyclopediaCreepItem ogre;
    private EncyclopediaCreepItem orcChampion;
    private EncyclopediaCreepItem pillager;
    private EncyclopediaCreepItem raider;
    private EncyclopediaCreepItem rocketeer;
    private EncyclopediaCreepItem rottenLesser;
    private EncyclopediaCreepItem sarelgaz;
    private EncyclopediaCreepItem selectedItem;
    private EncyclopediaCreepItem shadowArcher;
    private EncyclopediaCreepItem shaman;
    private EncyclopediaCreepItem skeleton;
    private EncyclopediaCreepItem skeletonWarrior;
    private EncyclopediaCreepItem sonOfSarelgaz;
    private EncyclopediaCreepItem spiderMatriarch;
    private EncyclopediaCreepItem swampThing;
    private EncyclopediaCreepItem treant;
    private EncyclopediaCreepItem troll;
    private EncyclopediaCreepItem trollBoss;
    private EncyclopediaCreepItem trollBrute;
    private EncyclopediaCreepItem trollChampion;
    private EncyclopediaCreepItem trollChieftain;
    private EncyclopediaCreepItem trollSkater;
    private EncyclopediaCreepItem veznan;
    private EncyclopediaCreepItem winterWolf;
    private EncyclopediaCreepItem worg;
    private EncyclopediaCreepItem worgRider;
    private EncyclopediaCreepItem wulf;
    private EncyclopediaCreepItem yeti;

    public EncyclopediaContainerCreeps()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public int GetSelectedPage()
    {
        return this.currentPage;
    }

    private void InitPages()
    {
        this.containerPage1 = base.transform.FindChild("Page1");
        this.containerPage2 = base.transform.FindChild("Page2");
        this.goblin.transform.parent = this.containerPage1;
        this.fatOrc.transform.parent = this.containerPage1;
        this.shaman.transform.parent = this.containerPage1;
        this.ogre.transform.parent = this.containerPage1;
        this.bandit.transform.parent = this.containerPage1;
        this.brigand.transform.parent = this.containerPage1;
        this.marauder.transform.parent = this.containerPage1;
        this.giantSpider.transform.parent = this.containerPage1;
        this.spiderMatriarch.transform.parent = this.containerPage1;
        this.gargoyle.transform.parent = this.containerPage1;
        this.shadowArcher.transform.parent = this.containerPage1;
        this.darkKnight.transform.parent = this.containerPage1;
        this.wulf.transform.parent = this.containerPage1;
        this.worg.transform.parent = this.containerPage1;
        this.golemHead.transform.parent = this.containerPage1;
        this.winterWolf.transform.parent = this.containerPage1;
        this.troll.transform.parent = this.containerPage1;
        this.trollChampion.transform.parent = this.containerPage1;
        this.trollChieftain.transform.parent = this.containerPage1;
        this.yeti.transform.parent = this.containerPage1;
        this.rocketeer.transform.parent = this.containerPage1;
        this.darkKnightSlayer.transform.parent = this.containerPage1;
        this.demon.transform.parent = this.containerPage1;
        this.demonMage.transform.parent = this.containerPage1;
        this.demonWolf.transform.parent = this.containerPage1;
        this.demonImp.transform.parent = this.containerPage1;
        this.skeleton.transform.parent = this.containerPage1;
        this.skeletonWarrior.transform.parent = this.containerPage1;
        this.necromancer.transform.parent = this.containerPage1;
        this.lavaElemental.transform.parent = this.containerPage1;
        this.juggernaut.transform.parent = this.containerPage1;
        this.jt.transform.parent = this.containerPage1;
        this.veznan.transform.parent = this.containerPage1;
        this.sonOfSarelgaz.transform.parent = this.containerPage1;
        this.goblinZapper.transform.parent = this.containerPage1;
        this.orcChampion.transform.parent = this.containerPage1;
        this.worgRider.transform.parent = this.containerPage2;
        this.forestTroll.transform.parent = this.containerPage2;
        this.sarelgaz.transform.parent = this.containerPage2;
        this.gulthak.transform.parent = this.containerPage2;
        this.husk.transform.parent = this.containerPage2;
        this.treant.transform.parent = this.containerPage2;
        this.noxiousCreeper.transform.parent = this.containerPage2;
        this.swampThing.transform.parent = this.containerPage2;
        this.greenmuck.transform.parent = this.containerPage2;
        this.pillager.transform.parent = this.containerPage2;
        this.raider.transform.parent = this.containerPage2;
        this.kingpin.transform.parent = this.containerPage2;
        this.trollBoss.transform.parent = this.containerPage2;
        this.trollBrute.transform.parent = this.containerPage2;
        this.trollSkater.transform.parent = this.containerPage2;
        this.demonLegion.transform.parent = this.containerPage2;
        this.flareon.transform.parent = this.containerPage2;
        this.gulaemon.transform.parent = this.containerPage2;
        this.cerberus.transform.parent = this.containerPage2;
        this.demonMoloch.transform.parent = this.containerPage2;
        this.containerPage2.gameObject.SetActive(0);
        return;
    }

    private void InitPositions()
    {
        this.goblin.transform.localPosition = new Vector3(-367f, 200f, -1f);
        this.fatOrc.transform.localPosition = new Vector3(-303f, 200f, -1f);
        this.shaman.transform.localPosition = new Vector3(-239f, 200f, -1f);
        this.ogre.transform.localPosition = new Vector3(-175f, 200f, -1f);
        this.bandit.transform.localPosition = new Vector3(-111f, 200f, -1f);
        this.brigand.transform.localPosition = new Vector3(-47f, 200f, -1f);
        this.marauder.transform.localPosition = new Vector3(-367f, 138f, -1f);
        this.giantSpider.transform.localPosition = new Vector3(-303f, 138f, -1f);
        this.spiderMatriarch.transform.localPosition = new Vector3(-239f, 138f, -1f);
        this.gargoyle.transform.localPosition = new Vector3(-175f, 138f, -1f);
        this.shadowArcher.transform.localPosition = new Vector3(-111f, 138f, -1f);
        this.darkKnight.transform.localPosition = new Vector3(-47f, 138f, -1f);
        this.wulf.transform.localPosition = new Vector3(-367f, 76f, -1f);
        this.worg.transform.localPosition = new Vector3(-303f, 76f, -1f);
        this.golemHead.transform.localPosition = new Vector3(-239f, 76f, -1f);
        this.winterWolf.transform.localPosition = new Vector3(-175f, 76f, -1f);
        this.troll.transform.localPosition = new Vector3(-111f, 76f, -1f);
        this.trollChampion.transform.localPosition = new Vector3(-47f, 76f, -1f);
        this.trollChieftain.transform.localPosition = new Vector3(-367f, 14f, -1f);
        this.yeti.transform.localPosition = new Vector3(-303f, 14f, -1f);
        this.rocketeer.transform.localPosition = new Vector3(-239f, 14f, -1f);
        this.darkKnightSlayer.transform.localPosition = new Vector3(-175f, 14f, -1f);
        this.demon.transform.localPosition = new Vector3(-111f, 14f, -1f);
        this.demonMage.transform.localPosition = new Vector3(-47f, 14f, -1f);
        this.demonWolf.transform.localPosition = new Vector3(-367f, -48f, -1f);
        this.demonImp.transform.localPosition = new Vector3(-303f, -48f, -1f);
        this.skeleton.transform.localPosition = new Vector3(-239f, -48f, -1f);
        this.skeletonWarrior.transform.localPosition = new Vector3(-175f, -48f, -1f);
        this.necromancer.transform.localPosition = new Vector3(-111f, -48f, -1f);
        this.lavaElemental.transform.localPosition = new Vector3(-47f, -48f, -1f);
        this.juggernaut.transform.localPosition = new Vector3(-367f, -110f, -1f);
        this.jt.transform.localPosition = new Vector3(-303f, -110f, -1f);
        this.veznan.transform.localPosition = new Vector3(-239f, -110f, -1f);
        this.sonOfSarelgaz.transform.localPosition = new Vector3(-175f, -110f, -1f);
        this.goblinZapper.transform.localPosition = new Vector3(-111f, -110f, -1f);
        this.orcChampion.transform.localPosition = new Vector3(-47f, -110f, -1f);
        this.worgRider.transform.localPosition = new Vector3(-367f, 200f, -1f);
        this.forestTroll.transform.localPosition = new Vector3(-303f, 200f, -1f);
        this.sarelgaz.transform.localPosition = new Vector3(-239f, 200f, -1f);
        this.gulthak.transform.localPosition = new Vector3(-175f, 200f, -1f);
        this.husk.transform.localPosition = new Vector3(-111f, 200f, -1f);
        this.treant.transform.localPosition = new Vector3(-47f, 200f, -1f);
        this.noxiousCreeper.transform.localPosition = new Vector3(-367f, 138f, -1f);
        this.swampThing.transform.localPosition = new Vector3(-303f, 138f, -1f);
        this.greenmuck.transform.localPosition = new Vector3(-239f, 138f, -1f);
        this.pillager.transform.localPosition = new Vector3(-175f, 138f, -1f);
        this.raider.transform.localPosition = new Vector3(-111f, 138f, -1f);
        this.kingpin.transform.localPosition = new Vector3(-47f, 138f, -1f);
        this.trollBrute.transform.localPosition = new Vector3(-367f, 76f, -1f);
        this.trollSkater.transform.localPosition = new Vector3(-303f, 76f, -1f);
        this.trollBoss.transform.localPosition = new Vector3(-239f, 76f, -1f);
        this.demonLegion.transform.localPosition = new Vector3(-175f, 76f, -1f);
        this.flareon.transform.localPosition = new Vector3(-111f, 76f, -1f);
        this.gulaemon.transform.localPosition = new Vector3(-47f, 76f, -1f);
        this.cerberus.transform.localPosition = new Vector3(-367f, 14f, -1f);
        this.demonMoloch.transform.localPosition = new Vector3(-303f, 14f, -1f);
        return;
    }

    private void LoadHolders()
    {
        this.holderBandit = base.transform.FindChild("HolderBandit");
        this.holderBrigand = base.transform.FindChild("HolderBrigand");
        this.holderDarkKnight = base.transform.FindChild("HolderDarkKnight");
        this.holderDarkKnightSlayer = base.transform.FindChild("HolderDarkKnightSlayer");
        this.holderDemon = base.transform.FindChild("HolderDemon");
        this.holderDemonImp = base.transform.FindChild("HolderDemonImp");
        this.holderDemonMage = base.transform.FindChild("HolderDemonMage");
        this.holderDemonWolf = base.transform.FindChild("HolderDemonWolf");
        this.holderFatOrc = base.transform.FindChild("HolderFatOrc");
        this.holderForestTroll = base.transform.FindChild("HolderForestTroll");
        this.holderGargoyle = base.transform.FindChild("HolderGargoyle");
        this.holderGiantSpider = base.transform.FindChild("HolderGiantSpiders");
        this.holderGoblin = base.transform.FindChild("HolderGoblin");
        this.holderGoblinZapper = base.transform.FindChild("HolderGoblinZapper");
        this.holderGolemHead = base.transform.FindChild("HolderGolemHead");
        this.holderGreenmuck = base.transform.FindChild("HolderGreenmuck");
        this.holderGulthak = base.transform.FindChild("HolderGulthak");
        this.holderHusk = base.transform.FindChild("HolderHusk");
        this.holderJt = base.transform.FindChild("HolderJT");
        this.holderJuggernaut = base.transform.FindChild("HolderJuggernaut");
        this.holderKingpin = base.transform.FindChild("HolderKingpin");
        this.holderLavaElemental = base.transform.FindChild("HolderLavaElemental");
        this.holderMarauder = base.transform.FindChild("HolderMarauder");
        this.holderNecromancer = base.transform.FindChild("HolderNecromancer");
        this.holderNoxiousCreeper = base.transform.FindChild("HolderNoxiousCreeper");
        this.holderOgre = base.transform.FindChild("HolderOgre");
        this.holderOrcChampion = base.transform.FindChild("HolderOrcChampion");
        this.holderPillager = base.transform.FindChild("HolderPillager");
        this.holderRaider = base.transform.FindChild("HolderRaider");
        this.holderRocketeer = base.transform.FindChild("HolderRocketeer");
        this.holderSarelgaz = base.transform.FindChild("HolderSarelgaz");
        this.holderShadowArcher = base.transform.FindChild("HolderShadowArcher");
        this.holderShaman = base.transform.FindChild("HolderShaman");
        this.holderSkeleton = base.transform.FindChild("HolderSkeleton");
        this.holderSkeletonWarrior = base.transform.FindChild("HolderSkeletonWarrior");
        this.holderSonOfSarelgaz = base.transform.FindChild("HolderSonOfSarelgaz");
        this.holderSpiderMatriarch = base.transform.FindChild("HolderMatriarch");
        this.holderSwampThing = base.transform.FindChild("HolderSwampThing");
        this.holderTreant = base.transform.FindChild("HolderTreant");
        this.holderTroll = base.transform.FindChild("HolderTroll");
        this.holderTrollChampion = base.transform.FindChild("HolderTrollChampion");
        this.holderTrollChieftain = base.transform.FindChild("HolderTrollChieftain");
        this.holderVeznan = base.transform.FindChild("HolderVeznan");
        this.holderWinterWolf = base.transform.FindChild("HolderWinterWolf");
        this.holderWorg = base.transform.FindChild("HolderWorg");
        this.holderWorgRider = base.transform.FindChild("HolderWorgRider");
        this.holderWulf = base.transform.FindChild("HolderWulf");
        this.holderYeti = base.transform.FindChild("HolderYeti");
        this.holderTrollBrute = base.transform.FindChild("HolderTrollBrute");
        this.holderTrollSkater = base.transform.FindChild("HolderTrollSkater");
        this.holderTrollBoss = base.transform.FindChild("HolderTrollBoss");
        this.holderDemonLegion = base.transform.FindChild("HolderDemonLegion");
        this.holderFlareon = base.transform.FindChild("HolderFlareon");
        this.holderGulaemon = base.transform.FindChild("HolderGulaemon");
        this.holderCerberus = base.transform.FindChild("HolderCerberus");
        this.holderDemonMoloch = base.transform.FindChild("HolderDemonMoloch");
        this.holderRottenLesser = base.transform.FindChild("HolderRottenLesser");
        this.holderMyconid = base.transform.FindChild("HolderMyconid");
        return;
    }

    private void LoadThumbs()
    {
        Transform transform;
        transform = base.transform.FindChild("Thumbs");
        this.bandit = transform.FindChild("Bandit").GetComponent<EncyclopediaCreepItem>();
        this.brigand = transform.FindChild("Brigand").GetComponent<EncyclopediaCreepItem>();
        this.darkKnight = transform.FindChild("Dark Knight").GetComponent<EncyclopediaCreepItem>();
        this.darkKnightSlayer = transform.FindChild("Dark Knight Slayer").GetComponent<EncyclopediaCreepItem>();
        this.demon = transform.FindChild("Demon").GetComponent<EncyclopediaCreepItem>();
        this.demonImp = transform.FindChild("Demon Imp").GetComponent<EncyclopediaCreepItem>();
        this.demonMage = transform.FindChild("Demon Mage").GetComponent<EncyclopediaCreepItem>();
        this.demonWolf = transform.FindChild("Demon Wolf").GetComponent<EncyclopediaCreepItem>();
        this.fatOrc = transform.FindChild("Fat Orc").GetComponent<EncyclopediaCreepItem>();
        this.forestTroll = transform.FindChild("Forest Troll").GetComponent<EncyclopediaCreepItem>();
        this.gargoyle = transform.FindChild("Gargoyle").GetComponent<EncyclopediaCreepItem>();
        this.giantSpider = transform.FindChild("Giant Spider").GetComponent<EncyclopediaCreepItem>();
        this.goblin = transform.FindChild("Goblin").GetComponent<EncyclopediaCreepItem>();
        this.goblinZapper = transform.FindChild("Goblin Zapper").GetComponent<EncyclopediaCreepItem>();
        this.golemHead = transform.FindChild("Golem Head").GetComponent<EncyclopediaCreepItem>();
        this.greenmuck = transform.FindChild("Greenmuck").GetComponent<EncyclopediaCreepItem>();
        this.gulthak = transform.FindChild("Gulthak").GetComponent<EncyclopediaCreepItem>();
        this.husk = transform.FindChild("Husk").GetComponent<EncyclopediaCreepItem>();
        this.jt = transform.FindChild("JT").GetComponent<EncyclopediaCreepItem>();
        this.juggernaut = transform.FindChild("Juggernaut").GetComponent<EncyclopediaCreepItem>();
        this.kingpin = transform.FindChild("Kingpin").GetComponent<EncyclopediaCreepItem>();
        this.lavaElemental = transform.FindChild("Lava Elemental").GetComponent<EncyclopediaCreepItem>();
        this.marauder = transform.FindChild("Marauder").GetComponent<EncyclopediaCreepItem>();
        this.necromancer = transform.FindChild("Necromancer").GetComponent<EncyclopediaCreepItem>();
        this.noxiousCreeper = transform.FindChild("Noxious Creeper").GetComponent<EncyclopediaCreepItem>();
        this.ogre = transform.FindChild("Ogre").GetComponent<EncyclopediaCreepItem>();
        this.orcChampion = transform.FindChild("Orc Champion").GetComponent<EncyclopediaCreepItem>();
        this.pillager = transform.FindChild("Pillager").GetComponent<EncyclopediaCreepItem>();
        this.raider = transform.FindChild("Raider").GetComponent<EncyclopediaCreepItem>();
        this.rocketeer = transform.FindChild("Rocketeer").GetComponent<EncyclopediaCreepItem>();
        this.sarelgaz = transform.FindChild("Sarelgaz").GetComponent<EncyclopediaCreepItem>();
        this.shadowArcher = transform.FindChild("Shadow Archer").GetComponent<EncyclopediaCreepItem>();
        this.shaman = transform.FindChild("Shaman").GetComponent<EncyclopediaCreepItem>();
        this.skeleton = transform.FindChild("Skeleton").GetComponent<EncyclopediaCreepItem>();
        this.skeletonWarrior = transform.FindChild("Skeleton Warrior").GetComponent<EncyclopediaCreepItem>();
        this.sonOfSarelgaz = transform.transform.FindChild("Son of Sarelgaz").GetComponent<EncyclopediaCreepItem>();
        this.spiderMatriarch = transform.FindChild("Spider Matriarch").GetComponent<EncyclopediaCreepItem>();
        this.swampThing = transform.FindChild("Swamp Thing").GetComponent<EncyclopediaCreepItem>();
        this.treant = transform.FindChild("Treant").GetComponent<EncyclopediaCreepItem>();
        this.troll = transform.FindChild("Troll").GetComponent<EncyclopediaCreepItem>();
        this.trollChampion = transform.FindChild("Troll Champion").GetComponent<EncyclopediaCreepItem>();
        this.trollChieftain = transform.FindChild("Troll Chieftain").GetComponent<EncyclopediaCreepItem>();
        this.veznan = transform.FindChild("Veznan").GetComponent<EncyclopediaCreepItem>();
        this.winterWolf = transform.FindChild("Winter Wolf").GetComponent<EncyclopediaCreepItem>();
        this.worg = transform.FindChild("Worg").GetComponent<EncyclopediaCreepItem>();
        this.worgRider = transform.FindChild("Worg Rider").GetComponent<EncyclopediaCreepItem>();
        this.wulf = transform.FindChild("Wulf").GetComponent<EncyclopediaCreepItem>();
        this.yeti = transform.FindChild("Yeti").GetComponent<EncyclopediaCreepItem>();
        this.trollBrute = transform.FindChild("Troll Brute").GetComponent<EncyclopediaCreepItem>();
        this.trollSkater = transform.FindChild("Troll Skater").GetComponent<EncyclopediaCreepItem>();
        this.trollBoss = transform.FindChild("Troll Boss").GetComponent<EncyclopediaCreepItem>();
        this.demonLegion = transform.FindChild("Demon Legion").GetComponent<EncyclopediaCreepItem>();
        this.flareon = transform.FindChild("Flareon").GetComponent<EncyclopediaCreepItem>();
        this.gulaemon = transform.FindChild("Gulaemon").GetComponent<EncyclopediaCreepItem>();
        this.cerberus = transform.FindChild("Cerberus").GetComponent<EncyclopediaCreepItem>();
        this.demonMoloch = transform.FindChild("Demon Moloch").GetComponent<EncyclopediaCreepItem>();
        return;
    }

    public void Open()
    {
        this.Select("Goblin");
        this.RefreshLocks();
        this.SetPage(1);
        this.buttonPage1.SetSelected();
        return;
    }

    public void RefreshLocks()
    {
        this.bandit.CheckLock();
        this.brigand.CheckLock();
        this.darkKnight.CheckLock();
        this.darkKnightSlayer.CheckLock();
        this.demon.CheckLock();
        this.demonImp.CheckLock();
        this.demonMage.CheckLock();
        this.demonWolf.CheckLock();
        this.fatOrc.CheckLock();
        this.forestTroll.CheckLock();
        this.gargoyle.CheckLock();
        this.giantSpider.CheckLock();
        this.goblin.CheckLock();
        this.goblinZapper.CheckLock();
        this.golemHead.CheckLock();
        this.greenmuck.CheckLock();
        this.gulthak.CheckLock();
        this.husk.CheckLock();
        this.jt.CheckLock();
        this.juggernaut.CheckLock();
        this.kingpin.CheckLock();
        this.lavaElemental.CheckLock();
        this.marauder.CheckLock();
        this.necromancer.CheckLock();
        this.noxiousCreeper.CheckLock();
        this.ogre.CheckLock();
        this.orcChampion.CheckLock();
        this.pillager.CheckLock();
        this.raider.CheckLock();
        this.rocketeer.CheckLock();
        this.sarelgaz.CheckLock();
        this.shadowArcher.CheckLock();
        this.shaman.CheckLock();
        this.skeleton.CheckLock();
        this.skeletonWarrior.CheckLock();
        this.sonOfSarelgaz.CheckLock();
        this.spiderMatriarch.CheckLock();
        this.swampThing.CheckLock();
        this.treant.CheckLock();
        this.troll.CheckLock();
        this.trollChampion.CheckLock();
        this.trollChieftain.CheckLock();
        this.veznan.CheckLock();
        this.winterWolf.CheckLock();
        this.worg.CheckLock();
        this.worgRider.CheckLock();
        this.wulf.CheckLock();
        this.yeti.CheckLock();
        this.trollBoss.CheckLock();
        this.trollBrute.CheckLock();
        this.trollSkater.CheckLock();
        this.demonLegion.CheckLock();
        this.flareon.CheckLock();
        this.gulaemon.CheckLock();
        this.cerberus.CheckLock();
        this.demonMoloch.CheckLock();
        return;
    }

    private void Reset()
    {
        this.holderBandit.gameObject.SetActive(0);
        this.holderBrigand.gameObject.SetActive(0);
        this.holderDarkKnight.gameObject.SetActive(0);
        this.holderDarkKnightSlayer.gameObject.SetActive(0);
        this.holderDemon.gameObject.SetActive(0);
        this.holderDemonImp.gameObject.SetActive(0);
        this.holderDemonMage.gameObject.SetActive(0);
        this.holderDemonWolf.gameObject.SetActive(0);
        this.holderFatOrc.gameObject.SetActive(0);
        this.holderForestTroll.gameObject.SetActive(0);
        this.holderGargoyle.gameObject.SetActive(0);
        this.holderGiantSpider.gameObject.SetActive(0);
        this.holderGoblin.gameObject.SetActive(0);
        this.holderGoblinZapper.gameObject.SetActive(0);
        this.holderGolemHead.gameObject.SetActive(0);
        this.holderGreenmuck.gameObject.SetActive(0);
        this.holderGulthak.gameObject.SetActive(0);
        this.holderHusk.gameObject.SetActive(0);
        this.holderJt.gameObject.SetActive(0);
        this.holderJuggernaut.gameObject.SetActive(0);
        this.holderKingpin.gameObject.SetActive(0);
        this.holderLavaElemental.gameObject.SetActive(0);
        this.holderMarauder.gameObject.SetActive(0);
        this.holderNecromancer.gameObject.SetActive(0);
        this.holderNoxiousCreeper.gameObject.SetActive(0);
        this.holderOgre.gameObject.SetActive(0);
        this.holderOrcChampion.gameObject.SetActive(0);
        this.holderPillager.gameObject.SetActive(0);
        this.holderRaider.gameObject.SetActive(0);
        this.holderRocketeer.gameObject.SetActive(0);
        this.holderSarelgaz.gameObject.SetActive(0);
        this.holderShadowArcher.gameObject.SetActive(0);
        this.holderShaman.gameObject.SetActive(0);
        this.holderSkeleton.gameObject.SetActive(0);
        this.holderSkeletonWarrior.gameObject.SetActive(0);
        this.holderSonOfSarelgaz.gameObject.SetActive(0);
        this.holderSpiderMatriarch.gameObject.SetActive(0);
        this.holderSwampThing.gameObject.SetActive(0);
        this.holderTreant.gameObject.SetActive(0);
        this.holderTroll.gameObject.SetActive(0);
        this.holderTrollChampion.gameObject.SetActive(0);
        this.holderTrollChieftain.gameObject.SetActive(0);
        this.holderVeznan.gameObject.SetActive(0);
        this.holderWinterWolf.gameObject.SetActive(0);
        this.holderWorg.gameObject.SetActive(0);
        this.holderWorgRider.gameObject.SetActive(0);
        this.holderWulf.gameObject.SetActive(0);
        this.holderYeti.gameObject.SetActive(0);
        this.holderTrollSkater.gameObject.SetActive(0);
        this.holderTrollBrute.gameObject.SetActive(0);
        this.holderTrollBoss.gameObject.SetActive(0);
        this.holderDemonLegion.gameObject.SetActive(0);
        this.holderFlareon.gameObject.SetActive(0);
        this.holderGulaemon.gameObject.SetActive(0);
        this.holderCerberus.gameObject.SetActive(0);
        this.holderDemonMoloch.gameObject.SetActive(0);
        this.holderRottenLesser.gameObject.SetActive(0);
        this.holderMyconid.gameObject.SetActive(0);
        this.footer.gameObject.SetActive(0);
        return;
    }

    private void ResetItems()
    {
        this.bandit.Deselect();
        this.brigand.Deselect();
        this.darkKnight.Deselect();
        this.darkKnightSlayer.Deselect();
        this.demon.Deselect();
        this.demonImp.Deselect();
        this.demonMage.Deselect();
        this.demonWolf.Deselect();
        this.fatOrc.Deselect();
        this.forestTroll.Deselect();
        this.gargoyle.Deselect();
        this.giantSpider.Deselect();
        this.goblin.Deselect();
        this.goblinZapper.Deselect();
        this.golemHead.Deselect();
        this.greenmuck.Deselect();
        this.gulthak.Deselect();
        this.husk.Deselect();
        this.jt.Deselect();
        this.juggernaut.Deselect();
        this.kingpin.Deselect();
        this.lavaElemental.Deselect();
        this.marauder.Deselect();
        this.necromancer.Deselect();
        this.noxiousCreeper.Deselect();
        this.ogre.Deselect();
        this.orcChampion.Deselect();
        this.pillager.Deselect();
        this.raider.Deselect();
        this.rocketeer.Deselect();
        this.sarelgaz.Deselect();
        this.shadowArcher.Deselect();
        this.shaman.Deselect();
        this.skeleton.Deselect();
        this.skeletonWarrior.Deselect();
        this.sonOfSarelgaz.Deselect();
        this.spiderMatriarch.Deselect();
        this.swampThing.Deselect();
        this.treant.Deselect();
        this.troll.Deselect();
        this.trollChampion.Deselect();
        this.trollChieftain.Deselect();
        this.veznan.Deselect();
        this.winterWolf.Deselect();
        this.worg.Deselect();
        this.worgRider.Deselect();
        this.wulf.Deselect();
        this.yeti.Deselect();
        this.trollBrute.Deselect();
        this.trollSkater.Deselect();
        this.trollBoss.Deselect();
        this.demonLegion.Deselect();
        this.flareon.Deselect();
        this.gulaemon.Deselect();
        this.cerberus.Deselect();
        this.demonMoloch.Deselect();
        return;
    }

    public unsafe void Select(string item)
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        this.Reset();
        this.ResetItems();
        str = item;
        if (str == null)
        {
            goto Label_0B81;
        }
        if (<>f__switch$map8 != null)
        {
            goto Label_02FB;
        }
        dictionary = new Dictionary<string, int>(0x38);
        dictionary.Add("Bandit", 0);
        dictionary.Add("Brigand", 1);
        dictionary.Add("Dark Knight", 2);
        dictionary.Add("Dark Knight Slayer", 3);
        dictionary.Add("Demon", 4);
        dictionary.Add("Demon Imp", 5);
        dictionary.Add("Demon Mage", 6);
        dictionary.Add("Demon Wolf", 7);
        dictionary.Add("Fat Orc", 8);
        dictionary.Add("Forest Troll", 9);
        dictionary.Add("Gargoyle", 10);
        dictionary.Add("Giant Spider", 11);
        dictionary.Add("Goblin", 12);
        dictionary.Add("Goblin Zapper", 13);
        dictionary.Add("Golem Head", 14);
        dictionary.Add("Greenmuck", 15);
        dictionary.Add("Gulthak", 0x10);
        dictionary.Add("Husk", 0x11);
        dictionary.Add("JT", 0x12);
        dictionary.Add("Juggernaut", 0x13);
        dictionary.Add("Kingpin", 20);
        dictionary.Add("Lava Elemental", 0x15);
        dictionary.Add("Marauder", 0x16);
        dictionary.Add("Necromancer", 0x17);
        dictionary.Add("Noxious Creeper", 0x18);
        dictionary.Add("Ogre", 0x19);
        dictionary.Add("Orc Champion", 0x1a);
        dictionary.Add("Pillager", 0x1b);
        dictionary.Add("Raider", 0x1c);
        dictionary.Add("Rocketeer", 0x1d);
        dictionary.Add("Sarelgaz", 30);
        dictionary.Add("Shadow Archer", 0x1f);
        dictionary.Add("Shaman", 0x20);
        dictionary.Add("Skeleton", 0x21);
        dictionary.Add("Skeleton Warrior", 0x22);
        dictionary.Add("Son of Sarelgaz", 0x23);
        dictionary.Add("Spider Matriarch", 0x24);
        dictionary.Add("Swamp Thing", 0x25);
        dictionary.Add("Treant", 0x26);
        dictionary.Add("Troll", 0x27);
        dictionary.Add("Troll Champion", 40);
        dictionary.Add("Troll Chieftain", 0x29);
        dictionary.Add("Veznan", 0x2a);
        dictionary.Add("Winter Wolf", 0x2b);
        dictionary.Add("Worg", 0x2c);
        dictionary.Add("Worg Rider", 0x2d);
        dictionary.Add("Wulf", 0x2e);
        dictionary.Add("Yeti", 0x2f);
        dictionary.Add("Troll Brute", 0x30);
        dictionary.Add("Troll Skater", 0x31);
        dictionary.Add("Troll Boss", 50);
        dictionary.Add("Demon Legion", 0x33);
        dictionary.Add("Flareon", 0x34);
        dictionary.Add("Gulaemon", 0x35);
        dictionary.Add("Cerberus", 0x36);
        dictionary.Add("Demon Moloch", 0x37);
        <>f__switch$map8 = dictionary;
    Label_02FB:
        if (<>f__switch$map8.TryGetValue(str, &num) == null)
        {
            goto Label_0B81;
        }
        switch (num)
        {
            case 0:
                goto Label_03F8;

            case 1:
                goto Label_041F;

            case 2:
                goto Label_0435;

            case 3:
                goto Label_044B;

            case 4:
                goto Label_0461;

            case 5:
                goto Label_0488;

            case 6:
                goto Label_04AF;

            case 7:
                goto Label_04D6;

            case 8:
                goto Label_04FD;

            case 9:
                goto Label_0513;

            case 10:
                goto Label_053A;

            case 11:
                goto Label_0561;

            case 12:
                goto Label_0577;

            case 13:
                goto Label_058D;

            case 14:
                goto Label_05B4;

            case 15:
                goto Label_05CA;

            case 0x10:
                goto Label_05F1;

            case 0x11:
                goto Label_0618;

            case 0x12:
                goto Label_062E;

            case 0x13:
                goto Label_0655;

            case 20:
                goto Label_067C;

            case 0x15:
                goto Label_06A3;

            case 0x16:
                goto Label_06CA;

            case 0x17:
                goto Label_06E0;

            case 0x18:
                goto Label_0707;

            case 0x19:
                goto Label_072E;

            case 0x1a:
                goto Label_0744;

            case 0x1b:
                goto Label_075A;

            case 0x1c:
                goto Label_0781;

            case 0x1d:
                goto Label_07A8;

            case 30:
                goto Label_07CF;

            case 0x1f:
                goto Label_07F6;

            case 0x20:
                goto Label_081D;

            case 0x21:
                goto Label_0844;

            case 0x22:
                goto Label_085A;

            case 0x23:
                goto Label_0870;

            case 0x24:
                goto Label_0886;

            case 0x25:
                goto Label_08AD;

            case 0x26:
                goto Label_08D4;

            case 0x27:
                goto Label_08EA;

            case 40:
                goto Label_0911;

            case 0x29:
                goto Label_0938;

            case 0x2a:
                goto Label_095F;

            case 0x2b:
                goto Label_0986;

            case 0x2c:
                goto Label_09AD;

            case 0x2d:
                goto Label_09D4;

            case 0x2e:
                goto Label_09FB;

            case 0x2f:
                goto Label_0A22;

            case 0x30:
                goto Label_0A49;

            case 0x31:
                goto Label_0A70;

            case 50:
                goto Label_0A97;

            case 0x33:
                goto Label_0ABE;

            case 0x34:
                goto Label_0AE5;

            case 0x35:
                goto Label_0B0C;

            case 0x36:
                goto Label_0B33;

            case 0x37:
                goto Label_0B5A;
        }
        goto Label_0B81;
    Label_03F8:
        this.holderBandit.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_041F:
        this.holderBrigand.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0435:
        this.holderDarkKnight.gameObject.SetActive(1);
        goto Label_0B81;
    Label_044B:
        this.holderDarkKnightSlayer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0461:
        this.holderDemon.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0488:
        this.holderDemonImp.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_04AF:
        this.holderDemonMage.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_04D6:
        this.holderDemonWolf.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_04FD:
        this.holderFatOrc.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0513:
        this.holderForestTroll.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_053A:
        this.holderGargoyle.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0561:
        this.holderGiantSpider.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0577:
        this.holderGoblin.gameObject.SetActive(1);
        goto Label_0B81;
    Label_058D:
        this.holderGoblinZapper.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_05B4:
        this.holderGolemHead.gameObject.SetActive(1);
        goto Label_0B81;
    Label_05CA:
        this.holderGreenmuck.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_05F1:
        this.holderGulthak.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0618:
        this.holderHusk.gameObject.SetActive(1);
        goto Label_0B81;
    Label_062E:
        this.holderJt.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0655:
        this.holderJuggernaut.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_067C:
        this.holderKingpin.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_06A3:
        this.holderLavaElemental.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_06CA:
        this.holderMarauder.gameObject.SetActive(1);
        goto Label_0B81;
    Label_06E0:
        this.holderNecromancer.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0707:
        this.holderNoxiousCreeper.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_072E:
        this.holderOgre.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0744:
        this.holderOrcChampion.gameObject.SetActive(1);
        goto Label_0B81;
    Label_075A:
        this.holderPillager.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0781:
        this.holderRaider.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_07A8:
        this.holderRocketeer.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_07CF:
        this.holderSarelgaz.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_07F6:
        this.holderShadowArcher.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_081D:
        this.holderShaman.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0844:
        this.holderSkeleton.gameObject.SetActive(1);
        goto Label_0B81;
    Label_085A:
        this.holderSkeletonWarrior.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0870:
        this.holderSonOfSarelgaz.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0886:
        this.holderSpiderMatriarch.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_08AD:
        this.holderSwampThing.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_08D4:
        this.holderTreant.gameObject.SetActive(1);
        goto Label_0B81;
    Label_08EA:
        this.holderTroll.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0911:
        this.holderTrollChampion.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0938:
        this.holderTrollChieftain.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_095F:
        this.holderVeznan.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0986:
        this.holderWinterWolf.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_09AD:
        this.holderWorg.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_09D4:
        this.holderWorgRider.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_09FB:
        this.holderWulf.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0A22:
        this.holderYeti.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0A49:
        this.holderTrollBrute.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0A70:
        this.holderTrollSkater.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0A97:
        this.holderTrollBoss.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0ABE:
        this.holderDemonLegion.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0AE5:
        this.holderFlareon.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0B0C:
        this.holderGulaemon.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0B33:
        this.holderCerberus.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
        goto Label_0B81;
    Label_0B5A:
        this.holderDemonMoloch.gameObject.SetActive(1);
        this.footer.gameObject.SetActive(1);
    Label_0B81:
        return;
    }

    public void SetPage(int num)
    {
        this.containerPage1.gameObject.SetActive(0);
        this.containerPage2.gameObject.SetActive(0);
        this.buttonPage1.Reset();
        this.buttonPage2.Reset();
        this.currentPage = num;
        if (num != 1)
        {
            goto Label_0067;
        }
        this.containerPage1.gameObject.SetActive(1);
        this.goblin.Select();
        goto Label_0085;
    Label_0067:
        if (num != 2)
        {
            goto Label_0085;
        }
        this.containerPage2.gameObject.SetActive(1);
        this.RefreshLocks();
    Label_0085:
        return;
    }

    private void Start()
    {
        this.footer = base.transform.FindChild("Footer");
        this.currentPage = 1;
        this.buttonPage1 = base.transform.FindChild("ButtonPage1").GetComponent<EncyclopediaCreepPageButton>();
        this.buttonPage2 = base.transform.FindChild("ButtonPage2").GetComponent<EncyclopediaCreepPageButton>();
        this.LoadThumbs();
        this.LoadHolders();
        this.InitPositions();
        this.InitPages();
        return;
    }
}

