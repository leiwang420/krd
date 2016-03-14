using System;
using System.Collections;
using UnityEngine;

public class EarthquakeController : MonoBehaviour
{
    private int currentIndex;
    private int currentRock;
    private int delayTime;
    private int delayTimeCounter;
    private Transform effectEarthquakePrefab;
    private bool isPaused;
    private int maxDamage;
    private int maxRocks;
    private int minDamage;
    private int nodeIndex;
    private int nodePath;
    private int nodeSubPath;
    private Vector2[][][] paths;
    private int rangeHeight;
    private int rangeWidth;
    private Transform spawner;
    private StageBase stage;

    public EarthquakeController()
    {
        base..ctor();
        return;
    }

    private unsafe void AddEffect(Vector2 pos)
    {
        Transform transform;
        Transform transform2;
        IEnumerator enumerator;
        Creep creep;
        IDisposable disposable;
        transform = UnityEngine.Object.Instantiate(this.effectEarthquakePrefab, new Vector3(&pos.x, &pos.y - 10f, -900f), Quaternion.identity) as Transform;
        this.stage.AddEffect(transform);
        enumerator = this.spawner.transform.GetEnumerator();
    Label_0051:
        try
        {
            goto Label_00C4;
        Label_0056:
            transform2 = (Transform) enumerator.Current;
            creep = transform2.GetComponent<Creep>();
            if (creep.IsActive() == null)
            {
                goto Label_00C4;
            }
            if (this.OnRangeFissure(creep, pos) == null)
            {
                goto Label_00C4;
            }
            creep.Damage(this.GetDamageFissure(), 1, 0, 0);
            if (creep.IsBoss() != null)
            {
                goto Label_00C4;
            }
            if (creep.isFlying != null)
            {
                goto Label_00C4;
            }
            if (creep.IsActive() == null)
            {
                goto Label_00C4;
            }
            if (creep.IsDead() != null)
            {
                goto Label_00C4;
            }
            creep.DoStun(60);
        Label_00C4:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0056;
            }
            goto Label_00E9;
        }
        finally
        {
        Label_00D4:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_00E1;
            }
        Label_00E1:
            disposable.Dispose();
        }
    Label_00E9:
        return;
    }

    private unsafe void FixedUpdate()
    {
        Vector2[][] vectorArray;
        int num;
        if (this.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.delayTimeCounter += 1;
        if (this.delayTimeCounter >= this.delayTime)
        {
            goto Label_002C;
        }
        return;
    Label_002C:
        vectorArray = this.paths[this.nodePath];
        num = this.currentRock * 4;
        if ((this.nodeIndex + num) >= ((int) vectorArray[0].Length))
        {
            goto Label_00F6;
        }
        if (this.currentRock != 1)
        {
            goto Label_0072;
        }
        this.currentIndex = this.nodeSubPath;
        goto Label_00D6;
    Label_0072:
        if (this.currentIndex == this.nodeSubPath)
        {
            goto Label_0094;
        }
        this.currentIndex = this.nodeSubPath;
        goto Label_00D6;
    Label_0094:
        if (this.currentIndex != 2)
        {
            goto Label_00AC;
        }
        this.currentIndex = 0;
        goto Label_00D6;
    Label_00AC:
        if (this.currentIndex != 1)
        {
            goto Label_00C4;
        }
        this.currentIndex = 0;
        goto Label_00D6;
    Label_00C4:
        if (this.currentIndex != null)
        {
            goto Label_00D6;
        }
        this.currentIndex = 1;
    Label_00D6:
        this.AddEffect(*(&(vectorArray[this.currentIndex][this.nodeIndex + num])));
    Label_00F6:
        if ((this.nodeIndex - num) <= 0)
        {
            goto Label_0124;
        }
        this.AddEffect(*(&(vectorArray[this.currentIndex][this.nodeIndex - num])));
    Label_0124:
        this.currentRock += 1;
        this.delayTimeCounter = 0;
        if (this.maxRocks >= this.currentRock)
        {
            goto Label_0151;
        }
        base.enabled = 0;
    Label_0151:
        return;
    }

    private int GetDamageFissure()
    {
        return UnityEngine.Random.Range(this.minDamage, this.maxDamage + 1);
    }

    public void InitWithPath(int pNodePath, int pSubPath, int pNodeIndex, int rocks, int damageMin, int damageMax, int pRangeWidth, int pRangeHeight)
    {
        this.nodePath = pNodePath;
        this.nodeSubPath = pSubPath;
        this.nodeIndex = pNodeIndex;
        this.maxRocks = rocks;
        this.minDamage = damageMin;
        this.maxDamage = damageMax;
        this.rangeWidth = pRangeWidth;
        this.rangeHeight = pRangeHeight;
        this.delayTime = 3;
        this.delayTimeCounter = 0;
        this.currentRock = 1;
        this.currentIndex = this.nodeSubPath;
        return;
    }

    private bool OnRangeFissure(Creep myEnemy, Vector2 pos)
    {
        return IronUtils.ellipseContainPoint(myEnemy.transform.position, (float) this.rangeHeight, (float) this.rangeWidth, pos);
    }

    public void Pause()
    {
        this.isPaused = 1;
        return;
    }

    private void Start()
    {
        this.spawner = GameObject.Find("Spawner").GetComponent<Transform>();
        this.stage = GameObject.Find("Stage").GetComponent<StageBase>();
        this.paths = this.stage.GetPath();
        this.effectEarthquakePrefab = Resources.Load("Prefabs/Particles & fx/Effect Ground Earthquake", typeof(Transform)) as Transform;
        return;
    }

    public void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

