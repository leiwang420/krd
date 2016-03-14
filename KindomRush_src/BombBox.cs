using System;
using UnityEngine;

public class BombBox : Bomb
{
    private int bombs;
    private Vector2[] path;
    public Transform smallBombPrefab;
    private int targetNode;

    public BombBox()
    {
        base..ctor();
        return;
    }

    private unsafe void CreateBombs()
    {
        int num;
        int num2;
        int num3;
        int num4;
        float num5;
        float num6;
        int num7;
        Vector2 vector;
        Transform transform;
        Bomb bomb;
        num = 0x12;
        num2 = Mathf.FloorToInt(((float) this.bombs) * 0.5f) * 7;
        num3 = -num2;
        num4 = num2;
        num5 = 0f;
        num6 = 0f;
        num7 = 1;
        goto Label_015C;
    Label_0033:
        if ((this.targetNode + num4) >= ((int) this.path.Length))
        {
            goto Label_0141;
        }
        if (UnityEngine.Random.Range(0f, 1f) <= 0.5f)
        {
            goto Label_0067;
        }
        num7 *= -1;
    Label_0067:
        vector = *(&(this.path[this.targetNode + num4]));
        num5 = &vector.x + ((UnityEngine.Random.Range(0f, 1f) * 6f) * ((float) num7));
        num6 = &vector.y + ((UnityEngine.Random.Range(0f, 1f) * 6f) * ((float) num7));
        transform = UnityEngine.Object.Instantiate(this.smallBombPrefab, base.transform.position, Quaternion.identity) as Transform;
        transform.parent = base.transform.parent;
        bomb = transform.GetComponent<Bomb>();
        bomb.SetDest(num5, num6);
        bomb.SetT1((float) num);
        bomb.SetDamage(60, 80);
        bomb.SetArea(100f);
        bomb.SetStage(base.stage);
        GameAchievements.ClusterFire();
    Label_0141:
        num4 -= 7;
        num += 1;
        if ((this.targetNode + num4) >= 0)
        {
            goto Label_015C;
        }
        goto Label_0163;
    Label_015C:
        if (num4 >= num3)
        {
            goto Label_0033;
        }
    Label_0163:
        return;
    }

    private void FixedUpdate()
    {
        if (base.isPaused == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        this.Rotate();
        base.Travel();
        if (this.TravelEnd() == null)
        {
            goto Label_003A;
        }
        GameSoundManager.PlayBombExplosionSound();
        this.Hit();
        this.ShowExplosion();
        this.ShowDecal();
    Label_003A:
        return;
    }

    public override void Hit()
    {
        this.CreateBombs();
        return;
    }

    public void SetBombs(int b)
    {
        this.bombs = b;
        return;
    }

    public void SetTargetPath(Creep target)
    {
        this.targetNode = target.GetCurrentNodeIndex();
        this.path = target.GetPath(0);
        return;
    }

    private void Start()
    {
        base.Init();
        GameSoundManager.PlayBombShootSound();
        return;
    }
}

