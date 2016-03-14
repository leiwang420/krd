using System;
using UnityEngine;

public class NotificationTipEnemy : MonoBehaviour
{
    private NotificationIcon icon;
    private bool isDisplayed;
    private Transform portraitBandit;
    private Transform portraitBrigand;
    private Transform portraitCerberus;
    private Transform portraitDarkKnight;
    private Transform portraitDarkSlayer;
    private Transform portraitDemon;
    private Transform portraitDemonImp;
    private Transform portraitDemonMage;
    private Transform portraitDemonWolf;
    private Transform portraitFatOrc;
    private Transform portraitFlareon;
    private Transform portraitForestTroll;
    private Transform portraitGargoyle;
    private Transform portraitGiantSpider;
    private Transform portraitGoblin;
    private Transform portraitGoblinZapper;
    private Transform portraitGolemHead;
    private Transform portraitGulaemon;
    private Transform portraitGulthak;
    private Transform portraitHusk;
    private Transform portraitJT;
    private Transform portraitJuggernaut;
    private Transform portraitLavaElemental;
    private Transform portraitLegion;
    private Transform portraitMarauder;
    private Transform portraitNecromancer;
    private Transform portraitOgre;
    private Transform portraitOrcArmored;
    private Transform portraitOrcRider;
    private Transform portraitPillager;
    private Transform portraitRaider;
    private Transform portraitRocketeer;
    private Transform portraitRottenBoss;
    private Transform portraitRottenLesser;
    private Transform portraitSarelgaz;
    private Transform portraitShadowArcher;
    private Transform portraitShaman;
    private Transform portraitSkeleton;
    private Transform portraitSkeletonWarrior;
    private Transform portraitSonOfSarelgaz;
    private Transform portraitSpider;
    private Transform portraitSpiderRotten;
    private Transform portraitSwampThing;
    private Transform portraitTreant;
    private Transform portraitTroll;
    private Transform portraitTrollAxe;
    private Transform portraitTrollBrute;
    private Transform portraitTrollChieftain;
    private Transform portraitTrollSkater;
    private Transform portraitVeznan;
    private Transform portraitWinterWolf;
    private Transform portraitWorg;
    private Transform portraitWulf;
    private Transform portraitYeti;
    private StageBase stage;
    private TextMesh textDescription;
    private TextMesh textExtra;
    private TextMesh textTitle;
    private Constants.notificationType type;

    public NotificationTipEnemy()
    {
        base..ctor();
        return;
    }

    private void Deactivate()
    {
        if (this.type != null)
        {
            goto Label_001B;
        }
        ((Stage1) this.stage).HideBalloonNotification();
    Label_001B:
        this.isDisplayed = 0;
        this.stage.UnPause(1);
        base.gameObject.SetActive(0);
        return;
    }

