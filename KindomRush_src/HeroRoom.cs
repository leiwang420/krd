using System;
using System.Collections;
using UnityEngine;

public class HeroRoom : MonoBehaviour
{
    private ButtonSelectHero buttonSelect;
    private Transform holderAlleria;
    private Transform holderBolin;
    private Transform holderDenas;
    private Transform holderElora;
    private Transform holderHacksaw;
    private Transform holderIgnus;
    private Transform holderLightseeker;
    private Transform holderMagnus;
    private Transform holderMalik;
    private Transform holderOni;
    private Transform holderThor;
    private Transform holderViking;
    private Map map;
    private HeroRoomPortrait portraitAlleria;
    private HeroRoomPortrait portraitBolin;
    private HeroRoomPortrait portraitDenas;
    private HeroRoomPortrait portraitElora;
    private HeroRoomPortrait portraitHacksaw;
    private HeroRoomPortrait portraitIgnus;
    private HeroRoomPortrait portraitLightSeeker;
    private HeroRoomPortrait portraitMagnus;
    private HeroRoomPortrait portraitMalik;
    private HeroRoomPortrait portraitOni;
    private HeroRoomPortrait portraitThor;
    private HeroRoomPortrait portraitViking;
    private GameUpgrades.heroType selectedHero;

    public HeroRoom()
    {
        base..ctor();
        return;
    }

    private void CleanUp()
    {
        base.transform.position = new Vector3(57f, 1600f, -910f);
        this.portraitAlleria.HideOutline();
        this.portraitBolin.HideOutline();
        this.portraitDenas.HideOutline();
        this.portraitIgnus.HideOutline();
        this.portraitLightSeeker.HideOutline();
        this.portraitMagnus.HideOutline();
        this.portraitMalik.HideOutline();
        this.portraitElora.HideOutline();
        this.portraitViking.HideOutline();
        this.portraitHacksaw.HideOutline();
        this.portraitOni.HideOutline();
        this.ResetFade(base.transform);
        this.RefreshLocks();
        return;
    }

    public void Close()
    {
        object[] objArray1;
        objArray1 = new object[] { "position", (Vector3) new Vector3(57f, 116f, -910f), "time", (double) 0.2, "easetype", (iTween.EaseType) 7, "oncomplete", "CleanUp" };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        this.Fade(base.transform);
        return;
    }

    public void DeselectHero()
    {
        if (this.selectedHero != 1)
        {
            goto Label_001C;
        }
        this.portraitLightSeeker.HideTick();
        goto Label_0132;
    Label_001C:
        if (this.selectedHero != 2)
        {
            goto Label_0038;
        }
        this.portraitAlleria.HideTick();
        goto Label_0132;
    Label_0038:
        if (this.selectedHero != 7)
        {
            goto Label_0054;
        }
        this.portraitDenas.HideTick();
        goto Label_0132;
    Label_0054:
        if (this.selectedHero != 3)
        {
            goto Label_0070;
        }
        this.portraitBolin.HideTick();
        goto Label_0132;
    Label_0070:
        if (this.selectedHero != 4)
        {
            goto Label_008C;
        }
        this.portraitMagnus.HideTick();
        goto Label_0132;
    Label_008C:
        if (this.selectedHero != 6)
        {
            goto Label_00A8;
        }
        this.portraitIgnus.HideTick();
        goto Label_0132;
    Label_00A8:
        if (this.selectedHero != 5)
        {
            goto Label_00C4;
        }
        this.portraitMalik.HideTick();
        goto Label_0132;
    Label_00C4:
        if (this.selectedHero != 8)
        {
            goto Label_00E0;
        }
        this.portraitElora.HideTick();
        goto Label_0132;
    Label_00E0:
        if (this.selectedHero != 9)
        {
            goto Label_00FD;
        }
        this.portraitViking.HideTick();
        goto Label_0132;
    Label_00FD:
        if (this.selectedHero != 12)
        {
            goto Label_011A;
        }
        this.portraitHacksaw.HideTick();
        goto Label_0132;
    Label_011A:
        if (this.selectedHero != 11)
        {
            goto Label_0132;
        }
        this.portraitOni.HideTick();
    Label_0132:
        GameUpgrades.SelectedHero = 0;
        this.buttonSelect.Refresh();
        return;
    }

