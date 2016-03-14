using System;
using UnityEngine;

public class HeroPortrait : MonoBehaviour
{
    private PackedSprite barHealth;
    private PackedSprite barXp;
    private UnitClickable clickable;
    private bool clickThisFrame;
    private PackedSprite effect;
    private GUIBottom gui;
    private SoldierHero hero;
    private PackedSprite heroImage;
    private bool isLoading;
    private TextMesh level;
    private Transform overlay;
    private Quickmenu quickmenu;
    private PackedSprite selected;
    private PackedSprite sprite;

    public HeroPortrait()
    {
        base..ctor();
        return;
    }

    private void Awake()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.heroImage = base.transform.FindChild("Image").GetComponent<PackedSprite>();
        this.barHealth = base.transform.FindChild("BarHealth").GetComponent<PackedSprite>();
        this.barXp = base.transform.FindChild("BarXp").GetComponent<PackedSprite>();
        this.level = base.transform.FindChild("Level").GetComponent<TextMesh>();
        this.overlay = base.transform.FindChild("Overlay");
        this.effect = base.transform.FindChild("Effect").GetComponent<PackedSprite>();
        this.selected = base.transform.FindChild("Selected").GetComponent<PackedSprite>();
        return;
    }

    public void EndLoading()
    {
        this.isLoading = 0;
        this.overlay.transform.localScale = new Vector3(1f, 0f, 1f);
        return;
    }

    public bool IsSelected()
    {
        return this.clickable.IsSelected();
    }

    private void OnMouseEnter()
    {
        if (this.hero.IsSelected() != null)
        {
            goto Label_0044;
        }
        if (this.hero.GetHealth() <= 0)
        {
            goto Label_0044;
        }
        this.effect.Hide(0);
        this.effect.PlayAnim(0);
        this.effect.PauseAnim();
    Label_0044:
        return;
    }

    private void OnMouseExit()
    {
        this.effect.Hide(1);
        return;
    }

    private void OnMouseUp()
    {
        if (this.hero.IsDead() == null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        this.clickThisFrame = 1;
        if (this.clickable.IsSelected() == null)
        {
            goto Label_0033;
        }
        this.UnselectHero();
        goto Label_0039;
    Label_0033:
        this.SelectHero();
    Label_0039:
        return;
    }

    public void Refresh()
    {
        this.selected.Hide(1);
        return;
    }

    private void SelectHero()
    {
        this.quickmenu.Hide();
        this.gui.SetSelected(this.clickable);
        this.clickable.Select();
        this.selected.Hide(0);
        return;
    }

    public void SetHero()
    {
        int num;
        switch ((GameUpgrades.SelectedHero - 1))
        {
            case 0:
                goto Label_0043;

            case 1:
                goto Label_0063;

            case 2:
                goto Label_0083;

            case 3:
                goto Label_00A3;

            case 4:
                goto Label_00E3;

            case 5:
                goto Label_00C3;

            case 6:
                goto Label_0103;

            case 7:
                goto Label_0143;

            case 8:
                goto Label_0123;

            case 9:
                goto Label_01A3;

            case 10:
                goto Label_0183;

            case 11:
                goto Label_0163;
        }
        goto Label_01C3;
    Label_0043:
        this.heroImage.PlayAnim("Lightseeker");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0063:
        this.heroImage.PlayAnim("Alleria");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0083:
        this.heroImage.PlayAnim("Bolin");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_00A3:
        this.heroImage.PlayAnim("Magnus");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_00C3:
        this.heroImage.PlayAnim("Ignus");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_00E3:
        this.heroImage.PlayAnim("Malik");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0103:
        this.heroImage.PlayAnim("Denas");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0123:
        this.heroImage.PlayAnim("Viking");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0143:
        this.heroImage.PlayAnim("Frost");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0163:
        this.heroImage.PlayAnim("hacksaw");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_0183:
        this.heroImage.PlayAnim("samurai");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_01A3:
        this.heroImage.PlayAnim("thor");
        this.heroImage.PauseAnim();
        goto Label_01C8;
    Label_01C3:;
    Label_01C8:
        return;
    }

    private void Start()
    {
        SoldierHero[] heroArray;
        heroArray = UnityEngine.Object.FindObjectsOfType(typeof(SoldierHero)) as SoldierHero[];
        this.hero = heroArray[0];
        this.hero.SetPortrait(this);
        this.clickable = this.hero.GetComponent<UnitClickable>();
        this.UpdateLevel();
        this.gui = GameObject.Find("GUI Bottom").GetComponent<GUIBottom>();
        this.quickmenu = GameObject.Find("Quickmenu").GetComponent<Quickmenu>();
        return;
    }

    public void StartLoading()
    {
        this.isLoading = 1;
        this.overlay.transform.localScale = new Vector3(1f, 1f, 1f);
        return;
    }

    public void UnselectHero()
    {
        this.gui.HideInfo(this.clickable);
        this.clickable.UnSelect();
        this.selected.Hide(1);
        return;
    }

    private void Update()
    {
        this.clickThisFrame = 0;
        if (this.hero.IsDead() != null)
        {
            goto Label_0045;
        }
        if (Input.GetKeyDown(0x20) == null)
        {
            goto Label_0045;
        }
        if (this.clickable.IsSelected() == null)
        {
            goto Label_003E;
        }
        this.UnselectHero();
        goto Label_0044;
    Label_003E:
        this.SelectHero();
    Label_0044:
        return;
    Label_0045:
        if (this.clickable.IsSelected() == null)
        {
            goto Label_0071;
        }
        if (this.sprite.IsAnimating() != null)
        {
            goto Label_0071;
        }
        this.selected.Hide(0);
    Label_0071:
        return;
    }

    public unsafe void UpdateLevel()
    {
        int num;
        string str;
        num = this.hero.GetLevel();
        if (num != null)
        {
            goto Label_001D;
        }
        str = "1";
        goto Label_0025;
    Label_001D:
        str = &num.ToString();
    Label_0025:
        this.level.text = str;
        this.effect.Hide(0);
        this.effect.PlayAnim(0);
        return;
    }

    public void UpdateLifeBar()
    {
        float num;
        num = ((float) this.hero.GetHealth()) / ((float) this.hero.GetInitHealth());
        this.barHealth.transform.localScale = new Vector3(num, 1f, 1f);
        return;
    }

    public void UpdateLoading(float maxTime, float currentTime)
    {
        float num;
        num = (maxTime - currentTime) / maxTime;
        this.overlay.transform.localScale = new Vector3(1f, num, 1f);
        return;
    }

    public void UpdateXpBar()
    {
        int num;
        int num2;
        float num3;
        float num4;
        if (this.hero.GetLevel() != 10)
        {
            goto Label_0037;
        }
        this.barXp.transform.localScale = new Vector3(1f, 1f, 1f);
        return;
    Label_0037:
        num = (int) GameSettings.GetHeroSetting("common_tables", "master_xp", this.hero.GetLevel());
        num2 = ((int) GameSettings.GetHeroSetting("common_tables", "master_xp", this.hero.GetLevel() + 1)) - num;
        num3 = (float) this.hero.GetXp();
        num4 = 1f - ((((float) num2) - (num3 - ((float) num))) / ((float) num2));
        this.barXp.transform.localScale = new Vector3(num4, 1f, 1f);
        return;
    }
}

