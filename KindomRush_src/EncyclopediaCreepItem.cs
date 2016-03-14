using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EncyclopediaCreepItem : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> switchmapA;
    private EncyclopediaContainerCreeps container;
    private string description;
    private bool selected;
    private string specialDecription;
    private PackedSprite sprite;
    private PackedSprite spriteDecoration;
    private string type;

    public EncyclopediaCreepItem()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.spriteDecoration = base.transform.FindChild("Decoration").GetComponent<PackedSprite>();
        this.spriteDecoration.transform.localPosition = new Vector3(0f, 0f, -1f);
        return;
    }

    public unsafe void CheckLock()
    {
        string str;
        Dictionary<string, int> dictionary;
        int num;
        str = base.name;
        if (str == null)
        {
            goto Label_0DC9;
        }
        if (switchmapA != null)
        {
            goto Label_030E;
        }
        dictionary = new Dictionary<string, int>(0x3a);
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
        dictionary.Add("Rotten lesser", 0x38);
        dictionary.Add("Myconid", 0x39);
        switchmapA = dictionary;
    Label_030E:
        if (switchmapA.TryGetValue(str, &num) == null)
        {
            goto Label_0DC9;
        }
        switch (num)
        {
            case 0:
                goto Label_0413;

            case 1:
                goto Label_043E;

            case 2:
                goto Label_0469;

            case 3:
                goto Label_0494;

            case 4:
                goto Label_04BF;

            case 5:
                goto Label_04EA;

            case 6:
                goto Label_0515;

            case 7:
                goto Label_0540;

            case 8:
                goto Label_056B;

            case 9:
                goto Label_0596;

            case 10:
                goto Label_05C1;

            case 11:
                goto Label_05EC;

            case 12:
                goto Label_0617;

            case 13:
                goto Label_063A;

            case 14:
                goto Label_0665;

            case 15:
                goto Label_0690;

            case 0x10:
                goto Label_06BB;

            case 0x11:
                goto Label_06E6;

            case 0x12:
                goto Label_0711;

            case 0x13:
                goto Label_073C;

            case 20:
                goto Label_0767;

            case 0x15:
                goto Label_0792;

            case 0x16:
                goto Label_07BD;

            case 0x17:
                goto Label_07E8;

            case 0x18:
                goto Label_0813;

            case 0x19:
                goto Label_083E;

            case 0x1a:
                goto Label_0869;

            case 0x1b:
                goto Label_0894;

            case 0x1c:
                goto Label_08BF;

            case 0x1d:
                goto Label_08EA;

            case 30:
                goto Label_0915;

            case 0x1f:
                goto Label_0940;

            case 0x20:
                goto Label_096B;

            case 0x21:
                goto Label_0996;

            case 0x22:
                goto Label_09C1;

            case 0x23:
                goto Label_09EC;

            case 0x24:
                goto Label_0A17;

            case 0x25:
                goto Label_0A42;

            case 0x26:
                goto Label_0A6D;

            case 0x27:
                goto Label_0A98;

            case 40:
                goto Label_0AC3;

            case 0x29:
                goto Label_0AEE;

            case 0x2a:
                goto Label_0B19;

            case 0x2b:
                goto Label_0B44;

            case 0x2c:
                goto Label_0B6F;

            case 0x2d:
                goto Label_0B9A;

            case 0x2e:
                goto Label_0BC5;

            case 0x2f:
                goto Label_0BF0;

            case 0x30:
                goto Label_0C1B;

            case 0x31:
                goto Label_0C46;

            case 50:
                goto Label_0C71;

            case 0x33:
                goto Label_0C9C;

            case 0x34:
                goto Label_0CC7;

            case 0x35:
                goto Label_0CF2;

            case 0x36:
                goto Label_0D1D;

            case 0x37:
                goto Label_0D48;

            case 0x38:
                goto Label_0D73;

            case 0x39:
                goto Label_0D9E;
        }
        goto Label_0DC9;
    Label_0413:
        if (GameData.notificationEnemyBandit != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_043E:
        if (GameData.notificationEnemyBrigand != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0469:
        if (GameData.notificationEnemyDarkKnight != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0494:
        if (GameData.notificationEnemyDarkSlayer != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_04BF:
        if (GameData.notificationEnemyDemon != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_04EA:
        if (GameData.notificationEnemyDemonImp != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0515:
        if (GameData.notificationEnemyDemonMage != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0540:
        if (GameData.notificationEnemyDemonWolf != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_056B:
        if (GameData.notificationEnemyFatOrc != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0596:
        if (GameData.notificationEnemyForestTroll != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_05C1:
        if (GameData.notificationEnemyGargoyle != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_05EC:
        if (GameData.notificationEnemySpiderSmall != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0617:
        this.spriteDecoration.Hide(0);
        this.spriteDecoration.RevertToStatic();
        this.selected = 1;
        goto Label_0DC9;
    Label_063A:
        if (GameData.notificationEnemyGoblinZapper != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0665:
        if (GameData.notificationEnemyGolemHead != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0690:
        if (GameData.notificationEnemyBossTreant != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_06BB:
        if (GameData.notificationEnemyGulThak != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_06E6:
        if (GameData.notificationEnemyZombie != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0711:
        if (GameData.notificationEnemyYetiBoss != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_073C:
        if (GameData.notificationEnemyJuggernaut != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0767:
        if (GameData.notificationEnemyBossBandit != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0792:
        if (GameData.notificationEnemyLavaElemental != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_07BD:
        if (GameData.notificationEnemyMarauder != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_07E8:
        if (GameData.notificationEnemyNecromancer != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0813:
        if (GameData.notificationEnemyRottenSpider != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_083E:
        if (GameData.notificationEnemyOgre != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0869:
        if (GameData.notificationEnemyOrcArmored != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0894:
        if (GameData.notificationEnemyPillager != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_08BF:
        if (GameData.notificationEnemyRaider != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_08EA:
        if (GameData.notificationEnemyRocketeer != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0915:
        if (GameData.notificationEnemySarelgaz != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0940:
        if (GameData.notificationEnemyShadowArcher != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_096B:
        if (GameData.notificationEnemyShaman != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0996:
        if (GameData.notificationEnemySkeletor != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_09C1:
        if (GameData.notificationEnemySkeletorBig != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_09EC:
        if (GameData.notificationEnemySarelgazSmall != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0A17:
        if (GameData.notificationEnemySpider != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0A42:
        if (GameData.notificationEnemySwampThing != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0A6D:
        if (GameData.notificationEnemyRottenTree != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0A98:
        if (GameData.notificationEnemyTroll != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0AC3:
        if (GameData.notificationEnemyTrollAxeThrower != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0AEE:
        if (GameData.notificationEnemyTrollChieftain != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0B19:
        if (GameData.notificationEnemyVeznan != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0B44:
        if (GameData.notificationEnemyWhiteWolf != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0B6F:
        if (GameData.notificationEnemyWolf != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0B9A:
        if (GameData.notificationEnemyOrcRider != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0BC5:
        if (GameData.notificationEnemySmallWolf != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0BF0:
        if (GameData.notificationEnemyYeti != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0C1B:
        if (GameData.notificationEnemyTrollBrute != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0C46:
        if (GameData.notificationEnemyTrollSkater != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0C71:
        if (GameData.notificationEnemyTrollBoss != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0C9C:
        if (GameData.notificationEnemyLegion != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0CC7:
        if (GameData.notificationEnemyFlareon != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0CF2:
        if (GameData.notificationEnemyGulaemon != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0D1D:
        if (GameData.notificationEnemyCerberus != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0D48:
        if (GameData.notificationEnemyBossDemonMoloch != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0D73:
        if (GameData.notificationEnemyRottenLesser != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
        goto Label_0DC9;
    Label_0D9E:
        if (GameData.notificationEnemyBossMyconid != null)
        {
            goto Label_0DC9;
        }
        this.sprite.PlayAnim("locked");
        base.collider.enabled = 0;
    Label_0DC9:
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
        this.Select();
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
        this.container.Select(base.name);
        this.ShowInfo();
        this.spriteDecoration.Hide(0);
        this.spriteDecoration.RevertToStatic();
        this.selected = 1;
        return;
    }

    private void ShowInfo()
    {
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.container = base.transform.parent.parent.GetComponent<EncyclopediaContainerCreeps>();
        this.spriteDecoration = base.transform.FindChild("Decoration").GetComponent<PackedSprite>();
        this.spriteDecoration.transform.localPosition = new Vector3(0f, 0f, -1f);
        return;
    }
}