    private void Fade(Transform t)
    {
        ParticleFadeOut @out;
        TextMesh mesh;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        if ((t.name == "Glow") == null)
        {
            goto Label_0016;
        }
        return;
    Label_0016:
        if (t.GetComponent<PackedSprite>() == null)
        {
            goto Label_00B9;
        }
        if ((t.name == "Outline") == null)
        {
            goto Label_004B;
        }
        if (t.GetComponent<PackedSprite>().IsHidden() != null)
        {
            goto Label_0070;
        }
    Label_004B:
        if ((t.name == "Tick") == null)
        {
            goto Label_0071;
        }
        if (t.GetComponent<PackedSprite>().IsHidden() == null)
        {
            goto Label_0071;
        }
    Label_0070:
        return;
    Label_0071:
        if (t.GetComponent<ParticleFadeOut>() != null)
        {
            goto Label_00AE;
        }
        @out = t.gameObject.AddComponent<ParticleFadeOut>();
        @out.fadeSpeed = 0.3f;
        @out.finalOpacity = 0f;
        @out.Fade();
        goto Label_00B9;
    Label_00AE:
        t.GetComponent<ParticleFadeOut>().Fade();
    Label_00B9:
        mesh = t.GetComponent<TextMesh>();
        if ((mesh != null) == null)
        {
            goto Label_00D8;
        }
        mesh.gameObject.SetActive(0);
    Label_00D8:
        enumerator = t.GetEnumerator();
    Label_00DF:
        try
        {
            goto Label_00F7;
        Label_00E4:
            transform = (Transform) enumerator.Current;
            this.Fade(transform);
        Label_00F7:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00E4;
            }
            goto Label_011C;
        }
        finally
        {
        Label_0107:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0114;
            }
        Label_0114:
            disposable.Dispose();
        }
    Label_011C:
        return;
    }

    public GameUpgrades.heroType GetClickedHero()
    {
        return this.selectedHero;
    }

    private void InitHolders()
    {
        this.holderLightseeker = base.transform.FindChild("HolderLightseeker");
        this.holderMalik = base.transform.FindChild("HolderMalik");
        this.holderBolin = base.transform.FindChild("HolderBolin");
        this.holderMagnus = base.transform.FindChild("HolderMagnus");
        this.holderAlleria = base.transform.FindChild("HolderAlleria");
        this.holderIgnus = base.transform.FindChild("HolderIgnus");
        this.holderDenas = base.transform.FindChild("HolderDenas");
        this.holderElora = base.transform.FindChild("HolderElora");
        this.holderViking = base.transform.FindChild("HolderViking");
        this.holderHacksaw = base.transform.FindChild("HolderHacksaw");
        this.holderOni = base.transform.FindChild("HolderOni");
        this.holderThor = base.transform.FindChild("HolderThor");
        this.holderLightseeker.gameObject.SetActive(1);
        this.holderMalik.gameObject.SetActive(0);
        this.holderBolin.gameObject.SetActive(0);
        this.holderMagnus.gameObject.SetActive(0);
        this.holderAlleria.gameObject.SetActive(0);
        this.holderIgnus.gameObject.SetActive(0);
        this.holderDenas.gameObject.SetActive(0);
        this.holderElora.gameObject.SetActive(0);
        this.holderViking.gameObject.SetActive(0);
        this.holderHacksaw.gameObject.SetActive(0);
        this.holderOni.gameObject.SetActive(0);
        this.holderThor.gameObject.SetActive(0);
        return;
    }

    private void InitPortraits()
    {
        this.portraitAlleria = base.transform.FindChild("PortraitAlleria").GetComponent<HeroRoomPortrait>();
        this.portraitBolin = base.transform.FindChild("PortraitBolin").GetComponent<HeroRoomPortrait>();
        this.portraitDenas = base.transform.FindChild("PortraitDenas").GetComponent<HeroRoomPortrait>();
        this.portraitIgnus = base.transform.FindChild("PortraitIgnus").GetComponent<HeroRoomPortrait>();
        this.portraitLightSeeker = base.transform.FindChild("PortraitLightseeker").GetComponent<HeroRoomPortrait>();
        this.portraitMagnus = base.transform.FindChild("PortraitMagnus").GetComponent<HeroRoomPortrait>();
        this.portraitMalik = base.transform.FindChild("PortraitMalik").GetComponent<HeroRoomPortrait>();
        this.portraitElora = base.transform.FindChild("PortraitElora").GetComponent<HeroRoomPortrait>();
        this.portraitViking = base.transform.FindChild("PortraitViking").GetComponent<HeroRoomPortrait>();
        this.portraitHacksaw = base.transform.FindChild("PortraitHacksaw").GetComponent<HeroRoomPortrait>();
        this.portraitOni = base.transform.FindChild("PortraitOni").GetComponent<HeroRoomPortrait>();
        this.portraitLightSeeker.Init(1);
        this.portraitMalik.Init(5);
        this.portraitBolin.Init(3);
        this.portraitMagnus.Init(4);
        this.portraitAlleria.Init(2);
        this.portraitIgnus.Init(6);
        this.portraitDenas.Init(7);
        this.portraitElora.Init(8);
        this.portraitViking.Init(9);
        this.portraitHacksaw.Init(12);
        this.portraitOni.Init(11);
        return;
    }

    private void RefreshLocks()
    {
        if (GameUpgrades.CanSelectHero(2) != null)
        {
            goto Label_001B;
        }
        this.portraitAlleria.ShowLock();
        goto Label_0026;
    Label_001B:
        this.portraitAlleria.HideLock();
    Label_0026:
        if (GameUpgrades.CanSelectHero(7) != null)
        {
            goto Label_0041;
        }
        this.portraitDenas.ShowLock();
        goto Label_004C;
    Label_0041:
        this.portraitDenas.HideLock();
    Label_004C:
        if (GameUpgrades.CanSelectHero(3) != null)
        {
            goto Label_0067;
        }
        this.portraitBolin.ShowLock();
        goto Label_0072;
    Label_0067:
        this.portraitBolin.HideLock();
    Label_0072:
        if (GameUpgrades.CanSelectHero(8) != null)
        {
            goto Label_008D;
        }
        this.portraitElora.ShowLock();
        goto Label_0098;
    Label_008D:
        this.portraitElora.HideLock();
    Label_0098:
        if (GameUpgrades.CanSelectHero(4) != null)
        {
            goto Label_00B3;
        }
        this.portraitMagnus.ShowLock();
        goto Label_00BE;
    Label_00B3:
        this.portraitMagnus.HideLock();
    Label_00BE:
        if (GameUpgrades.CanSelectHero(1) != null)
        {
            goto Label_00D9;
        }
        this.portraitLightSeeker.ShowLock();
        goto Label_00E4;
    Label_00D9:
        this.portraitLightSeeker.HideLock();
    Label_00E4:
        if (GameUpgrades.CanSelectHero(6) != null)
        {
            goto Label_00FF;
        }
        this.portraitIgnus.ShowLock();
        goto Label_010A;
    Label_00FF:
        this.portraitIgnus.HideLock();
    Label_010A:
        if (GameUpgrades.CanSelectHero(5) != null)
        {
            goto Label_0125;
        }
        this.portraitMalik.ShowLock();
        goto Label_0130;
    Label_0125:
        this.portraitMalik.HideLock();
    Label_0130:
        if (GameUpgrades.CanSelectHero(9) != null)
        {
            goto Label_014C;
        }
        this.portraitViking.ShowLock();
        goto Label_0157;
    Label_014C:
        this.portraitViking.HideLock();
    Label_0157:
        if (GameUpgrades.CanSelectHero(12) != null)
        {
            goto Label_0173;
        }
        this.portraitHacksaw.ShowLock();
        goto Label_017E;
    Label_0173:
        this.portraitHacksaw.HideLock();
    Label_017E:
        if (GameUpgrades.CanSelectHero(11) != null)
        {
            goto Label_019A;
        }
        this.portraitOni.ShowLock();
        goto Label_01A5;
    Label_019A:
        this.portraitOni.HideLock();
    Label_01A5:
        return;
    }

    public void Reset()
    {
        this.holderLightseeker.gameObject.SetActive(0);
        this.holderMalik.gameObject.SetActive(0);
        this.holderBolin.gameObject.SetActive(0);
        this.holderMagnus.gameObject.SetActive(0);
        this.holderAlleria.gameObject.SetActive(0);
        this.holderIgnus.gameObject.SetActive(0);
        this.holderDenas.gameObject.SetActive(0);
        this.holderElora.gameObject.SetActive(0);
        this.holderViking.gameObject.SetActive(0);
        this.holderHacksaw.gameObject.SetActive(0);
        this.holderOni.gameObject.SetActive(0);
        if (GameUpgrades.SelectedHero != 1)
        {
            goto Label_00F9;
        }
        this.holderLightseeker.gameObject.SetActive(1);
        this.selectedHero = 1;
        this.portraitLightSeeker.ShowTick();
        this.portraitLightSeeker.ShowOutline();
        goto Label_0398;
    Label_00F9:
        if (GameUpgrades.SelectedHero != 2)
        {
            goto Label_0137;
        }
        this.holderAlleria.gameObject.SetActive(1);
        this.selectedHero = 2;
        this.portraitAlleria.ShowTick();
        this.portraitAlleria.ShowOutline();
        goto Label_0398;
    Label_0137:
        if (GameUpgrades.SelectedHero != 7)
        {
            goto Label_0175;
        }
        this.holderDenas.gameObject.SetActive(1);
        this.selectedHero = 7;
        this.portraitDenas.ShowTick();
        this.portraitDenas.ShowOutline();
        goto Label_0398;
    Label_0175:
        if (GameUpgrades.SelectedHero != 3)
        {
            goto Label_01B3;
        }
        this.holderBolin.gameObject.SetActive(1);
        this.selectedHero = 3;
        this.portraitBolin.ShowTick();
        this.portraitBolin.ShowOutline();
        goto Label_0398;
    Label_01B3:
        if (GameUpgrades.SelectedHero != 4)
        {
            goto Label_01F1;
        }
        this.holderMagnus.gameObject.SetActive(1);
        this.selectedHero = 4;
        this.portraitMagnus.ShowTick();
        this.portraitMagnus.ShowOutline();
        goto Label_0398;
    Label_01F1:
        if (GameUpgrades.SelectedHero != 6)
        {
            goto Label_022F;
        }
        this.holderIgnus.gameObject.SetActive(1);
        this.selectedHero = 6;
        this.portraitIgnus.ShowTick();
        this.portraitIgnus.ShowOutline();
        goto Label_0398;
    Label_022F:
        if (GameUpgrades.SelectedHero != 5)
        {
            goto Label_026D;
        }
        this.holderMalik.gameObject.SetActive(1);
        this.selectedHero = 5;
        this.portraitMalik.ShowTick();
        this.portraitMalik.ShowOutline();
        goto Label_0398;
    Label_026D:
        if (GameUpgrades.SelectedHero != 8)
        {
            goto Label_02AB;
        }
        this.holderElora.gameObject.SetActive(1);
        this.selectedHero = 8;
        this.portraitElora.ShowTick();
        this.portraitElora.ShowOutline();
        goto Label_0398;
    Label_02AB:
        if (GameUpgrades.SelectedHero != 9)
        {
            goto Label_02EB;
        }
        this.holderViking.gameObject.SetActive(1);
        this.selectedHero = 9;
        this.portraitViking.ShowTick();
        this.portraitViking.ShowOutline();
        goto Label_0398;
    Label_02EB:
        if (GameUpgrades.SelectedHero != 12)
        {
            goto Label_032B;
        }
        this.holderHacksaw.gameObject.SetActive(1);
        this.selectedHero = 12;
        this.portraitHacksaw.ShowTick();
        this.portraitHacksaw.ShowOutline();
        goto Label_0398;
    Label_032B:
        if (GameUpgrades.SelectedHero != 11)
        {
            goto Label_036B;
        }
        this.holderOni.gameObject.SetActive(1);
        this.selectedHero = 11;
        this.portraitOni.ShowTick();
        this.portraitOni.ShowOutline();
        goto Label_0398;
    Label_036B:
        if (GameUpgrades.SelectedHero != 10)
        {
            goto Label_037C;
        }
        goto Label_0398;
    Label_037C:
        this.holderLightseeker.gameObject.SetActive(1);
        this.portraitLightSeeker.ShowOutline();
    Label_0398:
        this.buttonSelect.Refresh();
        this.RefreshLocks();
        return;
    }

    private void ResetFade(Transform t)
    {
        ParticleFadeOut @out;
        TextMesh mesh;
        Transform transform;
        IEnumerator enumerator;
        IDisposable disposable;
        @out = t.GetComponent<ParticleFadeOut>();
        if ((@out != null) == null)
        {
            goto Label_0019;
        }
        @out.Reset();
    Label_0019:
        mesh = t.GetComponent<TextMesh>();
        if ((mesh != null) == null)
        {
            goto Label_0038;
        }
        mesh.gameObject.SetActive(1);
    Label_0038:
        enumerator = t.GetEnumerator();
    Label_003F:
        try
        {
            goto Label_0057;
        Label_0044:
            transform = (Transform) enumerator.Current;
            this.ResetFade(transform);
        Label_0057:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0044;
            }
            goto Label_007C;
        }
        finally
        {
        Label_0067:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0074;
            }
        Label_0074:
            disposable.Dispose();
        }
    Label_007C:
        return;
    }

    public void SelectHero()
    {
        if (GameUpgrades.SelectedHero != 1)
        {
            goto Label_001B;
        }
        this.portraitLightSeeker.HideTick();
        goto Label_0127;
    Label_001B:
        if (GameUpgrades.SelectedHero != 2)
        {
            goto Label_0036;
        }
        this.portraitAlleria.HideTick();
        goto Label_0127;
    Label_0036:
        if (GameUpgrades.SelectedHero != 7)
        {
            goto Label_0051;
        }
        this.portraitDenas.HideTick();
        goto Label_0127;
    Label_0051:
        if (GameUpgrades.SelectedHero != 3)
        {
            goto Label_006C;
        }
        this.portraitBolin.HideTick();
        goto Label_0127;
    Label_006C:
        if (GameUpgrades.SelectedHero != 4)
        {
            goto Label_0087;
        }
        this.portraitMagnus.HideTick();
        goto Label_0127;
    Label_0087:
        if (GameUpgrades.SelectedHero != 6)
        {
            goto Label_00A2;
        }
        this.portraitIgnus.HideTick();
        goto Label_0127;
    Label_00A2:
        if (GameUpgrades.SelectedHero != 5)
        {
            goto Label_00BD;
        }
        this.portraitMalik.HideTick();
        goto Label_0127;
    Label_00BD:
        if (GameUpgrades.SelectedHero != 8)
        {
            goto Label_00D8;
        }
        this.portraitElora.HideTick();
        goto Label_0127;
    Label_00D8:
        if (GameUpgrades.SelectedHero != 9)
        {
            goto Label_00F4;
        }
        this.portraitViking.HideTick();
        goto Label_0127;
    Label_00F4:
        if (GameUpgrades.SelectedHero != 12)
        {
            goto Label_0110;
        }
        this.portraitHacksaw.HideTick();
        goto Label_0127;
    Label_0110:
        if (GameUpgrades.SelectedHero != 11)
        {
            goto Label_0127;
        }
        this.portraitOni.HideTick();
    Label_0127:
        if (this.selectedHero != 1)
        {
            goto Label_0143;
        }
        this.portraitLightSeeker.ShowTick();
        goto Label_0259;
    Label_0143:
        if (this.selectedHero != 2)
        {
            goto Label_015F;
        }
        this.portraitAlleria.ShowTick();
        goto Label_0259;
    Label_015F:
        if (this.selectedHero != 7)
        {
            goto Label_017B;
        }
        this.portraitDenas.ShowTick();
        goto Label_0259;
    Label_017B:
        if (this.selectedHero != 3)
        {
            goto Label_0197;
        }
        this.portraitBolin.ShowTick();
        goto Label_0259;
    Label_0197:
        if (this.selectedHero != 4)
        {
            goto Label_01B3;
        }
        this.portraitMagnus.ShowTick();
        goto Label_0259;
    Label_01B3:
        if (this.selectedHero != 6)
        {
            goto Label_01CF;
        }
        this.portraitIgnus.ShowTick();
        goto Label_0259;
    Label_01CF:
        if (this.selectedHero != 5)
        {
            goto Label_01EB;
        }
        this.portraitMalik.ShowTick();
        goto Label_0259;
    Label_01EB:
        if (this.selectedHero != 8)
        {
            goto Label_0207;
        }
        this.portraitElora.ShowTick();
        goto Label_0259;
    Label_0207:
        if (this.selectedHero != 9)
        {
            goto Label_0224;
        }
        this.portraitViking.ShowTick();
        goto Label_0259;
    Label_0224:
        if (this.selectedHero != 12)
        {
            goto Label_0241;
        }
        this.portraitHacksaw.ShowTick();
        goto Label_0259;
    Label_0241:
        if (this.selectedHero != 11)
        {
            goto Label_0259;
        }
        this.portraitOni.ShowTick();
    Label_0259:
        GameUpgrades.SelectedHero = this.selectedHero;
        this.buttonSelect.Refresh();
        return;
    }

    public void SetInfoHero(GameUpgrades.heroType hero)
    {
        this.holderLightseeker.gameObject.SetActive(0);
        this.holderAlleria.gameObject.SetActive(0);
        this.holderDenas.gameObject.SetActive(0);
        this.holderBolin.gameObject.SetActive(0);
        this.holderMagnus.gameObject.SetActive(0);
        this.holderIgnus.gameObject.SetActive(0);
        this.holderMalik.gameObject.SetActive(0);
        this.holderElora.gameObject.SetActive(0);
        this.holderViking.gameObject.SetActive(0);
        this.holderHacksaw.gameObject.SetActive(0);
        this.holderOni.gameObject.SetActive(0);
        this.holderThor.gameObject.SetActive(0);
        this.portraitLightSeeker.HideOutline();
        this.portraitAlleria.HideOutline();
        this.portraitDenas.HideOutline();
        this.portraitBolin.HideOutline();
        this.portraitMagnus.HideOutline();
        this.portraitIgnus.HideOutline();
        this.portraitMalik.HideOutline();
        this.portraitElora.HideOutline();
        this.portraitViking.HideOutline();
        this.portraitHacksaw.HideOutline();
        this.portraitOni.HideOutline();
        if (hero != 1)
        {
            goto Label_017D;
        }
        this.holderLightseeker.gameObject.SetActive(1);
        this.holderLightseeker.GetComponent<HeroRoomHolder>().Enable();
        this.portraitLightSeeker.ShowOutline();
        goto Label_03B8;
    Label_017D:
        if (hero != 2)
        {
            goto Label_01B5;
        }
        this.holderAlleria.gameObject.SetActive(1);
        this.holderAlleria.GetComponent<HeroRoomHolder>().Enable();
        this.portraitAlleria.ShowOutline();
        goto Label_03B8;
    Label_01B5:
        if (hero != 7)
        {
            goto Label_01ED;
        }
        this.holderDenas.gameObject.SetActive(1);
        this.holderDenas.GetComponent<HeroRoomHolder>().Enable();
        this.portraitDenas.ShowOutline();
        goto Label_03B8;
    Label_01ED:
        if (hero != 3)
        {
            goto Label_0225;
        }
        this.holderBolin.gameObject.SetActive(1);
        this.holderBolin.GetComponent<HeroRoomHolder>().Enable();
        this.portraitBolin.ShowOutline();
        goto Label_03B8;
    Label_0225:
        if (hero != 4)
        {
            goto Label_025D;
        }
        this.holderMagnus.gameObject.SetActive(1);
        this.holderMagnus.GetComponent<HeroRoomHolder>().Enable();
        this.portraitMagnus.ShowOutline();
        goto Label_03B8;
    Label_025D:
        if (hero != 6)
        {
            goto Label_0295;
        }
        this.holderIgnus.gameObject.SetActive(1);
        this.holderIgnus.GetComponent<HeroRoomHolder>().Enable();
        this.portraitIgnus.ShowOutline();
        goto Label_03B8;
    Label_0295:
        if (hero != 5)
        {
            goto Label_02CD;
        }
        this.holderMalik.gameObject.SetActive(1);
        this.holderMalik.GetComponent<HeroRoomHolder>().Enable();
        this.portraitMalik.ShowOutline();
        goto Label_03B8;
    Label_02CD:
        if (hero != 8)
        {
            goto Label_0305;
        }
        this.holderElora.gameObject.SetActive(1);
        this.holderElora.GetComponent<HeroRoomHolder>().Enable();
        this.portraitElora.ShowOutline();
        goto Label_03B8;
    Label_0305:
        if (hero != 9)
        {
            goto Label_033E;
        }
        this.holderViking.gameObject.SetActive(1);
        this.holderViking.GetComponent<HeroRoomHolder>().Enable();
        this.portraitViking.ShowOutline();
        goto Label_03B8;
    Label_033E:
        if (hero != 12)
        {
            goto Label_0377;
        }
        this.holderHacksaw.gameObject.SetActive(1);
        this.holderHacksaw.GetComponent<HeroRoomHolder>().Enable();
        this.portraitHacksaw.ShowOutline();
        goto Label_03B8;
    Label_0377:
        if (hero != 11)
        {
            goto Label_03B0;
        }
        this.holderOni.gameObject.SetActive(1);
        this.holderOni.GetComponent<HeroRoomHolder>().Enable();
        this.portraitOni.ShowOutline();
        goto Label_03B8;
    Label_03B0:
        if (hero != 10)
        {
            goto Label_03B8;
        }
    Label_03B8:
        this.selectedHero = hero;
        this.buttonSelect.Refresh();
        return;
    }

    public void Show()
    {
        object[] objArray1;
        base.transform.position = new Vector3(57f, 125f, -910f);
        objArray1 = new object[] { "position", (Vector3) new Vector3(57f, 75f, -910f), "time", (float) 0.25f, "easetype", (iTween.EaseType) 4 };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray1));
        this.Reset();
        return;
    }

    private void Start()
    {
        this.map = GameObject.Find("Map").GetComponent<Map>();
        this.InitHolders();
        this.InitPortraits();
        this.selectedHero = 1;
        this.buttonSelect = base.transform.FindChild("ButtonSelect").GetComponent<ButtonSelectHero>();
        return;
    }

    private unsafe void Update()
    {
        Vector3 vector;
        if (Input.GetKeyDown(0x1b) == null)
        {
            goto Label_0045;
        }
        if (&base.transform.position.y != 75f)
        {
            goto Label_0045;
        }
        this.map.EnableMapButtons();
        this.map.HideOverlay();
        this.Close();
    Label_0045:
        return;
    }
}

