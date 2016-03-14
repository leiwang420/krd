using System;
using System.Collections;
using UnityEngine;

public class TowerSasquatch : BarrackTower
{
    private bool opened;
    private SoldierSasquatch sasquash;
    public Transform sasquashPrefab;

    public TowerSasquatch()
    {
        base..ctor();
        return;
    }

    public override void BeginFire()
    {
    }

    public bool IsOpen()
    {
        return this.opened;
    }

    public bool IsSasquashAlive()
    {
        if ((this.sasquash == null) == null)
        {
            goto Label_0013;
        }
        return 0;
    Label_0013:
        return (this.sasquash.GetHealth() > 0);
    }

    public void OpenCave()
    {
        if (this.opened != null)
        {
            goto Label_001E;
        }
        this.opened = 1;
        base.GetComponent<PackedSprite>().PlayAnim(0);
    Label_001E:
        return;
    }

    protected override void PlayRallyPointMoveSound()
    {
        GameSoundManager.PlaySasquashRally();
        return;
    }

    public void ReleaseSasquash()
    {
        Transform transform;
        if ((this.sasquash == null) == null)
        {
            goto Label_0053;
        }
        transform = UnityEngine.Object.Instantiate(this.sasquashPrefab, new Vector3(-376f, 223f, -1f), Quaternion.identity) as Transform;
        transform.parent = base.transform;
        this.sasquash = transform.GetComponent<SoldierSasquatch>();
    Label_0053:
        this.sasquash.enabled = 1;
        base.stage.AddSoldier(this.sasquash);
        GameAchievements.LikeAHenderson();
        GameSoundManager.PlaySasquashReady();
        return;
    }

    private void Start()
    {
        base.doorStatus = 2;
        base.sprite = base.GetComponent<PackedSprite>();
        base.rallyRangeWidth = base.rangeRally;
        base.rallyRangeHeight = Mathf.CeilToInt(((float) base.rangeRally) * 0.7f);
        this.opened = 0;
        base.soldiers = new ArrayList();
        this.sasquash = base.transform.FindChild("Sasquash").GetComponent<SoldierSasquatch>();
        base.AddSoldier(this.sasquash);
        return;
    }
}