    public void Hide()
    {
        object[] objArray1;
        GameSoundManager.Unpause();
        GameSoundManager.PlayGUINotificationClose();
        this.icon.Hide();
        objArray1 = new object[] { "x", (float) 0.5f, "y", (float) 0.5f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1a, "oncomplete", "Deactivate" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        return;
    }

    private void HideAll()
    {
        this.portraitGoblin.gameObject.SetActive(0);
        this.portraitFatOrc.gameObject.SetActive(0);
        this.portraitWulf.gameObject.SetActive(0);
        this.portraitShaman.gameObject.SetActive(0);
        this.portraitOgre.gameObject.SetActive(0);
        this.portraitBandit.gameObject.SetActive(0);
        this.portraitBrigand.gameObject.SetActive(0);
        this.portraitDarkKnight.gameObject.SetActive(0);
        this.portraitMarauder.gameObject.SetActive(0);
        this.portraitGiantSpider.gameObject.SetActive(0);
        this.portraitSpider.gameObject.SetActive(0);
        this.portraitShadowArcher.gameObject.SetActive(0);
        this.portraitGargoyle.gameObject.SetActive(0);
        this.portraitWorg.gameObject.SetActive(0);
        this.portraitTroll.gameObject.SetActive(0);
        this.portraitTrollAxe.gameObject.SetActive(0);
        this.portraitTrollChieftain.gameObject.SetActive(0);
        this.portraitWinterWolf.gameObject.SetActive(0);
        this.portraitDarkSlayer.gameObject.SetActive(0);
        this.portraitYeti.gameObject.SetActive(0);
        this.portraitRocketeer.gameObject.SetActive(0);
        this.portraitDemon.gameObject.SetActive(0);
        this.portraitDemonMage.gameObject.SetActive(0);
        this.portraitDemonImp.gameObject.SetActive(0);
        this.portraitDemonWolf.gameObject.SetActive(0);
        this.portraitNecromancer.gameObject.SetActive(0);
        this.portraitLavaElemental.gameObject.SetActive(0);
        this.portraitSonOfSarelgaz.gameObject.SetActive(0);
        this.portraitGoblinZapper.gameObject.SetActive(0);
        this.portraitOrcRider.gameObject.SetActive(0);
        this.portraitOrcArmored.gameObject.SetActive(0);
        this.portraitForestTroll.gameObject.SetActive(0);
        this.portraitHusk.gameObject.SetActive(0);
        this.portraitSpiderRotten.gameObject.SetActive(0);
        this.portraitTreant.gameObject.SetActive(0);
        this.portraitSwampThing.gameObject.SetActive(0);
        this.portraitRaider.gameObject.SetActive(0);
        this.portraitPillager.gameObject.SetActive(0);
        this.portraitTrollSkater.gameObject.SetActive(0);
        this.portraitTrollBrute.gameObject.SetActive(0);
        this.portraitCerberus.gameObject.SetActive(0);
        this.portraitLegion.gameObject.SetActive(0);
        this.portraitFlareon.gameObject.SetActive(0);
        this.portraitGulaemon.gameObject.SetActive(0);
        this.portraitRottenLesser.gameObject.SetActive(0);
        return;
    }

    public bool IsDisplayed()
    {
        return this.isDisplayed;
    }

    private void PopIn()
    {
        object[] objArray1;
        GameSoundManager.PlayGUINotificationOpen();
        base.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        objArray1 = new object[] { "x", (float) 1f, "y", (float) 1f, "time", (float) 0.5f, "easetype", (iTween.EaseType) 0x1b };
        iTween.ScaleTo(base.gameObject, iTween.Hash(objArray1));
        this.isDisplayed = 1;
        return;
    }

    public void Setup(Constants.notificationType type, NotificationIcon icon)
    {
        Constants.notificationType type2;
        GameAchievements.ViewNotification();
        base.gameObject.SetActive(1);
        this.HideAll();
        this.icon = icon;
        this.type = type;
        type2 = type;
        switch (type2)
        {
            case 0:
                goto Label_012E;

            case 1:
                goto Label_0174;

            case 2:
                goto Label_0D7C;

            case 3:
                goto Label_0D7C;

            case 4:
                goto Label_0D7C;

            case 5:
                goto Label_0D7C;

            case 6:
                goto Label_0D7C;

            case 7:
                goto Label_0D7C;

            case 8:
                goto Label_0D7C;

            case 9:
                goto Label_01BA;

            case 10:
                goto Label_0200;

            case 11:
                goto Label_0246;

            case 12:
                goto Label_0D7C;

            case 13:
                goto Label_0D7C;

            case 14:
                goto Label_0D7C;

            case 15:
                goto Label_0D7C;

            case 0x10:
                goto Label_028C;

            case 0x11:
                goto Label_02D2;

            case 0x12:
                goto Label_0318;

            case 0x13:
                goto Label_035E;

            case 20:
                goto Label_03A4;

            case 0x15:
                goto Label_03EA;

            case 0x16:
                goto Label_0430;

            case 0x17:
                goto Label_0476;

            case 0x18:
                goto Label_04BC;

            case 0x19:
                goto Label_0D7C;

            case 0x1a:
                goto Label_0D7C;

            case 0x1b:
                goto Label_0D7C;

            case 0x1c:
                goto Label_0D7C;

            case 0x1d:
                goto Label_0502;

            case 30:
                goto Label_058E;

            case 0x1f:
                goto Label_0548;

            case 0x20:
                goto Label_05D4;

            case 0x21:
                goto Label_061A;

            case 0x22:
                goto Label_0660;

            case 0x23:
                goto Label_06A6;

            case 0x24:
                goto Label_06EC;

            case 0x25:
                goto Label_0732;

            case 0x26:
                goto Label_0778;

            case 0x27:
                goto Label_07BE;

            case 40:
                goto Label_0804;

            case 0x29:
                goto Label_084A;

            case 0x2a:
                goto Label_0890;

            case 0x2b:
                goto Label_08D6;

            case 0x2c:
                goto Label_091C;

            case 0x2d:
                goto Label_0962;

            case 0x2e:
                goto Label_09A8;

            case 0x2f:
                goto Label_09EE;

            case 0x30:
                goto Label_0A34;

            case 0x31:
                goto Label_0D7C;

            case 50:
                goto Label_0A7A;

            case 0x33:
                goto Label_0AC0;

            case 0x34:
                goto Label_0D7C;

            case 0x35:
                goto Label_0B06;

            case 0x36:
                goto Label_0B4C;

            case 0x37:
                goto Label_0D7C;

            case 0x38:
                goto Label_0B92;

            case 0x39:
                goto Label_0BD8;

            case 0x3a:
                goto Label_0C1E;

            case 0x3b:
                goto Label_0C64;

            case 60:
                goto Label_0CAA;

            case 0x3d:
                goto Label_0CF0;

            case 0x3e:
                goto Label_0D36;
        }
        goto Label_0D7C;
    Label_012E:
        this.portraitGoblin.gameObject.SetActive(1);
        this.textTitle.text = "Goblin";
        this.textDescription.text = "Small evil humanoids with no\noutstanding abilities.";
        this.textExtra.text = "* LOW HEALTH\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_0174:
        this.portraitFatOrc.gameObject.SetActive(1);
        this.textTitle.text = "Orc";
        this.textDescription.text = "Tough savages with light armor.";
        this.textExtra.text = "* LIGHT ARMOR\n* SLOW SPEED";
        goto Label_0D81;
    Label_01BA:
        this.portraitWulf.gameObject.SetActive(1);
        this.textTitle.text = "Wulf";
        this.textDescription.text = "Very fast vicious creatures that\ncan dodge melee attacks.";
        this.textExtra.text = "* CAN DODGE MELEE ATTACKS\n* LOW HEALTH\n* VERY FAST SPEED";
        goto Label_0D81;
    Label_0200:
        this.portraitShaman.gameObject.SetActive(1);
        this.textTitle.text = "Shaman";
        this.textDescription.text = "Tribal healers resistant to\nmagic attacks.";
        this.textExtra.text = "* HIGH MAGIC RESISTANCE\n* CAN HEAL ALLIES\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_0246:
        this.portraitOgre.gameObject.SetActive(1);
        this.textTitle.text = "Ogre";
        this.textDescription.text = "Big, ugly and tough humanoids,\nthey'll obliterate everything\nin their path.";
        this.textExtra.text = "* VERY HIGH HEALTH\n* VERY SLOW SPEED\n* COST 3 LIVES";
        goto Label_0D81;
    Label_028C:
        this.portraitBandit.gameObject.SetActive(1);
        this.textTitle.text = "Bandit";
        this.textDescription.text = "Swift & agile, they can dispatch\ntheir enemies very quickly.";
        this.textExtra.text = "* FAST SPEED\n* VERY HIGH DAMAGE\n* CAN DODGE MELEE ATTACKS";
        goto Label_0D81;
    Label_02D2:
        this.portraitBrigand.gameObject.SetActive(1);
        this.textTitle.text = "Brigand";
        this.textDescription.text = "Armored outlaws that can\nwithstand a lot of punishment.";
        this.textExtra.text = "* AVERAGE SPEED\n* MEDIUM ARMOR";
        goto Label_0D81;
    Label_0318:
        this.portraitDarkKnight.gameObject.SetActive(1);
        this.textTitle.text = "Dark Knight";
        this.textDescription.text = "Fully plated, corrupted knights,\nalmost impervious to damage.";
        this.textExtra.text = "* SLOW SPEED\n* HEAVY ARMOR";
        goto Label_0D81;
    Label_035E:
        this.portraitMarauder.gameObject.SetActive(1);
        this.textTitle.text = "Marauder";
        this.textDescription.text = "Hulking, well-trained armored\noutlaws, often seen leading\nbrigands and bandits.";
        this.textExtra.text = "* SLOW SPEED\n* MEDIUM ARMOR\n* COST 3 LIVES";
        goto Label_0D81;
    Label_03A4:
        this.portraitGiantSpider.gameObject.SetActive(1);
        this.textTitle.text = "Matriarch";
        this.textDescription.text = "Tough magic resistant beast that\ncan spawn several spiderlings.";
        this.textExtra.text = "* HIGH MAGIC RESISTANCE\n* SPAWNS SPIDERLINGS\n* COST 2 LIVES\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_03EA:
        this.portraitSpider.gameObject.SetActive(1);
        this.textTitle.text = "Giant Spider";
        this.textDescription.text = "Quick, vicious enemies resistant\nto magic.";
        this.textExtra.text = "* HIGH MAGIC RESISTANCE\n* LOW HEALTH\n* FAST SPEED";
        goto Label_0D81;
    Label_0430:
        this.portraitShadowArcher.gameObject.SetActive(1);
        this.textTitle.text = "Shadow Archer";
        this.textDescription.text = "Deadly accurate archers that\nwill shoot at nearby soldiers in\ntheir path.";
        this.textExtra.text = "* RANGED ATTACK\n* LOW MAGIC RESISTANCE\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_0476:
        this.portraitGargoyle.gameObject.SetActive(1);
        this.textTitle.text = "Gargoyle";
        this.textDescription.text = "Vile winged creatures that can\nfly past barracks and artillery.";
        this.textExtra.text = "* FLYING\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_04BC:
        this.portraitWorg.gameObject.SetActive(1);
        this.textTitle.text = "Worg";
        this.textDescription.text = "Cunning fast beasts that can\ndodge melee attacks and resist\nmagic attacks.";
        this.textExtra.text = "* MAGIC RESISTANCE\n* CAN DODGE MELEE ATTACKS\n* VERY FAST SPEEDS";
        goto Label_0D81;
    Label_0502:
        this.portraitTroll.gameObject.SetActive(1);
        this.textTitle.text = "Troll";
        this.textDescription.text = "Very tough warriors that can\nregenerate their wounds\nquickly.";
        this.textExtra.text = "* VERY HIGH DAMAGE\n* HEALTH REGENERATION\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_0548:
        this.portraitTrollChieftain.gameObject.SetActive(1);
        this.textTitle.text = "Troll Chieftain";
        this.textDescription.text = "The chieftain can enrage his\nbrethren, improving their\ncombat abilities!";
        this.textExtra.text = "* HIGH HEALTH REGENERATION\n* CAN ENRAGE OTHER TROLLS\n* VERY SLOW SPEED\n* COSTS 6 LIVES";
        goto Label_0D81;
    Label_058E:
        this.portraitTrollAxe.gameObject.SetActive(1);
        this.textTitle.text = "Troll Champion";
        this.textDescription.text = "Elite tribal warriors equipped\nwith vicious throwing axes that\npierce through armor.";
        this.textExtra.text = "* RANGED ATTACK\n* HEALTH REGENERATION\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_05D4:
        this.portraitWinterWolf.gameObject.SetActive(1);
        this.textTitle.text = "Winter Wolf";
        this.textDescription.text = "Cunning & deadly, these beasts\ncan defeat all but the best\nwarriors.";
        this.textExtra.text = "* MAGIC RESISTANCE\n* CAN DODGE MELEE ATTACKS\n* VERY FAST SPEED";
        goto Label_0D81;
    Label_061A:
        this.portraitDarkSlayer.gameObject.SetActive(1);
        this.textTitle.text = "Dark Slayer";
        this.textDescription.text = "Claimed by darkness; slayers\nare the bane of anyone standing\nin their way.";
        this.textExtra.text = "* VERY TOUGH\n* SLOW SPEED\n* GREAT ARMOR";
        goto Label_0D81;
    Label_0660:
        this.portraitYeti.gameObject.SetActive(1);
        this.textTitle.text = "Yeti";
        this.textDescription.text = "Large ape-man like creature\nthat can obliterate scores of\nsoldiers with one strike.";
        this.textExtra.text = "* VERY HIGH HEALTH\n* VERY SLOW SPEED\n* COST 5 LIVES\n* AREA ATTACK";
        goto Label_0D81;
    Label_06A6:
        this.portraitRocketeer.gameObject.SetActive(1);
        this.textTitle.text = "Rocket Rider";
        this.textDescription.text = "The rocket riders follow their\ndark lord's will wherever they\ngo.";
        this.textExtra.text = "* FLYING\n* AVERAGE SPEED\n* CAN USE TURBO";
        goto Label_0D81;
    Label_06EC:
        this.portraitDemon.gameObject.SetActive(1);
        this.textTitle.text = "Demon Spawn";
        this.textDescription.text = "Terrible infernal creatures\nthat explode when they die,\ndamaging nearby soldiers.";
        this.textExtra.text = "* MAGIC RESISTANCE\n* INFERNAL COMBUSTION";
        goto Label_0D81;
    Label_0732:
        this.portraitDemonMage.gameObject.SetActive(1);
        this.textTitle.text = "Demon Lord";
        this.textDescription.text = "They lead the fiendish armies\ninto battle, protecting their\nminions with infernal shields.";
        this.textExtra.text = "* SHIELDS OTHER DEMONS\n* MAGIC RESISTANCE\n* INFERNAL COMBUSTION";
        goto Label_0D81;
    Label_0778:
        this.portraitDemonImp.gameObject.SetActive(1);
        this.textTitle.text = "Demon Imp";
        this.textDescription.text = "Flying mischievious infernal\ncreatures that are often seen\nin the company of gargoyles.";
        this.textExtra.text = "* FLYING\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_07BE:
        this.portraitDemonWolf.gameObject.SetActive(1);
        this.textTitle.text = "Demon Hound";
        this.textDescription.text = "Vicious terrible creatures, they\nserve as hunting dogs for the\ndemon lords.";
        this.textExtra.text = "* MAGIC RESISTANCE\n* INFERNAL COMBUSTION\n* FAST SPEED";
        goto Label_0D81;
    Label_0804:
        this.portraitNecromancer.gameObject.SetActive(1);
        this.textTitle.text = "Necromancer";
        this.textDescription.text = "Master of the dark arts, the\nNecromancer summons undead\nminions to do their bidding.";
        this.textExtra.text = "* SUMMONS UNDEAD\n* RANGED ATTACK\n* SLOW SPEED";
        goto Label_0D81;
    Label_084A:
        this.portraitLavaElemental.gameObject.SetActive(1);
        this.textTitle.text = "Magma Elemental";
        this.textDescription.text = "Made of rock and fire, magma\nelementals are beings of death\nand destruction.";
        this.textExtra.text = "* VERY HIGH HEALTH\n* VERY SLOW SPEED\n* COST 5 LIVES\n* AREA ATTACK";
        goto Label_0D81;
    Label_0890:
        this.portraitSonOfSarelgaz.gameObject.SetActive(1);
        this.textTitle.text = "Son of Sarelgaz";
        this.textDescription.text = "The sons of the spider queen\nare formidable opponents and\nserve as her guardians.";
        this.textExtra.text = "* HIGH MAGIC RESISTANCE\n* HEAVY ARMOR";
        goto Label_0D81;
    Label_08D6:
        this.portraitGoblinZapper.gameObject.SetActive(1);
        this.textTitle.text = "Goblin Zapper";
        this.textDescription.text = "Hardened and fearless goblins\nthat run into battle tossing\nbombs at their enemies.";
        this.textExtra.text = "* AVERAGE SPEED\n* THROWS BOMBS\n* EXPLODES ON DEATH";
        goto Label_0D81;
    Label_091C:
        this.portraitOrcRider.gameObject.SetActive(1);
        this.textTitle.text = "Worg Rider";
        this.textDescription.text = "Fearsome mounted champions.\nThey dismount only when their\nworg dies.";
        this.textExtra.text = "* GREAT MAGIC RESISTANCE\n* FAST SPEED\n* CAN DISMOUNT";
        goto Label_0D81;
    Label_0962:
        this.portraitOrcArmored.gameObject.SetActive(1);
        this.textTitle.text = "Orc Champion";
        this.textDescription.text = "The elite fighting force of the\ngoblinoid horde, equipped with\nheavy armor.";
        this.textExtra.text = "* SLOW SPEED\n* GREAT ARMOR";
        goto Label_0D81;
    Label_09A8:
        this.portraitForestTroll.gameObject.SetActive(1);
        this.textTitle.text = "Forest Troll";
        this.textDescription.text = "Very hard to kill, these\nbehemots can regenerate their\nwounds almost instantly.";
        this.textExtra.text = "* VERY TOUGH\n* SLOW SPEED\n* SUPERB REGENERATION";
        goto Label_0D81;
    Label_09EE:
        this.portraitHusk.gameObject.SetActive(1);
        this.textTitle.text = "Husk";
        this.textDescription.text = "Fallen warriors, their bodies\nclaimed by the forest, they are\nnow only husks of their former\nselves.";
        this.textExtra.text = "\n* SLOW SPEED\n* MEDIUM ARMOR";
        goto Label_0D81;
    Label_0A34:
        this.portraitSpiderRotten.gameObject.SetActive(1);
        this.textTitle.text = "Noxious Creeper";
        this.textDescription.text = "An aggressive predator, that\nhatches mutated spiderlings to\nfeed on their prey.";
        this.textExtra.text = "* HIGH MAGIC RESISTANCE\n* SPAWNS SPIDERLINGS\n* COST 3 LIVES";
        goto Label_0D81;
    Label_0A7A:
        this.portraitTreant.gameObject.SetActive(1);
        this.textTitle.text = "Tainted Treant";
        this.textDescription.text = "With steel-hard bark, these\ncorrupted beings were once\nprotectors of the forest.";
        this.textExtra.text = "* HIGH ARMOR\n* TOUGH";
        goto Label_0D81;
    Label_0AC0:
        this.portraitSwampThing.gameObject.SetActive(1);
        this.textTitle.text = "Swamp Thing";
        this.textDescription.text = "A mass of vegetable matter\nthat comes from the vilest and\nmost tainted of places.";
        this.textExtra.text = "* VERY TOUGH\n* RANGED ATTACK\n* REGENERATION";
        goto Label_0D81;
    Label_0B06:
        this.portraitRaider.gameObject.SetActive(1);
        this.textTitle.text = "Raider";
        this.textDescription.text = "Elite armored mercenaries that\nfight only for the spoils of\nbattle and the promise of gold.";
        this.textExtra.text = "* SLOW SPEED\n* GREAT ARMOR\n* COST 3 LIVES\n* RANGED MAGIC ATTACK";
        goto Label_0D81;
    Label_0B4C:
        this.portraitPillager.gameObject.SetActive(1);
        this.textTitle.text = "Pillager";
        this.textDescription.text = "Magic resistant criminal\nwarlords that can dispatch\nscores of soldiers with their\ninfernal blades.";
        this.textExtra.text = "\n* AREA MAGIC ATTACK\n* COST 5 LIVES";
        goto Label_0D81;
    Label_0B92:
        this.portraitTrollSkater.gameObject.SetActive(1);
        this.textTitle.text = "Troll Pathfinder";
        this.textDescription.text = "Elite troll warriors that\nbecome unblockeable while\nstanding on ice.";
        this.textExtra.text = "* UNBLOCKABLE ON ICE\n* HEALTH REGENERATION\n* AVERAGE SPEED";
        goto Label_0D81;
    Label_0BD8:
        this.portraitTrollBrute.gameObject.SetActive(1);
        this.textTitle.text = "Troll Breaker";
        this.textDescription.text = "Armored, Combat-Trained\ntrolls, that can tear through\neven the most sophisticated of\ndefenses.";
        this.textExtra.text = "* VERY HIGH DAMAGE\n* SUPERB REGENERATION\n* LOW SPEED";
        goto Label_0D81;
    Label_0C1E:
        this.portraitCerberus.gameObject.SetActive(1);
        this.textTitle.text = "Cerberus";
        this.textDescription.text = "Three headed hounds with\nvery thick skin, they can\ndevour scores of soldiers.";
        this.textExtra.text = "* AREA ATTACK\n* HIGH ARMOR\n* MINIBOSS";
        goto Label_0D81;
    Label_0C64:
        this.portraitLegion.gameObject.SetActive(1);
        this.textTitle.text = "Demon Legion";
        this.textDescription.text = "Evil spawn from the abyss...\ntheir name is Legion,\nfor they can become many...";
        this.textExtra.text = "* GREAT ARMOR\n* CAN DUPLICATE ITSELF";
        goto Label_0D81;
    Label_0CAA:
        this.portraitFlareon.gameObject.SetActive(1);
        this.textTitle.text = "Flareon";
        this.textDescription.text = "These vile creatures can\nhurl devastating balls of\nfire, and they always attack in\ngroups.";
        this.textExtra.text = "* RANGED MAGIC ATTACK\n* FAST\n* MAGIC RESISTANCE";
        goto Label_0D81;
    Label_0CF0:
        this.portraitGulaemon.gameObject.SetActive(1);
        this.textTitle.text = "Gulaemon";
        this.textDescription.text = "Oversized demons with limited\nflight ability, able to withstand\na lot of punishment.";
        this.textExtra.text = "* SLOW SPEED\n* CAN FLY\n* VERY TOUGH";
        goto Label_0D81;
    Label_0D36:
        this.portraitRottenLesser.gameObject.SetActive(1);
        this.textTitle.text = "Rotshroom";
        this.textDescription.text = "Aggressive fungus creatures\nthat eagerly engage in\nmelee combat.";
        this.textExtra.text = "* POISONOUS SPORES";
        goto Label_0D81;
    Label_0D7C:;
    Label_0D81:
        this.PopIn();
        return;
    }

    private void Start()
    {
        Transform transform;
        this.stage = base.transform.parent.parent.GetComponent<StageBase>();
        this.textDescription = base.transform.FindChild("TextDescription").GetComponent<TextMesh>();
        this.textExtra = base.transform.FindChild("TextExtra").GetComponent<TextMesh>();
        this.textTitle = base.transform.FindChild("TextTitle").GetComponent<TextMesh>();
        transform = base.transform.FindChild("Portrait");
        this.portraitBandit = transform.FindChild("Bandit");
        this.portraitBrigand = transform.FindChild("Brigand");
        this.portraitDarkKnight = transform.FindChild("DarkKnight");
        this.portraitDarkSlayer = transform.FindChild("DarkSlayer");
        this.portraitDemon = transform.FindChild("Demon");
        this.portraitDemonImp = transform.FindChild("DemonImp");
        this.portraitDemonMage = transform.FindChild("DemonMage");
        this.portraitDemonWolf = transform.FindChild("DemonWolf");
        this.portraitFatOrc = transform.FindChild("FatOrc");
        this.portraitForestTroll = transform.FindChild("ForestTroll");
        this.portraitGargoyle = transform.FindChild("Gargoyle");
        this.portraitGiantSpider = transform.FindChild("GiantSpider");
        this.portraitGoblin = transform.FindChild("Goblin");
        this.portraitGoblinZapper = transform.FindChild("GoblinZapper");
        this.portraitGolemHead = transform.FindChild("GolemHead");
        this.portraitGulthak = transform.FindChild("Gulthak");
        this.portraitHusk = transform.FindChild("Husk");
        this.portraitJT = transform.FindChild("JT");
        this.portraitJuggernaut = transform.FindChild("Juggernaut");
        this.portraitLavaElemental = transform.FindChild("LavaElemental");
        this.portraitMarauder = transform.FindChild("Marauder");
        this.portraitNecromancer = transform.FindChild("Necromancer");
        this.portraitOgre = transform.FindChild("Ogre");
        this.portraitOrcArmored = transform.FindChild("OrcArmored");
        this.portraitOrcRider = transform.FindChild("OrcRider");
        this.portraitRocketeer = transform.FindChild("Rocketeer");
        this.portraitRottenBoss = transform.FindChild("RottenBoss");
        this.portraitSarelgaz = transform.FindChild("Sarelgaz");
        this.portraitShadowArcher = transform.FindChild("ShadowArcher");
        this.portraitShaman = transform.FindChild("Shaman");
        this.portraitSkeleton = transform.FindChild("Skeleton");
        this.portraitSkeletonWarrior = transform.FindChild("SkeletonWarrior");
        this.portraitSonOfSarelgaz = transform.FindChild("SonOfSarelgaz");
        this.portraitSpider = transform.FindChild("Spider");
        this.portraitSpiderRotten = transform.FindChild("SpiderRotten");
        this.portraitSwampThing = transform.FindChild("SwampThing");
        this.portraitTreant = transform.FindChild("Treant");
        this.portraitTroll = transform.FindChild("Troll");
        this.portraitTrollAxe = transform.FindChild("TrollAxe");
        this.portraitTrollChieftain = transform.FindChild("TrollChieftain");
        this.portraitVeznan = transform.FindChild("Veznan");
        this.portraitWinterWolf = transform.FindChild("WinterWolf");
        this.portraitWorg = transform.FindChild("Worg");
        this.portraitWulf = transform.FindChild("Wulf");
        this.portraitYeti = transform.FindChild("Yeti");
        this.portraitRaider = transform.FindChild("Raider");
        this.portraitPillager = transform.FindChild("Pillager");
        this.portraitTrollSkater = transform.FindChild("TrollSkater");
        this.portraitTrollBrute = transform.FindChild("TrollBrute");
        this.portraitCerberus = transform.FindChild("Cerberus");
        this.portraitLegion = transform.FindChild("Legion");
        this.portraitFlareon = transform.FindChild("Flareon");
        this.portraitGulaemon = transform.FindChild("Gulaemon");
        this.portraitRottenLesser = transform.FindChild("RottenLesser");
        base.gameObject.SetActive(0);
        return;
    }

    private void Update()
    {
    }
}

