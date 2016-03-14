using System;
using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public Transform bombPrefab;
    public Transform craterDecalPrefab;
    private bool isPaused;
    private int level;
    private int lifeTime;
    private int lifeTimeCounter;
    private int maxDamage;
    private int minDamage;
    private int rangeActivateHeight;
    private int rangeActivateWidth;
    private CreepSpawner spawner;
    private PackedSprite sprite;
    private StageBase stage;

    public Mine()
    {
        base..ctor();
        return;
    }

    protected bool CanExplode()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        bool flag;
        IDisposable disposable;
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0011:
        try
        {
            goto Label_0052;
        Label_0016:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_0052;
            }
            if (creep.isFlying != null)
            {
                goto Label_0052;
            }
            if (this.OnRange(creep) == null)
            {
                goto Label_0052;
            }
            flag = 1;
            goto Label_0079;
        Label_0052:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0016;
            }
            goto Label_0077;
        }
        finally
        {
        Label_0062:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006F;
            }
        Label_006F:
            disposable.Dispose();
        }
    Label_0077:
        return 0;
    Label_0079:
        return flag;
    }

    private unsafe void FixedUpdate()
    {
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        Transform transform2;
        IDisposable disposable;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        Vector3 vector4;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.lifeTimeCounter += 1;
        if (this.lifeTimeCounter < this.lifeTime)
        {
            goto Label_0037;
        }
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    Label_0037:
        if (this.CanExplode() != null)
        {
            goto Label_0043;
        }
        return;
    Label_0043:
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0054:
        try
        {
            goto Label_00AE;
        Label_0059:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00AE;
            }
            if (creep.isFlying != null)
            {
                goto Label_00AE;
            }
            if (this.OnRange(creep) == null)
            {
                goto Label_00AE;
            }
            creep.Damage(this.GetDamage(), 3, 0, 0);
            if (creep.IsDead() == null)
            {
                goto Label_00AE;
            }
            creep.Gib();
        Label_00AE:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0059;
            }
            goto Label_00D3;
        }
        finally
        {
        Label_00BE:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00CB;
            }
        Label_00CB:
            disposable.Dispose();
        }
    Label_00D3:
        GameSoundManager.PlayBombExplosionSound();
        UnityEngine.Object.Instantiate(this.craterDecalPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y, -1f), Quaternion.identity);
        transform2 = UnityEngine.Object.Instantiate(this.bombPrefab, new Vector3(&base.transform.position.x, &base.transform.position.y + 30f, -800f), Quaternion.identity) as Transform;
        this.stage.AddExplosion(transform2);
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    protected int GetDamage()
    {
        return UnityEngine.Random.Range(this.minDamage, this.maxDamage + 1);
    }

    protected unsafe bool OnRange(Creep myEnemy)
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        &vector = new Vector3(&myEnemy.transform.position.x, &myEnemy.transform.position.y + &myEnemy.anchorPoint.y, 0f);
        return IronUtils.ellipseContainPoint(vector, (float) this.rangeActivateHeight, (float) this.rangeActivateWidth, base.transform.position);
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.sprite.PauseAnim();
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
        this.sprite = base.GetComponent<PackedSprite>();
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        this.rangeActivateWidth = (int) GameSettings.GetHeroSetting("hero_dwarf", "mineActiveRangeWidth", 1);
        this.rangeActivateHeight = Mathf.RoundToInt(((float) this.rangeActivateWidth) * 0.7f);
        this.minDamage = ((int) GameSettings.GetHeroSetting("hero_dwarf", "mineMinDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_dwarf", "mineDamageIncrement", 1)) * this.level);
        this.maxDamage = ((int) GameSettings.GetHeroSetting("hero_dwarf", "mineMaxDamage", 1)) + (((int) GameSettings.GetHeroSetting("hero_dwarf", "mineDamageIncrement", 1)) * this.level);
        this.lifeTime = ((int) GameSettings.GetHeroSetting("hero_dwarf", "mineDuration", 1)) * 30;
        this.lifeTimeCounter = 0;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.sprite.UnpauseAnim();
        return;
    }
}

