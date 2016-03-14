using System;
using UnityEngine;

public class VeznanBlock : MonoBehaviour
{
    protected int clicks;
    protected float holdTime;
    protected float holdTimeCounter;
    protected bool isHolding;
    protected bool isPaused;
    protected bool isStarting;
    protected bool isTapping;
    protected PackedSprite sprite;
    protected float startTime;
    protected float startTimeCounter;
    protected Transform tap;
    public Transform tapPrefab;
    protected float tapTime;
    protected float tapTimeCounter;
    protected TowerBase tower;

    public VeznanBlock()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        float num;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if ((this.tower == null) == null)
        {
            goto Label_001D;
        }
    Label_001D:
        num = Time.deltaTime;
        if (this.isStarting == null)
        {
            goto Label_0076;
        }
        this.startTimeCounter += num;
        if (this.startTimeCounter < this.startTime)
        {
            goto Label_012B;
        }
        this.isStarting = 0;
        this.isTapping = 1;
        this.sprite.PlayAnim("startIdle");
        this.ShowTap();
        goto Label_012B;
    Label_0076:
        if (this.isTapping == null)
        {
            goto Label_00D8;
        }
        this.tapTimeCounter += num;
        if (this.tapTimeCounter < this.tapTime)
        {
            goto Label_012B;
        }
        this.isTapping = 0;
        this.isHolding = 1;
        this.sprite.PlayAnim("startEnd");
        GameSoundManager.PlayVeznanHoldTrap();
        UnityEngine.Object.Destroy(this.tap.gameObject);
        goto Label_012B;
    Label_00D8:
        if (this.isHolding == null)
        {
            goto Label_012B;
        }
        this.holdTimeCounter += num;
        if (this.holdTimeCounter < this.holdTime)
        {
            goto Label_012B;
        }
        this.isHolding = 0;
        this.sprite.PlayAnim("release");
        GameSoundManager.PlayVeznanHoldDissipate();
        this.tower.SetActive(1, 1);
    Label_012B:
        return;
    }

    private void OnMouseDown()
    {
        if (this.isTapping == null)
        {
            goto Label_0063;
        }
        this.clicks += 1;
        GameSoundManager.PlayVeznanHoldHit();
        if (this.clicks != 2)
        {
            goto Label_0063;
        }
        this.isTapping = 0;
        this.sprite.PlayAnim("release");
        GameSoundManager.PlayVeznanHoldDissipate();
        this.tower.SetActive(1, 1);
        UnityEngine.Object.Destroy(this.tap.gameObject);
    Label_0063:
        return;
    }

    public void Pause()
    {
        this.isPaused = 1;
        this.sprite.PauseAnim();
        if ((this.tap != null) == null)
        {
            goto Label_0033;
        }
        this.tap.GetComponent<PackedSprite>().PauseAnim();
    Label_0033:
        return;
    }

    public void SetTower(TowerBase t)
    {
        this.tower = t;
        this.tower.SetActive(0, 0);
        return;
    }

    protected unsafe void ShowTap()
    {
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        &vector = new Vector3(&base.transform.position.x, &base.transform.position.y, -891f);
        this.tap = UnityEngine.Object.Instantiate(this.tapPrefab, vector, Quaternion.identity) as Transform;
        return;
    }

    private void Start()
    {
        this.sprite = base.GetComponent<PackedSprite>();
        this.startTime = 1.1f;
        this.tapTime = 4f;
        this.holdTime = 6f;
        this.sprite.PlayAnim("start");
        this.isStarting = 1;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        this.sprite.UnpauseAnim();
        if ((this.tap != null) == null)
        {
            goto Label_0033;
        }
        this.tap.GetComponent<PackedSprite>().UnpauseAnim();
    Label_0033:
        return;
    }
}

