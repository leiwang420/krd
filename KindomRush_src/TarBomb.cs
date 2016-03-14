using System;
using System.Collections;
using UnityEngine;

public class TarBomb : MonoBehaviour
{
    private bool fading;
    private bool isActive;
    private bool isPaused;
    private int level;
    private float opacity;
    private int rangeHeight;
    private int rangewidth;
    private CreepSpawner spawner;
    private PackedSprite sprite;
    private StageBase stage;
    private int tarDuration;
    private int tarReload;
    private int tarReloadTime;

    public TarBomb()
    {
        base..ctor();
        return;
    }

    protected void EndMe()
    {
        this.isActive = 0;
        this.fading = 1;
        this.sprite.PlayAnim("fade");
        return;
    }

    private void FixedUpdate()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isActive != null)
        {
            goto Label_007C;
        }
        if (this.fading == null)
        {
            goto Label_007B;
        }
        this.opacity -= ((float) Time.deltaTime) * 3.3f;
        this.sprite.SetColor(new Color(1f, 1f, 1f, this.opacity));
        if (this.opacity > 0f)
        {
            goto Label_007B;
        }
        UnityEngine.Object.Destroy(base.gameObject);
    Label_007B:
        return;
    Label_007C:
        if (this.tarReloadTime >= this.tarReload)
        {
            goto Label_009C;
        }
        this.tarReloadTime += 1;
        return;
    Label_009C:
        enumerator = this.spawner.transform.GetEnumerator();
    Label_00AD:
        try
        {
            goto Label_00F9;
        Label_00B2:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00F9;
            }
            if ((creep.GetComponent<EnemyModifierTar>() == null) == null)
            {
                goto Label_00F9;
            }
            if (this.OnRangeTar(creep) == null)
            {
                goto Label_00F9;
            }
            creep.gameObject.AddComponent<EnemyModifierTar>();
        Label_00F9:
            if (enumerator.MoveNext() != null)
            {
                goto Label_00B2;
            }
            goto Label_011B;
        }
        finally
        {
        Label_0109:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0114;
            }
        Label_0114:
            disposable.Dispose();
        }
    Label_011B:
        this.tarReloadTime = 0;
        return;
    }

    protected bool OnRangeTar(Creep myEnemy)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeHeight, (float) this.rangewidth, base.transform.position);
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public void SetLevel(int l)
    {
        this.level = l;
        return;
    }

    public void SetStage(StageBase s)
    {
        this.stage = s;
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.sprite = base.GetComponent<PackedSprite>();
        this.tarDuration = ((int) GameSettings.GetHeroSetting("hero_dwarf", "tarDurationTime", 1)) + (((int) GameSettings.GetHeroSetting("hero_dwarf", "tarDurationTimeIncrement", 1)) * this.level);
        this.tarReload = 10;
        this.tarReloadTime = 0;
        this.rangewidth = (int) GameSettings.GetHeroSetting("hero_dwarf", "tarRangeApplyWidth", 1);
        this.rangeHeight = Mathf.RoundToInt(((float) this.rangewidth) * 0.7f);
        this.isActive = 1;
        this.opacity = 1f;
        base.Invoke("EndMe", (float) this.tarDuration);
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

