using System;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    protected int damage;
    public Transform decal;
    public bool decalOver;
    public bool decalRotation;
    protected Vector2 destination;
    protected bool isPaused;
    public bool spinning;
    protected StageBase stage;
    protected Creep target;
    protected Soldier targetSoldier;
    protected float xDest;
    public float yDecalAdjust;
    protected float yDest;

    public BaseProjectile()
    {
        base..ctor();
        return;
    }

    private void FixedUpdate()
    {
    }

    public virtual void Hit()
    {
    }

    public virtual void Pause()
    {
        this.isPaused = 1;
        return;
    }

    public virtual void SetDamage(int d)
    {
        this.damage = d;
        return;
    }

    public void SetDest(float x, float y)
    {
        this.xDest = x;
        this.yDest = y;
        this.destination = new Vector2(this.xDest, this.yDest);
        return;
    }

    public void SetStage(StageBase s)
    {
        this.stage = s;
        return;
    }

    public unsafe void SetTarget(Soldier c)
    {
        object[] objArray1;
        Vector3 vector;
        Vector3 vector2;
        Vector3 vector3;
        this.targetSoldier = c;
        this.xDest = &this.targetSoldier.transform.position.x;
        this.yDest = &this.targetSoldier.transform.position.y;
        this.destination = new Vector2(this.xDest, this.yDest);
        if ((c != null) == null)
        {
            goto Label_00A7;
        }
        this.yDest = &base.transform.position.y + c.yAdjust;
        this.destination += new Vector2(0f, c.yAdjust);
    Label_00A7:
        objArray1 = new object[] { "Target: ", this.targetSoldier, "xdest: ", (float) this.xDest, "ydest: ", (float) this.yDest };
        MonoBehaviour.print(string.Concat(objArray1));
        return;
    }

    public void SetTarget(Creep c, float x, float y)
    {
        this.target = c;
        this.xDest = x;
        this.yDest = y;
        this.destination = new Vector2(this.xDest, this.yDest);
        if ((c != null) == null)
        {
            goto Label_0081;
        }
        if ((this.target.name != "Veznan") == null)
        {
            goto Label_0081;
        }
        this.yDest = y + c.yAdjust;
        this.destination += new Vector2(0f, c.yAdjust);
    Label_0081:
        return;
    }

    public void SetTarget(Soldier c, float x, float y)
    {
        this.targetSoldier = c;
        this.xDest = x;
        this.yDest = y;
        this.destination = new Vector2(this.xDest, this.yDest);
        if ((c != null) == null)
        {
            goto Label_0067;
        }
        this.yDest = y - c.yAdjust;
        this.destination -= new Vector2(0f, c.yAdjust);
    Label_0067:
        return;
    }

    public virtual void ShowDecal()
    {
        Transform transform;
        int num;
        if ((this.decal != null) == null)
        {
            goto Label_00BB;
        }
        num = (this.decalOver == null) ? -1 : -900;
        if (this.decalRotation == null)
        {
            goto Label_006E;
        }
        transform = UnityEngine.Object.Instantiate(this.decal, new Vector3(this.xDest, this.yDest + this.yDecalAdjust, (float) num), base.transform.rotation) as Transform;
        goto Label_009E;
    Label_006E:
        transform = UnityEngine.Object.Instantiate(this.decal, new Vector3(this.xDest, this.yDest + this.yDecalAdjust, (float) num), Quaternion.identity) as Transform;
    Label_009E:
        if ((this.stage != null) == null)
        {
            goto Label_00BB;
        }
        this.stage.AddEffect(transform);
    Label_00BB:
        UnityEngine.Object.Destroy(base.gameObject);
        return;
    }

    private void Start()
    {
    }

    public virtual void Unpause()
    {
        this.isPaused = 0;
        return;
    }
}

