using System;
using System.Collections;
using UnityEngine;

public class DecoCloudManager : MonoBehaviour
{
    private ArrayList cloudList;
    private float counterSpawn;
    private float timeSpawn;

    public DecoCloudManager()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
        this.counterSpawn += Time.deltaTime;
        if (this.counterSpawn < this.timeSpawn)
        {
            goto Label_0034;
        }
        this.counterSpawn = 0f;
        this.SpawnCloud();
    Label_0034:
        return;
    }

    private void SpawnCloud()
    {
        DecoCloud cloud;
        IEnumerator enumerator;
        IDisposable disposable;
        enumerator = this.cloudList.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0033;
        Label_0011:
            cloud = (DecoCloud) enumerator.Current;
            if (cloud.IsSleeping() == null)
            {
                goto Label_0033;
            }
            cloud.Launch();
            goto Label_0055;
        Label_0033:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0055;
        }
        finally
        {
        Label_0043:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_004E;
            }
        Label_004E:
            disposable.Dispose();
        }
    Label_0055:
        return;
    }

    private void Start()
    {
        Transform transform;
        IEnumerator enumerator;
        DecoCloud cloud;
        IDisposable disposable;
        this.timeSpawn = 3f;
        this.cloudList = new ArrayList();
        enumerator = base.transform.GetEnumerator();
    Label_0022:
        try
        {
            goto Label_0053;
        Label_0027:
            transform = (Transform) enumerator.Current;
            cloud = transform.GetComponent<DecoCloud>();
            if ((cloud != null) == null)
            {
                goto Label_0053;
            }
            this.cloudList.Add(cloud);
        Label_0053:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0027;
            }
            goto Label_0075;
        }
        finally
        {
        Label_0063:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_006E;
            }
        Label_006E:
            disposable.Dispose();
        }
    Label_0075:
        return;
    }
}

