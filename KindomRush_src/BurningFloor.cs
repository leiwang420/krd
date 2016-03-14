using System;
using System.Collections;
using UnityEngine;

public abstract class BurningFloor : MonoBehaviour
{
    protected ArrayList damagePoints;
    protected int damageReloadTime;
    protected int damageReloadTimeCounter;
    protected int[][] data;
    protected ArrayList decalList;
    protected int durationTime;
    protected int durationTimeCounter;
    protected bool isActive;
    protected bool isBurning;
    protected int rangeHeight;
    protected int rangeWidth;
    protected int reloadTime;
    protected int reloadTimeCounter;
    protected StageBase stage;
    protected bool wasActive;

    protected BurningFloor()
    {
        base..ctor();
        return;
    }

    protected abstract void CreateDamagePoints();
    protected void DamageEnemies()
    {
        ArrayList list;
        Soldier soldier;
        IEnumerator enumerator;
        SoldierModifierFireBurningFloor floor;
        IDisposable disposable;
        this.damageReloadTimeCounter = 0;
        enumerator = this.stage.GetSoldiers().GetEnumerator();
    Label_001A:
        try
        {
            goto Label_0089;
        Label_001F:
            soldier = (Soldier) enumerator.Current;
            if (soldier.IsActive() == null)
            {
                goto Label_0089;
            }
            if (soldier.IsDead() != null)
            {
                goto Label_0089;
            }
            if (soldier.CanBeBurned() == null)
            {
                goto Label_0089;
            }
            if (this.OnRange(soldier) == null)
            {
                goto Label_0089;
            }
            if ((soldier.GetComponent<SoldierModifierFireBurningFloor>() != null) == null)
            {
                goto Label_0076;
            }
            soldier.ShowFire();
            goto Label_0089;
        Label_0076:
            soldier.gameObject.AddComponent<SoldierModifierFireBurningFloor>().SetProperties(1);
        Label_0089:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
            goto Label_00AE;
        }
        finally
        {
        Label_0099:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00A6;
            }
        Label_00A6:
            disposable.Dispose();
        }
    Label_00AE:
        return;
    }

    protected void FixedUpdate()
    {
        if (this.isActive != null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        if (this.isBurning != null)
        {
            goto Label_003E;
        }
        if (this.reloadTimeCounter >= this.reloadTime)
        {
            goto Label_0037;
        }
        this.reloadTimeCounter += 1;
        return;
    Label_0037:
        this.SetOn();
        return;
    Label_003E:
        if (this.durationTimeCounter >= this.durationTime)
        {
            goto Label_0084;
        }
        this.durationTimeCounter += 1;
        if (this.damageReloadTimeCounter >= this.damageReloadTime)
        {
            goto Label_007D;
        }
        this.damageReloadTimeCounter += 1;
        return;
    Label_007D:
        this.DamageEnemies();
        return;
    Label_0084:
        this.SetOff();
        return;
    }

    protected void LoadData()
    {
        if (GameData.GetGameMode() != null)
        {
            goto Label_0015;
        }
        this.LoadDataCampaign();
        goto Label_003C;
    Label_0015:
        if (GameData.GetGameMode() != 1)
        {
            goto Label_002B;
        }
        this.LoadDataHeroic();
        goto Label_003C;
    Label_002B:
        if (GameData.GetGameMode() != 2)
        {
            goto Label_003C;
        }
        this.LoadDataIron();
    Label_003C:
        return;
    }

    protected abstract void LoadDataCampaign();
    protected abstract void LoadDataHeroic();
    protected abstract void LoadDataIron();
    protected void LoadDecals()
    {
        Transform transform;
        IEnumerator enumerator;
        Transform transform2;
        BurningFloorDecal decal;
        IDisposable disposable;
        this.decalList = new ArrayList();
        enumerator = base.transform.GetEnumerator();
    Label_0017:
        try
        {
            goto Label_0065;
        Label_001C:
            transform = (Transform) enumerator.Current;
            transform2 = transform.FindChild("InfernoDecalOn");
            if ((transform2 != null) == null)
            {
                goto Label_0065;
            }
            decal = transform2.gameObject.AddComponent<BurningFloorDecal>();
            if ((decal != null) == null)
            {
                goto Label_0065;
            }
            this.decalList.Add(decal);
        Label_0065:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001C;
            }
            goto Label_008A;
        }
        finally
        {
        Label_0075:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0082;
            }
        Label_0082:
            disposable.Dispose();
        }
    Label_008A:
        return;
    }

    protected bool OnRange(Soldier mySoldier)
    {
        int num;
        num = 0;
        goto Label_005B;
    Label_0007:
        if (IronUtils.ellipseContainPoint(mySoldier.transform.position - new Vector3(0f, mySoldier.yAdjust, 0f), (float) this.rangeHeight, (float) this.rangeWidth, (Vector3) this.damagePoints[num]) == null)
        {
            goto Label_0057;
        }
        return 1;
    Label_0057:
        num += 1;
    Label_005B:
        if (num < this.damagePoints.Count)
        {
            goto Label_0007;
        }
        return 0;
    }

    public void Pause()
    {
        this.wasActive = this.isActive;
        this.isActive = 0;
        return;
    }

    protected void SetOff()
    {
        BurningFloorDecal decal;
        IEnumerator enumerator;
        IDisposable disposable;
        this.isActive = 0;
        this.isBurning = 0;
        this.reloadTimeCounter = 0;
        enumerator = this.decalList.GetEnumerator();
    Label_0021:
        try
        {
            goto Label_0038;
        Label_0026:
            decal = (BurningFloorDecal) enumerator.Current;
            decal.SetOff();
        Label_0038:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0026;
            }
            goto Label_005A;
        }
        finally
        {
        Label_0048:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_0053;
            }
        Label_0053:
            disposable.Dispose();
        }
    Label_005A:
        return;
    }

    protected void SetOn()
    {
        BurningFloorDecal decal;
        IEnumerator enumerator;
        IDisposable disposable;
        this.isBurning = 1;
        this.durationTimeCounter = 0;
        enumerator = this.decalList.GetEnumerator();
    Label_001A:
        try
        {
            goto Label_0031;
        Label_001F:
            decal = (BurningFloorDecal) enumerator.Current;
            decal.SetOn();
        Label_0031:
            if (enumerator.MoveNext() != null)
            {
                goto Label_001F;
            }
            goto Label_0053;
        }
        finally
        {
        Label_0041:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_004C;
            }
        Label_004C:
            disposable.Dispose();
        }
    Label_0053:
        return;
    }

    public virtual void SetSettingsOnWave()
    {
        if (this.reloadTime != null)
        {
            goto Label_0017;
        }
        this.isActive = 0;
        goto Label_001E;
    Label_0017:
        this.isActive = 1;
    Label_001E:
        if (this.isBurning == null)
        {
            goto Label_002F;
        }
        this.SetOff();
    Label_002F:
        return;
    }

    protected void Start()
    {
        this.stage = base.transform.parent.GetComponent<StageBase>();
        this.LoadDecals();
        this.CreateDamagePoints();
        this.LoadData();
        return;
    }

    public void Unpause()
    {
        this.isActive = this.wasActive;
        return;
    }
}

