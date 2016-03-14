using System;
using UnityEngine;

public class HeroRoomButton : MonoBehaviour
{
    private HeroRoom heroRoomScreen;
    private Map map;
    private PackedSprite portraitAlleria;
    private PackedSprite portraitBolin;
    private PackedSprite portraitDenas;
    private PackedSprite portraitElora;
    private PackedSprite portraitHacksaw;
    private PackedSprite portraitIgnus;
    private PackedSprite portraitLightseeker;
    private PackedSprite portraitMagnus;
    private PackedSprite portraitMalik;
    private PackedSprite portraitOni;
    private PackedSprite portraitThor;
    private PackedSprite portraitViking;
    private PackedSprite sprite;
    private PackedSprite spriteBalloonHero;

    public HeroRoomButton()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    private void OnMouseDown()
    {
        this.sprite.PlayAnim("click");
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

    private void OnMouseUp()
    {
        this.sprite.RevertToStatic();
        this.map.DisableMapButtons();
        this.map.ShowOverlay();
        this.heroRoomScreen.transform.position = new Vector3(57f, 275f, -910f);
        this.heroRoomScreen.Show();
        GameSoundManager.PlayGUIButtonCommon();
        this.spriteBalloonHero.Hide(1);
        return;
    }

    public void Refresh()
    {
        this.portraitAlleria.Hide(1);
        this.portraitDenas.Hide(1);
        this.portraitBolin.Hide(1);
        this.portraitMagnus.Hide(1);
        this.portraitLightseeker.Hide(1);
        this.portraitIgnus.Hide(1);
        this.portraitMalik.Hide(1);
        this.portraitViking.Hide(1);
        this.portraitElora.Hide(1);
        this.portraitHacksaw.Hide(1);
        this.portraitOni.Hide(1);
        this.portraitThor.Hide(1);
        if (GameUpgrades.SelectedHero != 2)
        {
            goto Label_00AC;
        }
        this.portraitAlleria.Hide(0);
        goto Label_01DF;
    Label_00AC:
        if (GameUpgrades.SelectedHero != 7)
        {
            goto Label_00C8;
        }
        this.portraitDenas.Hide(0);
        goto Label_01DF;
    Label_00C8:
        if (GameUpgrades.SelectedHero != 3)
        {
            goto Label_00E4;
        }
        this.portraitBolin.Hide(0);
        goto Label_01DF;
    Label_00E4:
        if (GameUpgrades.SelectedHero != 4)
        {
            goto Label_0100;
        }
        this.portraitMagnus.Hide(0);
        goto Label_01DF;
    Label_0100:
        if (GameUpgrades.SelectedHero != 1)
        {
            goto Label_011C;
        }
        this.portraitLightseeker.Hide(0);
        goto Label_01DF;
    Label_011C:
        if (GameUpgrades.SelectedHero != 6)
        {
            goto Label_0138;
        }
        this.portraitIgnus.Hide(0);
        goto Label_01DF;
    Label_0138:
        if (GameUpgrades.SelectedHero != 5)
        {
            goto Label_0154;
        }
        this.portraitMalik.Hide(0);
        goto Label_01DF;
    Label_0154:
        if (GameUpgrades.SelectedHero != 8)
        {
            goto Label_0170;
        }
        this.portraitElora.Hide(0);
        goto Label_01DF;
    Label_0170:
        if (GameUpgrades.SelectedHero != 9)
        {
            goto Label_018D;
        }
        this.portraitViking.Hide(0);
        goto Label_01DF;
    Label_018D:
        if (GameUpgrades.SelectedHero != 12)
        {
            goto Label_01AA;
        }
        this.portraitHacksaw.Hide(0);
        goto Label_01DF;
    Label_01AA:
        if (GameUpgrades.SelectedHero != 11)
        {
            goto Label_01C7;
        }
        this.portraitOni.Hide(0);
        goto Label_01DF;
    Label_01C7:
        if (GameUpgrades.SelectedHero != 10)
        {
            goto Label_01DF;
        }
        this.portraitThor.Hide(0);
    Label_01DF:
        return;
    }

    private void Start()
    {
        this.heroRoomScreen = GameObject.Find("Hero Room").GetComponent<HeroRoom>();
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.spriteBalloonHero = GameObject.Find("BalloonHero").GetComponent<PackedSprite>();
        this.portraitLightseeker = base.transform.FindChild("Lightseeker").GetComponent<PackedSprite>();
        this.portraitAlleria = base.transform.FindChild("Alleria").GetComponent<PackedSprite>();
        this.portraitBolin = base.transform.FindChild("Bolin").GetComponent<PackedSprite>();
        this.portraitMagnus = base.transform.FindChild("Magnus").GetComponent<PackedSprite>();
        this.portraitIgnus = base.transform.FindChild("Ignus").GetComponent<PackedSprite>();
        this.portraitMalik = base.transform.FindChild("Malik").GetComponent<PackedSprite>();
        this.portraitDenas = base.transform.FindChild("Denas").GetComponent<PackedSprite>();
        this.portraitViking = base.transform.FindChild("Viking").GetComponent<PackedSprite>();
        this.portraitElora = base.transform.FindChild("Frost").GetComponent<PackedSprite>();
        this.portraitHacksaw = base.transform.FindChild("Hacksaw").GetComponent<PackedSprite>();
        this.portraitOni = base.transform.FindChild("Oni").GetComponent<PackedSprite>();
        this.portraitThor = base.transform.FindChild("Thor").GetComponent<PackedSprite>();
        base.Invoke("Refresh", 0.05f);
        return;
    }
}

