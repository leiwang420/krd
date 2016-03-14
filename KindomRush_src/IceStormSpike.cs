using System;
using System.Collections;
using UnityEngine;

public class IceStormSpike : MonoBehaviour
{
    private int damage;
    private PackedSprite decal;
    private float delay;
    private Vector3 dmgPosition;
    private int range;
    private CreepSpawner spawner;
    private PackedSprite sprite;
    private int type;

    public IceStormSpike()
    {
        base..ctor();
        return;
    }

    private unsafe void Awake()
    {
        Vector3 vector;
        Vector3 vector2;
        this.sprite = base.GetComponent<PackedSprite>();
        this.decal = base.transform.FindChild("Decal").GetComponent<PackedSprite>();
        this.decal.transform.position = new Vector3(&base.transform.position.x, &base.transform.position.y, -1f);
        this.spawner = GameObject.Find("Spawner").GetComponent<CreepSpawner>();
        return;
    }

    private void DoDamage()
    {
        int num;
        Transform transform;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        this.decal.Hide(0);
        num = Mathf.RoundToInt(((float) this.range) * 0.7f);
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0030:
        try
        {
            goto Label_0092;
        Label_0035:
            transform = (Transform) enumerator.Current;
            creep = transform.GetComponent<Creep>();
            if ((creep != null) == null)
            {
                goto Label_0092;
            }
            if (creep.IsActive() == null)
            {
                goto Label_0092;
            }
            if (IronUtils.ellipseContainPoint(creep.transform.position, (float) num, (float) this.range, this.dmgPosition) == null)
            {
                goto Label_0092;
            }
            creep.Damage(this.damage, 2, 0, 0);
        Label_0092:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0035;
            }
            goto Label_00B7;
        }
        finally
        {
        Label_00A2:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00AF;
            }
        Label_00AF:
            disposable.Dispose();
        }
    Label_00B7:
        GameSoundManager.PlayHeroFrostIceRainDrop();
        base.Invoke("PlaySoundBreak", 1f);
        return;
    }

    private void FixedUpdate()
    {
    }

    public void Init(float delay, int type, int damage, int range)
    {
        Transform transform1;
        transform1 = base.transform;
        transform1.position += new Vector3(0f, 25f, 0f);
        this.dmgPosition = base.transform.position - new Vector3(0f, 60f, 0f);
        this.delay = delay;
        this.type = type - 1;
        this.damage = damage;
        this.range = range;
        base.Invoke("PlayAnimation", delay);
        base.Invoke("DoDamage", delay + 0.1f);
        return;
    }

    private void PlayAnimation()
    {
        this.sprite.PlayAnim(this.type);
        return;
    }

    private void PlaySoundBreak()
    {
        GameSoundManager.PlayHeroFrostIceRainBreak();
        return;
    }

    private void Start()
    {
    }
}

